using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyChat
{
    public partial class MainForm : Form
    {
        bool _isConnected, _isRunning;
        object _loomListLock;
        Socket _client;
        ManualResetEvent _checkUserNameStopper = new ManualResetEvent(false);
        ManualResetEvent _registUserNameStopper = new ManualResetEvent(false);
        
        public MainForm()
        {
            InitializeComponent();
            _isConnected = false;
            _isRunning = false;
            _loomListLock = new object();
            _client = null;
            ClientInfo.CurrentRoomID = -1;
        }

        // 各有効状態
        void stateEnabled(bool state)
        {
            Invoke(new Action(() =>
            {
                userNameTextBox.Enabled = state;
                portNumTextBox.Enabled = state;
                ipAddressTextBox.Enabled = state;
                connectButton.Text = state ? "接続する" : "切断する";
                if (state)
                {
                    _client?.Close();
                    _client = null;
                    _checkUserNameStopper.Reset();
                    _registUserNameStopper.Reset();
                    _isConnected = false;
                    _isRunning = false;
                    SyncFlag.IsGetChatPooling = false;
                    SyncFlag.IsGetRoomInfoPooling = false;
                    resiveMessageTextBox.Clear();
                    roomListBox.Items.Clear();
                    roomMemberStatusListBox.Items.Clear();
                }
            }));
        }

        

        // 接続ボタン
        private void connectButton_Click(object sender, EventArgs e)
        {
            string ipAddr = ipAddressTextBox.Text, 
                   port = portNumTextBox.Text, 
                   userName = userNameTextBox.Text;
            if (!ConnectInfoFormat.Check(ipAddr, port, userName))
            {
                ShowReport(true, "接続設定を確認してください。(ユーザー名の場合は4~10文字です)");
                return;
            }

            if (_isRunning)
            {
                sendAsync(CreateCommand.DISSCONNECT(ClientInfo.UserName));
                stateEnabled(true);
                return;
            }

            _isRunning = true;
            stateEnabled(false);
            IPAddress ipaddress = IPAddress.Parse(ipAddressTextBox.Text);
            int portNum = Convert.ToInt32(portNumTextBox.Text);
            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            ClientInfo.UserName = userNameTextBox.Text;
            socket.BeginConnect(ipaddress, portNum, new AsyncCallback(connectCallBack), socket);
        }

        // 接続コールバック
        void connectCallBack(IAsyncResult result)
        {
            _checkUserNameStopper.Reset();
            _registUserNameStopper.Reset();

            try
            {
                _client = ((Socket)result.AsyncState);
                _client.EndConnect(result);
                ShowReport(false, "接続完了");
                _isConnected = true;
                sendAsync(CreateCommand.CHECK_USERNAME(userNameTextBox.Text)); // ユーザー名の重複を確認
                _checkUserNameStopper.WaitOne();
                if (_client == null)
                {
                    stateEnabled(true);
                    return;
                }
                sendAsync(CreateCommand.REGIST_USERNAME(userNameTextBox.Text)); // ユーザー名をサーバーへ登録
                _registUserNameStopper.WaitOne();
                GetRoomInfoPooling(); // 部屋情報常時取得
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                stateEnabled(true);
            }
        }

        // メッセージ送信ボタン
        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            if (!_isConnected) return;
            if (!SyncFlag.IsInRoom) return;
            sendAsync(CreateCommand.SEND_MESSAGE(userNameTextBox.Text,
                ClientInfo.CurrentRoomID.ToString(),
                sendMessageTextBox.Text));
            Thread.Sleep(50);
            resiveMessageTextBox.Clear();
            sendMessageTextBox.Clear();
        }

        // 受信
        void resiveAsync(ResiveDataInfo rDataInfo)
        {
            rDataInfo.Socket = _client;
            try
            {
                _client.BeginReceive(rDataInfo.Buffer
                , 0
                , ResiveDataInfo.BufferSize
                , SocketFlags.None,
                new AsyncCallback(resiveCallBack),
                rDataInfo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                stateEnabled(true);
            }
        }

        // 受信コールバック
        void resiveCallBack(IAsyncResult result)
        {
            ResiveDataInfo rDataInfo = null;
            try
            {
                rDataInfo = (ResiveDataInfo)result.AsyncState;
                _client = rDataInfo.Socket;
                int resiveSize = _client.EndReceive(result);
                if (resiveSize > 0)
                {
                    rDataInfo.ResiveData.Append(Encoding.UTF8.GetString(rDataInfo.Buffer, 0, resiveSize));
                    if (rDataInfo.ResiveData.ToString().IndexOf("END") < 0)
                    {
                        resiveAsync(rDataInfo);
                        return;
                    }
                    string resiveMessage = rDataInfo.ResiveData.ToString();
                    commandAnalyzer(resiveMessage);
                    rDataInfo.ResiveData.Clear();
                }
            }
            catch (Exception ex)
            {
                rDataInfo.Socket.Close();
                Debug.WriteLine(ex.Message);
                stateEnabled(true);
            }
        }

        // 受信コマンド解析実行
        void commandAnalyzer(string command)
        {
            string[] tokens;
            try { tokens = command.Split(','); }
            catch { throw; }

            if (command.StartsWith("RETURN_CHECK_USERNAME"))
            {
                int RESULT = 1;
                if (tokens[RESULT] == "FALSE")
                {
                    _client = null;
                    ShowReport(true, "このユーザー名は既に使用されています。");
                }
                _checkUserNameStopper.Set();
                return;
            }

            if (command.StartsWith("RETURN_REGIST_USERNAME"))
            {
                int RESULT = 1;
                if (tokens[RESULT] == "FALSE") 
                    ShowReport(true, "ユーザー名の登録に失敗しました。");
                _registUserNameStopper.Set();
                return;
            }

            if (command.StartsWith("RETURN_ROOM_INFO"))
            {
                RoomInfoList.ClearAll();
                Invoke(new Action(() => roomListBox.Items.Clear()));
                int index = 1;
                while (tokens[index] != "END")
                {
                    RoomInfo roomInfo = new RoomInfo();
                    roomInfo.ID = Convert.ToInt32(tokens[index++]); // ID
                    roomInfo.Name = tokens[index++]; // 部屋名
                    roomInfo.MemberNum = Convert.ToInt32(tokens[index++]); // 部屋人数
                    int memberNum = index + roomInfo.MemberNum;
                    while (index < memberNum) 
                        roomInfo.MemberNameList.Add(tokens[index++]); // メンバー名を追加していく
                    RoomInfoList.Add(roomInfo);
                    string listStr = $"部屋ID:{roomInfo.ID},部屋名:{roomInfo.Name},部屋人数:{roomInfo.MemberNum}";
                    Invoke(new Action(() =>
                    {
                        lock (_loomListLock) roomListBox.Items.Add(listStr);
                    }));
                }
                if(ClientInfo.CurrentRoomID >= 0)
                    SetRoomStatusInfo(RoomInfoList.Get(ClientInfo.CurrentRoomID));
                return;
            }

            if (command.StartsWith("RETURN_ENTER_ROOM")) 
            {
                int FLAG = 1;
                int ROOM_CHAT = 2;
                if (tokens[FLAG] != "TRUE")
                {
                    ShowReport(true, "入室に失敗しました。");
                    return;
                }
                Invoke(new Action(() => resiveMessageTextBox.Clear()));
                printResiveMessage(tokens[ROOM_CHAT]);
                return;
            }

            if (command.StartsWith("RETURN_CHAT"))
            {
                int FLAG = 1;
                int CHAT = 2;
                if(tokens[FLAG] == "FALSE")
                {
                    ShowReport(true, "チャットの取得に失敗");
                    return;
                }
                Invoke(new Action(() => resiveMessageTextBox.Text = tokens[CHAT]));
                return;
            }

            if (command.StartsWith("RETURN_OUT_ROOM"))
            {
                int FLAG = 1;
                if (tokens[FLAG] == "FALSE")
                    ShowReport(true, "退室に失敗しました。");
            }

            if (command.StartsWith("RETURN_CREATE_ROOM"))
            {
                int FLAG = 1;
                if (tokens[FLAG] == "FALSE")
                    ShowReport(true, "部屋の作成に失敗しました。");
            }
        }

        

        // 送信
        void sendAsync(string message)
        {
            try
            {
                byte[] sendMessage = Encoding.UTF8.GetBytes($"{message}");
                _client.BeginSend(sendMessage,
                    0,
                    sendMessage.Length,
                    SocketFlags.None,
                    new AsyncCallback(sendCallBack),
                    _client);
                ResiveDataInfo rDataInfo = new ResiveDataInfo();
                rDataInfo.Socket = _client;
                resiveAsync(rDataInfo);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex.Message);
                stateEnabled(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                stateEnabled(true);
            }
        }

        // 送信コールバック
        void sendCallBack(IAsyncResult result)
        {
            _client = (Socket)result.AsyncState;
            if(_client.EndSend(result) < 0)
            {
                ShowReport(true, "送信エラー");
            }
        }

        void printResiveMessage(string message)
        {
            Invoke(new Action(() => resiveMessageTextBox.Text += message + Escape.Return));
        }

        void ShowReport(bool warning, string message, string functionName = "")
        {
            Invoke(new Action(() => {
                reportLabel.ForeColor = warning ? Color.Red : Color.Black;
                reportLabel.Text = functionName + message;
            }));
        }

        // 部屋情報更新
        void SetRoomStatusInfo(RoomInfo roomInfo)
        {
            Invoke(new Action(() =>
            {
                roomNameStatusLabel.Text = roomInfo.Name;
                memberNumStatusLabel.Text = roomInfo.MemberNum.ToString(); // +1は自分
                roomMemberStatusListBox.Items.Clear();
                foreach (var memberName in roomInfo.MemberNameList)
                    roomMemberStatusListBox.Items.Add(memberName);
            }));    
        }

        // 入室ボタン
        private void roomInButton_Click(object sender, EventArgs e)
        {
            if (!_isConnected) return;

            SyncFlag.IsInRoom = true;
            sendAsync(CreateCommand.OUT_ROOM(userNameTextBox.Text, ClientInfo.CurrentRoomID.ToString()));
            int selectRoomIndex = Convert.ToInt32(selectedRoomIDLabel.Text);
            if (selectRoomIndex == -1)
            {
                ShowReport(true, "入室エラー");
                return;
            }
            int roomID = RoomInfoList.Get(selectRoomIndex).ID;
            sendAsync(CreateCommand.ENTER_ROOM(roomID.ToString(), userNameTextBox.Text));
            ClientInfo.CurrentRoomID = Convert.ToInt32(roomID);
            SetRoomStatusInfo(RoomInfoList.Get(selectRoomIndex));
            if(!SyncFlag.IsGetChatPooling)
            {
                GetChatPooling();
                return;
            }
        }

        // チャット常時受信
        void GetChatPooling()
        {
            SyncFlag.IsGetChatPooling = true;
            Task.Run(() => {
                while (SyncFlag.IsGetChatPooling && _client != null)
                {
                    try
                    {                        
                        sendAsync(CreateCommand.GET_CHAT(ClientInfo.UserName, ClientInfo.CurrentRoomID.ToString()));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        stateEnabled(true);
                        break;
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        // 部屋情報常時受信
        void GetRoomInfoPooling()
        {
            SyncFlag.IsGetRoomInfoPooling = true;
            Task.Run(() => {
                while (SyncFlag.IsGetRoomInfoPooling && _client != null)
                {
                    try
                    {
                        sendAsync(CreateCommand.GET_ROOM_INFO()); // 部屋情報取得
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        stateEnabled(true);
                        break;
                    }
                    Thread.Sleep(1000 * 3);
                }
            });
        }

        private void roomListBox_Click(object sender, EventArgs e)
        {
            if (roomListBox.SelectedIndex == -1) return;
            selectedRoomIDLabel.Text = roomListBox.SelectedIndex.ToString();
        }

        private void createRoomButton_Click(object sender, EventArgs e)
        {
            if (roomNameTextBox.Text.Length <= 0) return;
            sendAsync(CreateCommand.CREATE_ROOM(roomNameTextBox.Text));
        }
    }
    
}

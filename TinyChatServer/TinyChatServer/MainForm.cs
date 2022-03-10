using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TinyChatServer
{
    public partial class MainForm : Form
    {
        ManualResetEvent _acceptStopper = new ManualResetEvent(false);
        ManualResetEvent _resiveStopper = new ManualResetEvent(false);
        public MainForm()
        {
            InitializeComponent();
            for(int id = 0; id < 2; id++)
                RoomList.Add(id, new Room($"みんなの部屋{id}", id, $"server{id}"));
        }

        // 開始ボタンイベント
        private void startButton_Click(object sender, EventArgs e)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, Convert.ToInt32(portNumTextBox.Text));
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(endpoint);
            Task.Run(() =>
            {
                while (true)
                {
                    server.Listen(5);
                    _acceptStopper.Reset();
                    server.BeginAccept(new AsyncCallback(acceptCallBack), server);
                    _acceptStopper.WaitOne();
                }
            });
        }

        // 接続要求受け入れコールバック
        void acceptCallBack(IAsyncResult result)
        {
            Socket tcpClient = null;
            _acceptStopper.Set();
            Invoke(new Action(() => writeLog("接続が完了しました。")));
            try
            {
                tcpClient = ((Socket)result.AsyncState).EndAccept(result);
            }
            catch (Exception ex)
            {
                writeLog(ex.Message);
            }
            resiveAsync(tcpClient, new ResiveDataInfo());
        }

        // 受信
        void resiveAsync(Socket tcpClient, ResiveDataInfo rDataInfo)
        {
            rDataInfo.Socket = tcpClient;
            try
            {
                tcpClient.BeginReceive(rDataInfo.ResiveBuffer,
                        0,
                        ResiveDataInfo.ResiveBufferSize,
                        SocketFlags.None,
                        new AsyncCallback(resiveCallBack),
                        rDataInfo);
            }
            catch (Exception ex)
            {
                writeLog(ex.Message);
                rDataInfo.Socket.Close();
            }
        }

        // 受信コールバック
        void resiveCallBack(IAsyncResult result)
        {
            ResiveDataInfo rDataInfo = null;
            try
            {
                rDataInfo = (ResiveDataInfo)result.AsyncState;
                int readByte = rDataInfo.Socket.EndReceive(result);
                if (readByte > 0)
                {
                    rDataInfo.ResiveDate.Append(Encoding.UTF8.GetString(rDataInfo.ResiveBuffer, 0, readByte));
                    if (rDataInfo.ResiveDate.ToString().IndexOf("END") < 0)
                    {
                        resiveAsync(rDataInfo.Socket, rDataInfo);
                        return;
                    }
                    string resiveCommand = rDataInfo.ResiveDate.ToString();
                    writeLog(resiveCommand);
                    string responseCommand = CommandAnalyzer.Analysis(resiveCommand);
                    rDataInfo.ResiveDate.Clear();
                    sendAsync(rDataInfo.Socket, responseCommand);
                }
                // 受信処理完了後、再び受信を開始
                resiveAsync(rDataInfo.Socket, rDataInfo);
            }
            catch(Exception ex)
            {
                rDataInfo.Socket.Close();
                writeLog(ex.Message);
            }
        }

        void sendAsync(Socket tcpClient, string message)
        {
            writeLog(message);
            try
            {
                byte[] sendMessage = Encoding.UTF8.GetBytes(message);
                tcpClient.BeginSend(sendMessage,
                    0,
                    sendMessage.Length,
                    SocketFlags.None,
                    new AsyncCallback(sendAsyncCallBack),
                    tcpClient);
            }
            catch (Exception ex)
            {
                tcpClient.Close();
                writeLog(ex.Message);
            }
        }

        void sendAsyncCallBack(IAsyncResult result)
        {
            Socket tcpClient = null;
            try
            {
                tcpClient = (Socket)result.AsyncState;
                if (tcpClient.EndSend(result) < 0)
                {
                    throw new Exception("送信エラー");
                }
            }
            catch (Exception ex)
            {
                writeLog(ex.Message);
                tcpClient.Close();
            }
        }

        void writeLog(string log)
        {
            Invoke(new Action(() => logTextBox.Text += log + Escape.Return));
        }
    }
}

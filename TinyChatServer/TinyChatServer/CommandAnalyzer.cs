using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinyChatServer
{
    static class CommandAnalyzer
    {
        public static string Analysis(string commad)
        {
            string[] tokens = null;
            try { tokens = commad.Split(','); }
            catch { throw; }
            if (commad.StartsWith("CHECK_USERNAME"))
            {
                const int USER_NAME = 1;
                if (!LoginUserName.IsExistUserName(tokens[USER_NAME]))
                    return CreateCommand.RETURN_CHECK_USERNAME(true);
                return CreateCommand.RETURN_CHECK_USERNAME(false);
            }
            if (commad.StartsWith("REGIST_USERNAME"))
            {
                const int USER_NAME = 1;
                LoginUserName.Add(tokens[USER_NAME]);
                return CreateCommand.RETURN_REGIST_USERNAME(true);
            }
            if (commad.StartsWith("GET_ROOM_INFO"))
            {
                return CreateCommand.RETURN_ROOM_INFO(RoomList.GetCommandInfo());
            }
            if (commad.StartsWith("ENTER_ROOM"))
            {
                int ROOM_ID = 1;
                int USER_NAME = 2;
                tokens = commad.Split(',');
                RoomList.AddMember(Convert.ToInt32(tokens[ROOM_ID]), tokens[USER_NAME]);
                return CreateCommand.RETURN_ENTER_ROOM(true, tokens[ROOM_ID]);
            }
            if (commad.StartsWith("SEND_MESSAGE"))
            {
                int USER_NAME = 1;
                int ROOM_ID = 2;
                int MESSAGE = 3;
                RoomList.SetChat(Convert.ToInt32(tokens[ROOM_ID]), tokens[USER_NAME], tokens[MESSAGE]);
                return CreateCommand.RETURN_SEND_MESSAGE(true);
            }
            if (commad.StartsWith("GET_CHAT"))
            {
                //int USER_NAME = 1;
                int ROOM_ID = 2;
                return CreateCommand.RETURN_GET_CHAT(true, RoomList.GetChat(Convert.ToInt32(tokens[ROOM_ID])));
            }
            if (commad.StartsWith("OUT_ROOM"))
            {
                int USER_NAME = 1;
                int ROOM_ID = 2;
                RoomList.RemoveMember(Convert.ToInt32(tokens[ROOM_ID]), tokens[USER_NAME]);
                return CreateCommand.RETURN_OUT_ROOM(true);
            }

            // CREATE_ROOM,部屋名,END
            if (commad.StartsWith("CREATE_ROOM"))
            {
                int roomName = 1;
                int newRoomID = RoomList.GetCount();
                RoomList.Add(newRoomID, new Room(tokens[roomName], newRoomID));
                return CreateCommand.RETURN_CREATE_ROOM(true);
            }

            if (commad.StartsWith("DISSCONNECT"))
            {
                int memberName = 1;
                List<Room> roomList = RoomList.GetRoomList();
                foreach(var room in roomList)
                    RoomList.RemoveMember(room.ID, tokens[memberName]);
            }
            return null;
        }
    }
}

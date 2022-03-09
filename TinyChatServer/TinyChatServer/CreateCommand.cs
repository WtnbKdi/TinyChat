using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChatServer
{
    static class CreateCommand
    {
        public static string RETURN_CHECK_USERNAME(bool param)
        {
            return $"RETURN_CHECK_USERNAME,{param.ToString().ToUpper()},END";
        }

        public static string RETURN_REGIST_USERNAME(bool param)
        {
            return $"RETURN_REGIST_USERNAME,{param.ToString().ToUpper()},END";
        }

        public static string RETURN_ROOM_INFO(string roomInfo)
        {
            return $"RETURN_ROOM_INFO,{roomInfo}END";
        }

        public static string RETURN_ENTER_ROOM(bool param, string roomID)
        {
            return $"RETURN_ENTER_ROOM,{param.ToString().ToUpper()},{RoomList.GetChat(Convert.ToInt32(roomID))},END";
        }

        public static string RETURN_SEND_MESSAGE(bool param)
        {
            return $"RETURN_SEND_MESSAGE,{param.ToString().ToUpper()},END";
        }

        public static string RETURN_GET_CHAT(bool param, string chat)
        {
            return $"RETURN_CHAT,{param.ToString().ToUpper()},{chat},END";
        }

        public static string RETURN_OUT_ROOM(bool param)
        {
            return $"RETURN_ROOM_OUT,{param.ToString().ToUpper()},END";
        }

        public static string RETURN_CREATE_ROOM(bool param)
        {
            return $"RETURN_CREATE_ROOM,{param.ToString().ToUpper()},END";
        }
    }
}

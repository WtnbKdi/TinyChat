using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat
{
    static class CreateCommand
    {
        public static string CHECK_USERNAME(string userName)
        {
            return $"CHECK_USERNAME,{userName},END ";
        }

        public static string REGIST_USERNAME(string userName)
        {
            return $"REGIST_USERNAME,{userName},END";
        }

        public static string GET_ROOM_INFO()
        {
            return "GET_ROOM_INFO,END";
        }

        public static string ENTER_ROOM(string roomID, string userName)
        {
            return $"ENTER_ROOM,{roomID},{userName},END ";
        }

        public static string SEND_MESSAGE(string userName, string roomID, string message)
        {
            return $"SEND_MESSAGE,{userName},{roomID},{message},END";
        }

        public static string GET_CHAT(string userName, string roomID)
        {
            return $"GET_CHAT,{userName},{roomID},END";
        }

        public static string OUT_ROOM(string userName, string roomID)
        {
            return $"OUT_ROOM,{userName},{roomID},END";
        }

        // CREATE_ROOM,部屋名,END
        public static string CREATE_ROOM(string roomName)
        {
            return $"CREATE_ROOM,{roomName},END";
        }
    }
}

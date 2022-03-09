using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChatServer
{
    static class RoomList
    {
        static Dictionary<int, Room> _roomList = new Dictionary<int, Room>();
        public static void Add(int id, Room room)
        {
            _roomList.Add(id, room);
        }

        // (部屋ID,部屋名,)+の文字列を返す
        public static string GetCommandInfo()
        {
            StringBuilder info = new StringBuilder();
            foreach (var element in _roomList)
            {
                info.Append(element.Key); // 部屋ID
                info.Append(",");
                info.Append(element.Value.Name); // 部屋名
                info.Append(",");
                info.Append(element.Value.MemberNameList.Count); // 人数
                info.Append(",");
                foreach(var memberName in element.Value.MemberNameList) // メンバー名
                {
                    info.Append(memberName);
                    info.Append(",");
                }
            }
            return info.ToString();
        }

        public static string GetChat(int id)
        {
            return _roomList[id].Chat;
        }

        public static void SetChat(int id, string userName, string chat)
        {
            _roomList[id].Chat = $"{DateTime.Now} : {userName} > {chat}\r\n";
            Debug.WriteLine(_roomList[id].Chat);
        }

        public static void AddMember(int id, string memberName)
        {
            _roomList[id].MemberNameList.Add(memberName);
        }

        public static void RemoveMember(int id, string memberName)
        {
            if (id == -1) return;
            _roomList[id].MemberNameList.Remove(memberName);
        }

        public static int GetCount()
        {
            return _roomList.Count;
        }
    }
}

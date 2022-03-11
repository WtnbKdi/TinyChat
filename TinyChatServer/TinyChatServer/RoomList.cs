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
        static object _roomListLock = new object();
        public static void Add(int id, Room room)
        {
            lock(_roomListLock) _roomList.Add(id, room);
        }

        // (部屋ID,部屋名,)+の文字列を返す
        public static string GetCommandInfo()
        {
            StringBuilder info = new StringBuilder();
            lock (_roomListLock)
            {
                foreach (var element in _roomList)
                {
                    info.Append(element.Key); // 部屋ID
                    info.Append(",");
                    info.Append(element.Value.Name); // 部屋名
                    info.Append(",");
                    info.Append(element.Value.MemberNameList.Count); // 人数
                    info.Append(",");
                    foreach (var memberName in element.Value.MemberNameList) // メンバー名
                    {
                        info.Append(memberName);
                        info.Append(",");
                    }
                }
            }
            return info.ToString();
        }

        public static string GetChat(int id)
        {
            lock (_roomListLock)
                return _roomList[id].Chat;
        }

        public static void AddChat(int id, string userName, string chat)
        {
            lock (_roomListLock)
            {
                _roomList[id].Chat = $"{DateTime.Now} : {userName} > {chat}{Escape.Return}";
                Debug.WriteLine(_roomList[id].Chat);
            }
        }

        public static void AddMember(int id, string memberName)
        {
            lock (_roomListLock)
                _roomList[id].MemberNameList.Add(memberName);
        }

        public static void RemoveMember(int id, string memberName)
        {
            if (id == -1) return;
            lock (_roomListLock)
                _roomList[id].MemberNameList.Remove(memberName);
        }

        public static int GetCount()
        {
            lock (_roomListLock)
                return _roomList.Count;
        }

        public static List<Room> GetRoomList()
        {
            List<Room> tmpRoomList = new List<Room>();
            lock (_roomListLock)
                foreach (var room in _roomList)
                    tmpRoomList.Add(room.Value);
            return tmpRoomList;
        }
    }
}

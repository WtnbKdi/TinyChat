using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat
{
    static class RoomInfoList
    {
        static List<RoomInfo> _roomInfoList = new List<RoomInfo>();

        public static void Add(RoomInfo roomInfo)
        {
            _roomInfoList.Add(roomInfo);
        }

        public static RoomInfo Get(int roomID)
        {
            return _roomInfoList[roomID];
        }

        public static void RemoveMemberName(int roomID, string memberName)
        {
            _roomInfoList[roomID].MemberNameList.Remove(memberName);
        }

        public static void ClearAll()
        {
            _roomInfoList.Clear();
        }
        

    }
}

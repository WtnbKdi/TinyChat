using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat
{
    static class ClientInfo
    {
        static object _lock_currentRoomID = new object();
        static int _currentRoomID = -1;
        public static int CurrentRoomID 
        { 
            get { lock(_lock_currentRoomID) return _currentRoomID; } 
            set { lock (_lock_currentRoomID) _currentRoomID = value; }
        }
        public static string UserName { get; set; }
    }
}

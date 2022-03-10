using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat
{
    static class SyncFlag
    {
        static bool _isGetChatPooling, _isGetRoomInfoPooling;
        static object _isGetChatPooling_lock = new object();
        static object _isGetRoomInfoPooling_lock = new object();
        public static bool IsGetChatPooling 
        { 
            get { return _isGetChatPooling; } 
            set { _isGetChatPooling = value; } 
        }
        public static bool IsGetRoomInfoPooling
        {
            get { return _isGetRoomInfoPooling; }
            set { _isGetRoomInfoPooling = value; }
        }
    }
}

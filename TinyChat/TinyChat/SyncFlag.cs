using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat
{
    static class SyncFlag
    {
        static bool _isGetChatPooling = false, _isGetRoomInfoPooling = false, _isInRoom = false;
        static object _isGetChatPooling_lock = new object();
        static object _isGetRoomInfoPooling_lock = new object();
        static object _isInRoom_lock = new object();

        public static bool IsGetChatPooling 
        { 
            get 
            { 
                lock(_isGetChatPooling_lock)
                    return _isGetChatPooling; 
            } 
            set 
            {
                lock (_isGetChatPooling_lock)
                    _isGetChatPooling = value; 
            } 
        }
        public static bool IsGetRoomInfoPooling
        {
            get 
            { 
                lock(_isGetRoomInfoPooling_lock)
                    return _isGetRoomInfoPooling; 
            }
            set 
            {
                lock (_isGetRoomInfoPooling_lock)
                    _isGetRoomInfoPooling = value; 
            }
        }
        public static bool IsInRoom
        {
            get 
            { 
                lock(_isInRoom_lock)
                    return _isInRoom; 
            }
            set 
            {
                lock (_isInRoom_lock)
                    _isInRoom = value; 
            }
        }
    }
}

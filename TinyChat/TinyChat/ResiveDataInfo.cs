using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat
{
    class ResiveDataInfo
    {
        public const int BufferSize = 1024;
        public byte[] Buffer = new byte[BufferSize];
        public StringBuilder ResiveData = new StringBuilder();
        public Socket Socket = null;
    }
}

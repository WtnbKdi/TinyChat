using System.Net.Sockets;
using System.Text;

namespace TinyChatServer
{
    class ResiveDataInfo
    {
        public const int ResiveBufferSize = 1024;
        public byte[] ResiveBuffer = new byte[ResiveBufferSize];
        public StringBuilder ResiveDate = new StringBuilder();
        public Socket Socket = null;
    }
}

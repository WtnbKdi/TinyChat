using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TinyChat
{
    static class ConnectInfoFormat
    {
        static Regex _ipAddrReg = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        static Regex _userNameReg = new Regex(@"^\w{4,10}$");
        public static bool Check(string ipAddr, string port, string userName)
        {
            return checkIpAddress(ipAddr) && checkPort(port) && checkUserName(userName);
        }

        static bool checkIpAddress(string ipAddr)
        {
            return _ipAddrReg.IsMatch(ipAddr);
        }

        static bool checkPort(string port)
        {
            int convertedPort;
            if (!Int32.TryParse(port, out convertedPort)) return false;
            return 0 <= convertedPort && convertedPort <= 65535;
        }

        static bool checkUserName(string userName)
        {
            return _userNameReg.IsMatch(userName);
        }
    }
}

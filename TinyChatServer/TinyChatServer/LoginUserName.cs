using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChatServer
{
    static class LoginUserName
    {
        static Dictionary<string, string> _userNameList = new Dictionary<string, string>();

        // ユーザー名が存在するか
        public static bool IsExistUserName(string userName)
        {
            return _userNameList.ContainsKey(userName);
        }

        // ユーザー名追加
        public static bool Add(string userName)
        {
            if (IsExistUserName(userName)) return false;
            _userNameList.Add(userName, userName);
            return true;
        }

        // ユーザー名削除
        public static bool Delete(string userName)
        {
            return _userNameList.Remove(userName);
        }
    }
}

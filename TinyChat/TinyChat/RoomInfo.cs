using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat
{
    class RoomInfo
    {
        List<string> _memberNameList = new List<string>();
        public int ID { get; set; }
        public string Name { get; set; }
        public int MemberNum { get; set; }
        public List<string> MemberNameList { get { return _memberNameList; } }
        public void AddMemberName(string name)
        {
            _memberNameList.Add(name);
            this.MemberNum = _memberNameList.Count;
        }
        public bool RemoveMemberName(string name)
        {
            return _memberNameList.Remove(name);
        }
    }
}

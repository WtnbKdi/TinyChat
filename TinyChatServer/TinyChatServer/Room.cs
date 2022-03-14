using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChatServer
{
    class Room
    {
        List<string> _memberNameList = new List<string>();
        StringBuilder _chat = new StringBuilder();
        public string Name { get; private set; }
        public string Chat { get { return _chat.ToString(); } set { _chat.Append(value); } }
        public int ID { get; private set; }
        public List<string> MemberNameList { get { return _memberNameList; } }

        public Room() { }
        public Room(string name, int id) 
        {
            this.Name = name;
            this.ID = id;
        }

        public Room(string name, int id, string memberName) : this(name, id)
        {
            _memberNameList.Add(memberName);
        }
    }
}

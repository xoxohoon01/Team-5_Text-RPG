using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Message
    {
        public int y;
        public string content;

        public Message(string _content)
        {
            content = _content;
            y = 0;
        }
    }
}

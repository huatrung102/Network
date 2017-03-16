using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.DefineAttribute
{
    public class DisplayTextEnum : Attribute
    {
        public DisplayTextEnum(string Text)
        {
            this.text = Text;
        }

       
        private string text;


        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class StringEventArgs : EventArgs
    {
        public string text { get; private set; }

        public StringEventArgs(string text)
            : base()
        {
            this.text = text;
        }
    }
}

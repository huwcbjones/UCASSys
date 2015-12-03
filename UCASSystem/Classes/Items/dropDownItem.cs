using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys.Classes.Items
{
    public class dropDownItem
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public dropDownItem(int ID, string value = "")
        {
            this._id = ID;
            this._text = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace UCASSys.Classes.Items
{
    public class NotificationItem
    {
        #region Properties
        private string msgTitle;
        public string Title
        {
            get { return msgTitle; }
            set
            {
                if (value.Length == 0 || value == null)
                {
                    msgTitle = "UCAS System";
                }
                else
                {
                    msgTitle = "UCAS System: " + value;
                }
            }
        }

        private string msg;
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }

        private ToolTipIcon ico;
        public ToolTipIcon Icon
        {
            get { return ico; }
            set { ico = value; }
        }

        private object handleData;
        public object Data
        {
            get { return handleData; }
            set { handleData = value; }
        }

        private SystemSound soundFile = null;
        public SystemSound Sound
        {
            get { return soundFile; }
            set { soundFile = value; }
        }


        private bool saveAsLastNotification = true;
        public bool SaveAsLast
        {
            get { return saveAsLastNotification; }
            set { saveAsLastNotification = value; }
        }
        #endregion

        public NotificationItem(string title = "", string message = "", ToolTipIcon icon  = ToolTipIcon.None, object data = null, SystemSound sound = null, bool saveAsLast = true)
        {
            this.Title = title;
            this.msg = message;
            this.ico = icon;
            this.handleData = data;
            this.soundFile = sound;
            this.saveAsLastNotification = saveAsLast;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys.Classes
{
    public class StatusMessage
    {
        #region Properties
        private string msg;
        public String Message
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }

        private bool success;
        public bool is_Success
        {
            get
            {
                return success;
            }
            set
            {
                success = value;
            }
        }

        private object additional_data;
        public object Data
        {
            get
            {
                return additional_data;
            }
            set
            {
                additional_data = value;
            }
        }
        #endregion

        public StatusMessage(bool is_success = true, string message = null, object data = null)
        {
            this.msg = message;
            this.is_Success = is_success;
            this.additional_data = data;
        }

        public static implicit operator bool(StatusMessage msg)
        {
            return msg.is_Success;
        }

        public override string ToString()
        {
            if (additional_data == null){
                return "Msg: " + msg + " | Success: " + success.ToString() + " Data: {NULL}";
            }else{
                return "Msg: " + msg + " | Success: " + success.ToString() + " Data: " + additional_data.ToString();
            }
         }
    }
}

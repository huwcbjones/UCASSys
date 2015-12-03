using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys.Classes.Items
{
    public class ConfigItem
    {
        #region "Properties"

        private string setting_id;
        public string ID
        {
            get { return setting_id; }
            set { setting_id = value; }
        }

        private object vlu;
        public object Value
        {
            get { return vlu; }
            set { vlu = value; }
        }
        private string desc;
        public string Description
        {
            get { return desc; }
            set { desc = value; }
        }
        #endregion

        public ConfigItem(string setting = null, object value = null, string description = null)
        {
            this.setting_id = setting;
            this.vlu = value;
            this.desc = description;
        }

        public override string ToString()
        {
            string value = "";
            string description = "";
            if ((this.vlu != null))
            {
                value = (string)vlu;
            }

            if ((this.desc != null))
            {
                description = this.desc;
            }

            return this.setting_id + ": " + value + " (" + description + ")";
        }
    }
}

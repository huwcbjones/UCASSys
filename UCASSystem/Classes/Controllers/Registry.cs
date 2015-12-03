using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg = Microsoft.Win32;

namespace UCASSys.Classes.Controllers
{
    public class Registry
    {
        private String appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        private String appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private Reg.RegistryKey reg;

        public Registry()
        {
            try
            {
                reg = Reg.Registry.CurrentUser.OpenSubKey("Software", true);
                reg.CreateSubKey(appName);
                reg = reg.OpenSubKey(appName, true);

                reg.CreateSubKey(appVersion);
                reg = reg.OpenSubKey(appVersion, true);
            }
            catch (Exception ex)
            {
                using (TaskDialog dialog = new TaskDialog())
                {
                    Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);

                    dialog.Title = "UCAS System Error";
                    dialog.Subtitle = "Registry Error";
                    dialog.Text = "UCAS System failed to load settings from the registry.";
                    dialog.DetailsText = ex.ToString();
                    dialog.ExpansionMode = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogExpandedDetailsLocation.ExpandFooter;
                    dialog.Show();
                }
                Environment.Exit(0);
            }
        }

        public StatusMessage writeKey(String key, object value, Reg.RegistryValueKind type)
        {
            StatusMessage message = new StatusMessage();
            try
            {
                reg.SetValue(key, value, type);
            }
            catch (Exception ex)
            {
                Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                message.is_Success = false;
                message.Message = ex.Message;
            }
            return message;
        }

        public StatusMessage getKey(string key)
        {
            Reg.RegistryKey regKey = this.reg;
            StatusMessage message = new StatusMessage();
            if (key.Contains("/"))
            {
                regKey = getSubkey(key);
                key = key.Split('/')[key.Split('/').Count() - 1];
            }
            if (regKey.GetValue(key) != null)
            {
                try
                {
                    message.Data = regKey.GetValue(key);
                    message.is_Success = true;
                }
                catch (Exception ex)
                {
                    message.is_Success = false;
                    message.Message = ex.Message;
                    Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                }
            }
            else
            {
                message.is_Success = false;
            }
            return message;
        }

        private Reg.RegistryKey getSubkey(string subkey)
        {
            Reg.RegistryKey newKey = this.reg;
            String[] keyToOpen = subkey.Split('/');
            foreach (string skey in keyToOpen)
            {
                if(newKey.GetSubKeyNames().Contains(skey)){
                    newKey = reg.OpenSubKey(skey, true);
                }
            }
            return newKey;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using WinAPI = Microsoft.WindowsAPICodePack;

namespace UCASSys.Classes
{
    class TaskDialog : IDisposable
    {
        #region Properties
        public WinAPI.Dialogs.TaskDialog taskDialog = new WinAPI.Dialogs.TaskDialog();
        
        public Boolean is_open = false;
        public WinAPI.Dialogs.TaskDialogStandardIcon Icon
        {
            get
            {
                return taskDialog.Icon;
            }
            set
            {
                taskDialog.Icon = value;
            }
        }
        public String Title
        {
            get
            {
                return taskDialog.Caption;
            }
            set
            {
                if (!is_open)
                {
                    taskDialog.Caption = value;
                }
            }
        }
        public String Subtitle
        {
            get
            {
                return taskDialog.InstructionText;
            }
            set
            {
                taskDialog.InstructionText = value;
            }
        }
        public String Text
        {
            get
            {
                return taskDialog.Text;
            }
            set
            {
                taskDialog.Text = value;
            }
        }
        public WinAPI.Dialogs.TaskDialogExpandedDetailsLocation ExpansionMode
        {
            get
            {
                return taskDialog.ExpansionMode;
            }
            set
            {
                taskDialog.ExpansionMode = value;
            }
        }
        public WinAPI.Dialogs.TaskDialogStandardButtons StandardButtons
        {
            get
            {
                return taskDialog.StandardButtons;
            }
            set
            {
                taskDialog.StandardButtons = value;
            }
        }
        public String DetailsText
        {
            get
            {
                return taskDialog.DetailsExpandedText;
            }
            set
            {
                if (value != null
                    && value.Length > 0)
                {
                    taskDialog.DetailsExpandedText = value;
                    taskDialog.ExpansionMode = WinAPI.Dialogs.TaskDialogExpandedDetailsLocation.ExpandFooter;
                }
                else
                {
                    taskDialog.ExpansionMode = WinAPI.Dialogs.TaskDialogExpandedDetailsLocation.Hide;
                }
            }
        }

        public SystemSound ShowSound = SystemSounds.Asterisk;
        #endregion

        public TaskDialog(IntPtr windowHandle = default(IntPtr))
        {
            taskDialog.StartupLocation = WinAPI.Dialogs.TaskDialogStartupLocation.CenterOwner;
            taskDialog.Opened += taskDialog_Opened;
            taskDialog.Closing += taskDialog_Closing;

            if (windowHandle != default(IntPtr))
            {
                taskDialog.OwnerWindowHandle = windowHandle;
            }
        }

        void taskDialog_Opened(object sender, EventArgs e)
        {
            ShowSound.Play();
            is_open = true;
            taskDialog.Icon = taskDialog.Icon;
        }
        void taskDialog_Closing(object sender, WinAPI.Dialogs.TaskDialogClosingEventArgs e)
        {
            is_open = false;
        }

        public void Dispose()
        {
            taskDialog.Dispose();
        }

        public WinAPI.Dialogs.TaskDialogResult Show()
        {
            try
            {
                return taskDialog.Show();
            }
            catch (Exception ex)
            {
                Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "UCAS System Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return WinAPI.Dialogs.TaskDialogResult.None;
        }

        void Close()
        {
            taskDialog.Close();
        }

        #region Shortcut Boxes

        /// <summary>
        /// Sets icon to Info, adds and OK button.
        /// </summary>
        public void infoBox()
        {
            taskDialog.Icon = WinAPI.Dialogs.TaskDialogStandardIcon.Information;
            taskDialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.Ok;
        }

        /// <summary>
        /// Sets the icon to Error, adds an OK button.
        /// </summary>
        public void errorBox()
        {
            ShowSound = SystemSounds.Exclamation;
            taskDialog.Icon = WinAPI.Dialogs.TaskDialogStandardIcon.Error;
            taskDialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.Ok;
        }

        /// <summary>
        /// Sets the icon to Auth, adds an OK button.
        /// </summary>
        public void authBox()
        {
            taskDialog.Icon = WinAPI.Dialogs.TaskDialogStandardIcon.Shield;
            taskDialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.Ok;
        }

        /// <summary>
        /// Sets the icon to Warning, adds Canel/OK buttons.
        /// </summary>
        public void confirmBox()
        {
            ShowSound = SystemSounds.Exclamation;
            taskDialog.Icon = WinAPI.Dialogs.TaskDialogStandardIcon.Warning;
            taskDialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.Cancel | WinAPI.Dialogs.TaskDialogStandardButtons.Ok;
        }
        #endregion
    }
}

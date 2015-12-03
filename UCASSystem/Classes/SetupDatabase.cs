using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registry = Microsoft.Win32.Registry;
using RegistryKey = Microsoft.Win32.RegistryKey;
using Screen = System.Windows.Forms.Screen;
using SetupForms = UCASSys.Forms.Setup;
using WinAPI = Microsoft.WindowsAPICodePack;

namespace UCASSys.Classes
{
    class SetupDatabase
    {

        private string databaseLocation;

        private string username;
        private string firstName;
        private string lastName;
        private string email;
        private string password;

        protected TaskDialog setupDialog = new TaskDialog();

        public static Boolean checkResolution()
        {
            TaskDialog dialog = new TaskDialog();
            if (Screen.PrimaryScreen.Bounds.Width < 800 | Screen.PrimaryScreen.Bounds.Height < 600)
            {
                dialog.Title = "UCAS System Error";
                dialog.Icon = WinAPI.Dialogs.TaskDialogStandardIcon.Error;
                dialog.Subtitle = "UCAS System cannot be used on a resolution smaller than 800x600";
                dialog.Text = "UCAS System will now exit.";
                dialog.DetailsText = "If this is your computer, please increase your resolution to at least 800x600, otherwise ask your system administrator to.";
                dialog.ExpansionMode = WinAPI.Dialogs.TaskDialogExpandedDetailsLocation.ExpandFooter;
                dialog.taskDialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.Ok;
                dialog.Show();
                dialog.Dispose();
                return false;
            }
            else if (Screen.PrimaryScreen.Bounds.Width == 800 | Screen.PrimaryScreen.Bounds.Height == 600)
            {
                dialog.Title = "UCAS System Warning";
                dialog.Icon = WinAPI.Dialogs.TaskDialogStandardIcon.Warning;
                dialog.Subtitle = "Using UCAS System on a small screen resolution is not recommended.";
                dialog.Text = "Continue to use UCAS System?";
                dialog.DetailsText = "If this is your computer, we recommend that you increase your resolution to at least 1024x768, otherwise please ask your system administrator to.";
                dialog.taskDialog.ExpansionMode = WinAPI.Dialogs.TaskDialogExpandedDetailsLocation.ExpandContent;
                dialog.taskDialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.No | WinAPI.Dialogs.TaskDialogStandardButtons.Yes;

                if (dialog.Show() == WinAPI.Dialogs.TaskDialogResult.No)
                {
                    dialog.Dispose();
                    return false;
                }
                else { dialog.Dispose(); }
            }
            return true;
        }

        public static Boolean is_openDatabase()
        {
            if (Program.regCtrl.getKey("database"))
            {
                return (Program.regCtrl.getKey("database").Data.ToString() != "");
            }
            return false;
        }

        #region Setup Database
        public bool setupNew()
        {
            return get_DatabaseLocation();
        }
        void quit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        void databaseBrowser_clickHandler(object sender, EventArgs e)
        {
            get_DatabaseLocation();
        }

        bool get_DatabaseLocation()
        {
            WinAPI.Dialogs.CommonSaveFileDialog databaseBrowse = new WinAPI.Dialogs.CommonSaveFileDialog();
            databaseBrowse.AllowPropertyEditing = false;
            databaseBrowse.EnsureFileExists = false;
            databaseBrowse.EnsurePathExists = true;
            databaseBrowse.DefaultFileName = "database";
            databaseBrowse.DefaultExtension = "usys";
            databaseBrowse.Filters.Add(new WinAPI.Dialogs.CommonFileDialogFilter("UCAS System Database", "usys"));
            databaseBrowse.Filters.Add(new WinAPI.Dialogs.CommonFileDialogFilter("UCAS System Compressed Database", "usysx"));
            databaseBrowse.Filters.Add(new WinAPI.Dialogs.CommonFileDialogFilter("Microsoft Access Database", "accdb"));
            databaseBrowse.CreatePrompt = false;
            databaseBrowse.Title = "Save Database";
            if (databaseBrowse.ShowDialog() != WinAPI.Dialogs.CommonFileDialogResult.Ok)
            {
                return false;
            }
            this.databaseLocation = databaseBrowse.FileName;
            return get_Details();
        }

        bool get_Details()
        {
            SetupForms.details userDetails = new SetupForms.details();
            userDetails.text_username.Text = this.username;
            userDetails.text_firstName.Text = this.firstName;
            userDetails.text_lastName.Text = this.lastName;
            userDetails.text_email.Text = this.email;

            if (userDetails.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                this.username = userDetails.text_username.Text;
                this.firstName = userDetails.text_firstName.Text;
                this.lastName = userDetails.text_lastName.Text;
                this.email = userDetails.text_email.Text;

                return get_Password();
            }
            else
            {
                return get_DatabaseLocation();
            }
        }

        bool get_Password()
        {
            SetupForms.password userPassword = new SetupForms.password();

            if (userPassword.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                this.password = userPassword.text_new.Text;

                return confirm();
            }
            else
            {
                return get_Details();
            }
        }

        bool confirm()
        {
            SetupForms.confirm confirmation = new SetupForms.confirm();
            confirmation.text_database.Text = this.databaseLocation;
            confirmation.text_username.Text = this.username;
            confirmation.text_firstName.Text = this.firstName;
            confirmation.text_lastName.Text = this.lastName;
            confirmation.text_email.Text = this.email;
            confirmation.text_password.Text = this.password;

            if (confirmation.ShowDialog() != System.Windows.Forms.DialogResult.Yes)
            {
                return get_DatabaseLocation();
            }

            String salt = Controllers.User.random_hash();
            String db_password = Controllers.User.password_hash(this.password, salt) + ":" + salt;

            //TODO: Fix usysx handling
            if (Path.GetExtension(this.databaseLocation) == ".usysx")
            {
                File.Copy("Resources\\default.usys", this.databaseLocation + ".tmp", true);
                Database.Manager.compress(this.databaseLocation + ".tmp", this.databaseLocation);
                File.Delete(this.databaseLocation + ".tmp");
            }
            else
            {
                File.Copy("Resources\\default.usys", this.databaseLocation, true);
            }

            Program.dbInt.currentDatabase = this.databaseLocation;
            if (!Program.dbInt.checkDatabase())
            {
                return false;
            }
            OleDbCommand insertQuery = Program.dbInt.preparedStmt();
            insertQuery.CommandText = "INSERT INTO `users` (`username`,`firstName`,`lastName`,`email`,`password`, `admin`) " +
                                      "VALUES (@username, @firstName, @lastName, @email, @password, true)";
            insertQuery.Parameters.AddWithValue("@username", username);
            insertQuery.Parameters.AddWithValue("@firstName", firstName);
            insertQuery.Parameters.AddWithValue("@lastName", lastName);
            insertQuery.Parameters.AddWithValue("@email", email);
            insertQuery.Parameters.AddWithValue("@password", db_password);

            try
            {
                if (insertQuery.ExecuteNonQuery() == 1)
                {
                    Program.regCtrl.writeKey("database", this.databaseLocation, Microsoft.Win32.RegistryValueKind.String);
                    Classes.Database.Manager.setLastBackupTime();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Database.Interface.databaseError("Failed to set up database!", "Class.SetupApplication.confirm", ex.Message);
                return false;
            }

            return false;
        }
        #endregion
    }
}

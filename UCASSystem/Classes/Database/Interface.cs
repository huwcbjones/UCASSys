using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OleDB = System.Data.OleDb;
using WinAPI = Microsoft.WindowsAPICodePack;
using System.IO;

namespace UCASSys.Classes.Database
{
    public class Interface : IDisposable
    {
        #region Properties
        public OleDB.OleDbConnection connection = new OleDB.OleDbConnection();
        private string database;
        private string archiveDB;

        public delegate void databaseOpenedHandler();
        public event databaseOpenedHandler databaseOpened;

        public delegate void databaseClosedHandler();
        public event databaseClosedHandler databaseClosed;

        public bool is_archive = false;

        public string currentDatabase
        {
            get
            {
                if (is_archive)
                {
                    return archiveDB;
                }
                else
                {
                    return database;
                }
            }
            set
            {
                if (value == null)
                {
                    if (this.is_connected)
                    {
                        this.connection.Close();
                    }
                    databaseClosed();
                    database = null;
                }
                else if (database != value)
                {
                    if (!this.is_connected)
                    {
                        database = value;
                    }
                    else if (value == null)
                    {
                        connection.Close();
                        databaseClosed();
                        database = value;
                    }
                }
            }
        }
        public string currentDatabaseDirectory()
        {
            return Path.GetDirectoryName(Program.dbInt.currentDatabase) + "\\";
        }

        public bool is_connected
        {
            get { return (connection.State == ConnectionState.Open); }
        }
        #endregion

        public Interface()
        {
            Program.log.console(GetType().ToString(), "Initialising...");
            
            if (Program.regCtrl.getKey("database"))
            {
                database = (string)Program.regCtrl.getKey("database").Data;
            }
            this.databaseClosed += closeArchiveDatabase;

            Program.log.console(GetType().ToString(), "Initialised!");
        }

        public void Dispose()
        {
            connection.Dispose();
        }
        public bool checkDatabase()
        {
            if (this.database == null)
            {
                return false;
            }
            if (!File.Exists(database))
            {
                return false;
            }
            if (Path.GetExtension(database) != ".usys"
                && Path.GetExtension(database) != ".accdb"
                && Path.GetExtension(database) != ".usysx")
            {
                return false;
            }
            if (this.is_connected)
            {
                this.connection.Close();
                databaseClosed();
            }

            if (Path.GetExtension(database) == ".usysx")
            {
                this.is_archive = true;
                StatusMessage openStatus = openArchiveDatabase(database);
                if (!openStatus)
                {
                    Database.Interface.databaseError(openStatus.Message, GetType().Namespace, (string)openStatus.Data);
                    return false;
                }
                else
                {
                    database = (string)openStatus.Data;
                }
            }

            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + database;

            try
            {
                Program.log.console(GetType().ToString(), "Opening database...");
                connection.Open();
                Program.log.console(GetType().ToString(), "Database opened!");
                databaseOpened();
                return true;
            }
            catch (Exception ex)
            {
                using (TaskDialog dialog = new TaskDialog())
                {
                    dialog.Icon = WinAPI.Dialogs.TaskDialogStandardIcon.Error;
                    dialog.Title = "UCAS Sys: Database Error";
                    dialog.Subtitle = "UCAS Sys failed to load the database.";
                    dialog.DetailsText = ex.Message;
                    dialog.ExpansionMode = WinAPI.Dialogs.TaskDialogExpandedDetailsLocation.ExpandFooter;
                    dialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.Cancel | WinAPI.Dialogs.TaskDialogStandardButtons.Retry;

                    Program.log.log(GetType().Namespace, ex.Message);

                    if (dialog.Show() == WinAPI.Dialogs.TaskDialogResult.Retry)
                    {
                        checkDatabase();
                    }
                }

                return false;
            }
        }

        private StatusMessage openArchiveDatabase(string archiveDB)
        {
            string fileOut = Path.GetDirectoryName(database) + "\\~" + Path.GetFileNameWithoutExtension(database) + ".usys";
            StatusMessage result = Database.Manager.expand(archiveDB, fileOut);
            if (result)
            {
                this.archiveDB = archiveDB;
                result.Data = fileOut;
                File.SetAttributes(fileOut, FileAttributes.Hidden);
            }
            return result;
        }

        private void closeArchiveDatabase()
        {
            if (!is_archive)
            {
                return;
            }
            Database.Manager.compress(this.database, this.database.Replace("~", string.Empty) + "x");
            File.Delete(this.database);
            this.archiveDB = "";
            this.database = "";
        }
        public OleDB.OleDbCommand query(string queryString)
        {
            return new OleDB.OleDbCommand(queryString, connection);
        }
        public OleDB.OleDbCommand preparedStmt()
        {
            OleDB.OleDbCommand query = new OleDB.OleDbCommand();
            query.Connection = this.connection;
            return query;
        }

        public static WinAPI.Dialogs.TaskDialogResult databaseError(string message, string QueryCode = "", string extra = "")
        {
            Program.log.log("UCASSys.Classes.Database.Interface", message + " at " + QueryCode + ". Extra: " + extra);
            using (TaskDialog dialog = new TaskDialog())
            {
                dialog.errorBox();

                dialog.Title = "Database Error";
                dialog.Subtitle = "UCAS Sys encountered a database error!";
                dialog.Text = message;
                dialog.ExpansionMode = WinAPI.Dialogs.TaskDialogExpandedDetailsLocation.ExpandFooter;
                if (QueryCode != "")
                {
                    dialog.DetailsText += "Query Error: " + QueryCode;
                }
                if (QueryCode != "" && extra != "")
                {
                    dialog.DetailsText += Environment.NewLine + Environment.NewLine;
                }
                if (extra != "")
                {
                    dialog.DetailsText += "Additional Information: " + Environment.NewLine + extra;
                }
                return dialog.Show();
            }
        }

    }
}

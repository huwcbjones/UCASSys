using System;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Threading;
using Text = System.Text.Encoding;
using Timer = System.Windows.Forms.Timer;

namespace UCASSys.Classes.Controllers
{
    public class User : IDisposable
    {
        private int userID = -1;
        private string f_name = null;
        private string l_name = null;
        private string u_name = null;
        private string emailAddress;
        private bool loggedIn = false;

        private bool acl_admin = false;
        private bool acl_can_read = true;
        private bool acl_can_write = false;

        private bool acl_students = false;
        private bool acl_applications = false;
        private bool acl_references = false;
        private bool acl_reports = false;
        private bool acl_users = false;

        public delegate void userLoggedInHandler();
        public event userLoggedInHandler userLoggedIn;

        public delegate void userLoggedOutHandler(StringEventArgs reason);
        public event userLoggedOutHandler userLoggedOut;

        public delegate void serverPolledEventHandler();
        public event serverPolledEventHandler serverPolled;

        public Timer serverPollTimer = new Timer();
        Thread pollServerThread;

        private AutoResetEvent pollServerQueue = new AutoResetEvent(false);

        #region Properties
        public int ID
        {
            get { return userID; }
        }
        public string userName
        {
            get { return u_name; }
        }
        public string firstName
        {
            get { return f_name; }
        }
        public string lastName
        {
            get { return l_name; }
        }
        public string fullName
        {
            get { return f_name + " " + l_name; }
        }
        public string email
        {
            get { return emailAddress; }
        }
        public bool is_loggedIn
        {
            get { return loggedIn; }
        }

        public bool is_admin
        {
            get { return acl_admin; }
        }
        public bool can_read
        {
            get { return acl_can_read; }
        }
        public bool can_write
        {
            get { return acl_can_write; }
        }
        public bool access_students
        {
            get { return acl_students; }
        }
        public bool access_applications
        {
            get { return acl_applications; }
        }
        public bool access_references
        {
            get { return acl_references; }
        }
        public bool access_reports
        {
            get { return acl_reports; }
        }
        public bool access_users
        {
            get { return acl_users; }
        }
        #endregion

        public User()
        {
            Program.log.console(GetType().ToString(), "Initialising...");
            serverPollTimer.Interval = 1 * 1000;
            serverPollTimer.Tick += serverPollTimer_Tick;
            pollServerThread = new Thread(poll_database);
            pollServerThread.Name = "User Details Worker";
            pollServerThread.Priority = ThreadPriority.BelowNormal;
            pollServerThread.IsBackground = true;
            pollServerThread.Start();
            Program.log.console(GetType().ToString(), "Initialised!");
        }

        public void Dispose()
        {
            if (this.is_loggedIn)
            {
                this.logout();
            }
        }

        private StatusMessage _isAuthed(int userID, string dbPass, string userPwd, bool checkSession)
        {
            StatusMessage result = new StatusMessage(false);
            String[] splitPwd = dbPass.Split(':');
            if (splitPwd.Length != 2)
            {
                return result;
            }
            string pass = splitPwd[0];
            string salt = splitPwd[1];

            if (password_hash(userPwd, salt) != pass)
            {
                return result;
            }
            else
            {
                result.is_Success = true;
            }
            if (!checkSession)
            {
                return result;
            }

            result.is_Success = true;
            if (is_activeSession(userID))
            {
                if (!_clearSession(userID))
                {
                    result.is_Success = false;
                }
            }
            return result;
        }
        public StatusMessage is_authenticatedName(string password, string username = null, bool checkSession = false)
        {
            StatusMessage result = new StatusMessage(false);
            if (username == null)
            {
                username = this.u_name;
            }
            if (username == null)
            {
                return result;
            }

            username = username.ToLower();

            using (OleDbCommand selectQuery = new OleDbCommand())
            {
                selectQuery.Connection = Program.dbInt.connection;
                selectQuery.CommandText = "SELECT `userID`, `password` FROM `users` WHERE `username`=@username";
                selectQuery.Parameters.AddWithValue("@username", username);

                try
                {
                    string dbPass = null;
                    int userID = -1;
                    using (OleDbDataReader data = selectQuery.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return result;
                        }

                        while (data.Read())
                        {
                            userID = (int)data["userID"];
                            dbPass = (string)data["password"];
                        }
                    }
                    if (dbPass == null)
                    {
                        return result;
                    }

                    return _isAuthed(userID, dbPass, password, checkSession);
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to authenticate password.", GetType().Namespace, ex.Message);
                }
            }
            return result;
        }
        public StatusMessage is_authenticatedID(string password, int userID = -1, bool checkSession = false)
        {
            StatusMessage result = new StatusMessage(false);
            if (userID == -1)
            {
                userID = this.userID;
            }
            if (userID == -1)
            {
                return result;
            }

            using (OleDbCommand selectQuery = new OleDbCommand())
            {
                selectQuery.Connection = Program.dbInt.connection;
                selectQuery.CommandText = "SELECT `password` FROM `users` WHERE `userID`=@userID";
                selectQuery.Parameters.AddWithValue("@userID", userID);

                try
                {
                    string dbPass = null;
                    using (OleDbDataReader data = selectQuery.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return result;
                        }

                        while (data.Read())
                        {
                            dbPass = (string)data["password"];
                        }
                    }
                    if (dbPass == null)
                    {
                        return result;
                    }
                    return _isAuthed(userID, dbPass, password, checkSession);
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to authenticate password.", GetType().Namespace, ex.Message);
                }
            }
            return result;
        }

        public StatusMessage login(string password, string username = null, int userID = -1, bool is_console = false)
        {
            StatusMessage result = new StatusMessage(false);
            if (username == null && userID == -1)
            {
                return result;
            }
            username = username.ToLower();
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                if (username != null)
                {
                    query.CommandText = "SELECT `userID` FROM `users` WHERE `username`=@username";
                    query.Parameters.AddWithValue("@username", username);
                }
                else if (userID != -1)
                {
                    query.CommandText = "SELECT `userID` FROM `users` WHERE `userID`=@userID";
                    query.Parameters.AddWithValue("@userID", userID);
                }
                else
                {
                    return result;
                }

                try
                {
                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            this.loggedIn = false;
                            return result;
                        }
                        while (data.Read())
                        {
                            this.userID = (int)data["userID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!is_console) Database.Interface.databaseError("Failed to fetch user details.", GetType().Namespace, ex.Message);
                    return result;
                }
            }
            StatusMessage auth = this.is_authenticatedID(password, this.userID);
            if (!auth)
            {
                return auth;
            }

            if (!fetch_userDetails())
            {
                return result;
            }

            if (this._setSession(this.userID, is_console))
            {
                this.loggedIn = true;
                serverPollTimer.Enabled = true;
                if (userLoggedIn != null) userLoggedIn();
                result.is_Success = true;
                return result;
            }
            return result;

        }

        private bool _setSession(int userID, bool is_console = false)
        {
            if (is_console)
            {
                return true;
            }
            using (OleDbCommand insertQuery = Program.dbInt.preparedStmt())
            {
                insertQuery.CommandText = "INSERT INTO `sessions` (`userID`, `computer`, `loggedInTime`, `lastConnected`) VALUES (@userID, @computer, NOW(), NOW())";

                insertQuery.Parameters.AddWithValue("@userID", userID);
                insertQuery.Parameters.AddWithValue("@computer", Environment.MachineName);

                try
                {
                    if (insertQuery.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Classes.Database.Interface.databaseError("Failed to create session.", "Classes.Controllers.User", ex.Message);
                }
            }
            return false;
        }

        public bool is_activeSession(int userID)
        {
            using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
            {
                selectQuery.CommandText = "SELECT `userID` FROM `sessions` WHERE `userID` = @userID";
                selectQuery.Parameters.AddWithValue("@userID", userID);

                try
                {
                    using (OleDbDataReader data = selectQuery.ExecuteReader())
                    {
                        return data.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                }
            }
            return false;
        }

        private bool _clearSession(int userID)
        {
            using (OleDbCommand deleteQuery = Program.dbInt.preparedStmt())
            {
                deleteQuery.CommandText = "DELETE FROM `sessions` WHERE `userID`=@userID";
                deleteQuery.Parameters.AddWithValue("@userID", userID);

                try
                {
                    return (deleteQuery.ExecuteNonQuery() == 1);
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to clear user session. User may have difficulty logging in next session.", GetType().Namespace, ex.Message);
                }
            }
            return false;
        }
        public void logout(string reason = "")
        {
            this._clearSession(this.userID);

            serverPollTimer.Enabled = false;
            this.userID = -1;
            this.u_name = null;
            this.emailAddress = null;
            this.f_name = null;
            this.l_name = null;
            this.loggedIn = false;
            this.acl_can_read = true;
            this.acl_can_write = false;
            this.acl_admin = false;
            this.acl_students = false;
            this.acl_applications = false;
            this.acl_references = false;
            this.acl_reports = false;
            this.acl_users = false;

            userLoggedOut(new StringEventArgs(reason));
        }

        private bool fetch_userDetails(int userID = -1)
        {
            if (userID == -1)
            {
                userID = this.userID;
            }
            if (userID == -1)
            {
                return false;
            }
            String queryString = "SELECT `userID`, `username`, `firstName`, `lastName`, `email`, `admin`, `can_read`, `can_write`, `acl_students`, `acl_applications`, `acl_references`, `acl_reports`, `acl_users` FROM `users` WHERE `userID` = " + userID;
            if (Program.regCtrl.getKey("disable_userCtrl_log") != true
                || (int)Program.regCtrl.getKey("disable_userCtrl_log").Data != 1)
            {
                Program.log.console(GetType().ToString(), "Fetching user details for UserID " + userID.ToString());
            }
            try
            {
                using (OleDbCommand query = Program.dbInt.query(queryString))
                {
                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return false;
                        }

                        while (data.Read())
                        {
                            this.userID = (int)data["userID"];
                            this.u_name = (string)data["username"];
                            this.f_name = (string)data["firstName"];
                            this.l_name = (string)data["lastName"];

                            this.emailAddress = (string)data["email"];

                            this.loggedIn = true;
                            this.acl_admin = (bool)data["admin"];
                            this.acl_can_read = (bool)data["can_read"];
                            this.acl_can_write = (bool)data["can_write"];
                            this.acl_students = (bool)data["acl_students"];
                            this.acl_applications = (bool)data["acl_applications"];
                            this.acl_references = (bool)data["acl_references"];
                            this.acl_reports = (bool)data["acl_reports"];
                            this.acl_users = (bool)data["acl_users"];
                            if (this.acl_admin)
                            {
                                this.acl_can_read = true;
                                this.acl_can_write = true;
                                this.acl_students = true;
                                this.acl_applications = true;
                                this.acl_references = true;
                                this.acl_reports = true;
                                this.acl_users = true;
                            }
                            if (serverPolled != null)
                            {
                                serverPolled();
                            }
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Database.Interface.databaseError("Failed to fetch user information.", "Class.UserController.fetch_userDetails", ex.Message);
            }
            return false;
        }

        public StatusMessage changePassword(string oldPwd, string newPwd, string confPwd)
        {
            StatusMessage result = new StatusMessage(false);

            if (!Validation.password(newPwd))
            {
                return Validation.password(newPwd);
            }
            if (!Validation.confirm(newPwd, oldPwd, "New password cannot be the same as old password.", true))
            {
                return Validation.confirm(newPwd, oldPwd, "New password cannot be the same as old password.", true);
            }
            if (!Validation.confirm(newPwd, confPwd, "Passwords do not match."))
            {
                return Validation.confirm(newPwd, confPwd, "Passwords do not match.");
            }
            if (!is_authenticatedID(oldPwd))
            {
                return is_authenticatedID(oldPwd);
            }

            string salt = User.random_hash();
            string dbPwd = User.password_hash(newPwd, salt) + ":" + salt;

            using (OleDbTransaction transaction = Program.dbInt.connection.BeginTransaction())
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.Transaction = transaction;

                    query.CommandText = "UPDATE `users` SET `password`=@pwd WHERE `userID`=@ID";

                    try
                    {
                        query.Parameters.AddWithValue("@pwd", dbPwd);
                        query.Parameters.AddWithValue("@ID", this.userID);

                        if (query.ExecuteNonQuery() == 1)
                        {
                            transaction.Commit();
                            result.is_Success = true;
                        }
                        else
                        {
                            transaction.Rollback();
                            result.Message = "Failed to update database.";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        result.Message = ex.Message;
                        result.Data = ex.ToString();
                        Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                    }
                }
            }

            return result;
        }

        #region Polling
        private void serverPollTimer_Tick(object sender, EventArgs e)
        {
            pollServerQueue.Set();
        }
        public void poll_database()
        {
            do
            {
                pollServerQueue.WaitOne();
                if (!_checkCurrentSession())
                {
                    logout("Login session was not found.");
                    continue;
                }

                if (!fetch_userDetails())
                {
                    Program.log.console(GetType().Namespace, "Checking user details... FAILED!");
                    logout("User was not found.");
                }
                else
                {
                    if (Program.regCtrl.getKey("disable_userCtrl_log") != true
                || (int)Program.regCtrl.getKey("disable_userCtrl_log").Data != 1)
                    {
                        Program.log.console(GetType().Namespace, "Checking user details... OK!");
                    }
                }

            } while (true);

        }

        private bool _checkCurrentSession()
        {
            try
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.CommandText = "SELECT COUNT(`userID`) from `sessions` WHERE `computer`=@pc AND `userID`=@userID";

                    query.Parameters.AddWithValue("@pc", Environment.MachineName);
                    query.Parameters.AddWithValue("@userID", this.userID);
                    if (Program.regCtrl.getKey("disable_userCtrl_log") != true
                        || (int)Program.regCtrl.getKey("disable_userCtrl_log").Data != 1)
                    {
                        Program.log.console(GetType().ToString(), "Checking user session... Session " + (((int)query.ExecuteScalar() == 1) ? "OK!" : "Missing"));
                    }
                    return ((int)query.ExecuteScalar() == 1);
                }
            }
            catch (Exception ex)
            {
                Database.Interface.databaseError("Failed to check session.", GetType().Namespace, ex.Message);
            }
            Program.log.console(GetType().ToString(), "Checking session... Session Missing");
            return false;
        }
        #endregion

        #region Static Methods
        public static string password_hash(string password, string salt)
        {
            using (SHA256Managed sha = new SHA256Managed())
            {
                Byte[] bytesToHash;
                Byte[] hash;
                bytesToHash = Text.UTF8.GetBytes(password + salt);
                hash = sha.ComputeHash(bytesToHash);
                hash = sha.ComputeHash(Text.UTF8.GetBytes(salt + BitConverter.ToString(hash)));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
        public static string random_hash()
        {
            using (SHA256Managed sha = new SHA256Managed())
            {
                Random random = new Random();
                Byte[] bytesToHash;
                Byte[] hash;

                bytesToHash = Text.UTF8.GetBytes(random.Next().ToString());
                hash = sha.ComputeHash(bytesToHash);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
        #endregion
    }
}
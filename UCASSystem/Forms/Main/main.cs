using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAPI = Microsoft.WindowsAPICodePack;
using System.Media;
using bkp = UCASSys.Classes.Database.Manager;
using UCASSys.Classes.Items;

namespace UCASSys.Forms.Main
{
    public partial class main : Form
    {

        Classes.Items.NotificationItem lastNotification;
        bool minimiseWarningShown = false;
        TaskList taskList = new TaskList();

        public main()
        {
            InitializeComponent();

            this.Shown += form_Main_shown;
            this.FormClosed += main_FormClosed;
            Program.userCtrl.userLoggedIn += userCtrl_userLoggedIn;
            Program.userCtrl.userLoggedOut += userCtrl_userLoggedOut;
            Program.userCtrl.serverPolled += userCtrl_serverPolled;

            Program.notifyCtrl.raiseNotification += showNotification;
            notify_icon.Click += notify_icon_Click;

            this.Load += taskListResize;
            panels.SplitterMoved += taskListResize;
            tabs.SizeChanged += taskListResize;
            tabs.SelectedIndexChanged += taskListResize;

            taskList.updateTaskList += taskList_updateTaskList;
            taskList.openForm += taskList_openForm;

            menu_main_file_new.Click += file_new;
            menu_main_file_open.Click += file_open;
            menu_main_file_changePassword.Click += file_changePassword;
            menu_main_file_database_backup.Click += file_database_backup;
            menu_main_file_logout.Click += file_logout;

            menu_main_student_new.Click += students_new;
            menu_main_student_open.Click += students_open;

            lv_main_details.DoubleClick += taskList.openStudent;
            lv_details.DoubleClick += taskList.openStudent;

            Program.userCtrl.userLoggedIn += _processStartupArgs;
            Program.startup.startupArgAddedHandler += _processStartupArgs;
        }

        void taskList_openForm(int mode, int ULN)
        {
            if (mode == TaskList.LV_STUDENT)
            {
                _openStudent(null, ULN);
            }
        }

        public void main_FormClosed(object sender, EventArgs e)
        {
            Program.userCtrl.Dispose();
        }

        private void form_Main_Load(object sender, EventArgs e)
        {

            disable_menu(menu_main_file_database);
            disable_menu(menu_main_file_changePassword);
            disable_menu(menu_main_file_logout);
            disable_menu(menu_main_student);
            disable_menu(menu_main_applications);
            disable_menu(menu_main_references);
            disable_menu(menu_main_reports);
            disable_menu(menu_main_tools_users);
            disable_menu(menu_main_tools_subjects);
            disable_menu(menu_main_tools_universities);

            disable_separator(menu_main_file_separator_database);
            disable_separator(menu_main_file_separator_password);
            disable_separator(menu_main_tools_separator_admin);
            disable_separator(menu_main_tools_separator_users);

            group_taskList.Enabled = false;
            group_dashboard.Enabled = false;

            status_main_time.Text = DateTime.Now.ToString();
        }

        private void form_Main_shown(object sender, EventArgs e)
        {
            openDatabase(null, true);
            Program.taskbarCtrl = new Classes.Controllers.Taskbar();
        }

        private void _processStartupArgs()
        {
            List<int> localStartupArgs = new List<int>(Program.startup.startupArgs);
            foreach (int arg in localStartupArgs)
            {
                switch (arg)
                {
                    case StartupArgs.ADD_STUDENT:
                        students_new(null, null);
                        break;
                }
                Program.startup.startupArgs.Remove(arg);
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Classes.NativeMethods.WM_ShowMe)
            {
                ShowMe();
            }
            else if (m.Msg == Classes.NativeMethods.WM_Add_Student)
            {
                students_new(null, null);
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            bool top = TopMost;
            TopMost = true;
            TopMost = top;
        }

        private void showMinimiseWarning()
        {
            if (!this.minimiseWarningShown)
            {
                this.minimiseWarningShown = true;
                Program.notifyCtrl.Add(new Classes.Items.NotificationItem(
                    "",
                    "You have selected UCAS System to be hidden when minimised. " +
                    "To restore the window, right click on this icon."
                    ));
            }
        }

        #region Helper Functions

        private void enable_separator(ToolStripSeparator item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<ToolStripSeparator>(enable_separator), item);
            }
            else
            {
                item.Visible = true;
                item.Enabled = true;
            }
        }
        private void disable_separator(ToolStripSeparator item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<ToolStripSeparator>(disable_separator), item);
            }
            else
            {
                item.Visible = false;
                item.Enabled = false;
            }
        }

        private void enable_menu(ToolStripMenuItem menu)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<ToolStripMenuItem>(enable_menu), menu);
            }
            menu.Visible = true;
            menu.Enabled = true;
            if (menu is ToolStripMenuItem)
            {
                foreach (object subitem in menu.DropDownItems)
                {
                    if (subitem is ToolStripMenuItem)
                    {
                        enable_menu((ToolStripMenuItem)subitem);
                    }
                    else if (subitem is ToolStripSeparator)
                    {
                        enable_separator((ToolStripSeparator)subitem);
                    }
                }
            }
        }
        private void disable_menu(ToolStripMenuItem menu)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<ToolStripMenuItem>(disable_menu), menu);
            }
            else
            {
                menu.Visible = false;
                menu.Enabled = false;
                if (menu is ToolStripMenuItem)
                {
                    foreach (object subitem in menu.DropDownItems)
                    {
                        if (subitem is ToolStripMenuItem)
                        {
                            disable_menu((ToolStripMenuItem)subitem);
                        }
                        else if (subitem is ToolStripSeparator)
                        {
                            disable_separator((ToolStripSeparator)subitem);
                        }
                    }
                }
            }
        }

        public void setFormText(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(setFormText), text);
            }
            else
            {
                this.Text = text;
            }
        }

        public void setToolStripAdminStatus(bool admin = false)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(setToolStripAdminStatus), admin);
            }
            else
            {
                if (admin)
                {
                    status_main_accountType.Text = "Admin";
                    status_main_accountType.ForeColor = Color.Red;
                }
                else
                {
                    status_main_accountType.Text = "Standard";
                    status_main_accountType.ForeColor = Color.Black;
                }
            }
        }
        public void groupEnabled(GroupBox group, bool enabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<GroupBox, bool>(groupEnabled), group, enabled);
            }
            else
            {
                group.Enabled = enabled;
            }
        }

        #endregion

        #region File Menu
        private void file_new(object sender, EventArgs e)
        {
            Classes.SetupDatabase setup = new Classes.SetupDatabase();
            setFormText("UCAS System: New Database");
            if (setup.setupNew())
            {
                openDatabase(null, true);
            }
        }

        private void file_open(object sender, EventArgs e)
        {
            using (WinAPI.Dialogs.CommonOpenFileDialog databaseBrowser = new WinAPI.Dialogs.CommonOpenFileDialog())
            {
                databaseBrowser.EnsureFileExists = true;
                databaseBrowser.Multiselect = false;
                databaseBrowser.Title = "Open UCAS System Database";
                databaseBrowser.Filters.Add(new WinAPI.Dialogs.CommonFileDialogFilter("UCAS System Database", "usys"));
                databaseBrowser.Filters.Add(new WinAPI.Dialogs.CommonFileDialogFilter("UCAS System Compressed Database", "usysx"));
                databaseBrowser.Filters.Add(new WinAPI.Dialogs.CommonFileDialogFilter("Microsoft Access Database", "accdb"));

                if (databaseBrowser.ShowDialog() != WinAPI.Dialogs.CommonFileDialogResult.Ok)
                {
                    return;
                }

                if (Program.userCtrl.is_loggedIn)
                {
                    Program.userCtrl.logout();
                }

                String database = databaseBrowser.FileName;

                openDatabase(database);
            }
        }

        private void file_changePassword(object sender, EventArgs e)
        {
            using (changePassword chgPwd = new changePassword())
            {
                chgPwd.ShowDialog();
            }
        }

        private void file_logout(object sender, EventArgs e)
        {
            Program.userCtrl.logout();

            using (login loginForm = new login(Program.dbInt.currentDatabase))
            {
                if (loginForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    setFormText("UCAS System");
                    Program.dbInt.currentDatabase = null;
                }
                else if (Program.userCtrl.login(loginForm.text_password.Text, loginForm.text_username.Text))
                {
                    Program.regCtrl.writeKey("database", Program.dbInt.currentDatabase, Microsoft.Win32.RegistryValueKind.String);
                    setFormText("UCAS System: \"" + Program.dbInt.currentDatabase + "\"");
                }
                else
                {
                    setFormText("UCAS System");
                    Program.dbInt.currentDatabase = null;
                }
            }
        }

        private void file_database_backup(object sender, EventArgs e)
        {
            Classes.Database.Manager.database_backup();
        }
        #endregion

        #region Students Menu
        private void students_new(object sender, EventArgs e)
        {
            Forms.Students.main form = new Students.main();
            form.Show();
        }

        private void students_open(object sender, EventArgs e)
        {
            using (Forms.Students.dialog.open open = new Students.dialog.open())
            {
                if (open.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                if (open.student == null)
                {
                    return;
                }
                _openStudent(open.student);
            }
        }

        private void _openStudent(StudentItem student, long ULN = -1)
        {
            if (student == null && ULN == -1) { return; }
            if (student != null) ULN = student.ULN;
            foreach (Form f in Application.OpenForms)
            {
                if (!(f is Forms.Students.main))
                {
                    continue;
                }

                Forms.Students.main sRef = (Forms.Students.main)f;

                if (sRef.student.ULN == ULN)
                {
                    sRef.BringToFront();
                    sRef.Activate();
                    return;
                }
            }
            Forms.Students.main newForm = new Forms.Students.main(Program.MODE_Edit, (student ?? new StudentItem(ULN)));
            newForm.Show();
        }
        #endregion

        #region Applications Menu

        #endregion

        #region References Menu
        #endregion

        public bool openDatabase(string database = null, bool defaultDatabase = false)
        {
            if (!defaultDatabase)
            {
                if (Program.dbInt.is_connected)
                {
                    Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle);
                    dialog.confirmBox();
                    dialog.Title = "Close Database?";
                    dialog.Subtitle = "Are you sure you want to close the database?";
                    dialog.Text = "All work has been saved.";

                    if (dialog.Show() != WinAPI.Dialogs.TaskDialogResult.Ok)
                    {
                        return false;
                    }
                }
                Program.dbInt.currentDatabase = database;
            }

            setFormText("UCAS System: Open Database");

            if (Program.dbInt.checkDatabase())
            {
                using (login loginForm = new login(Program.dbInt.currentDatabase))
                {
                    if (loginForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        setFormText("UCAS System");
                        Program.dbInt.currentDatabase = null;
                    }
                    else if (Program.userCtrl.login(loginForm.text_password.Text, loginForm.text_username.Text))
                    {
                        Program.regCtrl.writeKey("database", Program.dbInt.currentDatabase, Microsoft.Win32.RegistryValueKind.String);
                        setFormText("UCAS System: \"" + Program.dbInt.currentDatabase + "\"");
                        return true;
                    }
                    else
                    {
                        setFormText("UCAS System");
                        Program.dbInt.currentDatabase = null;
                    }
                }
            }
            else
            {
                setFormText("UCAS System");
            }
            return false;
        }


        #region UI Updating Events
        private void userCtrl_serverPolled()
        {
            status_main_loggedInAs.Text = "Logged in as: " + Program.userCtrl.fullName;
            status_main_accountType_label.Text = "Account Type:";
            if (Program.userCtrl.is_admin)
            {
                setToolStripAdminStatus(true);
            }
            else
            {
                setToolStripAdminStatus();
            }

            if (Program.userCtrl.is_admin)
            {
                enable_menu(menu_main_tools_subjects);
                enable_menu(menu_main_tools_universities);
                enable_separator(menu_main_tools_separator_admin);
                enable_menu(menu_main_file_database);
            }
            else
            {
                disable_menu(menu_main_file_database_restore);
                disable_menu(menu_main_tools_subjects);
                disable_menu(menu_main_tools_universities);
                disable_separator(menu_main_tools_separator_admin);
            }

            if (Program.userCtrl.access_students)
            {
                enable_menu(menu_main_student);

                if (Program.userCtrl.can_write)
                {
                    enable_menu(menu_main_student_new);
                }
                else
                {
                    disable_menu(menu_main_student_new);
                }
            }
            else
            {
                disable_menu(menu_main_student);
            }

            if (Program.userCtrl.access_applications)
            {
                enable_menu(menu_main_applications);
                if (Program.userCtrl.can_write)
                {
                    enable_menu(menu_main_applications_new);
                }
                else
                {
                    disable_menu(menu_main_applications_new);
                }
            }
            else
            {
                disable_menu(menu_main_applications);
            }

            if (Program.userCtrl.access_references)
            {
                enable_menu(menu_main_references);
                if (Program.userCtrl.can_write)
                {
                    enable_menu(menu_main_references_new);
                }
                else
                {
                    disable_menu(menu_main_references_new);
                }
            }
            else
            {
                disable_menu(menu_main_references);
            }

            if (Program.userCtrl.access_reports)
            {
                enable_menu(menu_main_reports);
            }
            else
            {
                disable_menu(menu_main_reports);
            }

            if (Program.userCtrl.access_users)
            {
                enable_menu(menu_main_tools_users);
                enable_separator(menu_main_tools_separator_users);
            }
            else
            {
                disable_menu(menu_main_tools_users);
                disable_separator(menu_main_tools_separator_users);
            }
        }
        private void userCtrl_userLoggedIn()
        {
            enable_menu(menu_main_file);

            groupEnabled(group_taskList, true);
            groupEnabled(group_dashboard, true);

            Program.notifyCtrl.Enable();

            taskList.Enabled(true);

            if (Classes.Database.Manager.should_backup())
            {
                backupPrompt();
            }
        }

        void taskListResize(object sender, EventArgs e)
        {
            TaskList.resizeTaskListLV(ref lv_main_details);
            TaskList.resizeTaskListLV(ref lv_details);
            TaskList.resizeTaskListLV(ref lv_main_applications);
            TaskList.resizeTaskListLV(ref lv_applications);
            TaskList.resizeTaskListLV(ref lv_main_references);
            TaskList.resizeTaskListLV(ref lv_references);
        }
        void taskList_updateTaskList(List<TaskListItem> tasklistItems, int target)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<TaskListItem>, int>(taskList_updateTaskList), tasklistItems, target);
                return;
            }

            ListView lvm;
            ListView lv;

            if (target == TaskList.LV_STUDENT)
            {
                Program.log.console(GetType().Namespace, "Processing TaskList LV_STUDENT...");
                lvm = lv_main_details;
                lv = lv_details;
            }
            else if (target == TaskList.LV_APPLICATION)
            {
                Program.log.console(GetType().Namespace, "Processing TaskList LV_APPLICATION...");
                lvm = lv_main_applications;
                lv = lv_applications;
            }
            else if (target == TaskList.LV_REFERENCE)
            {
                Program.log.console(GetType().Namespace, "Processing TaskList LV_REFERENCE...");
                lvm = lv_main_references;
                lv = lv_references;
            }
            else
            {
                Program.log.log(GetType().Namespace, "Unknown target '" + target.ToString() + "' passed to update tasklist.");
                return;
            }


            lvm.BeginUpdate();
            lv.BeginUpdate();

            lvm.Items.Clear();
            lv.Items.Clear();

            ListViewItem lv_item;
            ListViewItem lv_itemm;

            foreach (TaskListItem item in tasklistItems)
            {
                lv_item = lv.Items.Add(item.Deadline.ToString("ddd, d MMM yyyy"));
                lv_itemm = lvm.Items.Add(item.Deadline.ToString("ddd, d MMM yyyy"));

                lv_item.Tag = lv_itemm.Tag = item.ULN;

                lv_item.SubItems.Add(item.FirstName + " " + item.LastName);
                lv_itemm.SubItems.Add(item.FirstName + " " + item.LastName);

                lv_item.SubItems.Add(TaskList.getTimeInterval(item.Deadline));
                lv_itemm.SubItems.Add(TaskList.getTimeInterval(item.Deadline));

                this.taskList.colourLVItem(ref lv_item, item.Deadline);
                this.taskList.colourLVItem(ref lv_itemm, item.Deadline);
            }

            lv.EndUpdate();
            lvm.EndUpdate();
        }

        private void backupPrompt()
        {
            Int32 backup = Classes.Database.Manager.BackUp_Ask;
            if (Program.regCtrl.getKey("autoBackup"))
            {
                backup = (Int32)Program.regCtrl.getKey("autoBackup").Data;
            }
            if (backup == bkp.BackUp_Ask)
            {
                using (Classes.TaskDialog taskDialog = new Classes.TaskDialog(this.Handle))
                {

                    taskDialog.infoBox();
                    taskDialog.Title = "Backup Reminder";
                    taskDialog.Subtitle = "It's been a while since the database was backed up";
                    taskDialog.Text = "Do you want to backup the database?";
                    taskDialog.taskDialog.FooterCheckBoxText = "Do &not ask me again.";
                    taskDialog.StandardButtons = WinAPI.Dialogs.TaskDialogStandardButtons.No | WinAPI.Dialogs.TaskDialogStandardButtons.Yes;
                    WinAPI.Dialogs.TaskDialogResult result = taskDialog.Show();

                    if (result == WinAPI.Dialogs.TaskDialogResult.Yes)
                    {
                        bkp.database_backup(Program.dbInt.currentDatabaseDirectory() + "backup\\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".usysx");
                    }
                    Int32 newBackupSetting = 0x0;
                    if (taskDialog.taskDialog.FooterCheckBoxChecked.HasValue && taskDialog.taskDialog.FooterCheckBoxChecked.Value)
                    {
                        newBackupSetting |= bkp.BackUp_NoAsk;
                    }
                    if (taskDialog.taskDialog.FooterCheckBoxChecked.HasValue && result == WinAPI.Dialogs.TaskDialogResult.Yes)
                    {
                        newBackupSetting |= bkp.BackUp_Auto;
                    }
                    Program.regCtrl.writeKey("autoBackup", newBackupSetting, Microsoft.Win32.RegistryValueKind.DWord);
                }
            }
            else
            {
                if (backup == (bkp.BackUp_Auto | bkp.BackUp_NoAsk))
                {
                    bkp.database_backup(Program.dbInt.currentDatabaseDirectory() + "backup\\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".usysx");
                }
            }
        }
        private void userCtrl_userLoggedOut(StringEventArgs reason)
        {
            taskList.Enabled(false);
            setFormText("UCAS System");
            status_main_accountType.Text = "";
            status_main_accountType_label.Text = "";
            status_main_loggedInAs.Text = "Logged Out";

            disable_menu(menu_main_file_database);
            disable_menu(menu_main_file_changePassword);
            disable_menu(menu_main_file_logout);
            disable_menu(menu_main_student);
            disable_menu(menu_main_applications);
            disable_menu(menu_main_references);
            disable_menu(menu_main_reports);
            disable_menu(menu_main_tools_users);
            disable_menu(menu_main_tools_subjects);
            disable_menu(menu_main_tools_universities);

            disable_separator(menu_main_file_separator_database);
            disable_separator(menu_main_file_separator_password);
            disable_separator(menu_main_tools_separator_admin);
            disable_separator(menu_main_tools_separator_users);

            groupEnabled(group_taskList, false);
            groupEnabled(group_dashboard, false);

            Program.notifyCtrl.Disable();

            if (reason.text == "") { return; }
            _loggedOutMessage(reason);
        }

        private void _loggedOutMessage(StringEventArgs reason)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<StringEventArgs>(_loggedOutMessage), reason);
                return;
            }
            using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
            {
                dialog.authBox();
                dialog.Title = "Logged out.";
                dialog.Subtitle = "You were automatically logged out.";
                dialog.Text = reason.text;
                dialog.Show();
            }
        }
        private void clock_Tick(object sender, EventArgs e)
        {
            status_main_time.Text = DateTime.Now.ToString();
        }
        #endregion

        #region Notification Handling

        private void showNotification(Classes.Items.NotificationItem notification, bool data = false)
        {
            if (data && notification.Data != null)
            {
                notify_icon.Tag = notification.Data;
            }
            int showTime = 5;

            if (notification.SaveAsLast)
            {
                this.lastNotification = notification;
            }
            notify_icon.BalloonTipTitle = notification.Title;
            notify_icon.BalloonTipIcon = notification.Icon;
            notify_icon.BalloonTipText = notification.Message;

            if (notification.Sound is SystemSound)
            {
                notification.Sound.Play();
            }
            notify_icon.ShowBalloonTip(showTime * 1000);
        }

        private void notify_icon_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left
                && this.lastNotification != null
                )
            {
                this.showNotification(this.lastNotification);
            }
        }

        #endregion

    }
}

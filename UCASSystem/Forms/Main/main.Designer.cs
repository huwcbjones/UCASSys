namespace UCASSys.Forms.Main
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.group_main_applications = new System.Windows.Forms.GroupBox();
            this.lv_main_applications = new System.Windows.Forms.ListView();
            this.lv_main_applications_due = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_main_applications_student = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_main_applications_timeLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_main_details_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_main_details_dueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_main_details = new System.Windows.Forms.ListView();
            this.lv_main_details_timeLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.group_main_details = new System.Windows.Forms.GroupBox();
            this.table_main = new System.Windows.Forms.TableLayoutPanel();
            this.group_main_references = new System.Windows.Forms.GroupBox();
            this.lv_main_references = new System.Windows.Forms.ListView();
            this.lv_main_references_due = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_main_references_student = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_main_references_timeLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_all = new System.Windows.Forms.TabPage();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tab_details = new System.Windows.Forms.TabPage();
            this.group_details = new System.Windows.Forms.GroupBox();
            this.lv_details = new System.Windows.Forms.ListView();
            this.lv_details_dueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_details_student = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_details_timeLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_applications = new System.Windows.Forms.TabPage();
            this.group_applications = new System.Windows.Forms.GroupBox();
            this.lv_applications = new System.Windows.Forms.ListView();
            this.lv_applications_dueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_applications_student = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_applications_timeLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_references = new System.Windows.Forms.TabPage();
            this.group_references = new System.Windows.Forms.GroupBox();
            this.lv_references = new System.Windows.Forms.ListView();
            this.lv_references_dueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_references_student = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_references_timeLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.group_taskList = new System.Windows.Forms.GroupBox();
            this.panels = new System.Windows.Forms.SplitContainer();
            this.group_dashboard = new System.Windows.Forms.GroupBox();
            this.context_hideOnMin = new System.Windows.Forms.ToolStripMenuItem();
            this.context_menu_separator = new System.Windows.Forms.ToolStripSeparator();
            this.context_notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_notify_show = new System.Windows.Forms.ToolStripMenuItem();
            this.notify_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.server_poll = new System.ComponentModel.BackgroundWorker();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.status_main_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_main_separator_2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_main_accountType_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_main_separator_1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_main_loggedInAs = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu_main_help_about = new System.Windows.Forms.ToolStripMenuItem();
            this.status_main = new System.Windows.Forms.StatusStrip();
            this.status_main_accountType = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu_main_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_references = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_references_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_references_search = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_applications_open = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_applications_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_applications = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_student_open = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_student_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_student = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_separator_logout = new System.Windows.Forms.ToolStripSeparator();
            this.menu_main_file_database_restore = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_database_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_database = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_separator_database = new System.Windows.Forms.ToolStripSeparator();
            this.menu_main_file_changePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_open = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_file_separator_password = new System.Windows.Forms.ToolStripSeparator();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.menu_main_reports = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_users = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_users_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_users_view = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_separator_users = new System.Windows.Forms.ToolStripSeparator();
            this.menu_main_tools_subjects = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_subjects_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_subjects_view = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_universities = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_universities_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_universities_view = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_tools_separator_admin = new System.Windows.Forms.ToolStripSeparator();
            this.menu_main_tools_options = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_window = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_window_closeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.group_main_applications.SuspendLayout();
            this.group_main_details.SuspendLayout();
            this.table_main.SuspendLayout();
            this.group_main_references.SuspendLayout();
            this.tab_all.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tab_details.SuspendLayout();
            this.group_details.SuspendLayout();
            this.tab_applications.SuspendLayout();
            this.group_applications.SuspendLayout();
            this.tab_references.SuspendLayout();
            this.group_references.SuspendLayout();
            this.group_taskList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panels)).BeginInit();
            this.panels.Panel1.SuspendLayout();
            this.panels.Panel2.SuspendLayout();
            this.panels.SuspendLayout();
            this.group_dashboard.SuspendLayout();
            this.context_notify.SuspendLayout();
            this.status_main.SuspendLayout();
            this.menu_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_main_applications
            // 
            this.group_main_applications.Controls.Add(this.lv_main_applications);
            this.group_main_applications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_main_applications.Location = new System.Drawing.Point(0, 160);
            this.group_main_applications.Margin = new System.Windows.Forms.Padding(0);
            this.group_main_applications.Name = "group_main_applications";
            this.group_main_applications.Size = new System.Drawing.Size(156, 160);
            this.group_main_applications.TabIndex = 2;
            this.group_main_applications.TabStop = false;
            this.group_main_applications.Text = "Applications";
            // 
            // lv_main_applications
            // 
            this.lv_main_applications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_main_applications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_main_applications_due,
            this.lv_main_applications_student,
            this.lv_main_applications_timeLeft});
            this.lv_main_applications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_main_applications.FullRowSelect = true;
            this.lv_main_applications.GridLines = true;
            this.lv_main_applications.Location = new System.Drawing.Point(3, 16);
            this.lv_main_applications.MultiSelect = false;
            this.lv_main_applications.Name = "lv_main_applications";
            this.lv_main_applications.ShowGroups = false;
            this.lv_main_applications.Size = new System.Drawing.Size(150, 141);
            this.lv_main_applications.TabIndex = 0;
            this.lv_main_applications.UseCompatibleStateImageBehavior = false;
            this.lv_main_applications.View = System.Windows.Forms.View.Details;
            // 
            // lv_main_applications_due
            // 
            this.lv_main_applications_due.Text = "Due";
            this.lv_main_applications_due.Width = 50;
            // 
            // lv_main_applications_student
            // 
            this.lv_main_applications_student.Text = "Student";
            this.lv_main_applications_student.Width = 65;
            // 
            // lv_main_applications_timeLeft
            // 
            this.lv_main_applications_timeLeft.Text = "Time Left";
            this.lv_main_applications_timeLeft.Width = 35;
            // 
            // lv_main_details_name
            // 
            this.lv_main_details_name.Text = "Student";
            this.lv_main_details_name.Width = 65;
            // 
            // lv_main_details_dueDate
            // 
            this.lv_main_details_dueDate.Text = "Due";
            this.lv_main_details_dueDate.Width = 50;
            // 
            // lv_main_details
            // 
            this.lv_main_details.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_main_details.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_main_details_dueDate,
            this.lv_main_details_name,
            this.lv_main_details_timeLeft});
            this.lv_main_details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_main_details.FullRowSelect = true;
            this.lv_main_details.GridLines = true;
            this.lv_main_details.Location = new System.Drawing.Point(3, 16);
            this.lv_main_details.MultiSelect = false;
            this.lv_main_details.Name = "lv_main_details";
            this.lv_main_details.ShowGroups = false;
            this.lv_main_details.Size = new System.Drawing.Size(150, 141);
            this.lv_main_details.TabIndex = 0;
            this.lv_main_details.UseCompatibleStateImageBehavior = false;
            this.lv_main_details.View = System.Windows.Forms.View.Details;
            // 
            // lv_main_details_timeLeft
            // 
            this.lv_main_details_timeLeft.Text = "Time Left";
            this.lv_main_details_timeLeft.Width = 35;
            // 
            // group_main_details
            // 
            this.group_main_details.Controls.Add(this.lv_main_details);
            this.group_main_details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_main_details.Location = new System.Drawing.Point(0, 0);
            this.group_main_details.Margin = new System.Windows.Forms.Padding(0);
            this.group_main_details.Name = "group_main_details";
            this.group_main_details.Size = new System.Drawing.Size(156, 160);
            this.group_main_details.TabIndex = 1;
            this.group_main_details.TabStop = false;
            this.group_main_details.Text = "Student Details";
            // 
            // table_main
            // 
            this.table_main.ColumnCount = 1;
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_main.Controls.Add(this.group_main_details, 0, 0);
            this.table_main.Controls.Add(this.group_main_applications, 0, 1);
            this.table_main.Controls.Add(this.group_main_references, 0, 2);
            this.table_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_main.Location = new System.Drawing.Point(3, 3);
            this.table_main.Margin = new System.Windows.Forms.Padding(0);
            this.table_main.Name = "table_main";
            this.table_main.RowCount = 3;
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33556F));
            this.table_main.Size = new System.Drawing.Size(156, 483);
            this.table_main.TabIndex = 1;
            // 
            // group_main_references
            // 
            this.group_main_references.Controls.Add(this.lv_main_references);
            this.group_main_references.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_main_references.Location = new System.Drawing.Point(0, 320);
            this.group_main_references.Margin = new System.Windows.Forms.Padding(0);
            this.group_main_references.Name = "group_main_references";
            this.group_main_references.Size = new System.Drawing.Size(156, 163);
            this.group_main_references.TabIndex = 3;
            this.group_main_references.TabStop = false;
            this.group_main_references.Text = "References";
            // 
            // lv_main_references
            // 
            this.lv_main_references.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_main_references.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_main_references_due,
            this.lv_main_references_student,
            this.lv_main_references_timeLeft});
            this.lv_main_references.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_main_references.FullRowSelect = true;
            this.lv_main_references.GridLines = true;
            this.lv_main_references.Location = new System.Drawing.Point(3, 16);
            this.lv_main_references.MultiSelect = false;
            this.lv_main_references.Name = "lv_main_references";
            this.lv_main_references.ShowGroups = false;
            this.lv_main_references.Size = new System.Drawing.Size(150, 144);
            this.lv_main_references.TabIndex = 0;
            this.lv_main_references.UseCompatibleStateImageBehavior = false;
            this.lv_main_references.View = System.Windows.Forms.View.Details;
            // 
            // lv_main_references_due
            // 
            this.lv_main_references_due.Text = "Due";
            this.lv_main_references_due.Width = 50;
            // 
            // lv_main_references_student
            // 
            this.lv_main_references_student.Text = "Student";
            this.lv_main_references_student.Width = 65;
            // 
            // lv_main_references_timeLeft
            // 
            this.lv_main_references_timeLeft.Text = "Time Left";
            this.lv_main_references_timeLeft.Width = 35;
            // 
            // tab_all
            // 
            this.tab_all.Controls.Add(this.table_main);
            this.tab_all.Location = new System.Drawing.Point(4, 4);
            this.tab_all.Name = "tab_all";
            this.tab_all.Padding = new System.Windows.Forms.Padding(3);
            this.tab_all.Size = new System.Drawing.Size(162, 489);
            this.tab_all.TabIndex = 0;
            this.tab_all.Text = "All Tasks";
            this.tab_all.UseVisualStyleBackColor = true;
            // 
            // tabs
            // 
            this.tabs.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabs.Controls.Add(this.tab_all);
            this.tabs.Controls.Add(this.tab_details);
            this.tabs.Controls.Add(this.tab_applications);
            this.tabs.Controls.Add(this.tab_references);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(3, 16);
            this.tabs.Multiline = true;
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(189, 497);
            this.tabs.TabIndex = 2;
            // 
            // tab_details
            // 
            this.tab_details.Controls.Add(this.group_details);
            this.tab_details.Location = new System.Drawing.Point(4, 4);
            this.tab_details.Name = "tab_details";
            this.tab_details.Padding = new System.Windows.Forms.Padding(3);
            this.tab_details.Size = new System.Drawing.Size(162, 489);
            this.tab_details.TabIndex = 1;
            this.tab_details.Text = "Details";
            this.tab_details.UseVisualStyleBackColor = true;
            // 
            // group_details
            // 
            this.group_details.Controls.Add(this.lv_details);
            this.group_details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_details.Location = new System.Drawing.Point(3, 3);
            this.group_details.Name = "group_details";
            this.group_details.Size = new System.Drawing.Size(156, 483);
            this.group_details.TabIndex = 2;
            this.group_details.TabStop = false;
            this.group_details.Text = "Student Details";
            // 
            // lv_details
            // 
            this.lv_details.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_details.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_details_dueDate,
            this.lv_details_student,
            this.lv_details_timeLeft});
            this.lv_details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_details.FullRowSelect = true;
            this.lv_details.GridLines = true;
            this.lv_details.Location = new System.Drawing.Point(3, 16);
            this.lv_details.MultiSelect = false;
            this.lv_details.Name = "lv_details";
            this.lv_details.ShowGroups = false;
            this.lv_details.Size = new System.Drawing.Size(150, 464);
            this.lv_details.TabIndex = 2;
            this.lv_details.UseCompatibleStateImageBehavior = false;
            this.lv_details.View = System.Windows.Forms.View.Details;
            // 
            // lv_details_dueDate
            // 
            this.lv_details_dueDate.Text = "Due";
            this.lv_details_dueDate.Width = 50;
            // 
            // lv_details_student
            // 
            this.lv_details_student.Text = "Student";
            this.lv_details_student.Width = 65;
            // 
            // lv_details_timeLeft
            // 
            this.lv_details_timeLeft.Text = "Time Left";
            this.lv_details_timeLeft.Width = 35;
            // 
            // tab_applications
            // 
            this.tab_applications.Controls.Add(this.group_applications);
            this.tab_applications.Location = new System.Drawing.Point(4, 4);
            this.tab_applications.Name = "tab_applications";
            this.tab_applications.Padding = new System.Windows.Forms.Padding(3);
            this.tab_applications.Size = new System.Drawing.Size(162, 489);
            this.tab_applications.TabIndex = 2;
            this.tab_applications.Text = "Applications";
            this.tab_applications.UseVisualStyleBackColor = true;
            // 
            // group_applications
            // 
            this.group_applications.Controls.Add(this.lv_applications);
            this.group_applications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_applications.Location = new System.Drawing.Point(3, 3);
            this.group_applications.Name = "group_applications";
            this.group_applications.Size = new System.Drawing.Size(156, 483);
            this.group_applications.TabIndex = 2;
            this.group_applications.TabStop = false;
            this.group_applications.Text = "Applications";
            // 
            // lv_applications
            // 
            this.lv_applications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_applications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_applications_dueDate,
            this.lv_applications_student,
            this.lv_applications_timeLeft});
            this.lv_applications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_applications.FullRowSelect = true;
            this.lv_applications.GridLines = true;
            this.lv_applications.Location = new System.Drawing.Point(3, 16);
            this.lv_applications.MultiSelect = false;
            this.lv_applications.Name = "lv_applications";
            this.lv_applications.ShowGroups = false;
            this.lv_applications.Size = new System.Drawing.Size(150, 464);
            this.lv_applications.TabIndex = 1;
            this.lv_applications.UseCompatibleStateImageBehavior = false;
            this.lv_applications.View = System.Windows.Forms.View.Details;
            // 
            // lv_applications_dueDate
            // 
            this.lv_applications_dueDate.Text = "Due";
            this.lv_applications_dueDate.Width = 50;
            // 
            // lv_applications_student
            // 
            this.lv_applications_student.Text = "Student";
            this.lv_applications_student.Width = 65;
            // 
            // lv_applications_timeLeft
            // 
            this.lv_applications_timeLeft.Text = "Time Left";
            this.lv_applications_timeLeft.Width = 35;
            // 
            // tab_references
            // 
            this.tab_references.Controls.Add(this.group_references);
            this.tab_references.Location = new System.Drawing.Point(4, 4);
            this.tab_references.Name = "tab_references";
            this.tab_references.Padding = new System.Windows.Forms.Padding(3);
            this.tab_references.Size = new System.Drawing.Size(162, 489);
            this.tab_references.TabIndex = 3;
            this.tab_references.Text = "References";
            this.tab_references.UseVisualStyleBackColor = true;
            // 
            // group_references
            // 
            this.group_references.Controls.Add(this.lv_references);
            this.group_references.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_references.Location = new System.Drawing.Point(3, 3);
            this.group_references.Name = "group_references";
            this.group_references.Size = new System.Drawing.Size(156, 483);
            this.group_references.TabIndex = 2;
            this.group_references.TabStop = false;
            this.group_references.Text = "References";
            // 
            // lv_references
            // 
            this.lv_references.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_references.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_references_dueDate,
            this.lv_references_student,
            this.lv_references_timeLeft});
            this.lv_references.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_references.FullRowSelect = true;
            this.lv_references.GridLines = true;
            this.lv_references.Location = new System.Drawing.Point(3, 16);
            this.lv_references.MultiSelect = false;
            this.lv_references.Name = "lv_references";
            this.lv_references.ShowGroups = false;
            this.lv_references.Size = new System.Drawing.Size(150, 464);
            this.lv_references.TabIndex = 1;
            this.lv_references.UseCompatibleStateImageBehavior = false;
            this.lv_references.View = System.Windows.Forms.View.Details;
            // 
            // lv_references_dueDate
            // 
            this.lv_references_dueDate.Text = "Due";
            this.lv_references_dueDate.Width = 50;
            // 
            // lv_references_student
            // 
            this.lv_references_student.Text = "Student";
            this.lv_references_student.Width = 65;
            // 
            // lv_references_timeLeft
            // 
            this.lv_references_timeLeft.Text = "Time Left";
            this.lv_references_timeLeft.Width = 35;
            // 
            // group_taskList
            // 
            this.group_taskList.Controls.Add(this.tabs);
            this.group_taskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_taskList.Location = new System.Drawing.Point(0, 0);
            this.group_taskList.Name = "group_taskList";
            this.group_taskList.Size = new System.Drawing.Size(195, 516);
            this.group_taskList.TabIndex = 3;
            this.group_taskList.TabStop = false;
            this.group_taskList.Text = "Task List";
            // 
            // panels
            // 
            this.panels.BackColor = System.Drawing.Color.Transparent;
            this.panels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panels.Location = new System.Drawing.Point(0, 24);
            this.panels.Name = "panels";
            // 
            // panels.Panel1
            // 
            this.panels.Panel1.Controls.Add(this.group_dashboard);
            this.panels.Panel1MinSize = 585;
            // 
            // panels.Panel2
            // 
            this.panels.Panel2.Controls.Add(this.group_taskList);
            this.panels.Panel2MinSize = 195;
            this.panels.Size = new System.Drawing.Size(784, 516);
            this.panels.SplitterDistance = 585;
            this.panels.TabIndex = 7;
            // 
            // group_dashboard
            // 
            this.group_dashboard.Controls.Add(this.tableLayoutPanel1);
            this.group_dashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_dashboard.Location = new System.Drawing.Point(0, 0);
            this.group_dashboard.Name = "group_dashboard";
            this.group_dashboard.Size = new System.Drawing.Size(585, 516);
            this.group_dashboard.TabIndex = 0;
            this.group_dashboard.TabStop = false;
            this.group_dashboard.Text = "Dashboard";
            // 
            // context_hideOnMin
            // 
            this.context_hideOnMin.CheckOnClick = true;
            this.context_hideOnMin.Name = "context_hideOnMin";
            this.context_hideOnMin.Size = new System.Drawing.Size(192, 22);
            this.context_hideOnMin.Text = "&Hide When Minimised";
            // 
            // context_menu_separator
            // 
            this.context_menu_separator.Name = "context_menu_separator";
            this.context_menu_separator.Size = new System.Drawing.Size(189, 6);
            // 
            // context_notify
            // 
            this.context_notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_notify_show,
            this.context_menu_separator,
            this.context_hideOnMin});
            this.context_notify.Name = "context_notify";
            this.context_notify.Size = new System.Drawing.Size(193, 54);
            // 
            // context_notify_show
            // 
            this.context_notify_show.Name = "context_notify_show";
            this.context_notify_show.Size = new System.Drawing.Size(192, 22);
            this.context_notify_show.Text = "&Show";
            // 
            // notify_icon
            // 
            this.notify_icon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify_icon.ContextMenuStrip = this.context_notify;
            this.notify_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("notify_icon.Icon")));
            this.notify_icon.Text = "UCAS Sys";
            this.notify_icon.Visible = true;
            // 
            // server_poll
            // 
            this.server_poll.WorkerReportsProgress = true;
            // 
            // clock
            // 
            this.clock.Enabled = true;
            this.clock.Interval = 1000;
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // status_main_time
            // 
            this.status_main_time.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.status_main_time.Name = "status_main_time";
            this.status_main_time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.status_main_time.Size = new System.Drawing.Size(95, 17);
            this.status_main_time.Text = "01/01/2015 00:00";
            // 
            // status_main_separator_2
            // 
            this.status_main_separator_2.Name = "status_main_separator_2";
            this.status_main_separator_2.Size = new System.Drawing.Size(302, 17);
            this.status_main_separator_2.Spring = true;
            this.status_main_separator_2.Text = " ";
            // 
            // status_main_accountType_label
            // 
            this.status_main_accountType_label.Name = "status_main_accountType_label";
            this.status_main_accountType_label.Size = new System.Drawing.Size(0, 17);
            // 
            // status_main_separator_1
            // 
            this.status_main_separator_1.Name = "status_main_separator_1";
            this.status_main_separator_1.Size = new System.Drawing.Size(302, 17);
            this.status_main_separator_1.Spring = true;
            this.status_main_separator_1.Text = " ";
            // 
            // status_main_loggedInAs
            // 
            this.status_main_loggedInAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.status_main_loggedInAs.Name = "status_main_loggedInAs";
            this.status_main_loggedInAs.Size = new System.Drawing.Size(70, 17);
            this.status_main_loggedInAs.Text = "Logged Out";
            // 
            // menu_main_help_about
            // 
            this.menu_main_help_about.Name = "menu_main_help_about";
            this.menu_main_help_about.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menu_main_help_about.Size = new System.Drawing.Size(126, 22);
            this.menu_main_help_about.Text = "&About";
            // 
            // status_main
            // 
            this.status_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_main_loggedInAs,
            this.status_main_separator_1,
            this.status_main_accountType_label,
            this.status_main_accountType,
            this.status_main_separator_2,
            this.status_main_time});
            this.status_main.Location = new System.Drawing.Point(0, 540);
            this.status_main.Name = "status_main";
            this.status_main.Size = new System.Drawing.Size(784, 22);
            this.status_main.TabIndex = 6;
            // 
            // status_main_accountType
            // 
            this.status_main_accountType.Name = "status_main_accountType";
            this.status_main_accountType.Size = new System.Drawing.Size(0, 17);
            // 
            // menu_main_help
            // 
            this.menu_main_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_help_about});
            this.menu_main_help.Name = "menu_main_help";
            this.menu_main_help.Size = new System.Drawing.Size(44, 20);
            this.menu_main_help.Text = "&Help";
            // 
            // menu_main_references
            // 
            this.menu_main_references.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_references_new,
            this.menu_main_references_search});
            this.menu_main_references.Name = "menu_main_references";
            this.menu_main_references.Size = new System.Drawing.Size(76, 20);
            this.menu_main_references.Text = "&References";
            // 
            // menu_main_references_new
            // 
            this.menu_main_references_new.Name = "menu_main_references_new";
            this.menu_main_references_new.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menu_main_references_new.Size = new System.Drawing.Size(154, 22);
            this.menu_main_references_new.Text = "&New";
            // 
            // menu_main_references_search
            // 
            this.menu_main_references_search.Name = "menu_main_references_search";
            this.menu_main_references_search.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F4)));
            this.menu_main_references_search.Size = new System.Drawing.Size(154, 22);
            this.menu_main_references_search.Text = "&Open";
            // 
            // menu_main_applications_open
            // 
            this.menu_main_applications_open.Name = "menu_main_applications_open";
            this.menu_main_applications_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.menu_main_applications_open.Size = new System.Drawing.Size(154, 22);
            this.menu_main_applications_open.Text = "&Open";
            // 
            // menu_main_applications_new
            // 
            this.menu_main_applications_new.Name = "menu_main_applications_new";
            this.menu_main_applications_new.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menu_main_applications_new.Size = new System.Drawing.Size(154, 22);
            this.menu_main_applications_new.Text = "&New";
            // 
            // menu_main_applications
            // 
            this.menu_main_applications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_applications_new,
            this.menu_main_applications_open});
            this.menu_main_applications.Name = "menu_main_applications";
            this.menu_main_applications.Size = new System.Drawing.Size(85, 20);
            this.menu_main_applications.Text = "&Applications";
            // 
            // menu_main_student_open
            // 
            this.menu_main_student_open.Name = "menu_main_student_open";
            this.menu_main_student_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F2)));
            this.menu_main_student_open.Size = new System.Drawing.Size(154, 22);
            this.menu_main_student_open.Text = "&Open";
            // 
            // menu_main_student_new
            // 
            this.menu_main_student_new.Name = "menu_main_student_new";
            this.menu_main_student_new.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menu_main_student_new.Size = new System.Drawing.Size(154, 22);
            this.menu_main_student_new.Text = "New";
            // 
            // menu_main_student
            // 
            this.menu_main_student.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_student_new,
            this.menu_main_student_open});
            this.menu_main_student.Name = "menu_main_student";
            this.menu_main_student.Size = new System.Drawing.Size(65, 20);
            this.menu_main_student.Text = "&Students";
            // 
            // menu_main_file_exit
            // 
            this.menu_main_file_exit.Name = "menu_main_file_exit";
            this.menu_main_file_exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menu_main_file_exit.Size = new System.Drawing.Size(168, 22);
            this.menu_main_file_exit.Text = "E&xit";
            // 
            // menu_main_file_logout
            // 
            this.menu_main_file_logout.Name = "menu_main_file_logout";
            this.menu_main_file_logout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.menu_main_file_logout.Size = new System.Drawing.Size(168, 22);
            this.menu_main_file_logout.Text = "&Logout";
            // 
            // menu_main_file_separator_logout
            // 
            this.menu_main_file_separator_logout.Name = "menu_main_file_separator_logout";
            this.menu_main_file_separator_logout.Size = new System.Drawing.Size(165, 6);
            // 
            // menu_main_file_database_restore
            // 
            this.menu_main_file_database_restore.Name = "menu_main_file_database_restore";
            this.menu_main_file_database_restore.Size = new System.Drawing.Size(113, 22);
            this.menu_main_file_database_restore.Text = "&Restore";
            // 
            // menu_main_file_database_backup
            // 
            this.menu_main_file_database_backup.Name = "menu_main_file_database_backup";
            this.menu_main_file_database_backup.Size = new System.Drawing.Size(113, 22);
            this.menu_main_file_database_backup.Text = "&Backup";
            // 
            // menu_main_file_database
            // 
            this.menu_main_file_database.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_file_database_backup,
            this.menu_main_file_database_restore});
            this.menu_main_file_database.Name = "menu_main_file_database";
            this.menu_main_file_database.Size = new System.Drawing.Size(168, 22);
            this.menu_main_file_database.Text = "&Database";
            // 
            // menu_main_file_separator_database
            // 
            this.menu_main_file_separator_database.Name = "menu_main_file_separator_database";
            this.menu_main_file_separator_database.Size = new System.Drawing.Size(165, 6);
            // 
            // menu_main_file_changePassword
            // 
            this.menu_main_file_changePassword.Name = "menu_main_file_changePassword";
            this.menu_main_file_changePassword.Size = new System.Drawing.Size(168, 22);
            this.menu_main_file_changePassword.Text = "Change &Password";
            // 
            // menu_main_file
            // 
            this.menu_main_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_file_new,
            this.menu_main_file_open,
            this.menu_main_file_separator_database,
            this.menu_main_file_database,
            this.menu_main_file_separator_password,
            this.menu_main_file_changePassword,
            this.menu_main_file_separator_logout,
            this.menu_main_file_logout,
            this.menu_main_file_exit});
            this.menu_main_file.Name = "menu_main_file";
            this.menu_main_file.Size = new System.Drawing.Size(37, 20);
            this.menu_main_file.Text = "&File";
            // 
            // menu_main_file_new
            // 
            this.menu_main_file_new.Name = "menu_main_file_new";
            this.menu_main_file_new.Size = new System.Drawing.Size(168, 22);
            this.menu_main_file_new.Text = "&New";
            // 
            // menu_main_file_open
            // 
            this.menu_main_file_open.Name = "menu_main_file_open";
            this.menu_main_file_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menu_main_file_open.Size = new System.Drawing.Size(168, 22);
            this.menu_main_file_open.Text = "O&pen";
            // 
            // menu_main_file_separator_password
            // 
            this.menu_main_file_separator_password.Name = "menu_main_file_separator_password";
            this.menu_main_file_separator_password.Size = new System.Drawing.Size(165, 6);
            // 
            // menu_main
            // 
            this.menu_main.AutoSize = false;
            this.menu_main.BackColor = System.Drawing.SystemColors.Control;
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_file,
            this.menu_main_student,
            this.menu_main_applications,
            this.menu_main_references,
            this.menu_main_reports,
            this.menu_main_tools,
            this.menu_main_window,
            this.menu_main_help});
            this.menu_main.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.MdiWindowListItem = this.menu_main_window;
            this.menu_main.Name = "menu_main";
            this.menu_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu_main.Size = new System.Drawing.Size(784, 24);
            this.menu_main.TabIndex = 5;
            this.menu_main.Text = "MainMenu";
            // 
            // menu_main_reports
            // 
            this.menu_main_reports.Name = "menu_main_reports";
            this.menu_main_reports.Size = new System.Drawing.Size(59, 20);
            this.menu_main_reports.Text = "Re&ports";
            // 
            // menu_main_tools
            // 
            this.menu_main_tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_tools_users,
            this.menu_main_tools_separator_users,
            this.menu_main_tools_subjects,
            this.menu_main_tools_universities,
            this.menu_main_tools_separator_admin,
            this.menu_main_tools_options});
            this.menu_main_tools.Name = "menu_main_tools";
            this.menu_main_tools.Size = new System.Drawing.Size(47, 20);
            this.menu_main_tools.Text = "&Tools";
            // 
            // menu_main_tools_users
            // 
            this.menu_main_tools_users.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_tools_users_new,
            this.menu_main_tools_users_view});
            this.menu_main_tools_users.Name = "menu_main_tools_users";
            this.menu_main_tools_users.Size = new System.Drawing.Size(157, 22);
            this.menu_main_tools_users.Text = "&Users";
            // 
            // menu_main_tools_users_new
            // 
            this.menu_main_tools_users_new.Name = "menu_main_tools_users_new";
            this.menu_main_tools_users_new.Size = new System.Drawing.Size(99, 22);
            this.menu_main_tools_users_new.Text = "&New";
            // 
            // menu_main_tools_users_view
            // 
            this.menu_main_tools_users_view.Name = "menu_main_tools_users_view";
            this.menu_main_tools_users_view.Size = new System.Drawing.Size(99, 22);
            this.menu_main_tools_users_view.Text = "&View";
            // 
            // menu_main_tools_separator_users
            // 
            this.menu_main_tools_separator_users.Name = "menu_main_tools_separator_users";
            this.menu_main_tools_separator_users.Size = new System.Drawing.Size(154, 6);
            // 
            // menu_main_tools_subjects
            // 
            this.menu_main_tools_subjects.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_tools_subjects_new,
            this.menu_main_tools_subjects_view});
            this.menu_main_tools_subjects.Name = "menu_main_tools_subjects";
            this.menu_main_tools_subjects.Size = new System.Drawing.Size(157, 22);
            this.menu_main_tools_subjects.Text = "&Subjects";
            // 
            // menu_main_tools_subjects_new
            // 
            this.menu_main_tools_subjects_new.Name = "menu_main_tools_subjects_new";
            this.menu_main_tools_subjects_new.Size = new System.Drawing.Size(99, 22);
            this.menu_main_tools_subjects_new.Text = "&New";
            // 
            // menu_main_tools_subjects_view
            // 
            this.menu_main_tools_subjects_view.Name = "menu_main_tools_subjects_view";
            this.menu_main_tools_subjects_view.Size = new System.Drawing.Size(99, 22);
            this.menu_main_tools_subjects_view.Text = "&View";
            // 
            // menu_main_tools_universities
            // 
            this.menu_main_tools_universities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_tools_universities_new,
            this.menu_main_tools_universities_view});
            this.menu_main_tools_universities.Name = "menu_main_tools_universities";
            this.menu_main_tools_universities.Size = new System.Drawing.Size(157, 22);
            this.menu_main_tools_universities.Text = "Uni&versities";
            // 
            // menu_main_tools_universities_new
            // 
            this.menu_main_tools_universities_new.Name = "menu_main_tools_universities_new";
            this.menu_main_tools_universities_new.Size = new System.Drawing.Size(99, 22);
            this.menu_main_tools_universities_new.Text = "&New";
            // 
            // menu_main_tools_universities_view
            // 
            this.menu_main_tools_universities_view.Name = "menu_main_tools_universities_view";
            this.menu_main_tools_universities_view.Size = new System.Drawing.Size(99, 22);
            this.menu_main_tools_universities_view.Text = "&View";
            // 
            // menu_main_tools_separator_admin
            // 
            this.menu_main_tools_separator_admin.Name = "menu_main_tools_separator_admin";
            this.menu_main_tools_separator_admin.Size = new System.Drawing.Size(154, 6);
            // 
            // menu_main_tools_options
            // 
            this.menu_main_tools_options.Name = "menu_main_tools_options";
            this.menu_main_tools_options.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menu_main_tools_options.Size = new System.Drawing.Size(157, 22);
            this.menu_main_tools_options.Text = "&Options";
            // 
            // menu_main_window
            // 
            this.menu_main_window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_window_closeAll});
            this.menu_main_window.Name = "menu_main_window";
            this.menu_main_window.Size = new System.Drawing.Size(63, 20);
            this.menu_main_window.Text = "&Window";
            // 
            // menu_main_window_closeAll
            // 
            this.menu_main_window_closeAll.Name = "menu_main_window_closeAll";
            this.menu_main_window_closeAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.W)));
            this.menu_main_window_closeAll.Size = new System.Drawing.Size(188, 22);
            this.menu_main_window_closeAll.Text = "Close &All";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 497);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panels);
            this.Controls.Add(this.status_main);
            this.Controls.Add(this.menu_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "main";
            this.Text = "UCAS System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_Main_Load);
            this.group_main_applications.ResumeLayout(false);
            this.group_main_details.ResumeLayout(false);
            this.table_main.ResumeLayout(false);
            this.group_main_references.ResumeLayout(false);
            this.tab_all.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tab_details.ResumeLayout(false);
            this.group_details.ResumeLayout(false);
            this.tab_applications.ResumeLayout(false);
            this.group_applications.ResumeLayout(false);
            this.tab_references.ResumeLayout(false);
            this.group_references.ResumeLayout(false);
            this.group_taskList.ResumeLayout(false);
            this.panels.Panel1.ResumeLayout(false);
            this.panels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panels)).EndInit();
            this.panels.ResumeLayout(false);
            this.group_dashboard.ResumeLayout(false);
            this.context_notify.ResumeLayout(false);
            this.status_main.ResumeLayout(false);
            this.status_main.PerformLayout();
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox group_main_applications;
        internal System.Windows.Forms.ListView lv_main_applications;
        internal System.Windows.Forms.ColumnHeader lv_main_applications_due;
        internal System.Windows.Forms.ColumnHeader lv_main_applications_student;
        internal System.Windows.Forms.ColumnHeader lv_main_applications_timeLeft;
        internal System.Windows.Forms.ColumnHeader lv_main_details_name;
        internal System.Windows.Forms.ColumnHeader lv_main_details_dueDate;
        internal System.Windows.Forms.ListView lv_main_details;
        internal System.Windows.Forms.ColumnHeader lv_main_details_timeLeft;
        internal System.Windows.Forms.GroupBox group_main_details;
        internal System.Windows.Forms.TableLayoutPanel table_main;
        internal System.Windows.Forms.GroupBox group_main_references;
        internal System.Windows.Forms.ListView lv_main_references;
        internal System.Windows.Forms.ColumnHeader lv_main_references_due;
        internal System.Windows.Forms.ColumnHeader lv_main_references_student;
        internal System.Windows.Forms.ColumnHeader lv_main_references_timeLeft;
        internal System.Windows.Forms.TabPage tab_all;
        internal System.Windows.Forms.TabControl tabs;
        internal System.Windows.Forms.TabPage tab_details;
        internal System.Windows.Forms.GroupBox group_details;
        internal System.Windows.Forms.ListView lv_details;
        internal System.Windows.Forms.ColumnHeader lv_details_dueDate;
        internal System.Windows.Forms.ColumnHeader lv_details_student;
        internal System.Windows.Forms.ColumnHeader lv_details_timeLeft;
        internal System.Windows.Forms.TabPage tab_applications;
        internal System.Windows.Forms.GroupBox group_applications;
        internal System.Windows.Forms.ListView lv_applications;
        internal System.Windows.Forms.ColumnHeader lv_applications_dueDate;
        internal System.Windows.Forms.ColumnHeader lv_applications_student;
        internal System.Windows.Forms.ColumnHeader lv_applications_timeLeft;
        internal System.Windows.Forms.TabPage tab_references;
        internal System.Windows.Forms.GroupBox group_references;
        internal System.Windows.Forms.ListView lv_references;
        internal System.Windows.Forms.ColumnHeader lv_references_dueDate;
        internal System.Windows.Forms.ColumnHeader lv_references_student;
        internal System.Windows.Forms.ColumnHeader lv_references_timeLeft;
        internal System.Windows.Forms.GroupBox group_taskList;
        internal System.Windows.Forms.SplitContainer panels;
        internal System.Windows.Forms.GroupBox group_dashboard;
        internal System.Windows.Forms.ToolStripMenuItem context_hideOnMin;
        internal System.Windows.Forms.ToolStripSeparator context_menu_separator;
        internal System.Windows.Forms.ContextMenuStrip context_notify;
        internal System.Windows.Forms.ToolStripMenuItem context_notify_show;
        internal System.Windows.Forms.NotifyIcon notify_icon;
        internal System.ComponentModel.BackgroundWorker server_poll;
        internal System.Windows.Forms.Timer clock;
        internal System.Windows.Forms.ToolStripStatusLabel status_main_time;
        internal System.Windows.Forms.ToolStripStatusLabel status_main_separator_2;
        internal System.Windows.Forms.ToolStripStatusLabel status_main_accountType_label;
        internal System.Windows.Forms.ToolStripStatusLabel status_main_separator_1;
        internal System.Windows.Forms.ToolStripStatusLabel status_main_loggedInAs;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_help_about;
        internal System.Windows.Forms.StatusStrip status_main;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_help;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_references;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_references_search;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_applications_open;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_applications_new;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_applications;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_student_open;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_student_new;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_student;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_file_exit;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_file_logout;
        internal System.Windows.Forms.ToolStripSeparator menu_main_file_separator_logout;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_file_database_restore;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_file_database_backup;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_file_database;
        internal System.Windows.Forms.ToolStripSeparator menu_main_file_separator_database;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_file_changePassword;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_file;
        internal System.Windows.Forms.MenuStrip menu_main;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_reports;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_users;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_users_new;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_users_view;
        internal System.Windows.Forms.ToolStripSeparator menu_main_tools_separator_users;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_subjects;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_subjects_new;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_subjects_view;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_universities;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_universities_new;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_universities_view;
        internal System.Windows.Forms.ToolStripSeparator menu_main_tools_separator_admin;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_tools_options;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_window;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_window_closeAll;
        private System.Windows.Forms.ToolStripMenuItem menu_main_file_new;
        private System.Windows.Forms.ToolStripMenuItem menu_main_file_open;
        private System.Windows.Forms.ToolStripSeparator menu_main_file_separator_password;
        internal System.Windows.Forms.ToolStripStatusLabel status_main_accountType;
        internal System.Windows.Forms.ToolStripMenuItem menu_main_references_new;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
namespace UCASSys.Forms.Students
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
            this.table_quals = new System.Windows.Forms.TableLayoutPanel();
            this.btn_deleteQuals = new System.Windows.Forms.Button();
            this.btn_editQual = new System.Windows.Forms.Button();
            this.btn_addQuals = new System.Windows.Forms.Button();
            this.lv_quals = new System.Windows.Forms.ListView();
            this.lv_qual_level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_qual_board = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_qual_subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_qual_grade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_qual_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.context_qual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_qual_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.context_qual_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_quickAdd = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.group_notes = new System.Windows.Forms.GroupBox();
            this.table_notes = new System.Windows.Forms.TableLayoutPanel();
            this.label_notes = new System.Windows.Forms.Label();
            this.text_notes = new System.Windows.Forms.TextBox();
            this.group_personal = new System.Windows.Forms.GroupBox();
            this.table_personal = new System.Windows.Forms.TableLayoutPanel();
            this.btn_doPersonal = new System.Windows.Forms.Button();
            this.label_firstName = new System.Windows.Forms.Label();
            this.label_middleNames = new System.Windows.Forms.Label();
            this.label_lastName = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_DoB = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_phone = new System.Windows.Forms.Label();
            this.text_firstName = new System.Windows.Forms.TextBox();
            this.text_middleNames = new System.Windows.Forms.TextBox();
            this.text_lastName = new System.Windows.Forms.TextBox();
            this.text_email = new System.Windows.Forms.TextBox();
            this.text_phone = new System.Windows.Forms.TextBox();
            this.combo_gender = new System.Windows.Forms.ComboBox();
            this.datetime_DoB = new System.Windows.Forms.DateTimePicker();
            this.group_qual = new System.Windows.Forms.GroupBox();
            this.table_main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_completed = new System.Windows.Forms.Button();
            this.table_quals.SuspendLayout();
            this.context_qual.SuspendLayout();
            this.group_notes.SuspendLayout();
            this.table_notes.SuspendLayout();
            this.group_personal.SuspendLayout();
            this.table_personal.SuspendLayout();
            this.group_qual.SuspendLayout();
            this.table_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_quals
            // 
            this.table_quals.ColumnCount = 8;
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_quals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.table_quals.Controls.Add(this.btn_deleteQuals, 5, 1);
            this.table_quals.Controls.Add(this.btn_editQual, 4, 1);
            this.table_quals.Controls.Add(this.btn_addQuals, 3, 1);
            this.table_quals.Controls.Add(this.lv_quals, 0, 0);
            this.table_quals.Controls.Add(this.btn_quickAdd, 1, 1);
            this.table_quals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_quals.Location = new System.Drawing.Point(3, 16);
            this.table_quals.Name = "table_quals";
            this.table_quals.RowCount = 2;
            this.table_quals.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_quals.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_quals.Size = new System.Drawing.Size(772, 241);
            this.table_quals.TabIndex = 0;
            // 
            // btn_deleteQuals
            // 
            this.btn_deleteQuals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_deleteQuals.Enabled = false;
            this.btn_deleteQuals.Location = new System.Drawing.Point(423, 215);
            this.btn_deleteQuals.Name = "btn_deleteQuals";
            this.btn_deleteQuals.Size = new System.Drawing.Size(63, 23);
            this.btn_deleteQuals.TabIndex = 204;
            this.btn_deleteQuals.Text = "&Delete";
            this.btn_deleteQuals.UseVisualStyleBackColor = true;
            // 
            // btn_editQual
            // 
            this.btn_editQual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_editQual.Enabled = false;
            this.btn_editQual.Location = new System.Drawing.Point(354, 215);
            this.btn_editQual.Name = "btn_editQual";
            this.btn_editQual.Size = new System.Drawing.Size(63, 23);
            this.btn_editQual.TabIndex = 203;
            this.btn_editQual.Text = "&Edit";
            this.btn_editQual.UseVisualStyleBackColor = true;
            // 
            // btn_addQuals
            // 
            this.btn_addQuals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_addQuals.Location = new System.Drawing.Point(285, 215);
            this.btn_addQuals.Name = "btn_addQuals";
            this.btn_addQuals.Size = new System.Drawing.Size(63, 23);
            this.btn_addQuals.TabIndex = 202;
            this.btn_addQuals.Text = "&Add";
            this.btn_addQuals.UseVisualStyleBackColor = true;
            // 
            // lv_quals
            // 
            this.lv_quals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_qual_level,
            this.lv_qual_board,
            this.lv_qual_subject,
            this.lv_qual_grade,
            this.lv_qual_date});
            this.table_quals.SetColumnSpan(this.lv_quals, 8);
            this.lv_quals.ContextMenuStrip = this.context_qual;
            this.lv_quals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_quals.FullRowSelect = true;
            this.lv_quals.HideSelection = false;
            this.lv_quals.Location = new System.Drawing.Point(3, 3);
            this.lv_quals.Name = "lv_quals";
            this.lv_quals.Size = new System.Drawing.Size(766, 206);
            this.lv_quals.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_quals.TabIndex = 201;
            this.lv_quals.UseCompatibleStateImageBehavior = false;
            this.lv_quals.View = System.Windows.Forms.View.Details;
            // 
            // lv_qual_level
            // 
            this.lv_qual_level.Text = "Level";
            this.lv_qual_level.Width = 55;
            // 
            // lv_qual_board
            // 
            this.lv_qual_board.Text = "Board";
            this.lv_qual_board.Width = 175;
            // 
            // lv_qual_subject
            // 
            this.lv_qual_subject.Text = "Subject";
            this.lv_qual_subject.Width = 380;
            // 
            // lv_qual_grade
            // 
            this.lv_qual_grade.Text = "Grade";
            // 
            // lv_qual_date
            // 
            this.lv_qual_date.Text = "Date";
            this.lv_qual_date.Width = 90;
            // 
            // context_qual
            // 
            this.context_qual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_qual_edit,
            this.context_qual_delete});
            this.context_qual.Name = "context_qual";
            this.context_qual.Size = new System.Drawing.Size(108, 48);
            // 
            // context_qual_edit
            // 
            this.context_qual_edit.Name = "context_qual_edit";
            this.context_qual_edit.Size = new System.Drawing.Size(107, 22);
            this.context_qual_edit.Text = "&Edit";
            this.context_qual_edit.ToolTipText = "Edit this qualification.";
            // 
            // context_qual_delete
            // 
            this.context_qual_delete.Name = "context_qual_delete";
            this.context_qual_delete.Size = new System.Drawing.Size(107, 22);
            this.context_qual_delete.Text = "&Delete";
            this.context_qual_delete.ToolTipText = "Delete this qualification.";
            // 
            // btn_quickAdd
            // 
            this.btn_quickAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_quickAdd.Location = new System.Drawing.Point(23, 215);
            this.btn_quickAdd.Name = "btn_quickAdd";
            this.btn_quickAdd.Size = new System.Drawing.Size(83, 23);
            this.btn_quickAdd.TabIndex = 205;
            this.btn_quickAdd.Text = "&Quick Add";
            this.btn_quickAdd.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(395, 535);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(73, 23);
            this.btn_save.TabIndex = 401;
            this.btn_save.Text = "&Save";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_close.Location = new System.Drawing.Point(316, 535);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(73, 23);
            this.btn_close.TabIndex = 402;
            this.btn_close.Text = "&Close";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // group_notes
            // 
            this.table_main.SetColumnSpan(this.group_notes, 4);
            this.group_notes.Controls.Add(this.table_notes);
            this.group_notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_notes.Enabled = false;
            this.group_notes.Location = new System.Drawing.Point(395, 3);
            this.group_notes.Name = "group_notes";
            this.group_notes.Size = new System.Drawing.Size(386, 260);
            this.group_notes.TabIndex = 300;
            this.group_notes.TabStop = false;
            this.group_notes.Text = "Notes";
            // 
            // table_notes
            // 
            this.table_notes.ColumnCount = 5;
            this.table_notes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.table_notes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_notes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table_notes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_notes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.table_notes.Controls.Add(this.label_notes, 0, 0);
            this.table_notes.Controls.Add(this.text_notes, 1, 0);
            this.table_notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_notes.Location = new System.Drawing.Point(3, 16);
            this.table_notes.Name = "table_notes";
            this.table_notes.RowCount = 1;
            this.table_notes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_notes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.table_notes.Size = new System.Drawing.Size(380, 241);
            this.table_notes.TabIndex = 0;
            // 
            // label_notes
            // 
            this.label_notes.AutoSize = true;
            this.label_notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_notes.Location = new System.Drawing.Point(3, 0);
            this.label_notes.Name = "label_notes";
            this.label_notes.Size = new System.Drawing.Size(83, 241);
            this.label_notes.TabIndex = 0;
            this.label_notes.Text = "Notes";
            this.label_notes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_notes
            // 
            this.text_notes.AcceptsReturn = true;
            this.text_notes.AllowDrop = true;
            this.table_notes.SetColumnSpan(this.text_notes, 4);
            this.text_notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_notes.Location = new System.Drawing.Point(92, 3);
            this.text_notes.Multiline = true;
            this.text_notes.Name = "text_notes";
            this.text_notes.Size = new System.Drawing.Size(285, 235);
            this.text_notes.TabIndex = 301;
            // 
            // group_personal
            // 
            this.table_main.SetColumnSpan(this.group_personal, 4);
            this.group_personal.Controls.Add(this.table_personal);
            this.group_personal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_personal.Location = new System.Drawing.Point(3, 3);
            this.group_personal.Name = "group_personal";
            this.group_personal.Size = new System.Drawing.Size(386, 260);
            this.group_personal.TabIndex = 100;
            this.group_personal.TabStop = false;
            this.group_personal.Text = "Personal Information";
            // 
            // table_personal
            // 
            this.table_personal.ColumnCount = 5;
            this.table_personal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.table_personal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_personal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.table_personal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_personal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.table_personal.Controls.Add(this.btn_doPersonal, 2, 8);
            this.table_personal.Controls.Add(this.label_firstName, 0, 0);
            this.table_personal.Controls.Add(this.label_middleNames, 0, 1);
            this.table_personal.Controls.Add(this.label_lastName, 0, 2);
            this.table_personal.Controls.Add(this.label_gender, 0, 3);
            this.table_personal.Controls.Add(this.label_DoB, 0, 4);
            this.table_personal.Controls.Add(this.label_email, 0, 5);
            this.table_personal.Controls.Add(this.label_phone, 0, 6);
            this.table_personal.Controls.Add(this.text_firstName, 1, 0);
            this.table_personal.Controls.Add(this.text_middleNames, 1, 1);
            this.table_personal.Controls.Add(this.text_lastName, 1, 2);
            this.table_personal.Controls.Add(this.text_email, 1, 5);
            this.table_personal.Controls.Add(this.text_phone, 1, 6);
            this.table_personal.Controls.Add(this.combo_gender, 1, 3);
            this.table_personal.Controls.Add(this.datetime_DoB, 1, 4);
            this.table_personal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_personal.Location = new System.Drawing.Point(3, 16);
            this.table_personal.Name = "table_personal";
            this.table_personal.RowCount = 9;
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_personal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_personal.Size = new System.Drawing.Size(380, 241);
            this.table_personal.TabIndex = 0;
            // 
            // btn_doPersonal
            // 
            this.btn_doPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_doPersonal.Location = new System.Drawing.Point(138, 215);
            this.btn_doPersonal.Name = "btn_doPersonal";
            this.btn_doPersonal.Size = new System.Drawing.Size(103, 23);
            this.btn_doPersonal.TabIndex = 0;
            this.btn_doPersonal.Text = "Add &Personal Info";
            this.btn_doPersonal.UseVisualStyleBackColor = true;
            // 
            // label_firstName
            // 
            this.label_firstName.AutoSize = true;
            this.label_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_firstName.Location = new System.Drawing.Point(3, 0);
            this.label_firstName.Name = "label_firstName";
            this.label_firstName.Size = new System.Drawing.Size(83, 29);
            this.label_firstName.TabIndex = 0;
            this.label_firstName.Text = "First Name";
            this.label_firstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_middleNames
            // 
            this.label_middleNames.AutoSize = true;
            this.label_middleNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_middleNames.Location = new System.Drawing.Point(3, 29);
            this.label_middleNames.Name = "label_middleNames";
            this.label_middleNames.Size = new System.Drawing.Size(83, 29);
            this.label_middleNames.TabIndex = 0;
            this.label_middleNames.Text = "Middle Name(s)";
            this.label_middleNames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_lastName
            // 
            this.label_lastName.AutoSize = true;
            this.label_lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_lastName.Location = new System.Drawing.Point(3, 58);
            this.label_lastName.Name = "label_lastName";
            this.label_lastName.Size = new System.Drawing.Size(83, 29);
            this.label_lastName.TabIndex = 0;
            this.label_lastName.Text = "Last Name";
            this.label_lastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_gender.Location = new System.Drawing.Point(3, 87);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(83, 29);
            this.label_gender.TabIndex = 0;
            this.label_gender.Text = "Gender";
            this.label_gender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_DoB
            // 
            this.label_DoB.AutoSize = true;
            this.label_DoB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DoB.Location = new System.Drawing.Point(3, 116);
            this.label_DoB.Name = "label_DoB";
            this.label_DoB.Size = new System.Drawing.Size(83, 29);
            this.label_DoB.TabIndex = 0;
            this.label_DoB.Text = "Date of Birth";
            this.label_DoB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_email.Location = new System.Drawing.Point(3, 145);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(83, 29);
            this.label_email.TabIndex = 0;
            this.label_email.Text = "Email";
            this.label_email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_phone.Location = new System.Drawing.Point(3, 174);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(83, 29);
            this.label_phone.TabIndex = 0;
            this.label_phone.Text = "Phone";
            this.label_phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_firstName
            // 
            this.table_personal.SetColumnSpan(this.text_firstName, 4);
            this.text_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_firstName.Location = new System.Drawing.Point(92, 3);
            this.text_firstName.Name = "text_firstName";
            this.text_firstName.ReadOnly = true;
            this.text_firstName.Size = new System.Drawing.Size(285, 20);
            this.text_firstName.TabIndex = 101;
            // 
            // text_middleNames
            // 
            this.table_personal.SetColumnSpan(this.text_middleNames, 4);
            this.text_middleNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_middleNames.Location = new System.Drawing.Point(92, 32);
            this.text_middleNames.Name = "text_middleNames";
            this.text_middleNames.ReadOnly = true;
            this.text_middleNames.Size = new System.Drawing.Size(285, 20);
            this.text_middleNames.TabIndex = 102;
            // 
            // text_lastName
            // 
            this.table_personal.SetColumnSpan(this.text_lastName, 4);
            this.text_lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_lastName.Location = new System.Drawing.Point(92, 61);
            this.text_lastName.Name = "text_lastName";
            this.text_lastName.ReadOnly = true;
            this.text_lastName.Size = new System.Drawing.Size(285, 20);
            this.text_lastName.TabIndex = 103;
            // 
            // text_email
            // 
            this.table_personal.SetColumnSpan(this.text_email, 4);
            this.text_email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_email.Location = new System.Drawing.Point(92, 148);
            this.text_email.Name = "text_email";
            this.text_email.ReadOnly = true;
            this.text_email.Size = new System.Drawing.Size(285, 20);
            this.text_email.TabIndex = 13;
            // 
            // text_phone
            // 
            this.table_personal.SetColumnSpan(this.text_phone, 4);
            this.text_phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_phone.Location = new System.Drawing.Point(92, 177);
            this.text_phone.Name = "text_phone";
            this.text_phone.ReadOnly = true;
            this.text_phone.Size = new System.Drawing.Size(285, 20);
            this.text_phone.TabIndex = 14;
            // 
            // combo_gender
            // 
            this.table_personal.SetColumnSpan(this.combo_gender, 4);
            this.combo_gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_gender.Enabled = false;
            this.combo_gender.FormattingEnabled = true;
            this.combo_gender.Location = new System.Drawing.Point(92, 90);
            this.combo_gender.Name = "combo_gender";
            this.combo_gender.Size = new System.Drawing.Size(285, 21);
            this.combo_gender.TabIndex = 104;
            // 
            // datetime_DoB
            // 
            this.table_personal.SetColumnSpan(this.datetime_DoB, 4);
            this.datetime_DoB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datetime_DoB.Enabled = false;
            this.datetime_DoB.Location = new System.Drawing.Point(92, 119);
            this.datetime_DoB.MaxDate = new System.DateTime(2015, 12, 31, 0, 0, 0, 0);
            this.datetime_DoB.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.datetime_DoB.Name = "datetime_DoB";
            this.datetime_DoB.Size = new System.Drawing.Size(285, 20);
            this.datetime_DoB.TabIndex = 105;
            // 
            // group_qual
            // 
            this.table_main.SetColumnSpan(this.group_qual, 8);
            this.group_qual.Controls.Add(this.table_quals);
            this.group_qual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_qual.Enabled = false;
            this.group_qual.Location = new System.Drawing.Point(3, 269);
            this.group_qual.Name = "group_qual";
            this.group_qual.Size = new System.Drawing.Size(778, 260);
            this.group_qual.TabIndex = 200;
            this.group_qual.TabStop = false;
            this.group_qual.Text = "Qualifications";
            // 
            // table_main
            // 
            this.table_main.ColumnCount = 8;
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_main.Controls.Add(this.group_personal, 0, 0);
            this.table_main.Controls.Add(this.group_qual, 0, 1);
            this.table_main.Controls.Add(this.btn_save, 4, 2);
            this.table_main.Controls.Add(this.btn_close, 3, 2);
            this.table_main.Controls.Add(this.group_notes, 4, 0);
            this.table_main.Controls.Add(this.btn_completed, 6, 2);
            this.table_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_main.Location = new System.Drawing.Point(0, 0);
            this.table_main.Name = "table_main";
            this.table_main.RowCount = 3;
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.Size = new System.Drawing.Size(784, 561);
            this.table_main.TabIndex = 1;
            // 
            // btn_completed
            // 
            this.btn_completed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_completed.Enabled = false;
            this.btn_completed.Location = new System.Drawing.Point(561, 535);
            this.btn_completed.Name = "btn_completed";
            this.btn_completed.Size = new System.Drawing.Size(133, 23);
            this.btn_completed.TabIndex = 403;
            this.btn_completed.Text = "Set &Complete";
            this.btn_completed.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.table_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "main";
            this.Text = "Do Student";
            this.table_quals.ResumeLayout(false);
            this.context_qual.ResumeLayout(false);
            this.group_notes.ResumeLayout(false);
            this.table_notes.ResumeLayout(false);
            this.table_notes.PerformLayout();
            this.group_personal.ResumeLayout(false);
            this.table_personal.ResumeLayout(false);
            this.table_personal.PerformLayout();
            this.group_qual.ResumeLayout(false);
            this.table_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel table_quals;
        internal System.Windows.Forms.Button btn_deleteQuals;
        internal System.Windows.Forms.Button btn_editQual;
        internal System.Windows.Forms.Button btn_addQuals;
        internal System.Windows.Forms.ListView lv_quals;
        internal System.Windows.Forms.ColumnHeader lv_qual_level;
        internal System.Windows.Forms.ColumnHeader lv_qual_board;
        internal System.Windows.Forms.ColumnHeader lv_qual_subject;
        internal System.Windows.Forms.ColumnHeader lv_qual_grade;
        internal System.Windows.Forms.ColumnHeader lv_qual_date;
        internal System.Windows.Forms.ContextMenuStrip context_qual;
        internal System.Windows.Forms.ToolStripMenuItem context_qual_edit;
        internal System.Windows.Forms.ToolStripMenuItem context_qual_delete;
        internal System.Windows.Forms.Button btn_save;
        internal System.Windows.Forms.Button btn_close;
        internal System.Windows.Forms.GroupBox group_notes;
        internal System.Windows.Forms.TableLayoutPanel table_main;
        internal System.Windows.Forms.GroupBox group_personal;
        internal System.Windows.Forms.TableLayoutPanel table_personal;
        internal System.Windows.Forms.Button btn_doPersonal;
        internal System.Windows.Forms.Label label_firstName;
        internal System.Windows.Forms.Label label_middleNames;
        internal System.Windows.Forms.Label label_lastName;
        internal System.Windows.Forms.Label label_gender;
        internal System.Windows.Forms.Label label_DoB;
        internal System.Windows.Forms.Label label_email;
        internal System.Windows.Forms.Label label_phone;
        internal System.Windows.Forms.TextBox text_firstName;
        internal System.Windows.Forms.TextBox text_middleNames;
        internal System.Windows.Forms.TextBox text_lastName;
        internal System.Windows.Forms.TextBox text_email;
        internal System.Windows.Forms.TextBox text_phone;
        internal System.Windows.Forms.ComboBox combo_gender;
        internal System.Windows.Forms.DateTimePicker datetime_DoB;
        internal System.Windows.Forms.GroupBox group_qual;
        internal System.Windows.Forms.TableLayoutPanel table_notes;
        internal System.Windows.Forms.Label label_notes;
        internal System.Windows.Forms.TextBox text_notes;
        private System.Windows.Forms.Button btn_completed;
        private System.Windows.Forms.Button btn_quickAdd;
    }
}
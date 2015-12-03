namespace UCASSys.Forms.Setup
{
    partial class confirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(confirm));
            this.tooltip_check_pwd = new System.Windows.Forms.ToolTip(this.components);
            this.check_pwd_show = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.text_username = new System.Windows.Forms.TextBox();
            this.text_firstName = new System.Windows.Forms.TextBox();
            this.text_lastName = new System.Windows.Forms.TextBox();
            this.text_email = new System.Windows.Forms.TextBox();
            this.text_password = new System.Windows.Forms.TextBox();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_finish = new System.Windows.Forms.Button();
            this.label_database = new System.Windows.Forms.Label();
            this.text_database = new System.Windows.Forms.TextBox();
            this.text_info = new System.Windows.Forms.TextBox();
            this.table_main = new System.Windows.Forms.TableLayoutPanel();
            this.table_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tooltip_check_pwd
            // 
            this.tooltip_check_pwd.AutomaticDelay = 100;
            // 
            // check_pwd_show
            // 
            this.check_pwd_show.AutoSize = true;
            this.check_pwd_show.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_pwd_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.check_pwd_show.Location = new System.Drawing.Point(278, 202);
            this.check_pwd_show.Name = "check_pwd_show";
            this.check_pwd_show.Size = new System.Drawing.Size(23, 23);
            this.check_pwd_show.TabIndex = 10;
            this.tooltip_check_pwd.SetToolTip(this.check_pwd_show, "Check to show password");
            this.check_pwd_show.UseVisualStyleBackColor = true;
            this.check_pwd_show.CheckedChanged += new System.EventHandler(this.check_pwd_show_CheckedChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.table_main.SetColumnSpan(this.Label1, 2);
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(3, 83);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(93, 29);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Username";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.table_main.SetColumnSpan(this.Label2, 2);
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Location = new System.Drawing.Point(3, 112);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(93, 29);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "First Name";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.table_main.SetColumnSpan(this.Label3, 2);
            this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label3.Location = new System.Drawing.Point(3, 141);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(93, 29);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Last Name";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.table_main.SetColumnSpan(this.Label4, 2);
            this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label4.Location = new System.Drawing.Point(3, 170);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(93, 29);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Email Address";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.table_main.SetColumnSpan(this.Label5, 2);
            this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label5.Location = new System.Drawing.Point(3, 199);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(93, 29);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Password";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_username
            // 
            this.table_main.SetColumnSpan(this.text_username, 5);
            this.text_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_username.Location = new System.Drawing.Point(102, 86);
            this.text_username.Name = "text_username";
            this.text_username.ReadOnly = true;
            this.text_username.Size = new System.Drawing.Size(170, 20);
            this.text_username.TabIndex = 5;
            // 
            // text_firstName
            // 
            this.table_main.SetColumnSpan(this.text_firstName, 5);
            this.text_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_firstName.Location = new System.Drawing.Point(102, 115);
            this.text_firstName.Name = "text_firstName";
            this.text_firstName.ReadOnly = true;
            this.text_firstName.Size = new System.Drawing.Size(170, 20);
            this.text_firstName.TabIndex = 6;
            // 
            // text_lastName
            // 
            this.table_main.SetColumnSpan(this.text_lastName, 5);
            this.text_lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_lastName.Location = new System.Drawing.Point(102, 144);
            this.text_lastName.Name = "text_lastName";
            this.text_lastName.ReadOnly = true;
            this.text_lastName.Size = new System.Drawing.Size(170, 20);
            this.text_lastName.TabIndex = 7;
            // 
            // text_email
            // 
            this.table_main.SetColumnSpan(this.text_email, 5);
            this.text_email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_email.Location = new System.Drawing.Point(102, 173);
            this.text_email.Name = "text_email";
            this.text_email.ReadOnly = true;
            this.text_email.Size = new System.Drawing.Size(170, 20);
            this.text_email.TabIndex = 8;
            // 
            // text_password
            // 
            this.table_main.SetColumnSpan(this.text_password, 5);
            this.text_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_password.Location = new System.Drawing.Point(102, 202);
            this.text_password.Name = "text_password";
            this.text_password.ReadOnly = true;
            this.text_password.Size = new System.Drawing.Size(170, 20);
            this.text_password.TabIndex = 9;
            this.text_password.UseSystemPasswordChar = true;
            // 
            // btn_edit
            // 
            this.table_main.SetColumnSpan(this.btn_edit, 3);
            this.btn_edit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_edit.Location = new System.Drawing.Point(32, 231);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(117, 23);
            this.btn_edit.TabIndex = 11;
            this.btn_edit.Text = "&Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // btn_finish
            // 
            this.table_main.SetColumnSpan(this.btn_finish, 3);
            this.btn_finish.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btn_finish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_finish.Location = new System.Drawing.Point(155, 231);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(117, 23);
            this.btn_finish.TabIndex = 12;
            this.btn_finish.Text = "&Finish";
            this.btn_finish.UseVisualStyleBackColor = true;
            // 
            // label_database
            // 
            this.label_database.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_database, 2);
            this.label_database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_database.Location = new System.Drawing.Point(3, 54);
            this.label_database.Name = "label_database";
            this.label_database.Size = new System.Drawing.Size(93, 29);
            this.label_database.TabIndex = 13;
            this.label_database.Text = "Database";
            this.label_database.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_database
            // 
            this.table_main.SetColumnSpan(this.text_database, 5);
            this.text_database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_database.Location = new System.Drawing.Point(102, 57);
            this.text_database.Name = "text_database";
            this.text_database.ReadOnly = true;
            this.text_database.Size = new System.Drawing.Size(170, 20);
            this.text_database.TabIndex = 14;
            // 
            // text_info
            // 
            this.table_main.SetColumnSpan(this.text_info, 8);
            this.text_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_info.Location = new System.Drawing.Point(3, 3);
            this.text_info.Multiline = true;
            this.text_info.Name = "text_info";
            this.text_info.ReadOnly = true;
            this.text_info.Size = new System.Drawing.Size(298, 48);
            this.text_info.TabIndex = 15;
            this.text_info.TabStop = false;
            this.text_info.Text = "Please review the information below.\r\nOnce you are happy it is correct, click Fin" +
    "ish to save the data and open the database.\r\n";
            // 
            // table_main
            // 
            this.table_main.ColumnCount = 8;
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.Controls.Add(this.Label1, 0, 2);
            this.table_main.Controls.Add(this.Label2, 0, 3);
            this.table_main.Controls.Add(this.Label3, 0, 4);
            this.table_main.Controls.Add(this.Label4, 0, 5);
            this.table_main.Controls.Add(this.Label5, 0, 6);
            this.table_main.Controls.Add(this.text_username, 2, 2);
            this.table_main.Controls.Add(this.text_firstName, 2, 3);
            this.table_main.Controls.Add(this.text_lastName, 2, 4);
            this.table_main.Controls.Add(this.text_email, 2, 5);
            this.table_main.Controls.Add(this.text_password, 2, 6);
            this.table_main.Controls.Add(this.check_pwd_show, 7, 6);
            this.table_main.Controls.Add(this.btn_edit, 1, 7);
            this.table_main.Controls.Add(this.btn_finish, 4, 7);
            this.table_main.Controls.Add(this.label_database, 0, 1);
            this.table_main.Controls.Add(this.text_database, 2, 1);
            this.table_main.Controls.Add(this.text_info, 0, 0);
            this.table_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_main.Location = new System.Drawing.Point(0, 0);
            this.table_main.Name = "table_main";
            this.table_main.RowCount = 8;
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.Size = new System.Drawing.Size(304, 257);
            this.table_main.TabIndex = 1;
            // 
            // confirm
            // 
            this.AcceptButton = this.btn_finish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_edit;
            this.ClientSize = new System.Drawing.Size(304, 257);
            this.ControlBox = false;
            this.Controls.Add(this.table_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "confirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm New Database";
            this.table_main.ResumeLayout(false);
            this.table_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip tooltip_check_pwd;
        internal System.Windows.Forms.CheckBox check_pwd_show;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TableLayoutPanel table_main;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox text_username;
        internal System.Windows.Forms.TextBox text_firstName;
        internal System.Windows.Forms.TextBox text_lastName;
        internal System.Windows.Forms.TextBox text_email;
        internal System.Windows.Forms.TextBox text_password;
        internal System.Windows.Forms.Button btn_edit;
        internal System.Windows.Forms.Button btn_finish;
        internal System.Windows.Forms.Label label_database;
        internal System.Windows.Forms.TextBox text_database;
        internal System.Windows.Forms.TextBox text_info;
    }
}
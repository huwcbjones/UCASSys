namespace UCASSys.Forms.Main
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.Btn_Login = new System.Windows.Forms.Button();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.text_password = new System.Windows.Forms.TextBox();
            this.text_username = new System.Windows.Forms.TextBox();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.pic_banner = new System.Windows.Forms.PictureBox();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.label_database = new System.Windows.Forms.Label();
            this.text_database = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_banner)).BeginInit();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.table.SetColumnSpan(this.Btn_Login, 2);
            this.Btn_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Login.Location = new System.Drawing.Point(143, 158);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(125, 23);
            this.Btn_Login.TabIndex = 3;
            this.Btn_Login.Text = "&Login";
            this.Btn_Login.UseVisualStyleBackColor = true;
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblusername.Location = new System.Drawing.Point(6, 97);
            this.lblusername.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(60, 29);
            this.lblusername.TabIndex = 2;
            this.lblusername.Text = "Username";
            this.lblusername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblpassword.Location = new System.Drawing.Point(6, 126);
            this.lblpassword.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(60, 29);
            this.lblpassword.TabIndex = 3;
            this.lblpassword.Text = "Password";
            this.lblpassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_password
            // 
            this.table.SetColumnSpan(this.text_password, 3);
            this.text_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_password.Location = new System.Drawing.Point(72, 129);
            this.text_password.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.text_password.Name = "text_password";
            this.text_password.PasswordChar = '*';
            this.text_password.Size = new System.Drawing.Size(196, 20);
            this.text_password.TabIndex = 2;
            // 
            // text_username
            // 
            this.table.SetColumnSpan(this.text_username, 3);
            this.text_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_username.Location = new System.Drawing.Point(72, 100);
            this.text_username.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.text_username.Name = "text_username";
            this.text_username.Size = new System.Drawing.Size(196, 20);
            this.text_username.TabIndex = 1;
            // 
            // Btn_Exit
            // 
            this.table.SetColumnSpan(this.Btn_Exit, 2);
            this.Btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Exit.Location = new System.Drawing.Point(6, 158);
            this.Btn_Exit.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(125, 23);
            this.Btn_Exit.TabIndex = 4;
            this.Btn_Exit.Text = "&Cancel";
            this.Btn_Exit.UseVisualStyleBackColor = true;
            // 
            // pic_banner
            // 
            this.pic_banner.BackgroundImage = global::UCASSys.Properties.Resources.banner;
            this.pic_banner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.table.SetColumnSpan(this.pic_banner, 4);
            this.pic_banner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_banner.Location = new System.Drawing.Point(0, 0);
            this.pic_banner.Margin = new System.Windows.Forms.Padding(0);
            this.pic_banner.Name = "pic_banner";
            this.pic_banner.Size = new System.Drawing.Size(274, 68);
            this.pic_banner.TabIndex = 6;
            this.pic_banner.TabStop = false;
            // 
            // table
            // 
            this.table.ColumnCount = 4;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table.Controls.Add(this.label_database, 0, 1);
            this.table.Controls.Add(this.Btn_Login, 2, 4);
            this.table.Controls.Add(this.lblusername, 0, 2);
            this.table.Controls.Add(this.lblpassword, 0, 3);
            this.table.Controls.Add(this.text_password, 1, 3);
            this.table.Controls.Add(this.text_username, 1, 2);
            this.table.Controls.Add(this.Btn_Exit, 0, 4);
            this.table.Controls.Add(this.pic_banner, 0, 0);
            this.table.Controls.Add(this.text_database, 1, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 5;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.Size = new System.Drawing.Size(274, 184);
            this.table.TabIndex = 7;
            // 
            // label_database
            // 
            this.label_database.AutoSize = true;
            this.label_database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_database.Location = new System.Drawing.Point(6, 68);
            this.label_database.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label_database.Name = "label_database";
            this.label_database.Size = new System.Drawing.Size(60, 29);
            this.label_database.TabIndex = 1;
            this.label_database.Text = "Database";
            this.label_database.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_database
            // 
            this.table.SetColumnSpan(this.text_database, 3);
            this.text_database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_database.Location = new System.Drawing.Point(72, 71);
            this.text_database.Name = "text_database";
            this.text_database.ReadOnly = true;
            this.text_database.Size = new System.Drawing.Size(199, 20);
            this.text_database.TabIndex = 0;
            this.text_database.TabStop = false;
            // 
            // login
            // 
            this.AcceptButton = this.Btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_Exit;
            this.ClientSize = new System.Drawing.Size(274, 184);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_banner)).EndInit();
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Btn_Login;
        internal System.Windows.Forms.TableLayoutPanel table;
        internal System.Windows.Forms.Label lblusername;
        internal System.Windows.Forms.Label lblpassword;
        internal System.Windows.Forms.TextBox text_password;
        internal System.Windows.Forms.TextBox text_username;
        internal System.Windows.Forms.Button Btn_Exit;
        internal System.Windows.Forms.PictureBox pic_banner;
        internal System.Windows.Forms.Label label_database;
        private System.Windows.Forms.TextBox text_database;
    }
}
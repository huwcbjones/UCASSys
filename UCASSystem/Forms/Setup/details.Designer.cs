namespace UCASSys.Forms.Setup
{
    partial class details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(details));
            this.worker_loadDetails = new System.ComponentModel.BackgroundWorker();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.label_firstName = new System.Windows.Forms.Label();
            this.label_lastName = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.text_username = new System.Windows.Forms.TextBox();
            this.text_firstName = new System.Windows.Forms.TextBox();
            this.text_lastName = new System.Windows.Forms.TextBox();
            this.text_email = new System.Windows.Forms.TextBox();
            this.text_info = new System.Windows.Forms.TextBox();
            this.progress_load = new System.Windows.Forms.ProgressBar();
            this.label_loading = new System.Windows.Forms.Label();
            this.label_val_firstName = new System.Windows.Forms.Label();
            this.label_val_lastName = new System.Windows.Forms.Label();
            this.label_val_email = new System.Windows.Forms.Label();
            this.table_main = new System.Windows.Forms.TableLayoutPanel();
            this.label_val_username = new System.Windows.Forms.Label();
            this.table_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_back
            // 
            this.table_main.SetColumnSpan(this.btn_back, 3);
            this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_back.Location = new System.Drawing.Point(32, 161);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(117, 23);
            this.btn_back.TabIndex = 6;
            this.btn_back.Text = "&Back";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.table_main.SetColumnSpan(this.btn_next, 3);
            this.btn_next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_next.Location = new System.Drawing.Point(155, 161);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(117, 23);
            this.btn_next.TabIndex = 5;
            this.btn_next.Text = "&Next";
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // label_firstName
            // 
            this.label_firstName.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_firstName, 2);
            this.label_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_firstName.Location = new System.Drawing.Point(3, 71);
            this.label_firstName.Name = "label_firstName";
            this.label_firstName.Size = new System.Drawing.Size(93, 29);
            this.label_firstName.TabIndex = 3;
            this.label_firstName.Text = "First Name";
            this.label_firstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_lastName
            // 
            this.label_lastName.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_lastName, 2);
            this.label_lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_lastName.Location = new System.Drawing.Point(3, 100);
            this.label_lastName.Name = "label_lastName";
            this.label_lastName.Size = new System.Drawing.Size(93, 29);
            this.label_lastName.TabIndex = 4;
            this.label_lastName.Text = "Last Name";
            this.label_lastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_email, 2);
            this.label_email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_email.Location = new System.Drawing.Point(3, 129);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(93, 29);
            this.label_email.TabIndex = 5;
            this.label_email.Text = "Email";
            this.label_email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_username, 2);
            this.label_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_username.Location = new System.Drawing.Point(3, 42);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(93, 29);
            this.label_username.TabIndex = 2;
            this.label_username.Text = "Username";
            this.label_username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_username
            // 
            this.table_main.SetColumnSpan(this.text_username, 5);
            this.text_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_username.Location = new System.Drawing.Point(102, 45);
            this.text_username.Name = "text_username";
            this.text_username.Size = new System.Drawing.Size(170, 20);
            this.text_username.TabIndex = 1;
            // 
            // text_firstName
            // 
            this.table_main.SetColumnSpan(this.text_firstName, 5);
            this.text_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_firstName.Location = new System.Drawing.Point(102, 74);
            this.text_firstName.Name = "text_firstName";
            this.text_firstName.Size = new System.Drawing.Size(170, 20);
            this.text_firstName.TabIndex = 2;
            // 
            // text_lastName
            // 
            this.table_main.SetColumnSpan(this.text_lastName, 5);
            this.text_lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_lastName.Location = new System.Drawing.Point(102, 103);
            this.text_lastName.Name = "text_lastName";
            this.text_lastName.Size = new System.Drawing.Size(170, 20);
            this.text_lastName.TabIndex = 3;
            // 
            // text_email
            // 
            this.table_main.SetColumnSpan(this.text_email, 5);
            this.text_email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_email.Location = new System.Drawing.Point(102, 132);
            this.text_email.Name = "text_email";
            this.text_email.Size = new System.Drawing.Size(170, 20);
            this.text_email.TabIndex = 4;
            // 
            // text_info
            // 
            this.table_main.SetColumnSpan(this.text_info, 8);
            this.text_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_info.Location = new System.Drawing.Point(3, 3);
            this.text_info.Multiline = true;
            this.text_info.Name = "text_info";
            this.text_info.ReadOnly = true;
            this.text_info.Size = new System.Drawing.Size(298, 36);
            this.text_info.TabIndex = 10;
            this.text_info.TabStop = false;
            this.text_info.Text = "Please enter your details and choose a username for the Database Administrator.\r\n" +
    "";
            // 
            // progress_load
            // 
            this.table_main.SetColumnSpan(this.progress_load, 4);
            this.progress_load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progress_load.Location = new System.Drawing.Point(155, 190);
            this.progress_load.MarqueeAnimationSpeed = 10;
            this.progress_load.Name = "progress_load";
            this.progress_load.Size = new System.Drawing.Size(146, 14);
            this.progress_load.TabIndex = 11;
            // 
            // label_loading
            // 
            this.label_loading.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_loading, 4);
            this.label_loading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_loading.Location = new System.Drawing.Point(3, 187);
            this.label_loading.Name = "label_loading";
            this.label_loading.Size = new System.Drawing.Size(146, 20);
            this.label_loading.TabIndex = 12;
            this.label_loading.Text = "Please wait, loading details...";
            this.label_loading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_val_firstName
            // 
            this.label_val_firstName.AutoSize = true;
            this.label_val_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_firstName.Location = new System.Drawing.Point(278, 71);
            this.label_val_firstName.Name = "label_val_firstName";
            this.label_val_firstName.Size = new System.Drawing.Size(23, 29);
            this.label_val_firstName.TabIndex = 14;
            this.label_val_firstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_val_lastName
            // 
            this.label_val_lastName.AutoSize = true;
            this.label_val_lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_lastName.Location = new System.Drawing.Point(278, 100);
            this.label_val_lastName.Name = "label_val_lastName";
            this.label_val_lastName.Size = new System.Drawing.Size(23, 29);
            this.label_val_lastName.TabIndex = 15;
            this.label_val_lastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_val_email
            // 
            this.label_val_email.AutoSize = true;
            this.label_val_email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_email.Location = new System.Drawing.Point(278, 129);
            this.label_val_email.Name = "label_val_email";
            this.label_val_email.Size = new System.Drawing.Size(23, 29);
            this.label_val_email.TabIndex = 16;
            this.label_val_email.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.table_main.Controls.Add(this.btn_back, 1, 5);
            this.table_main.Controls.Add(this.btn_next, 4, 5);
            this.table_main.Controls.Add(this.label_firstName, 0, 2);
            this.table_main.Controls.Add(this.label_lastName, 0, 3);
            this.table_main.Controls.Add(this.label_email, 0, 4);
            this.table_main.Controls.Add(this.label_username, 0, 1);
            this.table_main.Controls.Add(this.text_username, 2, 1);
            this.table_main.Controls.Add(this.text_firstName, 2, 2);
            this.table_main.Controls.Add(this.text_lastName, 2, 3);
            this.table_main.Controls.Add(this.text_email, 2, 4);
            this.table_main.Controls.Add(this.text_info, 0, 0);
            this.table_main.Controls.Add(this.progress_load, 4, 6);
            this.table_main.Controls.Add(this.label_loading, 0, 6);
            this.table_main.Controls.Add(this.label_val_username, 7, 1);
            this.table_main.Controls.Add(this.label_val_firstName, 7, 2);
            this.table_main.Controls.Add(this.label_val_lastName, 7, 3);
            this.table_main.Controls.Add(this.label_val_email, 7, 4);
            this.table_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_main.Location = new System.Drawing.Point(0, 0);
            this.table_main.Name = "table_main";
            this.table_main.RowCount = 7;
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_main.Size = new System.Drawing.Size(304, 207);
            this.table_main.TabIndex = 1;
            // 
            // label_val_username
            // 
            this.label_val_username.AutoSize = true;
            this.label_val_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_username.Location = new System.Drawing.Point(278, 42);
            this.label_val_username.Name = "label_val_username";
            this.label_val_username.Size = new System.Drawing.Size(23, 29);
            this.label_val_username.TabIndex = 13;
            this.label_val_username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // details
            // 
            this.AcceptButton = this.btn_next;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_back;
            this.ClientSize = new System.Drawing.Size(304, 207);
            this.ControlBox = false;
            this.Controls.Add(this.table_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup Database Administrator";
            this.table_main.ResumeLayout(false);
            this.table_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.ComponentModel.BackgroundWorker worker_loadDetails;
        internal System.Windows.Forms.Button btn_back;
        internal System.Windows.Forms.TableLayoutPanel table_main;
        internal System.Windows.Forms.Button btn_next;
        internal System.Windows.Forms.Label label_firstName;
        internal System.Windows.Forms.Label label_lastName;
        internal System.Windows.Forms.Label label_email;
        internal System.Windows.Forms.Label label_username;
        internal System.Windows.Forms.TextBox text_username;
        internal System.Windows.Forms.TextBox text_firstName;
        internal System.Windows.Forms.TextBox text_lastName;
        internal System.Windows.Forms.TextBox text_email;
        internal System.Windows.Forms.TextBox text_info;
        internal System.Windows.Forms.ProgressBar progress_load;
        internal System.Windows.Forms.Label label_loading;
        internal System.Windows.Forms.Label label_val_username;
        internal System.Windows.Forms.Label label_val_firstName;
        internal System.Windows.Forms.Label label_val_lastName;
        internal System.Windows.Forms.Label label_val_email;
    }
}
namespace UCASSys.Forms.Main
{
    partial class changePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePassword));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.text_old = new System.Windows.Forms.TextBox();
            this.text_new = new System.Windows.Forms.TextBox();
            this.text_conf = new System.Windows.Forms.TextBox();
            this.label_old = new System.Windows.Forms.Label();
            this.label_new = new System.Windows.Forms.Label();
            this.label_conf = new System.Windows.Forms.Label();
            this.label_val_old = new System.Windows.Forms.Label();
            this.label_val_new = new System.Windows.Forms.Label();
            this.label_val_conf = new System.Windows.Forms.Label();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Controls.Add(this.text_old, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_new, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.text_conf, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_old, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_new, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_conf, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_val_old, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_val_new, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_val_conf, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_change, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 116);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // text_old
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.text_old, 5);
            this.text_old.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_old.Location = new System.Drawing.Point(102, 3);
            this.text_old.Name = "text_old";
            this.text_old.Size = new System.Drawing.Size(210, 20);
            this.text_old.TabIndex = 0;
            this.text_old.UseSystemPasswordChar = true;
            // 
            // text_new
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.text_new, 5);
            this.text_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_new.Location = new System.Drawing.Point(102, 32);
            this.text_new.Name = "text_new";
            this.text_new.Size = new System.Drawing.Size(210, 20);
            this.text_new.TabIndex = 1;
            this.text_new.UseSystemPasswordChar = true;
            // 
            // text_conf
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.text_conf, 5);
            this.text_conf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_conf.Location = new System.Drawing.Point(102, 61);
            this.text_conf.Name = "text_conf";
            this.text_conf.Size = new System.Drawing.Size(210, 20);
            this.text_conf.TabIndex = 2;
            this.text_conf.UseSystemPasswordChar = true;
            // 
            // label_old
            // 
            this.label_old.AutoSize = true;
            this.label_old.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_old.Location = new System.Drawing.Point(3, 0);
            this.label_old.Name = "label_old";
            this.label_old.Size = new System.Drawing.Size(93, 29);
            this.label_old.TabIndex = 0;
            this.label_old.Text = "Old Password";
            this.label_old.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_new
            // 
            this.label_new.AutoSize = true;
            this.label_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_new.Location = new System.Drawing.Point(3, 29);
            this.label_new.Name = "label_new";
            this.label_new.Size = new System.Drawing.Size(93, 29);
            this.label_new.TabIndex = 0;
            this.label_new.Text = "New Password";
            this.label_new.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_conf
            // 
            this.label_conf.AutoSize = true;
            this.label_conf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_conf.Location = new System.Drawing.Point(3, 58);
            this.label_conf.Name = "label_conf";
            this.label_conf.Size = new System.Drawing.Size(93, 29);
            this.label_conf.TabIndex = 0;
            this.label_conf.Text = "Confirm Password";
            this.label_conf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_val_old
            // 
            this.label_val_old.AutoSize = true;
            this.label_val_old.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_old.Location = new System.Drawing.Point(318, 0);
            this.label_val_old.Name = "label_val_old";
            this.label_val_old.Size = new System.Drawing.Size(23, 29);
            this.label_val_old.TabIndex = 0;
            this.label_val_old.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_val_new
            // 
            this.label_val_new.AutoSize = true;
            this.label_val_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_new.Location = new System.Drawing.Point(318, 29);
            this.label_val_new.Name = "label_val_new";
            this.label_val_new.Size = new System.Drawing.Size(23, 29);
            this.label_val_new.TabIndex = 0;
            this.label_val_new.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_val_conf
            // 
            this.label_val_conf.AutoSize = true;
            this.label_val_conf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_conf.Location = new System.Drawing.Point(318, 58);
            this.label_val_conf.Name = "label_val_conf";
            this.label_val_conf.Size = new System.Drawing.Size(23, 29);
            this.label_val_conf.TabIndex = 0;
            this.label_val_conf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_change
            // 
            this.btn_change.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_change.Location = new System.Drawing.Point(175, 90);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(63, 23);
            this.btn_change.TabIndex = 3;
            this.btn_change.Text = "&Change";
            this.btn_change.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancel.Location = new System.Drawing.Point(106, 90);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(63, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "&Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // changePassword
            // 
            this.AcceptButton = this.btn_change;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(344, 116);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "changePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox text_old;
        private System.Windows.Forms.TextBox text_new;
        private System.Windows.Forms.TextBox text_conf;
        private System.Windows.Forms.Label label_old;
        private System.Windows.Forms.Label label_new;
        private System.Windows.Forms.Label label_conf;
        private System.Windows.Forms.Label label_val_old;
        private System.Windows.Forms.Label label_val_new;
        private System.Windows.Forms.Label label_val_conf;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_cancel;
    }
}
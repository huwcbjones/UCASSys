namespace UCASSys.Forms.Setup
{
    partial class password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(password));
            this.label_val_new = new System.Windows.Forms.Label();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_new = new System.Windows.Forms.Label();
            this.label_confirm = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.text_info = new System.Windows.Forms.TextBox();
            this.text_new = new System.Windows.Forms.TextBox();
            this.text_conf = new System.Windows.Forms.TextBox();
            this.label_val_conf = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_val_new
            // 
            this.label_val_new.AutoSize = true;
            this.label_val_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_new.Location = new System.Drawing.Point(278, 26);
            this.label_val_new.Name = "label_val_new";
            this.label_val_new.Size = new System.Drawing.Size(23, 29);
            this.label_val_new.TabIndex = 5;
            this.label_val_new.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 8;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.TableLayoutPanel1.Controls.Add(this.label_new, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.label_confirm, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.btn_back, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.btn_next, 4, 3);
            this.TableLayoutPanel1.Controls.Add(this.text_info, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.text_new, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.text_conf, 2, 2);
            this.TableLayoutPanel1.Controls.Add(this.label_val_new, 7, 1);
            this.TableLayoutPanel1.Controls.Add(this.label_val_conf, 7, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 4;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(304, 113);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // label_new
            // 
            this.label_new.AutoSize = true;
            this.TableLayoutPanel1.SetColumnSpan(this.label_new, 2);
            this.label_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_new.Location = new System.Drawing.Point(3, 26);
            this.label_new.Name = "label_new";
            this.label_new.Size = new System.Drawing.Size(93, 29);
            this.label_new.TabIndex = 0;
            this.label_new.Text = "New Password";
            this.label_new.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_confirm
            // 
            this.label_confirm.AutoSize = true;
            this.TableLayoutPanel1.SetColumnSpan(this.label_confirm, 2);
            this.label_confirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_confirm.Location = new System.Drawing.Point(3, 55);
            this.label_confirm.Name = "label_confirm";
            this.label_confirm.Size = new System.Drawing.Size(93, 29);
            this.label_confirm.TabIndex = 1;
            this.label_confirm.Text = "Confirm Password";
            this.label_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_back
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.btn_back, 3);
            this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_back.Location = new System.Drawing.Point(32, 87);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(117, 23);
            this.btn_back.TabIndex = 4;
            this.btn_back.Text = "&Back";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.btn_next, 3);
            this.btn_next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_next.Location = new System.Drawing.Point(155, 87);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(117, 23);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "&Next";
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // text_info
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.text_info, 8);
            this.text_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_info.Location = new System.Drawing.Point(3, 3);
            this.text_info.Multiline = true;
            this.text_info.Name = "text_info";
            this.text_info.ReadOnly = true;
            this.text_info.Size = new System.Drawing.Size(298, 20);
            this.text_info.TabIndex = 4;
            this.text_info.TabStop = false;
            this.text_info.Text = "Please enter a password for the Administrator User.";
            // 
            // text_new
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.text_new, 5);
            this.text_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_new.Location = new System.Drawing.Point(102, 29);
            this.text_new.Name = "text_new";
            this.text_new.Size = new System.Drawing.Size(170, 20);
            this.text_new.TabIndex = 1;
            this.text_new.UseSystemPasswordChar = true;
            // 
            // text_conf
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.text_conf, 5);
            this.text_conf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_conf.Location = new System.Drawing.Point(102, 58);
            this.text_conf.Name = "text_conf";
            this.text_conf.Size = new System.Drawing.Size(170, 20);
            this.text_conf.TabIndex = 2;
            this.text_conf.UseSystemPasswordChar = true;
            // 
            // label_val_conf
            // 
            this.label_val_conf.AutoSize = true;
            this.label_val_conf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_conf.Location = new System.Drawing.Point(278, 55);
            this.label_val_conf.Name = "label_val_conf";
            this.label_val_conf.Size = new System.Drawing.Size(23, 29);
            this.label_val_conf.TabIndex = 6;
            this.label_val_conf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // password
            // 
            this.AcceptButton = this.btn_next;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_back;
            this.ClientSize = new System.Drawing.Size(304, 113);
            this.ControlBox = false;
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Administrator Password";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label_val_new;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label label_new;
        internal System.Windows.Forms.Label label_confirm;
        internal System.Windows.Forms.Button btn_back;
        internal System.Windows.Forms.Button btn_next;
        internal System.Windows.Forms.TextBox text_info;
        internal System.Windows.Forms.TextBox text_new;
        internal System.Windows.Forms.TextBox text_conf;
        internal System.Windows.Forms.Label label_val_conf;
    }
}
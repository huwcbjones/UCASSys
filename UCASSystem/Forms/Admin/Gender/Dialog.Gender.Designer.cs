namespace UCASSys.Forms.Admin.Gender
{
    partial class Gender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gender));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_val_ID = new System.Windows.Forms.Label();
            this.label_val_gender = new System.Windows.Forms.Label();
            this.text_ID = new System.Windows.Forms.TextBox();
            this.text_gender = new System.Windows.Forms.TextBox();
            this.btn_do = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Controls.Add(this.label_ID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_gender, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_val_ID, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_val_gender, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.text_ID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_gender, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_do, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ID.Location = new System.Drawing.Point(3, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(63, 29);
            this.label_ID.TabIndex = 0;
            this.label_ID.Text = "ID";
            this.label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_gender.Location = new System.Drawing.Point(3, 29);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(63, 29);
            this.label_gender.TabIndex = 0;
            this.label_gender.Text = "Gender";
            this.label_gender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_val_ID
            // 
            this.label_val_ID.AutoSize = true;
            this.label_val_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_ID.Location = new System.Drawing.Point(278, 0);
            this.label_val_ID.Name = "label_val_ID";
            this.label_val_ID.Size = new System.Drawing.Size(23, 29);
            this.label_val_ID.TabIndex = 0;
            this.label_val_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_val_gender
            // 
            this.label_val_gender.AutoSize = true;
            this.label_val_gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_gender.Location = new System.Drawing.Point(278, 29);
            this.label_val_gender.Name = "label_val_gender";
            this.label_val_gender.Size = new System.Drawing.Size(23, 29);
            this.label_val_gender.TabIndex = 0;
            this.label_val_gender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_ID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.text_ID, 5);
            this.text_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_ID.Location = new System.Drawing.Point(72, 3);
            this.text_ID.Name = "text_ID";
            this.text_ID.ReadOnly = true;
            this.text_ID.Size = new System.Drawing.Size(200, 20);
            this.text_ID.TabIndex = 1;
            // 
            // text_gender
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.text_gender, 5);
            this.text_gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_gender.Location = new System.Drawing.Point(72, 32);
            this.text_gender.Name = "text_gender";
            this.text_gender.Size = new System.Drawing.Size(200, 20);
            this.text_gender.TabIndex = 2;
            // 
            // btn_do
            // 
            this.btn_do.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_do.Location = new System.Drawing.Point(155, 61);
            this.btn_do.Name = "btn_do";
            this.btn_do.Size = new System.Drawing.Size(63, 23);
            this.btn_do.TabIndex = 3;
            this.btn_do.Text = "&Do";
            this.btn_do.UseVisualStyleBackColor = true;
            this.btn_do.Click += new System.EventHandler(this.btn_do_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancel.Location = new System.Drawing.Point(86, 61);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(63, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "&Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // Gender
            // 
            this.AcceptButton = this.btn_do;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(304, 87);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gender";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Do Gender";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.Label label_val_ID;
        private System.Windows.Forms.Label label_val_gender;
        private System.Windows.Forms.TextBox text_ID;
        private System.Windows.Forms.TextBox text_gender;
        private System.Windows.Forms.Button btn_do;
        private System.Windows.Forms.Button btn_cancel;
    }
}
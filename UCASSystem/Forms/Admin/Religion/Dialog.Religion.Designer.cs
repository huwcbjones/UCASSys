namespace UCASSys.Forms.Admin.Religion
{
    partial class Religion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Religion));
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_religion = new System.Windows.Forms.Label();
            this.label_val_ID = new System.Windows.Forms.Label();
            this.label_val_religion = new System.Windows.Forms.Label();
            this.text_ID = new System.Windows.Forms.TextBox();
            this.text_religion = new System.Windows.Forms.TextBox();
            this.btn_do = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 7;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.Controls.Add(this.label_ID, 0, 0);
            this.table.Controls.Add(this.label_religion, 0, 1);
            this.table.Controls.Add(this.label_val_ID, 6, 0);
            this.table.Controls.Add(this.label_val_religion, 6, 1);
            this.table.Controls.Add(this.text_ID, 1, 0);
            this.table.Controls.Add(this.text_religion, 1, 1);
            this.table.Controls.Add(this.btn_do, 3, 3);
            this.table.Controls.Add(this.btn_cancel, 2, 3);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 4;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table.Size = new System.Drawing.Size(304, 87);
            this.table.TabIndex = 0;
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
            // label_religion
            // 
            this.label_religion.AutoSize = true;
            this.label_religion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_religion.Location = new System.Drawing.Point(3, 29);
            this.label_religion.Name = "label_religion";
            this.label_religion.Size = new System.Drawing.Size(63, 29);
            this.label_religion.TabIndex = 1;
            this.label_religion.Text = "Religion";
            this.label_religion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_val_ID
            // 
            this.label_val_ID.AutoSize = true;
            this.label_val_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_ID.Location = new System.Drawing.Point(278, 0);
            this.label_val_ID.Name = "label_val_ID";
            this.label_val_ID.Size = new System.Drawing.Size(23, 29);
            this.label_val_ID.TabIndex = 2;
            // 
            // label_val_religion
            // 
            this.label_val_religion.AutoSize = true;
            this.label_val_religion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_val_religion.Location = new System.Drawing.Point(278, 29);
            this.label_val_religion.Name = "label_val_religion";
            this.label_val_religion.Size = new System.Drawing.Size(23, 29);
            this.label_val_religion.TabIndex = 3;
            // 
            // text_ID
            // 
            this.table.SetColumnSpan(this.text_ID, 5);
            this.text_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_ID.Location = new System.Drawing.Point(72, 3);
            this.text_ID.Name = "text_ID";
            this.text_ID.ReadOnly = true;
            this.text_ID.Size = new System.Drawing.Size(200, 20);
            this.text_ID.TabIndex = 4;
            // 
            // text_religion
            // 
            this.table.SetColumnSpan(this.text_religion, 5);
            this.text_religion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_religion.Location = new System.Drawing.Point(72, 32);
            this.text_religion.Name = "text_religion";
            this.text_religion.Size = new System.Drawing.Size(200, 20);
            this.text_religion.TabIndex = 5;
            // 
            // btn_do
            // 
            this.btn_do.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_do.Location = new System.Drawing.Point(155, 61);
            this.btn_do.Name = "btn_do";
            this.btn_do.Size = new System.Drawing.Size(63, 23);
            this.btn_do.TabIndex = 6;
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
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "&Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // Religion
            // 
            this.AcceptButton = this.btn_do;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(304, 87);
            this.ControlBox = false;
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Religion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Do Religion";
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_religion;
        private System.Windows.Forms.Label label_val_ID;
        private System.Windows.Forms.Label label_val_religion;
        private System.Windows.Forms.TextBox text_ID;
        private System.Windows.Forms.TextBox text_religion;
        private System.Windows.Forms.Button btn_do;
        private System.Windows.Forms.Button btn_cancel;
    }
}
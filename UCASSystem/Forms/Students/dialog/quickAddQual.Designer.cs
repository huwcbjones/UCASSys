namespace UCASSys.Forms.Students.dialog
{
    partial class quickAddQual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(quickAddQual));
            this.table_main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label_header_qual = new System.Windows.Forms.Label();
            this.label_header_grade = new System.Windows.Forms.Label();
            this.label_header_omit = new System.Windows.Forms.Label();
            this.table_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_main
            // 
            this.table_main.ColumnCount = 7;
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_main.Controls.Add(this.btn_add, 3, 2);
            this.table_main.Controls.Add(this.btn_close, 2, 2);
            this.table_main.Controls.Add(this.label_header_qual, 0, 0);
            this.table_main.Controls.Add(this.label_header_grade, 4, 0);
            this.table_main.Controls.Add(this.label_header_omit, 6, 0);
            this.table_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_main.Location = new System.Drawing.Point(0, 0);
            this.table_main.Name = "table_main";
            this.table_main.RowCount = 3;
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.Size = new System.Drawing.Size(404, 58);
            this.table_main.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_add.Enabled = false;
            this.btn_add.Location = new System.Drawing.Point(205, 32);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(63, 23);
            this.btn_add.TabIndex = 999;
            this.btn_add.Text = "&Add";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_close.Location = new System.Drawing.Point(136, 32);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(63, 23);
            this.btn_close.TabIndex = 998;
            this.btn_close.Text = "&Close";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // label_header_qual
            // 
            this.label_header_qual.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_header_qual, 4);
            this.label_header_qual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_header_qual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_header_qual.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label_header_qual.Location = new System.Drawing.Point(3, 0);
            this.label_header_qual.Name = "label_header_qual";
            this.label_header_qual.Size = new System.Drawing.Size(265, 29);
            this.label_header_qual.TabIndex = 2;
            this.label_header_qual.Text = "Qualification";
            this.label_header_qual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_header_grade
            // 
            this.label_header_grade.AutoSize = true;
            this.table_main.SetColumnSpan(this.label_header_grade, 2);
            this.label_header_grade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_header_grade.Location = new System.Drawing.Point(274, 0);
            this.label_header_grade.Name = "label_header_grade";
            this.label_header_grade.Size = new System.Drawing.Size(98, 29);
            this.label_header_grade.TabIndex = 3;
            this.label_header_grade.Text = "Grade";
            this.label_header_grade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_header_omit
            // 
            this.label_header_omit.AutoSize = true;
            this.label_header_omit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_header_omit.Location = new System.Drawing.Point(375, 0);
            this.label_header_omit.Margin = new System.Windows.Forms.Padding(0);
            this.label_header_omit.Name = "label_header_omit";
            this.label_header_omit.Size = new System.Drawing.Size(29, 29);
            this.label_header_omit.TabIndex = 4;
            this.label_header_omit.Text = "Omit";
            this.label_header_omit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // quickAddQual
            // 
            this.AcceptButton = this.btn_add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(404, 58);
            this.Controls.Add(this.table_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "quickAddQual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick Add Qualifications";
            this.table_main.ResumeLayout(false);
            this.table_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_main;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label_header_qual;
        private System.Windows.Forms.Label label_header_grade;
        private System.Windows.Forms.Label label_header_omit;
    }
}
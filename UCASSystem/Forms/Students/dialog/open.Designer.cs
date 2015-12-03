namespace UCASSys.Forms.Students.dialog
{
    partial class open
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(open));
            this.table_main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_open = new System.Windows.Forms.Button();
            this.group_search = new System.Windows.Forms.GroupBox();
            this.table_search = new System.Windows.Forms.TableLayoutPanel();
            this.label_YoE = new System.Windows.Forms.Label();
            this.label_tutorGroup = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_firstName = new System.Windows.Forms.Label();
            this.label_middleNames = new System.Windows.Forms.Label();
            this.label_lastName = new System.Windows.Forms.Label();
            this.combo_YoE = new System.Windows.Forms.ComboBox();
            this.combo_tutorGroup = new System.Windows.Forms.ComboBox();
            this.combo_gender = new System.Windows.Forms.ComboBox();
            this.text_firstName = new System.Windows.Forms.TextBox();
            this.text_middleNames = new System.Windows.Forms.TextBox();
            this.text_lastName = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.combo_status = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.group_students = new System.Windows.Forms.GroupBox();
            this.lv_results = new System.Windows.Forms.ListView();
            this.lv_col_ULN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_col_YoE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_col_form = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_col_firstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_col_middleNames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_col_lastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_col_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_cancel = new System.Windows.Forms.Button();
            this.table_main.SuspendLayout();
            this.group_search.SuspendLayout();
            this.table_search.SuspendLayout();
            this.group_students.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_main
            // 
            this.table_main.ColumnCount = 4;
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.table_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_main.Controls.Add(this.btn_open, 2, 2);
            this.table_main.Controls.Add(this.group_search, 0, 0);
            this.table_main.Controls.Add(this.group_students, 0, 1);
            this.table_main.Controls.Add(this.btn_cancel, 1, 2);
            this.table_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_main.Location = new System.Drawing.Point(0, 0);
            this.table_main.Name = "table_main";
            this.table_main.RowCount = 3;
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 229F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_main.Size = new System.Drawing.Size(784, 561);
            this.table_main.TabIndex = 0;
            // 
            // btn_open
            // 
            this.btn_open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_open.Enabled = false;
            this.btn_open.Location = new System.Drawing.Point(395, 535);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(73, 23);
            this.btn_open.TabIndex = 301;
            this.btn_open.Text = "&Open";
            this.btn_open.UseVisualStyleBackColor = true;
            // 
            // group_search
            // 
            this.table_main.SetColumnSpan(this.group_search, 4);
            this.group_search.Controls.Add(this.table_search);
            this.group_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_search.Location = new System.Drawing.Point(3, 3);
            this.group_search.Name = "group_search";
            this.group_search.Size = new System.Drawing.Size(778, 223);
            this.group_search.TabIndex = 100;
            this.group_search.TabStop = false;
            this.group_search.Text = "Search";
            // 
            // table_search
            // 
            this.table_search.ColumnCount = 3;
            this.table_search.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.table_search.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_search.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.table_search.Controls.Add(this.label_YoE, 0, 1);
            this.table_search.Controls.Add(this.label_tutorGroup, 0, 2);
            this.table_search.Controls.Add(this.label_gender, 0, 3);
            this.table_search.Controls.Add(this.label_firstName, 0, 4);
            this.table_search.Controls.Add(this.label_middleNames, 0, 5);
            this.table_search.Controls.Add(this.label_lastName, 0, 6);
            this.table_search.Controls.Add(this.combo_YoE, 1, 1);
            this.table_search.Controls.Add(this.combo_tutorGroup, 1, 2);
            this.table_search.Controls.Add(this.combo_gender, 1, 3);
            this.table_search.Controls.Add(this.text_firstName, 1, 4);
            this.table_search.Controls.Add(this.text_middleNames, 1, 5);
            this.table_search.Controls.Add(this.text_lastName, 1, 6);
            this.table_search.Controls.Add(this.label_status, 0, 0);
            this.table_search.Controls.Add(this.combo_status, 1, 0);
            this.table_search.Controls.Add(this.btn_search, 2, 0);
            this.table_search.Controls.Add(this.btn_reset, 2, 1);
            this.table_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_search.Location = new System.Drawing.Point(3, 16);
            this.table_search.Name = "table_search";
            this.table_search.RowCount = 8;
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.table_search.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_search.Size = new System.Drawing.Size(772, 204);
            this.table_search.TabIndex = 0;
            // 
            // label_YoE
            // 
            this.label_YoE.AutoSize = true;
            this.label_YoE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_YoE.Location = new System.Drawing.Point(3, 29);
            this.label_YoE.Name = "label_YoE";
            this.label_YoE.Size = new System.Drawing.Size(83, 29);
            this.label_YoE.TabIndex = 0;
            this.label_YoE.Text = "Year of Entry";
            this.label_YoE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_tutorGroup
            // 
            this.label_tutorGroup.AutoSize = true;
            this.label_tutorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_tutorGroup.Location = new System.Drawing.Point(3, 58);
            this.label_tutorGroup.Name = "label_tutorGroup";
            this.label_tutorGroup.Size = new System.Drawing.Size(83, 29);
            this.label_tutorGroup.TabIndex = 0;
            this.label_tutorGroup.Text = "Tutor Group";
            this.label_tutorGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // label_firstName
            // 
            this.label_firstName.AutoSize = true;
            this.label_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_firstName.Location = new System.Drawing.Point(3, 116);
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
            this.label_middleNames.Location = new System.Drawing.Point(3, 145);
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
            this.label_lastName.Location = new System.Drawing.Point(3, 174);
            this.label_lastName.Name = "label_lastName";
            this.label_lastName.Size = new System.Drawing.Size(83, 29);
            this.label_lastName.TabIndex = 0;
            this.label_lastName.Text = "Last Name";
            this.label_lastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combo_YoE
            // 
            this.combo_YoE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_YoE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_YoE.FormattingEnabled = true;
            this.combo_YoE.Location = new System.Drawing.Point(92, 32);
            this.combo_YoE.Name = "combo_YoE";
            this.combo_YoE.Size = new System.Drawing.Size(588, 21);
            this.combo_YoE.TabIndex = 102;
            // 
            // combo_tutorGroup
            // 
            this.combo_tutorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_tutorGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_tutorGroup.FormattingEnabled = true;
            this.combo_tutorGroup.Location = new System.Drawing.Point(92, 61);
            this.combo_tutorGroup.Name = "combo_tutorGroup";
            this.combo_tutorGroup.Size = new System.Drawing.Size(588, 21);
            this.combo_tutorGroup.TabIndex = 103;
            // 
            // combo_gender
            // 
            this.combo_gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_gender.FormattingEnabled = true;
            this.combo_gender.Location = new System.Drawing.Point(92, 90);
            this.combo_gender.Name = "combo_gender";
            this.combo_gender.Size = new System.Drawing.Size(588, 21);
            this.combo_gender.TabIndex = 104;
            // 
            // text_firstName
            // 
            this.text_firstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_firstName.Location = new System.Drawing.Point(92, 119);
            this.text_firstName.Name = "text_firstName";
            this.text_firstName.Size = new System.Drawing.Size(588, 20);
            this.text_firstName.TabIndex = 105;
            // 
            // text_middleNames
            // 
            this.text_middleNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_middleNames.Location = new System.Drawing.Point(92, 148);
            this.text_middleNames.Name = "text_middleNames";
            this.text_middleNames.Size = new System.Drawing.Size(588, 20);
            this.text_middleNames.TabIndex = 106;
            // 
            // text_lastName
            // 
            this.text_lastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_lastName.Location = new System.Drawing.Point(92, 177);
            this.text_lastName.Name = "text_lastName";
            this.text_lastName.Size = new System.Drawing.Size(588, 20);
            this.text_lastName.TabIndex = 107;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_status.Location = new System.Drawing.Point(3, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(83, 29);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "Section Status";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combo_status
            // 
            this.combo_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location = new System.Drawing.Point(92, 3);
            this.combo_status.Name = "combo_status";
            this.combo_status.Size = new System.Drawing.Size(588, 21);
            this.combo_status.TabIndex = 101;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(686, 3);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 108;
            this.btn_search.Text = "&Search";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(686, 32);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 109;
            this.btn_reset.Text = "&Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // group_students
            // 
            this.table_main.SetColumnSpan(this.group_students, 4);
            this.group_students.Controls.Add(this.lv_results);
            this.group_students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_students.Location = new System.Drawing.Point(3, 232);
            this.group_students.Name = "group_students";
            this.group_students.Size = new System.Drawing.Size(778, 297);
            this.group_students.TabIndex = 200;
            this.group_students.TabStop = false;
            this.group_students.Text = "Students";
            // 
            // lv_results
            // 
            this.lv_results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_col_ULN,
            this.lv_col_YoE,
            this.lv_col_form,
            this.lv_col_firstName,
            this.lv_col_middleNames,
            this.lv_col_lastName,
            this.lv_col_status});
            this.lv_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_results.FullRowSelect = true;
            this.lv_results.Location = new System.Drawing.Point(3, 16);
            this.lv_results.MultiSelect = false;
            this.lv_results.Name = "lv_results";
            this.lv_results.ShowGroups = false;
            this.lv_results.Size = new System.Drawing.Size(772, 278);
            this.lv_results.TabIndex = 0;
            this.lv_results.UseCompatibleStateImageBehavior = false;
            this.lv_results.View = System.Windows.Forms.View.Details;
            // 
            // lv_col_ULN
            // 
            this.lv_col_ULN.Text = "ULN";
            this.lv_col_ULN.Width = 75;
            // 
            // lv_col_YoE
            // 
            this.lv_col_YoE.Text = "Year of Entry";
            this.lv_col_YoE.Width = 120;
            // 
            // lv_col_form
            // 
            this.lv_col_form.Text = "Form";
            // 
            // lv_col_firstName
            // 
            this.lv_col_firstName.Text = "First Name";
            this.lv_col_firstName.Width = 120;
            // 
            // lv_col_middleNames
            // 
            this.lv_col_middleNames.Text = "Middle Name(s)";
            this.lv_col_middleNames.Width = 180;
            // 
            // lv_col_lastName
            // 
            this.lv_col_lastName.Text = "Last Name";
            this.lv_col_lastName.Width = 120;
            // 
            // lv_col_status
            // 
            this.lv_col_status.Text = "Status";
            this.lv_col_status.Width = 90;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancel.Location = new System.Drawing.Point(316, 535);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(73, 23);
            this.btn_cancel.TabIndex = 302;
            this.btn_cancel.Text = "&Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // open
            // 
            this.AcceptButton = this.btn_open;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.table_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "open";
            this.ShowInTaskbar = false;
            this.Text = "Open Student";
            this.table_main.ResumeLayout(false);
            this.group_search.ResumeLayout(false);
            this.table_search.ResumeLayout(false);
            this.table_search.PerformLayout();
            this.group_students.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_main;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.GroupBox group_search;
        private System.Windows.Forms.TableLayoutPanel table_search;
        private System.Windows.Forms.GroupBox group_students;
        private System.Windows.Forms.Label label_YoE;
        private System.Windows.Forms.Label label_tutorGroup;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.Label label_firstName;
        private System.Windows.Forms.Label label_middleNames;
        private System.Windows.Forms.Label label_lastName;
        private System.Windows.Forms.ComboBox combo_YoE;
        private System.Windows.Forms.ComboBox combo_tutorGroup;
        private System.Windows.Forms.ComboBox combo_gender;
        private System.Windows.Forms.TextBox text_firstName;
        private System.Windows.Forms.TextBox text_middleNames;
        private System.Windows.Forms.TextBox text_lastName;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ComboBox combo_status;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ListView lv_results;
        private System.Windows.Forms.ColumnHeader lv_col_ULN;
        private System.Windows.Forms.ColumnHeader lv_col_form;
        private System.Windows.Forms.ColumnHeader lv_col_firstName;
        private System.Windows.Forms.ColumnHeader lv_col_middleNames;
        private System.Windows.Forms.ColumnHeader lv_col_lastName;
        private System.Windows.Forms.ColumnHeader lv_col_status;
        private System.Windows.Forms.ColumnHeader lv_col_YoE;
    }
}
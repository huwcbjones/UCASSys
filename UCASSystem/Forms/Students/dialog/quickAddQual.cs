using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using UCASSys.Classes.Items;

namespace UCASSys.Forms.Students.dialog
{
    public partial class quickAddQual : Form
    {

        private int _YoE;

        private int _nextTabIndex = 0;

        private Dictionary<QualificationItem, Dictionary<string, Control>> _controls = new Dictionary<QualificationItem, Dictionary<string, Control>>();

        public List<QualificationItem> Qualifications
        {
            get
            {
                List<QualificationItem> List = new List<QualificationItem>();
                foreach (KeyValuePair<QualificationItem, Dictionary<string, Control>> qual in _controls)
                {
                    List.Add(qual.Key);
                }
                return List;
            }
        }

        public quickAddQual(int YearOfEntry)
        {
            this._YoE = YearOfEntry;

            InitializeComponent();
            _loadForm();

            btn_add.Click += btn_add_Click;
        }

        private void _loadForm()
        {
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                try
                {
                    query.CommandText = "SELECT `qualID`, `achieved` FROM `YoE_qual` WHERE `YoE`=@YoE";
                    query.Parameters.AddWithValue("@YoE", this._YoE);

                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            using (Classes.TaskDialog dialog = new Classes.TaskDialog())
                            {
                                dialog.infoBox();
                                dialog.Title = "No Quals Found";
                                dialog.Subtitle = "No qualifications for quick add found.";
                                dialog.DetailsText = "Add qualifications to this Year of Entry to use quick add.";
                                dialog.Show();
                                this.Close();
                            }
                        }
                        QualificationItem newQual;
                        int newRowNum;
                        while (data.Read())
                        {
                            newQual = new QualificationItem((string)data["qualID"]);
                            newQual.DateAchieved = (DateTime)data["achieved"];

                            newRowNum = _addNewRow();
                            _addQual(newRowNum, newQual);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Classes.Database.Interface.databaseError("Failed to load quick add qualifications.", GetType().Namespace, ex.Message);
                    this.Close();
                }
            }
        }

        private int _addNewRow()
        {
            // Add a new row
            table_main.RowCount = table_main.RowCount + 1;
            table_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            table_main.Controls.Remove(btn_add);
            table_main.Controls.Add(btn_add, 3, table_main.RowCount - 1);
            table_main.Controls.Remove(btn_close);
            table_main.Controls.Add(btn_close, 2, table_main.RowCount - 1);
            this.Height = this.Height + 29;

            return table_main.RowCount - 2;
        }

        private void _addQual(int rowNum, QualificationItem qualification)
        {
            Dictionary<string, Control> controls = new Dictionary<string, Control>();

            // Label
            Label label = new Label();
            label.TabIndex = 0;
            label.Text = qualification.Name;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleLeft;
            controls.Add("label", label);
            table_main.Controls.Add(label, 0, rowNum);
            table_main.SetColumnSpan(label, 4);

            // Combo
            ComboBox combo = new ComboBox();
            combo.TabIndex = _nextTabIndex;
            combo.Tag = qualification;
            _nextTabIndex++;
            combo.Dock = DockStyle.Fill;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.DisplayMember = "Text";
            combo.ValueMember = "ID";
            combo.DataSource = new Classes.Lists.Grades(qualification.Grades).List;
            combo.SelectedValueChanged += _gradeChange;
            controls.Add("combo", combo);
            table_main.Controls.Add(combo, 4, rowNum);
            table_main.SetColumnSpan(combo, 2);

            // Checkbox
            CheckBox check = new CheckBox();
            check.TabIndex = _nextTabIndex;
            check.Tag = qualification;
            _nextTabIndex++;
            check.Dock = DockStyle.Fill;
            check.CheckedChanged += _toggleRow;
            table_main.Controls.Add(check, 6, rowNum);
            controls.Add("check", check);

            _controls.Add(qualification, controls);
        }

        private void _toggleRow(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            QualificationItem qualification = (QualificationItem)checkbox.Tag;

            Dictionary<string, Control> controls = _controls[qualification];
            ComboBox combo = (ComboBox)controls["combo"];
            combo.Enabled = !checkbox.Checked;

            _setAddButton();
        }

        private void _gradeChange(object sender, EventArgs e)
        {
            _setAddButton();
        }
        private void _setAddButton()
        {
            Dictionary<string, bool> is_enabled = new Dictionary<string, bool>();
            Dictionary<string, bool> is_omitted = new Dictionary<string, bool>();
            ComboBox combo;
            CheckBox check;
            foreach (KeyValuePair<QualificationItem, Dictionary<string, Control>> item in _controls)
            {
                combo = (ComboBox)item.Value["combo"];
                check = (CheckBox)item.Value["check"];
                is_omitted[item.Key.Reference] = check.Checked;
                if (check.Checked)
                {
                    is_enabled[item.Key.Reference] = true;
                }
                else
                {
                    if ((int)combo.SelectedValue < 0)
                    {
                        is_enabled[item.Key.Reference] = false;
                    }
                    else
                    {
                        is_enabled[item.Key.Reference] = true;
                    }
                }
            }

            if (is_enabled.ContainsValue(false))
            {
                btn_add.Enabled = false;
            }
            else
            {
                if (is_omitted.ContainsValue(false))
                {
                    btn_add.Enabled = true;
                }
                else
                {
                    btn_add.Enabled = false;
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<QualificationItem, Dictionary<string, Control>> item in _controls)
            {
                item.Key.GradeAchieved = (string)((dropDownItem)((ComboBox)item.Value["combo"]).SelectedItem).Text;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}

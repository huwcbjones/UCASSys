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
using StatusMessage = UCASSys.Classes.StatusMessage;
using Validation = UCASSys.Classes.Validation;

namespace UCASSys.Forms.Admin.YoE.Dialog
{
    public partial class TutorGroup : Form
    {

        private int _mode = Program.MODE_New;
        public TutorGroup(int mode = Program.MODE_New, Classes.Items.TutorItem tutor = null)
        {
            InitializeComponent();

            this._mode = mode;
            if (mode == Program.MODE_New)
            {
                this.Text = "Add Tutor Group";
                btn_do.Text = "&Add";
            }
            else if (mode == Program.MODE_Edit
               && tutor != null
               )
            {
                this.Text = "Edit Tutor Group: " + tutor.ID.ToString();
                btn_do.Text = "&Edit";
                text_ID.Text = tutor.ID.ToString();
                combo_YoE.SelectedValue = tutor.YearOfEntry;
                int_yearGroup.Value = tutor.YearGroup;
                text_initials.Text = tutor.Initials;
            }
            else
            {
                Program.error("Tutor Group Error", "Failed to load Tutor Group.", "Invalid mode passed to form.");
                this.DialogResult = DialogResult.Abort;
            }

            combo_YoE.DataSource = new Classes.Lists.YearOfEntry().List;
            combo_YoE.DisplayMember = "Text";
            combo_YoE.ValueMember = "ID";

            btn_do.Click += btn_do_Click;

            combo_YoE.SelectedValueChanged += combo_YoE_SelectedValueChanged;
            int_yearGroup.ValueChanged += int_yearGroup_ValueChanged;
            text_initials.TextChanged += text_initials_TextChanged;
        }

        private void btn_do_Click(object sender, EventArgs e)
        {
            if (!Program.userCtrl.is_admin)
            {
                using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
                {
                    dialog.authBox();
                    dialog.Subtitle = "Unauthorised action.";
                    dialog.Text = "You lack the privileges to do that.";

                    dialog.Show();
                    this.Close();
                    return;
                }
            }
            if (!checkFields())
            {
                return;
            }
            using (OleDbTransaction transaction = Program.dbInt.connection.BeginTransaction())
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.Transaction = transaction;
                    if (this._mode == Program.MODE_New)
                    {
                        query.CommandText = "INSERT INTO `tutorGroups` (`YoE`, `yearGroup`, `initials`) VALUES (@YoE, @yearGroup, @initials)";
                    }
                    else
                    {
                        query.CommandText = "UPDATE `tutorGroups` SET `YoE`=@YoE, `yearGroup`=@yearGroup, `initials`=@initials WHERE `ID`=@ID";
                    }
                    try
                    {
                        query.Parameters.AddWithValue("@YoE", combo_YoE.SelectedValue);
                        query.Parameters.AddWithValue("@yearGroup", int_yearGroup.Value);
                        query.Parameters.AddWithValue("@initials", text_initials.Text);

                        if (this._mode == Program.MODE_Edit)
                        {
                            query.Parameters.AddWithValue("@ID", text_ID.Text);
                        }

                        if (query.ExecuteNonQuery() == 1)
                        {
                            transaction.Commit();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            transaction.Rollback();
                            Classes.Database.Interface.databaseError("Failed to save data.", GetType().Namespace, "Number of rows saved did not match rows inserted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Classes.Database.Interface.databaseError("Failed to save data.", GetType().Namespace, ex.Message);
                    }
                }
            }
        }

        #region Validation Handlers
        void combo_YoE_SelectedValueChanged(object sender, EventArgs e)
        {
            if (
                 (int)combo_YoE.SelectedValue == -2
                 && Program.userCtrl.is_admin
                )
            {
                Forms.Admin.YoE.Dialog.YearOfEntry newYearOfEntry = new Forms.Admin.YoE.Dialog.YearOfEntry();
                if (newYearOfEntry.ShowDialog() == DialogResult.OK)
                {
                    combo_YoE.DataSource = new Classes.Lists.YearOfEntry().List;
                }
                else
                {
                    validate_YoE();
                }
            }
            else
            {
                validate_YoE();
            }
        }
        void int_yearGroup_ValueChanged(object sender, EventArgs e)
        {
            validate_yearGroup();
        }
        void text_initials_TextChanged(object sender, EventArgs e)
        {
            validate_Initials();
        }
        #endregion
        #region Validation
        StatusMessage validate_YoE()
        {
            StatusMessage result = new StatusMessage();
            if ((int)combo_YoE.SelectedValue < 0)
            {
                result.Message = "Year of Entry selection is invalid.";
                result.is_Success = false;
            }
            Validation.set_validation(label_val_YoE, result);
            return result;
        }
        StatusMessage validate_yearGroup()
        {
            StatusMessage result = new StatusMessage();
            if (int_yearGroup.Value < 12
                || int_yearGroup.Value > 14
                )
            {
                result.Message = "Year group must be in the range 12 to 14 inclusive.";
                result.is_Success = false;
            }
            Validation.set_validation(label_val_yearGroup, result);
            return result;
        }
        StatusMessage validate_Initials()
        {
            StatusMessage result = Validation.validate_string(text_initials.Text, "Initials", "^[A-z]{2,3}$", "can only contain letters", 2, 3);
            Validation.set_validation(label_val_tutor, result);
            return result;
        }
        #endregion

        private bool checkFields()
        {
            List<string> messages = new List<string>();
            bool is_success = true;

            if (!validate_YoE())
            {
                messages.Add(validate_YoE().Message);
                is_success = false;
            }
            if (!validate_yearGroup())
            {
                messages.Add(validate_Initials().Message);
                is_success = false;
            }
            if (!validate_Initials())
            {
                messages.Add(validate_Initials().Message);
                is_success = false;
            }

            if (!is_success)
            {
                Validation.show_message(messages);
            }
            return is_success;
        }
    }
}

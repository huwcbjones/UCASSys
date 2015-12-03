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

namespace UCASSys.Forms.Admin.YoE.Dialog
{
    public partial class YearOfEntry : Form
    {

        private int _mode = Program.MODE_New;

        public YearOfEntry(int mode = Program.MODE_New, Classes.Items.YearOfEntryItem YoE = null)
        {
            InitializeComponent();

            this._mode = mode;
            if (mode == Program.MODE_New)
            {
                this.Text = "Add Year of Entry";
                btn_do.Text = "&Add";
            }
            else if (mode == Program.MODE_Edit
               && YoE != null
               )
            {
                this.Text = "Edit Year of Entry: " + YoE.ID.ToString();
                btn_do.Text = "&Edit";
                text_ID.Text = YoE.ID.ToString();
                text_YoE.Text = YoE.Text;
                text_description.Text = YoE.Text;
                date_dline_info.Value = YoE.deadline_Details;
                date_dline_apps.Value = YoE.deadline_Applications;
                date_dline_refs.Value = YoE.deadline_Reference;
            }
            else
            {
                Program.error("Year of Entry Error", "Failed to load Year of Entry.", "Invalid mode passed to form.");
                this.DialogResult = DialogResult.Abort;
            }

            btn_do.Click += btn_do_Click;

            text_description.TextChanged += text_description_TextChanged;
            text_YoE.TextChanged += text_YoE_TextChanged;
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
                        query.CommandText = "INSERT INTO `yearOfEntry` (`YearOfEntry`, `deadline_details`, `deadline_applications`, `deadline_references`, `description`)" +
                            "VALUES (@yoe, @details, @apps, @references, @desc)";
                    }
                    else
                    {
                        query.CommandText = "UPDATE `yearOfEntry` SET `yearOfEntry`=@yoe, `deadline_details`=@details, `deadline_applications`=@apps, " +
                            "`deadline_references`=@references, `description`=@desc WHERE `ID`=@ID";
                    }
                    try
                    {
                        query.Parameters.AddWithValue("@yoe", text_YoE.Text);
                        query.Parameters.AddWithValue("@details", DateTimeHelper.GetWithoutMilliseconds(date_dline_info.Value));
                        query.Parameters.AddWithValue("@apps", DateTimeHelper.GetWithoutMilliseconds(date_dline_apps.Value));
                        query.Parameters.AddWithValue("@references", DateTimeHelper.GetWithoutMilliseconds(date_dline_refs.Value));
                        query.Parameters.AddWithValue("@desc", text_description.Text);

                        if (this._mode == Program.MODE_Edit)
                        {
                            query.Parameters.AddWithValue("@ID", text_ID);
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

        void text_YoE_TextChanged(object sender, EventArgs e)
        {
            validate_YoE();
        }
        void text_description_TextChanged(object sender, EventArgs e)
        {
            validate_Description();
        }

        Classes.StatusMessage validate_YoE()
        {
            Classes.StatusMessage result = Classes.Validation.validate_string(text_YoE.Text, "Year of Entry", "^[A-z0-9\\s]+$", "can only contain letters, numbers and spaces.", 1, 255);
            Classes.Validation.set_validation(label_val_YoE, result);
            return result;
        }

        Classes.StatusMessage validate_Description()
        {
            Classes.StatusMessage result = Classes.Validation.validate_string(text_description.Text, "Description", "[\\s\\S]*", " failed to pass validation.", -1, 255);
            Classes.Validation.set_validation(label_val_desc, result);
            return result;
        }

        private bool checkFields()
        {
            List<string> messages = new List<string>();
            bool is_success = true;
            if (!validate_YoE())
            {
                messages.Add(validate_YoE().Message);
                is_success = false;
            }
            if (!validate_Description())
            {
                messages.Add(validate_Description().Message);
                is_success = false;
            }

            if (!is_success)
            {
                Classes.Validation.show_message(messages);
            }

            return is_success;
        }
    }
}

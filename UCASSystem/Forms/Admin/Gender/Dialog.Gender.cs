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

namespace UCASSys.Forms.Admin.Gender
{
    public partial class Gender : Form
    {

        private int _mode = Program.MODE_New;
        public Gender(int mode = Program.MODE_New, Classes.Items.GenderItem gender = null)
        {
            InitializeComponent();

            if (mode == Program.MODE_New)
            {
                this.Text = "Add Gender";
                btn_do.Text = "&Add";
            }
            else if (mode == Program.MODE_Edit
                && gender != null
                )
            {
                this.Text = "Edit Gender";
                btn_do.Text = "&Edit";
            }
            else
            {
                Program.error("Religion Error", "Failed to load gender.", "Invalid mode passed to form.");
                this.DialogResult = DialogResult.Abort;
            }

            text_gender.TextChanged += text_gender_TextChanged;
        }

        void text_gender_TextChanged(object sender, EventArgs e)
        {
            validate_Gender();
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
                        query.CommandText = "INSERT INTO `genders` (`gender`) VALUES (@gender)";
                    }
                    else
                    {
                        query.CommandText = "UDPATE `genders` SET `gender`=@gender WHERE `ID=@ID";
                    }

                    try
                    {
                        query.Parameters.AddWithValue("@gender", text_gender.Text);
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

        Classes.StatusMessage validate_Gender()
        {
            Classes.StatusMessage result = Classes.Validation.validate_string(text_gender.Text, "Gender", "^([a-z\\-]+)(\\s[a-z\\-]+)*$", "can only containt letters and spaces");
            Classes.Validation.set_validation(label_val_gender, result);
            return result;
        }

        private bool checkFields()
        {
            List<string> messages = new List<string>();
            bool is_success = true;
            if (!validate_Gender())
            {
                messages.Add(validate_Gender().Message);
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

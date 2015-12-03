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

namespace UCASSys.Forms.Admin.Religion
{
    public partial class Religion : Form
    {

        private int _mode = Program.MODE_New;
        public Religion(int mode = Program.MODE_New, Classes.Items.ReligionItem religion = null)
        {
            InitializeComponent();

            this._mode = mode;
            if (mode == Program.MODE_New)
            {
                this.Text = "Add Religion";
                btn_do.Text = "&Add";
            }
            else if (mode == Program.MODE_Edit
                && religion != null
                )
            {
                this.Text = "Edit Religion";
                btn_do.Text = "&Edit";
                text_ID.Text = religion.ID.ToString();
                text_religion.Text = religion.Text;
            }
            else
            {
                Program.error("Religion Error", "Failed to load religion.", "Invalid mode passed to form.");
                this.DialogResult = DialogResult.Abort;
            }

            text_religion.TextChanged += text_religion_TextChanged;
        }

        void text_religion_TextChanged(object sender, EventArgs e)
        {
            validate_Religion();
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
                        query.CommandText = "INSERT INTO `religions` (`religion`) VALUES (@religion)";
                    }
                    else
                    {
                        query.CommandText = "UPDATE `religions` SET `religion`=@religion WHERE `ID`=@ID";
                    }

                    try
                    {
                        query.Parameters.AddWithValue("@religion", text_religion.Text);
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

        Classes.StatusMessage validate_Religion()
        {
            Classes.StatusMessage result = Classes.Validation.name(text_religion.Text, "Religion", true);
            Classes.Validation.set_validation(label_val_religion, result);
            return result;
        }

        private bool checkFields()
        {
            List<string> messages = new List<string>();
            bool is_success = true;
            if (!validate_Religion())
            {
                messages.Add(validate_Religion().Message);
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

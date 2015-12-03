using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCASSys.Classes;


namespace UCASSys.Forms.Main
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();

            text_old.TextChanged += text_old_TextChanged;
            text_new.TextChanged += text_new_TextChanged;
            text_conf.TextChanged += text_conf_TextChanged;

            btn_change.Click += btn_change_Click;
        }

        void btn_change_Click(object sender, EventArgs e)
        {
            if (!checkFields())
            {
                return;
            }
            StatusMessage result = Program.userCtrl.changePassword(text_old.Text, text_new.Text, text_conf.Text);
            using (TaskDialog dialog = new TaskDialog(this.Handle))
            {
                if (result)
                {
                    dialog.infoBox();
                    dialog.Title = "Password Changed";
                    dialog.Subtitle = "Password successfully changed!";

                    dialog.Show();
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    dialog.errorBox();
                    dialog.Title = "Password Error";
                    dialog.Subtitle = "Failed to change password.";
                    dialog.Text = result.Message;
                    dialog.DetailsText = (string)result.Data;

                    dialog.Show();
                    return;
                }
            }
        }

        #region Validation Handlers
        private void text_old_TextChanged(object sender, EventArgs e)
        {
            validate_old();
        }
        private void text_new_TextChanged(object sender, EventArgs e)
        {
            validate_new();
        }
        private void text_conf_TextChanged(object sender, EventArgs e)
        {
            validate_new();
        }
        #endregion

        #region Validation
        StatusMessage validate_old()
        {
            StatusMessage result = Validation.password(text_old.Text);
            Validation.set_validation(label_val_old, result);
            return result;
        }
        StatusMessage validate_new()
        {
            StatusMessage result = Validation.password(text_new.Text);
            Validation.set_validation(label_val_new, result);
            return result;
        }
        StatusMessage validate_conf()
        {
            StatusMessage result = Validation.confirm(text_new.Text, text_conf.Text, "Passwords do not match.");
            Validation.set_validation(label_val_conf, result);
            return result;
        }
        #endregion

        private bool checkFields()
        {
            List<string> messages = new List<string>();
            bool is_success = true;

            if (!validate_old())
            {
                is_success = false;
                messages.Add(validate_old().Message);
            }
            if (!validate_new())
            {
                is_success = false;
                messages.Add(validate_new().Message);
            }
            if (!validate_conf())
            {
                is_success = false;
                messages.Add(validate_conf().Message);
            }
            if (!Validation.confirm(text_old.Text, text_new.Text, "New password cannot be the same as the old password.", true))
            {
                is_success = false;
                messages.Add("New password cannot be the same as the old password.");
            }

            if (!is_success)
            {
                Validation.show_message(messages);
            }
            return is_success;
        }
    }
}

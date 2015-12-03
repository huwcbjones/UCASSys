using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using StatusMsg = UCASSys.Classes.StatusMessage;
using Validation = UCASSys.Classes.Validation;
using System.DirectoryServices.AccountManagement;

namespace UCASSys.Forms.Setup
{
    public partial class details : Form
    {
        public details()
        {
            InitializeComponent();

            worker_loadDetails.DoWork += worker_loadDetails_DoWork;
            if (!worker_loadDetails.IsBusy)
            {
                worker_loadDetails.RunWorkerAsync();
            }

            // Buton Handlers
            btn_next.Click += btn_next_Click;

            // Validation Handlers
            text_username.TextChanged += text_username_TextChanged;
            text_firstName.TextChanged += text_firstName_TextChanged;
            text_lastName.TextChanged += text_lastName_TextChanged;
            text_email.TextChanged += text_email_TextChanged;

            // Format handlers
            text_firstName.LostFocus += formatName;
            text_lastName.LostFocus += formatName;
            text_email.LostFocus += formatEmail;

        }

        #region Handlers
        void text_username_TextChanged(object sender, EventArgs e)
        {
            validate_username();
        }
        void text_firstName_TextChanged(object sender, EventArgs e)
        {
            validate_firstname();
        }
        void text_lastName_TextChanged(object sender, EventArgs e)
        {
            validate_lastname();
        }
        void text_email_TextChanged(object sender, EventArgs e)
        {
            validate_email();
        }
        #endregion

        #region Formatters
        void formatName(object sender, EventArgs e)
        {
            TextInfo textinf = CultureInfo.CurrentCulture.TextInfo;
            TextBox textbox;
            textbox = (TextBox)sender;
            textbox.Text = textinf.ToTitleCase(textbox.Text);
        }
        void formatEmail(object sender, EventArgs e)
        {
            TextBox textbox;
            textbox = (TextBox)sender;
            textbox.Text = textbox.Text.ToLower();
        }
        #endregion

        #region Validation
        StatusMsg validate_username()
        {
            StatusMsg result = Validation.username(text_username.Text);
            Validation.set_validation(label_val_username, result);
            return result;
        }
        StatusMsg validate_firstname()
        {
            StatusMsg result = Validation.name(text_firstName.Text, "First Name");
            Validation.set_validation(label_val_firstName, result);
            return result;
        }
        StatusMsg validate_lastname()
        {
            StatusMsg result = Validation.name(text_lastName.Text, "Last Name");
            Validation.set_validation(label_val_lastName, result);
            return result;
        }
        StatusMsg validate_email()
        {
            StatusMsg result = Validation.email(text_email.Text);
            Validation.set_validation(label_val_email, result);
            return result;
        }
        #endregion

        private bool checkFields()
        {
            List<string> messages = new List<string>();
            bool is_success = true;
            if (!validate_username())
            {
                messages.Add(validate_username().Message);
                is_success = false;
            }
            if (!validate_firstname())
            {
                messages.Add(validate_firstname().Message);
                is_success = false;
            }
            if (!validate_lastname())
            {
                messages.Add(validate_lastname().Message);
                is_success = false;
            }
            if (!validate_email())
            {
                messages.Add(validate_email().Message);
                is_success = false;
            }
            if (!is_success)
            {
                Validation.show_message(messages);
            }
            return is_success;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                this.Hide();
            }
        }

        #region Worker Delegation
        // Allows the worker to update the fields from a different thread
        delegate void set_text_delegate(TextBox textbox, string text);
        void set_text(TextBox textbox, string text)
        {
            if (textbox.InvokeRequired)
            {
                set_text_delegate invoke = new set_text_delegate(set_text);
                this.Invoke(invoke, new Object[] { textbox, text });
            }
            else if (textbox.TextLength == 0)
            {
                textbox.Text = text;
            }
        }

        delegate void set_marquee_del(bool is_enabled);
        private void set_marquee(bool is_enabled)
        {
            if (progress_load.InvokeRequired)
            {
                set_marquee_del invoke = new set_marquee_del(set_marquee);
                this.Invoke(invoke, is_enabled);
            }
            else
            {
                if (is_enabled)
                {
                    label_loading.Text = "Please wait, loading details...";
                    progress_load.Style = ProgressBarStyle.Marquee;
                    label_loading.Visible = true;
                }
                else
                {
                    label_loading.Text = "Details loaded";
                    progress_load.Style = ProgressBarStyle.Blocks;
                }
            }
        }

        #endregion
        private void worker_loadDetails_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            set_marquee(true);
            try
            {
                if (UserPrincipal.Current == null)
                {
                    set_marquee(false);
                    return;
                }
                UserPrincipal currentUser = UserPrincipal.Current;
                set_text(text_username, currentUser.SamAccountName.ToLower());
                set_text(text_firstName, currentUser.Name);
                set_text(text_lastName, currentUser.GivenName);
                set_text(text_email, currentUser.EmailAddress);
            }
            catch (Exception ex)
            {
                Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
            }
            set_marquee(false);
        }
    }
}

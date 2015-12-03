using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatusMsg = UCASSys.Classes.StatusMessage;
using Validation = UCASSys.Classes.Validation;

namespace UCASSys.Forms.Setup
{
    public partial class password : Form
    {
        public password()
        {
            InitializeComponent();

            btn_next.Click += btn_next_Click;
            text_new.TextChanged += text_new_TextChanged;
            text_conf.TextChanged += text_conf_TextChanged;
        }

        #region Handlers
        private void text_new_TextChanged(object sender, EventArgs e)
        {
            validate_new();
        }
        private void text_conf_TextChanged(object sender, EventArgs e)
        {
            validate_conf();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }
        #endregion
        #region Validation

        private StatusMsg validate_new()
        {
            StatusMsg result = Validation.password(text_new.Text);
            Validation.set_validation(label_val_new, result);
            return result;
        }
        private StatusMsg validate_conf()
        {
            StatusMsg result = Validation.confirm(text_new.Text, text_conf.Text, "Passwords do not match");
            Validation.set_validation(label_val_conf, result);
            return result;
        }

        private bool checkFields()
        {
            List<string> messages = new List<string>();
            bool is_success = true;

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
            if (!is_success)
            {
                Validation.show_message(messages);
            }

            return is_success;
        }
        #endregion
    }
}

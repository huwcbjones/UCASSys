using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskDialog = UCASSys.Classes.TaskDialog;
using Validation = UCASSys.Classes.Validation;

namespace UCASSys.Forms.Main
{
    public partial class login : Form
    {
        public login(string database)
        {
            InitializeComponent();
            Btn_Login.Click += btn_login_Click;
            text_database.Text = database;
        }

        private void login_Load(object sender, EventArgs e)
        {
            text_username.Focus();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            process_login();
        }
        private void process_login()
        {
            TaskDialog dialog = new TaskDialog(this.Handle);

            dialog.authBox();
            dialog.Title = "Authentication Failure";

            if (text_username.TextLength == 0 | text_password.TextLength == 0)
            {
                dialog.Subtitle = "No username or password provided.";
                dialog.Text = "Please enter a username and password.";
                dialog.Show();
                return;
            }
            Classes.StatusMessage result = Program.userCtrl.is_authenticatedName(text_password.Text, text_username.Text, true);
            if (result)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                dialog.Subtitle = "Invalid Username/Password";
                dialog.Text = "Please enter a valid username and password.";
                if (result.Message != null)
                {
                    dialog.DetailsText = result.Message;
                }
                dialog.Show();
                clearForm();
                text_username.Focus();
            }
        }

        void clearForm()
        {
            text_username.Text = "";
            text_password.Text = "";
        }
    }
}

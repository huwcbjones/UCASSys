using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCASSys.Forms.Setup
{
    public partial class confirm : Form
    {
        public confirm()
        {
            InitializeComponent();
        }

        private void check_pwd_show_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pwd_show.Checked)
            {
                text_password.UseSystemPasswordChar = false;
            }
            else
            {
                text_password.UseSystemPasswordChar = true;
            }
        }
    }
}

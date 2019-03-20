using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingStudy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrWhiteSpace(tbUsername.Text)){
                btnLogin.Text = "Войти как гость";
            }
            else
            {
                btnLogin.Text = "Войти как " + tbUsername.Text;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Main form = new Main(new UserArguments(tbUsername.Text));
            form.Show();
        }
    }
}

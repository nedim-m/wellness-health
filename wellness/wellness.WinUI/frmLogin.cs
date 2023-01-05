using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wellness.WinUI
{
    public partial class frmLogin : Form
    {

        private readonly ApiService _api = new ApiService("Auth");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            ApiService.request.UserName=txtUsernameInput.Text;
            ApiService.request.Password=txtPasswordInput.Text;
            try
            {
                 await _api.Authentication();
                mdiMainMenu mdi = new();
                mdi.Show();

            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect username or password");
            }

        }
    }
}

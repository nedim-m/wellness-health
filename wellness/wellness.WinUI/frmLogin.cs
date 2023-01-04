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
            ApiService.Username=txtUsernameInput.Text;
            ApiService.Password=txtPasswordInput.Text;
            try
            {
                //var result = var list = await _endPoint.WithOAuthBearerToken()
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect username or password");
            }

        }
    }
}

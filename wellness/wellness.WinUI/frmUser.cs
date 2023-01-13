using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wellness.Model;
using wellness.Model.User;

namespace wellness.WinUI
{
    public partial class frmUser : Form
    {
        private readonly ApiService _api = new ApiService("User");
        private readonly string role = "Member";

        public frmUser()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var search = new UserSearchObj();
            search.Role=role;
            search.SearchName = txtUserSearch.Text;

            var response = await _api.Get<ServiceResponse<IEnumerable<Models.User.User>>>(search);
            
            dgvUsers.DataSource=response.Data;
            dgvUsers.Columns["Picture"].Visible=false;
            dgvUsers.Columns["Id"].Visible=false;
            dgvUsers.Columns["Role"].Visible=false;
            dgvUsers.Columns["Email"].Visible=false;
            
           

        }
    }
}

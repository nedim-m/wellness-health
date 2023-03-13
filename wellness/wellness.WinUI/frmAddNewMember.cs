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
    public partial class frmAddNewMember : Form
    {
        public frmAddNewMember()
        {
            InitializeComponent();
        }

        private void frmAddNewMember_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string imageLocation = string.Empty;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter= "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation=dialog.FileName;
                    imgInput.ImageLocation=imageLocation;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("An error occured","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}

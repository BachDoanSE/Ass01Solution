using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccess.Repository;
using DataAccess;
using BusinessObject;
namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        MemberDAO member = new MemberDAO();
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            String password = txtPassword.Text;

            try
            {
                MemberObject loginMember = member.Login(email, password);
                if (loginMember != null)
                {
                    this.Hide();
                    frmManagement frmManagement = new frmManagement(loginMember);
                    frmManagement.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

using BusinessObject;
namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        IMemberServices memberServices = new MemberServices();
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
                MemberObject loginMember = memberServices.Login(email, password);
                if (loginMember != null)
                {
                    this.Hide();
                    frmMemberManagement frmManagement = new frmMemberManagement(loginMember);
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

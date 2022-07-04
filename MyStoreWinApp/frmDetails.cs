using BusinessObject;
namespace MyStoreWinApp
{
    public partial class frmDetails : Form
    {

        public IMemberServices memberServices { get; set; }
        public bool IsUpdate { get; set; }
        public MemberObject memberInfo { get; set; }
        public frmDetails()
        {
            InitializeComponent();
        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsUpdate == true)
                {
                    txtMemberId.Text = memberInfo.MemberID.ToString();
                    txtMemberName.Text = memberInfo.MemberName;
                    txtEmail.Text = memberInfo.Email;
                    txtPassword.Text = memberInfo.Password;
                    txtCity.Text = memberInfo.City;
                    txtCountry.Text = memberInfo.Country;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Details form");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                };
                if (IsUpdate == false)
                {
                    memberServices.CreateMember(member);
                }
                else
                {
                    member.MemberID = int.Parse(txtMemberId.Text);
                    memberServices.UpdateMember(member);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IsUpdate==false ? "Add Member" : "Update Member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void grpDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}

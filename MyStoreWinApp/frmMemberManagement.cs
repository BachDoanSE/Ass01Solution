using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using DataAccess;
using BusinessObject;
namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        private MemberObject loginMember;
        private MemberDAO member = new MemberDAO();
        private bool IsAdmin = false;
        private BindingSource source;
        private void CheckAuthentication()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", true, true)
                .Build();

            string adminEmail = config["DefaultAccounts:Email"];

            if (loginMember.Email == adminEmail)
            {
                IsAdmin = true;
            }
        }

        private MemberObject GetMemberObject()
        {
            MemberObject member = null;
            try
            {
                var currentRow = dgvMemberList.CurrentRow;
                member = new MemberObject
                {
                    MemberID = Convert.ToInt32(currentRow.Cells[0].Value),
                    MemberName = currentRow.Cells[1].Value.ToString(),
                    Email = currentRow.Cells[2].Value.ToString(),
                    Password = currentRow.Cells[3].Value.ToString(),
                    City = currentRow.Cells[4].Value.ToString(),
                    Country = currentRow.Cells[5].Value.ToString(),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }

        private void ClearText()
        {
            // CODE HERE
            txtMemberId.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtCity.Text = string.Empty;
        }
        public void LoadMemberList(IEnumerable<MemberObject> list)
        {
            // CODE HERE
            try
            {
                source = new BindingSource();
                if (IsAdmin == false)
                {
                    source.DataSource = null;
                }
                else
                {
                    source.DataSource = list;
                }

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;

                if (list.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }

        }

        public frmMemberManagement(MemberObject loginMember)
        {
            this.loginMember = loginMember;
            InitializeComponent();
        }

 

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            CheckAuthentication();

            btnDelete.Enabled = false;

            var memberList = member.GetMemberList();
            LoadMemberList(memberList);
            dgvMemberList.CellDoubleClick += DgvMemberList_CellDoubleClick;
        }
        private void DgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDetails details = new frmDetails
            {
                Text = "Update Member",
                IsUpdate = true,
                memberInfo = GetMemberObject(),
                memberServices = memberServices,
            };
            if (details.ShowDialog() == DialogResult.OK)
            {
                var memberList = memberServices.GetMemberList();
                LoadMemberList(memberList);
                source.Position = source.Count - 1;
            }
        }

        private void dgvMemberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

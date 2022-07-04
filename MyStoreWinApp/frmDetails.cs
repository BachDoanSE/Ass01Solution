using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessObject;
namespace MyStoreWinApp
{
    public partial class frmDetails : Form
    {
        

        public bool IsUpdate { get; set; }
        public MemberObject memberInfo { get; set; }
        public frmDetails()
        {
            InitializeComponent();
        }

        private void frmDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}

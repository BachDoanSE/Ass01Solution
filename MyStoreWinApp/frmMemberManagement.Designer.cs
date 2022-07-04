namespace MyStoreWinApp
{
    partial class frmMemberManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpManagement = new System.Windows.Forms.GroupBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvMemberList = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.grpManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            this.SuspendLayout();
            // 
            // grpManagement
            // 
            this.grpManagement.BackColor = System.Drawing.SystemColors.Control;
            this.grpManagement.Controls.Add(this.txtCity);
            this.grpManagement.Controls.Add(this.txtCountry);
            this.grpManagement.Controls.Add(this.btnLogout);
            this.grpManagement.Controls.Add(this.dgvMemberList);
            this.grpManagement.Controls.Add(this.btnSearch);
            this.grpManagement.Controls.Add(this.btnDelete);
            this.grpManagement.Controls.Add(this.btnInsert);
            this.grpManagement.Controls.Add(this.lblCity);
            this.grpManagement.Controls.Add(this.lblCountry);
            this.grpManagement.Controls.Add(this.txtMemberName);
            this.grpManagement.Controls.Add(this.txtMemberId);
            this.grpManagement.Controls.Add(this.lblMemberName);
            this.grpManagement.Controls.Add(this.lblMemberId);
            this.grpManagement.Location = new System.Drawing.Point(24, 2);
            this.grpManagement.Name = "grpManagement";
            this.grpManagement.Size = new System.Drawing.Size(797, 520);
            this.grpManagement.TabIndex = 2;
            this.grpManagement.TabStop = false;
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCity.Location = new System.Drawing.Point(516, 67);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(228, 34);
            this.txtCity.TabIndex = 15;
            // 
            // txtCountry
            // 
            this.txtCountry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCountry.Location = new System.Drawing.Point(516, 22);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(228, 34);
            this.txtCountry.TabIndex = 14;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.Location = new System.Drawing.Point(344, 451);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(108, 47);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // dgvMemberList
            // 
            this.dgvMemberList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemberList.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvMemberList.Location = new System.Drawing.Point(0, 177);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.RowHeadersWidth = 51;
            this.dgvMemberList.RowTemplate.Height = 29;
            this.dgvMemberList.Size = new System.Drawing.Size(797, 264);
            this.dgvMemberList.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 16;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(0, 0);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 18;
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(0, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(100, 23);
            this.lblCity.TabIndex = 19;
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(0, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(100, 23);
            this.lblCountry.TabIndex = 20;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(0, 0);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 27);
            this.txtMemberName.TabIndex = 21;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(0, 0);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(100, 27);
            this.txtMemberId.TabIndex = 22;
            // 
            // lblMemberName
            // 
            this.lblMemberName.Location = new System.Drawing.Point(0, 0);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(100, 23);
            this.lblMemberName.TabIndex = 23;
            // 
            // lblMemberId
            // 
            this.lblMemberId.Location = new System.Drawing.Point(0, 0);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(100, 23);
            this.lblMemberId.TabIndex = 24;
            // 
            // frmMemberManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(865, 423);
            this.Name = "frmMemberManagement";
            this.Text = "MemberManagement";
            this.Load += new System.EventHandler(this.frmMemberManagement_Load);
            this.grpManagement.ResumeLayout(false);
            this.grpManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpManagement;
        private TextBox txtCity;
        private TextBox txtCountry;
        private Button btnLogout;
        private DataGridView dgvMemberList;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnInsert;
        private Label lblCity;
        private Label lblCountry;
        private TextBox txtMemberName;
        private TextBox txtMemberId;
        private Label lblMemberName;
        private Label lblMemberId;
    }
}
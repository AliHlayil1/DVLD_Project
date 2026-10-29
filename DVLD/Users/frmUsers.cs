using DVLD.User;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmUsers : Form
    {
        private DataTable _dtAllUsers = clsUser.getAllUsers();

        public frmUsers()
        {
            InitializeComponent();
        }

        private void _dgvEditSettings()
        {
            dgvUsers.ClearSelection();
            dgvUsers.AllowUserToAddRows = false;
            for (int i = 0; i < dgvUsers.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvUsers.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }
            }
        }
        
        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.getAllUsers();
            
            dgvUsers.DataSource = _dtAllUsers;
            lblRecordNumber.Text = dgvUsers.Rows.Count.ToString();
            _dgvEditSettings();
        }
        
        private void frmUsers_Load(object sender, EventArgs e)
        {
            cmbFiltter.SelectedIndex = 0;
            dgvUsers.DataSource = _dtAllUsers;
            _dgvEditSettings();
            lblRecordNumber.Text = dgvUsers.Rows.Count.ToString();

            if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 120;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 350;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 120;
            }

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser AddUser = new frmAddUpdateUser();

            AddUser.DataBack += frmAddUpdateUser_DataBack;

            AddUser.ShowDialog();
        }

        private void showDetailsTSMI_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());

            frmUserInformation InfoScreen = new frmUserInformation(userID);

            InfoScreen.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddUser_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());
            frmAddUpdateUser AddUser = new frmAddUpdateUser(userID);

            AddUser.DataBack += frmAddUpdateUser_DataBack;

            AddUser.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());
            DialogResult re = MessageBox.Show("Are You Sure Delete This User ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (re == DialogResult.Yes)
            {
                if (clsUser.Delete(userID))
                {
                    MessageBox.Show($"Deleted This user with ID {userID}");
                    frmAddUpdateUser_DataBack(sender, userID);
                }
                else
                {
                    MessageBox.Show($"Not Deleted user somthing went wrong");
                }
            }

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());

            frmChangePassword changePassword = new frmChangePassword(userID);

            changePassword.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This featur not Exists it's added in soon");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This featur not Exists it's added in soon");
        }

        private void frmAddUpdateUser_DataBack(object sender,int userID)
        {
            _RefreshUsersList();
        }

        private void cmbFiltter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltter.Text == "is Active")
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                return;
            }
            cbIsActive.SelectedIndex = 0;
            txtFilterValue.Visible = (cmbFiltter.Text != "None") && (cmbFiltter.Text != "is Active");
            cbIsActive.Visible = (cmbFiltter.Text == "is Active");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }

            txtFilterValue.Enabled = !(cmbFiltter.Text == "None");

            txtFilterValue.Text = string.Empty;
            txtFilterValue.Focus();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cmbFiltter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordNumber.Text = dgvUsers.Rows.Count.ToString();
                _dgvEditSettings();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordNumber.Text = dgvUsers.Rows.Count.ToString();
            _dgvEditSettings();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFiltter.Text != "Full Name" && cmbFiltter.Text != "UserName")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordNumber.Text = dgvUsers.Rows.Count.ToString();
            _dgvEditSettings();

        }
    }
}

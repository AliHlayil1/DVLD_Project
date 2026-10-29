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
    public partial class frmChangePassword : Form
    {
        private int _userID = -1;

        private clsUser _user;

        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfrimPassword.Text = string.Empty;
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _user = clsUser.Find(this._userID);

            if (_user == null)
            {
                MessageBox.Show($"This User is not exists with this ID {this._userID}", "Not Exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlUserCard1.LoadInfornationToControl(_userID);
        }

        private bool _fillNewPassowrdToObject()
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are field is not validate");
                return false;
            }

            _user.password = txtNewPassword.Text;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_fillNewPassowrdToObject())
            {
                MessageBox.Show("There are wrong try another");
            }

            if (_user.Save())
            {
                MessageBox.Show("Changed password successfully");
                _ResetDefaultValues();
            }
            else
            {
                MessageBox.Show("An error occurred while saving");
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider.SetError(txtCurrentPassword, "This Field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtCurrentPassword, null);
            }

            if (_user.password != txtCurrentPassword.Text)
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider.SetError(txtCurrentPassword, "This Password is wrong");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider.SetError(txtNewPassword, "The new password must not be empty");
            }
            else if (txtNewPassword.Text.Length < 4)
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider.SetError(txtNewPassword, "The password must be more than three charactore");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNewPassword, "");
            }
        }

        private void txtConfrimPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!string.Equals(txtConfrimPassword.Text,txtNewPassword.Text))
            {
                e.Cancel = true;
                txtConfrimPassword.Focus();
                errorProvider.SetError(txtConfrimPassword, "The confrim password must be equal new password");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtConfrimPassword, "");
            }
        }
    }
}

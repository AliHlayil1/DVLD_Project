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
    public partial class frmAddUpdateUser : Form
    {
        public delegate void DataBackEventHandler(object sender, int userID);

        public DataBackEventHandler DataBack;

        enum enMode { AddMode = 1, UpdateMode = 2 }
        enMode Mode;

        private int _userID;

        private clsUser _user;
        private bool isSelected;


        public frmAddUpdateUser()
        {
            InitializeComponent();

            Mode = enMode.AddMode;
        }


        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();

            this._userID = userID;
            Mode = enMode.UpdateMode;
        }

        private void _ResetDefualtValues()
        {
            if(Mode == enMode.AddMode)
            {
                lblTitle.Text = "Add New User";
                _user = new clsUser();
                tpLogginInfo.Enabled = false;
                ctrPersonCardWithFilter1.FocusFilter();
            }
            else
            {
                lblTitle.Text = "Update User";
                _user = clsUser.Find(_userID);
                tbctrlLogginNewUser.Enabled = true;
                btnSave.Enabled = true;
            }

            lblUserID.Text = "N/A";
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;

        }

        private void _LoadData()
        {
            _user = clsUser.Find(_userID);

            ctrPersonCardWithFilter1.FilterEnabled = false;

            if(_user == null)
            {
                MessageBox.Show("This user is not found!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserID.Text = _user.userID.ToString();
            txtUserName .Text = _user.userName.ToString();
            txtPassword.Text = _user.password.ToString();
            txtConfirmPassword.Text = _user.password.ToString();
            ctrPersonCardWithFilter1.loadPersonData(_user.personID);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (Mode == enMode.UpdateMode)
                _LoadData();
        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrPersonCardWithFilter1.FocusFilter();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(Mode==enMode.UpdateMode)
            {
                btnSave.Enabled = true;
                tpLogginInfo.Enabled = true;
                tbctrlLogginNewUser.SelectedTab = tbctrlLogginNewUser.TabPages["tpLogginInfo"];
                return;
            }

            if(ctrPersonCardWithFilter1.personID != -1)
            {
                if(!clsUser.isPersonExists(ctrPersonCardWithFilter1.personID))
                {
                    btnSave.Enabled = true;
                    tpLogginInfo.Enabled = true;
                    tbctrlLogginNewUser.SelectedTab = tbctrlLogginNewUser.TabPages["tpLogginInfo"];
                }
                else
                {
                    MessageBox.Show("This person is Exist in user enter another person", "person is exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ctrPersonCardWithFilter1.FocusFilter();
                }
            }
            else
            {
                MessageBox.Show("Please selected the personID", "selected personID", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                ctrPersonCardWithFilter1.FocusFilter();
            }

        }

        private void btnPrevios_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                tbctrlLogginNewUser.SelectTab(0);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider.SetError(txtUserName, "The UserName can not be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider.SetError(txtPassword, "The Password can not be Empty");
            }
            else if (txtPassword.Text.Length < 4)
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider.SetError(txtPassword, "The Password can not be Less Than 4 Charactar");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(!string.Equals(txtPassword.Text,txtConfirmPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider.SetError(txtConfirmPassword, "The Confrim Password must be Equal Passowrd Field");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtConfirmPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadInfoToObject()
        {
            _user.personID = ctrPersonCardWithFilter1.personID;
            _user.userName = txtUserName.Text;
            _user.password = txtPassword.Text;
            _user.isActive = chbxIsActive.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            loadInfoToObject();
            
            if (_user.Save())
            {
                lblTitle.Text = "Update User";
                lblUserID.Text = _user.userID.ToString();
                _userID = _user.userID;
                Mode = enMode.UpdateMode;
                MessageBox.Show($"Saved user with ID {_user.userID}");
                DataBack?.Invoke(sender, _user.userID);
            }
            else
            {
                MessageBox.Show($"Not saved user somthing went wrong");
            }
        }

        private void ctrPersonCardWithFilter1_OnPersonSelected(int personID)
        {
        }

    }
}

using DVLDBusinessLayer;
using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace DVLD.Forms
{
    public partial class frmLoggin : Form
    {
        struct stUserInfo
        {
            public string userName {  get; set; }
            public string password { get; set; }
        }

        string _filePath = Application.StartupPath + "\\App_File_Setting.txt";

        string _fileContent = "";

        private stUserInfo _ConvertLineToRecord(string Line,string seperator = "#||#")
        {
            stUserInfo stUser = new stUserInfo();

            stUser.userName = Line.Split(new string[] { seperator },StringSplitOptions.None)[0];
            stUser.password = Line.Split(new string[] { seperator },StringSplitOptions.None)[1];

            return stUser;
        }

        public frmLoggin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.Find(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (user == null)
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(chRememberAcount.Checked)
            {
                clsGlobal.SaveUserNameAndPasswordToFile(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            }
            else
            {
                clsGlobal.SaveUserNameAndPasswordToFile("", "");
            }

            if(!user.isActive)
            {
                txtUserName.Focus();
                MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            clsGlobal.currentUser = user;
            MainForm MF = new MainForm(this);
            MF.Show();
        }

        private void frmLoggin_Load(object sender, EventArgs e)
        {
            string userName = string.Empty;
            string password = string.Empty;
            if (clsGlobal.RecoveryUserNameAndPasswordFromFile(ref userName,ref password))
            {
                txtUserName.Text = userName;
                txtPassword.Text = password;
                chRememberAcount.Checked = true;
            }
            else
            {
                chRememberAcount.Checked = false;
            }
        }
    }
}

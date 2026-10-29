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
    public partial class MainForm : Form
    {
        private const int MAXWIDTH = 250;
        private const int MINWIDTH = 50;
        private clsFormsSetting FormSetting;
        private Form _fromLoggin;

        public MainForm(Form frm)
        {
            InitializeComponent();
            FormSetting = new clsFormsSetting(pMainBody);
            _fromLoggin = frm;
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {

        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            FormSetting.currentForm = new frmPeople();
            if (FormSetting.isOpen())
            {
                FormSetting.CloseForm();
                pSideMenu.Width = MAXWIDTH;
            }
            else
            {
                FormSetting.OpenForm();
                pSideMenu.Width = MINWIDTH;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormSetting.currentForm = new frmUsers();
            if (FormSetting.isOpen())
            {
                FormSetting.CloseForm();
                pSideMenu.Width = MAXWIDTH;
            }
            else
            {
                FormSetting.OpenForm();
                pSideMenu.Width = MINWIDTH;
            }
        }

        int count;
        private void btnAplications_Click(object sender, EventArgs e)
        {
            count++;
            if(count == 1)
            {
                pApplicationFeature.Height = 170;
            }
            else
            {
                pApplicationFeature.Height = 43;
                count = 0;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsGlobal.currentUser = null;
            _fromLoggin.Show();
            this.Close();
        }
    }
}

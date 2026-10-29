using DVLD.Applications.Local_Driving_License;
using DVLD.Tests.TestType;
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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            clsGlobal.currentUser = clsUser.Find("Hlyl", "1234");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            new frmAddUpdateLocalDrivingLicense().ShowDialog();
        }

        private void btnUpdateTest_Click(object sender, EventArgs e)
        {
            new frmAddUpdateUser(21).ShowDialog();
        }
    }
}

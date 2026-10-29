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

namespace DVLD.Tests.TestType
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            dgvTestType.DataSource = clsTestType.getAllTestType();
            lblRecordNumber.Text = dgvTestType.Rows.Count.ToString();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frmUpdate = new frmUpdateTestType((clsTestType.enTestTypes)dgvTestType.CurrentRow.Cells[0].Value);

            frmUpdate.DataBack += frmUpdateTestType_DataBack;

            frmUpdate.ShowDialog();
        }

        private void frmUpdateTestType_DataBack(object sender, clsTestType.enTestTypes TestTypeID)
        {
            frmManageTestTypes_Load(null, null);
        }
    }
}

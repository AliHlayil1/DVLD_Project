using DVLD.Applications.ApplicationType;
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
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
        }
        
        private void _dgvEditSettings()
        {
            dgvApplicationType.ClearSelection();
            dgvApplicationType.AllowUserToAddRows = false;
            for (int i = 0; i < dgvApplicationType.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvApplicationType.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }
            }
        }

        private void frmApplications_Load(object sender, EventArgs e)
        {
            dgvApplicationType.DataSource = clsAplicationType.getAllApllicationType();
            _dgvEditSettings();
            lblRecordNumber.Text = dgvApplicationType.Rows.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frmUpdate = new frmUpdateApplicationType(int.Parse(dgvApplicationType.CurrentRow.Cells[0].Value.ToString()));

            frmUpdate.DataBack += frmUpdateApplicationType_DataBack;

            frmUpdate.ShowDialog();
        }

        private void frmUpdateApplicationType_DataBack(object sender, int id)
        {
            frmApplications_Load(null, null);
        }

    }
}

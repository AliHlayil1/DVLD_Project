using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.ApplicationType
{
    public partial class frmUpdateApplicationType : Form
    {
        public delegate void FormDataBackHandler(object sender, int ID);

        public event FormDataBackHandler DataBack;

        private int _ApplicationTypeID;

        private clsAplicationType _ApplicationType;

        public frmUpdateApplicationType(int ID)
        {
            InitializeComponent();
            this._ApplicationTypeID = ID;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsAplicationType.Find(this._ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show($"This Appplication Type is not found in data with ID {_ApplicationTypeID} try another time", 
                    "Not Exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblApplicationTypeID.Text = _ApplicationType.id.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.title.ToString();
            txtFees.Text = _ApplicationType.fees.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are Field is Not Valid", "Not Valid", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return; 
            }

            if(MessageBox.Show("Is you want Saving This Change in This Appliction?",
                "Is Sure",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            _ApplicationType.title = txtApplicationTypeTitle.Text;
            _ApplicationType.fees = Convert.ToSingle(txtFees.Text);

            if (!_ApplicationType.Update())
            {
                MessageBox.Show("The Update Faild try another time", "Error in Server", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            DataBack?.Invoke(this, _ApplicationType.id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if(string.IsNullOrEmpty(txt.Text))
            {
                txt.Focus();
                e.Cancel = true;
                errorProvider.SetError(txt, "This Field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txt, null);
            }

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            TextBoxEmpty_Validating(sender, e);

            if(double.TryParse(txtFees.Text, out double fees))
            {
                if(fees < 0)
                {
                    txtFees.Text = string.Empty;
                    txtFees.Focus();
                    e.Cancel = true;
                    errorProvider.SetError(txtFees, "This Field is Not less than zero");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtFees, null);
                }
            }

        }

    }
}

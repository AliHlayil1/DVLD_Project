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
    public partial class frmUpdateTestType : Form
    {
        public delegate void DataBackEventHandler(object sender, clsTestType.enTestTypes TestTypeID);

        public DataBackEventHandler DataBack;

        private clsTestType.enTestTypes _TestTypeID;

        private clsTestType _TestType;

        public frmUpdateTestType(clsTestType.enTestTypes id)
        {
            InitializeComponent();
            this._TestTypeID = id;
        }

        private void clsUpdateTestType_Load(object sender, EventArgs e)
        {
            this._TestType = clsTestType.Find((clsTestType.enTestTypes)this._TestTypeID);

            if (this._TestType == null)
            {
                MessageBox.Show($"This Test Type is Not Found With this id {this._TestTypeID}", "Not exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTestTypeID.Text = this._TestType.id.ToString();
            txtTestTypeTitle.Text = this._TestType.title.ToString();
            txtTestTypeDescreption.Text = this._TestType.description.ToString();
            txtFees.Text = this._TestType.fees.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are field is not valid", "not valid", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            if(MessageBox.Show("Is you sure to saving this data", "Is Sure", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            this._TestType.title = txtTestTypeTitle.Text;
            this._TestType.description = txtTestTypeDescreption.Text;
            this._TestType.fees = double.Parse(txtFees.Text);

            if(_TestType.Update())
            {
                MessageBox.Show("This Test Type is Updated", "Update Successfull", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                DataBack?.Invoke(this, this._TestType.id);
            }
            else
            {
                MessageBox.Show("This Test Type is not Updated", "Update Faild", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxEmpty_Validate(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if(string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "This Field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, null);
            }

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            TextBoxEmpty_Validate(sender, e);

            if (double.TryParse(txtFees.Text,out double fees))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, null);

                if (fees < 0)
                {
                    e.Cancel = true;
                    txtFees.Focus();
                    errorProvider1.SetError(txtFees, "The fees must be more than zero");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtFees, null);
                }

            }
            else
            {
                e.Cancel = true;
                txtFees.Focus();
                errorProvider1.SetError(txtFees, "The fees must be Number");
            }
        }

    }
}

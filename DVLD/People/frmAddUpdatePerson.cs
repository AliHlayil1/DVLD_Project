using DVLD.Properties;
using DVLD.Settings_Class;
using DVLDBusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public DataBackEventHandler DataBack;

        enum enMode { AddMode=1, UpdateMode=2};
        enum enGendor { Male=0, Female=1 };
        enMode Mode;

        private int _PersonID { get; set;}

        private clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();

            _PersonID = -1;
            Mode = enMode.AddMode;
            _Person = new clsPerson();
            lblTitle.Text = "Add New Person";
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            Mode = enMode.UpdateMode;
            _Person = clsPerson.Find(PersonID);
            lblTitle.Text = "Update Person";
        }

        private void _ResetDefaultValue()
        {

            _FillCountriesInComoboBox();

            if (Mode == enMode.AddMode)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            rbMale.Checked = true;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.personbody72;
            else
                pbPersonImage.Image = Resources.person_girl72;

            llblRemove.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cmbCountry.SelectedIndex = cmbCountry.FindString("Syria");

            txtFirstName.Text = string.Empty;
            txtSecondName.Text = string.Empty;
            txtThirdName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;            
        }

        private bool _HandelerImagePath()
        {
            if (_Person.imagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.imagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.imagePath);
                    }
                    catch (IOException ex)
                    {

                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    string sourceImageToFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtile.CopyImageToProjectImageFolder(ref sourceImageToFile))
                    {
                        pbPersonImage.ImageLocation = sourceImageToFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("The Iamge Not Added", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCounries = clsCountries.getAllCountries();

            foreach (DataRow row in dtCounries.Rows)
            {
                cmbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _loadDataToObject()
        {
            _Person.firstName = txtFirstName.Text;
            _Person.secondName = txtSecondName.Text;
            _Person.thirdName = txtThirdName.Text;
            _Person.lastName = txtLastName.Text;
            _Person.nationalNo = txtNationalNo.Text;
            _Person.dateOfBirth = dtpDateOfBirth.Value;
            if(rbMale.Checked)
            {
                _Person.gendor = (short)enGendor.Male;
            }
            else if(rbFemale.Checked)
            {
                _Person.gendor = (short)enGendor.Female;
            }
            _Person.phone = txtPhone.Text;
            _Person.email = txtEmail.Text;
            _Person.countryID = cmbCountry.SelectedIndex + 1;
            _Person.address = txtAddress.Text;
            _Person.imagePath = pbPersonImage.ImageLocation ?? "";
        }

        private void _loadPersonInfoToForm()
        {
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            _FillCountriesInComoboBox();
            cmbCountry.SelectedIndex = cmbCountry.FindString("Syria");
            
            lblPersonID.Text = _Person.personID.ToString();
            txtFirstName.Text = _Person.firstName.ToString();
            txtSecondName.Text = _Person.secondName.ToString();
            txtThirdName.Text = _Person.thirdName.ToString();
            txtLastName.Text = _Person.lastName.ToString();
            txtNationalNo.Text = _Person.nationalNo.ToString();
            txtPhone.Text = _Person.phone.ToString();
            txtEmail.Text = _Person.email.ToString();
            txtAddress.Text = _Person.address.ToString();
            dtpDateOfBirth.Value = _Person.dateOfBirth;
            cmbCountry.SelectedIndex = cmbCountry.FindString(_Person.countryInfo.CountryName);
            if(_Person.gendor == (short)enGendor.Male)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            if(_Person.imagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.imagePath;
                llblRemove.Visible = true;
            }
            else
            {
                if(_Person.gendor == 0)
                {
                    rbMale.Checked = true;
                    pbPersonImage.InitialImage = Resources.personbody72;
                }
                else
                {
                    rbFemale.Checked = true;
                    pbPersonImage.InitialImage = Resources.person_girl72;
                }
                llblRemove.Visible = false;
                pbPersonImage.Image = pbPersonImage.InitialImage;
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (Mode == enMode.UpdateMode)
                _loadPersonInfoToForm();

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.Image == null)
            {
                pbPersonImage.Image = Resources.personbody72;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.Image == null)
            {
                pbPersonImage.Image = Resources.person_girl72;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are Value is not Validate");
                return;
            }

            if (!_HandelerImagePath())
                return;

            _loadDataToObject();
            if(_Person.Save())
            {
                _PersonID = _Person.personID;
                lblTitle.Text = "Update Person";
                lblPersonID.Text = _Person.personID.ToString();
                Mode = enMode.UpdateMode;
                MessageBox.Show($"Successful Save Person With PersonId : {_Person.personID}");
                DataBack?.Invoke(sender, _Person.personID);
            }
            else
            {
                MessageBox.Show($"Faild Save Person With PersonId : {_Person.personID}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBack?.Invoke(this, this._Person.personID);
        }

        private void TextBoxEmpty_Validate(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if(string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, "This Field is required");
            }
            else
            {
                errorProvider.SetError(textBox, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if(!Validation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider.SetError(txtEmail, "This is Not Email");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtEmail, null);
            }

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider.SetError(txtNationalNo, "This field is required");
                return;
            }
            else
            {
                errorProvider.SetError(txtNationalNo, null);
            }

            if (txtNationalNo.Text.Trim() != _Person.nationalNo && clsPerson.isExist(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider.SetError(txtNationalNo, "There are NationalNo is Found");
            }
            else
            {
                errorProvider.SetError(txtNationalNo, null);
            }

        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.Filter = "(*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                string sourceFile = openFileDialog.FileName;
                pbPersonImage.Load(sourceFile);
                llblRemove.Visible = true;
            }

        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = pbPersonImage.InitialImage;
            pbPersonImage.ImageLocation = null;
            llblRemove.Visible = false;
        }

    }
}
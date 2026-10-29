using DVLD.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlPersonCard : UserControl
    {
        enum enGendor { Male = 0,Female = 1}
        enGendor Gendor;

        private int _personID = -1;

        private clsPerson _person;

        public int personID { get { return this._personID; } }

        public clsPerson SelectedPerson { get { return this._person; } }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _loadImage()
        {

            if (_person.gendor == 0)
            {
                pbGendor.InitialImage = Resources.personbody72;
            }
            else
            {
                pbGendor.InitialImage = Resources.person_girl72;
            }
            pbPersonImage.Image = pbGendor.InitialImage;

            string ImagePath = _person.imagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = _person.imagePath;
                else
                    MessageBox.Show($"This Image With File {ImagePath} is not Exist", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pbGendor.Image = pbGendor.InitialImage;
        }

        private void _FillPersonInfo()
        {
            llbEditPerson.Enabled = true;
            _personID = _person.personID;
            lblPersonID.Text = _person.personID.ToString();
            lblPersonID.Text = _person.personID.ToString();
            lblName.Text = _person.fullName.ToString();
            lblNationalNO.Text = _person.nationalNo.ToString();
            lblPhone.Text = _person.phone.ToString();
            lblEmail.Text = _person.email.ToString();
            lblAddress.Text = _person.address.ToString();
            lblDateOfBirth.Text = _person.dateOfBirth.ToString();
            lblCountry.Text = clsCountries.Find(_person.countryID).CountryName;
            Gendor = (enGendor)_person.gendor;
            lblGendor.Text = Gendor.ToString();

            _loadImage();
        }

        public void loadPersonInfoToForm(int PersonID)
        {
            _person = clsPerson.Find(PersonID);
            if (_person == null)
            {
                resetPersonInfo();
                MessageBox.Show($"This Person With ID {PersonID} is Not Exists");
                return;
            }

            _FillPersonInfo();
        }

        public void loadPersonInfoToForm(string NationalNo)
        {
            _person = clsPerson.Find(NationalNo);
            if (_person == null)
            {
                resetPersonInfo();
                MessageBox.Show($"This Person With ID {NationalNo} is Not Exists");
                return;
            }

            _FillPersonInfo();
        }

        public void resetPersonInfo()
        {
            _person = null;
            _personID = -1;
            lblPersonID.Text = "N/A";
            lblName.Text = "N/A";
            lblNationalNO.Text = "N/A";
            lblPhone.Text = "N/A";
            lblEmail.Text = "N/A";
            lblAddress.Text = "N/A";
            lblDateOfBirth.Text = "N/A";
            lblCountry.Text = "N/A";
            lblGendor.Text = "N/A";
            pbPersonImage.Image = pbPersonImage.InitialImage;
            pbGendor.Image = pbGendor.InitialImage;
            llbEditPerson.Enabled = false;
        }

        private void llbEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frmUpdate = new frmAddUpdatePerson(_person.personID);

            frmUpdate.DataBack += frmAddUpdatePerson_DataBack;

            frmUpdate.ShowDialog();
        }

        private void frmAddUpdatePerson_DataBack(object sender, int personID)
        {
            loadPersonInfoToForm(personID);
        }
    }
}

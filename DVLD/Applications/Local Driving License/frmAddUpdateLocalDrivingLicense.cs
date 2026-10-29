using DVLD.Controls;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicense : Form
    {
        enum enMode { AddMode = 1, UpdateMode = 2 }
        enMode Mode;

        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicense()
        {
            InitializeComponent();
            Mode = enMode.AddMode;
        }

        public frmAddUpdateLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            Mode = enMode.UpdateMode;
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClass = clsLicenceClass.getAllLicenseClass();

            foreach (DataRow row in dtLicenseClass.Rows)
            {
                cmbLicenseClass.Items.Add(row["ClassName"]);
            }
            cmbLicenseClass.SelectedIndex = 2;
        }
        
        private void _ResetDefualtValues()
        {
            _FillLicenseClassesInComoboBox();

            if (Mode == enMode.AddMode)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrPersonCardWithFilter1.FocusFilter();
                tpApplicationInfo.Enabled = false;

                cmbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsAplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUserName.Text = clsGlobal.currentUser.userName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }

        }

        private void _LoadData()
        {

            ctrPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrPersonCardWithFilter1.loadPersonData(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cmbLicenseClass.SelectedIndex = cmbLicenseClass.FindString(clsLicenceClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).className);
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblDLApplicationID.Text = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID).userName;

        }

        private void frmAddUpdateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (Mode == enMode.UpdateMode)
            {
                _LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.UpdateMode)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tbctrlApplicationAddUpdate.SelectedTab = tbctrlApplicationAddUpdate.TabPages["tpApplicationInfo"];
                return;
            }

            if (ctrPersonCardWithFilter1.personID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tbctrlApplicationAddUpdate.SelectedTab = tbctrlApplicationAddUpdate.TabPages["tpApplicationInfo"];
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonCardWithFilter1.FocusFilter();
            }
        }

        private void btnPrevios_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                return;
            tbctrlApplicationAddUpdate.SelectedTab = tbctrlApplicationAddUpdate.TabPages["tpPersonInfo"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenceClass.Find(cmbLicenseClass.Text).id;


            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLicenseClass.Focus();
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(ctrPersonCardWithFilter1.personID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrPersonCardWithFilter1.personID; ;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.currentUser.userID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {
                lblDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                Mode = enMode.UpdateMode;
                lblTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ctrPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmAddUpdateLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrPersonCardWithFilter1.FocusFilter();
        }
    }
}

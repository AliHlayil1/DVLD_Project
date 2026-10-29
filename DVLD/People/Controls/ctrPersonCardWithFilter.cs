using DVLD;
using DVLDBusinessLayer;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int personID)
        {
            Action<int> handler = OnPersonSelected;
            if(handler != null)
            {
                handler(personID);
            }

        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbxFilter.Enabled = _FilterEnabled;
            }
        }

        public int personID { get { return ctrlPersonCard1.personID; } }

        public clsPerson person { get { return ctrlPersonCard1.SelectedPerson; } }

        public ctrPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cmbFiltter.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        public void loadPersonData(int personID)
        {

            cmbFiltter.SelectedIndex = 0;
            txtFilterValue.Text = personID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch(cmbFiltter.Text)
            {
                case "Person ID":
                    int id;
                    if(!int.TryParse(txtFilterValue.Text, out id))
                    {
                        id = -1;
                    }
                    ctrlPersonCard1.loadPersonInfoToForm(id);
                    break;
                case "NationalNO.":
                    ctrlPersonCard1.loadPersonInfoToForm(txtFilterValue.Text);
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                OnPersonSelected(ctrlPersonCard1.personID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are Validate in Filter");
                ctrlPersonCard1.Enabled = false;
                return;
            }

            FindNow();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddPersonScreen = new frmAddUpdatePerson();

            AddPersonScreen.DataBack += frmAddUpdatePerson_DataBack;

            AddPersonScreen.ShowDialog();
        }

        private void frmAddUpdatePerson_DataBack(object sender, int personID)
        {

            cmbFiltter.SelectedIndex = 1;
            txtFilterValue.Text = personID.ToString();
            ctrlPersonCard1.loadPersonInfoToForm(personID);
        }

        private void cmbFiltter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = string.Empty;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();

            if (cmbFiltter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void FocusFilter()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterValue.Text))
            {
                errorProvider.SetError(txtFilterValue, "This field is required");
            }
            else
            {
                errorProvider.SetError(txtFilterValue, null);
            }
        }

    }
}

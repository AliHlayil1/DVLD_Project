using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmPeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.getAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName","SecondName","ThirdName"
                                                                            ,"LastName","DateOfBirth","GendorCaption","Address","Phone","Email"
                                                                            ,"CountryName");

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.getAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName"
                                                                            , "LastName", "DateOfBirth", "GendorCaption", "Address", "Phone", "Email"
                                                                            , "CountryName");

            dgvPeople.DataSource = _dtPeople;
            lblRecordNumber.Text = dgvPeople.Rows.Count.ToString();
            _dgvEditSettings();
        }

        public frmPeople()
        {
            InitializeComponent();
        }

        private void _dgvEditSettings()
        {
            dgvPeople.ClearSelection();
            dgvPeople.AllowUserToAddRows = false;
            for (int i = 0; i < dgvPeople.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvPeople.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }
            }
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _dtPeople;

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "ID";
                dgvPeople.Columns[0].Width = 50;

                dgvPeople.Columns[1].HeaderText = "NationalNo";
                dgvPeople.Columns[1].Width = 75;

                dgvPeople.Columns[2].HeaderText = "First";
                dgvPeople.Columns[2].Width = 90;

                dgvPeople.Columns[3].HeaderText = "Seconde";
                dgvPeople.Columns[3].Width = 90;

                dgvPeople.Columns[4].HeaderText = "Third";
                dgvPeople.Columns[4].Width = 90;

                dgvPeople.Columns[5].HeaderText = "Last";
                dgvPeople.Columns[5].Width = 90;

                dgvPeople.Columns[6].HeaderText = "Birth";
                dgvPeople.Columns[6].Width = 75;

                dgvPeople.Columns[7].HeaderText = "Gendor";
                dgvPeople.Columns[7].Width = 75;

                dgvPeople.Columns[8].HeaderText = "Address";
                dgvPeople.Columns[8].Width = 120;

                dgvPeople.Columns[9].HeaderText = "phone";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 120;

                dgvPeople.Columns[11].HeaderText = "Nationality";
                dgvPeople.Columns[11].Width = 120;
            }

            lblRecordNumber.Text = dgvPeople.Rows.Count.ToString();
            _dgvEditSettings();
            cmbFiltter.SelectedIndex = 0;
        }

        private void showDetailsTSMI_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(dgvPeople.CurrentRow.Cells[0].Value.ToString());
            frmPersonInformation personInfoScreen = new frmPersonInformation(personID);

            personInfoScreen.DataBack += frmAddUpdatePerson_DataBack;

            personInfoScreen.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddPerson_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(dgvPeople.CurrentRow.Cells[0].Value.ToString());
            frmAddUpdatePerson AddUpdateScreen = new frmAddUpdatePerson(personID);

            AddUpdateScreen.DataBack += frmAddUpdatePerson_DataBack;

            AddUpdateScreen.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Do you want delete this person with ID {int.Parse(dgvPeople.CurrentRow.Cells[0].Value.ToString())} ", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            string imagePath = clsPerson.Find(int.Parse(dgvPeople.CurrentRow.Cells[0].Value.ToString())).imagePath;
            if (!string.IsNullOrEmpty(imagePath))
            {
                File.Delete(imagePath);
            }
            if (clsPerson.Delete(int.Parse(dgvPeople.CurrentRow.Cells[0].Value.ToString())))
            {
                MessageBox.Show($"person with personID {int.Parse(dgvPeople.CurrentRow.Cells[0].Value.ToString())} deleted");
                _RefreshPeopleList();
            }
            else
            {
                MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This featur not Exists it's added in soon");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This featur not Exists it's added in soon");
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddUpdateScreen = new frmAddUpdatePerson();

            AddUpdateScreen.DataBack +=frmAddUpdatePerson_DataBack;

            AddUpdateScreen.ShowDialog();
        }

        private void frmAddUpdatePerson_DataBack(object sender, int PersonID)
        {
            _RefreshPeopleList();
        }

        private void cmbFiltter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cmbFiltter.Text != "None");

            if(txtFilterValue.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }

            if(cmbFiltter.Text == "None")
            {
                _RefreshPeopleList();
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumnName = string.Empty;

            switch (cmbFiltter.Text)
            {
                case "Person ID":
                    FilterColumnName = "PersonID";
                    break;
                case "NationalNO.":
                    FilterColumnName = "NationalNo";
                    break;
                case "First Name":
                    FilterColumnName = "FirstName";
                    break;
                case "Second Name":
                    FilterColumnName = "SecondName";
                    break;
                case "Third Name":
                    FilterColumnName = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumnName = "LastName";
                    break;
                case "Nationality":
                    FilterColumnName = "CountryName";
                    break;
                case "Gendor":
                    FilterColumnName = "GendorCaption";
                    break;
                case "Phone":
                    FilterColumnName = "Phone";
                    break;
                case "Email":
                    FilterColumnName = "Email";
                    break;
                default:
                    FilterColumnName = "";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || cmbFiltter.Text == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordNumber.Text = dgvPeople.Rows.Count.ToString();
                _dgvEditSettings();
                return;
            }

            if (FilterColumnName == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumnName, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumnName, txtFilterValue.Text.Trim());

            lblRecordNumber.Text = dgvPeople.Rows.Count.ToString();
            _dgvEditSettings();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbFiltter.Text == "Person ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }
    }
}

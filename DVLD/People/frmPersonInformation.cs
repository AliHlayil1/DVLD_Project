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
    public partial class frmPersonInformation : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public DataBackEventHandler DataBack;

        public frmPersonInformation(int personID)
        {
            InitializeComponent();
            ctrlPersonCard1.loadPersonInfoToForm(personID);
        }

        public frmPersonInformation(string nationalNo)
        {
            InitializeComponent();
            ctrlPersonCard1.loadPersonInfoToForm(nationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlPersonCard1.personID);
            this.Close();
        }

    }
}

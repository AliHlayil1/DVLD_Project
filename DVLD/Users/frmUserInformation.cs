using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmUserInformation : Form
    {
        int _userID = -1;

        public frmUserInformation(int userID)
        {
            InitializeComponent();
            this._userID = userID;
        }

        private void frmUserInformation_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadInfornationToControl(this._userID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

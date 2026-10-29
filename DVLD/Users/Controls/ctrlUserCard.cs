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

namespace DVLD.User.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private int _userID = -1;
        
        private clsUser _user;

        public int UserID { get { return this._userID; } }

        public clsUser User { get { return this._user; } }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _FillInformationToControl()
        {
            _userID = _user.userID;
            lblUserID.Text = _user.userID.ToString();
            ctrlPersonCard1.loadPersonInfoToForm(_user.personID);
            lblUserName.Text = _user.userName.ToString();
            lblIsActive.Text = _user.isActive.ToString();
        }

        public void LoadInfornationToControl(int userID)
        {
            _user = clsUser.Find(userID);
            if (_user == null)
            {
                resetUserControl();
                _userID = -1;
                return;
            }
            _FillInformationToControl();
        }

        public void resetUserControl()
        {
            string initialValue = "[N/A]";
            _userID = -1;
            lblUserID.Text = initialValue;
            ctrlPersonCard1.resetPersonInfo();
            lblUserName.Text = initialValue;
            lblIsActive.Text = initialValue;
        }

    }
}

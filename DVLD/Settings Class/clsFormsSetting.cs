using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal class clsFormsSetting
    {
        enum enMode { OpenMode = 1, CloseMode = 2 }
        enMode Mode;

        public Form currentForm {  get; set; }
        private Panel containerPanel { get; set; }

        public clsFormsSetting(Panel containerPanel)
        {
            this.containerPanel = containerPanel;
            this.currentForm = null;
            Mode = enMode.CloseMode;
        }

        public void OpenForm()
        {
            if (this.currentForm == null)
                return;
            if(this.containerPanel.Controls.Count >0)
            {
                this.containerPanel.Controls.Clear();
            }

            currentForm.Width = containerPanel.Width;
            currentForm.Height = containerPanel.Height;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.TopMost = false;
            currentForm.TopLevel = false;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            containerPanel.Controls.Add(currentForm);
            Mode = enMode.OpenMode;
        }

        public void CloseForm()
        {
            containerPanel.Controls.Clear();
            currentForm = null;
            Mode = enMode.CloseMode;
        }

        public bool isOpen()
        {
            return (Mode == enMode.OpenMode);
        }

    }
}

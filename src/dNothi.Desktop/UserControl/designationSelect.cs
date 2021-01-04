using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI;

namespace dNothi.Desktop
{
    public partial class designationSelect : UserControl
    {
        public designationSelect()
        {
            InitializeComponent();
        }
        private string _designationLinkText;
        private int _dakTotalNumber;
        private int _nothiTotalNumber;

        public string designationLinkText
        {
            get
            {
                return _designationLinkText;
            }
            set
            {
                _designationLinkText = value;
                linkLabel.Text = value;
            }
        }

        public int dakTotalNumber
        {
            get
            {
                return _dakTotalNumber;
            }
            set
            {
                _dakTotalNumber = value;
                dakCountButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')))+ " টি ডাক";
            }
        }
        public int nothiTotalNumber
        {
            get
            {
                return _nothiTotalNumber;
            }
            set
            {
                _nothiTotalNumber = value;
                nothiCountButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + " টি নথি";
            }
        }




        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler LogoutButtonClick;
        private void btnLogout_Click(object sender, EventArgs e)
        {

            if (this.LogoutButtonClick != null)
                this.LogoutButtonClick(sender, e);
        }
    }
}
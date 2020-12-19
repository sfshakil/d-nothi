using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class MovementStatusDetailsUserControl : UserControl
    {
        public MovementStatusDetailsUserControl()
        {
            InitializeComponent();
        }
        private string _userType;
        private string _userDesignation;
        private string _userName;

        public string userType
        {
            get { return _userType; }
            set { _userType = value; if (value == null) { userTypeLabel.Visible = false; } else { userTypeLabel.Text = value; } }
        }
        
        public string userName
        {
            get { return _userName; }
            set { _userName = value; if (value == null) { userNameLabel.Visible = false; } else { userNameLabel.Text = value; } }
        }

      

        public string userDesignation
        {
            get { return _userDesignation; }
            set { _userDesignation = value;  userDesignationLabel.Text = value;}
        }

        private void userDesignationLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

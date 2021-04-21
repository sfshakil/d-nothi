using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraPrapokListRowUserControl : UserControl
    {
        public KhosraPrapokListRowUserControl()
        {
            InitializeComponent();
        }

        public string _UserName { get; set; }
        public string UserName { get {return _UserName ; } set { _UserName = value ; userNameLabel.Text = value; } }

        public string _UserType { get; set; }
        public string UserType { get { return _UserType; } set { _UserType = value; userTypeLabel.Text = value; userTypeLabel.Visible = true; } }

        public string _UserDesignation { get; set; }
        public string UserDesignation { get { return _UserDesignation; } set { _UserDesignation = value; userDesignationLabel.Text = value; } }


        public string _UserOfficeName { get; set; }
        public string UserOfficeName { get { return _UserOfficeName; } set { _UserOfficeName = value; userOfficeLabel.Text = value; } }

    }
}

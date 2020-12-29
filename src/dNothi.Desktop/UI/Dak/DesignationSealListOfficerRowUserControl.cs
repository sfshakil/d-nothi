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
    public partial class DesignationSealListOfficerRowUserControl : UserControl
    {
        private string _officeName;
        public DesignationSealListOfficerRowUserControl()
        {
            InitializeComponent();
        }


        public string officerName
        {
            get { return _officeName; }
            set
            {
                _officeName = value;
                officerNameLabel.Text = value;
            }

        }
    }
}

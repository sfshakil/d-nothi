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
    public partial class DesignationSealBranchRowUserControl : UserControl
    {
        private string _branchofficeName;
        private string[] _officerName;
        public DesignationSealBranchRowUserControl()
        {
            InitializeComponent();
        }


        public string branchOfficeName { get { return _branchofficeName; } set { _branchofficeName = value; branchNameLabel.Text = value; } }

        public string[] officerName { get { return _officerName; }
            set { 
                _officerName = officerName;
                foreach(string s in value)
                {
                    DesignationSealListOfficerRowUserControl designationSealListOfficerRowUserControl = new DesignationSealListOfficerRowUserControl();
                    designationSealListOfficerRowUserControl.officerName = s;
                    branchOfficeFlowLayoutPanel.Controls.Add(designationSealListOfficerRowUserControl);
                }
            
            }
        
        }

    }
}

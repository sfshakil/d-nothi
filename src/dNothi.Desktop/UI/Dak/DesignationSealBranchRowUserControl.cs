using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DesignationSealBranchRowUserControl : UserControl
    {
        private string _branchofficeName;


        private List<PrapokDTO> _prapokdtos;
            
            
        public int _unitid { get; set; }
        public string _unitCode { get; set; }
 
        public DesignationSealBranchRowUserControl()
        {
            InitializeComponent();
        }

        public string unitCode { get { return _unitCode; } set { _unitCode = value; } }
        public int unitId { get { return _unitid; } set { _unitid = value; } }

        public string branchOfficeName { get { return _branchofficeName; } set { _branchofficeName = value; branchNameLabel.Text = value; } }

        public List<PrapokDTO> prapokDtos
        { get { return _prapokdtos; }
            set {
                _prapokdtos = value;
                foreach(PrapokDTO prapokDTO in value)
                {
                    DesignationSealListOfficerRowUserControl designationSealListOfficerRowUserControl = new DesignationSealListOfficerRowUserControl();
                    designationSealListOfficerRowUserControl.officerName = prapokDTO.NameWithOrganogram;
                    designationSealListOfficerRowUserControl.designationid = prapokDTO.designation_id;
                    designationSealListOfficerRowUserControl.isNewlyAdded = false;
                    //designationSealListOfficerRowUserControl.Visible = false;

                    branchOfficeFlowLayoutPanel.Controls.Add(designationSealListOfficerRowUserControl);
                    break;
                }
            
            }
        
        }

    }
}

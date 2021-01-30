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
        private List<PrapokDTO> _designationListAlreadyAdded;


         
        
            
        public int _unitid { get; set; }
        public int _designationid { get; set; }
        public string _unitCode { get; set; }

        //public int designationid

       public bool isAnyDesignationNewlyAdded = false;



        public int designationid { set {

                var designationList = branchOfficeFlowLayoutPanel.Controls.OfType<DesignationSealListOfficerRowUserControl>().ToList();

                foreach (var designation in designationList)
                {
                    if (designation.designationid == value)
                    {
                        designation.Visible = true;
                        designation.isNewlyAdded = true;
                        //isAnyDesignationNewlyAdded = true;
                    }
                    
                }

            } }


        public DesignationSealBranchRowUserControl()
        {
            InitializeComponent();
        }
        public string unitCode { get { return _unitCode; } set { _unitCode = value; } }
        public List<PrapokDTO> designationListAlreadyAdded { get { return _designationListAlreadyAdded; } set { _designationListAlreadyAdded = value; } }
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
                    designationSealListOfficerRowUserControl.DeleteButton += delegate (object sender, EventArgs e) { DesignationDelete_ButtonClick(sender, e, designationSealListOfficerRowUserControl.designationid); };

                  if(prapokDTO.isofficerAdded==true)
                    {
                        designationSealListOfficerRowUserControl.Visible = true;
                        designationSealListOfficerRowUserControl.isNewlyAdded = true;

                    }
                  else if(_designationListAlreadyAdded.Any(a => a.designation_id == prapokDTO.designation_id))
                    {
                        designationSealListOfficerRowUserControl.Visible = true;
                        if(!this.Visible)
                        {
                            this.Visible=true;
                        }
                    }
                    
                    else
                    {
                        designationSealListOfficerRowUserControl.Visible = false;
                    }

                    branchOfficeFlowLayoutPanel.Controls.Add(designationSealListOfficerRowUserControl);
                   
                }
            
            }
        
        }
        public event EventHandler DesignationDeleteButton;
        private void DesignationDelete_ButtonClick(object sender, EventArgs e, int designationid)
        {
            _designationid = designationid;
            var designationList = branchOfficeFlowLayoutPanel.Controls.OfType<DesignationSealListOfficerRowUserControl>().ToList();
             isAnyDesignationNewlyAdded = false;
            foreach (var designation in designationList)
            {
                if (designation.designationid == designationid)
                {
                    designation.Visible = false;
                }
               if(designation.designationid!=designationid && designation.Visible)
                {
                    isAnyDesignationNewlyAdded = true;
                }
            }

            if (this.DesignationDeleteButton != null)
                this.DesignationDeleteButton(sender, e);


        }
    }
}

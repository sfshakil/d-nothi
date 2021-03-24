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
using dNothi.Core.Entities;
using dNothi.JsonParser.Entity;

namespace dNothi.Desktop
{
    public partial class designationSelect : UserControl
    {
        public EmployeDakNothiCountResponse _employeDakNothiCountResponse = new EmployeDakNothiCountResponse();
        public EmployeDakNothiCountResponse employeDakNothiCountResponse { get { return _employeDakNothiCountResponse; } set { _employeDakNothiCountResponse = value; } }



        public designationSelect()
        {
            InitializeComponent();
        }

        
        public int _designationId { get; set; }


        public List<OfficeInfoDTO> _officeInfos { get; set; }

        public List<OfficeInfoDTO> officeInfos {
            get { return _officeInfos; }
            set
            {
                _officeInfos = value;
                designationRowFlowLayoutPanel.Controls.Clear();
                if(value != null)
                {
                    foreach (var officeInfo in officeInfos)
                    {
                        DesignationRow designationRow = new DesignationRow();
                        designationRow.designationId = officeInfo.office_unit_organogram_id;
                        designationRow.designationLinkText = officeInfo.designation + "," + officeInfo.unit_name_bn + "," + officeInfo.office_name_bn;
                        designationRow.User += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUserClick(changeButtonSender, changeButtonEvent, designationRow._designationId); };
                        var employeDakNothiCountResponseTotal = _employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == designationRow.designationId.ToString());


                        designationRow.dakTotalNumber = employeDakNothiCountResponseTotal.Value.dak;
                        designationRow.nothiTotalNumber = employeDakNothiCountResponseTotal.Value.own_office_nothi;

                        designationRowFlowLayoutPanel.Controls.Add(designationRow);

                    }
                }
            }
             

            }


        public event EventHandler ChangeUserClick;
        private void ChageUserClick(object changeButtonSender, EventArgs changeButtonEvent, int designationId)
        {
            _designationId = designationId;

            if (this.ChangeUserClick != null)
                this.ChangeUserClick(changeButtonSender, changeButtonEvent);
        }

      

     

        private void DakInboxUserControl_Click(object sender, EventArgs e)
        {


           
        }


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler LogoutButtonClick;

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //this.Hide();
            foreach (Form f in Application.OpenForms)
            { f.Hide(); }
            var form = FormFactory.Create<Login>();
            form.ShowDialog();
        }
    }
}
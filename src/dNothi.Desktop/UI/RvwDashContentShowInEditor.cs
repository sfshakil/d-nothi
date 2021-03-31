using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class RvwDashContentShowInEditor : Form
    {
        public RvwDashContentShowInEditor(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            khosraViewWebBrowser.Url = new Uri("https://www.google.com/");
        }

        IUserService _userService { get; set; }
        designationSelect designationDetailsPanelNothi = new designationSelect();
        private void profilePanel_Click(object sender, EventArgs e)
        {
            
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Visible = true;
                //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
        
        }
    }
}

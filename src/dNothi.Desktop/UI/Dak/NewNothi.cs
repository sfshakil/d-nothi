using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NewNothi : UserControl
    {
        public NewNothi()
        {
            InitializeComponent();
        }
        private void btnGuidelines_Click(object sender, EventArgs e)
        {
            NothiGuidelines nothiGuidelines = new NothiGuidelines();
            nothiGuidelines.Visible = true;
            nothiGuidelines.Location = new System.Drawing.Point(0,0);
            Controls.Add(nothiGuidelines);
            nothiGuidelines.BringToFront();
        }

        private void btnNothiTypeList_Click(object sender, EventArgs e)
        {
            //var nothiType = UserControlFactory.Create<NothiType>();
            //nothiType.Visible = true;
            //nothiType.Location = new System.Drawing.Point(550, 0);
            //Controls.Add(nothiType);
            //nothiType.BringToFront();
        }
    }
}

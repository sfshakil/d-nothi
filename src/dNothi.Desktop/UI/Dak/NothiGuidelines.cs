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
    public partial class NothiGuidelines : UserControl
    {
        public NothiGuidelines()
        {
            InitializeComponent();
            flpNothiGuidelines.AutoScroll = true;
            flpNothiGuidelines.FlowDirection = FlowDirection.TopDown;
            flpNothiGuidelines.WrapContents = false;
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            NewNothi newNothi = new NewNothi();
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(0,0);
            Controls.Add(newNothi);
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;

        }
    }
}

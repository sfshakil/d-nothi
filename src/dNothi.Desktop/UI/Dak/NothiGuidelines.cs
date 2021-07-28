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
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Nothi")
                    f.Close();
            }
            //foreach (Form f in Application.OpenForms)
            //{ BeginInvoke((Action)(() => f.Hide())); }
            //var form = FormFactory.Create<Nothi>();
            //form.forceLoadNewNothi();
            //BeginInvoke((Action)(() => form.ShowDialog()));

        }
    }
}

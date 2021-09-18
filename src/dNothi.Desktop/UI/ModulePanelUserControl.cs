using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.OtherModule;
using dNothi.Desktop.UI.PotroJariGroups;

namespace dNothi.Desktop.UI
{
    public partial class ModulePanelUserControl : UserControl
    {
        public ModulePanelUserControl()
        {
            InitializeComponent();
        }

        private void khosraPotroButton_Click(object sender, EventArgs e)
        {
            //this.Parent.Hide();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            KhosraDashboard khosraDashboard = FormFactory.Create<KhosraDashboard>();
            khosraDashboard.TopMost = true;
            BeginInvoke((Action)(() => khosraDashboard.ShowDialog()));
            BeginInvoke((Action)(() => khosraDashboard.TopMost = false));
            khosraDashboard.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void khosraButton_Click(object sender, EventArgs e)
        {

            UIDesignCommonMethod.returnForm = this.Parent.FindForm();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            var khosra = FormFactory.Create<Khosra>();
            khosra.TopMost = true;
            BeginInvoke((Action)(() => khosra.ShowDialog()));
            BeginInvoke((Action)(() => khosra.TopMost = false));
            khosra.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void reviewDashBoardButton_Click(object sender, EventArgs e)
        {
            //this.Parent.Hide();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            ReviewDashBoard reviewDashBoard = FormFactory.Create<ReviewDashBoard>();
            reviewDashBoard.TopMost = true;
            BeginInvoke((Action)(() => reviewDashBoard.ShowDialog()));
            BeginInvoke((Action)(() => reviewDashBoard.TopMost = false));
            reviewDashBoard.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void guardFileModuleButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            var gurdFileControl = FormFactory.Create<GurdFileControl>();
            gurdFileControl.TopMost = true;
            BeginInvoke((Action)(() => gurdFileControl.ShowDialog()));
            BeginInvoke((Action)(() => gurdFileControl.TopMost = false));
            gurdFileControl.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void potrojariButton_Click(object sender, EventArgs e)
        {
            //this.Parent.Hide();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
           
            PotrojariGroupForm potrojariGroup = FormFactory.Create<PotrojariGroupForm>();
            potrojariGroup.TopMost = true;
            BeginInvoke((Action)(() => potrojariGroup.ShowDialog()));
            BeginInvoke((Action)(() => potrojariGroup.TopMost = false));
            potrojariGroup.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
    }
}

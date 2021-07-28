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
            BeginInvoke((Action)(() => khosraDashboard.ShowDialog()));
            khosraDashboard.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void khosraButton_Click(object sender, EventArgs e)
        {

            UIDesignCommonMethod.returnForm = this.Parent.FindForm();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            var form = FormFactory.Create<Khosra>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
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
            BeginInvoke((Action)(() => reviewDashBoard.ShowDialog()));
            reviewDashBoard.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void guardFileModuleButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            var gurdFileControl = FormFactory.Create<GurdFileControl>();
            BeginInvoke((Action)(() => gurdFileControl.ShowDialog()));
            gurdFileControl.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void potrojariButton_Click(object sender, EventArgs e)
        {
            //this.Parent.Hide();
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
           
            PotrojariGroupForm potrojariGroup = FormFactory.Create<PotrojariGroupForm>();
           
            BeginInvoke((Action)(() => potrojariGroup.ShowDialog()));
            potrojariGroup.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
    }
}

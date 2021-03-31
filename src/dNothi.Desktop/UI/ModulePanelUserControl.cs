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
            this.Parent.Hide();
            KhosraDashboard khosraDashboard = FormFactory.Create<KhosraDashboard>();
            khosraDashboard.ShowDialog();
        }

        private void khosraButton_Click(object sender, EventArgs e)
        {
            
            var form = FormFactory.Create<Khosra>();
            form.ShowDialog();

            this.Hide();
        }

        private void reviewDashBoardButton_Click(object sender, EventArgs e)
        {
            this.Parent.Hide();
            ReviewDashBoard reviewDashBoard = FormFactory.Create<ReviewDashBoard>();
            reviewDashBoard.ShowDialog();
        }

        private void guardFileModuleButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var gurdFileControl = FormFactory.Create<GurdFileControl>();
            gurdFileControl.ShowDialog();
        }

        private void potrojariButton_Click(object sender, EventArgs e)
        {
            this.Parent.Hide();
            PotrojariGroup potrojariGroup = FormFactory.Create<PotrojariGroup>();
            potrojariGroup.ShowDialog();
        }
    }
}

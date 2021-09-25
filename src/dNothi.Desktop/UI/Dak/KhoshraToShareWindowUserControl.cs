using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class KhoshraToShareWindowUserControl : UserControl
    {
        public KhoshraToShareWindowUserControl()
        {
            InitializeComponent();
        }

        private void reviewDashboardButton_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            ReviewDashBoard reviewDashBoard = FormFactory.Create<ReviewDashBoard>();
            reviewDashBoard.TopMost = true;
            BeginInvoke((Action)(() => reviewDashBoard.ShowDialog()));
            BeginInvoke((Action)(() => reviewDashBoard.TopMost = false));
            reviewDashBoard.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

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
    public partial class NothiCreateNextStep : Form
    {
        public NothiCreateNextStep()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ForceLoadNothiALL();
            form.ShowDialog();
        }

        private void btnYES_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<NothiOnumodonkari>();
            form.ShowDialog();
        }
    }
}

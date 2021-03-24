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
    public partial class PotrojariGroupContent : UserControl
    {
        public PotrojariGroupContent()
        {
            InitializeComponent();
        }

        private void detailsPanel_MouseHover(object sender, EventArgs e)
        {
            lbDetails.ForeColor = Color.FromArgb(78, 165, 254);
            this.BackColor = Color.FromArgb(245,245,245);
        }

        private void detailsPanel_MouseLeave(object sender, EventArgs e)
        {
            lbDetails.ForeColor = Color.FromArgb(63, 66, 84);
            this.BackColor = Color.FromArgb(250, 250, 250);
        }
        public event EventHandler PotrojariEditButtonClick;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.PotrojariEditButtonClick != null)
                this.PotrojariEditButtonClick(sender, e);
        }
    }
}

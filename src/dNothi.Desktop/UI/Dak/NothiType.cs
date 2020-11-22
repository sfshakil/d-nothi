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

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiType : UserControl
    {
        public NothiType()
        {
            InitializeComponent();

        }


        private void btnNothiTypeCross_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI;

namespace dNothi.Desktop
{
    public partial class designationSelect : UserControl
    {
        public designationSelect()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
           
            var form = FormFactory.Create<Login>();
            form.ShowDialog();
           
        }
    }
}

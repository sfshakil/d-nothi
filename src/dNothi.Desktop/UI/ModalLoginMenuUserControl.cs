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
    public partial class ModalLoginMenuUserControl : UserControl
    {
        public ModalLoginMenuUserControl()
        {
            InitializeComponent();
        }
        
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }

   
        public event EventHandler courseStartButtonClick;
        public event EventHandler courseRegisterButtonClick;
       
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void courseStartButton_Click(object sender, EventArgs e)
        {
            if (this.courseStartButtonClick != null)
                this.courseStartButtonClick(sender,e);
        }

        private void courseRegisterButton_Click(object sender, EventArgs e)
        {
            if (this.courseRegisterButtonClick != null)
                this.courseRegisterButtonClick(sender, e);
        }
    }
}

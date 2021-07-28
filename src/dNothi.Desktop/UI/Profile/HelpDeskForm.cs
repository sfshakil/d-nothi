using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Profile
{
    public partial class HelpDeskForm : Form
    {
        public HelpDeskForm()
        {
            InitializeComponent();
        }

        private void HelpDeskForm_Load(object sender, EventArgs e)
        {
            UIDesignCommonMethod.RightSideWindowSet(this);
            UIDesignCommonMethod.SetDefaultFont(this.Controls);
           
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

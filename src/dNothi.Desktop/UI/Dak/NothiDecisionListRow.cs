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
    public partial class NothiDecisionListRow : UserControl
    {
        public NothiDecisionListRow()
        {
            InitializeComponent();
        }
        private string _decisionText;

        [Category("Custom Props")]
        public string decisionText
        {
            get { return _decisionText; }
            set { _decisionText = value; lbDecisionText.Text = value; }
        }
        public event EventHandler DecisionAddButton;
        private void btnDecisionAdd_Click(object sender, EventArgs e)
        {
            if (this.DecisionAddButton != null)
                this.DecisionAddButton(lbDecisionText.Text, e);
        }
    }
}

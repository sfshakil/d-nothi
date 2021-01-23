using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.CustomMessageBox
{
    public partial class ConditonBoxForm : Form
    {
       // private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000;
                
                return cp;
            }
        }
        public ConditonBoxForm()
        {
            InitializeComponent();
        }

        public bool Yes;
        public bool No;

        public string _message { get; set; }
        public string message { get {return _message ; } set { _message = value; messageLabel.Text = value; } }

        private void yesButton_Click(object sender, EventArgs e)
        {
            Yes = true;No = false;
            this.Hide();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Yes = false; No = true;
            this.Hide();
        }
    }
}

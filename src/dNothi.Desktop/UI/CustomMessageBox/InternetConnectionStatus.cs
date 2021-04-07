using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.CustomMessageBox
{
    public partial class InternetConnectionStatus : UserControl
    {
        public InternetConnectionStatus()
        {
            InitializeComponent();
        }

        public void Online()
        {
            checkIconPictureBox.Visible = true;
            messageIconPictureBox.Visible = false;


            messageLabel.Text = "Back to the online!";
            this.BackColor = Color.FromArgb(27, 197, 189);
        }

        public void Offline()
        {
            checkIconPictureBox.Visible = false;
            messageIconPictureBox.Visible = true;


            //messageLabel.Text = "Back to the online!";
           // this.BackColor = Color.FromArgb(27, 197, 189);
        }
    }
}

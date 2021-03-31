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
    public partial class ReviewDashBoardContentShare : UserControl
    {
        public ReviewDashBoardContentShare()
        {
            InitializeComponent();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(235, 237, 243);
            panel2.BackColor = Color.FromArgb(235, 237, 243);
            label4.BackColor = Color.FromArgb(235, 237, 243);
            label5.BackColor = Color.FromArgb(235, 237, 243);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
        }

        private void ReviewDashBoardContentShare_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
    }
}

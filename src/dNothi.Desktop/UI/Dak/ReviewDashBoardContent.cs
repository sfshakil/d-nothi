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
    public partial class ReviewDashBoardContent : UserControl
    {
        public ReviewDashBoardContent()
        {
            InitializeComponent();
        }

        private void ReviewDashBoardContent_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void ReviewDashBoardContent_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            label4.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            label6.ForeColor = Color.FromArgb(78, 165, 254);

        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            label8.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            label10.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            label12.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            label14.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            btnEdit.IconColor = Color.FromArgb(246, 78, 96);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
            btnEdit.IconColor = Color.FromArgb(78, 165, 254);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            btnDelete.IconColor = Color.FromArgb(246, 78, 96);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
            btnDelete.IconColor = Color.FromArgb(78, 165, 254);
        }
    }
}

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
            rvwDashBoardContentShare.Visible = false;
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
            btnShare.IconColor = Color.FromArgb(246, 78, 96);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
            btnShare.IconColor = Color.FromArgb(78, 165, 254);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            btnShowInEditor.IconColor = Color.FromArgb(246, 78, 96);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
            btnShowInEditor.IconColor = Color.FromArgb(78, 165, 254);
        }
        
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
        public Form AttachNothiTypeListControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Location = new System.Drawing.Point(16, 32);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = form.Size;
            hideform.Opacity = .1;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        ReviewDashBoardContentShare rvwDashBoardContentShare = new ReviewDashBoardContentShare();
        private void btnShare_Click(object sender, EventArgs e)
        {
            if (rvwDashBoardContentShare.Visible)
            {
                rvwDashBoardContentShare.Visible = false;
            }
            else
            {
                Controls.Add(rvwDashBoardContentShare);
                rvwDashBoardContentShare.Location = new Point(415, 76);
                rvwDashBoardContentShare.Visible = true;
                rvwDashBoardContentShare.BringToFront();
            }
        }

        private void btnShowInEditor_Click(object sender, EventArgs e)
        {
            RvwDashContentShowInEditor rvwDashContentShowInEditor = FormFactory.Create<RvwDashContentShowInEditor>();
            rvwDashContentShowInEditor.Show();
        }
    }
}

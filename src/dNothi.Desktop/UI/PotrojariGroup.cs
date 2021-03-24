using dNothi.Desktop.UI.Dak;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class PotrojariGroup : Form
    {
        public PotrojariGroup()
        {
            InitializeComponent();
            loadpotrojariGroupContent();

        }

        private void loadpotrojariGroupContent()
        {
            newPotrojariPanel.Visible = false;
            totalPotrojariPanel.Visible = true;

            btnNewPotrojariGroup.BackColor = Color.FromArgb(27, 197, 189);
            btnNewPotrojariGroup.FlatAppearance.BorderColor = Color.FromArgb(27, 197, 189);
            btnNewPotrojariGroup.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnNewPotrojariGroup.Text = "নতুন পত্রজারি গ্রুপ";

            dakBodyFlowLayoutPanel.Controls.Clear();


            for (int j = 0; j <= 10 ; j++)
            {

                PotrojariGroupContent pgc = new PotrojariGroupContent();

                dakBodyFlowLayoutPanel.AutoScroll = true;

                pgc.Dock = DockStyle.Fill;

                int row = dakBodyFlowLayoutPanel.RowCount++;

                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                if (row == 1)
                {
                    row = dakBodyFlowLayoutPanel.RowCount++;
                    dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                }
                dakBodyFlowLayoutPanel.Controls.Add(pgc, 0, row);


            }
        }

        private void potrojariGroupButton_MouseHover(object sender, EventArgs e)
        {
            potrojariGroupButton.BackColor = Color.FromArgb(243, 246, 249);
            potrojariGroupButton.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void potrojariGroupButton_MouseLeave(object sender, EventArgs e)
        {
            potrojariGroupButton.BackColor = Color.White;
            potrojariGroupButton.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void btnNewPotrojariGroup_Click(object sender, EventArgs e)
        {
            if (newPotrojariPanel.Visible != true)
            {
                dakBodyFlowLayoutPanel.Controls.Clear();
                lbPotrojariName.Text = "পত্রজারি গ্রুপ অন্তর্ভুক্তিকরণ";
                newPotrojariPanel.Visible = true;
                totalPotrojariPanel.Visible = false;
                btnNewPotrojariGroup.BackColor = Color.FromArgb(54, 153, 255);
                btnNewPotrojariGroup.FlatAppearance.BorderColor = Color.FromArgb(54, 153, 255);
                btnNewPotrojariGroup.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
                btnNewPotrojariGroup.Text = "পত্রজারি গ্রুপ তালিকা";
            }
            else
            {
                loadpotrojariGroupContent();
            }
            
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void potrojariGroupButton_Click(object sender, EventArgs e)
        {
            loadpotrojariGroupContent();
        }
    }
}

using dNothi.Desktop.UI.Dak;
using dNothi.Services.UserServices;
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
    public partial class ReviewDashBoard : Form
    {
        public ReviewDashBoard(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            loadpotrojariGroupContent(10);
        }

        private void dakModulePanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        private void loadpotrojariGroupContent(int i)
        {

            dakBodyFlowLayoutPanel.Controls.Clear();


            for (int j = 0; j <= i; j++)
            {

                ReviewDashBoardContent pgc = new ReviewDashBoardContent();
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

        private void btnReviewByMe_Click(object sender, EventArgs e)
        {
            allButtonColorClear();
            btnReviewByMe.ForeColor = Color.FromArgb(78, 165, 254);
            btnReviewByMe.BackColor = Color.FromArgb(243, 246, 249);
            loadpotrojariGroupContent(10);
        }

        private void btnReviewToMe_Click(object sender, EventArgs e)
        {
            allButtonColorClear();
            btnReviewToMe.ForeColor = Color.FromArgb(78, 165, 254);
            btnReviewToMe.BackColor = Color.FromArgb(243, 246, 249);
            loadpotrojariGroupContent(4);
        }

        private void btnReviewRecent_Click(object sender, EventArgs e)
        {
            allButtonColorClear();
            btnReviewRecent.ForeColor = Color.FromArgb(78, 165, 254);
            btnReviewRecent.BackColor = Color.FromArgb(243, 246, 249);
            loadpotrojariGroupContent(7);
        }
        public void allButtonColorClear()
        {
            btnReviewByMe.ForeColor = Color.FromArgb(63, 66, 84);
            btnReviewByMe.BackColor = Color.White;

            btnReviewToMe.ForeColor = Color.FromArgb(63, 66, 84);
            btnReviewToMe.BackColor = Color.White;

            btnReviewRecent.ForeColor = Color.FromArgb(63, 66, 84);
            btnReviewRecent.BackColor = Color.White;
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        IUserService _userService { get; set; }
        designationSelect designationDetailsPanelNothi = new designationSelect();
        private void profilePanel_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Visible = true;
                //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
            
            }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }
    }
}

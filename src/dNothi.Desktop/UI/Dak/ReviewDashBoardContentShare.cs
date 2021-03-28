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
            loadReviewDashBoardContentShareContent(2);
        }
        private void loadReviewDashBoardContentShareContent(int i)
        {

            contentTableLayoutPanel.Controls.Clear();


            for (int j = 0; j <= i; j++)
            {

                ReviewDashBoardContentShareItem pgc = new ReviewDashBoardContentShareItem();
                contentTableLayoutPanel.AutoScroll = true;

                pgc.Dock = DockStyle.Fill;

                int row = contentTableLayoutPanel.RowCount++;

                contentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                if (row == 1)
                {
                    row = contentTableLayoutPanel.RowCount++;
                    contentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                }
                contentTableLayoutPanel.Controls.Add(pgc, 0, row);
            }
        }
    }
}

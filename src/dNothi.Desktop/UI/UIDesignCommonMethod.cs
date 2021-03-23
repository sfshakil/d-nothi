using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
   public class UIDesignCommonMethod
    {
        public static void AddRowinTable(TableLayoutPanel tableLayoutPanel, UserControl userControl)
        {

            userControl.Dock = DockStyle.Fill;

            int row = tableLayoutPanel.RowCount++;

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            if (row == 1)
            {
                row = tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            }
            tableLayoutPanel.Controls.Add(userControl, 0, row);

        }


        public static void Border_Color_Blue(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        public static void Border_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }


        public static void Border_Color_Gray(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);
        }

        public static void Border_Color_Gray(object sender, TableLayoutCellPaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);
        }
    }
}

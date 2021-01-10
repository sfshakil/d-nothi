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
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
            ScrollBar vScrollbar1 = new VScrollBar();
            vScrollbar1.Dock = DockStyle.Right;
            vScrollbar1.Scroll += (sender, e) => { panel5.VerticalScroll.Value = vScrollbar1.Value; };
            panel5.Controls.Add(vScrollbar1);
        }
        
        
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(255, 168, 0);
            btnBack.ForeColor = Color.White;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.White;
            btnBack.ForeColor = Color.FromArgb(255, 168, 0);
        }

        private void fileUploadPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
    }
}

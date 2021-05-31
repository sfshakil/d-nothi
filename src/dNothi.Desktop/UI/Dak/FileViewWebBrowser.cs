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
    public partial class FileViewWebBrowser : Form
    {
        public FileViewWebBrowser()
        {
            InitializeComponent();
            //fileWebBrowser.ScrollBarsEnabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        public void fileAddInWebBrowser(string uri, string fileName)
        {
            if (uri !="") {
                fileWebBrowser.Url = new Uri(uri);
                //int q = fileWebBrowser.Document.Body.ScrollRectangle.Height;
                lbFileName.Text = fileName;
            }
                
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

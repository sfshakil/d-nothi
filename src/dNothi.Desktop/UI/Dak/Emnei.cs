using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;

namespace dNothi.Desktop.UI.Dak
{
    public partial class Emnei : UserControl
    {
        public Emnei()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
            
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

       

        private void fileUploadPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        
        private void fileUploadPanel_Click(object sender, EventArgs e)
        {
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}

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
    public partial class SeparateOnuchhed : UserControl
    {
        private int originalWidth;
        private int originalHeight;
        public SeparateOnuchhed()
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
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

        private void btnPlusSquare_Click(object sender, EventArgs e)
        {
            if (btnPlusSquare.IconChar == FontAwesome.Sharp.IconChar.PlusSquare)
            {
                this.Height = 500 + originalHeight;
                this.Width = originalWidth;
                topPnl.Visible = true;
                middlePnl.Visible = true;
                btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
                btnPlusSquare.IconColor = Color.White;
                btnPlusSquare.BackColor = Color.FromArgb(27, 197, 189);
                //loadnewAllNoteFlowLayoutPanel();
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                topPnl.Visible = false;
                middlePnl.Visible = false;

                btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
                btnPlusSquare.IconColor = Color.White;
                btnPlusSquare.BackColor = Color.FromArgb(27, 197, 189);
            }
        }
    }
}

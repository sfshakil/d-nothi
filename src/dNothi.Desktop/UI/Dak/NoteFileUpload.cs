using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NoteFileUpload : UserControl
    {
        public NoteFileUpload()
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

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
        private string _imageSrc;
        private string _attachmentName;
        private string _fileextension;

        public string imgSource
        {
            get { return _imageSrc; }
            set
            {
                _imageSrc = value;
                if (value != "")
                {
                    attachmentPicturebox.Image = new Bitmap(value);
                }
                else
                {
                    attachmentPicturebox.Enabled = false;
                }
            }

        }
        public string attachmentName
        {
            get { return _attachmentName; }
            set
            {
                _attachmentName = value; attachmentNameTextBox.Text = value;
            }

        }
        public string fileexension
        {
            get { return _fileextension; }
            set
            {
                _fileextension = value;
                lbByte.Text = value;


            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}

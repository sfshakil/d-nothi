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
    public partial class NoteFileDelete : UserControl
    {
        public NoteFileDelete()
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
        public string _attachmentName;
        private string _fileextension;
        public string attachmentName
        {
            get { return _attachmentName; }
            set
            {
                _attachmentName = value; lbAattachmentName.Text = value;
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
            this.Hide();
        }
    }
}

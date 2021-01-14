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
    public partial class Attachment : UserControl
    {
        public Attachment()
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
        private string _attachmentSize;
        private string _attachmentName;

        [Category("Custom Props")]
        public string attachmentName
        {
            get { return _attachmentName; }
            set { _attachmentName = value; lbAttachmentName.Text = value; }
        }
        [Category("Custom Props")]
        public string attachmentSize
        {
            get { return _attachmentSize; }
            set { _attachmentSize = value; lbAttachmentSize.Text = value; }
        }

    }
}

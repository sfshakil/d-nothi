using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Desktop.UI.Dak;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraAttachmentViewForm : Form
    {
        public KhosraAttachmentViewForm()
        {
            InitializeComponent();
        }

        private void KhosraAttachmentViewForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }
        public DakAttachmentResponse _dakAttachmentResponse { get; set; }
        public DakAttachmentResponse dakAttachmentResponse
        {
            get { return _dakAttachmentResponse; }
            set
            {
                _dakAttachmentResponse = value;


                attachmentTableLayoutPanel.Controls.Clear();
                DakAttachmentListBodyUserControl detailsAttachmentListUserControl = new DakAttachmentListBodyUserControl();
                try
                {
                    //detailsAttachmentListUserControl.dakSub = _subject;
                    detailsAttachmentListUserControl.dakAttachmentDTOs = _dakAttachmentResponse.data;

                    detailsAttachmentListUserControl.allattachmentdownloadlink = "";
                    detailsAttachmentListUserControl.Dock = DockStyle.Fill;
                    attachmentTableLayoutPanel.Controls.Add(detailsAttachmentListUserControl);
                }
                catch
                {

                }



            }
        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

using dNothi.JsonParser.Entity.Dak;
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
    public partial class DakAttachmentViewForm : Form
    {
        private DakAttachmentResponse _dakAttachmentResponse;
        private string _subject;

        public DakAttachmentViewForm()
        {
            InitializeComponent();
        }

        public string subject { get { return _subject; } set { _subject = value; Subjectlabel.Text = Subjectlabel.Text + value; } }

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
                    detailsAttachmentListUserControl.dakSub = _subject;
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

        private void DakAttachmentViewForm_Load(object sender, EventArgs e)
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

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

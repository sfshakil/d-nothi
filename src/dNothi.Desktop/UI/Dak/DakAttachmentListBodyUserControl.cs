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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakAttachmentListBodyUserControl : UserControl
    {
        public DakAttachmentListBodyUserControl()
        {
            InitializeComponent();
        }

        private List<DakAttachmentDTO> _dakAttachmentDTOs;
        private int _attachmentcount;
        private string _dakSub;
        private string _allattachmentdownloadlink;

        public string dakSub
        {
            get { return _dakSub; }
            set { _dakSub = value; }
        }

        public string allattachmentdownloadlink
        {
            get { return _allattachmentdownloadlink; }
            set { _allattachmentdownloadlink = value; }
        }

        public List<DakAttachmentDTO> dakAttachmentDTOs
        {
            get { return _dakAttachmentDTOs; }
            set
            {
                _dakAttachmentDTOs = value;
                if (dakAttachmentDTOs != null)
                {
                    _attachmentcount = value.Count;
                    attachmentCountLabel.Text = "সংযুক্তি(" + string.Concat(value.Count.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    attachmentListFlowLayoutPanel.Controls.Clear();
                    foreach (DakAttachmentDTO dakAttachmentDTO in dakAttachmentDTOs)
                    {
                        DakAttachmentRowUserControl detailsAttachmentUserControl = new DakAttachmentRowUserControl();

                        detailsAttachmentUserControl.mainattachment = dakAttachmentDTO.is_main;
                        detailsAttachmentUserControl.dakAttachmentDTOs = dakAttachmentDTOs;

                        if (dakAttachmentDTO.is_main == 1 && dakAttachmentDTO.attachment_type.ToUpper().Contains("TEXT"))
                        {

                            detailsAttachmentUserControl.attachmentName = _dakSub;
                        }
                        else
                        {

                            detailsAttachmentUserControl.attachmentName = dakAttachmentDTO.file_name;
                        }

                        detailsAttachmentUserControl.dakAttachmentDTO = dakAttachmentDTO;
                        detailsAttachmentUserControl.attachmentsize = Convert.ToDouble(dakAttachmentDTO.file_size_in_kb);
                        detailsAttachmentUserControl.attachmentdownload = dakAttachmentDTO.download_url;
                        detailsAttachmentUserControl.attachmenttype = dakAttachmentDTO.attachment_type;
                        detailsAttachmentUserControl.attachmentid = dakAttachmentDTO.attachment_id;


                        if (dakAttachmentDTO.attachment_type.ToLower().Contains("image") || dakAttachmentDTO.attachment_type.ToLower().Contains("img") || dakAttachmentDTO.attachment_type.ToLower().Contains("pdf") || dakAttachmentDTO.attachment_type.ToLower().Contains("txt") || dakAttachmentDTO.attachment_type.ToLower().Contains("text"))
                        {
                            detailsAttachmentUserControl.attachmentlink = dakAttachmentDTO.url;
                        }
                        else
                        {
                            detailsAttachmentUserControl.attachmentlink = "";
                        }

                       // attachmentListFlowLayoutPanel.Controls.Clear();
                        detailsAttachmentUserControl.Dock = DockStyle.Fill;

                        int row = attachmentListFlowLayoutPanel.RowCount++;

                        attachmentListFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                        if (row == 1)
                        {
                            row = attachmentListFlowLayoutPanel.RowCount++;
                            attachmentListFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                        }
                        attachmentListFlowLayoutPanel.Controls.Add(detailsAttachmentUserControl, 0, row);


                        attachmentListFlowLayoutPanel.Controls.Add(detailsAttachmentUserControl);
                    }
                }





            }
        }


        private void BorderColorBlue(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
    }
}

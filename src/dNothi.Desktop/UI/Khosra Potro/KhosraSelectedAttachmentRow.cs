using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraSelectedAttachmentRow : UserControl
    {
        public KhosraSelectedAttachmentRow()
        {
            InitializeComponent();
        }
     
        public PermittedPotroResponseMulpotroDTO _permittedPotroResponseMulpotroDTO { get; set; }
        public PermittedPotroResponseMulpotroDTO permittedPotroResponseMulpotroDTO
        {
            get { return _permittedPotroResponseMulpotroDTO; }
            set
            {
                _permittedPotroResponseMulpotroDTO = value;
                if (value != null)
                {
                    attachmentNameLabel.Text = value.user_file_name;
                    UIDesignCommonMethod.FileIconSet(value.attachment_type, fileIconButton);



                }
            }
        }
        public int _id { get; set; }
        public int id { get { return _id; } set { _id = value; } }

        public string _fileName { get; set; }
        public string fileName { get { return _fileName; } set { _fileName = value; attachmentNameLabel.Text = value; } }

        public bool isDeleted { get; set; }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            isDeleted = true;
            this.Hide();

         

        }

        private void TableBorderColor(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void TableBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }

        private void fileIconButton_Click(object sender, EventArgs e)
        {
            DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
            dakAttachmentDTO.id = _permittedPotroResponseMulpotroDTO.id;
            dakAttachmentDTO.download_url = _permittedPotroResponseMulpotroDTO.download_url;
            dakAttachmentDTO.file_url = _permittedPotroResponseMulpotroDTO.url;
            dakAttachmentDTO.url = _permittedPotroResponseMulpotroDTO.url;
      

            UIDesignCommonMethod.ShowSingleAttachment(dakAttachmentDTO, this);
        }
    }
}

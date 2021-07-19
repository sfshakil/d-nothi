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
using dNothi.Utility;
using FontAwesome.Sharp;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraSingleAttachmentUserControl : UserControl
    {
        public bool _isChecked { get; set; }
        public bool isChecked {
            get { return _isChecked; }
            set 
            {
                 _isChecked = value;
                selectCheckBox.Checked = value;
                
            }
            
           
        }
        public PermittedPotroResponseMulpotroDTO _permittedPotroResponseMulpotroDTO { get; set; }
        public PermittedPotroResponseMulpotroDTO permittedPotroResponseMulpotroDTO 
        {
            get { return _permittedPotroResponseMulpotroDTO; }
            set
            {
                _permittedPotroResponseMulpotroDTO = value;
                if(value !=null)
                {
                    if(value.is_main==1)
                    {
                        attachmentNameLabel.Text = "মূলপত্র​";
                    }
                    else
                    {
                        attachmentNameLabel.Text = value.user_file_name;
                    }
                 
                    attachmentPageCountLabel.Text = "পাতা নং:" + ConversionMethod.EnglishNumberToBangla(value.nothi_potro_page.ToString());
                    UIDesignCommonMethod.FileIconSet(value.attachment_type, fileTypeIconButton);



                }
            }
        }

       

        public KhosraSingleAttachmentUserControl()
        {
            InitializeComponent();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.DownLoadFile(_permittedPotroResponseMulpotroDTO.download_url,_permittedPotroResponseMulpotroDTO.user_file_name);
        }

        private void fileTypeIconButton_Click(object sender, EventArgs e)
        {

        }

        private void eyeButton_Click(object sender, EventArgs e)
        {
            DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
            dakAttachmentDTO.id = _permittedPotroResponseMulpotroDTO.id;
            dakAttachmentDTO.download_url = _permittedPotroResponseMulpotroDTO.download_url;
            dakAttachmentDTO.file_url = _permittedPotroResponseMulpotroDTO.url;
            dakAttachmentDTO.url = _permittedPotroResponseMulpotroDTO.url;


            UIDesignCommonMethod.ShowSingleAttachment(dakAttachmentDTO, this);
        }
        public event EventHandler checkButtonClick;
        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = selectCheckBox.Checked;
            if (this.checkButtonClick != null)
                this.checkButtonClick(sender, e);
        }
    }
}

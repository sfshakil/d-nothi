using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Utility;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class CommonKhosraRowUserControl : UserControl
    {
        public CommonKhosraRowUserControl()
        {
            InitializeComponent();
        }


        public string _sharokNo { get; set; }
        public string sharokNo { get { return _sharokNo; } set { _sharokNo = value; sharokNoLabel.Text = value; if (value == "") { sharokNoFlowLayoutPanel.Visible = false; } } }
        public string sharokNoEng { get { return _sharokNo; } set { _sharokNo = value; sharokNoLabel.Text = ConversionMethod.EnglishNumberToBangla(value); if (value == "") { sharokNoFlowLayoutPanel.Visible = false; } } }




        public string _sub { get; set; }
        public string sub { get { return _sub; } set { _sub = value; subLabel.Text = value; } }

        public string _date { get; set; }
        public string date { get { return _date; } set { _date = value; dateLabel.Text = value; } }


        public int _noteCount { get; set; }
        public int noteCount { get { return _noteCount; } set { _noteCount = value; noteCountLabel.Text = "নোট : "+ ConversionMethod.EnglishNumberToBangla(value.ToString()); } }





        public void ButtonVisibility(bool edit, bool attachment, bool details, bool onumodon)
        {
            editButton.Visible = edit;
            attachmentButton.Visible = attachment;
            eyeButton.Visible = details;
            onumodonButton.Visible = onumodon;
            
        }






        public bool _isDraft{get;set;}
        public bool isDraft{ get { return _isDraft; }
            set { _isDraft = value;
            if(value)
                {
                    noteCountLabel.Visible = false;
                    sharokNoFlowLayoutPanel.Visible = false;
                }
            
            }
        
        }

        private void attachmentButton_Click(object sender, EventArgs e)
        {
            DakAttachmentResponse dakAttachmentResponse = new DakAttachmentResponse();
            dakAttachmentResponse.data = new List<DakAttachmentDTO>();
            dakAttachmentResponse.data.Add(new DakAttachmentDTO { file_name = "Attachment Delete", id = 1, attachment_type = "pdf", is_main = 1, file_size_in_kb = "12.22" });
            dakAttachmentResponse.data.Add(new DakAttachmentDTO { file_name = "ছবি-ETL_MR_May'2020", id = 2, attachment_type = "pdf", is_main = 0, file_size_in_kb = "12.22" });
            dakAttachmentResponse.data.Add(new DakAttachmentDTO { file_name = "জাতীয় পরিচয়পত্র(আবেদনকারীর) - NID_ARIF", id = 3, attachment_type = "pdf", is_main = 0, file_size_in_kb = "14.22" });



            KhosraAttachmentViewForm khosraAttachmentViewForm = new KhosraAttachmentViewForm();
            khosraAttachmentViewForm.dakAttachmentResponse = dakAttachmentResponse;


            Form parentForm = UIDesignCommonMethod.GetParentsForm(this);



            UIDesignCommonMethod.CalPopUpWindow(khosraAttachmentViewForm, parentForm);
            
        }

        private void onumodonButton_Click(object sender, EventArgs e)
        {
            KhosraPrapokListViewForm khosraPrapokListViewForm = new KhosraPrapokListViewForm();
            UIDesignCommonMethod.CalPopUpWindow(khosraPrapokListViewForm, UIDesignCommonMethod.GetParentsForm(this));
        }
    }
}

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
using dNothi.Services.UserServices;
using Xamarin.Forms.Xaml;
using dNothi.Services.KasaraPatraDashBoardService;
using dNothi.Services.KasaraPatraDashBoardService.Models;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class CommonKhosraRowUserControl : UserControl
    {//
       
        public CommonKhosraRowUserControl()
        {
            InitializeComponent();
          
        }


        public string _sharokNo { get; set; }
     
        public string sharokNo{ 
            get { return _sharokNo; } 
            set { 
                    _sharokNo = value; 
                    sharokNoLabel.Text = value; 
                    if (value == "") 
                    { //sharokNoFlowLayoutPanels.Visible = false; 
                    } 
                } 
         }
        public string sharokNoEng { 
            get { return _sharokNo; } 
            set { _sharokNo = value; 
                   sharokNoLabel.Text = ConversionMethod.EnglishNumberToBangla(value);
                   if (value == "") 
                      { 
                        //sharokNoFlowLayoutPanels.Visible = false; 
                      } 
                }
               }
        public string _sub { get; set; }
        public string sub { get { return _sub; } set { _sub = value; subLabel.Text = value; } }
        public string _date { get; set; }
        public string date { get { return _date; } set { _date = value; dateLabel.Text = value; } }
        public int _noteCount { get; set; }
        public int noteCount { get { return _noteCount; } set { _noteCount = value; noteCountLabel.Text = "নোট : "+ ConversionMethod.EnglishNumberToBangla(value.ToString()); } }

        private string _approver { get; set; }
        public string approver { get => _approver; set { _approver = value; aproverLabel.Text = value; } }

        private string _sender { get; set; }
        public string sender { get => _sender; set { _sender = value; senderLabel.Text = value; } }

        private string _daran { get; set; }
        public string daran { get => _daran; set { _daran = value; daranLabel.Text = value; } }

        private string _kasaraPotterNam { get; set; }
        public string kasaraPotterNam { get => _kasaraPotterNam; set { _kasaraPotterNam = value; kasaraPotterNamLabel.Text = value; } }
        public bool noteVisible { set => noteCountLabel.Visible = value; }
        private string _noteNo { get; set; }
        public string noteNo { get => _noteNo; set { _noteNo = value; noteCountLabel.Text = "নোটঃ " + value; } }
       
        private string _onucchedNo { get; set; }
        public string onucchedNo { get => _onucchedNo; set=>_onucchedNo = value;  }

        public void ButtonVisibility(bool sampadan, bool view, bool prapaklist)
        {
            sampadanIconButton.Visible = sampadan;
           
            viewIconButton.Visible = view;
            prapaklistIconButton.Visible = prapaklist;
            
        }

        public bool _isDraft{get;set;}
        public bool isDraft{ get { return _isDraft; }
            set { _isDraft = value;
            if(value)
                {
                   // noteCountLabel.Visible = true;
                   // sharokNoFlowLayoutPanels.Visible = false;
                }
            
            }
        
        }
       
        public event EventHandler attachmentButtonClick;
        public event EventHandler sampadanButtonClick;
        public event EventHandler PrapakListButtonClick;
        public event EventHandler viewButtonClick;
        private void attachmentButton_Click(object sender, EventArgs e)
        {

            //if (this.attachmentButtonClick != null)
            //{

            //    _kasaraPatraDashBoardService = new KararaPotroDashBoardServices();

            //    var dakListUserParam = _userService.GetLocalDakUserParam();
            //    dakListUserParam.limit = 10;
            //    var noteAntarvuktaKasralist = _kasaraPatraDashBoardService.GetMulPattraAndSanjukti(dakListUserParam, Record);
            //    if (noteAntarvuktaKasralist.status == "success")
            //    {
            //        DakAttachmentResponse dakAttachmentResponse = new DakAttachmentResponse();
            //        dakAttachmentResponse.data = new List<DakAttachmentDTO>();
            //        dakAttachmentResponse.data.Add(new DakAttachmentDTO { file_name = "Attachment Delete", id = 1, attachment_type = "pdf", is_main = 1, file_size_in_kb = "12.22" });
            //        dakAttachmentResponse.data.Add(new DakAttachmentDTO { file_name = "ছবি-ETL_MR_May'2020", id = 2, attachment_type = "pdf", is_main = 0, file_size_in_kb = "12.22" });
            //        dakAttachmentResponse.data.Add(new DakAttachmentDTO { file_name = "জাতীয় পরিচয়পত্র(আবেদনকারীর) - NID_ARIF", id = 3, attachment_type = "pdf", is_main = 0, file_size_in_kb = "14.22" });



            //        KhosraAttachmentViewForm khosraAttachmentViewForm = new KhosraAttachmentViewForm();
            //        khosraAttachmentViewForm.dakAttachmentResponse = dakAttachmentResponse;
            //        Form parentForm = UIDesignCommonMethod.GetParentsForm(this);

            //        UIDesignCommonMethod.CalPopUpWindow(khosraAttachmentViewForm, parentForm);
            //    }


            //}

            if (this.attachmentButtonClick != null)
                this.attachmentButtonClick(sender, e);

        }
        private void onumodonButton_Click(object sender, EventArgs e)
        {
            //if (this.onumodonButtonClick != null)
            //{

            //    _kasaraPatraDashBoardService = new KararaPotroDashBoardServices();

            //    var dakListUserParam = _userService.GetLocalDakUserParam();
            //    dakListUserParam.limit = 10;

            //    var prapakerTalika = _kasaraPatraDashBoardService.GetPrapakerTalika(dakListUserParam, Record.basic.id);
            //    if (prapakerTalika.status == "success")
            //    {

            //        KhosraPrapokListViewForm khosraPrapokListViewForm = new KhosraPrapokListViewForm();
            //        khosraPrapokListViewForm.prapakerTalika = prapakerTalika;


            //        UIDesignCommonMethod.CalPopUpWindow(khosraPrapokListViewForm, UIDesignCommonMethod.GetParentsForm(this));
            //    }
            //}
            
        }

        private void noteCountLabel_Click(object sender, EventArgs e)
        {

        }
        private void prapaklistIconButton_Click(object sender, EventArgs e)
        {
            if (this.PrapakListButtonClick != null)
                this.PrapakListButtonClick(sender, e);
        }

        private void viewIconButton_Click(object sender, EventArgs e)
        {
            if (this.viewButtonClick != null)
                this.viewButtonClick(sender, e);
           
        }

        private void sampadanIconButton_Click(object sender, EventArgs e)
        {
            if (this.sampadanButtonClick != null)
                this.sampadanButtonClick(sender, e);
        }
    }
}

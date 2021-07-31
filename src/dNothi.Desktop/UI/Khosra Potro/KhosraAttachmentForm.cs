using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraAttachmentForm : Form
    {
       
        private int potroAll_StartPage;
        private int potroAll_EndPage;
        private int potroAll_PageNo;


        IUserService _userService { get; set; }
        IPotroServices _potroServices { get; set; }
        private DakUserParam _dakuserparam { get; set; }

        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "JPE", "BMP", "GIF", "PNG", ".JPE", ".BMP", ".GIF", ".PNG", "IMAGE", "IMG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF" };

        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        //public WaitFormFunc WaitForm;
        public WaitNothiForm WaitForm;
        public KhosraAttachmentForm(IUserService userService, IPotroServices potroServices)
        {
            //WaitForm = new WaitNothiForm();
            //UIDesignCommonMethod.CalPopUpWindow(WaitForm, this);
            //UIDesignCommonMethod.hideform_Shown
            paginationReset();

            _userService = userService;
            _potroServices = potroServices;
            InitializeComponent();
            LoadAllPermittedPotro();

            //WaitForm.Hide();
        }

        private void paginationReset()
        {
            potroAll_StartPage = 1;
            potroAll_EndPage = 0;
            potroAll_PageNo = 1;
        }

        private void LoadAllPermittedPotro()
        {



            _dakuserparam = _userService.GetLocalDakUserParam();
            _dakuserparam.page =potroAll_PageNo;
            _dakuserparam.limit =NothiCommonStaticValue.pageLimit;



            attachmentBodyTableLayoutPanel.Controls.Clear();

            PermittedPotroResponse permittedPotroResponse = _potroServices.GetPermittedPotro(_dakuserparam);
            if (permittedPotroResponse != null && permittedPotroResponse.data != null && permittedPotroResponse.data.records != null && permittedPotroResponse.data.records.Count > 0)
            {
                SetPotroAllPagination(permittedPotroResponse.data.records.Count, permittedPotroResponse.data.total_records);


                IsThereAnyPermittedPotre(true);

                foreach (var potro in permittedPotroResponse.data.records)
                {
                    KhosraOnumodonAttachmentUserControl khosraOnumodonAttachmentUserControl = new KhosraOnumodonAttachmentUserControl();

                    khosraOnumodonAttachmentUserControl.permittedPotroResponseRecordDTO = potro;

                    khosraOnumodonAttachmentUserControl.checkButtonClick += delegate (object sender, EventArgs e) { AddAttachmentFromPermittedTab(sender, e, khosraOnumodonAttachmentUserControl.selectedPermittedPotroResponseMulpotroDTO, khosraOnumodonAttachmentUserControl.isPotroSelected); ; };

                    UIDesignCommonMethod.AddRowinTable( attachmentBodyTableLayoutPanel, khosraOnumodonAttachmentUserControl);
                }
            }
            else
            {
                IsThereAnyPermittedPotre(false);
            }
          
        }

        private void AddAttachmentFromPermittedTab(object sender, EventArgs e, PermittedPotroResponseMulpotroDTO selectedPermittedPotroResponseMulpotroDTO, bool ischecked)
        {
            if (ischecked)
            {
                SelecteAttachment(selectedPermittedPotroResponseMulpotroDTO);
            }
            else
            {
                RemoveSelectedAttachment(selectedPermittedPotroResponseMulpotroDTO.id);

            }

            CountSelectedPotro();
        }

        private void RemoveSelectedAttachment(long id)
        {
            var khosraSelectedAttachmentRow = selectedAttachmentTableLayoutPanel.Controls.OfType<KhosraSelectedAttachmentRow>().FirstOrDefault(a => a._permittedPotroResponseMulpotroDTO.id ==id && a.isDeleted == false);
            if (khosraSelectedAttachmentRow != null)
            {
                khosraSelectedAttachmentRow.isDeleted = true;
                khosraSelectedAttachmentRow.Hide();
            }

            CountSelectedPotro();
        }

        private void SelecteAttachment(PermittedPotroResponseMulpotroDTO selectedPermittedPotroResponseMulpotroDTO)
        {
            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow = new KhosraSelectedAttachmentRow();

            khosraSelectedAttachmentRow.permittedPotroResponseMulpotroDTO = selectedPermittedPotroResponseMulpotroDTO;

            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow);

        }

        private void CountSelectedPotro()
        {
            try
            {
                var khosraSelectedAttachmentRows = selectedAttachmentTableLayoutPanel.Controls.OfType<KhosraSelectedAttachmentRow>().Where(a => a.isDeleted==false).ToList();
                selectedAttachmentTabPage.Text = "বাছাইকৃত(" + ConversionMethod.EngDigittoBanDigit(khosraSelectedAttachmentRows.Count.ToString()) + ")";
            }
            catch
            {

                selectedAttachmentTabPage.Text = "বাছাইকৃত(০)";
            }
        }

        private void SetPotroAllPagination(int count, int total_records)
        {

            potroAll_StartPage = 1+potroAll_PageNo*NothiCommonStaticValue.pageLimit-10;
            potroAll_EndPage = potroAll_StartPage + count - 1;

            totalAttachmentAllLabel.Text = "সর্বমোট " + ConversionMethod.EngDigittoBanDigit(total_records.ToString()) + " টি";
            attachmentAllRangeLabel.Text = ConversionMethod.EngDigittoBanDigit(potroAll_StartPage.ToString()) + "-" + ConversionMethod.EngDigittoBanDigit(potroAll_EndPage.ToString());

            



        }

        private void SetPaginationText(int total_records, int StartPage, int EndPage)
        {
           
        }

        private void IsThereAnyPermittedPotre(bool anyRow)
        {
            
                noFIlePanel02.Visible = !anyRow;
                searchPanel.Visible = anyRow;
                paginationPanel.Visible = anyRow;
            
           

           
        }

        public void  IsCurrentPotroTabPageShow(bool Show)
        {
            if(!Show)
            {
                tabControlLeft.TabPages.Remove(currentNothiAttachmentTabPageLeft); 
            }
        }

        private void crossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Border_Gray(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Gray(sender, e);
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                Byte[] bytes = File.ReadAllBytes(opnfd.FileName);
                _dakFileUploadParam.content = Convert.ToBase64String(bytes);

                _dakFileUploadParam.path = "Potrojari";
                _dakFileUploadParam.model = "PotrojariAttachments";

                var size = new System.IO.FileInfo(opnfd.FileName).Length;

                _dakFileUploadParam.file_size_in_kb = size.ToString() + " KB";



                DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();

                using (var form = FormFactory.Create<Dashboard>())
                {
                    dakUploadedFileResponse = form.UploadFile(_dakFileUploadParam);
                }

                if (dakUploadedFileResponse.status == "success")
                {
                    if (dakUploadedFileResponse.data.Count > 0)
                    {
                        PermittedPotroResponseMulpotroDTO permittedPotroResponseMulpotroDTO = new PermittedPotroResponseMulpotroDTO();
                        DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            dakUploadAttachmentTableRow._isAllowedforOCR = true;
                            dakUploadAttachmentTableRow.imgSource = opnfd.FileName;
                         


                        }

                      
                        dakUploadAttachmentTableRow.isAllowedforMulpotro = false;



                        permittedPotroResponseMulpotroDTO.content_body = dakUploadAttachmentTableRow.imageBase64String = _dakFileUploadParam.content;

                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        permittedPotroResponseMulpotroDTO.attachment_type=dakUploadAttachmentTableRow.fileexension = new System.IO.FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
                        dakUploadAttachmentTableRow._dakAttachment = dakUploadedFileResponse.data[0];
                        dakUploadAttachmentTableRow.imageLink = dakUploadedFileResponse.data[0].url;

                        permittedPotroResponseMulpotroDTO.user_file_name= dakUploadAttachmentTableRow.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                        permittedPotroResponseMulpotroDTO.id=dakUploadAttachmentTableRow.attachmentId = dakUploadedFileResponse.data[0].attachment_id; ;
                      
                        dakUploadAttachmentTableRow.Dock = DockStyle.Top;
                        attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);


                        permittedPotroResponseMulpotroDTO.file_name= dakUploadedFileResponse.data[0].file_name;
                        permittedPotroResponseMulpotroDTO.file_dir= dakUploadedFileResponse.data[0].file_dir;
                        try
                        {

                            permittedPotroResponseMulpotroDTO.file_size_in_kb = Convert.ToDouble(dakUploadedFileResponse.data[0].file_size_in_kb);
                        }
                        catch
                        {

                        }
                        permittedPotroResponseMulpotroDTO.application_origin= dakUploadedFileResponse.data[0].application_origin;
                        permittedPotroResponseMulpotroDTO.attachment_description= dakUploadedFileResponse.data[0].attachment_description;
                        permittedPotroResponseMulpotroDTO.attachment_type= dakUploadedFileResponse.data[0].attachment_type;
                        permittedPotroResponseMulpotroDTO.download_url= dakUploadedFileResponse.data[0].download_url;
                        permittedPotroResponseMulpotroDTO.meta_data= dakUploadedFileResponse.data[0].meta_data;
                        permittedPotroResponseMulpotroDTO.thumb_url= dakUploadedFileResponse.data[0].thumb_url;
                        permittedPotroResponseMulpotroDTO.url = dakUploadedFileResponse.data[0].url ;


                        //permittedPotroResponseMulpotroDTO=permittedPotroResponseMulpotroDTO;
                        SelecteAttachment(permittedPotroResponseMulpotroDTO);
                        CountSelectedPotro();

                    }
                }


            }
        }

       

        private void DeleteControl_ButtonClick(object sender, EventArgs e, DakAttachmentDTO dakAttachment)
        {
            //this.Hide();
            DakUploadFileDeleteParam deleteParam = new DakUploadFileDeleteParam();
            deleteParam.delete_token = dakAttachment.delete_token;
            deleteParam.file_name = dakAttachment.file_name;

            DakFileDeleteResponse response;

            using (var form = FormFactory.Create<Dashboard>())
            {
                response = form.DeleteFile(deleteParam);
            }
            if (response.status == "success")

            {
                UIDesignCommonMethod.SuccessMessage("সফলভাবে সংযুক্তি মুছে ফেলা হয়েছে");
                var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

                foreach (var attachment in attachmentList)
                {
                    if (attachment.attachmentId == dakAttachment.attachment_id)
                    {
                        attachmentListFlowLayoutPanel.Controls.Remove(attachment);
                        RemoveSelectedAttachment(attachment.attachmentId);
                    }
                }
            }


        }

      

        private void KhosraAttachmentForm_Shown(object sender, EventArgs e)
        {
            //WaitForm.Close();
        }

        private void Border_Blue(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
          
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            
        }

        private void previousAllButton_Click(object sender, EventArgs e)
        {
            potroAll_PageNo -= 1;
            LoadAllPermittedPotro();
        }

        private void nextAllButton_Click(object sender, EventArgs e)
        {
            potroAll_PageNo += 1;
            LoadAllPermittedPotro();
        }

        private void allNothiAttachmentTabPageLeft_Click(object sender, EventArgs e)
        {
            paginationReset();
            LoadAllPermittedPotro();
        }

        public List<PermittedPotroResponseMulpotroDTO> permittedPotroResponseMulpotroDTOs;
        public event EventHandler SelectButtonClicked;
        private void selectButton_Click(object sender, EventArgs e)
        {
            permittedPotroResponseMulpotroDTOs = new List<PermittedPotroResponseMulpotroDTO>();
            var khosraSelectedAttachmentRows = selectedAttachmentTableLayoutPanel.Controls.OfType<KhosraSelectedAttachmentRow>().Where(a=>a.isDeleted == false).ToList();
            if (khosraSelectedAttachmentRows != null && khosraSelectedAttachmentRows.Count>0)
            {
                foreach(var attachment in khosraSelectedAttachmentRows)
                {
                    permittedPotroResponseMulpotroDTOs.Add(attachment._permittedPotroResponseMulpotroDTO);
                }
            }
            this.Hide();
            if (this.SelectButtonClicked != null)
                this.SelectButtonClicked(sender, e);
        }

        private void KhosraAttachmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}

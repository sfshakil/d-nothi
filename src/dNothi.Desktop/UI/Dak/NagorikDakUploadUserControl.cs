using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.View_Model;
using dNothi.Services.DakServices;
using dNothi.JsonParser.Entity.Dak;
using AutoMapper;
using System.IO;
using dNothi.Utility;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Constants;
using System.Text.RegularExpressions;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NagorikDakUploadUserControl : UserControl
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPEG", ".JPG", "JPG", "JPE", "BMP", "GIF", "PNG", ".JPE", ".BMP", ".GIF", ".PNG", "IMAGE", "IMG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF" };
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        List<string> sendMediumListCollection = new List<string>();
        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        public int _prerokId = 0;
        public int _dakId = 0;
        private DakUserParam _dak_List_User_Param;
        public DakUploadParameter dakUploadParameter = new DakUploadParameter();
        public List<DakAttachmentDTO> _dakAttachmentDTOs = new List<DakAttachmentDTO>();
        public DakInfoDTO _dakInfoDTO = new DakInfoDTO();
        public PrapokDTO _mul_prapok = new PrapokDTO();
        public Dictionary<string, PrapokDTO> _onulipi;

        public string prerokName;
        public string prapokName;
        public string sub;


        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        bool NijOffice = true;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        List<DakAttachmentinGrid> _dakAttachmentinGrids = new List<DakAttachmentinGrid>();

        public PrapokDTO mul_prapokEdit { get { return _mul_prapok; } set { _mul_prapok = value; viewDesignationSealLists.FirstOrDefault(a => a.designation_id == value.designation_id).mul_prapok = true; } }
        public Dictionary<string, PrapokDTO> onulipi
        {
            get { return _onulipi; }
            set
            {
                _onulipi = value;
                foreach (KeyValuePair<string, PrapokDTO> prapok in value)
                {
                    viewDesignationSealLists.FirstOrDefault(a => a.designation_id == prapok.Value.designation_id).onulipi_prapok = true;
                }
            }
        }


        public DakInfoDTO dakInfoDTO
        {
            get { return _dakInfoDTO; }
            set
            {
                _dakInfoDTO = value;
                _prerokId = value.sender_officer_designation_id;
                //selectedPrerokLabel.Text = value.receiving_officer_name + "," + value.receiving_officer_designation_label + "," + value.receiving_office_unit_name + "," + value.receiving_office_name;
                // sharokNoTextBox.Text = value.sender_sarok_no;
                //sharokdateTimePicker.Text = value.sending_date;

                subjectXTextBox.Text = value.dak_subject;
                _dakId = value.id;

                //sendMediumSearchButton.searchButtonText = value.dak_sending_media;

                dakDescriptionXTextBox.Text = value.dak_description;

                mobileXTextBox.Text = value.mobile_no;
                emailXTextBox.Text = value.email;

                if(value.gender!="")
                {
                    //genderSearchButton.searchButtonText = value.gender;
                    genderSearchButton1.SelectedItem = value.gender;
                }
                 if(value.nationality != "")
                {
                    //searchNationalityUserController1.searchButtonText = value.nationality;
                    searchNationalityUserController.SelectedItem = value.nationality;
                }
                   if(value.religion != "")
                {
                    //searchReligionUserController.searchButtonText = value.religion;
                    searchReligionUserController1.SelectedItem = value.religion;
                }


            
                nameBanglaXTextBox.Text = value.name_bng;
                NameEnglishXTextBox.Text = value.name_eng;
                nationalIdXTextBox.Text = value.national_idendity_no;
                birthCertificateNoXTextBox.Text = value.birth_registration_number;
                nameFatherorHusbandXTextBox.Text = value.father_name;
                nameMotherXTextBox.Text = value.mother_name;
                passportNoXTextBox.Text = value.passport;
                permenantAddressXTextBox.Text = value.parmanent_address;
                presentAddressXTextBox.Text = value.address;
               
               // nameFatherorHusbandXTextBox.Text=value.


                if (value.dak_priority_level != "0")
                {
                    DakPriorityList dakPriority = new DakPriorityList();
                    //prioritySearchButton.searchButtonText = dakPriority.GetDakPriorityName(value.dak_priority_level);
                    prioritySearchButton1.SelectedItem = dakPriority.GetDakPriorityName(value.dak_priority_level);





                }
                if (value.dak_security_level != "0")
                {
                    DakSecurityList dakSecurityList = new DakSecurityList();
                    //seurityLevelSearchButton.searchButtonText = dakSecurityList.GetDakSecuritiesName(value.dak_security_level);
                    seurityLevelSearchButton1.SelectedItem = dakSecurityList.GetDakSecuritiesName(value.dak_security_level);


                }







            }

        }

        public List<DakAttachmentDTO> dakAttachmentDTOs
        {
            get { return _dakAttachmentDTOs; }
            set
            {
                _dakAttachmentDTOs = value;
                if (value != null)
                {
                    if (value.Count > 0)
                    {
                        foreach (DakAttachmentDTO attachment in dakAttachmentDTOs)
                        {
                            DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();

                            if (attachment.attachment_type.ToUpperInvariant().Contains("IMAGE"))
                            {
                                dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                                dakUploadAttachmentTableRow._isAllowedforOCR = true;
                                try
                                {
                                    using (Image image = Image.FromFile(attachment.url))
                                    {
                                        using (MemoryStream m = new MemoryStream())
                                        {
                                            image.Save(m, image.RawFormat);
                                            byte[] imageBytes = m.ToArray();
                                            // dakUploadAttachmentTableRow.imgSource = attachment.i;

                                            // Convert byte[] to Base64 String
                                            dakUploadAttachmentTableRow.imageBase64String = Convert.ToBase64String(imageBytes);

                                        }
                                    }
                                }
                                catch (Exception Ex)
                                {

                                }
                            }


                            else if (attachment.attachment_type.ToUpperInvariant().Contains("PDF"))
                            {
                                dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                                dakUploadAttachmentTableRow._isAllowedforOCR = true;

                            }
                            else
                            {
                                dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                            }

                            if (attachment.is_main == 1)
                            {
                                dakUploadAttachmentTableRow.isMulpotro = true;
                            }



                            dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(oCRSender, oCREvent, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                            dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(deleteSender, deleteeVent, dakUploadAttachmentTableRow._dakAttachment); };



                            dakUploadAttachmentTableRow.fileexension = attachment.attachment_type.ToLowerInvariant();
                            dakUploadAttachmentTableRow._dakAttachment = attachment;
                            dakUploadAttachmentTableRow.imageLink = attachment.url;
                            dakUploadAttachmentTableRow.imageDownloadLink = attachment.download_url;

                            dakUploadAttachmentTableRow.attachmentName = attachment.user_file_name;
                            dakUploadAttachmentTableRow.attachmentId = attachment.attachment_id; ;
                            dakUploadAttachmentTableRow.RadioButtonClick += delegate (object radioSender, EventArgs radioEvent) { AttachmentTable_RadioButtonClick(radioSender, radioEvent, dakUploadAttachmentTableRow.attachmentId); };


                            attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);
                        }
                    }
                }


            }
        }

        public DakUserParam dakListUserParam
        {
            get { return _dak_List_User_Param; }
            set { _dak_List_User_Param = value; }

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




                SetDefaultFont(ctrl.Controls);
            }

        }
        public bool _isOwnDesk;
        public NagorikDakUploadUserControl()
        {
            InitializeComponent();


            PriorityListCollection.Clear();

            DakAttachmentListinGrid dakAttachmentListinGrid = new DakAttachmentListinGrid();
            _dakAttachmentinGrids = dakAttachmentListinGrid.dakAttachmentinGrids;
            PriorityListCollection.Clear();
            originalHeight = dakUploadPanel2.Size.Height;
            searchNationalityUserController.SelectedIndex = 0;
            genderSearchButton1.SelectedIndex = 0;
            searchReligionUserController1.SelectedIndex = 0;
            prioritySearchButton1.SelectedIndex = 0;
            seurityLevelSearchButton1.SelectedIndex = 0;

            MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);


        }
        private int originalHeight;
        private void AttachmentTable_RadioButtonClick(object sender, EventArgs e, long attachmentId)
        {
            var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

            foreach (var attachment in attachmentList)
            {
                if (attachment.attachmentId != attachmentId)
                {
                    attachment.isMulpotro = false;
                }
            }

        }

        private DesignationSealListResponse _designationSealListResponse;


        public DesignationSealListResponse designationSealListResponse
        {
            get { return _designationSealListResponse; }
            set
            {
                _designationSealListResponse = value;
                try
                {
                    foreach (PrapokDTO ownOfficeDTO in value.data.own_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOwnOffice = mapper.Map<ViewDesignationSealList>(ownOfficeDTO);



                        viewdesignationListOwnOffice.nij_Office = true;



                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOwnOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOwnOffice);
                        }

                    }

                    foreach (PrapokDTO otherOfficeDTO in value.data.other_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOtherOffice = mapper.Map<ViewDesignationSealList>(otherOfficeDTO);
                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOtherOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOtherOffice);
                        }

                    }

                    PopulateGrid();

                }
                catch
                {

                }



            }

        }



        int designationColumn = 2;
        private void SaveOnulipiPrapok(int row_index)
        {

            for (int i = 0; i <= prapokDataGridView.Rows.Count - 1; i++)
            {
                if (i == row_index)
                {
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    SetThisMulprapokfalse(designation_id);
                }
            }
        }

        private void SetThisMulprapokfalse(int designation_id)
        {
            viewDesignationSealLists.FirstOrDefault(a => a.designation_id == designation_id).mul_prapok = false;


        }

        private void SaveMulPrapok(int row_index)
        {
            for (int i = 0; i <= prapokDataGridView.Rows.Count - 1; i++)
            {
                prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;

                if (i != row_index)
                {
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                }
                else
                {
                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;

                    SetOtherMulprapokfalse(designation_id);

                }
            }
        }

        private void SetOtherMulprapokfalse(int designation_id)
        {
            foreach (ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists)
            {
                if (viewDesignationSealList.designation_id != designation_id)
                {
                    viewDesignationSealList.mul_prapok = false;
                }
                else
                {
                    viewDesignationSealList.mul_prapok = true;
                }
            }
        }

        private void ownOfficeButton_Click(object sender, EventArgs e)
        {
            PopulateGrid();


        }
        public void PopulateGrid()
        {
            BindingList<ViewDesignationSealList> bindinglist = new BindingList<ViewDesignationSealList>();
            foreach (ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists)
            {
                bindinglist.Add(viewDesignationSealList);
            }
            prapokDataGridView.DataSource = null;
            prapokDataGridView.DataSource = bindinglist;
        }

        private void officerSearchXTextBox_TextChanged(object sender, EventArgs e)
        {

            var prapokList = prapokDataGridView.DataSource;

            IEnumerable<ViewDesignationSealList> designationSealListsinGridView = (IEnumerable<ViewDesignationSealList>)prapokList;
            List<ViewDesignationSealList> NewViewDesignationSealLists = new List<ViewDesignationSealList>();


            if (officerSearchXTextBox.Text == "")
            {
                PopulateGrid();
            }
            else
            {
                foreach (var des in designationSealListsinGridView)
                {
                    if (des.designation.Contains(officerSearchXTextBox.Text) || des.employee_name_bng.Contains(officerSearchXTextBox.Text))
                    {
                        NewViewDesignationSealLists.Add(des);
                    }

                }
                BindingList<ViewDesignationSealList> bindinglist = new BindingList<ViewDesignationSealList>();
                foreach (ViewDesignationSealList viewDesignationSealList in NewViewDesignationSealLists)
                {
                    bindinglist.Add(viewDesignationSealList);
                }
                prapokDataGridView.DataSource = null;
                prapokDataGridView.DataSource = bindinglist;
            }



        }

        private void ownOfficeButton_Click_1(object sender, EventArgs e)
        {
            NijOffice = false;
            PopulateGrid();
        }



        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;

            if (prapokDataGridView.Columns[prapokDataGridView.CurrentCell.ColumnIndex].Name == "ActionButton")
            {

                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "অপনি কি প্রাপকটিকে মুছে ফেলতে চান?";
                conditonBoxForm.ShowDialog();
                if (conditonBoxForm.Yes)
                {
                    int designation_id = Convert.ToInt32(prapokDataGridView.Rows[row_index].Cells["designationid_id"].Value);
                    var form = FormFactory.Create<Dashboard>();
                    string designationSealIdJson = designation_id.ToString();
                    DeleteDesignationSealResponse deleteDesignationSealResponse = form.DeleteDesignation(designationSealIdJson);

                    if (deleteDesignationSealResponse.status == "success")
                    {
                        MessageBox.Show("প্রাপকটিকে সফলভাবে মুছে ফেলা হ​য়েছে।");

                        prapokDataGridView.Rows.RemoveAt(row_index);



                        viewDesignationSealLists = viewDesignationSealLists.Where(a => a.designation_id != designation_id).ToList();

                    }
                    else
                    {
                        MessageBox.Show("মুছে ফেলা সফল হ​য়নি।।");
                    }

                }
                else
                {

                }
            }
            if (e.ColumnIndex == mulPrapokColumn)
            {
                SaveMulPrapok(row_index);
            }
            else if (e.ColumnIndex == onulipiColumn)
            {
                SaveOnulipiPrapok(row_index);
            }

            prapokDataGridView.Refresh();
        }







        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpeg;*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpeg;*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                // var fileStream = opnfd.OpenFile();

                // using (StreamReader reader = new StreamReader(opnfd.FileName, Encoding.UTF8))
                // {
                //     _dakFileUploadParam.content = reader.ReadToEnd();
                // }

                //// _dakFileUploadParam.content = File.ReadAllText(opnfd.FileName);
                // // _dakFileUploadParam.file_size_in_kb=opnfd.

                Byte[] bytes = File.ReadAllBytes(opnfd.FileName);
                _dakFileUploadParam.content = Convert.ToBase64String(bytes);

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
                        //attachmentListFlowLayoutPanel.Controls.Clear();
                        DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            dakUploadAttachmentTableRow._isAllowedforOCR = true;
                            dakUploadAttachmentTableRow.imgSource = opnfd.FileName;
                            //using (Image image = Image.FromFile(opnfd.FileName))
                            //{
                            //    using (MemoryStream m = new MemoryStream())
                            //    {
                            //        image.Save(m, image.RawFormat);
                            //        byte[] imageBytes = m.ToArray();

                            //        // Convert byte[] to Base64 String
                            //        dakUploadAttachmentTableRow.imageBase64String = Convert.ToBase64String(imageBytes);

                            //    }
                            //}


                        }

                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;

                        }
                        else
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }


                        dakUploadAttachmentTableRow.imageBase64String = _dakFileUploadParam.content;

                        dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        dakUploadAttachmentTableRow.fileexension = new System.IO.FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
                        dakUploadAttachmentTableRow._dakAttachment = dakUploadedFileResponse.data[0];
                        dakUploadAttachmentTableRow.imageLink = dakUploadedFileResponse.data[0].url;
                        dakUploadAttachmentTableRow.imageDownloadLink = dakUploadedFileResponse.data[0].download_url;

                        dakUploadAttachmentTableRow.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                        dakUploadAttachmentTableRow.attachmentId = dakUploadedFileResponse.data[0].attachment_id; ;
                        dakUploadAttachmentTableRow.RadioButtonClick += delegate (object radioSender, EventArgs radioEvent) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow.attachmentId); };


                        //attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);

                        dakUploadAttachmentTableRow.Width = dakUploadAttachmentListTableUserControl2.Width;
                        attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);
                        dakUploadPanel2.AutoSize = false;
                        dakUploadPanel2.Size = new Size(dakUploadPanel2.Size.Width, originalHeight + attachmentListFlowLayoutPanel.Height);
                    }
                }


            }


        }
        private void DeleteControl_ButtonClick(object sender, EventArgs e, DakAttachmentDTO dakAttachment)
        {
            DakUploadFileDeleteParam deleteParam = new DakUploadFileDeleteParam();
            deleteParam.delete_token = dakAttachment.delete_token;
            deleteParam.file_name = dakAttachment.file_name;

            DakFileDeleteResponse response;

            using (var form = FormFactory.Create<Dashboard>())
            {
                response = form.DeleteFile(deleteParam);
            }
            if (dakAttachment.id == 0 || (response != null && response.status == "success"))
            {
                UIDesignCommonMethod.SuccessMessage("সফলভাবে সংযুক্তি মুছে ফেলা হয়েছে");
                var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

                foreach (var attachment in attachmentList)
                {
                    if (attachment.attachmentId == dakAttachment.attachment_id)
                    {
                        attachmentListFlowLayoutPanel.Controls.Remove(attachment);
                    }
                }
                dakUploadPanel2.AutoSize = false;
                dakUploadPanel2.Size = new Size(dakUploadPanel2.Size.Width, originalHeight + attachmentListFlowLayoutPanel.Height);
            }


        }
        
        private void OCRControl_ButtonClick(object sender, EventArgs e, string imageBase64String, DakAttachmentDTO dakAttachment, string Extension)
        {
            OCRParameter oCRParameter = new OCRParameter();
            oCRParameter.data = imageBase64String;
            oCRParameter.Extension = Extension;

            OCRResponse oCRResponse = new OCRResponse();

            using (var form = FormFactory.Create<Dashboard>())
            {
                oCRResponse = form.OCRFile(oCRParameter);
            }
            if (oCRResponse != null)
            {
                dakDescriptionXTextBox.Text = oCRResponse.text;
            }
          

        }

        private void fileUploadPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }




        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void xTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownOfficeButton_Click_2(object sender, EventArgs e)
        {
            PopulateGrid();
        }


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler KhosraSaveButtonClick;
        private void khosraSaveButton_Click(object sender, EventArgs e)
        {
           if(!NagorikDakSaveAndSendValidation(false))
            {
                return;
            }

            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি সংরক্ষণ করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {


                
                SetDakUploadData(false);

                if (this.KhosraSaveButtonClick != null)
                    this.KhosraSaveButtonClick(sender, e);
            }
            else
            {

            }






        }




        private void SetDakUploadData(bool isOwnDesk)
        {
            _isOwnDesk = isOwnDesk;
            prerokName = nameBanglaXTextBox.Text;
            sub = subjectXTextBox.Text;

            //uploader

            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<DakUserParam, DakForwardRequestSenderInfo>()
                  );
            var mapper = new Mapper(config);
            var dakSender = mapper.Map<DakForwardRequestSenderInfo>(_dak_List_User_Param);


            dakUploadParameter.uploader = dakUploadParameter.CSharpObjtoJson(dakSender);

            //Sender

            dakUploadParameter.sender_info = "[]";


            // Dak

            DakInfo dak = new DakInfo(true);

            List<DakUploadAttachment> dakUploadAttachments = new List<DakUploadAttachment>();

            var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

            foreach (var attachment in attachmentList)
            {
                DakUploadAttachment dakUploadAttachment = new DakUploadAttachment();
                if (attachment.isMulpotro)
                {
                    dakUploadAttachment.mulpotro = 1;
                }


                dakUploadAttachment.file_infoModel = attachment._dakAttachment;
                dakUploadAttachment.file_infoModel.user_file_name = attachment._attachmentName;
                dakUploadAttachment.file_infoModel.img_base64 = attachment.imageBase64String;
                dakUploadAttachment.file_info = dakUploadParameter.CSharpObjtoJson(dakUploadAttachment.file_infoModel);


                dakUploadAttachments.Add(dakUploadAttachment);


            }

            dakUploadParameter.remoteAttachments = dakUploadAttachments.Where(a => a.file_infoModel.id != 0).ToList();
            dakUploadParameter.localAttachments = dakUploadAttachments.Where(a => a.file_infoModel.id == 0).ToList();

            dak.national_idendity_no = nationalIdXTextBox.Text;
            dak.birth_registration_number = birthCertificateNoXTextBox.Text;
            dak.passport = passportNoXTextBox.Text;
            dak.name_bng = nameBanglaXTextBox.Text;
            dak.name_eng = NameEnglishXTextBox.Text;
            dak.father_name = nameFatherorHusbandXTextBox.Text;
            dak.mother_name = nameMotherXTextBox.Text;
            dak.address = presentAddressXTextBox.Text;
            dak.parmanent_address = permenantAddressXTextBox.Text;
            dak.email = emailXTextBox.Text;
            dak.mobile_no = mobileXTextBox.Text;
            //dak.nationality = searchNationalityUserController1.searchButtonText.ToString();
            if(otherNationalityLabel.Visible)
            {
                dak.nationality = otherNationalityTextBox.Text;
            }
            else
            {
                dak.nationality = searchNationalityUserController.SelectedItem.ToString();
            }
            //dak.gender = genderSearchButton.searchButtonText.ToString();
            dak.gender = genderSearchButton1.SelectedItem.ToString();
            //dak.religion = searchReligionUserController.searchButtonText.ToString();
            dak.religion = searchReligionUserController1.SelectedItem.ToString();




            dak.dak_subject = subjectXTextBox.Text;
            dak.id = _dakId;
            dak.dak_description = dakDescriptionXTextBox.Text;





            DakPriorityList dakPriority = new DakPriorityList();
            //int dak_priority_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.searchButtonText.ToString()));
            int dak_priority_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton1.SelectedItem.ToString()));




            DakSecurityList dakSecurityList = new DakSecurityList();
            //int dak_security_id = Convert.ToInt32(dakSecurityList.GetDakSecuritiesId(seurityLevelSearchButton.searchButtonText.ToString()));
            int dak_security_id = Convert.ToInt32(dakSecurityList.GetDakSecuritiesId(seurityLevelSearchButton1.SelectedItem.ToString()));

            dak.priority = dak_priority_id.ToString();
            //dak.dak_priority = prioritySearchButton.ToString();
            dak.dak_priority = prioritySearchButton1.SelectedItem.ToString();
            dak.security = dak_security_id.ToString();
            //dak.dak_security = seurityLevelSearchButton.ToString();
            dak.dak_security = seurityLevelSearchButton1.SelectedItem.ToString();


            dakUploadParameter.dak_info = dakUploadParameter.CSharpObjtoJson(dak);
            dakUploadParameter.dak_Info_Obj = dak;

            // Receiver
            DakUploadReceiver dakUploadReceiver = new DakUploadReceiver();
            if (!isOwnDesk)
            {


                ViewDesignationSealList mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);

                if (mulprapok.nij_Office == true)
                {
                    var receiver_info = designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                    dakUploadReceiver.mul_prapok = receiver_info;
                }
                else
                {
                    var receiver_info = designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                    dakUploadReceiver.mul_prapok = receiver_info;
                }

            }
            else
            {
                dakUploadReceiver.mul_prapok = UIDesignCommonMethod.GetMulPrapokForOwnDesk(_dak_List_User_Param);

            }

            prapokName = dakUploadReceiver.mul_prapok.officer_name + " ," + dakUploadReceiver.mul_prapok.designation_bng + "," + dakUploadReceiver.mul_prapok.unit_name_bng + "," + dakUploadReceiver.mul_prapok.office_bng;


            // onulipi
            List<PrapokDTO> OnulipiprapokDTOs = new List<PrapokDTO>();

            List<ViewDesignationSealList> viewDesignationSealListsOnulipPrapok = viewDesignationSealLists.Where(a => a.onulipi_prapok == true).ToList();
           if(viewDesignationSealListsOnulipPrapok.Count>0)
            {
                foreach (ViewDesignationSealList viewDesignationSeal in viewDesignationSealListsOnulipPrapok)
                {
                    if (viewDesignationSeal.nij_Office == true)
                    {
                        OnulipiprapokDTOs.Add(designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                    }
                    else
                    {
                        OnulipiprapokDTOs.Add(designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                    }
                }

            }
            dakUploadReceiver.onulipi = OnulipiprapokDTOs.ToDictionary(a => a.designation_id.ToString());








            dakUploadParameter.receiver_info = dakUploadParameter.CSharpObjtoJson(dakUploadReceiver);
            dakUploadParameter.others = "[]";
            // dakUploadParameter.path = sendMediumSearchButton.searchButtonText;
            dakUploadParameter.content = dakDescriptionXTextBox.Text;
            dakUploadParameter.office_id = _dak_List_User_Param.office_id;
            dakUploadParameter.designation_id = _dak_List_User_Param.designation_id;

        }
        public void setDataGridViewColumnWidth()
        {
            prapokDataGridView.Columns[6].FillWeight = (prapokDataGridView.Width * 50) / 100;
            prapokDataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            prapokDataGridView.Columns[6].Width = (prapokDataGridView.Width * 50) / 100;
            prapokDataGridView.Columns[7].FillWeight = (prapokDataGridView.Width * 20) / 100;

            prapokDataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            prapokDataGridView.Columns[7].Width = (prapokDataGridView.Width * 20) / 100;
            prapokDataGridView.Columns[9].FillWeight = (prapokDataGridView.Width * 10) / 100;
            prapokDataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            prapokDataGridView.Columns[9].Width = (prapokDataGridView.Width * 10) / 100;
            prapokDataGridView.Columns[10].FillWeight = (prapokDataGridView.Width * 10) / 100;
            prapokDataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            prapokDataGridView.Columns[10].Width = (prapokDataGridView.Width * 10) / 100;
        }
        public event EventHandler AddDesignationButtonClick;
        private void addDesignationButton_Click(object sender, EventArgs e)
        {

            if (this.AddDesignationButtonClick != null)
                this.AddDesignationButtonClick(sender, e);

        }
        public event EventHandler DakSendButton;
        private void sendButton_Click(object sender, EventArgs e)
        {

            if (!NagorikDakSaveAndSendValidation(false))
            {
                return;
            }
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি প্রেরণ করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {

                
                SetDakUploadData(false);


                if (this.DakSendButton != null)
                    this.DakSendButton(sender, e);
            }
            else
            {

            }

        }
        private bool NagorikDakSaveAndSendValidation(bool isOwnDesk)
        {


            // Mulpotro
            List<DakUploadAttachment> dakUploadAttachments = new List<DakUploadAttachment>();

            var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

            if (!attachmentList.Any(a => a.isMulpotro == true))
            {
                fileUploadPanel.Focus();
                ShowAlertMessage(MessageBoxMessage.mulpotroNotSelectErrorMessage);
                return false;
            }



            if (nationalIdXTextBox.Text.Length != 10 && nationalIdXTextBox.Text.Length != 13 && nationalIdXTextBox.Text.Length != 17 && !string.IsNullOrEmpty(nationalIdXTextBox.Text))
            {

                nationalIdXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.natioanlIdNotGivenSpedifiedDegitErrorMessage);
                return false;
            }
            if (birthCertificateNoXTextBox.Text.Length != 17 && !string.IsNullOrEmpty(birthCertificateNoXTextBox.Text))
            {

                birthCertificateNoXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.birthCertificateNotGiven17ErrorMessage);
                return false;
            }
             
            if (mobileXTextBox.Text.Length != 11 && !string.IsNullOrEmpty(mobileXTextBox.Text))
            {

                mobileXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.mobileNoNotGiven11DigitErrorMessage);
                return false;
            }

            if (string.IsNullOrEmpty(nameBanglaXTextBox.Text))
            {

                nameBanglaXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.nameBengaliNotGivenErrorMessage);
                return false;
            }

            if (string.IsNullOrEmpty(presentAddressXTextBox.Text))
            {

                presentAddressXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.presentAddressNotGivenErrorMessage);
                return false;
            }

            if (string.IsNullOrEmpty(permenantAddressXTextBox.Text))
            {

                permenantAddressXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.permenantAddressNotGivenErrorMessage);
                return false;
            }

            if (string.IsNullOrEmpty(subjectXTextBox.Text))
            {

                subjectXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.subjectNotGivenErrorMessage);
                return false;
            }
           if(!isOwnDesk)
            {
                var mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);
                if (mulprapok == null)
                {
                    ShowAlertMessage(MessageBoxMessage.mulPrapokNotSelectErrorMessage);
                    return false;
                }
            }

            return true;

        }
        private void sameAsPresentAddressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            permenantAddressXTextBox.Text = presentAddressXTextBox.Text.ToString(); ;
        }

        private void nationalIdXTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {



            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                char ch = (char)('0' + e.KeyChar - '\u09E6');
                if (!char.IsDigit(ch))
                {
                    e.Handled = true;
                }

            }

            else if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length == 17)
            {
                e.Handled = true;
            }
        }


        private void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {

            UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
            alertMessageBox.message = mulpotroNotSelectErrorMessage;
            alertMessageBox.ShowDialog();
        }
        private void passportNoXTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && passportNoXTextBox.Text.Length >= 2)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                   
                        e.Handled = true;
                    

                }
                else if(!char.IsControl(e.KeyChar) && passportNoXTextBox.Text.Length >= 9)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsUpper(e.KeyChar))
                {
                    e.Handled = true;
                }
                
            }
            
         
        }

        private void mobileXTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                char ch = (char)('0' + e.KeyChar - '\u09E6');
                if (!char.IsDigit(ch))
                {
                    e.Handled = true;
                }

            }

            else if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length == 11)
            {
                e.Handled = true;
            }
        }

        private void nameBanglaXTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;
            var regexItem = new Regex("^[a-zA-Z0-9$@$!%*?&#^-_.+`\b]+$");
            string pressedChar = inputChar.ToString();
            if (!char.IsControl(e.KeyChar) && regexItem.IsMatch(pressedChar))
            {
                e.Handled = true;

            }
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ownDeskSendButton_Click(object sender, EventArgs e)
        {
            if (!NagorikDakSaveAndSendValidation(true))
            {
                return;
            }
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি প্রেরণ করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {


                SetDakUploadData(true);


                if (this.DakSendButton != null)
                    this.DakSendButton(sender, e);
            }
            else
            {

            }
        }

        private void searchNationalityUserController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(searchNationalityUserController.Text== "অন্যান্য")
            {
                otherNationalityPanel.Visible = otherNationalityLabel.Visible = true;
            }
            else
            {
                otherNationalityPanel.Visible = otherNationalityLabel.Visible = false;
            }
        }
    }
}

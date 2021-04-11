using dNothi.Core.Entities;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Desktop.UI.OtherModule;
using dNothi.Desktop.View_Model;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class Dashboard : Form
    {
        private DakUserParam dakListUserParam = new DakUserParam();

        private PictureBox pb;
        private bool _isDakUploaded;

        public int pageStart = 0;
        public int pageEnd = 0;
        public int pageNumber = 0;

        public string dak_category = "";




        public string dak_security = "";
        public string dak_priority = "";
        public string last_modified_date = "";
        public string dak_type = "";
        public string potro_type = "";
        public string dak_view_status = "";

        public DateTime dateFrom = new DateTime();
        public DateTime dateTo = new DateTime();

        public DakUserDTO _dak_user { get; set; }
        public DakOriginDTO _dak_origin { get; set; }
        public MovementStatusDTO _movement_status { get; set; }
        public List<DakTagDTO> _dak_Tags { get; set; }
        public NothiDTO nothi { get; set; }
        public WaitFormFunc WaitForm;


        IUserService _userService { get; set; }
        IRegisterService _registerService { get; set; }
        IDakFolderService _dakFolderService { get; set; }
        IDakSearchService _dakSearchService { get; set; }
        IProtibedonService _protibedonService { get; set; }
        IDesignationSealService _designationSealService { get; set; }

        private DakUserParam _dakuserparam = new DakUserParam();
        IDakKhosraService _dakkhosraservice { get; set; }
        IDakListService _dakListService { get; set; }
        IDakOutboxService _dakOutboxService { get; set; }
        IDakUploadService _dakuploadservice { get; set; }
        IDakInboxServices _dakInbox { get; set; }

        IDakArchiveService _dakArchiveService { get; set; }
        IDakNothijatoService _dakNothijatoService { get; set; }

        IDakNothivuktoService _dakNothivuktoService { get; set; }
        IDakListSortedService _dakListSortedService { get; set; }
        IDakForwardService _dakForwardService { get; set; }
        public DakCatagoryList _currentDakCatagory { get; set; }

        public Dashboard(IDakInboxServices dakInbox,
            IUserService userService,
            IDakOutboxService dakOutboxService,
            IDakNothivuktoService dakNothivuktoService,
            IDakArchiveService dakListArchiveService,
            IDakListService dakListService,
            IDakListSortedService dakListSortedService,
            IDakForwardService dakForwardService,
            IDakKhosraService dakKhosraService,
            IDakUploadService dakUploadService,
            IDesignationSealService designationSealService,
            IDakSearchService dakSearchService,
            IRegisterService registerService,
             IDakFolderService dakFolderService,
             IProtibedonService protibedonService,
            IDakNothijatoService dakNothijatoService)
        {
            _dakNothivuktoService = dakNothivuktoService;
            _userService = userService;
            _dakSearchService = dakSearchService;
            _registerService = registerService;
            _designationSealService = designationSealService;
            _dakOutboxService = dakOutboxService;
            _dakInbox = dakInbox;
            _dakArchiveService = dakListArchiveService;
            _dakNothijatoService = dakNothijatoService;
            _dakListService = dakListService;
            _dakListSortedService = dakListSortedService;
            _dakForwardService = dakForwardService;
            _dakkhosraservice = dakKhosraService;
            _dakuploadservice = dakUploadService;
            _protibedonService = protibedonService;
            _currentDakCatagory = new DakCatagoryList();
            _dakFolderService = dakFolderService;
            InitializeComponent();




            pb = new PictureBox();

            pb.Dock = DockStyle.Fill;
            WaitForm = new WaitFormFunc();



        }
        private void Blur()
        {
            //Bitmap bmp = Screenshot.TakeSnapshot(dashBoardBlurPanel);
            //BitmapFilter.GaussianBlur(bmp,1);

            //pb.Image = bmp;
            //dashBoardBlurPanel.BringToFront();
        }

        private void UnBlur()
        {
            pb.Image = null;
            //  dashBoardBlurPanel.SendToBack();
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
        public OCRResponse OCRFile(OCRParameter oCRParameter)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();



            OCRResponse oCRResponse = _dakuploadservice.GetOCRResponsse(dakListUserParam, oCRParameter);


            return oCRResponse;
        }
        public DakFileDeleteResponse DeleteFile(DakUploadFileDeleteParam deleteParam)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();



            DakFileDeleteResponse deleteResponse = _dakuploadservice.GetFileDeleteResponsse(dakListUserParam, deleteParam);


            return deleteResponse;
        }



        public DakUploadedFileResponse UploadFile(DakFileUploadParam dakFileUploadParam)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();



            DakUploadedFileResponse dakUploadedFileResponse = _dakuploadservice.GetDakUploadedFile(dakListUserParam, dakFileUploadParam);



            return dakUploadedFileResponse;
        }
        protected void UserControl_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak, DakListRecordsDTO dak, DakCatagoryList category)
        {
            string s = (sender as Control).Name;

            if (s == "dakMovementStatusButton")
            {
                GetDakMovementList(dak_id, dak_type, is_copied_dak, dak);
            }

            else if (s == "DakSendButton")
            {
                DakSendButtonClicked(dak_id, dak_type, is_copied_dak, dak_subject, dak);
            }

            else
            {




                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


                DakDetailsResponse dakDetailsResponse = _dakListService.GetDakDetailsbyDakId(dak_id, dak_type, is_copied_dak, dakListUserParam);

                detailsFlowLayoutPanel.Controls.Clear();


                if (dakDetailsResponse != null)
                {
                    if (dakDetailsResponse.data != null)
                    {
                        dakSortMetroPanel.Visible = false;
                        bodyTableLayoutPanel.RowStyles[6] = new RowStyle(SizeType.AutoSize);
                        searchHeaderTableLayoutPanel.Visible = false;
                        bodyPanel.Visible = false;
                        detailsFlowLayoutPanel.Visible = true;
                        detailsFlowLayoutPanel.BringToFront();


                        DetailsDakUserControl detailsDakUserControl = new DetailsDakUserControl();
                        if (dakDetailsResponse.data.dak_user != null)
                        {
                            //dakDetailsResponse.data.dak_user.
                            detailsDakUserControl.dakid = dakDetailsResponse.data.dak_user.dak_id;
                            detailsDakUserControl.subject = dakDetailsResponse.data.dak_user.dak_subject;
                            detailsDakUserControl.decision = dakDetailsResponse.data.dak_user.dak_decision;
                            detailsDakUserControl.sharokNo = dakDetailsResponse.data.dak_origin.sender_sarok_no;
                            detailsDakUserControl.docketingNo = dakDetailsResponse.data.dak_origin.docketing_no;
                            detailsDakUserControl.date = dakDetailsResponse.data.dak_user.last_movement_date;


                            detailsDakUserControl.attentionTypeIconValue = dakDetailsResponse.data.dak_user.attention_type;
                            detailsDakUserControl.dakSecurityIconValue = dakDetailsResponse.data.dak_user.dak_security;
                            detailsDakUserControl.dakPrioriy = dakDetailsResponse.data.dak_user.dak_priority;
                            detailsDakUserControl.dakType = dakDetailsResponse.data.dak_user.dak_type;
                            detailsDakUserControl.potrojari = dakDetailsResponse.data.dak_user.from_potrojari;
                            detailsDakUserControl.dakAttachmentCount = dakDetailsResponse.data.attachment_count;
                            detailsDakUserControl.dakDetailsResponse = dakDetailsResponse;
                            detailsDakUserControl.dakCatagory = category;
                            detailsDakUserControl.ButtonClick += delegate (object se, EventArgs ev) { UserControl_ButtonClick(se, ev, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak, dakDetailsResponse.data, category); };
                            detailsDakUserControl.NothiteUposthapitoButtonClick += delegate (object se, EventArgs ev) { NothiteUposthapito_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };
                            detailsDakUserControl.DakArchiveButtonClick += delegate (object se, EventArgs ev) { DakArchive_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };
                            detailsDakUserControl.NothijatoButtonClick += delegate (object se, EventArgs ev) { Nothitejato_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };
                            detailsDakUserControl.BackButtonClick += delegate (object se, EventArgs ev) { DetailsBack_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };
                            if (_currentDakCatagory.isArchived)
                            {
                                detailsDakUserControl.RevertButtonClick += delegate (object se, EventArgs ev) { DakArchiveRevert_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };

                            }
                            else if (_currentDakCatagory.isNothijato)
                            {
                                detailsDakUserControl.RevertButtonClick += delegate (object se, EventArgs ev) { NothijatoRevert_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };

                            }
                            else if (_currentDakCatagory.isNothivukto)
                            {
                                detailsDakUserControl.RevertButtonClick += delegate (object se, EventArgs ev) { DakNothivuktoRevert_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };

                            }
                            else if (_currentDakCatagory.isOutbox)
                            {
                                detailsDakUserControl.RevertButtonClick += delegate (object se, EventArgs ev) { DakForwardRevert_ButtonClick(sender, e, detailsDakUserControl.dakid, dakDetailsResponse.data.dak_user.dak_type, dakDetailsResponse.data.dak_user.dak_subject, dakDetailsResponse.data.dak_user.is_copied_dak); };

                            }

                            try
                            {
                                detailsDakUserControl.officerName = dakDetailsResponse.data.movement_status.from.officer;

                                if (dakDetailsResponse.data.movement_status.from.designation != "")
                                {
                                    detailsDakUserControl.officerDesignation = "(" + dakDetailsResponse.data.movement_status.from.designation + ")";

                                }
                                else
                                {
                                    detailsDakUserControl.officerDesignation = "";

                                }
                                detailsDakUserControl.officeName = dakDetailsResponse.data.movement_status.from.office;

                            }
                            catch
                            {

                            }


                            if (_currentDakCatagory.isInbox)
                            {
                                if (dakDetailsResponse.data.dak_user.attention_type == "0")
                                {
                                    detailsDakUserControl.isOnulipi = true;
                                }
                            }
                            // Attachment Call
                            DakAttachmentResponse dakAttachmentResponse = _dakListService.GetDakAttachmentbyDakId(dak_id, dak_type, is_copied_dak, dakListUserParam);
                            if (dakAttachmentResponse != null)
                            {
                                if (dakAttachmentResponse.data != null)
                                {

                                    detailsDakUserControl.dakAttachmentResponse = dakAttachmentResponse;
                                    // string attachmentjson = new JavaScriptSerializer().Serialize(detailsDakUserControl.dakAttachmentResponse.data);

                                }
                            }

                            //string jsondetails = new JavaScriptSerializer().Serialize(dakDetailsResponse.data); 
                            detailsDakUserControl.Dock = DockStyle.Fill;
                            detailsFlowLayoutPanel.Controls.Add(detailsDakUserControl);

                        }
                    }

                    if(!InternetConnection.Check())
                    {
                        ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা! ");
                    }
                }
            }

        }

        private void DetailsBack_ButtonClick(object sender, EventArgs e, int dakid, string dak_type, string dak_subject, int is_copied_dak)
        {

            // detailsFlowLayoutPanel.BringToFront();
            NormalizeDashBoard();
        }

        private void DakSendButtonClicked(int dak_id, string dak_type, int is_copied_dak, string dak_subject, DakListRecordsDTO dak)
        {




            var dakSendUserControl = FormFactory.Create<DakForwardUserControl>();

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakSendUserControl.designationSealListResponse = designationSealListResponse;
            dakSendUserControl.dak_id = dak_id;
            dakSendUserControl.dak_subject = dak_subject;
            dakSendUserControl.dak_type = dak_type;
            dakSendUserControl.is_copied_dak = is_copied_dak;
            dakSendUserControl.dak_List_User_Param = dakListUserParam;
            dakSendUserControl.dakPrioriy = dak.dak_user.dak_priority;
            dakSendUserControl.dakSecurityIconValue = dak.dak_user.dak_security;

            dakSendUserControl.ButtonClick += delegate (object sender, EventArgs e) { sliderCrossButton_Click(sender, e); };
            dakSendUserControl.AddDesignationButtonClick += delegate (object sender, EventArgs e) { AddDesignationFromForwardWindow_ButtonClick(dakSendUserControl); };
            dakSendUserControl.SucessfullyDakForwarded += delegate (object sender, EventArgs e) { SuccessfullySingleDakForwarded(false, 0, 0, 0,dakSendUserControl._IsDakLocallyUploaded); };


            CalPopUpWindow(dakSendUserControl);


        }

        private void AddDesignationFromForwardWindow_ButtonClick(DakForwardUserControl dakSendUserControl)
        {
            var form = FormFactory.Create<AddDesignationSeal>();

            CalPopUpWindow(form);

            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(_dakuserparam);


            dakSendUserControl.designationSealListResponse = designationSealListResponse;



        }

        private void SuccessfullySingleDakForwarded(bool v, int req, int success, int fail, bool _IsDakLocallyUploaded)
        {
            if(_IsDakLocallyUploaded)
            {
                LoadDakInbox();
            }
            else
            {
                LoadDakOutbox();
            }
           
        }

        private void GetDakMovementList(int dak_id, string dak_type, int is_copied_dak, DakListRecordsDTO dak)
        {

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DakMovementStatusResponse dakMovementStatusResponse = _dakListService.GetDakMovementStatusListbyDakId(dak_id, dak_type, is_copied_dak, dakListUserParam);
            DakMovementDetailsForm dakMovementDetailsForm = new DakMovementDetailsForm();


            if (dakMovementStatusResponse != null)
            {
                if (dakMovementStatusResponse.data != null)
                {

                    if (dakMovementStatusResponse.data.records != null)
                    {
                        foreach (MovementStatusDTO movementStatusDTO in dakMovementStatusResponse.data.records)
                        {

                            MovementStatusLeftSidePicUserControl movementStatusLeftSidePicUserControl = new MovementStatusLeftSidePicUserControl();

                            movementStatusLeftSidePicUserControl.movementStatusDTO = movementStatusDTO;
                            movementStatusLeftSidePicUserControl.decision = movementStatusDTO.other.dak_actions;
                            movementStatusLeftSidePicUserControl.date = movementStatusDTO.other.last_movement_date;
                            movementStatusLeftSidePicUserControl.dakPrioriy = movementStatusDTO.other.dak_priority.ToString();
                            movementStatusLeftSidePicUserControl.dakSecurityIconValue = movementStatusDTO.other.dak_security_level;



                            dakMovementDetailsForm.dashboardRightSideFlowLayoutPanel.Controls.Add(movementStatusLeftSidePicUserControl);
                        }

                    }
                }
            }
            CalPopUpWindow(dakMovementDetailsForm);



        }
        void DisabledOtherControlExceptLeftPopUpPanel(System.Windows.Forms.Control.ControlCollection collection)
        {

            foreach (Control ctrl in collection)
            {
                if (ctrl.Name == "dashboardRightSideDisplaypanel")
                {
                    continue;
                }

                ctrl.Enabled = false;
                DisabledOtherControlExceptLeftPopUpPanel(ctrl.Controls);
            }

        }
        void EnableOtherControlExceptLeftPopUpPanel(System.Windows.Forms.Control.ControlCollection collection, Control control)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl.Name == control.Name)
                {
                    continue;
                }

                ctrl.Enabled = true;
                EnableOtherControlExceptLeftPopUpPanel(ctrl.Controls, control);
            }

        }
        public Dashboard(List<DakListRecordsDTO> dakLists)
        {
            InitializeComponent();
            HideSubmenu();
            detailsDakSearcPanel.Visible = false;

            LoadReadDakComboBox();
        }

        private void LoadReadDakComboBox()
        {
            searchDakStatusComboBox.SelectedIndex = comboBox1.Items.IndexOf("সকল");
        }

        private void HideSubmenu()
        {
            dakUploadDropDownPanel.Visible = false;
        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.dakSearchButton.ForeColor = Color.DodgerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.dakSearchButton.ForeColor = Color.Black;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.dakInboxButton.ForeColor = Color.DodgerBlue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.dakInboxButton.ForeColor = Color.Black;
        }
        private void button16_MouseHover(object sender, EventArgs e)
        {
            this.dakSortButton.ForeColor = Color.DodgerBlue;
        }
        private void button16_MouseLeave(object sender, EventArgs e)
        {
            this.dakSortButton.ForeColor = Color.Black;
        }
        private void button5_MouseHover(object sender, EventArgs e)
        {
            this.dakNotivuktoButton.ForeColor = Color.DodgerBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.dakNotivuktoButton.ForeColor = Color.Black;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.dakNothijatoButton.ForeColor = Color.DodgerBlue;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.dakNothijatoButton.ForeColor = Color.Black;
        }

        private void button10_MouseHover_1(object sender, EventArgs e)
        {
            this.dakUploadButton.ForeColor = Color.DodgerBlue;
        }

        private void button10_MouseLeave_1(object sender, EventArgs e)
        {
            this.dakUploadButton.ForeColor = Color.Black;
        }



        private void button18_MouseHover(object sender, EventArgs e)
        {
            this.dakArchiveButton.ForeColor = Color.DodgerBlue;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            this.dakArchiveButton.ForeColor = Color.Black;
        }

        private void label1_Resize(object sender, EventArgs e)
        {
            this.moduleDakCountLabel.Size = new System.Drawing.Size(19, 20);
            this.moduleDakCountLabel.AutoSize = true;
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            this.moduleDakCountLabel.Size = new System.Drawing.Size(19, 20);
        }






        private void button13_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }






        private void LoadDakOutbox()
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakOutboxButton);
            NormalizeDashBoard();
            _currentDakCatagory.isOutbox = true;
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            // Satic Class
            dakListUserParam.limit = NothiCommonStaticValue.pageLimit;
            dakListUserParam.page = pageNumber;

            DakListOutboxResponse dakListOutboxResponse = _dakOutboxService.GetDakOutbox(dakListUserParam);

            List<DakListRecordsDTO> dakListRecordsDTOs = new List<DakListRecordsDTO>();
           
            if (pageNumber == 1)
            {
                dakListRecordsDTOs = _dakuploadservice.GetPendingDakUpload(false);
                if (dakListRecordsDTOs.Count > 0)
                {
                    foreach (DakListRecordsDTO dakListRecordsDTO in dakListRecordsDTOs)
                    {
                     
                        LoadDakSingleOutboxinPanel(dakListRecordsDTO);
                    }
                }

            }




            if (dakListOutboxResponse!=null && dakListOutboxResponse.status == "success")
            {

                if (dakListOutboxResponse.data.records.Count > 0)
                {
                    Pagination(dakListOutboxResponse.data.records.Count, dakListOutboxResponse.data.total_records);

                    LoadDakOutboxinPanel(dakListOutboxResponse.data.records);
                    return;
                }


            }



            if (dakListRecordsDTOs.Count <= 0)
            {
                noDakTableLayoutPanel.Visible = true;
            }
        }
        private void LoadDakOutboxUsingSearchParam(string searchParam)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakOutboxButton);
            NormalizeDashBoard();
            _currentDakCatagory.isOutbox = true;
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            // Satic Class
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;

            dakBodyFlowLayoutPanel.Controls.Clear();
            DakListOutboxResponse dakListOutboxResponse = _dakOutboxService.GetDakOutbox(dakListUserParam, searchParam);
            
         

         
            if (dakListOutboxResponse.status == "success")
            {

                if (dakListOutboxResponse.data.records.Count > 0)
                {
                    LoadDakOutboxinPanel(dakListOutboxResponse.data.records);
                    return;
                }
                    

            }
           


            
                noDakTableLayoutPanel.Visible=true;
            
                


           
        }

        private void LoadDakOutboxinPanel(List<DakListRecordsDTO> dakLists)
        {

            


            List<DakOutboxUserControl> dakOutboxUserControls = new List<DakOutboxUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {


                DakOutboxUserControl dakOutboxUserControl = new DakOutboxUserControl();
                dakOutboxUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);


                dakOutboxUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;


                dakOutboxUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;

                dakOutboxUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                //dakOutboxUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;

                dakOutboxUserControl.sender = dakListInboxRecordsDTO.dak_origin.sender_name;


                dakOutboxUserControl.receiver = dakListInboxRecordsDTO.dak_origin.receiving_officer_name;
                dakOutboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakOutboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakOutboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakOutboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakOutboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakOutboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;

                DakCatagoryList dakCatagoryList = new DakCatagoryList();
                dakCatagoryList.isOutbox = true;

                dakOutboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };

                dakOutboxUserControl.RevertButtonClick += delegate (object sender, EventArgs e) { DakForwardRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakOutboxUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakOutboxUserControl.DakArchiveButtonClick += delegate (object sender, EventArgs e) { DakArchive_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakOutboxUserControl.NothijatoButtonClick += delegate (object sender, EventArgs e) { Nothitejato_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakOutboxUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                i = i + 1;
                dakOutboxUserControls.Add(dakOutboxUserControl);

            }
           
            //dakBodyFlowLayoutPanel.AutoScroll = true;


            for (int j = 0; j <= dakOutboxUserControls.Count - 1; j++)
            {
                dakOutboxUserControls[j].Dock = DockStyle.Fill;
                int row = dakBodyFlowLayoutPanel.RowCount++;
                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                dakBodyFlowLayoutPanel.Controls.Add(dakOutboxUserControls[j], 0, row);

            }
        }

        private void LoadDakSingleOutboxinPanel(DakListRecordsDTO dakListInboxRecordsDTO)
        {



            DakOutboxUserControl dakOutboxUserControl = new DakOutboxUserControl();
            dakOutboxUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);


            dakOutboxUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;


            dakOutboxUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;

            dakOutboxUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;

            dakOutboxUserControl.sender = dakListInboxRecordsDTO.dak_origin.sender_name;


            dakOutboxUserControl.receiver =dakListInboxRecordsDTO.dak_origin.receiving_officer_name;
            dakOutboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
            dakOutboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
            dakOutboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
            dakOutboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
            dakOutboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
            dakOutboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
            dakOutboxUserControl.DakResendButton += delegate (object sender, EventArgs e) { DakResndButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            dakCatagoryList.isOutbox = true;

           
            if(dakListInboxRecordsDTO.dak_user.last_movement_date=="")
            {
                dakOutboxUserControl.isOfflineDak = true;
            }
            else
            {
                dakOutboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };
                dakOutboxUserControl.RevertButtonClick += delegate (object sender, EventArgs e) { DakForwardRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakOutboxUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakOutboxUserControl.DakArchiveButtonClick += delegate (object sender, EventArgs e) { DakArchive_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakOutboxUserControl.NothijatoButtonClick += delegate (object sender, EventArgs e) { Nothitejato_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                dakOutboxUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

            }


            UIDesignCommonMethod.AddRowinTable(dakBodyFlowLayoutPanel, dakOutboxUserControl);

           

        }

        private void DakResndButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak)
        {
            if (_dakuploadservice.UploadDakFromLocal(dak_id))
            {
                LoadDakOutbox();
            }
            else
            {
                ErrorMessage("ইন্টারনেট সংযোগের কারণে আপলোড ব্যর্থ হয়েছে!");
            }

           

        }

        private string GetDakListMainReceiverName(MovementStatusDTO movementStatusDTO)
        {
            try
            {
                ToDTO toDTOs = movementStatusDTO.to.FirstOrDefault(a => a.attention_type == "1" && a.designation_id != movementStatusDTO.from.designation_id);
                return toDTOs?.officer;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string IsNagorikDakType(string dak_type, string sender_name, string name_bng)
        {
            CheckNagorikDakType checkNagorikDakType = new CheckNagorikDakType(dak_type);
            if (checkNagorikDakType.IsNagarik)
            {
                return name_bng;
            }
            else
            {
                return sender_name;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            //dakUploadBackgorundWorker.RunWorkerAsync();
            dateFrom = DateTime.Now;
            dateTo = DateTime.Now;

            _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            LoadDakPriority();
            LoadDakSecurite();
            LoadDakType();
            LoadPotroTemplate();
            LoadDakStatus();
            LoadThirtPartyService();

        }

        private void LoadThirtPartyService()
        {
            ThirdPartyServiceList thirdParty = new ThirdPartyServiceList();

            searchThirdPartyComboBox.DataSource = null;

            searchThirdPartyComboBox.DataSource = thirdParty.thirdPartyServices.OrderBy(a => a._id).ToList();
            searchThirdPartyComboBox.DisplayMember = "_typeName";
            searchThirdPartyComboBox.ValueMember = "_id";

        }

        private void LoadDakStatus()
        {
            DakStatusList dakStatus = new DakStatusList();
            dakStatusComboBox.DataSource = null;
            searchDakStatusComboBox.DataSource = null;
            dakStatusComboBox.DataSource = dakStatus._dakStatus.OrderBy(a => a._id).ToList();
            searchDakStatusComboBox.DataSource = dakStatus._dakStatus.OrderBy(a => a._id).ToList();
            dakStatusComboBox.DisplayMember = "_typeName"; searchDakStatusComboBox.DisplayMember = "_typeName";
            dakStatusComboBox.ValueMember = "_id"; searchDakStatusComboBox.ValueMember = "_id";

        }

        private void LoadPotroTemplate()
        {
            PotroTemplateResponse potroTemplateResponse = _dakListService.GetPotroTemplate(_dakuserparam);
            if (potroTemplateResponse !=null && potroTemplateResponse.status == "success")
            {
                if (potroTemplateResponse.data.Count > 0)
                {
                    PotroTemplateDTO potroTemplateDTO = new PotroTemplateDTO();
                    potroTemplateDTO.id = 0;
                    potroTemplateDTO.template_name = "পত্রের ধরন";
                    potroTemplateResponse.data.Add(potroTemplateDTO);


                    searchDakPotroTypeComboBox.DataSource = null;
                    searchDakPotroTypeComboBox.DataSource = potroTemplateResponse.data.OrderBy(a => a.id).ToList();
                    searchDakPotroTypeComboBox.DisplayMember = "template_name";
                    searchDakPotroTypeComboBox.ValueMember = "id";
                }
            }
        }

        private void LoadDakType()
        {
            DakTypeList dakTypeList = new DakTypeList();
            dakTypeComboBox.DataSource = null;
            searchDakTypeComboBox.DataSource = null;
            dakTypeComboBox.DataSource = dakTypeList._dakTypes.OrderBy(a => a._id).ToList();
            searchDakTypeComboBox.DataSource = dakTypeList._dakTypes.OrderBy(a => a._id).ToList();
            dakTypeComboBox.DisplayMember = searchDakTypeComboBox.DisplayMember = "_typeName";
            dakTypeComboBox.ValueMember = searchDakTypeComboBox.ValueMember = "_id";

        }

        private void LoadDakSecurite()
        {
            DakSecurityList dakSecurityList = new DakSecurityList(true);
            searchDakSecurityComboBox.DataSource = null;
            dakSecretComboBox.DataSource = null;

            dakSecretComboBox.DataSource = searchDakSecurityComboBox.DataSource = dakSecurityList._dakSecurities.OrderBy(a => a._id).ToList();
            dakSecretComboBox.DisplayMember = "_typeName";
            searchDakSecurityComboBox.DisplayMember = "_typeName";
            dakSecretComboBox.ValueMember = "_id";
            searchDakSecurityComboBox.ValueMember = "_id";

        }

        private void LoadDakPriority()
        {
            DakPriorityList dakPriorityList = new DakPriorityList(true);
            dakPriorityComboBox.DataSource = null;
            searchDakPriorityComboBox.DataSource = null;
            dakPriorityComboBox.DataSource = dakPriorityList._dakPriority.OrderBy(a => a._id).ToList();
            searchDakPriorityComboBox.DataSource = dakPriorityList._dakPriority.OrderBy(a => a._id).ToList();
            searchDakPriorityComboBox.DisplayMember = dakPriorityComboBox.DisplayMember = "_typeName";
            searchDakPriorityComboBox.ValueMember = dakPriorityComboBox.ValueMember = "_id";
        }

        private async void LoadDakInbox()
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakInboxButton);

            NormalizeDashBoard();
            selectDakBoxHolderPanel.Visible = true;
            _currentDakCatagory.isInbox = true;


            dakListUserParam.limit = NothiCommonStaticValue.pageLimit;
            dakListUserParam.page = pageNumber;

            try
            {
                var dakInbox = await Task.Run(() => _dakInbox.GetDakInbox(dakListUserParam));
                if (dakInbox.status == "success")
                {


                    _dakInbox.SaveorUpdateDakInbox(dakInbox);
                    if (dakInbox.data.records.Count > 0)
                    {
                        Pagination(dakInbox.data.records.Count, dakInbox.data.total_records);
                        LoadDakInboxinPanel(dakInbox.data.records);
                        return;

                    }


                }
            }
            catch
            {


            }

            noDakTableLayoutPanel.Visible = true;

            //try
            //{
            //    // var dakInbox = await Task.Run(() => _dakInbox.GetDakInbox(dakListUserParam));
            //    var dakInbox = _dakListService.GetDakList();

            //    if (dakInbox.Any(a => a.dak_user.dak_category == "Inbox"))
            //    {




            //        LoadLocalDakInboxinPanel(dakInbox.Where(a=>a.dak_user.dak_category=="Inbox").ToList());

            //    }
            //    else
            //    {
            //        noDakTableLayoutPanel.Visible = true;
            //    }


            //}
            //catch
            //{
            //    noDakTableLayoutPanel.Visible = true;

            //}


        }
        private async void LoadDakInboxUsingSearchParam(string searchParam)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakInboxButton);

            NormalizeDashBoard();
            selectDakBoxHolderPanel.Visible = true;
            _currentDakCatagory.isInbox = true;

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;



            try
            {
                var dakInbox = await Task.Run(() => _dakInbox.GetDakInbox(dakListUserParam, searchParam));
                if (dakInbox.status == "success")
                {


                    _dakInbox.SaveorUpdateDakInbox(dakInbox);
                    if (dakInbox.data.records.Count > 0)
                    {

                        LoadDakInboxinPanel(dakInbox.data.records);

                    }
                    else
                    {
                        noDakTableLayoutPanel.Visible = true;
                    }

                }
            }
            catch
            {
                noDakTableLayoutPanel.Visible = true;

            }


        }
        private void LoadLocalDakInboxinPanel(List<DakList> dakLists)
        {
            List<DakInboxUserControl> dakInboxUserControls = new List<DakInboxUserControl>();
            int i = 0;
            foreach (var dakListInboxRecordsDTO in dakLists)
            {

                DakInboxUserControl dakInboxUserControl = new DakInboxUserControl();
                dakInboxUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakInboxUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakInboxUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakInboxUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);
                dakInboxUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakInboxUserControl.receiver = dakListInboxRecordsDTO.movement_status.from.officer;
                dakInboxUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakInboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakInboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakInboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakInboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakInboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakInboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakInboxUserControl.dakid = dakListInboxRecordsDTO.dak_user.dak_id;
                dakInboxUserControl.dakArchiveUserId = dakListInboxRecordsDTO.dak_user.archived_dak_user_id;
                dakInboxUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                DakCatagoryList dakCatagoryList = new DakCatagoryList();
                dakCatagoryList.isInbox = true;

                //   dakInboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };
                dakInboxUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakInboxUserControl.DakArchiveButtonClick += delegate (object sender, EventArgs e) { DakArchive_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakInboxUserControl.NothijatoButtonClick += delegate (object sender, EventArgs e) { Nothitejato_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakInboxUserControl.CheckBoxClick += delegate (object sender, EventArgs e) { SelectorUnselectSingleDak(); };
                // dakInboxUserControl.dak = dakListInboxRecordsDTO;

                i = i + 1;
                dakInboxUserControls.Add(dakInboxUserControl);

            }
            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.AutoScroll = true;



            for (int j = 0; j <= dakInboxUserControls.Count - 1; j++)
            {
                dakInboxUserControls[j].Dock = DockStyle.Fill;
                int row = dakBodyFlowLayoutPanel.RowCount + 1;
                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                dakBodyFlowLayoutPanel.Controls.Add(dakInboxUserControls[j], 0, row);


            }




        }
        private void LoadDakInboxinPanel(List<DakListRecordsDTO> dakLists)
        {
            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            dakCatagoryList.isInbox = true;

            List<DakInboxUserControl> dakInboxUserControls = new List<DakInboxUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {

                DakInboxUserControl dakInboxUserControl = new DakInboxUserControl();
                dakInboxUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakInboxUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakInboxUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakInboxUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);
                dakInboxUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakInboxUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status);
                dakInboxUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakInboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakInboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakInboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakInboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakInboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakInboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakInboxUserControl.dakid = dakListInboxRecordsDTO.dak_user.dak_id;
                dakInboxUserControl.dak_Tags = dakListInboxRecordsDTO.dak_Tags;
                dakInboxUserControl.dakArchiveUserId = dakListInboxRecordsDTO.dak_user.archived_dak_user_id;
                
                if (_dakForwardService.Is_Locally_Forwarde(dakListInboxRecordsDTO.dak_user.dak_id))
                {
                    dakInboxUserControl.is_Forwarded = true;
                }
                else if(_dakNothijatoService.Is_Locally_Nothijato(dakListInboxRecordsDTO.dak_user.dak_id))
                {
                    dakInboxUserControl.is_Nothijato = true;
                }
                else if (_dakNothivuktoService.Is_Locally_Nothivukto(dakListInboxRecordsDTO.dak_user.dak_id))
                {
                    dakInboxUserControl.is_Nothivukto = true;
                }
                else if (_dakArchiveService.Is_Locally_Archived(dakListInboxRecordsDTO.dak_user.dak_id))
                {
                    dakInboxUserControl.is_Archived = true;
                }
                else
                {
                    dakInboxUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                    dakInboxUserControl.DakArchiveButtonClick += delegate (object sender, EventArgs e) { DakArchive_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                    dakInboxUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                    dakInboxUserControl.NothijatoButtonClick += delegate (object sender, EventArgs e) { Nothitejato_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                    dakInboxUserControl.DakTagButtonCLick += delegate (object sender, EventArgs e) { DakTag_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_Tags, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                    dakInboxUserControl.DakTagShowButtonCLick += delegate (object sender, EventArgs e) { DakTagShow_ButtonClick(dakListInboxRecordsDTO.dak_Tags); };


                    dakInboxUserControl.CheckBoxClick += delegate (object sender, EventArgs e) { SelectorUnselectSingleDak(); };

                }

                dakInboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };

               
                  dakInboxUserControl.dak = dakListInboxRecordsDTO;

                i = i + 1;
                dakInboxUserControls.Add(dakInboxUserControl);

            }
            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.AutoScroll = true;



            for (int j = 0; j <= dakInboxUserControls.Count - 1; j++)
            {
                dakInboxUserControls[j].Dock = DockStyle.Fill;

                int row = dakBodyFlowLayoutPanel.RowCount++;

                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                if (row == 1)
                {
                    row = dakBodyFlowLayoutPanel.RowCount++;
                    dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                }
                dakBodyFlowLayoutPanel.Controls.Add(dakInboxUserControls[j], 0, row);


            }




        }

        private void DakTagShow_ButtonClick(List<DakTagDTO> dak_Tags)
        {
            if (dakTagPanel.Visible)
            {
                dakTagListBox.Items.Clear();
                dakTagPanel.Visible = false;
            }
            else
            {
                for (int i = 1; i <= dak_Tags.Count - 1; i++)
                {


                    dakTagListBox.Items.Add(dak_Tags[i].tag);

                }
                dakTagPanel.Location = System.Windows.Forms.Cursor.Position;
                dakTagPanel.Visible = true;
            }
        }

        private void DakTag_ButtonClick(object sender, EventArgs e, int dakid, List<DakTagDTO> dak_Tags, string dak_subject, string dak_Type, int is_copied_dak)
        {




            FolderListResponse folderListResponse = _dakFolderService.GetFolderList(_dakuserparam);

            var dakTagForm = FormFactory.Create<DakTagForm>();
            dakTagForm.folderListDataDTO = folderListResponse.data;
            dakTagForm.dak_Tags = dak_Tags;
            dakTagForm.dak_Sub = dak_subject;
            dakTagForm.dakId = dakid;
            dakTagForm.is_copied_Id = is_copied_dak;
            dakTagForm.dak_Type = dak_Type;

            dakTagForm.SuccessfullButton += delegate (object dakTagsender, EventArgs dakTagEvent) { ReloadBodyPanel(); };




            CalPopUpWindow(dakTagForm);



        }

        private void DakAttachmentShow_ButtonClick(object sender, EventArgs e, int dakid, string dak_type, string dak_subject, int is_copied_dak)
        {

            DakAttachmentResponse dakAttachmentResponse = _dakListService.GetDakAttachmentbyDakId(dakid, dak_type, is_copied_dak, _dakuserparam);
            if (dakAttachmentResponse != null)
            {
                if (dakAttachmentResponse.data != null)
                {

                    DakAttachmentViewForm dakAttachmentViewForm = new DakAttachmentViewForm();
                    dakAttachmentViewForm.subject = dak_subject;

                    dakAttachmentViewForm.dakAttachmentResponse = dakAttachmentResponse;


                    CalPopUpWindow(dakAttachmentViewForm);

                }
            }
        }

        private void LoadSingleDakInboxinPanel(DakListRecordsDTO dakLists)
        {
            List<DakInboxUserControl> dakInboxUserControls = new List<DakInboxUserControl>();


            DakInboxUserControl dakInboxUserControl = new DakInboxUserControl();
            dakInboxUserControl.date = dakLists.dak_user.last_movement_date;
            dakInboxUserControl.subject = dakLists.dak_user.dak_subject;
            dakInboxUserControl.decision = dakLists.dak_user.dak_decision;
            dakInboxUserControl.source = IsNagorikDakType(dakLists.dak_user.dak_type, dakLists.dak_origin.sender_name, dakLists.dak_origin.name_bng);
            dakInboxUserControl.sender = dakLists.movement_status.from.officer;
            dakInboxUserControl.receiver = GetDakListMainReceiverName(dakLists.movement_status);
            dakInboxUserControl.dakViewStatus = dakLists.dak_user.dak_view_status;
            dakInboxUserControl.attentionTypeIconValue = dakLists.dak_user.attention_type;
            dakInboxUserControl.dakSecurityIconValue = dakLists.dak_user.dak_security;
            dakInboxUserControl.dakPrioriy = dakLists.dak_user.dak_priority;
            dakInboxUserControl.dakType = dakLists.dak_user.dak_type;
            dakInboxUserControl.potrojari = dakLists.dak_user.from_potrojari;
            dakInboxUserControl.dakAttachmentCount = dakLists.attachment_count;
            dakInboxUserControl.dakid = dakLists.dak_user.dak_id;
            dakInboxUserControl.dakArchiveUserId = dakLists.dak_user.archived_dak_user_id;

            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            dakCatagoryList.isInbox = true;

            dakInboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakLists.dak_user.dak_id, dakLists.dak_user.dak_type, dakLists.dak_user.dak_subject, dakLists.dak_user.is_copied_dak, dakLists, dakCatagoryList); };


            dakInboxUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakInboxUserControl.dakid, dakLists.dak_user.dak_type, dakLists.dak_user.dak_subject, dakLists.dak_user.is_copied_dak); };
            dakInboxUserControl.DakArchiveButtonClick += delegate (object sender, EventArgs e) { DakArchive_ButtonClick(sender, e, dakInboxUserControl.dakid, dakLists.dak_user.dak_type, dakLists.dak_user.dak_subject, dakLists.dak_user.is_copied_dak); };
            dakInboxUserControl.NothijatoButtonClick += delegate (object sender, EventArgs e) { Nothitejato_ButtonClick(sender, e, dakInboxUserControl.dakid, dakLists.dak_user.dak_type, dakLists.dak_user.dak_subject, dakLists.dak_user.is_copied_dak); };
            dakInboxUserControl.CheckBoxClick += delegate (object sender, EventArgs e) { SelectorUnselectSingleDak(); };
            dakInboxUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakInboxUserControl.dakid, dakLists.dak_user.dak_type, dakLists.dak_user.dak_subject, dakLists.dak_user.is_copied_dak); };

            dakInboxUserControl.dak = dakLists;

            dakInboxUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(dakInboxUserControl, 0, row);






        }

        private void Nothitejato_ButtonClick(object sender, EventArgs e, int dakid, string dak_type, string dak_subject, int is_copied_dak)
        {
            var form = FormFactory.Create<DakNothijatoForm>();
            form.dak_type = dak_type;
            form.dakid = dakid;
            form.is_copied_dak = is_copied_dak;
            form.dakSubject = dak_subject;
            form.SucessfullyDakNothijato += delegate (object snd, EventArgs eve) { SucessfullyDakNothijato(form._dakNothijatoLocally); };
            CalPopUpWindow(form);




        }

        private void DakArchive_ButtonClick(object sender, EventArgs e, int dakid, string dak_type, string dak_subject, int is_copied_dak)
        {



            DakArchiveResponse dakArchiveResponse = _dakArchiveService.GetDakArcivedResponse(_dakuserparam, dakid, dak_type, is_copied_dak);
            if(dakArchiveResponse.message=="Local")
            {
                SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে এই ডাকটি আর্কাইভ করা হবে");
                LoadDakInbox();
            }
            else if (dakArchiveResponse.status == "success")
            {
                SuccessMessage(dakArchiveResponse.data);
                if (detailsFlowLayoutPanel.Visible)
                {
                    LoadDakArchive();
                }



                ReloadBodyPanel();

            }
            else
            {
                ErrorMessage(dakArchiveResponse.message);

            }

        }

        private void NothiteUposthapito_ButtonClick(object sender, EventArgs e, int dakid, string dak_type, string dak_subject, int is_copied_dak)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();
            form.dak_type = dak_type;
            form.dakid = dakid;
            form.is_copied_dak = is_copied_dak;
            form.dakSubject = dak_subject;
            form.SucessfullyDakNothivukto += delegate (object snd, EventArgs eve) { SucessfullyDakNothivukto(form._dakNothiteUposthapitoLocally); };


            CalPopUpWindow(form);




        }

        private void SucessfullyDakNothivukto(bool dakNothiteUposthapitoLocally)
        {
           if(dakNothiteUposthapitoLocally)
            {
                LoadDakInbox();
            }
           else
            {

                LoadDakNothivukto();
            }
        }

        private void SucessfullyDakNothijato(bool dakNothijatoLocally)
        {
            if (dakNothijatoLocally)
            {

                LoadDakInbox();
            }
            else
            {
                LoadDakNothijato();
            }
        } 


        private void ReloadBodyPanel()
        {



            if (!bodyPanel.Visible)
            {
                return;
            }


            var dakInboxUserControl = dakBodyFlowLayoutPanel.Controls.OfType<DakInboxUserControl>().ToList();

            if (dakInboxUserControl.Count > 0)
            {
                LoadDakInbox();
                // return;
            }

            var dakNothijato = dakBodyFlowLayoutPanel.Controls.OfType<DakNothijatoUserControl>().ToList();

            if (dakNothijato.Count > 0)
            {
                LoadDakNothijato();
                //return;
            }

            var dakNothivukto = dakBodyFlowLayoutPanel.Controls.OfType<DakNothivuktoUserControl>().ToList();

            if (dakNothivukto.Count > 0)
            {
                LoadDakNothivukto();
                //return;
            }


            var dakArchive = dakBodyFlowLayoutPanel.Controls.OfType<DakArchiveUserControl>().ToList();

            if (dakArchive.Count > 0)
            {
                LoadDakArchive();
                //return;
            }

            var dakOutbox = dakBodyFlowLayoutPanel.Controls.OfType<DakOutboxUserControl>().ToList();

            if (dakOutbox.Count > 0)
            {
                LoadDakOutbox();
                //return;
            }


            var daptorikDakList = dakBodyFlowLayoutPanel.Controls.OfType<DaptorikDakUploadUserControl>().ToList();

            if (daptorikDakList.Count > 0)
            {
                DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(_dakuserparam);
                foreach (var daptorikDak in daptorikDakList)
                {
                    daptorikDak.designationSealListResponse = designationSealListResponse;
                }
                return;
            }



            var nagorikDakList = dakBodyFlowLayoutPanel.Controls.OfType<NagorikDakUploadUserControl>().ToList();
            if (nagorikDakList.Count > 0)
            {
                DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(_dakuserparam);

                foreach (var nagorikDak in nagorikDakList)
                {
                    nagorikDak.designationSealListResponse = designationSealListResponse;

                }
                return;
            }

        }

        private void ShowSubMenu(Panel dakUploadDropDownPanel)
        {
            if (dakUploadDropDownPanel.Visible == true)
            {
                dakUploadDropDownPanel.Visible = false;
            }
            else
            {
                HideSubmenu();
                dakUploadDropDownPanel.Visible = true;
            }
        }

        private void dakUploadButton_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(dakUploadDropDownPanel);
        }

        private void dakInboxButton_Click_1(object sender, EventArgs e)
        {
            RefreshPagination();

            selectDakBoxHolderPanel.Visible = true;

            ResetAllMenuButtonSelection();
            SelectButton(dakInboxButton);
            DakListLoad();
            LoadDakInbox();
        }

        private void ResetAllMenuButtonSelection()
        {
            IterateControlsReseatSelection(menuTableLayoutPanel.Controls);



        }
        void IterateControlsReseatSelection(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                ctrl.BackColor = Color.FromArgb(254, 254, 254);
                ctrl.ForeColor = Color.FromArgb(97, 99, 114);


                IterateControlsReseatSelection(ctrl.Controls);
            }

        }

        private void SelectButton(Button button)
        {
            button.BackColor = Color.FromArgb(243, 246, 249);
            button.ForeColor = Color.FromArgb(78, 165, 254);
        }











        private void detailPanelDropDownButton_Click(object sender, EventArgs e)
        {
            if (detailsDakSearcPanel.Visible == true)
            {
                detailsDakSearcPanel.Visible = false;


            }
            else
            {


                detailsDakSearcPanel.Visible = true;
            }



        }
        private void sortingUserButton_Click(object sender, EventArgs e)
        {

        }

        private void notvuktoDakButton_Click(object sender, EventArgs e)
        {
            RefreshPagination();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();
            LoadDakNothivukto();
        }


        private void LoadDakNothivukto()
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakNotivuktoButton);


            NormalizeDashBoard();
            _currentDakCatagory.isNothivukto = true;

            dakListUserParam.limit = NothiCommonStaticValue.pageLimit;
            dakListUserParam.page = pageNumber;



            var dakInbox = _dakNothivuktoService.GetNothivuktoDakList(dakListUserParam);
            if (dakInbox != null && dakInbox.status == "success")
            {
                _dakNothivuktoService.SaveorUpdateDakNothivukto(dakInbox);

                if (dakInbox.data.records.Count > 0)
                {
                    Pagination(dakInbox.data.records.Count, dakInbox.data.total_records);
                    LoadDakNothivuktoinPanel(dakInbox.data.records);

                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
        }
        private void LoadDakNothivuktoUsingSearchParam(string searchParam)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakNotivuktoButton);


            NormalizeDashBoard();
            _currentDakCatagory.isNothivukto = true;
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;



            var dakInbox = _dakNothivuktoService.GetNothivuktoDakList(dakListUserParam, searchParam);
            if (dakInbox.status == "success")
            {
                _dakNothivuktoService.SaveorUpdateDakNothivukto(dakInbox);

                if (dakInbox.data.records.Count > 0)
                {

                    LoadDakNothivuktoinPanel(dakInbox.data.records);

                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
        }

        private void LoadDakNothivuktoinPanel(List<DakListRecordsDTO> dakLists)
        {
            List<DakNothivuktoUserControl> dakNothivuktoUserControls = new List<DakNothivuktoUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {

                DakNothivuktoUserControl dakNothivuktoUserControl = new DakNothivuktoUserControl();
                dakNothivuktoUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakNothivuktoUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakNothivuktoUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakNothivuktoUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
                dakNothivuktoUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

                dakNothivuktoUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status);
                dakNothivuktoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakNothivuktoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakNothivuktoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakNothivuktoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakNothivuktoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakNothivuktoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;

                DakCatagoryList dakCatagoryList = new DakCatagoryList();
                dakCatagoryList.isNothivukto = true;

                dakNothivuktoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };
                dakNothivuktoUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };





                dakNothivuktoUserControl.RevertButtonClick += delegate (object sender, EventArgs e) { DakNothivuktoRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                if (dakListInboxRecordsDTO.nothi != null)
                {
                    dakNothivuktoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                }
                dakNothivuktoUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                i = i + 1;
                dakNothivuktoUserControls.Add(dakNothivuktoUserControl);

            }
            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.AutoScroll = true;

            for (int j = 0; j <= dakNothivuktoUserControls.Count - 1; j++)
            {
                dakNothivuktoUserControls[j].Dock = DockStyle.Fill;
                int row = dakBodyFlowLayoutPanel.RowCount++;
                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                dakBodyFlowLayoutPanel.Controls.Add(dakNothivuktoUserControls[j], 0, row);

            }




        }
        private void LoadDakSingleNothivuktoinPanel(DakListRecordsDTO dakListInboxRecordsDTO)
        {

            DakNothivuktoUserControl dakNothivuktoUserControl = new DakNothivuktoUserControl();
            dakNothivuktoUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
            dakNothivuktoUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
            dakNothivuktoUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
            dakNothivuktoUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
            dakNothivuktoUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

            dakNothivuktoUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status);
            dakNothivuktoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
            dakNothivuktoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
            dakNothivuktoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
            dakNothivuktoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
            dakNothivuktoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
            dakNothivuktoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
            dakNothivuktoUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            dakCatagoryList.isNothivukto = true;

            dakNothivuktoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };


            dakNothivuktoUserControl.RevertButtonClick += delegate (object sender, EventArgs e) { DakNothivuktoRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

            if (dakListInboxRecordsDTO.nothi != null)
            {
                dakNothivuktoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
            }
            dakNothivuktoUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;



            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(dakNothivuktoUserControl, 0, row);






        }

        private void officerSourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (officerSourceCheckBox.Checked)
            {
                detailsSearchOfficerNamePanel.Visible = true;
            }
            else
            {
                detailsSearchOfficerNamePanel.Visible = false;
            }

            VisibleSenderOfficePanle();

        }

        private void VisibleSenderOfficePanle()
        {
            if (officeSourceCheckBox.Checked || officerSourceCheckBox.Checked)
            {
                senderOfficePanel.Visible = true;
            }
            else
            {
                senderOfficePanel.Visible = false;
            }
        }

        private void officeSourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (officeSourceCheckBox.Checked)
            {
                detailsSearchOfficeNamePanel.Visible = true;
            }
            else
            {
                detailsSearchOfficeNamePanel.Visible = false;
            }

            VisibleSenderOfficePanle();
        }

        private void dakArchiveButton_Click(object sender, EventArgs e)
        {
            RefreshPagination();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            DakListLoad();
            LoadDakArchive();
        }

        private void LoadDakArchive()
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakArchiveButton);
            NormalizeDashBoard();


            _currentDakCatagory.isArchived = true;

            dakListUserParam.limit = NothiCommonStaticValue.pageLimit;
            dakListUserParam.page = pageNumber;




            var dakArchive = _dakArchiveService.GetDakList(dakListUserParam);
            if (dakArchive!=null && dakArchive.status == "success")
            {
                _dakArchiveService.SaveorUpdateDakArchive(dakArchive);
                if (dakArchive.data.records.Count > 0)
                {
                    Pagination(dakArchive.data.records.Count, dakArchive.data.total_records);
                    LoadDakArchiveinPanel(dakArchive.data.records);
                    return;

                }
                

            }
                
                noDakTableLayoutPanel.Visible = true;
            


        }
        private void LoadDakArchiveUsingSearchParam(string searchParam)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakArchiveButton);
            NormalizeDashBoard();


            _currentDakCatagory.isArchived = true;
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;



            var dakArchive = _dakArchiveService.GetDakList(dakListUserParam, searchParam);
            if (dakArchive.status == "success")
            {
                _dakArchiveService.SaveorUpdateDakArchive(dakArchive);
                if (dakArchive.data.records.Count > 0)
                {

                    LoadDakArchiveinPanel(dakArchive.data.records);

                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
            else
            {
                noDakTableLayoutPanel.Visible = true;
            }



        }

        private void LoadDakArchiveinPanel(List<DakListRecordsDTO> dakLists)
        {
            List<DakArchiveUserControl> dakArchiveUserControls = new List<DakArchiveUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {

                DakArchiveUserControl dakArchiveUserControl = new DakArchiveUserControl();

                dakArchiveUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakArchiveUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakArchiveUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakArchiveUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

                try
                {
                    dakArchiveUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                    dakArchiveUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status);
                }
                catch
                {

                }


                dakArchiveUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakArchiveUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakArchiveUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakArchiveUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakArchiveUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakArchiveUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakArchiveUserControl.ArchiveRevertButtonClick += delegate (object sender, EventArgs e) { DakArchiveRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                if (dakListInboxRecordsDTO.nothi != null)
                {
                    dakArchiveUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                }
                dakArchiveUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakArchiveUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                DakCatagoryList dakCatagoryList = new DakCatagoryList();
                dakCatagoryList.isArchived = true;

                dakArchiveUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };



                i = i + 1;
                dakArchiveUserControls.Add(dakArchiveUserControl);

            }
            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.AutoScroll = true;


            for (int j = 0; j <= dakArchiveUserControls.Count - 1; j++)
            {
                dakArchiveUserControls[j].Dock = DockStyle.Fill;
                int row = dakBodyFlowLayoutPanel.RowCount++;
                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                dakBodyFlowLayoutPanel.Controls.Add(dakArchiveUserControls[j], 0, row);

            }




        }
        private void LoadDakSingleArchiveinPanel(DakListRecordsDTO dakListInboxRecordsDTO)
        {

            DakArchiveUserControl dakArchiveUserControl = new DakArchiveUserControl();

            dakArchiveUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
            dakArchiveUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
            dakArchiveUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
            dakArchiveUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

            try
            {
                dakArchiveUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakArchiveUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status);
            }
            catch
            {

            }


            dakArchiveUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
            dakArchiveUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
            dakArchiveUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
            dakArchiveUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
            dakArchiveUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
            dakArchiveUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
            dakArchiveUserControl.ArchiveRevertButtonClick += delegate (object sender, EventArgs e) { DakArchiveRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
            if (dakListInboxRecordsDTO.nothi != null)
            {
                dakArchiveUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
            }
            dakArchiveUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            dakCatagoryList.isArchived = true;

            dakArchiveUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };
            dakArchiveUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };



            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(dakArchiveUserControl, 0, row);






        }

        private void DakArchiveRevert_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak)
        {
            DakArchiveRevertResponse revertResponse = _dakArchiveService.GetDakArcivedRevertResponse(_dakuserparam, dak_id, dak_type, is_copied_dak);
            if (revertResponse != null)
            {
                if (revertResponse.status == "success")
                {
                    SuccessMessage(revertResponse.data);
                    LoadDakArchive();

                }
                else
                {
                    ErrorMessage(revertResponse.message);

                }
            }


        }
        private void DakNothivuktoRevert_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak)
        {
            DakNothivuktoRevertResponse revertResponse = _dakNothivuktoService.GetDakNothivuktoRevertResponse(_dakuserparam, dak_id, dak_type, is_copied_dak);
            if (revertResponse != null)
            {
                if (revertResponse.status == "success")
                {
                    SuccessMessage(revertResponse.data);
                    LoadDakNothivukto();

                }
                else
                {
                    ErrorMessage(revertResponse.message);

                }
            }

        }

        private void DakForwardRevert_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak)
        {
            DakForwardRevertResponse revertResponse = _dakForwardService.GetDakForwardRevertResponse(_dakuserparam, dak_id, dak_type, is_copied_dak);
            if (revertResponse != null)
            {
                if (revertResponse.status == "success")
                {
                    SuccessMessage(revertResponse.data);
                    LoadDakOutbox();

                }
                else
                {
                    ErrorMessage(revertResponse.message);

                }

            }
            else
            {
                ErrorMessage("দুঃখিত ! ডাকটি অন্য কার্যক্রমের সাথে যুক্ত রয়েছে বিধায় ফেরত আনা সম্ভব হচ্ছে না");
            }

        }

        private void dakOutboxButton_Click(object sender, EventArgs e)
        {
            RefreshPagination();



            DakListLoad();
            LoadDakOutbox();
        }

        private void DakListLoad()
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            NormalizeDashBoard();

        }

        private void NormalizeDashBoard()
        {

            dakTagPanel.Visible = false;

            bodyTableLayoutPanel.RowStyles[6] = new RowStyle(SizeType.Percent);
            bodyTableLayoutPanel.RowStyles[6].Height = 100;
            selectDakBoxHolderPanel.Visible = false;
            noDakTableLayoutPanel.Visible = false;
            multipleSelectionPanel.Visible = false;
            folderName.Text = "";
            dakBodyFlowLayoutPanel.BringToFront();
            bodyPanel.Visible = true;
            detailsFlowLayoutPanel.Visible = false;

            detailsDakSearcPanel.Visible = false;
            dakSortMetroPanel.Visible = true;
            searchHeaderTableLayoutPanel.Visible = true;
            designationDetailsPanel.Visible = false;
        }

        private void LoadDakNothijato()
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakNothijatoButton);
            NormalizeDashBoard();
            _currentDakCatagory.isNothijato = true;

            dakListUserParam.limit = NothiCommonStaticValue.pageLimit;
            dakListUserParam.page = pageNumber;



            var dakNothijato = _dakNothijatoService.GetNothijatoDak(dakListUserParam);
            if (dakNothijato != null && dakNothijato.status == "success")
            {
                _dakNothijatoService.SaveorUpdateDakNothijato(dakNothijato);
                if (dakNothijato.data.records.Count > 0)
                {
                    Pagination(dakNothijato.data.records.Count, dakNothijato.data.total_records);
                    LoadDakNothijatoinPanel(dakNothijato.data.records);

                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
            else
            {
                noDakTableLayoutPanel.Visible = false;
            }
        }
        private void LoadDakNothijatoUsingSearchParam(string searchParam)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            ResetAllMenuButtonSelection();
            SelectButton(dakNothijatoButton);
            NormalizeDashBoard();
            _currentDakCatagory.isNothijato = true;
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;


            var dakNothijato = _dakNothijatoService.GetNothijatoDak(dakListUserParam, searchParam);
            if (dakNothijato.status == "success")
            {
                _dakNothijatoService.SaveorUpdateDakNothijato(dakNothijato);
                if (dakNothijato.data.records.Count > 0)
                {

                    LoadDakNothijatoinPanel(dakNothijato.data.records);

                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
            else
            {
                noDakTableLayoutPanel.Visible = true;
            }
        }


        private void LoadDakNothijatoinPanel(List<DakListRecordsDTO> dakLists)
        {
            List<DakNothijatoUserControl> dakNothijatoUserControls = new List<DakNothijatoUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {

                DakNothijatoUserControl dakNothijatoUserControl = new DakNothijatoUserControl();
                dakNothijatoUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakNothijatoUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakNothijatoUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakNothijatoUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
                dakNothijatoUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

                dakNothijatoUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status); ;
                dakNothijatoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakNothijatoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakNothijatoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakNothijatoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakNothijatoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakNothijatoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                if (dakListInboxRecordsDTO.nothi != null)
                {
                    dakNothijatoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                }
                dakNothijatoUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                dakNothijatoUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;

                DakCatagoryList dakCatagoryList = new DakCatagoryList();
                dakCatagoryList.isNothijato = true;

                dakNothijatoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };

                dakNothijatoUserControl.NothijatoRevertButtonClick += delegate (object sender, EventArgs e) { NothijatoRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                // dakNothijatoUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                i = i + 1;
                dakNothijatoUserControls.Add(dakNothijatoUserControl);

            }
            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.AutoScroll = true;


            for (int j = 0; j <= dakNothijatoUserControls.Count - 1; j++)
            {
                dakNothijatoUserControls[j].Dock = DockStyle.Fill;
                int row = dakBodyFlowLayoutPanel.RowCount++;
                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                dakBodyFlowLayoutPanel.Controls.Add(dakNothijatoUserControls[j], 0, row);

            }




        }
        private void LoadDakSingleNothijatoinPanel(DakListRecordsDTO dakListInboxRecordsDTO)
        {

            DakNothijatoUserControl dakNothijatoUserControl = new DakNothijatoUserControl();
            dakNothijatoUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
            dakNothijatoUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
            dakNothijatoUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
            dakNothijatoUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
            dakNothijatoUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

            dakNothijatoUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status); ;
            dakNothijatoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
            dakNothijatoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
            dakNothijatoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
            dakNothijatoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
            dakNothijatoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
            dakNothijatoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
            if (dakListInboxRecordsDTO.nothi != null)
            {
                dakNothijatoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
            }
            dakNothijatoUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            dakCatagoryList.isNothijato = true;

            dakNothijatoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };
            dakNothijatoUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };



            dakNothijatoUserControl.NothijatoRevertButtonClick += delegate (object sender, EventArgs e) { NothijatoRevert_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
            // dakNothijatoUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(dakNothijatoUserControl, 0, row);






        }

        private void NothijatoRevert_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak)
        {
            DakNothijatoRevertResponse revertResponse = _dakNothijatoService.GetDakNothijatoRevertResponse(_dakuserparam, dak_id, dak_type, is_copied_dak);
            if (revertResponse != null)
            {
                if (revertResponse.status == "success")
                {
                    SuccessMessage(revertResponse.data);
                    LoadDakNothijato();

                }
                else
                {
                    ErrorMessage(revertResponse.message);

                }
            }

        }

        private void nothijatoButton_Click(object sender, EventArgs e)
        {
            RefreshPagination();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();
            LoadDakNothijato();
        }

        private void dakSearchButton_Click(object sender, EventArgs e)
        {
            _currentDakCatagory.MakeAllFalse();
            NormalizeDashBoard();
            dakBodyFlowLayoutPanel.Controls.Clear();

            noDakTableLayoutPanel.Visible = true;

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            //DakListLoad();
        }

        private void dakSortButton_Click(object sender, EventArgs e)
        {
            RefreshPagination();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();

            LoadDakListSorted();

        }

        private void LoadDakListSorted()
        {
            _currentDakCatagory.isSorted = true;
            NormalizeDashBoard();
            dakListUserParam.limit = NothiCommonStaticValue.pageLimit;
            dakListUserParam.page = pageNumber;

            dakBodyFlowLayoutPanel.Controls.Clear();

            var dakSorted = _dakListSortedService.GetDakList(dakListUserParam);
            if (dakSorted != null && dakSorted.status == "success")
            {
                // _dakListSortedService.SaveorUpdateDakSorted(dakSorted);
                if (dakSorted.data.records.Count > 0)
                {
                    Pagination(dakSorted.data.records.Count, dakSorted.data.total_records);
                    LoadDakSortedinPanel(dakSorted.data.records);

                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
        }

        private void LoadDakListSortedUsingSearchParam(string searchParam)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;


            var dakSorted = _dakListSortedService.GetDakList(dakListUserParam, searchParam);
            if (dakSorted.status == "success")
            {
                // _dakListSortedService.SaveorUpdateDakSorted(dakSorted);
                if (dakSorted.data.records.Count > 0)
                {

                    LoadDakSortedinPanel(dakSorted.data.records);

                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
        }

        private void LoadDakSortedinPanel(List<DakListRecordsDTO> dakLists)
        {
            List<DakSortedUserControl> dakSortedUserControls = new List<DakSortedUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {

                DakSortedUserControl dakSortedUserControl = new DakSortedUserControl();
                dakSortedUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakSortedUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakSortedUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakSortedUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
                dakSortedUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

                dakSortedUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status);
                dakSortedUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakSortedUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakSortedUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakSortedUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakSortedUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakSortedUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                if (dakListInboxRecordsDTO.nothi != null)
                {
                    dakSortedUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                }
                dakSortedUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakSortedUserControl.draftedDecision = dakListInboxRecordsDTO.dak_user.draftedDecisionDTO;
                DakCatagoryList dakCatagoryList = new DakCatagoryList();
                dakCatagoryList.isSorted = true;

                // dakSortedUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };
                // dakSortedUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakSortedUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };
                dakSortedUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakSortedUserControl.DakArchiveButtonClick += delegate (object sender, EventArgs e) { DakArchive_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakSortedUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakSortedUserControl.NothijatoButtonClick += delegate (object sender, EventArgs e) { Nothitejato_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                dakSortedUserControl.DakTagButtonCLick += delegate (object sender, EventArgs e) { DakTag_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_Tags, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakSortedUserControl.DakTagShowButtonCLick += delegate (object sender, EventArgs e) { DakTagShow_ButtonClick(dakListInboxRecordsDTO.dak_Tags); };


                dakSortedUserControl.CheckBoxClick += delegate (object sender, EventArgs e) { SelectorUnselectSingleDak(); };


                i = i + 1;
                dakSortedUserControls.Add(dakSortedUserControl);

            }
            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.AutoScroll = true;


            for (int j = 0; j <= dakSortedUserControls.Count - 1; j++)
            {
                dakSortedUserControls[j].Dock = DockStyle.Fill;
                int row = dakBodyFlowLayoutPanel.RowCount++;
                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                dakBodyFlowLayoutPanel.Controls.Add(dakSortedUserControls[j], 0, row);

            }
        }

        private void LoadSingleDakSortedinPanel(DakListRecordsDTO dakListInboxRecordsDTO)
        {


            DakSortedUserControl dakSortedUserControl = new DakSortedUserControl();
            dakSortedUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
            dakSortedUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
            dakSortedUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
            dakSortedUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
            dakSortedUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

            dakSortedUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status);
            dakSortedUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
            dakSortedUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
            dakSortedUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
            dakSortedUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
            dakSortedUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
            dakSortedUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
            if (dakListInboxRecordsDTO.nothi != null)
            {
                dakSortedUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
            }
            dakSortedUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
            dakSortedUserControl.draftedDecision = dakListInboxRecordsDTO.dak_user.draftedDecisionDTO;
            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            dakCatagoryList.isSorted = true;

            dakSortedUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak, dakListInboxRecordsDTO, dakCatagoryList); };



            dakSortedUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(dakSortedUserControl, 0, row);


        }



        private void sliderCrossButton_Click(object sender, EventArgs e)
        {



        }

        private void daptorikDakUploadButton_Click(object sender, EventArgs e)
        {

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);


            DaptorikDakSavePageLoad(null);
        }

        private void DakSend_ButtonClick(object sender, EventArgs e, DakUploadParameter dakUploadParameter, DakUserParam dakListUserParam, bool isDaptorik, string sub, string prerok, string prapok)
        {

            DakUploadResponse dakSendResponse = _dakuploadservice.GetDakSendResponse(dakListUserParam, dakUploadParameter);
            try
            {
                if (dakSendResponse.status == "error")
                {
                    ErrorMessage("ডাকটি আপলোড সফল হইনি!");
                }
                else if (dakSendResponse.status == "success")
                {
                    ShowDakUploadMessageWindow(dakSendResponse, isDaptorik, sub, prerok, prapok, dakListUserParam);
                    LoadDakOutbox();
                }
            }
            catch (Exception Ex)
            {
                LoadDakOutbox();
            }
        }

        private void ShowDakUploadMessageWindow(DakUploadResponse dakSendResponse, bool isDaptorik, string sub, string prerok, string prapok, DakUserParam dakListUserParam)
        {

            if (dakSendResponse.data.dak_receipt_no == null || dakSendResponse.data.dak_receipt_no == "")
            {
                SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে এই ডাকটি আপলোড করা হবে");
                return;
            }

            DakUploadConfirmationMessage dakUploadConfirmationMessage = new DakUploadConfirmationMessage();
            dakUploadConfirmationMessage.isDaptorik = isDaptorik;
            dakUploadConfirmationMessage.applicationNo = dakSendResponse.data.dak_receipt_no;
            dakUploadConfirmationMessage.prerokName = prerok;
            dakUploadConfirmationMessage.prapokName = prapok;
            dakUploadConfirmationMessage.subject = sub;
            dakUploadConfirmationMessage.date = dakSendResponse.data.receiving_date;
            dakUploadConfirmationMessage.companyName = dakListUserParam.office;
            dakUploadConfirmationMessage.companyWithUnitName = dakListUserParam.designation + " ," + dakListUserParam.office;
            dakUploadConfirmationMessage.userDept = dakListUserParam.designation;
            dakUploadConfirmationMessage.userName = dakListUserParam.officer_name;
            dakUploadConfirmationMessage.imageBase64 = dakListUserParam.SignBase64;


            CalPopUpWindow(dakUploadConfirmationMessage);


        }

        private void AddDesignationUserControl_ButtonClick(object sender, EventArgs e)
        {




            var form = FormFactory.Create<AddDesignationSeal>();

            CalPopUpWindow(form);
            ReloadBodyPanel();



        }

        public AddDesignationSealResponse AddDesignation(string designationSeal)
        {
            _dakuserparam = _userService.GetLocalDakUserParam();

            AddDesignationSealResponse addDesignationSealResponse = _dakuploadservice.GetDesiognationSealAddResponse(_dakuserparam, designationSeal);






            return addDesignationSealResponse;





        }
        public DeleteDesignationSealResponse DeleteDesignation(string designationSealIds)
        {
            _dakuserparam = _userService.GetLocalDakUserParam();
            DeleteDesignationSealResponse deleteDesignationSealResponse = _dakuploadservice.GetDesiognationSealDeleteResponse(_dakuserparam, designationSealIds);


            return deleteDesignationSealResponse;
        }

        private void khosraSaveUserControl_ButtonClick(object sender, EventArgs e, DakUploadParameter dakUploadParameter, DakUserParam dakListUserParam)
        {
            DakDraftedResponse dakDraftedResponse = _dakuploadservice.GetDakDraftedResponse(dakListUserParam, dakUploadParameter);

            try
            {
                if (dakDraftedResponse.status == "error")
                {
                    ErrorMessage("ডাকটি প্রেরণ সফল হইনি!");
                }
                else if (dakDraftedResponse.status == "success")
                {
                    SuccessMessage(dakDraftedResponse.data);
                    ResetAllMenuButtonSelection();
                    SelectButton(khasraDakButton);
                    LoadDakKhasraList();

                }
            }
            catch (Exception Ex)
            {
                ResetAllMenuButtonSelection();
                SelectButton(khasraDakButton);
                LoadDakKhasraList();
            }

        }

        private void nagorikDakUploadMenuButton_Click(object sender, EventArgs e)
        {
            dakSortMetroPanel.Visible = false;
            searchHeaderTableLayoutPanel.Visible = false;
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();

            NagorikDakSavePageLoad(null);
        }

        private void KhasraDakButton_Click(object sender, EventArgs e)
        {
            RefreshPagination();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            LoadDakKhasraList();
        }

        private void LoadDakKhasraList()
        {
            _currentDakCatagory.isKhosra = true;
            dakBodyFlowLayoutPanel.Controls.Clear();
            NormalizeDashBoard();

            // Satic Class
            dakListUserParam.limit = NothiCommonStaticValue.pageLimit;
            dakListUserParam.page = pageNumber;

            dakBodyFlowLayoutPanel.Controls.Clear();

            DakListKhosraResponse dakListKhosraResponse = _dakkhosraservice.GetDakKhosraList(dakListUserParam);

            List<DakListRecordsDTO> dakListRecordsDTOs = new List<DakListRecordsDTO>();

            if (pageNumber == 1)
            {
                dakListRecordsDTOs = _dakuploadservice.GetPendingDakUpload(true);
                if (dakListRecordsDTOs.Count > 0)
                {
                    foreach (DakListRecordsDTO dakListRecordsDTO in dakListRecordsDTOs)
                    {

                        LoadDakKhosrainPanel(dakListRecordsDTO);
                    }
                }

            }



            if ( dakListKhosraResponse!=null && dakListKhosraResponse.status == "success")
            {
                //Save This  

                if (dakListKhosraResponse.data.records.Count > 0)
                {
                    List<DakListRecordsDTO> dakListRecordsDTOsWithoutLocallyEdited = new List<DakListRecordsDTO>();
                    dakListRecordsDTOsWithoutLocallyEdited = dakListKhosraResponse.data.records.Where(a => !dakListRecordsDTOs.Any(f => f.dak_id_Remote == a.dak_user.dak_id)).ToList();

                    if(dakListRecordsDTOsWithoutLocallyEdited.Count>0)
                    {
                        Pagination(dakListRecordsDTOsWithoutLocallyEdited.Count, dakListKhosraResponse.data.total_records);
                        LoadDakKhosrainPanel(dakListRecordsDTOsWithoutLocallyEdited);
                        return;
                    }
                   
                }
                
            }
            if(dakListRecordsDTOs.Count<=0)
            {
                noDakTableLayoutPanel.Visible = true;
            }
        }
        private void LoadDakKhasraListUsingSearchParam(string searchParam)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            // Satic Class
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;

            DakListKhosraResponse dakListKhosraResponse = _dakkhosraservice.GetDakKhosraList(dakListUserParam, searchParam);

            if (dakListKhosraResponse.status == "success")
            {
                //Save This

                if (dakListKhosraResponse.data.records.Count > 0)
                {
                    LoadDakKhosrainPanel(dakListKhosraResponse.data.records);
                }
                else
                {
                    noDakTableLayoutPanel.Visible = true;
                }

            }
            else
            {
                noDakTableLayoutPanel.Visible = true;
            }
        }

        private void LoadDakKhosrainPanel(List<DakListRecordsDTO> dakLists)
        {
            List<DraftedDakUserControl> draftedDakUserControls = new List<DraftedDakUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {
                bool is_Daptorik = false;
                string prerok = "";

                CheckNagorikDakType checkNagorikDakType = new CheckNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type);
                if (!checkNagorikDakType.IsNagarik)
                {
                    is_Daptorik = true;
                    prerok = dakListInboxRecordsDTO.dak_origin.sender_name + "," + dakListInboxRecordsDTO.dak_origin.sender_officer_designation_label + "," + dakListInboxRecordsDTO.dak_origin.sender_office_unit_name + "," + dakListInboxRecordsDTO.dak_origin.sender_office_name;

                }
                else
                {
                    prerok = dakListInboxRecordsDTO.dak_origin.name_bng;
                }




                DraftedDakUserControl draftedDakUserControl = new DraftedDakUserControl();
                draftedDakUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

                draftedDakUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;


                draftedDakUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;



                draftedDakUserControl.receiver = dakListInboxRecordsDTO.dak_origin.receiving_officer_name + "," + dakListInboxRecordsDTO.dak_origin.receiving_officer_designation_label + "," + dakListInboxRecordsDTO.dak_origin.receiving_office_unit_name + "," + dakListInboxRecordsDTO.dak_origin.receiving_office_name;
                draftedDakUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                draftedDakUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                draftedDakUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                draftedDakUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                draftedDakUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                draftedDakUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                draftedDakUserControl.DraftedDakSendButtonClick += delegate (object sender, EventArgs e) { DraftedDakSend_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak, prerok, is_Daptorik, draftedDakUserControl.receiver, draftedDakUserControl.subject,false); };
                draftedDakUserControl.DraftedDakDeleteButtonClick += delegate (object sender, EventArgs e) { DraftedDakDelete_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak,false); };
                draftedDakUserControl.DraftedDakEditButtonClick += delegate (object sender, EventArgs e) { DraftedDakEdit_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                draftedDakUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                i = i + 1;
                draftedDakUserControls.Add(draftedDakUserControl);

            }
            
            dakBodyFlowLayoutPanel.AutoScroll = true;


            for (int j = 0; j <= draftedDakUserControls.Count - 1; j++)
            {
                draftedDakUserControls[j].Dock = DockStyle.Fill;
                int row = dakBodyFlowLayoutPanel.RowCount++;
                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                dakBodyFlowLayoutPanel.Controls.Add(draftedDakUserControls[j], 0, row);

            }
        }
        private void LoadDakKhosrainPanel(DakListRecordsDTO dakListInboxRecordsDTO)
        {


            DraftedDakUserControl draftedDakUserControl = new DraftedDakUserControl();
            draftedDakUserControl.source = IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);

            bool is_Daptorik = false;
            string prerok = "";

            CheckNagorikDakType checkNagorikDakType = new CheckNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type);
            if (!checkNagorikDakType.IsNagarik)
            {
                is_Daptorik = true;
                prerok = dakListInboxRecordsDTO.dak_origin.name_bng + "," + dakListInboxRecordsDTO.dak_origin.sender_officer_designation_label + "," + dakListInboxRecordsDTO.dak_origin.sender_office_unit_name + "," + dakListInboxRecordsDTO.dak_origin.sender_office_name;

            }
            else
            {
                prerok = dakListInboxRecordsDTO.dak_origin.sender_name;
            }
            draftedDakUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;


            draftedDakUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;



            draftedDakUserControl.receiver = dakListInboxRecordsDTO.dak_origin.receiving_officer_name + "," + dakListInboxRecordsDTO.dak_origin.receiving_officer_designation_label + "," + dakListInboxRecordsDTO.dak_origin.receiving_office_unit_name + "," + dakListInboxRecordsDTO.dak_origin.receiving_office_name;
            draftedDakUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
            draftedDakUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
            draftedDakUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
            draftedDakUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
            draftedDakUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
            draftedDakUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
           
            if (dakListInboxRecordsDTO.dak_user.last_movement_date == "")
            {
                draftedDakUserControl.isOfflineDak = true;
                draftedDakUserControl.DraftedDakSendButtonClick += delegate (object sender, EventArgs e) { DraftedDakSend_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak, prerok, is_Daptorik, draftedDakUserControl.receiver, draftedDakUserControl.subject,true); };
                draftedDakUserControl.DraftedDakDeleteButtonClick += delegate (object sender, EventArgs e) { DraftedDakDelete_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak,true); };

            }
            else
            {
                draftedDakUserControl.DraftedDakSendButtonClick += delegate (object sender, EventArgs e) { DraftedDakSend_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak, prerok, is_Daptorik, draftedDakUserControl.receiver, draftedDakUserControl.subject,false); };
                draftedDakUserControl.DraftedDakDeleteButtonClick += delegate (object sender, EventArgs e) { DraftedDakDelete_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak,false); };

                draftedDakUserControl.DraftedDakEditButtonClick += delegate (object sender, EventArgs e) { DraftedDakEdit_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                draftedDakUserControl.DakAttachmentButton += delegate (object sender, EventArgs e) { DakAttachmentShow_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

            }


            UIDesignCommonMethod.AddRowinTable(dakBodyFlowLayoutPanel, draftedDakUserControl);



        }

        private void DraftedDakEdit_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, int is_copied_dak)
        {
            DraftedDakEditResponse dakEditResponse = _dakuploadservice.GetDraftedDakEditResponse(_dakuserparam, dak_id, dak_type, is_copied_dak);
            try
            {
                if (dakEditResponse.status == "success")
                {
                    if (dakEditResponse.data.receiver.mul_prapok.dak_type == "Daptorik")
                    {
                        DaptorikDakSavePageLoad(dakEditResponse);
                    }
                    else
                    {
                        NagorikDakSavePageLoad(dakEditResponse);
                    }
                }
            }
            catch (Exception Ex)
            {

            }

        }

        private void DaptorikDakSavePageLoad(DraftedDakEditResponse dakEditResponse)
        {
            dakSortMetroPanel.Visible = false;
            searchHeaderTableLayoutPanel.Visible = false;
            dakBodyFlowLayoutPanel.Controls.Clear();
            detailsFlowLayoutPanel.Visible = false;
            bodyPanel.Visible = true;


            DaptorikDakUploadUserControl dakUploadUserControl = new DaptorikDakUploadUserControl();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakUploadUserControl.designationSealListResponse = designationSealListResponse;
            dakUploadUserControl.dakListUserParam = dakListUserParam;
            dakUploadUserControl.KhosraSaveButtonClick += delegate (object khosraSaveSender, EventArgs khosraSaveEvent) { khosraSaveUserControl_ButtonClick(khosraSaveSender, khosraSaveEvent, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam); };
            dakUploadUserControl.AddDesignationButtonClick += delegate (object addDesignationSender, EventArgs addDesignationEvent) { AddDesignationUserControl_ButtonClick(addDesignationSender, addDesignationEvent); };
            dakUploadUserControl.DakSendButton += delegate (object addDesignationSender, EventArgs addDesignationEvent) { DakSend_ButtonClick(addDesignationSender, addDesignationEvent, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam, true, dakUploadUserControl.sub, dakUploadUserControl.prerokName, dakUploadUserControl.prapokName); };





            if (dakEditResponse != null)
            {
                dakUploadUserControl.mul_prapokEdit = dakEditResponse.data.receiver.mul_prapok;

                if (dakEditResponse.data.receiver.Onulipi != null)
                {
                    dakUploadUserControl.onulipi = dakEditResponse.data.receiver.Onulipi;
                }



                dakUploadUserControl.dakInfoDTO = dakEditResponse.data.dak;
                dakUploadUserControl.dakAttachmentDTOs = dakEditResponse.data.dak.attachments;
            }

            dakBodyFlowLayoutPanel.Controls.Add(dakUploadUserControl);
        }

        private void NagorikDakSavePageLoad(DraftedDakEditResponse dakEditResponse)
        {
            dakSortMetroPanel.Visible = false;
            searchHeaderTableLayoutPanel.Visible = false;
            dakBodyFlowLayoutPanel.Controls.Clear();
            detailsFlowLayoutPanel.Visible = false;
            bodyPanel.Visible = true;

            NagorikDakUploadUserControl dakUploadUserControl = new NagorikDakUploadUserControl();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakUploadUserControl.designationSealListResponse = designationSealListResponse;
            dakUploadUserControl.dakListUserParam = dakListUserParam;
            dakUploadUserControl.KhosraSaveButtonClick += delegate (object khosraSaveSender, EventArgs khosraSaveEvent) { khosraSaveUserControl_ButtonClick(khosraSaveSender, khosraSaveEvent, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam); };
            dakUploadUserControl.AddDesignationButtonClick += delegate (object addDesignationSender, EventArgs addDesignationEvent) { AddDesignationUserControl_ButtonClick(addDesignationSender, addDesignationEvent); };
            dakUploadUserControl.DakSendButton += delegate (object addDesignationSender, EventArgs addDesignationEvent) { DakSend_ButtonClick(addDesignationSender, addDesignationEvent, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam, false, dakUploadUserControl.sub, dakUploadUserControl.prerokName, dakUploadUserControl.prapokName); };





            if (dakEditResponse != null)
            {
                dakUploadUserControl.mul_prapokEdit = dakEditResponse.data.receiver.mul_prapok;
                if (dakEditResponse.data.receiver.Onulipi != null)
                {
                    dakUploadUserControl.onulipi = dakEditResponse.data.receiver.Onulipi;
                }

                dakUploadUserControl.dakInfoDTO = dakEditResponse.data.dak;
                dakUploadUserControl.dakAttachmentDTOs = dakEditResponse.data.dak.attachments;
            }

            dakBodyFlowLayoutPanel.Controls.Add(dakUploadUserControl);
        }

        private void DraftedDakDelete_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, int is_copied_dak, bool is_local)
        {
            DraftedDakDeleteResponse dakDeleteResponse = _dakuploadservice.GetDraftedDakDeleteResponse(_dakuserparam, dak_id, dak_type, is_copied_dak, is_local);
            try
            {
                if (dakDeleteResponse.status == "error")
                {
                    ErrorMessage("ডাকটি মুছন সফল হইনি!");
                }
                else if (dakDeleteResponse.status == "success")
                {
                    SuccessMessage(dakDeleteResponse.data);
                    LoadDakKhasraList();

                }
            }
            catch (Exception Ex)
            {
                LoadDakKhasraList();
            }
        }

        private void DraftedDakSend_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, int is_copied_dak, string prerok, bool is_Daptorik, string receiver, string sub,bool is_local)
        {

            DakUploadResponse dakSendResponse = _dakuploadservice.GetDraftedDakSendResponse(_dakuserparam, dak_id, dak_type, is_copied_dak, is_local);
            try
            {
                if (dakSendResponse.status == "error")
                {
                    ErrorMessage("ডাকটি প্রেরণ সফল হইনি!");
                }
                else if (dakSendResponse.status == "success")
                {
                    //SuccessMessage(dakSendResponse.data.message);
                    ShowDakUploadMessageWindow(dakSendResponse, is_Daptorik, sub, prerok, receiver, _dakuserparam);

                    LoadDakKhasraList();

                }


            }
            catch (Exception Ex)
            {
                LoadDakKhasraList();
            }
        }

        private void dakSortingButton_Click(object sender, EventArgs e)
        {

        }

        private void dakMenuButton_Click(object sender, EventArgs e)
        {

        }

        private void detailPanelDropDownButton_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void detailPanelDropDownButton_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void detailPanelDropDownButton_MouseHover(object sender, EventArgs e)
        {
            ClickedDetaiPanleDropDownButtonStyle();
        }

        private void detailPanelDropDownButton_MouseLeave(object sender, EventArgs e)
        {

            NormalDetaiPanleDropDownButtonStyle();

        }

        private void ClickedDetaiPanleDropDownButtonStyle()
        {
            detailPanelDropDownButton.IconColor = Color.White;
            detailPanelDropDownButton.BackColor = Color.FromArgb(136, 80, 250);
        }

        private void NormalDetaiPanleDropDownButtonStyle()
        {
            if (detailsDakSearcPanel.Visible)
            {
                ClickedDetaiPanleDropDownButtonStyle();

            }
            else
            {

                detailPanelDropDownButton.IconColor = Color.FromArgb(136, 80, 250);
                detailPanelDropDownButton.BackColor = Color.FromArgb(236, 227, 253);
            }

        }

        private void searchBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.searchBoxPanel.ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void dakModulePanel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void moduleDakCountLabel_Paint(object sender, PaintEventArgs e)
        {
            //  ControlPaint.DrawBorder(e.Graphics, this.moduleDakCountLabel,, Color.FromArgb(203, 225, 248), );
        }

        private void dakModulePanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.CancelAsync();
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void nothiModulePanel_MouseHover(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            nothiModuleNameLabel.ForeColor = Color.Blue;
        }

        private void nothiModulePanel_MouseLeave(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.Transparent;
            nothiModuleNameLabel.ForeColor = Color.Black;
        }

        private void dakTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dak_type = searchDakTypeComboBox.SelectedItem.ToString();
        }

        private void nothiModulePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void profileShowArrowButton_Click(object sender, EventArgs e)
        {
            if (!designationDetailsPanel.Visible)
            {
                int designationPanleX = this.Width - designationDetailsPanel.Width - 25;
                int designationPanleY = profilePanel.Location.Y + profilePanel.Height;
                designationDetailsPanel.Location = new Point(designationPanleX, designationPanleY);

                designationDetailsPanel.Visible = true;


            }
            else
            {
                designationDetailsPanel.Visible = false;
            }
        }

        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            dakListUserParam = _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());


            RefreshdDakList();
        }

        private void RefreshdDakList()
        {
            NormalizeDashBoard();
            if (_currentDakCatagory._isArchived)
            {
                LoadDakArchive();
            }
            else if (_currentDakCatagory._isInbox)
            {
                LoadDakInbox();
            }
            else if (_currentDakCatagory._isKhosra)
            {
                LoadDakKhasraList();
            }
            else if (_currentDakCatagory._isNothijato)
            {
                LoadDakNothijato();
            }
            else if (_currentDakCatagory._isNothivukto)
            {
                LoadDakNothivukto();
            }
            else if (_currentDakCatagory._isOutbox)
            {
                LoadDakOutbox();
            }
            else if (_currentDakCatagory._isSorted)
            {
                LoadDakListSorted();
            }

        }

        private void profileShowArrowButton_Enter(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void profileShowArrowButton_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
        }

        private void profileShowArrowButton_MouseEnter(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void personalFolderButton_Click(object sender, EventArgs e)
        {
            //NormalizeDashBoard();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            FolderListResponse folderListResponse = _dakFolderService.GetFolderList(_dakuserparam);

            var dakFolderForm = FormFactory.Create<DakFolderForm>();
            dakFolderForm.folderListDataDTO = folderListResponse.data;
            dakFolderForm.ShowDakListButton += delegate (object showDakListButton, EventArgs showDakListEvent) { ShowDakList_ButtonClick(showDakListButton, showDakListEvent, dakFolderForm._selectedFolderId, dakFolderForm._selectedFolderName); };

            CalPopUpWindow(dakFolderForm);


        }

        private void ShowDakList_ButtonClick(object showDakListButton, EventArgs showDakListEvent, int selectedFolderId, string selectedFolderName)
        {



            DakSearchResponse dakSearchResponse = _dakListService.GetDakListFromFolderResponse(_dakuserparam, selectedFolderId);

            NormalizeDashBoard();
            folderName.Text = selectedFolderName;


            try
            {

                if (dakSearchResponse.status == "success")
                {



                    if (dakSearchResponse.data.records.Count > 0)
                    {

                        LoadDakAllinPanel(dakSearchResponse.data.records);

                    }

                }
            }
            catch
            {


            }
        }

        private void ShowDakList(int selectedFolderId, string selectedFolderName)
        {

        }

        private void dakSortedUserButton_Click(object sender, EventArgs e)
        {
            NormalizeDashBoard();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            dakSortingUserFlowLayoutPanel.Controls.Clear();





        }

        private void designationDetailsPanel_LogoutButtonClick(object sender, EventArgs e)
        {

            this.Hide();
            var form = FormFactory.Create<Login>();
            form.ShowDialog();





        }

        private void dashBoardBlurPanel_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawLine(Pens.Silver, 0, 0, 100, 100);

        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Checked)
            {

                multipleSelectionPanel.Visible = true;
            }
            else
            {
                multipleSelectionPanel.Visible = false;
            }
            SelectorUnselectDak(selectAllCheckBox.Checked);
        }

        private void SelectorUnselectDak(bool isChecked)
        {
            var dakInboxUserControls = dakBodyFlowLayoutPanel.Controls.OfType<DakInboxUserControl>().ToList();

            if (dakInboxUserControls.Count > 0)
            {
                foreach (DakInboxUserControl dakInboxUser in dakInboxUserControls)
                {
                    dakInboxUser.isChecked = isChecked;
                }
            }
        }

        private void SelectorUnselectSingleDak()
        {
            var dakInboxUserControls = dakBodyFlowLayoutPanel.Controls.OfType<DakInboxUserControl>().ToList();

            if (dakInboxUserControls.Count > 0)
            {
                if (dakInboxUserControls.Any(a => a._isChecked))
                {
                    multipleSelectionPanel.Visible = true;
                }
                else
                {
                    multipleSelectionPanel.Visible = false;
                }
            }
        }

        private void multipleDakForwardButton_Click(object sender, EventArgs e)
        {
            List<DakListRecordsDTO> daks = new List<DakListRecordsDTO>();


            var dakInboxUserControls = dakBodyFlowLayoutPanel.Controls.OfType<DakInboxUserControl>().ToList();

            if (dakInboxUserControls.Count > 0)
            {
                List<DakInboxUserControl> dakInboxSelectedUserControls = dakInboxUserControls.Where(a => a._isChecked == true).ToList();
                if (dakInboxSelectedUserControls.Count > 0)
                {
                    foreach (DakInboxUserControl dakInboxUserControl in dakInboxSelectedUserControls)
                    {
                        daks.Add(dakInboxUserControl._dak);
                    }
                }
            }

            if (daks.Count > 0)
            {
                var dakSendUserControl = FormFactory.Create<DakForwardUserControl>();

                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


                DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




                dakSendUserControl.designationSealListResponse = designationSealListResponse;
                dakSendUserControl.dakCount = daks.Count;
                dakSendUserControl.isMultipleDak = true;
                dakSendUserControl.dakListRecordsDTO = daks;
                dakSendUserControl.dak_List_User_Param = dakListUserParam;
                dakSendUserControl.AddDesignationButtonClick += delegate (object snd, EventArgs eve) { AddDesignationUserControl_ButtonClick(sender, e); };
                dakSendUserControl.SucessfullyDakForwarded += delegate (object snd, EventArgs eve) { SuccessfullySingleDakForwarded(true, dakSendUserControl._totalFailForwardRequest, dakSendUserControl._totalSuccessForwardRequest, dakSendUserControl._totalFailForwardRequest, dakSendUserControl._IsDakLocallyUploaded) ; };




                CalPopUpWindow(dakSendUserControl);

            }
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }

        private void multipleDakActionButton_Click(object sender, EventArgs e)
        {
            List<DakListRecordsDTO> daks = new List<DakListRecordsDTO>();


            var dakInboxUserControls = dakBodyFlowLayoutPanel.Controls.OfType<DakInboxUserControl>().ToList();

            if (dakInboxUserControls.Count > 0)
            {
                List<DakInboxUserControl> dakInboxSelectedUserControls = dakInboxUserControls.Where(a => a._isChecked == true).ToList();
                if (dakInboxSelectedUserControls.Count > 0)
                {
                    foreach (DakInboxUserControl dakInboxUserControl in dakInboxSelectedUserControls)
                    {
                        daks.Add(dakInboxUserControl._dak);
                    }
                }
            }

            if (daks.Count > 0)
            {
                var multipleDakAction = UserControlFactory.Create<MultipleDakSelectedListConfirmForm>();

                if ((sender as Button) == multipleDakArchiveButton)
                {
                    multipleDakAction.isArchive = true;
                    multipleDakAction.SucessfullyDakArchived += delegate (object snd, EventArgs eve) { LoadDakArchive(); };

                }
                else if ((sender as Button) == multipleDakNothijatoButton)
                {
                    multipleDakAction.isNothijato = true;
                    multipleDakAction.SucessfullyDakNothijato += delegate (object snd, EventArgs eve) { LoadDakNothijato(); };

                }
                else if ((sender as Button) == multipleDakNothivuktoButton)
                {
                    multipleDakAction.isNothivukto = true;
                    multipleDakAction.SucessfullyDakNothivukto += delegate (object snd, EventArgs eve) { LoadDakNothivukto(); };
                    
                }
                multipleDakAction.dakListRecordsDTO = daks;



                this.WindowState = FormWindowState.Maximized;
                this.MinimizeBox = false;







                Form form = AttachControlToForm(multipleDakAction);



                CalPopUpWindow(form);









            }
        }
        public Form AttachControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Height = 100;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }

        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = this.Size;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            dakListUserParam = _userService.GetLocalDakUserParam();
            RefreshPagination();
            LoadDakInbox();
            LoadDetailsOffice();
            LoadDetailsOfficer();



            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();



            try
            {
                EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
                moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());

            }
            catch(Exception Ex)
            {

            }





            List<OfficeInfoDTO> officeInfoDTO = _userService.GetAllLocalOfficeInfo();


            foreach (OfficeInfoDTO officeInfoDTO1 in officeInfoDTO)
            {
                dakUserParam.designation_id = officeInfoDTO1.office_unit_organogram_id;
                dakUserParam.office_id = officeInfoDTO1.office_id;
                try
                {
                    EmployeDakNothiCountResponse singleOfficeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                    var singleOfficeDakNothiCount = singleOfficeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                    officeInfoDTO1.dakCount = singleOfficeDakNothiCount.Value.dak;
                    officeInfoDTO1.nothiCount = singleOfficeDakNothiCount.Value.own_office_nothi;
                }
                catch
                {

                }
            }



            designationDetailsPanel.officeInfos = officeInfoDTO;





            designationDetailsPanel.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanel._designationId); };


            NormalizeDashBoard();
            selectDakBoxHolderPanel.Visible = true;
            SetDefaultFont(this.Controls);

           

        }

        private void RefreshPagination()
        {
            pageStart = 1;
            pageEnd = 0;
            pageNumber = 1;

            Pagination(0, 0);
        }

        private void Pagination(int count, int total)
        {

            if (pageEnd == 0)
            {
                pageEnd = pageEnd + count;
            }
            else
            {
                pageEnd = pageEnd - (NothiCommonStaticValue.pageLimit - count);

            }



            int pageStartTemp = pageStart;


            if (count == 0)
            {
                pageStartTemp = pageStartTemp - 1;
            }



            pageLabel.Text = ConversionMethod.EnglishNumberToBangla(pageStartTemp.ToString()) + " - " + ConversionMethod.EnglishNumberToBangla(pageEnd.ToString());
            totalLabel.Text = "সর্বমোট: " + ConversionMethod.EnglishNumberToBangla(total.ToString());

            if (pageEnd == total)
            {
                pageNextButton.Enabled = false;
            }
            else
            {
                pageNextButton.Enabled = true;
            }

            if (pageStart == 1)
            {
                pagePrevButton.Enabled = false;
            }
            else
            {
                pagePrevButton.Enabled = true;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Close();
        }
        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }


        public void LoadDetailsOfficer()
        {
            AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
            designationSealListResponse = _designationSealService.GetAllDesignationSeal(_dakuserparam, _dakuserparam.office_id);
            List<ComboBoxItems> comboBoxItems = new List<ComboBoxItems>();
            try
            {

                if (designationSealListResponse.data.Count > 0)
                {

                    foreach (PrapokDTO prapokDTO in designationSealListResponse.data)
                    {
                        comboBoxItems.Add(new ComboBoxItems { id = prapokDTO.officer_id, Name = prapokDTO.NameWithDesignation });
                    }
                }


            }
            catch (Exception Ex)
            {

            }

            officerSearchList.itemList = comboBoxItems;


        }
        public void LoadDetailsOffice()
        {
            OfficeListResponse officeListResponse = new OfficeListResponse();
            officeListResponse = _designationSealService.GetAllOffice(_dakuserparam);
            List<ComboBoxItems> comboBoxItems = new List<ComboBoxItems>();
            try
            {

                if (officeListResponse.data.Count > 0)
                {
                    List<JsonParser.Entity.OfficeInfoDTO> officeDTOs = new List<OfficeInfoDTO>();
                    officeDTOs = officeListResponse.data[_dakuserparam.office_id.ToString()];
                    foreach (OfficeInfoDTO officeInfo in officeDTOs)
                    {

                        comboBoxItems.Add(new ComboBoxItems { id = officeInfo.id, Name = officeInfo.office_name_bng });
                    }

                }


            }
            catch (Exception Ex)
            {

            }

            searchOfficeDetailSearch.itemList = comboBoxItems;
            searchOfficeDetailSearch.isListShown = true;

        }
        private void detailSearchStopButton_Click(object sender, EventArgs e)
        {
            detailsDakSearcPanel.Visible = false;
            RefreshDetailsSearchAllInput();
        }

        private void detailsSearchResetButton_Click(object sender, EventArgs e)
        {
            RefreshDetailsSearchAllInput();
        }

        private void dakSearchUsingTextButton_Click(object sender, EventArgs e)
        {


            string searchParam = "dak_subject=" + dakSearchSubTextBox.Text;

            SearchDak(searchParam);
            RefreshDetailsSearchAllInput();
        }

        private void SearchDak(string searchParam)
        {
            if (_currentDakCatagory._isInbox)
            {
                LoadDakInboxUsingSearchParam(searchParam);
            }
            else if (_currentDakCatagory._isOutbox)
            {
                LoadDakOutboxUsingSearchParam(searchParam);
            }

            else if (_currentDakCatagory._isNothijato)
            {
                LoadDakNothijatoUsingSearchParam(searchParam);
            }
            else if (_currentDakCatagory._isNothivukto)
            {
                LoadDakNothivuktoUsingSearchParam(searchParam);
            }
            else if (_currentDakCatagory._isArchived)
            {
                LoadDakArchiveUsingSearchParam(searchParam);
            }


            else if (_currentDakCatagory._isSorted)
            {
                LoadDakListSortedUsingSearchParam(searchParam);
            }
            else if (_currentDakCatagory._isKhosra)
            {
                LoadDakKhasraListUsingSearchParam(searchParam);
            }
            else
            {
                SearchAllTypeDataUsingSearchParam(searchParam);
            }
        }

        private void SearchAllTypeDataUsingSearchParam(string searchParam)
        {
            DakSearchResponse dakSearchResponse = _dakSearchService.GetDakSearchDetailsResponse(_dakuserparam, searchParam);

            NormalizeDashBoard();


            try
            {

                if (dakSearchResponse.status == "success")
                {



                    if (dakSearchResponse.data.records.Count > 0)
                    {

                        LoadDakAllinPanel(dakSearchResponse.data.records);

                    }

                }
            }
            catch
            {


            }
        }

        private void LoadDakAllinPanel(List<DakListRecordsDTO> records)
        {
            dakBodyFlowLayoutPanel.Controls.Clear();
            DakCatagoryList dakCatagoryList = new DakCatagoryList();
            if (records.Count > 0)
            {

                dakBodyFlowLayoutPanel.Controls.Clear();

                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));

                foreach (DakListRecordsDTO dakListRecordsDTO in records)
                {
                    dakCatagoryList.SetCategory = dakListRecordsDTO.dak_user.dak_category;



                    if (dakCatagoryList._isInbox)
                    {
                        LoadSingleDakInboxinPanel(dakListRecordsDTO);
                    }
                    else if (dakCatagoryList._isOutbox)
                    {
                        LoadDakSingleOutboxinPanel(dakListRecordsDTO);
                    }
                    else if (dakCatagoryList._isSorted)
                    {
                        LoadSingleDakSortedinPanel(dakListRecordsDTO);
                    }
                    else if (dakCatagoryList._isKhosra)
                    {
                        LoadDakKhosrainPanel(dakListRecordsDTO);
                    }
                    else if (dakCatagoryList._isArchived)
                    {
                        LoadDakSingleArchiveinPanel(dakListRecordsDTO);
                    }
                    else if (dakCatagoryList._isNothijato)
                    {
                        LoadDakSingleNothijatoinPanel(dakListRecordsDTO);
                    }
                    else if (dakCatagoryList._isNothivukto)
                    {
                        LoadDakSingleNothivuktoinPanel(dakListRecordsDTO);
                    }
                }
            }
            else
            {
                noDakTableLayoutPanel.Visible = false;
            }
        }

        private void detailSearchButton_Click(object sender, EventArgs e)
        {
            string searchParam = "";
            //  if(dakSearchSubTextBox.Text !=""){ searchParam += "dak_subject=" + dakSearchSubTextBox.Text; }
            if (searchDakSecurityComboBox.SelectedValue != null && searchDakSecurityComboBox.SelectedValue.ToString() != "0" && searchDakSecurityComboBox.SelectedValue.ToString() != "")
            {
                searchParam += " & dak_security=" + searchDakSecurityComboBox.SelectedValue.ToString();
            }
            if (searchDakPriorityComboBox.SelectedValue != null && searchDakPriorityComboBox.SelectedValue.ToString() != "0" && searchDakPriorityComboBox.SelectedValue.ToString() != "")
            {
                searchParam += " & dak_priority=" + searchDakPriorityComboBox.SelectedValue.ToString();
            }

            if (last_modified_date != "")
            {
                searchParam += " & last_modified_date=" + last_modified_date;
            }

            if (searchDakTypeComboBox.SelectedValue != null && searchDakTypeComboBox.SelectedValue.ToString() != "0" && searchDakTypeComboBox.SelectedValue.ToString() != "")
            {
                searchParam += " & dak_type=" + searchDakTypeComboBox.SelectedValue.ToString();
            }

            if (searchDakPotroTypeComboBox.SelectedValue != null && searchDakPotroTypeComboBox.SelectedValue.ToString() != "0" && searchDakPotroTypeComboBox.SelectedValue.ToString() != "")
            {
                searchParam += " & potro_type=" + searchDakPotroTypeComboBox.SelectedValue.ToString();
            }

            if (searchDakStatusComboBox.SelectedValue != null && searchDakStatusComboBox.SelectedValue.ToString() != "0" && searchDakStatusComboBox.SelectedValue.ToString() != "")
            {
                searchParam += " & dak_view_status=" + searchDakStatusComboBox.SelectedValue.ToString();
            }
            if (searchThirdPartyComboBox.SelectedValue != null && searchThirdPartyComboBox.SelectedValue.ToString() != "0" && searchThirdPartyComboBox.SelectedValue.ToString() != "")
            {
                searchParam += " & daak_service=" + searchThirdPartyComboBox.SelectedValue.ToString();
            }




            if (detailSearchApplicationAcceptNumberTextBox.Text.ToString() != "")
            {
                searchParam += " & dak_receipt_no=" + detailSearchApplicationAcceptNumberTextBox.Text.ToString();
            }
            if (detailsSearchDocketingNoTextBox.Text.ToString() != "")
            {
                searchParam += " & docketing_no=" + detailsSearchDocketingNoTextBox.Text.ToString();
            }
            if (detailsSearchPrerokOficerNameTextBox.Text.ToString() != "")
            {
                searchParam += " & sender_officer_name=" + detailsSearchPrerokOficerNameTextBox.Text.ToString();
            }

            if (detailsSearchPrerokOficeNameTextBox.Text.ToString() != "")
            {
                searchParam += " & sender_office_name=" + detailsSearchPrerokOficeNameTextBox.Text.ToString();
            }




            // searchParam += "&sender_officer_id=" + dakSecurityComboBox.SelectedItem.ToString();


            //  searchParam += "&sender_office_id=" + detailsSearchPrerokOficeNameTextBox.Text.ToString();
            if (officerSearchList._id != 0)
            {
                searchParam += " & to_officer_id=" + officerSearchList._id;
            }

            if (searchOfficeDetailSearch._id != 0)
            {
                searchParam += " & to_office_id=" + searchOfficeDetailSearch._id;
            }
            string subStringWithoutFirstLetter = "";
            if (searchParam != "")
            {
                int strLength = searchParam.Length - 3;

                subStringWithoutFirstLetter = searchParam.Substring(3, strLength);

            }

            SearchDak(subStringWithoutFirstLetter);
            RefreshDetailsSearchAllInput();

        }

        private void RefreshDetailsSearchAllInput()
        {
            // timeLimitFromDateTimePicker.Text = DateTime.Now.Date.ToString();
            // timeLimitToDateTimePicker.Text = DateTime.Now.Date.ToString();
            dakSearchSubTextBox.Text = "";

            searchDakStatusComboBox.Text = "সকল";
            searchDakPotroTypeComboBox.Text = "পত্রের ধরন";
            searchDakSecurityComboBox.Text = "গোপনীয়তা";
            searchDakPriorityComboBox.Text = "অগ্রাধিকার";
            searchDakTypeComboBox.Text = "ডাকের ধরণ";
            searchThirdPartyComboBox.Text = "সার্ভিস";


            officerSourceCheckBox.Checked = false;
            detailsSearchOfficerNamePanel.Visible = false;

            officeSourceCheckBox.Checked = false;
            detailsSearchOfficeNamePanel.Visible = false;


            officerSearchList.searchButtonText = "নাম/পদবী দিয়ে খুঁজুন";
            officerSearchList._id = 0;
            searchOfficeDetailSearch.searchButtonText = "অফিস খুঁজুন";
            searchOfficeDetailSearch._id = 0;

            last_modified_date = "";
            dateRangeTextBox.Text = "";
            dak_type = "";
            potro_type = "";
            dak_view_status = "";
            detailsSearchDocketingNoTextBox.Text = "";
            detailsSearchDocketingNoTextBox.Text = "";
            detailSearchApplicationAcceptNumberTextBox.Text = "";

            detailsSearchPrerokOficerNameTextBox.Text = "";
            detailsSearchPrerokOficeNameTextBox.Text = "";



        }

        public bool istimeLimitFromDateTimePickerSelected = false;
        private void timeLimitFromDateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            //istimeLimitFromDateTimePickerSelected = true;
        }

        private void timeLimitToDateTimePicker_MouseEnter(object sender, EventArgs e)
        {
            SetDateRange();
        }

        private void timeLimitFromDateTimePicker_MouseEnter(object sender, EventArgs e)
        {
            istimeLimitFromDateTimePickerSelected = true;
        }

        private void timeLimitFromDateTimePicker_MouseEnter_1(object sender, EventArgs e)
        {
            SetDateRange();
        }

        private void SetDateRange()
        {
            // last_modified_date = timeLimitFromDateTimePicker.Value.Date.ToString("yyyy/MM/dd") + ":" + timeLimitToDateTimePicker.Value.Date.ToString("yyyy/MM/dd");



        }

        private void dakAttentionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dak_view_status= searchDakStatusComboBox.SelectedValue.ToString();



        }

        private void dakPaperTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // potro_type= searchDakPotroTypeComboBox.SelectedValue.ToString();
        }

        private void dakSecurityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  dak_security= searchDakSecurityComboBox.SelectedValue.ToString();
        }

        private void dakPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dak_priority =searchDakPriorityComboBox.SelectedValue.ToString();
        }

        private void searchComboBoxTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);

        }

        private void comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
            }

            try
            {
                e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                         e.Font,
                                         new SolidBrush(Color.Black),
                                         new Point(e.Bounds.X, e.Bounds.Y));
            }
            catch
            {

            }
        }

        private void dateRangeSelect_Click(object sender, EventArgs e)
        {
            if (customDatePicker.Visible)
            {
                customDatePicker.Visible = false;
            }
            else
            {
                customDatePicker.Visible = true;
                //  customDatePicker.Location =new Point(datePickerTableLayoutPanel.Location.X, datePickerTableLayoutPanel.Location.Y+datePickerTableLayoutPanel.Height);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customDatePicker_Load(object sender, EventArgs e)
        {

        }

        private void customDatePicker_Click(object sender, EventArgs e)
        {

        }

        private void customDatePicker_OptionClick(object sender, EventArgs e)
        {
            last_modified_date = customDatePicker._date;
            dateRangeTextBox.Text = customDatePicker._date;

            customDatePicker.Visible = false;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {



            //monthCalendar1.SelectionRange = new SelectionRange(projectStart, projectEnd);
        }

        private void menuTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void khosraButton_Click(object sender, EventArgs e)
        {
            modulePanel.Hide();
            var form = FormFactory.Create<Khosra>();
            form.ShowDialog();

        }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            if (!modulePanel.Visible)
            {
                //  modulePanel.Location = new Point(moduleButton.Location.Y , moduleButton.Location.X + moduleButton.Height);
                modulePanel.Visible = true;


            }
            else
            {
                modulePanel.Visible = false;
            }

        }

        private void detailsDakSearcPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (registerPanel.Visible)
            {
                registerPanel.Visible = false;
            }
            else
            {
                registerPanel.Visible = true;
            }
        }

        private void registerGrohonButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            RegisterReportResponse registerReportResponse = _registerService.GetDakGrohonResponse(_dakuserparam, null, null, null);
            RegisterReportUserControl registerReportUserControl = new RegisterReportUserControl();
            registerReportUserControl.isDakGrohon = true;
            registerReportUserControl.registerReports = ConvertRegisterResponsetoReport.GetRegisterReports(registerReportResponse);


            registerReportUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0F));
            dakBodyFlowLayoutPanel.Controls.Add(registerReportUserControl, 0, row);
        }

        private void registerBiliButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            RegisterReportResponse registerReportResponse = _registerService.GetDakBiliResponse(_dakuserparam, null, null, null);
            RegisterReportUserControl registerReportUserControl = new RegisterReportUserControl();
            registerReportUserControl.isDakBili = true;
            registerReportUserControl.registerReports = ConvertRegisterResponsetoReport.GetRegisterReports(registerReportResponse);


            registerReportUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(registerReportUserControl, 0, row);
        }

        private void registerDiaryButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            RegisterReportResponse registerReportResponse = _registerService.GetDakDiaryResponse(_dakuserparam, null, null, null);
            RegisterReportUserControl registerReportUserControl = new RegisterReportUserControl();
            registerReportUserControl.isDakDiary = true;
            registerReportUserControl.registerReports = ConvertRegisterResponsetoReport.GetRegisterReports(registerReportResponse);


            registerReportUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(registerReportUserControl, 0, row);
        }

        private void pendingReportButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            dakSortMetroPanel.Visible = false;

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            ProtibedonResponse protibedonResponse = _protibedonService.GetPendingProtibedonResponse(_dakuserparam, null, null, null);
            ProtibedonUserControl protibedonUserControl = new ProtibedonUserControl();
            protibedonUserControl.isPending = true;
            protibedonUserControl.protibedons = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);



            protibedonUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(protibedonUserControl, 0, row);
        }

        private void resolvedReportButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            ProtibedonResponse protibedonResponse = _protibedonService.GetResolvedProtibedonResponse(_dakuserparam, null, null, null);
            ProtibedonUserControl protibedonUserControl = new ProtibedonUserControl();
            protibedonUserControl.isResolved = true;
            protibedonUserControl.protibedons = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);



            protibedonUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(protibedonUserControl, 0, row);
        }

        private void protibedonButton_Click(object sender, EventArgs e)
        {
            if (protibedonPanel.Visible)
            {
                protibedonPanel.Visible = false;
            }
            else
            {
                protibedonPanel.Visible = true;
            }

        }

        private void nothiteUposthapitoListReportButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            DakProtibedonResponse protibedonResponse = _protibedonService.GetNothiteUposthapitoProtibedonResponse(_dakuserparam, null, null, null);
            ProtibedonUserControl protibedonUserControl = new ProtibedonUserControl();
            protibedonUserControl.isNothiteUposthapito = true;
            protibedonUserControl.protibedons = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);




            protibedonUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(protibedonUserControl, 0, row);
        }

        private void PotrojariListReportButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            DakProtibedonResponse protibedonResponse = _protibedonService.GetPotrojariProtibedonResponse(_dakuserparam, null, null, null);
            ProtibedonUserControl protibedonUserControl = new ProtibedonUserControl();
            protibedonUserControl.isPotrojari = true;
            protibedonUserControl.protibedons = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);



            protibedonUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(protibedonUserControl, 0, row);
        }

        private void nothijatoListReportButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakBodyFlowLayoutPanel.Controls.Clear();
            dakBodyFlowLayoutPanel.RowCount = 0;
            DakProtibedonResponse protibedonResponse = _protibedonService.GetNothijatoProtibedonResponse(_dakuserparam, null, null, null);
            ProtibedonUserControl protibedonUserControl = new ProtibedonUserControl();
            protibedonUserControl.isNothijato = true;
            protibedonUserControl.protibedons = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);



            protibedonUserControl.Dock = DockStyle.Fill;
            int row = dakBodyFlowLayoutPanel.RowCount++;
            dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            dakBodyFlowLayoutPanel.Controls.Add(protibedonUserControl, 0, row);
        }

        private void dakShareButton_Click(object sender, EventArgs e)
        {
            var dakBoxSharingForm = FormFactory.Create<DakBoxSharingForm>();

            CalPopUpWindow(dakBoxSharingForm);
        }

        private void Drop_Shadow(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.dropShadow(sender, e);
        }

        private void potrojariButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            PotrojariGroup potrojariGroup = FormFactory.Create<PotrojariGroup>();
            potrojariGroup.ShowDialog();
        }

        private void khosraPotroButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhosraDashboard khosraDashboard = FormFactory.Create<KhosraDashboard>();
            khosraDashboard.ShowDialog();
        }

        private void reviewDashBoardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReviewDashBoard reviewDashBoard = FormFactory.Create<ReviewDashBoard>();
            reviewDashBoard.ShowDialog();
        }

        private void guardFileModuleButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var gurdFileControl = FormFactory.Create<GurdFileControl>();
            gurdFileControl.ShowDialog();
        }

        private void pagePrevButton_Click(object sender, EventArgs e)
        {
            pageNumber = pageNumber - 1;


            if (NothiCommonStaticValue.pageLimit > (pageEnd - pageStart + 1))
            {

                pageEnd = pageEnd - (pageEnd - pageStart + 1);
            }
            else
            {

                pageEnd = pageEnd - NothiCommonStaticValue.pageLimit;
            }

            pageStart = pageStart - NothiCommonStaticValue.pageLimit;



            RefreshdDakList();
        }

        private void pageNextButton_Click(object sender, EventArgs e)
        {
            pageNumber = pageNumber + 1;
            pageStart = pageStart + NothiCommonStaticValue.pageLimit;
            pageEnd = pageEnd + NothiCommonStaticValue.pageLimit;

            

            RefreshdDakList();

            if(noDakTableLayoutPanel.Visible)
            {
                pageNumber = pageNumber - 1;
                pageStart = pageStart - NothiCommonStaticValue.pageLimit;
                pageEnd = pageEnd - NothiCommonStaticValue.pageLimit;

            }
        }
        private bool _isLocallYDakForwarded;
        private bool _isLocallYDakNothijato;
        private bool _isLocallYDakNothivukto;
        private bool _isLocallYDakArchived;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            _isDakUploaded = false;
            _isLocallYDakArchived = false;
            _isLocallYDakNothijato = false;
            _isLocallYDakNothivukto = false;
            _isLocallYDakForwarded = false;
               
            if (InternetConnection.Check())
                {
            
                if (_dakuploadservice.UploadDakFromLocal())
                {
                    _isDakUploaded = true;
                }
                if (_dakForwardService.SendDakForwardFromLocal())
                {
                    _isLocallYDakForwarded = true;
                }
                if (_dakNothivuktoService.DakNothivuktoFromLocal())
                {
                    _isLocallYDakNothivukto = true;
                }
                if (_dakArchiveService.DakArchivedFromLocal())
                {
                    _isLocallYDakArchived = true;
                }
                if (_dakNothijatoService.DakNothijatoFromLocal())
                {
                    _isLocallYDakNothijato = true;
                }

                if (onlineStatus.IconColor != Color.LimeGreen)
                    {



                        if(IsHandleCreated)
                    {
                        onlineStatus.Invoke(new MethodInvoker(delegate

                        {
                            onlineStatus.IconColor = Color.LimeGreen;
                            MyToolTip.SetToolTip(onlineStatus, "Online");

                        }));
                    }
                        else
                    {

                    }

                    


                    //dakUploadBackgorundWorker.RunWorkerAsync();
                }





            }
                else
                {
                   if(IsHandleCreated)
                {
                    onlineStatus.Invoke(new MethodInvoker(delegate

                    {
                        onlineStatus.IconColor = Color.Silver;
                        MyToolTip.SetToolTip(onlineStatus, "Offline");

                    }));
                }
                else
                {

                }



                }





                
        }

       
        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           if (pageNumber == 1 && _currentDakCatagory._isOutbox == true && _isDakUploaded)
            {
                LoadDakOutbox();
            }

           else if (pageNumber == 1 && _currentDakCatagory._isKhosra == true && _isDakUploaded)
            {
                LoadDakKhasraList();
            }
           else if (_currentDakCatagory._isInbox == true && _isLocallYDakForwarded)
            {
                LoadDakInbox();
            }
           else if (_currentDakCatagory._isInbox == true && _isLocallYDakArchived)
            {
                LoadDakInbox();
            }
           else if (_currentDakCatagory._isInbox == true && _isLocallYDakNothijato)
            {
                LoadDakInbox();
            }
           else if (_currentDakCatagory._isInbox == true && _isLocallYDakNothivukto)
            {
                LoadDakInbox();
            }

           // Thread.Sleep(10);
          
            if (!backgroundWorker1.IsBusy && this.Visible)
            {
                
               
                backgroundWorker1.RunWorkerAsync();
            }
           

        }
    }


   

   


}
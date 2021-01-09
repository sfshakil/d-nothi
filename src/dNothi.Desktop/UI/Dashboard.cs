using dNothi.Desktop.UI;
using dNothi.Desktop.UI.Dak;
using dNothi.Services.AccountServices;
using dNothi.Services.UserServices;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Utility;
using dNothi.Desktop.UI.VIew;
using System.Drawing.Imaging;

namespace dNothi.Desktop.UI
{
    public partial class Dashboard : Form
    {
        private PictureBox pb;
        IUserService _userService { get; set; }

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
            IDakNothijatoService dakNothijatoService)
        {
            _dakNothivuktoService = dakNothivuktoService;
            _userService = userService;
            _dakOutboxService = dakOutboxService;
            _dakInbox = dakInbox;
            _dakArchiveService = dakListArchiveService;
            _dakNothijatoService = dakNothijatoService;
            _dakListService = dakListService;
            _dakListSortedService = dakListSortedService;
            _dakForwardService = dakForwardService;
            _dakkhosraservice = dakKhosraService;
            _dakuploadservice = dakUploadService;
            InitializeComponent();

            dashboardSlideFlowLayoutPanel.BringToFront();


            pb = new PictureBox();
            dashBoardBlurPanel.Controls.Add(pb);
            pb.Dock = DockStyle.Fill;



        }
        private void Blur()
        {
            Bitmap bmp = Screenshot.TakeSnapshot(dashBoardBlurPanel);
            BitmapFilter.GaussianBlur(bmp,1);

            pb.Image = bmp;
            dashBoardBlurPanel.BringToFront();
        }

        private void UnBlur()
        {
            pb.Image = null;
            dashBoardBlurPanel.SendToBack();
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
        protected void UserControl_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak)
        {
            string s = (sender as Control).Name;

            if (s == "dakMovementStatusButton")
            {
                GetDakMovementList(dak_id, dak_type, is_copied_dak);
            }

            else if (s == "DakSendButton")
            {
                DakSendButtonClicked(dak_id, dak_type, is_copied_dak, dak_subject);
            }

            else
            {
                dakSortMetroPanel.Visible = false;
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


                DakDetailsResponse dakDetailsResponse = _dakListService.GetDakDetailsbyDakId(dak_id, dak_type, is_copied_dak, dakListUserParam);

                dakListFlowLayoutPanel.Controls.Clear();


                if (dakDetailsResponse != null)
                {
                    if (dakDetailsResponse.data != null)
                    {
                        DetailsDakUserControl detailsDakUserControl = new DetailsDakUserControl();
                        if (dakDetailsResponse.data.dak_user != null)
                        {
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

                            try
                            {
                                detailsDakUserControl.officerName = dakDetailsResponse.data.movement_status.from.officer;
                                detailsDakUserControl.officerDesignation = "(" + dakDetailsResponse.data.movement_status.from.designation + ")";
                                detailsDakUserControl.officeName = dakDetailsResponse.data.movement_status.from.office;

                            }
                            catch
                            {

                            }



                            // Attachment Call
                            DakAttachmentResponse dakAttachmentResponse = _dakListService.GetDakAttachmentbyDakId(dak_id, dak_type, is_copied_dak, dakListUserParam);
                            if (dakAttachmentResponse != null)
                            {
                                if (dakAttachmentResponse.data != null)
                                {
                                    detailsDakUserControl.dakAttachmentResponse = dakAttachmentResponse;
                                }
                            }

                            dakListFlowLayoutPanel.Controls.Add(detailsDakUserControl);

                        }
                    }
                }
            }

        }

        private void DakSendButtonClicked(int dak_id, string dak_type, int is_copied_dak, string dak_subject)
        {
            dashboardSlideFlowLayoutPanel.Controls.Clear();
            movementStatusDisplaypanel.Visible = true;


            rightSliderHeadLineLabel.Text = "ডাক প্রেরণ করুন";
            DisabledOtherControlExceptLeftPopUpPanel(this.Controls);

            DakForwardUserControl dakSendUserControl = new DakForwardUserControl();



            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakSendUserControl.designationSealListResponse = designationSealListResponse;
            dakSendUserControl.dak_id = dak_id;
            dakSendUserControl.dak_subject = dak_subject;
            dakSendUserControl.dak_type = dak_type;
            dakSendUserControl.is_copied_dak = is_copied_dak;
            dakSendUserControl.dak_List_User_Param = dakListUserParam;
            dakSendUserControl.ButtonClick += delegate (object sender, EventArgs e) { sliderCrossButton_Click(sender, e); };




            dashboardSlideFlowLayoutPanel.Controls.Add(dakSendUserControl);
        }

        private void GetDakMovementList(int dak_id, string dak_type, int is_copied_dak)
        {

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DakMovementStatusResponse dakMovementStatusResponse = _dakListService.GetDakMovementStatusListbyDakId(dak_id, dak_type, is_copied_dak, dakListUserParam);

            dashboardSlideFlowLayoutPanel.Controls.Clear();
            movementStatusDisplaypanel.Visible = true;


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

                            dashboardSlideFlowLayoutPanel.Controls.Add(movementStatusLeftSidePicUserControl);
                        }








                    }
                }
            }
            DisabledOtherControlExceptLeftPopUpPanel(this.Controls);


        }
        void DisabledOtherControlExceptLeftPopUpPanel(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl.Name == "movementStatusDisplaypanel")
                {
                    continue;
                }

                ctrl.Enabled = false;
                DisabledOtherControlExceptLeftPopUpPanel(ctrl.Controls);
            }

        }
        void EnableOtherControlExceptLeftPopUpPanel(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl.Name == "movementStatusDisplaypanel")
                {
                    continue;
                }

                ctrl.Enabled = true;
                EnableOtherControlExceptLeftPopUpPanel(ctrl.Controls);
            }

        }
        public Dashboard(List<DakListRecordsDTO> dakLists)
        {
            InitializeComponent();
            HideSubmenu();
            detailsDakSearcPanel.Visible = false;
            nameorDesignationSearchPanel.Visible = false;
            LoadReadDakComboBox();
        }

        private void LoadReadDakComboBox()
        {
            dakAttentionTypeComboBox.SelectedIndex = comboBox1.Items.IndexOf("সকল");
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

        private void button12_Click(object sender, EventArgs e)
        {

        }






        private void LoadDakOutbox()
        {
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            // Satic Class
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            dakListUserParam.api = "https://a2i.nothibs.tappware.com/api/dak/outbox";

            DakListOutboxResponse dakListOutboxResponse = _dakOutboxService.GetDakOutbox(dakListUserParam);

            if (dakListOutboxResponse.status == "success")
            {
                _dakOutboxService.SaveorUpdateDakOutbox(dakListOutboxResponse);

                if (dakListOutboxResponse.data.records.Count > 0)
                {
                    LoadDakOutboxinPanel(dakListOutboxResponse.data.records);
                }

            }
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

                dakOutboxUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;


                dakOutboxUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status.to);
                dakOutboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakOutboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakOutboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakOutboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakOutboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakOutboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakOutboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                i = i + 1;
                dakOutboxUserControls.Add(dakOutboxUserControl);

            }
            dakListFlowLayoutPanel.Controls.Clear();
            dakListFlowLayoutPanel.AutoScroll = true;
            dakListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            dakListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= dakOutboxUserControls.Count - 1; j++)
            {
                dakListFlowLayoutPanel.Controls.Add(dakOutboxUserControls[j]);
            }
        }

        private string GetDakListMainReceiverName(List<ToDTO> to)
        {
            try
            {
                ToDTO toDTOs = to.FirstOrDefault(a => a.attention_type == "1");
                return toDTOs.officer;
            }
            catch
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
            NormalizeDashBoard();
            _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            SetDefaultFont(this.Controls);
            LoadDakInbox();
        }



        private async void LoadDakInbox()
        {
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;



            try
            {
                var dakInbox = await Task.Run(() => _dakInbox.GetDakInbox(dakListUserParam));
                if (dakInbox.status == "success")
                {


                    _dakInbox.SaveorUpdateDakInbox(dakInbox);
                    if (dakInbox.data.records.Count > 0)
                    {

                        LoadDakInboxinPanel(dakInbox.data.records);

                    }

                }
            }
            catch
            {


            }


        }

        private void LoadDakInboxinPanel(List<DakListRecordsDTO> dakLists)
        {
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
                dakInboxUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status.to);
                dakInboxUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakInboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakInboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakInboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakInboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakInboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakInboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakInboxUserControl.dakid = dakListInboxRecordsDTO.dak_user.dak_id;
                dakInboxUserControl.dakArchiveUserId = dakListInboxRecordsDTO.dak_user.archived_dak_user_id;
                dakInboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakInboxUserControl.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                dakInboxUserControl.DakArchiveButtonClick += delegate (object sender, EventArgs e) { DakArchive_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                i = i + 1;
                dakInboxUserControls.Add(dakInboxUserControl);

            }
            dakListFlowLayoutPanel.Controls.Clear();
            dakListFlowLayoutPanel.AutoScroll = true;
            dakListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            dakListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= dakInboxUserControls.Count - 1; j++)
            {
                dakListFlowLayoutPanel.Controls.Add(dakInboxUserControls[j]);
            }




        }

        private void DakArchive_ButtonClick(object sender, EventArgs e, int dakid, string dak_type, string dak_subject, int is_copied_dak)
        {
            DakArchiveResponse dakArchiveResponse = _dakArchiveService.GetDakArcivedResponse(_dakuserparam, dakid, dak_type, is_copied_dak);
            if (dakArchiveResponse.status == "success")
            {
                ReloadBodyPanel();
            }
            else
            {
                MessageBox.Show("ডাক আর্কাইভ সফল হ​য়নি!");
            }

        }

        private void NothiteUposthapito_ButtonClick(object sender, EventArgs e, int dakid, string dak_type, string dak_subject, int is_copied_dak)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();
            form.dak_type = dak_type;
            form.dakid = dakid;
            form.is_copied_dak = is_copied_dak;
            form.dakSubject = dak_subject;
            Blur();
            form.ShowDialog(this);
            UnBlur();
            ReloadBodyPanel();

        }

        private void ReloadBodyPanel()
        {
            var dakInboxUserControl = dakListFlowLayoutPanel.Controls.OfType<DakInboxUserControl>().ToList();

            if (dakInboxUserControl != null)
            {
                LoadDakInbox();
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
            dakSortMetroPanel.Visible = true;

            ResetAllMenuButtonSelection();
            SelectButton(dakInboxButton);
            DakListLoad();
            LoadDakInbox();
        }

        private void ResetAllMenuButtonSelection()
        {
            IterateControlsReseatSelection(dakMenuPanel.Controls);



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

        private void dakOutboxButton_Click_1(object sender, EventArgs e)
        {

        }

        private void xTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void docketingNoSearchXTextBox_MouseHover(object sender, EventArgs e)
        {
            //if (docketingNoSearchXTextBox.Text == "ডকেটিং নং")
            //{
            //    docketingNoSearchXTextBox.Text = "";
            //}
            //else if(docketingNoSearchXTextBox.Text == "")
            //{
            //    docketingNoSearchXTextBox.Text = "ডকেটিং নং";
            //}
        }



        private void nameDesignationSearchButton_Click(object sender, EventArgs e)
        {
            if (nameorDesignationSearchPanel.Visible == false)
            {
                nameorDesignationSearchPanel.Visible = true;
                nameorDesignationSearchPanel.BringToFront();
                nameorDesignationSearchXTextBox.Focus();
            }
            else
            {
                nameorDesignationSearchPanel.Visible = false;


            }
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

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();
            LoadDakNothivukto();
        }


        private void LoadDakNothivukto()
        {
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;



            var dakInbox = _dakNothivuktoService.GetNothivuktoDakList(dakListUserParam);
            if (dakInbox.status == "success")
            {
                _dakNothivuktoService.SaveorUpdateDakNothivukto(dakInbox);

                if (dakInbox.data.records.Count > 0)
                {

                    LoadDakNothivuktoinPanel(dakInbox.data.records);

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

                dakNothivuktoUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status.to);
                dakNothivuktoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakNothivuktoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakNothivuktoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakNothivuktoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakNothivuktoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakNothivuktoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakNothivuktoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                if (dakListInboxRecordsDTO.nothi != null)
                {
                    dakNothivuktoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                }
                dakNothivuktoUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                i = i + 1;
                dakNothivuktoUserControls.Add(dakNothivuktoUserControl);

            }
            dakListFlowLayoutPanel.Controls.Clear();
            dakListFlowLayoutPanel.AutoScroll = true;
            dakListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            dakListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= dakNothivuktoUserControls.Count - 1; j++)
            {
                dakListFlowLayoutPanel.Controls.Add(dakNothivuktoUserControls[j]);
            }




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

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            DakListLoad();
            LoadDakArchive();
        }

        private void LoadDakArchive()
        {
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;



            var dakArchive = _dakArchiveService.GetDakList(dakListUserParam);
            if (dakArchive.status == "success")
            {
                _dakArchiveService.SaveorUpdateDakArchive(dakArchive);
                if (dakArchive.data.records.Count > 0)
                {

                    LoadDakArchiveinPanel(dakArchive.data.records);

                }

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
                    dakArchiveUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status.to);
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
                dakArchiveUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                i = i + 1;
                dakArchiveUserControls.Add(dakArchiveUserControl);

            }
            dakListFlowLayoutPanel.Controls.Clear();
            dakListFlowLayoutPanel.AutoScroll = true;
            dakListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            dakListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= dakArchiveUserControls.Count - 1; j++)
            {
                dakListFlowLayoutPanel.Controls.Add(dakArchiveUserControls[j]);
            }




        }

        private void DakArchiveRevert_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, string dak_subject, int is_copied_dak)
        {
            throw new NotImplementedException();
        }

        private void dakOutboxButton_Click(object sender, EventArgs e)
        {

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();
            LoadDakOutbox();
        }

        private void DakListLoad()
        {
            dakListFlowLayoutPanel.Controls.Clear();
            NormalizeDashBoard();



        }

        private void NormalizeDashBoard()
        {
            detailsDakSearcPanel.Visible = false;
            dakSortMetroPanel.Visible = true;
            dakSearchHeadingPanel.Visible = true;
            designationDetailsPanel.Visible = false;
        }

        private void LoadDakNothijato()
        {
            NormalizeDashBoard();

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;


            var dakNothijato = _dakNothijatoService.GetNothijatoDak(dakListUserParam);
            if (dakNothijato.status == "success")
            {
                _dakNothijatoService.SaveorUpdateDakNothijato(dakNothijato);
                if (dakNothijato.data.records.Count > 0)
                {

                    LoadDakNothijatoinPanel(dakNothijato.data.records);

                }

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

                dakNothijatoUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status.to); ;
                dakNothijatoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakNothijatoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakNothijatoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakNothijatoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakNothijatoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakNothijatoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakNothijatoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                dakNothijatoUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakNothijatoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                i = i + 1;
                dakNothijatoUserControls.Add(dakNothijatoUserControl);

            }
            dakListFlowLayoutPanel.Controls.Clear();
            dakListFlowLayoutPanel.AutoScroll = true;
            dakListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            dakListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= dakNothijatoUserControls.Count - 1; j++)
            {
                dakListFlowLayoutPanel.Controls.Add(dakNothijatoUserControls[j]);
            }




        }

        private void nothijatoButton_Click(object sender, EventArgs e)
        {

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();
            LoadDakNothijato();
        }

        private void dakSearchButton_Click(object sender, EventArgs e)
        {
            NormalizeDashBoard();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();
        }

        private void dakSortButton_Click(object sender, EventArgs e)
        {

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();

            LoadDakListSorted();

        }

        private void LoadDakListSorted()
        {
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;


            var dakSorted = _dakListSortedService.GetDakList(dakListUserParam);
            if (dakSorted.status == "success")
            {
                // _dakListSortedService.SaveorUpdateDakSorted(dakSorted);
                if (dakSorted.data.records.Count > 0)
                {

                    LoadDakSortedinPanel(dakSorted.data.records);

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

                dakSortedUserControl.receiver = GetDakListMainReceiverName(dakListInboxRecordsDTO.movement_status.to);
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
                dakSortedUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                i = i + 1;
                dakSortedUserControls.Add(dakSortedUserControl);

            }
            dakListFlowLayoutPanel.Controls.Clear();
            dakListFlowLayoutPanel.AutoScroll = true;
            dakListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            dakListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= dakSortedUserControls.Count - 1; j++)
            {
                dakListFlowLayoutPanel.Controls.Add(dakSortedUserControls[j]);
            }
        }



        private void EnableController()
        {
            EnableOtherControlExceptLeftPopUpPanel(this.Controls);
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            movementStatusDisplaypanel.Visible = false;


            EnableController();
            //LoadDakInbox();
        }

        private void daptorikDakUploadButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);


            DaptorikDakSavePageLoad(null);
        }

        private void DakSend_ButtonClick(object sender, EventArgs e, DakUploadParameter dakUploadParameter, DakUserParam dakListUserParam)
        {

            DakSendResponse dakSendResponse = _dakuploadservice.GetDakSendResponse(dakListUserParam, dakUploadParameter);
            try
            {
                if (dakSendResponse.status == "error")
                {
                    MessageBox.Show("ডাকটি প্রেরণ সফল হইনি!");
                }
                else if (dakSendResponse.status == "success")
                {
                    MessageBox.Show(dakSendResponse.data.message);
                    LoadDakOutbox();

                }
            }
            catch (Exception Ex)
            {
                LoadDakOutbox();
            }
        }

        private void AddDesignationUserControl_ButtonClick(object sender, EventArgs e)
        {




            var form = FormFactory.Create<AddDesignationSeal>();

            form.ShowDialog();
            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(_dakuserparam);
            try
            {
                var daptorikDakList = dakListFlowLayoutPanel.Controls.OfType<DaptorikDakUploadUserControl>().ToList();

                foreach (var daptorikDak in daptorikDakList)
                {
                    daptorikDak.designationSealListResponse = designationSealListResponse;


                }
            }

            catch (Exception Ex)
            {

            }


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
                    MessageBox.Show("ডাকটি প্রেরণ সফল হইনি!");
                }
                else if (dakDraftedResponse.status == "success")
                {
                    MessageBox.Show(dakDraftedResponse.message);
                    LoadDakKhasraList();

                }
            }
            catch (Exception Ex)
            {
                LoadDakKhasraList();
            }

        }

        private void nagorikDakUploadMenuButton_Click(object sender, EventArgs e)
        {
            dakSortMetroPanel.Visible = false;
            dakSearchHeadingPanel.Visible = false;
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);

            dakListFlowLayoutPanel.Controls.Clear();

            NagorikDakUploadUserControl dakUploadUserControl = new NagorikDakUploadUserControl();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakUploadUserControl.designationSealListResponse = designationSealListResponse;


            dakListFlowLayoutPanel.Controls.Add(dakUploadUserControl);
        }

        private void KhasraDakButton_Click(object sender, EventArgs e)
        {

            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            LoadDakKhasraList();
        }

        private void LoadDakKhasraList()
        {
            NormalizeDashBoard();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            // Satic Class
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;

            DakListKhosraResponse dakListKhosraResponse = _dakkhosraservice.GetDakKhosraList(dakListUserParam);

            if (dakListKhosraResponse.status == "success")
            {
                //Save This

                if (dakListKhosraResponse.data.records.Count > 0)
                {
                    LoadDakKhosrainPanel(dakListKhosraResponse.data.records);
                }

            }
        }

        private void LoadDakKhosrainPanel(List<DakListRecordsDTO> dakLists)
        {
            List<DraftedDakUserControl> draftedDakUserControls = new List<DraftedDakUserControl>();
            int i = 0;
            foreach (DakListRecordsDTO dakListInboxRecordsDTO in dakLists)
            {


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
                draftedDakUserControl.DraftedDakSendButtonClick += delegate (object sender, EventArgs e) { DraftedDakSend_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                draftedDakUserControl.DraftedDakDeleteButtonClick += delegate (object sender, EventArgs e) { DraftedDakDelete_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                draftedDakUserControl.DraftedDakEditButtonClick += delegate (object sender, EventArgs e) { DraftedDakEdit_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


                i = i + 1;
                draftedDakUserControls.Add(draftedDakUserControl);

            }
            dakListFlowLayoutPanel.Controls.Clear();
            dakListFlowLayoutPanel.AutoScroll = true;
            dakListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            dakListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= draftedDakUserControls.Count - 1; j++)
            {
                dakListFlowLayoutPanel.Controls.Add(draftedDakUserControls[j]);
            }
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
            dakSearchHeadingPanel.Visible = false;
            dakListFlowLayoutPanel.Controls.Clear();

            DaptorikDakUploadUserControl dakUploadUserControl = new DaptorikDakUploadUserControl();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakUploadUserControl.designationSealListResponse = designationSealListResponse;
            dakUploadUserControl.dakListUserParam = dakListUserParam;
            dakUploadUserControl.KhosraSaveButtonClick += delegate (object khosraSaveSender, EventArgs khosraSaveEvent) { khosraSaveUserControl_ButtonClick(khosraSaveSender, khosraSaveEvent, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam); };
            dakUploadUserControl.AddDesignationButtonClick += delegate (object addDesignationSender, EventArgs addDesignationEvent) { AddDesignationUserControl_ButtonClick(addDesignationSender, addDesignationEvent); };
            dakUploadUserControl.DakSendButton += delegate (object addDesignationSender, EventArgs addDesignationEvent) { DakSend_ButtonClick(addDesignationSender, addDesignationEvent, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam); };





            if (dakEditResponse != null)
            {
                dakUploadUserControl.mul_prapokEdit = dakEditResponse.data.receiver.mul_prapok;
                dakUploadUserControl.onulipi = dakEditResponse.data.receiver.Onulipi;
                dakUploadUserControl.dakInfoDTO = dakEditResponse.data.dak;
                dakUploadUserControl.dakAttachmentDTOs = dakEditResponse.data.dak.attachments;
            }

            dakListFlowLayoutPanel.Controls.Add(dakUploadUserControl);
        }

        private void DraftedDakDelete_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, int is_copied_dak)
        {
            DraftedDakDeleteResponse dakDeleteResponse = _dakuploadservice.GetDraftedDakDeleteResponse(_dakuserparam, dak_id, dak_type, is_copied_dak);
            try
            {
                if (dakDeleteResponse.status == "error")
                {
                    MessageBox.Show("ডাকটি মুছন সফল হইনি!");
                }
                else if (dakDeleteResponse.status == "success")
                {
                    MessageBox.Show(dakDeleteResponse.data);
                    LoadDakKhasraList();

                }
            }
            catch (Exception Ex)
            {
                LoadDakKhasraList();
            }
        }

        private void DraftedDakSend_ButtonClick(object sender, EventArgs e, int dak_id, string dak_type, int is_copied_dak)
        {

            DakSendResponse dakSendResponse = _dakuploadservice.GetDraftedDakSendResponse(_dakuserparam, dak_id, dak_type, is_copied_dak);
            try
            {
                if (dakSendResponse.status == "error")
                {
                    MessageBox.Show("ডাকটি প্রেরণ সফল হইনি!");
                }
                else if (dakSendResponse.status == "success")
                {
                    MessageBox.Show(dakSendResponse.data.message);
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
                designationDetailsPanel.Visible = true;
                designationDetailsPanel.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
            }
            else
            {
                designationDetailsPanel.Visible = false;
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
            NormalizeDashBoard();
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
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
    }


    public class BitmapFilter
    {
        private static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                            (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                            (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }

        public static bool GaussianBlur(Bitmap b, int nWeight /* default to 4*/)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Factor = nWeight + 12;

            return BitmapFilter.Conv3x3(b, m);
        }

        public class ConvMatrix
        {
            public int TopLeft = 0, TopMid = 0, TopRight = 0;
            public int MidLeft = 0, Pixel = 1, MidRight = 0;
            public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
            public int Factor = 1;
            public int Offset = 0;
            public void SetAll(int nVal)
            {
                TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
            }
        }
    }

    class Screenshot
    {
        public static Bitmap TakeSnapshot(Control ctl)
        {
            Bitmap bmp = new Bitmap(ctl.Size.Width, ctl.Size.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
            g.CopyFromScreen(ctl.PointToScreen(ctl.ClientRectangle.Location), new Point(0, 0), ctl.ClientRectangle.Size);
            return bmp;
        }
    }
}
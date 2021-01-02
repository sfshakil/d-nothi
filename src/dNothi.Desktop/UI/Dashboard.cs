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

namespace dNothi.Desktop.UI
{
    public partial class Dashboard : Form
    {

        IUserService _userService { get; set; }
        IDakKhosraService _dakkhosraservice { get; set; }
        IDakListService _dakListService { get; set; }
        IDakOutboxService _dakOutboxService { get; set; }
        IDakUploadService _dakuploadservice { get; set; }
        IDakInboxServices _dakInbox { get; set; }

        IDakListArchiveService _dakListArchiveService { get; set; }
        IDakNothijatoService _dakNothijatoService { get; set; }

        IDakNothivuktoService _dakNothivuktoService { get; set; }
        IDakListSortedService _dakListSortedService { get; set; }
        IDakForwardService _dakForwardService { get; set; }

        public Dashboard(IDakInboxServices dakInbox,
            IUserService userService,
            IDakOutboxService dakOutboxService,
            IDakNothivuktoService dakNothivuktoService,
            IDakListArchiveService dakListArchiveService,
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
            _dakListArchiveService = dakListArchiveService;
            _dakNothijatoService = dakNothijatoService;
            _dakListService = dakListService;
            _dakListSortedService = dakListSortedService;
            _dakForwardService = dakForwardService;
            _dakkhosraservice = dakKhosraService;
            _dakuploadservice = dakUploadService;
            InitializeComponent();
            designationDetailPanel.Hide();
            dashboardSlideFlowLayoutPanel.BringToFront();

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
                            movementStatusLeftSidePicUserControl.movementStatusDTO = movementStatusDTO;
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
            MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
            dakInboxButton.Font = MemoryFonts.GetFont(0, 14);
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

            //var dakInboxList = _dakInbox.GetLocalDakInbox(dakListUserParam);

            //if (dakInboxList.data.records.Count > 0)
            //{

            //    LoadDakInboxinPanel(dakInboxList.data.records);

            //}
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
                dakInboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
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
                ctrl.ForeColor = Color.Black;


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



            var dakArchive = _dakListArchiveService.GetDakList(dakListUserParam);
            if (dakArchive.status == "success")
            {
                _dakListArchiveService.SaveorUpdateDakArchive(dakArchive);
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

            dakSortMetroPanel.Visible = false;
            dakSearchHeadingPanel.Visible = false;
            dakListFlowLayoutPanel.Controls.Clear();

            DaptorikDakUploadUserControl dakUploadUserControl = new DaptorikDakUploadUserControl();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakUploadUserControl.designationSealListResponse = designationSealListResponse;
            dakUploadUserControl.dakListUserParam = dakListUserParam;
            dakUploadUserControl.KhosraSaveButtonClick += delegate (object khosraSaveSender, EventArgs khosraSaveEvent) { khosraSaveUserControl_ButtonClick(sender, e, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam); };
            dakUploadUserControl.AddDesignationButtonClick += delegate (object addDesignationSender, EventArgs addDesignationEvent) { AddDesignationUserControl_ButtonClick(sender, e); };
            dakUploadUserControl.DakSendButton += delegate (object addDesignationSender, EventArgs addDesignationEvent) { DakSend_ButtonClick(sender, e, dakUploadUserControl.dakUploadParameter, dakUploadUserControl.dakListUserParam); };


            dakListFlowLayoutPanel.Controls.Add(dakUploadUserControl);
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
            form.Show();
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
                //  draftedDakUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


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
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
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
            if (designationDetailPanel.Visible)
            {
                designationDetailPanel.Visible = false;
            }
            else
            {
                designationDetailPanel.Visible = true;
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
            //Button button = new Button();
            //button.BackColor = Color.Transparent;
            //button.Text = "শারমিন ফেরদৌসি(প্রজেক্ট এ্যাসিসটেন্ট";

            //dakSortingUserFlowLayoutPanel.Controls.Add(button);


        }

    }
}

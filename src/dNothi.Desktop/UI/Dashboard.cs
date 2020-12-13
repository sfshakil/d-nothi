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
        IDakListService _dakListService { get; set; }
        IDakOutboxService _dakOutboxService { get; set; }
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
            InitializeComponent();
            designationSelect2.Hide();
            dashboardSlideFlowLayoutPanel.BringToFront();

        }

        

        protected void UserControl_ButtonClick(object sender, EventArgs e,int dak_id,string dak_type, int is_copied_dak)
        {
            string s = (sender as Control).Name;

            if (s== "dakMovementStatusButton")
            {
                GetDakMovementList(dak_id, dak_type, is_copied_dak);
            }
            
           else if (s== "DakSendButton")
            {
                DakSendButtonClicked(dak_id, dak_type, is_copied_dak);
            }

           else
            {
                dakSortMetroPanel.Visible = false;
                DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();


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

        private void DakSendButtonClicked(int dak_id, string dak_type, int is_copied_dak)
        {
            dashboardSlideFlowLayoutPanel.Controls.Clear();
            movementStatusDisplaypanel.Visible = true;


            rightSliderHeadLineLabel.Text = "ডাক প্রেরণ করুন";
            DisabledOtherControlExceptLeftPopUpPanel(this.Controls);

            DakSendUserControl dakSendUserControl = new DakSendUserControl();



            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakSendUserControl.designationSealListResponse = designationSealListResponse;
            dakSendUserControl.dak_id = dak_id;
            dakSendUserControl.dak_type = dak_type;
            dakSendUserControl.is_copied_dak = is_copied_dak;
            dakSendUserControl.dak_List_User_Param = dakListUserParam;
            dakSendUserControl.ButtonClick += delegate (object sender, EventArgs e) { sliderCrossButton_Click(sender, e); };




            dashboardSlideFlowLayoutPanel.Controls.Add(dakSendUserControl);
        }

        private void GetDakMovementList(int dak_id, string dak_type, int is_copied_dak)
        {

            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DakMovementStatusResponse dakMovementStatusResponse = _dakListService.GetDakMovementStatusListbyDakId(dak_id, dak_type, is_copied_dak, dakListUserParam);

            dashboardSlideFlowLayoutPanel.Controls.Clear();
            movementStatusDisplaypanel.Visible = true;


            if (dakMovementStatusResponse != null)
            {
                if (dakMovementStatusResponse.data != null)
                {
                 
                    if (dakMovementStatusResponse.data.records != null)
                    {
                        foreach(MovementStatusDTO movementStatusDTO in dakMovementStatusResponse.data.records)
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
                if(ctrl.Name== "movementStatusDisplaypanel")
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

        private  void HideSubmenu()
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
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.AutoSize = true;
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            this.label1.Size = new System.Drawing.Size(19, 20);
        }

        private void xTextBox2_MouseHover(object sender, EventArgs e)
        {
            this.xTextBox2.Text = "";
            this.xTextBox2.BackColor = Color.WhiteSmoke;
        }

        private void xTextBox2_MouseLeave(object sender, EventArgs e)
        {
            this.xTextBox2.Text = "খুঁজুন";
            this.xTextBox2.BackColor = Color.Gainsboro;
        }

        private void xTextBox2_MouseEnter(object sender, EventArgs e)
        {
            this.xTextBox2.Text = "";
            this.xTextBox2.BackColor = Color.WhiteSmoke;
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (designationSelect2.Width == 428)
            {
                designationSelect2.Show();
                designationSelect2.Width = 427;
                button15.BackColor = Color.WhiteSmoke;
                designationSelect2.BringToFront();
            }
            else
            {
                designationSelect2.Hide();
                designationSelect2.Width = 428;
            }
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
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }
   
      

       


        private void LoadDakOutbox()
        {
            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();

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
                dakOutboxUserControl.source=IsNagorikDakType(dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_origin.sender_name, dakListInboxRecordsDTO.dak_origin.name_bng);


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
                dakOutboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


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
            LoadDakInbox();
        }

        private void LoadDakInbox()
        {
            DakListUserParam dakListUserParam= _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
           


            try
            {
                var dakInbox = _dakInbox.GetDakInbox(dakListUserParam);
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
                dakInboxUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e,dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
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
            if(dakUploadDropDownPanel.Visible==true)
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
            dakSearchButton.BackColor=Color.WhiteSmoke;
            dakSearchButton.ForeColor = Color.Black;

            dakArchiveButton.BackColor = Color.WhiteSmoke;
            dakArchiveButton.ForeColor = Color.Black;

            dakInboxButton.BackColor = Color.WhiteSmoke;
            dakInboxButton.ForeColor = Color.Black;

            dakOutboxButton.BackColor = Color.WhiteSmoke;
            dakOutboxButton.ForeColor = Color.Black;


            dakNothijatoButton.BackColor = Color.WhiteSmoke;
            dakNothijatoButton.ForeColor = Color.Black;

            dakNotivuktoButton.BackColor = Color.WhiteSmoke;
            dakNotivuktoButton.ForeColor = Color.Black;

            dakSortButton.BackColor = Color.WhiteSmoke;
            dakSortButton.ForeColor = Color.Black;


        }

        private void SelectButton(Button button)
        {
            button.BackColor = Color.Silver;
            button.ForeColor = Color.Blue;
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

        private void docketingNoSearchXTextBox_MouseLeave(object sender, EventArgs e)
        {
            if(docketingNoSearchXTextBox.Text == "")
            {
                docketingNoSearchXTextBox.Text = "ডকেটিং নং";
            }
            
            
        }

        private void docketingNoSearchXTextBox_MouseEnter(object sender, EventArgs e)
        {

            if (docketingNoSearchXTextBox.Text == "ডকেটিং নং")
            {
                docketingNoSearchXTextBox.Text = "";
            }

        }

        private void applicationAcceptNumberXTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (applicationAcceptNumberXTextBox.Text == "আবেদন গ্রহন নাম্বার")
            {
                applicationAcceptNumberXTextBox.Text = "";
            }
        }

        private void applicationAcceptNumberXTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (applicationAcceptNumberXTextBox.Text == "")
            {
                applicationAcceptNumberXTextBox.Text = "আবেদন গ্রহন নাম্বার";
            }

        }

        private void nameDesignationSearchButton_Click(object sender, EventArgs e)
        {
           if(nameorDesignationSearchPanel.Visible==false)
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

        private void notvuktoDakButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            DakListLoad();
            LoadDakNothivukto();
        }


        private void LoadDakNothivukto()
        {
            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();

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
                dakNothivuktoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

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
                officerSenderOfficeNameTextBox.Visible = true;
            }
            else
            {
                officerSenderOfficeNameTextBox.Visible = false;
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
                officeSenderOfficeNameTextBox.Visible = true;
            }
            else
            {
                officeSenderOfficeNameTextBox.Visible = false;
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
         
            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();

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
                    if(dakListInboxRecordsDTO.nothi !=null)
                      {
                               dakArchiveUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                      }
                dakArchiveUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
                dakArchiveUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


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
            detailsDakSearcPanel.Visible = false;
        }

        private void LoadDakNothijato()
        {

            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();

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
                dakNothijatoUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

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
            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();

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
                dakSortedUserControl.ButtonClick += delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakListInboxRecordsDTO.dak_user.dak_id, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.is_copied_dak); };


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
            LoadDakInbox();
        }

        private void daptorikDakUploadButton_Click(object sender, EventArgs e)
        {
            dakSortMetroPanel.Visible = false;
            dakListFlowLayoutPanel.Controls.Clear();

            DakUploadUserControl dakUploadUserControl = new DakUploadUserControl();
            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(dakListUserParam);




            dakUploadUserControl.designationSealListResponse = designationSealListResponse;


            dakListFlowLayoutPanel.Controls.Add(dakUploadUserControl);
        }
    }
}

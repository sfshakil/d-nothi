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

namespace dNothi.Desktop.UI
{
    public partial class Dashboard : Form
    {
        IUserService _userService { get; set; }
        IDakOutboxService _dakOutboxService { get; set; }
        IDakInboxServices _dakInbox { get; set; }
        IDakListArchiveService _dakListArchiveService { get; set; }
        IDakNothijatoService _dakNothijatoService { get; set; }

        IDakNothivuktoService _dakNothivuktoService { get; set; }

        public Dashboard(IDakInboxServices dakInbox,
            IUserService userService,
            IDakOutboxService dakOutboxService,
            IDakNothivuktoService dakNothivuktoService,
            IDakListArchiveService dakListArchiveService,
            IDakNothijatoService dakNothijatoService)
        {
            _dakNothivuktoService = dakNothivuktoService;
            _userService = userService;
            _dakOutboxService = dakOutboxService;
            _dakInbox = dakInbox;
            _dakListArchiveService = dakListArchiveService;
            _dakNothijatoService = dakNothijatoService;
            InitializeComponent();
            designationSelect2.Hide();
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
        private void HideOtherSubMenuButThis()
        {
    
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
            this.notvuktoDakButton.ForeColor = Color.DodgerBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.notvuktoDakButton.ForeColor = Color.Black;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.nothijatoButton.ForeColor = Color.DodgerBlue;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.nothijatoButton.ForeColor = Color.Black;
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
        private bool IsCollasped;
      

       


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
                dakOutboxUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakOutboxUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakOutboxUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakOutboxUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
                dakOutboxUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakOutboxUserControl.receiver = dakListInboxRecordsDTO.movement_status.to[0].officer;
                dakOutboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakOutboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakOutboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakOutboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakOutboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakOutboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;


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

        private void OnLoad(object sender, EventArgs e)
        {
            LoadDakInbox();
        }

        private void LoadDakInbox()
        {
            DakListUserParam dakListUserParam= _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            dakListUserParam.api = "https://a2i.nothibs.tappware.com/api/dak/inbox";


            var dakInbox = _dakInbox.GetDakInbox(dakListUserParam);
            if (dakInbox.status == "success")
            {
                foreach (var record in dakInbox.data.records)
                {
                    _dakInbox.SaveOrUpdateDakUser(record.dak_user);
                }
                if (dakInbox.data.records.Count > 0)
                {

                    LoadDakInboxinPanel(dakInbox.data.records);

                }

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
                dakInboxUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
                dakInboxUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakInboxUserControl.receiver = dakListInboxRecordsDTO.movement_status.to[0].officer;
                dakInboxUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakInboxUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakInboxUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakInboxUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakInboxUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakInboxUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakInboxUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
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
            DakListLoad();
            LoadDakInbox();
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
            DakListLoad();
            LoadDakNothivukto();
        }


        private void LoadDakNothivukto()
        {
            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            dakListUserParam.api = "https://a2i.nothibs.tappware.com/api/dak/nothivukto";


            var dakInbox = _dakNothivuktoService.GetNothivuktoDakList(dakListUserParam);
            if (dakInbox.status == "success")
            {
               
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
                dakNothivuktoUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakNothivuktoUserControl.receiver = dakListInboxRecordsDTO.movement_status.to[0].officer;
                dakNothivuktoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakNothivuktoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakNothivuktoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakNothivuktoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakNothivuktoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakNothivuktoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakNothivuktoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
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
            DakListLoad();
            LoadDakArchive();
        }

        private void LoadDakArchive()
        {
         
            DakListUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            dakListUserParam.api = "https://a2i.nothibs.tappware.com/api/dak/onulipi";


            var dakArchive = _dakListArchiveService.GetDakList(dakListUserParam);
            if (dakArchive.status == "success")
            {

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
                dakArchiveUserControl.source = dakListInboxRecordsDTO.dak_origin.sender_name;
                dakArchiveUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakArchiveUserControl.receiver = dakListInboxRecordsDTO.movement_status.to[0].officer;
                dakArchiveUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakArchiveUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakArchiveUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakArchiveUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakArchiveUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakArchiveUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakArchiveUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                dakArchiveUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
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
            dakListUserParam.api = "https://a2i.nothibs.tappware.com/api/dak/nothijato";


            var dakNothijato = _dakNothijatoService.GetNothijatoDak(dakListUserParam);
            if (dakNothijato.status == "success")
            {

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
                dakNothijatoUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakNothijatoUserControl.receiver = dakListInboxRecordsDTO.movement_status.to[0].officer;
                dakNothijatoUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;
                dakNothijatoUserControl.attentionTypeIconValue = dakListInboxRecordsDTO.dak_user.attention_type;
                dakNothijatoUserControl.dakSecurityIconValue = dakListInboxRecordsDTO.dak_user.dak_security;
                dakNothijatoUserControl.dakPrioriy = dakListInboxRecordsDTO.dak_user.dak_priority;
                dakNothijatoUserControl.dakType = dakListInboxRecordsDTO.dak_user.dak_type;
                dakNothijatoUserControl.potrojari = dakListInboxRecordsDTO.dak_user.from_potrojari;
                dakNothijatoUserControl.nothiNo = dakListInboxRecordsDTO.nothi.nothi_no;
                dakNothijatoUserControl.dakAttachmentCount = dakListInboxRecordsDTO.attachment_count;
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
            DakListLoad();
            LoadDakNothijato();
        }

        private void dakSearchButton_Click(object sender, EventArgs e)
        {
            DakListLoad();
        }

        private void dakSortButton_Click(object sender, EventArgs e)
        {
            DakListLoad();
        }
    }
}

using dNothi.Desktop.Properties;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class SingleDakUserControl : UserControl
    {
       


     

        public bool _isOfflineDak { get; set; }
        public bool isOfflineDak { get { return _isOfflineDak; } set { _isOfflineDak = value; uploadIconButton.Visible = true; } }


        public bool _IsNothijatoDak { get; set; }
        public bool IsNothijatoDak
        {
            get
            {
                return _IsNothijatoDak;
            }
            set
            {
                _IsNothijatoDak = value;

                dakCheckBox.Visible = false;
                nothiteUposthaponButton.Visible = true;
                dakRevertButton.Visible = true;
                
            }
        }

        public bool _IsInboxDak { get; set; }
        public bool IsInboxDak
        {
            get
            {
                return _IsInboxDak;
            }
            set
            {
                _IsInboxDak = value;


                nothiteUposthaponButton.Visible = true;
                nothijatoButton.Visible = true;
                dakArchiveButton.Visible = true;
                DakSendButton.Visible = true;
              

            }
        }

        public bool _IsSortedDak { get; set; }
        public bool IsSortedDak
        {
            get
            {
                return _IsSortedDak;
            }
            set
            {
                _IsSortedDak = value;


                nothiteUposthaponButton.Visible = true;
                nothijatoButton.Visible = true;
                dakArchiveButton.Visible = true;
                DakSendButton.Visible = true;


            }
        }

        public bool _IsDraftedDak { get; set; }
        public bool IsDraftedDak
        {
            get
            {
                return _IsDraftedDak;
            }
            set
            {
                _IsDraftedDak = value;


                dakMovementStatusButton.Visible = false;
                dakTagButton.Visible = false;
                dakCheckBox.Visible = false;

                dakEditButton.Visible = true;
                draftedDakSendButton.Visible = true;
                dakDeleteButton.Visible = true;


                decisionAndNothiTableLayoutPanel.Visible = false;
                senderTableLayoutPanel.Visible = false;


            }
        }

        public bool _IsNothivuktoDak { get; set; }
        public bool IsNothivuktoDak
        {
            get
            {
                return _IsNothivuktoDak;
            }
            set
            {
                _IsNothivuktoDak = value;


                dakRevertButton.Visible = true;

                dakCheckBox.Visible = false;

            }
        }


        public bool _IsArchivedDak { get; set; }
        public bool IsArchivedDak
        {
            get
            {
                return _IsArchivedDak;
            }
            set
            {
                _IsArchivedDak = value;


                dakRevertButton.Visible = true;
                dakCheckBox.Visible = false;


            }
        }

        public bool _IsOutboxDak { get; set; }
        public bool IsOutboxDak
        {
            get
            {
                return _IsOutboxDak;
            }
            set
            {
                _IsOutboxDak = value;


                dakRevertButton.Visible = true;

                dakCheckBox.Visible = false;

            }
        }

        



        public bool _is_Tag { get; set; }
        public bool is_Tag
        {
            get { return _is_Tag; }
            set
            {
                _is_Tag = value;
                if (value)
                {
                    uploadIconButton.Visible = true;
                    MyToolTip.SetToolTip(uploadIconButton, "ট্যাগ করা হচ্ছে");
                    dakActionPanel.Visible = false;
                }


            }

        }
        public bool _is_Reverted { get; set; }
        public bool is_Reverted
        {
            get { return _is_Reverted; }
            set
            {
                _is_Reverted = value;
                if (value)
                {
                    uploadIconButton.Visible = true;
                    MyToolTip.SetToolTip(uploadIconButton, "ফেরত নেওয়া হচ্ছে");
                    dakActionPanel.Visible = false;
                }


            }

        }
        public bool _is_Forwarded { get; set; }
        public bool is_Forwarded
        {
            get { return _is_Forwarded; }
            set
            {
                _is_Forwarded = value;
                if (value)
                {
                    uploadIconButton.Visible = true;
                    MyToolTip.SetToolTip(uploadIconButton, "প্রেরণ হচ্ছে");
                    dakActionPanel.Visible = false;
                }


            }

        }
        public bool _is_Archived { get; set; }
        public bool is_Archived
        {
            get { return _is_Archived; }
            set
            {
                _is_Archived = value;
                if (value)
                {
                    uploadIconButton.Visible = true;
                    MyToolTip.SetToolTip(uploadIconButton, "আর্কাইভ হচ্ছে");
                    dakActionPanel.Visible = false;
                }


            }

        }
        public bool _is_Nothijato { get; set; }
        public bool is_Nothijato
        {
            get { return _is_Nothijato; }
            set
            {
                _is_Nothijato = value;
                if (value)
                {
                    uploadIconButton.Visible = true;
                    MyToolTip.SetToolTip(uploadIconButton, "নথিজাত হচ্ছে");
                    dakActionPanel.Visible = false;
                }


            }

        }
        public bool _is_Nothivukto { get; set; }
        public bool is_Nothivukto
        {
            get { return _is_Nothivukto; }
            set
            {
                _is_Nothivukto = value;
                if (value)
                {
                    uploadIconButton.Visible = true;
                    MyToolTip.SetToolTip(uploadIconButton, "নথিতে উপস্থাপন হচ্ছে");
                    dakActionPanel.Visible = false;
                }


            }

        }



        private bool MouseIsOverControl() =>
   this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
      
        
        public SingleDakUserControl()
        {
            InitializeComponent();

            dakPriorityIconPanel.Visible = false;
            dakSecurityIconPanel.Visible = false;

            IterateControls(this.Controls);
            SetDefaultFont(this.Controls);
        }

        public bool _isChecked;
        public bool isChecked { get { return _isChecked; } set { _isChecked = value; dakCheckBox.Checked = value; } }

        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl.Font.Style == FontStyle.Regular)
                {
                    // ctrl.Font.Style = "Normal";
                }

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }

        void IterateControls(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                if (ctrl.Name == "dakActionPanel")
                {
                    continue;
                }
                if (ctrl.Name == "dakCheckBox")
                {
                    continue;
                }
                if (ctrl == dakAttachmentButton)
                {
                    continue;
                }
                if (ctrl == dakTagPanel)
                {
                    continue;
                }

                


                ctrl.Click += DakSortedUserControl_Click;
                ctrl.MouseEnter += DakSortedUserControl_MouseEnter;
                ctrl.MouseLeave += DakSortedUserControl_MouseLeave;
                IterateControls(ctrl.Controls);
            }

        }
        private void MouseHoverAction()
        {
            if (MouseIsOverControl())
            {
                this.BackColor = Color.FromArgb(243, 243, 243);
                if (!uploadIconButton.Visible)
                {
                    dakActionPanel.Visible = true;
                }
                //dakActionPanel.Visible = true;
            }
            else
            {
                this.BackColor = Color.White;
                dakActionPanel.Visible = false;
            }
        }

        public List<DakTagDTO> _dak_Tags { get; set; }
        public List<DakTagDTO> dak_Tags
        {
            get
            {
                return _dak_Tags;
            }


            set
            {
                _dak_Tags = value;
                if (value.Count > 0)
                {
                    dakLabel.Text = value[0].tag;
                    dakTagPanel.Visible = true;
                    if (value.Count > 1)
                    {
                        dakTagListButton.Visible = true;
                    }

                }


            }


        }
        public DakListRecordsDTO _dak;
        public DakListRecordsDTO dak { get { return _dak; } set { _dak = value; } }


        private string _nothiNo;
        private string _source;
        private string _sender;
        private string _receiver;
        private string _mainreceiver;
        private string _subject;
        private string _decision;
        private string _drafteddecision;
        private string _date;
        private string _dakViewStatus;

        private string _attentionTypeIconValue;
        private string _dakSecurityIconValue;
        private string _drafteddakSecurityIconValue;
        private string _dakType;
        private string _dakPriority;
        private string _drafteddakPriority;
        private int _potrojari;
        public int _dakAttachmentCount;


       
        private int _is_dak_Archived;
        public int dakArchiveUserId
        {
            get { return _is_dak_Archived; }
            set { _is_dak_Archived = value; }
            //if (_is_dak_Archived == 0){ dakArchiveButton.Visible = false; }
        }

        private int _dakid;
       

        [Category("Custom Props")]
        public int dakid
        {
            get { return _dakid; }
            set { _dakid = value; }
        }

        public DraftedDecisionDTO _draftedDecisionDTO { get; set; }


        public DraftedDecisionDTO draftedDecision
        {
            get { return _draftedDecisionDTO; }
            set
            {
                _draftedDecisionDTO = value;
                try
                {
                    if (draftedDecision.decision != "")
                    {
                        DraftedDecisionLabel.Text += draftedDecision.decision;
                    }
                    else
                    {
                        DraftedDecisionLabel.Visible = false;
                        
                    }

                    DakPriorityList dakPriorityList = new DakPriorityList();
                    string priorityName = dakPriorityList.GetDakPriorityName(draftedDecision.priority);

                    if (priorityName == "")
                    {
                        dakPriorityIconPanel.Visible = false;
                    }
                    else
                    {
                        dakPriorityIconPanel.Visible = true;
                        prioriyLabel.Text = priorityName;

                    }






                    DakSecurityList dakSecurityList = new DakSecurityList();
                    string icon = dakSecurityList.GetDakSecuritiesIcon(draftedDecision.security);
                    string Name = dakSecurityList.GetDakSecuritiesName(draftedDecision.security);

                    dakSecurityIcon.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);

                    if (Name == "")
                    {
                        dakSecurityIconPanel.Visible = false;
                    }
                    else
                    {
                        dakSecurityIconPanel.Visible = true;
                        dakSecurityLabel.Text = Name;
                    }


                    try
                    {
                        mainPrapokButton.Text += draftedDecision.recipients.mul_prapok.employee_name_bng;
                    }
                    catch
                    {
                        mainPrapokButton.Visible = false;
                    }




                }
                catch
                {
                    sortedTableLayoutPanel.Visible = false;
                }

            }
        }

        [Category("Custom Props")]
        public string nothiNo
        {
            get { return _nothiNo; }
            set { 
                _nothiNo = value; 
                if (string.IsNullOrEmpty(value)) 
                { nothiTableLayoutPanel.Visible = false; } 
                else { nothiTableLayoutPanel.Visible = true; nothiNoLabel.Text = value; } 
            }
        }


        [Category("Custom Props")]
        public int dakAttachmentCount
        {
            get { return _dakAttachmentCount; }
            set { _dakAttachmentCount = value; dakAttachmentButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }



        [Category("Custom Props")]
        public int potrojari
        {
            get { return _potrojari; }
            set
            {
                _potrojari = value;



                rightInfoPanel.potrojari = value;







            }
        }

        [Category("Custom Props")]
        public string dakPrioriy
        {
            get { return _dakPriority; }
            set
            {
                _dakPriority = value;




                rightInfoPanel.dakPrioriy = value;








            }
        }

        [Category("Custom Props")]
        public string dakType
        {



            get { return _dakType; }
            set
            {
                _dakType = value;



                rightInfoPanel.dakType = value;






            }
        }


        public void daksource(string value)
        {
            rightInfoPanel.daksource = value;
        }

        [Category("Custom Props")]
        public string dakSecurityIconValue
        {



            get { return _dakSecurityIconValue; }
            set
            {
                _dakSecurityIconValue = value;

                rightInfoPanel.dakSecurityIconValue = value;

                DakSecurityList dakSecurityList = new DakSecurityList();
                string icon = dakSecurityList.GetDakSecuritiesIcon(value);
                string Name = dakSecurityList.GetDakSecuritiesName(value);

                dakSecurityIcon.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);

                if (Name == "")
                {
                    dakSecurityIconPanel.Visible = false;
                }
                else
                {
                    dakSecurityIconPanel.Visible = true;
                    dakSecurityLabel.Text = Name;
                }





            }
        }




        [Category("Custom Props")]
        public string attentionTypeIconValue
        {



            get { return _attentionTypeIconValue; }
            set
            {
                _attentionTypeIconValue = value;
                if (value == "0")
                {
                    dakArchiveButton.Visible = true;
                }
                else
                {
                    dakArchiveButton.Visible = false;
                }
                rightInfoPanel.attentionTypeIconValue = value;







            }
        }



        [Category("Custom Props")]
        public string dakViewStatus
        {
            get { return _dakViewStatus; }
            set
            {
                _dakViewStatus = value;
                rightInfoPanel.dakViewStatus = value;

            }

        }



        [Category("Custom Props")]
        public string source
        {
            get { return _source; }
            set { _source = value; sourceLabel.Text = value; }
        }




        [Category("Custom Props")]
        public string sender
        {
            get { return _sender; }
            set { _sender = value; senderLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string receiver
        {
            get { return _receiver; }
            set { _receiver = value; mainReceiverLabel.Text = value; }
        }


        [Category("Custom Props")]
        public string subject
        {
            get { return _subject; }
            set { _subject = value; subjectLabel.Text = value; }
        }


        [Category("Custom Props")]
        public string decision
        {
            get { return _decision; }
            set { _decision = value; decisionLabel.Text = value; }
        }

        //private int _id;
        //public int id
        //{
        //    get { return _id; }
        //    set { _id = value;}
        //}

        [Category("Custom Props")]
        public string date
        {
            get { return _date; }
            set { _date = value; dateLabel.Text = value; }
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DakSortedUserControl_MouseHover(object sender, EventArgs e)
        {

        }

        private void subjectLabel_Click(object sender, EventArgs e)
        {

        }

        private void DakSortedUserControl_MouseEnter(object sender, EventArgs e)
        {
            MouseHoverAction();
        }

        private void DakSortedUserControl_MouseLeave(object sender, EventArgs e)
        {
            MouseHoverAction();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;
        private void DakSortedUserControl_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }




        public event EventHandler DakAttachmentButton;

        private void DakAttachmentButton_Click(object sender, EventArgs e)
        {


            if (this.DakAttachmentButton != null)
                this.DakAttachmentButton(sender, e);
        }

        private void dakMovementButton_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }

        private void dakMovementStatusButton_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }
        public event EventHandler NothiteUposthapitoButtonClick;
        private void nothiteUposthaponButton_Click(object sender, EventArgs e)
        {
            if (this.NothiteUposthapitoButtonClick != null)
                this.NothiteUposthapitoButtonClick(sender, e);
        }

        public event EventHandler DakArchiveButtonClick;
        private void dakArchiveButton_Click(object sender, EventArgs e)
        {


            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি আর্কাইভ করতে চান?";
            conditonBoxForm.ShowDialog();




            if (conditonBoxForm.Yes)
            {


                if (this.DakArchiveButtonClick != null)
                    this.DakArchiveButtonClick(sender, e);
            }

        }

        private void DakSendButton_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }


        public event EventHandler NothijatoButtonClick;


        private void nothijatoButton_Click(object sender, EventArgs e)
        {
            if (this.NothijatoButtonClick != null)
                this.NothijatoButtonClick(sender, e);
        }


        public event EventHandler CheckBoxClick;

        private void dakCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = dakCheckBox.Checked;
            if (this.CheckBoxClick != null)
                this.CheckBoxClick(sender, e);
        }






        private void dakMovementStatusButton_MouseHover(object sender, EventArgs e)
        {
            dakMovementStatusButton.BackgroundImage = Resources.Repeal_alt_Hover;
        }

        private void dakMovementStatusButton_MouseLeave(object sender, EventArgs e)
        {
            dakMovementStatusButton.BackgroundImage = Resources.Repeat_alt_New;
        }

        private void nothiteUposthaponButton_MouseLeave(object sender, EventArgs e)
        {
            nothiteUposthaponButton.BackgroundImage = Resources.Nothijato_Icon;
        }

        private void nothiteUposthaponButton_MouseHover(object sender, EventArgs e)
        {
            nothiteUposthaponButton.BackgroundImage = Resources.Nothivukto_Icon_Hover;
        }

        private void DakSendButton_MouseHover(object sender, EventArgs e)
        {
            DakSendButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void DakSendButton_MouseLeave(object sender, EventArgs e)
        {
            DakSendButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void nothijatoButton_MouseHover(object sender, EventArgs e)
        {
            nothijatoButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void nothijatoButton_MouseLeave(object sender, EventArgs e)
        {
            nothijatoButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void dakArchiveButton_MouseHover(object sender, EventArgs e)
        {
            dakArchiveButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void dakArchiveButton_MouseLeave(object sender, EventArgs e)
        {
            dakArchiveButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            dakTagButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            dakTagButton.IconColor = Color.FromArgb(54, 153, 255);
        }


        public event EventHandler DakTagButtonCLick;
        private void dakTagButton_Click(object sender, EventArgs e)
        {
            if (this.DakTagButtonCLick != null)
                this.DakTagButtonCLick(sender, e);

        }
        public event EventHandler DakTagShowButtonCLick;
        private void dakTagListButton_Click(object sender, EventArgs e)
        {
            if (this.DakTagShowButtonCLick != null)
                this.DakTagShowButtonCLick(sender, e);
        }

        private void DakSortedUserControl_Load(object sender, EventArgs e)
        {
            dakActionPanel.Location = new Point(this.Width, dakActionPanel.Location.Y);
            rightInfoPanel.Location = new Point(this.Width-rightInfoPanel.Width, rightInfoPanel.Location.Y);

            HideAndShow();
        }

        public void HideAndShow()
        {
            HideAndShowSender();
            HideAndShowmainReceiver();
            HideAndShowSubject();
            HideAndShowDecision();
            HideAndShowDateAndAttachment();
            HideAndShowFolder();
        }

        public void HideAndShowFolder()
        {
            dakTagPanel.Visible = HideAndShowData.folder;
        }

        public void HideAndShowDateAndAttachment()
        {
            dakAttachmentButton.Visible = dateLabel.Visible = HideAndShowData.dateAndAttachment;
        }

        public void HideAndShowDecision()
        {
            decisionAndNothiTableLayoutPanel.Visible = HideAndShowData.decision;
        }

        public void HideAndShowSubject()
        {
            subTableLayoutPanel.Visible = HideAndShowData.subject;
        }

        public void HideAndShowmainReceiver()
        {
            receiverTableLayoutPanel.Visible = HideAndShowData.mainReceiver;
        }

        public void HideAndShowSender()
        {
            senderTableLayoutPanel.Visible = HideAndShowData.sender;
        }

        public event EventHandler PreronIconButtonClick;
        private void preronIconButton_Click(object sender, EventArgs e)
        {
            if (this.PreronIconButtonClick != null)
                this.PreronIconButtonClick(sender, e);

        }
        public event EventHandler RevertButtonClick;
        private void dakRevertButton_Click(object sender, EventArgs e)
        {
           

                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "আপনি কি ডাকটি ফেরত আনতে চান?";
                conditonBoxForm.ShowDialog();




                if (conditonBoxForm.Yes)
                {



                    if (this.RevertButtonClick != null)
                        this.RevertButtonClick(sender, e);



                }


            }

        private void dakRevertButton_MouseHover(object sender, EventArgs e)
        {
            
                dakRevertButton.IconColor = Color.FromArgb(246, 78, 144);
            
        }

        private void dakRevertButton_MouseLeave(object sender, EventArgs e)
        {
            dakRevertButton.IconColor = Color.FromArgb(54, 153, 255);
        }



        public event EventHandler DraftedDakSendButtonClick;
        private void draftedDakSendButton_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি প্রেরণ করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {


                if (this.DraftedDakSendButtonClick != null)
                    this.DraftedDakSendButtonClick(sender, e);
            }
            else
            {

            }


        }



        public event EventHandler DraftedDakDeleteButtonClick;
        private void dakDeleteButton_Click(object sender, EventArgs e)
        {

        }

        public event EventHandler DraftedDakEditButtonClick;
        private void dakEditButton_Click(object sender, EventArgs e)
        {

            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি সম্পাদন করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {

                if (this.DraftedDakEditButtonClick != null)
                    this.DraftedDakEditButtonClick(sender, e);
            }
            else
            {

            }
        }

        private void dakDeleteButton_MouseHover(object sender, EventArgs e)
        {

        }

        private void dakDeleteButton_MouseLeave(object sender, EventArgs e)
        {

        }

        private void draftedDakSendButton_MouseHover(object sender, EventArgs e)
        {
            draftedDakSendButton.IconColor = Color.FromArgb(246, 78, 144);
        }

       

        private void dakEditButton_MouseHover(object sender, EventArgs e)
        {
            dakEditButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void dakEditButton_MouseLeave(object sender, EventArgs e)
        {
            dakEditButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void draftedDakSendButton_MouseLeave(object sender, EventArgs e)
        {
            draftedDakSendButton.IconColor = Color.FromArgb(54, 153, 255);
        }
    }
}

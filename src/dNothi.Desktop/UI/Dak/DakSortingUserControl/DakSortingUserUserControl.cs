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
using dNothi.Desktop.Properties;
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakSortingUserUserControl : UserControl
    {
        private bool MouseIsOverControl() =>
    this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
        public DakSortingUserUserControl()
        {
            InitializeComponent();
            //dakPriorityIconPanel.Visible = false;
            dakSecurityIconPanel.Visible = false;
           
            IterateControls(this.Controls);
            SetDefaultFont(this.Controls);

        }
       
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
                dakActionPanel.Visible = true;
            }
            else
            {
                this.BackColor = Color.White;
                dakActionPanel.Visible = false;
            }
        }

       

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
        public bool _isChecked;
       
        public bool isChecked { get { return _isChecked; } set { _isChecked = value; dakCheckBox.Checked = value; } }

        #region TopRightPanel set value

        public bool _fewlabel;
        public bool _patrajariLabel;
        public bool _importancelabel;
        public bool _sequirelabel;
        public bool _mostSecquirelabel;
        public bool _anulipilabel;
        public bool _prapaklabel;
        public bool _newlabel;

        public bool fewvalue { get { return _fewlabel; } 
            set  { 
                    _fewlabel=value;

                    fewlabel.Visible = _fewlabel;
                 } 
        }
        public bool patrajarivalue
        {
            get { return _patrajariLabel; }
            set
            {
                _patrajariLabel = value;

                patrajariLabel.Visible = _patrajariLabel;
            }
        }
        public bool importancevalue
        {
            get { return _importancelabel; }
            set
            {
                _importancelabel = value;

                importancelabel.Visible = _importancelabel;
            }
        }

        public bool sequirevalue
        {
            get { return _sequirelabel; }
            set
            {
                _sequirelabel = value;

                sequirelabel.Visible = _sequirelabel;
            }
        }

        public bool mostSecquirevalue
        {
            get { return _mostSecquirelabel; }
            set
            {
                _mostSecquirelabel = value;

                mostSecquirelabel.Visible = _mostSecquirelabel;
            }
        }
        public bool anulipivalue
        {
            get { return _anulipilabel; }
            set
            {
                _anulipilabel = value;

                anulipilabel.Visible = _anulipilabel;
            }
        }

        public bool prapakvalue
        {
            get { return _prapaklabel; }
            set
            {
                _prapaklabel = value;

                prapaklabel.Visible = _prapaklabel;
            }
        }

        public bool newvalue
        {
            get { return _newlabel; }
            set
            {
                _newlabel = value;

                newlabel.Visible = _newlabel;
            }
        }

        #endregion
        public DraftedDecisionDTO _draftedDecisionDTO { get; set; }


        public DraftedDecisionDTO draftedDecision
        {
            get { return _draftedDecisionDTO; }
            set
            {
                _draftedDecisionDTO = value;
                if (value != null)
                { 
                try
                {
                    if (draftedDecision.decision != "")
                    {
                        decisionmainLabel.Text += draftedDecision.decision;
                    }
                    else
                    {
                        decisionmainLabel.Visible = false;
                        //draftedDecisionsSidelabel.Visible = false;
                    }

                    DakPriorityList dakPriorityList = new DakPriorityList();
                    string priorityName = dakPriorityList.GetDakPriorityName(draftedDecision.priority);

                    if (priorityName == "")
                    {
                        // dakPriorityIconPanel.Visible = false;
                    }
                    else
                    {
                        //dakPriorityIconPanel.Visible = true;
                        //prioriyLabel.Text = priorityName;

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
                    draftedInfoPanel.Visible = false;
                }
                 }
                else
                {
                    draftedInfoPanel.Visible = false;
                }
            }
        }

        [Category("Custom Props")]
        public string nothiNo
        {
            get { return _nothiNo; }
            set { _nothiNo = value; if (value == null) { nothiPlainTextLabel.Visible = false; } else { nothiPlainTextLabel.Visible = true; nothiNoLabel.Text = value; } }
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
        public event EventHandler RemoveIconButtonClick;
        private void removeIconButton_Click(object sender, EventArgs e)
        {
            if (this.RemoveIconButtonClick != null)
                this.RemoveIconButtonClick(sender, e);
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


       
        private void DakSortedUserControl_Load(object sender, EventArgs e)
        {
            dakActionPanel.Location = new Point(this.Width, dakActionPanel.Location.Y);

        }

      
    }
}

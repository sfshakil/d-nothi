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
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.Properties;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakInboxUserControl : UserControl
    {

       
        private bool MouseIsOverControl() =>
    this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
        public DakInboxUserControl()
        {
            InitializeComponent();
       
            IterateControls(this.Controls);


            SetDefaultFont(this.Controls);


        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if(ctrl.Font.Style==FontStyle.Regular)
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
                if(ctrl.Name== "dakCheckBox")
                {
                    continue;
                }
                
               
                ctrl.Click += DakInboxUserControl_Click;
                ctrl.MouseEnter += DakInboxUserControl_MouseEnter;
                ctrl.MouseLeave += DakInboxUserControl_MouseLeave;
                IterateControls(ctrl.Controls);
            }
          
        }

        private string _source;
        private string _sender;
        private string _receiver;
        private string _subject;
        private string _decision;
        private string _date;
        private string _dakViewStatus;
        private int _is_dak_Archived;

        private string _attentionTypeIconValue;
        private string _dakSecurityIconValue;
        private string _dakType;
        private string _dakPriority;
        private int _potrojari;
        private int _dakAttachmentCount;
        private int _dakid;
        public bool _isChecked;
        public DakListRecordsDTO _dak;


        public DakListRecordsDTO dak { get { return _dak; }set { _dak = value; } }

        public bool isChecked { get { return _isChecked; } set { _isChecked = value; dakCheckBox.Checked = value; } }


        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }

        [Category("Custom Props")]
        public int dakAttachmentCount
        {
            get { return _dakAttachmentCount; }
            set { _dakAttachmentCount = value; dakAttachmentButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        public int dakArchiveUserId
        {
            get { return _is_dak_Archived; }
            set { _is_dak_Archived = value;  }
            //if (_is_dak_Archived == 0){ dakArchiveButton.Visible = false; }
        }

        [Category("Custom Props")]
        public int dakid
        {
            get { return _dakid; }
            set { _dakid = value; }
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







            }
        }




        [Category("Custom Props")]
        public string attentionTypeIconValue
        {



            get { return _attentionTypeIconValue; }
            set { _attentionTypeIconValue = value;
                if(value== "0")
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

        private void DakInboxUserControl_MouseEnter(object sender, EventArgs e)
        {


            MouseHoverAction();

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

        private void DakInboxUserControl_MouseLeave(object sender, EventArgs e)
        {

            MouseHoverAction();


        }

        private void DakInboxUserControl_Load(object sender, EventArgs e)
        {
            dakActionPanel.Location = new Point(this.Width, dakActionPanel.Location.Y);
         // rightInfoPanel.Location = new Point(this.Width- rightInfoPanel.Width, rightInfoPanel.Location.Y);
        }

        private void DakInboxUserControl_Enter(object sender, EventArgs e)
        {
           
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;
       
        private void DakInboxUserControl_Click(object sender, EventArgs e)
        {
            
           
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
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
            iconButton3.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.FromArgb(54, 153, 255);
        }
    }
}

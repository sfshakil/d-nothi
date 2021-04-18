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
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Constants;
using dNothi.Desktop.Properties;
using dNothi.JsonParser.Entity.Dak_List_Inbox;

namespace dNothi.Desktop.UI.Dak
{
   

    public partial class DakArchiveUserControl : UserControl
    {
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
                }


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
                }


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




        private bool MouseIsOverControl() =>
    this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));

        public DakArchiveUserControl()
        {
            InitializeComponent();
            IterateControls(this.Controls);
        }
        public event EventHandler DakAttachmentButton;

        private void DakAttachmentButton_Click(object sender, EventArgs e)
        {


            if (this.DakAttachmentButton != null)
                this.DakAttachmentButton(sender, e);
        }
        void IterateControls(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl == dakTagPanel)
                {
                    continue;
                }
                if (ctrl.Name == "dakActionPanel")
                {
                    continue;
                }
                if (ctrl == dakAttachmentButton)
                {
                    continue;
                }
                ctrl.Click += DakArchiveUserControl_Click;
                ctrl.MouseEnter += DakArchiveUserControl_MouseEnter;
                ctrl.MouseLeave += DakArchiveUserControl_MouseLeave;
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

        private string _attentionTypeIconValue;
        private string _dakSecurityIconValue;
        private string _dakType;
        private string _dakPriority;
        private int _potrojari;
        private string _nothiNo;
        private int _dakAttachmentCount;
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
            set
            {
                _attentionTypeIconValue = value;
              
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
        private void MouseHoverAction()
        {
            if (MouseIsOverControl())
            {
                this.BackColor = Color.WhiteSmoke;
                if(!uploadIconButton.Visible)
                {
                    dakActionPanel.Visible = true;
                }
            }
            else
            {
                this.BackColor = Color.White;
                dakActionPanel.Visible = false;
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




        private void DakArchiveUserControl_Load(object sender, EventArgs e)
        {
            dakActionPanel.Location = new Point(this.Width - dakActionPanel.Width, dakActionPanel.Location.Y);
          //  disablePanel.Location = new Point(this.Width - disablePanel.Width, disablePanel.Location.Y);
            SetDefaultFont(this.Controls);
        }

        private void DakArchiveUserControl_MouseEnter(object sender, EventArgs e)
        {
            MouseHoverAction();

        }

        private void DakArchiveUserControl_MouseLeave(object sender, EventArgs e)
        {
            MouseHoverAction();
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;
        private void DakArchiveUserControl_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }


        public event EventHandler ArchiveRevertButtonClick;
        private void dakRevertButton_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = MessageBoxMessage.dakArchiveConditionMessage;
            conditonBoxForm.ShowDialog();




            if (conditonBoxForm.Yes)
            {

                if (this.ArchiveRevertButtonClick != null)
                    this.ArchiveRevertButtonClick(sender, e);
            }
        }

        private void dakMovementStatusButton_Click_1(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }

        private void dakRevertButton_MouseHover(object sender, EventArgs e)
        {
            dakRevertButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void dakMovementStatusButton_MouseHover(object sender, EventArgs e)
        {
            dakMovementStatusButton.BackgroundImage = Resources.Repeal_alt_Hover;
        }

        private void dakMovementStatusButton_MouseLeave(object sender, EventArgs e)
        {
            dakMovementStatusButton.BackgroundImage = Resources.Repeat_alt_New;
        }









        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            dakTagButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            dakTagButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void dakRevertButton_MouseLeave(object sender, EventArgs e)
        {
            dakRevertButton.IconColor = Color.FromArgb(54, 153, 255);
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
    }
}

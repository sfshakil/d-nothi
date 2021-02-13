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
using dNothi.Desktop.Properties;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakNothijatoUserControl : UserControl
    {
        public DakNothijatoUserControl()
        {
            InitializeComponent(); IterateControls(this.Controls);





        }
        private bool MouseIsOverControl() =>
        this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
        private void MouseHoverAction()
        {
            if (MouseIsOverControl())
            {
                this.BackColor = Color.WhiteSmoke;
                dakActionPanel.Visible = true;
            }
            else
            {
                this.BackColor = Color.White;
                dakActionPanel.Visible = false;
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
                ctrl.Click += DakNothijatoUserControl_Click;
                ctrl.MouseEnter += DakNothijatoUserControl_MouseEnter;
                ctrl.MouseLeave += DakNothijatoUserControl_MouseLeave;
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

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;
        private void DakNothijatoUserControl_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }

        public event EventHandler NothiteUposthapitoButtonClick;


        private void nothijatoButton_Click(object sender, EventArgs e)
        {
            if (this.NothiteUposthapitoButtonClick != null)
                this.NothiteUposthapitoButtonClick(sender, e);
        }

        private void DakNothijatoUserControl_MouseEnter(object sender, EventArgs e)
        {
            MouseHoverAction();
        }

        private void DakNothijatoUserControl_MouseLeave(object sender, EventArgs e)
        {
            MouseHoverAction();
        }
        public event EventHandler NothijatoRevertButtonClick;
        private void dakRevertButton_Click(object sender, EventArgs e)
        {


            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি ফেরত আনতে চান?";
            conditonBoxForm.ShowDialog();




            if (conditonBoxForm.Yes)
            {



                if (this.NothijatoRevertButtonClick != null)
                    this.NothijatoRevertButtonClick(sender, e);



            }


        }

        private void dakMovementStatusButton_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }






        private void DakNothijatoUserControl_Load(object sender, EventArgs e)
        {
            //dakActionPanel.Location = new Point(this.Width - dakActionPanel.Width, dakActionPanel.Location.Y);
           // disablePanel.Location = new Point(this.Width - disablePanel.Width, disablePanel.Location.Y);

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





        private void nothijatoButton_MouseHover(object sender, EventArgs e)
        {
            nothiteUposthaponButton.BackgroundImage = Resources.Nothivukto_Icon_Hover;
        }

        private void nothijatoButton_MouseLeave(object sender, EventArgs e)
        {
            nothiteUposthaponButton.BackgroundImage = Resources.Nothijato_Icon;
        }



        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void dakRevertButton_MouseLeave(object sender, EventArgs e)
        {
            dakRevertButton.IconColor = Color.FromArgb(54, 153, 255);
        }
    }
}

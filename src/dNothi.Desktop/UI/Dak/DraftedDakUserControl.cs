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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DraftedDakUserControl : UserControl
    {
        private bool MouseIsOverControl() =>
   this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
        public DraftedDakUserControl()
        {
            InitializeComponent();
            InitializeComponent();
          
            dakActionPanel.BringToFront();
            IterateControls(this.Controls);
        }
        void IterateControls(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                ctrl.Click += DraftedDakUserControl_Click;
                ctrl.MouseEnter += DraftedDakUserControl_MouseEnter;
                ctrl.MouseLeave += DraftedDakUserControl_MouseLeave;
                IterateControls(ctrl.Controls);
            }

        }


        private string _source;

        private string _receiver;
        private string _subject;
     
        private string _date;
        private string _dakViewStatus;

        private string _attentionTypeIconValue;
        private string _dakSecurityIconValue;
        private string _dakType;
        private string _dakPriority;
        private int _potrojari;
        private int _dakAttachmentCount;
        private int _dakid;

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

       
      


       
        public string receiver
        {
            get { return _receiver; }
            set { _receiver = value; mainReceiverLabel.Text = value; }
        }

      
        public string subject
        {
            get { return _subject; }
            set { _subject = value; subjectLabel.Text = value; }
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
            set { _date = value; dateLabel.Text = value; dateLabel.BringToFront(); }
        }

        private void DraftedDakUserControl_MouseEnter(object sender, EventArgs e)
        {


            MouseHoverAction();

        }

        private void MouseHoverAction()
        {
            if (MouseIsOverControl())
            {
                this.BackColor = Color.WhiteSmoke;
                dakActionPanel.Visible = true;
                dakActionPanel.BringToFront();
            }
            else
            {
                this.BackColor = Color.White;
                dakActionPanel.Visible = false;
            }
        }

        private void DraftedDakUserControl_MouseLeave(object sender, EventArgs e)
        {

            MouseHoverAction();


        }



        
        private void DraftedDakUserControl_Click(object sender, EventArgs e)
        {


            //if (this.ButtonClick != null)
            //    this.ButtonClick(sender, e);
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler DraftedDakSendButtonClick;
        private void dakSendButton_Click(object sender, EventArgs e)
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
            

                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "আপনি কি ডাকটি মুছে ফেলতে চান?";
               conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
                {
                    if (this.DraftedDakDeleteButtonClick != null)
                    this.DraftedDakDeleteButtonClick(sender, e);
            }
            else
            {

            }
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

        private void dakEditButton_MouseHover(object sender, EventArgs e)
        {
            dakEditButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void dakEditButton_MouseLeave(object sender, EventArgs e)
        {
            dakEditButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void dakSendButton_MouseHover(object sender, EventArgs e)
        {
            dakSendButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void dakSendButton_MouseLeave(object sender, EventArgs e)
        {
            dakSendButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void dakDeleteButton_MouseHover(object sender, EventArgs e)
        {
            dakDeleteButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void dakDeleteButton_MouseLeave(object sender, EventArgs e)
        {
            dakDeleteButton.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void DraftedDakUserControl_Load(object sender, EventArgs e)
        {
            //disablePanel.Location = new Point(this.Width - disablePanel.Width, disablePanel.Location.Y);

        }
    }
}

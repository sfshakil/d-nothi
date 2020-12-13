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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakInboxUserControl : UserControl
    {
       



        public DakInboxUserControl()
        {
            InitializeComponent();
            dakPriorityIconPanel.Visible = false;
            dakSecurityIconPanel.Visible = false;
            attentionTypeIconPanel.Visible = false;
            newDakImagePanel.Visible = false;
            dakTypePanel.Visible = false;
            potrojariPanel.Visible = false;
            IterateControls(this.Controls);

          



        }

        void IterateControls(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

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


               
                if (value == 1)
                {
                    potrojariPanel.Visible = true;
                }
                else
                {
                    potrojariPanel.Visible = false;
                }






            }
        }

        [Category("Custom Props")]
        public string dakPrioriy
        {
            get { return _dakPriority; }
            set
            {
                _dakPriority = value;


                DakPriorityList dakPriorityList = new DakPriorityList();
                string priorityName = dakPriorityList.GetDakPriorityName(value);


                if (priorityName == "")
                {
                   dakPriorityIconPanel.Visible = false;
                }
                else
                {
                    dakPriorityIconPanel.Visible = true;
                    prioriyLabel.Text = priorityName;

                }






            }
        }

        [Category("Custom Props")]
        public string dakType
        {



            get { return _dakType; }
            set
            {
                _dakType = value;

              

                dakTypePanel.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(value);

                if (dakTypePanel.BackgroundImage == null)
                {
                    dakTypePanel.Visible = false;
                }
                else
                {
                    dakTypePanel.Visible = true;

                }






            }
        }

        [Category("Custom Props")]
        public string dakSecurityIconValue
        {



            get { return _dakSecurityIconValue; }
            set
            {
                _dakSecurityIconValue = value;

                DakSecurityList dakSecurityList = new DakSecurityList();
                string icon = dakSecurityList.GetDakSecuritiesIcon(value);

                dakSecurityIconPanel.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);

                if (dakSecurityIconPanel.BackgroundImage == null)
                {
                    dakSecurityIconPanel.Visible = false;
                }
                else
                {
                    dakSecurityIconPanel.Visible = true;

                }






            }
        }




        [Category("Custom Props")]
        public string attentionTypeIconValue
        {



            get { return _attentionTypeIconValue; }
            set { _attentionTypeIconValue = value;

                AttentionTypeList attentionTypeIconList = new AttentionTypeList();
               string icon= attentionTypeIconList.GetAttentionTypeIcon(value);
               
                    attentionTypeIconPanel.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);
                    
                   if(attentionTypeIconPanel.BackgroundImage == null)
                {
                    attentionTypeIconPanel.Visible = false;
                }
                else
                {
                    attentionTypeIconPanel.Visible = true;

                }






            }
        }

        [Category("Custom Props")]
        public string source
        {
            get { return _source; }
            set { _source = value; sourceLabel.Text = value; }
        }
        
        [Category("Custom Props")]
        public string dakViewStatus
        {
            get { return _dakViewStatus; }
            set { _dakViewStatus = value; 
            if(dakViewStatus== "New")
                {
                    newDakImagePanel.Visible = true;
                   

                }
            else
                {
                    newDakImagePanel.Visible = false;
                }
            
            }
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
           
                this.BackColor = Color.WhiteSmoke;
               
           
          
            
        }

        private void DakInboxUserControl_MouseLeave(object sender, EventArgs e)
        {
            
                this.BackColor = Color.White;
              
          
        
        }

        private void DakInboxUserControl_Load(object sender, EventArgs e)
        {
           
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

        }

        private void dakMovementStatusButton_Click(object sender, EventArgs e)
        {

        }
    }
}

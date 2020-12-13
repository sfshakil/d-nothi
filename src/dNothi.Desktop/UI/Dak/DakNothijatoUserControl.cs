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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakNothijatoUserControl : UserControl
    {
        public DakNothijatoUserControl()
        {
            InitializeComponent(); IterateControls(this.Controls);





        }

        void IterateControls(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

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
            set
            {
                _attentionTypeIconValue = value;

                AttentionTypeList attentionTypeIconList = new AttentionTypeList();
                string icon = attentionTypeIconList.GetAttentionTypeIcon(value);

                attentionTypeIconPanel.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);

                if (attentionTypeIconPanel.BackgroundImage == null)
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
            set
            {
                _dakViewStatus = value;
                if (dakViewStatus == "New")
                {
                    newDakImagePanel.Visible = true;
                    subjectLabel.Font = new Font(Label.DefaultFont, FontStyle.Bold);

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

        private void DakNothijatoUserControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }

        private void DakNothijatoUserControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}

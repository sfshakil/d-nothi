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
using dNothi.JsonParser.Entity.Dak_List_Inbox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DetailsDakUserControl : UserControl
    {
        public DetailsDakUserControl()
        {
            InitializeComponent();
        }
        private int _docketingNo;
       
        private string _sharokNo;
        private string _subject;
        private string _decision;
        private string _date;
       
        private string _attentionTypeIconValue;
        private string _dakSecurityIconValue;
        private string _dakType;
        private string _dakPriority;
        private int _potrojari;
        private int _dakAttachmentCount;
        private int _dakid;
        private string _officerName;
        private string _officerDesignation;
        private string _officeName;

        private DakDetailsResponse _dakDetailsResponse;
        private DakAttachmentResponse _dakAttachmentResponse;


        public string officerName
        {
            get { return _officerName; ; }
            set { _officerName = value; nameLabel.Text = value; }
        }
        public string officeName
        {
            get { return _officeName; ; }
            set { _officeName = value; movementStatusDetailsButton.Text = value; }
        }
        public string officerDesignation
        {
            get { return _officerDesignation; ; }
            set { _officerDesignation = value; designationLabel.Text = value; designationLabel.Font = new Font("SolaimanLipi", 8,FontStyle.Regular); }
        }
        public int dakAttachmentCount
        {
            get { return _dakAttachmentCount; }
            set { _dakAttachmentCount = value; }
        }
        public DakAttachmentResponse dakAttachmentResponse
        {
            get { return _dakAttachmentResponse; }
            set { _dakAttachmentResponse = value;

                try
                {
                    DakAttachmentDTO dakAttachmentDTO = dakAttachmentResponse.data.FirstOrDefault(a => a.is_main == 1);
                    mainAttachmentViewWebBrowser.Url = new Uri(dakAttachmentDTO.url);
                }
                catch(Exception ex)
                {

                }

            
            
            }
        }

        public DakDetailsResponse dakDetailsResponse
        {
            get { return _dakDetailsResponse; }
            set { _dakDetailsResponse = value;
                movementStatusDetailsPanel.Controls.Clear();
                movementStatusDetailsUserControl movementStatusDetailsUserControlSource = new movementStatusDetailsUserControl();

                movementStatusDetailsUserControlSource.userType = "উৎসঃ";
                movementStatusDetailsUserControlSource.userName = dakDetailsResponse.data.dak_origin.sender_name;
                movementStatusDetailsUserControlSource.userDesignation ="("+dakDetailsResponse.data.dak_origin.sender_officer_designation_label+","+ dakDetailsResponse.data.dak_origin.sender_office_unit_name + ","+ dakDetailsResponse.data.dak_origin.sender_office_name+")";
                movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlSource);


                movementStatusDetailsUserControl movementStatusDetailsUserControlMainReceiver = new movementStatusDetailsUserControl();

                movementStatusDetailsUserControlMainReceiver.userType = "মূল প্রাপকঃ";
                movementStatusDetailsUserControlMainReceiver.userName = dakDetailsResponse.data.dak_origin.receiving_officer_name;
                movementStatusDetailsUserControlMainReceiver.userDesignation = "(" + dakDetailsResponse.data.dak_origin.receiving_officer_designation_label + ","+ dakDetailsResponse.data.dak_origin.receiving_office_unit_name + "," + dakDetailsResponse.data.dak_origin.receiving_office_name + ")";
                movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlMainReceiver);


                movementStatusDetailsUserControl movementStatusDetailsUserControlSender = new movementStatusDetailsUserControl();

                try
                {
                    movementStatusDetailsUserControlSender.userType = "প্রেরকঃ";
                    movementStatusDetailsUserControlSender.userName = dakDetailsResponse.data.movement_status.from.officer;
                    movementStatusDetailsUserControlSender.userDesignation = "(" + dakDetailsResponse.data.movement_status.from.designation + ","+ dakDetailsResponse.data.movement_status.from.office_unit + ","+ dakDetailsResponse.data.movement_status.from.office + ")";
                    movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlSender);
                }
                catch
                {

                }

                movementStatusDetailsUserControl movementStatusDetailsUserControlReceiver = new movementStatusDetailsUserControl();

                try
                {
                    movementStatusDetailsUserControlReceiver.userType = "প্রাপকঃ";
                    ToDTO toDTO = dakDetailsResponse.data.movement_status.to.FirstOrDefault(a => a.designation_id!=dakDetailsResponse.data.dak_origin.receiving_officer_designation_id && a.attention_type=="1" );


                    movementStatusDetailsUserControlReceiver.userName = toDTO.officer;
                    movementStatusDetailsUserControlReceiver.userDesignation = "(" +toDTO.designation + ","+toDTO.office_unit+","+ toDTO.office + ")";
                    movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlReceiver);
                }
                catch
                {

                }

                try
                {
                    string type= "অনুলিপি প্রাপকঃ";
                    foreach (ToDTO toDTO in dakDetailsResponse.data.movement_status.to.Where(a=>a.attention_type!="1"))
                    {
                        movementStatusDetailsUserControl movementStatusDetailsUserControlOnulipi = new movementStatusDetailsUserControl();

                        movementStatusDetailsUserControlOnulipi.userType =type;
                        movementStatusDetailsUserControlOnulipi.userName = toDTO.officer;
                        movementStatusDetailsUserControlOnulipi.userDesignation = "(" + toDTO.designation + "," + toDTO.office_unit + "," + toDTO.office + ")";
                        movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlOnulipi);
                        type = "";
                    }
                   
                }
                catch
                {

                }





            }
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

      
        public int docketingNo
        {
            get { return _docketingNo; }
            set { _docketingNo = value; docketingNoText.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

       

      

        public string sharokNo
        {
            get { return _sharokNo; }
            set { _sharokNo = value; sharokNoText.Text = value; if (sharokNo == "" || sharokNo == null) { sharokNoLabel.Visible = false;sharokNoText.Visible = false;sharokNoSpaceLabel.Visible = false; } }
        }

        public string subject
        {
            get { return _subject; }
            set { _subject = value; subjectLabel.Text = value; }
        }

        public string decision
        {
            get { return _decision; }
            set { _decision = value; decisionText.Text = value; }
        }

       
        public string date
        {
            get { return _date; }
            set { _date = value; dateLabel.Text = value; }
        }










        private void movementStatusDetailsButton_Click(object sender, EventArgs e)
        {
            if(movementStatusDetailsPanel.Visible==true)
            {
                movementStatusDetailsPanel.Visible = false;
                movementStatusDetailsPanel.SendToBack();
            }
            else
            {
                movementStatusDetailsPanel.Visible = true;
                movementStatusDetailsPanel.BringToFront();
            }
        }

        private void mainAttachmentButton_MouseEnter(object sender, EventArgs e)
        {
            mainAttachmentButton.ForeColor = Color.Blue;
        }

        private void mainAttachmentButton_MouseLeave(object sender, EventArgs e)
        {
            mainAttachmentButton.ForeColor = Color.Black;
        }

      

        private void attachmentListButton_MouseEnter(object sender, EventArgs e)
        {
            attachmentListButton.ForeColor = Color.Blue;
        }

        private void attachmentListButton_MouseLeave(object sender, EventArgs e)
        {
            attachmentListButton.ForeColor = Color.Black;
        }

        private void mainAttachmentButton_Click(object sender, EventArgs e)
        {

            attachmentFlowLayoutPanel.Controls.Clear();
            attachmentFlowLayoutPanel.Controls.Add(mainAttachmentViewWebBrowser);
            mainAttachmentButton.FlatAppearance.BorderColor = Color.White;
            attachmentListButton.FlatAppearance.BorderColor = Color.Black;
        }

        private void attachmentListButton_Click(object sender, EventArgs e)
        {
           
            attachmentListButton.FlatAppearance.BorderColor = Color.White;

            mainAttachmentButton.FlatAppearance.BorderColor = Color.Black;

            attachmentFlowLayoutPanel.Controls.Clear();
            detailsAttachmentListUserControl detailsAttachmentListUserControl = new detailsAttachmentListUserControl();
            try
            {

                detailsAttachmentListUserControl.dakAttachmentDTOs = _dakAttachmentResponse.data;
                detailsAttachmentListUserControl.allattachmentdownloadlink = "";
                attachmentFlowLayoutPanel.Controls.Add(detailsAttachmentListUserControl);
            }
            catch
            {

            }



        }
    }
}

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
using dNothi.Services.DakServices;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Constants;
using dNothi.Desktop.Properties;
using System.IO;
using Patagames.Pdf.Net;
using System.Net;
using System.Web;
using com.sun.org.apache.xalan.@internal.xsltc;
using System.Text.RegularExpressions;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DetailsDakUserControl : UserControl
    {
        private bool MouseIsOverControl() =>
   mainAttachmentTabPage.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
        PictureBox pictureBox = new PictureBox();
        public DetailsDakUserControl()
        {
            InitializeComponent();
         
        }
        private int _docketingNo;
        private int _imgHeight;
        private int _imgWidth;
        private double _zoomIn;
        private double _limit;
        private string _mainimageSrc;
        private string _imageName;
       
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
        private bool _isOnulipi;

        private DakCatagoryList _dakCatagory;

        private DakDetailsResponse _dakDetailsResponse;
        private DakAttachmentResponse _dakAttachmentResponse;

        public DakCatagoryList dakCatagory
        {
            get { return _dakCatagory; ; }
            set { _dakCatagory = value; 
                
                dakCategoryLabel.Text = value.GetName;
                if(value.isInbox)
                {
                    dakRevertButton.Visible = false;
                }
                else
                {
                    nothiteUposthaponButton.Visible = false;
                    nothijatoButton.Visible = false;
                    DakSendButton.Visible = false;
                }
            }
        }
        public bool isOnulipi
        {
            get { return _isOnulipi; ; }
            set { _isOnulipi = value; if (value) { dakArchiveButton.Visible = true; } }
        }
        public int dakid
        {
            get { return _dakid; }
            set { _dakid = value; }
        }

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
            set { _officerDesignation = value; designationLabel.Text = value;}
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

                    if (dakAttachmentDTO.attachment_type.ToLower().Contains("image") || dakAttachmentDTO.attachment_type.ToLower().Contains("img"))
                    {


                        _zoomIn = 1;
                        _limit = 2.2;

                        mainAttachmentViewWebBrowser.Visible = false;
                        pdfViewerControl.Visible = false;
                        imagePanel.Visible = true;
                        imageViewPictureBox.Load(dakAttachmentDTO.url);
                        pictureBox.Load(dakAttachmentDTO.url);
                        _imgHeight = pictureBox.Image.Height;
                        _imgWidth = pictureBox.Image.Width;
                        _mainimageSrc = dakAttachmentDTO.url;
                        mainAttachmentTabPage.MouseHover += imagePanel_MouseHover;
                        mainAttachmentTabPage.MouseLeave += imagePanel_MouseLeave;

                        zoomInOutPanel.MouseHover += imagePanel_MouseHover;
                        zoomInOutPanel.MouseLeave += imagePanel_MouseLeave;





                    }
                    else if(dakAttachmentDTO.attachment_type.ToLower().Contains("pdf"))
                    {

                        mainAttachmentViewWebBrowser.Visible = false;
                        imagePanel.Visible = false;
                        pdfViewerControl.Visible = true;
                        WebClient myClient = new WebClient();
                        byte[] bytes = myClient.DownloadData(dakAttachmentDTO.url);
                        var stream = new MemoryStream(bytes);
                        pdfViewerControl.src = dakAttachmentDTO.url;

                      //  var pdfDocument = PdfDocument.Load(stream);


                        //      pdfViewerControl.Document= pdfDocument;
                        // pdfViewerControl.MouseWheel += new MouseEventHandler(this.pdfViewerControl_MouseWheel);
                    }

                    else
                    {
                        //txtFileRichTextBox.Text = System.Net.WebUtility.HtmlDecode(_dakDetailsResponse.data.dak_origin.dak_description);
                        imagePanel.Visible = false;
                        pdfViewerControl.Visible = false;
                        //mainAttachmentViewWebBrowser.DocumentText=_dakDetailsResponse.data.dak_origin.dak_description;
                        mainAttachmentViewWebBrowser.Visible = true;
                        //mainAttachmentViewWebBrowser.Navigate("about:blank");
                        if (mainAttachmentViewWebBrowser.Document != null)
                        {
                            mainAttachmentViewWebBrowser.Document.Write(string.Empty);
                        }
                        string DecodedString = dakAttachmentDTO.dak_description;
                        int loopCount = 0;
                        do
                        {

                            StringWriter writer = new StringWriter();
                            System.Net.WebUtility.HtmlDecode(DecodedString, writer);
                            DecodedString = writer.ToString();
                            loopCount += 1;


                        } while (!DecodedString.StartsWith("<") && loopCount < 5);



                        mainAttachmentViewWebBrowser.DocumentText = DecodedString;
                    }
                    
                }
                catch(Exception ex)
                {

                }
                attachmentListFlowLayoutPanel.Controls.Clear();
                DetailsAttachmentListUserControl detailsAttachmentListUserControl = new DetailsAttachmentListUserControl();
                try
                {
                    detailsAttachmentListUserControl.dakSub = _subject;
                    detailsAttachmentListUserControl.dakAttachmentDTOs = _dakAttachmentResponse.data;
                 
                    detailsAttachmentListUserControl.allattachmentdownloadlink = "";
                    attachmentListFlowLayoutPanel.Controls.Add(detailsAttachmentListUserControl);
                }
                catch
                {

                }



            }
        }

      

        private void pdfViewerControl_MouseWheel(object sender, MouseEventArgs e)
        {
           
        }

        private void imagePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            
               
        }

        public DakDetailsResponse dakDetailsResponse
        {
            get { return _dakDetailsResponse; }
            set { _dakDetailsResponse = value;
                movementStatusDetailsPanel.Controls.Clear();
                DakMovementStatusListUserControl movementStatusDetailsUserControlSource = new DakMovementStatusListUserControl();

                movementStatusDetailsUserControlSource.userType = "উৎসঃ";
               
                movementStatusDetailsUserControlSource.userDesignation = dakDetailsResponse.data.dak_origin.sender_name+ "(" +dakDetailsResponse.data.dak_origin.sender_officer_designation_label+","+ dakDetailsResponse.data.dak_origin.sender_office_unit_name + ","+ dakDetailsResponse.data.dak_origin.sender_office_name+")";
                movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlSource);


                DakMovementStatusListUserControl movementStatusDetailsUserControlMainReceiver = new DakMovementStatusListUserControl();

                movementStatusDetailsUserControlMainReceiver.userType = "মূল প্রাপকঃ";
                movementStatusDetailsUserControlMainReceiver.userDesignation = dakDetailsResponse.data.dak_origin.receiving_officer_name + "(" + dakDetailsResponse.data.dak_origin.receiving_officer_designation_label + ","+ dakDetailsResponse.data.dak_origin.receiving_office_unit_name + "," + dakDetailsResponse.data.dak_origin.receiving_office_name + ")";
                movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlMainReceiver);


                DakMovementStatusListUserControl movementStatusDetailsUserControlSender = new DakMovementStatusListUserControl();

                try
                {
                    movementStatusDetailsUserControlSender.userType = "প্রেরকঃ";
                    movementStatusDetailsUserControlSender.userDesignation = dakDetailsResponse.data.movement_status.from.officer + "(" + dakDetailsResponse.data.movement_status.from.designation + ","+ dakDetailsResponse.data.movement_status.from.office_unit + ","+ dakDetailsResponse.data.movement_status.from.office + ")";
                    movementStatusDetailsPanel.Controls.Add(movementStatusDetailsUserControlSender);
                }
                catch
                {

                }

                DakMovementStatusListUserControl movementStatusDetailsUserControlReceiver = new DakMovementStatusListUserControl();

                try
                {
                    movementStatusDetailsUserControlReceiver.userType = "প্রাপকঃ";
                    ToDTO toDTO = dakDetailsResponse.data.movement_status.to.FirstOrDefault(a => a.designation_id!=dakDetailsResponse.data.dak_origin.receiving_officer_designation_id && a.attention_type=="1");

                    movementStatusDetailsUserControlReceiver.userDesignation = toDTO.officer+"(" +toDTO.designation + ","+toDTO.office_unit+","+ toDTO.office + ")";
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
                        DakMovementStatusListUserControl movementStatusDetailsUserControlOnulipi = new DakMovementStatusListUserControl();

                        movementStatusDetailsUserControlOnulipi.userType =type;
                        movementStatusDetailsUserControlOnulipi.userDesignation = toDTO.officer + "(" + toDTO.designation + "," + toDTO.office_unit + "," + toDTO.office + ")";
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



       
        public int docketingNo
        {
            get { return _docketingNo; }
            set { _docketingNo = value; docketingNoText.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

       

      

        public string sharokNo
        {
            get { return _sharokNo; }
            set { _sharokNo = value;
                var isValidNumber = Regex.IsMatch(value, @"^[0-9]+(\.[0-9]+)?$");
                if (isValidNumber)
                {

                    try { sharokNoText.Text = string.Concat(value.Select(c => (char)('\u09E6' + c - '0'))); } catch (Exception Ex) { }


                }
                else
                {
                    sharokNoText.Text = value;
                }

              
              
                if (sharokNo == "" || sharokNo == null) { sharokNoLabel.Visible = false;sharokNoText.Visible = false;sharokNoSpaceLabel.Visible = false; }
            }
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

        private void DetailsDakUserControl_Load(object sender, EventArgs e)
        {
          //  dakActionPanel.Location = new Point(this.Width - dakActionPanel.Width, dakActionPanel.Location.Y);
          //  disablePanel.Location = new Point(this.Width - disablePanel.Width, dakActionPanel.Location.Y);

        }

        public event EventHandler BackButtonClick;        
        private void backButton_Click(object sender, EventArgs e)
        {
            if (this.BackButtonClick != null)
                this.BackButtonClick(sender, e);
        }




        public event EventHandler ButtonClick;
       

        private void dakMovementButton_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(sender, e);
        }
        private void DakSendButton_Click(object sender, EventArgs e)
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
            conditonBoxForm.message = "অপনি কি ডাকটি আর্কাইভ করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {

                if (this.DakArchiveButtonClick != null)
                    this.DakArchiveButtonClick(sender, e);
            }
        }

        


        public event EventHandler NothijatoButtonClick;


        private void nothijatoButton_Click(object sender, EventArgs e)
        {
            if (this.NothijatoButtonClick != null)
                this.NothijatoButtonClick(sender, e);
        }


        public event EventHandler RevertButtonClick;


        private void revertButton_Click(object sender, EventArgs e)
        {
         
                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = MessageBoxMessage.dakArchiveConditionMessage;
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
                {

                    if (this.RevertButtonClick != null)
                    this.RevertButtonClick(sender, e);
            }
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

        private void dakRevertButton_MouseHover(object sender, EventArgs e)
        {
            dakRevertButton.IconColor = Color.FromArgb(246, 78, 144);
        }

        private void dakRevertButton_MouseLeave(object sender, EventArgs e)
        {
            dakRevertButton.IconColor = Color.FromArgb(54, 153, 255);
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

        private void mainAttachmentViewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            mainAttachmentViewWebBrowser.Document.Body.Style = "zoom:100%";
        }

        private void movementStatusDetailsPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);
          //  movementStatusDetailsPanel.Location = new Point(movementStatusDetailsButton.Location.X, movementStatusDetailsButton.Location.Y+ movementStatusDetailsButton.Height+1);

        }

        private void imageViewPictureBox_Click(object sender, EventArgs e)
        {
            //if(imageViewPictureBox.SizeMode==PictureBoxSizeMode.Normal)
            //{
            //    imageViewPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //}
            //else
            //{
            //    imageViewPictureBox.SizeMode = PictureBoxSizeMode.Normal;
            //}
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            
        }

        private void pdfViewerControl_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void pdfViewerControl_MouseDown(object sender, MouseEventArgs e)
        {

        }

        
        private void bodyTableLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            movementStatusDetailsPanel.Visible = false;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _zoomIn = 1;

            
            imageViewPictureBox.Load(_mainimageSrc);

        }

        private void imagePanel_MouseHover(object sender, EventArgs e)
        {
            zoomInOutPanelShow();
          
        }

        private void zoomInOutPanelShow()
        {
           if(MouseIsOverControl())
            {
                zoomInOutPanel.Visible = true;
            }
            else
            {
                zoomInOutPanel.Visible = false;
            }
        }

        private void imagePanel_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            
            if(_zoomIn < _limit)
            {
                _zoomIn +=0.1;
                int imgHeight =Convert.ToInt32(_imgHeight * _zoomIn);
                int imgWidth = Convert.ToInt32(_imgWidth * _zoomIn);


                Bitmap bitmap = new Bitmap(pictureBox.Image, imgWidth, imgHeight);
               Graphics graphics = Graphics.FromImage(bitmap);
               graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                imageViewPictureBox.Image = bitmap;
            }
            
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (_zoomIn > .7)
            {
                _zoomIn -= 0.1;
                if(_zoomIn==1)
                {
                    imageViewPictureBox.Load(_mainimageSrc);
                    return;
                }
                int imgHeight = Convert.ToInt32(_imgHeight * _zoomIn);
                int imgWidth = Convert.ToInt32( _imgWidth * _zoomIn);


                Bitmap bitmap = new Bitmap(pictureBox.Image, imgWidth, imgHeight);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                imageViewPictureBox.Image = bitmap;
            }
        }

        private void imageSaveButton_Click(object sender, EventArgs e)
        {


            string dummyFileName = "Image File Name";
           

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;
            sf.DefaultExt = ".jpg";
            sf.Filter = "Image|*.jpg;*.jpeg;*.png;";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
               // string savePath = Path.GetDirectoryName(sf.FileName);


                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(_mainimageSrc);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                img.Save(sf.FileName);
            }

            
               

                


               
               
            
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

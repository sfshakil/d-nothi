using CefSharp;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class AttachmentViewPopUpForm : Form
    {
        private bool MouseIsOverControl() =>
   this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
        public AttachmentViewPopUpForm()
        {
            InitializeComponent();
            IterateControls(this.Controls);
        

        }

        private void Body_MouseOver(object sender, HtmlElementEventArgs e)
        {
            if (MouseIsOverControl())
            {

                rightArrowButton.Visible = true;
                leftArrowButton.Visible = true;
            }
            else
            {
                rightArrowButton.Visible = false;
                leftArrowButton.Visible = false;
            }
        }

        void IterateControls(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                if (ctrl.Name == "rightArrowButton")
                {
                    continue;
                }
                if (ctrl.Name == "leftArrowButton")
                {
                    continue;
                }


              
                ctrl.MouseHover += AttachmentViewPopUpForm_MouseHover;
                ctrl.MouseLeave += AttachmentViewPopUpForm_MouseHover;
                IterateControls(ctrl.Controls);
            }

        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public List<DakAttachmentDTO> _dakAttachmentDTOs { get; set; }
      
        public List<DakAttachmentDTO> dakAttachmentDTOs { get { return _dakAttachmentDTOs; } set { 
                
                    
                _dakAttachmentDTOs = value.Where(a=>a.attachment_type.ToLower().Contains("image") || a.attachment_type.ToLower().Contains("img") || a.attachment_type.ToLower().Contains("pdf") || a.attachment_type.ToLower().Contains("txt") || a.attachment_type.ToLower().Contains("text")).ToList(); 
            
            } 
        
        }

        public DakAttachmentDTO _dakAttachmentDTO { get; set; }
        public DakAttachmentDTO dakAttachmentDTO { get { return _dakAttachmentDTO; } 
            set
            {
                _dakAttachmentDTO = value;
               
                try
                {
                    if (dakAttachmentDTO.attachment_type.ToLower().Contains("image") || dakAttachmentDTO.attachment_type.ToLower().Contains("img"))
                    {
                        rightArrowButton.Visible = true;

                        leftArrowButton.Visible = true;
                        mainAttachmentViewWebBrowser.Visible = false;
                        pdfViewerControl.Visible = false;
                       
                        fileMissingLabel.Visible = false;
                        imagePanel.Visible = true;
                       


                        imageViewPictureBox.Load(dakAttachmentDTO.url);

                    }
                    else if (dakAttachmentDTO.attachment_type.ToLower().Contains("pdf"))
                    {
                        rightArrowButton.Visible = true;

                        leftArrowButton.Visible = true;

                        WebClient myClient = new WebClient();
                        byte[] bytes = myClient.DownloadData(dakAttachmentDTO.url);
                        var stream = new MemoryStream(bytes);
                        //if(pdfViewerControl.LoadFile(dakAttachmentDTO.url))
                        //{
                        //    mainAttachmentViewWebBrowser.Visible = false;

                        //    imagePanel.Visible = false;
                        //    fileMissingLabel.Visible = false;
                        //    pdfViewerControl.Visible = true;
                        //}
                        //else
                        //{
                        //    this.Size = new Size(767, 520);
                        //    fileMissingLabel.Visible = true;
                        //    pdfViewerControl.Visible = false;
                        //    imagePanel.Visible = false;
                        //    mainAttachmentViewWebBrowser.Visible = false;
                        //}
                            mainAttachmentViewWebBrowser.Visible = false;
                            imagePanel.Visible = false;
                            fileMissingLabel.Visible = false;
                            pdfViewerControl.Visible = true;
                            pdfViewerControl.src = dakAttachmentDTO.url;

                        //  var pdfDocument = PdfDocument.Load(stream);


                        //      pdfViewerControl.Document= pdfDocument;
                        // pdfViewerControl.MouseWheel += new MouseEventHandler(this.pdfViewerControl_MouseWheel);
                    }
                   
                    else
                    {

                       
                        pdfViewerControl.Visible = false;
                        imagePanel.Visible = false;
                        fileMissingLabel.Visible = false;
                        mainAttachmentViewWebBrowser.Visible = true;
                        rightArrowButton.Visible = false;
                        leftArrowButton.Visible = false;
                        //if (mainAttachmentViewWebBrowser.Document != null)
                        //{
                        //    mainAttachmentViewWebBrowser.Document.Write(string.Empty);
                        //}
                        string DecodedString = dakAttachmentDTO.dak_description!=null? dakAttachmentDTO.dak_description : Base64Conversion.Base64ToHtmlContent(dakAttachmentDTO.potro_description); 
                        int loopCount = 0;
                        do
                        {

                            StringWriter writer = new StringWriter();
                            System.Net.WebUtility.HtmlDecode(DecodedString, writer);
                            DecodedString = writer.ToString();
                            loopCount += 1;

                        } while (!DecodedString.StartsWith("<") && loopCount < 5);

                        mainAttachmentViewWebBrowser.LoadHtml(DecodedString, "https://myfakeurl.com");
                    }
                }
                catch
                {
                    fileMissingLabel.Visible = true;
                    pdfViewerControl.Visible = false;
                    imagePanel.Visible = false;
                    mainAttachmentViewWebBrowser.Visible = false;
                }
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler PreviousButton;
        public event EventHandler NextButton;

       

        private void mainAttachmentViewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //If dockstyle = fill
            //if(mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Width<this.Width)
            //{
            //    this.Width = mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Width + 10;//Border

            //}
            //if (mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Height < this.Height)
            //{
            //    this.Height = mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Height + 10;//Border

            //}

           

            Screen scr = Screen.FromPoint(this.Location);
            int heightLoc =Convert.ToInt32((scr.WorkingArea.Bottom - this.Height) / 2);
            if( heightLoc < 0)
            {
                heightLoc = 10;
            }
            int widthLoc =Convert.ToInt32((scr.WorkingArea.Right - this.Width) / 2);
            this.Location = new Point(widthLoc, heightLoc);


           // mainAttachmentViewWebBrowser.Document.Body.MouseOver += new HtmlElementEventHandler(Body_MouseOver);

        }

        private void rightArrowButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            waitPictureBox.Visible = true;
 

            if (_dakAttachmentDTOs != null)
                {
                    for (int i = 0; i <= _dakAttachmentDTOs.Count - 1; i++)
                    {
                        if (_dakAttachmentDTOs[i].attachment_id == _dakAttachmentDTO.attachment_id)
                        {
                            if (i == _dakAttachmentDTOs.Count - 1)
                            {
                                dakAttachmentDTO = _dakAttachmentDTOs[0];
                            }
                            else
                            {

                                dakAttachmentDTO = _dakAttachmentDTOs[i + 1];
                            }
                            break;
                        }
                    }
                
                // this.Hide();
                //this.NextButton(sender, e);
               
            }

            waitPictureBox.Visible = false;


        }

        private void AttachmentViewPopUpForm_MouseHover(object sender, EventArgs e)
        {



            if(MouseIsOverControl())
            {

                rightArrowButton.Visible = true;
                leftArrowButton.Visible = true;
            }
            else
            {
                rightArrowButton.Visible = false;
                leftArrowButton.Visible = false;
            }
        }

        private void leftArrowButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            waitPictureBox.Visible = true;
            //this.Visible = false;
            //WaitWindowForm waitWindowForm = new WaitWindowForm();
            //waitWindowForm.Show(this.Parent);
           
                if (_dakAttachmentDTOs != null)
                {
                    for (int i = 0; i <= _dakAttachmentDTOs.Count - 1; i++)
                    {
                        if (_dakAttachmentDTOs[i].attachment_id == _dakAttachmentDTO.attachment_id)
                        {
                            if (i == _dakAttachmentDTOs.Count - 1)
                            {
                               dakAttachmentDTO = _dakAttachmentDTOs[0];
                            }
                            else
                            {

                                dakAttachmentDTO = _dakAttachmentDTOs[i + 1];
                            }
                            break;
                        }
                    }
                }

            waitPictureBox.Visible = false;
            //this.Hide();

            //this.PreviousButton(sender, e);
            //waitWindowForm.Hide();
            //this.Visible = true;
        }

        private void AttachmentViewPopUpForm_Load(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void closesIconButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void mainAttachmentViewWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
           
            BeginInvoke((MethodInvoker)delegate
            {
                Screen scr = Screen.FromPoint(this.Location);
                int heightLoc = Convert.ToInt32((scr.WorkingArea.Bottom - this.Height) / 2);
                if (heightLoc < 0)
                {
                    heightLoc = 10;
                }
                int widthLoc = Convert.ToInt32((scr.WorkingArea.Right - this.Width) / 2);
                this.Location = new Point(widthLoc, heightLoc);
            });

        }
       
    }
}

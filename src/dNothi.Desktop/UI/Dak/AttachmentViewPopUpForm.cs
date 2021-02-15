using dNothi.JsonParser.Entity.Dak;
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
        public AttachmentViewPopUpForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


       public DakAttachmentDTO _dakAttachmentDTO { get; set; }
       public DakAttachmentDTO dakAttachmentDTO { get { return _dakAttachmentDTO; } 
            set
            {
                _dakAttachmentDTO = value;

                if (dakAttachmentDTO.attachment_type.ToLower().Contains("text") || dakAttachmentDTO.attachment_type.ToLower().Contains("txt"))
                {

                    //txtFileRichTextBox.Text = System.Net.WebUtility.HtmlDecode(_dakDetailsResponse.data.dak_origin.dak_description);
                    imageViewPictureBox.Visible = false;
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
                else if (dakAttachmentDTO.attachment_type.ToLower().Contains("pdf"))
                {

                    mainAttachmentViewWebBrowser.Visible = false;
                    imageViewPictureBox.Visible = false;
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
                    

                    mainAttachmentViewWebBrowser.Visible = true;
                    pdfViewerControl.Visible = false;
                    imageViewPictureBox.Visible = false;


                    mainAttachmentViewWebBrowser.Url=new Uri(dakAttachmentDTO.url);
                    //    imagePanel.MouseWheel += new MouseEventHandler(this.imagePanel_MouseWheel);
                   
                }
            }
        }

        private void mainAttachmentViewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //If dockstyle = fill
            this.Width = mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Width + 10;//Border
            this.Height = mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Height + 10;//Border
        }
    }
}

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

                if (dakAttachmentDTO.attachment_type.ToLower().Contains("image") || dakAttachmentDTO.attachment_type.ToLower().Contains("img"))
                {
                    mainAttachmentViewWebBrowser.Visible = false;
                    pdfViewerControl.Visible = false;
                    imagePanel.Visible = true;


                    imageViewPictureBox.Load(dakAttachmentDTO.url);
                   
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



                    imagePanel.Visible = false;
                    pdfViewerControl.Visible = false;
                    mainAttachmentViewWebBrowser.Visible = true;
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
        }

        private void mainAttachmentViewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //If dockstyle = fill
            this.Width = mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Width + 10;//Border
            this.Height = mainAttachmentViewWebBrowser.Document.Body.ScrollRectangle.Height + 10;//Border
        }
    }
}

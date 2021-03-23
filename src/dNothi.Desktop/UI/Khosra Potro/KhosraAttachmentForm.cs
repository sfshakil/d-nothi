using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraAttachmentForm : Form
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "JPE", "BMP", "GIF", "PNG", ".JPE", ".BMP", ".GIF", ".PNG", "IMAGE", "IMG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF" };

        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        public KhosraAttachmentForm()
        {
            InitializeComponent();
        }

        private void crossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Border_Gray(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Gray(sender, e);
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                // var fileStream = opnfd.OpenFile();

                // using (StreamReader reader = new StreamReader(opnfd.FileName, Encoding.UTF8))
                // {
                //     _dakFileUploadParam.content = reader.ReadToEnd();
                // }

                //// _dakFileUploadParam.content = File.ReadAllText(opnfd.FileName);
                // // _dakFileUploadParam.file_size_in_kb=opnfd.

                Byte[] bytes = File.ReadAllBytes(opnfd.FileName);
                _dakFileUploadParam.content = Convert.ToBase64String(bytes);

                var size = new System.IO.FileInfo(opnfd.FileName).Length;

                _dakFileUploadParam.file_size_in_kb = size.ToString() + " KB";



                DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();

                using (var form = FormFactory.Create<Dashboard>())
                {
                    dakUploadedFileResponse = form.UploadFile(_dakFileUploadParam);
                }

                if (dakUploadedFileResponse.status == "success")
                {
                    if (dakUploadedFileResponse.data.Count > 0)
                    {
                        //attachmentListFlowLayoutPanel.Controls.Clear();
                        DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            dakUploadAttachmentTableRow._isAllowedforOCR = true;
                            dakUploadAttachmentTableRow.imgSource = opnfd.FileName;
                            //using (Image image = Image.FromFile(opnfd.FileName))
                            //{
                            //    using (MemoryStream m = new MemoryStream())
                            //    {
                            //        image.Save(m, image.RawFormat);
                            //        byte[] imageBytes = m.ToArray();

                            //        // Convert byte[] to Base64 String
                            //        dakUploadAttachmentTableRow.imageBase64String = Convert.ToBase64String(imageBytes);

                            //    }
                            //}


                        }

                      
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        


                        dakUploadAttachmentTableRow.imageBase64String = _dakFileUploadParam.content;

                     //   dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        dakUploadAttachmentTableRow.fileexension = new System.IO.FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
                        dakUploadAttachmentTableRow._dakAttachment = dakUploadedFileResponse.data[0];
                        dakUploadAttachmentTableRow.imageLink = dakUploadedFileResponse.data[0].url;

                        dakUploadAttachmentTableRow.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                        dakUploadAttachmentTableRow.attachmentId = dakUploadedFileResponse.data[0].attachment_id; ;
                        //dakUploadAttachmentTableRow.RadioButtonClick += delegate (object radioSender, EventArgs radioEvent) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow.attachmentId); };

                        dakUploadAttachmentTableRow.Dock = DockStyle.Top;
                        attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);
                    }
                }


            }
        }

       

        private void DeleteControl_ButtonClick(object sender, EventArgs e, DakAttachmentDTO dakAttachment)
        {
            DakUploadFileDeleteParam deleteParam = new DakUploadFileDeleteParam();
            deleteParam.delete_token = dakAttachment.delete_token;
            deleteParam.file_name = dakAttachment.file_name;

            DakFileDeleteResponse response;

            using (var form = FormFactory.Create<Dashboard>())
            {
                response = form.DeleteFile(deleteParam);
            }
            if (response.status == "success")

            {
                SuccessMessage("সফলভাবে সংযুক্তি মুছে ফেলা হয়েছে");
                var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

                foreach (var attachment in attachmentList)
                {
                    if (attachment.attachmentId == dakAttachment.attachment_id)
                    {
                        attachmentListFlowLayoutPanel.Controls.Remove(attachment);
                    }
                }
            }


        }

        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }

        private void KhosraAttachmentForm_Shown(object sender, EventArgs e)
        {
            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow.fileName = "৫৬.৪২.০০০০.০১০.২৫.০০৩.২১.২ - ২২ ফেব্রুয়ারি ২০২";

            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow);



            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow2 = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow2.fileName = "Potrojari_2021_65_02_2216139904184630293468.png";
            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow2);


            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow3 = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow3.fileName = "file_example_JPG_1MB.jpg";

            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow3);

        }

        private void Border_Blue(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }
    }
}

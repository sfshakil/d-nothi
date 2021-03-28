using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.DakServices;
using System.IO;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Desktop.UI.CustomMessageBox;
using sun.invoke.empty;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class UCGuardFileUpload : UserControl
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "JPE", "BMP", "GIF", "PNG", ".JPE", ".BMP", ".GIF", ".PNG", "IMAGE", "IMG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF" };
        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
        public UCGuardFileUpload()
        {
            InitializeComponent();
            List<gdftype> fl = new List<gdftype>();
            fl.Add(new gdftype() { rowNo = "1", type = "বাজেট ", typeNo = "1" });
            fl.Add(new gdftype() { rowNo = "2", type = "test", typeNo = "2" });
            fl.Add(new gdftype() { rowNo = "3", type = "test2", typeNo = "3" });
            fl.Add(new gdftype() { rowNo = "4", type = "test3", typeNo = "4" });
            var data = from s in fl
                       select new ComboBoxItems
                       {
                           id = Convert.ToInt32(s.rowNo),
                           Name = s.type
                       };
           
            typesearchComboBox.itemList = data.ToList();
            typesearchComboBox.isListShown = true;
            panel5.Hide();  
        }

        private void label2_Click(object sender, EventArgs e)
        {

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



                //DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();

                //using (var form = FormFactory.Create<Dashboard>())
                //{
                //    dakUploadedFileResponse = form.UploadFile(_dakFileUploadParam);
                //}

                //if (dakUploadedFileResponse.status == "success")
                //{
                    panel5.Show();
                    //if (dakUploadedFileResponse.data.Count > 0)
                    //{
                        //attachmentListFlowLayoutPanel.Controls.Clear();
                        GuardFileBrowseUC dakUploadAttachmentTableRow = new GuardFileBrowseUC();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            dakUploadAttachmentTableRow._isAllowedforOCR = true;
                            dakUploadAttachmentTableRow.imgSource = opnfd.FileName;
                            using (Image image = Image.FromFile(opnfd.FileName))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    image.Save(m, image.RawFormat);
                                    byte[] imageBytes = m.ToArray();

                                    // Convert byte[] to Base64 String
                                    dakUploadAttachmentTableRow.imageBase64String = Convert.ToBase64String(imageBytes);

                                }
                            }


                        }

                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;

                        }
                        else
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }


                        dakUploadAttachmentTableRow.imageBase64String = _dakFileUploadParam.content;

                        //dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._attachmentName); };



                        dakUploadAttachmentTableRow.fileexension = new System.IO.FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
                      //  dakUploadAttachmentTableRow._dakAttachment = dakUploadedFileResponse.data[0];
                        //dakUploadAttachmentTableRow.imageLink = dakUploadedFileResponse.data[0].url;

                       // dakUploadAttachmentTableRow.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                        dakUploadAttachmentTableRow.attachmentName = new System.IO.FileInfo(opnfd.FileName).Name;
                      //  dakUploadAttachmentTableRow.attachmentId = dakUploadedFileResponse.data[0].attachment_id; ;
                        dakUploadAttachmentTableRow.attachmentId = 0;
                // dakUploadAttachmentTableRow.RadioButtonClick += delegate (object radioSender, EventArgs radioEvent) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow.attachmentId); };

                guardFileTextBox.Text = new System.IO.FileInfo(opnfd.FileName).Name;
                flowLayoutPanel1.Controls.Add(dakUploadAttachmentTableRow);
                        panel3.Hide();
                    //}
                //}


            }
        }

        private void DeleteControl_ButtonClick(object sender, EventArgs e, string filename)
        {
            flowLayoutPanel1.Controls.Clear();
            panel3.Show();
            panel5.Hide();
          
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void userIdPanel_Paint(object sender, PaintEventArgs e)
        {
            
           ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void UCGuardFileUpload_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ///MessageBox.Show("সংরক্ষণ করা হয়েছে।");
            string subjectText = subjectTextBox.Text.Trim();
            int typeId = typesearchComboBox.selectedId;
            string guardFileName = guardFileTextBox.Text.Trim();
            if(subjectText!=string.Empty && typeId!=0 && guardFileName!=string.Empty)
            {
                MessageBox.Show("সংরক্ষণ করা সফল হয়েছে।");
            }
            else
            {
                if (subjectTextBox.Text == string.Empty)
                {
                    ShowAlertMessage("দুংখিত! শিরোনাম ফাঁকা রাখা যাবে না।");
                }
                if (typesearchComboBox.selectedId <= 0)
                {
                    ShowAlertMessage("দুংখিত! ধরণ ফাঁকা রাখা যাবে না।");
                }
                if (guardFileTextBox.Text == string.Empty)
                {
                    ShowAlertMessage("দুংখিত! গার্ড ফাইল দেয়া হয়নি।");
                }
            }

           

        }
        private void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {
            UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
            alertMessageBox.message = mulpotroNotSelectErrorMessage;

            alertMessageBox.ShowDialog();
        }
    }
}

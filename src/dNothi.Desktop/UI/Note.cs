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

namespace dNothi.Desktop.UI
{
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
            tinyMceEditor.CreateEditor();
            cbxNothiType.SelectedIndex = 0;
            cbxNothiType.ItemHeight = 30;
            NoteView noteView = new NoteView();
            noteViewFLP.Controls.Add(noteView);
        }



        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(255, 168, 0);
            btnBack.ForeColor = Color.White;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.White;
            btnBack.ForeColor = Color.FromArgb(255, 168, 0);
        }

        private void fileUploadPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
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
        
        private void btnAllNothi_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();
            form.ShowDialog();
            
        }
        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "PNG",".PNG"};
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF", ".Doc", "Doc", ".Docx", "Docx", ".XLS", "XLS", ".CSV", "CSV", ".MP3", "MP3", ".M4p", "M4p", ".MP4", "MP4", ".PPT", "PPT", ".PPTX", "PPTX" };

        private void fileUploadPanel_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                var fileStream = opnfd.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _dakFileUploadParam.content = reader.ReadToEnd();
                }


                // _dakFileUploadParam.file_size_in_kb=opnfd.


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
                        NoteFileUpload noteFileUpload = new NoteFileUpload();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = opnfd.FileName;
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            fileAddFLP.Controls.Add(noteFileUpload);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            //dakUploadAttachmentTableRow._isAllowedforOCR = true;

                            using (Image image = Image.FromFile(opnfd.FileName))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    image.Save(m, image.RawFormat);
                                    byte[] imageBytes = m.ToArray();

                                    // Convert byte[] to Base64 String
                                    //noteFileUpload.imageBase64String = Convert.ToBase64String(imageBytes);

                                }
                            }




                        }
                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = "";
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            fileAddFLP.Controls.Add(noteFileUpload);

                        }
                        else
                        {
                            NoteFileDelete noteFileDelete = new NoteFileDelete();
                            noteFileDelete.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileDelete.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            fileAddFLP.Controls.Add(noteFileDelete);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }



                        //dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        //dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };




                    }
                }

            }
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                var fileStream = opnfd.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _dakFileUploadParam.content = reader.ReadToEnd();
                }


                // _dakFileUploadParam.file_size_in_kb=opnfd.


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
                        NoteFileUpload noteFileUpload = new NoteFileUpload();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = opnfd.FileName;
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            fileAddFLP.Controls.Add(noteFileUpload);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            //dakUploadAttachmentTableRow._isAllowedforOCR = true;

                            using (Image image = Image.FromFile(opnfd.FileName))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    image.Save(m, image.RawFormat);
                                    byte[] imageBytes = m.ToArray();

                                    // Convert byte[] to Base64 String
                                    //noteFileUpload.imageBase64String = Convert.ToBase64String(imageBytes);

                                }
                            }




                        }
                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = "";
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            fileAddFLP.Controls.Add(noteFileUpload);

                        }
                        else
                        {
                            NoteFileDelete noteFileDelete = new NoteFileDelete();
                            noteFileDelete.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileDelete.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            fileAddFLP.Controls.Add(noteFileDelete);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }



                        //dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        //dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        
                    }
                }

            }
        }

        private void fileUploadPanel_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<CreateNewNotes>();
            form.ShowDialog();
            
        }

        private void cbxNothiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

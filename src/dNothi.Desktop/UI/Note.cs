using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class Note : Form
    {
        NoteSaveDTO newnotedata = new NoteSaveDTO();
        NoteView newNoteView = new NoteView();

        NothiListRecordsDTO nothiListRecords = new NothiListRecordsDTO();
        IUserService _userService { get; set; }
        IOnucchedSave _onucchedSave { get; set; }
        public Note(IUserService userService, IOnucchedSave onucchedSave)
        {
            _userService = userService;
            _onucchedSave = onucchedSave;
            InitializeComponent();
            SetDefaultFont(this.Controls);
            tinyMceEditor.CreateEditor();
            cbxNothiType.SelectedIndex = 0;
            cbxNothiType.ItemHeight = 30;
            onuchhedheaderPnl.Hide();
            PnlSave.Visible = false;
        }
        public void loadNoteData(NoteSaveDTO notedata)
        {
            newnotedata = notedata;
        }
        public void loadNothiInboxRecords(NothiListRecordsDTO nothiListRecordsDTO)
        {
            nothiListRecords = nothiListRecordsDTO;
        }
        public void loadNoteView(NoteView noteView)
        {
            newNoteView = noteView;
            noteViewFLP.Controls.Add(noteView);
            noteView.CheckBoxClick += delegate (object sender, EventArgs e) { checkBox_Click(sender, e, newNoteView); };
        }
        private void checkBox_Click(object sender, EventArgs e, NoteView noteView)
        {
            string str = sender.ToString();
            if (str == "System.Windows.Forms.CheckBox, CheckState: 0")
            {
                NoteFullPanel.Hide();
                NoteFullPanel.Visible = false;
            }
            else
                NoteFullPanel.Visible = true;

        }

        private string _nothiShakha;
        private string _nothiNo;
        private string _nothiSubject;
        private string _noteTotal;
        private string _office;

        [Category("Custom Props")]
        public string office
        {
            get { return _office; }
            set { _office = value; lbOffice.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiShakha
        {
            get { return _nothiShakha; }
            set { _nothiShakha = value; lbNoteShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiNo
        {
            get { return _nothiNo; }
            set { _nothiNo = value; lbNothiNo.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiSubject
        {
            get { return _nothiSubject; }
            set { _nothiSubject = value; lbSubject.Text = value; }
        }
        private string _nothiLastDate;
        private string _noteSubject;

        [Category("Custom Props")]
        public string noteTotal
        {
            get { return _noteTotal; }
            set { _noteTotal = value; string vl = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbNoteTtl.Text = vl+ ".০"; }
        }

        [Category("Custom Props")]
        public string nothiLastDate
        {
            get { return _nothiLastDate; }
            set { _nothiLastDate = value; lbNothiLastDate.Text = value; }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
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
        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "PNG", ".PNG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF", ".Doc", "Doc", ".Docx", "Docx", ".XLS", "XLS", ".CSV", "CSV", ".MP3", "MP3", ".M4p", "M4p", ".MP4", "MP4", ".PPT", "PPT", ".PPTX", "PPTX" };



        private void fileUploadPanel_Paint_3(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
        int fileuploadDoneFlag = 0;
        List<NoteFileUpload> noteFileUploads = new List<NoteFileUpload>();
        private void fileUploadPanel_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";
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
                        fileuploadDoneFlag = 1;
                        //attachmentListFlowLayoutPanel.Controls.Clear();
                        NoteFileUpload noteFileUpload = new NoteFileUpload();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = opnfd.FileName;
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileUploads.Add(noteFileUpload);
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
                            noteFileUploads.Add(noteFileUpload);
                            fileAddFLP.Controls.Add(noteFileUpload);

                        }
                        else
                        {
                            NoteFileDelete noteFileDelete = new NoteFileDelete();
                            noteFileDelete.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileDelete.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUploads.Add(noteFileUpload);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }



                        //dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        //dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };




                    }
                }

            }
        }
        List<DakUploadedFileResponse> onuchhedSaveWithAttachments = new List<DakUploadedFileResponse>();
        private void fileUploadButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.DefaultExt = "txt";
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";
            //opnfd.Filter = "Pdf Files (*.PDF;)|*.PDF;";
            //opnfd.Filter = "Word Files ()|";
            //opnfd.Filter = "Excel Files ()|";
            //opnfd.Filter = "Excel Files ()|";
            //opnfd.Filter = "Audio Files ()|";
            //opnfd.Filter = "Video Files ()|";
            //opnfd.Filter = "ALL Files (*.*)|*.*";

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
                    fileuploadDoneFlag = 1;
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
                            noteFileUploads.Add(noteFileUpload);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            //dakUploadAttachmentTableRow._isAllowedforOCR = true;

                            using (Image image = Image.FromFile(opnfd.FileName))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    image.Save(m, image.RawFormat);
                                    byte[] imageBytes = m.ToArray();

                                    // Convert byte[] to Base64 String
                                    dakUploadedFileResponse.data[0].img_base64 = Convert.ToBase64String(imageBytes);

                                }
                            }


                        }
                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = "";
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            fileAddFLP.Controls.Add(noteFileUpload);
                            noteFileUploads.Add(noteFileUpload);

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



                        onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                    }
                }

            }
        }

        private void panel40_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }
        int onuchhedint = 0;
        List<FileAttachment> fileAttachments = new List<FileAttachment>();
        
        public string getparagraphtext(string editortext)
        {
            Match m = Regex.Match(editortext, @"<p>\s*(.+?)\s*</p>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
                return "";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (onuchhedint == 1)
            {
                onuchhedheaderPnl.Visible = false;
            }
            onuchhedint--;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!PnlSave.Visible)
            {
                PnlSave.Visible = true;
                //PnlSave.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
            }
            else
            {
                PnlSave.Visible = false;
            }
        }

        private void btnSaveArrow_Click(object sender, EventArgs e)
        {
            if (!PnlSave.Visible)
            {
                PnlSave.Visible = true;
                //PnlSave.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
            }
            else
            {
                PnlSave.Visible = false;
            }
        }

        private void btnOnuchhedSave_Click(object sender, EventArgs e)
        {
            PnlSave.Visible = false;
            //string editortext = tinyMceEditor.HtmlContent;
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);

            if (editortext != "")
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(editortext);
                var encodedEditorText = System.Convert.ToBase64String(plainTextBytes);
                onuchhedheaderPnl.Visible = true;
                OnuchhedAdd onuchhed = new OnuchhedAdd();
                onuchhed.currentDate = DateTime.Now.ToString("dd");
                onuchhed.currentMonth = DateTime.Now.ToString("MM");
                onuchhed.currentYear = DateTime.Now.ToString("yyyy");
                onuchhed.noteOnuchhed = newNoteView.totalNothi;
                onuchhed.Onuchhed = onuchhedint.ToString();
                onuchhedint++;
                onuchhed.fileflag = 0;
                onuchhed.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1, e1); };
                onuchhed.body = editortext;
                int i = 1;
                foreach (NoteFileUpload notefileupload in noteFileUploads)
                {
                    FileAttachment fileattachment = new FileAttachment();
                    fileattachment.attachmentName = notefileupload.attachmentName;
                    fileattachment.attachmentSize = notefileupload.fileexension;
                    fileAttachments.Add(fileattachment);

                    onuchhed.fileflag = 1;
                    onuchhed.getAttachment(notefileupload); onuchhed.file = i; i++;
                }
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

                var onucchedSave = _onucchedSave.GetNothiOnuchhedSave(dakListUserParam, onuchhedSaveWithAttachments, nothiListRecords, newnotedata, encodedEditorText);
                if (onucchedSave.status == "success")
                {
                    //panel22.Visible = false;
                    tinyMceEditor.Visible = false;
                    PnlSave.Visible = false;
                    panel24.Visible = false;
                    panel28.Visible = false;

                    btnCancel.Visible = false;
                    btnSave.Visible = false;
                    btnSaveArrow.Visible = false;

                    btnWriteOnuchhed.Visible = true;
                    btnSend.Visible = true;
                    tinyMceEditor.HtmlContent = "";
                    onuchhedFLP.Controls.Add(onuchhed);
                    fileAddFLP.Controls.Clear();
                    noteFileUploads.Clear();
                }
                else
                {
                    string message = "Error";
                    MessageBox.Show(message);
                }

            }
            else
            {
                string message = "অনুচ্ছেদ বডি দেওয়া হইনি";
                MessageBox.Show(message);
            }

            //tinyMceEditor.Controls.Clear();
        }

        private void btnSaveWithNewOnuchhed_Click(object sender, EventArgs e)
        {
            PnlSave.Visible = false;
            //string editortext = tinyMceEditor.HtmlContent;
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);

            if (editortext != "")
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(editortext);
                var encodedEditorText = System.Convert.ToBase64String(plainTextBytes);
                onuchhedheaderPnl.Visible = true;
                OnuchhedAdd onuchhed = new OnuchhedAdd();
                onuchhed.currentDate = DateTime.Now.ToString("dd");
                onuchhed.currentMonth = DateTime.Now.ToString("MM");
                onuchhed.currentYear = DateTime.Now.ToString("yyyy");
                onuchhed.noteOnuchhed = newNoteView.totalNothi;
                onuchhed.Onuchhed = onuchhedint.ToString();
                onuchhedint++;
                onuchhed.fileflag = 0;
                onuchhed.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1, e1); };
                onuchhed.body = editortext;
                int i = 1;
                foreach (NoteFileUpload notefileupload in noteFileUploads)
                {
                    FileAttachment fileattachment = new FileAttachment();
                    fileattachment.attachmentName = notefileupload.attachmentName;
                    fileattachment.attachmentSize = notefileupload.fileexension;
                    fileAttachments.Add(fileattachment);

                    onuchhed.fileflag = 1;
                    onuchhed.getAttachment(notefileupload); onuchhed.file = i; i++;
                }
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

                var onucchedSave = _onucchedSave.GetNothiOnuchhedSave(dakListUserParam, onuchhedSaveWithAttachments, nothiListRecords, newnotedata, encodedEditorText);
                if (onucchedSave.status == "success")
                {
                    panel22.Visible = true;
                    tinyMceEditor.Visible = true;
                    panel24.Visible = true;
                    panel28.Visible = true;
                    tinyMceEditor.HtmlContent = "";
                    onuchhedFLP.Controls.Add(onuchhed);
                    fileAddFLP.Controls.Clear();
                    noteFileUploads.Clear();
                }
                else
                {
                    string message = "Error";
                    MessageBox.Show(message);
                }

            }
            else
            {
                string message = "অনুচ্ছেদ বডি দেওয়া হইনি";
                MessageBox.Show(message);
            }

            //tinyMceEditor.Controls.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //panel22.Visible = false;
            tinyMceEditor.Visible = false;
            panel24.Visible = false;
            panel28.Visible = false;
            PnlSave.Visible = false;

            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnSaveArrow.Visible = false;

            btnWriteOnuchhed.Visible = true;
            btnSend.Visible = true;
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
        }

        private void btnWriteOnuchhed_Click(object sender, EventArgs e)
        {
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            btnSave.Visible = true;
            btnSaveArrow.Visible = true;
            btnCancel.Visible = true;

            PnlSave.Visible = false;
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel24.Visible = true;
            panel28.Visible = true;
            tinyMceEditor.HtmlContent = "";
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
        }

        private void iconButton20_Click(object sender, EventArgs e)
        {
            PnlSave.Visible = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var nothiType = UserControlFactory.Create<NothiNextStep>();
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType.Location = new System.Drawing.Point(845, 0);
            this.Controls.Add(nothiType);
            nothiType.BringToFront();
        }
    }
}

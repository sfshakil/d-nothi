﻿using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private DakUserParam _dakuserparam = new DakUserParam();
        NoteSaveDTO newnotedata = new NoteSaveDTO();
        NoteView newNoteView = new NoteView();

        NothiListRecordsDTO nothiListRecords = new NothiListRecordsDTO();
        IUserService _userService { get; set; }
        IOnucchedSave _onucchedSave { get; set; }
        IOnucchedDelete _onucchedDelete { get; set; }
        IOnumodonService _onumodonService { get; set; }
        INothiNoteTalikaServices _nothiNoteTalikaServices { get; set; }
        public Note(IUserService userService, IOnucchedSave onucchedSave, IOnumodonService onumodonService, IOnucchedDelete onucchedDelete, INothiNoteTalikaServices nothiNoteTalikaServices)
        {
            _userService = userService;
            _onucchedSave = onucchedSave;
            _onucchedDelete=onucchedDelete;
            _onumodonService = onumodonService;
            _dakuserparam = _userService.GetLocalDakUserParam();
            _nothiNoteTalikaServices = nothiNoteTalikaServices;

            InitializeComponent();
            SetDefaultFont(this.Controls);
            tinyMceEditor.CreateEditor();
            cbxNothiType.SelectedIndex = 0;
            cbxNothiType.ItemHeight = 30;
            onuchhedheaderPnl.Hide();
            PnlSave.Visible = false;
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";
        }
        public void loadNoteData(NoteSaveDTO notedata)
        {
            newnotedata = notedata;
        }
        public void loadNothiInboxRecords(NothiListRecordsDTO nothiListRecordsDTO)
        {
            nothiListRecords = nothiListRecordsDTO;
        }
        public int loadNoteView(NoteView noteView)
        {
            NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
            var i = allNoteList.data.total_records;
            noteView.totalNothi = i.ToString();
            lbNothiType.Text = "বাছাইকৃত নোট (১)";
            noteViewFLP.Controls.Clear();
            newNoteView = noteView;
            noteViewFLP.Controls.Add(noteView);
            noteView.CheckBoxClick += delegate (object sender, EventArgs e) { checkBox_Click(sender as NoteListDataRecordNoteDTO, e, newNoteView); };
            return i;
        }
        private void checkBox_Click(NoteListDataRecordNoteDTO list, EventArgs e, NoteView noteView)
        {
            string str = list.note_status;
            if (list.khoshra_potro>0)
            {
                pnlNoNote.Visible = false;
                lbNote.Visible = true;
                pnlNoteKhoshra.Visible = true;
                lbNoteKhoshra.Text = list.khoshra_potro.ToString();
            }
            if(list.khoshra_waiting_for_approval > 0)
            {
                pnlNoNote.Visible = false;
                lbNote.Visible = true;
                pnlNoteKhoshraWaiting.Visible = true;
                lbNoteKhoshraWaiting.Text = list.khoshra_waiting_for_approval.ToString();
            }
            if (list.potrojari > 0)
            {
                pnlNoNote.Visible = false;
                lbNote.Visible = true;
                pnlNotePotrojari.Visible = true;
                lbNotePotrojari.Text = list.potrojari.ToString();
            }
            


            //if (str == "System.Windows.Forms.CheckBox, CheckState: 0")
            //{
            //    NoteFullPanel.Hide();
            //    NoteFullPanel.Visible = false;
            //}
            //else
            //    NoteFullPanel.Visible = true;

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
            
            string selectedItem = cbxNothiType.Items[cbxNothiType.SelectedIndex].ToString() ;
            newNoteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };
            if (selectedItem == "বাছাইকৃত নোট")
            {
                lbNothiType.Text = "বাছাইকৃত নোট (১)";
                noteViewFLP.Controls.Clear();
                noteViewFLP.Controls.Add(newNoteView);
                
            }
            else if(selectedItem == "আগত নোট")
            {
                noteViewFLP.Controls.Clear();
                NoteListResponse inboxNoteList = _nothiNoteTalikaServices.GetNoteListInbox(_dakuserparam, nothiListRecords.id);
                lbNothiType.Text = "আগত নোট ("+ string.Concat(inboxNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                if (inboxNoteList.data.records.Count>0)
                {

                    foreach (NoteListDataRecordDTO inboxList in inboxNoteList.data.records)
                    {
                        NoteView noteView = new NoteView();
                        noteView.totalNothi = inboxList.note.note_no.ToString();
                        if (inboxList.note.note_subject_sub_text == "")
                        {
                            noteView.noteSubject = inboxList.note.note_subject;
                        }
                        else
                        {
                            noteView.noteSubject = inboxList.note.note_subject_sub_text;
                        }
                        noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };
                        noteView.nothiLastDate = inboxList.desk.issue_date;
                        noteView.nothivukto = inboxList.note.nothivukto_potro.ToString();
                        noteView.onucchedCount = inboxList.note.onucched_count.ToString();
                        noteView.potrojari = inboxList.note.potrojari.ToString();
                        noteView.approved = inboxList.note.approved_potro.ToString();
                        noteView.khoshraWaiting = inboxList.note.khoshra_waiting_for_approval.ToString();
                        noteView.khosraPotro = inboxList.note.khoshra_potro.ToString();
                        noteView.loadEyeIcon(inboxList.note.can_revert);
                        noteView.officerInfo = inboxList.desk.officer + "," +inboxList.desk.designation+","+inboxList.desk.office_unit+","+inboxList.desk.office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                        noteViewFLP.Controls.Add(noteView);
                    }
                }
                else
                {
                    noteViewFLP.Controls.Clear();
                }
            }
            else if (selectedItem == "প্রেরিত নোট")
            {
                noteViewFLP.Controls.Clear();
                NoteListResponse sentNoteList = _nothiNoteTalikaServices.GetNoteListSent(_dakuserparam, nothiListRecords.id);
                lbNothiType.Text = "প্রেরিত নোট (" + string.Concat(sentNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                if (sentNoteList.data.records.Count > 0)
                {

                    foreach (NoteListDataRecordDTO sentList in sentNoteList.data.records)
                    {
                        NoteView noteView = new NoteView();
                        noteView.totalNothi = sentList.note.note_no.ToString();
                        if (sentList.note.note_subject_sub_text == "")
                        {
                            noteView.noteSubject = sentList.note.note_subject;
                        }
                        else
                        {
                            noteView.noteSubject = sentList.note.note_subject_sub_text;
                        }
                        noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };
                        noteView.nothiLastDate = sentList.desk.issue_date; 
                        noteView.nothivukto = sentList.note.nothivukto_potro.ToString();
                        noteView.onucchedCount = sentList.note.onucched_count.ToString();
                        noteView.potrojari = sentList.note.potrojari.ToString();
                        noteView.approved = sentList.note.approved_potro.ToString();
                        noteView.khoshraWaiting = sentList.note.khoshra_waiting_for_approval.ToString();
                        noteView.khosraPotro = sentList.note.khoshra_potro.ToString();
                        noteView.loadEyeIcon(sentList.note.can_revert);
                        noteView.officerInfo = sentList.desk.officer + "," + sentList.desk.designation + "," + sentList.desk.office_unit + "," + sentList.desk.office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                        noteViewFLP.Controls.Add(noteView);
                    }
                }
                else
                {
                    noteViewFLP.Controls.Clear();
                }
            }
            else if (selectedItem == "সকল নোট")
            {
                noteViewFLP.Controls.Clear();
                NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
                lbNothiType.Text = "সকল নোট (" + string.Concat(allNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                if (allNoteList.data.records.Count > 0)
                {

                    foreach (NoteAllListDataRecordDTO allList in allNoteList.data.records)
                    {
                        
                        if (allList.deskDtoList.Count > 0)
                        {
                            NoteView noteView = new NoteView();
                            noteView.totalNothi = allList.note.note_no.ToString();
                            if (allList.note.note_subject_sub_text == "")
                            {
                                noteView.noteSubject = allList.note.note_subject;
                            }
                            else
                            {
                                noteView.noteSubject = allList.note.note_subject_sub_text;
                            }
                            noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };
                            noteView.nothiLastDate = allList.deskDtoList[0].issue_date;
                            noteView.nothivukto = allList.note.nothivukto_potro.ToString();
                            noteView.onucchedCount = allList.note.onucched_count.ToString();
                            noteView.potrojari = allList.note.potrojari.ToString();
                            noteView.approved = allList.note.approved_potro.ToString();
                            noteView.khoshraWaiting = allList.note.khoshra_waiting_for_approval.ToString();
                            noteView.khosraPotro = allList.note.khoshra_potro.ToString();
                            noteView.loadEyeIcon(allList.note.can_revert);
                            noteView.officerInfo = allList.deskDtoList[0].officer + "," + allList.deskDtoList[0].designation + "," + allList.deskDtoList[0].office_unit + "," + allList.deskDtoList[0].office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                            noteViewFLP.Controls.Add(noteView);
                        }
                        else 
                        {
                            NoteViewNotInCurrentDesk noteViewNotInCurrentDesk = new NoteViewNotInCurrentDesk();
                            noteViewNotInCurrentDesk.totalNothi = allList.note.note_no.ToString();
                            noteViewNotInCurrentDesk.noteSubject = allList.note.note_subject_sub_text;
                            noteViewFLP.Controls.Add(noteViewNotInCurrentDesk);
                        }
                        
                    }
                }
                else
                {
                    noteViewFLP.Controls.Clear();
                }
            }
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

        private void DeleteButton_Click(string onucchedId, EventArgs e, DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata)
        {
            var onucchedDelete = _onucchedDelete.GetNothiOnuchhedDelete(dakListUserParam, nothiListRecords, newnotedata, onucchedId);
            if (onucchedDelete.status == "success")
            {
                MessageBox.Show("সফলভাবে অনুচ্ছেদটি মুছে ফেলা হয়েছে");
                if (onuchhedint == 1)
                {
                    onuchhedheaderPnl.Visible = false;
                }
                onuchhedint--;
            }
      
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
            string noteId = "0";
            if (updateNoteID > 0)
                noteId = updateNoteID.ToString();
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

                var onucchedSave = _onucchedSave.GetNothiOnuchhedSave(noteId, dakListUserParam, onuchhedSaveWithAttachments, nothiListRecords, newnotedata, encodedEditorText);
                
                if (onucchedSave.status == "success")
                {
                    onuchhed.onucchedId = onucchedSave.data.id;
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

                onuchhed.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata ); };
                onuchhed.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as NoteListDataRecordNoteDTO, e1, dakListUserParam, nothiListRecords, newnotedata ); };
                
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
            string noteId = "0";
            if (updateNoteID > 0)
                noteId = updateNoteID.ToString();
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

                var onucchedSave = _onucchedSave.GetNothiOnuchhedSave(noteId, dakListUserParam, onuchhedSaveWithAttachments, nothiListRecords, newnotedata, encodedEditorText);
                if (onucchedSave.status == "success")
                {
                    onuchhed.onucchedId = onucchedSave.data.id;
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
                onuchhed.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                onuchhed.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as NoteListDataRecordNoteDTO, e1, dakListUserParam, nothiListRecords, newnotedata); };

            }
            else
            {
                string message = "অনুচ্ছেদ বডি দেওয়া হইনি";
                MessageBox.Show(message);
            }

            //tinyMceEditor.Controls.Clear();
        }
        private int updateNoteID;
        public void EditButton_Click(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata)
        {
            //onuchhed.onucchedId = onucchedSave.data.id;
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            btnSave.Visible = true;
            btnSaveArrow.Visible = true;
            btnCancel.Visible = true;
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel24.Visible = true;
            panel28.Visible = true;
            tinyMceEditor.HtmlContent = noteListDataRecordNoteDTO.note_subject;
            updateNoteID = noteListDataRecordNoteDTO.nothi_note_id;
            //onuchhedFLP.Controls.Add(onuchhed);
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
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

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            var onumodonList = _onumodonService.GetOnumodonMembers(dakListUserParam, nothiListRecords);
            if (onumodonList.status == "success")
            {
                if (onumodonList.data.records.Count > 0)
                {
                    
                    LoadOnumodonListinPanel(onumodonList.data.records);
                }
                
                //this.ShowDialog();
            }


            
        }
        public void LoadOnumodonListinPanel(List<onumodonDataRecordDTO> records)
        {
            var nothiType = UserControlFactory.Create<NothiNextStep>();
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType.noteTotal = newNoteView.totalNothi;
            nothiType.noteSubject = newNoteView.noteSubject;
            nothiType.loadNewNoteData(newnotedata);
            nothiType.loadlistInboxRecord(nothiListRecords);
            nothiType.Location = new System.Drawing.Point(903, 0);
            foreach (onumodonDataRecordDTO  record in records)
            {
                nothiType.loadFlowLayout(record);

            }
            this.Controls.Add(nothiType);
            nothiType.BringToFront();

            
        }
        designationSelect designationDetailsPanelNothi = new designationSelect();
        private void userNameLabel_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 428)
            {
                designationDetailsPanelNothi.Visible = true;
                designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 428;
            }
        }

        private void userPictureBox_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 428)
            {
                designationDetailsPanelNothi.Visible = true;
                designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 428;
            }
        }

        private void profilePanel_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 428)
            {
                designationDetailsPanelNothi.Visible = true;
                designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 428;
            }
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void dakModuleNameLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void moduleDakCountLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void nothiModuleNameLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }
    }
}

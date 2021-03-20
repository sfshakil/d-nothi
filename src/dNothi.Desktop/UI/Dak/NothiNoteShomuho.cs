﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.UserServices;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity.Nothi;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiNoteShomuho : UserControl
    {
        IUserService _userService { get; set; }
        INoteDeleteService _noteDelete { get; set; }
        public NothiNoteShomuho(IUserService userService, INoteDeleteService noteDelete)
        {
            _userService = userService;
            _noteDelete = noteDelete;
            InitializeComponent();
            SetDefaultFont(this.Controls);
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
        private string _note_no;
        private string _note_subject;
        private string _deskofficer;
        private string _toofficer;
        private string _onucched;
        private string _khosra;
        private string _khoshraWaiting;
        private string _noteIssueDate;

        public void loadEyeIcon(int i)
        {
            if (i != 0)
            {
                eyeIcon.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                eyeIcon.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        [Category("Custom Props")]
        public string noteIssueDate
        {
            get { return _noteIssueDate; }
            set { _noteIssueDate = value; lbNoteIssueDate.Text = value; }
        }
        [Category("Custom Props")]
        public string khoshraWaiting
        {
            get { return _khoshraWaiting; }
            set { _khoshraWaiting = value; lbKhoshrawaiting.Visible = true; lbKhoshrawaiting.Text = "অনুমোদনের অপেক্ষায়: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string khosra
        {
            get { return _khosra; }
            set { _khosra = value; lbKhoshra.Visible = true; lbKhoshra.Text = "খসড়া: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string onucched
        {
            
            get { return _onucched; }
            set { _onucched = value; lbOnucched.Visible = true; lbOnucched.Text = "অনুচ্ছেদ: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string note_no
        {
            get { return _note_no; }
            set { _note_no = value; lbNoteNumber.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        private string _note_ID;

        [Category("Custom Props")]
        public string note_ID
        {
            get { return _note_ID; }
            set { _note_ID = value; lbNoteId.Text = value; }
        }
        private string _noteSubText;

        [Category("Custom Props")]
        public string noteSubText
        {
            get { return _noteSubText; }
            set { _noteSubText = value; lbNoteSubText.Text = value; }
        }

        [Category("Custom Props")]
        public string note_subject
        {
            get { return _note_subject; }
            set { _note_subject = value; lbNoteSubject.Text = value; }
        }

        [Category("Custom Props")]
        public string deskofficer
        {
            get { return _deskofficer; }
            set { _deskofficer = value; lbDeskOfficer.Text = value; }
        }

        [Category("Custom Props")]
        public string toofficer
        {
            get { return _toofficer; }
            set { _toofficer = value; 
                if(value == "")
                {
                    iconButton5.Visible = false;
                    lbToOfficer.Visible = false;
                }
                else
                {
                    iconButton5.Visible = true;
                    lbToOfficer.Visible = true;
                    lbToOfficer.Text = value;
                }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
            }
                
        }
        public event EventHandler NoteDetailsButton;
        private void NoteDetailsButton_Click(object sender, EventArgs e)
        {
            NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
            noteListDataRecordNoteDTO.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
            noteListDataRecordNoteDTO.note_no = Convert.ToInt32(_note_no);
            noteListDataRecordNoteDTO.is_editable = 0; // is editable ==0 means not new tab;
            if (this.NoteDetailsButton != null)
                this.NoteDetailsButton(noteListDataRecordNoteDTO, e);

        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            string message = "নোটটি মুছে ফেলুন";
            string title = "";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes && lbNoteSubText.Text == "অনুচ্ছেদ দেওয়া হয়নি")
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                string model = "NothiNotes";
                string noteID = lbNoteId.Text;
                var noteDelete = _noteDelete.GetNoteDelteResponse(dakListUserParam,model,noteID);
                if(noteDelete.status == "success")
                {
                    this.Hide();
                }

            }
            else
            {
                
            }
        }

        private void detailsButtonNewTab_Click(object sender, EventArgs e)
        {
            NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
            noteListDataRecordNoteDTO.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
            noteListDataRecordNoteDTO.note_no = Convert.ToInt32(_note_no);
            noteListDataRecordNoteDTO.is_editable = 1; // is editable ==1 means new tab;
            if (this.NoteDetailsButton != null)
                this.NoteDetailsButton(noteListDataRecordNoteDTO, e);
        }
    }
}
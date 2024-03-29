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
using dNothi.Desktop.UI.CustomMessageBox;

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
        private string _noteAttachment;
        public long _nothi_id;
        public int onucched_count;
        public bool isNothiAll;
        public void loadEyeIcon(string i)
        {
            if (i != "New")
            {
                eyeIcon.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
            else
            {
                eyeIcon.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
        }
        public void visibilityOffOption()
        {
            btnOption.Visible = false;
        }
        public void invisible()
        {
            fromToIcon.Visible = false;
            lbToOfficer.Visible = false;
            eyeIcon.Visible = false;
            lbNoteIssueDate.Visible = false;

            btnSchedule.Visible = true;
        }

        [Category("Custom Props")]
        public string noteAttachment
        {
            get { return _noteIssueDate; }
            set { _noteIssueDate = value; 
                if (Convert.ToInt32(value) > 0) 
                {
                    btnNoteAttachment.Visible = true;
                    btnNoteAttachment.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); 
                } 
            }
        }
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
        public void notePriority(int priority)
        {
            if (priority == 1)
                lbNoteSubject.ForeColor = Color.FromArgb(246, 78, 96);
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
                    fromToIcon.Visible = false;
                    lbToOfficer.Visible = false;
                }
                else
                {
                    fromToIcon.Visible = true;
                    lbToOfficer.Visible = true;
                    lbToOfficer.Text = value;
                }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
            }
                
        }
        public event EventHandler NoteDetailsButton;
        public event EventHandler LocalNoteDetailsButton;
        private void NoteDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSchedule.Visible)
                {
                    NoteListDataRecordNoteDTO noteListDataRecordNoteDTO1 = new NoteListDataRecordNoteDTO();
                    noteListDataRecordNoteDTO1.extra_nothi_id = _nothi_id;
                    noteListDataRecordNoteDTO1.note_subject = lbNoteSubject.Text;
                    noteListDataRecordNoteDTO1.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
                    noteListDataRecordNoteDTO1.note_no = Convert.ToInt32(_note_no);
                    noteListDataRecordNoteDTO1.new_tab = 0; // new_tab ==0 means not new tab;

                    if (this.LocalNoteDetailsButton != null)
                        this.LocalNoteDetailsButton(noteListDataRecordNoteDTO1, e);
                }

                NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
                noteListDataRecordNoteDTO.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
                noteListDataRecordNoteDTO.note_no = Convert.ToInt32(_note_no);
                noteListDataRecordNoteDTO.new_tab = 0; // new_tab ==0 means not new tab;
                if (this.NoteDetailsButton != null)
                    this.NoteDetailsButton(noteListDataRecordNoteDTO, e);
            }
            catch (Exception ex)
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            

        }
        
        public event DatabaseChangeHandler btnOptionClickedPoint;
        public delegate void DatabaseChangeHandler(int x,int y);
        public event EventHandler btnOptionClick;
        ModalMenuUserControl uc = new ModalMenuUserControl();
        private void btnOption_Click(object sender, EventArgs e)
        {
           
            Point locationOnForm = GetPositionInForm(btnOption);
            locationOnForm.Y += btnOption.Height;
            object buttonCoOrdinates = locationOnForm;
            
            if (this.btnOptionClick != null)
            { 
                this.btnOptionClick(locationOnForm,e);
            }
            //if (this.btnOptionClickedPoint != null)
            //{
            //    this.btnOptionClickedPoint(locationOnForm.X, locationOnForm.Y);
            //}

        }
        public Point GetPositionInForm(Control ctrl)
        {
            Point p = ctrl.Location;
            Control parent = ctrl.Parent;
            if(isNothiAll)
            {
                while (!(parent is NothiAll))
                {
                    p.Offset(parent.Location.X, parent.Location.Y);

                    parent = parent.Parent;
                }
            }
            else
            {
                while (!(parent is NothiInbox))
                {
                    p.Offset(parent.Location.X, parent.Location.Y);

                    parent = parent.Parent;
                }
            }
           
           
            return p;
        }
        private void uc_noteEditButtonClick(object sender, EventArgs e)
        {

        }
        private void uc_noteOnumodanButtonClick(object sender, EventArgs e)
        {

        }
        private void uc_noteRemoveButtonClick(object sender, EventArgs e)
        {
            RemoveNote();
        }
        public void RemoveNote()
        {
            string message = "নোটটি মুছে ফেলুন";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            if (conditonBoxForm.Yes && lbNoteSubText.Text == "অনুচ্ছেদ দেওয়া হয়নি")
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                string model = "NothiNotes";
                string noteID = lbNoteId.Text;
                var noteDelete = _noteDelete.GetNoteDelteResponse(dakListUserParam, model, noteID);
                if (noteDelete.status == "success")
                {
                    UIDesignCommonMethod.SuccessMessage(noteDelete.status);
                    this.Hide();
                }

            }
            else
            {

            }
        }

        private void detailsButtonNewTab_Click(object sender, EventArgs e)
        {
            try
            {
                NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
                noteListDataRecordNoteDTO.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
                noteListDataRecordNoteDTO.note_no = Convert.ToInt32(_note_no);
                noteListDataRecordNoteDTO.new_tab = 1; // is new_tab ==1 means new tab;
                if (this.NoteDetailsButton != null)
                    this.NoteDetailsButton(noteListDataRecordNoteDTO, e);
            }
            catch (Exception ex)
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        public event EventHandler btnAttachment;
        private void btnNoteAttachment_Click(object sender, EventArgs e)
        {
            if (this.btnAttachment != null)
                this.btnAttachment(sender, e);
        }
    }
}
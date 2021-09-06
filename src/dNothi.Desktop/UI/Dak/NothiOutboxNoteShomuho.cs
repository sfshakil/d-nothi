using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Nothi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiOutboxNoteShomuho : UserControl
    {
        public NothiOutboxNoteShomuho()
        {
            InitializeComponent();
        }
        private string _noteNumber;
        private string _notesubject;
        private string _prapok;
        private string _currentDesk;
        private string _onucched;
        private string _khoshra;
        private string _potrojari;
        private string _nishponno;
        private string _noteIssueDate;
        private string _noteAttachment;
        private int _canRevert;
        private long _noteID;
        public long _nothi_id;

        public void not_permittedVisibilityOff()
        {
            pnlLeft.Visible = false;
            pnlRight.Visible = false;
            panel10.Visible = false;
            panel13.Visible = false;
            panel7.Padding = new Padding(pnlLeft.Width - panel15.Width, 0, pnlRight.Width, 0);
        }
        public void No_Note()
        {
            not_permittedVisibilityOff();
            lbsubject.Text = "কোন নোট পাওয়া যায়নি";
            lbsubject.Font = new Font("SolaimanLipi", 16f);
            lbsubject.ForeColor = Color.FromArgb(54, 153, 255);
            panel8.BackColor = Color.FromArgb(225, 240, 255);
            panel9.Visible = false;
        }
        [Category("Custom Props")]
        public long noteID
        {
            get { return _noteID; }
            set { _noteID = value; lbNoteId.Text = value.ToString(); }
        }
        public string noteNumber
        {
            get { return _noteNumber; }
            set { _noteNumber = value; lbNoteNumber.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string notesubject
        {
            get { return _notesubject; }
            set { _notesubject = value; lbsubject.Text = value; }
        }
        public void notePriority(int priority)
        {
            if (priority == 1)
                lbsubject.ForeColor = Color.FromArgb(246, 78, 96);
        }
        public string prapok
        {
            get { return _prapok; }
            set { _prapok = value; lbPrapok.Text = value; }
        }public string currentDesk
        {
            get { return _currentDesk; }
            set { _currentDesk = value; lbCurrentDesk.Text = value; }
        }public string onucched
        {
            get { return _onucched; }
            set { _onucched = value; lbOnucched.Text = "অনুচ্ছেদ: "+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string khoshra
        {
            get { return _khoshra; }
            set { _khoshra = value; lbKhoshra.Text = "খসড়া: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string potrojari
        {
            get { return _potrojari; }
            set { _potrojari = value; lbPotrojari.Text = "পত্রজারি: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string nishponno
        {
            get { return _nishponno; }
            set { _nishponno = value; lbNishponno.Text = "নিষ্পন্ন: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string noteIssueDate
        {
            get { return _noteIssueDate; }
            set { _noteIssueDate = value; lbNoteIssueDate.Text = value; }
        }public string noteAttachment
        {
            get { return _noteAttachment; }
            set { _noteAttachment = value;
                if (Convert.ToInt32(value) > 0)
                {
                    btnAttachment.Visible = true;
                    btnAttachment.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                } 
            }
        }public int canRevert
        {
            get { return _canRevert; }
            set { _canRevert = value;
                if (value == 0)
                { eyeIcon.IconChar = FontAwesome.Sharp.IconChar.Eye; btnCanRevert.Visible = false; }
                else
                { eyeIcon.IconChar = FontAwesome.Sharp.IconChar.EyeSlash; btnCanRevert.Visible = true; }
            }
        }
        public void invisible()
        {
            lbOnucched.Visible = false;
            lbKhoshra.Visible = false;
            lbPotrojari.Visible = false;
            lbNishponno.Visible = false;
            btnAttachment.Visible = false;
            eyeIcon.Visible = false;
            lbNoteIssueDate.Visible = false;

            btnSchedule.Visible = true;
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        public event EventHandler OutboxNoteDetailsButton;
        public event EventHandler LocalNoteDetailsButton;
        private void NoteDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSchedule.Visible)
                {
                    NoteListDataRecordNoteDTO noteListDataRecordNoteDTO1 = new NoteListDataRecordNoteDTO();
                    noteListDataRecordNoteDTO1.extra_nothi_id = _nothi_id;
                    noteListDataRecordNoteDTO1.note_subject = lbsubject.Text;
                    noteListDataRecordNoteDTO1.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
                    noteListDataRecordNoteDTO1.note_no = Convert.ToInt32(_noteNumber);
                    noteListDataRecordNoteDTO1.new_tab = 0; // is new_tab ==0 means not new tab;

                    if (this.LocalNoteDetailsButton != null)
                        this.LocalNoteDetailsButton(noteListDataRecordNoteDTO1, e);
                }
                NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
                noteListDataRecordNoteDTO.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
                noteListDataRecordNoteDTO.note_no = Convert.ToInt32(_noteNumber);
                noteListDataRecordNoteDTO.new_tab = 0; // is new_tab ==0 means not new tab;
                if (this.OutboxNoteDetailsButton != null)
                    this.OutboxNoteDetailsButton(noteListDataRecordNoteDTO, e);
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
        }

        private void nothiOutboxDetBtnNewTab_Click(object sender, EventArgs e)
        {
            try
            {
                NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
                noteListDataRecordNoteDTO.nothi_note_id = Convert.ToInt32(lbNoteId.Text);
                noteListDataRecordNoteDTO.note_no = Convert.ToInt32(_noteNumber);
                noteListDataRecordNoteDTO.new_tab = 1; // is new_tab ==1 means new tab;
                if (this.OutboxNoteDetailsButton != null)
                    this.OutboxNoteDetailsButton(noteListDataRecordNoteDTO, e);
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        public event EventHandler btnnoteAttachment;
        private void btnAttachment_Click(object sender, EventArgs e)
        {
            if (this.btnnoteAttachment != null)
                this.btnnoteAttachment(sender, e);
        }
        public event EventHandler btnnoteCanRevert;
        private void btnCanRevert_Click(object sender, EventArgs e)
        {
            if (this.btnnoteCanRevert != null)
                this.btnnoteCanRevert(sender, e);
        }
    }
}

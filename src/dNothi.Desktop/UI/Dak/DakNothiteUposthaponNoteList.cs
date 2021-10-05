using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Utility;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakNothiteUposthaponNoteList : UserControl
    {

        public int _can_revert { get; set; }
        public int can_revert
        {
            set
            {
                _can_revert = value;
                if (value == 1)
                {
                    nothiteUposthapitoButton.Visible = false;
                    eyeIcon.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                }
            }
            get
            {
                return _can_revert;
            }
        }
        public string _sub_subject_text { get; set; }
        public string sub_subject_text { 
            set {
                _sub_subject_text = value;
                if(!string.IsNullOrEmpty(value))
                {
                    subjectLabel.Text += "(" + value + ")";
                }
            }
            get
            {
                return _sub_subject_text;
            }
        }

        public DakNothiteUposthaponNoteList()
        {
            InitializeComponent();
        }

        public bool _NoDesk { get; set; }
        public bool NoDesk { get { return _NoDesk; } set { _NoDesk = value; if (value) { nothiteUposthapitoButton.Visible = false; } } }

        public void invisible()
        {
          rightArrowIcon.Visible = false;
          lbToOfficer.Visible = false;
          eyeIcon.Visible = false;
          dateLabel.Visible = false;

            btnSchedule.Visible = true;
        }

        private string _note_no;
        public string _note_ID;
        public string note_ID
        {
            get { return _note_ID; }
            set { _note_ID = value; }
        }
        public long _nothi_id;
        public long nothi_id
        {
            get { return _nothi_id; }
            set { _nothi_id = value; }
        }
        private string _note_subject;
        private string _deskofficer;
        private string _toofficer;
        private int _nothiAttachmentCount;
        private string _date;
        private int _nothivukto;
        private int _onucched;
        private int _onumodon;
        private int _potrojari;
        public NoteNothiDTO _nothiDTO;
   
       


        public NoteNothiDTO nothiDTO
        {
            get { return _nothiDTO; }
            set { _nothiDTO = value; }
        }
       


        [Category("Custom Props")]
        public string date
        {
            get { return _date; }
            set { _date = value; dateLabel.Text = value; }
        }
      

        [Category("Custom Props")]
        public int onumodon
        {
            get { return _onumodon; }
            set { _onumodon = value; onumodonLabel.Text = onumodonLabel.Text+string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
       
        [Category("Custom Props")]
        public int potrojari
        {
            get { return _potrojari; }
            set { _potrojari = value; potrojariLabel.Text = potrojariLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public int onucched
        {
            get { return _onucched; }
            set { _onucched = value; onucchedLabel.Text = onucchedLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public int nothivukto
        {
            get { return _nothivukto; }
            set { _nothivukto = value; nothivuktoLabel.Text = nothivuktoLabel.Text+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        [Category("Custom Props")]
        public int nothiAttachmentCount
        {
            get { return _nothiAttachmentCount; }
            set { _nothiAttachmentCount = value; nothiAttachmentButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        [Category("Custom Props")]
        public string note_no
        {
            get { return _note_no; }
            set { _note_no = value; noteNoLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string note_subject
        {
            get { return _note_subject; }
            set { _note_subject = value; subjectLabel.Text = value; }
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
            set { _toofficer = value; lbToOfficer.Text = value; }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        public bool _khoshra;
        public NothiListInboxNoteRecordsDTO _noteDto;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler NothiteUposthapitoButtonClick;
        private void nothiteUposthapitoButton_Click(object sender, EventArgs e)
        {

            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            if(_khoshra)
            {
                conditonBoxForm.message = "আপনি কি এই নোটের জন্য খসড়া করতে চান?";

            }
            else
            {
                conditonBoxForm.message = "আপনি কি এই নোটে ডাকটি উপস্থাপন করতে চান?";

            }
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                if (this.NothiteUposthapitoButtonClick != null)
                    this.NothiteUposthapitoButtonClick(sender, e);

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
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            //  successMessage.ShowDialog();
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();

        }
        public event EventHandler NoteDetailsButton;
        private void btnNoteDetailsNewTab_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
                noteListDataRecordNoteDTO.nothi_note_id = Convert.ToInt32(_note_ID);
                noteListDataRecordNoteDTO.note_no = Convert.ToInt32(_note_no);
                if (this.NoteDetailsButton != null)
                    this.NoteDetailsButton(noteListDataRecordNoteDTO, e);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
    }
}

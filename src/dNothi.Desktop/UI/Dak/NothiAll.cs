using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;
using dNothi.Utility;
using dNothi.Core.Entities;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiAll : UserControl
    {
        private int originalWidth;
        private int originalHeight;
        IUserService _userService { get; set; }
        //INothiInboxNoteServices _nothiInboxNote { get; set; }
        INothiAllNoteServices _nothiAllNote { get; set; }

        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO { get; set; }
        public NothiAll(IUserService userService, INothiAllNoteServices nothiAllNote)
        {
            _userService = userService;
            _nothiAllNote = nothiAllNote;
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            pnlNewAllNote.Visible = false;
            newAllNoteFlowLayoutPanel.Visible = false;
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
        private string _nothi;
        private string _shakha;
        private string _desk;
        private int _noteTotal;
        private int _permitted;
        public int _onishponno;
        public int _nishponno;
        public int _archived;
        public string _noteLastDate;
        public int _flag;
        private string _nothiId;

        [Category("Custom Props")]
        public string nothiId
        {
            get { return _nothiId; }
            set { _nothiId = value; lbNothiId.Text = value; }
        }

        [Category("Custom Props")]
        public string nothi
        {
            get { return _nothi; }
            set { _nothi = value; lbNothi.Text = value; }
        }


        [Category("Custom Props")]
        public string shakha
        {
            get { return _shakha; }
            set { _shakha = value; lbShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string desk
        {
            get { return _desk; }
            set
            {
                _desk = value; lbDesk.Text = "ডেস্ক: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
            }
        }
        //public int id
        //{
        //    get { return _id; }
        //    set { _id = value;}
        //}
        [Category("Custom Props")]
        public int noteTotal
        {
            get { return _noteTotal; }
            set { _noteTotal = value; 
                lbNoteTotal.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbNoteTotal1.Text = "সর্বমোট: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
            }
        }

        [Category("Custom Props")]
        public int permitted
        {
            get { return _permitted; }
            set { _permitted = value; lbPermitted.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
            
        }

        [Category("Custom Props")]
        public int onishponno
        {
            get { return _onishponno; }
            set { _onishponno = value; lbOnishponno.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public int nishponno
        {
            get { return _nishponno; }
            set { _nishponno = value; lbNishponno.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public int archived
        {
            get { return _archived; }
            set { _archived = value; lbArchived.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string noteLastDate
        {
            get { return _noteLastDate; }
            set { _noteLastDate = value; lbNoteLastDate.Text = value; }
        }
        [Category("Custom Props")]
        public int flag
        {
            get { return _flag; }
            set { _flag = value;
                if (value == 1)
                {
                    lbDesk.Visible = false; btnNote.Visible = false; btnOnumodito.Visible = false;
                    btnOnishponno.Visible = false; btnNishponno.Visible = false; btnArchive.Visible = false;
                    lbNoteLastDate.Visible = false; iconButton2.Visible = false; iconButton4.Visible = false;
                    iconButton5.Visible = false; iconButton6.Visible = false; iconButton7.Visible = false;
                    lbNoteTotal.Visible = false; lbPermitted.Visible = false; lbOnishponno.Visible = false;
                    lbNishponno.Visible = false; lbArchived.Visible = false;
                    nothiShompadonIcon.Visible = true;
                }
                if (value == 2)
                {
                    lbDesk.Visible = false; btnNote.Visible = false; btnOnumodito.Visible = false;
                    btnOnishponno.Visible = false; btnNishponno.Visible = false; btnArchive.Visible = false;
                    lbNoteLastDate.Visible = false; iconButton2.Visible = false; iconButton4.Visible = false;
                    iconButton5.Visible = false; iconButton6.Visible = false; iconButton7.Visible = false;
                    lbNoteTotal.Visible = false; lbPermitted.Visible = false; lbOnishponno.Visible = false;
                    lbNishponno.Visible = false; lbArchived.Visible = false;
                    nothiShompadonIcon.Visible = false; btnSchedule.Visible = true;
                }
            }
        }
        public void nothiPriority(int priority)
        {
            if (priority == 1)
                lbNothi.ForeColor = Color.FromArgb(246, 78, 96);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (btnNothiAllNoteShomuho.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                //int totalNote = Convert.ToInt32(totalnothi.Substring(9));
                int totalNote = Convert.ToInt32(_noteTotal);
                if (totalNote <= 0)
                {
                    totalNote = 1;
                }
                //int totalNote1 = Convert.ToInt32(_desk.Substring(_desk.IndexOf("ডেস্ক:") + 2));
                this.Height = totalNote * 100 + originalHeight;
                //this.Height = 100 + originalHeight;
                this.Width = originalWidth;
                pnlNewAllNote.Visible = true;
                newAllNoteFlowLayoutPanel.Visible = true;
                btnNothiAllNoteShomuho.IconChar = FontAwesome.Sharp.IconChar.Minus;
                btnNothiAllNoteShomuho.IconColor = Color.White;
                btnNothiAllNoteShomuho.BackColor = Color.FromArgb(27, 197, 189);
                loadnewAllNoteFlowLayoutPanel();
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                pnlNewAllNote.Visible = false;
                newAllNoteFlowLayoutPanel.Visible = false;

                btnNothiAllNoteShomuho.IconChar = FontAwesome.Sharp.IconChar.Plus;
                btnNothiAllNoteShomuho.IconColor = Color.White;
                btnNothiAllNoteShomuho.BackColor = Color.FromArgb(27, 197, 189);
            }
        }
        private void loadnewAllNoteFlowLayoutPanel()
        {
            var eachNothiId = lbNothiId.Text;
            var nothiListUserParam = _userService.GetLocalDakUserParam();
            string note_category = "all";
            
            if (!InternetConnection.Check())
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
                newAllNoteFlowLayoutPanel.AutoScroll = true;
                newAllNoteFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                newAllNoteFlowLayoutPanel.WrapContents = false;
                var nothiInboxNotUploadedNotes = _nothiAllNote.GetNotUploadedNoteFromLocal(nothiListUserParam, eachNothiId, note_category);
                if (nothiInboxNotUploadedNotes.Count > 0)
                {
                    _noteTotal = _noteTotal+ nothiInboxNotUploadedNotes.Count;
                    this.Height = _noteTotal * 100 + originalHeight;
                    _noteTotal = 0;
                    List <NothiNoteShomuho> nothiNoteShomuhos = new List<NothiNoteShomuho>();
                    foreach (NoteSaveItemAction nothiInboxNotUploadedNote in nothiInboxNotUploadedNotes)
                    {
                        //NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO = new NothiListInboxNoteRecordsDTO();
                        //nothiListInboxNoteRecordsDTO.note.note_subject = nothiInboxNotUploadedNote.noteSubject;

                        var nothiNoteShomuho = UserControlFactory.Create<NothiNoteShomuho>();
                        nothiNoteShomuho.note_subject = nothiInboxNotUploadedNote.noteSubject;
                        nothiNoteShomuho.deskofficer = nothiInboxNotUploadedNote.officer_name;
                        nothiNoteShomuho._nothi_id = nothiInboxNotUploadedNote.nothi_id;
                        nothiNoteShomuho.note_ID = nothiInboxNotUploadedNote.Id.ToString();
                        nothiNoteShomuho.note_no = nothiInboxNotUploadedNote.Id.ToString(); 
                        nothiNoteShomuho.LocalNoteDetailsButton += delegate (object sender1, EventArgs e1) {
                            
                        LocalNoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1); };
                        nothiNoteShomuho.invisible();

                        nothiNoteShomuhos.Add(nothiNoteShomuho);

                    }
                   

                    for (int j = 0; j <= nothiNoteShomuhos.Count - 1; j++)
                    {
                        newAllNoteFlowLayoutPanel.Controls.Add(nothiNoteShomuhos[j]);
                    }
                }
            }

            var nothiInboxNote = _nothiAllNote.GetNothiAllNote(nothiListUserParam, eachNothiId, note_category);

            if (nothiInboxNote.status == "success")
            {

                if (nothiInboxNote.data.records.Count > 0)
                {

                    LoadNothiNoteAllinPanel(nothiInboxNote.data.records);

                }
            }
        }
        public event EventHandler LocalNoteDetailsButton;
        private void LocalNoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO1, EventArgs e)
        {
            if (this.LocalNoteDetailsButton != null)
                this.LocalNoteDetailsButton(noteListDataRecordNoteDTO1, e);
        }

        NothiListInboxNoteRecordsDTO _noteListForNoteAll = new NothiListInboxNoteRecordsDTO();

        
        
        public event EventHandler NoteDetailsButton;

        private void NoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e1, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            _nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;
            if (this.NoteDetailsButton != null)
                this.NoteDetailsButton(noteListDataRecordNoteDTO, e1);
        }
        public event EventHandler NoteAllButton;
        private void NothiNoteAllButton_Click(object sender, EventArgs e)
        {
            if (this.NoteAllButton != null)
                this.NoteAllButton(_noteListForNoteAll, e);
        }
        public void LoadNothiNoteAllinPanel(List<NothiListInboxNoteRecordsDTO> nothiNoteInboxLists)
        {
            List<NothiNoteShomuho> nothiNoteShomuhos = new List<NothiNoteShomuho>();
            int i = 0;
            foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiNoteInboxLists)
            {
                var nothiNoteShomuho = UserControlFactory.Create<NothiNoteShomuho>();
                _noteListForNoteAll = nothiNoteInboxLists[0];

                nothiNoteShomuho.note_ID = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
                //nothiNoteShomuho.noteSubText = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                nothiNoteShomuho.note_no = Convert.ToString(nothiListInboxNoteRecordsDTO.note.note_no);
                nothiNoteShomuho.noteIssueDate = nothiListInboxNoteRecordsDTO.desk.issue_date;
                nothiNoteShomuho.loadEyeIcon(nothiListInboxNoteRecordsDTO.desk.note_current_status);
                nothiNoteShomuho.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1, nothiListInboxNoteRecordsDTO); };


                if (nothiListInboxNoteRecordsDTO.note.onucched_count > 0)
                {
                    nothiNoteShomuho.onucched = nothiListInboxNoteRecordsDTO.note.onucched_count.ToString();
                }
                if (nothiListInboxNoteRecordsDTO.note.khoshra_potro > 0)
                {
                    nothiNoteShomuho.khosra = nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString();
                }
                if (nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval > 0)
                {
                    nothiNoteShomuho.khoshraWaiting = nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval.ToString();
                }
                if (nothiListInboxNoteRecordsDTO.note.note_subject != null && nothiListInboxNoteRecordsDTO.note.note_subject_sub_text != "")
                {
                    nothiNoteShomuho.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject + " (" + nothiListInboxNoteRecordsDTO.note.note_subject_sub_text + ")";
                }
                else
                {
                    nothiNoteShomuho.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject;
                }
                if (nothiListInboxNoteRecordsDTO.to.officer != null)
                {
                    nothiNoteShomuho.deskofficer = nothiListInboxNoteRecordsDTO.to.officer;
                }
                else
                {
                    nothiNoteShomuho.deskofficer = " ";
                }
                if (nothiListInboxNoteRecordsDTO.desk.officer != null && nothiListInboxNoteRecordsDTO.desk.officer != nothiListInboxNoteRecordsDTO.to.officer)
                {
                    nothiNoteShomuho.toofficer = nothiListInboxNoteRecordsDTO.desk.officer;
                }
                else
                {
                    nothiNoteShomuho.toofficer = "";
                }
                i = i + 1;
                nothiNoteShomuhos.Add(nothiNoteShomuho);

            }
            if (InternetConnection.Check())
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
            }
            newAllNoteFlowLayoutPanel.AutoScroll = true;
            newAllNoteFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            newAllNoteFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiNoteShomuhos.Count - 1; j++)
            {
                newAllNoteFlowLayoutPanel.Controls.Add(nothiNoteShomuhos[j]);
            }

        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            btnNothiAllNoteShomuho.IconColor = Color.White;
            btnNothiAllNoteShomuho.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            if (btnNothiAllNoteShomuho.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                btnNothiAllNoteShomuho.IconColor = Color.FromArgb(27, 197, 189);
                btnNothiAllNoteShomuho.BackColor = Color.FromArgb(201, 247, 245);

            }
        }

        private void nothiShompadonIcon_MouseHover(object sender, EventArgs e)
        {
            //nothiShompadonIcon.IconColor = Color.Salmon;
        }

        private void nothiShompadonIcon_MouseLeave(object sender, EventArgs e)
        {
           // nothiShompadonIcon.IconColor = Color.FromArgb(54, 153, 255);
        }

        public NothiListAllRecordsDTO _nothiAllListDTO;

        public NothiListAllRecordsDTO nothiAllListDTO { get { return _nothiAllListDTO; } set { _nothiAllListDTO = value; } }

        public event EventHandler NothiAllOnumodonButtonClick;
        private void btnOnumodon_Click(object sender, EventArgs e)
        {
            if (this.NothiAllOnumodonButtonClick != null)
                this.NothiAllOnumodonButtonClick(sender, e);
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler NothiAllNewNoteButtonClick;
        private void btnNewNote_Click(object sender, EventArgs e)
        {
            sender= lbNothiId.Text;
            if (this.NothiAllNewNoteButtonClick != null)
                this.NothiAllNewNoteButtonClick(sender, e);
        }
        
    }
}

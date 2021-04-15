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
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;
using dNothi.Utility;
using dNothi.Core.Entities;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiOutbox : UserControl
    {
        private int originalWidth;
        private int originalHeight;

        IUserService _userService { get; set; }
        INothiInboxNoteServices _nothiInboxNote { get; set; }
        NothiListInboxNoteRecordsDTO _noteListForNoteAll = new NothiListInboxNoteRecordsDTO();
        public NothiOutbox(IUserService userService, INothiInboxNoteServices nothiInboxNote)
        {
            _userService = userService;
            _nothiInboxNote = nothiInboxNote;
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
        private string _prapok;
        private string _bortomanDesk;
        private string _lastdate;
        private int _nothiId;
        private int _noteTotal;

        [Category("Custom Props")]
        //public string noteTotal
        //{
        //    get { return _noteTotal; }
        //    set { _noteTotal = value;
        //        lbNoteTotal.Text = "সর্বমোট: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        //}
        public string nothi
        {
            get { return _nothi; }
            set { _nothi = value; lbNothi.Text = value; }
        }
        public int nothiId
        {
            get { return _nothiId; }
            set { _nothiId = value; lbNothiId.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public string shakha
        {
            get { return _shakha; }
            set { _shakha = value; lbShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string prapok
        {
            get { return _prapok; }
            set { _prapok = value; lblPrapok.Text = value; }
        }

        [Category("Custom Props")]
        public string bortomanDesk
        {
            get { return _bortomanDesk; }
            set { _bortomanDesk = value; lblPresentDesk.Text = value; }
        }

        [Category("Custom Props")]
        public string lastdate
        {
            get { return _lastdate; }
            set { _lastdate = value; lbLastNoteDate.Text = value; }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                loadnewAllNoteFlowLayoutPanel();
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                pnlNewAllNote.Visible = false;
                newAllNoteFlowLayoutPanel.Visible = false;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Plus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
            }
        }
        private void loadnewAllNoteFlowLayoutPanel()
        {
            var eachNothiId = lbNothiId.Text;
            var nothiListUserParam = _userService.GetLocalDakUserParam();
            string note_category = "sent";

            if (!InternetConnection.Check())
            {
                var nothiInboxNotUploadedNotes = _nothiInboxNote.GetNotUploadedNoteFromLocal(nothiListUserParam, eachNothiId, note_category);
                if (nothiInboxNotUploadedNotes.Count > 0)
                {
                    _noteTotal = _noteTotal + nothiInboxNotUploadedNotes.Count;
                    List<NothiOutboxNoteShomuho> nothiNoteShomuhos = new List<NothiOutboxNoteShomuho>();
                    foreach (NoteSaveItemAction nothiInboxNotUploadedNote in nothiInboxNotUploadedNotes)
                    {
                        var nothiNoteShomuho = UserControlFactory.Create<NothiOutboxNoteShomuho>();
                        nothiNoteShomuho.notesubject = nothiInboxNotUploadedNote.noteSubject;
                        nothiNoteShomuho.prapok = nothiInboxNotUploadedNote.officer_name + "," +
                                                  nothiInboxNotUploadedNote.office_designation_name + "," +
                                                  nothiInboxNotUploadedNote.office_unit_name + "," +
                                                  nothiInboxNotUploadedNote.office_name;
                        nothiNoteShomuho.currentDesk = nothiInboxNotUploadedNote.officer_name + "," +
                                                       nothiInboxNotUploadedNote.office_designation_name + "," +
                                                       nothiInboxNotUploadedNote.office_unit_name + "," +
                                                       nothiInboxNotUploadedNote.office_name;

                        nothiNoteShomuho.invisible();

                        nothiNoteShomuhos.Add(nothiNoteShomuho);

                    }
                    newAllNoteFlowLayoutPanel.Controls.Clear();
                    newAllNoteFlowLayoutPanel.AutoScroll = true;
                    newAllNoteFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                    newAllNoteFlowLayoutPanel.WrapContents = false;

                    for (int j = 0; j <= nothiNoteShomuhos.Count - 1; j++)
                    {
                        newAllNoteFlowLayoutPanel.Controls.Add(nothiNoteShomuhos[j]);
                    }
                }
            }

            var nothiInboxNote = _nothiInboxNote.GetNothiInboxNote(nothiListUserParam, eachNothiId, note_category);

            if (nothiInboxNote.status == "success")
            {
                if (nothiInboxNote.data.records.Count > 0)
                {
                    _noteTotal = nothiInboxNote.data.total_records;
                    lbNoteTotal.Text = "সর্বমোট: " + string.Concat(nothiInboxNote.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    int totalNote = _noteTotal;
                    //int totalNote = Convert.ToInt32(totalnothi.Substring(9));
                    if (nothiInboxNote.data.records.Count == 1)
                    {
                        this.Height = totalNote * 150 + originalHeight;
                    }
                    else
                    {
                        this.Height = totalNote * 130 + originalHeight;
                    }
                    
                    this.Width = originalWidth;
                    pnlNewAllNote.Visible = true;
                    newAllNoteFlowLayoutPanel.Visible = true;
                    iconButton3.IconChar = FontAwesome.Sharp.IconChar.Minus;
                    iconButton3.IconColor = Color.White;
                    iconButton3.BackColor = Color.FromArgb(27, 197, 189);
                    LoadNothiNoteAllinPanel(nothiInboxNote.data.records);

                }
            }
        }
        public void LoadNothiNoteAllinPanel(List<NothiListInboxNoteRecordsDTO> nothiNoteInboxLists)
        {
            List<NothiOutboxNoteShomuho> nothiNoteShomuhos = new List<NothiOutboxNoteShomuho>();
            int i = 0;
            foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiNoteInboxLists)
            {
                var nothiNoteShomuho = new NothiOutboxNoteShomuho();

                _noteListForNoteAll = nothiNoteInboxLists[0];
                
                nothiNoteShomuho.noteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
                nothiNoteShomuho.noteNumber = nothiListInboxNoteRecordsDTO.note.note_no.ToString();
                nothiNoteShomuho.notesubject = nothiListInboxNoteRecordsDTO.note.note_subject.ToString();
                nothiNoteShomuho.prapok = nothiListInboxNoteRecordsDTO.to.officer+","+
                                          nothiListInboxNoteRecordsDTO.to.designation + ","+
                                          nothiListInboxNoteRecordsDTO.to.office_unit + ","+
                                          nothiListInboxNoteRecordsDTO.to.office;
                nothiNoteShomuho.currentDesk = nothiListInboxNoteRecordsDTO.desk.officer + "," +
                                               nothiListInboxNoteRecordsDTO.desk.designation + "," +
                                               nothiListInboxNoteRecordsDTO.desk.office_unit + "," +
                                               nothiListInboxNoteRecordsDTO.desk.office + "; শাখা: " +
                                               nothiListInboxNoteRecordsDTO.nothi.office_unit+","+ 
                                               nothiListInboxNoteRecordsDTO.nothi.office + "; নথি নম্বর: " +
                                               nothiListInboxNoteRecordsDTO.nothi.nothi_no+ "; বিষয়: " +
                                               nothiListInboxNoteRecordsDTO.nothi.subject;

                nothiNoteShomuho.onucched = nothiListInboxNoteRecordsDTO.note.onucched_count.ToString();
                nothiNoteShomuho.khoshra = nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString();
                nothiNoteShomuho.potrojari = nothiListInboxNoteRecordsDTO.note.potrojari.ToString();

                nothiNoteShomuho.nishponno = nothiListInboxNoteRecordsDTO.note.approved_potro.ToString();

                nothiNoteShomuho.noteIssueDate = nothiListInboxNoteRecordsDTO.desk.issue_date;
                nothiNoteShomuho.canRevert = nothiListInboxNoteRecordsDTO.note.can_revert;

                nothiNoteShomuho.OutboxNoteDetailsButton += delegate (object sender1, EventArgs e1) { OutboxNoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1, nothiListInboxNoteRecordsDTO); };

                //nothiNoteShomuho.noteAttachment = nothiListInboxNoteRecordsDTO.note.note_subject.ToString();
                //nothiNoteShomuho.note_ID = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
                ////nothiNoteShomuho.noteSubText = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                //nothiNoteShomuho.note_no = Convert.ToString(nothiListInboxNoteRecordsDTO.note.note_no);
                //nothiNoteShomuho.noteIssueDate = nothiListInboxNoteRecordsDTO.desk.issue_date;
                //nothiNoteShomuho.loadEyeIcon(nothiListInboxNoteRecordsDTO.note.can_revert);
                ////nothiNoteShomuho.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1, nothiListInboxNoteRecordsDTO); };


                //if (nothiListInboxNoteRecordsDTO.note.onucched_count > 0)
                //{
                //    nothiNoteShomuho.onucched = nothiListInboxNoteRecordsDTO.note.onucched_count.ToString();
                //}
                //if (nothiListInboxNoteRecordsDTO.note.khoshra_potro > 0)
                //{
                //    nothiNoteShomuho.khosra = nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString();
                //}
                //if (nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval > 0)
                //{
                //    nothiNoteShomuho.khoshraWaiting = nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval.ToString();
                //}
                //if (nothiListInboxNoteRecordsDTO.note.note_subject != null && nothiListInboxNoteRecordsDTO.note.note_subject_sub_text != "")
                //{
                //    nothiNoteShomuho.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject + " (" + nothiListInboxNoteRecordsDTO.note.note_subject_sub_text + ")";
                //}
                //else
                //{
                //    nothiNoteShomuho.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject;
                //}
                //if (nothiListInboxNoteRecordsDTO.desk.officer != null)
                //{
                //    nothiNoteShomuho.deskofficer = nothiListInboxNoteRecordsDTO.desk.officer;
                //}
                //else
                //{
                //    nothiNoteShomuho.deskofficer = " ";
                //}
                //if (nothiListInboxNoteRecordsDTO.to.officer != null && nothiListInboxNoteRecordsDTO.desk.officer != nothiListInboxNoteRecordsDTO.to.officer)
                //{
                //    nothiNoteShomuho.toofficer = nothiListInboxNoteRecordsDTO.to.officer;
                //}
                //else
                //{
                //    nothiNoteShomuho.toofficer = "";
                //}
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
        public event EventHandler OutboxNoteDetailsButton;
        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO { get; set; }
        private void OutboxNoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e1, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            _nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;
            if (this.OutboxNoteDetailsButton != null)
                this.OutboxNoteDetailsButton(noteListDataRecordNoteDTO, e1);
        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
            iconButton3.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                iconButton3.IconColor = Color.FromArgb(27, 197, 189);
                iconButton3.BackColor = Color.FromArgb(201, 247, 245);

            }
        }
        public NothiOutboxListRecordsDTO _nothioutboxListRecordsDTO;

        public NothiOutboxListRecordsDTO nothiOutboxListRecordsDTO { get { return _nothioutboxListRecordsDTO; } set { _nothioutboxListRecordsDTO = value; } }

        public event EventHandler NothiOutboxOnumodonButtonClick;
        private void btnNothiOutboxOnumodon_Click(object sender, EventArgs e)
        {
            if (this.NothiOutboxOnumodonButtonClick != null)
                this.NothiOutboxOnumodonButtonClick(sender, e);
            //var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            //form.ShowDialog();
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler NewNoteButtonClick;

        private void dakSearchButton_Click(object sender, EventArgs e)
        {
            //var form = FormFactory.Create<CreateNewNotes>();
            //form.ShowDialog();
            if (this.NewNoteButtonClick != null)
                this.NewNoteButtonClick(sender, e);
        }

        public event EventHandler NoteAllButton;
        private void btnAllNote_Click(object sender, EventArgs e)
        {
            if (this.NoteAllButton != null)
                this.NoteAllButton(_noteListForNoteAll, e);
        }
    }
}

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
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiOutbox : UserControl
    {
        private int originalWidth;
        private int originalHeight;

        IUserService _userService { get; set; }
        INothiInboxNoteServices _nothiInboxNote { get; set; }
        //INothiInboxNoteServices _nothiInboxNote { get; set; }
        INothiOutboxNoteServices _nothiOutboxNote { get; set; }
        NothiListInboxNoteRecordsDTO _noteListForNoteAll = new NothiListInboxNoteRecordsDTO();
        INoteOnucchedRevertServices _noteOnucchedRevert { get; set; }
        public NothiOutbox(IUserService userService, INothiOutboxNoteServices nothiOutboxNote, INothiInboxNoteServices nothiInboxNote, INoteOnucchedRevertServices noteOnucchedRevert)
        {
            _userService = userService;
            _nothiOutboxNote = nothiOutboxNote;
            _nothiInboxNote = nothiInboxNote;
            _noteOnucchedRevert = noteOnucchedRevert;
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
        private string _office;
        private string _nothi_office;
        private int _nothiId;
        private int _noteTotal;
        public bool _isOtherOffice;
        public void visibilityOnNothiOutboxOfficePanel()
        {
            pnlOffice.Visible = true;
            dakSearchButton.Visible = false;
        }
        [Category("Custom Props")]
        //public string noteTotal
        //{
        //    get { return _noteTotal; }
        //    set { _noteTotal = value;
        //        lbNoteTotal.Text = "সর্বমোট: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        //}
        public string office
        {
            get { return _office; }
            set { _office = value; lbOffice.Text = value; }
        }
        public string nothi_office
        {
            get { return _nothi_office; }
            set { _nothi_office = value;  }
        }
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
        public void nothiPriority(int priority)
        {
            if (priority == 1)
                lbNothi.ForeColor = Color.FromArgb(246, 78, 96);
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.FolderPlus)
            {
                btnNoteOrder.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
                
                if (_isOtherOffice == true)
                {
                    loadotherOfficeNoteFlowLayoutPanel("asc");
                }
                else
                {
                    loadnewAllNoteFlowLayoutPanel("asc");
                }
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                pnlNewAllNote.Visible = false;
                newAllNoteFlowLayoutPanel.Visible = false;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
            }
        }
        private void loadotherOfficeNoteFlowLayoutPanel(string note_order)
        {
            btnNoteOrder.Location = new Point(newAllNoteFlowLayoutPanel.Width / 2, 0);
            var eachNothiId = lbNothiId.Text;
            var nothiListUserParam = _userService.GetLocalDakUserParam();
            string note_category = "other_office_sent";
            
            var nothiInboxNote = _nothiOutboxNote.GetOtherOfficeNothiOutboxNote(nothiListUserParam, eachNothiId, note_category, note_order, nothi_office);

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
                        this.Height = totalNote * 190 + originalHeight;
                    }
                    else
                    {
                        this.Height = totalNote * 170 + originalHeight;
                    }

                    this.Width = originalWidth;
                    pnlNewAllNote.Visible = true;
                    newAllNoteFlowLayoutPanel.Visible = true;
                    iconButton3.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
                    iconButton3.IconColor = Color.White;
                    iconButton3.BackColor = Color.FromArgb(27, 197, 189);
                    LoadOtherOfficeNothiNoteAllinPanel(nothiInboxNote.data.records);

                }
            }
        }
        public void LoadOtherOfficeNothiNoteAllinPanel(List<NothiListInboxNoteRecordsDTO> nothiNoteInboxLists)
        {
            newAllNoteFlowLayoutPanel.Controls.Clear();
            foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiNoteInboxLists)
            {
                var nothiNoteShomuho = new NothiOutboxNoteShomuho();

                if (nothiListInboxNoteRecordsDTO.note.note_status != "not_permitted")
                {
                    _noteListForNoteAll = nothiNoteInboxLists[0];

                    nothiNoteShomuho.noteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
                    nothiNoteShomuho.noteNumber = nothiListInboxNoteRecordsDTO.note.note_no.ToString();
                    nothiNoteShomuho.notesubject = nothiListInboxNoteRecordsDTO.note.note_subject.ToString();
                    nothiNoteShomuho.prapok = nothiListInboxNoteRecordsDTO.to.officer + "," +
                                              nothiListInboxNoteRecordsDTO.to.designation + "," +
                                              nothiListInboxNoteRecordsDTO.to.office_unit + "," +
                                              nothiListInboxNoteRecordsDTO.to.office;
                    nothiNoteShomuho.currentDesk = nothiListInboxNoteRecordsDTO.desk.officer + "," +
                                                   nothiListInboxNoteRecordsDTO.desk.designation + "," +
                                                   nothiListInboxNoteRecordsDTO.desk.office_unit + "," +
                                                   nothiListInboxNoteRecordsDTO.desk.office + "; শাখা: " +
                                                   nothiListInboxNoteRecordsDTO.nothi.office_unit_name + "," +
                                                   nothiListInboxNoteRecordsDTO.nothi.office_name + "; নথি নম্বর: " +
                                                   nothiListInboxNoteRecordsDTO.nothi.nothi_no + "; বিষয়: " +
                                                   nothiListInboxNoteRecordsDTO.nothi.subject;

                    nothiNoteShomuho.onucched = nothiListInboxNoteRecordsDTO.note.onucched_count.ToString();
                    nothiNoteShomuho.khoshra = nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString();
                    nothiNoteShomuho.potrojari = nothiListInboxNoteRecordsDTO.note.potrojari.ToString();

                    nothiNoteShomuho.nishponno = nothiListInboxNoteRecordsDTO.note.approved_potro.ToString();

                    nothiNoteShomuho.noteIssueDate = nothiListInboxNoteRecordsDTO.desk.issue_date;
                    nothiNoteShomuho.canRevert = 0;//nothiListInboxNoteRecordsDTO.note.can_revert;
                    nothiNoteShomuho.notePriority(nothiListInboxNoteRecordsDTO.desk.priority);
                    nothiNoteShomuho.noteAttachment = nothiListInboxNoteRecordsDTO.note.attachment_count.ToString();
                    nothiNoteShomuho.btnnoteAttachment += delegate (object sender1, EventArgs e1) { NoteAttachment_ButtonClick(nothiListInboxNoteRecordsDTO, e1); };
                    nothiNoteShomuho.OutboxNoteDetailsButton += delegate (object sender1, EventArgs e1) { OutboxNoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1, nothiListInboxNoteRecordsDTO); };
                }
                else
                {
                    nothiNoteShomuho.noteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
                    nothiNoteShomuho.noteNumber = nothiListInboxNoteRecordsDTO.note.note_no.ToString();
                    nothiNoteShomuho.notesubject = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                    nothiNoteShomuho.not_permittedVisibilityOff();
                }

                UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);

            }
        }
        private void loadnewAllNoteFlowLayoutPanel(string note_order)
        {
            btnNoteOrder.Location = new Point(newAllNoteFlowLayoutPanel.Width / 2, 0);
            var eachNothiId = lbNothiId.Text;
            var nothiListUserParam = _userService.GetLocalDakUserParam();
            string note_category = "sent";

            if (!InternetConnection.Check())
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
                var nothiInboxNotUploadedNotes = _nothiOutboxNote.GetNotUploadedNoteFromLocal(nothiListUserParam, eachNothiId, note_category);
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
                        
                        
                        
                        
                        
                        
                        nothiNoteShomuho._nothi_id = nothiInboxNotUploadedNote.nothi_id;
                        nothiNoteShomuho.noteID = nothiInboxNotUploadedNote.Id;
                        nothiNoteShomuho.noteNumber = nothiInboxNotUploadedNote.Id.ToString();
                        nothiNoteShomuho.LocalNoteDetailsButton += delegate (object sender1, EventArgs e1) {

                            LocalNoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1);
                        };





                        nothiNoteShomuho.invisible();

                        UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);

                    }
                    //newAllNoteFlowLayoutPanel.Controls.Clear();
                    //newAllNoteFlowLayoutPanel.AutoScroll = true;
                    //newAllNoteFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                    //newAllNoteFlowLayoutPanel.WrapContents = false;

                    //for (int j = 0; j <= nothiNoteShomuhos.Count - 1; j++)
                    //{
                    //    newAllNoteFlowLayoutPanel.Controls.Add(nothiNoteShomuhos[j]);
                    //}
                }
            }


            var nothiInboxNote = _nothiOutboxNote.GetNothiOutboxNote(nothiListUserParam, eachNothiId, note_category, note_order, nothi_office);

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
                        this.Height = totalNote * 190 + originalHeight;
                    }
                    else
                    {
                        this.Height = totalNote * 170 + originalHeight;
                    }
                    
                    this.Width = originalWidth;
                    pnlNewAllNote.Visible = true;
                    newAllNoteFlowLayoutPanel.Visible = true;
                    iconButton3.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
                    iconButton3.IconColor = Color.White;
                    iconButton3.BackColor = Color.FromArgb(27, 197, 189);
                    LoadNothiNoteAllinPanel(nothiInboxNote.data.records);

                }
                else
                {
                    _noteTotal = nothiInboxNote.data.total_records;
                    lbNoteTotal.Text = "সর্বমোট: " + string.Concat(nothiInboxNote.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    int totalNote = _noteTotal;
                    this.Height =  170 + originalHeight;
                    this.Width = originalWidth;
                    pnlNewAllNote.Visible = true;
                    newAllNoteFlowLayoutPanel.Visible = true;
                    iconButton3.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
                    iconButton3.IconColor = Color.White;
                    iconButton3.BackColor = Color.FromArgb(27, 197, 189);
                    newAllNoteFlowLayoutPanel.Controls.Clear();
                    //_noteListForNoteAll = nothiNoteInboxLists[0];
                    var nothiNoteShomuho = new NothiOutboxNoteShomuho();

                    nothiNoteShomuho.No_Note();


                    UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);

                    

                }
            }
        }
        public event EventHandler LocalNoteDetailsButton;
        private void LocalNoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO1, EventArgs e)
        {
            if (this.LocalNoteDetailsButton != null)
                this.LocalNoteDetailsButton(noteListDataRecordNoteDTO1, e);
        }
        public void LoadNothiNoteAllinPanel(List<NothiListInboxNoteRecordsDTO> nothiNoteInboxLists)
        {
            List<NothiOutboxNoteShomuho> nothiNoteShomuhos = new List<NothiOutboxNoteShomuho>();

            if (InternetConnection.Check())
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
            }
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
                nothiNoteShomuho.notePriority(nothiListInboxNoteRecordsDTO.desk.priority); 
                nothiNoteShomuho.noteAttachment = nothiListInboxNoteRecordsDTO.note.attachment_count.ToString();
                nothiNoteShomuho.btnnoteAttachment  += delegate (object sender1, EventArgs e1) { NoteAttachment_ButtonClick(nothiListInboxNoteRecordsDTO, e1); };
                nothiNoteShomuho.btnnoteCanRevert += delegate (object sender1, EventArgs e1) { NoteCanRevert_ButtonClick(nothiListInboxNoteRecordsDTO, e1); };

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
                UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);

            }
            

            //for (int j = 0; j <= nothiNoteShomuhos.Count - 1; j++)
            //{
            //    newAllNoteFlowLayoutPanel.Controls.Add(nothiNoteShomuhos[j]);
            //}

        }
        public event EventHandler OutboxNoteDetailsButton;
        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO { get; set; }
        private void OutboxNoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e1, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            _nothiListInboxNoteRecordsDTO= nothiListInboxNoteRecordsDTO;

            if (this.OutboxNoteDetailsButton != null)
                this.OutboxNoteDetailsButton(noteListDataRecordNoteDTO, e1);
        }
        private void NoteAttachment_ButtonClick(NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, EventArgs e1)
        {
            if (InternetConnection.Check())
            {
                var nothiListUserParam = _userService.GetLocalDakUserParam();
                var nothiInboxNote = _nothiInboxNote.GetNoteAttachments(nothiListUserParam, nothiListInboxNoteRecordsDTO.nothi.id.ToString(), nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString());

                var nothiDecisionList = UserControlFactory.Create<NothiDecisionList>();
                nothiDecisionList.labelText = "নোটের সংযুক্তি";
                nothiDecisionList.loadNoteRowAttachments(nothiInboxNote, 1);
                //nothiDecisionList.OnuchhedAdd += delegate (object sender1, EventArgs e1) { OnuchhedAdd_Click(sender1 as string, e1); };
                var form = NothiNextStepControlToForm(nothiDecisionList);

                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        public event EventHandler OutboxNoteRevertButton;
        private void NoteCanRevert_ButtonClick(NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, EventArgs e1)
        {
            if (InternetConnection.Check())
            {
                NoteSaveDTO newnotedata = new NoteSaveDTO();
                NothiListRecordsDTO nothiListRecords = new NothiListRecordsDTO();

                var nothiListUserParam = _userService.GetLocalDakUserParam();
                newnotedata.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject;
                newnotedata.note_id = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
                nothiListRecords.subject = nothiListInboxNoteRecordsDTO.nothi.subject;
                nothiListRecords.id = nothiListInboxNoteRecordsDTO.nothi.id;
                nothiListRecords.office_name = nothiListInboxNoteRecordsDTO.nothi.office_name;

                NoteOnucchedRevertResPonse noteOnucchedRevert = _noteOnucchedRevert.GetNoteOnucchedRevert(nothiListUserParam, nothiListRecords, newnotedata);
                if (noteOnucchedRevert.status == "success")
                {
                    SuccessMessage(noteOnucchedRevert.data);
                    if (this.OutboxNoteRevertButton != null)
                        this.OutboxNoteRevertButton(nothiListInboxNoteRecordsDTO as object, e1);
                    

                }
                else
                {
                    ErrorMessage(noteOnucchedRevert.message);
                }
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
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
            successMessage.ShowDialog();

        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();

            Screen scr = Screen.FromPoint(this.Location);
            hideform.BackColor = Color.Black;
            hideform.Size = scr.WorkingArea.Size;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
        public Form NothiNextStepControlToForm(Control control)
        {
            Form form = new Form();
            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.AutoSize = true;
            form.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - control.Width, 0);
            control.Location = new System.Drawing.Point(0, 0);
            //form.Size = control.Size;
            form.Height = Screen.PrimaryScreen.WorkingArea.Height;
            form.Width = control.Width;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Height = form.Height;
            form.Controls.Add(control);
            return form;
        }
        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
            iconButton3.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.FolderPlus)
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
            if (this.NoteAllButton != null && _noteListForNoteAll.desk != null && _noteListForNoteAll.note != null && _noteListForNoteAll.nothi != null && _noteListForNoteAll.to != null)
                this.NoteAllButton(_noteListForNoteAll, e);
        }

        private void btnRefreshNote_Click(object sender, EventArgs e)
        {
            newAllNoteFlowLayoutPanel.Controls.Clear();
            loadnewAllNoteFlowLayoutPanel("asc");
        }

        private void btnNoteOrder_Click(object sender, EventArgs e)
        {
            if (btnNoteOrder.IconChar == FontAwesome.Sharp.IconChar.ChevronDown)
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
                btnNoteOrder.IconChar = FontAwesome.Sharp.IconChar.ChevronUp;
                loadnewAllNoteFlowLayoutPanel("desc");
            }
            else
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
                btnNoteOrder.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
                loadnewAllNoteFlowLayoutPanel("asc");
            }
        }
    }
}

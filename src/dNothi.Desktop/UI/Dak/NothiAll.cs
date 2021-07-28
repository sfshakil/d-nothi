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
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Services.DakServices;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiAll : UserControl
    {
        ModalMenuUserControl uc = new ModalMenuUserControl();
        private int originalWidth;
        private int originalHeight;
        IUserService _userService { get; set; }
        INoteDeleteService _noteDelete { get; set; }
        INothiInboxNoteServices _nothiInboxNote { get; set; }
        //INothiInboxNoteServices _nothiInboxNote { get; set; }
        INothiAllNoteServices _nothiAllNote { get; set; }

        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO { get; set; }
        public NothiAll(IUserService userService, INothiAllNoteServices nothiAllNote, INothiInboxNoteServices nothiInboxNote, INoteDeleteService noteDelete)
        {
            _userService = userService;
            _nothiAllNote = nothiAllNote;
            _nothiInboxNote = nothiInboxNote;
            _noteDelete = noteDelete;
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            pnlNewAllNote.Visible = false;
            uc.Visible = false;
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
                    btnNothiEdit.Visible = true;
                }
                if (value == 2)
                {
                    lbDesk.Visible = false; btnNote.Visible = false; btnOnumodito.Visible = false;
                    btnOnishponno.Visible = false; btnNishponno.Visible = false; btnArchive.Visible = false;
                    lbNoteLastDate.Visible = false; iconButton2.Visible = false; iconButton4.Visible = false;
                    iconButton5.Visible = false; iconButton6.Visible = false; iconButton7.Visible = false;
                    lbNoteTotal.Visible = false; lbPermitted.Visible = false; lbOnishponno.Visible = false;
                    lbNishponno.Visible = false; lbArchived.Visible = false;
                    btnNothiEdit.Visible = false; btnSchedule.Visible = true;
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
            if (btnNothiAllNoteShomuho.IconChar == FontAwesome.Sharp.IconChar.FolderPlus)
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
                btnNothiAllNoteShomuho.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
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

                btnNothiAllNoteShomuho.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
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

                        UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);

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
        private void btnOption_ButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            //if (!isActive)
            ////  uc.Location = System.Windows.Forms.Cursor.Position;
            //{
           
            if (uc.Visible != true)
            {
                bool remove = true;
                if (nothiListInboxNoteRecordsDTO.note.onucched_count > 0)
                { remove = false; }
                uc.ButtonVisibility(true, remove, true);
                //uc.Location = new Point(50, ((Point)sender).Y);
                uc.Location = new Point(50, this.Location.Y);
                // uc.Location = new Point(50,this.Location.Y);//((Point)sender).X, ((Point)sender).Y);
                uc.noteEditButtonClick += delegate (object s1, EventArgs e1) { uc_noteEditButtonClick(s1, e1, nothiListInboxNoteRecordsDTO); };
                uc.noteOnumodanButtonClick += delegate (object s2, EventArgs e2) { uc_noteOnumodanButtonClick(s2, e2, nothiListInboxNoteRecordsDTO); };
                uc.noteRemoveButtonClick += delegate (object s3, EventArgs e3) { uc_noteRemoveButtonClick(s3, e3, nothiListInboxNoteRecordsDTO); };

                this.Controls.Add(uc);
                uc.BringToFront();
                uc.Visible = true;
            }
            else
            {
                uc.Visible = false;
            }

            //    isActive = true;
            //}
            //else
            //    uc.Visible = false;
            //    isActive = false;
        }

        private void uc_noteOnumodanButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f.Name != "Note")
            //    { BeginInvoke((Action)(() => f.Hide())); }
            //}
            NoteView newNoteView = new NoteView();

            var nothiListRecord = MappingModels.MapModel<NothiNothiListInboxNoteRecordsDTO, NothiListRecordsDTO>(nothiListInboxNoteRecordsDTO.nothi);
            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiListRecord;

            // form.noteIdfromNothiInboxNoteShomuho = nothiListInboxNoteRecordsDTO.note.;

            form.nothiNo = nothiListInboxNoteRecordsDTO.nothi.nothi_no;
            form.nothiShakha = nothiListInboxNoteRecordsDTO.nothi.office;
            form.nothiSubject = nothiListInboxNoteRecordsDTO.nothi.subject;
            form.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            form.nothiLastDate = nothiListInboxNoteRecordsDTO.nothi.nothi_created_date;
            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;

            form.office = nothiListInboxNoteRecordsDTO.nothi.office;


            form.loadNothiInboxRecords(nothiListRecord);
            form.loadNoteView(newNoteView);
            form.noteTotal = ConversionMethod.EnglishNumberToBangla(nothiListInboxNoteRecordsDTO.note.finished_count.ToString());

            form.GetNothiInboxRecords(nothiListRecord, "Note", nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString());
            var notelist = MappingModels.MapModel<NoteNothiListInboxNoteRecordsDTO, NoteListDataRecordNoteDTO>(nothiListInboxNoteRecordsDTO.note);
            //form.loadNewNoteDataFromNote(nothiType);
            form.loadNoteList(notelist);
            CalPopUpWindow(form);
        }
        private void uc_noteRemoveButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {

            string message = "নোটটি মুছে ফেলুন";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            if (conditonBoxForm.Yes && nothiListInboxNoteRecordsDTO.note.onucched_count == 0)
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                string model = "NothiNotes";
                string noteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
                var noteDelete = _noteDelete.GetNoteDelteResponse(dakListUserParam, model, noteID);
                if (noteDelete.status == "success")
                {
                    SuccessMessage(noteDelete.status);
                    this.Hide();
                }

            }
            else
            {

            }
        }
        private void uc_noteEditButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            var noteCreatePopUpForm = FormFactory.Create<NoteCreatePopUpForm>();

            noteCreatePopUpForm.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            noteCreatePopUpForm.noteId = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
            noteCreatePopUpForm.nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;
            noteCreatePopUpForm.SaveButtonClick += delegate (object senderSaveButton, EventArgs eventSaveButton) {
                loadnewAllNoteFlowLayoutPanel();
            };


            CalPopUpWindow(noteCreatePopUpForm);

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
            if (InternetConnection.Check())
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
            }
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
                nothiNoteShomuho.noteAttachment = nothiListInboxNoteRecordsDTO.note.attachment_count.ToString();
                nothiNoteShomuho.btnAttachment += delegate (object sender1, EventArgs e1) { NoteAttachment_ButtonClick(nothiListInboxNoteRecordsDTO, e1); };
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
                nothiNoteShomuho.btnOptionClick += delegate (object sender1, EventArgs e1)
                {

                    btnOption_ButtonClick(sender1 as object, e1, nothiListInboxNoteRecordsDTO);
                };
                i = i + 1;
                UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);

            }
            
            

        }
        private void NoteAttachment_ButtonClick(NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, EventArgs e1)
        {
            if (InternetConnection.Check())
            {
                var nothiListUserParam = _userService.GetLocalDakUserParam();
                var nothiInboxNote = _nothiInboxNote.GetNoteAttachments(nothiListUserParam, nothiListInboxNoteRecordsDTO.nothi.id.ToString(), nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString());

                var nothiDecisionList = UserControlFactory.Create<NothiDecisionList>();
                nothiDecisionList.labelText = "নোটের সংযুক্তি";
                nothiDecisionList.loadNoteRowAttachments(nothiInboxNote);
                //nothiDecisionList.OnuchhedAdd += delegate (object sender1, EventArgs e1) { OnuchhedAdd_Click(sender1 as string, e1); };
                var form = NothiNextStepControlToForm(nothiDecisionList);

                CalPopUpWindow(form);
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
            btnNothiAllNoteShomuho.IconColor = Color.White;
            btnNothiAllNoteShomuho.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            if (btnNothiAllNoteShomuho.IconChar == FontAwesome.Sharp.IconChar.FolderPlus)
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
        public event EventHandler NothiAllEditButtonClick;
        private void btnNewNote_Click(object sender, EventArgs e)
        {
            sender= lbNothiId.Text;
            if (this.NothiAllNewNoteButtonClick != null)
                this.NothiAllNewNoteButtonClick(sender, e);
        }

        private void btnNothiEdit_Click(object sender, EventArgs e)
        {
            if (this.NothiAllEditButtonClick != null)
                this.NothiAllEditButtonClick(sender, e);
        }
    }
}

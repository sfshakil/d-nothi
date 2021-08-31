using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Utility;
using dNothi.Services.DakServices;
using dNothi.Core.Entities;
using dNothi.Desktop.UI.CustomMessageBox;
using Xamarin.Forms.Xaml;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiInbox : UserControl
    {
        ModalMenuUserControl uc = null;
        IUserService _userService { get; set; }
        INothiInboxNoteServices _nothiInboxNote { get; set; }
        INoteDeleteService _noteDelete { get; set; }

        int x;
        int y;
        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO { get; set; }
        NothiListInboxNoteRecordsDTO _noteListForNoteAll = new NothiListInboxNoteRecordsDTO();



        private int originalWidth;
        private int originalHeight;
        public NothiInbox(IUserService userService, INothiInboxNoteServices nothiInboxNote, INoteDeleteService noteDelete)
        {
            _userService = userService;
           
            _nothiInboxNote = nothiInboxNote;
            _noteDelete = noteDelete;
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            pnlNewAllNote.Visible = false;
            newAllNoteFlowLayoutPanel.Visible = false;
            //uc.Visible = false;
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
        private string _nothiId;
        private string _shakha;
        private string _totalnothi;
        private string _lastdate;
        
       
        public NothiListRecordsDTO _nothiListRecordsDTO;
        
        public NothiListRecordsDTO nothiListRecordsDTO { get { return _nothiListRecordsDTO; } set { _nothiListRecordsDTO = value; } }




        [Category("Custom Props")]
        public string nothi
        {
            get { return _nothi; }
            set { _nothi = value; lbNothi.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiId
        {
            get { return _nothiId; }
            set { _nothiId = value; lbNothiId.Text = value; }
        }

        [Category("Custom Props")]
        public string shakha
        {
            get { return _shakha; }
            set { _shakha = value; lbShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string totalnothi
        {
            get { return _totalnothi; }
            set { _totalnothi = value; lbTotalNothi.Text = "মোট নোটঃ " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); lbTotalNote.Text = "মোট নোটঃ " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) ; }//"মোট নোটঃ " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string lastdate
        {
            get { return _lastdate; }
            set { _lastdate = value; lbNoteLastDate.Text = value; }
        }
        public void nothiPriority(int priority)
        {
            if (priority == 1)
                lbNothi.ForeColor = Color.FromArgb(246, 78, 96);
        }
        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.FolderPlus)
            {
                int totalNote = Convert.ToInt32(totalnothi);
                this.Height = totalNote * 100 + originalHeight;
                this.Width = originalWidth;
                pnlNewAllNote.Visible = true;
                newAllNoteFlowLayoutPanel.Visible = true;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
                loadnewAllNoteFlowLayoutPanel();
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
        private void loadnewAllNoteFlowLayoutPanel()
        {
            
            var eachNothiId = lbNothiId.Text;
            var nothiListUserParam = _userService.GetLocalDakUserParam();
            string note_category = "Inbox";
            
            if (!InternetConnection.Check())
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
                
                var nothiInboxNotUploadedNotes = _nothiInboxNote.GetNotUploadedNoteFromLocal(nothiListUserParam, eachNothiId, note_category);
                if(nothiInboxNotUploadedNotes.Count > 0)
                {
                    _totalnothi = _totalnothi + nothiInboxNotUploadedNotes.Count;
                    List<NothiNoteShomuho> nothiNoteShomuhos = new List<NothiNoteShomuho>();
                    foreach (NoteSaveItemAction nothiInboxNotUploadedNote in nothiInboxNotUploadedNotes)
                    {
                        var nothiNoteShomuho = UserControlFactory.Create<NothiNoteShomuho>();
                        nothiNoteShomuho.note_subject = nothiInboxNotUploadedNote.noteSubject;
                        nothiNoteShomuho.deskofficer = nothiInboxNotUploadedNote.officer_name;
                        
                        nothiNoteShomuho._nothi_id = nothiInboxNotUploadedNote.nothi_id;
                        nothiNoteShomuho.note_ID = nothiInboxNotUploadedNote.Id.ToString();
                        nothiNoteShomuho.note_no = nothiInboxNotUploadedNote.Id.ToString();
                        nothiNoteShomuho.LocalNoteDetailsButton += delegate (object sender1, EventArgs e1) {

                            LocalNoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1);
                        };
                      //  nothiNoteShomuho.btnOptionClickedPoint += nothiNoteShomuho_btnOptionClickedPoint;
                        nothiNoteShomuho.invisible();
                       
                        UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);
                    }
                    
                }
            }
            var nothiInboxNote = _nothiInboxNote.GetNothiInboxNote(nothiListUserParam, eachNothiId, note_category);

            if (nothiInboxNote.status == "success")
            {

                if (nothiInboxNote.data.records.Count > 0)
                {
                    LoadNothiNoteInboxinPanel(nothiInboxNote.data.records);
                }
            }
        }

        public event EventHandler LocalNoteDetailsButton;
        bool isActive = false;
      
        
        private void btnOption_ButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, int rowCount)
        {
          
            if (uc==null)
            {
                uc = new ModalMenuUserControl();
                bool remove = true;
                if (nothiListInboxNoteRecordsDTO.note.onucched_count > 0)
                { remove = false; }
                uc.ButtonVisibility(true, remove, true);
                uc.Location = new Point(((Point)sender).X, ((Point)sender).Y+10+rowCount*6);
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
                uc=null;
            }
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

            noteCreatePopUpForm.noteSubject= nothiListInboxNoteRecordsDTO.note.note_subject;
            noteCreatePopUpForm.noteId = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
            noteCreatePopUpForm.nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;
            noteCreatePopUpForm.SaveButtonClick += delegate (object senderSaveButton, EventArgs eventSaveButton) {
                SaveorUpdate(); 
            };


            CalPopUpWindow(noteCreatePopUpForm);

        }
        public void SaveorUpdate()
        {
            loadnewAllNoteFlowLayoutPanel();
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
      
        private void LocalNoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO1, EventArgs e)
        {
            if (this.LocalNoteDetailsButton != null)
                this.LocalNoteDetailsButton(noteListDataRecordNoteDTO1, e);
        }
        public void LoadNothiNoteInboxinPanel(List<NothiListInboxNoteRecordsDTO> nothiNoteInboxLists)
        {
            List<NothiNoteShomuho> nothiNoteShomuhos = new List<NothiNoteShomuho>();
            int i = 0;
            if (InternetConnection.Check())
            {
                newAllNoteFlowLayoutPanel.Controls.Clear();
            }
            foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiNoteInboxLists)
            {
                var nothiNoteShomuho = UserControlFactory.Create<NothiNoteShomuho>();

                _noteListForNoteAll = nothiNoteInboxLists[0];
                
                nothiNoteShomuho.note_ID = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
                nothiNoteShomuho.noteSubText = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                nothiNoteShomuho.note_no = Convert.ToString(nothiListInboxNoteRecordsDTO.note.note_no);
                nothiNoteShomuho.noteIssueDate = nothiListInboxNoteRecordsDTO.desk.issue_date;
                nothiNoteShomuho.onucched_count = nothiListInboxNoteRecordsDTO.note.onucched_count;

                nothiNoteShomuho.noteAttachment = nothiListInboxNoteRecordsDTO.note.attachment_count.ToString();
                nothiNoteShomuho.btnAttachment  += delegate (object sender1, EventArgs e1) { NoteAttachment_ButtonClick(nothiListInboxNoteRecordsDTO, e1); };
                nothiNoteShomuho.loadEyeIcon(nothiListInboxNoteRecordsDTO.desk.note_current_status);
                nothiNoteShomuho.notePriority(nothiListInboxNoteRecordsDTO.desk.priority);
                nothiNoteShomuho.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1, nothiListInboxNoteRecordsDTO); };

                
                if (nothiListInboxNoteRecordsDTO.note.onucched_count>0)
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
                    nothiNoteShomuho.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject + " (" + nothiListInboxNoteRecordsDTO.note.note_subject_sub_text+")";
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
                nothiNoteShomuho.isNothiAll = false;
                int rowCount = newAllNoteFlowLayoutPanel.Controls.Count;
                nothiNoteShomuho.btnOptionClick += delegate (object sender1, EventArgs e1)
                {
                   
                    btnOption_ButtonClick(sender1 as object, e1, nothiListInboxNoteRecordsDTO, rowCount);
                };
                //nothiNoteShomuho.btnOptionClickedPoint += nothiNoteShomuho_btnOptionClickedPoint;
                i = i + 1;
                UIDesignCommonMethod.AddRowinTable(newAllNoteFlowLayoutPanel, nothiNoteShomuho);

            }
            

        }
        public event EventHandler NoteDetailsButton;
        
        private void NoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e1, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            _nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;
            if (this.NoteDetailsButton != null)
                this.NoteDetailsButton(noteListDataRecordNoteDTO, e1);
        }
        public event EventHandler NoteAttachment;
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
        public event EventHandler NoteAllButton;
        private void btnAllNote_Click(object sender, EventArgs e)
        {
            if (this.NoteAllButton != null)
                this.NoteAllButton(_noteListForNoteAll, e);
        }

        private void iconButton3_MouseHover_1(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
            iconButton3.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave_1(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.FolderPlus)
            {
                iconButton3.IconColor = Color.FromArgb(27, 197, 189);
                iconButton3.BackColor = Color.FromArgb(201, 247, 245);

            }
        }
        public event EventHandler NothiOnumodonButtonClick;
        private void btnNothiInboxOnumodon_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Nothi")
                { openForms.Add(f); }
            }
            

            foreach (Form f in openForms)
            {
                if (f.Name != "Nothi")
                { f.Close(); f.Hide(); }
            }

            if (this.NothiOnumodonButtonClick != null)
                this.NothiOnumodonButtonClick(sender, e);
            
            
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

        //public event EventHandler NoteEditButtonClick;


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler NewNoteButtonClick;

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            //var form = FormFactory.Create<CreateNewNotes>();
            //form.ShowDialog();
            if (this.NewNoteButtonClick != null)
                this.NewNoteButtonClick(sender, e);

        }

        
    }
}

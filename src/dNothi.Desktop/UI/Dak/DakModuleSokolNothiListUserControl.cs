using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Utility;
using dNothi.Core.Entities;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakModuleSokolNothiListUserControl : UserControl
    {
        INothiInboxNoteServices _nothiInboxNote { get; set; }
        private int originalWidth;
        private int originalHeight;
        INoteSaveService _noteSave { get; set; }
        public int _dak_id;
        public string _dak_type;
        public int _is_copied_dak;
        public NoteNothiDTO _nothiDTO;
        public NothiListInboxNoteRecordsDTO _nothiListInboxRecordDTO;
        public NothiAllDTO _nothiAllDTO;

        public string dak_type
        {
            get { return _dak_type; }
            set { _dak_type = value; }
        }
        public int dak_id
        {
            get { return _dak_id; }
            set { _dak_id = value; }
        }

        public int is_copied_dak
        {
            get { return _is_copied_dak; }
            set { _is_copied_dak = value; }
        }

        IUserService _userService { get; set; }
        IDakNothivuktoService _nothivuktoService { get; set; }
        INothiNoteTalikaServices _nothinotetalikaservices { get; set; }
        public DakModuleSokolNothiListUserControl(INoteSaveService noteSave,INothiInboxNoteServices nothiInboxNote,IDakNothivuktoService dakNothivuktoService, IUserService userService, INothiNoteTalikaServices nothiNoteTalikaServices)
        {
            _nothiInboxNote = nothiInboxNote;
            _noteSave = noteSave;
            InitializeComponent();
            _userService = userService;
            _nothivuktoService = dakNothivuktoService;
            _nothinotetalikaservices = nothiNoteTalikaServices;
            originalWidth = this.Width;
            originalHeight = this.Height;


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
        public string _id;
        public string _masterid;




        public string nothi_id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string master_id
        {
            get { return _masterid; }
            set { _masterid = value; }
        }

        public NothiListAllRecordsDTO _nothiListAllRecordsDTO;
        public NothiListAllRecordsDTO nothiListAllRecordsDTO
        {
            get { return _nothiListAllRecordsDTO; }
            set { _nothiListAllRecordsDTO = value;  }
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
            set { _desk = value; lbDesk.Text = value; }
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
            set { _noteTotal = value; lbNoteTotal.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public int permitted
        {
            get { return _permitted; }
            set { _permitted = value; lbPermitted.Text = value.ToString(); }
        }
        public bool NothiteUposthapitoButtonVisible { get { return true; } set { if (value) addButton.Visible = true; } }
        public bool NothijatoButtonVisible { get { return true; } set { if (value) { nothijatoButton.Visible = true; addButton.Visible = false; } } }


        [Category("Custom Props")]
        public int onishponno
        {
            get { return _onishponno; }
            set { _onishponno = value; lbOnishponno.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public int nishponno
        {
            get { return _nishponno; }
            set { _nishponno = value; lbNishponno.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public int archived
        {
            get { return _archived; }
            set { _archived = value; lbArchived.Text = value.ToString(); }
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
            set
            {
                _flag = value;
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
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            addButton.IconColor = Color.White;
            addButton.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            if (addButton.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                addButton.IconColor = Color.FromArgb(27, 197, 189);
                addButton.BackColor = Color.FromArgb(201, 247, 245);

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (addButton.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                LoadNote();

                NoteListPanel.Visible = true;
                addButton.IconChar = FontAwesome.Sharp.IconChar.Minus;
                addButton.IconColor = Color.White;
                addButton.BackColor = Color.FromArgb(27, 197, 189);
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                NoteListPanel.Visible = false;

                addButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
                addButton.IconColor = Color.White;
                addButton.BackColor = Color.FromArgb(27, 197, 189);
            }
        }

        private void LoadNote()
        {
            newAllNoteFlowLayoutPanel.Controls.Clear();
            if (!InternetConnection.Check())
            {
                var nothiInboxNotUploadedNotes = _nothiInboxNote.GetNotUploadedNoteFromLocal(_userService.GetLocalDakUserParam(), _id, "All");
                if (nothiInboxNotUploadedNotes.Count > 0)
                {
                    _noteTotal = _noteTotal + nothiInboxNotUploadedNotes.Count;
                    this.Height = _noteTotal * 100 + originalHeight;
                    _noteTotal = 0;
                    List<DakNothiteUposthaponNoteList> nothiNoteShomuhos = new List<DakNothiteUposthaponNoteList>();
                    foreach (NoteSaveItemAction nothiInboxNotUploadedNote in nothiInboxNotUploadedNotes)
                    {
                        //NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO = new NothiListInboxNoteRecordsDTO();
                        //nothiListInboxNoteRecordsDTO.note.note_subject = nothiInboxNotUploadedNote.noteSubject;
                        NoteNothiDTO noteNothiDTO = new NoteNothiDTO();
                        DakNothiteUposthaponNoteList nothiNoteShomuho = new DakNothiteUposthaponNoteList();
                        nothiNoteShomuho.note_subject = nothiInboxNotUploadedNote.noteSubject;
                        nothiNoteShomuho.deskofficer = nothiInboxNotUploadedNote.officer_name;
                        nothiNoteShomuho.nothi_id = nothiInboxNotUploadedNote.nothi_id;
                        nothiNoteShomuho.note_ID = nothiInboxNotUploadedNote.Id.ToString();
                        nothiNoteShomuho.note_no = nothiInboxNotUploadedNote.Id.ToString();
                      
                       
                        noteNothiDTO.note_subject = nothiInboxNotUploadedNote.noteSubject;
                        noteNothiDTO.note_id = nothiInboxNotUploadedNote.Id.ToString();
                        noteNothiDTO._isOffline = true;
                        noteNothiDTO.extra_nothi_id= nothiInboxNotUploadedNote.nothi_id;
                        noteNothiDTO.note_no= nothiInboxNotUploadedNote.Id.ToString();

                        nothiNoteShomuho.nothiDTO = noteNothiDTO;
                        //nothiNoteShomuho.LocalNoteDetailsButton += delegate (object sender1, EventArgs e1) {

                        //   LocalNoteDetails_ButtonClick(sender1 as NoteListDataRecordNoteDTO, e1);
                        // };
                        nothiNoteShomuho.invisible();
                        
                            nothiNoteShomuho._khoshra = _khoshra;
                        NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO=null;

                        nothiNoteShomuho.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, nothiNoteShomuho._nothiDTO, nothiListInboxNoteRecordsDTO); };

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


            var nothiInboxNote = _nothiInboxNote.GetNothiInboxNote(_userService.GetLocalDakUserParam(), _id, "All");

          //  NothiNoteListResponse noteAll = new NothiNoteListResponse();
           
           
            
          //  noteAll = _nothinotetalikaservices.GetNothiNoteListAll(_userService.GetLocalDakUserParam(), Convert.ToInt32(_id));
           
            
            if (nothiInboxNote != null && nothiInboxNote.status == "success")
            {
                if (nothiInboxNote.data.records.Count > 0)
                {
                    LoadNoteAllinPanel(nothiInboxNote.data.records);
                }

            }
        }

        private void LoadNoteAllinPanel(List<NothiListInboxNoteRecordsDTO> records)
        {
            List<DakNothiteUposthaponNoteList> dakNothiteUposthaponNoteLists = new List<DakNothiteUposthaponNoteList>();
            int i = 0;
            foreach (NothiListInboxNoteRecordsDTO noteDTO in records)
            {
                DakNothiteUposthaponNoteList dakNothiteUposthaponNoteList = new DakNothiteUposthaponNoteList();

                if (noteDTO.desk != null)
                {
                    dakNothiteUposthaponNoteList.date = noteDTO.desk.issue_date;
                    dakNothiteUposthaponNoteList.deskofficer = noteDTO.desk.officer;
                }
                else
                {
                    dakNothiteUposthaponNoteList.NoDesk = true;
                }
                dakNothiteUposthaponNoteList._noteDto = noteDTO;
                dakNothiteUposthaponNoteList.note_no = Convert.ToString(noteDTO.note.note_no);
                dakNothiteUposthaponNoteList.note_subject = noteDTO.note.note_subject;

                //dakNothiteUposthaponNoteList.toofficer = noteDTO.deskConverted.;
                dakNothiteUposthaponNoteList.potrojari = noteDTO.note.potrojari;
                dakNothiteUposthaponNoteList.onumodon = noteDTO.note.finished_count;
                dakNothiteUposthaponNoteList.nothiAttachmentCount = noteDTO.note.attachment_count;
                // dakNothiteUposthaponNoteList.toofficer = noteDTO;
                dakNothiteUposthaponNoteList.onucched = noteDTO.note.onucched_count;
                dakNothiteUposthaponNoteList.nothivukto = noteDTO.note.nothivukto_potro;
                
                NoteNothiDTO noteNothiDTO = new NoteNothiDTO();

                if (noteDTO.nothi != null)
                {
                    //  noteDTO.nothi = new NoteNothiDTO();
                    noteNothiDTO.archived_date = noteDTO.nothi.archived_date;
                    noteNothiDTO.archived_designation_name = noteDTO.nothi.archived_designation_name;
                    noteNothiDTO.archived_organogram_id = noteDTO.nothi.archived_organogram_id;
                    noteNothiDTO.created = noteDTO.nothi.created;
                    noteNothiDTO.created_by = noteDTO.nothi.created_by;
                    noteNothiDTO.description = noteDTO.nothi.description;
                    noteNothiDTO.id = noteDTO.nothi.id;
                    noteNothiDTO.is_active = noteDTO.nothi.is_active;
                    noteNothiDTO.is_archived = noteDTO.nothi.is_archived;
                    noteNothiDTO.is_deleted = noteDTO.nothi.is_deleted;
                    noteNothiDTO.modified = noteDTO.nothi.modified;
                    noteNothiDTO.modified_by = noteDTO.nothi.modified_by;
                    noteNothiDTO.nothi_class = noteDTO.nothi.nothi_class;
                    noteNothiDTO.nothi_created_date = noteDTO.nothi.nothi_created_date;
                    noteNothiDTO.nothi_no = noteDTO.nothi.nothi_no;
                    noteNothiDTO.nothi_type_id = noteDTO.nothi.nothi_type_id;
                    noteNothiDTO.office = noteDTO.nothi.office;
                    noteNothiDTO.office_designation_name = noteDTO.nothi.office_designation_name;
                    noteNothiDTO.office_id = noteDTO.nothi.office_id;
                    noteNothiDTO.office_name = noteDTO.nothi.office_name;
                    noteNothiDTO.office_unit = noteDTO.nothi.office_unit;
                    noteNothiDTO.office_unit_id = noteDTO.nothi.office_unit_id;
                    noteNothiDTO.office_unit_name = noteDTO.nothi.office_unit_name;
                    noteNothiDTO.office_unit_organogram_id = noteDTO.nothi.office_unit_organogram_id;
                    noteNothiDTO.subject = noteDTO.nothi.subject;

                }
              

              
                noteNothiDTO.note_no = Convert.ToString(noteDTO.note.note_no);
                noteNothiDTO.note_subject = noteDTO.note.note_subject;
                noteNothiDTO.note_id = Convert.ToString(noteDTO.note.nothi_note_id);




                dakNothiteUposthaponNoteList.nothiDTO = noteNothiDTO;
                dakNothiteUposthaponNoteList.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakNothiteUposthaponNoteList._nothiDTO, dakNothiteUposthaponNoteList._noteDto); };
                dakNothiteUposthaponNoteList.NoteDetailsButton += delegate (object sender, EventArgs e) { NoteDetails_ButtonClick(sender, e, dakNothiteUposthaponNoteList._nothiDTO, dakNothiteUposthaponNoteList._noteDto); };
                dakNothiteUposthaponNoteList._khoshra = _khoshra;
                dakNothiteUposthaponNoteLists.Add(dakNothiteUposthaponNoteList);
            }
          

            for (int j = 0; j <= dakNothiteUposthaponNoteLists.Count - 1; j++)
            {
                newAllNoteFlowLayoutPanel.Controls.Add(dakNothiteUposthaponNoteLists[j]);
            }
        }

        public event EventHandler NoteDetailsButton;

        private void NoteDetails_ButtonClick(object sender, EventArgs e, NoteNothiDTO nothiDTO, NothiListInboxNoteRecordsDTO _noteDto)
        {
            _nothiDTO = nothiDTO;
            _nothiListInboxRecordDTO = _noteDto;
            if (this.NoteDetailsButton != null)
                this.NoteDetailsButton(sender, e);
        }

        public event EventHandler NothiteUposthaponButton;
        public bool _khoshra;
      
        
        private void NothiteUposthapito_ButtonClick(object sender, EventArgs e, NoteNothiDTO nothiDTO, NothiListInboxNoteRecordsDTO _noteDto)
        {
            _nothiDTO = nothiDTO;
            _nothiListInboxRecordDTO = _noteDto;

            if (this.NothiteUposthaponButton != null)
                this.NothiteUposthaponButton(sender, e);

        }

        private void newNothiAddButton_Click(object sender, EventArgs e)
        {
            var newNoteAddForm = FormFactory.Create<DakNothiteUposthapitoNewNoteAddUserControl>();
            newNoteAddForm.SaveNoteButtonClick += delegate (object addSender, EventArgs addEvent) { SaveNote_ButtonClick(newNoteAddForm._noteSubject); };


            newNoteAddForm.ShowDialog();
            
        }

        private void SaveNote_ButtonClick(string noteSubject)
        {

            
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
           
            nothiListRecordsDTO.id = Convert.ToInt32(_nothiListAllRecordsDTO.nothi.id);
            nothiListRecordsDTO.office_id = _nothiListAllRecordsDTO.nothi.office_id;
            nothiListRecordsDTO.office_name = _nothiListAllRecordsDTO.nothi.office_unit_name;
            nothiListRecordsDTO.office_unit_id = _nothiListAllRecordsDTO.nothi.office_unit_id;
            nothiListRecordsDTO.office_unit_name = _nothiListAllRecordsDTO.nothi.office_unit_name;
            nothiListRecordsDTO.office_unit_organogram_id = _nothiListAllRecordsDTO.nothi.office_unit_organogram_id;
            nothiListRecordsDTO.office_designation_name = _nothiListAllRecordsDTO.nothi.office_designation_name;
            nothiListRecordsDTO.nothi_no = _nothiListAllRecordsDTO.nothi.nothi_no;
            nothiListRecordsDTO.subject = _nothiListAllRecordsDTO.nothi.subject;
            nothiListRecordsDTO.nothi_class = _nothiListAllRecordsDTO.nothi.nothi_class;
            nothiListRecordsDTO.last_note_date = _nothiListAllRecordsDTO.nothi.last_note_date;

            nothiListRecordsDTO.nothi_type = "all";
             var noteSave = _noteSave.GetNoteSave(dakListUserParam, nothiListRecordsDTO, noteSubject);
            
                if (noteSave.status == "success" && noteSave.message == "Local")
                {
                UIDesignCommonMethod.SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে এই নোটটি আপলোড করা হবে");
                   LoadNote();
                }

                else if(noteSave.status == "success")
                  
                 {
                
                UIDesignCommonMethod.SuccessMessage("নোটটি আপলোড সফল হয়েছে");

                LoadNote();
               
                 }
           
            else
            {
                UIDesignCommonMethod.ErrorMessage("নোটটি আপলোড সফল হইনি");
            }

            
            



           
            
        }
        public event EventHandler NothijatoButton;
        private void nothijatoButton_Click(object sender, EventArgs e)
        {


            if (this.NothijatoButton != null)
                this.NothijatoButton(sender, e);
        }
    }
}

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
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakModuleAgotoNothiList : UserControl
    {
        INothiInboxNoteServices _nothiInboxNote { get; set; }
        private int originalWidth;
        private int originalHeight;

        public int _dak_id;
        public string _dak_type;
        public int _is_copied_dak;
        public NoteNothiDTO _nothiDTO;
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


        private string _nothi;
        private string _nothiId;
        private string _shakha;
        private string _totalnothi;
        private string _lastdate;

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
            set { _totalnothi = value; lbTotalNothi.Text = value; }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        //lbTotalNote.Text = value; 
        [Category("Custom Props")]
        public string lastdate
        {
            get { return _lastdate; }
            set { _lastdate = value; lbNoteLastDate.Text = value; }
        }



        IUserService _userService { get; set; }
        IDakNothivuktoService _nothivuktoService { get; set; }
        INothiNoteTalikaServices _nothinotetalikaservices { get; set; }
        public DakModuleAgotoNothiList(INothiInboxNoteServices nothiInboxNote, IDakNothivuktoService dakNothivuktoService, IUserService userService, INothiNoteTalikaServices nothiNoteTalikaServices)
        {

            InitializeComponent();
            _nothiInboxNote = nothiInboxNote;
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



        private void newNothiAddButton_Click(object sender, EventArgs e)
        {
            var newNoteAddForm = FormFactory.Create<DakNothiteUposthapitoNewNoteAddUserControl>();
            newNoteAddForm.SaveNoteButtonClick += delegate (object addSender, EventArgs addEvent) { SaveNote_ButtonClick(newNoteAddForm._noteSubject); };


            newNoteAddForm.ShowDialog();
        }
        public bool NothiteUposthapitoButtonVisible { get { return true; } set { if (value) addButton.Visible = true; } }
        public bool NothijatoButtonVisible { get { return true; } set { if (value) { nothijatoButton.Visible = true; addButton.Visible = false; } } }

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
            var noteAll = _nothinotetalikaservices.GetNothiNoteListAll(_userService.GetLocalDakUserParam(), Convert.ToInt32(_id));
            var nothiInboxNote = _nothiInboxNote.GetNothiInboxNote(_userService.GetLocalDakUserParam(), _id, "all");

            if (noteAll.status == "success")
            {
                if (noteAll.data.records.Count > 0)
                {
                    LoadNoteAllinPanel(noteAll.data.records);
                }

            }
        }

        private void LoadNoteAllinPanel(List<NothiNoteListRecordDTO> records)
        {
            List<DakNothiteUposthaponNoteList> dakNothiteUposthaponNoteLists = new List<DakNothiteUposthaponNoteList>();
            int i = 0;
            foreach (NothiNoteListRecordDTO noteDTO in records)
            {
                DakNothiteUposthaponNoteList dakNothiteUposthaponNoteList = new DakNothiteUposthaponNoteList();

                if (noteDTO.deskConverted != null)
                {
                    dakNothiteUposthaponNoteList.date = noteDTO.deskConverted.issue_date;
                    dakNothiteUposthaponNoteList.deskofficer = noteDTO.deskConverted.officer;
                }

                dakNothiteUposthaponNoteList.note_no = Convert.ToString(noteDTO.note.note_no);
                dakNothiteUposthaponNoteList.note_subject = noteDTO.note.note_subject;

                //dakNothiteUposthaponNoteList.toofficer = noteDTO.deskConverted.;
                dakNothiteUposthaponNoteList.potrojari = noteDTO.note.potrojari;
                dakNothiteUposthaponNoteList.onumodon = noteDTO.note.finished_count;
                dakNothiteUposthaponNoteList.nothiAttachmentCount = noteDTO.note.attachment_count;
                // dakNothiteUposthaponNoteList.toofficer = noteDTO;
                dakNothiteUposthaponNoteList.onucched = noteDTO.note.onucched_count;
                dakNothiteUposthaponNoteList.nothivukto = noteDTO.note.nothivukto_potro;

                if (noteDTO.nothi == null)
                {
                    noteDTO.nothi = new NoteNothiDTO();
                }
                noteDTO.nothi.note_no = Convert.ToString(noteDTO.note.note_no);
                noteDTO.nothi.note_subject = noteDTO.note.note_subject;
                noteDTO.nothi.note_id = Convert.ToString(noteDTO.note.nothi_note_id);

                dakNothiteUposthaponNoteList.nothiDTO = noteDTO.nothi;
                dakNothiteUposthaponNoteList.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakNothiteUposthaponNoteList._nothiDTO); };


                dakNothiteUposthaponNoteLists.Add(dakNothiteUposthaponNoteList);
            }
            newAllNoteFlowLayoutPanel.Controls.Clear();

            for (int j = 0; j <= dakNothiteUposthaponNoteLists.Count - 1; j++)
            {
                newAllNoteFlowLayoutPanel.Controls.Add(dakNothiteUposthaponNoteLists[j]);
            }
        }

        public event EventHandler NothiteUposthaponButton;


        private void NothiteUposthapito_ButtonClick(object sender, EventArgs e, NoteNothiDTO nothiDTO)
        {
            _nothiDTO = nothiDTO;




            if (this.NothiteUposthaponButton != null)
                this.NothiteUposthaponButton(sender, e);

        }


        private void SaveNote_ButtonClick(string noteSubject)
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            DakNothivuktoNoteAddParam dakNothivuktoNoteAddParam = new DakNothivuktoNoteAddParam();
            dakNothivuktoNoteAddParam.note_subject = noteSubject;
            dakNothivuktoNoteAddParam.nothi_master_id = Convert.ToInt32(_masterid);
            dakNothivuktoNoteAddParam.officer_name = dakUserParam.officer_name;
            dakNothivuktoNoteAddParam.office_designation_name = dakUserParam.designation;
            dakNothivuktoNoteAddParam.office_id = dakUserParam.office_id;
            dakNothivuktoNoteAddParam.office_name = dakUserParam.office_label;
            dakNothivuktoNoteAddParam.office_unit_name = dakUserParam.office_unit;


            GetNothivuktoNoteAddResponse getNothivuktoNoteAddResponse = _nothivuktoService.GetNothivuktoNoteAddResponse(dakUserParam, dakNothivuktoNoteAddParam);

            if (getNothivuktoNoteAddResponse.status == "success")
            {
                LoadNote();
            }
            else
            {

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

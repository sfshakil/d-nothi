using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
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
    public partial class DakNothiteUposthapitoForm : Form
    {
        IUserService _userService { get; set; }
        INothiAllServices _nothiAll { get; set; }
        IDakNothivuktoService _nothivuktoService { get; set; }


        public bool _dakNothiteUposthapitoLocally;
        public string _dakSubject { get; set; }
        public NoteNothiDTO _noteSelected { get; set; }

        INothiNoteTalikaServices _nothinotetalikaservices { get; set; }

        public DakUserParam _userParam = new DakUserParam();
        public bool _khosra;

        public void Khoshra()
        {
            nothiteUposthaponLabel.Visible = true;
            dakSubjectLabel.Visible = true;
            _khosra = true;
        }

        public DakNothiteUposthapitoForm(IDakNothivuktoService dakNothivuktoService, IUserService userService, INothiAllServices nothiAll, INothiNoteTalikaServices nothiNoteTalikaServices)
        {
            _nothiAll = nothiAll;
            _nothivuktoService = dakNothivuktoService;
            _userService = userService;
            _nothinotetalikaservices = nothiNoteTalikaServices;
            _userParam = _userService.GetLocalDakUserParam();
            
            InitializeComponent();
            LoadNothiAll();
        }


        public int _dak_id;
        public string _dak_type;
        public string _nothiName;
        public string _nothiBranch;
        public int _is_copied_dak;

        public string dak_type
        {
            get { return _dak_type; }
            set { _dak_type = value; }
        }
        public int dakid
        {
            get { return _dak_id; }
            set { _dak_id = value; }
        }

        public int is_copied_dak
        {
            get { return _is_copied_dak; }
            set { _is_copied_dak = value; }
        }

        public string dakSubject { get { return _dakSubject; } set { _dakSubject = value; dakSubjectLabel.Text = value; } }

        private void LoadNothiAll()
        {

            _userParam.page = 1;
            _userParam.limit = 10;


            var nothiAll = _nothiAll.GetNothiAll(_userParam);

            if (nothiAll.status == "success")
            {
                if (nothiAll.data.records.Count > 0)
                {
                    LoadNothiAllinPanel(nothiAll.data.records);
                }

            }
        }
        private void LoadNothiAllinPanel(List<NothiListAllRecordsDTO> nothiAllLists)
        {
            nothiListFlowLayoutPanel.Controls.Clear();
            List<DakModuleSokolNothiListUserControl> nothiAlls = new List<DakModuleSokolNothiListUserControl>();
            int i = 0;
            foreach (NothiListAllRecordsDTO nothiAllListDTO in nothiAllLists)
            {
                var nothiAll = UserControlFactory.Create<DakModuleSokolNothiListUserControl>();
                nothiAll.nothiListAllRecordsDTO = nothiAllListDTO;
                if (nothiAllListDTO.desk != null)
                {
                   
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.desk = "ডেস্ক: " + nothiAllListDTO.desk.note_count.ToString();

                    nothiAll.noteLastDate = "নোটের সর্বশেষ তারিখঃ " + nothiAllListDTO.nothi.last_note_date;
                    nothiAll.master_id = nothiAllListDTO.desk.nothi_master_id.ToString();


                    i = i + 1;

                }
                else
                {

                    //NothiAll nothiAll = new NothiAll();
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;


                }
                if (nothiAllListDTO.status != null)
                {
                    nothiAll.noteTotal = nothiAllListDTO.status.total;
                    nothiAll.permitted = nothiAllListDTO.status.permitted;
                    nothiAll.onishponno = nothiAllListDTO.status.onishponno;
                    nothiAll.nishponno = nothiAllListDTO.status.nishponno;
                    nothiAll.archived = nothiAllListDTO.status.archived;
                    // nothiAll.master_id = nothiAllListDTO.status.nothi_master_id.ToString();

                }
                else
                {
                    nothiAll.flag = 1;
                }
                nothiAll.NothiteUposthaponButton += delegate (object addSender, EventArgs addEvent) { NothiteUposthapito_ButtonClick(addSender, addEvent, nothiAll._nothiDTO, nothiAll.nothi, nothiAllListDTO.nothi.office_unit_name, nothiAllListDTO,nothiAll._nothiListInboxRecordDTO); };
                nothiAll.NoteDetailsButton += delegate (object addSender, EventArgs addEvent) { NoteDetails_ButtonClick(addSender, addEvent, nothiAll._nothiDTO, nothiAll.nothi, nothiAllListDTO.nothi.office_unit_name, nothiAllListDTO,nothiAll._nothiListInboxRecordDTO); };
                nothiAll._khoshra = _khosra;
                nothiAll.nothi_id = nothiAllListDTO.nothi.id.ToString();
                nothiAll.dak_id = _dak_id;
                nothiAll.is_copied_dak = _is_copied_dak;
                nothiAll._dak_type = _dak_type;
                nothiAll.master_id = nothiAllListDTO.nothi.id.ToString();
                UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, nothiAll);
            }
            

        }
        private void DoSomethingAsync(object sender, EventArgs e, int i)
        {
            if (i == 0)
            {
                this.Hide();
            }
            else
            {

            }
        }
        private void NoteDetails_ButtonClick(object addSender, EventArgs addEvent, NoteNothiDTO nothiDTO, string nothiName, string nothiBranch, NothiListAllRecordsDTO nothiAllListDTO, NothiListInboxNoteRecordsDTO _nothiListInboxRecordDTO)
        {
            var form = FormFactory.Create<Note>();
            form.NoteBackButton += delegate (object sender1, EventArgs e1) {
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide())); }
                var nothi = FormFactory.Create<Nothi>();
                nothi.TopMost = true;
                nothi.LoadNothiAllButton(sender1, e1);
                BeginInvoke((Action)(() => nothi.ShowDialog()));
                BeginInvoke((Action)(() => nothi.TopMost = false));
                nothi.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
            };
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = nothiDTO.note_id;
            NothiListAllRecordsDTO nothiAllListRecords = nothiAllListDTO;
            form.nothiNo = nothiAllListRecords.nothi.nothi_no;
            form.nothiShakha = nothiAllListRecords.nothi.office_unit_name + " " + _dakuserparam.office_label;
            form.nothiSubject = nothiAllListRecords.nothi.subject;
            form.noteSubject = nothiDTO.note_subject;
            form.nothiLastDate = nothiAllListRecords.nothi.last_note_date;
            form.noteAllListDataRecordDTO = _nothiListInboxRecordDTO;
            form.office = "( " + nothiAllListRecords.nothi.office_name + " " + nothiAllListRecords.nothi.last_note_date + ")";

            NoteView noteView = new NoteView();
            noteView.totalNothi = nothiDTO.note_no.ToString();
            noteView.noteSubject = nothiDTO.note_subject;
            noteView.nothiLastDate = nothiAllListRecords.nothi.last_note_date;
            noteView.officerInfo = _dakuserparam.officer + "," + nothiAllListRecords.nothi.office_designation_name + "," + nothiAllListRecords.nothi.office_unit_name + "," + _dakuserparam.office_label;
            noteView.checkBox = "1";
            noteView.nothiNoteID = _nothiListInboxRecordDTO.note.nothi_note_id;
            noteView.onucchedCount = _nothiListInboxRecordDTO.note.onucched_count.ToString();
            noteView.khosraPotro = _nothiListInboxRecordDTO.note.khoshra_potro.ToString();
            noteView.khoshraWaiting = _nothiListInboxRecordDTO.note.khoshra_waiting_for_approval.ToString();
            noteView.approved = _nothiListInboxRecordDTO.note.approved_potro.ToString();
            noteView.potrojari = _nothiListInboxRecordDTO.note.potrojari.ToString();
            noteView.nothivukto = _nothiListInboxRecordDTO.note.nothivukto_potro.ToString();
            NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
            nothiListRecordsDTO.id = nothiAllListDTO.nothi.id;
            nothiListRecordsDTO.office_id = nothiAllListDTO.nothi.office_id;
            nothiListRecordsDTO.office_name = nothiAllListDTO.nothi.office_name;
            nothiListRecordsDTO.office_unit_id = nothiAllListDTO.nothi.office_unit_id;
            nothiListRecordsDTO.office_unit_name = nothiAllListDTO.nothi.office_unit_name;
            nothiListRecordsDTO.office_unit_organogram_id = nothiAllListDTO.nothi.office_unit_organogram_id;
            nothiListRecordsDTO.office_designation_name = nothiAllListDTO.nothi.office_designation_name;
            nothiListRecordsDTO.nothi_no = nothiAllListDTO.nothi.nothi_no;
            nothiListRecordsDTO.subject = nothiAllListDTO.nothi.subject;
            nothiListRecordsDTO.nothi_class = nothiAllListDTO.nothi.nothi_class;
            nothiListRecordsDTO.last_note_date = nothiAllListDTO.nothi.last_note_date;
            nothiListRecordsDTO.local_nothi_type = nothiAllListDTO.nothi.nothi_type;
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.loadNoteView(noteView);
            form.noteTotal = nothiDTO.note_no.ToString();
            form.TopMost = true;
            form.TopMost = false;
            form.Show();
        }
        public event EventHandler SucessfullyDakNothivukto;
        public event EventHandler NothiKhosrajato;
        public event EventHandler MultipleDakNothivukto;

        public NothiListAllRecordsDTO _nothiAllListDTO { get; set; }
        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO { get; set; }
        public string _noteId { get; set; }


        private void NothiteUposthapito_ButtonClick(object addSender, EventArgs addEvent, NoteNothiDTO nothiDTO, string nothiName, string nothiBranch, NothiListAllRecordsDTO nothiAllListDTO, NothiListInboxNoteRecordsDTO _nothiListInboxRecordDTO)
        {
            _noteId = nothiDTO.note_id;
            _nothiAllListDTO = nothiAllListDTO;

            _nothiListInboxNoteRecordsDTO = _nothiListInboxRecordDTO;
            _noteSelected = nothiDTO;
            _nothiName = nothiName;
            _nothiBranch = nothiBranch;

            if (this.NothiKhosrajato != null)
            {
                this.NothiKhosrajato(addSender, addEvent);
                this.Hide();
            }
                



            else if (_dak_id == 0)
            {

                if (this.MultipleDakNothivukto != null)
                    this.MultipleDakNothivukto(addSender, addEvent);
                this.Hide();
            }
            else
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                DakNothivuktoResponse dakNothivuktoResponse = _nothivuktoService.GetDakNothivuktoResponse(dakUserParam, nothiDTO, _dak_id, _dak_type, _is_copied_dak);

                if (dakNothivuktoResponse.message == "Local")
                {
                    _dakNothiteUposthapitoLocally = true;
                    UIDesignCommonMethod.SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে এই ডাকটি নথিতে উপস্থাপন করা হবে");


                    if (this.SucessfullyDakNothivukto != null)
                        this.SucessfullyDakNothivukto(addSender, addEvent);

                    this.Hide();
                }
                else if (dakNothivuktoResponse.status == "success")
                {
                    _dakNothiteUposthapitoLocally = false;
                    UIDesignCommonMethod.SuccessMessage(dakNothivuktoResponse.data);


                    if (this.SucessfullyDakNothivukto != null)
                        this.SucessfullyDakNothivukto(addSender, addEvent);
                    this.Hide();
                }

                else
                {
                    UIDesignCommonMethod.ErrorMessage(dakNothivuktoResponse.message);
                }
            }
        }
        
        private void DakNothiteUposthapitoForm_Load(object sender, EventArgs e)
        {

            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = scr.WorkingArea.Height;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void detailPanelDropDownButton_Click(object sender, EventArgs e)
        {
            if (detailsNothiSearcPanel.Visible)
            {
                detailsNothiSearcPanel.Visible = false;
            }
            else
            {
                detailsNothiSearcPanel.Visible = true;
            }
        }

        private void BorderBlueColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);


        }

       
    }
}

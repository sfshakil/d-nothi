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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakModuleSokolNothiListUserControl : UserControl
    {

        private int originalWidth;
        private int originalHeight;

        public int _dak_id;
        public string _dak_type;
        public int _is_copied_dak;
        public NoteNothiDTO _nothiDTO;

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
        public DakModuleSokolNothiListUserControl(IDakNothivuktoService dakNothivuktoService,IUserService userService,INothiNoteTalikaServices nothiNoteTalikaServices)
        {
           
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
            set { _id = value;}
        }
        public string master_id
        {
            get { return _masterid; }
            set { _masterid = value; }
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

        private void nothiShompadonIcon_MouseHover(object sender, EventArgs e)
        {
            nothiShompadonIcon.IconColor = Color.Salmon;
        }

        private void nothiShompadonIcon_MouseLeave(object sender, EventArgs e)
        {
            nothiShompadonIcon.IconColor = Color.FromArgb(54, 153, 255);
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
            var noteAll = _nothinotetalikaservices.GetNothiNoteListAll(_userService.GetLocalDakUserParam(),Convert.ToInt32(_id));

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

                if(noteDTO.deskConverted!=null)
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
               
                noteDTO.nothi.note_no = noteDTO.note.note_no.ToString();
                noteDTO.nothi.note_subject= noteDTO.note.note_subject;
                noteDTO.nothi.note_id= noteDTO.note.nothi_note_id.ToString();

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

        private void newNothiAddButton_Click(object sender, EventArgs e)
        {
            var newNoteAddForm = FormFactory.Create<DakNothiteUposthapitoNewNoteAddUserControl>();
            newNoteAddForm.SaveNoteButtonClick += delegate (object addSender, EventArgs addEvent) { SaveNote_ButtonClick(newNoteAddForm._noteSubject); };


            newNoteAddForm.ShowDialog();
        }

        private void SaveNote_ButtonClick(string noteSubject)
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            DakNothivuktoNoteAddParam dakNothivuktoNoteAddParam = new DakNothivuktoNoteAddParam();
            dakNothivuktoNoteAddParam.note_subject = noteSubject;
            dakNothivuktoNoteAddParam.nothi_master_id =Convert.ToInt32(_masterid);
            dakNothivuktoNoteAddParam.officer_name = dakUserParam.officer_name;
            dakNothivuktoNoteAddParam.office_designation_name = dakUserParam.designation;
            dakNothivuktoNoteAddParam.office_id = dakUserParam.office_id;
            dakNothivuktoNoteAddParam.office_name = dakUserParam.office_label;
            dakNothivuktoNoteAddParam.office_unit_name = dakUserParam.office_unit;


            GetNothivuktoNoteAddResponse getNothivuktoNoteAddResponse = _nothivuktoService.GetNothijatoNoteAddResponse(dakUserParam, dakNothivuktoNoteAddParam);

            if(getNothivuktoNoteAddResponse.status=="success")
            {
                LoadNote();
            }
            else
            {

            }
        }
    }
}

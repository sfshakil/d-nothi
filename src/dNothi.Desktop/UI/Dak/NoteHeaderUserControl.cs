using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NoteHeaderUserControl : UserControl
    {
        IRepository<NoteList> _noteList;
        IUserService _userService { get; set; }
        public WaitFormFunc WaitForm;
        public NoteHeaderUserControl(IUserService userService, IRepository<NoteList> noteList)
        {
            _userService = userService;
            _noteList = noteList;
            WaitForm = new WaitFormFunc();
            InitializeComponent();
        }
        private string _noteNumber;
        NoteListDataRecordNoteDTO _list = new NoteListDataRecordNoteDTO();
        List<NoteListDataRecordNoteDTO> listnote = new List<NoteListDataRecordNoteDTO>();
        NoteView _noteView = new NoteView();
        List<NoteView> listNoteView = new List<NoteView>();
        [Category("Custom Props")]
        public string noteNumber
        {
            get { return _noteNumber; }
            set
            {
                _noteNumber = value;
                lbNoteNumber.Text = "নোটঃ " + value;
            }
        }
        public NoteListDataRecordNoteDTO NoteList
        {
            get { return _list; }
            set { _list = value;
                DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
                NoteList noteListDB = _noteList.Table.FirstOrDefault(a => a.note_number == _noteNumber && a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id);

                if (noteListDB != null)
                {
                    var json = new JavaScriptSerializer().Serialize(_list);
                    noteListDB.jsonResponse = json;
                    _noteList.Update(noteListDB);
                }
                else
                {
                    var json = new JavaScriptSerializer().Serialize(_list);
                    NoteList noteItem = new NoteList();
                    noteItem.note_number = _noteNumber;
                    noteItem.designation_id = _userService.GetLocalDakUserParam().designation_id;
                    noteItem.office_id = _userService.GetLocalDakUserParam().office_id;
                    noteItem.jsonResponse = json;
                    _noteList.Insert(noteItem);

                }
            }
        }
        public NoteView noteView
        {
            get { return _noteView; }
            set { _noteView = value;}
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
        }
        public void setNoteNUmberForeCOlor(int r, int g, int b)
        {
            lbNoteNumber.ForeColor = Color.FromArgb(r,g,b);
        }
        public event EventHandler NoteNumberButton;
        private void lbNoteNumber_Click(object sender, EventArgs e)
        {
            WaitForm.Show();
            lbNoteNumber.ForeColor = Color.FromArgb(54, 153, 255);
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            List<NoteList> noteSaveItemActions = _noteList.Table.Where(a => a.note_number == _noteNumber && a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();

            if (noteSaveItemActions != null)
            {
                foreach (NoteList Notelist in noteSaveItemActions)
                {
                    NoteListDataRecordNoteDTO nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NoteListDataRecordNoteDTO>(Notelist.jsonResponse); 
                    if (this.NoteNumberButton != null)
                        this.NoteNumberButton(nothiListInboxNoteResponse, e);
                }
            }
            WaitForm.Close();

        }

        private void panel55_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
    }
}

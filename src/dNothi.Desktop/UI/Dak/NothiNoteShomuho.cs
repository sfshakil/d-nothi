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
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiNoteShomuho : UserControl
    {
        IUserService _userService { get; set; }
        INoteDeleteService _noteDelete { get; set; }
        public NothiNoteShomuho(IUserService userService, INoteDeleteService noteDelete)
        {
            _userService = userService;
            _noteDelete = noteDelete;
            InitializeComponent();
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
        private string _note_no;
        private string _note_subject;
        private string _deskofficer;
        private string _toofficer;

        [Category("Custom Props")]
        public string note_no
        {
            get { return _note_no; }
            set { _note_no = value; lbNoteNumber.Text = value; }
        }
        private string _note_ID;

        [Category("Custom Props")]
        public string note_ID
        {
            get { return _note_ID; }
            set { _note_ID = value; lbNoteId.Text = value; }
        }
        private string _noteSubText;

        [Category("Custom Props")]
        public string noteSubText
        {
            get { return _noteSubText; }
            set { _noteSubText = value; lbNoteSubText.Text = value; }
        }

        [Category("Custom Props")]
        public string note_subject
        {
            get { return _note_subject; }
            set { _note_subject = value; lbNoteSubject.Text = value; }
        }

        [Category("Custom Props")]
        public string deskofficer
        {
            get { return _deskofficer; }
            set { _deskofficer = value; lbDeskOfficer.Text = value; }
        }

        [Category("Custom Props")]
        public string toofficer
        {
            get { return _toofficer; }
            set { _toofficer = value; lbToOfficer.Text = value; }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            string message = "নোটটি মুছে ফেলুন";
            string title = "";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes && lbNoteSubText.Text == "অনুচ্ছেদ দেওয়া হয়নি")
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                string model = "NothiNotes";
                string noteID = lbNoteId.Text;
                var noteDelete = _noteDelete.GetNoteDelteResponse(dakListUserParam,model,noteID);
                if(noteDelete.status == "success")
                {
                    this.Hide();
                }

            }
            else
            {
                
            }
        }
    }
}
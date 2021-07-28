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

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiNoteTalikaAll : UserControl
    {
        public NothiNoteTalikaAll()
        {
            InitializeComponent();
        }
        private string _note_no;
        private string _note_subject;
        private string _deskofficer;
        private string _toofficer;
        private int _nothiAttachmentCount;
        private string _date;
        private int _nothivukto;
        private int _onucched;
        private int _onumodon;
        private int _potrojari;
        private bool _isPreritoNote;
        private bool _isEyeOff;
        private string _preritoNoteCDesk;
        private string _preritoNoteDate;
        private string _preritoNotePrapok;

        public string preritoNotePrapok
        {
            get { return _preritoNotePrapok; }
            set { _preritoNotePrapok = value; preritoNotePrapokLabel.Text = value; }
        }
          public string preritoNoteDate
        {
            get { return _preritoNoteDate; }
            set { _preritoNoteDate = value; preritoNoteCDeskLabel.Text = value; }
        }

         public string preritoNoteCDesk
        {
            get { return _preritoNoteCDesk; }
            set { _preritoNoteCDesk = value; cDeskLabel.Text = value; }
        }


        public bool isEyeInvisible
        {
            get { return _isEyeOff; }
            set { _isEyeOff = value; if (value) { NoEyeIconButton.Visible = true;eyeButton.Visible = false;} }
        }

        public bool isPreritoNote
        {
            get { return _isPreritoNote; }
            set { _isPreritoNote = value; if (value) { sokolNoteNoteDeskPanel.Visible = false; preritoNoteCDeskPanel.Visible = true; preritoNoteDatePanel.Visible = true; preritoNotePrapokPanel.Visible = true;usersButton.Visible = true; optionButton.Visible = false; } }
        }



        public NoteNothiDTO _nothiDTO;




        public NoteNothiDTO nothiDTO
        {
            get { return _nothiDTO; }
            set { _nothiDTO = value; }
        }



        [Category("Custom Props")]
        public string date
        {
            get { return _date; }
            set { _date = value; dateLabel.Text = value; }
        }


        [Category("Custom Props")]
        public int onumodon
        {
            get { return _onumodon; }
            set { _onumodon = value; if (value == 0) { onumodonLabel.Visible = false; } else { onumodonLabel.Text = onumodonLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }
        }

        [Category("Custom Props")]
        public int potrojari
        {
            get { return _potrojari; }
            set { _potrojari = value; if (value == 0) { potrojariLabel.Visible = false; } else { potrojariLabel.Text = potrojariLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }  }
        }
        [Category("Custom Props")]
        public int onucched
        {
            get { return _onucched; }
            set { _onucched = value; if (value == 0) { onucchedLabel.Visible = false; } else { onucchedLabel.Text = onucchedLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }
        }

        [Category("Custom Props")]
        public int nothivukto
        {
            get { return _nothivukto; }
            set { _nothivukto = value; if (value == 0) { nothivuktoLabel.Visible = false; } else { nothivuktoLabel.Text = nothivuktoLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }
        }


        [Category("Custom Props")]
        public int nothiAttachmentCount
        {
            get { return _nothiAttachmentCount; }
            set { _nothiAttachmentCount = value; if (value == 0) { nothiAttachmentButton.Visible = false; } else { nothiAttachmentButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }
        }


        public int _nisponnoCount { get; set; }
      
       [Category("Custom Props")]
        public int nisponnoCount
        {
            get { return _nisponnoCount; }
            set { _nisponnoCount = value; if (value == 0) { nishponnoLabel.Visible = false; } else { nishponnoLabel.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }
        }

        public string _sub { get; set; }
        [Category("Custom Props")]
        public string sub
        {
            get { return _sub; }
            set { _sub = value; branchNoteSubLabel.Text = value; }
        }


        [Category("Custom Props")]
        public string note_no
        {
            get { return _note_no; }
            set { _note_no = value; noteNoLabel.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string note_subject
        {
            get { return _note_subject; }
            set { _note_subject = value; subjectLabel.Text = value; }
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

        private void BorderColorDate(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);
        }
        public event EventHandler btnOptionClick;
        private void optionButton_Click(object sender, EventArgs e)
        {
            // UIDesignCommonMethod.CallAllModulePanel(optionButton, this);
            Point locationOnForm = optionButton.FindForm().PointToClient(optionButton.Parent.PointToScreen(optionButton.Location));
            object buttonCoOrdinates = locationOnForm;

            if (this.btnOptionClick != null)
            {
                this.btnOptionClick(locationOnForm, e);
            }

        }
        
       
       
    }
}

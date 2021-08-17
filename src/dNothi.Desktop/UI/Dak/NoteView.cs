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
    public partial class NoteView : UserControl
    {
        public NoteView()
        {
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
        public string _totalNothi;
        public bool _checkBoxValue;
        public string _noteSubject;
        private string _officerInfo;
        public string _nothiLastDate;
        private string _checkBox;
        private string _onucchedCount;
        public string _khosraPotro;
        public string _khoshraWaiting;
        private string _approved;
        public string _potrojari;
        private string _nothivukto;
        public int _nothiNoteID;

        public void loadEyeIcon(int i)
        {
            if (i == 0)
            {
                eyeIcon.Visible = true;
                eyeSlashIcon.Visible = false;
            }
            else if (i == 1)
            {
                eyeIcon.Visible = false;
                eyeSlashIcon.Visible = true;
            }
        }

        [Category("Custom Props")]
        public string onucchedCount
        {
            get { return _onucchedCount; }
            set { _onucchedCount = value; lbOnucchedCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string khosraPotro
        {
            get { return _khosraPotro; }
            set { _khosraPotro = value; lbKhosraPotro.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string khoshraWaiting
        {
            get { return _khoshraWaiting; }
            set { _khoshraWaiting = value; lbKhoshraWaiting.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string approved
        {
            get { return _approved; }
            set { _approved = value; lbApproved.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string potrojari
        {
            get { return _potrojari; }
            set { _potrojari = value; lbPotrojari.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string nothivukto
        {
            get { return _nothivukto; }
            set { _nothivukto = value; lbNothivukto.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string totalNothi
        {
            get { return _totalNothi; }
            set { _totalNothi = value; lbTotalNothi.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
        }
        [Category("Custom Props")]
        public int nothiNoteID
        {
            get { return _nothiNoteID; }
            set { _nothiNoteID = value; lbNothiNoteID.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public string officerInfo
        {
            get { return _officerInfo; }
            set { _officerInfo = value; lbOfficerInfo.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiLastDate
        {
            get { return _nothiLastDate; }
            set { _nothiLastDate = value; lbNothiLastDate.Text = value; }
        }

        [Category("Custom Props")]
        public string checkBox
        {
            get { return _checkBox; }
            set
            {
                _checkBox = value;
                if (value == "1")
                    cbNote.Checked = true;
                else
                    cbNote.Checked = false;
            }
        }
        public void checkcbNote()
        {
            cbNote.Checked = false;
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler CheckBoxClick;

        private void cbNote_Click_1(object sender, EventArgs e)
        {
            if (cbNote.Checked == true)
            {
                NoteListDataRecordNoteDTO List1 = new NoteListDataRecordNoteDTO();
                List1.khoshra_potro = Convert.ToInt32(_khosraPotro);
                List1.khoshra_waiting_for_approval = Convert.ToInt32(khoshraWaiting);
                List1.potrojari = Convert.ToInt32(potrojari);
                List1.nothivukto_potro = Convert.ToInt32(nothivukto);
                //List1.note_status = sender.ToString();
                List1.nothi_note_id = Convert.ToInt32(lbNothiNoteID.Text);
                List1.note_status = lbTotalNothi.Text;
                List1.note_subject_sub_text = lbNoteSubject.Text;
                List1.date = lbNothiLastDate.Text;
                if (eyeSlashIcon.Visible == true)
                {
                    List1.can_revert = 1;
                }
                if (this.CheckBoxClick != null)
                    this.CheckBoxClick(List1, e);
            }
            

        }

        private void cbNote_CheckedChanged(object sender, EventArgs e)
        {
            NoteListDataRecordNoteDTO List1 = new NoteListDataRecordNoteDTO();
            List1.khoshra_potro = Convert.ToInt32(_khosraPotro);
            List1.khoshra_waiting_for_approval = Convert.ToInt32(khoshraWaiting);
            List1.potrojari = Convert.ToInt32(potrojari);
            //List1.note_status = sender.ToString();
            List1.nothi_note_id = Convert.ToInt32(lbNothiNoteID.Text);
            List1.note_status = lbTotalNothi.Text;
            List1.note_subject_sub_text = lbNoteSubject.Text;
            List1.date = lbNothiLastDate.Text;
            if (eyeSlashIcon.Visible == true)
            {
                List1.can_revert = 1;
            }
            if (this.CheckBoxClick != null)
                this.CheckBoxClick(List1, e);

        }

        //private void cbNote_Click(object sender, EventArgs e)
        //{
        //    if (cbNote.Checked == false)
        //    {
        //        //Emnei emnei = new Emnei();
        //        //emnei.nothiLastDate = ;
        //        //emnei.noteSubject = ;
        //        //pnlALLNoteView.Controls.Add(emnei);
        //    }
        //    else
        //    {
        //        if (this.CheckBoxClick != null)
        //            this.CheckBoxClick(sender, e);
        //    }


        //}
    }
}

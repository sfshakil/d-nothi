using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private string _totalNothi;
        private string _noteSubject;
        private string _officerInfo;
        private string _nothiLastDate;
        private string _checkBox;
        private string _onucchedCount;
        private string _khosraPotro;
        private string _khoshraWaiting;
        private string _approved;
        private string _potrojari;
        private string _nothivukto;

        public void loadEyeIcon(int i)
        {
            if (i == 0)
            {
                eyeIcon.Visible = true;
                eyeSlashIcon.Visible = false;
            }
            else if (i== 1)
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
            set { _checkBox = value;
                if (value == "1")
                    cbNote.Checked = true;
                else
                    cbNote.Checked = false;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler CheckBoxClick;

        private void cbNote_Click_1(object sender, EventArgs e)
        {
                if (this.CheckBoxClick != null)
                    this.CheckBoxClick(sender, e);
                
        }

        //private void cbNote_Click(object sender, EventArgs e)
        //{
        //    if (cbNote.Checked == false)
        //    {

        //        //MessageBox.Show("Madarchod");
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

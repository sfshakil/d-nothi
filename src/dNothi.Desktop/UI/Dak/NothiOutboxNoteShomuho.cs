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
    public partial class NothiOutboxNoteShomuho : UserControl
    {
        public NothiOutboxNoteShomuho()
        {
            InitializeComponent();
        }
        private string _noteNumber;
        private string _notesubject;
        private string _prapok;
        private string _currentDesk;
        private string _onucched;
        private string _khoshra;
        private string _potrojari;
        private string _nishponno;
        private string _noteIssueDate;
        private string _noteAttachment;
        private int _canRevert;

        [Category("Custom Props")]
        public string noteNumber
        {
            get { return _noteNumber; }
            set { _noteNumber = value; lbNoteNumber.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string notesubject
        {
            get { return _notesubject; }
            set { _notesubject = value; lbsubject.Text = value; }
        }public string prapok
        {
            get { return _prapok; }
            set { _prapok = value; lbPrapok.Text = value; }
        }public string currentDesk
        {
            get { return _currentDesk; }
            set { _currentDesk = value; lbCurrentDesk.Text = value; }
        }public string onucched
        {
            get { return _onucched; }
            set { _onucched = value; lbOnucched.Text = "অনুচ্ছেদ: "+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string khoshra
        {
            get { return _khoshra; }
            set { _khoshra = value; lbKhoshra.Text = "খসড়া: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string potrojari
        {
            get { return _potrojari; }
            set { _potrojari = value; lbPotrojari.Text = "পত্রজারি: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string nishponno
        {
            get { return _nishponno; }
            set { _nishponno = value; lbNishponno.Text = "নিষ্পন্ন: " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string noteIssueDate
        {
            get { return _noteIssueDate; }
            set { _noteIssueDate = value; lbNoteIssueDate.Text = value; }
        }public string noteAttachment
        {
            get { return _noteAttachment; }
            set { _noteAttachment = value; btnAttachment.Text = value; }
        }public int canRevert
        {
            get { return _canRevert; }
            set { _canRevert = value;
                if (value == 0)
                    eyeIcon.IconChar = FontAwesome.Sharp.IconChar.Eye;
                else
                    eyeIcon.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
        }

    }
}

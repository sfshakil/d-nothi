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
    public partial class OnuchhedAdd : UserControl
    {
        public OnuchhedAdd()
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
        private string _currentDate;
        private string _currentMonth;
        private string _currentYear;
        private string _noteOnuchhed;
        private string _body;
        private string _Onuchhed; 
        private int _file;
        private int _fileflag;
        private string _onucchedId;

        [Category("Custom Props")]
        public int fileflag
        {
            get { return _fileflag; }
            set
            {
                _fileflag = value;
                if (value == 0)
                {
                    fileheadpnl.Visible = false;
                    fileFLP.Visible = false;
                }
                else
                {
                    fileheadpnl.Visible = true;
                    fileFLP.Visible = true;
                }
            }
        }
        [Category("Custom Props")]
        public string currentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; lbCurrentDate.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string currentMonth
        {
            get { return _currentMonth; }
            set { _currentMonth = value; lbCurrentMonth.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string currentYear
        {
            get { return _currentYear; }
            set { _currentYear = value; lbCurrentYear.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string noteOnuchhed
        {
            get { return _noteOnuchhed; }
            set { _noteOnuchhed = value; lbNotettl.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string body
        {
            get { return _body; }
            set { _body = value; lbBody.Text = value; }
        }
        [Category("Custom Props")]
        public string onucchedId
        {
            get { return _onucchedId; }
            set { _onucchedId = value; lbonucchedId.Text = value; }
        }
        [Category("Custom Props")]
        public int file
        {
            get { return _file; }
            set { _file = value; lbfileflag.Text = "("+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')))+")"; }
        }

        [Category("Custom Props")]
        public string Onuchhed
        {
            get { return _Onuchhed; }
            set { _Onuchhed = value; lbOnuchhed.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        private void OnuchhedAdd_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnKhoshra.Visible = true;
        }

        private void topPnl_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnKhoshra.Visible = true;
        }

        private void middlePnl_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnKhoshra.Visible = true;
        }

        private void bodyPnl_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnKhoshra.Visible = true;
        }


        private void btnKhoshra_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnKhoshra.Visible = true;
            btnKhoshra.IconColor = Color.Red;
        }

        private void btnKhoshra_MouseLeave(object sender, EventArgs e)
        {
            btnKhoshra.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnKhoshra.Visible = true;
            btnEdit.IconColor = Color.Red;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.IconColor = Color.FromArgb(54, 153, 255);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnKhoshra.Visible = true;
            btnDelete.IconColor = Color.Red;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.IconColor = Color.FromArgb(54, 153, 255);
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler DeleteButtonClick;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.DeleteButtonClick != null)
                this.DeleteButtonClick(onucchedId, e);
        }
        [Category("Custom Props")]
        public void getAttachment(NoteFileUpload notefileupload)
        {
            Attachment attachment = new Attachment();
            attachment.attachmentName = notefileupload.attachmentName;
            attachment.attachmentSize = notefileupload.fileexension;
            fileFLP.Controls.Add(attachment);
        }
        //public event EventHandler EditButtonClick;
        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    if (this.EditButtonClick != null)
        //        this.EditButtonClick(onucchedId, e);
        //}
    }
}

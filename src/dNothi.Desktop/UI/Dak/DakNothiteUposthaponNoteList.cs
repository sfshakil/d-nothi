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
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakNothiteUposthaponNoteList : UserControl
    {
        public DakNothiteUposthaponNoteList()
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
            set { _onumodon = value; onumodonLabel.Text = onumodonLabel.Text+string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
       
        [Category("Custom Props")]
        public int potrojari
        {
            get { return _potrojari; }
            set { _potrojari = value; potrojariLabel.Text = potrojariLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public int onucched
        {
            get { return _onucched; }
            set { _onucched = value; onucchedLabel.Text = onucchedLabel.Text + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public int nothivukto
        {
            get { return _nothivukto; }
            set { _nothivukto = value; nothivuktoLabel.Text = nothivuktoLabel.Text+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        [Category("Custom Props")]
        public int nothiAttachmentCount
        {
            get { return _nothiAttachmentCount; }
            set { _nothiAttachmentCount = value; nothiAttachmentButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        [Category("Custom Props")]
        public string note_no
        {
            get { return _note_no; }
            set { _note_no = value; noteNoLabel.Text = value; }
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


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler NothiteUposthapitoButtonClick;
        private void nothiteUposthapitoButton_Click(object sender, EventArgs e)
        {

            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি এই নোটে ডাকটি উপস্থাপন করতে চান ?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {


                if (this.NothiteUposthapitoButtonClick != null)
                    this.NothiteUposthapitoButtonClick(sender, e);
            }
               
        }




    }
}

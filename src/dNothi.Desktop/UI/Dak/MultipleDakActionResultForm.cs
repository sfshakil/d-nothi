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
    public partial class MultipleDakActionResultForm : Form
    {
        public MultipleDakActionResultForm()
        {
            InitializeComponent();
        }
        public int _totalRequest { get; set; }


        public int totalRequest { get { return _totalRequest; } set { _totalRequest = value; selectedDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }

        public int _totalRequestFail { get; set; }
        public int totalRequestFail { get { return _totalRequestFail; } set { _totalRequestFail = value; failureDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalNothivuktoRequest { get; set; }
        public int totalNothivuktoRequest { get { return _totalNothivuktoRequest; } set { _totalNothivuktoRequest = value; NothivuktoPanel.Visible = true; nothivuktoHeadline.Visible = true;  nothivuktoDakCount.Text= string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalArchiveRequest { get; set; }
        public int totalArchiveRequest { get { return _totalArchiveRequest; } set { _totalArchiveRequest = value; archivePanel.Visible = true; archiveHeadline.Visible = true; archiveDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalNothijatoRequest { get; set; }
        public int totalNothijatoRequest { get { return _totalNothijatoRequest; } set { _totalNothijatoRequest = value; nothijatoPanel.Visible = true; nothijatoHeadline.Visible = true; nothijatoDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalForwardRequest { get; set; }
        public int totalForwardRequest { get { return _totalForwardRequest; } set { _totalForwardRequest = value; forwardPanel.Visible = true; forwardHeadline.Visible = true; forwardDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public MultipleDakActionResultDakRowUserControl multiplaeDakActionResultAdd { get { return null; } set { dakListFlowLayoutPanel.Controls.Add(value); } }



        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

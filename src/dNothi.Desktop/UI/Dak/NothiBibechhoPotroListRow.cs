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
    public partial class NothiBibechhoPotroListRow : UserControl
    {
        public NothiBibechhoPotroListRow()
        {
            InitializeComponent();
        }
        private string _potroName;
        private string _potroNumber;
        private string _potroDate;
        private string _potroNote;
        public string mulpotroURL;
        [Category("Custom Props")]
        public string potroName
        {
            get { return _potroName; }
            set { _potroName = value; lbPotroName.Text = value; }
        }
        public string potroNumber
        {
            get { return _potroNumber; }
            set { _potroNumber = value; lbPotroNumber.Text = value; }
        }
        public string potroDate
        {
            get { return _potroDate; }
            set { _potroDate = value; lbPotroDate.Text = value; }
        }
        public string potroNote
        {
            get { return _potroNote; }
            set { _potroNote = value; lbPotroNote.Text = "নোট :" + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        private void lbPotroName_Click(object sender, EventArgs e)
        {
            FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
            fileViewWebBrowser.fileAddInWebBrowser(mulpotroURL, potroName);
            UIDesignCommonMethod.CalPopUpWindow(fileViewWebBrowser,this);
        }
        
        public event EventHandler GaurdFileAddButton;
        private void btnGaurdFileAdd_Click(object sender, EventArgs e)
        {
            if (this.GaurdFileAddButton != null)
                this.GaurdFileAddButton(sender, e);
        }
    }
}

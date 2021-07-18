using dNothi.JsonParser.Entity.Dak;
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
    public partial class NothiDecisionListRow : UserControl
    {
        public NothiDecisionListRow()
        {
            InitializeComponent();
        }
        private string _decisionText;
        private string _URL;
        public string URL
        {
            get { return _URL; }
            set { _URL = value; lbDecisionText.ForeColor = Color.FromArgb(54, 153, 255); lbDecisionText.Cursor = Cursors.Hand;  }
        }
        [Category("Custom Props")]
        public string decisionText
        {
            get { return _decisionText; }
            set { _decisionText = value; lbDecisionText.Text = value; }
        }
        
        public event EventHandler DecisionAddButton;
        public event EventHandler AttachmentAddButton;
        private void btnDecisionAdd_Click(object sender, EventArgs e)
        {
            if (this.DecisionAddButton != null)
                this.DecisionAddButton(lbDecisionText.Text, e);

            if (this.AttachmentAddButton != null)
            {
                DakAttachmentDTO record = new DakAttachmentDTO();
                record.user_file_name = _decisionText;
                record.url = _URL;
                this.AttachmentAddButton(record, e);
            }
        }

        private void lbDecisionText_Click(object sender, EventArgs e)
        {
            if (_URL != null)
            {
                FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
                fileViewWebBrowser.fileAddInWebBrowser(_URL, _decisionText);
                CalPopUpWindow(fileViewWebBrowser);
            }
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
    }
}

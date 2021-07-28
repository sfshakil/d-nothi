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
        private string _shongjuktiURL;
        private string _potakaURL;
        private string _attachmentKilobyte;
        public string attachmentKilobyte
        {
            get { return _attachmentKilobyte; }
            set { 
                _attachmentKilobyte = value; //lbDecisionText.ForeColor = Color.FromArgb(54, 153, 255);
                lbAttachmentKilobyte.Visible = true;
                lbAttachmentKilobyte.Text = string.Concat(value.ToString().Select(c => char.IsDigit(c) ?  (char)('\u09E6' + c - '0') : '.')) + " কিলোবাইট";
            }
        }
        public string potakaURL
        {
            get { return _potakaURL; }
            set { _potakaURL = value; //lbDecisionText.ForeColor = Color.FromArgb(54, 153, 255);
                  lbDecisionText.Cursor = Cursors.Hand;  }
        }
        public void setPotakaColor(string color)
        {
            if (color == "#fada5e")
            {
                lbDecisionText.ForeColor = Color.FromArgb(250, 218, 94);
            }else if (color == "#dc143c")
            {
                lbDecisionText.ForeColor = Color.Crimson;
            }
            else if (color == "#6495ed")
            {
                lbDecisionText.ForeColor = Color.CornflowerBlue;
            }
            
        }

        public string shongjuktiURL
        {
            get { return _shongjuktiURL; }
            set { _shongjuktiURL = value; lbDecisionText.ForeColor = Color.FromArgb(54, 153, 255); lbDecisionText.Cursor = Cursors.Hand;  }
        }
        [Category("Custom Props")]
        public string decisionText
        {
            get { return _decisionText; }
            set { _decisionText = value; lbDecisionText.Text = value; }
        }
        public void setPaddingForOnuchhedList()
        {
            this.Padding = new Padding(25, 0, 0, 0);
            this.Margin = new Padding(0, 10, 0, 0);
            this.BackColor = Color.FromArgb(243,246,249);
        }
        public void setLabelColorForOnuchhedList()
        {
            this.Margin = new Padding(0, 10, 0, 0);
            this.BackColor = Color.FromArgb(243, 246, 249);
            lbDecisionText.ForeColor = Color.FromArgb(54, 153, 255); lbDecisionText.Cursor = Cursors.Hand;
        }
        public void setbtnDecisionIcon()
        {
            btnDecisionAdd.Cursor = Cursors.Default;
            btnDecisionAdd.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnDecisionAdd.FlatAppearance.MouseOverBackColor = Color.Transparent;
            //btnDecisionAdd.Enabled = false;
            btnDecisionAdd.BackColor = Color.White;
            btnDecisionAdd.IconChar = FontAwesome.Sharp.IconChar.Image;
            btnDecisionAdd.IconColor = Color.FromArgb(255, 168, 0);
        }
        public event EventHandler DecisionAddButton;
        public event EventHandler AttachmentAddButton;
        public event EventHandler PotakaAddButton;
        public event EventHandler OnuchhedAddButton;
        private void btnDecisionAdd_Click(object sender, EventArgs e)
        {
            if (this.DecisionAddButton != null)
                this.DecisionAddButton(lbDecisionText.Text, e);

            if (this.AttachmentAddButton != null)
            {
                DakAttachmentDTO record = new DakAttachmentDTO();
                record.user_file_name = _decisionText;
                record.url = _shongjuktiURL;
                this.AttachmentAddButton(record, e);
            }
            if (this.PotakaAddButton != null)
            {
                this.PotakaAddButton(sender, e);
            }
            if (this.OnuchhedAddButton != null)
            {
                this.OnuchhedAddButton(lbDecisionText.Text, e);
            }
        }

        private void lbDecisionText_Click(object sender, EventArgs e)
        {
            if (_shongjuktiURL != null)
            {
                FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
                fileViewWebBrowser.fileAddInWebBrowser(_shongjuktiURL, _decisionText);
                CalPopUpWindow(fileViewWebBrowser);
            }
            else if (_potakaURL != null)
            {
                FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
                fileViewWebBrowser.fileAddInWebBrowser(_potakaURL, _decisionText);
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

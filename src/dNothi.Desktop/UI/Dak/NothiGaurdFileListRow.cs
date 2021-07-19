using dNothi.JsonParser.Entity.Nothi;
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
    public partial class NothiGaurdFileListRow : UserControl
    {
        public NothiGaurdFileListRow()
        {
            InitializeComponent();
        }
        private string _nameText;
        private string _categoryNameText;
        public string attachmentURL;

        [Category("Custom Props")]
        public string nameText
        {
            get { return _nameText; }
            set { _nameText = value; lbname_bng.Text = value; }
        }
        public string categoryNameText
        {
            get { return _categoryNameText; }
            set { _categoryNameText = value; lbguard_file_category_name_bng.Text = value; }
        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        public event EventHandler GaurdFileAddButton;
        private void btnGaurdFileAdd_Click(object sender, EventArgs e)
        {
            GaurdFileRecord gaurdFileRecord = new GaurdFileRecord();
            gaurdFileRecord.name_bng = _nameText;

            GaurdFileAttachment gaurdFileAttachment = new GaurdFileAttachment();
            gaurdFileAttachment.url = attachmentURL;

            gaurdFileRecord.attachment = gaurdFileAttachment;

            if (this.GaurdFileAddButton != null)
                this.GaurdFileAddButton(gaurdFileRecord, e);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
            fileViewWebBrowser.fileAddInWebBrowser(attachmentURL, _nameText);
            CalPopUpWindow(fileViewWebBrowser);
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

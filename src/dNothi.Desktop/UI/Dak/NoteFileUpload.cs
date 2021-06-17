using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NoteFileUpload : UserControl
    {
        public NoteFileUpload()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
            client = new WebClient();
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
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
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download complete !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
        WebClient client;
        private string _imageSrc;
        private string _attachmentName;
        private string _fileextension;
        private string _attachementId;
        ProgressBar pBar = new ProgressBar();
        private void CreateProgressBar()
        {
            //pBar.Location = new System.Drawing.Point(20, 20);
            //pBar.Name = "progressBar1";
            pBar.Width = 200;
            pBar.Height = 30;
            //pBar.BackColor = Color.Transparent;
            pBar.Minimum = 0;
            pBar.Maximum = 100;
            pBar.Value = 0;
            panel10.Controls.Add(pBar);
            //UIDesignCommonMethod.AddRowinTable(fileAddFLP, pBar);
        }
        
        public string imgSource
        {
            get { return _imageSrc; }
            set
            {
                _imageSrc = value;
                if (value != "")
                {
                    attachmentPicturebox.Image = new Bitmap(value);
                }
                else
                {
                    attachmentPicturebox.Enabled = false;
                }
            }

        }
        public string attachmentName
        {
            get { return _attachmentName; }
            set
            {
                _attachmentName = value; attachmentNameTextBox.Text = value;
            }

        }
        public string fileexension
        {
            get { return _fileextension; }
            set
            {
                _fileextension = value;
                lbByte.Text = value;


            }

        }
        public string attachementId
        {
            get { return _attachementId; }
            set
            {
                _attachementId = value;
                lbAttachmentID.Text = value;


            }

        }
        public void imageBoxOffFileShow(string url)
        {
            attachmentPicturebox.Visible = false;
            btnFile.Visible = true;
            lbFileName.Text = url;
        }
        public string getNewAttachmentText()
        {
            return attachmentNameTextBox.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (lbFileName.Text != "")
            {
                if (directchoosedlg.ShowDialog() == DialogResult.OK)
                {
                    folderPath = directchoosedlg.SelectedPath;
                    Uri uri = new Uri(lbFileName.Text);
                    //string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
                    client.DownloadFileAsync(uri, folderPath + "/" + attachmentNameTextBox.Text);
                }
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

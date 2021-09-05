using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class FileUserControl : UserControl
    {
        public FileUserControl()
        {
            InitializeComponent();
            client = new WebClient();
            originalHeight = this.Height;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }
        private int originalHeight;
        private string _fileName;
        private string _fileSizeInKb;
        private string _fileViewLink;
        private string _fileDownloadLink;
        WebClient client;
        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; lbFileName.Text =  value; }
        }
        public string fileViewLink
        {
            get { return _fileViewLink; }
            set { _fileViewLink = value; lbFileViewLink.Text =  value; }
        }
        public string fileDownloadLink
        {
            get { return _fileDownloadLink; }
            set { _fileDownloadLink = value; lbFileDownloadLink.Text =  value; }
        }
        public string fileSize
        {
            get { return _fileSizeInKb; }
            set { _fileSizeInKb = value; lbFileSizeInKb.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + " কিলোবাইট"; }
        }

        private void btnFileDownload_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (lbFileDownloadLink.Text!="")
            {
                if (directchoosedlg.ShowDialog() == DialogResult.OK)
                {
                    folderPath = directchoosedlg.SelectedPath;
                    Uri uri = new Uri(lbFileDownloadLink.Text);
                    //string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
                    client.DownloadFileAsync(uri, folderPath + "/" + _fileName);
                }
            }

            
        }
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download complete !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar.Value = e.ProgressPercentage;
        }
        public void docExtension()
        {
            btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.FileWord;
            lbFileName.Cursor = default;
            lbFileSizeInKb.Cursor = default;
        }
        public void csvExtension()
        {
            btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            lbFileName.Cursor = default;
            lbFileSizeInKb.Cursor = default;
        }
        public void mp4Extension()
        {
            //btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            lbFileName.Cursor = default;
            lbFileSizeInKb.Cursor = default;
        }
        public void pdfExtension()
        {
            btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            //lbFileName.Cursor = default;
            //lbFileSizeInKb.Cursor = default;
        }
        public void xlsExtension()
        {
            btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            lbFileName.Cursor = default;
            lbFileSizeInKb.Cursor = default;
        }
        public static readonly List<string> DOCExtensions = new List<string> { ".DOC", "DOC", ".DOCX", "DOCX", ".CSV", "CSV",".XLS", "XLS", ".XLSX", "XLSX", ".MP4", "MP4" };
        private void lbFileName_Click(object sender, EventArgs e)
        {
            if (DOCExtensions.Contains(new System.IO.FileInfo(fileName).Extension.ToUpperInvariant()))
            {

            }
            else
            {
                FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
                fileViewWebBrowser.fileAddInWebBrowser(lbFileViewLink.Text, lbFileName.Text);
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

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (btnMailShare.Visible == false && btnWhatsappShare.Visible == false)
            {
                this.Height = originalHeight + btnMailShare.Height + 10;
                btnMailShare.Visible = true;
                btnWhatsappShare.Visible = true;
            }
            else
            {
                this.Height = originalHeight;
                btnMailShare.Visible = false;
                btnWhatsappShare.Visible = false;
            }
        }

        private void btnMailShare_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/?view=cm&su=" + lbFileName.Text + "&body= " + fileViewLink);

        }

        private void btnWhatsappShare_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?text=" + "বিষয়: " + lbFileName.Text + " Url: " + fileViewLink + "&body=Found this useful link for you : ");

        }
    }
}

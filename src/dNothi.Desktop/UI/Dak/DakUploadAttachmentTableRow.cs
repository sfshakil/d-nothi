﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Desktop.UI.CustomMessageBox;
using System.Net;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakUploadAttachmentTableRow : UserControl
    {
         
        private string _imageSrc;
        private string _imageDownloadLink;
        private string _imageLink;
        private long _attachmentId;
        private bool _isAllowedforMulpotro;
        public bool _isAllowedforOCR=false;
        private bool _isMulpotro;
        public string _attachmentName;
        private string _fileextension;
        private bool _isOCRVisible;
        private bool _isDeleteVisible;
        private bool _isRejectVisible;
      

       

        public DakAttachmentDTO _dakAttachment = new DakAttachmentDTO();
        internal string imageBase64String;

        public DakUploadAttachmentTableRow()
        {
            InitializeComponent();
            client = new WebClient();
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            UIDesignCommonMethod.SuccessMessage("ডাউনলোড সম্পন্ন হয়েছে");
        }
        private long _id;
        public long id { get=>_id; set=>_id=value; }

        public string imgSource{
            get{return _imageSrc; }
            set
            {
                _imageSrc = value;
                _imageSrc = value;
                if (value != "")
                {
                    attachmentLink.Image = new Bitmap(value);
                }
                else
                {
                    attachmentLink.Enabled = false;
                }
               
            }
          
        }
        public string imageLink
        {
            get { return _imageLink; }
            set
            {
                _imageLink = value;
              
           
               
            }

        }
        public string imageDownloadLink
        {
            get { return _imageDownloadLink; }
            set
            {
                _imageDownloadLink = value;



            }

        }


        public string fileexension
        {
            get { return _fileextension; }
            set
            {
                _fileextension = value;

                ShowFile(value);

            }

        }

        private void ShowFile(string value)
        {
            string extUpper = value.ToUpperInvariant();

            if(UIDesignCommonMethod.ImageExtensions.Contains(extUpper))
            {
                attachmentLink.Visible = true;
            }
            else if(UIDesignCommonMethod.PdfExtensions.Contains(extUpper))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            }
            else if (UIDesignCommonMethod.docExtension.Contains(extUpper))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileWord;
            }
            else if (UIDesignCommonMethod.CSVExtension.Contains(extUpper))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            }
            else if (UIDesignCommonMethod.TxtExtension.Contains(extUpper))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileWord;
            }
            else if (UIDesignCommonMethod.AudioExtension.Contains(extUpper))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileAudio;
            }
            else if (UIDesignCommonMethod.ExcelExtension.Contains(extUpper))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            }
            else if (UIDesignCommonMethod.PPTExtension.Contains(extUpper))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FilePowerpoint;
            }
        }

        public string attachmentName
        {
            get { return _attachmentName; }
            set
            {
                _attachmentName = value; dakUploadAttachmentNameTextBox.Text = value;
            }

        }

        public long attachmentId
        {
            get { return _attachmentId; }
            set
            {
                _attachmentId = value;
            }

        }

        public bool isAllowedforMulpotro
        {
            get { return _isAllowedforMulpotro; }
            set
            {
                _isAllowedforMulpotro = value; 
                if (value == true) { if (!dakAttachmentTableRadioButton.Visible) { dakAttachmentTableRadioButton.Visible = true;  } }
                else { dakAttachmentTableRadioButton.Visible = true; dakAttachmentTableRadioButton.Visible = false; }

            }

        }

        public bool isMulpotro
        {
            get { return _isMulpotro; }
            set
            {
                _isMulpotro = value;
                if (value == true && _isAllowedforOCR == true) { attachmentOCRButton.Visible = true; dakAttachmentTableRadioButton.Checked = true;  }
                else if (value == true) { dakAttachmentTableRadioButton.Checked = true; }
                else { dakAttachmentTableRadioButton.Checked = false; attachmentOCRButton.Visible = false; }

            }

        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler RadioButtonClick;
        public event EventHandler DeleteButtonClick;
        public event EventHandler OCRButtonClick;
       
        private void dakAttachmentTableRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(dakAttachmentTableRadioButton.Checked)
            {
                isMulpotro = true;
                if (this.RadioButtonClick != null)
                    this.RadioButtonClick(sender, e);
            }
            else
            {
                isMulpotro = false;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void attachmentLink_Click(object sender, EventArgs e)
        {
           if(_imageLink!=null)
            {
                System.Diagnostics.Process.Start(_imageLink);
            }

        }

        private void attachmentOCRButton_Click(object sender, EventArgs e)
        {
            if (this.OCRButtonClick != null)
                this.OCRButtonClick(sender, e);
        }

        private void attachmentDeleteButton_Click(object sender, EventArgs e)
        {
           
                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "আপনি কি নিশ্চিতভাবে সংযুক্তি টি মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();

            if (conditonBoxForm.Yes)
                {
                    if (this.DeleteButtonClick != null)
                    this.DeleteButtonClick(sender, e);
            }
        }

        private void dakUploadAttachmentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _attachmentName = dakUploadAttachmentNameTextBox.Text;
        }

        private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(203, 225, 248)), e.CellBounds);
        }
        WebClient client;
        private void btnFile_Click(object sender, EventArgs e)
        {
            
                string folderPath = "";
                FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
                if (_imageDownloadLink != "")
                {
                    if (directchoosedlg.ShowDialog() == DialogResult.OK)
                    {
                        folderPath = directchoosedlg.SelectedPath;
                        Uri uri = new Uri(_imageDownloadLink);
                        //string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
                        client.DownloadFileAsync(uri, folderPath + "/" + dakUploadAttachmentNameTextBox.Text);
                    }
                }
            
        }
    }
}

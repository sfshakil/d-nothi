﻿using dNothi.JsonParser.Entity.Dak;
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
            originalHeight = this.Height;
        }
        private int originalHeight;
        private string _decisionText;
        private string _shongjuktiURL;
        private string _shongjuktiDownloadURL;
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
        public string shongjuktiDownloadURL
        {
            get { return _shongjuktiDownloadURL; }
            set { _shongjuktiDownloadURL = value; }
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
                UIDesignCommonMethod.CalPopUpWindow(fileViewWebBrowser,this);
            }
            else if (_potakaURL != null)
            {
                FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
                fileViewWebBrowser.fileAddInWebBrowser(_potakaURL, _decisionText);
                UIDesignCommonMethod.CalPopUpWindow(fileViewWebBrowser,this);
            }
        }
        
        public event EventHandler VisibleDownloadAndShareButton;
        private void panel3_MouseHover(object sender, EventArgs e)
        {
            if (this.VisibleDownloadAndShareButton != null)
            {
                //this.PotakaAddButton(sender, e);
                btnDownload.Visible = true;
                btnShare.Visible = true;
            }
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            btnDownload.Visible = false;
            btnShare.Visible = false;
            this.Height = originalHeight;
            btnMailShare.Visible = false;
            btnWhatsappShare.Visible = false;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(shongjuktiDownloadURL);

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
            System.Diagnostics.Process.Start("https://mail.google.com/mail/?view=cm&su=" + lbDecisionText.Text + "&body= " + shongjuktiURL);
        }

        private void btnWhatsappShare_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?text=" + "বিষয়: " + lbDecisionText.Text + " Url: " + shongjuktiURL + "&body=Found this useful link for you : ");
        }
    }
}

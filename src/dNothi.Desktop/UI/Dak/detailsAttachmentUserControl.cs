using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Utility;
using System.Net;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DetailsAttachmentUserControl : UserControl
    {
        public DetailsAttachmentUserControl()
        {
            InitializeComponent();
        }
        private string _attachmentName;
        private int _mainattachment;
        private double _attachmentsize;
        private string _attachmentdownload;
       
        private string _attachmenttype;
        private string _attachmentlink;
        private long _attachmentid;

        public List<DakAttachmentDTO> _dakAttachmentDTOs { get; set; }
        public List<DakAttachmentDTO> dakAttachmentDTOs { get { return _dakAttachmentDTOs; } set { _dakAttachmentDTOs = value; } }




        public DakAttachmentDTO _dakAttachmentDTO { get; set; }
        public DakAttachmentDTO dakAttachmentDTO
        {
            get { return _dakAttachmentDTO; }
            set
            {
                _dakAttachmentDTO = value;
            }
        }

                private void attachmentLink_Click(object sender, EventArgs e)
        {
           
        }
        public int mainattachment
        {
            get { return _mainattachment; }
            set { _mainattachment = value; if (value == 1) { mainAttachmentIconPanel.Visible = true; } else { mainAttachmentIconPanel.Visible = false; } }
        }

        public string attachmentName
        {
            get { return _attachmentName; }
            set { _attachmentName = value;  attachmentNameLabel.Text = value;}
        }
        public double attachmentsize
        {
            get { return _attachmentsize; }
            set { _attachmentsize = value;

              if(value==0)
                {
                    attachmentSizeLabel.Visible = false;
                   // attachmentNameLabel.Padding = new Padding(0,10,0,0);
                }
                else
                {
                    try
                    {
                        string part1 = value.ToString().Substring(0, value.ToString().IndexOf('.'));
                        string part2 = ".";

                        string part3 = value.ToString().Substring(value.ToString().IndexOf('.') + 1);

                        string part1Bangla = string.Concat(part1.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        //string part2Bangla = string.Concat(part2.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        string part3Bangla = string.Concat(part3.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        attachmentSizeLabel.Text = part1Bangla + part2 + part3Bangla + " KB";



                    }


                    catch
                    {
                        attachmentSizeLabel.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + " KB";
                    }
                }

            }
        }
        public string attachmentlink
        {
            get { return _attachmentlink; }
            set { _attachmentlink = value; 
            
            if(value =="")
                {
                    attachmentNameLabel.LinkColor = Color.Gray;
                }
            }
        }
        public string attachmentdownload
        {
            get { return _attachmentdownload; }
            set { _attachmentdownload = value; if (_attachmentdownload == null) { downloadButton.Visible = false; shareButton.Visible = false; } }
        }

        public long attachmentid
        {
            get { return _attachmentid; }
            set { _attachmentid = value; }
        }

        public string attachmenttype
        {



            get { return _attachmenttype; }
            set
            {
                _attachmenttype = value;

                DakAttachmentTypeIconList dakAttachmentTypeIconList = new DakAttachmentTypeIconList();
                string icon = dakAttachmentTypeIconList.GetDakAttachmentTypeIcon(value);

                attchmentTypePanel.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);

               






            }
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();
            Screen scr = Screen.FromPoint(this.Location);

            hideform.BackColor = Color.Black;
            hideform.Width=scr.WorkingArea.Width;
            hideform.Height=scr.WorkingArea.Height;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            
        }
        private void attachmentNameLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();
            attachmentViewPopUpForm.dakAttachmentDTO = _dakAttachmentDTO;
            attachmentViewPopUpForm.dakAttachmentDTOs = _dakAttachmentDTOs;
            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(_dakAttachmentDTO, _dakAttachmentDTOs); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(_dakAttachmentDTO, _dakAttachmentDTOs); };

            CalPopUpWindow(attachmentViewPopUpForm);
        }

        private void Next(DakAttachmentDTO dakAttachmentDTO, List<DakAttachmentDTO> dakAttachmentDTOs)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();

            attachmentViewPopUpForm.dakAttachmentDTOs = dakAttachmentDTOs;
         
            
            if (_dakAttachmentDTOs != null)
            {
                for (int i = 0; i <= _dakAttachmentDTOs.Count - 1; i++)
                {
                    if (_dakAttachmentDTOs[i].attachment_id == dakAttachmentDTO.attachment_id)
                    {
                        if (i == _dakAttachmentDTOs.Count - 1)
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = _dakAttachmentDTOs[0];
                        }
                        else
                        {

                            attachmentViewPopUpForm.dakAttachmentDTO = _dakAttachmentDTOs[i + 1];
                        }
                        break;
                    }
                }
            }

            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };

            CalPopUpWindow(attachmentViewPopUpForm);

        }

        private void Previous(DakAttachmentDTO dakAttachmentDTO, List<DakAttachmentDTO> dakAttachmentDTOs)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();
           
            attachmentViewPopUpForm.dakAttachmentDTOs = dakAttachmentDTOs;
          
            if (dakAttachmentDTOs != null)
            {
                for (int i = dakAttachmentDTOs.Count - 1; i >= 0; i--)
                {
                    if (dakAttachmentDTOs[i].attachment_id == dakAttachmentDTO.attachment_id)
                    {
                        if (i == 0)
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[_dakAttachmentDTOs.Count - 1];
                        }

                        else
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[i - 1];
                        }
                        break;
                    }
                }
            }

            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };

            CalPopUpWindow(attachmentViewPopUpForm);
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            //using (var client = new WebClient())
            //{
            //    client.DownloadFile(_attachmentdownload, _attachmentName);
            //}
            System.Diagnostics.Process.Start(_attachmentdownload);
           
        }
    }
}

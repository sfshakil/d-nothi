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
        private int _attachmentid;



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

                try
                {
                    string part1 = value.ToString().Substring(0, value.ToString().IndexOf('.'));
                    string part2 = ".";
                    
                    string part3 = value.ToString().Substring(value.ToString().IndexOf('.')+1);

                    string part1Bangla = string.Concat(part1.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    //string part2Bangla = string.Concat(part2.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    string part3Bangla = string.Concat(part3.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    attachmentSizeLabel.Text = part1Bangla+part2+part3Bangla + " KB";
                
                }

                
                catch
                {
                        attachmentSizeLabel.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')))+" KB"; }
                }
               
        }

        public string attachmentdownload
        {
            get { return _attachmentdownload; }
            set { _attachmentdownload = value; }
        }

        public int attachmentid
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


    }
}

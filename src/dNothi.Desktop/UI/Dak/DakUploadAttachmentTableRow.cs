using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakUploadAttachmentTableRow : UserControl
    {


        private string _imageSrc;
        private string _imageLink;
        private long _attachmentId;
        private bool _isAllowedforMulpotro;
        private bool _isMulpotro;
        private string _attachmentName;
        private bool _isOCRVisible;
        private bool _isDeleteVisible;
        private bool _isRejectVisible;

        public DakUploadAttachmentTableRow()
        {
            InitializeComponent();
        }


        public string imgSource{
            get{return _imageSrc; }
            set
            {
                _imageSrc = value;
                try
                {
                    attachmentLink.Load(value);
                }
                catch(Exception Ex)
                {
                    attachmentLink.Text = Ex.ToString();
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
      
        public string attachmentName
        {
            get { return _attachmentName; }
            set
            {
                _attachmentName = value; dakUploadAttachmentNameLabel.Text= value;
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
                if (value == true) { dakAttachmentTableRadioButton.Visible = true; }
                else { dakAttachmentTableRadioButton.Visible = false; }

            }

        }

        public bool isMulpotro
        {
            get { return _isMulpotro; }
            set
            {
                _isMulpotro = value;
                if (value == true) {attachmentOCRButton.Visible = true; }
                else { dakAttachmentTableRadioButton.Checked = false; attachmentOCRButton.Visible = false; }

            }

        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler RadioButtonClick;
       
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

        }

        private void attachmentLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_imageLink);
        }
    }
}

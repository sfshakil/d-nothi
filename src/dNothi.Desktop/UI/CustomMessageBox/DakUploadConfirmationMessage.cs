using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace dNothi.Desktop.UI.CustomMessageBox
{
    public partial class DakUploadConfirmationMessage : Form
    {
        public DakUploadConfirmationMessage()
        {
           

            InitializeComponent();
        }

        public bool isDaptorik { 
            set {
                if (value)
                {
                    dakTypeHeaderLabel.Text = "দাপ্তরিক আবেদনের রশিদ";
                    dakTypeBodyHeaderLabel.Text = "দাপ্তরিক আবেদনের রশিদ";
                }
                else
                {
                    dakTypeHeaderLabel.Text = "নাগরিক আবেদনের রশিদ";
                    dakTypeBodyHeaderLabel.Text = "নাগরিক আবেদনের রশিদ";
                }
            } 
        }
        public string _imageBase64;
        public string imageBase64
        {
            get { return _imageBase64; }
            set
            {
                _imageBase64 = value;
                byte[] bytes = Convert.FromBase64String(value);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    signPictureBox.Image = Image.FromStream(ms);
                }
            }
        }


        public string _companyName;
        public string companyName { get { return _companyName; } set { _companyName = value; companyNameLabel.Text = value; } }





        public string _companyWithUnitName;
        public string companyWithUnitName { get { return _companyWithUnitName; } set { _companyWithUnitName = value; userCompanyLabel.Text = value; } }

        
        public string _applicationNo;
        public string applicationNo { get { return _applicationNo; } set { _applicationNo = value; applicationNoLabel.Text = value; } }

        
        public string _subject;
        public string subject { get { return _subject; } set { _subject = value; subLabel.Text = value; } }

       
        public string _prerokName;
        public string prerokName { get { return _prerokName; } set { _prerokName = value; prerokNameLabel.Text = value; } }

        public string _prapokName;
        public string prapokName { get { return _prapokName; } set { _prapokName = value; prapokNameLabel.Text = value; } }
       
        public string _date;
        public string date { get { return _date; } set { _date = value; dateLabel.Text = value; } }

        public string _userName;
        public string userName { get { return _userName; } set { _userName = value; userNameLabel.Text = value; } }

        
        public string _userDept;
        public string userDept { get { return _userDept; } set { _userDept = value; userDeptLabel.Text = value; } }

        


        private void fullBodyTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bodyTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DakUploadConfirmationMessage_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Width = scr.WorkingArea.Width - 200;
            this.Height = scr.WorkingArea.Height - 200;
            this.Location  = new Point(100, 100);

            SetDefaultFont(this.Controls);
        }

        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }
    }
}

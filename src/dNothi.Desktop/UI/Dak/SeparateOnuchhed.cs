using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Nothi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class SeparateOnuchhed : UserControl
    {
        private int originalWidth;
        private int originalHeight;
        public SeparateOnuchhed()
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            SetDefaultFont(this.Controls);
        }

        private string _createDate;
        private string _office;
        private string _subjectBrowser;
        private int _onucchedId;
        public void loadinLocal()
        {
            btnSchedule.Visible = true;
            btnDelete.Visible = false;
        }
        public void lastopenOnuchhed()
        {
            if (SubjectBrowser.DocumentText != "" && SignatureFLP.Controls.Count > 0)
            {
                this.Height = 400 + originalHeight;
                this.Width = originalWidth;
            }
            else
            {

                this.Height = 174 + originalHeight;
                this.Width = originalWidth;
            }
            topPnl.Visible = true;
            middlePnl.Visible = true;
            SignatureFLP.Visible = true;
            SubjectBrowser.Visible = true;
            btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
        }

        [Category("Custom Props")]
        public string office
        {
            get { return _office; }
            set { _office = value; lbOffice.Text = "("+value+")"; }
        }
        public int onucchedId
        {
            get { return _onucchedId; }
            set { _onucchedId = value; lbonucchedId.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public string createDate
        {
            get { return _createDate; }
            set { _createDate = value; lbCreateDate.Text = "("+value+")"; }
        }
        [Category("Custom Props")]
        public string subjectBrowser
        {
            get { return _subjectBrowser; }
            set { _subjectBrowser = value; SubjectBrowser.DocumentText = value; }
        }

        [Category("Custom Props")]
        public void noteNo(string int1,string int2)
        {
            int2 = string.Concat(int2.ToString().Select(c => (char)('\u09E6' + c - '0')));
            lbNoteNo.Text = int1 + '.'+ int2;
            lbOnucchedNo.Text = int1 + '.' + int2;
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

        private void btnPlusSquare_Click(object sender, EventArgs e)
        {
            if (btnPlusSquare.IconChar == FontAwesome.Sharp.IconChar.PlusSquare)
            {
                if(SubjectBrowser.DocumentText != "" && SignatureFLP.Controls.Count > 0)
                {
                    this.Height = 400 + originalHeight;
                    this.Width = originalWidth;
                }
                else
                {

                    this.Height = 174 + originalHeight;
                    this.Width = originalWidth;
                }
                topPnl.Visible = true;
                middlePnl.Visible = true;
                SignatureFLP.Visible = true;
                SubjectBrowser.Visible = true;
                btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
                
                //loadnewAllNoteFlowLayoutPanel();
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                topPnl.Visible = false;
                middlePnl.Visible = false;
                SignatureFLP.Visible = false;
                SubjectBrowser.Visible = false;

                btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
                
            }
        }
        public void loadOnuchhedSignature(SingleOnucchedRecordSignatureDTO singleRecSignature)
        {
            if(singleRecSignature.Signature1 != null || singleRecSignature.Signature2 != null || singleRecSignature.Signature3 != null || singleRecSignature.Signature4 != null)
            {
                var onucchedSignature = UserControlFactory.Create<OnucchedSignature>();
                if (singleRecSignature.Signature1 != null)
                {

                    onucchedSignature.showSignature1element();
                    onucchedSignature.SignatureDate1 = singleRecSignature.Signature1.signature_date;
                    onucchedSignature.EmployeeName1 = singleRecSignature.Signature1.employee_name;
                    onucchedSignature.EmployeeDesignation1 = singleRecSignature.Signature1.employee_designation;
                    if (singleRecSignature.Signature1.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature1.encode_sign.Substring(singleRecSignature.Signature1.encode_sign.IndexOf(",") + 1);
                        onucchedSignature.pbSign1 = Convert.FromBase64String(str);
                    }
                    

                }
                if (singleRecSignature.Signature2 != null)
                {
                    onucchedSignature.showSignature2element();
                    onucchedSignature.SignatureDate2 = singleRecSignature.Signature2.signature_date;
                    onucchedSignature.EmployeeName2 = singleRecSignature.Signature2.employee_name;
                    onucchedSignature.EmployeeDesignation2 = singleRecSignature.Signature2.employee_designation;
                    if (singleRecSignature.Signature2.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature2.encode_sign.Substring(singleRecSignature.Signature2.encode_sign.IndexOf(",") + 1);
                        onucchedSignature.pbSign2 = Convert.FromBase64String(str);
                    }
                }
                if (singleRecSignature.Signature3 != null)
                {
                    onucchedSignature.showSignature3element();
                    onucchedSignature.SignatureDate3 = singleRecSignature.Signature3.signature_date;
                    onucchedSignature.EmployeeName3 = singleRecSignature.Signature3.employee_name;
                    onucchedSignature.EmployeeDesignation3 = singleRecSignature.Signature3.employee_designation;
                    if (singleRecSignature.Signature3.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature3.encode_sign.Substring(singleRecSignature.Signature3.encode_sign.IndexOf(",") + 1);
                        onucchedSignature.pbSign3 = Convert.FromBase64String(str);
                    }
                    
                }
                if (singleRecSignature.Signature4 != null)
                {
                    onucchedSignature.showSignature4element();
                    onucchedSignature.SignatureDate4 = singleRecSignature.Signature4.signature_date;
                    onucchedSignature.EmployeeName4 = singleRecSignature.Signature4.employee_name;
                    onucchedSignature.EmployeeDesignation4 = singleRecSignature.Signature4.employee_designation;
                    if (singleRecSignature.Signature4.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature4.encode_sign.Substring(singleRecSignature.Signature4.encode_sign.IndexOf(",") + 1);
                        onucchedSignature.pbSign4 = Convert.FromBase64String(str);
                    }
                    
                }
                //SignatureFLP.Controls.Add(onucchedSignature);
                UIDesignCommonMethod.AddRowinTable(SignatureFLP, onucchedSignature);
            }
            

        }

        private void onuchhedheaderPnl_MouseHover(object sender, EventArgs e)
        {
            if (btnSchedule.Visible==true)
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
            }
            
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                btnDelete.IconColor = Color.Red;
            }
            
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.IconColor = Color.FromArgb(54, 153, 255);
            }
        }
        public event EventHandler DeleteButtonClick;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "আপনি অনুচ্ছেদটি মুছে ফেলতে চান?";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            if (conditonBoxForm.Yes)
            {
                if (this.DeleteButtonClick != null)
                    this.DeleteButtonClick(onucchedId, e);
            }
            
        }

        private void onuchhedheaderPnl_MouseLeave(object sender, EventArgs e)
        {
            //btnDelete.Visible = false;
        }
    }
}

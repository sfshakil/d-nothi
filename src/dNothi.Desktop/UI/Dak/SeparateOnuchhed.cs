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

        [Category("Custom Props")]
        public string office
        {
            get { return _office; }
            set { _office = value; lbOffice.Text = "("+value+")"; }
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
                this.Height = 400 + originalHeight;
                this.Width = originalWidth;
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
            if(singleRecSignature.Signature1 != null)
            {
                
                var onucchedSignature = UserControlFactory.Create<OnucchedSignature>();
                onucchedSignature.showSignature1element();
                onucchedSignature.SignatureDate1 = singleRecSignature.Signature1.signature_date;
                onucchedSignature.EmployeeName1 = singleRecSignature.Signature1.employee_name;
                onucchedSignature.EmployeeDesignation1 = singleRecSignature.Signature1.employee_designation;
                SignatureFLP.Controls.Add(onucchedSignature);
            }
            
        }
    }
}

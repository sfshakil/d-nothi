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

namespace dNothi.Desktop.UI.Dak
{
    public partial class OnucchedSignature : UserControl
    {
        public OnucchedSignature()
        {
            InitializeComponent();

            SetDefaultFont(this.Controls);
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
        private string _employeeName1;
        private string _signatureDate1;
        private string _employeeDesignation1;
        private byte[] _pbSign1;

        [Category("Custom Props")]
        public string SignatureDate1
        {
            get { return _signatureDate1; }
            set { _signatureDate1 = value; lbSignatureDate1.Text = "(" + value + ")";
                int lbSignatureDate1x = (panel7.Size.Width - lbSignatureDate1.Size.Width) / 2;
                lbSignatureDate1.Location = new Point(lbSignatureDate1x, lbSignatureDate1.Location.Y);
            }
        }
        [Category("Custom Props")]
        public byte[] pbSign1
        {
            get { return _pbSign1; }
            set { _pbSign1 = value;

                using (MemoryStream ms = new MemoryStream(value))
                {
                    pbSignature1.Image = Image.FromStream(ms)
;
                }
            }
        }
        [Category("Custom Props")]
        public string EmployeeName1
        {
            get { return _employeeName1; }
            set { _employeeName1 = value; lbEmployeeName1.Text = "(" + value + ")";
                int lbEmployeeName1x = (panel8.Size.Width - lbEmployeeName1.Size.Width) / 2;
                lbEmployeeName1.Location = new Point(lbEmployeeName1x, lbEmployeeName1.Location.Y);
            }

        }
        [Category("Custom Props")]
        public string EmployeeDesignation1
        {
            get { return _employeeDesignation1; }
            set { _employeeDesignation1 = value; lbEmployeeDesignation1.Text = value;
                int lbEmployeeDesignation1x = (panel9.Size.Width - lbEmployeeDesignation1.Size.Width) / 2;
                lbEmployeeDesignation1.Location = new Point(lbEmployeeDesignation1x, lbEmployeeDesignation1.Location.Y);
            }
        }

        private string _employeeName2;
        private string _signatureDate2;
        private string _employeeDesignation2;
        private byte[] _pbSign2;

        [Category("Custom Props")]
        public string SignatureDate2
        {
            get { return _signatureDate2; }
            set { _signatureDate2 = value; lbSignatureDate2.Text = "(" + value + ")"; 
                int lbSignatureDate1x = (panel7.Size.Width - lbSignatureDate2.Size.Width) / 2;
                lbSignatureDate2.Location = new Point(lbSignatureDate1x, lbSignatureDate2.Location.Y);
            }
        }
        [Category("Custom Props")]
        public byte[] pbSign2
        {
            get { return _pbSign2; }
            set { _pbSign2 = value;

                using (MemoryStream ms = new MemoryStream(value))
                {
                    pbSignature2.Image = Image.FromStream(ms)
;
                }
            }
        }
        [Category("Custom Props")]
        public string EmployeeName2
        {
            get { return _employeeName2; }
            set { _employeeName2 = value; lbEmployeeName2.Text = "(" + value + ")";
                int lbEmployeeName1x = (panel8.Size.Width - lbEmployeeName2.Size.Width) / 2;
                lbEmployeeName2.Location = new Point(lbEmployeeName1x, lbEmployeeName2.Location.Y);
            }
        }
        [Category("Custom Props")]
        public string EmployeeDesignation2
        {
            get { return _employeeDesignation2; }
            set { _employeeDesignation2 = value; lbEmployeeDesignation2.Text = value;
                int lbEmployeeDesignation1x = (panel9.Size.Width - lbEmployeeDesignation2.Size.Width) / 2;
                lbEmployeeDesignation2.Location = new Point(lbEmployeeDesignation1x, lbEmployeeDesignation2.Location.Y);
            }
        }

        private string _employeeName3;
        private string _signatureDate3;
        private string _employeeDesignation3;
        private byte[] _pbSign3;

        [Category("Custom Props")]
        public string SignatureDate3
        {
            get { return _signatureDate3; }
            set { _signatureDate3 = value; lbSignatureDate3.Text = "(" + value + ")";
                int lbSignatureDate1x = (panel7.Size.Width - lbSignatureDate3.Size.Width) / 2;
                lbSignatureDate3.Location = new Point(lbSignatureDate1x, lbSignatureDate3.Location.Y);
            }
        }
        [Category("Custom Props")]
        public byte[] pbSign3
        {
            get { return _pbSign3; }
            set { _pbSign3 = value;

                using (MemoryStream ms = new MemoryStream(value))
                {
                    pbSignature3.Image = Image.FromStream(ms)
;
                }
            }
        }
        [Category("Custom Props")]
        public string EmployeeName3
        {
            get { return _employeeName3; }
            set { _employeeName3 = value; lbEmployeeName3.Text = "(" + value + ")";
                int lbEmployeeName1x = (panel8.Size.Width - lbEmployeeName3.Size.Width) / 2;
                lbEmployeeName3.Location = new Point(lbEmployeeName1x, lbEmployeeName3.Location.Y);
            }
        }
        [Category("Custom Props")]
        public string EmployeeDesignation3
        {
            get { return _employeeDesignation3; }
            set { _employeeDesignation3 = value; lbEmployeeDesignation3.Text = value;
                int lbEmployeeDesignation1x = (panel9.Size.Width - lbEmployeeDesignation3.Size.Width) / 2;
                lbEmployeeDesignation3.Location = new Point(lbEmployeeDesignation1x, lbEmployeeDesignation3.Location.Y);
            }
        }
        
        private string _employeeName4;
        private string _signatureDate4;
        private string _employeeDesignation4;
        private byte[] _pbSign4;

        [Category("Custom Props")]
        public string SignatureDate4
        {
            get { return _signatureDate4; }
            set { _signatureDate4 = value; lbSignatureDate4.Text = "(" + value + ")";
                int lbSignatureDate1x = (panel7.Size.Width - lbSignatureDate4.Size.Width) / 2;
                lbSignatureDate4.Location = new Point(lbSignatureDate1x, lbSignatureDate4.Location.Y);
            }
        }
        [Category("Custom Props")]
        public byte[] pbSign4
        {
            get { return _pbSign4; }
            set { _pbSign4 = value;

                using (MemoryStream ms = new MemoryStream(value))
                {
                    pbSignature4.Image = Image.FromStream(ms)
;
                }
            }
        }
        [Category("Custom Props")]
        public string EmployeeName4
        {
            get { return _employeeName4; }
            set { _employeeName4 = value; lbEmployeeName4.Text = "(" + value + ")";
                int lbEmployeeName1x = (panel8.Size.Width - lbEmployeeName4.Size.Width) / 2;
                lbEmployeeName4.Location = new Point(lbEmployeeName1x, lbEmployeeName4.Location.Y);
            }
        }
        [Category("Custom Props")]
        public string EmployeeDesignation4
        {
            get { return _employeeDesignation4; }
            set { _employeeDesignation4 = value; lbEmployeeDesignation4.Text = value;
                int lbEmployeeDesignation1x = (panel9.Size.Width - lbEmployeeDesignation4.Size.Width) / 2;
                lbEmployeeDesignation4.Location = new Point(lbEmployeeDesignation1x, lbEmployeeDesignation4.Location.Y);
            }
        }
        public void showSignature1element()
        {
            pbSignature1.Visible = true;
            pnlSignature1.Visible = true;
            lbSignatureDate1.Visible = true;
            lbEmployeeName1.Visible = true;
            lbEmployeeDesignation1.Visible = true;
        }
        public void showSignature2element()
        {
            pbSignature2.Visible = true;
            pnlSignature2.Visible = true;
            lbSignatureDate2.Visible = true;
            lbEmployeeName2.Visible = true;
            lbEmployeeDesignation2.Visible = true;
        }
        public void showSignature3element()
        {
            pbSignature3.Visible = true;
            pnlSignature3.Visible = true;
            lbSignatureDate3.Visible = true;
            lbEmployeeName3.Visible = true;
            lbEmployeeDesignation3.Visible = true;
        }
        public void showSignature4element()
        {
            pbSignature4.Visible = true;
            pnlSignature4.Visible = true;
            lbSignatureDate4.Visible = true;
            lbEmployeeName4.Visible = true;
            lbEmployeeDesignation4.Visible = true;
        }

    }
}

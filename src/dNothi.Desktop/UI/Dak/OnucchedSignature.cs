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
        private string _createDate;
        private string _office;
        private string _subjectBrowser;

        [Category("Custom Props")]
        public string SignatureDate1
        {
            get { return _office; }
            set { _office = value; lbSignatureDate1.Text = "(" + value + ")"; }
        }
        [Category("Custom Props")]
        public string EmployeeName1
        {
            get { return _createDate; }
            set { _createDate = value; lbEmployeeName1.Text = "(" + value + ")"; }
        }
        [Category("Custom Props")]
        public string EmployeeDesignation1
        {
            get { return _subjectBrowser; }
            set { _subjectBrowser = value; lbEmployeeDesignation1.Text = value; }
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

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
    public partial class NothiTypeList : UserControl
    {
        public NothiTypeList()
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
        private string _serialNo;
        private string _nothiSubjectType;
        private string _nothiCode;
        private string _nothiNumber;

        [Category("Custom Props")]
        public string serialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; lblSerialNo.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        [Category("Custom Props")]
        public string nothiSubjectType
        {
            get { return _nothiSubjectType; }
            set { _nothiSubjectType = value; lbNothiSubjectType.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiCode
        {
            get { return _nothiCode; }
            set { _nothiCode = value; lbNothiCode.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string nothiNumber
        {
            get { return _nothiNumber; }
            set { _nothiNumber = value; lbNothiNumber.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


    }
}

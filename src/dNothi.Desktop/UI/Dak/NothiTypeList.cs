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
        }

        private string _serialNo;
        private string _nothiSubjectType;
        private string _nothiCode;
        private string _nothiNumber;

        [Category("Custom Props")]
        public string serialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; txtSerialNo.Text = value; }
        }


        [Category("Custom Props")]
        public string nothiSubjectType
        {
            get { return _nothiSubjectType; }
            set { _nothiSubjectType = value; txtNothiSubjectType.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiCode
        {
            get { return _nothiCode; }
            set { _nothiCode = value; txtNothiCode.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiNumber
        {
            get { return _nothiNumber; }
            set { _nothiNumber = value; txtNothiNumber.Text = value; }
        }

    }
}

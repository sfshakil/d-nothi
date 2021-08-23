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
    public partial class NothiALLDecisionListRow : UserControl
    {
        public NothiALLDecisionListRow()
        {
            InitializeComponent();
        }
        private string _decision;
        private int _serialNo;

        [Category("Custom Props")]
        public string decision
        {
            get { return _decision; }
            set { _decision = value; lbDecision.Text = value; }
        }
        public int serialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; lbSerialNumber.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public void visibility_off_cbx_edit_dlt() 
        {
            cbxdecisions_employee.Visible = false;
            btnDelete.Visible = false;
            btnEdit.Visible = false;

        }
        public void visibility_on_cbx_edit_dlt() 
        {
            cbxdecisions_employee.Visible = true;
            btnDelete.Visible = true;
            btnEdit.Visible = true;

        }

        public void cbxDecisionList(int i )
        {
            if ( i == 1)
            {
                cbxdecisions_employee.Checked = true;
            }
            else
            {
                cbxdecisions_employee.Checked = false;
            }
        }
            
    }
}

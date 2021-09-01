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
        public event EventHandler NothiDecisionDeleteButton;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি নথি সিদ্ধান্ত মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                if (this.NothiDecisionDeleteButton != null)
                    this.NothiDecisionDeleteButton(sender, e);
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            subjectPanel.Visible = true;
            btnEditSave.Visible = true;
            btnEditCancel.Visible = true;
            lbDecision.Visible = false;
            txtSubjectEdit.Text = lbDecision.Text;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            subjectPanel.Visible = false;
            btnEditSave.Visible = false;
            btnEditCancel.Visible = false;
            lbDecision.Visible = true;
        }
        public event EventHandler NothiDecisionEditButton;
        private void btnEditSave_Click(object sender, EventArgs e)
        {
            RecordsDTO nothiDecisionList = new RecordsDTO();
            nothiDecisionList.decisions = txtSubjectEdit.Text;
            if (cbxdecisions_employee.Checked == true)
            {
                nothiDecisionList.decisions_employee = 1;
            }
            else
            {
                nothiDecisionList.decisions_employee = 0;
            }
            if (this.NothiDecisionEditButton != null)
                this.NothiDecisionEditButton(nothiDecisionList, e);
        }
    }
}

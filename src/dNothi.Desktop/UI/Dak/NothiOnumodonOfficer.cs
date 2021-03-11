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
    public partial class NothiOnumodonOfficer : UserControl
    {

        public string _officeName;
        public int _designationid;
        public bool _isNewAdded;
        public string _designation;
        public int _routeIndex;
        public bool _isChecked;

        public NothiOnumodonOfficer()
        {
            InitializeComponent();
        }

        public string officerName
        {
            get { return _officeName; }
            set
            {
                _officeName = value;
                officerNameLabel.Text = value;
            }

        }

        public string designation
        {
            get { return _designation; }
            set
            {
                _designation = value;
                lbDesignation.Text = value;
            }

        }

        public int designationid
        {
            get { return _designationid; }
            set
            {
                _designationid = value;

            }

        }

        public int routeIndex
        {
            get { return _routeIndex; }
            set
            {
                _routeIndex = value;

            }

        }

        public bool isNewlyAdded
        {
            get { return _isNewAdded; }
            set
            {
                _isNewAdded = value;

                if (value)
                {
                    deleteButton.Visible = true;
                }
                else

                {
                    deleteButton.Visible = false;
                }

            }

        }





        public event EventHandler DeleteButton;
        

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            isNewlyAdded = false;
            if (this.DeleteButton != null)
                this.DeleteButton(sender, e);
            this.Hide();
        }
        
        public event EventHandler UpButton;
        private void upButton_Click(object sender, EventArgs e)
        {
            if (this.UpButton != null)
                this.UpButton(sender, e);
        }
       
        public event EventHandler DownButton;
        private void downButton_Click(object sender, EventArgs e)
        {
            if (this.DownButton != null)
                this.DownButton(sender, e);
        }
       

        public void Check_Box_Show()
        {
            cbxControl.Visible = true;
            upDownPanel.Visible = false;
            deleteButton.Visible = false;


        }


        public event EventHandler CheckedButton;
        private void cbxControl_CheckedChanged(object sender, EventArgs e)
        {
            _isChecked = cbxControl.Checked;


            if (this.CheckedButton != null)
                this.CheckedButton(sender, e);
        }
    }
}

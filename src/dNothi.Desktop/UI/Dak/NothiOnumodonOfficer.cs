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
    }
}

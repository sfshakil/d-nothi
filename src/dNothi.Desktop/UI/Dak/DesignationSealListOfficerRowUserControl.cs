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
    public partial class DesignationSealListOfficerRowUserControl : UserControl
    {
        private string _officeName;

        private int _designationid;
        private bool _isNewAdded;
        public DesignationSealListOfficerRowUserControl()
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

                if(value)
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
        private void deleteButton_Click(object sender, EventArgs e)
        {
            isNewlyAdded = false;
            if (this.DeleteButton != null)
                this.DeleteButton(sender, e);
        }
    }
}

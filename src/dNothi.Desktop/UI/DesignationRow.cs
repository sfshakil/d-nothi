using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class DesignationRow : UserControl
    {
        public DesignationRow()
        {
            InitializeComponent();
            IterateControls(this.Controls);
        }
        void IterateControls(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                ctrl.Click += User_Click;
                IterateControls(ctrl.Controls);
            }

        }


        public event EventHandler User;

        private void User_Click(object sender, EventArgs e)
        {


            if (this.User != null)
                this.User(sender, e);
        }

        private string _designationLinkText;
        private int _dakTotalNumber;
        private int _nothiTotalNumber;
        public int _designationId;


        public int designationId
        {
            get
            {
                return _designationId;
            }
            set
            {
                _designationId = value;
               
            }
        }
        public string designationLinkText
        {
            get
            {
                return _designationLinkText;
            }
            set
            {
                _designationLinkText = value;
                linkLabel.Text = value;
            }
        }

        public int dakTotalNumber
        {
            get
            {
                return _dakTotalNumber;
            }
            set
            {
                _dakTotalNumber = value;
                dakCountButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + " টি ডাক";
            }
        }
        public int nothiTotalNumber
        {
            get
            {
                return _nothiTotalNumber;
            }
            set
            {
                _nothiTotalNumber = value;
                nothiCountButton.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + " টি নথি";
            }
        }
    }
}

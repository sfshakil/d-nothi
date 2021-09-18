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
    public partial class Reviewer : UserControl
    {
        public Reviewer()
        {
            InitializeComponent();
        }
        private string _officerName;
        private string _officerDesignation;
        public string officerName
        {
            get { return _officerName; }
            set { _officerName = value;  lbOfficerName.Text = value; }
        }
        public string officerDesignation
        {
            get { return _officerDesignation; }
            set { _officerDesignation = value;  lbOfficerDesignation.Text = value; }
        }
    }
}

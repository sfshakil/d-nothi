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
    public partial class DakBoxSharedOfficerRowUserControl : UserControl
    {
        public DakBoxSharedOfficerRowUserControl()
        {
            InitializeComponent();
        }
        public string _officerName { get; set; }
        public string officerName { get { return _officerName; } set { _officerName = value; officerNameLabel.Text = value; } }

       


        public string _designation { get; set; }
        public string designation { get { return _designation; } set { _designation = value; designationLabel.Text = value; } }

        public int _designationId { get; set; }
        public int designationId { get { return _designationId; } set { _designationId = value; } }


        public string _officeName { get; set; }
        public string officeName { get { return _officeName; } set { _officeName = value; officeUnitLabel.Text = value; } }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

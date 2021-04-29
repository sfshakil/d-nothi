using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI
{
    public partial class OfficerRowUserControl : UserControl
    {
        public OfficerRowUserControl()
        {
            InitializeComponent();
        }
        public bool Hide { get; set; }
        public int _designationId { get; set; }
        public int designationId { get {return _designationId ; } set { _designationId=value; } }



        public string _officerName { get; set; }
        public string officerName { get { return _officerName; } set { _officerName = value; officerNameLabel.Text = value; } }
        public PrapokDTO _officerInfo { get; set; }
        public PrapokDTO officerInfo { get { return _officerInfo; } set { _officerInfo = value; } }




        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);

        }
        public event EventHandler DeleteButton;

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Hide = true;
            if (this.DeleteButton != null)
                this.DeleteButton(sender, e);
                this.Hide();
        }
    }
}

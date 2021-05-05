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


        public void InvisibleUpDown()
        {
            upDownPanel.Visible = false;
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

        private void OfficerRowUserControl_Paint(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Gray(sender, e);
        }

        private void OfficerRowUserControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TableLayoutPanel))) e.Effect = DragDropEffects.Move;
        }

        private void OfficerRowUserControl_DragDrop(object sender, DragEventArgs e)
        {
            var tlp = (TableLayoutPanel)e.Data.GetData(typeof(TableLayoutPanel));
            tlp.Location = this.PointToClient(new Point(e.X, e.Y));
            tlp.Parent = this;
            tlp.BringToFront();
        }
    }
}

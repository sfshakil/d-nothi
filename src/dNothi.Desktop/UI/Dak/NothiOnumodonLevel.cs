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
    public partial class NothiOnumodonLevel : UserControl
    {
        public int _designationId;

        public List<int> _designationIds;
        public NothiOnumodonLevel()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }



        private string _level;
        public int _layerIndex;
        private string _name;
        private string _designation;
        public bool _checked;
       
        public bool checkedBox { 
            get
            { return _checked; } 
           set { _checked = value;
            if(value)
                {
                    cbxNiontron.Checked = true;
                }
            else
                {
                    cbxNiontron.Checked = false;
                }
            
            }
        }

        public int layerIndex
        {
            get { return _layerIndex; }
            set { _layerIndex = value; }
        }

        public void uncheck()
        {
            this.Hide();
        }
        [Category("Custom Props")]
        public string level
        {
            get { return _level; }
            set { _level = value;lbLevel.Text = "লেভেল "+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

       
        public void AddNewOfficer( string officerName, int designationId, string designation)
        {



            NothiOnumodonOfficer nothiOnumodonOfficer = new NothiOnumodonOfficer();


            nothiOnumodonOfficer.officerName = officerName;
            nothiOnumodonOfficer.designation = designation;
            nothiOnumodonOfficer.designationid = designationId;
            nothiOnumodonOfficer.DeleteButton += delegate (object sender, EventArgs e) { deleteButton_Click(sender, e, nothiOnumodonOfficer._designationid); };



            //nothiOnumodonOfficer.Dock = DockStyle.Fill;

            //int row = this.officerTableLayoutPanel.RowCount++;

            //officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            //if (row == 1)
            //{
            //    row = officerTableLayoutPanel.RowCount++;
            //    officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            //}
            // officerTableLayoutPanel.Controls.Add(nothiOnumodonOfficer, 0, row);

            officerTableLayoutPanel.Controls.Add(nothiOnumodonOfficer);

        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler DeleteButtonClick;
        private void deleteButton_Click(object sender, EventArgs e, int id)
        {
            var nothiOfficer = officerTableLayoutPanel.Controls.OfType<NothiOnumodonOfficer>().Where(a=>a.Visible==true).ToList();
            
                _designationId = id;
            if (this.DeleteButtonClick != null)
                this.DeleteButtonClick(sender, e);
            if (nothiOfficer != null && nothiOfficer.Count==1)
            {
                if (this.DeleteLevelButtonClick != null)
                    this.DeleteLevelButtonClick(sender, e);
                this.Hide();
            }
        }
       
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler CheckboxButtonClick;
        private void cbxControl_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.CheckboxButtonClick != null)
                this.CheckboxButtonClick(sender, e);
        }

       
        public event EventHandler DeleteLevelButtonClick;
        private void deleteButton_Click(object sender, EventArgs e)
        {
           
            



            if (this.DeleteLevelButtonClick != null)
                this.DeleteLevelButtonClick(sender, e);


            this.Hide();
        }

        private void officerTableLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void officerTableLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            NothiOnumodonOfficer data = (NothiOnumodonOfficer)e.Data.GetData(typeof(NothiOnumodonOfficer));

            FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
            FlowLayoutPanel _source = (FlowLayoutPanel)data.Parent;

            if (_source != _destination)
            {
                // Add control to panel
                _destination.Controls.Add(data);
                data.Size = new Size(_destination.Width, 50);

                // Reorder
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);
                _destination.Controls.SetChildIndex(data, index);

                // Invalidate to paint!
                _destination.Invalidate();
                _source.Invalidate();
            }
            else
            {
                // Just add the control to the new panel.
                // No need to remove from the other panel,
                // this changes the Control.Parent property.
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);
                _destination.Controls.SetChildIndex(data, index);
                _destination.Invalidate();
            }
        }

        private void cbxNiontron_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

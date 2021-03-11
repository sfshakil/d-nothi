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

        public bool _isFromNothiNextStep{get;set;}

        public bool isFromNothiNextStep
        {
            get { return _isFromNothiNextStep; }
            set { _isFromNothiNextStep = value;
                if(value)
                {
                    cbxNiontron.Visible = false;
                    deleteButton.Visible = false;
                }
            
            
            }
        
        }


        public int _designationId;
        public bool _isChecked;
        public List<int> _designationIds;
        public int _selectedRouteIndex;
        public NothiOnumodonLevel()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
            this.officerTableLayoutPanel.DragEnter += new DragEventHandler(officerTableLayoutPanel_DragEnter);
            this.officerTableLayoutPanel.DragDrop += new DragEventHandler(officerTableLayoutPanel_DragDrop);

        }

        void officerTableLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            DragAndDropOfficerPanel data = (DragAndDropOfficerPanel)e.Data.GetData(typeof(DragAndDropOfficerPanel));
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
                // No need to remove from the other panel, this changes the Control.Parent property.
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);
                _destination.Controls.SetChildIndex(data, index);
                _destination.Invalidate();
            }
        }

        void officerTableLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
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

       
        public void AddNewOfficer( string officerName, int designationId, string designation, int routeIndexs)
        {
            Size s = new Size(officerTableLayoutPanel.Width, 50);
            DragAndDropOfficerPanel dragAndDropOfficerPanel;

            dragAndDropOfficerPanel = new DragAndDropOfficerPanel();
            dragAndDropOfficerPanel.Padding = new Padding(5);
            dragAndDropOfficerPanel.LeftText = "1";
            dragAndDropOfficerPanel.MainText = "47x100x5400 - 20/100";
            dragAndDropOfficerPanel.FillDegree = 20;
            dragAndDropOfficerPanel.RightText = "1";
            dragAndDropOfficerPanel.StatusText = "Raw";
            dragAndDropOfficerPanel.StatusBarColor = 0;
            dragAndDropOfficerPanel.Size = s;
            dragAndDropOfficerPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dragAndDropOfficerPanel.officerName = officerName;
            dragAndDropOfficerPanel.designation = designation;
            dragAndDropOfficerPanel.designationid = designationId;
            dragAndDropOfficerPanel.routeIndex = routeIndexs;
            dragAndDropOfficerPanel.DeleteButton += delegate (object sender, EventArgs e) { deleteButton_Click(sender, e, dragAndDropOfficerPanel._designationid); };
            dragAndDropOfficerPanel.UpButton += delegate (object sender, EventArgs e) { UpButton_Click(sender, e, dragAndDropOfficerPanel._routeIndex); };
            dragAndDropOfficerPanel.DownButton += delegate (object sender, EventArgs e) { DownButton_Click(sender, e, dragAndDropOfficerPanel._routeIndex); };
            


            // this._items.Add(pgb);
            this.officerTableLayoutPanel.Controls.Add(dragAndDropOfficerPanel);


          //  NothiOnumodonOfficer nothiOnumodonOfficer = new NothiOnumodonOfficer();


           


            //nothiOnumodonOfficer.Dock = DockStyle.Fill;

            //int row = this.officerTableLayoutPanel.RowCount++;

            //officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            //if (row == 1)
            //{
            //    row = officerTableLayoutPanel.RowCount++;
            //    officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            //}
            // officerTableLayoutPanel.Controls.Add(nothiOnumodonOfficer, 0, row);

         //   officerTableLayoutPanel.Controls.Add(nothiOnumodonOfficer);

        }

        public void AddNewOfficerFromNothiNextStep(string officerName, int designationId, string designation, int routeIndexs)
        {
            Size s = new Size(officerTableLayoutPanel.Width, 50);
            DragAndDropOfficerPanel dragAndDropOfficerPanel;

            dragAndDropOfficerPanel = new DragAndDropOfficerPanel();
            dragAndDropOfficerPanel.Padding = new Padding(5);
            dragAndDropOfficerPanel.LeftText = "1";
            dragAndDropOfficerPanel.MainText = "47x100x5400 - 20/100";
            dragAndDropOfficerPanel.FillDegree = 20;
            dragAndDropOfficerPanel.RightText = "1";
            dragAndDropOfficerPanel.StatusText = "Raw";
            dragAndDropOfficerPanel.StatusBarColor = 0;
            dragAndDropOfficerPanel.Size = s;
            dragAndDropOfficerPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dragAndDropOfficerPanel.officerName = officerName;
            dragAndDropOfficerPanel.designation = designation;
            dragAndDropOfficerPanel.designationid = designationId;
            dragAndDropOfficerPanel.routeIndex = routeIndexs;

            dragAndDropOfficerPanel.Check_Box_Show();
           

            dragAndDropOfficerPanel.CheckedButton += delegate (object sender, EventArgs e) { checkBoxButton_Click(sender, e, dragAndDropOfficerPanel._designationid,dragAndDropOfficerPanel._isChecked); };
           

            this.officerTableLayoutPanel.Controls.Add(dragAndDropOfficerPanel);


          

        }


        public event EventHandler CheckBoxButton;
        private void checkBoxButton_Click(object sender, EventArgs e, int designationid, bool isChecked)
        {
            _isChecked = isChecked;
            _designationId = designationid;


            if (this.CheckBoxButton != null)
                this.CheckBoxButton(sender, e);
        }

        public event EventHandler DownButton;
        private void DownButton_Click(object sender, EventArgs e, int routeIndex)
        {

           
            var nothiOfficerSource = officerTableLayoutPanel.Controls.OfType<DragAndDropOfficerPanel>().FirstOrDefault(a => a.Visible == true && a._routeIndex==routeIndex);
            var nothiOfficerDestination = officerTableLayoutPanel.Controls.OfType<DragAndDropOfficerPanel>().FirstOrDefault(a => a.Visible == true && a._routeIndex == routeIndex+1);



            if(nothiOfficerDestination !=null)
            {
                InterchangeOfficer(nothiOfficerSource, nothiOfficerDestination);
                _selectedRouteIndex = routeIndex;
                if (this.DownButton != null)
                    this.DownButton(sender, e);
            }
        }

        private void InterchangeOfficer(DragAndDropOfficerPanel nothiOfficerSource, DragAndDropOfficerPanel nothiOfficerDestination)
        {
            var sourceIndex = officerTableLayoutPanel.Controls.IndexOf(officerTableLayoutPanel.Controls.OfType<DragAndDropOfficerPanel>().FirstOrDefault(a => a.Visible == true && a._routeIndex == nothiOfficerSource._routeIndex));
            var destIndex = officerTableLayoutPanel.Controls.IndexOf(officerTableLayoutPanel.Controls.OfType<DragAndDropOfficerPanel>().FirstOrDefault(a => a.Visible == true && a._routeIndex == nothiOfficerDestination._routeIndex));

            int temp = nothiOfficerSource.routeIndex;

            nothiOfficerSource.routeIndex = nothiOfficerDestination._routeIndex;
            nothiOfficerDestination.routeIndex = temp;


            officerTableLayoutPanel.Controls.SetChildIndex(nothiOfficerSource, destIndex);
            officerTableLayoutPanel.Controls.SetChildIndex(nothiOfficerDestination, sourceIndex);
          
        }
        public event EventHandler UpButton;
        private void UpButton_Click(object sender, EventArgs e, int routeIndex)
        {
            var nothiOfficerSource = officerTableLayoutPanel.Controls.OfType<DragAndDropOfficerPanel>().FirstOrDefault(a => a.Visible == true && a._routeIndex == routeIndex);
            var nothiOfficerDestination = officerTableLayoutPanel.Controls.OfType<DragAndDropOfficerPanel>().FirstOrDefault(a => a.Visible == true && a._routeIndex == routeIndex - 1);



            if (nothiOfficerDestination != null)
            {
                InterchangeOfficer(nothiOfficerSource, nothiOfficerDestination);
                _selectedRouteIndex = routeIndex;
                if (this.UpButton != null)
                    this.UpButton(sender, e);
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler DeleteButtonClick;
        private void deleteButton_Click(object sender, EventArgs e, int id)
        {
            var nothiOfficer = officerTableLayoutPanel.Controls.OfType<DragAndDropOfficerPanel>().Where(a=>a.Visible==true).ToList();
            
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

       

        private void cbxNiontron_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Nothi;

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
        private string _karjodibosh;
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
        public string karjodibosh
        {
            get { return _karjodibosh; }
            set { _karjodibosh = value;
                string buildString = "";
                if (Convert.ToInt32(value) > 0)
                {
                    buildString += string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + " ";
                }
                 
                btnKarjodibosh.Text = buildString + "কার্যদিবস";
            }
        }
        public void uncheck()
        {
            this.Hide();
        }
        [Category("Custom Props")]
        public string level
        {
            get { return _level; }
            set { _level = value; lbLevel.Text = "লেভেল " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }//"লেভেল "+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

       
        public void AddNewOfficer( string officerName, int designationId, string designation, int routeIndexs, int isSignatory)
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
            dragAndDropOfficerPanel.isSignatory = isSignatory;
            dragAndDropOfficerPanel.DeleteButton += delegate (object sender, EventArgs e) { deleteButton_Click(sender, e, dragAndDropOfficerPanel._designationid); };
            dragAndDropOfficerPanel.UpButton += delegate (object sender, EventArgs e) { UpButton_Click(sender, e, dragAndDropOfficerPanel._routeIndex); };
            dragAndDropOfficerPanel.DownButton += delegate (object sender, EventArgs e) { DownButton_Click(sender, e, dragAndDropOfficerPanel._routeIndex); };
            dragAndDropOfficerPanel.CheckedSignatoryButton += delegate (object sender, EventArgs e) { SignatoryCheckbox_Changed(sender as onumodonDataRecordDTO, e); };
            


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

        public void AddNewOfficerFromNothiNextStep(string officerName, int designationId, string designation, int routeIndexs, int flag, int isSignatory)
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
            dragAndDropOfficerPanel.isSignatory = isSignatory;
            if (flag == 1)
            {
                dragAndDropOfficerPanel.Check_Box_Hide();
            }
            else
            {
                dragAndDropOfficerPanel.Check_Box_Show();
            }
            
           

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
        public event EventHandler SignatoryCheckboxChanged;
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
        private void SignatoryCheckbox_Changed(onumodonDataRecordDTO onumodonDataRecordDTO, EventArgs e)
        {
            if (this.SignatoryCheckboxChanged != null)
                this.SignatoryCheckboxChanged(onumodonDataRecordDTO, e);
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
        public event EventHandler KarjodiboshButtonClick;
        private void deleteButton_Click(object sender, EventArgs e)
        {
           
            



            if (this.DeleteLevelButtonClick != null)
                this.DeleteLevelButtonClick(sender, e);


            this.Hide();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
        public Form AttachNothiTypeListControlToForm(Control control)
        {
            Form form = new Form();

            //form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            //form.Location = new System.Drawing.Point(903, 0);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            //
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            form.TopMost = true;
            //form.Activate();
            //form.Focus();
            //form.Show();
            return form;
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.TopMost = true;
            hideform.ShowDialog();
        }
        private void btnKarjodibosh_Click(object sender, EventArgs e)
        {
            if (deleteButton.Visible)
            {
                //this.SendToBack();
                SetKarjodibosh setkarjodibosh = new SetKarjodibosh();
                setkarjodibosh.KarjodiboshSaveButtonClick += delegate (object sender1, EventArgs e1) { karjodiboshSaveButton_Click(sender1, e); };
                setkarjodibosh.Visible = true;
                //setkarjodibosh.Location = new System.Drawing.Point(0, 0);
                //Controls.Add(setkarjodibosh);
                var form = AttachNothiTypeListControlToForm(setkarjodibosh);
                CalPopUpWindow(form);
            }
        }
        private void karjodiboshSaveButton_Click(object karjodibosh, EventArgs e1)
        {
            var karjoDibosh = karjodibosh.ToString();
            string buildString = "";
            
            if (Convert.ToInt32(karjoDibosh) >0) { buildString += string.Concat(karjoDibosh.ToString().Select(c => (char)('\u09E6' + c - '0'))) + " "; }
            btnKarjodibosh.Text = buildString + "কার্যদিবস";

            if (this.KarjodiboshButtonClick != null)
                this.KarjodiboshButtonClick(karjoDibosh, e1);
        }

        private void cbxNiontron_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NothiOnumodonLevel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        
    }
}

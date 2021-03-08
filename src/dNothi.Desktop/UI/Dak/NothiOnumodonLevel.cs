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
        private int _designationId;
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

       
        public void AddNewOfficer(string officerName, int designationId, string designation)
        {

            NothiOnumodonOfficer nothiOnumodonOfficer = new NothiOnumodonOfficer();


            nothiOnumodonOfficer.officerName = officerName;
            nothiOnumodonOfficer.Name = designation;
            nothiOnumodonOfficer.designationid = designationId;
            nothiOnumodonOfficer.DeleteButton += delegate (object sender, EventArgs e) { deleteButton_Click(sender, e, nothiOnumodonOfficer._designationid); };



            nothiOnumodonOfficer.Dock = DockStyle.Fill;

            int row = this.officerTableLayoutPanel.RowCount++;

            officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            if (row == 1)
            {
                row = officerTableLayoutPanel.RowCount++;
                officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            }
            officerTableLayoutPanel.Controls.Add(nothiOnumodonOfficer, 0, row);

        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler DeleteButtonClick;
        private void deleteButton_Click(object sender, EventArgs e, int id)
        {
            _designationId = id;
            if (this.DeleteButtonClick != null)
                this.DeleteButtonClick(sender, e);

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
            
            if (this.DeleteButtonClick != null)
                this.DeleteButtonClick(sender, e);
            this.Hide();
        }
    }
}

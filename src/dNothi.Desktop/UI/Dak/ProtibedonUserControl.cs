using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.View_Model;

namespace dNothi.Desktop.UI.Dak
{
    public partial class ProtibedonUserControl : UserControl
    {
        public ProtibedonUserControl()
        {
            InitializeComponent();
        }

        public bool _isNothijato { get; set; }
        public bool isNothijato {
            get{ return _isNothijato; }
            set
            {
                _isNothijato = value;
                if(value)
                {
                    ReportingTypeTwo();
                    registerReportDataGridView.Columns["NothiJatoDate"].Visible = true;
                    headlineLabel.Text = "নথিজাত ডাকসমূহ";
                }
            }
        
        }



        public bool _isNothiteUposthapito { get; set; }
        public bool isNothiteUposthapito
        {
            get { return _isNothiteUposthapito; }
            set
            {
                _isNothiteUposthapito = value;
                if (value)
                {
                    ReportingTypeTwo();
                    registerReportDataGridView.Columns["NothiteUposthapitoDate"].Visible = true;
                    headlineLabel.Text = "নথিতে উপস্থাপিত ডাকসমূহ";
                }
            }

        }



        public bool _isPotrojari { get; set; }
        public bool isPotrojari
        {
            get { return _isPotrojari; }
            set
            {
                _isPotrojari = value;
                if (value)
                {
                    ReportingTypeTwo();
                    registerReportDataGridView.Columns["PotrojariDate"].Visible = true;
                    headlineLabel.Text = "জারিকৃত ডাকসমূহ";
                }
            }

        }


        public bool _isPending { get; set; }
        public bool _isResolved { get; set; }
      

        public bool isPending { get { return _isPending; } set { _isPending = value; if (value) { headlineLabel.Text = "অমীমাংসিত ডাকসমূহ"; } } }
        public bool isResolved { get { return _isResolved; } set { _isResolved = value; if (value) { headlineLabel.Text = "মীমাংসিত ডাকসমূহ"; } } }
        public List<Protibedon> _protibedons { get; set; }
        public List<Protibedon> protibedons
        {
            get { return _protibedons; }
            set
            {
                _protibedons = value;

                if (value.Count <= 0)
                {
                    noRowMessageLabel.Visible = true;
                }
                else
                {
                    noRowMessageLabel.Visible = false;
                }

                registerReportDataGridView.DataSource = null;
                registerReportDataGridView.DataSource = value;


                // Resize the master DataGridView columns to fit the newly loaded data.
                registerReportDataGridView.AutoResizeColumns();

                // Configure the details DataGridView so that its columns automatically
                // adjust their widths when the data changes.
                registerReportDataGridView.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.AllCells;

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);
            }


        }

        
        private void ReportingTypeTwo()
        {
            registerReportDataGridView.Columns["docketingNo"].Visible = false;
            registerReportDataGridView.Columns["mainPrapok"].Visible = false;
            registerReportDataGridView.Columns["finalState"].Visible = false;
            registerReportDataGridView.Columns["pendingTime"].Visible = false;
        }


        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void dateRangePickerShow(object sender, EventArgs e)
        {
            if (customDatePicker.Visible)
            {
                customDatePicker.Visible = false;
            }
            else
            {
                customDatePicker.Visible = true;
                //  customDatePicker.Location =new Point(datePickerTableLayoutPanel.Location.X, datePickerTableLayoutPanel.Location.Y+datePickerTableLayoutPanel.Height);

            }
        }

        private void customDatePicker_OptionClick(object sender, EventArgs e)
        {

            dateRangeTextBox.Text = customDatePicker._date;

            customDatePicker.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

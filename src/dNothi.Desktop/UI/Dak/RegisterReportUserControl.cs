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
using dNothi.Utility;

namespace dNothi.Desktop.UI.Dak
{
    public partial class RegisterReportUserControl : UserControl
    {
        public int pageLimit=10;
        public int pageNo=1;
       

        private void RefreshPagination()
        {
            

            //Pagination(0, 0);
        }

        //private void Pagination(int count, int total)
        //{



        //    pageLabel.Text = ConversionMethod.EnglishNumberToBangla(pageStartTemp.ToString()) + " - " + ConversionMethod.EnglishNumberToBangla(pageEnd.ToString());
        //    totalRowlabel.Text = "সর্বমোট: " + ConversionMethod.EnglishNumberToBangla(total.ToString());

        //    if (pageLimit <= total)
        //    {
        //        pageNextButton.Enabled = false;
        //    }
        //    else
        //    {
        //        pageNextButton.Enabled = true;
        //    }

        //    if (pageStart == 1)
        //    {
        //        pagePrevButton.Enabled = false;
        //    }
        //    else
        //    {
        //        pagePrevButton.Enabled = true;
        //    }


        //}

        public RegisterReportUserControl()
        {
            InitializeComponent();
        }


        public bool _isDakGrohon { get; set; }
        public bool _isDakDiary { get; set; }
        public bool _isDakBili { get; set; }

        public bool isDakGrohon { get {return _isDakGrohon ; } set {_isDakGrohon=value; if (value) { headlineLabel.Text = "ডাক গ্রহণ নিবন্ধন বহি"; } } }
        public bool isDakDiary { get {return _isDakDiary; } set { _isDakDiary = value; if (value) { headlineLabel.Text = "শাখা ডায়েরি নিবন্ধন বহি"; } } }
        public bool isDakBili { get {return _isDakBili; } set { _isDakBili = value; if (value) { headlineLabel.Text = "ডাক বিলি নিবন্ধন বহি"; } } }

        public List<RegisterReport> _registerReports { get; set; }
        public List<RegisterReport> registerReports {
            get { return _registerReports; }
            set
            {
                _registerReports = value;

                if(value.Count<=0)
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
                registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0,12, registerReportDataGridView.Font.Style);
            }
        
        
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

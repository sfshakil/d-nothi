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
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.Dak
{
    public partial class ProtibedonUserControl : UserControl
    {
        IProtibedonService _protibedonService { get; set; }
        IUserService _userService { get; set; }
        public ProtibedonUserControl(IProtibedonService protibedonService, IUserService userService)
        {
            InitializeComponent();
            _protibedonService = protibedonService;
            _userService = userService;
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
        private int _totalRecord { get; set; }
        public int totalRecord { get => _totalRecord;
            set { 
                _totalRecord = value; 
                totalRowlabel.Text = "সর্বমোট "+ ConversionMethod.EnglishNumberToBangla(value.ToString())+" টি";
               
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                if (value >= 20)
                {
                    int totalpage = (int)Math.Ceiling((float)value / (float)20);
                    int pageSize = 20;
                    int page = 0;
                    for (int i = 1; i <= totalpage; i++)
                    {
                        page += pageSize;
                        comboBox1.Items.Add(new ComboBoxItem(ConversionMethod.EnglishNumberToBangla(page.ToString()), i));
                    }
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.Items.Add(new ComboBoxItem("১০", 1));
                    comboBox1.Items.Add(new ComboBoxItem("২০", 2));
                    comboBox1.Items.Add(new ComboBoxItem("৩০", 3));
                    comboBox1.Items.Add(new ComboBoxItem("৪০", 4));
                    comboBox1.Items.Add(new ComboBoxItem("৫০", 5));
                    comboBox1.SelectedIndex = 0;
                }
               
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

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            List<Protibedon> protibedonlist = new List<Protibedon>();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            string name = comboBox1.Text;

            dakListUserParam.page = 1;
            dakListUserParam.limit =Convert.ToInt32( ConversionMethod.BanglaDigittoEngDigit(name));
            if (isPending)
            {
                ProtibedonResponse protibedonResponse = _protibedonService.GetPendingProtibedonResponse(dakListUserParam, null, null, null);
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }
            if(isResolved)
            {
                ProtibedonResponse protibedonResponse = _protibedonService.GetResolvedProtibedonResponse(dakListUserParam, null, null, null);
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }
            if(isNothiteUposthapito)
            {
                DakProtibedonResponse protibedonResponse = _protibedonService.GetNothiteUposthapitoProtibedonResponse(dakListUserParam, null, null, null);
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }
            if(isPotrojari)
            {
                DakProtibedonResponse protibedonResponse = _protibedonService.GetPotrojariProtibedonResponse(dakListUserParam, null, null, null);
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            
            }
            if(isNothijato)
            {
                DakProtibedonResponse protibedonResponse = _protibedonService.GetNothijatoProtibedonResponse(dakListUserParam, null, null, null);
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }
            if (protibedonlist.Count <= 0)
            {
                noRowMessageLabel.Visible = true;
            }
            else
            {
                noRowMessageLabel.Visible = false;
            }
            registerReportDataGridView.DataSource = null;
            registerReportDataGridView.DataSource = protibedonlist;


            // Resize the master DataGridView columns to fit the newly loaded data.
            registerReportDataGridView.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            registerReportDataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
            registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);

            //if (this.comboBoxSelectedIndexChanged != null)
            //{
            //    string name = comboBox1.Text;

            //   // string  ids = comboBox1.SelectedValue.ToString();
            //    int id = 1;
            //    this.comboBoxSelectedIndexChanged(name,id);
            //}

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

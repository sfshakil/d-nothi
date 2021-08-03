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
using dNothi.Services.BasicService;

namespace dNothi.Desktop.UI.Dak
{
    public partial class ProtibedonUserControl : UserControl
    {
        string fromdate, todate;
        public int pageLimit = 10;
        public int pageNo = 1;
        int page = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        int lastCountValue = 0;
        string datetextFromtextbox = string.Empty;
        public bool _isPending { get; set; }
        public bool _isResolved { get; set; }
        public bool _isNothijato { get; set; }
        public bool isNothijato
        {
            get { return _isNothijato; }
            set
            {
                _isNothijato = value;
                if (value)
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



        public List<Protibedon> _protibedons { get; set; }
        public List<Protibedon> protibedons
        {
            get { return _protibedons; }
            set
            {
                _protibedons = value;

                //    if (value.Count <= 0)
                //    {
                //        noRowMessageLabel.Visible = true;
                //    }
                //    else
                //    {
                //        noRowMessageLabel.Visible = false;
                //    }

                //    registerReportDataGridView.DataSource = null;
                //    registerReportDataGridView.DataSource = value;


                //    // Resize the master DataGridView columns to fit the newly loaded data.
                //    registerReportDataGridView.AutoResizeColumns();

                //    // Configure the details DataGridView so that its columns automatically
                //    // adjust their widths when the data changes.
                //    registerReportDataGridView.AutoSizeColumnsMode =
                //        DataGridViewAutoSizeColumnsMode.AllCells;

                //    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                //    registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);
            }


        }

        private void ReportingTypeTwo()
        {
            registerReportDataGridView.Columns["docketingNo"].Visible = false;
            registerReportDataGridView.Columns["mainPrapok"].Visible = false;
            registerReportDataGridView.Columns["finalState"].Visible = false;
            registerReportDataGridView.Columns["pendingTime"].Visible = false;
        }



        public bool isPending { get { return _isPending; } set { _isPending = value; if (value) { headlineLabel.Text = "অমীমাংসিত ডাকসমূহ"; } } }
        public bool isResolved { get { return _isResolved; } set { _isResolved = value; if (value) { headlineLabel.Text = "মীমাংসিত ডাকসমূহ"; } } }
        private int _totalRecord { get; set; }
        public int totalRecord
        {
            get => _totalRecord;
            set
            {
                _totalRecord = value;
                totalRowlabel.Text = "সর্বমোট " + ConversionMethod.EnglishNumberToBangla(value.ToString()) + " টি";

                //comboBox1.DisplayMember = "Name";
                //comboBox1.ValueMember = "Id";
                //if (value >= 20)
                //{
                //    int totalpage = (int)Math.Ceiling((float)value / (float)20);
                //    int pageSize = 20;
                //    int page = 0;
                //    for (int i = 1; i <= totalpage; i++)
                //    {
                //        page += pageSize;
                //        comboBox1.Items.Add(new ComboBoxItem(ConversionMethod.EnglishNumberToBangla(page.ToString()), i));
                //    }
                //    comboBox1.SelectedIndex = 0;
                //}
                //else
                //{
                //comboBox1.Items.Add(new ComboBoxItem("১০", 1));
                //comboBox1.Items.Add(new ComboBoxItem("২০", 2));
                //comboBox1.Items.Add(new ComboBoxItem("৩০", 3));
                //comboBox1.Items.Add(new ComboBoxItem("৪০", 4));
                //comboBox1.Items.Add(new ComboBoxItem("৫০", 5));
                //comboBox1.SelectedIndex = 0;
                // }

            }
        }
        IProtibedonService _protibedonService { get; set; }
        IUserService _userService { get; set; }
        IBasicService _basicService { get; set; }
        public ProtibedonUserControl(IProtibedonService protibedonService, IUserService userService, IBasicService basicService)
        {
            InitializeComponent();
            _protibedonService = protibedonService;
            _userService = userService;
            _basicService = basicService;
            fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
            todate = DateTime.Now.ToString("yyyy/MM/dd");
            dateTextBox.Text = fromdate + ":" + todate;

            dakPriorityComboBox.DataSource = getShaka();
            dakPriorityComboBox.DisplayMember = "Name";
            dakPriorityComboBox.ValueMember = "Id";
        }
        private List<ComboBoxItem> getList()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            ComboBoxItem data0 = new ComboBoxItem("শাখা নির্বাচন করুন", 0);
            comboBoxItems.Add(data0);

            ComboBoxItem data = new ComboBoxItem("প্রকল্প পরিচালকের", 6691);
            comboBoxItems.Add(data);
            ComboBoxItem data1 = new ComboBoxItem("পলিসি অ্যাডভাইজর", 6692);
            comboBoxItems.Add(data1);
            ComboBoxItem data2 = new ComboBoxItem("ক্যাপাসিটি ডেভেলপমেন্ট", 6699);
            comboBoxItems.Add(data2);
            ComboBoxItem data3 = new ComboBoxItem("ক্যাপাসিটি ডেভেলপমেন্ট", 6700);
            comboBoxItems.Add(data3);
            ComboBoxItem data4 = new ComboBoxItem("কমিউনিকেশন ও পার্টনারশীপ", 6707);
            comboBoxItems.Add(data4);
            ComboBoxItem data5 = new ComboBoxItem("এইচডি মিডিয়া", 6711);
            comboBoxItems.Add(data5);
            ComboBoxItem data6 = new ComboBoxItem("ই - লার্নিং", 6712);
            comboBoxItems.Add(data6);
            ComboBoxItem data7 = new ComboBoxItem("এডমিন", 6712);
            comboBoxItems.Add(data7);
            ComboBoxItem data8 = new ComboBoxItem("মনিটরিং এ্যান্ড ইভালুয়েশন", 9739);
            comboBoxItems.Add(data8);
            ComboBoxItem data9 = new ComboBoxItem("ই - সার্ভিস ", 9625);
            comboBoxItems.Add(data9);
            ComboBoxItem data10 = new ComboBoxItem("হিউম্যান রিসোর্স", 9739);
            comboBoxItems.Add(data10);
            ComboBoxItem data11 = new ComboBoxItem("ইনোভেশন -১", 9742);
            comboBoxItems.Add(data11);
            ComboBoxItem data12 = new ComboBoxItem("অবকাঠামো", 9747);
            comboBoxItems.Add(data12);
            ComboBoxItem data13 = new ComboBoxItem("টেকনোলজি", 46122);
            comboBoxItems.Add(data13);
            ComboBoxItem data14 = new ComboBoxItem("টেস্ট 111", 46180);
            comboBoxItems.Add(data14);
            return comboBoxItems;

        }

        private List<ComboBoxItem> getShaka()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            var userparam=  _userService.GetLocalDakUserParam();
            var officeUnitResponse = _basicService.GetOfficeUnitList(userparam);
            if (officeUnitResponse.status == "success")
            {
                comboBoxItems.Add(new ComboBoxItem("শাখা নির্বাচন করুন", 0));
                foreach (var item in officeUnitResponse.data)
                {
                    comboBoxItems.Add(new ComboBoxItem(item.unit_name_bng, item.unit_id));
                }
            }
            return comboBoxItems;
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

            dateTextBox.Text = customDatePicker._date;

            customDatePicker.Visible = false;
            page = 1;
            lastCountValue = 0;
            LoadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 0;
            LoadData();
            NextPreviousButtonShow();


            //List<Protibedon> protibedonlist = new List<Protibedon>();
            //DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            //string name = comboBox1.Text;
            //string dateRange = dateTextBox.Text;
            //string unit = dakPriorityComboBox.SelectedValue.ToString();
            //if (dateRange == string.Empty)
            //{
            //    fromdate = dateRange.Substring(0, dateRange.IndexOf(":"));
            //    todate = dateRange.Substring(dateRange.IndexOf(":") + 1);
            //}
            //else
            //{
            //    fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
            //    todate = DateTime.Now.ToString("yyyy/MM/dd");
            //}

            //pageLimit = Convert.ToInt32(ConversionMethod.BanglaDigittoEngDigit(name));

            //dakListUserParam.page = page;
            //dakListUserParam.limit = pageLimit;
            //if (isPending)
            //{
            //    ProtibedonResponse protibedonResponse = _protibedonService.GetPendingProtibedonResponse(dakListUserParam, fromdate, todate, unit);
            //    protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            //}
            //if(isResolved)
            //{
            //    ProtibedonResponse protibedonResponse = _protibedonService.GetResolvedProtibedonResponse(dakListUserParam, fromdate, todate, unit);
            //    protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            //}
            //if(isNothiteUposthapito)
            //{
            //    DakProtibedonResponse protibedonResponse = _protibedonService.GetNothiteUposthapitoProtibedonResponse(dakListUserParam, fromdate, todate, unit);
            //    protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            //}
            //if(isPotrojari)
            //{
            //    DakProtibedonResponse protibedonResponse = _protibedonService.GetPotrojariProtibedonResponse(dakListUserParam, fromdate, todate, unit);
            //    protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);

            //}
            //if(isNothijato)
            //{
            //    DakProtibedonResponse protibedonResponse = _protibedonService.GetNothijatoProtibedonResponse(dakListUserParam, fromdate, todate, unit);
            //    protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            //}
            //if (protibedonlist.Count <= 0)
            //{
            //    noRowMessageLabel.Visible = true;
            //}
            //else
            //{
            //    noRowMessageLabel.Visible = false;
            //}
            //registerReportDataGridView.DataSource = null;
            //registerReportDataGridView.DataSource = protibedonlist;


            //// Resize the master DataGridView columns to fit the newly loaded data.
            //registerReportDataGridView.AutoResizeColumns();

            //// Configure the details DataGridView so that its columns automatically
            //// adjust their widths when the data changes.
            //registerReportDataGridView.AutoSizeColumnsMode =
            //    DataGridViewAutoSizeColumnsMode.AllCells;

            //MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
            //registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);

            ////if (this.comboBoxSelectedIndexChanged != null)
            ////{
            ////    string name = comboBox1.Text;

            ////   // string  ids = comboBox1.SelectedValue.ToString();
            ////    int id = 1;
            ////    this.comboBoxSelectedIndexChanged(name,id);
            ////}

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            List<Protibedon> protibedonlist = new List<Protibedon>();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            string name = comboBox1.Text;
            string dateRange = dateTextBox.Text;
            string unit = dakPriorityComboBox.SelectedValue.ToString();
            if (dateRange == string.Empty)
            {
                fromdate = dateRange.Substring(0, dateRange.IndexOf(":"));
                todate = dateRange.Substring(dateRange.IndexOf(":") + 1);
            }
            else
            {
                fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
                todate = DateTime.Now.ToString("yyyy/MM/dd");
            }

            pageLimit = Convert.ToInt32(ConversionMethod.BanglaDigittoEngDigit(name));

            dakListUserParam.page = page;
            dakListUserParam.limit = pageLimit;

            if (isPending)
            {
                ProtibedonResponse protibedonResponse = _protibedonService.GetPendingProtibedonResponse(dakListUserParam, fromdate, todate, unit);
                ConvertProtibedonResponsetoProtibedon.lastCount = lastCountValue;
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }
            if (isResolved)
            {
                ProtibedonResponse protibedonResponse = _protibedonService.GetResolvedProtibedonResponse(dakListUserParam, fromdate, todate, unit);
                ConvertProtibedonResponsetoProtibedon.lastCount = lastCountValue;
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }
            if (isNothiteUposthapito)
            {
                DakProtibedonResponse protibedonResponse = _protibedonService.GetNothiteUposthapitoProtibedonResponse(dakListUserParam, fromdate, todate, unit);
                ConvertProtibedonResponsetoProtibedon.lastCount = lastCountValue;
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }
            if (isPotrojari)
            {
                DakProtibedonResponse protibedonResponse = _protibedonService.GetPotrojariProtibedonResponse(dakListUserParam, fromdate, todate, unit);
                ConvertProtibedonResponsetoProtibedon.lastCount = lastCountValue;
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);

            }
            if (isNothijato)
            {
                DakProtibedonResponse protibedonResponse = _protibedonService.GetNothijatoProtibedonResponse(dakListUserParam, fromdate, todate, unit);
                ConvertProtibedonResponsetoProtibedon.lastCount = lastCountValue;
                protibedonlist = ConvertProtibedonResponsetoProtibedon.GetProtibedons(protibedonResponse);
            }

            if (protibedonlist.Count <= 0)
            {
                noRowMessageLabel.Visible = true;
            }
            else
            {
                noRowMessageLabel.Visible = false;
                lastCountValue = protibedonlist.Max(x => x.sln);
            }

            float pagesize = (float)_totalRecord / (float)pageLimit;
            totalPage = (int)Math.Ceiling(pagesize);


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
        }
        #region Pagination
        private void NextPreviousButtonShow()
        {
            if (page < totalPage)
            {
                if (page == 1 && totalPage > 1)
                {
                    iconButton3.Enabled = false;
                }
                else
                {
                    iconButton3.Enabled = true;

                }
                iconButton4.Enabled = true;
            }
            if (page == totalPage)
            {
                if (page == 1 && totalPage == 1)
                {
                    iconButton3.Enabled = false;

                }
                else
                {
                    iconButton3.Enabled = true;

                }
                iconButton4.Enabled = false;
            }



        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            string endrow;

            if (page <= totalPage)
            {
                page += 1;
                start += pageLimit;
                end += pageLimit;

            }
            else
            {
                page = totalPage;
                start = start;
                end = end;


            }
            endrow = end.ToString();
            LoadData();


            if (totalrecord < end) { endrow = totalrecord.ToString(); }

            NextPreviousButtonShow();
        }

        private void dakPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 0;
            LoadData();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {

                page -= 1;
                start -= pageLimit;
                end -= pageLimit;
                lastCountValue -= pageLimit;

            }
            else
            {
                page = 1;
                start = start;
                end = end;

            }


            LoadData();
            //perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
            NextPreviousButtonShow();

        }

        #endregion
    }
}

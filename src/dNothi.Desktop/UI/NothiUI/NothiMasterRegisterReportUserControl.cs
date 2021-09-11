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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using dNothi.Services.NothiReportService;
using dNothi.Services.UserServices;
using dNothi.Services.BasicService;
using dNothi.Services.NothiReportService.Model;
using dNothi.Services.DakServices;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class NothiMasterRegisterReportUserControl : UserControl
    {
        string fromdate, todate;
        public int pageLimit = 1;
        public int pageNo = 1;
        int page = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        int lastCountValue = 1;
        int lastrecord = 0;
        string datetextFromtextbox = string.Empty;
        IUserService _userService { get; set; }
        INothiReportService _nothiReportService { get; set; }
        IBasicService _basicService { get; set; }
        private void RefreshPagination()
        {
            
        }

        public NothiMasterRegisterReportUserControl(IUserService userService, INothiReportService nothiReportService, IBasicService basicService)
        {
            _userService = userService;
            _nothiReportService = nothiReportService;
            _basicService = basicService;
            InitializeComponent();
            fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
            todate = DateTime.Now.ToString("yyyy/MM/dd");
            dateTextBox.Text = fromdate + ":" + todate;

            var userparam = _userService.GetLocalDakUserParam();
            dakPriorityComboBox.DataSource = getShaka(userparam);
            dakPriorityComboBox.DisplayMember = "Name";
            dakPriorityComboBox.ValueMember = "Id";
            dakPriorityComboBox.SelectedValue = userparam.office_unit_id;
        }

        private List<ComboBoxItem> getShaka(DakUserParam userparam)
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();

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
        public bool _isNothiPerito { get; set; }
        public bool _isNothiRegister { get; set; }
        public bool _isNothiGrahon { get; set; }
        public bool _isPotraJariBohi { get; set; }
        private bool _isNothiMasterFile { get; set; }

        public bool isNothiPerito { get { return _isNothiPerito; } set { _isNothiPerito = value; if (value) { headlineLabel.Text = "নথি প্রেরণ নিবন্ধন বহি"; } } }
        public bool isNothiRegister { get { return _isNothiRegister; } set { _isNothiRegister = value; if (value) { headlineLabel.Text = "নথি নিবন্ধন বহি"; } } }
        public bool isNothiGrahon { get { return _isNothiGrahon; } set { _isNothiGrahon = value; if (value) { headlineLabel.Text = "নথি গ্রহণ নিবন্ধন বহি"; } } }

        public bool isPotraJariBohi { get { return _isPotraJariBohi; } set { _isPotraJariBohi = value; if (value) { headlineLabel.Text = "পত্রজারি নিবন্ধন বহি"; } } }

        public bool isNothiMasterFile { get { return _isNothiMasterFile; } set { _isNothiMasterFile = value; if (value) { headlineLabel.Text = "মাস্টার ফাইল"; } } }

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
            lastCountValue = 1;
            LoadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //DataExportToExcel();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // DataExportToPDF(); 
           
        }
        private void LoadData()
        {
            var userParam = _userService.GetLocalDakUserParam();
            string pagessize = comboBox1.Text;
            string dateRange = dateTextBox.Text;
            string unitid = dakPriorityComboBox.SelectedValue!=null? dakPriorityComboBox.SelectedValue.ToString():string.Empty;
            if (dateRange == string.Empty)
            {
                fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
                todate = DateTime.Now.ToString("yyyy/MM/dd");
                
            }
            else
            {
                fromdate = dateRange.Substring(0, dateRange.IndexOf(":"));
                todate = dateRange.Substring(dateRange.IndexOf(":") + 1);
            }

            pageLimit = Convert.ToInt32(ConversionMethod.BanglaDigittoEngDigit(pagessize));

            userParam.page = page;
            userParam.limit = pageLimit;
          
            var nothiRegisterBook = _nothiReportService.NothiRegisterBook(userParam, fromdate, todate, unitid, _isNothiPerito, _isNothiGrahon, _isNothiRegister, _isPotraJariBohi, _isNothiMasterFile);
            if (nothiRegisterBook.status == "success")
            {
                totalRowlabel.Text = "সর্বমোট "+ ConversionMethod.EnglishNumberToBangla( nothiRegisterBook.data.total_records.ToString())+" টি";
                noRowMessageLabel.Visible = false;
                lastrecord = nothiRegisterBook.data.records.Count();
                //lastCountValue = 1;
                //int serial = 1;
             foreach(var item in nothiRegisterBook.data.records)
                {
                    fileWebBrowser.Url = new Uri(item.mulpotro.url);
                }
                //var columns = (from t in nothiRegisterBook.data.records
                //               select new
                //               {
                //                   sl = ConversionMethod.EnglishNumberToBangla((lastCountValue++).ToString()),
                //                   sub=t.potrojari.potro_subject,
                //                   mainPrapok=getPrerok(t.potrojari.recipient.sender),
                //                   sharokNo= t.potrojari.sarok_no,
                //                   applyDate=t.basic.issue_date,
                //                   previousPrapok= getPrapok(t.potrojari.recipient.receiver),
                //                   docketingNo=getOnulipi(t.potrojari.recipient.onulipi),

                //                   type=t.potrojari.potro_type==1?"অফিস স্বারক": (t.potrojari.potro_type == 2? "সরকারি পত্র" : "আধা সরকারি পত্র"),

                //               }).ToList();
                //if (columns.Count <= 0)
                //{
                //    noRowMessageLabel.Visible = true;
                //}
                //else
                //{
                //    noRowMessageLabel.Visible = false;
                //    //lastCountValue = columns.Max(x => x.lastCountValue);
                //}
                pageLimit = 1;
                float pagesize = (float)(nothiRegisterBook.data.total_records) / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
               // registerReportDataGridView.DataSource = null;
               //registerReportDataGridView.DataSource = columns.ToList();
               
               // registerReportDataGridView.AutoResizeColumns();

               // registerReportDataGridView.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;

               // MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
               // registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);
            }
            else
            {
                noRowMessageLabel.Visible = true;
            }

        }
        Bitmap bitmap;

     
       
        private void RegisterReportUserControl_Load(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 1;
           // LoadData();
            NextPreviousButtonShow();
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
                pageNextButton.Enabled = true;
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
                pageNextButton.Enabled = false;
            }



        }
        private void pageNextButton_Click(object sender, EventArgs e)
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
        private void iconButton3_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {

                page -= 1;
                start -= pageLimit;
                end -= pageLimit;
                lastCountValue -= (pageLimit+lastrecord);

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

        private void dakPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dakPriorityComboBox.SelectedValue.ToString() != "dNothi.Desktop.ComboBoxItem")
                
            {
                page = 1;
                lastCountValue = 1;
                LoadData();
                NextPreviousButtonShow();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 1;
            LoadData();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}

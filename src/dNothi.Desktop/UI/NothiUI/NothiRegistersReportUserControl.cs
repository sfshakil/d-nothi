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
using System.Reflection;
using dNothi.Services.NothiReportService.Model;
using iText.Layout.Element;
using dNothi.Services.DakServices;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class NothiRegistersReportUserControl : UserControl
    {
        string fromdate, todate;
        public int pageLimit = 10;
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
        
        public NothiRegistersReportUserControl(IUserService userService, INothiReportService nothiReportService, IBasicService basicService)
        {
            InitializeComponent();
            _userService = userService;
            _nothiReportService = nothiReportService;
            _basicService = basicService;
         
        }
        #region Property

        public bool _isNothiPerito { get; set; }
        public bool _isNothiRegister { get; set; }
        public bool _isNothiGrahon { get; set; }
        public bool _isPotraJariBohi { get; set; }
        private bool _isNothiMasterFile { get; set; }

        public bool isNothiPerito
        {
            get { return _isNothiPerito; }
            set
            {
                _isNothiPerito = value; 
                if (value) {
                    headlineLabel.Text = "নথি প্রেরণ নিবন্ধন বহি";
                    AdjustColumnOrderForNothiPerito();
                    Formload(); 
                }
            }
        }
        public bool isNothiRegister
        {
            get { return _isNothiRegister; }
            set
            {
                _isNothiRegister = value;
                if (value)
                {
                    headlineLabel.Text = "নথি নিবন্ধন বহি";
                    AdjustColumnOrderForNothiNibandan();
                    Formload();
                }
            }
        }
        public bool isNothiGrahon
        {
            get { return _isNothiGrahon; }
            set
            {
                _isNothiGrahon = value;
                if (value)
                {
                    headlineLabel.Text = "নথি গ্রহণ নিবন্ধন বহি";
                    AdjustColumnOrderForNothiGrihita();
                    Formload();
                }
            }
        }
        public bool isPotraJariBohi
        {
            get { return _isPotraJariBohi; }
            set
            {
                _isPotraJariBohi = value; if (value)
                {
                    headlineLabel.Text = "পত্রজারি নিবন্ধন বহি"; 
                    AdjustColumnOrderForPotrojari();
                    Formload();
                }
            }
        }
        public bool isNothiMasterFile { get { return _isNothiMasterFile; } 
            set { _isNothiMasterFile = value; 
                if (value) 
                { headlineLabel.Text = "মাস্টার ফাইল"; 
                } } }
        private int _totalRecord { get; set; }
        public int totalRecord
        {
            get => _totalRecord;
            set
            {
                _totalRecord = value;

            }
        }
        #endregion

        #region Method
        private void AdjustColumnOrder()
        {
            
            registerReportDataGridView.Columns["sl"].DisplayIndex = 0;
            registerReportDataGridView.Columns["nothiNo"].DisplayIndex = 1;
            registerReportDataGridView.Columns["office_shaka"].DisplayIndex = 2;
            registerReportDataGridView.Columns["subject"].DisplayIndex = 3;
            registerReportDataGridView.Columns["previousSender"].DisplayIndex = 4;
            registerReportDataGridView.Columns["preronDate"].DisplayIndex = 5;
            registerReportDataGridView.Columns["nextReceiver"].DisplayIndex = 6;
            registerReportDataGridView.Columns["receivedDate"].DisplayIndex = 7;
            registerReportDataGridView.Columns["previousNothiNo"].DisplayIndex = 8;
            registerReportDataGridView.Columns["nothiVuktirDate"].DisplayIndex = 9;
            registerReportDataGridView.Columns["sender"].DisplayIndex = 10;
            registerReportDataGridView.Columns["sharokNo"].DisplayIndex = 11;
            registerReportDataGridView.Columns["receivers"].DisplayIndex = 12;
            registerReportDataGridView.Columns["onulipis"].DisplayIndex = 13;
            registerReportDataGridView.Columns["potroType"].DisplayIndex = 14;
        }
        private void AdjustColumnOrderForNothiPerito()
        {
            registerReportDataGridView.Columns["sl"].DisplayIndex = 0;
            
            registerReportDataGridView.Columns["nothiNo"].Visible = true;
            registerReportDataGridView.Columns["nothiNo"].DisplayIndex = 1;
            registerReportDataGridView.Columns["nothiNo"].HeaderText = "প্রেরিত নথির নং";
            registerReportDataGridView.Columns["office_shaka"].Visible = true;
            registerReportDataGridView.Columns["office_shaka"].DisplayIndex = 2;
            registerReportDataGridView.Columns["subject"].Visible = true;
            registerReportDataGridView.Columns["subject"].DisplayIndex = 3;
            registerReportDataGridView.Columns["previousSender"].Visible = true;
            registerReportDataGridView.Columns["previousSender"].DisplayIndex = 4;
            registerReportDataGridView.Columns["preronDate"].Visible = true;
            registerReportDataGridView.Columns["preronDate"].DisplayIndex = 5;
            registerReportDataGridView.Columns["nextReceiver"].Visible = true;
            registerReportDataGridView.Columns["nextReceiver"].DisplayIndex = 6;

            registerReportDataGridView.Columns["receivedDate"].Visible = false;
            registerReportDataGridView.Columns["previousNothiNo"].Visible = false;
            registerReportDataGridView.Columns["nothiVuktirDate"].Visible = false;
            registerReportDataGridView.Columns["sender"].Visible = false;
            registerReportDataGridView.Columns["sharokNo"].Visible = false;
            registerReportDataGridView.Columns["receivers"].Visible = false;
            registerReportDataGridView.Columns["onulipis"].Visible = false;
            registerReportDataGridView.Columns["potroType"].Visible = false;

        }

        private void AdjustColumnOrderForNothiGrihita()
        {
            registerReportDataGridView.Columns["sl"].DisplayIndex = 0;
            registerReportDataGridView.Columns["nothiNo"].Visible = true;
            registerReportDataGridView.Columns["nothiNo"].DisplayIndex = 1;
            registerReportDataGridView.Columns["nothiNo"].HeaderText = "গৃহীত নথির নং";
            registerReportDataGridView.Columns["receivedDate"].Visible = true;
            registerReportDataGridView.Columns["receivedDate"].DisplayIndex = 2;
            registerReportDataGridView.Columns["office_shaka"].Visible = true;
            registerReportDataGridView.Columns["office_shaka"].DisplayIndex = 3;
            registerReportDataGridView.Columns["subject"].Visible = true;
            registerReportDataGridView.Columns["subject"].DisplayIndex = 4;
            registerReportDataGridView.Columns["previousSender"].Visible = true;
            registerReportDataGridView.Columns["previousSender"].DisplayIndex = 5;

            registerReportDataGridView.Columns["preronDate"].Visible = false;
            registerReportDataGridView.Columns["nextReceiver"].Visible = false;
            registerReportDataGridView.Columns["previousNothiNo"].Visible = false;
            registerReportDataGridView.Columns["nothiVuktirDate"].Visible = false;
            registerReportDataGridView.Columns["sender"].Visible = false;
            registerReportDataGridView.Columns["sharokNo"].Visible = false;
            registerReportDataGridView.Columns["receivers"].Visible = false;
            registerReportDataGridView.Columns["onulipis"].Visible = false;
            registerReportDataGridView.Columns["potroType"].Visible = false;

        }

        private void AdjustColumnOrderForNothiNibandan()
        {
            registerReportDataGridView.Columns["sl"].Visible = true;
            registerReportDataGridView.Columns["sl"].DisplayIndex = 0;
            registerReportDataGridView.Columns["nothiNo"].Visible = true;
            registerReportDataGridView.Columns["nothiNo"].DisplayIndex = 1;
            registerReportDataGridView.Columns["nothiNo"].HeaderText = "নথির নং";
            registerReportDataGridView.Columns["previousNothiNo"].Visible = true;
            registerReportDataGridView.Columns["previousNothiNo"].DisplayIndex = 2;
            registerReportDataGridView.Columns["subject"].Visible = true;
            registerReportDataGridView.Columns["subject"].DisplayIndex = 3;
            registerReportDataGridView.Columns["subject"].HeaderText = "ধরণ/শিরোনাম";
            registerReportDataGridView.Columns["nothiVuktirDate"].Visible = true;
            registerReportDataGridView.Columns["nothiVuktirDate"].DisplayIndex = 4;

            registerReportDataGridView.Columns["office_shaka"].Visible = false;
            registerReportDataGridView.Columns["previousSender"].Visible = false;
            registerReportDataGridView.Columns["preronDate"].Visible = false;
            registerReportDataGridView.Columns["nextReceiver"].Visible = false;
            registerReportDataGridView.Columns["receivedDate"].Visible = false;
            registerReportDataGridView.Columns["sender"].Visible = false;
            registerReportDataGridView.Columns["sharokNo"].Visible = false;
            registerReportDataGridView.Columns["receivers"].Visible = false;
            registerReportDataGridView.Columns["onulipis"].Visible = false;
            registerReportDataGridView.Columns["potroType"].Visible = false;
            
            
        }

        private void AdjustColumnOrderForPotrojari()
        {
            registerReportDataGridView.Columns["sl"].DisplayIndex = 0;
            registerReportDataGridView.Columns["subject"].Visible = true;
            registerReportDataGridView.Columns["subject"].DisplayIndex = 1;
            registerReportDataGridView.Columns["subject"].HeaderText = "বিষয়";
            registerReportDataGridView.Columns["sender"].Visible = true;
            registerReportDataGridView.Columns["sender"].DisplayIndex = 2;
            registerReportDataGridView.Columns["sharokNo"].Visible = true;
            registerReportDataGridView.Columns["sharokNo"].DisplayIndex = 3;
            registerReportDataGridView.Columns["preronDate"].Visible = true;
            registerReportDataGridView.Columns["preronDate"].DisplayIndex = 4;
            registerReportDataGridView.Columns["receivers"].Visible = true;
            registerReportDataGridView.Columns["receivers"].DisplayIndex = 5;
            registerReportDataGridView.Columns["onulipis"].Visible = true;
            registerReportDataGridView.Columns["onulipis"].DisplayIndex = 6;
            registerReportDataGridView.Columns["potroType"].Visible = true;
            registerReportDataGridView.Columns["potroType"].DisplayIndex = 7;

            registerReportDataGridView.Columns["nothiNo"].Visible = false;
            registerReportDataGridView.Columns["previousNothiNo"].Visible = false;
            registerReportDataGridView.Columns["nothiVuktirDate"].Visible = false;
            registerReportDataGridView.Columns["office_shaka"].Visible = false;
            registerReportDataGridView.Columns["previousSender"].Visible = false;
            registerReportDataGridView.Columns["nextReceiver"].Visible = false;
            registerReportDataGridView.Columns["receivedDate"].Visible = false;
            
            

        }
        private void Formload()
        {
            page = 1;
            lastCountValue = 0;
            LoadData();
            NextPreviousButtonShow();
        }
        #endregion

        #region Events
        private void RegisterReportUserControl_Load(object sender, EventArgs e)
        {
            fromdate = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd");
            todate = DateTime.Now.ToString("yyyy/MM/dd");
            dateTextBox.Text = fromdate + ":" + todate;

            var userparam = _userService.GetLocalDakUserParam();
            officeUnitComboBox.DataSource = getShaka(userparam);
            officeUnitComboBox.DisplayMember = "Name";
            officeUnitComboBox.ValueMember = "Id";
            officeUnitComboBox.SelectedValue = userparam.office_unit_id;
            
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
            datetextFromtextbox = customDatePicker._date;


            customDatePicker.Visible = false;
            Formload();
        }
        private void pageLimitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Formload();
        }
        private void officeUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (officeUnitComboBox.SelectedValue.ToString() != "dNothi.Desktop.ComboBoxItem")
            {
                Formload();
            }
        }
        private void excelExportIconButton_Click(object sender, EventArgs e)
        {

            DataExportToExcel();
        }
        private void pdfExportIconButton_Click(object sender, EventArgs e)
        {
            DataExportToPDF();
        }

        #region Pagination
        private void NextPreviousButtonShow()
        {
            if (page < totalPage)
            {
                if (page == 1 && totalPage > 1)
                {
                    PreviousIconButton.Enabled = false;
                }
                else
                {
                    PreviousIconButton.Enabled = true;

                }
                nextIconButton.Enabled = true;
            }
            if (page == totalPage)
            {
                if (page == 1 && totalPage == 1)
                {
                    PreviousIconButton.Enabled = false;

                }
                else
                {
                    PreviousIconButton.Enabled = true;

                }
                nextIconButton.Enabled = false;
            }
        }
        private void nextIconButton_Click(object sender, EventArgs e)
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
            }
            endrow = end.ToString();
            LoadData();
            if (totalrecord < end) { endrow = totalrecord.ToString(); }

            NextPreviousButtonShow();
        }
        private void PreviousIconButton_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {

                page -= 1;
                start -= pageLimit;
                end -= pageLimit;
                lastCountValue -= (pageLimit + lastrecord);

            }
            else
            {
                page = 1;

            }


            LoadData();

            NextPreviousButtonShow();

        }

        #endregion

        #endregion

        #region Get Data From Server
       
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
        private NothiRegisterReport GetDataFromServer(int page, int limit)
        {

            DakUserParam userParam = _userService.GetLocalDakUserParam();


            string dateRange = dateTextBox.Text;
            string unitid = officeUnitComboBox.SelectedValue!=null? officeUnitComboBox.SelectedValue.ToString(): userParam.office_unit_id.ToString();
            if (dateRange != string.Empty)
            {
                fromdate = dateRange.Substring(0, dateRange.IndexOf(":"));
                todate = dateRange.Substring(dateRange.IndexOf(":") + 1);
            }
            else
            {
                fromdate = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd");
                todate = DateTime.Now.ToString("yyyy/MM/dd");
            }



            userParam.page = page;
            userParam.limit = limit;


            NothiRegisterReport registerReportResponse = _nothiReportService.NothiRegisterBook(userParam, fromdate, todate, unitid, isNothiPerito, isNothiGrahon, isNothiRegister, isPotraJariBohi, isNothiMasterFile);

            return registerReportResponse;
        }
        private void LoadData()
        {
            string name = pageLimitComboBox.Text;
            pageLimit = Convert.ToInt32(ConversionMethod.BanglaDigittoEngDigit(name));
            var RegisterReportlists = GetDataFromServer(page, pageLimit);

            ConvertNothiReport.lastCount = lastCountValue;
            var RegisterReportlist = ConvertNothiReport.GetNothiRegisterReports(RegisterReportlists);
            lastrecord = RegisterReportlist.Count();
            if (RegisterReportlist.Count <= 0)
            {
                noRowMessageLabel.Visible = true;
            }
            else
            {
                noRowMessageLabel.Visible = false;
                lastCountValue = RegisterReportlist.Max(x => x.sln);
            }
            _totalRecord = RegisterReportlists.data.total_records;
            totalLabel.Text = "সর্বমোট " + ConversionMethod.EnglishNumberToBangla(_totalRecord.ToString()) + " টি";

            float pagesize = (float)_totalRecord / (float)pageLimit;
            totalPage = (int)Math.Ceiling(pagesize);


            registerReportDataGridView.DataSource = null;
            registerReportDataGridView.DataSource = RegisterReportlist;


            // Resize the master DataGridView columns to fit the newly loaded data.
            registerReportDataGridView.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            registerReportDataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
            registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);
        }

        private void Formload1()
        {
            lastCountValue = 1;
            page = 1;
            start = 1;
            LoadData();
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            NextPreviousButtonShow();
            //perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }
        private void LoadData1()
        {
            var userParam = _userService.GetLocalDakUserParam();
            string pagessize = pageLimitComboBox.Text;
            string dateRange = dateTextBox.Text;
            string unitid = officeUnitComboBox.SelectedValue.ToString();
            if (dateRange == string.Empty)
            {
                fromdate = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd");
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
            var nothiRegisterBook = _nothiReportService.NothiRegisterBook(userParam, fromdate, todate, unitid, isNothiPerito, isNothiGrahon, isNothiRegister,isPotraJariBohi,isNothiMasterFile);
            if (nothiRegisterBook.status == "success")
            {
                totalLabel.Text = "সর্বমোট "+ ConversionMethod.EnglishNumberToBangla( nothiRegisterBook.data.total_records.ToString());
                noRowMessageLabel.Visible = false;
                lastrecord = nothiRegisterBook.data.records.Count();
                //lastCountValue = 1;
                //int serial = 1;
                var columns = (from t in nothiRegisterBook.data.records
                               select new
                               {
                                    
                                   sl = ConversionMethod.EnglishNumberToBangla((lastCountValue++).ToString()),
                                   acceptNum = t.nothi.nothi_no,
                                   docketingNo = "",
                                   sharokNo = t.nothi.subject,
                                   applyDate = ConversionMethod.numberToConsonet(t.nothi.nothi_class.ToString()) + ", " + t.created

                               }).ToList();
                if (columns.Count <= 0)
                {
                    noRowMessageLabel.Visible = true;
                }
                else
                {
                    noRowMessageLabel.Visible = false;
                    //lastCountValue = columns.Max(x => x.lastCountValue);
                }
              
                totalrecord = nothiRegisterBook.data.total_records;
                float pagesize = (float)(nothiRegisterBook.data.total_records) / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
                registerReportDataGridView.DataSource = null;
               registerReportDataGridView.DataSource = columns.ToList();
               
                registerReportDataGridView.AutoResizeColumns();

                registerReportDataGridView.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);
            }
            else
            {
                noRowMessageLabel.Visible = true;
            }

        }

        #endregion
        private void DataExportToExcel()
        {
            try
            {
                DateTime fDate = Convert.ToDateTime(fromdate);
                DateTime tDate = Convert.ToDateTime(todate);
                var fdate = ConversionMethod.ConvertIntoBanglaDate(fDate, "bn-BD", "dd MMMM yyyy");
                var tdate = ConversionMethod.ConvertIntoBanglaDate(tDate, "bn-BD", "dd MMMM yyyy");

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = false;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                string name = headlineLabel.Text + "_" + officeUnitComboBox.Text + "_" + fdate + "_" + tdate;
                worksheet.Name = headlineLabel.Text;
                var nothiRegisterBook = LoadExportData();
                try
                {
                    for (int i = 0; i < registerReportDataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = registerReportDataGridView.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < nothiRegisterBook.Rows.Count; i++)
                    {
                        for (int j = 0; j < nothiRegisterBook.Columns.Count; j++)
                        {
                            if (nothiRegisterBook.Rows[i][j].ToString() != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = nothiRegisterBook.Rows[i][j].ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;
                    saveDialog.FileName = name;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        private DataTable LoadExportData()
        {
            var userParam = _userService.GetLocalDakUserParam();

            string dateRange = dateTextBox.Text;
            string unitid = officeUnitComboBox.SelectedValue.ToString();
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

            userParam.page = 1;
            userParam.limit = totalrecord;
            var nothiRegisterBook = _nothiReportService.NothiRegisterBook(userParam, fromdate, todate, unitid, _isNothiPerito, _isNothiGrahon, _isNothiRegister, _isPotraJariBohi, _isNothiMasterFile);
            int lastCount = 1;
            var columns = (from t in nothiRegisterBook.data.records
                           select new RegisterReport
                           {

                               sl = ConversionMethod.EnglishNumberToBangla((lastCount++).ToString()),
                               acceptNum = t.nothi.nothi_no,
                               docketingNo = "",
                               sharokNo = t.nothi.subject,
                               applyDate = ConversionMethod.numberToConsonet(t.nothi.nothi_class.ToString()) + ", " + t.nothi.modified

                           }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("sl", typeof(string));
            dt.Columns.Add("acceptNum", typeof(string));
            dt.Columns.Add("docketingNo", typeof(string));
            dt.Columns.Add("sharokNo", typeof(string));
            dt.Columns.Add("applyDate", typeof(string));
            foreach (var item in columns)
            {
                dt.Rows.Add(new object[] {
                        item.sl,
                        item.acceptNum,
                        item.docketingNo,
                        item.sharokNo,
                        item.applyDate,
                         });
            }
           
            return dt;
        }
        private void DataExportToPDF()
        {
           
            if (registerReportDataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        var nothiRegisterBook = LoadExportData();
                        try
                        {
                            int cols = nothiRegisterBook.Columns.Count;
                            int rows = nothiRegisterBook.Rows.Count;
                            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\Fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H,true);
                            //BaseFont bf = BaseFont.CreateFont(MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi), BaseFont.IDENTITY_H, true);
                             PdfPTable pdfTable = new PdfPTable(registerReportDataGridView.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in registerReportDataGridView.Columns)
                            {
                                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                               
                               PdfPCell cell = new PdfPCell(new Phrase(12, column.HeaderText, font));
                               // PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in nothiRegisterBook.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                                    PdfPCell cells = new PdfPCell(new Phrase(12, cell.Value.ToString(), font));
                                    // pdfTable.AddCell(cell.Value.ToString());
                                    pdfTable.AddCell(cells);
                                }
                            }

                            for (int k = 0; k < rows; k++)
                            {
                                for (int j = 0; j < cols; j++)
                                {
                                   
                                    iTextSharp.text.Font RowFont = FontFactory.GetFont(FontFactory.COURIER_BOLD, 12);
                                    PdfPCell cellsrow = new PdfPCell(new Phrase(12, nothiRegisterBook.Rows[k][j].ToString(), RowFont));
                                  
                                    pdfTable.AddCell(cellsrow);

                                }
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);

                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
      
    }
}

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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.JsonParser.Entity;
using dNothi.Services.BasicService;
using dNothi.Services.DakServices.DakReports;
using System.Threading;
using System.Globalization;

namespace dNothi.Desktop.UI.Dak
{
    public partial class RegisterReportUserControl : UserControl
    {
        string fromdate, todate;
        public int pageLimit=10;
        public int pageNo=1;
        int page = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        int lastCountValue = 0;
        int lastrecord = 0;
        string datetextFromtextbox=string.Empty;

        public WaitFormFunc WaitForm;
        #region Property
        private bool _isDakGrohon { get; set; }
        private bool _isDakDiary { get; set; }
        private bool _isDakBili { get; set; }

        public bool isDakGrohon { get { return _isDakGrohon; } set { 
                _isDakGrohon = value; if (value) { headlineLabel.Text = "ডাক গ্রহণ নিবন্ধন বহি"; } } }
        public bool isDakDiary { get { return _isDakDiary; } set { 
                _isDakDiary = value; if (value) { headlineLabel.Text = "শাখা ডায়েরি নিবন্ধন বহি"; } } }
        public bool isDakBili { get { return _isDakBili; } set {
                _isDakBili = value; if (value) { headlineLabel.Text = "ডাক বিলি নিবন্ধন বহি"; } } }
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

        IRegisterService _registerService;
        IUserService _userService { get; set; }
        IBasicService _basicService { get; set; }
        public RegisterReportUserControl(IRegisterService registerService, IUserService userService, IBasicService basicService)
        {
            InitializeComponent();
            WaitForm = new WaitFormFunc();
            WaitForm.Show();
            _registerService = registerService;
            _userService = userService;
            _basicService = basicService;

        }



        #region Method
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

            WaitForm.Close();
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
            page = 1;
            lastCountValue = 0;
            LoadData();
        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void pageLimitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 0;
            LoadData();
            NextPreviousButtonShow();
        }

        private void customDatePicker_Click(object sender, EventArgs e)
        {


                dateTextBox.Text = customDatePicker._date;

                customDatePicker.Visible = false;

        }
   

  
        private void officeUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (officeUnitComboBox.SelectedValue.ToString() != "dNothi.Desktop.ComboBoxItem")
            {
                page = 1;
                lastCountValue = 0;
                LoadData();
            }
        }

        private void pdfExportIconButton_Click(object sender, EventArgs e)
        {
            DataExportToPDF();
        }
       
        private void excelExportIconButton_Click(object sender, EventArgs e)
        {
            DataExportToExcel();
        }

        #endregion

        #region Load Data From Server

        private List<ComboBoxItem> getShaka(DakUserParam userParam)
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();

            var officeUnitResponse = _basicService.GetOfficeUnitList(userParam);
            if (officeUnitResponse != null && officeUnitResponse.status == "success")
            {
                comboBoxItems.Add(new ComboBoxItem("শাখা নির্বাচন করুন", 0));
                foreach (var item in officeUnitResponse.data)
                {
                    comboBoxItems.Add(new ComboBoxItem(item.unit_name_bng, item.unit_id));
                }
            }
            else
            {
                WaitForm.Close();
            }

            return comboBoxItems;
        }
        private DakReportModel GetDataFromServer(int page, int limit)
        {

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


            string dateRange = dateTextBox.Text;
            string value = officeUnitComboBox.SelectedValue.ToString();
            if (dateRange != string.Empty)
            {
                fromdate = dateRange.Substring(0, dateRange.IndexOf(":"));
                todate = dateRange.Substring(dateRange.IndexOf(":") + 1);
            }
            else
            {
                fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
                todate = DateTime.Now.ToString("yyyy/MM/dd");
            }



            dakListUserParam.page = page;
            dakListUserParam.limit = limit;


            DakReportModel registerReportResponse = _registerService.GetDakGrohonResponse(dakListUserParam, fromdate, todate, value, isDakGrohon, isDakBili, isDakDiary);

            return registerReportResponse;
        }
        private void LoadData()
        {
            string name = pageLimitComboBox.Text;
            pageLimit = Convert.ToInt32(ConversionMethod.BanglaDigittoEngDigit(name));
            var RegisterReportlists = GetDataFromServer(page, pageLimit);
           
            ConvertRegisterResponsetoReport.lastCount = lastCountValue;
            var RegisterReportlist = ConvertRegisterResponsetoReport.GetGrahonRegisterReports(RegisterReportlists);
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
            totalRowlabel.Text = "সর্বমোট " + ConversionMethod.EnglishNumberToBangla(_totalRecord.ToString()) + " টি";

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

        #endregion

        #region Pagination
        private void NextPreviousButtonShow()
        {
            if (page < totalPage)
            {
                if (page == 1 && totalPage > 1)
                {
                    previousIconButton.Enabled = false;
                }
                else
                {
                    previousIconButton.Enabled = true;

                }
                pageNextButton.Enabled = true;
            }
            if (page == totalPage)
            {
                if (page == 1 && totalPage == 1)
                {
                    previousIconButton.Enabled = false;

                }
                else
                {
                    previousIconButton.Enabled = true;

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
        private void previousIconButton_Click(object sender, EventArgs e)
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
                start = start;
                end = end;

            }


            LoadData();
            //perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
            NextPreviousButtonShow();

        }


        #endregion

        #region Data Export
       
        private DataTable LoadExportData()
        {
            int pagevalue = 1;

            var registerReportlists = GetDataFromServer(pagevalue, _totalRecord);
            ConvertRegisterResponsetoReport.lastCount = lastCountValue;
            var registerReportlist = ConvertRegisterResponsetoReport.GetGrahonRegisterReports(registerReportlists);
            int count = 1;
            DataTable dt = new DataTable();
            dt.Columns.Add("sl", typeof(string));
            dt.Columns.Add("acceptNum", typeof(string));
            dt.Columns.Add("docketingNo", typeof(string));
            dt.Columns.Add("sharokNo", typeof(string));
            dt.Columns.Add("applyDate", typeof(string));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("sub", typeof(string));
            dt.Columns.Add("applicant", typeof(string));
            dt.Columns.Add("previousPrapok", typeof(string));
            dt.Columns.Add("mainPrapok", typeof(string));
            dt.Columns.Add("receivedDate", typeof(string));
            dt.Columns.Add("security", typeof(string));
            dt.Columns.Add("priority", typeof(string));
            dt.Columns.Add("finalState", typeof(string));

            foreach (var item in registerReportlist)
            {
                dt.Rows.Add(new object[] {
                        ConversionMethod.EnglishNumberToBangla(count++.ToString()),
                        item.acceptNum,
                        item.docketingNo,
                        item.sharokNo,
                        item.applyDate,
                        item.type,
                         item.sub,
                          item.applicant,
                           item.previousPrapok,
                            item.mainPrapok,
                            item.receivedDate,
                            item.security,
                            item.priority,
                            item.finalState
                         });
            }

            return dt;
        }
        private void DataExportToExcel()
        {
            try
            {
                
                DateTime fDate = Convert.ToDateTime(fromdate);
                DateTime tDate = Convert.ToDateTime(todate);
                var fdate =ConversionMethod.ConvertIntoBanglaDate(fDate, "bn-BD", "dd MMMM yyyy");
                var tdate = ConversionMethod.ConvertIntoBanglaDate(tDate, "bn-BD", "dd MMMM yyyy");

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = false;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                string name=headlineLabel.Text + "_" + officeUnitComboBox.Text + "_" + fdate + "_" + tdate;
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

        



        //private void DataExportToExcel()
        //{
        //    try
        //    {
        //        Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
        //        Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
        //        Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
        //        app.Visible = true;
        //        worksheet = workbook.Sheets["Sheet1"];
        //        worksheet = workbook.ActiveSheet;
        //        worksheet.Name = "Records";

        //        try
        //        {
        //            for (int i = 0; i < registerReportDataGridView.Columns.Count; i++)
        //            {
        //                worksheet.Cells[1, i + 1] = registerReportDataGridView.Columns[i].HeaderText;
        //            }
        //            for (int i = 0; i < registerReportDataGridView.Rows.Count; i++)
        //            {
        //                for (int j = 0; j < registerReportDataGridView.Columns.Count; j++)
        //                {
        //                    if (registerReportDataGridView.Rows[i].Cells[j].Value != null)
        //                    {
        //                        worksheet.Cells[i + 2, j + 1] = registerReportDataGridView.Rows[i].Cells[j].Value.ToString();
        //                    }
        //                    else
        //                    {
        //                        worksheet.Cells[i + 2, j + 1] = "";
        //                    }
        //                }
        //            }

        //            //Getting the location and file name of the excel to save from user. 
        //            SaveFileDialog saveDialog = new SaveFileDialog();
        //            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        //            saveDialog.FilterIndex = 2;

        //            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //            {
        //                workbook.SaveAs(saveDialog.FileName);
        //                MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //        finally
        //        {
        //            app.Quit();
        //            workbook = null;
        //            worksheet = null;
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        //}
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
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(registerReportDataGridView.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in registerReportDataGridView.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in registerReportDataGridView.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                string fontLoc = @"C:\Windows\Fonts\SolaimanLipi";
                                BaseFont bf = BaseFont.CreateFont(fontLoc, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                // Font f = new Font(bf, 12);


                                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL; // can also be set on the cell


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
      
        #endregion

    }
}

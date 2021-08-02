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
        string datetextFromtextbox=string.Empty;

        IRegisterService _registerService;
        IUserService _userService { get; set; }
        public RegisterReportUserControl(IRegisterService registerService, IUserService userService)
        {
            InitializeComponent();
            _registerService = registerService;
            _userService = userService;
            fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
            todate = DateTime.Now.ToString("yyyy/MM/dd");
            dateTextBox.Text = fromdate+":"+todate;

            
            dakPriorityComboBox.DataSource= getList();
            dakPriorityComboBox.DisplayMember = "Name";
            dakPriorityComboBox.ValueMember = "Id";
            //dakPriorityComboBox.SelectedIndex = 0;
        }
        private List<ComboBoxItem> getList()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            ComboBoxItem data0 = new ComboBoxItem("শাখা নির্বাচন করুন", 0);
            comboBoxItems.Add(data0);
           
            ComboBoxItem data = new ComboBoxItem ( "প্রকল্প পরিচালকের",  6691 );
            comboBoxItems.Add(data);                           
            ComboBoxItem data1 = new ComboBoxItem ( "পলিসি অ্যাডভাইজর",  6692 );
            comboBoxItems.Add(data1);                          
            ComboBoxItem data2 = new ComboBoxItem ("ক্যাপাসিটি ডেভেলপমেন্ট", 6699 );
            comboBoxItems.Add(data2);                          
            ComboBoxItem data3 = new ComboBoxItem( "ক্যাপাসিটি ডেভেলপমেন্ট", 6700);
            comboBoxItems.Add(data3);                          
            ComboBoxItem data4 = new ComboBoxItem ("কমিউনিকেশন ও পার্টনারশীপ" ,6707 );
            comboBoxItems.Add(data4);                          
            ComboBoxItem data5 = new ComboBoxItem (  "এইচডি মিডিয়া", 6711 );
            comboBoxItems.Add(data5);                          
            ComboBoxItem data6 = new ComboBoxItem ("ই - লার্নিং", 6712);
            comboBoxItems.Add(data6);                          
            ComboBoxItem data7 = new ComboBoxItem ( "এডমিন", 6712);
            comboBoxItems.Add(data7);                          
            ComboBoxItem data8 = new ComboBoxItem ( "মনিটরিং এ্যান্ড ইভালুয়েশন", 9739 );
            comboBoxItems.Add(data8);                          
            ComboBoxItem data9 = new ComboBoxItem (  "ই - সার্ভিস ", 9625 );
            comboBoxItems.Add(data9);
            ComboBoxItem data10 = new ComboBoxItem (  "হিউম্যান রিসোর্স", 9739 );
            comboBoxItems.Add(data10);
            ComboBoxItem data11 = new ComboBoxItem ( "ইনোভেশন -১", 9742 );
            comboBoxItems.Add(data11);
            ComboBoxItem data12 = new ComboBoxItem (  "অবকাঠামো", 9747 );
            comboBoxItems.Add(data12);
            ComboBoxItem data13 = new ComboBoxItem ("টেকনোলজি", 46122 );
            comboBoxItems.Add(data13);
            ComboBoxItem data14 = new ComboBoxItem (  "টেস্ট 111", 46180 );
            comboBoxItems.Add(data14);
            return comboBoxItems;

        }

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

        //public RegisterReportUserControl()
        //{
        //    InitializeComponent();
        //}


        public bool _isDakGrohon { get; set; }
        public bool _isDakDiary { get; set; }
        public bool _isDakBili { get; set; }

        public bool isDakGrohon { get {return _isDakGrohon ; } set {_isDakGrohon=value; if (value) { headlineLabel.Text = "ডাক গ্রহণ নিবন্ধন বহি"; } } }
        public bool isDakDiary { get {return _isDakDiary; } set { _isDakDiary = value; if (value) { headlineLabel.Text = "শাখা ডায়েরি নিবন্ধন বহি"; } } }
        public bool isDakBili { get {return _isDakBili; } set { _isDakBili = value; if (value) { headlineLabel.Text = "ডাক বিলি নিবন্ধন বহি"; } } }
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
                //    comboBox1.Items.Add(new ComboBoxItem("১০", 1));
                //    comboBox1.Items.Add(new ComboBoxItem("২০", 2));
                //    comboBox1.Items.Add(new ComboBoxItem("৩০", 3));
                //    comboBox1.Items.Add(new ComboBoxItem("৪০", 4));
                //    comboBox1.Items.Add(new ComboBoxItem("৫০", 5));
                //    comboBox1.SelectedIndex = 0;
                //}

            }
        }
        public List<RegisterReport> _registerReports { get; set; }
        public List<RegisterReport> registerReports {
            get { return _registerReports; }
            set
            {
                _registerReports = value;

                //if(value.Count<=0)
                //{
                //    noRowMessageLabel.Visible = true;
                //}
                //else
                //{
                //    noRowMessageLabel.Visible = false;
                //}

                //registerReportDataGridView.DataSource = null;
                //registerReportDataGridView.DataSource = value;


                //// Resize the master DataGridView columns to fit the newly loaded data.
                //registerReportDataGridView.AutoResizeColumns();

                //// Configure the details DataGridView so that its columns automatically
                //// adjust their widths when the data changes.
                //registerReportDataGridView.AutoSizeColumnsMode =
                //    DataGridViewAutoSizeColumnsMode.AllCells;

                //MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                //registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0,12, registerReportDataGridView.Font.Style);
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

            dateTextBox.Text = customDatePicker._date;
            datetextFromtextbox = customDatePicker._date;
           

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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            DataExportToExcel();
        }
        private void DataExportToExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < registerReportDataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = registerReportDataGridView.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < registerReportDataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < registerReportDataGridView.Columns.Count; j++)
                        {
                            if (registerReportDataGridView.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = registerReportDataGridView.Rows[i].Cells[j].Value.ToString();
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DataExportToPDF();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 0;
            LoadData();
            NextPreviousButtonShow();
        }
        private void LoadData()
        {
            List<RegisterReport> RegisterReportlist = new List<RegisterReport>();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
           
            string name = comboBox1.Text;
            string dateRange = dateTextBox.Text;
            int value =(int) dakPriorityComboBox.SelectedValue;
            if (dateRange==string.Empty) {
                 fromdate = dateRange.Substring(0, dateRange.IndexOf(":"));
                 todate = dateRange.Substring(dateRange.IndexOf(":") + 1);
            }
            else
            {
                 fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
                 todate = DateTime.Now.ToString("yyyy/MM/dd");
            }

            pageLimit =Convert.ToInt32(ConversionMethod.BanglaDigittoEngDigit(name));
            
            dakListUserParam.page = page;
            dakListUserParam.limit = pageLimit;
         

            if (isDakGrohon)
            {

                RegisterReportResponse registerReportResponse = _registerService.GetDakGrohonResponse(dakListUserParam, fromdate, todate, value.ToString());
                ConvertRegisterResponsetoReport.lastCount = lastCountValue;
                RegisterReportlist = ConvertRegisterResponsetoReport.GetRegisterReports(registerReportResponse);
            }
            if (isDakBili)
            {
                RegisterReportResponse registerReportResponse = _registerService.GetDakBiliResponse(dakListUserParam, fromdate, todate, value.ToString());
                ConvertRegisterResponsetoReport.lastCount = lastCountValue;
                RegisterReportlist = ConvertRegisterResponsetoReport.GetRegisterReports(registerReportResponse);
            }
            if (isDakDiary)
            {
                RegisterReportResponse registerReportResponse = _registerService.GetDakDiaryResponse(dakListUserParam, fromdate, todate, value.ToString());
                ConvertRegisterResponsetoReport.lastCount = lastCountValue;
                RegisterReportlist = ConvertRegisterResponsetoReport.GetRegisterReports(registerReportResponse);
            }

            if (RegisterReportlist.Count <= 0)
            {
                noRowMessageLabel.Visible = true;
            }
            else
            {
                noRowMessageLabel.Visible = false;
                lastCountValue = RegisterReportlist.Max(x => x.sln);
            }
           
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
        //private void pageNextButton_Click(object sender, EventArgs e)
        //{

        //}

        //private void iconButton3_Click(object sender, EventArgs e)
        //{

        //}
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
                lastCountValue-= pageLimit;

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

        private void customDatePicker_Click(object sender, EventArgs e)
        {


                dateTextBox.Text = customDatePicker._date;

                customDatePicker.Visible = false;
           
        }

        private void customDatePicker_Load(object sender, EventArgs e)
        {

        }

        private void dakPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                page = 1;
                lastCountValue = 0;
                LoadData();
           
        }
    }
}

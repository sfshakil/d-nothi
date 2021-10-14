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
using dNothi.Services.BasicService.Models;
using dNothi.Services.DakServices.DakReports;

namespace dNothi.Desktop.UI.Dak
{
    public partial class AllDakTrakingUserControl : UserControl
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

        IRegisterService _registerService;
        IUserService _userService { get; set; }
        IBasicService _basicService { get; set; }
        public AllDakTrakingUserControl(IRegisterService registerService, IUserService userService, IBasicService basicService)
        {
            InitializeComponent();
            _registerService = registerService;
            _userService = userService;
            _basicService = basicService;
            fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
            todate = DateTime.Now.ToString("yyyy/MM/dd");
            dateTextBox.Text = fromdate+":"+todate;

        }
      
        private int _totalRecord { get; set; }
        public int totalRecord
        {
            get => _totalRecord;
            set
            {
                _totalRecord = value;
               
            
            }
        }
        public List<RegisterReport> _registerReports { get; set; }
        public List<RegisterReport> registerReports {
            get { return _registerReports; }
            set
            {
                _registerReports = value;

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
           // DataExportToPDF();
        }

        private List<RegisterReport> GetDataFromServer(int pages,int limit)
        {
            List<RegisterReport> RegisterReportlist = new List<RegisterReport>();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            string dateRange = dateTextBox.Text;

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


            string subject = subjectTextBox.Text;
            string mobile = mobileTextBox.Text;
            string application_no = applicaionNoTextBox.Text;
            dakListUserParam.page = pages;
            dakListUserParam.limit = limit;

            DakReportModel registerReportResponse = _registerService.GetDakTrakingResponse(dakListUserParam, fromdate, todate, mobile, subject, application_no);

            RegisterReportlist = ConvertRegisterResponsetoReport.GetDakTrakingReports(registerReportResponse);
            return RegisterReportlist;
        }
        private void LoadData()
        {
            var RegisterReportlist = GetDataFromServer(page,pageLimit);
            if (RegisterReportlist.Count <= 0)
            {
                noRowMessageLabel.Visible = true;
            }
            else
            {
                noRowMessageLabel.Visible = false;
               
            }

            //float pagesize = (float)_totalRecord / (float)pageLimit;
            //totalPage = (int)Math.Ceiling(pagesize);


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
        private void dakSearchUsingTextButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void resetSubjectSearchButton_Click(object sender, EventArgs e)
        {
             dateTextBox.Text=string.Empty;
            subjectTextBox.Text=string.Empty;
           mobileTextBox.Text=string.Empty;
           applicaionNoTextBox.Text=string.Empty;
            registerReportDataGridView.DataSource = null;
         
            registerReportDataGridView.AutoResizeColumns();

            registerReportDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
            registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);
        }

        private void customDatePicker_Click(object sender, EventArgs e)
        {


                dateTextBox.Text = customDatePicker._date;

                customDatePicker.Visible = false;
           
        }

        private void customDatePicker_Load(object sender, EventArgs e)
        {

        }

        private void RegisterReportUserControl_Load(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 0;
            LoadData();
           
        }

        private void userIdPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void dateTextBox_Click(object sender, EventArgs e)
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }


    }
}

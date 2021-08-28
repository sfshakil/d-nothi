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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class NothiPotrajariRegisterReportUserControl : UserControl
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
        private void RefreshPagination()
        {
            
        }

        public NothiPotrajariRegisterReportUserControl(IUserService userService, INothiReportService nothiReportService, IBasicService basicService)
        {
            _userService = userService;
            _nothiReportService = nothiReportService;
            _basicService = basicService;
            InitializeComponent();
            fromdate = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd");
            todate = DateTime.Now.ToString("yyyy/MM/dd");
            dateTextBox.Text = fromdate + ":" + todate;


            dakPriorityComboBox.DataSource = getShaka();
            dakPriorityComboBox.DisplayMember = "Name";
            dakPriorityComboBox.ValueMember = "Id";
        }

        private List<ComboBoxItem> getShaka()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            var userparam = _userService.GetLocalDakUserParam();
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

        public bool isNothiPerito { get { return _isNothiPerito; } set { _isNothiPerito = value; if (value) { headlineLabel.Text = "নথি প্রেরণ নিবন্ধন বহি"; } } }
        public bool isNothiRegister { get { return _isNothiRegister; } set { _isNothiRegister = value; if (value) { headlineLabel.Text = "নথি নিবন্ধন বহি"; } } }
        public bool isNothiGrahon { get { return _isNothiGrahon; } set { _isNothiGrahon = value; if (value) { headlineLabel.Text = "নথি গ্রহণ নিবন্ধন বহি"; } } }


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
            DataExportToExcel();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
             DataExportToPDF(); 
            //printPdf();
        }
        private void LoadData()
        {
            var userParam = _userService.GetLocalDakUserParam();
            string pagessize = comboBox1.Text;
            string dateRange = dateTextBox.Text;
            string unitid = dakPriorityComboBox.SelectedValue.ToString();
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

            pageLimit = Convert.ToInt32(ConversionMethod.BanglaDigittoEngDigit(pagessize));
            //pageLimit = 20;
            userParam.page = page;
            userParam.limit = pageLimit;
            bool potraJariBohi = true;
            var nothiRegisterBook = _nothiReportService.NothiRegisterBook(userParam, fromdate, todate, unitid, _isNothiPerito, _isNothiGrahon, _isNothiRegister, potraJariBohi);
            if (nothiRegisterBook.status == "success")
            {
                totalRowlabel.Text = "সর্বমোট "+ ConversionMethod.EnglishNumberToBangla( nothiRegisterBook.data.total_records.ToString())+" টি";
                noRowMessageLabel.Visible = false;
                lastrecord = nothiRegisterBook.data.records.Count();
                //lastCountValue = 1;
                //int serial = 1;
             
                var columns = (from t in nothiRegisterBook.data.records
                               select new
                               {
                                   sl = ConversionMethod.EnglishNumberToBangla((lastCountValue++).ToString()),
                                   sub=t.potrojari.potro_subject,
                                   mainPrapok=getPrerok(t.potrojari.recipient.sender),
                                   sharokNo= t.potrojari.sarok_no,
                                   applyDate=t.basic.issue_date,
                                   previousPrapok= getPrapok(t.potrojari.recipient.receiver),
                                   docketingNo=getOnulipi(t.potrojari.recipient.onulipi),
                                   
                                   type=t.potrojari.potro_type==1?"অফিস স্বারক": (t.potrojari.potro_type == 2? "সরকারি পত্র" : "আধা সরকারি পত্র"),

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
        Bitmap bitmap;

        private string getOnulipi(object onulipiObject)
        {
            
            string onulipidata=string.Empty;
            if (onulipiObject != null)
            {
                List<NothiRegisterReport.Onulipi> onulipi = JsonConvert.DeserializeObject<List<NothiRegisterReport.Onulipi>>(onulipiObject.ToString());

                foreach (var item in onulipi)
                {
                    onulipidata += item.office_unit + "," + item.office;
                }
            }
            return onulipidata;
        }
        private string getPrapok(object receiverObject)
        {
           
            string receiverdata = string.Empty;
            if (receiverObject != null)
            {
                List<NothiRegisterReport.Receiver> receiver = JsonConvert.DeserializeObject<List<NothiRegisterReport.Receiver>>(receiverObject.ToString());

                foreach (var item in receiver)
                {
                    receiverdata += item.office_unit + "," + item.office;
                }
            }

            return receiverdata;
        }
        private string getPrerok(object senderObject)
        {
            string senderdata = string.Empty;
            if (senderObject != null)
            {
                List<NothiRegisterReport.Sender> sender = JsonConvert.DeserializeObject<List<NothiRegisterReport.Sender>>(senderObject.ToString());

                foreach (var item in sender)
                {
                    senderdata += item.office_unit + "," + item.office;
                }
            }

            return senderdata;
        }
        private void printPdf()
        {
            //Add a Panel control.
            Panel panel = new Panel();
            this.Controls.Add(panel);

            //Create a Bitmap of size same as that of the Form.
            Graphics grp = panel.CreateGraphics();
            Size formSize = bodyTableLayoutPanel.ClientSize;
             bitmap = new Bitmap(registerReportDataGridView.Width + bodyTableLayoutPanel.Width, registerReportDataGridView.Height + bodyTableLayoutPanel.Height, grp);
            grp = Graphics.FromImage(bitmap);

            formSize.Width = registerReportDataGridView.Width + bodyTableLayoutPanel.Width;
            formSize.Height = registerReportDataGridView.Height + bodyTableLayoutPanel.Height;

            //Copy screen area that that the Panel covers.
            Point panelLocation = PointToScreen(registerReportDataGridView.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);

            //Show the Print Preview Dialog.
            nothiPrintPreviewDialog.Document = printDocument1;
            nothiPrintPreviewDialog.PrintPreviewControl.Zoom = 1;
            printDocument1.DefaultPageSettings.Landscape = true;
            nothiPrintPreviewDialog.ShowDialog();
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

                            foreach (DataGridViewRow row in registerReportDataGridView.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                                    PdfPCell cells = new PdfPCell(new Phrase(12, cell.Value.ToString(), font));
                                    // pdfTable.AddCell(cell.Value.ToString());
                                    pdfTable.AddCell(cells);
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
       
        private void RegisterReportUserControl_Load(object sender, EventArgs e)
        {
            page = 1;
            lastCountValue = 1;
            LoadData();
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

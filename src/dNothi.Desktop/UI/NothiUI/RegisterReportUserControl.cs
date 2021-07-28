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

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class RegisterReportUserControl : UserControl
    {
        public int pageLimit=100;
        public int pageNo=1;
        IUserService _userService { get; set; }
        INothiReportService _nothiReportService { get; set; }
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

        public RegisterReportUserControl(IUserService userService, INothiReportService nothiReportService)
        {
            _userService = userService;
            _nothiReportService = nothiReportService;
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            DataExportToExcel();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
             DataExportToPDF(); 
            //printPdf();
        }
        private void DisplayData()
        {
            var userParam = _userService.GetLocalDakUserParam();
            DataTable dt = new DataTable();
            userParam.page = 1;
            userParam.limit = 100;
            var nothiRegisterBook = _nothiReportService.NothiRegisterBook(userParam);
            if (nothiRegisterBook.status == "success")
            {
                totalRowlabel.Text = "সর্বমোট "+ ConversionMethod.EnglishNumberToBangla( nothiRegisterBook.data.total_records.ToString())+" টি";
                noRowMessageLabel.Visible = false;
                int sirialNo = 1;
                var columns = from t in nothiRegisterBook.data.records

                              select new
                              {

                                  sl = ConversionMethod.EnglishNumberToBangla(sirialNo++.ToString()),
                                  acceptNum = t.nothi.nothi_no,
                                  docketingNo = "",
                                  sharokNo = t.nothi.subject,
                                  applyDate = ConversionMethod.numberToConsonet(t.nothi.nothi_class.ToString()) + ", " + t.nothi.modified

                              };

                registerReportDataGridView.DataSource = columns.ToList();
                // Resize the master DataGridView columns to fit the newly loaded data.
                registerReportDataGridView.AutoResizeColumns();

                // Configure the details DataGridView so that its columns automatically
                // adjust their widths when the data changes.
                registerReportDataGridView.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                registerReportDataGridView.ColumnHeadersDefaultCellStyle.Font = MemoryFonts.GetFont(0, 12, registerReportDataGridView.Font.Style);
            }
            else
            {
                noRowMessageLabel.Visible = true;
            }

        }
        Bitmap bitmap;
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
            DisplayData();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}

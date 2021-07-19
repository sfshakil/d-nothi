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
    }
}

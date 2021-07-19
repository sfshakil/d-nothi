using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Services.UserServices;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.DakServices;
using dNothi.Utility;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.GuardFileUI;
using System.IO;
using dNothi.JsonParser.Entity.Dak;
using AutoMapper;
using dNothi.Services.NothiReportService;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class UCAllNothiList : UserControl
    {
        IUserService _userService { get; set; }
        INothiReportService _nothiReportService { get; set; }

        AllAlartMessage alartMessage = new AllAlartMessage();
        int page = 1;
        int pageLimit = 10;

        public UCAllNothiList(IUserService userService, INothiReportService nothiReportService)
        {
            _userService = userService;
            _nothiReportService = nothiReportService;
              InitializeComponent();
           
            //typesearchComboBox.itemList = GuardFileCategories();
            //typesearchComboBox.isListShown = true;

            //Formload();


        }
        private void DisplayData()
        {
            var userParam = _userService.GetLocalDakUserParam();
            DataTable dt = new DataTable();
            userParam.page = 1;
            userParam.limit = 100;
            var nothiRegisterBook=  _nothiReportService.NothiRegisterBook(userParam);
            int sirialNo = 1;
            var columns = from t in nothiRegisterBook.data.records

                          select new
                          {
                              
                              sln =ConversionMethod.EnglishNumberToBangla( sirialNo++.ToString()),
                              nothiNo =t.nothi.nothi_no,
                              previousNothiNo = "",
                              types =t.nothi.subject,
                              nothiEntryDate =ConversionMethod.EngDigittoBanDigit( t.nothi.nothi_class.ToString())+ ", "+t.nothi.modified
                          };
           // RegisterBookColumns

            nothiRegisterdataGridView.DataSource = columns.ToList();
           
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
                    for (int i = 0; i < nothiRegisterdataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = nothiRegisterdataGridView.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < nothiRegisterdataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < nothiRegisterdataGridView.Columns.Count; j++)
                        {
                            if (nothiRegisterdataGridView.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = nothiRegisterdataGridView.Rows[i].Cells[j].Value.ToString();
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
            if (nothiRegisterdataGridView.Rows.Count > 0)
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
                            PdfPTable pdfTable = new PdfPTable(nothiRegisterdataGridView.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in nothiRegisterdataGridView.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in nothiRegisterdataGridView.Rows)
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

        private void Table_Border_Color_Blue(object sender, PaintEventArgs e)
        {
           // UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }

        private void Table_Border_Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }


        private void typesearchComboBox_Load(object sender, EventArgs e)
        {

        }

        private void searchBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void dakSearchUsingTextButton_Click(object sender, EventArgs e)
        {
           // Formload();
        }

        private void recycleIconButton_Click(object sender, EventArgs e)
        {
          
           // dakSearchSubTextBox.Text = string.Empty;
           // Formload();
        }

        private void typesearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {
            //Formload();
        }

        private void UCform_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void excelbutton_Click(object sender, EventArgs e)
        {
            DataExportToExcel();
        }

        private void pdfbutton_Click(object sender, EventArgs e)
        {
            DataExportToPDF();
        }
    }

    public class RegisterBookColumns
    {
        public string sln { get; set; }
        public string nothiNo { get; set; }
        public string previousNothiNo { get; set; }
        public string type { get; set; }
        public string nothiEntryDate { get; set; }
    }
}

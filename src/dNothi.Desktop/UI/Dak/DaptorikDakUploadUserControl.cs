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
using dNothi.JsonParser.Entity.Dak;
using AutoMapper;
using dNothi.Services.DakServices;
using System.IO;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DaptorikDakUploadUserControl : UserControl
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF" };
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        List<string> sendMediumListCollection = new List<string>();
        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();

        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        bool NijOffice = true;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        List<DakAttachmentinGrid> _dakAttachmentinGrids = new List<DakAttachmentinGrid>();
      
      


        public DaptorikDakUploadUserControl()
        {
            InitializeComponent();


            PriorityListCollection.Clear();

            DakAttachmentListinGrid dakAttachmentListinGrid = new DakAttachmentListinGrid();
            _dakAttachmentinGrids = dakAttachmentListinGrid.dakAttachmentinGrids;



            //attachmentListFlowLayoutPanel.Controls.Clear();
            //DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();
            //dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
            //dakUploadAttachmentTableRow.imageLink = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDg3MjEzNzUsImlhdCI6MTYwODYzNDM3NSwianRpIjoiTVRZd09EWXpORE0zTlE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg2MzQzNzUsImRhdGEiOnsiZmlsZSI6IkdrbDBhNVZvTkNNUmtLTWsxQ1NoWGI4bEJvVVpJMDJtZkorQUg2ZjZjS2Q1WHFBRFFmQU94TmZHU29wRHNYUmR2TjFOYnFlMnN5bnRPR2FIZStoSG5DOTJYT1JyWENoMFJUNHRIbFNGR3Jja1g0YUxlcWZHaEJKVDFWTjhQZWdRRXcxZGM4Snk3SldKcTk4dGZyR2duMFJyMzBOaGpUa3E2azd1M3U2Q1Job29sQUNiZ2laZ240Y2VOSlNWbE5HMlFRWCtUWXdTcGJFR0ttTzFjalhNM3c9PSIsImRlc2lnbmF0aW9uIjoiYVJpMkNVbUlRdXJuclwvYXBCN251Zk9uYWVQaTIxRFF2WVpuV0xCT01mV0RJTnhWZ2QrWW5xcG9rVEVyQ09paHZDbXZGc1BQYkgxSTdQaHFUdlFrcG13PT0ifX0.Q1OZt-HCPQ7VCVnSN6LQIBaqY6L4dSC2ZtL8R--lb55lzdaKIOACSyyA4S8sNATmt2Jgf27W_gFoelFOBVPJWQ";
            //dakUploadAttachmentTableRow.imgSource = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDkwMTI5MjgsImlhdCI6MTYwODkyNTkyOCwianRpIjoiTVRZd09Ea3lOVGt5T0E9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg5MjU5MjgsImRhdGEiOnsiZmlsZSI6IkNLUUJRY2RJamtQUTlOeXhvUEJ1M1Y2UGthZ08wQTlWNzhBWms3blVtbmpIblZsTTMxZmxzQk1OTFVZdWR0UmFYTU9Yd1RXekNJejl4eVJnQUM3MEE4bWQyNmNQTFN1U1wva1c3M3VleUxkQ0lrRVwvcnJGVnpqS0gwRWJLUUQzSDRFVm9qWjR5Z2w1cFdcL2NHRmROMTg1QjZ2ZWw0YTBkOFUwRUVySzZZblFtRnkxbUFIbXZYeW9mMUhCd1wvRXlOc3hLVmlTeXVva1A4ZVwvdlY5Q0pvcnQ0QT09IiwiZGVzaWduYXRpb24iOiJQK3EyRDVuSlBaekgwbjRZN2daclg5RGdpNmRhWFdoWnFtR3NNV3NxQ1MzdjNDNmVoVHdKU0lXbkJsV05qMGRqWTlLWUM4WDlGOWtsOElOR0I0ZFVDdz09In19.N1-nRj1V625a6_SnFxduNutcCNLxEqAK13bj4ABqElAvSmg_SLPFTXIais8uGRzE26totIDVTpfZfbAFC3k2Ng";
            //dakUploadAttachmentTableRow.attachmentName = "LoginPanel.jpg";
            //dakUploadAttachmentTableRow.attachmentId = 1;
            //dakUploadAttachmentTableRow.RadioButtonClick += delegate (object sender, EventArgs e) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow.attachmentId); };


            //attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);

            //DakUploadAttachmentTableRow dakUploadAttachmentTableRow2 = new DakUploadAttachmentTableRow();
            //dakUploadAttachmentTableRow2.isAllowedforMulpotro = true;
            //dakUploadAttachmentTableRow2.imageLink = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDg3MjEzNzUsImlhdCI6MTYwODYzNDM3NSwianRpIjoiTVRZd09EWXpORE0zTlE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg2MzQzNzUsImRhdGEiOnsiZmlsZSI6IkdrbDBhNVZvTkNNUmtLTWsxQ1NoWGI4bEJvVVpJMDJtZkorQUg2ZjZjS2Q1WHFBRFFmQU94TmZHU29wRHNYUmR2TjFOYnFlMnN5bnRPR2FIZStoSG5DOTJYT1JyWENoMFJUNHRIbFNGR3Jja1g0YUxlcWZHaEJKVDFWTjhQZWdRRXcxZGM4Snk3SldKcTk4dGZyR2duMFJyMzBOaGpUa3E2azd1M3U2Q1Job29sQUNiZ2laZ240Y2VOSlNWbE5HMlFRWCtUWXdTcGJFR0ttTzFjalhNM3c9PSIsImRlc2lnbmF0aW9uIjoiYVJpMkNVbUlRdXJuclwvYXBCN251Zk9uYWVQaTIxRFF2WVpuV0xCT01mV0RJTnhWZ2QrWW5xcG9rVEVyQ09paHZDbXZGc1BQYkgxSTdQaHFUdlFrcG13PT0ifX0.Q1OZt-HCPQ7VCVnSN6LQIBaqY6L4dSC2ZtL8R--lb55lzdaKIOACSyyA4S8sNATmt2Jgf27W_gFoelFOBVPJWQ";
            //dakUploadAttachmentTableRow2.imgSource = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDkwMTI5MjgsImlhdCI6MTYwODkyNTkyOCwianRpIjoiTVRZd09Ea3lOVGt5T0E9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg5MjU5MjgsImRhdGEiOnsiZmlsZSI6IkNLUUJRY2RJamtQUTlOeXhvUEJ1M1Y2UGthZ08wQTlWNzhBWms3blVtbmpIblZsTTMxZmxzQk1OTFVZdWR0UmFYTU9Yd1RXekNJejl4eVJnQUM3MEE4bWQyNmNQTFN1U1wva1c3M3VleUxkQ0lrRVwvcnJGVnpqS0gwRWJLUUQzSDRFVm9qWjR5Z2w1cFdcL2NHRmROMTg1QjZ2ZWw0YTBkOFUwRUVySzZZblFtRnkxbUFIbXZYeW9mMUhCd1wvRXlOc3hLVmlTeXVva1A4ZVwvdlY5Q0pvcnQ0QT09IiwiZGVzaWduYXRpb24iOiJQK3EyRDVuSlBaekgwbjRZN2daclg5RGdpNmRhWFdoWnFtR3NNV3NxQ1MzdjNDNmVoVHdKU0lXbkJsV05qMGRqWTlLWUM4WDlGOWtsOElOR0I0ZFVDdz09In19.N1-nRj1V625a6_SnFxduNutcCNLxEqAK13bj4ABqElAvSmg_SLPFTXIais8uGRzE26totIDVTpfZfbAFC3k2Ng";
            //dakUploadAttachmentTableRow2.attachmentName = "LoginPanel.jpg";
            //dakUploadAttachmentTableRow2.attachmentId = 2;
            //dakUploadAttachmentTableRow2.RadioButtonClick += delegate (object sender, EventArgs e) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow2.attachmentId); };

            //attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow2);
        }

        private void AttachmentTable_RadioButtonClick(object sender, EventArgs e, long attachmentId)
        {
            var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

            foreach (var attachment in attachmentList)
            {
                if(attachment.attachmentId!=attachmentId)
                {
                    attachment.isMulpotro = false;
                }
            }
               
        }

        private DesignationSealListResponse _designationSealListResponse;


        public DesignationSealListResponse designationSealListResponse
        {
            get { return _designationSealListResponse; }
            set
            {
                _designationSealListResponse = value;
                try
                {
                    foreach (PrapokDTO ownOfficeDTO in value.data.own_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOwnOffice = mapper.Map<ViewDesignationSealList>(ownOfficeDTO);



                        viewdesignationListOwnOffice.nij_Office = true;
                        viewDesignationSealLists.Add(viewdesignationListOwnOffice);
                    }

                    foreach (PrapokDTO otherOfficeDTO in value.data.other_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOtherOffice = mapper.Map<ViewDesignationSealList>(otherOfficeDTO);

                        viewDesignationSealLists.Add(viewdesignationListOtherOffice);
                    }

                    PopulateGrid();
                }
                catch
                {

                }



            }

        }


        int designationColumn = 2;
        private void SaveOnulipiPrapok(int row_index)
        {

            for (int i = 0; i <= prapokDataGridView.Rows.Count - 1; i++)
            {
                if (i == row_index)
                {
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    SetThisMulprapokfalse(designation_id);
                }
            }
        }

        private void SetThisMulprapokfalse(int designation_id)
        {
            viewDesignationSealLists.FirstOrDefault(a => a.designation_id == designation_id).mul_prapok = false;


        }

        private void SaveMulPrapok(int row_index)
        {
            for (int i = 0; i <= prapokDataGridView.Rows.Count - 1; i++)
            {
                prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;

                if (i != row_index)
                {
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                }
                else
                {
                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;

                    SetOtherMulprapokfalse(designation_id);

                }
            }
        }

        private void SetOtherMulprapokfalse(int designation_id)
        {
            foreach (ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists)
            {
                if (viewDesignationSealList.designation_id != designation_id)
                {
                    viewDesignationSealList.mul_prapok = false;
                }
                else
                {
                    viewDesignationSealList.mul_prapok = true;
                }
            }
        }

        private void ownOfficeButton_Click(object sender, EventArgs e)
        {
            PopulateGrid();


        }
        public void PopulateGrid()
        {
            prapokDataGridView.DataSource = null;
            prapokDataGridView.DataSource = viewDesignationSealLists.Where(a => a.nij_Office == NijOffice).ToList();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

      
        private void dakUploadPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;
            //bool mulprapok = (bool)prapokDataGridView.Rows[row_index].Cells[mulPrapokColumn].Value;
            //bool Onulipi = (bool)prapokDataGridView.Rows[row_index].Cells[onulipiColumn].Value;
            //  if(e.ColumnIndex==prapokDataGridView.Columns["mul_prapok"].Index)
            if (e.ColumnIndex == mulPrapokColumn)
            {
                SaveMulPrapok(row_index);
            }
            else if (e.ColumnIndex == onulipiColumn)
            {
                SaveOnulipiPrapok(row_index);
            }

            prapokDataGridView.Refresh();
        }

        private void officerSearchXTextBox_TextChanged(object sender, EventArgs e)
        {

            var prapokList = prapokDataGridView.DataSource;

            List<ViewDesignationSealList> designationSealListsinGridView = (List<ViewDesignationSealList>)prapokList;
            List<ViewDesignationSealList> NewViewDesignationSealLists = new List<ViewDesignationSealList>();


            if (officerSearchXTextBox.Text == "")
            {
                PopulateGrid();
            }
            else
            {
                foreach (var des in designationSealListsinGridView)
                {
                    if (des.designation.StartsWith(officerSearchXTextBox.Text)|| des.employee_name_bng.StartsWith(officerSearchXTextBox.Text))
                    {
                        NewViewDesignationSealLists.Add(des);
                    }

                }
                prapokDataGridView.DataSource = null;
                prapokDataGridView.DataSource = NewViewDesignationSealLists.ToList();
            }

           
                
                }

        private void ownOfficeButton_Click_1(object sender, EventArgs e)
        {
            NijOffice = false;
            PopulateGrid();
        }

        private void senderSearchButton_Click(object sender, EventArgs e)
        {
            senderSortSidePanel.Visible = true;
            HoverColorChangeSenderSearchButton();
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            senderSortSidePanel.Visible = false;
            NormalColorSenderSearchButton();
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new FileInfo(opnfd.FileName).Name;
               


                //Read the contents of the file into a stream
                var fileStream = opnfd.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _dakFileUploadParam.content = reader.ReadToEnd();
                }


                // _dakFileUploadParam.file_size_in_kb=opnfd.


                var size = new FileInfo(opnfd.FileName).Length;

                _dakFileUploadParam.file_size_in_kb = size.ToString() + " KB";

               

                DakUploadedFileResponse dakUploadedFileResponse=new DakUploadedFileResponse();

                using (var form = FormFactory.Create<Dashboard>())
                {
                  dakUploadedFileResponse= form.UploadFile(_dakFileUploadParam);
                }

                if(dakUploadedFileResponse.status== "success")
                {
                    if(dakUploadedFileResponse.data.Count>0)
                    {
                        //attachmentListFlowLayoutPanel.Controls.Clear();
                        DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();
                        if (ImageExtensions.Contains(new FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            dakUploadAttachmentTableRow._isAllowedforOCR = true;
                       
                            using (Image image = Image.FromFile(opnfd.FileName))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    image.Save(m, image.RawFormat);
                                    byte[] imageBytes = m.ToArray();

                                    // Convert byte[] to Base64 String
                                    dakUploadAttachmentTableRow.imageBase64String = Convert.ToBase64String(imageBytes);
                                  
                                }
                            }



                             
                        }
                        else if(PdfExtensions.Contains(new FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                          
                        }
                        else
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }



                        dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        dakUploadAttachmentTableRow.fileexension = new FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
                        dakUploadAttachmentTableRow._dakAttachment = dakUploadedFileResponse.data[0];
                        dakUploadAttachmentTableRow.imageLink = dakUploadedFileResponse.data[0].url;
                        dakUploadAttachmentTableRow.imgSource = dakUploadedFileResponse.data[0].thumbnail_url;
                        dakUploadAttachmentTableRow.attachmentName = dakUploadedFileResponse.data[0].file_name;
                        dakUploadAttachmentTableRow.attachmentId = dakUploadedFileResponse.data[0].attachment_id; ;
                        dakUploadAttachmentTableRow.RadioButtonClick += delegate (object radioSender, EventArgs radioEvent) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow.attachmentId); };


                        attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);
                    }
                }

            }


        }

        private void DeleteControl_ButtonClick(object sender, EventArgs e, DakAttachmentDTO dakAttachment)
        {
            DakUploadFileDeleteParam deleteParam = new DakUploadFileDeleteParam();
            deleteParam.delete_token = dakAttachment.delete_token;
            deleteParam.file_name = dakAttachment.file_name;

            DakFileDeleteResponse response;

            using (var form = FormFactory.Create<Dashboard>())
            {
                response = form.DeleteFile(deleteParam);
            }
            if (response.status != "success")

            {
                var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

                foreach (var attachment in attachmentList)
                {
                    if (attachment.attachmentId == dakAttachment.attachment_id)
                    {
                        attachmentListFlowLayoutPanel.Controls.Remove(attachment);
                    }
                }
            }

                   
        }

        private void OCRControl_ButtonClick(object sender, EventArgs e, string imageBase64String, DakAttachmentDTO dakAttachment,string Extension)
        {
            OCRParameter oCRParameter = new OCRParameter();
            oCRParameter.data = imageBase64String;
            oCRParameter.Extension = Extension;

            OCRResponse oCRResponse = new OCRResponse();

            using (var form = FormFactory.Create<Dashboard>())
            {
                oCRResponse = form.OCRFile(oCRParameter);
            }

            dakDescriptionXTextBox.Text = oCRResponse.text;

        }

        private void attachmentDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 4)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 4)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //var w = Properties.Resources.SomeImage.Width;
                //var h = Properties.Resources.SomeImage.Height;
                //var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                //var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                //e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                //e.Handled = true;
            }
        }

        private void searchOfficerRightXTextBox_TextChanged(object sender, EventArgs e)
        {
            searchOfficerRightListBox.Items.Clear();
            if (searchOfficerRightXTextBox.Text == "")
            {
                searchOfficerRightResultLabel.Text = "Please Enter 4 or More Character";
                searchOfficerRightListBox.Visible = false;

            }
            else 
            {
              
                List<ViewDesignationSealList> viewDesignationSealListsforOfficerSearch = viewDesignationSealLists.Where(a => a.employee_name_bng.StartsWith(searchOfficerRightXTextBox.Text)).ToList();
               
                if(officerSearchRightNijOfficeCheckBox.Checked && viewDesignationSealListsforOfficerSearch.Count>0)
                {
                    viewDesignationSealListsforOfficerSearch = viewDesignationSealListsforOfficerSearch.Where(a=>a.nij_Office == officerSearchRightNijOfficeCheckBox.Checked).ToList();
                }
                
                
                if(viewDesignationSealListsforOfficerSearch.Count>0)
                {
                    foreach (var officer in viewDesignationSealListsforOfficerSearch)
                    {
                        searchOfficerRightListBox.Items.Add(officer.employee_name_bng + "," + officer.designation);


                    }
                    searchOfficerRightListBox.Visible = true;
                }
                else
                {
                    searchOfficerRightListBox.Visible = false;
                    searchOfficerRightResultLabel.Text = "No Result Found!";
                }

            }
        }

        private void searchOfficerRightButton_Click(object sender, EventArgs e)
        {
           if (searchOfficerRightPanel.Visible)
            {
                
                searchOfficerRightPanel.Visible = false;
            }
            else
            {
                searchOfficerRightXTextBox.Text = "";
                searchOfficerRightListBox.Visible = false;
                searchOfficerRightPanel.Visible = true;
                searchOfficerRightResultLabel.Text = "Please Enter 4 or More Character";
               
                searchOfficerRightXTextBox.Focus();
            }
        }

        private void searchOfficerRightListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            searchOfficerRightPanel.Visible = false;
            searchOfficerRightButton.Text = searchOfficerRightListBox.GetItemText(searchOfficerRightListBox.SelectedItem);
        }

        private void prerokBachaiButton_Click(object sender, EventArgs e)
        {
            selectedPrerokLabel.Text = searchOfficerRightButton.Text.ToString();
        }

        private void searchOfficerRightControl_Load(object sender, EventArgs e)
        {

        }

        private void prerokBachaifroOfficeRightButton_Click(object sender, EventArgs e)
        {
            selectedPrerokLabel.Text =searchOfficerRightControl.searchButtonText+","+searchDesignationRightControl.searchButtonText+","+searchUnitRightControl.searchButtonText+","+ searchCascadingOfficeRightControl.searchButtonText;
        }

        private void prerokBachaiOwnRightButton_Click(object sender, EventArgs e)
        {
            selectedPrerokLabel.Text = officerManualEntryXTextBox.Text + "," + designationManualEntryXTextBox.Text + "," + unitAddressManualEntryXTextBox.Text + "," + officeAddressManualEntryXTextBox.Text + ",Mobile:" + mobileAddressManualEntryXTextBox.Text + ", Email:" + emailAddressManualEntryXTextBox.Text;
        }

        private void dakUploadAttachmentTableRow1_Load(object sender, EventArgs e)
        {

        }

        private void fileUploadPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void senderSearchButton_MouseHover(object sender, EventArgs e)
        {
            HoverColorChangeSenderSearchButton();
        }

        private void HoverColorChangeSenderSearchButton()
        {
            senderSearchButton.BackColor = Color.FromArgb(54, 153, 255);
            senderSearchButton.ForeColor = Color.White;
            senderSearchButton.IconColor = Color.White;

        }
        private void NormalColorSenderSearchButton()
        {
            senderSearchButton.BackColor = Color.Transparent;
            senderSearchButton.ForeColor = Color.FromArgb(54, 153, 255);
            senderSearchButton.IconColor = Color.FromArgb(54, 153, 255);

        }

        private void senderSearchButton_Enter(object sender, EventArgs e)
        {
            NormalColorSenderSearchButton();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        

        private void senderSearchButton_MouseLeave(object sender, EventArgs e)
        {
            NormalColorSenderSearchButton();
        }
    }
}

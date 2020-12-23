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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DaptorikDakUploadUserControl : UserControl
    {
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        List<string> sendMediumListCollection = new List<string>();
      
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



            attachmentListFlowLayoutPanel.Controls.Clear();
            DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();
            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
            dakUploadAttachmentTableRow.imageLink = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDg3MjEzNzUsImlhdCI6MTYwODYzNDM3NSwianRpIjoiTVRZd09EWXpORE0zTlE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg2MzQzNzUsImRhdGEiOnsiZmlsZSI6IkdrbDBhNVZvTkNNUmtLTWsxQ1NoWGI4bEJvVVpJMDJtZkorQUg2ZjZjS2Q1WHFBRFFmQU94TmZHU29wRHNYUmR2TjFOYnFlMnN5bnRPR2FIZStoSG5DOTJYT1JyWENoMFJUNHRIbFNGR3Jja1g0YUxlcWZHaEJKVDFWTjhQZWdRRXcxZGM4Snk3SldKcTk4dGZyR2duMFJyMzBOaGpUa3E2azd1M3U2Q1Job29sQUNiZ2laZ240Y2VOSlNWbE5HMlFRWCtUWXdTcGJFR0ttTzFjalhNM3c9PSIsImRlc2lnbmF0aW9uIjoiYVJpMkNVbUlRdXJuclwvYXBCN251Zk9uYWVQaTIxRFF2WVpuV0xCT01mV0RJTnhWZ2QrWW5xcG9rVEVyQ09paHZDbXZGc1BQYkgxSTdQaHFUdlFrcG13PT0ifX0.Q1OZt-HCPQ7VCVnSN6LQIBaqY6L4dSC2ZtL8R--lb55lzdaKIOACSyyA4S8sNATmt2Jgf27W_gFoelFOBVPJWQ";
            dakUploadAttachmentTableRow.imgSource = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDg3MjEzNzUsImlhdCI6MTYwODYzNDM3NSwianRpIjoiTVRZd09EWXpORE0zTlE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg2MzQzNzUsImRhdGEiOnsiZmlsZSI6ImpmQ3BpdFkyaGpRejZ5TDBFZG0reGJrZ0FkTFduazNYS2ZmOXhSM0JWMmxcLzh5bEJcLzk2TUs5WHlWS0ljTmh5VFwvc25GY1hMYmlUaFBQRmFMcnBCQkpKOFdjaXByRWxTZGlWazFqQTFmM3gwUHBOSTJmM0FPSkJVV0Z3M3N5a1wvcnZjUkErZHJaSkVORHdhaFRuOURoOTNQdW9sUDRkNHY0ekM2V1A3RnF5VGtMR1JnM3lGclJNY2ZzQmQrd0E3cFNCZ2pPd0J2aGJMbVdtQWlNV1JINTdRPT0iLCJkZXNpZ25hdGlvbiI6IjYwT0xXeFQrWEIyTlNLcmJ4NURraFR1SXdtVCsrTmtSNUtcLzQrV2QrejlZaHVcLzBxZHF2bXo2VWJRNWZCTHJXamU5emcxUXhQRXh2YWJacXNTMmZLdnc9PSJ9fQ.tWCCEbq5Ua5YsqurGg2u3Ij9qkS0e1ZlupjjgJRGEpJq_xgGCzjtcL4FS-bqLlDFsrAiqjzXSJCegSqhv04OnA";
            dakUploadAttachmentTableRow.attachmentName = "LoginPanel.jpg";
            dakUploadAttachmentTableRow.attachmentId = 1;
            dakUploadAttachmentTableRow.RadioButtonClick += delegate (object sender, EventArgs e) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow.attachmentId); };


            attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);

            DakUploadAttachmentTableRow dakUploadAttachmentTableRow2 = new DakUploadAttachmentTableRow();
            dakUploadAttachmentTableRow2.isAllowedforMulpotro = true;
            dakUploadAttachmentTableRow2.imageLink = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDg3MjEzNzUsImlhdCI6MTYwODYzNDM3NSwianRpIjoiTVRZd09EWXpORE0zTlE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg2MzQzNzUsImRhdGEiOnsiZmlsZSI6IkdrbDBhNVZvTkNNUmtLTWsxQ1NoWGI4bEJvVVpJMDJtZkorQUg2ZjZjS2Q1WHFBRFFmQU94TmZHU29wRHNYUmR2TjFOYnFlMnN5bnRPR2FIZStoSG5DOTJYT1JyWENoMFJUNHRIbFNGR3Jja1g0YUxlcWZHaEJKVDFWTjhQZWdRRXcxZGM4Snk3SldKcTk4dGZyR2duMFJyMzBOaGpUa3E2azd1M3U2Q1Job29sQUNiZ2laZ240Y2VOSlNWbE5HMlFRWCtUWXdTcGJFR0ttTzFjalhNM3c9PSIsImRlc2lnbmF0aW9uIjoiYVJpMkNVbUlRdXJuclwvYXBCN251Zk9uYWVQaTIxRFF2WVpuV0xCT01mV0RJTnhWZ2QrWW5xcG9rVEVyQ09paHZDbXZGc1BQYkgxSTdQaHFUdlFrcG13PT0ifX0.Q1OZt-HCPQ7VCVnSN6LQIBaqY6L4dSC2ZtL8R--lb55lzdaKIOACSyyA4S8sNATmt2Jgf27W_gFoelFOBVPJWQ";
            dakUploadAttachmentTableRow2.imgSource = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDg3MjEzNzUsImlhdCI6MTYwODYzNDM3NSwianRpIjoiTVRZd09EWXpORE0zTlE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDg2MzQzNzUsImRhdGEiOnsiZmlsZSI6ImpmQ3BpdFkyaGpRejZ5TDBFZG0reGJrZ0FkTFduazNYS2ZmOXhSM0JWMmxcLzh5bEJcLzk2TUs5WHlWS0ljTmh5VFwvc25GY1hMYmlUaFBQRmFMcnBCQkpKOFdjaXByRWxTZGlWazFqQTFmM3gwUHBOSTJmM0FPSkJVV0Z3M3N5a1wvcnZjUkErZHJaSkVORHdhaFRuOURoOTNQdW9sUDRkNHY0ekM2V1A3RnF5VGtMR1JnM3lGclJNY2ZzQmQrd0E3cFNCZ2pPd0J2aGJMbVdtQWlNV1JINTdRPT0iLCJkZXNpZ25hdGlvbiI6IjYwT0xXeFQrWEIyTlNLcmJ4NURraFR1SXdtVCsrTmtSNUtcLzQrV2QrejlZaHVcLzBxZHF2bXo2VWJRNWZCTHJXamU5emcxUXhQRXh2YWJacXNTMmZLdnc9PSJ9fQ.tWCCEbq5Ua5YsqurGg2u3Ij9qkS0e1ZlupjjgJRGEpJq_xgGCzjtcL4FS-bqLlDFsrAiqjzXSJCegSqhv04OnA";
            dakUploadAttachmentTableRow2.attachmentName = "LoginPanel.jpg";
            dakUploadAttachmentTableRow2.attachmentId = 2;
            dakUploadAttachmentTableRow2.RadioButtonClick += delegate (object sender, EventArgs e) { AttachmentTable_RadioButtonClick(sender, e, dakUploadAttachmentTableRow2.attachmentId); };

            attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow2);
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
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            senderSortSidePanel.Visible = false;
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
           //opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            opnfd.ShowDialog();

            
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
    }
}

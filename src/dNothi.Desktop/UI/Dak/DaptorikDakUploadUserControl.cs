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
using dNothi.Utility;

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
        public int _prerokId = 0;
        private DakListUserParam _dak_List_User_Param;
        public DakUploadParameter dakUploadParameter = new DakUploadParameter();


        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        bool NijOffice = true;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        List<DakAttachmentinGrid> _dakAttachmentinGrids = new List<DakAttachmentinGrid>();


        public DakListUserParam dakListUserParam
        {
            get { return _dak_List_User_Param; }
            set { _dak_List_User_Param = value; }
        
        }


        public DaptorikDakUploadUserControl()
        {
            InitializeComponent();


            PriorityListCollection.Clear();

            DakAttachmentListinGrid dakAttachmentListinGrid = new DakAttachmentListinGrid();
            _dakAttachmentinGrids = dakAttachmentListinGrid.dakAttachmentinGrids;

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
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;
               


                //Read the contents of the file into a stream
                var fileStream = opnfd.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _dakFileUploadParam.content = reader.ReadToEnd();
                }


                // _dakFileUploadParam.file_size_in_kb=opnfd.


                var size = new System.IO.FileInfo(opnfd.FileName).Length;

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
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
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
                        else if(PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                          
                        }
                        else
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }



                        dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        dakUploadAttachmentTableRow.fileexension = new System.IO.FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
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
            if (response.status == "success")

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
            searchOfficerRightListBox.DataSource = null;
            if (searchOfficerRightXTextBox.Text == "")
            {
                searchOfficerRightResultLabel.Text = "";
                searchOfficerRightListBox.Visible = false;

            }
            else 
            {
              
                List<ViewDesignationSealList> viewDesignationSealListsforOfficerSearch = viewDesignationSealLists.Where(a => a.employee_name_bng.Contains(searchOfficerRightXTextBox.Text)).ToList();
               
              
                
                
                if(viewDesignationSealListsforOfficerSearch.Count>0)
                {
                    searchOfficerRightListBox.DisplayMember = "designationwithname";
                    searchOfficerRightListBox.DataSource = null;
                    searchOfficerRightListBox.DataSource = viewDesignationSealListsforOfficerSearch;

                    searchOfficerRightListBox.Visible = true;
                }
                else
                {
                    searchOfficerRightListBox.Visible = false;
                    searchOfficerRightResultLabel.Text = "";
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
                searchOfficerRightResultLabel.Text = "";
               
                searchOfficerRightXTextBox.Focus();
            }
        }

        private void searchOfficerRightListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }

        private void prerokBachaiButton_Click(object sender, EventArgs e)
        {
            selectedPrerokLabel.Text = officerSearchOfficerNameLabel.Text.ToString();
            try
            {
                _prerokId = Convert.ToInt32(officerSearchOfficerIdLabel.Text);
            }
            catch(Exception Ex)
            {
                MessageBox.Show("অফিসার সিলেক্ট করুন!");
            }

            senderSortSidePanel.Visible = false;
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

        private void searchOfficerRightListBox_Click(object sender, EventArgs e)
        {
            searchOfficerRightPanel.Visible = false;
            officerSearchOfficerNameLabel.Text = searchOfficerRightListBox.GetItemText(searchOfficerRightListBox.SelectedItem);
            officerSearchOfficerIdLabel.Text = (searchOfficerRightListBox.SelectedItem as ViewDesignationSealList).designation_id.ToString();

        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler KhosraSaveButtonClick;
        private void khosraSaveButton_Click(object sender, EventArgs e)
        {
          

            //uploader
            
            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<DakListUserParam, DakForwardRequestSenderInfo>()
                  );
            var mapper = new Mapper(config);
            var dakSender = mapper.Map<DakForwardRequestSenderInfo>(_dak_List_User_Param);


            dakUploadParameter.uploader = dakUploadParameter.CSharpObjtoJson(dakSender);

            //Sender
           var sender_info = designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == _prerokId);
           if(sender_info == null)
            {
                sender_info= designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == _prerokId);
            }

            dakUploadParameter.sender_info = dakUploadParameter.CSharpObjtoJson(sender_info);


            // Dak

            DakInfo dak = new DakInfo(false);

            List<DakUploadAttachment> dakUploadAttachments = new List<DakUploadAttachment>();

            var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

            foreach (var attachment in attachmentList)
            {
                DakUploadAttachment dakUploadAttachment = new DakUploadAttachment();
                if(attachment.isMulpotro)
                {
                    dakUploadAttachment.mulpotro = 1;
                }
                dakUploadAttachment.file_info = dakUploadParameter.CSharpObjtoJson(attachment._dakAttachment);
                dakUploadAttachments.Add(dakUploadAttachment);


            }

            dak.attachment=dakUploadParameter.CSharpObjtoJson(dakUploadAttachments);
            dak.sarok_no = sharokNoTextBox.Text;
            dak.dak_subject = subjectXTextBox.Text;
            dak.sending_date = DateTime.Now.ToString("dd-MM-yyyy");
            dak.sending_media = sendMediumSearchButton.searchButtonText;
      
            dak.dak_description = dakDescriptionXTextBox.Text;





            DakPriorityList dakPriority = new DakPriorityList();
            int dak_priority_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.Text.ToString()));



            DakSecurityList dakSecurityList = new DakSecurityList();
            int dak_security_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.Text.ToString()));

            dak.priority = dak_priority_id.ToString();
            dak.security = dak_security_id.ToString();


            dakUploadParameter.dak_info = dakUploadParameter.CSharpObjtoJson(dak);
           
            
            // Receiver
            DakUploadReceiver dakUploadReceiver = new DakUploadReceiver();

            ViewDesignationSealList mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);

            if (mulprapok.nij_Office == true)
            {
                var receiver_info = designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                dakUploadReceiver.mul_prapok = receiver_info;
            }
            else
            {
                var receiver_info = designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                dakUploadReceiver.mul_prapok = receiver_info;
            }


            // onulipi
            List<PrapokDTO> OnulipiprapokDTOs = new List<PrapokDTO>();

            List<ViewDesignationSealList> viewDesignationSealListsOnulipPrapok = viewDesignationSealLists.Where(a => a.onulipi_prapok == true).ToList();
            foreach (ViewDesignationSealList viewDesignationSeal in viewDesignationSealListsOnulipPrapok)
            {
                if (viewDesignationSeal.nij_Office == true)
                {
                    OnulipiprapokDTOs.Add(designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                }
                else
                {
                    OnulipiprapokDTOs.Add(designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                }
            }

            dakUploadReceiver.onulipi = OnulipiprapokDTOs;







            dakUploadParameter.receiver_info = dakUploadParameter.CSharpObjtoJson(dakUploadReceiver);
            dakUploadParameter.others = "[]";
           // dakUploadParameter.path = sendMediumSearchButton.searchButtonText;
            dakUploadParameter.content = dakDescriptionXTextBox.Text;
            dakUploadParameter.office_id = _dak_List_User_Param.office_id;
            dakUploadParameter.designation_id = _dak_List_User_Param.designation_id;
        

            if (this.KhosraSaveButtonClick != null)
                this.KhosraSaveButtonClick(sender, e);




        }
        public event EventHandler AddDesignationButtonClick;
        private void addDesignationButton_Click(object sender, EventArgs e)
        {
            if (this.AddDesignationButtonClick != null)
                this.AddDesignationButtonClick(sender, e);

        }
    }
}

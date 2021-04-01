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
using System.Net;
using System.Net.Http;
using dNothi.Constants;
using dNothi.Desktop.UI.CustomMessageBox;
using System.Drawing.Text;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DaptorikDakUploadUserControl : UserControl
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG","JPE", "BMP", "GIF", "PNG", ".JPE", ".BMP", ".GIF", ".PNG","IMAGE","IMG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF","PDF" };
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        List<string> sendMediumListCollection = new List<string>();
        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        public int _prerokId = 0;
        public int _dakId = 0;
        private DakUserParam _dak_List_User_Param;
        public DakUploadParameter dakUploadParameter = new DakUploadParameter();
        public List<DakAttachmentDTO> _dakAttachmentDTOs = new List<DakAttachmentDTO>();
        public DakInfoDTO _dakInfoDTO = new DakInfoDTO();
        public PrapokDTO _mul_prapok = new PrapokDTO();
        public Dictionary<string, PrapokDTO> _onulipi;


        public string prerokName;
        public string prapokName;
        public string sub;

        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        bool NijOffice = true;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        List<DakAttachmentinGrid> _dakAttachmentinGrids = new List<DakAttachmentinGrid>();
        
        public PrapokDTO mul_prapokEdit { get { return _mul_prapok; } set { _mul_prapok = value; viewDesignationSealLists.FirstOrDefault(a => a.designation_id == value.designation_id).mul_prapok = true; } }
        public Dictionary<string, PrapokDTO> onulipi { get { return _onulipi; } 
            set { 
                _onulipi = value;
                foreach (KeyValuePair<string, PrapokDTO> prapok in value)
                {
                    viewDesignationSealLists.FirstOrDefault(a => a.designation_id == prapok.Value.designation_id).onulipi_prapok = true;
                }
            } 
        }

        public MessageBoxMessage _message = new MessageBoxMessage();
      
        public DakInfoDTO dakInfoDTO {
            get { return _dakInfoDTO; }
            set { 
                _dakInfoDTO = value; 
                _prerokId = value.sender_officer_designation_id; 
                selectedPrerokLabel.Text = value.receiving_officer_name + "," + value.receiving_officer_designation_label + "," + value.receiving_office_unit_name + "," + value.receiving_office_name;
                
                
                sharokNoTextBox.Text = value.sender_sarok_no;
                //sharokdateTimePicker.Text = value.sending_date;
              
                subjectXTextBox.Text=value.dak_subject;
                _dakId = value.id;
               
                if(value.dak_sending_media !="")
                {
                    sendMediumSearchButton.searchButtonText = value.dak_sending_media;
                }
            

                dakDescriptionXTextBox.Text=value.dak_description;


                if(value.dak_priority_level !="0")
                {
                    DakPriorityList dakPriority = new DakPriorityList();
                    prioritySearchButton.searchButtonText = dakPriority.GetDakPriorityName(value.dak_priority_level);



                   
                 
                }
                if (value.dak_security_level != "0")
                {
                    DakSecurityList dakSecurityList = new DakSecurityList();
                    seurityLevelSearchButton.searchButtonText = dakSecurityList.GetDakSecuritiesName(value.dak_security_level);

                   
                }
              
               
               

            }
                
        }

        public List<DakAttachmentDTO> dakAttachmentDTOs {
            get { return _dakAttachmentDTOs; }
            set { _dakAttachmentDTOs = value;
                 if(value != null)
                {
                    if(value.Count>0)
                    {
                        foreach(DakAttachmentDTO attachment in dakAttachmentDTOs)
                        {
                            DakUploadAttachmentTableRow dakUploadAttachmentTableRow = new DakUploadAttachmentTableRow();
                                 
                            if(attachment.attachment_type.ToUpperInvariant().Contains("IMAGE"))
                            {
                                dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                                dakUploadAttachmentTableRow._isAllowedforOCR = true;
                                try
                                {
                                    using (Image image = Image.FromFile(attachment.url))
                                    {
                                        using (MemoryStream m = new MemoryStream())
                                        {
                                            image.Save(m, image.RawFormat);
                                            byte[] imageBytes = m.ToArray();
                                            // dakUploadAttachmentTableRow.imgSource = image.;
                                            // Convert byte[] to Base64 String
                                            dakUploadAttachmentTableRow.imageBase64String = Convert.ToBase64String(imageBytes);

                                        }
                                    }
                                }
                                catch (Exception Ex)
                                {

                                }
                            }


                            else if (attachment.attachment_type.ToUpperInvariant().Contains("PDF"))
                            {
                                dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                                dakUploadAttachmentTableRow._isAllowedforOCR = true;

                            }
                            else
                            {
                                dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                            }

                            if(attachment.is_main==1)
                            {
                                dakUploadAttachmentTableRow.isMulpotro = true;
                            }



                            dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(oCRSender, oCREvent, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                            dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(deleteSender, deleteeVent, dakUploadAttachmentTableRow._dakAttachment); };



                            dakUploadAttachmentTableRow.fileexension = attachment.attachment_type.ToLowerInvariant();
                            dakUploadAttachmentTableRow._dakAttachment = attachment;
                            dakUploadAttachmentTableRow.imageLink = attachment.url;
                          
                            dakUploadAttachmentTableRow.attachmentName = attachment.user_file_name;
                            dakUploadAttachmentTableRow.attachmentId = attachment.attachment_id; ;
                            dakUploadAttachmentTableRow.RadioButtonClick += delegate (object radioSender, EventArgs radioEvent) { AttachmentTable_RadioButtonClick(radioSender, radioEvent, dakUploadAttachmentTableRow.attachmentId); };


                            attachmentListFlowLayoutPanel.Controls.Add(dakUploadAttachmentTableRow);
                        }
                    }
                }
            
            
            } }

        public DakUserParam dakListUserParam
        {
            get { return _dak_List_User_Param; }
            set { _dak_List_User_Param = value; }
        
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {



                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        public DaptorikDakUploadUserControl()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);

            PriorityListCollection.Clear();

            DakAttachmentListinGrid dakAttachmentListinGrid = new DakAttachmentListinGrid();
            _dakAttachmentinGrids = dakAttachmentListinGrid.dakAttachmentinGrids;
           
            
            MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
            headlineLabel.Font = MemoryFonts.GetFont(0, 14);
            attachmentHeaderLabel.Font = MemoryFonts.GetFont(0, 14);


           
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

                       

                        if(!viewDesignationSealLists.Any(a=>a.designation_id==viewdesignationListOwnOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOwnOffice);
                        }
                      
                    }

                    foreach (PrapokDTO otherOfficeDTO in value.data.other_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOtherOffice = mapper.Map<ViewDesignationSealList>(otherOfficeDTO);
                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOtherOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOtherOffice);
                        }
                      
                    }

                    PopulateGrid();
                    PopulateSenderListBox();
                   
                }
                catch
                {

                }



            }

        }

        private void PopulateSenderListBox()
        {
            searchOfficerRightListBox.DisplayMember = "designationwithname";
            searchOfficerRightListBox.DataSource = null;
            searchOfficerRightListBox.DataSource = viewDesignationSealLists;
            searchOfficerRightListBox.Visible = true;
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
            BindingList<ViewDesignationSealList> bindinglist = new BindingList<ViewDesignationSealList>();
            foreach(ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists)
            {
                bindinglist.Add(viewDesignationSealList);
            }
            prapokDataGridView.DataSource = null;
            prapokDataGridView.DataSource = bindinglist;
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
          
            if (prapokDataGridView.Columns[prapokDataGridView.CurrentCell.ColumnIndex].Name== "ActionButton")
            {

                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "অপনি কি প্রাপকটিকে মুছে ফেলতে চান?";
                conditonBoxForm.ShowDialog();
                if (conditonBoxForm.Yes)
                {
                    int designation_id= Convert.ToInt32(prapokDataGridView.Rows[row_index].Cells["designationid_id"].Value);
                    var form = FormFactory.Create<Dashboard>();
                    string designationSealIdJson =designation_id.ToString();
                    DeleteDesignationSealResponse deleteDesignationSealResponse = form.DeleteDesignation(designationSealIdJson);

                    if (deleteDesignationSealResponse.status == "success")
                    {
                        MessageBox.Show("প্রাপকটিকে সফলভাবে মুছে ফেলা হ​য়েছে।");
                        
                            prapokDataGridView.Rows.RemoveAt(row_index);
                           
                        

                        viewDesignationSealLists = viewDesignationSealLists.Where(a => a.designation_id != designation_id).ToList();

                    }
                    else
                    {
                        MessageBox.Show("মুছে ফেলা সফল হ​য়নি।।");
                    }

                }
                else
                {

                }
            }
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

            IEnumerable<ViewDesignationSealList> designationSealListsinGridView = (IEnumerable<ViewDesignationSealList>)prapokList;
            List<ViewDesignationSealList> NewViewDesignationSealLists = new List<ViewDesignationSealList>();


            if (officerSearchXTextBox.Text == "")
            {
                PopulateGrid();
            }
            else
            {
                foreach (var des in designationSealListsinGridView)
                {
                    if (des.designation.Contains(officerSearchXTextBox.Text)|| des.employee_name_bng.Contains(officerSearchXTextBox.Text))
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
            senderSortSidePanel.Focus();
            
            HoverColorChangeSenderSearchButton();
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as Form; if (parent != null) { parent.Hide(); }
            senderSortSidePanel.Visible = false;
            NormalColorSenderSearchButton();
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                // var fileStream = opnfd.OpenFile();

                // using (StreamReader reader = new StreamReader(opnfd.FileName, Encoding.UTF8))
                // {
                //     _dakFileUploadParam.content = reader.ReadToEnd();
                // }

                //// _dakFileUploadParam.content = File.ReadAllText(opnfd.FileName);
                // // _dakFileUploadParam.file_size_in_kb=opnfd.
                
                Byte[] bytes = File.ReadAllBytes(opnfd.FileName);
                _dakFileUploadParam.content = Convert.ToBase64String(bytes);

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
                            dakUploadAttachmentTableRow.imgSource = opnfd.FileName;
                            //using (Image image = Image.FromFile(opnfd.FileName))
                            //{
                            //    using (MemoryStream m = new MemoryStream())
                            //    {
                            //        image.Save(m, image.RawFormat);
                            //        byte[] imageBytes = m.ToArray();

                            //        // Convert byte[] to Base64 String
                            //        dakUploadAttachmentTableRow.imageBase64String = Convert.ToBase64String(imageBytes);

                            //    }
                            //}

                           
                        }

                        else if(PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                          
                        }
                        else
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }


                        dakUploadAttachmentTableRow.imageBase64String = _dakFileUploadParam.content;

                        dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        dakUploadAttachmentTableRow.fileexension = new System.IO.FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
                        dakUploadAttachmentTableRow._dakAttachment = dakUploadedFileResponse.data[0];
                        dakUploadAttachmentTableRow.imageLink = dakUploadedFileResponse.data[0].url;
                     
                        dakUploadAttachmentTableRow.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
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
            if (dakAttachment.id==0 ||(response != null && response.status == "success"))
            {
                SuccessMessage("সফলভাবে সংযুক্তি মুছে ফেলা হয়েছে");
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

        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
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
            if(oCRResponse != null)
            {
                dakDescriptionXTextBox.Text = oCRResponse.text;
            }
         

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
                PopulateSenderListBox();

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
                    //searchOfficerRightResultLabel.Text = "";
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
                //searchOfficerRightListBox.Visible = false;
                searchOfficerRightPanel.Visible = true;
               // searchOfficerRightResultLabel.Text = "";
               
                searchOfficerRightXTextBox.Focus();
            }
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
            starLabel.BackColor = Color.FromArgb(54, 153, 255);
            senderSearchButton.BackColor = Color.FromArgb(54, 153, 255);
            senderSearchButton.ForeColor = Color.White;
            senderSearchButton.IconColor = Color.White;

        }
        private void NormalColorSenderSearchButton()
        {
            senderSearchButton.BackColor = Color.Transparent;
            starLabel.BackColor = Color.Transparent;
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

            if (!DaptorikDakSaveAndSendValidation())
            {
                return;
            }

            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি সংরক্ষণ করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {

                SetDakUploadData();

                if (this.KhosraSaveButtonClick != null)
                    this.KhosraSaveButtonClick(sender, e);
            }
            else
            {

            }

           




        }

        private void SetDakUploadData()
        {
            prerokName = selectedPrerokLabel.Text;
            sub = subjectXTextBox.Text;
          
            //uploader

            var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<DakUserParam, DakForwardRequestSenderInfo>()
                  );
            var mapper = new Mapper(config);
            var dakSender = mapper.Map<DakForwardRequestSenderInfo>(_dak_List_User_Param);


            dakUploadParameter.uploader = dakUploadParameter.CSharpObjtoJson(dakSender);

            //Sender
            var sender_info = designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == _prerokId);
            if (sender_info == null)
            {
                sender_info = designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == _prerokId);
            }


            
            dakUploadParameter.sender_info = dakUploadParameter.CSharpObjtoJson(sender_info);


            // Dak

            DakInfo dak = new DakInfo(false);

            List<DakUploadAttachment> dakUploadAttachments = new List<DakUploadAttachment>();

            var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

            foreach (var attachment in attachmentList)
            {
                DakUploadAttachment dakUploadAttachment = new DakUploadAttachment();
                if (attachment.isMulpotro)
                {
                    dakUploadAttachment.mulpotro = 1;
                }

                
                dakUploadAttachment.file_infoModel = attachment._dakAttachment;
                dakUploadAttachment.file_infoModel.user_file_name = attachment._attachmentName;
                dakUploadAttachment.file_infoModel.img_base64 = attachment.imageBase64String;
                dakUploadAttachment.file_info= dakUploadParameter.CSharpObjtoJson(dakUploadAttachment.file_infoModel);
               
               // dak.attachment.Add(new Lookup<string, DakUploadAttachment>(dakUploadAttachment.file_infoModel.id.ToString(), dakUploadAttachment));

                dakUploadAttachments.Add(dakUploadAttachment);
                 

            }


            dakUploadParameter.remoteAttachments = dakUploadAttachments.Where(a => a.file_infoModel.id != 0).ToList();
            dakUploadParameter.localAttachments = dakUploadAttachments.Where(a => a.file_infoModel.id == 0).ToList();
           
            dak.sarok_no = sharokNoTextBox.Text;
            dak.dak_subject = subjectXTextBox.Text;
            dak.sending_date =sharokdateTimePicker.Value.ToString("dd-MM-yyyy");
            dak.sending_media = sendMediumSearchButton.searchButtonText;
            dak.id = _dakId;
            dak.dak_description = dakDescriptionXTextBox.Text;





            DakPriorityList dakPriority = new DakPriorityList();
            int dak_priority_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.searchButtonText.ToString()));



            DakSecurityList dakSecurityList = new DakSecurityList();
            int dak_security_id = Convert.ToInt32(dakSecurityList.GetDakSecuritiesId(seurityLevelSearchButton.searchButtonText.ToString()));

            dak.priority = dak_priority_id.ToString();
            dak.dak_priority = prioritySearchButton.ToString();
            dak.security = dak_security_id.ToString();
            dak.dak_security = seurityLevelSearchButton.ToString();


            dakUploadParameter.dak_info = dakUploadParameter.CSharpObjtoJson(dak);
            dakUploadParameter.dak_Info_Obj = dak;

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
            prapokName = dakUploadReceiver.mul_prapok.officer_name + " ," + dakUploadReceiver.mul_prapok.designation_bng + "," + dakUploadReceiver.mul_prapok.unit_name_bng + "," + dakUploadReceiver.mul_prapok.office_bng;

          // onulipi
            List <PrapokDTO> OnulipiprapokDTOs = new List<PrapokDTO>();

            List<ViewDesignationSealList> viewDesignationSealListsOnulipPrapok = viewDesignationSealLists.Where(a => a.onulipi_prapok == true).ToList();

            if (viewDesignationSealListsOnulipPrapok.Count > 0)
            {
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

            }
           

            dakUploadReceiver.onulipi = OnulipiprapokDTOs.ToDictionary(a=>a.designation_id.ToString());







          
            dakUploadParameter.receiver_info = dakUploadParameter.CSharpObjtoJson(dakUploadReceiver);
            dakUploadParameter.others = "[]";
            // dakUploadParameter.path = sendMediumSearchButton.searchButtonText;
            dakUploadParameter.content = dakDescriptionXTextBox.Text;
            dakUploadParameter.office_id = _dak_List_User_Param.office_id;
            dakUploadParameter.designation_id = _dak_List_User_Param.designation_id;

        }

        public event EventHandler AddDesignationButtonClick;
        private void addDesignationButton_Click(object sender, EventArgs e)
        {
           
            if (this.AddDesignationButtonClick != null)
                this.AddDesignationButtonClick(sender, e);

        }
        public event EventHandler DakSendButton;
        private void sendButton_Click(object sender, EventArgs e)
        {

            if(!DaptorikDakSaveAndSendValidation())
            {
                return;
            }


            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি ডাকটি প্রেরণ করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
               
                SetDakUploadData();


                if (this.DakSendButton != null)
                    this.DakSendButton(sender, e);
            }
            else
            {

            }
        
        }

        private bool DaptorikDakSaveAndSendValidation()
        {
          

            // Mulpotro
            List<DakUploadAttachment> dakUploadAttachments = new List<DakUploadAttachment>();

            var attachmentList = attachmentListFlowLayoutPanel.Controls.OfType<DakUploadAttachmentTableRow>().ToList();

            if(!attachmentList.Any(a=>a.isMulpotro==true))
            {
                fileUploadPanel.Focus();
                ShowAlertMessage(MessageBoxMessage.mulpotroNotSelectErrorMessage);
                return false;
            }
            


            if (string.IsNullOrEmpty(selectedPrerokLabel.Text))
            {

                senderSearchButton.Focus();
                ShowAlertMessage(MessageBoxMessage.officerNotSelectErrorMessage);
                return false;
            }
           
            if (string.IsNullOrEmpty(sharokNoTextBox.Text))
            {

                sharokNoTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.sharokNoNotGivenErrorMessage);
                return false;
            }

            if (string.IsNullOrEmpty(subjectXTextBox.Text))
            {

                subjectXTextBox.Focus();
                ShowAlertMessage(MessageBoxMessage.subjectNotGivenErrorMessage);
                return false;
            }

            var mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);
            if (mulprapok == null)
            {
                ShowAlertMessage(MessageBoxMessage.mulPrapokNotSelectErrorMessage);
                return false;
            }

            return true;

        }

        private void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {
            UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
            alertMessageBox.message = mulpotroNotSelectErrorMessage;
           
            alertMessageBox.ShowDialog();
        }

        private void searchOfficerRightListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
           e.ItemHeight = 60;
            
        }

        private void searchOfficerRightListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

           

            var lbx = sender as ListBox;
            string itemText = lbx.GetItemText(lbx.Items[e.Index]);

            e.DrawBackground();
            e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), e.Bounds);

        }

        private void DaptorikDakUploadUserControl_Load(object sender, EventArgs e)
        {
            searchOfficerRightListBox.Height = searchOfficerRightListBox.PreferredHeight;

        }

        private void officeAddressManualEntryXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

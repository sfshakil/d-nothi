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
using Newtonsoft.Json;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class UCGuardFileList : UserControl
    {
        IUserService _userService { get; set; }
        IGuardFileService<GuardFileModel,GuardFileModel.Record> _guardFileService { get; set; }
        IGuardFileService<GuardFileCategory, GuardFileCategory.Record> _guardFileCategoryService;
        public const string guardFile = "GuardFiles";
        AllAlartMessage alartMessage = new AllAlartMessage();
        int page = 1;
        int pageLimit = 10;

        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
       

       
        public UCGuardFileList(IUserService userService, IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService, IGuardFileService<GuardFileCategory, GuardFileCategory.Record> guardFileCategoryService)
        {
            _userService = userService;
            _guardFileService = guardFileService;
            _guardFileCategoryService = guardFileCategoryService;
              InitializeComponent();
           
            typesearchComboBox.itemList = GuardFileCategories();
            typesearchComboBox.isListShown = true;

            Formload();


        }
        private void Formload()
        {
            page = 1;
            start = 1;
            LoadGuardFileList();
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            NextPreviousButtonShow();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }
        private List<ComboBoxItems> GuardFileCategories()
        {
            List<ComboBoxItems> categoryList = new List<ComboBoxItems>();
            categoryList.Add(new ComboBoxItems { id = 0, Name = "ধরন বাছাই করুন" });

            foreach (var item in LoadGuardFileTypeList())
            {
                categoryList.Add(new ComboBoxItems {  id=item.id, Name=item.name_bng});
            }
            return categoryList;


        }
        public void LoadGuardFileList()
        {
            int categoryid = typesearchComboBox.selectedId;
            string naemSearchparam = dakSearchSubTextBox.Text;
            var dakListUserParam = _userService.GetLocalDakUserParam();
          
            dakListUserParam.page = page;
            dakListUserParam.limit = pageLimit;
            dakListUserParam.CategoryId = categoryid;
            dakListUserParam.NameSearchParam = naemSearchparam;
            var datalist = _guardFileService.GetList(dakListUserParam, 2);
            RemoveArbitraryRow(guardFileListTableLayoutPanel, guardFileListTableLayoutPanel.RowCount, 2);
           // guardListTableLayoutPanel.Controls.Clear();
            if (datalist != null)
            {
                if (datalist.data.records.Count > 0)
                {
                   
                    List<DakAttachmentDTO> dta = new List<DakAttachmentDTO>();

                    //var attachment = datalist.data.records.Select(x => x.attachment).ToList();
                    //foreach (var item in attachment)
                    //{
                    //    DakAttachmentDTO dTO = new DakAttachmentDTO();

                    //    if (item.ToString()!="{[]}")
                    //    {

                    //        var attachement = JsonConvert.DeserializeObject<GuardFileModel.Attachment>(item.ToString());
                    //        dTO.attachment_type = attachement.attachment_type;
                    //        dTO.dak_description = attachement.content_body;
                    //        dTO.id = attachement.id;
                    //        dTO.url = attachement.url;
                    //    }
                    //    else
                    //    {
                    //        dTO.attachment_type = null;
                    //        dTO.dak_description = null;
                    //        dTO.id = 0;
                    //        dTO.url = null;
                    //    }
                    //    dta.Add(dTO);
                    //}
                    
                 
                     foreach(var s in datalist.data.records)
                    {
                        if(s.attachment!=null)
                        {
                            dta.Add(new DakAttachmentDTO
                            {
                                attachment_type = s.attachment.attachment_type,
                                dak_description = s.attachment.content_body,
                                id = s.attachment.id,
                                url = s.attachment.url
                            });
                        }
                    }
                           

                    int row = 2;
                    foreach (var item in datalist.data.records)
                    {
                    

                    
                        
                        GuardFileListRowUserControl guardFileTable = UserControlFactory.Create<GuardFileListRowUserControl>();

                        if (item.attachment != null)
                        {
                            DakAttachmentDTO data = new DakAttachmentDTO
                            {
                                attachment_type = item.attachment.attachment_type,
                                url = item.attachment.url,
                                dak_description = item.attachment.content_body,
                                id = item.attachment.id
                            };
                            guardFileTable.dakAttachmentDTO = data;
                        }
                        else
                        {
                            
                            guardFileTable.dakAttachmentDTO = null;
                        }


                        guardFileTable.id = item.id;
                        guardFileTable.type = item.name_bng;
                        guardFileTable.name = item.guard_file_category_name_bng;
                       
                        guardFileTable.designation_id = dakListUserParam.designation_id;
                        guardFileTable.office_unit_organogram_id = item.office_unit_organogram_id;


                        guardFileTable.dakAttachmentDTO = data;
                        guardFileTable.dakAttachmentDTOs = dta;

                     
                            guardFileTable.DeleteButtonClick += delegate (object sender, EventArgs e) { guardFileTableUserControl_deleteButtonClick(sender, e, item.id); };
                            // guardFileTable.ViewButtonClick += delegate (object sender, EventArgs e) { guardFileTableUserControl_viewButtonClick(sender, e, item.id); };

                     
                        guardFileTable.Dock = DockStyle.Fill;

                        // int row = guardFileTypeTableLayoutPanel.RowCount++;
                        // UIDesignCommonMethod.AddRowinTable(guardListTableLayoutPanel, guardFileTable);
                        // decisionTable.Dock = DockStyle.Fill;

                       

                        guardFileListTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 45f));
                       
                        guardFileListTableLayoutPanel.Controls.Add(guardFileTable, 0, row);
                        row= guardFileListTableLayoutPanel.RowCount++;

                        // guardFileListTableLayoutPanel.Controls.Add(guardFileTable);

                    }
                }
                totalrecord = datalist.data.total_records;
                totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = (float)totalrecord / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
            }
        }
        private void guardFileTableUserControl_viewButtonClick(object sender, EventArgs e, int id)
        {
            
                if (id > 0)
                {
                  
                }

        }
        private void guardFileTableUserControl_deleteButtonClick(object sender, EventArgs e,int id)
        {
            
                if (id > 0)
                {
                   
                    var dakListUserParam = _userService.GetLocalDakUserParam();
                    var response = _guardFileService.Delete(dakListUserParam, 4, id, guardFile);

                    if (response.status == "success")
                    {

                        alartMessage.SuccessMessage("মুছে ফেলা হয়েছে।");
                        LoadGuardFileList();

                    }
                    else
                    {

                        alartMessage.ErrorMessage("পুনরায় চেষ্ঠা করুন।");

                    }
                }
            
        }
        public List<GuardFileCategory.Record> LoadGuardFileTypeList()
        {
            var dakListUserParam = _userService.GetLocalDakUserParam();
          
            
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            var datalist = _guardFileCategoryService.GetList(dakListUserParam, 1);
            return datalist.data.records;
        }
        public static void RemoveArbitraryRow(TableLayoutPanel panel, int rows, int rowIndex)
        {
            if (rowIndex >= panel.RowCount)
            {
                return;
            }

            for (int row = rowIndex; row < rows; row++)
            {

                // delete all controls of row that we want to delete
                for (int i = 0; i < panel.ColumnCount; i++)
                {
                    var control = panel.GetControlFromPosition(i, rowIndex);
                    panel.Controls.Remove(control);
                }

                // move up row controls that comes after row we want to remove
                for (int i = rowIndex + 1; i < panel.RowCount; i++)
                {
                    for (int j = 0; j < panel.ColumnCount; j++)
                    {
                        var control = panel.GetControlFromPosition(j, i);
                        if (control != null)
                        {
                            panel.SetRow(control, i - 1);
                        }
                    }
                }

                var removeStyle = panel.RowCount - 1;

                if (panel.RowStyles.Count > removeStyle)
                    panel.RowStyles.RemoveAt(removeStyle);

                panel.RowCount--;
            }
        }
        private void UCGuardFileList_Load(object sender, EventArgs e)
        {

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
            Formload();
        }

        private void recycleIconButton_Click(object sender, EventArgs e)
        {
          
            dakSearchSubTextBox.Text = string.Empty;
            Formload();
        }

        private void typesearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {
            Formload();
        }


        #region Pagination
        private void NextPreviousButtonShow()
        {
            if (page < totalPage)
            {
                if (page == 1 && totalPage > 1)
                {
                    PreviousIconButton.Enabled = false;
                }
                else
                {
                    PreviousIconButton.Enabled = true;

                }
                nextIconButton.Enabled = true;
            }
            if (page == totalPage)
            {
                if (page == 1 && totalPage == 1)
                {
                    PreviousIconButton.Enabled = false;

                }
                else
                {
                    PreviousIconButton.Enabled = true;

                }
                nextIconButton.Enabled = false;
            }

        }
        private void nextIconButton_Click(object sender, EventArgs e)
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
            LoadGuardFileList();


            if (totalrecord < end) { endrow = totalrecord.ToString(); }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(endrow);

            NextPreviousButtonShow();
        }
        private void PreviousIconButton_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {

                page -= 1;
                start -= pageLimit;
                end -= pageLimit;

            }
            else
            {
                page = 1;
                start = start;
                end = end;

            }


            LoadGuardFileList();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
            NextPreviousButtonShow();

        }

        #endregion
    }
}

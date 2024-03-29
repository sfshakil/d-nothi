﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.Dak;
using com.sun.corba.se.spi.orbutil.fsm;
using dNothi.Services.UserServices;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.DakServices;
using dNothi.Utility;
using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Services.SyncServices;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class UCGuardFileTypes : UserControl
    {
        IUserService _userService { get; set; }
        public int page=1;
        // public int page { get { return currentPage; } set { currentPage = value; }  } 
        ISyncerService _syncerServices { get; set; }
        int pageLimit = 10;
       
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        int rowid = 0;
        int lastrecord = 0;

        public const string GuardFileCategory = "GuardFileCategories";
      
        AllAlartMessage alartMessage = new AllAlartMessage();
        IGuardFileService<GuardFileModel, GuardFileModel.Record> _guardFileService;
        IGuardFileService<GuardFileCategory,GuardFileCategory.Record> _guardFileCategoryService { get; set; }
        public UCGuardFileTypes(IUserService userService, IGuardFileService<GuardFileCategory, GuardFileCategory.Record> guardFileCategoryService, IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService, ISyncerService syncerServices)
        {
            InitializeComponent();
            _userService = userService;
            _guardFileCategoryService = guardFileCategoryService;
            _guardFileService = guardFileService;
            _syncerServices = _syncerServices;
            // page = 1;
            start = 1;
            LoadGuardFileTypeList();
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            NextPreviousButtonShow();
           
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
        }

       
        public void LoadGuardFileTypeList()
        {
           
            var dakListUserParam = _userService.GetLocalDakUserParam();
           
            dakListUserParam.limit = pageLimit;
            dakListUserParam.page = page;
           

           var datalist=  GetDataList( dakListUserParam);
            //guardFileTypeTableLayoutPanel.Controls.Clear();
            // RemoveArbitraryRow(guardFileTypeTableLayoutPanel,3);
            RemoveTableLayoutPanelRow(guardFileTypeTableLayoutPanel, guardFileTypeTableLayoutPanel.RowCount, 3);

            if (datalist != null)
            {
                if (datalist.data.records.Count > 0)
                {
                    lastrecord = datalist.data.records.Count();
                    foreach (var item in datalist.data.records)
                    {
                        rowid++;
                        var decisionTable = UserControlFactory.Create<GuardFileTypeTableUserControl>();
                        decisionTable.id = rowid;
                        decisionTable.isOnline = item.offline;
                         decisionTable.decision = item.name_bng;
                        decisionTable.TypeNo = item.guard_file_type_count;
                        decisionTable.TypeId = item.id;
                        decisionTable.designation_id = dakListUserParam.designation_id;
                        decisionTable.office_unit_organogram_id = item.office_unit_organogram_id;
                        

                        decisionTable.GuardFileCountLabelClick += delegate (object sender, EventArgs e) { GuardFileList_Click(sender, e, item); };

                        //decisionTable.editButtonClick += delegate (object sender, EventArgs e) { dakDecisionTableUserControl_attachmentButtonClick(sender, e); };
                        decisionTable.DeleteButtonClick += delegate (object sender, EventArgs e) { typedeleteTableUserControl_ButtonClick(sender, e,item.id); };

                        decisionTable.Dock = DockStyle.Fill;

                        int row = guardFileTypeTableLayoutPanel.RowCount++;

                        guardFileTypeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                        guardFileTypeTableLayoutPanel.Controls.Add(decisionTable, 0, row);

                        guardFileTypeTableLayoutPanel.Controls.Add(decisionTable);
                        

                    }
                }
                totalrecord = datalist.data.total_records;
                totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = (float)totalrecord / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
            }
        }
        private GuardFileCategory GetDataList(DakUserParam dakListUserParam)
        {
            GuardFileCategory datalist = new GuardFileCategory();
            List<GuardFileCategory.Record> records = new List<GuardFileCategory.Record>();
            int recordCount = 0;
            if (page == 1 && !InternetConnection.Check())
            {
                var getlocalData = _guardFileCategoryService.GetLocalGuarFileCategoryData(dakListUserParam, 1);
                recordCount = getlocalData.data.records.Count();
                datalist.data = getlocalData.data;
            }
            else
            {
                datalist.data = new GuardFileCategory.Data { records = records, total_records = 0 };
            }

            var datalists = _guardFileCategoryService.GetList(dakListUserParam, 1);
            if (page == 1)
            {
               
                if (datalists != null)
                {
                    for (int item = 0; item < datalists.data.records.Count() - recordCount; item++)
                    {
                        GuardFileCategory.Record record = new GuardFileCategory.Record();
                        record= datalists.data.records[item];
                        datalist.data.records.Add(record);
                    }
                   
                    datalist.data.total_records = datalists.data.total_records;
                    datalist.status = datalists.status;
                }
            }
            else
            {
                datalist = datalists;
            }
            return datalist;

        }
        private void typedeleteTableUserControl_ButtonClick(object sender,EventArgs e, int TypeId)
        {
            if (TypeId > 0)
            {
              
                var dakListUserParam = _userService.GetLocalDakUserParam();
                var response = _guardFileService.Delete(dakListUserParam, 4, TypeId, GuardFileCategory);
                if (response.status == "success")
                {

                    alartMessage.SuccessMessage("গার্ড ফাইল ধরন মুছে ফেলা হয়েছে।");
                    LoadGuardFileTypeList();
                }
                else
                {

                    alartMessage.ErrorMessage("পুনরায় চেষ্ঠা করুন।");

                }
            }
        }

        private void GuardFileList_Click(object sender, EventArgs e, GuardFileCategory.Record model)
        {
           
            GuardFileListForm guardFileListForm = new GuardFileListForm(_userService,_guardFileService);
            guardFileListForm.guardFileCategory = model;
           
            CalPopUpWindow(guardFileListForm);
          
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = this.Size;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

         
        }
        public static void RemoveTableLayoutPanelRow(TableLayoutPanel panel, int rows,int rowIndex)
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

        private void dakDecisionTableUserControl_RadioButtonClick(object sender, EventArgs e, int id)
        {
            var decisionTable = guardFileTypeTableLayoutPanel.Controls.OfType<GuardFileTypeTableUserControl>().ToList();

            foreach (var dakDecisionTableUser in decisionTable)
            {
                if (dakDecisionTableUser._id != id)
                {
                    //dakDecisionTableUser.isDecisionSelected = false;
                }
            }
        }

        private void Table_Border_Color(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }

        private void Table_Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
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
            LoadGuardFileTypeList();
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
                rowid -=(pageLimit + lastrecord);

            }
            else
            {
                page = 1;
                start = start;
                end = end;

            }


            LoadGuardFileTypeList();

            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
            NextPreviousButtonShow();

        }
       
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
    }
}

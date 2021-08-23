using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.OtherModule.GuardFileUserControls;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiGaurdFileList : UserControl
    {
        IUserService _userService { get; set; }
        INothiDecisionListService _nothiDecisionListService { get; set; }
        IGuardFileService<GuardFilePortal,GuardFileOffice> _guardFileService { get; set; }
        public NothiGaurdFileList(IUserService userService, INothiDecisionListService nothiDecisionListService, IGuardFileService<GuardFilePortal, GuardFileOffice> guardFileService)
        {
            _userService = userService;
            _nothiDecisionListService = nothiDecisionListService;
            _guardFileService = guardFileService;
            InitializeComponent();
            guardFiletabControl.SelectedIndexChanged += new EventHandler(guardFiletabControl_SelectedIndexChanged);
            loadRow();
        }
        private void portalCreate_SubmitButtonClick(object sender, EventArgs e)
        {
            loadRow();
        }
        private void guardFiletabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guardFiletabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == guardFilePortalTabPage)
            {

                categoryComboBox.DataSource = GuardFilePortalOfficeTypeLoadData();
                categoryComboBox.DisplayMember = "Name";
                categoryComboBox.ValueMember = "Id";
                categoryComboBox.SelectedIndex = 0;


                officeComboBox.DataSource = GuardFileOfficeLoadData();
                officeComboBox.DisplayMember = "Name";
                officeComboBox.ValueMember = "Id";
                officeComboBox.SelectedIndex = 0;
                //GuardFilePortalFormLoad();
            }

        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        public void loadRow()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 30;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiDecisionList = _nothiDecisionListService.GetNothiGaurdFileList(dakListUserParam);
            if (nothiDecisionList != null && nothiDecisionList.status == "success")
            {
                if (nothiDecisionList.data.records.Count > 0)
                {
                    lbLengthStart.Text = "১";
                    lbLengthEnd.Text = string.Concat(nothiDecisionList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalGaurdFile.Text = " সর্বমোট: " + string.Concat(nothiDecisionList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiInboxinPanel(nothiDecisionList.data.records);
                }

            }
            else
            {
                ErrorMessage(nothiDecisionList.status);
            }
        }
        private void LoadNothiInboxinPanel(List<GaurdFileRecord> records)
        {
            foreach (GaurdFileRecord record in records)
            {
                var nothiGaurdFileListRow = UserControlFactory.Create<NothiGaurdFileListRow>();
                nothiGaurdFileListRow.nameText = record.name_bng.ToString();
                nothiGaurdFileListRow.categoryNameText = record.guard_file_category_name_bng.ToString();
                nothiGaurdFileListRow.attachmentURL = record.attachment.url;
                nothiGaurdFileListRow.GaurdFileAddButton += delegate (object sender1, EventArgs e1) { GaurdFileAdd_ButtonClick(sender1 as GaurdFileRecord, e1); };
                UIDesignCommonMethod.AddRowinTable(gaurdFileViewFLP, nothiGaurdFileListRow);
            }
        }
        public event EventHandler GaurdFileAttachment;
        private void GaurdFileAdd_ButtonClick(GaurdFileRecord gaurdFileRecord, EventArgs e1)
        {
          
          
            if (this.GaurdFileAttachment != null)
                this.GaurdFileAttachment(gaurdFileRecord, e1);
        }
        private void btnNothiGaurdFileListCross_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Note")
                    f.Close();
            }
        }

        private void btnNothiOutboxPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNothiAllNext_Click(object sender, EventArgs e)
        {

        }

        

        #region GuardFilePortal

        int page = 1;
        int pageLimit = 10;
      
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        private void panel19_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        private void panel22_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        private List<ComboBoxItem> GuardFilePortalOfficeTypeLoadData()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            
                comboBoxItems.Add(new ComboBoxItem("বাছাই করুন", 1));
                
                comboBoxItems.Add(new ComboBoxItem("মন্ত্রণালয়/বিভাগ", 2));
                comboBoxItems.Add(new ComboBoxItem("অধিদপ্তর/সংস্থা", 3));

            return comboBoxItems;


        }

        private List<ComboBoxItem> GuardFileOfficeLoadData()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            var userparam = _userService.GetLocalDakUserParam();

            int layerid =Convert.ToInt32(categoryComboBox.SelectedValue);
            var guardFileOfficelist = _guardFileService.GuardFilePortalOfficeList(userparam, layerid, string.Empty);
            if (guardFileOfficelist.status == "success")
            {
                comboBoxItems.Add(new ComboBoxItem("অফিস বাছাই করুন", 0));
                foreach (var item in guardFileOfficelist.data)
                {
                    comboBoxItems.Add(new ComboBoxItem(item.type, item.id));
                }
            }
            return comboBoxItems;
            

        }
        private void GuardFilePortalFormLoad()
        {
            page = 1;
            start = 1;
            GuardFilePortalLoadData(page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            NextPreviousButtonShow();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }
        private void GuardFilePortalLoadData(int pages)
        {
            portalListTableLayoutPanel.Controls.Clear();

            var dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = pageLimit;

            dakListUserParam.page = pages;

            string type = officeComboBox.Text.ToString();
            string name = gfpNameSearchTextBox.Text;
            var guardFilePortallist = _guardFileService.GuardFilePortalList(dakListUserParam, string.Empty, type);
            if (guardFilePortallist.status == "success")
            {
                noDataPanel.Visible = false;
                foreach (var item in guardFilePortallist.data.records)
                {

                    GaurdFilePortalListRow gfp = UserControlFactory.Create<GaurdFilePortalListRow>();
                    gfp.id = item.id;
                    gfp.layerId = item.layer_id;
                    gfp.link= item.link;
                    gfp.subdomain= item.subdomain;
                    gfp.nameText = item.type;
                    gfp.categoryNameText = item.name;
                    
                    gfp.GaurdFileAddButton += delegate (object sender, EventArgs e) { guardFilePortalTableUserControl_AddButtonClick(sender, e, item.id); };


                    UIDesignCommonMethod.AddRowinTable(portalListTableLayoutPanel, gfp);

                }

                totalrecord = guardFilePortallist.data.total_records;
                totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = (float)totalrecord / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
            }
            else
            {
                noDataPanel.Visible = true;
            }

        }
        private void guardFilePortalTableUserControl_AddButtonClick(object sender, EventArgs e,int id)
        {
            var portalCreate = FormFactory.Create<UCGuardFilePortalCreate>();
            portalCreate.SubmitButtonClick += delegate (object sender1, EventArgs e1) { portalCreate_SubmitButtonClick(sender1, e1); };

            
            UIDesignCommonMethod.CalPopUpWindow(portalCreate, this.ParentForm);
        }
        private void officeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                GuardFilePortalFormLoad();
           
        }
        
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryComboBox.SelectedIndex > 0)
            {

                officeComboBox.DataSource = GuardFileOfficeLoadData();
               
            }
            else
            {
                List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
                comboBoxItems.Add(new ComboBoxItem("অফিস বাছাই করুন", 0));
                officeComboBox.DataSource = comboBoxItems;
            }
            officeComboBox.DisplayMember = "Name";
            officeComboBox.ValueMember = "Id";

        }
        #region pagination
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

            }
            endrow = end.ToString();
            GuardFilePortalLoadData( page);
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

            }

            GuardFilePortalLoadData(page);
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

        private void searchBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }




        #endregion

        #endregion

       
    }
}

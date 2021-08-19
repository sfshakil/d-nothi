using AutoMapper;
using dNothi.Desktop.UI.Dak;
using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.Desktop.View_Model;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.PotroJariGroup;
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

namespace dNothi.Desktop.UI
{
    public partial class SelectOfficerForm : Form
    {
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        public List<int> _selectedOfficerDesignations = new List<int>();
        IUserService _userService { get; set; }
       IPotroJariGroupService _potroJariGroupService { get; set; }
        public SelectOfficerForm(IUserService userService, IPotroJariGroupService potroJariGroupService)
        {
            InitializeComponent();
            _userService = userService;
            _potroJariGroupService = potroJariGroupService;
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == potraJariTabPage)
            {
                Formload();
            }
        }
        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public bool _isOneOfficerAllowed;

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



                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOwnOffice.designation_id))
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

                  
                    PopulateSenderListBox();

                }
                catch
                {

                }



            }

        }
        private void SelectOfficerForm_Load(object sender, EventArgs e)
        {
           // Formload();
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            SetDefaultFont(this.Controls);
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
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
        private void PopulateSenderListBox()
        {
            searchOfficerRightListBox.DisplayMember = "designationwithname";
            searchOfficerRightListBox.DataSource = null;
            searchOfficerRightListBox.DataSource = viewDesignationSealLists;
            searchOfficerRightListBox.Visible = true;
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




                if (viewDesignationSealListsforOfficerSearch.Count > 0)
                {
                    searchOfficerRightListBox.DisplayMember = "designationwithname";
                    searchOfficerRightListBox.DataSource = null;
                    searchOfficerRightListBox.DataSource = viewDesignationSealListsforOfficerSearch;

                    searchOfficerRightListBox.Visible = true;
                }
                else
                {
                    searchOfficerRightListBox.Visible = true;
                    //searchOfficerRightResultLabel.Text = "";
                }

            }
        }

        private void searchOfficerRightListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchOfficerRightPanel.Visible)
            {

                //searchOfficerRightPanel.Visible = false;
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
        private int _designationId=0;
        private void searchOfficerRightListBox_Click(object sender, EventArgs e)
        {
            searchOfficerRightPanel.Visible = false;



            officerSearchOfficerNameLabel.Text = searchOfficerRightListBox.GetItemText(searchOfficerRightListBox.SelectedItem);
            _designationId = (searchOfficerRightListBox.SelectedItem as ViewDesignationSealList).designation_id;
            // _selectedOfficerDesignations.Add(_designationId);

            VisibleSaveSingleOfficer();



        }

        private void VisibleSaveSingleOfficer()
        {
            if (_designationId != 0)
            {
                saveOfficerButton.Visible = true;
            }
            else
            {
                saveOfficerButton.Visible = false;
            }
        }

        private void saveOfficerButton_Click(object sender, EventArgs e)
        {
           
            if (!_selectedOfficerDesignations.Contains(_designationId) && _designationId !=0)
            {
                OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();
                officerRowUserControl.officerName = viewDesignationSealLists.FirstOrDefault(a => a.designation_id == _designationId).designationwithname;
                officerRowUserControl.designationId = _designationId;
               
                officerRowUserControl.DeleteButton+= delegate (object se, EventArgs ev) { ReloadOfficerList(); };
                officerRowUserControl.Width = officerListFlowLayoutPanel.Width-50;

                _selectedOfficerDesignations.Add(_designationId);
                UIDesignCommonMethod.AddRowinTable(officerListFlowLayoutPanel, officerRowUserControl);
            }
           


            var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

            ReloadOfficerList();


            _designationId = 0;

            if(_isOneOfficerAllowed)
            {
                finalSave(sender, e);
            }

            VisibleSaveSingleOfficer();

        }

        private void ReloadOfficerList()
        {
            var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();



            if (officerList.Count == 0)
            {
                officerEmptyPanel.Visible = true;
            }
            else
            {
                officerEmptyPanel.Visible = false;
                
            }


            countOfficer.Text = string.Concat(officerList.Count.ToString().Select(c => (char)('\u09E6' + c - '0')));

        }
        private void RemoveOfficerFromList(int designationId)
        {
            var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

            _selectedOfficerDesignations.Remove(designationId);

            if (officerList.Count == 0)
            {
                officerEmptyPanel.Visible = true;
            }
            else
            {
                officerEmptyPanel.Visible = false;
               
            }


            countOfficer.Text = string.Concat(officerList.Count.ToString().Select(c => (char)('\u09E6' + c - '0')));

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public event EventHandler SaveButtonClick;
        private void finalSaveButton_Click(object sender, EventArgs e)
        {
            finalSave(sender,e);
        }

        private void finalSave(object sender, EventArgs e)
        {



            var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();
            if(officerList == null || officerList.Count==0)
            {
                UIDesignCommonMethod.ErrorMessage("অফিসার বাছাই করা হইনি!");
                return;
            }
            _selectedOfficerDesignations.Clear();


            foreach (var officer in officerList)
            {
                _selectedOfficerDesignations.Add(officer._designationId);
            }


            if (this.SaveButtonClick != null)
                this.SaveButtonClick(sender, e);

            this.Hide();
        }

        private void searchOfficerRightListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lbx = sender as ListBox;
            string itemText = lbx.GetItemText(lbx.Items[e.Index]);

            e.DrawBackground();
            e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), e.Bounds);

        }

        private void searchOfficerRightListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 60;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void officerRowUserControl1_Load(object sender, EventArgs e)
        {

        }

        #region potraJariGroup
      
        int page = 1;
        int pageLimit = 10;
        int menuNo = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        private void potraJariTabPage_Click(object sender, EventArgs e)
        {
            Formload();
        }
        private void Formload()
        {
            page = 1;
            start = 1;
            LoadData(menuNo, page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            NextPreviousButtonShow();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }
        private void LoadData(int menuNo, int pages)
        {
            khosraListTableLayoutPanel.Controls.Clear();

            var dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = pageLimit;

            dakListUserParam.page = pages;


            var potroJariGrouplist = _potroJariGroupService.GetList(dakListUserParam, menuNo);
            if (potroJariGrouplist.status == "success")
            {
                noKhosraPanel.Visible = false;
                foreach (var item in potroJariGrouplist.data.records)
                {

                    PotrojariGroupContent pgc = UserControlFactory.Create<PotrojariGroupContent>();

                    pgc.creator = item.group.createdby_officer;
                    pgc.groupName = item.group.group_name;
                    pgc.privacyType = item.group.privacy_type;
                    pgc.totalPerson = item.group.total_users > 0 ? item.group.total_users : 0;
                    pgc.id = item.group.id;
                    pgc.users = item.users;
                  

                    if (dakListUserParam.designation_id == item.group.createdby_designation_id)
                    {
                        pgc.isDelete = true;
                        pgc.isEditable = true;
                    }
                    else
                    {
                        pgc.isDelete = false;
                        pgc.isEditable = false;
                    }
                    pgc.isPatrajariGroupFromKasra = true;
                    pgc.ActiveForKasraPatro();
                   // pgc.PotrojariDeleteButtonClick += delegate (object sender, EventArgs e) { Potrojari_EditButtonClick(sender, e, item); };
                    //pgc.PotrojariEditButtonClick += delegate (object sender, EventArgs e) { Potrojari_EditButtonClick(sender, e, item); };
                    //pgc.PotrojariDeleteButtonClick += delegate (object sender, EventArgs e) { potrojarigroup_DeleteButtonClick(sender, e, item.group.id); };
                    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, pgc);

                }

                totalrecord = potroJariGrouplist.data.total_records;
                totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = (float)totalrecord / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
            }
            else
            {
                noKhosraPanel.Visible = true;
            }

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
            LoadData(menuNo, page);
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

            LoadData(menuNo, page);
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

        #endregion

        #endregion
        List<PrapokDTO> prapokDTOs = new List<PrapokDTO>();
        private void potraJariIButton_Click(object sender, EventArgs e)
        {
            // selectedUsers
            var potrajaricontentList = khosraListTableLayoutPanel.Controls.OfType<PotrojariGroupContent>().ToList();
            if(potrajaricontentList!=null)
            {
                foreach (var item in potrajaricontentList)
                {
                    
                    var groupid = item.users.Select(x => x.group_id).FirstOrDefault();
                   
                    var controls = item.Controls.Cast<Control>();
                       
                    var contentTableLayoutPanel = controls.Where(c => c.GetType() == typeof(TableLayoutPanel) && c.Name == "contentTableLayoutPanel").FirstOrDefault();
                    var tableLayoutPanel1 = contentTableLayoutPanel.Controls.Cast<Control>().Where(c => c.GetType() == typeof(TableLayoutPanel)).FirstOrDefault();
                    var namckeckbox = tableLayoutPanel1.Controls.Cast<Control>().OfType<CheckBox>().Where(x=>x.Name== "nameCheckBox").Select(x=>x.Checked).FirstOrDefault();
                    var nametext = tableLayoutPanel1.Controls.Cast<Control>().Where(x => x.Name == "nameTextBox").Select(x => x.Text).FirstOrDefault();
                    var tableLayoutPanel2 = tableLayoutPanel1.Controls.Cast<Control>().Where(c => c.GetType() == typeof(TableLayoutPanel)).FirstOrDefault();
                        

                    var potrajariUsers = tableLayoutPanel2.Controls.OfType<PotrojariUsersListRowUserControl>().ToList();
                    

                    if (potrajariUsers != null && potrajariUsers.Count>0)
                    {
                        

                        foreach (var item2 in potrajariUsers)
                            {

                                var control1 = item2.Controls.Cast<Control>();
                                var con1 = control1.Where(c => c.GetType() == typeof(TableLayoutPanel)).FirstOrDefault();

                                //var data3 = con1.Controls.Cast<Control>().Where(x => x.GetType() == typeof(CheckBox)).FirstOrDefault();
                                var d = con1.Controls.Cast<Control>();
                                CheckBox selecteddata = d.OfType<CheckBox>().FirstOrDefault();
                            

                                if (selecteddata.Checked)
                                {
                                //PrapokDTO prapokDTO = new PrapokDTO();
                                //prapokDTO.officer_id = item2.id;
                                //prapokDTO.officer = item2.UserName;
                                //prapokDTO.designation_bng = item2.UserDesignation;
                                //prapokDTO.office_address = item2.UserOfficeName;

                                if (namckeckbox)
                                {
                                    _designationId = item2.groupId;

                                    if (!_selectedOfficerDesignations.Contains(_designationId) && _designationId != 0)
                                    {
                                        OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();

                                        officerRowUserControl.officerName = item2.groupName;

                                        officerRowUserControl.designationId = _designationId;

                                        officerRowUserControl.DeleteButton += delegate (object se, EventArgs ev) { RemoveOfficerFromList(_designationId); };
                                        officerRowUserControl.Width = officerListFlowLayoutPanel.Width - 50;

                                        _selectedOfficerDesignations.Add(_designationId);
                                        UIDesignCommonMethod.AddRowinTable(officerListFlowLayoutPanel, officerRowUserControl);
                                    }



                                    var officerLists = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

                                    ReloadOfficerList();

                                    _designationId = 0;

                                    if (_isOneOfficerAllowed)
                                    {
                                        finalSave(sender, e);
                                    }

                                    VisibleSaveSingleOfficer();
                                    break;
                                }

                                else
                                {

                                    _designationId = item2.designationId;

                                    if (!_selectedOfficerDesignations.Contains(_designationId) && _designationId != 0)
                                    {
                                        OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();
                                        var result = viewDesignationSealLists.FirstOrDefault(a => a.designation_id == item2.designationId);
                                        if (result != null)
                                        {
                                            officerRowUserControl.officerName = result.designationwithname;

                                        }
                                        else
                                        {
                                            officerRowUserControl.officerName = item2.UserName + item2.UserDesignation + item2.UserOfficeName;
                                        }
                                        officerRowUserControl.designationId = item2.designationId;

                                        officerRowUserControl.DeleteButton += delegate (object se, EventArgs ev) { RemoveOfficerFromList(item2.designationId); };
                                        officerRowUserControl.Width = officerListFlowLayoutPanel.Width - 50;

                                        _selectedOfficerDesignations.Add(item2.designationId);
                                        UIDesignCommonMethod.AddRowinTable(officerListFlowLayoutPanel, officerRowUserControl);
                                    }



                                    var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

                                    ReloadOfficerList();

                                    _designationId = 0;

                                    if (_isOneOfficerAllowed)
                                    {
                                        finalSave(sender, e);
                                    }

                                    VisibleSaveSingleOfficer();
                                }
                                    
                                }

                            }
                        
                    }

                   
                }
             
            }
        }

       
    }
}

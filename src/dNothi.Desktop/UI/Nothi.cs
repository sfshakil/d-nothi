using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Desktop.UI.NothiUI;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class Nothi : Form
    {
        private DakUserParam _dakuserparam = new DakUserParam();
        IUserService _userService { get; set; }
        INothiInboxServices _nothiInbox { get; set; }
        INoteSaveService _noteSave { get; set; }
        INothiOutboxServices _nothiOutbox { get; set; }
        IOnuchhedForwardService _onuchhedForwardService { get; set; }
        NothiCategoryList _nothiCurrentCategory = new NothiCategoryList();
        INothiNoteTalikaServices _nothiNoteTalikaServices { get; set; }
        INothiAllServices _nothiAll { get; set; }
        INothiTypeSaveService _nothiTypeSave { get; set; }
        INothiCreateService _nothiCreateServices { get; set; }
        IRepository<NothiCreateItemAction> _nothiCreateItemAction;
        IOnucchedSave _onucchedSave { get; set; }
        INothiTypeListServices _nothiType { get; set; }
        IOnucchedFileUploadService _onucchedFileUploadService { get; set; }
        IDesignationSealService _designationSealService { get; set; }
        INothiAllNoteServices _nothiAllNote { get; set; }
        INoteDeleteService _noteDelete { get; set; }

        public WaitFormFunc WaitForm;
        ModalMenuUserControl uc = null;
        NothiMasterRegisterReportUserControl nothiMasterRegisterBook = UserControlFactory.Create<NothiMasterRegisterReportUserControl>();
        NothiRegisterReportUserControl nothiRegisterBook = UserControlFactory.Create<NothiRegisterReportUserControl>();
        NothiGrahonRegisterReportUserControl nothigrahonRegisterBook = UserControlFactory.Create<NothiGrahonRegisterReportUserControl>();
        NothiPreronRegisterReportUserControl nothipreronRegisterBook = UserControlFactory.Create<NothiPreronRegisterReportUserControl>();
        NothiPotrajariRegisterReportUserControl nothiPotrajariRegisterBook = UserControlFactory.Create<NothiPotrajariRegisterReportUserControl>();

        ShakaVittikNothiReportUserControl nothiShakaWiseProtibedan = UserControlFactory.Create<ShakaVittikNothiReportUserControl>();
        
        public Nothi(IUserService userService, INothiInboxServices nothiInbox, INothiNoteTalikaServices nothiNoteTalikaServices,
            INothiOutboxServices nothiOutbox, INothiAllServices nothiAll, INoteSaveService noteSave, INothiTypeSaveService nothiTypeSave,
            INothiCreateService nothiCreateServices, IRepository<NothiCreateItemAction> nothiCreateItemAction,
            INoteDeleteService noteDelete,
            IOnuchhedForwardService onuchhedForwardService, IOnucchedSave onucchedSave, IOnucchedFileUploadService onucchedFileUploadService, 
            INothiTypeListServices nothiType, IDesignationSealService designationSealService, INothiAllNoteServices nothiAllNote)
        {
            _nothiNoteTalikaServices = nothiNoteTalikaServices;
            _userService = userService;
            _nothiInbox = nothiInbox;
            _nothiOutbox = nothiOutbox;
            _nothiAll = nothiAll;
            _noteSave = noteSave;
            _nothiTypeSave = nothiTypeSave;
            _nothiCreateServices = nothiCreateServices;
            _nothiCreateItemAction = nothiCreateItemAction;
            _onuchhedForwardService = onuchhedForwardService;
            _onucchedSave = onucchedSave;
            _nothiType = nothiType;
            _onucchedFileUploadService = onucchedFileUploadService;
            _designationSealService = designationSealService;
            _nothiAllNote = nothiAllNote;
            _noteDelete = noteDelete;
            InitializeComponent();
            LoadNothiTypeListDropDown();
            LoadOfficerListDropDown();
            LoadNothiBranchListDropDown();

            cbxPriorityType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxPriorityType.AutoCompleteSource = AutoCompleteSource.ListItems;

            nothiCustomDatePickerUserControl.Visible = false;

            WaitForm = new WaitFormFunc();
            loadNothiExtra();
            //nothiBackGroundWorker.RunWorkerAsync();
        }
        public void loadNothiExtra()
        {
            WaitForm.Show(this);
            LoadNothiInbox();
            ResetAllMenuButtonSelection();
            SetDefaultFont(this.Controls);
            SelectButton(btnNothiInbox);
            //nothiDhoronSrchUC.Visible = true;
            designationDetailsPanelNothi.Visible = false;
            _dakuserparam = _userService.GetLocalDakUserParam();
            _nothiCurrentCategory.isInbox = true;
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";
            agotoNothiSelected = 1;
            preritoNothiSelected = 0;
            shokolNothiSelected = 0;
            modulePanel.Visible = false;
            noteListButton.BackColor = Color.FromArgb(130, 80, 230); ;
            btnNothiTalika.BackColor = Color.FromArgb(102, 16, 242); //115, 55, 238
            loadNothiInboxTotal();
            WaitForm.Close();

        }
        NothiTypeListResponse nothiType = new NothiTypeListResponse();
        AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
        NothiBranchListResponse nothiBranch = new NothiBranchListResponse();
        public void LoadNothiTypeListDropDown()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            nothiType = _nothiType.GetNothiTypeList(dakListUserParam);
            if (nothiType != null && nothiType.status == "success")
            {

                if (nothiType.data.Count > 0)
                {
                    foreach (NothiTypeListDTO nothiTypeListDTO in nothiType.data)
                    {
                        cbxNothiType.Items.Add(nothiTypeListDTO.nothi_type);
                        cbxNothiType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbxNothiType.AutoCompleteSource = AutoCompleteSource.ListItems;

                    }

                }
            }
        }
        public void LoadOfficerListDropDown()
        {
            
            _dakuserparam = _userService.GetLocalDakUserParam();
            designationSealListResponse = _designationSealService.GetAllDesignationSeal(_dakuserparam, _dakuserparam.office_id);
            if (designationSealListResponse != null && designationSealListResponse.status == "success")
            {

                if (designationSealListResponse.data.Count > 0)
                {
                    foreach (PrapokDTO prapokDTO in designationSealListResponse.data)
                    {
                        cbxSearchOfficer.Items.Add(prapokDTO.NameWithOrganogram);
                        cbxSearchOfficer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbxSearchOfficer.AutoCompleteSource = AutoCompleteSource.ListItems;

                    }

                }
            }
        }
        public void LoadNothiBranchListDropDown()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            nothiBranch = _nothiType.GetNothiBranchList(dakListUserParam);
            if (nothiBranch != null && nothiBranch.status == "success")
            {

                if (nothiBranch.data.Count > 0)
                {
                    foreach (NothiBranchUnitDTO nothiBranchDTO in nothiBranch.data[0].units)
                    {
                        cbxNothiBranch.Items.Add(nothiBranchDTO.unit_name_bng);
                        cbxNothiBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbxNothiBranch.AutoCompleteSource = AutoCompleteSource.ListItems;

                    }

                }
            }
        }
        public void loadNothiInboxTotal()
        {
            //var noteList = _nothiNoteTalikaServices.GetNothiNoteListInbox(_dakuserparam, -1);
            ////lbTotalNothi.Text = "সর্বমোট: " + string.Concat(noteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
            //NothiInboxTotal.Text = string.Concat(noteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            NothiInboxTotal.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());
        }
        public void forceLoadNewNothi()
        {
            nothiListFlowLayoutPanel.Controls.Clear();
            newNothi.Dock = System.Windows.Forms.DockStyle.Fill;
            //newNothi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            newNothi.loadNewNothiPage();
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNewNothi as Button);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 50);
            //newNothi.Size = this.Size - panel4.Size;
            newNothi.Height = this.Height - panel2.Height - pnlNothiNoteTalika.Height - panel6.Height;
            newNothi.Width = bodyPanel.Width;
            Controls.Add(newNothi);
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;
        }
        public void LoadNothiInboxButton(object sender, EventArgs e)
        {
            btnNothiInbox_Click_1(sender, e);
        }
        public void LoadNothiOutboxButton(object sender, EventArgs e)
        {
            btnNothiOutbox_Click(sender, e);
        }public void LoadNothiAllButton(object sender, EventArgs e)
        {
            btnNothiAll_Click(sender, e);
        }
        public void LoadOthersOfficeNothiInboxButton(object sender, EventArgs e)
        {
            btnOtherOfficeNothiInbox_Click(sender, e);
        }
        public void LoadOthersOfficeNothiOutboxButton(object sender, EventArgs e)
        {
            btnOtherOfficeNothiOutbox_Click(sender, e);
        }

        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }
        private void btnNothiInbox_Click(object sender, EventArgs e)
        {

        }
        public void allNextButtonVisibilityOff()
        {
            btnNothiInboxNext.Visible = false;
            btnNothiAllNext.Visible = false;
            btnNothiOutboxNext.Visible = false;
            btnOthersOfficeNothiInboxNext.Visible = false;
            btnOthersOfficeNothiOutboxNext.Visible = false;
        }
        public void allPreviousButtonVisibilityOff()
        {
            btnNothiInboxPrevious.Visible = false;
            btnNothiAllPrevious.Visible = false;
            btnNothiOutboxPrevious.Visible = false;
            btnOthersOfficeNothiInboxPrevious.Visible = false;
            btnOthersOfficeNothiOutboxPrevious.Visible = false;
        }

        int limitNothiInboxNo, pageNoNothiInboxNo, totalNothiInboxNo, lengthStartNothiInboxNo, lengthEndNothiInboxNo;
        private void LoadNothiInbox()
        {
            allPreviousButtonVisibilityOff();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            limitNothiInboxNo = 10;
            pageNoNothiInboxNo = 1;
            dakListUserParam.limit = limitNothiInboxNo;
            dakListUserParam.page = pageNoNothiInboxNo;
            var token = _userService.GetToken();
            var nothiInbox = _nothiInbox.GetNothiInbox(dakListUserParam);
            if (nothiInbox != null && nothiInbox.status == "success")
            {
                //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                totalNothiInboxNo = nothiInbox.data.total_records;

                if (nothiInbox.data.records.Count > 0)
                {
                    lengthEndNothiInboxNo = nothiInbox.data.records.Count;
                    lbLengthStart.Text = string.Concat(pageNoNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbLengthEnd.Text = string.Concat(lengthEndNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allNextButtonVisibilityOff();
                    if (totalNothiInboxNo > 10)
                    {
                        btnNothiInboxNext.Visible = true;
                    }
                    

                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiInboxinPanel(nothiInbox.data.records);

                }
                else
                {
                    allNextButtonVisibilityOff();

                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }

        }
        private void btnNothiInboxNext_Click(object sender, EventArgs e)
        {

            if (limitNothiInboxNo * pageNoNothiInboxNo < totalNothiInboxNo)
            {
                pageNoNothiInboxNo++;
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = limitNothiInboxNo;
                dakListUserParam.page = pageNoNothiInboxNo;
                var nothiInbox = _nothiInbox.GetNothiInbox(dakListUserParam);
                if (nothiInbox.status == "success")
                {
                    //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                    totalNothiInboxNo = nothiInbox.data.total_records;

                    if (nothiInbox.data.records.Count > 0)
                    {
                        lengthStartNothiInboxNo = lengthEndNothiInboxNo + 1;
                        lengthEndNothiInboxNo = lengthEndNothiInboxNo + nothiInbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(lengthStartNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allPreviousButtonVisibilityOff();
                        btnNothiInboxPrevious.Visible = true;
                        allNextButtonVisibilityOff();
                        btnNothiInboxNext.Visible = true;
                        if (lengthEndNothiInboxNo == totalNothiInboxNo)
                        {
                            allNextButtonVisibilityOff();
                        }

                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        nothiListFlowLayoutPanel.Controls.Clear();
                        LoadNothiInboxinPanel(nothiInbox.data.records);

                    }
                    else
                    {
                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }
                }
            }
            else
            {
                allNextButtonVisibilityOff();
            }
        }

        private void btnNothiInboxPrevious_Click(object sender, EventArgs e)
        {
            DakUserParam dakListUserParamextra = _userService.GetLocalDakUserParam();
            limitNothiInboxNo = 10;
            dakListUserParamextra.limit = limitNothiInboxNo;
            dakListUserParamextra.page = pageNoNothiInboxNo;
            var nothiInboxextra = _nothiInbox.GetNothiInbox(dakListUserParamextra);
            if (nothiInboxextra.status == "success")
            {
                if (nothiInboxextra.data.records.Count > 0)
                {
                    lengthStartNothiInboxNo = lengthStartNothiInboxNo - limitNothiInboxNo;
                    lengthEndNothiInboxNo = lengthEndNothiInboxNo - nothiInboxextra.data.records.Count;
                }
            }
            pageNoNothiInboxNo--;
            if (pageNoNothiInboxNo > 0)
            {
                if (pageNoNothiInboxNo == 1)
                {
                    allPreviousButtonVisibilityOff();
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    limitNothiInboxNo = 10;
                    pageNoNothiInboxNo = 1;
                    dakListUserParam.limit = limitNothiInboxNo;
                    dakListUserParam.page = pageNoNothiInboxNo;
                    var token = _userService.GetToken();
                    var nothiInbox = _nothiInbox.GetNothiInbox(dakListUserParam);
                    if (nothiInbox.status == "success")
                    {
                        //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                        totalNothiInboxNo = nothiInbox.data.total_records;

                        if (nothiInbox.data.records.Count > 0)
                        {
                            lengthEndNothiInboxNo = nothiInbox.data.records.Count;
                            lbLengthStart.Text = string.Concat(pageNoNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allNextButtonVisibilityOff();
                            btnNothiInboxNext.Visible = true;

                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            LoadNothiInboxinPanel(nothiInbox.data.records);

                        }
                        else
                        {
                            allNextButtonVisibilityOff();

                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
                if (limitNothiInboxNo * pageNoNothiInboxNo < totalNothiInboxNo && pageNoNothiInboxNo > 1)
                {
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    dakListUserParam.limit = limitNothiInboxNo;
                    dakListUserParam.page = pageNoNothiInboxNo;
                    var nothiInbox = _nothiInbox.GetNothiInbox(dakListUserParam);
                    if (nothiInbox.status == "success")
                    {
                        //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                        totalNothiInboxNo = nothiInbox.data.total_records;

                        if (nothiInbox.data.records.Count > 0)
                        {
                            lbLengthStart.Text = string.Concat(lengthStartNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allPreviousButtonVisibilityOff();
                            btnNothiInboxPrevious.Visible = true;
                            allNextButtonVisibilityOff();
                            btnNothiInboxNext.Visible = true;

                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            nothiListFlowLayoutPanel.Controls.Clear();
                            LoadNothiInboxinPanel(nothiInbox.data.records);

                        }
                        else
                        {
                            allNextButtonVisibilityOff();

                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
            }
            else
            {
                allPreviousButtonVisibilityOff();
            }

        }

        int nothiInboxDisplayed = 0;
        int index = 0;
        NothiListRecordsDTO nothiInboxRecord;
        private void LoadNothiInboxinPanel(List<NothiListRecordsDTO> nothiLists)
        {
            List<NothiInbox> nothiInboxs = new List<NothiInbox>();
            nothiListFlowLayoutPanel.Controls.Clear();
            foreach (NothiListRecordsDTO nothiListRecordsDTO in nothiLists)
            {
                nothiInboxRecord = nothiListRecordsDTO;
                var nothiInbox = UserControlFactory.Create<NothiInbox>();
                nothiInbox.nothiPriority(Convert.ToInt32(nothiListRecordsDTO.priority));
                nothiInbox.nothi = nothiListRecordsDTO.nothi_no + " " + nothiListRecordsDTO.subject;
                nothiInbox.shakha = nothiListRecordsDTO.office_unit_name;
                nothiInbox.totalnothi = nothiListRecordsDTO.note_count.ToString();
                nothiInbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiListRecordsDTO.last_note_date;
                nothiInbox.nothiId = Convert.ToString(nothiListRecordsDTO.id);
                nothiInbox.NewNoteButtonClick += delegate (object sender, EventArgs e) { nothiListRecordsDTO.nothi_type = "Inbox"; NewNote_ButtonClick(sender, e, nothiListRecordsDTO); };
                nothiInbox.NoteDetailsButton += delegate (object sender, EventArgs e) { nothiListRecordsDTO.nothi_type = "Inbox"; NoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiInbox._nothiListInboxNoteRecordsDTO, 1); };// 1 means inbox
                nothiInbox.NoteAllButton += delegate (object sender, EventArgs e) { nothiListRecordsDTO.nothi_type = "Inbox"; NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO, 1); };// 1 means inbox
                nothiInbox.NothiOnumodonButtonClick += delegate (object sender, EventArgs e) { NothiOnumodon_ButtonClick(sender, e, nothiListRecordsDTO); };

                nothiInbox.LocalNoteDetailsButton += delegate (object sender, EventArgs e) {
                    NothiCreateItemAction nothiCreateItemAction = new NothiCreateItemAction();
                    nothiCreateItemAction.nothi_no = nothiListRecordsDTO.nothi_no;
                    nothiCreateItemAction.office_unit_name = nothiListRecordsDTO.office_unit_name;
                    nothiCreateItemAction.nothi_subject = nothiListRecordsDTO.subject;
                    nothiCreateItemAction.designation = nothiListRecordsDTO.office_designation_name;
                    nothiCreateItemAction.office_unit_name = nothiListRecordsDTO.office_unit_name;
                    LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction,"Inbox");
                };


                //delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                nothiInbox.nothiListRecordsDTO = nothiListRecordsDTO;

                nothiInboxDisplayed++;
                UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, nothiInbox);
            }
        }
        
        private void NoteAllDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, NothiListAllRecordsDTO nothiAllListDTO, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {

            //if (noteListDataRecordNoteDTO.is_editable == 0)
            //{
            //    this.Hide();
            //}
            //else
            //{
                
            //}
            var form = FormFactory.Create<Note>();
            form.NoteBackButton += delegate (object sender1, EventArgs e1) {
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide() )); }
                var nothi = FormFactory.Create<Nothi>();
                nothi.TopMost = true;
                nothi.LoadNothiAllButton(sender1, e1);
                BeginInvoke((Action)(() => nothi.ShowDialog()));
                BeginInvoke((Action)(() => nothi.TopMost = false));
                nothi.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
            };
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = noteListDataRecordNoteDTO.nothi_note_id.ToString();
            form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteAllDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiAllListDTO, nothiListInboxNoteRecordsDTO); };

            NothiListAllRecordsDTO nothiAllListRecords = nothiAllListDTO;
            form.nothiNo = nothiAllListRecords.nothi.nothi_no;
            form.nothiShakha = nothiAllListRecords.nothi.office_unit_name + " " + _dakuserparam.office_label;
            form.nothiSubject = nothiAllListRecords.nothi.subject;
            form.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            form.nothiLastDate = nothiAllListRecords.nothi.last_note_date;
            

            //var totalnothi = nothiListRecordsDTO.note_count; //nothiListInboxNoteRecordsDTO.note.note_no;
            //totalnothi.ToString();
            form.office = "( " + nothiAllListRecords.nothi.office_name + " " + nothiAllListRecords.nothi.last_note_date + ")";

            NoteView noteView = new NoteView();
            noteView.totalNothi = noteListDataRecordNoteDTO.note_no.ToString();
            noteView.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            noteView.nothiLastDate = nothiAllListRecords.nothi.last_note_date;
            noteView.officerInfo = _dakuserparam.officer + "," + nothiAllListRecords.nothi.office_designation_name + "," + nothiAllListRecords.nothi.office_unit_name + "," + _dakuserparam.office_label;
            noteView.checkBox = "1";
            noteView.nothiNoteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
            noteView.onucchedCount = nothiListInboxNoteRecordsDTO.note.onucched_count.ToString();
            noteView.khosraPotro = nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString();
            noteView.khoshraWaiting = nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval.ToString();
            noteView.approved = nothiListInboxNoteRecordsDTO.note.approved_potro.ToString();
            noteView.potrojari = nothiListInboxNoteRecordsDTO.note.potrojari.ToString();
            noteView.nothivukto = nothiListInboxNoteRecordsDTO.note.nothivukto_potro.ToString();
            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
            //form.loadNoteData(notedata);
            NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
            nothiListRecordsDTO.id = nothiAllListDTO.nothi.id;
            nothiListRecordsDTO.office_id = nothiAllListDTO.nothi.office_id;
            nothiListRecordsDTO.office_name = nothiAllListDTO.nothi.office_name;
            nothiListRecordsDTO.office_unit_id = nothiAllListDTO.nothi.office_unit_id;
            nothiListRecordsDTO.office_unit_name = nothiAllListDTO.nothi.office_unit_name;
            nothiListRecordsDTO.office_unit_organogram_id = nothiAllListDTO.nothi.office_unit_organogram_id;
            nothiListRecordsDTO.office_designation_name = nothiAllListDTO.nothi.office_designation_name;
            nothiListRecordsDTO.nothi_no = nothiAllListDTO.nothi.nothi_no;
            nothiListRecordsDTO.subject = nothiAllListDTO.nothi.subject;
            nothiListRecordsDTO.nothi_class = nothiAllListDTO.nothi.nothi_class;
            nothiListRecordsDTO.last_note_date = nothiAllListDTO.nothi.last_note_date;
            nothiListRecordsDTO.local_nothi_type = nothiAllListDTO.nothi.nothi_type;
            nothiListRecordsDTO.nothi_type = nothiAllListDTO.nothi.nothi_type;
            form.loadNothiInboxRecords(nothiListRecordsDTO);///////////////////////////////////////
            form._nothiListRecordsDTO = nothiListRecordsDTO;
            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;
            form.loadNoteView(noteView);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();


            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, noteListDataRecordNoteDTO.new_tab); };

        }
        private void DoSomethingAsync(object sender, EventArgs e, int i)
        {
            if (i == 0)
            {
                this.Hide();
            }
            else
            {

            }
        }
        private void NoteAll_ButtonClick(NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO, int inboxORoutboxORall)
        {
            NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
            //noteListDataRecordNoteDTO.new_tab = nothiListInboxNoteRecordsDTO.note.new_tab;
            noteListDataRecordNoteDTO.note_no = nothiListInboxNoteRecordsDTO.note.note_no;

            //this.Hide();
            var form = FormFactory.Create<Note>();
            form.NoteBackButton += delegate (object sender1, EventArgs e1) {
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide())); }
                var nothi = FormFactory.Create<Nothi>();
                nothi.TopMost = true;
                if (inboxORoutboxORall == 1)
                {
                    nothi.LoadNothiInboxButton(sender1, e1);
                }
                else if (inboxORoutboxORall == 2)
                {
                    nothi.LoadNothiOutboxButton(sender1, e1);
                }
                else if (inboxORoutboxORall == 3)
                {
                    nothi.LoadNothiAllButton(sender1, e1);
                }
                else if (inboxORoutboxORall == 4)
                {
                    nothi.LoadOthersOfficeNothiInboxButton(sender1, e1);
                }
                else if (inboxORoutboxORall == 5)
                {
                    nothi.LoadOthersOfficeNothiOutboxButton(sender1, e1);
                }
                BeginInvoke((Action)(() => nothi.ShowDialog()));
                BeginInvoke((Action)(() => nothi.TopMost = false));
                nothi.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
            };
            if (inboxORoutboxORall == 2 || inboxORoutboxORall == 4 || inboxORoutboxORall == 5)
            {
                form.visibilityoffNewNoteButton();
            }
            if (inboxORoutboxORall == 1)
            {
                nothiListRecordsDTO.nothi_type = "Inbox";
            }
            else if (inboxORoutboxORall == 2)
            {
                nothiListRecordsDTO.nothi_type = "sent";
            }
            else if (inboxORoutboxORall == 4)
            {
                nothiListRecordsDTO.nothi_type = "other_office_Inbox";
            }
            else if (inboxORoutboxORall == 5)
            {
                nothiListRecordsDTO.nothi_type = "other_office_Outbox";
            }
            else
            {
                nothiListRecordsDTO.nothi_type = "all";
            }
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
            //form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiListInboxNoteRecordsDTO); };

            NothiListRecordsDTO nothiListRecords = nothiListRecordsDTO;
            form.nothiNo = nothiListRecords.nothi_no;
            form.nothiShakha = nothiListRecords.office_unit_name + " " + _dakuserparam.office_label;
            form.nothiSubject = nothiListRecords.subject;
            form.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            form.nothiLastDate = nothiListRecordsDTO.last_note_date;
            form._nothiListRecordsDTO = nothiListRecordsDTO;
            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;

            //var totalnothi = nothiListRecordsDTO.note_count; //nothiListInboxNoteRecordsDTO.note.note_no;
            //totalnothi.ToString();
            form.office = "( " + nothiListRecords.office_name + " " + nothiListRecordsDTO.last_note_date + ")";

            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
            //form.loadNoteData(notedata);
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.noteAllButtonClick(nothiListRecordsDTO);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();


            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }
        private void NoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, int inboxORoutboxORall)
        {
            //if (noteListDataRecordNoteDTO.is_editable == 0)
            //{
            //    this.Hide();
            //}
            //else
            //{

            //}

            var form = FormFactory.Create<Note>();
            form.NoteBackButton += delegate (object sender1, EventArgs e1) {
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide())); }
                var nothi = FormFactory.Create<Nothi>();
                nothi.TopMost = true;
                if (inboxORoutboxORall == 1)
                {
                    nothi.LoadNothiInboxButton(sender1, e1);
                }
                else if (inboxORoutboxORall == 2)
                {
                    nothi.LoadNothiOutboxButton(sender1, e1);
                }
                else if (inboxORoutboxORall == 4)
                {
                    nothi.LoadOthersOfficeNothiInboxButton(sender1, e1);
                }
                else if (inboxORoutboxORall == 5)
                {
                    nothi.LoadOthersOfficeNothiOutboxButton(sender1, e1);
                }
                BeginInvoke((Action)(() => nothi.ShowDialog()));
                BeginInvoke((Action)(() => nothi.TopMost = false));
                nothi.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
            };
            if (inboxORoutboxORall == 2 || inboxORoutboxORall == 4 || inboxORoutboxORall == 5)
            {
                form.visibilityoffNewNoteButton();
            }
            if (inboxORoutboxORall == 1)
            {
                nothiListRecordsDTO.nothi_type = "Inbox";
            }
            else if (inboxORoutboxORall == 2)
            {
                nothiListRecordsDTO.nothi_type = "sent";
            }
            else if (inboxORoutboxORall == 4)
            {
                nothiListRecordsDTO.nothi_type = "other_office_Inbox";
            }
            else if (inboxORoutboxORall == 5)
            {
                nothiListRecordsDTO.nothi_type = "other_office_Outbox";
            }
            else
            {
                nothiListRecordsDTO.nothi_type = "all";
            }
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = noteListDataRecordNoteDTO.nothi_note_id.ToString();
            form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiListInboxNoteRecordsDTO, inboxORoutboxORall); };
            form._noteListDataRecordNoteDTO = noteListDataRecordNoteDTO;
            form._nothiListRecordsDTO = nothiListRecordsDTO;
            form._nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;

            NothiListRecordsDTO nothiListRecords = nothiListRecordsDTO;
            form.nothiNo = nothiListRecords.nothi_no;
            form.nothiShakha = nothiListRecords.office_unit_name + " " + _dakuserparam.office_label;
            form.nothiSubject = nothiListRecords.subject;
            form.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            form.nothiLastDate = nothiListRecordsDTO.last_note_date;
            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;

            //var totalnothi = nothiListRecordsDTO.note_count; //nothiListInboxNoteRecordsDTO.note.note_no;
            //totalnothi.ToString();
            form.office = "( " + nothiListRecords.office_name + " " + nothiListRecordsDTO.last_note_date + ")";

            NoteView noteView = new NoteView();
            noteView.totalNothi = noteListDataRecordNoteDTO.note_no.ToString();
            noteView.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            noteView.nothiLastDate = nothiListRecordsDTO.last_note_date;
            noteView.officerInfo = _dakuserparam.officer + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
            noteView.checkBox = "1";
            noteView.nothiNoteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
            noteView.onucchedCount = nothiListInboxNoteRecordsDTO.note.onucched_count.ToString();
            noteView.khosraPotro = nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString();
            noteView.khoshraWaiting = nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval.ToString();
            noteView.approved = nothiListInboxNoteRecordsDTO.note.approved_potro.ToString();
            noteView.potrojari = nothiListInboxNoteRecordsDTO.note.potrojari.ToString();
            noteView.nothivukto = nothiListInboxNoteRecordsDTO.note.nothivukto_potro.ToString();
            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
            //form.loadNoteData(notedata);
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.loadNoteView(noteView);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();


            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, noteListDataRecordNoteDTO.new_tab); };
        }

        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        private void LocalNoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, NothiCreateItemAction nothiCreateItemAction, string nothi_type)
        {
            //this.Hide();
            var form = FormFactory.Create<Note>();
            form.NoteBackButton += delegate (object sender1, EventArgs e1) {
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide())); }
                var nothi = FormFactory.Create<Nothi>();
                nothi.TopMost = true;
                if (nothi_type == "Inbox")
                {
                    nothi.LoadNothiInboxButton(sender1, e1);
                }
                else if (nothi_type == "sent")
                {
                    nothi.LoadNothiOutboxButton(sender1, e1);
                }
                else if (nothi_type == "all")
                {
                    nothi.LoadNothiAllButton(sender1, e1);
                }
                BeginInvoke((Action)(() => nothi.ShowDialog()));
                BeginInvoke((Action)(() => nothi.TopMost = false));
                nothi.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
            };
            if (nothi_type == "sent")
            {
                form.visibilityoffNewNoteButton();
            }
            //form.ShowDialog();vf

            _dakuserparam = _userService.GetLocalDakUserParam();

            form.nothiNo = nothiCreateItemAction.nothi_no;
            form.nothiShakha = nothiCreateItemAction.office_unit_name + " " + _dakuserparam.office_label;
            form.nothiSubject = nothiCreateItemAction.nothi_subject;
            form.noteSubject = noteListDataRecordNoteDTO.note_subject;
            //form.noteIdfromNothiInboxNoteShomuho = notedata.note_id.ToString();
            //var totalnothi = nothiListRecordsDTO.note_count; //nothiListInboxNoteRecordsDTO.note.note_no;
            //totalnothi.ToString();
            //form.office = "( " + nothiCreateItemAction.office_name + " " + nothiListRecordsDTO.last_note_date + ")";

            NoteView noteView = new NoteView();
            noteView.totalNothi = noteListDataRecordNoteDTO.note_no.ToString();
            noteView.noteSubject = noteListDataRecordNoteDTO.note_subject;
            //noteView.nothiLastDate = nothiListRecordsDTO.last_note_date;
            noteView.officerInfo = _dakuserparam.officer + "," + nothiCreateItemAction.designation + "," + nothiCreateItemAction.office_unit_name + "," + _dakuserparam.office_label;
            noteView.checkBox = "1";
            noteView.nothiNoteID = noteListDataRecordNoteDTO.nothi_note_id;

            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
            //form.loadNoteData(notedata);
            NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
            nothiListRecordsDTO.id = noteListDataRecordNoteDTO.extra_nothi_id;
            nothiListRecordsDTO.local_nothi_type = nothi_type;
            nothiListRecordsDTO.office_unit_name = nothiCreateItemAction.office_unit_name;
            nothiListRecordsDTO.nothi_no = nothiCreateItemAction.nothi_no;
            nothiListRecordsDTO.office_name = _dakuserparam.officer_name;
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.loadNoteView(noteView);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();
            form.setStatus("offline");

            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void NewNote_ButtonClick(object sender, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO)
        {
            NothiListRecordsDTO nothiListRecords = nothiListRecordsDTO;
            var form = FormFactory.Create<CreateNewNotes>();

            form.SaveNewNoteButtonClick += delegate (object sender1, EventArgs e1) { SaveNewNote_ButtonClick(sender1, e1, nothiListRecords); };
            //form.ShowDialog();

            CalPopUpWindow(form);

        }
        private void NothiOnumodon_ButtonClick(object sender, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO)
        {
            NothiListRecordsDTO nothiListRecords = nothiListRecordsDTO;
            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiListRecordsDTO;
            form.GetNothiInboxRecords(nothiListRecords,"","");
            form.SuccessfullyOnumodonSaveButton += delegate (object saveOnumodonButtonSender, EventArgs saveOnumodonButtonEvent) { ClickNothiInbox(); };

            CalPopUpWindow(form);

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
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        private void SaveNewNote_ButtonClick(object sender, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO)
        {
            string noteSubject = sender.ToString();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var noteSave = _noteSave.GetNoteSave(dakListUserParam, nothiListRecordsDTO, noteSubject);
            if (!InternetConnection.Check())
            {
                if (noteSave.status == "success" && noteSave.message == "Local")
                {
                    foreach (Form f in Application.OpenForms)
                    { BeginInvoke((Action)(() => f.Hide())); }
                    
                    var form = FormFactory.Create<Nothi>();
                    form.TopMost = true;
                    form.LoadNothiInbox();
                    BeginInvoke((Action)(() => form.ShowDialog()));
                    BeginInvoke((Action)(() => form.TopMost = false));
                    form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
                }
            }
            else
            {
                if (noteSave.status == "success")
                {
                    NoteSaveDTO notedata = noteSave.data;
                    //this.Hide();

                    var form = FormFactory.Create<Note>();
                    form.NoteBackButton += delegate (object sender1, EventArgs e1) {
                        foreach (Form f in Application.OpenForms)
                        { BeginInvoke((Action)(() => f.Hide())); }
                        var nothi = FormFactory.Create<Nothi>();
                        nothi.TopMost = true;
                        if (nothiListRecordsDTO.nothi_type == "Inbox")
                        {
                            nothi.LoadNothiInboxButton(sender1, e1);
                        }
                        else if (nothiListRecordsDTO.nothi_type == "sent")
                        {
                            nothi.LoadNothiOutboxButton(sender1, e1);
                        }
                        else if (nothiListRecordsDTO.nothi_type == "all")
                        {
                            nothi.LoadNothiAllButton(sender1, e1);
                        }
                        BeginInvoke((Action)(() => nothi.ShowDialog()));
                        BeginInvoke((Action)(() => nothi.TopMost = false));
                        nothi.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
                    };
                    if (nothiListRecordsDTO.nothi_type == "sent")
                    {
                        form.visibilityoffNewNoteButton();
                    }
                    _dakuserparam = _userService.GetLocalDakUserParam();

                    NothiListRecordsDTO nothiListRecords = nothiListRecordsDTO;
                    form.nothiNo = nothiListRecords.nothi_no;
                    form.nothiShakha = nothiListRecords.office_unit_name + " " + _dakuserparam.office_label;
                    form.nothiSubject = nothiListRecords.subject;
                    form.noteSubject = sender.ToString();
                    form.nothiLastDate = nothiListRecordsDTO.last_note_date;
                    form.noteIdfromNothiInboxNoteShomuho = notedata.note_id.ToString();
                    //var totalnothi = nothiListRecordsDTO.note_count; //nothiListInboxNoteRecordsDTO.note.note_no;
                    //totalnothi.ToString();
                    form.office = "( " + nothiListRecords.office_name + " " + nothiListRecordsDTO.last_note_date + ")";
                    
                    var eachNothiId = nothiListRecords.id;
                    var nothiListUserParam = _userService.GetLocalDakUserParam();
                    string note_category = "all";

                    var nothiInboxNote = _nothiAllNote.GetNothiAllNote(nothiListUserParam, eachNothiId.ToString(), note_category,"asc");
                    if (nothiInboxNote != null && nothiInboxNote.status == "success")
                    {
                        foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiInboxNote.data.records)
                        {
                            if (nothiListInboxNoteRecordsDTO.note.nothi_note_id == notedata.note_id)
                            { form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO; }
                        }
                    }

                    //form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;
                    NoteView noteView = new NoteView();
                    noteView.totalNothi = notedata.note_no.ToString();
                    noteView.noteSubject = sender.ToString();
                    noteView.nothiLastDate = nothiListRecordsDTO.last_note_date;
                    noteView.officerInfo = _dakuserparam.officer + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                    noteView.checkBox = "1";
                    noteView.nothiNoteID = notedata.note_id;

                    //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
                    form.loadNoteData(notedata);
                    form.loadNothiInboxRecords(nothiListRecordsDTO);
                    form.loadNoteView(noteView);
                    form.noteTotal = notedata.note_no.ToString();


                    BeginInvoke((Action)(() => form.ShowDialog()));
                    form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };

                }
                else
                {
                    ErrorMessage(noteSave.status + noteSave.message);
                }
            }
        }
        //private void checkBox_Click(object sender, EventArgs e,NothiListRecordsDTO nothiListRecordsDTO)
        //{
        //    this.Hide();
        //    var form = FormFactory.Create<Note>();
        //    _dakuserparam = _userService.GetLocalDakUserParam();
        //    NothiListRecordsDTO nothiListRecords = nothiListRecordsDTO;
        //    form.nothiNo = nothiListRecords.nothi_no;
        //    form.nothiShakha = nothiListRecords.office_unit_name + " " + _dakuserparam.office_label;
        //    form.nothiSubject = nothiListRecords.subject;

        //    NoteView noteView = new NoteView();
        //    noteView.totalNothi = nothiListRecordsDTO.note_count.ToString();
        //    noteView.noteSubject = sender.ToString();
        //    noteView.nothiLastDate = nothiListRecordsDTO.last_note_date;
        //    noteView.officerInfo = nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
        //    noteView.checkBox = "1";

        //    form.loadNoteView(noteView);
        //    form.offAllNoteView();
        //    form.ShowDialog();

        //}

        private void btnNothi_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };

        }

        private void btnNothiIcon_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void btnDak_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }
        int limitNothiOutboxNo, pageNoNothiOutboxNo, totalNothiOutboxNo, lengthStartNothiOutboxNo, lengthEndNothiOutboxNo;
        private void LoadNothiOutbox()
        {
            allPreviousButtonVisibilityOff();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            limitNothiOutboxNo = 10;
            pageNoNothiOutboxNo = 1;
            dakListUserParam.limit = limitNothiOutboxNo;
            dakListUserParam.page = pageNoNothiOutboxNo;
            var token = _userService.GetToken();
            NothiListOutboxResponse nothiOutbox = _nothiOutbox.GetNothiOutbox(dakListUserParam);

            if (nothiOutbox.status == "success")
            {
                totalNothiOutboxNo = nothiOutbox.data.total_records;

                if (nothiOutbox.data.records.Count > 0)
                {
                    lengthEndNothiOutboxNo = nothiOutbox.data.records.Count;
                    lbLengthStart.Text = string.Concat(pageNoNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbLengthEnd.Text = string.Concat(lengthEndNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allNextButtonVisibilityOff();
                    if (totalNothiOutboxNo > 10)
                    {
                        btnNothiOutboxNext.Visible = true;
                    }
                    

                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiOutboxinPanel(nothiOutbox.data.records);
                }
                else
                {
                    allNextButtonVisibilityOff();
                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }

            }
        }
        private void btnNothiOutboxNext_Click(object sender, EventArgs e)
        {
            if (limitNothiOutboxNo * pageNoNothiOutboxNo < totalNothiOutboxNo)
            {
                pageNoNothiOutboxNo++;
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = limitNothiOutboxNo;
                dakListUserParam.page = pageNoNothiOutboxNo;
                var token = _userService.GetToken();
                NothiListOutboxResponse nothiOutbox = _nothiOutbox.GetNothiOutbox(dakListUserParam);

                if (nothiOutbox.status == "success")
                {
                    totalNothiOutboxNo = nothiOutbox.data.total_records;

                    if (nothiOutbox.data.records.Count > 0)
                    {
                        lengthStartNothiOutboxNo = lengthEndNothiOutboxNo + 1;
                        lengthEndNothiOutboxNo = lengthEndNothiOutboxNo + nothiOutbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(lengthStartNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allPreviousButtonVisibilityOff();
                        btnNothiOutboxPrevious.Visible = true;

                        allNextButtonVisibilityOff();
                        btnNothiOutboxNext.Visible = true;

                        if (lengthEndNothiOutboxNo == totalNothiOutboxNo)
                        {
                            allNextButtonVisibilityOff();
                        }
                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        nothiListFlowLayoutPanel.Controls.Clear();
                        LoadNothiOutboxinPanel(nothiOutbox.data.records);
                    }
                    else
                    {
                        allNextButtonVisibilityOff();
                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }

                }

            }
            else
            {
                allNextButtonVisibilityOff();
            }
        }
        private void btnNothiOutboxPrevious_Click(object sender, EventArgs e)
        {
            DakUserParam dakListUserParamextra = _userService.GetLocalDakUserParam();
            limitNothiOutboxNo = 10;
            dakListUserParamextra.limit = limitNothiOutboxNo;
            dakListUserParamextra.page = pageNoNothiOutboxNo;
            var nothiOutboxextra = _nothiOutbox.GetNothiOutbox(dakListUserParamextra);
            if (nothiOutboxextra.status == "success")
            {
                if (nothiOutboxextra.data.records.Count > 0)
                {
                    lengthStartNothiOutboxNo = lengthStartNothiOutboxNo - limitNothiOutboxNo;
                    lengthEndNothiOutboxNo = lengthEndNothiOutboxNo - nothiOutboxextra.data.records.Count;
                }
            }
            pageNoNothiOutboxNo--;
            if (pageNoNothiOutboxNo > 0)
            {
                if (pageNoNothiOutboxNo == 1)
                {
                    allPreviousButtonVisibilityOff();
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    limitNothiOutboxNo = 10;
                    pageNoNothiOutboxNo = 1;
                    dakListUserParam.limit = limitNothiOutboxNo;
                    dakListUserParam.page = pageNoNothiOutboxNo;
                    var token = _userService.GetToken();
                    NothiListOutboxResponse nothiOutbox = _nothiOutbox.GetNothiOutbox(dakListUserParam);

                    if (nothiOutbox.status == "success")
                    {
                        totalNothiOutboxNo = nothiOutbox.data.total_records;

                        if (nothiOutbox.data.records.Count > 0)
                        {
                            lengthEndNothiOutboxNo = nothiOutbox.data.records.Count;
                            lbLengthStart.Text = string.Concat(pageNoNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allNextButtonVisibilityOff();
                            btnNothiOutboxNext.Visible = true;

                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            LoadNothiOutboxinPanel(nothiOutbox.data.records);
                        }
                        else
                        {
                            allNextButtonVisibilityOff();
                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }

                    }
                }
                if (limitNothiOutboxNo * pageNoNothiOutboxNo < totalNothiOutboxNo && pageNoNothiOutboxNo > 1)
                {
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    dakListUserParam.limit = limitNothiOutboxNo;
                    dakListUserParam.page = pageNoNothiOutboxNo;
                    var token = _userService.GetToken();
                    NothiListOutboxResponse nothiOutbox = _nothiOutbox.GetNothiOutbox(dakListUserParam);

                    if (nothiOutbox.status == "success")
                    {
                        totalNothiOutboxNo = nothiOutbox.data.total_records;

                        if (nothiOutbox.data.records.Count > 0)
                        {
                            lbLengthStart.Text = string.Concat(lengthStartNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allPreviousButtonVisibilityOff();
                            btnNothiOutboxPrevious.Visible = true;
                            allNextButtonVisibilityOff();
                            btnNothiOutboxNext.Visible = true;

                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            LoadNothiOutboxinPanel(nothiOutbox.data.records);
                        }
                        else
                        {
                            allNextButtonVisibilityOff();
                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
            }
            else
            {
                allPreviousButtonVisibilityOff();
            }
        }
        private void LoadNothiOutboxinPanel(List<NothiOutboxListRecordsDTO> nothiOutboxLists)
        {
            nothiListFlowLayoutPanel.Controls.Clear();
            List<NothiOutbox> nothiOutboxs = new List<NothiOutbox>();
            int i = 0;
            foreach (NothiOutboxListRecordsDTO nothiOutboxListDTO in nothiOutboxLists)
            {
                //NothiOutbox nothiOutbox = new NothiOutbox();
                NothiOutbox nothiOutbox = UserControlFactory.Create<NothiOutbox>();
                nothiOutbox.nothiPriority(nothiOutboxListDTO.desk.priority);
                nothiOutbox.nothi = nothiOutboxListDTO.nothi.nothi_no + " " + nothiOutboxListDTO.nothi.subject;
                nothiOutbox.shakha = nothiOutboxListDTO.nothi.office_unit_name;
                nothiOutbox.prapok = nothiOutboxListDTO.to.officer + " " + nothiOutboxListDTO.to.designation + "," + nothiOutboxListDTO.to.office_unit + "," + nothiOutboxListDTO.to.office;
                if (nothiOutboxListDTO.desk != null)
                    nothiOutbox.bortomanDesk = nothiOutboxListDTO.desk.officer + " " + nothiOutboxListDTO.desk.designation + "," + nothiOutboxListDTO.desk.office_unit + "," + nothiOutboxListDTO.desk.office;
                nothiOutbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiOutboxListDTO.nothi.last_note_date;
                nothiOutbox.nothiId = nothiOutboxListDTO.nothi.id;
                nothiOutbox.nothi_office = nothiOutboxListDTO.nothi.office_id.ToString();

                nothiOutbox.NothiOutboxOnumodonButtonClick += delegate (object sender, EventArgs e) { NothiOutboxOnumodon_ButtonClick(sender, e, nothiOutboxListDTO); };
                nothiOutbox.NewNoteButtonClick += delegate (object sender, EventArgs e) {
                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = nothiOutboxListDTO.nothi.id;
                    nothiListRecordsDTO.office_id = nothiOutboxListDTO.nothi.office_id;
                    nothiListRecordsDTO.office_name = nothiOutboxListDTO.nothi.office_name;
                    nothiListRecordsDTO.office_unit_id = nothiOutboxListDTO.nothi.office_unit_id;
                    nothiListRecordsDTO.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    nothiListRecordsDTO.office_unit_organogram_id = nothiOutboxListDTO.nothi.office_unit_organogram_id;
                    nothiListRecordsDTO.office_designation_name = nothiOutboxListDTO.nothi.office_designation_name;
                    nothiListRecordsDTO.nothi_no = nothiOutboxListDTO.nothi.nothi_no;
                    nothiListRecordsDTO.subject = nothiOutboxListDTO.nothi.subject;
                    nothiListRecordsDTO.nothi_class = nothiOutboxListDTO.nothi.nothi_class;
                    nothiListRecordsDTO.last_note_date = nothiOutboxListDTO.nothi.last_note_date;
                    nothiListRecordsDTO.nothi_type = "sent";
                    NewNote_ButtonClick(sender, e, nothiListRecordsDTO);
                };

                nothiOutbox.OutboxNoteDetailsButton += delegate (object sender, EventArgs e) {
                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = nothiOutboxListDTO.nothi.id;
                    nothiListRecordsDTO.office_id = nothiOutboxListDTO.nothi.office_id;
                    nothiListRecordsDTO.office_name = nothiOutboxListDTO.nothi.office_name;
                    nothiListRecordsDTO.office_unit_id = nothiOutboxListDTO.nothi.office_unit_id;
                    nothiListRecordsDTO.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    nothiListRecordsDTO.office_unit_organogram_id = nothiOutboxListDTO.nothi.office_unit_organogram_id;
                    nothiListRecordsDTO.office_designation_name = nothiOutboxListDTO.nothi.office_designation_name;
                    nothiListRecordsDTO.nothi_no = nothiOutboxListDTO.nothi.nothi_no;
                    nothiListRecordsDTO.subject = nothiOutboxListDTO.nothi.subject;
                    nothiListRecordsDTO.nothi_class = nothiOutboxListDTO.nothi.nothi_class;
                    nothiListRecordsDTO.last_note_date = nothiOutboxListDTO.nothi.last_note_date;
                    nothiListRecordsDTO.nothi_type = "sent";
                    NoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiOutbox._nothiListInboxNoteRecordsDTO, 2);// 2 means outbox
                };
                nothiOutbox.OutboxNoteRevertButton += delegate (object sender, EventArgs e) { LoadNothiOutboxButton(sender, e); };

                nothiOutbox.NoteAllButton += delegate (object sender, EventArgs e) {
                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = nothiOutboxListDTO.nothi.id;
                    nothiListRecordsDTO.office_id = nothiOutboxListDTO.nothi.office_id;
                    nothiListRecordsDTO.office_name = nothiOutboxListDTO.nothi.office_name;
                    nothiListRecordsDTO.office_unit_id = nothiOutboxListDTO.nothi.office_unit_id;
                    nothiListRecordsDTO.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    nothiListRecordsDTO.office_unit_organogram_id = nothiOutboxListDTO.nothi.office_unit_organogram_id;
                    nothiListRecordsDTO.office_designation_name = nothiOutboxListDTO.nothi.office_designation_name;
                    nothiListRecordsDTO.nothi_no = nothiOutboxListDTO.nothi.nothi_no;
                    nothiListRecordsDTO.subject = nothiOutboxListDTO.nothi.subject;
                    nothiListRecordsDTO.nothi_class = nothiOutboxListDTO.nothi.nothi_class;
                    nothiListRecordsDTO.last_note_date = nothiOutboxListDTO.nothi.last_note_date;
                    nothiListRecordsDTO.nothi_type = "sent";
                    NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO, 2);// 2 means outbox
                };


                nothiOutbox.LocalNoteDetailsButton += delegate (object sender, EventArgs e) {
                    NothiCreateItemAction nothiCreateItemAction = new NothiCreateItemAction();
                    nothiCreateItemAction.nothi_no = nothiOutboxListDTO.nothi.nothi_no;
                    nothiCreateItemAction.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    nothiCreateItemAction.nothi_subject = nothiOutboxListDTO.nothi.subject;
                    nothiCreateItemAction.designation = nothiOutboxListDTO.nothi.office_designation_name;
                    nothiCreateItemAction.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction,"sent");
                };

                nothiOutbox.nothiOutboxListRecordsDTO = nothiOutboxListDTO;
                i = i + 1;
                nothiOutboxs.Add(nothiOutbox);
                UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, nothiOutbox);
            }
        }
        private void NothiOutboxOnumodon_ButtonClick(object sender, EventArgs e, NothiOutboxListRecordsDTO nothiOutboxListDTO)
        {
            NothiListRecordsDTO nothiOutboxListRecords = new NothiListRecordsDTO();
            NothiOutboxDTO nothi = nothiOutboxListDTO.nothi;

            nothiOutboxListRecords.id = nothi.id;
            nothiOutboxListRecords.office_id = nothi.office_id;
            nothiOutboxListRecords.office_name = nothi.office_name;
            nothiOutboxListRecords.office_unit_id = nothi.office_unit_id;
            nothiOutboxListRecords.office_unit_name = nothi.office_unit_name;
            nothiOutboxListRecords.office_unit_organogram_id = nothi.office_unit_organogram_id;
            nothiOutboxListRecords.office_designation_name = nothi.office_designation_name;
            nothiOutboxListRecords.nothi_no = nothi.nothi_no;
            nothiOutboxListRecords.subject = nothi.subject;
            nothiOutboxListRecords.nothi_class = nothi.nothi_class;
            nothiOutboxListRecords.last_note_date = nothi.last_note_date;

            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiOutboxListRecords;
            form.GetNothiInboxRecords(nothiOutboxListRecords,"","");
            form.SuccessfullyOnumodonSaveButton += delegate (object saveOnumodonButtonSender, EventArgs saveOnumodonButtonEvent) { ClickNothiAll(); };

            CalPopUpWindow(form);

        }
        private void NothiAllOnumodon_ButtonClick(object sender, EventArgs e, NothiListAllRecordsDTO nothiAllListDTO)
        {
            NothiListRecordsDTO nothiAllListRecords = new NothiListRecordsDTO();
            NothiAllDTO nothi = nothiAllListDTO.nothi;
          //  nothi.  //
            nothiAllListRecords.id = nothi.id;
            nothiAllListRecords.office_id = nothi.office_id;
            nothiAllListRecords.office_name = nothi.office_name;
          
            nothiAllListRecords.office_unit_id = nothi.office_unit_id;
            nothiAllListRecords.office_unit_name = nothi.office_unit_name;
            nothiAllListRecords.office_unit_organogram_id = nothi.office_unit_organogram_id;
            nothiAllListRecords.office_designation_name = nothi.office_designation_name;
            nothiAllListRecords.nothi_no = nothi.nothi_no;
            nothiAllListRecords.subject = nothi.subject;
            nothiAllListRecords.nothi_class = nothi.nothi_class;
            nothiAllListRecords.last_note_date = nothi.last_note_date;

            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiAllListRecords;
            form.GetNothiInboxRecords(nothiAllListRecords,"","");

            form.SuccessfullyOnumodonSaveButton += delegate (object saveOnumodonButtonSender, EventArgs saveOnumodonButtonEvent) { ClickNothiAll(); };

            CalPopUpWindow(form);

        }
        List<NothiCreateItemAction> nothiCreateItemActions = new List<NothiCreateItemAction>();
        private void loadNothiAllFromLocal()
        {
            if (!InternetConnection.Check())
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                limitNothiAllNo = 10;
                pageNoNothiAllNo = 1;
                dakListUserParam.limit = limitNothiAllNo;
                dakListUserParam.page = pageNoNothiAllNo;
                var nothiAllextra = _nothiAll.GetNothiAll(dakListUserParam);
                int greaterNothiId = 0;
                if (nothiAllextra.status == "success")
                {
                    if (nothiAllextra.data.records.Count > 0)
                    {
                        foreach (NothiListAllRecordsDTO nothiAllListDTO in nothiAllextra.data.records)
                        {
                            if (greaterNothiId < nothiAllListDTO.nothi.id)
                            {
                                greaterNothiId = nothiAllListDTO.nothi.id;
                            }
                            
                        } 
                    }
                }
                nothiListFlowLayoutPanel.Controls.Clear();
                List<NothiAll> nothiAlls = new List<NothiAll>();
                nothiCreateItemActions = _nothiCreateItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                if (nothiCreateItemActions != null && nothiCreateItemActions.Count > 0)
                {
                    greaterNothiId = greaterNothiId + nothiCreateItemActions.Count;
                    foreach (NothiCreateItemAction nothiCreateItemAction in nothiCreateItemActions)
                    {
                        
                        NothiAll nothiAll = UserControlFactory.Create<NothiAll>();
                        nothiAll.nothi = nothiCreateItemAction.nothi_no + " " + nothiCreateItemAction.nothi_subject;
                        nothiAll.shakha = nothiCreateItemAction.nothishkha;
                        
                        if (greaterNothiId != nothiCreateItemAction.nothi_id && nothiCreateItemAction.nothi_id == 0)
                        {
                            nothiAll.nothiId = Convert.ToString(greaterNothiId);
                            nothiCreateItemAction.nothi_id = greaterNothiId;
                            _nothiCreateItemAction.Update(nothiCreateItemAction);
                        }
                        else
                        {
                            nothiAll.nothiId = nothiCreateItemAction.nothi_id.ToString();
                        }
                        greaterNothiId++;

                        nothiAll.NothiAllNewNoteButtonClick += delegate (object sender, EventArgs e) {
                            NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                            nothiListRecordsDTO.id = Convert.ToInt32(sender.ToString());
                            nothiListRecordsDTO.office_id = nothiCreateItemAction.office_id;
                            nothiListRecordsDTO.office_unit_id = nothiCreateItemAction.office_unit_id;
                            nothiListRecordsDTO.office_designation_name = nothiCreateItemAction.designation;
                            nothiListRecordsDTO.nothi_no = nothiCreateItemAction.nothi_no;
                            nothiListRecordsDTO.subject = nothiCreateItemAction.nothi_subject;
                            nothiListRecordsDTO.nothi_type = "all";
                            NewNote_ButtonClick(sender, e, nothiListRecordsDTO);
                        };
                        
                        nothiAll.LocalNoteDetailsButton += delegate (object sender, EventArgs e) {
                            LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction, "all");
                        };

                        nothiAll.flag = 2;
                        nothiAlls.Add(nothiAll);
                        UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, nothiAll);
                    }
                    
                }
            }
        }

        int limitNothiAllNo, pageNoNothiAllNo, totalNothiAllNo, lengthStartNothiAllNo, lengthEndNothiAllNo;
        private void LoadNothiAll()
        {
            loadNothiAllFromLocal();
            allPreviousButtonVisibilityOff();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            limitNothiAllNo = 10;
            pageNoNothiAllNo = 1;
            dakListUserParam.limit = limitNothiAllNo;
            dakListUserParam.page = pageNoNothiAllNo;
            var token = _userService.GetToken();
            var nothiAll = _nothiAll.GetNothiAll(dakListUserParam);

            if (nothiAll.status == "success")
            {
                totalNothiAllNo = nothiAll.data.total_records;

                if (nothiAll.data.records.Count > 0)
                {

                    lengthEndNothiAllNo = nothiAll.data.records.Count;
                    lbLengthStart.Text = string.Concat(pageNoNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbLengthEnd.Text = string.Concat(lengthEndNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allNextButtonVisibilityOff();
                    if (totalNothiAllNo > 10)
                    {
                        btnNothiAllNext.Visible = true;
                    }
                    

                    pnlNoData.Visible = false;
                    //nothiListFlowLayoutPanel.Controls.Clear();
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(totalNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiAllinPanel(nothiAll.data.records);
                }
                else
                {
                    allNextButtonVisibilityOff();
                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }
        }
        private void btnNothiAllNext_Click(object sender, EventArgs e)
        {
            if (limitNothiAllNo * pageNoNothiAllNo < totalNothiAllNo)
            {
                pageNoNothiAllNo++;
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = limitNothiAllNo;
                dakListUserParam.page = pageNoNothiAllNo;
                var token = _userService.GetToken();
                var nothiAll = _nothiAll.GetNothiAll(dakListUserParam);

                if (nothiAll.status == "success")
                {
                    totalNothiAllNo = nothiAll.data.total_records;

                    if (nothiAll.data.records.Count > 0)
                    {
                        lengthStartNothiAllNo = lengthEndNothiAllNo + 1;
                        lengthEndNothiAllNo = lengthEndNothiAllNo + nothiAll.data.records.Count;
                        lbLengthStart.Text = string.Concat(lengthStartNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allPreviousButtonVisibilityOff();
                        btnNothiAllPrevious.Visible = true;

                        allNextButtonVisibilityOff();
                        btnNothiAllNext.Visible = true;

                        if (lengthEndNothiAllNo == totalNothiAllNo)
                        {
                            allNextButtonVisibilityOff();
                        }

                        pnlNoData.Visible = false;
                        nothiListFlowLayoutPanel.Controls.Clear();
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(totalNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        nothiListFlowLayoutPanel.Controls.Clear();
                        LoadNothiAllinPanel(nothiAll.data.records);
                    }
                    else
                    {
                        allNextButtonVisibilityOff();
                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }
                }
            }
            else
            {
                allNextButtonVisibilityOff();
            }
        }
        private void btnNothiAllPrevious_Click(object sender, EventArgs e)
        {
            DakUserParam dakListUserParamextra = _userService.GetLocalDakUserParam();
            limitNothiAllNo = 10;
            dakListUserParamextra.limit = limitNothiAllNo;
            dakListUserParamextra.page = pageNoNothiAllNo;
            var nothiAllextra = _nothiAll.GetNothiAll(dakListUserParamextra);
            if (nothiAllextra.status == "success")
            {
                if (nothiAllextra.data.records.Count > 0)
                {
                    lengthStartNothiAllNo = lengthStartNothiAllNo - limitNothiAllNo;
                    lengthEndNothiAllNo = lengthEndNothiAllNo - nothiAllextra.data.records.Count;
                }
            }

            pageNoNothiAllNo--;
            if (pageNoNothiAllNo > 0)
            {
                if (pageNoNothiAllNo == 1)
                {
                    loadNothiAllFromLocal();
                    allPreviousButtonVisibilityOff();
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    limitNothiAllNo = 10;
                    pageNoNothiAllNo = 1;
                    dakListUserParam.limit = limitNothiAllNo;
                    dakListUserParam.page = pageNoNothiAllNo;
                    var token = _userService.GetToken();
                    var nothiAll = _nothiAll.GetNothiAll(dakListUserParam);

                    if (nothiAll.status == "success")
                    {
                        totalNothiAllNo = nothiAll.data.total_records;

                        if (nothiAll.data.records.Count > 0)
                        {
                            lengthEndNothiAllNo = nothiAll.data.records.Count;
                            lbLengthStart.Text = string.Concat(pageNoNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));


                            allNextButtonVisibilityOff();
                            btnNothiAllNext.Visible = true;

                            pnlNoData.Visible = false;
                            nothiListFlowLayoutPanel.Controls.Clear();
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(totalNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            LoadNothiAllinPanel(nothiAll.data.records);
                        }
                        else
                        {
                            allNextButtonVisibilityOff();
                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
                if (limitNothiAllNo * pageNoNothiAllNo < totalNothiAllNo && pageNoNothiAllNo > 1)
                {
                    allPreviousButtonVisibilityOff();
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    dakListUserParam.limit = limitNothiAllNo;
                    dakListUserParam.page = pageNoNothiAllNo;
                    var token = _userService.GetToken();
                    var nothiAll = _nothiAll.GetNothiAll(dakListUserParam);

                    if (nothiAll.status == "success")
                    {
                        totalNothiAllNo = nothiAll.data.total_records;

                        if (nothiAll.data.records.Count > 0)
                        {
                            //lengthStartNothiAllNo = lengthEndNothiAllNo + 1;
                            //lengthEndNothiAllNo = lengthEndNothiAllNo + nothiAll.data.records.Count;
                            lbLengthStart.Text = string.Concat(lengthStartNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allPreviousButtonVisibilityOff();
                            btnNothiAllPrevious.Visible = true;
                            allNextButtonVisibilityOff();
                            btnNothiAllNext.Visible = true;

                            pnlNoData.Visible = false;
                            nothiListFlowLayoutPanel.Controls.Clear();
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(totalNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            LoadNothiAllinPanel(nothiAll.data.records);
                        }
                        else
                        {
                            allNextButtonVisibilityOff();
                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
            }
            else
            {
                allPreviousButtonVisibilityOff();
            }
        }
        int nothiAllDisplayed = 0;
        int indexNothiAll = 0;
        private void LoadNothiAllinPanel(List<NothiListAllRecordsDTO> nothiAllLists)
        {

            List<NothiAll> nothiAlls = new List<NothiAll>();
            if (InternetConnection.Check())
            {
                nothiListFlowLayoutPanel.Controls.Clear();
            }
            foreach (NothiListAllRecordsDTO nothiAllListDTO in nothiAllLists)
            {
                NothiAll nothiAll = UserControlFactory.Create<NothiAll>();
                
                nothiAll.NothiAllOnumodonButtonClick += delegate (object sender, EventArgs e) { NothiAllOnumodon_ButtonClick(sender, e, nothiAllListDTO); };
                nothiAll.NoteDetailsButton += delegate (object sender, EventArgs e) { nothiAllListDTO.nothi.nothi_type = "all";
                    NoteAllDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiAllListDTO, nothiAll._nothiListInboxNoteRecordsDTO); };
                
                nothiAll.LocalNoteDetailsButton += delegate (object sender, EventArgs e) {
                    NothiCreateItemAction nothiCreateItemAction = new NothiCreateItemAction();
                    nothiCreateItemAction.nothi_no = nothiAllListDTO.nothi.nothi_no;
                    nothiCreateItemAction.office_unit_name= nothiAllListDTO.nothi.office_unit_name;
                    nothiCreateItemAction.nothi_subject= nothiAllListDTO.nothi.subject;
                    nothiCreateItemAction.designation = nothiAllListDTO.nothi.office_designation_name;
                    nothiCreateItemAction.office_unit_name = nothiAllListDTO.nothi.office_unit_name;
                    LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction, "all");
                };

                nothiAll.NoteAllButton += delegate (object sender, EventArgs e) {
                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = nothiAllListDTO.nothi.id;
                    nothiListRecordsDTO.office_id = nothiAllListDTO.nothi.office_id;
                    nothiListRecordsDTO.office_name = nothiAllListDTO.nothi.office_name;
                    nothiListRecordsDTO.office_unit_id = nothiAllListDTO.nothi.office_unit_id;
                    nothiListRecordsDTO.office_unit_name = nothiAllListDTO.nothi.office_unit_name;
                    nothiListRecordsDTO.office_unit_organogram_id = nothiAllListDTO.nothi.office_unit_organogram_id;
                    nothiListRecordsDTO.office_designation_name = nothiAllListDTO.nothi.office_designation_name;
                    nothiListRecordsDTO.nothi_no = nothiAllListDTO.nothi.nothi_no;
                    nothiListRecordsDTO.subject = nothiAllListDTO.nothi.subject;
                    nothiListRecordsDTO.nothi_class = nothiAllListDTO.nothi.nothi_class;
                    nothiListRecordsDTO.last_note_date = nothiAllListDTO.nothi.last_note_date;
                    nothiListRecordsDTO.nothi_type = "all";
                    NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO, 3); // 3 means allnothi
                };

                //nothiAll.NoteAllButton += delegate (object sender, EventArgs e) { NoteAllDetails_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiAllListDTO, nothiAll._nothiListInboxNoteRecordsDTO); };

                nothiAll.NothiAllNewNoteButtonClick += delegate (object sender, EventArgs e) {
                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = nothiAllListDTO.nothi.id;
                    nothiListRecordsDTO.office_id = nothiAllListDTO.nothi.office_id;
                    nothiListRecordsDTO.office_name = nothiAllListDTO.nothi.office_name;
                    nothiListRecordsDTO.office_unit_id = nothiAllListDTO.nothi.office_unit_id;
                    nothiListRecordsDTO.office_unit_name = nothiAllListDTO.nothi.office_unit_name;
                    nothiListRecordsDTO.office_unit_organogram_id = nothiAllListDTO.nothi.office_unit_organogram_id;
                    nothiListRecordsDTO.office_designation_name = nothiAllListDTO.nothi.office_designation_name;
                    nothiListRecordsDTO.nothi_no = nothiAllListDTO.nothi.nothi_no;
                    nothiListRecordsDTO.subject = nothiAllListDTO.nothi.subject;
                    nothiListRecordsDTO.nothi_class = nothiAllListDTO.nothi.nothi_class;
                    nothiListRecordsDTO.last_note_date = nothiAllListDTO.nothi.last_note_date;
                    nothiListRecordsDTO.nothi_type = "all";
                    NewNote_ButtonClick(sender, e, nothiListRecordsDTO);
                };

                nothiAll.nothiAllListDTO = nothiAllListDTO;
                nothiAll.NothiAllEditButtonClick += delegate (object sender, EventArgs e) { NothiAllEdit_ButtonClick(sender, e, nothiAllListDTO); };
                if (nothiAllListDTO.desk != null || nothiAllListDTO.status != null)
                {
                    if (nothiAllListDTO.desk != null)
                    {
                        nothiAll.nothiPriority(nothiAllListDTO.desk.priority);
                        nothiAll.desk = nothiAllListDTO.desk.note_count.ToString();
                    }
                    if (nothiAllListDTO.status != null)
                    {
                        nothiAll.noteTotal = nothiAllListDTO.status.total;
                        nothiAll.permitted = nothiAllListDTO.status.permitted;
                        nothiAll.onishponno = nothiAllListDTO.status.onishponno;
                        nothiAll.nishponno = nothiAllListDTO.status.nishponno;
                        nothiAll.archived = nothiAllListDTO.status.archived;
                    }
                    
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.noteLastDate = "নোটের সর্বশেষ তারিখঃ " + nothiAllListDTO.nothi.last_note_date;
                    nothiAll.nothiId = Convert.ToString(nothiAllListDTO.nothi.id);

                }
                else
                {
                    //NothiAll nothiAll = new NothiAll();
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha =nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.nothiId = Convert.ToString(nothiAllListDTO.nothi.id);
                    nothiAll.flag = 1;
                }
                nothiAlls.Add(nothiAll);
                UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, nothiAll);
            }
            
        }
        private void NothiAllEdit_ButtonClick(object sender, EventArgs e, NothiListAllRecordsDTO nothiAllListDTO)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            NothiInformationResponse nothiInfo = _nothiAll.GetNothiInformation(dakListUserParam, nothiAllListDTO.nothi.id);
            nothiListFlowLayoutPanel.Controls.Clear();
            detailsNothiSearcPanel.Visible = false;
            allReset();
            newNothi.Dock = System.Windows.Forms.DockStyle.Fill;
            //newNothi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            newNothi.loadNewNothiPageWithData(nothiAllListDTO, nothiInfo);
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNewNothi);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 50);
            //newNothi.Size = this.Size - panel4.Size;
            newNothi.Height = this.Height - panel2.Height - pnlNothiNoteTalika.Height - panel6.Height;
            newNothi.Width = bodyPanel.Width;
            Controls.Add(newNothi);
            //<nothi>int borderWidth = (this.Height - this.ClientSize.Height) / 2;
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;
        }
        private void btnGardFile_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
        }
        private void ShowSubMenu(Panel gardFileDropDownPanel)
        {
            if (gardFileDropDownPanel.Visible == true)
            {
                gardFileDropDownPanel.Visible = false;
            }
            else
            {
                gardFileDropDownPanel.Visible = true;
            }
        }
        public NewNothi newNothi = UserControlFactory.Create<NewNothi>();


        private void btnPotrojari_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            newNothi.Visible = false;
            nothiListFlowLayoutPanel.Visible = false;
            pnlNothiNoteTalika.Visible = false;
        }
        private void ResetAllMenuButtonSelection()
        {
            btnNothiInbox.BackColor = Color.White;
            btnNothiInbox.ForeColor = Color.Black;

            btnNothiOutbox.BackColor = Color.White;
            btnNothiOutbox.ForeColor = Color.Black;

            btnNothiAll.BackColor = Color.White;
            btnNothiAll.ForeColor = Color.Black;


            btnNewNothi.BackColor = Color.White;
            btnNewNothi.ForeColor = Color.Black;

            btnOtherOfficeNothiInbox.BackColor = Color.White;
            btnOtherOfficeNothiInbox.ForeColor = Color.Black;

            btnOtherOfficeNothiOutbox.BackColor = Color.White;
            btnOtherOfficeNothiOutbox.ForeColor = Color.Black;

            btnNothiALLDecisionList.BackColor = Color.White;
            btnNothiALLDecisionList.ForeColor = Color.Black;

        }
        private void SelectButton(Button button)
        {
            button.BackColor = Color.FromArgb(243, 246, 249);
            button.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void dakModulePanel_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, dakModulePanel.ClientRectangle,
            //    Color.White, 1, ButtonBorderStyle.Solid, // left
            //    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
            //    Color.White, 1, ButtonBorderStyle.Solid, // right
            //    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }

        private void nothiModulePanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void detailPanelDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void detailPanelDropDownButton_MouseHover(object sender, EventArgs e)
        {
            ClickedDetaiPanleDropDownButtonStyle();
        }
        private void ClickedDetaiPanleDropDownButtonStyle()
        {
            detailPanelDropDownButton.IconColor = Color.White;
            detailPanelDropDownButton.BackColor = Color.FromArgb(136, 80, 250);
        }
        private void detailPanelDropDownButton_MouseLeave(object sender, EventArgs e)
        {
            NormalDetaiPanleDropDownButtonStyle();
        }
        private void NormalDetaiPanleDropDownButtonStyle()
        {
            if (detailsNothiSearcPanel.Visible)
            {
                ClickedDetaiPanleDropDownButtonStyle();

            }
            else
            {

                detailPanelDropDownButton.IconColor = Color.FromArgb(136, 80, 250);
                detailPanelDropDownButton.BackColor = Color.FromArgb(236, 227, 253);
            }

        }
        public void allReset()
        {
            cbxNothiType.Text = "বাছাই করুন";
            cbxPriorityType.Text = "বাছাই করুন";
            cbxSearchOfficer.Text = "নাম/পদবি দিয়ে খুঁজুন";
            cbxNothiBranch.Text = "দপ্তর/শাখা";
            dateRangeTextBox.PlaceholderText = "সময়সীমা";
            dateRangeTextBox.Text = "";
            placeholderTextBox2.Text = "";
            nothiCustomDatePickerUserControl.Visible = false;
        }
        private void detailPanelDropDownButton_Click_1(object sender, EventArgs e)
        {
            if (detailsNothiSearcPanel.Visible == true)
            {
                detailsNothiSearcPanel.Visible = false;
                allReset();
            }
            else
            {
                detailsNothiSearcPanel.Visible = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void nothiModuleNameLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void label22_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void dakModulePanel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
        }

        private void dakModulePanel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void dakModuleNameLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void moduleDakCountLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;

        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }
        private void dakModuleNameLabel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
        }

        private void dakModuleNameLabel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }

        private void moduleDakCountLabel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
        }

        private void moduleDakCountLabel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }



        private void detailSearchStopButton_Click(object sender, EventArgs e)
        {
            if (detailsNothiSearcPanel.Visible == true)
            {
                detailsNothiSearcPanel.Visible = false;
            }
            else
            {
                detailsNothiSearcPanel.Visible = true;
            }
        }
        private int agotoNothiSelected = 0;
        private int preritoNothiSelected = 0;
        private int shokolNothiSelected = 0;
        private int onnoOfficeagotoNothiSelected = 0;
        private int onnoOfficepreritoNothiSelected = 0;
        private void btnNothiInbox_Click_1(object sender, EventArgs e)
        {
            WaitForm.Show(this);
            detailsNothiSearcPanel.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = false;
            someSearchFunctionOn();

            allReset();
            panel3.Visible = true;
            agotoNothiSelected = 1;
            preritoNothiSelected = 0;
            shokolNothiSelected = 0;
            onnoOfficeagotoNothiSelected = 0;
            onnoOfficepreritoNothiSelected = 0;
            _nothiCurrentCategory.isInbox = true;
            _nothiCurrentCategory.isInbox = true;
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiInbox.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNothiInbox);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;

            allNextButtonVisibilityOff();
            btnNothiInboxNext.Visible = true;

            LoadNothiInbox();
            WaitForm.Close();
        }

        private void btnNothiOutbox_Click(object sender, EventArgs e)
        {
            WaitForm.Show(this);
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = false;
            someSearchFunctionOn();
            allReset();
            panel3.Visible = true;
            agotoNothiSelected = 0;
            preritoNothiSelected = 1;
            shokolNothiSelected = 0;
            onnoOfficeagotoNothiSelected = 0;
            onnoOfficepreritoNothiSelected = 0;
            _nothiCurrentCategory.isOutbox = true;

            allPreviousButtonVisibilityOff();
            allNextButtonVisibilityOff();

            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNothiOutbox);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            LoadNothiOutbox();
            WaitForm.Close();

        }
        public void ForceLoadNothiALL()
        {
            WaitForm.Show(this);
            agotoNothiSelected = 0;
            preritoNothiSelected = 0;
            shokolNothiSelected = 1;
            onnoOfficeagotoNothiSelected = 0;
            onnoOfficepreritoNothiSelected = 0;
            _nothiCurrentCategory.isAll = true;
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNothiAll as Button);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            //lpadNothiAllFromLocal();
            LoadNothiAll();
            WaitForm.Close();
        }

        private void btnNothiAll_Click(object sender, EventArgs e)
        {
            WaitForm.Show(this);
           
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = false;
            someSearchFunctionOn();
            allReset();
            panel3.Visible = true;
            agotoNothiSelected = 0;
            preritoNothiSelected = 0;
            shokolNothiSelected = 1;
            _nothiCurrentCategory.isAll = true;

            allPreviousButtonVisibilityOff();
            allNextButtonVisibilityOff();

            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNothiAll);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            LoadNothiAll();
            WaitForm.Close();
        }

        private void ClickNothiAll()
        {
            WaitForm.Show(this);
            agotoNothiSelected = 0;
            preritoNothiSelected = 0;
            shokolNothiSelected = 1;
            _nothiCurrentCategory.isAll = true;
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNothiAll);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            LoadNothiAll();
            WaitForm.Close();
        }
        private void ClickNothiInbox()
        {
            WaitForm.Show(this);
            agotoNothiSelected = 1;
            preritoNothiSelected = 0;
            shokolNothiSelected = 0;
            _nothiCurrentCategory.isInbox = true;
            btnNothiInbox.IconColor = Color.FromArgb(78, 165, 254);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            ResetAllMenuButtonSelection();
            SelectButton(btnNothiInbox);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            LoadNothiInbox();
            WaitForm.Close();
        }

        private void btnNewNothi_Click(object sender, EventArgs e)
        {
            nothiListFlowLayoutPanel.Controls.Clear();
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = false;
            allReset();
            panel3.Visible = true;
            newNothi.Dock = System.Windows.Forms.DockStyle.Fill;
            //newNothi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            newNothi.loadNewNothiPage();
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnOtherOfficeNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 50);
            //newNothi.Size = this.Size - panel4.Size;
            newNothi.Height = this.Height - panel2.Height - pnlNothiNoteTalika.Height - panel6.Height;
            newNothi.Width = bodyPanel.Width;
            Controls.Add(newNothi);
            //<nothi>int borderWidth = (this.Height - this.ClientSize.Height) / 2;
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;
        }
        public void ForceLoadNewNothi()
        {
            //btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            //btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            //btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            //btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            //ResetAllMenuButtonSelection();
            //btnNewNothi.BackColor = Color.FromArgb(243, 246, 249);
            //btnNewNothi.ForeColor = Color.FromArgb(78, 165, 254);
            //newNothi.Visible = true;
            //newNothi.Location = new System.Drawing.Point(233, 50);
            //Controls.Add(newNothi);
            //newNothi.BringToFront();
            //newNothi.BackColor = Color.WhiteSmoke;

            nothiListFlowLayoutPanel.Controls.Clear();
            newNothi.Dock = System.Windows.Forms.DockStyle.Fill;
            newNothi.loadNewNothiPage();
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNewNothi as Button);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 50);
            newNothi.Height = this.Height - panel2.Height - pnlNothiNoteTalika.Height - panel6.Height;
            newNothi.Width = bodyPanel.Width;
            Controls.Add(newNothi);
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;
        }
        designationSelect designationDetailsPanelNothi = new designationSelect();
        
        private void profilePanel_Click(object sender, EventArgs e)
        {

        }


        private void userPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Dock = System.Windows.Forms.DockStyle.Right;
                designationDetailsPanelNothi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                designationDetailsPanelNothi.Visible = true;
                //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(this.Width - designationDetailsPanelNothi.Width, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                //designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                List<OfficeInfoDTO> officeInfoDTO = _userService.GetAllLocalOfficeInfo();


                foreach (OfficeInfoDTO officeInfoDTO1 in officeInfoDTO)
                {
                    dakUserParam.designation_id = officeInfoDTO1.office_unit_organogram_id;
                    dakUserParam.office_id = officeInfoDTO1.office_id;
                    EmployeDakNothiCountResponse singleOfficeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                    var singleOfficeDakNothiCount = singleOfficeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                    officeInfoDTO1.dakCount = singleOfficeDakNothiCount.Value.dak;
                    officeInfoDTO1.nothiCount = singleOfficeDakNothiCount.Value.own_office_nothi;
                }



                designationDetailsPanelNothi.officeInfos = officeInfoDTO;

                designationDetailsPanelNothi.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanelNothi._designationId); };

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
        }
        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            NothiInboxTotal.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());
            loadNothiExtra();
        }

        private void profileShowArrowButton_Click(object sender, EventArgs e)
        {

        }

        private void profilePanel_MouseHover(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void userPictureBox_MouseHover(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void userNameLabel_MouseHover(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void profileShowArrowButton_MouseHover(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void profilePanel_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
        }

        private void nothiBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InternetConnection.Check())
            {
                _nothiTypeSave.SendNothiTypeListFromLocal();
                _nothiCreateServices.SendNothiCreateListFromLocal();
                _noteSave.SendNoteListFromLocal();
                _onucchedFileUploadService.SendNoteListFromLocal();
                _onucchedSave.SendNoteListFromLocal();
                _onuchhedForwardService.SendNoteListFromLocal();
                if (onlineStatus.IconColor != Color.LimeGreen)
                {
                    if (IsHandleCreated)
                    {
                        onlineStatus.Invoke(new MethodInvoker(delegate
                        {
                            onlineStatus.IconColor = Color.LimeGreen;
                            MyToolTip.SetToolTip(onlineStatus, "Online");
                        }));
                    }
                    else
                    {

                    }

                }
            }
            else
            {
                if (IsHandleCreated)
                {
                    onlineStatus.Invoke(new MethodInvoker(delegate
                    {
                        onlineStatus.IconColor = Color.Silver;
                        MyToolTip.SetToolTip(onlineStatus, "Offline");
                    }));
                }
                else
                {

                }



            }
        }

        private void nothiBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Thread.Sleep(100);
            //nothiBackGroundWorker.RunWorkerAsync();
            if (!nothiBackGroundWorker.IsBusy && this.Visible)
            {
                nothiBackGroundWorker.RunWorkerAsync();
            }
        }

        private void Nothi_Load_1(object sender, EventArgs e)
        {
            label7.Text = UIDesignCommonMethod.copyRightLableText;
            nothiBackGroundWorker.RunWorkerAsync();
        }

        private void modulePanel_Paint(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.dropShadow(sender, e);
        }

        private void userPictureBox_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
        }

        private void detailSearchStopButton_Click_1(object sender, EventArgs e)
        {
            detailsNothiSearcPanel.Visible = false;
            allReset();
        }
        
        private void btnTimeLimit_Click(object sender, EventArgs e)
        {
            if (!nothiCustomDatePickerUserControl.Visible)
            {
                
                //nothiCustomDatePickerUserControl.AutoSize = false;
                //nothiCustomDatePickerUserControl.Height = 300;
                nothiCustomDatePickerUserControl.Dock = DockStyle.None;
                nothiCustomDatePickerUserControl.Location = new System.Drawing.Point(panel4.Width + panel22.Width + panel23.Width + panel24.Width + 4, 
                    panel2.Height + panel12.Height + nothiSearchHeadingPanel.Height + panel5.Height + panel14.Height + panel13.Height + panel15.Height);
                Controls.Add(nothiCustomDatePickerUserControl);
                nothiCustomDatePickerUserControl.BringToFront();
                nothiCustomDatePickerUserControl.Visible = true;
                

            }
            else
            {
                nothiCustomDatePickerUserControl.Visible = false;
            }
        }
        private void customDatePicker_OptionClick(object sender, EventArgs e)
        {
            last_modified_date = nothiCustomDatePickerUserControl._date;
            dateRangeTextBox.Text = nothiCustomDatePickerUserControl._date;

            nothiCustomDatePickerUserControl.Visible = false;
        }

        private void detailsSearchResetButton_Click(object sender, EventArgs e)
        {
            allReset();

        }
        public string last_modified_date = "";
        private void detailSearchButton_Click(object sender, EventArgs e)
        {
            detailsNothiSearcPanel.Visible = false;

            NothiTypeListDTO nothiSelectedType = new NothiTypeListDTO();
            PrapokDTO designation = new PrapokDTO();
            NothiBranchUnitDTO office = new NothiBranchUnitDTO();
            int priority = 0;

            if (cbxNothiType.Text != "বাছাই করুন" && cbxNothiType.Text !="") 
            {
                int i = cbxNothiType.SelectedIndex;
                nothiSelectedType.id = nothiType.data[i].id;
            }
            else
            {
                nothiSelectedType.id = 0;
            }

            if (cbxPriorityType.Text != "বাছাই করুন")
            {
                if (cbxPriorityType.Text == "সর্বোচ্চ অগ্রাধিকার")
                {
                    priority = 3;
                }
                else if (cbxPriorityType.Text == "অবিলম্বে")
                {
                    priority = 2;
                }
                else if (cbxPriorityType.Text == "জরুরি")
                {
                    priority = 1;
                }
                else
                {
                    priority = 0;
                }
            }
            else
            {
                priority = 0;
            }
            if (cbxSearchOfficer.Text != "নাম/পদবি দিয়ে খুঁজুন" && cbxSearchOfficer.Text != "")
            {
                int i = cbxSearchOfficer.SelectedIndex;
                designation.designation_id = designationSealListResponse.data[i].designation_id;
            }
            else
            {
                designation.designation_id = 0;
            }
            if (cbxNothiBranch.Text != "দপ্তর/শাখা" && cbxNothiBranch.Text !="")
            {
                int i = cbxNothiBranch.SelectedIndex;
                office.office_unit_id = nothiBranch.data[0].units[i].office_unit_id;

            }
            else
            {
                office.office_unit_id = 0;
            }
            if (dateRangeTextBox.Text != "")
            {

            }
            else
            {
                last_modified_date = "";
            }
            string nothiSubject = placeholderTextBox2.Text;
            //string date = dateRangeTextBox.Text;

            var search_Param = "nothi_subject="+ nothiSubject + "&nothi_priority="+ priority + "&nothi_type="+ nothiSelectedType.id + "&office_unit_id="+ office.office_unit_id + "&officer_designation_id="+ designation.designation_id + "&last_modified_date="+ last_modified_date + "";
            var search_Paramforothersoffice = "nothi_subject="+ nothiSubject + "&nothi_priority="+ priority + "&nothi_type="+ nothiSelectedType.id + "&office_unit_id="+ office.office_unit_id + "&to_officer_designation_id=" + designation.designation_id + "&last_modified_date="+ last_modified_date + "";
            //nothi_subject = &nothi_priority = 4 & nothi_type = 0 & office_unit_id = 0 & last_modified_date = 2021 / 09 / 02:2021 / 09 / 08 & to_officer_designation_id = 426733
            //nothi_subject = &nothi_priority = 0 & nothi_type = 0 & office_unit_id = 0 & last_modified_date = &officer_designation_id = 0
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            limitNothiInboxNo = 100000;
            pageNoNothiInboxNo = 1;
            pageNoNothiOutboxNo = 1;
            pageNoNothiAllNo = 1;
            pageNoOtherOfficeNothiInboxNo = 1;
            pageNootherOfficeNothiOutboxNo = 1;
            dakListUserParam.limit = limitNothiInboxNo;
            dakListUserParam.page = pageNoNothiInboxNo;

            if (agotoNothiSelected == 1)
            {
                var nothiSearchInbox = _nothiInbox.GetSearchNothiInbox(dakListUserParam, search_Param);
                if (nothiSearchInbox != null && nothiSearchInbox.status == "success")
                {
                    if (nothiSearchInbox.data.records.Count > 0)
                    {
                        lengthEndNothiInboxNo = nothiSearchInbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(pageNoNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiSearchInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        LoadNothiInboxinPanel(nothiSearchInbox.data.records);

                    }
                    else
                    {
                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }
                }
            }
            else if (preritoNothiSelected == 1)
            {
                NothiListOutboxResponse nothiOutbox = _nothiOutbox.GetNothiOutbox(dakListUserParam, search_Param);

                if (nothiOutbox.status == "success")
                {
                    totalNothiOutboxNo = nothiOutbox.data.total_records;

                    if (nothiOutbox.data.records.Count > 0)
                    {
                        lengthEndNothiOutboxNo = nothiOutbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(pageNoNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        LoadNothiOutboxinPanel(nothiOutbox.data.records);
                    }
                    else
                    {
                        allNextButtonVisibilityOff();
                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }

                }
            }
            else if (shokolNothiSelected == 1)
            {
                var nothiAll = _nothiAll.GetNothiAll(dakListUserParam, search_Param);

                if (nothiAll.status == "success")
                {
                    totalNothiAllNo = nothiAll.data.total_records;

                    if (nothiAll.data.records.Count > 0)
                    {

                        lengthEndNothiAllNo = nothiAll.data.records.Count;
                        lbLengthStart.Text = string.Concat(pageNoNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(totalNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        LoadNothiAllinPanel(nothiAll.data.records);
                    }
                    else
                    {
                        allNextButtonVisibilityOff();
                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }
                }
            }
            else if (onnoOfficeagotoNothiSelected == 1)
            {
                var otherOfficenothiInbox = _nothiInbox.GetOthersOfficeNothiInbox(dakListUserParam, search_Paramforothersoffice);
                if (otherOfficenothiInbox != null && otherOfficenothiInbox.status == "success")
                {
                    //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                    totalOtherOfficeNothiInboxNo = otherOfficenothiInbox.data.total_records;

                    if (otherOfficenothiInbox.data.records.Count > 0)
                    {
                        lengthEndOtherOfficeNothiInboxNo = otherOfficenothiInbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(pageNoOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allNextButtonVisibilityOff();
                        if (totalOtherOfficeNothiInboxNo > 10)
                        {
                            btnOthersOfficeNothiInboxNext.Visible = true;
                        }
                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficenothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        LoadOtherOfficeNothiInboxinPanel(otherOfficenothiInbox.data.records);

                    }
                    else
                    {
                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }
                }
                else
                {
                    allNextButtonVisibilityOff();

                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }
            else if (onnoOfficepreritoNothiSelected == 1)
            {
                OtherOfficeNothiListOutboxResponse otherOfficeNothiOutbox = _nothiOutbox.OtherOfficeNothiOutboxListEndPoint(dakListUserParam, search_Paramforothersoffice);

                if (otherOfficeNothiOutbox.status == "success")
                {
                    totalotherOfficeNothiOutboxNo = otherOfficeNothiOutbox.data.total_records;

                    if (otherOfficeNothiOutbox.data.records.Count > 0)
                    {
                        lengthEndotherOfficeNothiOutboxNo = otherOfficeNothiOutbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(pageNootherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndotherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allNextButtonVisibilityOff();
                        if (totalotherOfficeNothiOutboxNo > 10)
                        {
                            btnOthersOfficeNothiOutboxNext.Visible = true;
                        }

                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficeNothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        LoadOtherOfficeNothiOutboxinPanel(otherOfficeNothiOutbox.data.records);
                    }
                    else
                    {
                        allNextButtonVisibilityOff();
                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }

                }
                else
                {
                    allNextButtonVisibilityOff();

                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (registerPanel.Visible)
            {
                registerPanel.Visible = false;
                registerMenuArrow.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            }
            else
            {
                registerPanel.Visible = true;
                registerMenuArrow.IconChar = FontAwesome.Sharp.IconChar.ChevronUp;
            }
        }
       //NothiRegisterReportUserControl nothiRegisterBook = UserControlFactory.Create<NothiRegisterReportUserControl>();
       // NothiGrahonRegisterReportUserControl nothigrahonRegisterBook = UserControlFactory.Create<NothiGrahonRegisterReportUserControl>();
       // NothiPreronRegisterReportUserControl nothipreronRegisterBook = UserControlFactory.Create<NothiPreronRegisterReportUserControl>();
        private void registerDiaryButton_Click(object sender, EventArgs e)
        {
            
            panel3.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiSearchHeadingPanel.Visible = false;
            nothiRegisterBook.Visible = true;
            nothigrahonRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = false;

            nothiRegisterBook.isNothiRegister = true;
            nothiRegisterBook.Dock = DockStyle.Fill;
            pnlNothiBody.Controls.Add(nothiRegisterBook);
            pnlNothiBody.BringToFront();
           
            //nothiRegisterBook.Show();
        }
      
        private void registerBiliButton_Click(object sender, EventArgs e)
        {
           
            panel3.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiSearchHeadingPanel.Visible = false;
            nothiRegisterBook.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = true;
            nothipreronRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = false;
            //pnlNothiBody.Controls.Clear();
            nothigrahonRegisterBook.isNothiGrahon = true;
            nothigrahonRegisterBook.Dock = DockStyle.Fill;
            pnlNothiBody.Controls.Add(nothigrahonRegisterBook);
            pnlNothiBody.BringToFront();
        }
       

        private void registerGrohonButton_Click(object sender, EventArgs e)
        {
           
            panel3.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiSearchHeadingPanel.Visible = false;
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = true;
            nothiShakaWiseProtibedan.Visible = false;

            nothipreronRegisterBook.isNothiPerito = true;
            //pnlNothiBody.Controls.Clear();
            nothipreronRegisterBook.Dock = DockStyle.Fill;
            pnlNothiBody.Controls.Add(nothipreronRegisterBook);
            pnlNothiBody.BringToFront();

        }

        private void btnPotrajariBohi_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiSearchHeadingPanel.Visible = false;
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiPotrajariRegisterBook.Visible = true;
            nothiShakaWiseProtibedan.Visible = false;
            nothiPotrajariRegisterBook.isPotraJariBohi = true;
            nothiPotrajariRegisterBook.Dock = DockStyle.Fill;
            pnlNothiBody.Controls.Add(nothiPotrajariRegisterBook);
            pnlNothiBody.BringToFront();
        }

        private void btnMasterFile_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiSearchHeadingPanel.Visible = false;
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = false;
            nothiMasterRegisterBook.Visible = true;

            nothiMasterRegisterBook.isNothiMasterFile = true;
            nothiMasterRegisterBook.Dock = DockStyle.Fill;
            pnlNothiBody.Controls.Add(nothiMasterRegisterBook);
            pnlNothiBody.BringToFront();
        }

        private void registerMenuArrow_Click(object sender, EventArgs e)
        {
            if (registerPanel.Visible)
            {
                registerPanel.Visible = false;
                registerMenuArrow.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            }
            else
            {
                registerPanel.Visible = true;
                registerMenuArrow.IconChar = FontAwesome.Sharp.IconChar.ChevronUp;
            }
        }

        private void userNameLabel_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
        }

        private void profileShowArrowButton_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
        }

        private void noteListButton_Click(object sender, EventArgs e)
        {
            WaitForm.Show(this);
            detailsNothiSearcPanel.Visible = false;
            allReset();
            btnNothiTalika.BackColor = Color.FromArgb(130, 80, 230);
            noteListButton.BackColor = Color.FromArgb(102, 16, 242);
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            NothiNoteListResponse noteList = new NothiNoteListResponse();

            if (_nothiCurrentCategory._isAll)
            {
                noteList = _nothiNoteTalikaServices.GetNothiNoteListAll(dakUserParam, -1);

            }
            else if (_nothiCurrentCategory._isInbox)
            {
                noteList = _nothiNoteTalikaServices.GetNothiNoteListInbox(dakUserParam, -1);

            }
            else if (_nothiCurrentCategory._isOutbox)
            {

                noteList = _nothiNoteTalikaServices.GetNothiNoteListSent(dakUserParam, -1);

            }
            try
            {
                if (noteList.data.records.Count > 0)
                {
                    var str = 1;
                    lbLengthStart.Text = string.Concat(str.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbLengthEnd.Text = string.Concat(noteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(noteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();
                    pnlNoData.Visible = false;
                    LoadNote(noteList);
                }
                else
                {
                    var str = 0;
                    lbLengthStart.Text = string.Concat(str.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbLengthEnd.Text = string.Concat(str.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(str.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();
                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }
            catch
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
            WaitForm.Close();
        }
        private void btnOption_ButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, int rowCount)
        {

            if (uc == null)
            {
                uc = new ModalMenuUserControl();
                bool remove = true;
                if (nothiListInboxNoteRecordsDTO.note.onucched_count > 0)
                { remove = false; }
                uc.ButtonVisibility(true, remove, true);
                uc.Location = new Point(((Point)sender).X, ((Point)sender).Y + 10 + rowCount * 6);
                uc.noteEditButtonClick += delegate (object s1, EventArgs e1) { uc_noteEditButtonClick(s1, e1, nothiListInboxNoteRecordsDTO); };
                uc.noteOnumodanButtonClick += delegate (object s2, EventArgs e2) { uc_noteOnumodanButtonClick(s2, e2, nothiListInboxNoteRecordsDTO); };
                uc.noteRemoveButtonClick += delegate (object s3, EventArgs e3) { uc_noteRemoveButtonClick(s3, e3, nothiListInboxNoteRecordsDTO); };

                this.Controls.Add(uc);
                uc.BringToFront();
                uc.Visible = true;
            }
            else
            {
                uc.Visible = false;
                uc = null;
            }

        }
        private void uc_noteOnumodanButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            //uc.Visible = false;
            NoteView newNoteView = new NoteView();

            var nothiListRecord = MappingModels.MapModel<NothiNothiListInboxNoteRecordsDTO, NothiListRecordsDTO>(nothiListInboxNoteRecordsDTO.nothi);
            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiListRecord;

            form.nothiNo = nothiListInboxNoteRecordsDTO.nothi.nothi_no;
            form.nothiShakha = nothiListInboxNoteRecordsDTO.nothi.office;
            form.nothiSubject = nothiListInboxNoteRecordsDTO.nothi.subject;
            form.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            form.nothiLastDate = nothiListInboxNoteRecordsDTO.nothi.nothi_created_date;
            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;

            form.office = nothiListInboxNoteRecordsDTO.nothi.office;


            form.loadNothiInboxRecords(nothiListRecord);
            form.loadNoteView(newNoteView);
            form.noteTotal = ConversionMethod.EnglishNumberToBangla(nothiListInboxNoteRecordsDTO.note.finished_count.ToString());

            form.GetNothiInboxRecords(nothiListRecord, "Note", nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString());
            var notelist = MappingModels.MapModel<NoteNothiListInboxNoteRecordsDTO, NoteListDataRecordNoteDTO>(nothiListInboxNoteRecordsDTO.note);
            //form.loadNewNoteDataFromNote(nothiType);
            form.loadNoteList(notelist);
            CalPopUpWindow(form);
        }

      

        private void uc_noteRemoveButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {

            string message = "নোটটি মুছে ফেলুন";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            if (conditonBoxForm.Yes && nothiListInboxNoteRecordsDTO.note.onucched_count == 0)
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                string model = "NothiNotes";
                string noteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
                var noteDelete = _noteDelete.GetNoteDelteResponse(dakListUserParam, model, noteID);
                if (noteDelete.status == "success")
                {
                    SuccessMessage(noteDelete.status);
                    uc.Visible = false;
                    noteListButton_Click(sender, e);
                }

            }
            else
            {

            }
        }
        private void uc_noteEditButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            var noteCreatePopUpForm = FormFactory.Create<NoteCreatePopUpForm>();

            noteCreatePopUpForm.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            noteCreatePopUpForm.noteId = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
            noteCreatePopUpForm.nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;
            noteCreatePopUpForm.SaveButtonClick += delegate (object senderSaveButton, EventArgs eventSaveButton) {
                noteListButton_Click( null,  null);uc.Visible = false;
            };


            CalPopUpWindow(noteCreatePopUpForm);

        }
        public void someSearchFunctionOffforOthersOffice()
        {
            label16.Visible = false;
            cbxNothiType.Visible = false;
            label5.Visible = false;
            cbxNothiBranch.Visible = false;
        }
        public void someSearchFunctionOn()
        {
            label16.Visible = true;
            cbxNothiType.Visible = true;
            label5.Visible = true;
            cbxNothiBranch.Visible = true;
        }
        private void btnOtherOfficeNothiInbox_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                WaitForm.Show(this);

                nothiRegisterBook.Visible = false;
                nothigrahonRegisterBook.Visible = false;
                nothipreronRegisterBook.Visible = false;
                detailsNothiSearcPanel.Visible = false;
                nothiPotrajariRegisterBook.Visible = false;
                nothiMasterRegisterBook.Visible = false;
                someSearchFunctionOffforOthersOffice();
                allReset();
                panel3.Visible = true;

                agotoNothiSelected = 0;
                preritoNothiSelected = 0;
                shokolNothiSelected = 0;
                onnoOfficeagotoNothiSelected = 1;
                onnoOfficepreritoNothiSelected = 0;
                _nothiCurrentCategory.isOtherOfficeInbox = true;

                allPreviousButtonVisibilityOff();
                allNextButtonVisibilityOff();

                btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
                btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
                btnOtherOfficeNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);

                btnOtherOfficeNothiInbox.IconColor = Color.FromArgb(78, 165, 254);

                ResetAllMenuButtonSelection();
                SelectButton(btnOtherOfficeNothiInbox);

                nothiListFlowLayoutPanel.Visible = true;
                pnlNothiNoteTalika.Visible = true;
                newNothi.Visible = false;

                LoadOtherOfficeNothiInbox();
                WaitForm.Close();
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
        }
        int limitOtherOfficeNothiInboxNo, pageNoOtherOfficeNothiInboxNo, totalOtherOfficeNothiInboxNo, lengthStartOtherOfficeNothiInboxNo, lengthEndOtherOfficeNothiInboxNo;
        private void LoadOtherOfficeNothiInbox()
        {
            allPreviousButtonVisibilityOff();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            limitOtherOfficeNothiInboxNo = 10;
            pageNoOtherOfficeNothiInboxNo = 1;
            dakListUserParam.limit = limitOtherOfficeNothiInboxNo;
            dakListUserParam.page = pageNoOtherOfficeNothiInboxNo;
            var token = _userService.GetToken();
            var searchParam = "";
            var otherOfficenothiInbox = _nothiInbox.GetOthersOfficeNothiInbox(dakListUserParam, searchParam);
            if (otherOfficenothiInbox != null && otherOfficenothiInbox.status == "success")
            {
                //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                totalOtherOfficeNothiInboxNo = otherOfficenothiInbox.data.total_records;

                if (otherOfficenothiInbox.data.records.Count > 0)
                {
                    lengthEndOtherOfficeNothiInboxNo = otherOfficenothiInbox.data.records.Count;
                    lbLengthStart.Text = string.Concat(pageNoOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbLengthEnd.Text = string.Concat(lengthEndOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allNextButtonVisibilityOff();
                    if ( totalOtherOfficeNothiInboxNo > 10)
                    {
                        btnOthersOfficeNothiInboxNext.Visible = true;
                    }
                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficenothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadOtherOfficeNothiInboxinPanel(otherOfficenothiInbox.data.records);

                }
                else
                {
                    allNextButtonVisibilityOff();

                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }
            else
            {
                allNextButtonVisibilityOff();

                pnlNoData.Visible = true;
                nothiListFlowLayoutPanel.Controls.Clear();
            }

        }
        private void btnOthersOfficeNothiInboxNext_Click(object sender, EventArgs e)
        {
            if (limitOtherOfficeNothiInboxNo * pageNoOtherOfficeNothiInboxNo < totalOtherOfficeNothiInboxNo)
            {
                pageNoOtherOfficeNothiInboxNo++;
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = limitOtherOfficeNothiInboxNo;
                dakListUserParam.page = pageNoOtherOfficeNothiInboxNo;
                var searchParam = "";
                var otherOfficenothiInbox = _nothiInbox.GetOthersOfficeNothiInbox(dakListUserParam, searchParam);
                if (otherOfficenothiInbox.status == "success")
                {
                    //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                    totalOtherOfficeNothiInboxNo = otherOfficenothiInbox.data.total_records;

                    if (otherOfficenothiInbox.data.records.Count > 0)
                    {
                        lengthStartOtherOfficeNothiInboxNo = lengthStartOtherOfficeNothiInboxNo + 1;
                        lengthEndOtherOfficeNothiInboxNo = lengthEndOtherOfficeNothiInboxNo + otherOfficenothiInbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(lengthStartOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allPreviousButtonVisibilityOff();
                        btnOthersOfficeNothiInboxPrevious.Visible = true;
                        allNextButtonVisibilityOff();
                        btnOthersOfficeNothiInboxNext.Visible = true;
                        if (lengthEndOtherOfficeNothiInboxNo == totalOtherOfficeNothiInboxNo)
                        {
                            allNextButtonVisibilityOff();
                        }

                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficenothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        nothiListFlowLayoutPanel.Controls.Clear();
                        LoadOtherOfficeNothiInboxinPanel(otherOfficenothiInbox.data.records);

                    }
                    else
                    {
                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }
                }
            }
            else
            {
                allNextButtonVisibilityOff();
            }
        }
        private void btnOthersOfficeNothiInboxPrevious_Click(object sender, EventArgs e)
        {
            DakUserParam dakListUserParamextra = _userService.GetLocalDakUserParam();
            limitOtherOfficeNothiInboxNo = 10;
            dakListUserParamextra.limit = limitOtherOfficeNothiInboxNo;
            dakListUserParamextra.page = pageNoOtherOfficeNothiInboxNo;
            var searchParam = "";
            var otherOfficenothiInboxextra = _nothiInbox.GetOthersOfficeNothiInbox(dakListUserParamextra, searchParam);
            if (otherOfficenothiInboxextra.status == "success")
            {
                if (otherOfficenothiInboxextra.data.records.Count > 0)
                {
                    lengthStartOtherOfficeNothiInboxNo = lengthStartOtherOfficeNothiInboxNo - limitOtherOfficeNothiInboxNo;
                    lengthEndOtherOfficeNothiInboxNo = lengthEndOtherOfficeNothiInboxNo - otherOfficenothiInboxextra.data.records.Count;
                }
            }
            pageNoOtherOfficeNothiInboxNo--;
            if (pageNoOtherOfficeNothiInboxNo > 0)
            {
                if (pageNoOtherOfficeNothiInboxNo == 1)
                {
                    allPreviousButtonVisibilityOff();
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    limitOtherOfficeNothiInboxNo = 10;
                    pageNoOtherOfficeNothiInboxNo = 1;
                    dakListUserParam.limit = limitOtherOfficeNothiInboxNo;
                    dakListUserParam.page = pageNoOtherOfficeNothiInboxNo;
                    var searchParam1 = "";
                    var otherOfficenothiInbox = _nothiInbox.GetOthersOfficeNothiInbox(dakListUserParam, searchParam1);
                    if (otherOfficenothiInbox.status == "success")
                    {
                        //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                        totalNothiInboxNo = otherOfficenothiInbox.data.total_records;

                        if (otherOfficenothiInbox.data.records.Count > 0)
                        {
                            lengthEndOtherOfficeNothiInboxNo = otherOfficenothiInbox.data.records.Count;
                            lbLengthStart.Text = string.Concat(pageNoOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allNextButtonVisibilityOff();
                            btnOthersOfficeNothiInboxNext.Visible = true;

                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficenothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            LoadOtherOfficeNothiInboxinPanel(otherOfficenothiInbox.data.records);

                        }
                        else
                        {
                            allNextButtonVisibilityOff();

                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
                if (limitOtherOfficeNothiInboxNo * pageNoOtherOfficeNothiInboxNo < totalNothiInboxNo && pageNoOtherOfficeNothiInboxNo > 1)
                {
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    dakListUserParam.limit = limitOtherOfficeNothiInboxNo;
                    dakListUserParam.page = pageNoOtherOfficeNothiInboxNo;
                    var searchParam1 = "";
                    var otherOfficenothiInbox = _nothiInbox.GetOthersOfficeNothiInbox(dakListUserParam, searchParam1);
                    if (otherOfficenothiInbox.status == "success")
                    {
                        //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                        totalNothiInboxNo = otherOfficenothiInbox.data.total_records;

                        if (otherOfficenothiInbox.data.records.Count > 0)
                        {
                            lbLengthStart.Text = string.Concat(lengthStartOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndOtherOfficeNothiInboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allPreviousButtonVisibilityOff();
                            btnOthersOfficeNothiInboxPrevious.Visible = true;
                            allNextButtonVisibilityOff();
                            btnOthersOfficeNothiInboxNext.Visible = true;

                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficenothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            nothiListFlowLayoutPanel.Controls.Clear();
                            LoadOtherOfficeNothiInboxinPanel(otherOfficenothiInbox.data.records);

                        }
                        else
                        {
                            allNextButtonVisibilityOff();

                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
            }
            else
            {
                allPreviousButtonVisibilityOff();
            }
        }
        private void LoadOtherOfficeNothiInboxinPanel(List<OthersOfficeNothiListInboxDataRecord> nothiLists)
        {
            nothiListFlowLayoutPanel.Controls.Clear();
            foreach (OthersOfficeNothiListInboxDataRecord nothiListRecordsDTO in nothiLists)
            {
                //nothiInboxRecord = nothiListRecordsDTO;
                var nothiInbox = UserControlFactory.Create<NothiInbox>();
                nothiInbox.nothiPriority(Convert.ToInt32(nothiListRecordsDTO.priority));
                nothiInbox.nothi = nothiListRecordsDTO.nothi_no + " " + nothiListRecordsDTO.subject;
                nothiInbox.shakha = nothiListRecordsDTO.office_unit_name;
                nothiInbox.totalnothi = nothiListRecordsDTO.note_count.ToString();
                nothiInbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiListRecordsDTO.last_note_date;
                nothiInbox.nothiId = Convert.ToString(nothiListRecordsDTO.id);
                nothiInbox.visibilityoffNothiInboxOnumodon();
                nothiInbox._isOtherOffice = true;
                
                nothiInbox.NoteDetailsButton += delegate (object sender, EventArgs e) {
                    
                    NothiListRecordsDTO nothiListRecordsDTO1 = new NothiListRecordsDTO();
                    nothiListRecordsDTO1 = MappingModels.MapModel<OthersOfficeNothiListInboxDataRecord, NothiListRecordsDTO>(nothiListRecordsDTO);
                    nothiListRecordsDTO1.nothi_type = "";
                    NoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiListRecordsDTO1, nothiInbox._nothiListInboxNoteRecordsDTO, 4); };// 4 means otherofficeinbox
                
                nothiInbox.NoteAllButton += delegate (object sender, EventArgs e) {

                    NothiListRecordsDTO nothiListRecordsDTO1 = new NothiListRecordsDTO();
                    nothiListRecordsDTO1 = MappingModels.MapModel<OthersOfficeNothiListInboxDataRecord, NothiListRecordsDTO>(nothiListRecordsDTO);
                    nothiListRecordsDTO1.nothi_type = "";
                    
                    NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO1, 4); };// 4 means other office inbox
                
                UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, nothiInbox);
            }
        }
        private void btnOtherOfficeNothiOutbox_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                WaitForm.Show(this);

                nothiRegisterBook.Visible = false;
                nothigrahonRegisterBook.Visible = false;
                nothipreronRegisterBook.Visible = false;
                detailsNothiSearcPanel.Visible = false;
                nothiPotrajariRegisterBook.Visible = false;
                nothiMasterRegisterBook.Visible = false;
                someSearchFunctionOffforOthersOffice();
                allReset();
                panel3.Visible = true;

                agotoNothiSelected = 0;
                preritoNothiSelected = 0;
                shokolNothiSelected = 0;
                onnoOfficeagotoNothiSelected = 0;
                onnoOfficepreritoNothiSelected = 1;

                _nothiCurrentCategory.isOtherOfficeOutbox = true;

                allPreviousButtonVisibilityOff();
                allNextButtonVisibilityOff();

                btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
                btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
                btnOtherOfficeNothiInbox.IconColor = Color.FromArgb(181, 181, 195);

                btnOtherOfficeNothiOutbox.IconColor = Color.FromArgb(78, 165, 254);

                ResetAllMenuButtonSelection();
                SelectButton(btnOtherOfficeNothiOutbox);

                nothiListFlowLayoutPanel.Visible = true;
                pnlNothiNoteTalika.Visible = true;
                newNothi.Visible = false;

                LoadNothiOtherOfficeNothiOutbox();
                WaitForm.Close();
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
        }
        


        int limitotherOfficeNothiOutboxNo, pageNootherOfficeNothiOutboxNo, totalotherOfficeNothiOutboxNo, lengthStartotherOfficeNothiOutboxNo, lengthEndotherOfficeNothiOutboxNo;

        private void LoadNothiOtherOfficeNothiOutbox()
        {
            allPreviousButtonVisibilityOff();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            limitotherOfficeNothiOutboxNo = 10;
            pageNootherOfficeNothiOutboxNo = 1;
            dakListUserParam.limit = limitotherOfficeNothiOutboxNo;
            dakListUserParam.page = pageNootherOfficeNothiOutboxNo;
            var token = _userService.GetToken();
            var search_param = "";
            OtherOfficeNothiListOutboxResponse otherOfficeNothiOutbox = _nothiOutbox.OtherOfficeNothiOutboxListEndPoint(dakListUserParam, search_param);

            if (otherOfficeNothiOutbox.status == "success")
            {
                totalotherOfficeNothiOutboxNo = otherOfficeNothiOutbox.data.total_records;

                if (otherOfficeNothiOutbox.data.records.Count > 0)
                {
                    lengthEndotherOfficeNothiOutboxNo = otherOfficeNothiOutbox.data.records.Count;
                    lbLengthStart.Text = string.Concat(pageNootherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbLengthEnd.Text = string.Concat(lengthEndotherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allNextButtonVisibilityOff();
                    if (totalotherOfficeNothiOutboxNo > 10)
                    {
                        btnOthersOfficeNothiOutboxNext.Visible = true;
                    }
                    
                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficeNothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadOtherOfficeNothiOutboxinPanel(otherOfficeNothiOutbox.data.records);
                }
                else
                {
                    allNextButtonVisibilityOff();
                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }

            }
            else
            {
                allNextButtonVisibilityOff();

                pnlNoData.Visible = true;
                nothiListFlowLayoutPanel.Controls.Clear();
            }
        }
        private void btnOthersOfficeNothiOutboxNext_Click(object sender, EventArgs e)
        {
            if (limitotherOfficeNothiOutboxNo * pageNootherOfficeNothiOutboxNo < totalOtherOfficeNothiInboxNo)
            {
                pageNootherOfficeNothiOutboxNo++;
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = limitotherOfficeNothiOutboxNo;
                dakListUserParam.page = pageNootherOfficeNothiOutboxNo;
                var searchParam = "";
                var otherOfficeNothiOutbox = _nothiOutbox.OtherOfficeNothiOutboxListEndPoint(dakListUserParam, searchParam);
                if (otherOfficeNothiOutbox.status == "success")
                {
                    //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                    totalotherOfficeNothiOutboxNo = otherOfficeNothiOutbox.data.total_records;

                    if (otherOfficeNothiOutbox.data.records.Count > 0)
                    {
                        lengthStartotherOfficeNothiOutboxNo = lengthStartotherOfficeNothiOutboxNo + 1;
                        lengthEndotherOfficeNothiOutboxNo = lengthEndotherOfficeNothiOutboxNo + otherOfficeNothiOutbox.data.records.Count;
                        lbLengthStart.Text = string.Concat(lengthStartotherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbLengthEnd.Text = string.Concat(lengthEndotherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allPreviousButtonVisibilityOff();
                        btnOthersOfficeNothiOutboxPrevious.Visible = true;
                        allNextButtonVisibilityOff();
                        btnOthersOfficeNothiOutboxNext.Visible = true;
                        if (lengthEndotherOfficeNothiOutboxNo == totalotherOfficeNothiOutboxNo)
                        {
                            allNextButtonVisibilityOff();
                        }

                        pnlNoData.Visible = false;
                        lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficeNothiOutbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        nothiListFlowLayoutPanel.Controls.Clear();
                        LoadOtherOfficeNothiOutboxinPanel(otherOfficeNothiOutbox.data.records);

                    }
                    else
                    {
                        allNextButtonVisibilityOff();

                        pnlNoData.Visible = true;
                        nothiListFlowLayoutPanel.Controls.Clear();
                    }
                }
            }
            else
            {
                allNextButtonVisibilityOff();
            }
        }
        private void btnOthersOfficeNothiOutboxPrevious_Click(object sender, EventArgs e)
        {
            DakUserParam dakListUserParamextra = _userService.GetLocalDakUserParam();
            limitotherOfficeNothiOutboxNo = 10;
            dakListUserParamextra.limit = limitotherOfficeNothiOutboxNo;
            dakListUserParamextra.page = pageNootherOfficeNothiOutboxNo;
            var searchParam = "";
            var otherOfficenothiInboxextra = _nothiOutbox.OtherOfficeNothiOutboxListEndPoint(dakListUserParamextra, searchParam);
            if (otherOfficenothiInboxextra.status == "success")
            {
                if (otherOfficenothiInboxextra.data.records.Count > 0)
                {
                    lengthStartotherOfficeNothiOutboxNo = lengthStartotherOfficeNothiOutboxNo - limitotherOfficeNothiOutboxNo;
                    lengthEndotherOfficeNothiOutboxNo = lengthEndotherOfficeNothiOutboxNo - otherOfficenothiInboxextra.data.records.Count;
                }
            }
            pageNootherOfficeNothiOutboxNo--;
            if (pageNootherOfficeNothiOutboxNo > 0)
            {
                if (pageNootherOfficeNothiOutboxNo == 1)
                {
                    allPreviousButtonVisibilityOff();
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    limitotherOfficeNothiOutboxNo = 10;
                    pageNootherOfficeNothiOutboxNo = 1;
                    dakListUserParam.limit = limitotherOfficeNothiOutboxNo;
                    dakListUserParam.page = pageNootherOfficeNothiOutboxNo;
                    var searchParam1 = "";
                    var otherOfficenothiInbox = _nothiOutbox.OtherOfficeNothiOutboxListEndPoint(dakListUserParam, searchParam1);
                    if (otherOfficenothiInbox.status == "success")
                    {
                        //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                        totalotherOfficeNothiOutboxNo = otherOfficenothiInbox.data.total_records;

                        if (otherOfficenothiInbox.data.records.Count > 0)
                        {
                            lengthEndotherOfficeNothiOutboxNo = otherOfficenothiInbox.data.records.Count;
                            lbLengthStart.Text = string.Concat(pageNootherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndotherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allNextButtonVisibilityOff();
                            btnOthersOfficeNothiOutboxNext.Visible = true;
                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficenothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            LoadOtherOfficeNothiOutboxinPanel(otherOfficenothiInbox.data.records);

                        }
                        else
                        {
                            allNextButtonVisibilityOff();

                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
                if (limitotherOfficeNothiOutboxNo * pageNootherOfficeNothiOutboxNo < totalotherOfficeNothiOutboxNo && pageNootherOfficeNothiOutboxNo > 1)
                {
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    dakListUserParam.limit = limitotherOfficeNothiOutboxNo;
                    dakListUserParam.page = pageNootherOfficeNothiOutboxNo;
                    var searchParam1 = "";
                    var otherOfficenothiInbox = _nothiOutbox.OtherOfficeNothiOutboxListEndPoint(dakListUserParam, searchParam1);
                    if (otherOfficenothiInbox.status == "success")
                    {
                        //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                        totalotherOfficeNothiOutboxNo = otherOfficenothiInbox.data.total_records;

                        if (otherOfficenothiInbox.data.records.Count > 0)
                        {
                            lbLengthStart.Text = string.Concat(lengthStartotherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            lbLengthEnd.Text = string.Concat(lengthEndotherOfficeNothiOutboxNo.ToString().Select(c => (char)('\u09E6' + c - '0')));

                            allPreviousButtonVisibilityOff();
                            btnOthersOfficeNothiOutboxPrevious.Visible = true;
                            allNextButtonVisibilityOff();
                            btnOthersOfficeNothiOutboxNext.Visible = true;

                            pnlNoData.Visible = false;
                            lbTotalNothi.Text = "সর্বমোট: " + string.Concat(otherOfficenothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                            nothiListFlowLayoutPanel.Controls.Clear();
                            LoadOtherOfficeNothiOutboxinPanel(otherOfficenothiInbox.data.records);

                        }
                        else
                        {
                            allNextButtonVisibilityOff();

                            pnlNoData.Visible = true;
                            nothiListFlowLayoutPanel.Controls.Clear();
                        }
                    }
                }
            }
            else
            {
                allPreviousButtonVisibilityOff();
            }
        }
        private void LoadOtherOfficeNothiOutboxinPanel(List<OtherOfficeNothiListOutboxDataRecord> nothiOutboxLists)
        {
            nothiListFlowLayoutPanel.Controls.Clear();
            int i = 0;
            foreach (OtherOfficeNothiListOutboxDataRecord nothiOutboxListDTO in nothiOutboxLists)
            {
                //NothiOutbox nothiOutbox = new NothiOutbox();
                NothiOutbox nothiOutbox = UserControlFactory.Create<NothiOutbox>();
                nothiOutbox.nothiPriority(nothiOutboxListDTO.desk.priority);
                nothiOutbox.nothi = nothiOutboxListDTO.nothi.nothi_no + " " + nothiOutboxListDTO.nothi.subject;
                nothiOutbox.shakha = nothiOutboxListDTO.nothi.office_unit_name;
                nothiOutbox.prapok = nothiOutboxListDTO.to.officer + " " + nothiOutboxListDTO.to.designation + "," + nothiOutboxListDTO.to.office_unit + "," + nothiOutboxListDTO.to.office;
                if (nothiOutboxListDTO.desk != null)
                    nothiOutbox.bortomanDesk = nothiOutboxListDTO.desk.officer + " " + nothiOutboxListDTO.desk.designation + "," + nothiOutboxListDTO.desk.office_unit + "," + nothiOutboxListDTO.desk.office;
                nothiOutbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiOutboxListDTO.nothi.last_note_date;
                nothiOutbox.nothiId = nothiOutboxListDTO.nothi.id;
                nothiOutbox.visibilityOnNothiOutboxOfficePanel();
                nothiOutbox.office = nothiOutboxListDTO.desk.office;
                nothiOutbox._isOtherOffice = true;
                nothiOutbox.nothi_office = nothiOutboxListDTO.nothi.office_id.ToString();



                nothiOutbox.OutboxNoteDetailsButton += delegate (object sender, EventArgs e)
                {
                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = nothiOutboxListDTO.nothi.id;
                    nothiListRecordsDTO.office_id = nothiOutboxListDTO.nothi.office_id;
                    nothiListRecordsDTO.office_name = nothiOutboxListDTO.nothi.office_name;
                    nothiListRecordsDTO.office_unit_id = nothiOutboxListDTO.nothi.office_unit_id;
                    nothiListRecordsDTO.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    nothiListRecordsDTO.office_unit_organogram_id = nothiOutboxListDTO.nothi.office_unit_organogram_id;
                    nothiListRecordsDTO.office_designation_name = nothiOutboxListDTO.nothi.office_designation_name;
                    nothiListRecordsDTO.nothi_no = nothiOutboxListDTO.nothi.nothi_no;
                    nothiListRecordsDTO.subject = nothiOutboxListDTO.nothi.subject;
                    nothiListRecordsDTO.nothi_class = nothiOutboxListDTO.nothi.nothi_class;
                    nothiListRecordsDTO.last_note_date = nothiOutboxListDTO.nothi.last_note_date;
                    nothiListRecordsDTO.nothi_type = "";
                    NoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiOutbox._nothiListInboxNoteRecordsDTO, 5);// 5 means others office outbox
                };


                nothiOutbox.NoteAllButton += delegate (object sender, EventArgs e)
                {
                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = nothiOutboxListDTO.nothi.id;
                    nothiListRecordsDTO.office_id = nothiOutboxListDTO.nothi.office_id;
                    nothiListRecordsDTO.office_name = nothiOutboxListDTO.nothi.office_name;
                    nothiListRecordsDTO.office_unit_id = nothiOutboxListDTO.nothi.office_unit_id;
                    nothiListRecordsDTO.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    nothiListRecordsDTO.office_unit_organogram_id = nothiOutboxListDTO.nothi.office_unit_organogram_id;
                    nothiListRecordsDTO.office_designation_name = nothiOutboxListDTO.nothi.office_designation_name;
                    nothiListRecordsDTO.nothi_no = nothiOutboxListDTO.nothi.nothi_no;
                    nothiListRecordsDTO.subject = nothiOutboxListDTO.nothi.subject;
                    nothiListRecordsDTO.nothi_class = nothiOutboxListDTO.nothi.nothi_class;
                    nothiListRecordsDTO.last_note_date = nothiOutboxListDTO.nothi.last_note_date;
                    nothiListRecordsDTO.nothi_type = "";
                    NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO, 5);// 5 means others office outbox
                };


                //nothiOutbox.nothiOutboxListRecordsDTO = nothiOutboxListDTO;
                i = i + 1;
                UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, nothiOutbox);
            }
        }
        private void protibedanIconButton_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            detailsNothiSearcPanel.Visible = false;
            nothiSearchHeadingPanel.Visible = false;
            nothiRegisterBook.Visible = false;
            nothigrahonRegisterBook.Visible = false;
            nothiMasterRegisterBook.Visible = false;
            nothiPotrajariRegisterBook.Visible = false;
            nothipreronRegisterBook.Visible = false;
            nothiShakaWiseProtibedan.Visible = true;


            nothiShakaWiseProtibedan.Dock = DockStyle.Fill;
            pnlNothiBody.Controls.Add(nothiShakaWiseProtibedan);
            pnlNothiBody.BringToFront();

        }

        private void SaveorUpdate()
        {
            var nothiInbox = UserControlFactory.Create<NothiInbox>();
            nothiInbox.SaveorUpdate();
        }
        private void LoadNote(NothiNoteListResponse noteList)
        {

            if (noteList.data != null)
            {
                nothiListFlowLayoutPanel.Controls.Clear();
                List<NothiNoteTalikaAll> noteListUserControls = new List<NothiNoteTalikaAll>();
                foreach (NothiNoteListRecordDTO noteDTO in noteList.data.records)
                {
                    NothiNoteTalikaAll dakNothiteUposthaponNoteList = new NothiNoteTalikaAll();
                    if (_nothiCurrentCategory._isOutbox)
                    {
                        dakNothiteUposthaponNoteList.btnOptionVisible(!_nothiCurrentCategory._isOutbox);
                    }
                    int rowCount = nothiListFlowLayoutPanel.Controls.Count;
                    dakNothiteUposthaponNoteList.btnOptionClick += delegate (object sender1, EventArgs e1)
                    {
                        NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO = new NothiListInboxNoteRecordsDTO();

                        nothiListInboxNoteRecordsDTO.nothi = MappingModels.MapModel<NoteNothiDTO, NothiNothiListInboxNoteRecordsDTO>(noteDTO.nothi);
                        nothiListInboxNoteRecordsDTO.note = MappingModels.MapModel<NoteDTO, NoteNothiListInboxNoteRecordsDTO>(noteDTO.note);
                        nothiListInboxNoteRecordsDTO.to = MappingModels.MapModel<NoteTo, ToNothiListInboxNoteRecordsDTO>(noteDTO.to);
                        nothiListInboxNoteRecordsDTO.desk = MappingModels.MapModel<NothiNoteDeskDTO, DeskNothiListInboxNoteRecordsDTO>(noteDTO.deskConverted);
                        btnOption_ButtonClick(sender1 as object, e1, nothiListInboxNoteRecordsDTO, rowCount);
                    };
                    dakNothiteUposthaponNoteList.NoteDetailsButton += delegate (object sender, EventArgs e) 
                    {
                        NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                        nothiListRecordsDTO.id = noteDTO.nothi.id;
                        nothiListRecordsDTO.last_note_date = noteDTO.deskConverted.issue_date;
                        nothiListRecordsDTO.nothi_no = noteDTO.nothi.nothi_no;
                        nothiListRecordsDTO.office_unit_name = noteDTO.nothi.office_unit_name;
                        nothiListRecordsDTO.subject = noteDTO.nothi.subject;
                        nothiListRecordsDTO.office_name = noteDTO.nothi.office_name;
                        nothiListRecordsDTO.office_designation_name = noteDTO.nothi.office_designation_name;
                        NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO = new NothiListInboxNoteRecordsDTO();

                        nothiListInboxNoteRecordsDTO.nothi = MappingModels.MapModel<NoteNothiDTO, NothiNothiListInboxNoteRecordsDTO>(noteDTO.nothi);
                        nothiListInboxNoteRecordsDTO.note = MappingModels.MapModel<NoteDTO, NoteNothiListInboxNoteRecordsDTO>(noteDTO.note);
                        nothiListInboxNoteRecordsDTO.to = MappingModels.MapModel<NoteTo, ToNothiListInboxNoteRecordsDTO>(noteDTO.to);
                        nothiListInboxNoteRecordsDTO.desk = MappingModels.MapModel<object, DeskNothiListInboxNoteRecordsDTO>(noteDTO.desk);

                        NoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiListInboxNoteRecordsDTO, 1); ; };// 1 means inbox
                    if (noteDTO.deskConverted != null)
                    {
                        dakNothiteUposthaponNoteList.date = noteDTO.deskConverted.issue_date;
                        dakNothiteUposthaponNoteList.deskofficer = noteDTO.deskConverted.officer;
                        dakNothiteUposthaponNoteList.sub = "শাখা: " + noteDTO.deskConverted.office_unit + "," + noteDTO.deskConverted.office + "; নথি নম্বর: " + noteDTO.nothi.nothi_no + "; বিষয়:" + noteDTO.nothi.subject;
                        dakNothiteUposthaponNoteList.preritoNoteDate = noteDTO.deskConverted.issue_date; ;
                        dakNothiteUposthaponNoteList.preritoNoteCDesk = noteDTO.deskConverted.officer + "," + noteDTO.deskConverted.designation + "," + noteDTO.deskConverted.office_unit + "," + noteDTO.deskConverted.office;


                    }

                    dakNothiteUposthaponNoteList.note_no = Convert.ToString(noteDTO.note.note_no);
                    dakNothiteUposthaponNoteList.note_subject = noteDTO.note.note_subject;

                    //dakNothiteUposthaponNoteList.toofficer = noteDTO.deskConverted.;
                    dakNothiteUposthaponNoteList.potrojari = noteDTO.note.potrojari;
                    dakNothiteUposthaponNoteList.onumodon = noteDTO.note.finished_count;
                    dakNothiteUposthaponNoteList.nothiAttachmentCount = noteDTO.note.attachment_count;
                    // dakNothiteUposthaponNoteList.toofficer = noteDTO;
                    dakNothiteUposthaponNoteList.onucched = noteDTO.note.onucched_count;
                    dakNothiteUposthaponNoteList.nothivukto = noteDTO.note.nothivukto_potro;
                    dakNothiteUposthaponNoteList.nisponnoCount = noteDTO.note.finished_count;
                    dakNothiteUposthaponNoteList.toofficer = noteDTO.to.officer;

                    if (noteDTO.nothi == null)
                    {
                        noteDTO.nothi = new NoteNothiDTO();
                    }
                    noteDTO.nothi.note_no = Convert.ToString(noteDTO.note.note_no);
                    noteDTO.nothi.note_subject = noteDTO.note.note_subject;
                    noteDTO.nothi.note_id = Convert.ToString(noteDTO.note.nothi_note_id);

                    if (noteDTO.to.view_status == 1)
                    {
                        dakNothiteUposthaponNoteList.isEyeInvisible = true;
                    }

                    dakNothiteUposthaponNoteList.nothiDTO = noteDTO.nothi;
                    // dakNothiteUposthaponNoteList.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakNothiteUposthaponNoteList._nothiDTO); };

                    if (_nothiCurrentCategory._isOutbox)
                    {
                        dakNothiteUposthaponNoteList.isPreritoNote = true;
                        dakNothiteUposthaponNoteList.preritoNotePrapok = noteDTO.to.officer + "," + noteDTO.to.designation + "," + noteDTO.to.office_unit + "," + noteDTO.to.office;

                    }

                    //dakNothiteUposthaponNoteList.btnOptionClick += delegate (object sender1, EventArgs e1)
                    //{

                    //    btnOption_ButtonClick(sender1 as object, e1, noteDTO);
                    //};
                    noteListUserControls.Add(dakNothiteUposthaponNoteList);
                    UIDesignCommonMethod.AddRowinTable(nothiListFlowLayoutPanel, dakNothiteUposthaponNoteList);
                }
            }
        }
        /*
        private void btnOption_ButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {

            //if (!isActive)
            ////  uc.Location = System.Windows.Forms.Cursor.Position;
            //{
            if (uc.Visible != true)
            {
                bool remove = true;
                if (nothiListInboxNoteRecordsDTO.note.onucched_count > 0)
                { remove = false; }
                uc.ButtonVisibility(true, remove, true);
                //uc.Location = new Point(50, ((Point)sender).Y);
                uc.Location = new Point(50, this.Location.Y);
                // uc.Location = new Point(50,this.Location.Y);//((Point)sender).X, ((Point)sender).Y);
                uc.noteEditButtonClick += delegate (object s1, EventArgs e1) { uc_noteEditButtonClick(s1, e1, nothiListInboxNoteRecordsDTO); };
                uc.noteOnumodanButtonClick += delegate (object s2, EventArgs e2) { uc_noteOnumodanButtonClick(s2, e2, nothiListInboxNoteRecordsDTO); };
                uc.noteRemoveButtonClick += delegate (object s3, EventArgs e3) { uc_noteRemoveButtonClick(s3, e3, nothiListInboxNoteRecordsDTO); };

                this.Controls.Add(uc);
                uc.BringToFront();
                uc.Visible = true;
            }
            else
            {
                uc.Visible = false;
            }

            //    isActive = true;
            //}
            //else
            //    uc.Visible = false;
            //    isActive = false;
        }
        private void uc_noteOnumodanButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f.Name != "Note")
            //    { BeginInvoke((Action)(() => f.Hide())); }
            //}
            NoteView newNoteView = new NoteView();

            var nothiListRecord = MappingModels.MapModel<NothiNothiListInboxNoteRecordsDTO, NothiListRecordsDTO>(nothiListInboxNoteRecordsDTO.nothi);
            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiListRecord;

            // form.noteIdfromNothiInboxNoteShomuho = nothiListInboxNoteRecordsDTO.note.;

            form.nothiNo = nothiListInboxNoteRecordsDTO.nothi.nothi_no;
            form.nothiShakha = nothiListInboxNoteRecordsDTO.nothi.office;
            form.nothiSubject = nothiListInboxNoteRecordsDTO.nothi.subject;
            form.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            form.nothiLastDate = nothiListInboxNoteRecordsDTO.nothi.nothi_created_date;
            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;

            form.office = nothiListInboxNoteRecordsDTO.nothi.office;


            form.loadNothiInboxRecords(nothiListRecord);
            form.loadNoteView(newNoteView);
            form.noteTotal = ConversionMethod.EnglishNumberToBangla(nothiListInboxNoteRecordsDTO.note.finished_count.ToString());

            form.GetNothiInboxRecords(nothiListRecord, "Note", nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString());
            var notelist = MappingModels.MapModel<NoteNothiListInboxNoteRecordsDTO, NoteListDataRecordNoteDTO>(nothiListInboxNoteRecordsDTO.note);
            //form.loadNewNoteDataFromNote(nothiType);
            form.loadNoteList(notelist);
            CalPopUpWindow(form);
        }
        private void uc_noteRemoveButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {

            string message = "নোটটি মুছে ফেলুন";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            if (conditonBoxForm.Yes && nothiListInboxNoteRecordsDTO.note.onucched_count == 0)
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                string model = "NothiNotes";
                string noteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
                var noteDelete = _noteDelete.GetNoteDelteResponse(dakListUserParam, model, noteID);
                if (noteDelete.status == "success")
                {
                    SuccessMessage(noteDelete.status);
                    this.Hide();
                }

            }
            else
            {

            }
        }
        private void uc_noteEditButtonClick(object sender, EventArgs e, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            var noteCreatePopUpForm = FormFactory.Create<NoteCreatePopUpForm>();

            noteCreatePopUpForm.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            noteCreatePopUpForm.noteId = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
            noteCreatePopUpForm.nothiListInboxNoteRecordsDTO = nothiListInboxNoteRecordsDTO;
            noteCreatePopUpForm.SaveButtonClick += delegate (object senderSaveButton, EventArgs eventSaveButton) {
                SaveorUpdate();
            };


            CalPopUpWindow(noteCreatePopUpForm);

        }
      */
        private void btnNothiTalika_Click(object sender, EventArgs e)
        {
            detailsNothiSearcPanel.Visible = false;
            allReset();
            noteListButton.BackColor = Color.FromArgb(130, 80, 230);// LightSteelBlue;//130, 80, 230
            btnNothiTalika.BackColor = Color.FromArgb(102, 16, 242);
            if (agotoNothiSelected == 1)
            {
                _nothiCurrentCategory.isInbox = true;
                _nothiCurrentCategory.isInbox = true;
                btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiInbox.IconColor = Color.FromArgb(78, 165, 254);
                ResetAllMenuButtonSelection();
                SelectButton(btnNothiInbox as Button);
                nothiListFlowLayoutPanel.Visible = true;
                pnlNothiNoteTalika.Visible = true;
                newNothi.Visible = false;
                LoadNothiInbox();
            }
            if (preritoNothiSelected == 1)
            {

                _nothiCurrentCategory.isOutbox = true;

                btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
                btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiOutbox.IconColor = Color.FromArgb(78, 165, 254);
                ResetAllMenuButtonSelection();
                SelectButton(btnNothiOutbox as Button);
                nothiListFlowLayoutPanel.Visible = true;
                pnlNothiNoteTalika.Visible = true;
                newNothi.Visible = false;
                LoadNothiOutbox();
            }
            if (shokolNothiSelected == 1)
            {
                _nothiCurrentCategory.isAll = true;
                btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
                btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
                btnNothiAll.IconColor = Color.FromArgb(78, 165, 254);
                ResetAllMenuButtonSelection();
                SelectButton(btnNothiAll as Button);
                nothiListFlowLayoutPanel.Visible = true;
                pnlNothiNoteTalika.Visible = true;
                newNothi.Visible = false;
                LoadNothiAll();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void nothiModulePanel_MouseHover(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            nothiModulePanel.ForeColor = Color.Blue;
        }

        private void nothiModulePanel_MouseLeave(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.Transparent;
            nothiModulePanel.ForeColor = Color.Black;
        }

        private void Nothi_Load(object sender, EventArgs e)
        {

        }
        ModulePanelUserControl modulePanel = new ModulePanelUserControl();
        
        private void moduleButton_Click(object sender, EventArgs e)
        {
            if (modulePanel.Width == 334 && !modulePanel.Visible)
            {
                modulePanel.Visible = true;
                modulePanel.Location = new System.Drawing.Point(moduleButton.Location.X + dakModulePanel.Width + nothiModulePanel.Width, 40);
                Controls.Add(modulePanel);
                modulePanel.BringToFront();
                modulePanel.Width = 335;
                
            }
            else
            {
                modulePanel.Visible = false;
                modulePanel.Width = 334;
            }
        }

        private void btnNothiALLDecisionList_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                //WaitForm.Show(this);
                var nothiDecisionList = UserControlFactory.Create<NothiALLDecisionList>();

                nothiDecisionList.loadRow();
                var form = NothiNextStepControlToForm(nothiDecisionList);
                //WaitForm.Close();
                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }

        public Form NothiNextStepControlToForm(Control control)
        {
            Form form = new Form();
            form.TopMost = true;
            form.TopMost = false;
            form.Name = "ExtraPopUPWindow";
            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.AutoSize = true;
            form.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - control.Width, 0);
            control.Location = new System.Drawing.Point(0, 0);
            //form.Size = control.Size;
            form.Height = Screen.PrimaryScreen.WorkingArea.Height;
            form.Width = control.Width;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Height = form.Height;
            form.Controls.Add(control);
            return form;
        }
    }
}

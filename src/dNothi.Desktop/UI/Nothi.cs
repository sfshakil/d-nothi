using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity;
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

        public WaitFormFunc WaitForm;
        public Nothi(IUserService userService, INothiInboxServices nothiInbox, INothiNoteTalikaServices nothiNoteTalikaServices,
            INothiOutboxServices nothiOutbox, INothiAllServices nothiAll, INoteSaveService noteSave, INothiTypeSaveService nothiTypeSave,
            INothiCreateService nothiCreateServices, IRepository<NothiCreateItemAction> nothiCreateItemAction,
            IOnuchhedForwardService onuchhedForwardService, IOnucchedSave onucchedSave)
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

            InitializeComponent();
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
            nothiDhoronSrchUC.Visible = true;
            designationDetailsPanelNothi.Visible = false;
            _dakuserparam = _userService.GetLocalDakUserParam();
            _nothiCurrentCategory.isInbox = true;
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";
            agotoNothiSelected = 1;
            preritoNothiSelected = 0;
            shokolNothiSelected = 0;

            noteListButton.BackColor = Color.FromArgb(130, 80, 230); ;
            btnNothiTalika.BackColor = Color.FromArgb(102, 16, 242); //115, 55, 238
            loadNothiInboxTotal();
            WaitForm.Close();

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
            newNothi.loadNewNothiPage();
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(btnNewNothi as Button);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 50);
            Controls.Add(newNothi);
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;
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
        }
        public void allPreviousButtonVisibilityOff()
        {
            btnNothiInboxPrevious.Visible = false;
            btnNothiAllPrevious.Visible = false;
            btnNothiOutboxPrevious.Visible = false;
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

            foreach (NothiListRecordsDTO nothiListRecordsDTO in nothiLists)
            {
                nothiInboxRecord = nothiListRecordsDTO;
                var nothiInbox = UserControlFactory.Create<NothiInbox>();
                nothiInbox.nothi = nothiListRecordsDTO.nothi_no + " " + nothiListRecordsDTO.subject;
                nothiInbox.shakha = nothiListRecordsDTO.office_unit_name;
                nothiInbox.totalnothi = nothiListRecordsDTO.note_count.ToString();
                nothiInbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiListRecordsDTO.last_note_date;
                nothiInbox.nothiId = Convert.ToString(nothiListRecordsDTO.id);
                nothiInbox.NewNoteButtonClick += delegate (object sender, EventArgs e) { nothiListRecordsDTO.nothi_type = "Inbox"; NewNote_ButtonClick(sender, e, nothiListRecordsDTO); };
                nothiInbox.NoteDetailsButton += delegate (object sender, EventArgs e) { NoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiInbox._nothiListInboxNoteRecordsDTO); };
                nothiInbox.NoteAllButton += delegate (object sender, EventArgs e) { NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO); };
                nothiInbox.NothiOnumodonButtonClick += delegate (object sender, EventArgs e) { NothiOnumodon_ButtonClick(sender, e, nothiListRecordsDTO); };

                nothiInbox.LocalNoteDetailsButton += delegate (object sender, EventArgs e) {
                    NothiCreateItemAction nothiCreateItemAction = new NothiCreateItemAction();
                    nothiCreateItemAction.nothi_no = nothiListRecordsDTO.nothi_no;
                    nothiCreateItemAction.office_unit_name = nothiListRecordsDTO.office_unit_name;
                    nothiCreateItemAction.nothi_subject = nothiListRecordsDTO.subject;
                    nothiCreateItemAction.designation = nothiListRecordsDTO.office_designation_name;
                    nothiCreateItemAction.office_unit_name = nothiListRecordsDTO.office_unit_name;
                    LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction);
                };


                //delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };
                nothiInbox.nothiListRecordsDTO = nothiListRecordsDTO;

                nothiInboxDisplayed++;
                nothiInboxs.Add(nothiInbox);
            }
            nothiListFlowLayoutPanel.Controls.Clear();
            nothiListFlowLayoutPanel.AutoScroll = true;
            nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            nothiListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiInboxs.Count - 1; j++)
            {
                nothiListFlowLayoutPanel.Controls.Add(nothiInboxs[j]);
            }
        }
        private void NoteAllDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, NothiListAllRecordsDTO nothiAllListDTO, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {

            if (noteListDataRecordNoteDTO.is_editable == 0)
            {
                this.Hide();
            }
            else
            {

            }
            var form = FormFactory.Create<Note>();
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = noteListDataRecordNoteDTO.nothi_note_id.ToString();
            form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteAllDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiAllListDTO, nothiListInboxNoteRecordsDTO); };

            NothiListAllRecordsDTO nothiAllListRecords = nothiAllListDTO;
            form.nothiNo = nothiAllListRecords.nothi.nothi_no;
            form.nothiShakha = nothiAllListRecords.nothi.office_unit_name + " " + _dakuserparam.office_label;
            form.nothiSubject = nothiAllListRecords.nothi.subject;
            form.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            form.nothiLastDate = nothiAllListRecords.nothi.last_note_date;
            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;

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
            form.loadNothiInboxRecords(nothiListRecordsDTO);///////////////////////////////////////
            form.loadNoteView(noteView);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();


            form.ShowDialog();

        }
        private void NoteAll_ButtonClick(NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO)
        {
            NoteListDataRecordNoteDTO noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO();
            noteListDataRecordNoteDTO.is_editable = nothiListInboxNoteRecordsDTO.note.is_editable;
            noteListDataRecordNoteDTO.note_no = nothiListInboxNoteRecordsDTO.note.note_no;

            this.Hide();
            var form = FormFactory.Create<Note>();
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = noteListDataRecordNoteDTO.nothi_note_id.ToString();
            //form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiListInboxNoteRecordsDTO); };

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

            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
            //form.loadNoteData(notedata);
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.noteAllButtonClick(nothiListRecordsDTO);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();


            form.ShowDialog();
        }
        private void NoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            if (noteListDataRecordNoteDTO.is_editable == 0)
            {
                this.Hide();
            }
            else
            {

            }

            var form = FormFactory.Create<Note>();
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = noteListDataRecordNoteDTO.nothi_note_id.ToString();
            form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiListInboxNoteRecordsDTO); };

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

            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
            //form.loadNoteData(notedata);
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.loadNoteView(noteView);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();


            form.ShowDialog();
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
            hideform.Size = this.Size;
            hideform.Opacity = .4;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        private void LocalNoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, NothiCreateItemAction nothiCreateItemAction)
        {
            this.Hide();
            var form = FormFactory.Create<Note>();

            //form.ShowDialog();

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
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.loadNoteView(noteView);
            form.noteTotal = noteListDataRecordNoteDTO.note_no.ToString();
            form.setStatus("offline");

            form.ShowDialog();
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
            form.GetNothiInboxRecords(nothiListRecords);
            form.SuccessfullyOnumodonSaveButton += delegate (object saveOnumodonButtonSender, EventArgs saveOnumodonButtonEvent) { ClickNothiAll(); };

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
                    { f.Hide(); }
                    var form = FormFactory.Create<Nothi>();
                    form.LoadNothiInbox();
                    form.ShowDialog();
                }
            }
            else
            {
                if (noteSave.status == "success")
                {
                    NoteSaveDTO notedata = noteSave.data;
                    this.Hide();

                    var form = FormFactory.Create<Note>();
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


                    form.ShowDialog();

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
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();

        }

        private void btnNothiIcon_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void btnDak_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
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

            List<NothiOutbox> nothiOutboxs = new List<NothiOutbox>();
            int i = 0;
            foreach (NothiOutboxListRecordsDTO nothiOutboxListDTO in nothiOutboxLists)
            {
                //NothiOutbox nothiOutbox = new NothiOutbox();
                NothiOutbox nothiOutbox = UserControlFactory.Create<NothiOutbox>();
                nothiOutbox.nothi = nothiOutboxListDTO.nothi.nothi_no + " " + nothiOutboxListDTO.nothi.subject;
                nothiOutbox.shakha = nothiOutboxListDTO.nothi.office_unit_name;
                nothiOutbox.prapok = nothiOutboxListDTO.to.officer + " " + nothiOutboxListDTO.to.designation + "," + nothiOutboxListDTO.to.office_unit + "," + nothiOutboxListDTO.to.office;
                if (nothiOutboxListDTO.desk != null)
                    nothiOutbox.bortomanDesk = nothiOutboxListDTO.desk.officer + " " + nothiOutboxListDTO.desk.designation + "," + nothiOutboxListDTO.desk.office_unit + "," + nothiOutboxListDTO.desk.office;
                nothiOutbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiOutboxListDTO.nothi.last_note_date;
                nothiOutbox.nothiId = nothiOutboxListDTO.nothi.id;

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
                    NoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiOutbox._nothiListInboxNoteRecordsDTO);
                };

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
                    NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO);
                };


                nothiOutbox.LocalNoteDetailsButton += delegate (object sender, EventArgs e) {
                    NothiCreateItemAction nothiCreateItemAction = new NothiCreateItemAction();
                    nothiCreateItemAction.nothi_no = nothiOutboxListDTO.nothi.nothi_no;
                    nothiCreateItemAction.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    nothiCreateItemAction.nothi_subject = nothiOutboxListDTO.nothi.subject;
                    nothiCreateItemAction.designation = nothiOutboxListDTO.nothi.office_designation_name;
                    nothiCreateItemAction.office_unit_name = nothiOutboxListDTO.nothi.office_unit_name;
                    LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction);
                };

                nothiOutbox.nothiOutboxListRecordsDTO = nothiOutboxListDTO;
                i = i + 1;
                nothiOutboxs.Add(nothiOutbox);

            }
            nothiListFlowLayoutPanel.Controls.Clear();
            nothiListFlowLayoutPanel.AutoScroll = true;
            nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            nothiListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiOutboxs.Count - 1; j++)
            {
                nothiListFlowLayoutPanel.Controls.Add(nothiOutboxs[j]);
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
            form.GetNothiInboxRecords(nothiOutboxListRecords);
            form.SuccessfullyOnumodonSaveButton += delegate (object saveOnumodonButtonSender, EventArgs saveOnumodonButtonEvent) { ClickNothiAll(); };

            CalPopUpWindow(form);

        }
        private void NothiAllOnumodon_ButtonClick(object sender, EventArgs e, NothiListAllRecordsDTO nothiAllListDTO)
        {
            NothiListRecordsDTO nothiAllListRecords = new NothiListRecordsDTO();
            NothiAllDTO nothi = nothiAllListDTO.nothi;

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
            form.GetNothiInboxRecords(nothiAllListRecords);

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
                List<NothiAll> nothiAlls = new List<NothiAll>();
                nothiCreateItemActions = _nothiCreateItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                if (nothiCreateItemActions != null && nothiCreateItemActions.Count > 0)
                {
                    greaterNothiId = greaterNothiId + nothiCreateItemActions.Count;
                    foreach (NothiCreateItemAction nothiCreateItemAction in nothiCreateItemActions)
                    {
                        greaterNothiId++;
                        NothiAll nothiAll = UserControlFactory.Create<NothiAll>();
                        nothiAll.nothi = nothiCreateItemAction.nothi_no + " " + nothiCreateItemAction.nothi_subject;
                        nothiAll.shakha = "নথির শাখা: " + nothiCreateItemAction.nothishkha;
                        nothiAll.nothiId = Convert.ToString(greaterNothiId);
                        
                        nothiCreateItemAction.nothi_id = greaterNothiId;
                        _nothiCreateItemAction.Update(nothiCreateItemAction);
                        
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
                            LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction);
                        };

                        nothiAll.flag = 2;
                        nothiAlls.Add(nothiAll);
                    }
                    
                }
                nothiListFlowLayoutPanel.Controls.Clear();
                nothiListFlowLayoutPanel.AutoScroll = true;
                nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                nothiListFlowLayoutPanel.WrapContents = false;

                for (int j = 0; j <= nothiAlls.Count - 1; j++)
                {
                    nothiListFlowLayoutPanel.Controls.Add(nothiAlls[j]);
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
                    btnNothiAllNext.Visible = true;

                    pnlNoData.Visible = false;
                    //nothiListFlowLayoutPanel.Controls.Clear();
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(totalNothiAllNo.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiAllinPanel(nothiAll.data.records);
                }
                else
                {
                    allNextButtonVisibilityOff();
                    pnlNoData.Visible = true;
                    //nothiListFlowLayoutPanel.Controls.Clear();
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

            foreach (NothiListAllRecordsDTO nothiAllListDTO in nothiAllLists)
            {
                NothiAll nothiAll = UserControlFactory.Create<NothiAll>();
                nothiAll.NothiAllOnumodonButtonClick += delegate (object sender, EventArgs e) { NothiAllOnumodon_ButtonClick(sender, e, nothiAllListDTO); };
                nothiAll.NoteDetailsButton += delegate (object sender, EventArgs e) { NoteAllDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiAllListDTO, nothiAll._nothiListInboxNoteRecordsDTO); };
                
                nothiAll.LocalNoteDetailsButton += delegate (object sender, EventArgs e) {
                    NothiCreateItemAction nothiCreateItemAction = new NothiCreateItemAction();
                    nothiCreateItemAction.nothi_no = nothiAllListDTO.nothi.nothi_no;
                    nothiCreateItemAction.office_unit_name= nothiAllListDTO.nothi.office_unit_name;
                    nothiCreateItemAction.nothi_subject= nothiAllListDTO.nothi.subject;
                    nothiCreateItemAction.designation = nothiAllListDTO.nothi.office_designation_name;
                    nothiCreateItemAction.office_unit_name = nothiAllListDTO.nothi.office_unit_name;
                    LocalNoteDetails_ButtonClick(sender as NoteListDataRecordNoteDTO, e, nothiCreateItemAction);
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
                    NoteAll_ButtonClick(sender as NothiListInboxNoteRecordsDTO, e, nothiListRecordsDTO);
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

                if (nothiAllListDTO.desk != null && nothiAllListDTO.status != null)
                {

                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.desk = nothiAllListDTO.desk.note_count.ToString();
                    nothiAll.noteTotal = nothiAllListDTO.status.total;
                    nothiAll.permitted = nothiAllListDTO.status.permitted;
                    nothiAll.onishponno = nothiAllListDTO.status.onishponno;
                    nothiAll.nishponno = nothiAllListDTO.status.nishponno;
                    nothiAll.archived = nothiAllListDTO.status.archived;
                    nothiAll.noteLastDate = "নোটের সর্বশেষ তারিখঃ " + nothiAllListDTO.nothi.last_note_date;
                    nothiAll.nothiId = Convert.ToString(nothiAllListDTO.nothi.id);

                }
                else
                {
                    //NothiAll nothiAll = new NothiAll();
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.nothiId = Convert.ToString(nothiAllListDTO.nothi.id);
                    nothiAll.flag = 1;
                }
                nothiAlls.Add(nothiAll);
            }
            if (InternetConnection.Check())
            { 
                nothiListFlowLayoutPanel.Controls.Clear(); 
            }
            nothiListFlowLayoutPanel.AutoScroll = true;
            nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            nothiListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiAlls.Count - 1; j++)
            {
                nothiListFlowLayoutPanel.Controls.Add(nothiAlls[j]);
            }
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

        }
        private void SelectButton(Button button)
        {
            button.BackColor = Color.FromArgb(243, 246, 249);
            button.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
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
        private void detailPanelDropDownButton_Click_1(object sender, EventArgs e)
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void nothiModuleNameLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
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
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void dakModuleNameLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void moduleDakCountLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
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
        private void btnNothiInbox_Click_1(object sender, EventArgs e)
        {
            WaitForm.Show(this);
            agotoNothiSelected = 1;
            preritoNothiSelected = 0;
            shokolNothiSelected = 0;
            _nothiCurrentCategory.isInbox = true;
            _nothiCurrentCategory.isInbox = true;
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiInbox.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
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
            agotoNothiSelected = 0;
            preritoNothiSelected = 1;
            shokolNothiSelected = 0;
            _nothiCurrentCategory.isOutbox = true;

            allPreviousButtonVisibilityOff();
            allNextButtonVisibilityOff();

            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
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
            agotoNothiSelected = 0;
            preritoNothiSelected = 0;
            shokolNothiSelected = 1;
            _nothiCurrentCategory.isAll = true;

            allPreviousButtonVisibilityOff();
            allNextButtonVisibilityOff();

            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
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

        private void btnNewNothi_Click(object sender, EventArgs e)
        {
            newNothi.loadNewNothiPage();
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 50);
            Controls.Add(newNothi);
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;
        }
        public void ForceLoadNewNothi()
        {
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            btnNewNothi.BackColor = Color.FromArgb(243, 246, 249);
            btnNewNothi.ForeColor = Color.FromArgb(78, 165, 254);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 50);
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
                designationDetailsPanelNothi.Visible = true;
                //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 50);
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

            nothiBackGroundWorker.RunWorkerAsync();
        }

        private void userPictureBox_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
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

            LoadNote(noteList);
            WaitForm.Close();
        }

        private void LoadNote(NothiNoteListResponse noteList)
        {

            if (noteList.data != null)
            {
                List<NothiNoteTalikaAll> noteListUserControls = new List<NothiNoteTalikaAll>();
                foreach (NothiNoteListRecordDTO noteDTO in noteList.data.records)
                {
                    NothiNoteTalikaAll dakNothiteUposthaponNoteList = new NothiNoteTalikaAll();

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


                    noteListUserControls.Add(dakNothiteUposthaponNoteList);
                }
                nothiListFlowLayoutPanel.Controls.Clear();
                nothiListFlowLayoutPanel.AutoScroll = true;
                nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                nothiListFlowLayoutPanel.WrapContents = false;

                for (int j = 0; j <= noteListUserControls.Count - 1; j++)
                {
                    nothiListFlowLayoutPanel.Controls.Add(noteListUserControls[j]);
                }
            }
        }

        private void btnNothiTalika_Click(object sender, EventArgs e)
        {
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

        private void moduleButton_Click(object sender, EventArgs e)
        {
        }
    }
}

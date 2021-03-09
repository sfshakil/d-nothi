using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
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
        NothiCategoryList _nothiCurrentCategory = new NothiCategoryList();
        INothiNoteTalikaServices _nothiNoteTalikaServices { get; set; }
        INothiAllServices _nothiAll { get; set; }

        public Nothi(IUserService userService, INothiInboxServices nothiInbox, INothiNoteTalikaServices nothiNoteTalikaServices, INothiOutboxServices nothiOutbox, INothiAllServices nothiAll, INoteSaveService noteSave)
        {
            _nothiNoteTalikaServices= nothiNoteTalikaServices;
            _userService = userService;
            _nothiInbox = nothiInbox;
            _nothiOutbox = nothiOutbox;
            _nothiAll = nothiAll;
            _noteSave = noteSave;

            InitializeComponent();
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
            noteListButton.BackColor = Color.LightSteelBlue;
            btnNothiTalika.BackColor = Color.MediumSlateBlue;
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

        private async void LoadNothiInbox()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiInbox = await Task.Run(() => _nothiInbox.GetNothiInbox(dakListUserParam));
            if (nothiInbox.status == "success")
            {
                _nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                if (nothiInbox.data.records.Count > 0)
                {
                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiInbox.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiInboxinPanel(nothiInbox.data.records);

                }
                else
                {
                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }

        }
        NothiListRecordsDTO nothiInboxRecord;
        private void LoadNothiInboxinPanel(List<NothiListRecordsDTO> nothiLists)
        {
            List<NothiInbox> nothiInboxs = new List<NothiInbox>();
            int i = 0;
            foreach (NothiListRecordsDTO nothiListRecordsDTO in nothiLists)
            {
                nothiInboxRecord = nothiListRecordsDTO;
                var nothiInbox = UserControlFactory.Create<NothiInbox>();
                nothiInbox.nothi = nothiListRecordsDTO.nothi_no + " " + nothiListRecordsDTO.subject;
                nothiInbox.shakha = nothiListRecordsDTO.office_unit_name;
                nothiInbox.totalnothi = nothiListRecordsDTO.note_count.ToString();
                nothiInbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiListRecordsDTO.last_note_date;
                nothiInbox.nothiId = Convert.ToString(nothiListRecordsDTO.id);
                nothiInbox.NewNoteButtonClick += delegate (object sender, EventArgs e) { NewNote_ButtonClick(sender, e, nothiListRecordsDTO); };
                nothiInbox.NoteDetailsButton += delegate (object sender, EventArgs e) { NoteDetails_ButtonClick(sender, e, nothiListRecordsDTO, nothiInbox._nothiListInboxNoteRecordsDTO); };
                nothiInbox.NothiOnumodonButtonClick += delegate (object sender, EventArgs e) { NothiOnumodon_ButtonClick(sender, e, nothiListRecordsDTO); };
                //delegate (object sender, EventArgs e) { UserControl_ButtonClick(sender, e, dakInboxUserControl.dakid, dakListInboxRecordsDTO.dak_user.dak_type, dakListInboxRecordsDTO.dak_user.dak_subject, dakListInboxRecordsDTO.dak_user.is_copied_dak); };

                i = i + 1;
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

        private void NoteDetails_ButtonClick(object sender, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
           
            this.Hide();
            var form = FormFactory.Create<Note>();
            _dakuserparam = _userService.GetLocalDakUserParam();




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
            //noteView.totalNothi = totalnothi.ToString();
            noteView.noteSubject = nothiListInboxNoteRecordsDTO.note.note_subject;
            noteView.nothiLastDate = nothiListRecordsDTO.last_note_date;
            noteView.officerInfo = _dakuserparam.officer + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
            noteView.checkBox = "1";
            noteView.nothiNoteID = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
           
            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
          //  form.loadNoteData(notedata);
            form.loadNothiInboxRecords(nothiListRecordsDTO);
            form.noteTotal = form.loadNoteView(noteView).ToString();


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
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
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
            form.GetNothiInboxRecords(nothiListRecords);
            form.ShowDialog();

        }
        private void SaveNewNote_ButtonClick(object sender, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO)
        {
            string noteSubject = sender.ToString();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var noteSave = _noteSave.GetNoteSave(dakListUserParam, nothiListRecordsDTO, noteSubject);

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
                //var totalnothi = nothiListRecordsDTO.note_count; //nothiListInboxNoteRecordsDTO.note.note_no;
                //totalnothi.ToString();
                form.office = "( " + nothiListRecords.office_name + " " + nothiListRecordsDTO.last_note_date + ")";

                NoteView noteView = new NoteView();
                //noteView.totalNothi = totalnothi.ToString();
                noteView.noteSubject = sender.ToString();
                noteView.nothiLastDate = nothiListRecordsDTO.last_note_date;
                noteView.officerInfo = _dakuserparam.officer + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                noteView.checkBox = "1";
                noteView.nothiNoteID = notedata.note_id;

                //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
                form.loadNoteData(notedata);
                form.loadNothiInboxRecords(nothiListRecordsDTO);
                form.noteTotal = form.loadNoteView(noteView).ToString();
                

                form.ShowDialog();

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

        private void LoadNothiOutbox()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiOutbox = _nothiOutbox.GetNothiOutbox(dakListUserParam);

            if (nothiOutbox.status == "success")
            {
                if (nothiOutbox.data.records.Count > 0)
                {
                    pnlNoData.Visible = false;
                    LoadNothiOutboxinPanel(nothiOutbox.data.records);
                }
                else
                {
                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }

            }
        }
        private void LoadNothiOutboxinPanel(List<NothiOutboxListRecordsDTO> nothiOutboxLists)
        {

            List<NothiOutbox> nothiOutboxs = new List<NothiOutbox>();
            int i = 0;
            foreach (NothiOutboxListRecordsDTO nothiOutboxListDTO in nothiOutboxLists)
            {
                NothiOutbox nothiOutbox = new NothiOutbox();
                nothiOutbox.nothi = nothiOutboxListDTO.nothi.nothi_no + " " + nothiOutboxListDTO.nothi.subject;
                nothiOutbox.shakha = nothiOutboxListDTO.nothi.office_unit_name;
                nothiOutbox.prapok = nothiOutboxListDTO.to.officer + " "+ nothiOutboxListDTO.to.designation +","+ nothiOutboxListDTO.to.office_unit +","+ nothiOutboxListDTO.to.office;
                if(nothiOutboxListDTO.desk !=null)
                nothiOutbox.bortomanDesk = nothiOutboxListDTO.desk.officer+" "+ nothiOutboxListDTO.desk.designation +","+ nothiOutboxListDTO.desk.office_unit +","+ nothiOutboxListDTO.desk.office;
                nothiOutbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiOutboxListDTO.nothi.last_note_date;
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

        private void LoadNothiAll()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 30;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiAll = _nothiAll.GetNothiAll(dakListUserParam);

            if (nothiAll.status == "success")
            {
                if (nothiAll.data.records.Count > 0)
                {
                    pnlNoData.Visible = false;
                    LoadNothiAllinPanel(nothiAll.data.records);
                }
                else
                {
                    pnlNoData.Visible = true;
                    nothiListFlowLayoutPanel.Controls.Clear();
                }
            }
        }
        private void LoadNothiAllinPanel(List<NothiListAllRecordsDTO> nothiAllLists)
        {

            List<NothiAll> nothiAlls = new List<NothiAll>();
            int i = 0;
            foreach (NothiListAllRecordsDTO nothiAllListDTO in nothiAllLists)
            {
                NothiAll nothiAll = new NothiAll();
                if (nothiAllListDTO.desk != null && nothiAllListDTO.status != null)
                {
                    
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.desk = "ডেস্ক: " + nothiAllListDTO.desk.note_count.ToString();
                    nothiAll.noteTotal = nothiAllListDTO.status.total;
                    nothiAll.permitted = nothiAllListDTO.status.permitted;
                    nothiAll.onishponno = nothiAllListDTO.status.onishponno;
                    nothiAll.nishponno = nothiAllListDTO.status.nishponno;
                    nothiAll.archived = nothiAllListDTO.status.archived;
                    nothiAll.noteLastDate = "নোটের সর্বশেষ তারিখঃ " + nothiAllListDTO.nothi.last_note_date;
                    i = i + 1;
                    
                }
                else
                {
                    //NothiAll nothiAll = new NothiAll();
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.flag = 1;
                }
                nothiAlls.Add(nothiAll);
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

        }

        private void nothiModulePanel_Paint(object sender, PaintEventArgs e)
        {

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
            LoadNothiInbox();
        }

        private void btnNothiOutbox_Click(object sender, EventArgs e)
        {
            agotoNothiSelected = 0;
            preritoNothiSelected = 1;
            shokolNothiSelected = 0;
            _nothiCurrentCategory.isOutbox = true;
           
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
        }
        public void ForceLoadNothiALL()
        {
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
        private void btnNothiAll_Click(object sender, EventArgs e)
        {
            agotoNothiSelected = 0;
            preritoNothiSelected = 0;
            shokolNothiSelected = 1;
            _nothiCurrentCategory.isAll = true;
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
            //_dakuserparam = _userService.GetLocalDakUserParam();
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Visible = true;
            //    designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
        }
        

        private void userPictureBox_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Visible = true;
               // designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new Point(227 + 689, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
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
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
        }

        private void profileShowArrowButton_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Visible = true;
          //      designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
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
            btnNothiTalika.BackColor = Color.LightSteelBlue; 
            noteListButton.BackColor = Color.MediumSlateBlue;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            NothiNoteListResponse noteList = new NothiNoteListResponse();

            if (_nothiCurrentCategory._isAll)
            {
                noteList = _nothiNoteTalikaServices.GetNothiNoteListAll(dakUserParam, -1);

            }
            else if(_nothiCurrentCategory._isInbox)
            {
               noteList = _nothiNoteTalikaServices.GetNothiNoteListInbox(dakUserParam, -1);

            }
            else if (_nothiCurrentCategory._isOutbox)
            {
               
                noteList = _nothiNoteTalikaServices.GetNothiNoteListSent(dakUserParam, -1);

            }

            LoadNote(noteList);

        }

        private void LoadNote(NothiNoteListResponse noteList)
        {

            if(noteList.data!=null)
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

                    if (noteDTO.to.view_status== 1)
                    {
                        dakNothiteUposthaponNoteList.isEyeInvisible = true;
                    }

                    dakNothiteUposthaponNoteList.nothiDTO = noteDTO.nothi;
                   // dakNothiteUposthaponNoteList.NothiteUposthapitoButtonClick += delegate (object sender, EventArgs e) { NothiteUposthapito_ButtonClick(sender, e, dakNothiteUposthaponNoteList._nothiDTO); };

                    if(_nothiCurrentCategory._isOutbox)
                    {
                        dakNothiteUposthaponNoteList.isPreritoNote = true;
                        dakNothiteUposthaponNoteList.preritoNotePrapok = noteDTO.to.officer+","+noteDTO.to.designation+","+ noteDTO.to.office_unit + ","+ noteDTO.to.office;
                       
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
            noteListButton.BackColor = Color.LightSteelBlue;
            btnNothiTalika.BackColor = Color.MediumSlateBlue;
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

    }
}

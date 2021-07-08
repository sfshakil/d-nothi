using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.DakServices;
using dNothi.Services.KhasraService;
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
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.JsonParser;
using HtmlAgilityPack;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity;
using dNothi.Services.KasaraPatraDashBoardService.Models;

namespace dNothi.Desktop.UI
{
    public partial class Khosra : Form
    {
        IUserService _userService { get; set; }
        INothiInboxNoteServices _nothiInboxNote { get; set; }
        IDesignationSealService _designationSealService { get; set; }
        IKhosraSaveService _khosraSaveService { get; set; }
        IDakForwardService _dakForwardService { get; set; }
        IKhasraTemplateService _khasraTemplateService { get; set; }

        public PrapokDTO _OnumodonOffice;
        public NoteListDataRecordNoteDTO _noteListDataRecordNoteDTO { get; set; }
        public NothiListRecordsDTO _nothiListRecordsDTO { get; set; }
        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO { get; set; }

        public KhasraPotroTemplateResponse khasraPotroTemplateResponse { get; set; }
        public WaitFormFunc WaitForm;
        private DakUserParam _dakuserparam { get; set; }


        private void commonKhosraRowUserControl_NoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, NothiListRecordsDTO nothiListRecordsDTO, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
         

            var form = FormFactory.Create<Note>();
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = noteListDataRecordNoteDTO.nothi_note_id.ToString();
            form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { commonKhosraRowUserControl_NoteDetails_ButtonClick(noteListDataRecordNoteDTO,  nothiListRecordsDTO, nothiListInboxNoteRecordsDTO); };
            form.IskasaraDashBoard = true;
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

            //this.Parent.Hide();
            this.Hide();

            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, noteListDataRecordNoteDTO.is_editable); };

            

        }


        public Khosra(INothiInboxNoteServices nothiInboxNote,IDesignationSealService designationSealService, IKhosraSaveService khosraSaveService,IUserService userService, IKhasraTemplateService khasraTemplateService, IDakForwardService dakForwardService)
        {
            _nothiInboxNote = nothiInboxNote;
            _khosraSaveService = khosraSaveService;
            _designationSealService = designationSealService;
            _userService = userService;
            _dakForwardService = dakForwardService;
            _khasraTemplateService = khasraTemplateService;
            WaitForm = new WaitFormFunc();
            InitializeComponent();
            timePicker.CustomFormat = "HH:mm";

            //WaitForm.Show(this);

            //CreateEditor();

            // WaitForm.Close();
        }
        public DesignationSealListResponse _designationSealListResponse { get; set; }
        private void CreateEditor()
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce\js\tinymce\tinymce.min.js")))
            {
                tinyMceEditor.Load(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce/tinymce.htm").Replace('\\', '/'));
               
           
            }
            else
            {
                MessageBox.Show("Could not find the tinyMCE script directory. Please ensure the directory is in the same location as tinymce.htm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };

        }
        private string _nothiShakha;
        private string _nothiNo;
        private string _nothiSubject;


        [Category("Custom Props")]
        public string nothiShakha
        {
            get { return _nothiShakha; }
            set { _nothiShakha = value; lbNoteShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiNo
        {
            get { return _nothiNo; }
            set { _nothiNo = value; lbNothiNo.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiSubject
        {
            get { return _nothiSubject; }
            set { _nothiSubject = value; lbSubject.Text = value; }
        }

        public string kasaradashboardHtmlContent;
        private List<PrapokDTO> _onumodanKariOfficerDesignations { get; set; }
        public List<PrapokDTO> onumodanKariOfficerDesignations
        {
            get => _onumodanKariOfficerDesignations;
            set { _onumodanKariOfficerDesignations = value;onumodonOfficer = value; DraftOfficerinOnumodonKariOfficerList(onumodonkariOfficerSelectButton, value.Select(x=>x.designation_id).ToList(), onumodonkariListPanel, onumodonkariEmptyPanel, onumodonkariListFlowLayoutPanel); }
       
        }
        
        private List<PrapokDTO> _prapakOfficerDesignations { get; set; }
        public List<PrapokDTO> prapakOfficerDesignations
        {
            get => _prapakOfficerDesignations;
            set {
                _prapakOfficerDesignations = value;prapokOfficers = value;
                DraftOfficerinOnumodonKariOfficerList(prapokListShowButton, value.Select(x => x.designation_id).ToList(), prapokListPanel, prapokEmptyPanel, prapokListFlowLayoutPanel); }
        }
        private List<PrapokDTO> _prerokOfficerDesignations { get; set; }
        public List<PrapokDTO> prerokOfficerDesignations
        {
            get => _prerokOfficerDesignations;
            set { _prerokOfficerDesignations = value;senderOfficer = value; DraftOfficerinOnumodonKariOfficerList(prerokListShowButton, value.Select(x => x.designation_id).ToList(), prerokListPanel, prerokEmptyPanel, prerokListFlowLayoutPanel); }
        }
        private List<PrapokDTO> _attensionOfficerDesignations { get; set; }
        public List<PrapokDTO> attensionOfficerDesignations
        {
            get => _attensionOfficerDesignations;
            set { _attensionOfficerDesignations = value;attentionOfficers = value; DraftOfficerinOnumodonKariOfficerList(attentionListShowButton, value.Select(x => x.designation_id).ToList(), attentionListPanel, attentionEmptyPanel, attentionListFlowLayoutPanel); }
            }
        private List<PrapokDTO> _onulipiOfficerDesignations { get; set; }
        public List<PrapokDTO> onulipiOfficerDesignations
        {
            get => _onulipiOfficerDesignations;
            set { _onulipiOfficerDesignations = value;onumodonOfficer = value; DraftOfficerinOnumodonKariOfficerList(onulipiListShowButton, value.Select(x => x.designation_id).ToList(), onulipiListPanel, onulipiEmptyPanel, onulipiListFlowLayoutPanel); }
        }
        private List<DakAttachmentDTO> _draftAttachmentDTOs { get; set; }
        public List<DakAttachmentDTO> draftAttachmentDTOs
        {
            get { return _draftAttachmentDTOs; }
            set
            {
                _draftAttachmentDTOs = value;
               
            }
        }


        private void Khosra_Shown(object sender, EventArgs e)
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = dakUserParam.officer_name + "(" + dakUserParam.designation_label + "," + dakUserParam.unit_label + ")";

            try
            {
                EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
                moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());

            }
            catch (Exception Ex)
            {

            }





            List<OfficeInfoDTO> officeInfoDTO = _userService.GetAllLocalOfficeInfo();


            foreach (OfficeInfoDTO officeInfoDTO1 in officeInfoDTO)
            {
                dakUserParam.designation_id = officeInfoDTO1.office_unit_organogram_id;
                dakUserParam.office_id = officeInfoDTO1.office_id;
                try
                {
                    EmployeDakNothiCountResponse singleOfficeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                    var singleOfficeDakNothiCount = singleOfficeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                    officeInfoDTO1.dakCount = singleOfficeDakNothiCount.Value.dak;
                    officeInfoDTO1.nothiCount = singleOfficeDakNothiCount.Value.own_office_nothi;
                }
                catch
                {

                }
            }



            designationDetailsPanel.officeInfos = officeInfoDTO;





            designationDetailsPanel.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanel._designationId); };

        }

        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = dakUserParam.officer_name + "(" + dakUserParam.designation_label + "," + dakUserParam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());


           
        }
        public string _sub;
        private void Template_CLick_New(KhasraPotroTemplateDataDTO khasraPotroTemplateData)
        {

            protibedonOnumodonButton(khasraPotroTemplateData);

            if (_khasraPotroTemplateData.template_id != khasraPotroTemplateData.template_id)
            {
                _khasraPotroTemplateData = khasraPotroTemplateData;
                LoadNewTemplate();
            }

            SetRecipientType(khasraPotroTemplateData.recipient_type);



            tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { khasraPotroTemplateData.html_content });
            tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
          
            LoadTime(DateTime.Now);
            LoadDate(DateTime.Now);
        }
        private void Template_CLick(KhasraPotroTemplateDataDTO khasraPotroTemplateData)
        {
            protibedonOnumodonButton(khasraPotroTemplateData);


            if (_khasraPotroTemplateData.template_id != khasraPotroTemplateData.template_id)
            {
                _khasraPotroTemplateData = khasraPotroTemplateData;
                LoadNewTemplate();
            }

            SetRecipientType(khasraPotroTemplateData.recipient_type);

          

            tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { khasraPotroTemplateData.html_content });
            tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
            LoadTime(DateTime.Now);
            //LoadDate(DateTime.Now);
        }

        private void protibedonOnumodonButton(KhasraPotroTemplateDataDTO khasraPotroTemplateData)
        {
            if (khasraPotroTemplateData.template_id == 30)
            {
                protibedonOnumedonButton.Visible = true;
            }
            else
            {
                protibedonOnumedonButton.Visible = false;
            }
        }

        private void SetRecipientType(string recipient_type)
        {
            //approver, receiver, sender, attention, onulipi
            if (recipient_type.Contains("approver"))
            {
                onumodonkariSelectButtonPanel.Visible = true;
            }
            else
            {
                onumodonkariSelectButtonPanel.Visible = false;
                onumodonkariListPanel.Visible = false;
            }

            if (recipient_type.Contains("receiver"))
            {
                prapokSelectButtonPanel.Visible = true;
            }
            else
            {
                prapokSelectButtonPanel.Visible = false;
                prapokListPanel.Visible = false;
            }


            if (recipient_type.Contains("sender"))
            {
                prerokSelectButtonPanel.Visible = true;
            }
            else
            {
                prerokSelectButtonPanel.Visible = false;
                prerokListPanel.Visible = false;
            }

            if (recipient_type.Contains("attention"))
            {
                attentionSelectButtonPanel.Visible = true;
            }
            else
            {
                attentionSelectButtonPanel.Visible = false;
                attentionListPanel.Visible = false;
            }

            if (recipient_type.Contains("onulipi"))
            {
                onulipiSelectButtonPanel.Visible = true;
            }
            else
            {
                onulipiSelectButtonPanel.Visible = false;
                onulipiListPanel.Visible = false;
            }

        }

        private async void SetCurrentInputValue(string currentString)
        {
            
            JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");
            string sub = GetPotroSubjectFromHtmlString(response.Result.ToString());
           
            string newHtmlString= SetPotroElementToHtmlString(currentString, sub);

            tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { newHtmlString });
            tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
        }

       
        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void LoadDakPriority()
        {
            DakPriorityList dakPriorityList = new DakPriorityList(true);
            dakPriorityComboBox.DataSource = null;
           
            dakPriorityComboBox.DataSource = dakPriorityList._dakPriority.OrderBy(a => a._id).ToList();
            dakPriorityComboBox.DisplayMember = "_typeName";
            dakPriorityComboBox.ValueMember = "_id";
        }

        private void LoadDakSecurity()
        {
            DakSecurityList dakSecurityList = new DakSecurityList(true);
          
            dakSecrurityComboBox.DataSource = null;

            dakSecrurityComboBox.DataSource  = dakSecurityList._dakSecurities.OrderBy(a => a._id).ToList();
            dakSecrurityComboBox.DisplayMember = "_typeName";
           
            dakSecrurityComboBox.ValueMember = "_id";
          

        }

        private void onumodonkariListShowButton_Click(object sender, EventArgs e)
        {
            if (onumodonkariListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                onumodonkariListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (onumodonkariListFlowLayoutPanel.Controls.Count == 0)
                {
                    onumodonkariEmptyPanel.Visible = true;
                }
                onumodonkariListPanel.Visible = true;
            }


            else
            {
                onumodonkariListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                onumodonkariListPanel.Visible = false;
            }
        }

        private void prapokListShowButton_Click(object sender, EventArgs e)
        {
            if (prapokListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                prapokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (prapokListFlowLayoutPanel.Controls.Count == 0)
                {
                    prapokEmptyPanel.Visible = true;
                }
                prapokListPanel.Visible = true;
            }
            else
            {
                prapokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                prapokListPanel.Visible = false;
            }
        }

        private void prerokListShowButton_Click(object sender, EventArgs e)
        {
            if (prerokListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                prerokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (prerokListFlowLayoutPanel.Controls.Count == 0)
                {
                    prerokEmptyPanel.Visible = true;
                }
                prerokListPanel.Visible = true;
            }
            else
            {
                prerokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                prerokListPanel.Visible = false;
            }
        }

        private void attentionListShowButton_Click(object sender, EventArgs e)
        {
            if (attentionListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                attentionListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (attentionListFlowLayoutPanel.Controls.Count == 0)
                {
                    attentionEmptyPanel.Visible = true;
                }
                attentionListPanel.Visible = true;
            }
            else
            {
                attentionListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                attentionListPanel.Visible = false;
            }
        }

        private void onulipiListShowButton_Click(object sender, EventArgs e)
        {
            if (onulipiListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                onulipiListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (onulipiListFlowLayoutPanel.Controls.Count == 0)
                {
                    onulipiEmptyPanel.Visible = true;
                }
                onulipiListPanel.Visible = true;
            }
            else
            {
                onulipiListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                onulipiListPanel.Visible = false;
            }
        }

        private void attentionSelectButtonPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        
       



       
        private void onumodonkariOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(onumodonkariOfficerSelectButton,onumodonkariListPanel, onumodonkariEmptyPanel,onumodonkariListFlowLayoutPanel);
        }

        private void SelectOfficer(FontAwesome.Sharp.IconButton officerSelectButton, Panel officerListPanel, Panel officerEmptyPanel, TableLayoutPanel officerListFlowLayoutPanel)
        {
            SelectOfficerForm selectOfficerForm = new SelectOfficerForm();
            
            if(officerSelectButton == onumodonkariOfficerSelectButton || officerSelectButton== prerokListShowButton)
            {
                selectOfficerForm._isOneOfficerAllowed = true;
            }
               
            selectOfficerForm.designationSealListResponse = _designationSealListResponse;

            selectOfficerForm.SaveButtonClick += delegate (object se, EventArgs ev) { SaveOfficerinOnumodonKariOfficerList(officerSelectButton,selectOfficerForm._selectedOfficerDesignations, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel); };

            UIDesignCommonMethod.CalPopUpWindow(selectOfficerForm,this);
        }

        private void SaveOfficerinOnumodonKariOfficerList(FontAwesome.Sharp.IconButton officerSelectButton, List<int> selectedOfficerDesignations, Panel officerListPanel, Panel officerEmptyPanel, TableLayoutPanel officerListFlowLayoutPanel)
        {
            officerListFlowLayoutPanel.Controls.Clear();

            if (selectedOfficerDesignations.Count > 0)
            {
                foreach (int id in selectedOfficerDesignations)
                {
                    var designationSeal = _designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == id);
                    if (designationSeal == null)
                    {
                        designationSeal = _designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == id);
                    }

                    if (designationSeal != null)
                    {
                        OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();
                        officerRowUserControl.officerName = designationSeal.officer_name+","+ designationSeal.designation_bng + "," + designationSeal.office_unit + "," + designationSeal.office_bng;
                        officerRowUserControl.designationId = designationSeal.designation_id;
                        officerRowUserControl.officerInfo = designationSeal;
                         officerRowUserControl.DeleteButton += delegate (object se, EventArgs ev) {
                       
                               ReloadOfficerList(officerSelectButton,officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);};

                            officerListFlowLayoutPanel.Controls.Add(officerRowUserControl);

                       if(selectedOfficerDesignations.Count !=1)
                        {
                            
                            officerRowUserControl.UpButton += delegate (object sender, EventArgs e) { UpButton_Click(sender, e, officerRowUserControl._designationId, officerListFlowLayoutPanel, officerSelectButton, officerListPanel, officerEmptyPanel); };
                            officerRowUserControl.DownButton += delegate (object sender, EventArgs e) { DownButton_Click(sender, e, officerRowUserControl._designationId, officerListFlowLayoutPanel, officerSelectButton, officerListPanel, officerEmptyPanel); };

                        }
                        else
                        {
                            officerRowUserControl.InvisibleUpDown();
                        }

                        UIDesignCommonMethod.AddRowinTable(officerListFlowLayoutPanel, officerRowUserControl);
                        
                    }

                }
                ReloadOfficerList(officerSelectButton, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);

            }
        }

        private void DraftOfficerinOnumodonKariOfficerList(FontAwesome.Sharp.IconButton officerSelectButton, List<int> selectedOfficerDesignations, Panel officerListPanel, Panel officerEmptyPanel, TableLayoutPanel officerListFlowLayoutPanel)
        {
            officerListFlowLayoutPanel.Controls.Clear();

            if (selectedOfficerDesignations.Count > 0)
            {
                foreach (int id in selectedOfficerDesignations)
                {
                    var designationSeal = _designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == id);
                    if (designationSeal == null)
                    {
                        designationSeal = _designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == id);
                    }

                    if (designationSeal != null)
                    {
                        OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();
                        officerRowUserControl.officerName = designationSeal.officer_name + "," + designationSeal.designation_bng + "," + designationSeal.office_unit + "," + designationSeal.office_bng;
                        officerRowUserControl.designationId = designationSeal.designation_id;
                        officerRowUserControl.officerInfo = designationSeal;
                        officerRowUserControl.DeleteButton += delegate (object se, EventArgs ev) {

                            ReloadOfficerList(officerSelectButton, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);
                        };

                        officerListFlowLayoutPanel.Controls.Add(officerRowUserControl);

                        if (selectedOfficerDesignations.Count != 1)
                        {

                            officerRowUserControl.UpButton += delegate (object sender, EventArgs e) { UpButton_Click(sender, e, officerRowUserControl._designationId, officerListFlowLayoutPanel, officerSelectButton, officerListPanel, officerEmptyPanel); };
                            officerRowUserControl.DownButton += delegate (object sender, EventArgs e) { DownButton_Click(sender, e, officerRowUserControl._designationId, officerListFlowLayoutPanel, officerSelectButton, officerListPanel, officerEmptyPanel); };

                        }
                        else
                        {
                            officerRowUserControl.InvisibleUpDown();
                        }

                        UIDesignCommonMethod.AddRowinTable(officerListFlowLayoutPanel, officerRowUserControl);

                    }

                }
               // ReloadOfficerList(officerSelectButton, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);

            }
        }

        private void DownButton_Click(object sender, EventArgs e, int designationId, TableLayoutPanel officerListFlowLayoutPanel, FontAwesome.Sharp.IconButton officerSelectButton, Panel officerListPanel, Panel officerEmptyPanel)
        {

            var officers = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Visible == true).ToList();
           
            if(officers!=null && officers.Count!=0)
            {
                for(int i=0;i<officers.Count;i++)
                {
                    if (officers[i]._designationId == designationId && i!=officers.Count-1)
                    {
                        OfficerRowUserControl temp = officers[i + 1];
                        
                        officers[i + 1] = officers[i];
                        officers[i] =temp;
                    }

                }
                officerListFlowLayoutPanel.Controls.Clear();

                for (int i = 0; i < officers.Count; i++)
                {

                    UIDesignCommonMethod.AddRowinTable(officerListFlowLayoutPanel, officers[i]);
                }
            }

                ReloadOfficerList(officerSelectButton, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);

            



        }
       
        private void UpButton_Click(object sender, EventArgs e, int designationId, TableLayoutPanel officerListFlowLayoutPanel, FontAwesome.Sharp.IconButton officerSelectButton, Panel officerListPanel, Panel officerEmptyPanel)
        {
            var officers = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Visible == true).ToList();

            if (officers != null && officers.Count != 0)
            {
                for (int i = 0; i < officers.Count; i++)
                {
                    if (officers[i]._designationId == designationId && i != 0)
                    {
                        OfficerRowUserControl temp = officers[i - 1];

                        officers[i - 1] = officers[i];
                        officers[i] = temp;
                    }

                }
                officerListFlowLayoutPanel.Controls.Clear();

                for (int i = 0; i < officers.Count; i++)
                {

                    UIDesignCommonMethod.AddRowinTable(officerListFlowLayoutPanel, officers[i]);
                }
            }

            ReloadOfficerList(officerSelectButton, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);


        }

        Point ptOriginal = Point.Empty;
        private void btnDrag_MouseDown(object sender, MouseEventArgs e)
        {
            ptOriginal = new Point(e.X, e.Y);


            ((sender as Control).Parent as TableLayoutPanel).AllowDrop = true;
            ((Control)sender).DoDragDrop(sender, DragDropEffects.All);
        }

        private void tableLayoutPanelDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.Button)))
                e.Effect = DragDropEffects.All;

        }

        

        private void tableLayoutPanelDrop_DragOver(object sender, DragEventArgs e)
        {
            ((Control)e.Data.GetData(typeof(System.Windows.Forms.Button))).Location =
            this.PointToClient(new Point(e.X - ptOriginal.X, e.Y - ptOriginal.Y));
            ((Control)e.Data.GetData(typeof(System.Windows.Forms.Button))).BringToFront();

        }

        private void ReloadOfficerList(FontAwesome.Sharp.IconButton officerSelectButton, Panel onumodonkariListPanel, Panel onumodonkariEmptyPanel, TableLayoutPanel onumodonkariListFlowLayoutPanel)
        {
            var officerList = onumodonkariListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();



            if (officerList.Count == 0)
            {
                onumodonkariEmptyPanel.Visible = true;
            }
            else
            {
                onumodonkariEmptyPanel.Visible = false;
            }

            if(officerSelectButton==onumodonkariOfficerSelectButton)
            {
                onumodonkariListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddOnumodonOfficertoScript(officerList);
                

            }

            else if (officerSelectButton== prapokListShowButton)
            {
                prapokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddPrapokOfficerstoScript(officerList);


            }
            else if (officerSelectButton== prerokListShowButton)
            {
                prerokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddSenderOfficertoScript(officerList);


            }
            else if(officerSelectButton == attentionListShowButton)
            {
                attentionListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddAttentionOfficersOfficertoScript(officerList);
            }
            else if(officerSelectButton == onulipiListShowButton)
            {
                onulipiListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddOnulipiOfficersOfficertoScript(officerList);
            }

            onumodonkariListPanel.Visible = true;
        }

        public string onulipiofficersScript;
        public List<PrapokDTO> onulipiOfficers;
        private async void AddOnulipiOfficersOfficertoScript(List<OfficerRowUserControl> officerList)
        {

            JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

            _currentHtmlString = response.Result.ToString();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_currentHtmlString);


            var onulipiDateAndTimeElement = doc.DocumentNode.Descendants("table").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("sarokBottomWrapper"));
            var officerTableElement = doc.DocumentNode.Descendants("table").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("khoshraOnulipiList"));
            var officerULElement = doc.DocumentNode.Descendants("ul").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("list-style-bengali listed_items khoshra_onulipi"));



            // htmlString = htmlString.Replace(System.Environment.NewLine, "");

            if (officerList.Count > 0)
            {
                List<string> officerListString = new List<string>();
                onulipiOfficers = new List<PrapokDTO>();
                foreach (OfficerRowUserControl officerRowUserControl in officerList)
                {
                    onulipiOfficers.Add(officerRowUserControl.officerInfo);
                    officerListString.Add(officerRowUserControl.officerInfo.designation_bng + "," + officerRowUserControl.officerInfo.unit_name_bng + "," + officerRowUserControl.officerInfo.office_bng);

                }


                try
                {
                    officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "width: 100%; opacity: 1;";

                    string officerListHtml =KhoshraTemplateHtmlStringChange.AddOnulipiOfficerintheList(officerListString);
                    officerULElement.InnerHtml = officerListHtml;

                    onulipiDateAndTimeElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "width: 100%; opacity: 1;";
                }
                catch
                {

                }



            }
            else
            {
                try
                {
                    officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "width: 100%; opacity: 0;";
                    officerULElement.InnerHtml = "<li><span class=\"remove_item\">(১) </span></li>";
                    onulipiOfficers = null;
                    onulipiDateAndTimeElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "width: 100%; opacity: 0;";
                }
                catch
                {

                }




            }
            _currentHtmlString = _khasraPotroTemplateData.html_content = doc.DocumentNode.OuterHtml;
            Template_CLick(_khasraPotroTemplateData);
        }

        public string attentionofficersScript;
        public List<PrapokDTO> attentionOfficers;
        private async void AddAttentionOfficersOfficertoScript(List<OfficerRowUserControl> officerList)
        {
           
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                _currentHtmlString = response.Result.ToString();
           
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_currentHtmlString);

           
            var officerTableElement = doc.DocumentNode.Descendants("div").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("khoshraAttentionList"));
            //var officerTableElementProtibedon = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_attention_text"));



            // htmlString = htmlString.Replace(System.Environment.NewLine, "");
           
            if (officerList.Count > 0)
            {
                List<string> officerListString = new List<string>();
                attentionOfficers = new List<PrapokDTO>();
                foreach (OfficerRowUserControl officerRowUserControl in officerList)
                {
                    attentionOfficers.Add(officerRowUserControl.officerInfo);
                    officerListString.Add(officerRowUserControl.officerInfo.designation_bng + "," + officerRowUserControl.officerInfo.unit_name_bng + "," + officerRowUserControl.officerInfo.office_bng);

                }

               
                
                    try
                    {
                        officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "margin-top: 40px;";
                        string officerListHtml = KhoshraTemplateHtmlStringChange.AttentionOfficerPOriginal + KhoshraTemplateHtmlStringChange.AddAttentionOfficerintheList(officerListString);

                        officerTableElement.InnerHtml = officerListHtml;
                    }
                    catch
                    {

                    }
                
                



            }
            else
            {
                try
                {
                    
                    
                    officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "display: none; margin-top: 40px;";
                    officerTableElement.InnerHtml = "<p class=\"write_here khoshraAttentionTitle\" style=\"margin: 0; font - family: 'nikosh'!important; \" contenteditable=\"false\">দৃষ্টি আকর্ষণ:</p>";
                    attentionOfficers = null;
                }
                catch
                {

                }
                



            }
            _currentHtmlString = _khasraPotroTemplateData.html_content = doc.DocumentNode.OuterHtml;
            Template_CLick(_khasraPotroTemplateData);
        }



        public string prapokofficersScript;
        public List<PrapokDTO> prapokOfficers;
        public string _currentHtmlString;


        private  void LoadNewTemplate()
        {
            prapokofficersScript = null;
            _currentHtmlString = null;
            prapokOfficers = null;
            dateTime = null;
            dateTimeApprover = null;

            onumodonkariListFlowLayoutPanel.Controls.Clear();
            onumodonkariEmptyPanel.Visible = true;
            

            prerokListFlowLayoutPanel.Controls.Clear();
            prerokEmptyPanel.Visible = true;

            prapokListFlowLayoutPanel.Controls.Clear();
            prapokEmptyPanel.Visible = true;

            attentionListFlowLayoutPanel.Controls.Clear();
            attentionEmptyPanel.Visible = true;

            onulipiListFlowLayoutPanel.Controls.Clear();
            onulipiEmptyPanel.Visible = true;
        }
        
        private async void AddPrapokOfficerstoScript(List<OfficerRowUserControl> officerList)
        {


            JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

            _currentHtmlString = response.Result.ToString();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_currentHtmlString);


            var officerTableElement = doc.DocumentNode.Descendants("div").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("khoshraReceiversList"));



            // htmlString = htmlString.Replace(System.Environment.NewLine, "");

            if (officerList.Count > 0)
            {
                List<string> officerListString = new List<string>();
                prapokOfficers = new List<PrapokDTO>();
                foreach (OfficerRowUserControl officerRowUserControl in officerList)
                {
                    prapokOfficers.Add(officerRowUserControl.officerInfo);
                    officerListString.Add(officerRowUserControl.officerInfo.designation_bng + "," + officerRowUserControl.officerInfo.unit_name_bng + "," + officerRowUserControl.officerInfo.office_bng);

                }


                try
                {
                    officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "margin-top: 40px;";

                    string officerListHtml = KhoshraTemplateHtmlStringChange.KhoshraReceivingTitleShow + KhoshraTemplateHtmlStringChange.AddReceiverintheList(officerListString);
                    officerTableElement.InnerHtml = officerListHtml;
                }
                catch
                {

                }



            }
            else
            {
                try
                {
                    officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "display: none; margin-top: 40px;";
                    officerTableElement.InnerHtml = "<p class=\"write_here khoshraReceiversTitle\" style=\"margin: 0; font - family: 'nikosh'!important; \" contenteditable=\"false\">বিতরণ :</p>";
                    prapokOfficers = null;
                }
                catch
                {

                }




            }
            _currentHtmlString = _khasraPotroTemplateData.html_content = doc.DocumentNode.OuterHtml;
            Template_CLick(_khasraPotroTemplateData);

        }



        private string _onumodonOfficer;
        private string _onumodonDesignation;
        private string _onumodonPhone;
        private string _onumodonEmail;
        private string _onumodonFax;
        List<PrapokDTO> onumodonOfficer;
        private async void AddOnumodonOfficertoScript(List<OfficerRowUserControl> officerList)
        {

           
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                _currentHtmlString = response.Result.ToString();

          
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_currentHtmlString);

            var officerNameApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("write_here khoshra_approver_text"));
            var shovapotiNames = doc.DocumentNode.Descendants("td").Where(d => d.GetAttributeValue("class", "").Contains("shovapoti_name")).ToList();
            

            if(officerNameApprover == null)
            {
               officerNameApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_approver_text write_here"));

            }

            var officerDesignationApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("write_here khoshra_approver_designation"));
            if (officerDesignationApprover == null)
            {
                officerDesignationApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_approver_designation write_here"));

            }

            var officerPhoneApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("write_here khoshra_approver_phone"));
            if (officerPhoneApprover == null)
            {
                officerPhoneApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_approver_phone write_here"));

            }

            var officerfaxApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("write_here khoshra_approver_fax"));
            if (officerfaxApprover == null)
            {
                officerfaxApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_approver_fax write_here"));

            }

            var officeremailApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("write_here khoshra_approver_email"));
            if (officeremailApprover == null)
            {
                officeremailApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_approver_email write_here"));

            }

          

           


            if (officerList.Count>0)
            {
                onumodonOfficer = new List<PrapokDTO>();
                onumodonOfficer.Add(officerList[0]._officerInfo);
             
                if (shovapotiNames != null && shovapotiNames.Count > 0)
                {
                    foreach (HtmlNode shovapotiName in shovapotiNames)
                    {
                        shovapotiName.InnerHtml = onumodonOfficer[0].officer_bng;
                    }
                }

                try
                {
                    officerPhoneApprover.InnerHtml =officerList[0]._officerInfo.personal_mobile;
                    officeremailApprover.InnerHtml =officerList[0]._officerInfo.personal_email;
                    officerfaxApprover.InnerHtml = "";
                    officerNameApprover.InnerHtml = officerList[0]._officerInfo.officer_bng;
                    officerDesignationApprover.InnerHtml =officerList[0]._officerInfo.designation_bng;

                }
                catch
                {

                }



            }
            else
            {
                onumodonOfficer = null;
               
                if (shovapotiNames != null && shovapotiNames.Count > 0)
                {
                    foreach (HtmlNode shovapotiName in shovapotiNames)
                    {
                        shovapotiName.InnerHtml ="..............";
                    }
                }

                try
                {
                    officerPhoneApprover.InnerHtml = "অনুমোদনকারী ফোন";
                    officeremailApprover.InnerHtml = "অনুমোদনকারী ইমেইল";
                    officerfaxApprover.InnerHtml = "অনুমোদনকারী ফ্যাক্স";
                    officerNameApprover.InnerHtml = "অনুমোদনকারী";
                    officerDesignationApprover.InnerHtml = "অনুমোদনকারী পদবী";
                }
                catch
                {

                }

            }

           _currentHtmlString = _khasraPotroTemplateData.html_content = doc.DocumentNode.OuterHtml;
            Template_CLick(_khasraPotroTemplateData);

        }

        private string _senderOfficer;
        private string _senderDesignation;
        List<PrapokDTO> senderOfficer;
        private async void AddSenderOfficertoScript(List<OfficerRowUserControl> officerList)
        {

            JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

            _currentHtmlString = response.Result.ToString();


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_currentHtmlString);

            var officerNameApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("write_here khoshra_sender"));
            if (officerNameApprover == null)
            {
                officerNameApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_sender write_here"));

            }

            var officerDesignationApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("write_here khoshra_sender_designation"));
            if (officerDesignationApprover == null)
            {
                officerDesignationApprover = doc.DocumentNode.Descendants("p").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_sender_designation write_here"));

            }
            var officerTableElement = doc.DocumentNode.Descendants("table").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("senderWrapper"));



           


            if (officerList.Count > 0)
            {
                senderOfficer = new List<PrapokDTO>();
                senderOfficer.Add(officerList[0]._officerInfo);


                try
                {
                    officerNameApprover.InnerHtml = officerList[0]._officerInfo.officer_bng;
                    officerDesignationApprover.InnerHtml = officerList[0]._officerInfo.designation_bng;
                    officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "width: 100%; opacity: 1;";



                }
                catch
                {

                }



            }
            else
            {
                senderOfficer = null;

                try
                {
                   
                    officerNameApprover.InnerHtml = "(প্রেরক)";
                    officerDesignationApprover.InnerHtml = "(প্রেরক পদবী)";
                    officerTableElement.Attributes.FirstOrDefault(a => a.Name == "style").Value = "width: 100%; opacity: 0;";
                }
                catch
                {

                }

            }

            _currentHtmlString = _khasraPotroTemplateData.html_content = doc.DocumentNode.OuterHtml;
            Template_CLick(_khasraPotroTemplateData);

        }

        public System.Windows.Forms.HtmlDocument GetHtmlDocument(string html)
        {
            WebBrowser browser = new WebBrowser();
            browser.ScriptErrorsSuppressed = true;
            browser.DocumentText = html;
            browser.Document.OpenNew(true);
            browser.Document.Write(html);
            browser.Refresh();
            return browser.Document;
        }

        private void prapokOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(prapokListShowButton, prapokListPanel, prapokEmptyPanel, prapokListFlowLayoutPanel);

        }
       
        private void prerokOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(prerokListShowButton,prerokListPanel, prerokEmptyPanel, prerokListFlowLayoutPanel);
        }

        private void attentionOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(attentionListShowButton, attentionListPanel, attentionEmptyPanel, attentionListFlowLayoutPanel);
        }

        private void onulipiOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(onulipiListShowButton, onulipiListPanel, onulipiEmptyPanel, onulipiListFlowLayoutPanel);
        }

        private void newAttachmentButton_Click(object sender, EventArgs e)
        {
            KhosraAttachmentForm khosraAttachmentForm = new KhosraAttachmentForm();
            UIDesignCommonMethod.CalPopUpWindow(khosraAttachmentForm, this);
        }

        private void khosraReviewButton_Click(object sender, EventArgs e)
        {
            SelectOfficersFormKhosraReview selectOfficerForm = new SelectOfficersFormKhosraReview();
            
            
            selectOfficerForm.designationSealListResponse = _designationSealListResponse;

            //selectOfficerForm.SaveButtonClick += delegate (object se, EventArgs ev) { SaveOfficerinOnumodonKariOfficerList(officerSelectButton, selectOfficerForm._selectedOfficerDesignations, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel); };

            UIDesignCommonMethod.CalPopUpWindow(selectOfficerForm, this);
        }
        public KhasraPotroTemplateDataDTO _khasraPotroTemplateData { get; set; }
        private void Khosra_Load(object sender, EventArgs e)
        {
            RefreshKhosra();
            label7.Text = UIDesignCommonMethod.copyRightLableText;
            khosraTableLayoutPanel.Enabled = false;
        }

        private void RefreshKhosra()
        {
            //ControlExtension.Draggable(prapokListFlowLayoutPanel, true);
            CreateEditor();
            DakUserParam userParam = _userService.GetLocalDakUserParam();

            LoadAllDesignation();
            // _designationSealListResponse = designationSealListResponse;
            LoadDakPriority();
            LoadDakSecurity();

            templateListTableLayoutPanel.Controls.Clear();




            khasraPotroTemplateResponse = _khasraTemplateService.GetKhosraTemplate(userParam);

            templateListTableLayoutPanel.Controls.Clear();

            if (khasraPotroTemplateResponse.status == "success")
            {
                if (khasraPotroTemplateResponse.data.Count > 0)
                {


                    int count = 0;
                    KhosraTemplateButton khosraTemplateButtonFake = new KhosraTemplateButton();
                    KhosraTemplateButton khosraTemplateButtonFake2 = new KhosraTemplateButton();
                    foreach (KhasraPotroTemplateDataDTO khasraPotroTemplateDataDTO in khasraPotroTemplateResponse.data)
                    {



                        KhosraTemplateButton khosraTemplateButton = new KhosraTemplateButton();
                        khosraTemplateButton.khasraPotroTemplateData = khasraPotroTemplateDataDTO;
                        khosraTemplateButton.TemplateClick += delegate (object se, EventArgs ve) { Template_CLick_New(khosraTemplateButton._khasraPotroTemplateData); };

                        if (count == 0)
                        {
                            if(_khasraPotroTemplateData == null)
                            {
                                _khasraPotroTemplateData = khasraPotroTemplateDataDTO;
                            }
                           


                            khosraTemplateButtonFake.khasraPotroTemplateData = khasraPotroTemplateDataDTO;
                            khosraTemplateButtonFake.TemplateClick += delegate (object se, EventArgs ve) { Template_CLick(khosraTemplateButtonFake._khasraPotroTemplateData); };
                            UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButtonFake);
                            UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButtonFake2);




                        }

                        UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButton);
                        count += 1;
                    }
                    //  UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButtonFake);

                }
            }


            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow.fileName = "৫৬.৪২.০০০০.০১০.২৫.০০৩.২১.২ - ২২ ফেব্রুয়ারি ২০২";

            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow);



            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow2 = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow2.fileName = "Potrojari_2021_65_02_2216139904184630293468.png";
            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow2);


            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow3 = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow3.fileName = "file_example_JPG_1MB.jpg";

            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow3);

        }

        public void LoadAllDesignation()
        {
            DakUserParam userParam = _userService.GetLocalDakUserParam();

            AllDesignationSealListResponse designationSealListResponse = _designationSealService.GetAllDesignationSeal(userParam, userParam.office_id);

            if (designationSealListResponse != null && designationSealListResponse.data != null && designationSealListResponse.data.Count > 0)
            {
                _designationSealListResponse = new DesignationSealListResponse();
                _designationSealListResponse.data = new DesignationSealDataDTO();
                _designationSealListResponse.data.other_office = new List<PrapokDTO>();
                _designationSealListResponse.data.own_office = new List<PrapokDTO>();
                _designationSealListResponse.data.own_office = designationSealListResponse.data;

            }
        }

        private void tinyMceisLoaded()
        {
            throw new NotImplementedException();
        }

        private void nothiAllButton_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();


            form.Khoshra();


            form.NothiKhosrajato += delegate (object snd, EventArgs eve) { NothiKhosrajato(form._noteSelected, form._nothiBranch, form._nothiName, form._nothiAllListDTO); };


            UIDesignCommonMethod.CalPopUpWindow(form,this);
        }
        private NoteNothiDTO _noteSelected;
        private NothiListAllRecordsDTO _nothiAllListDTO;

        public void NothiKhosrajato(NoteNothiDTO noteSelected, string nothiBranch, string nothiName, NothiListAllRecordsDTO nothiAllListDTO)
        {
            lbNoteShakha.Text = nothiBranch;
            lbNothiNo.Text = noteSelected.nothi_no;
            lbSubject.Text = nothiName;


            _noteSelected = noteSelected;
            _nothiAllListDTO = nothiAllListDTO;


            nothiNamePanel.Visible = true;
            noteDetailsButton.Visible = true;
        }

        
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        bool _isTinyMceEditorLoaded;
        private void khoshraBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            

            //try
            //{
            //    tinyMceEditor.Invoke(new MethodInvoker(delegate

            //    {
            //        tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _khasraPotroTemplateData.html_content });
            //        tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
            //        _isTinyMceEditorLoaded = true;

            //    }));
            //}
            //catch
            //{
            //    _isTinyMceEditorLoaded = false;
            //}
        }

        private void khoshraBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if(tinyMceEditor.IsAccessible)
            {
                tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _khasraPotroTemplateData.html_content });
                tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
            }
            else
            {
                khoshraBackgroundWorker.RunWorkerAsync();
            }

            //if (!khoshraBackgroundWorker.IsBusy && this.Visible && _isTinyMceEditorLoaded)
            //{

            //   
            //}
        }

      

        private void tinyMceEditor_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if(!_isTinyMceEditorLoaded)
            {
                try
                {
                    
                    if (!string.IsNullOrEmpty(kasaradashboardHtmlContent))
                    {
                        tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { kasaradashboardHtmlContent });
                        _khasraPotroTemplateData.html_content = kasaradashboardHtmlContent;
                    }
                    else
                    {
                        tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _khasraPotroTemplateData.html_content });
                        LoadDate(DateTime.Now);
                    }
                    tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
                    _isTinyMceEditorLoaded = true;
                   
                }
                catch(Exception ex)
                {
                    _isTinyMceEditorLoaded = false;
                }
            }


            BeginInvoke((MethodInvoker)delegate
            {
                khosraTableLayoutPanel.Enabled = true;
            });
           
        }
        private async void LoadTime(DateTime now)
        {

            JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

            _currentHtmlString = response.Result.ToString();
            string timestring = ConversionMethod.EngDigittoBanDigit(now.ToString("hh:mm ")) + "মিনিট";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_currentHtmlString);

            try
            {

                var timeHtmlElem = doc.DocumentNode.Descendants("span").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("bn_time_text"));

                timeHtmlElem.InnerHtml = timestring;

            }
            catch
            {

            }

            _currentHtmlString = _khasraPotroTemplateData.html_content = doc.DocumentNode.OuterHtml;


            tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _currentHtmlString });
            tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");







        }

        private DateTime? dateTime;
        
        private async void LoadDate(DateTime now)
        {
           
          JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

         _currentHtmlString = response.Result.ToString();
            string enDate = ConversionMethod.EnglishNumberToBangla(now.Day.ToString()) + " " + ConversionMethod.GetEngMonthNameinBengali(now.Month) + " " + ConversionMethod.EnglishNumberToBangla(now.Year.ToString());
            string bnDate = KhoshraTemplateHtmlStringChange.BanglaDateFromEngDate(now);
          //string timestring=now.
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(_currentHtmlString);

            try
            {
               
                var engDate = doc.DocumentNode.Descendants("input").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("potro_date_en"));
                var engDateSpan = doc.DocumentNode.Descendants("span").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("en_date_text"));
                if(engDateSpan !=null)
                {
                    engDateSpan.InnerHtml = enDate;
                    if (engDate != null)
                    {
                        engDate.Attributes.FirstOrDefault(a => a.Name == "value").Value = enDate;
                        engDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 0;";

                    }
                }
                else if(engDate !=null)
                {
                    engDate.Attributes.FirstOrDefault(a => a.Name == "value").Value = enDate;
                    engDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 1;";

                }

                var banglaDate = doc.DocumentNode.Descendants("input").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("potro_date_bn"));
                var banglaDateSpan = doc.DocumentNode.Descendants("span").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("bn_date_text"));

                
                if(banglaDateSpan != null)
                {
                    banglaDateSpan.InnerHtml = bnDate;
                    banglaDateSpan.Attributes.FirstOrDefault(a => a.Name == "style").Value = "position: absolute; top: 0px; left: 0px; right: 0px; color: #414141; opacity: 1;";
                    if (banglaDate != null)
                    {
                        banglaDate.Attributes.FirstOrDefault(a => a.Name == "value").Value = bnDate;
                        banglaDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 0;";

                    }
                }
                else
                {
                    if (banglaDate != null)
                    {
                        banglaDate.Attributes.FirstOrDefault(a => a.Name == "value").Value = bnDate;
                        banglaDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 1;";

                    }
                }


            }
            catch
            {

            }
            try
            {
                var engDate = doc.DocumentNode.Descendants("input").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("approver_potro_date_en"));
                engDate.Attributes.FirstOrDefault(a => a.Name == "value").Value = enDate;
                engDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 1;";

                var banglaDate = doc.DocumentNode.Descendants("input").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("approver_potro_date_bn"));
                banglaDate.Attributes.FirstOrDefault(a => a.Name == "value").Value = bnDate;
                banglaDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "border: none; font-size: 15px; width: 100%; text-align: center; background: transparent; opacity: 1;";

            }
            catch (Exception ex)
            {

            }
            try
            {
                var engDate = doc.DocumentNode.Descendants("span").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("approver_bn_date_text"));
                engDate.InnerHtml = enDate;
                engDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "position: absolute; top: 0;left: 0; right: 0; text-align: center;opacity:0";

                var banglaDate = doc.DocumentNode.Descendants("span").FirstOrDefault(d => d.GetAttributeValue("id", "").Contains("approver_en_date_text"));
                banglaDate.InnerHtml = bnDate;
                banglaDate.Attributes.FirstOrDefault(a => a.Name == "style").Value = "position: absolute; top: 0;left: 0; right: 0; text-align: center;opacity:0";

            }
            catch(Exception ex)
            {

            }

            _currentHtmlString = _khasraPotroTemplateData.html_content = doc.DocumentNode.OuterHtml;
          
            
            tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _currentHtmlString });
            tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");







        }

        public void SetSarokNo(string sarokNo)
        {
            _sarokNo = sarokNo;
        }
        private DateTime? dateTimeApprover;
      


        private string _potrosub;
        private string _potrotype;
        private string _sarokNo;
        public int draft_id;
        private async void saveButton_Click(object sender, EventArgs e)
        {
           


            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "অপনি কি খসরা টি সংরক্ষণ করতে চান?";
            conditonBoxForm.ShowDialog();

            if (conditonBoxForm.Yes)
            {
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");


                _currentHtmlString = response.Result.ToString();

                //_currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.dateSharokTitleOriginal, KhoshraTemplateHtmlStringChange.dateSharokTitleReplace);


                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                KhosraSaveParamPotro khosraSaveParamPotro = new KhosraSaveParamPotro();
                khosraSaveParamPotro.potrojari = new KhasraSaveParamPotrojari();
                khosraSaveParamPotro.potrojari.potro_type = _khasraPotroTemplateData.template_id;
                if(draft_id !=0)
                {
                      khosraSaveParamPotro.potrojari.id = draft_id;
                    
                }
                //khosraSaveParamPotro.potrojari.attached_potro=
                int potrojari_id = 0;

                if(_khasraPotroTemplateData.potrojari_id != 0)
                {
                    potrojari_id = _khasraPotroTemplateData.potrojari_id;
                }
                else
                {
                    potrojari_id = _khasraPotroTemplateData.id;
                }

                if(_noteSelected != null)
                {
                    khosraSaveParamPotro.potrojari.note_subject = _noteSelected.note_subject;
                    khosraSaveParamPotro.potrojari.nothi_master_id = Convert.ToInt32(_noteSelected.nothi_id);
                   
                    if (!string.IsNullOrEmpty(_sarokNo))
                    {
                        khosraSaveParamPotro.potrojari.sarok_no = _sarokNo;
                    }
                    else
                    {
                        GetSarokNoResponse sarok_no = _khosraSaveService.GetSharokNoResponse(dakUserParam, Convert.ToInt32(_noteSelected.nothi_id), potrojari_id);
                        khosraSaveParamPotro.potrojari.sarok_no = sarok_no.sarok_no;
                    }

                    khosraSaveParamPotro.potrojari.nothi_note_id = Convert.ToInt32(_noteSelected.note_id);
                 

                }


                khosraSaveParamPotro.potrojari.potro_description = ConversionMethod.Base64Encode(_currentHtmlString);
                khosraSaveParamPotro.potrojari.potro_priority_level = dakPriorityComboBox.SelectedIndex;
                khosraSaveParamPotro.potrojari.potro_security_level = dakSecrurityComboBox.SelectedIndex;

                khosraSaveParamPotro.potrojari.potro_subject = GetPotroSubjectFromHtmlString(_currentHtmlString);
                khosraSaveParamPotro.potrojari.draft_officer_id = dakUserParam.officer_id;
                khosraSaveParamPotro.potrojari.operation_type = "draft";


              //khosraSaveParamPotro.potrojari.potro_subject=_khasraPotroTemplateData
              //khosraSaveParamPotro.potrojari.potro_type= _khasraPotroTemplateData.
              //khosraSaveParamPotro.potrojari.sarok_no=
                khosraSaveParamPotro.recipient = new KhosraSaveParamRecipent();

               
               if(onumodonOfficer != null)
                {
                    AddOnumodontoParam(khosraSaveParamPotro);
                }
               if(onulipiOfficers != null)
                {
                    AddOnulipiParam(khosraSaveParamPotro);
                }
                if (prapokOfficers != null)
                {
                    AddPrpoktoParam(khosraSaveParamPotro);
                }
                if (senderOfficer != null)
                {
                    AddSendertoParam(khosraSaveParamPotro);
                }
                if (attentionOfficers != null)
                {
                    AddAttentiontoParam(khosraSaveParamPotro);
                }

               
    
               



                 KhosraSaveResponse khosraSaveResponse = _khosraSaveService.GetKhosraSaveResponse(dakUserParam, khosraSaveParamPotro);


                if(khosraSaveResponse.status=="success")
                {
                    UIDesignCommonMethod.SuccessMessage(khosraSaveResponse.data);
                   
                    if(_noteListDataRecordNoteDTO != null)
                    {
                        commonKhosraRowUserControl_NoteDetails_ButtonClick(_noteListDataRecordNoteDTO, _nothiListRecordsDTO, _nothiListInboxNoteRecordsDTO);
                    }
                    else if(_noteSelected != null)
                    {
                        LoadNote();
                    }
                   
                }
                else if(khosraSaveResponse.status == "error")
                {
                    UIDesignCommonMethod.ErrorMessage(khosraSaveResponse.message);
                }
                else
                {
                    UIDesignCommonMethod.ErrorMessage("");
                }
            }


        }

        private void LoadNote()
        {
            var form = FormFactory.Create<Note>();
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = _noteSelected.note_id.ToString();
            // form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { NoteDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiListInboxNoteRecordsDTO); };

            NothiListRecordsDTO nothiListRecords = new NothiListRecordsDTO();
            nothiListRecords.id = _nothiAllListDTO.nothi.id;
            if (_nothiAllListDTO.desk != null)
            {
                nothiListRecords.issue_date = _nothiAllListDTO.desk.issue_date;
                nothiListRecords.note_count = _nothiAllListDTO.desk.note_count;
                nothiListRecords.note_current_status = _nothiAllListDTO.desk.note_current_status;
                nothiListRecords.priority = _nothiAllListDTO.desk.priority.ToString();

            }
            if (_nothiAllListDTO.nothi != null)
            {
                nothiListRecords.last_note_date = _nothiAllListDTO.nothi.last_note_date;

                nothiListRecords.nothi_class = _nothiAllListDTO.nothi.nothi_class;
                nothiListRecords.nothi_no = _nothiAllListDTO.nothi.nothi_no;
                nothiListRecords.office_designation_name = _nothiAllListDTO.nothi.office_designation_name;
                nothiListRecords.office_id = _nothiAllListDTO.nothi.office_id;
                nothiListRecords.office_name = _nothiAllListDTO.nothi.office_name;
                nothiListRecords.office_unit_id = _nothiAllListDTO.nothi.office_unit_id;
                nothiListRecords.office_unit_name = _nothiAllListDTO.nothi.office_unit_name;
                nothiListRecords.office_unit_organogram_id = _nothiAllListDTO.nothi.office_unit_organogram_id;
                nothiListRecords.subject = _nothiAllListDTO.nothi.subject;

            }

            //nothiListRecords.nothi_type = _nothiAllListDTO.nothi.;
            NoteView noteView = new NoteView();
            //
            form.nothiNo = nothiListRecords.nothi_no;
            form.nothiShakha = nothiListRecords.office_unit_name + " " + _dakuserparam.office_label;
            form.nothiSubject = nothiListRecords.subject;
            form.noteSubject = _noteSelected.note_subject;
            form.nothiLastDate = nothiListRecords.last_note_date;

            var nothiInboxNote = _nothiInboxNote.GetNothiInboxNote(_dakuserparam, _nothiAllListDTO.nothi.id.ToString(), "all");
            noteView.totalNothi = "0";

            NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO = new NothiListInboxNoteRecordsDTO();
            try
            {

                if (nothiInboxNote.status == "success")
                {

                    if (nothiInboxNote.data.records.Count > 0)
                    {

                        nothiListInboxNoteRecordsDTO = nothiInboxNote.data.records.FirstOrDefault(a => a.note.nothi_note_id == _nothiAllListDTO.nothi.id);
                        if (nothiListInboxNoteRecordsDTO != null)

                        {
                            form.noteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO;

                        }

                    }
                }


            }
            catch
            {

            }




            form.office = "( " + nothiListRecords.office_name + " " + nothiListRecords.last_note_date + ")";


            noteView.nothiLastDate = nothiListRecords.last_note_date;

            noteView.totalNothi = _noteSelected.note_no.ToString();
            noteView.noteSubject = _noteSelected.note_subject;
            noteView.officerInfo = _dakuserparam.officer + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
            noteView.checkBox = "1";
            noteView.nothiNoteID = Convert.ToInt32(_noteSelected.note_id);


            form.noteTotal = _noteSelected.note_no.ToString();



            form.loadNothiInboxRecords(nothiListRecords);
            form.loadNoteView(noteView);

            if (_noteSelected._isOffline)
            {
                form.setStatus("offline");
                nothiListRecords.id = _noteSelected.extra_nothi_id;

            }


            nothiListRecords.local_nothi_type = "all";
            this.Hide();
            form.ShowDialog();



           
        }

        private string GetPotroSubjectFromHtmlString(string currentHtmlString)
        {




            string sub = "";

            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(currentHtmlString);
                var td = doc.DocumentNode.Descendants("td").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_subject"));
                sub = td.InnerText;

               



            }
            catch
            {

            }

            return sub;

        }
        private string SetPotroElementToHtmlString(string currentHtmlString, string subject)
        {




           

            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(currentHtmlString);
                var td = doc.DocumentNode.Descendants("td").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_subject"));
                td.InnerHtml=subject;


                return doc.DocumentNode.OuterHtml;


            }
            catch
            {

            }

            return currentHtmlString;

        }
        private void AddPrpoktoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach(PrapokDTO prapokDTO in prapokOfficers)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();
                khosraSaveParamOfficer.recipient_type = "receiver";
                khosraSaveParamOfficer.office_id = prapokDTO.office_id.ToString();
                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.receiver = receivers.ToDictionary(a=>a.designation_id);
        }

        private void AddOnulipiParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in onulipiOfficers)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();
                khosraSaveParamOfficer.recipient_type = "onulipi";
                khosraSaveParamOfficer.office_id = prapokDTO.office_id.ToString();
                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.onulipi = receivers.ToDictionary(a => a.designation_id);
        }
        private void AddAttentiontoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in attentionOfficers)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();
                khosraSaveParamOfficer.recipient_type = "attention";
                khosraSaveParamOfficer.office_id = prapokDTO.office_id.ToString();

                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.attention = receivers.ToDictionary(a => a.designation_id);
        }
        private void AddSendertoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in senderOfficer)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();
                khosraSaveParamOfficer.recipient_type = "sender";
                khosraSaveParamOfficer.office_id = prapokDTO.office_id.ToString();
                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.sender = receivers.ToDictionary(a => a.designation_id);
        }
        private void AddOnumodontoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in onumodonOfficer)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();
                khosraSaveParamOfficer.office_id = prapokDTO.office_id.ToString();
              
                khosraSaveParamOfficer.recipient_type = "approver";
                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.approver = receivers.ToDictionary(a => a.designation_id);
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadDate(dateTimePicker.Value);
           
        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void userDetailsPanel_Click(object sender, EventArgs e)
        {
            if (!designationDetailsPanel.Visible)
            {
                int designationPanleX = this.Width - designationDetailsPanel.Width - 25;
                int designationPanleY = profilePanel.Location.Y + profilePanel.Height;
                designationDetailsPanel.Location = new Point(designationPanleX, designationPanleY);

                designationDetailsPanel.Visible = true;


            }
            else
            {
                designationDetailsPanel.Visible = false;
            }
        }

        private void DakModule_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
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
        private void Nothi_Module_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }

        private void protibedonOnumedonButton_Click(object sender, EventArgs e)
        {
            AddProtibedonOnumodonSealAsync();
        }

        private async void AddProtibedonOnumodonSealAsync()
        {
            JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

            _currentHtmlString = response.Result.ToString();

            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            string onumodonProtibedonSign = KhoshraTemplateHtmlStringChange.GetOnumodonProtibedonString(dakUserParam.officer_name, dakUserParam.designation + "," + dakUserParam.office_unit + "," + dakUserParam.office_label);
            _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.onumodonProtibedonString, onumodonProtibedonSign);


             _khasraPotroTemplateData.html_content = _currentHtmlString;
            Template_CLick(_khasraPotroTemplateData);
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadTime(timePicker.Value);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

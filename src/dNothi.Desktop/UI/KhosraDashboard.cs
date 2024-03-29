﻿using dNothi.Desktop.UI.Dak;
using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.Desktop.UI.PotroJariGroups;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.KasaraPatraDashBoardService;
using dNothi.Services.KasaraPatraDashBoardService.Models;
using dNothi.Services.SyncServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using FontAwesome.Sharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using org.ietf.jgss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace dNothi.Desktop.UI
{
    public partial class KhosraDashboard : Form
    {
        private DakUserParam dakListUserParam = new DakUserParam();
        private DakUserParam _dakuserparam = new DakUserParam();
       
        IKasaraPatraDashBoardService _kasaraPatraDashBoardService { get; set; }
        ISyncerService _syncerServices { get; set; }

        int page = 1;
        int pageLimit = 10;
        int menuNo = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
       
        IUserService _userService { get; set; }
        public KhosraDashboard(IUserService userService, ISyncerService syncerServices,
               IKasaraPatraDashBoardService kasaraPatraDashBoardService)
        {
            InitializeComponent();
            _userService = userService;
            _syncerServices = syncerServices;
            _kasaraPatraDashBoardService = kasaraPatraDashBoardService;

        }


        private void MakeThisPanelClicked(object sender)
        {
            Panel panel = sender as Panel;
            if(panel == null)
            {
                panel = (sender as Control).Parent as Panel;
            }


            foreach (Control control in menuTableLayoutPanel.Controls)
            {
                if (control is Panel)
                {
                    if (control == panel)
                    {
                        MakeClickUnClickButton(control, Color.FromArgb(243, 246, 249), Color.FromArgb(78, 165, 254));

                    }
                    else
                    {
                        if(control is Button)
                        {
                            listTypeLabel.Text = control.Text;
                        }
                        MakeClickUnClickButton(control, Color.FromArgb(254, 254, 254), Color.FromArgb(97, 99, 114));

                    }
                }
            }
        }

        private void MakeClickUnClickButton(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            if (control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {

                    c.ForeColor = foreColor;


                }
            }
        }

        private void draftPotroPanel_Click(object sender, EventArgs e)
        {
            isPotrojari = false;
            menuNo = 1;
            MakeThisPanelClicked(sender);
            Formload();
            listTypeLabel.Text = draftPotroButton.Text;
           
           
        }

        private void noteAttachmentKhosraButton_Click(object sender, EventArgs e)
        {
            isPotrojari = false;
            menuNo = 2;
            MakeThisPanelClicked(sender);
            Formload();
            listTypeLabel.Text = noteAttachmentKhosraButton.Text;
            
        }

        private void pendingApprovalPanel_Click(object sender, EventArgs e)
        {
            isPotrojari = false;
            menuNo = 3;
            MakeThisPanelClicked(sender);
            Formload();
            listTypeLabel.Text = pendingApprovalButton.Text;
           
        }

        private void pendingForwardPanel_Click(object sender, EventArgs e)
        {
            isPotrojari = false;
            menuNo = 4;
            MakeThisPanelClicked(sender);
            Formload();
            listTypeLabel.Text = pendingForwardButton.Text;
         
        }
        bool isPotrojari;
        private void jarikritoButton_Click(object sender, EventArgs e)
        {
            isPotrojari = true;
            menuNo = 5;
            MakeThisPanelClicked(sender);
            Formload();
            listTypeLabel.Text = jarikritoButton.Text;
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }

        private void KhosraDashboard_Shown(object sender, EventArgs e)
        {
            
            Formload();
            UserProfile();
            GetMenuTotalRecord();
          
        }
        private void UserProfile()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();


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




            userNameLabel.Text = dakUserParam.officer_name + "(" + dakUserParam.designation_label + "," + dakUserParam.unit_label + ")";

            designationDetailsPanel.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanel._designationId); };

        }
        private void GetMenuTotalRecord()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            var totalRecord = _kasaraPatraDashBoardService.KasaraDashBoardRecordCount(dakUserParam);

            JObject data = JObject.Parse(totalRecord.data.ToString());
            string khoshrapotro = "khoshra_potro";
            string approvedpotro = "approved_potro";
            string khoshrawaitingforapproval = "khoshra_waiting_for_approval";
            string potrojariassenderapprover = "potrojari_as_sender_approver";
            string draftpotro = "draft_potro";

            draftPotroCountLabel.Text = "(" + ConversionMethod.EnglishNumberToBangla(data[draftpotro].ToString()) + ")";
            noteAttachmentKhosraCountLabel.Text = "(" + ConversionMethod.EnglishNumberToBangla((string)data[khoshrapotro]) + ")";
            pendingApprovalCountLabel.Text = "(" + ConversionMethod.EnglishNumberToBangla((string)data[khoshrawaitingforapproval]) + ")";
            pendingForwardCountLabel.Text = "(" + ConversionMethod.EnglishNumberToBangla((string)data[approvedpotro]) + ")";
            jarikritoCountLabel.Text = "(" + ConversionMethod.EnglishNumberToBangla((string)data[potrojariassenderapprover]) + ")";
        }
        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            dakListUserParam = _dakuserparam  = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());


           
        }

        //private void LoadFakeRow(bool v)
        //{
        //    khosraListTableLayoutPanel.Controls.Clear();

        //    CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl.isDraft = v;

        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);




        //    CommonKhosraRowUserControl commonKhosraRowUserControl2 = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl2.isDraft = v;


        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl2);


        //    CommonKhosraRowUserControl commonKhosraRowUserControl3 = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl3.isDraft = v;


        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl3);




        //    CommonKhosraRowUserControl commonKhosraRowUserControl4 = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl4.isDraft = v;


        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl4);

        //}

        private void LoadData(int menuNo,int pages)
        {
            khosraListTableLayoutPanel.Controls.Clear();
           
            string nameSearchparam = dakSearchSubTextBox.Text;
            var dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = pageLimit;

            dakListUserParam.page = pages;
            dakListUserParam.NameSearchParam = nameSearchparam;

            var kasarapatralist = _kasaraPatraDashBoardService.GetList(dakListUserParam, menuNo);

            if (kasarapatralist.Status == "success" || kasarapatralist!=null)
            {
                noKhosraPanel.Visible = false;
                foreach (var item in kasarapatralist.data.Records)
                {
                    
                    CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();
                    
                    var subcontrol = KasaraUserControlButtonVisibilityAndNoteNo(item, dakListUserParam.designation_id);
                    if (InternetConnection.Check())
                    {
                        commonKhosraRowUserControl.isLocal = true;
                    }
                    else
                    {
                        commonKhosraRowUserControl.isLocal = item.isLocal;
                    }
                    commonKhosraRowUserControl.potroPage = item.Basic.PotroPages;
                    commonKhosraRowUserControl.sharokNo = item.Basic.SarokNo +" "+ (item.NoteOwner!=null?item.NoteOwner.NothiSubject:string.Empty);
                    commonKhosraRowUserControl.sub = item.Basic.PotroSubject;
                    commonKhosraRowUserControl.date = item.Basic.Modified;
                    if(item.Recipient !=null)
                    {
                        commonKhosraRowUserControl.approver = item.Recipient.Approver.Select(x => x.Officer + ", " + x.Designation).FirstOrDefault();
                        commonKhosraRowUserControl.sender = item.Recipient.Sender.Select(x => x.Officer + ", " + x.Designation).FirstOrDefault();

                    }
                    commonKhosraRowUserControl.daran = item.Basic.NoteOnucchedId>0?"অনুচ্ছেদ":"খসড়া";
                    commonKhosraRowUserControl.ButtonVisibility(subcontrol.Item1, subcontrol.Item2, subcontrol.Item3, isPotrojari);
                    commonKhosraRowUserControl.kasaraPotterNam = item.Basic.PotroTypeName;
                    commonKhosraRowUserControl.noteVisible = subcontrol.Item4;
                    commonKhosraRowUserControl.noteNo = subcontrol.Item5;
                    var mapmodel = MappingModel(item);
                
                    commonKhosraRowUserControl.attachmentButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_attachmentButtonClick(sender, e,item); };
                    commonKhosraRowUserControl.sampadanButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_sampadanButtonClick(sender, e, item, mapmodel); };
                    commonKhosraRowUserControl.PrapakListButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_PrapakListButtonClick(sender, e,item.Basic.Id, item.Recipient); };
                    commonKhosraRowUserControl.portalIconButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_portalIconButtonClick(sender, e,item); };
                   
                    commonKhosraRowUserControl.viewButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_NoteDetails_ButtonClick(mapmodel.Item1, e, mapmodel.Item2, mapmodel.Item3); };

                    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);

                }
               
                totalrecord = kasarapatralist.data.TotalRecords;
                totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = (float)totalrecord / (float)pageLimit;
                totalPage =(int) Math.Ceiling(pagesize);
            }
            else
            {
                noKhosraPanel.Visible = true;
            }

        }

        private (NoteListDataRecordNoteDTO,NothiListRecordsDTO, NothiListInboxNoteRecordsDTO) MappingModel(KasaraPotro.Record item)
        {
            var nothiListRecordsDTO = new NothiListRecordsDTO
            {
                id = item.NoteOwner.NothiMasterId,
                issue_date = item.NoteOwner.IssueDate,
                last_note_date = null,
                local_nothi_type = null,
                note_count = 0,
                note_current_status = item.NoteOwner.NoteCurrentStatus,
                nothi_class = 1,
                nothi_no = null,
                nothi_type = null,
                office_designation_name = item.NoteOwner.Designation,
                office_id = item.NoteOwner.OfficeId,
                office_name = item.NoteOwner.Office,
                office_unit_id = item.NoteOwner.OfficeUnitId,
                office_unit_name = item.NoteOwner.OfficeUnit,
                office_unit_organogram_id = item.NoteOwner.OfficeUnitId,
                priority = item.NoteOwner.Priority.ToString(),
                subject = item.NoteOwner.NothiSubject
            };

            var noteListDataRecordNoteDTO = new NoteListDataRecordNoteDTO { nothi_note_id = item.NoteOwner.NothiNoteId, note_no = item.NoteOwner.NoteNo, is_editable = 1 };
          
            var nothiListInboxNoteRecordsDTO = new NothiListInboxNoteRecordsDTO
            {
                note = new NoteNothiListInboxNoteRecordsDTO
                {
                    note_subject = item.NoteOwner.NoteSubject,
                    nothi_note_id = item.NoteOwner.NothiNoteId,
                    onucched_count = item.NoteOwner.OnucchedCount,
                    khoshra_potro = item.NoteOwner.KhoshraPotro,
                    khoshra_waiting_for_approval = item.NoteOwner.KhoshraWaitingForApproval,
                    approved_potro = item.NoteOwner.ApprovedPotro,
                    potrojari = item.NoteOwner.Potrojari,
                    nothivukto_potro = item.NoteOwner.NothivuktoPotro
                }
            };

            return (noteListDataRecordNoteDTO,nothiListRecordsDTO, nothiListInboxNoteRecordsDTO);
        }
        private (bool,bool,bool,bool,string) KasaraUserControlButtonVisibilityAndNoteNo(KasaraPotro.Record item,int UserParam_designation_id)
        {
            bool sampadan = false, view = false, prapaklist = false,  nodeVisible = false;
            string nodeNo = string.Empty;
            if ((item.NoteOwner!=null? item.NoteOwner.NoteNo:0) > 0)
            {
                nodeVisible = true;
                nodeNo = ConversionMethod.EnglishNumberToBangla(item.NoteOwner.NoteNo.ToString());
                if (item.NoteOnucched.OnucchedNo != null && item.NoteOnucched.OnucchedNo != "0")
                {
                    nodeNo += "." + ConversionMethod.EnglishNumberToBangla(item.NoteOnucched.OnucchedNo);
                }

            }
            if (item.Basic.DakId == 0)
                prapaklist = true;
            if (item.Basic.PotroStatus == "Draft")
                sampadan = true;
            if ((item.NoteOwner != null ? item.NoteOwner.DesignationId:0) == UserParam_designation_id)
                view = true;
            return (sampadan, view, prapaklist, nodeVisible, nodeNo);
        }
        private void commonKhosraRowUserControl_attachmentButtonClick(object sender, EventArgs e, KasaraPotro.Record kasaraPotro)
        {

                KhosraAttachmentViewForm khosraAttachmentViewForm = new KhosraAttachmentViewForm();
           
                khosraAttachmentViewForm.dakAttachmentResponse = GetAllMulPattraAndSanjukti( kasaraPotro);

                UIDesignCommonMethod.CalPopUpWindow(khosraAttachmentViewForm, this);
            
        }
        private DakAttachmentResponse GetAllMulPattraAndSanjukti(KasaraPotro.Record kasaraPotro)
        {
            DakAttachmentResponse dakAttachmentResponse = new DakAttachmentResponse { data = null, status = null };
            if (!InternetConnection.Check())
            {
                dakAttachmentResponse = _kasaraPatraDashBoardService.GetLocalMulpotroSanjukti(kasaraPotro.Basic.Id);
            }
            else
            {
                var dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = pageLimit;
                var noteAntarvuktaKasralist = _kasaraPatraDashBoardService.GetMulPattraAndSanjukti(dakListUserParam, kasaraPotro);
                if (noteAntarvuktaKasralist.status == "success")
                {
                    dakAttachmentResponse = noteAntarvuktaKasralist;
                }
            }
          
            return dakAttachmentResponse;
            
        }
        private void commonKhosraRowUserControl_sampadanButtonClick(object sender, EventArgs e, KasaraPotro.Record kasaraPotro, (NoteListDataRecordNoteDTO, NothiListRecordsDTO, NothiListInboxNoteRecordsDTO) mapmodel)
        {
            

            var khosra = FormFactory.Create<Khosra>();
            var dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = pageLimit;
            PrapakerTalika prapakerTalika = new PrapakerTalika();
            if (InternetConnection.Check())
            {
                 prapakerTalika = _kasaraPatraDashBoardService.GetPrapakerTalika(dakListUserParam, kasaraPotro.Basic.Id);
            }
            else
            {
                prapakerTalika = new PrapakerTalika { status = "success", data = Getprapoktalika(kasaraPotro.Recipient) };
            }
            KhasraPotroTemplateDataDTO khasraPotroTemplateData = new KhasraPotroTemplateDataDTO();
            if (kasaraPotro.NoteOwner != null)
            {
                NoteNothiDTO noteNothiDTO = new NoteNothiDTO();
               
                NothiAllDTO nothi = new NothiAllDTO { id= kasaraPotro.Basic.NothiMasterId};
                DeskAllDTO desk = new DeskAllDTO {  note_count= kasaraPotro.NoteOwner.NothiNoteId>0?1:0};

                NothiListAllRecordsDTO nothiListAllRecordsDTO = new NothiListAllRecordsDTO {  nothi=nothi, desk=desk};
                noteNothiDTO.note_id = Convert.ToString(kasaraPotro.Basic.NothiNoteId);
                noteNothiDTO.id = kasaraPotro.Basic.NothiMasterId;
                noteNothiDTO.note_subject = kasaraPotro.NoteOwner.NoteSubject;
                noteNothiDTO.nothi_id = kasaraPotro.Basic.NothiMasterId.ToString();
                string branchName = kasaraPotro.NoteOwner.OfficeUnit;
                string nothiName = kasaraPotro.NoteOwner.NothiSubject;
                khasraPotroTemplateData.potrojari_id = kasaraPotro.NoteOwner.Potrojari;
                khosra.NothiKhosrajato(noteNothiDTO, branchName, nothiName, nothiListAllRecordsDTO,mapmodel.Item3);
                khosra.SetSarokNo(kasaraPotro.Basic.SarokNo);
            }
            khosra.draft_id = kasaraPotro.Basic.Id;
            khosra._noteListDataRecordNoteDTO = mapmodel.Item1;
            khosra._nothiListRecordsDTO = mapmodel.Item2;
            khosra._nothiListInboxNoteRecordsDTO = mapmodel.Item3;

            if (kasaraPotro.Basic.PotroPages>0)
            {
                var attachment = GetAllMulPattraAndSanjukti(kasaraPotro);
                khosra.draftAttachmentDTOs = attachment != null ? attachment.data.Where(a => a.is_main != 1).ToList() : null;
            }

            khosra.kasaradashboardHtmlContent = Base64Conversion.Base64ToHtmlContent(kasaraPotro.Mulpotro.PotroDescription);

          
            khasraPotroTemplateData.template_id = kasaraPotro.Basic.PotroType;
            khasraPotroTemplateData.template_name = kasaraPotro.Basic.PotroTypeName;
           
            khasraPotroTemplateData.html_content = Base64Conversion.Base64ToHtmlContent(kasaraPotro.Mulpotro.PotroDescription);

            khosra._khasraPotroTemplateData = khasraPotroTemplateData;
        
            khosra._dakSecurity= Convert.ToInt32(kasaraPotro.Basic.PotroSecurityLevel);
            khosra._dakPriority= Convert.ToInt32(kasaraPotro.Basic.PotroPriorityLevel);


            if (prapakerTalika.status == "success")
            {

              
                khosra.LoadAllDesignation();
               
                if(prapakerTalika != null && prapakerTalika.data != null)
                {
                khosra.onulipiOfficerDesignations = prapakerTalika.data.onulipi;
                khosra.onumodanKariOfficerDesignations = prapakerTalika.data.approver;
                khosra.prapakOfficerDesignations = prapakerTalika.data.receiver;
                khosra.prerokOfficerDesignations = prapakerTalika.data.sender;
                khosra.attensionOfficerDesignations = prapakerTalika.data.attention;
                }
               
            }
            //this.ShowInTaskbar = false;
            UIDesignCommonMethod.returnForm = this;
            this.Hide();
            khosra.ShowDialog();
            //this.ShowInTaskbar = true;

        }
        private void commonKhosraRowUserControl_PrapakListButtonClick(object sender, EventArgs e,int nodeId, KasaraPotro.Recipient recipient)
        {
                PrapakerTalika prapakerTalika = new PrapakerTalika();
                var dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = pageLimit;
            if (InternetConnection.Check())
                prapakerTalika = _kasaraPatraDashBoardService.GetPrapakerTalika(dakListUserParam, nodeId);
            else
                 prapakerTalika = new PrapakerTalika { status="success", data= Getprapoktalika(recipient) };
           if (prapakerTalika.status == "success")
                {

                    KhosraPrapokListViewForm khosraPrapokListViewForm = new KhosraPrapokListViewForm();
                    khosraPrapokListViewForm.prapakerTalika = prapakerTalika;


                    UIDesignCommonMethod.CalPopUpWindow(khosraPrapokListViewForm, this);
                }
            
        }
        private PrapakerTalika.Data Getprapoktalika(KasaraPotro.Recipient recipient)
        {
            List<PrapokDTO> approvers = new List<PrapokDTO>();
            List<PrapokDTO> senders = new List<PrapokDTO>();
            List<PrapokDTO> attentions = new List<PrapokDTO>();
            List<PrapokDTO> onulipis = new List<PrapokDTO>();
            List<PrapokDTO> receivers = new List<PrapokDTO>();
            if (recipient.Approver != null)
            {
               
                foreach (var item in recipient.Approver)
                {
                    PrapokDTO approver = new PrapokDTO {  designation_id=item.DesignationId, officer_id=item.OfficeId,designation= item.Designation,  designation_bng = item.Designation, office = item.Office, officer = item.Officer };
                    approvers.Add(approver);
                }
            }

            if (recipient.Sender != null)
            {

                foreach (var item in recipient.Sender)
                {
                    PrapokDTO sender = new PrapokDTO { designation_id = item.DesignationId, officer_id = item.OfficeId, designation = item.Designation, designation_bng = item.Designation, office = item.Office, officer = item.Officer };
                    senders.Add(sender);
                }
            }

            if (recipient.Attention != null)
            {

                foreach (var item in recipient.Attention)
                {
                    PrapokDTO attention = new PrapokDTO { designation_id = item.DesignationId, officer_id = item.OfficeId, designation = item.Designation, designation_bng = item.Designation, office = item.Office, officer = item.Officer };
                    attentions.Add(attention);
                }
            }
            
            if (recipient.Onulipi!= null)
            {
                // onulipis= JsonConvert.DeserializeObject<List<PrapokDTO>>(recipient.Onulipi.ToString());
                var onulipies = JsonConvert.DeserializeObject<List<KasaraPotro.Receiver>>(recipient.Onulipi.ToString());
                foreach (var item in onulipies)
                {
                    PrapokDTO onulipi = new PrapokDTO { designation_id = item.DesignationId, officer_id = item.OfficeId, designation = item.Designation, designation_bng = item.Designation, office = item.Office, officer = item.Officer };
                    onulipis.Add(onulipi);

                }

            }
            if (recipient.Receiver != null)
            {
                var receiveres = JsonConvert.DeserializeObject<List<KasaraPotro.Receiver>>(recipient.Receiver.ToString());
                foreach (var item in receiveres)
                {
                    PrapokDTO receiver = new PrapokDTO { designation_id = item.DesignationId, officer_id = item.OfficeId, designation = item.Designation, designation_bng = item.Designation, office = item.Office, officer = item.Officer };
                    receivers.Add(receiver);
                  
                }
               // receivers = JsonConvert.DeserializeObject<List<PrapokDTO>>(recipient.Receiver.ToString());

            }
            PrapakerTalika.Data data = new PrapakerTalika.Data { approver= approvers, sender=senders, attention= attentions, onulipi= onulipis, receiver=receivers };
            return data;
        }
        private void commonKhosraRowUserControl_viewButtonClick(object sender, EventArgs e)
        {

        }
        private void commonKhosraRowUserControl_portalIconButtonClick(object sender, EventArgs e, KasaraPotro.Record kasaraPotro)
        {

            PotroPublishingForm potroPublishingForm = FormFactory.Create<PotroPublishingForm>();
            potroPublishingForm.subject = kasaraPotro.Basic.PotroSubject;
            //potroPublishingForm.domainname= kasaraPotro.Basic

           // potroPublishingForm.dakAttachmentResponse = GetAllMulPattraAndSanjukti(kasaraPotro);

            UIDesignCommonMethod.CalPopUpWindow(potroPublishingForm, this);

        }
        private void commonKhosraRowUserControl_NoteDetails_ButtonClick(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO, NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO)
        {
            
            var form = FormFactory.Create<Note>();
            _dakuserparam = _userService.GetLocalDakUserParam();
            form.noteIdfromNothiInboxNoteShomuho = noteListDataRecordNoteDTO.nothi_note_id.ToString();
            form.NoteDetailsButton += delegate (object sender1, EventArgs e1) { commonKhosraRowUserControl_NoteDetails_ButtonClick(noteListDataRecordNoteDTO, e, nothiListRecordsDTO, nothiListInboxNoteRecordsDTO); };
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


            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, noteListDataRecordNoteDTO.is_editable); };
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
      
        //    private void LoadApprovedData(bool v,int pages)
        //    {
        //        khosraListTableLayoutPanel.Controls.Clear();
        //        _patraJarirApekkaiService = new PatraJarirApekkaiService();
        //        //  _userService = new UserService();
        //        //  DakUserParam dakListUserParams = new DakUserParam();
        //        var dakListUserParam = _userService.GetLocalDakUserParam();

        //        // Satic Class
        //        dakListUserParam.limit = pageLimit;
        //        dakListUserParam.page = pages;

        //        var patraJarirApekkaiServicelist = _patraJarirApekkaiService.GetList(dakListUserParam);

        //        if (patraJarirApekkaiServicelist.status == "success")
        //        {
        //            foreach (var item in patraJarirApekkaiServicelist.data.records)
        //            {
        //                CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();

        //                commonKhosraRowUserControl.sharokNo = item.basic.sarok_no;
        //                commonKhosraRowUserControl.sub = item.basic.potro_subject;
        //                commonKhosraRowUserControl.date = item.basic.modified;
        //                commonKhosraRowUserControl.isDraft = v;
        //                UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);

        //            }

        //            totalLabel.Text = "সর্বমোট " + patraJarirApekkaiServicelist.data.total_records.ToString() + " টি";
        //        }
        //        }

        //    private void LoadJarikritaData(bool v,int pages)
        //    {
        //        khosraListTableLayoutPanel.Controls.Clear();
        //        _jarikritaPattraService = new JarikritaPattraService();
        //        //  _userService = new UserService();
        //        //  DakUserParam dakListUserParams = new DakUserParam();
        //        var dakListUserParam = _userService.GetLocalDakUserParam();

        //        // Satic Class
        //        dakListUserParam.limit = pageLimit;
        //        dakListUserParam.page = pages;

        //        var jarikritaPattraServicelist = _jarikritaPattraService.GetList(dakListUserParam);
        //        if(jarikritaPattraServicelist.status== "success")
        //        { 
        //        foreach (var item in jarikritaPattraServicelist.data.records)
        //        {
        //            CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();

        //            commonKhosraRowUserControl.sharokNo = item.basic.sarok_no;
        //            commonKhosraRowUserControl.sub = item.basic.potro_subject;
        //            commonKhosraRowUserControl.date = item.basic.modified;
        //            commonKhosraRowUserControl.isDraft = v;
        //            UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);

        //        }

        //        totalLabel.Text = "সর্বমোট "+ jarikritaPattraServicelist.data.total_records.ToString()+ " টি";
        //        }

        //}

        private void DakModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.DakModuleClick(this);
        }
        private void NothiModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.NothiModuleClick(this);
        }

        private void designationDetailsPanel_Load(object sender, EventArgs e)
        {

        }

        private void nextIconButton_Click(object sender, EventArgs e)
        {
            string endrow;
           
            if (page <= totalPage)
            {
                page += 1;
                start +=  pageLimit;
                end += pageLimit;
                
            }
            else
            {
                page = totalPage;
                start = start;
                end = end;
                
            }
            endrow = end.ToString();
            LoadData( menuNo, page);
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
           
            LoadData( menuNo, page);
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

        private void profileShowArrowButton_Click(object sender, EventArgs e)
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
       
        public bool InternetConnectionTemp;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InternetConnection.Check())
            {

                _syncerServices.SyncLocaltoRemoteData();
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




                    //dakUploadBackgorundWorker.RunWorkerAsync();
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
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (!backgroundWorker1.IsBusy && this.Visible)
            {

                backgroundWorker1.RunWorkerAsync();
            }


        }
        private void KhosraDashboard_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            label7.Text = UIDesignCommonMethod.copyRightLableText;
        }

        private void recycleIconButton_Click(object sender, EventArgs e)
        {
            dakSearchSubTextBox.Text = string.Empty;
            Formload();
        }
      
        private void Formload()
        {
            page = 1;
            start = 1;
            LoadData( menuNo, page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            NextPreviousButtonShow();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }

        private void dakSearchUsingTextButton_Click(object sender, EventArgs e)
        {
            Formload();
        }

        private void searchBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void potrojariButton_Click(object sender, EventArgs e)
        {
            this.Hide();
           
            PotrojariGroupForm potrojariGroup = FormFactory.Create<PotrojariGroupForm>();
          
            potrojariGroup.ShowDialog();
        }
    }
}

using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dNothi.JsonParser.Entity.Nothi.NothiListInboxNoteResponse;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiDecisionList : UserControl
    {
        IUserService _userService { get; set; }
        INothiDecisionListService _nothiDecisionListService { get; set; }
        public NothiDecisionList(IUserService userService, INothiDecisionListService nothiDecisionListService)
        {
            _userService = userService;
            _nothiDecisionListService = nothiDecisionListService;
            InitializeComponent();
            
        }

        private string _labelText;
        public string labelText
        {
            get { return _labelText; }
            set { _labelText = value; lbLabelText.Text = value; }
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
            dakListUserParam.limit = 32;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiDecisionList = _nothiDecisionListService.GetNothiDecisionList(dakListUserParam);
            if (nothiDecisionList != null && nothiDecisionList.Status == "success" )
            {
                if (nothiDecisionList.Data.records.Count > 0) 
                {
                    lbLengthStart.Text = "১";
                    lbLengthEnd.Text = string.Concat(nothiDecisionList.Data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalNothi.Text = " সর্বমোট: " + string.Concat(nothiDecisionList.Data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiInboxinPanel(nothiDecisionList.Data.records);
                }
                
            } else {
                ErrorMessage(nothiDecisionList.Status);
            }
        }
        private void LoadNothiInboxinPanel(List<RecordsDTO> nothiDecisionLists)
        {
            foreach (RecordsDTO nothiDecisionList in nothiDecisionLists)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiDecisionListRow>();
                nothiDecisionListRow.decisionText = nothiDecisionList.decisions;
                nothiDecisionListRow.DecisionAddButton += delegate (object sender1, EventArgs e1) { DecisionAdd_ButtonClick(sender1 as string, e1); };
                UIDesignCommonMethod.AddRowinTable(decisionViewFLP, nothiDecisionListRow);
            }
        }
        public void loadRowAttachments(List<DakUploadedFileResponse> onuchhedSaveWithAttachments)
        {
            if (onuchhedSaveWithAttachments.Count > 0)
            {
                lbLengthStart.Visible = false;
                lbDash.Visible = false;
                lbLengthEnd.Visible = false;
                lbTotalNothi.Text = " সংযুক্তি :( " + string.Concat(onuchhedSaveWithAttachments.Count.ToString().Select(c => (char)('\u09E6' + c - '0')))+" )";
                foreach (DakUploadedFileResponse response in onuchhedSaveWithAttachments)
                {
                    LoadAttachmentinPanel(response.data);
                }
                
            }
            else
            {
                lbLengthStart.Visible = false;
                lbDash.Visible = false;
                lbLengthEnd.Visible = false;
                lbTotalNothi.Text = " সংযুক্তি :( ০ )";
                decisionViewFLP.Controls.Clear();
            }
        }
        private int isNothi;
        public void loadNoteRowAttachments(NoteAttachmentsListResponse onuchhedSaveWithAttachments, int flag)
        {
            isNothi = flag;//1 means nothi, 0 means note
            if (onuchhedSaveWithAttachments.data.total_records > 0)
            {
                lbLengthStart.Visible = false;
                lbDash.Visible = false;
                lbLengthEnd.Visible = false;
                lbTotalNothi.Dock = DockStyle.Left;
                lbTotalNothi.Text = " সংযুক্তি :( " + string.Concat(onuchhedSaveWithAttachments.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')))+" )";
                LoadNoteAttachmentinPanel(onuchhedSaveWithAttachments.data);
                
            }
            else
            {
                lbLengthStart.Visible = false;
                lbDash.Visible = false;
                lbLengthEnd.Visible = false;
                lbTotalNothi.Dock = DockStyle.Left;
                lbTotalNothi.Text = " সংযুক্তি :( ০ )";
                decisionViewFLP.Controls.Clear();
            }
        }
        private void LoadNoteAttachmentinPanel(NoteAttachmentsData Attachments)
        {
            foreach (NoteAttachmentsRecord record in Attachments.records)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiDecisionListRow>();
                nothiDecisionListRow.decisionText = record.user_file_name;
                nothiDecisionListRow.shongjuktiURL = record.url;
                nothiDecisionListRow.attachmentKilobyte = record.file_size_in_kb.ToString();
                nothiDecisionListRow.setbtnDecisionIcon();
                //nothiDecisionListRow.AttachmentAddButton += delegate (object sender1, EventArgs e1) { AttachmentAdd_ButtonClick(sender1 as DakAttachmentDTO, e1); };
                UIDesignCommonMethod.AddRowinTable(decisionViewFLP, nothiDecisionListRow);
            }
        }
        private void LoadAttachmentinPanel(List<DakAttachmentDTO> Attachments)
        {
            foreach (DakAttachmentDTO record in Attachments)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiDecisionListRow>();
                nothiDecisionListRow.decisionText = record.user_file_name;
                nothiDecisionListRow.shongjuktiURL = record.url;
                nothiDecisionListRow.AttachmentAddButton += delegate (object sender1, EventArgs e1) { AttachmentAdd_ButtonClick(sender1 as DakAttachmentDTO, e1); };
                UIDesignCommonMethod.AddRowinTable(decisionViewFLP, nothiDecisionListRow);
            }
        }
        public void loadPotaka(string nothi_id, string note_id)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 32;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiPotakaList = _nothiDecisionListService.GetNothiPotakaList(dakListUserParam, nothi_id, note_id);
            if (nothiPotakaList != null && nothiPotakaList.status == "success")
            {
                if (nothiPotakaList.data.records.Count > 0)
                {
                    lbLengthStart.Text = "১";
                    lbLengthEnd.Text = string.Concat(nothiPotakaList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalNothi.Text = " সর্বমোট: " + string.Concat(nothiPotakaList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiPotakainTLP(nothiPotakaList.data.records);
                }

            }
            else
            {
                //ErrorMessage(nothiPotakaList.status);
            }
        }
        private void LoadNothiPotakainTLP(List<PotakaListRecord> Records)
        {
            foreach (PotakaListRecord record in Records)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiDecisionListRow>();
                nothiDecisionListRow.decisionText = record.title;
                nothiDecisionListRow.potakaURL = record.attachment.url;
                nothiDecisionListRow.setPotakaColor(record.color);
                nothiDecisionListRow.PotakaAddButton += delegate (object sender1, EventArgs e1) { PotakaAdd_ButtonClick(sender1, e1, record); };
                UIDesignCommonMethod.AddRowinTable(decisionViewFLP, nothiDecisionListRow);
            }
        }
        public void loadOnuchhed(string nothi_id)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 32;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiOnuchhedList = _nothiDecisionListService.GetNothiOnuchhedList(dakListUserParam, nothi_id);
            if (nothiOnuchhedList != null && nothiOnuchhedList.status == "success")
            {
                if (nothiOnuchhedList.data.Count > 0)
                {
                    lbLengthStart.Visible = false;
                    lbLengthEnd.Visible = false;
                    lbTotalNothi.Visible = false;
                    lbDash.Visible = false;
                    LoadNothiOnuchhedTLP(nothiOnuchhedList.data);
                }

            }
            else
            {
                ErrorMessage(nothiOnuchhedList.status);
            }
        }
        private void LoadNothiOnuchhedTLP(List<OnuchhedListData> Records)
        {
            
            foreach (OnuchhedListData record in Records)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiDecisionListRow>();
                nothiDecisionListRow.setLabelColorForOnuchhedList();
                
                if (record.onucched_id == 0) 
                {
                    nothiDecisionListRow.decisionText = "অনুচ্ছেদ " + string.Concat(record.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')))+".*";
                }
                else
                {
                    string str = record.value;
                    string target = ".";
                    char[] anyOf = target.ToCharArray();
                    int at = str.IndexOfAny(anyOf);
                    nothiDecisionListRow.setPaddingForOnuchhedList();
                    nothiDecisionListRow.decisionText = "অনুচ্ছেদ " + string.Concat(record.note_no.ToString().Select(c => (char)('\u09E6' + c - '0'))) +"."+ string.Concat(record.value.ToString().Substring(at+1).Select(c => (char)('\u09E6' + c - '0')));
                }
                nothiDecisionListRow.OnuchhedAddButton += delegate (object sender1, EventArgs e1) { OnuchhedAdd_ButtonClick(sender1 as string, e1); };
                UIDesignCommonMethod.AddRowinTable(decisionViewFLP, nothiDecisionListRow);
            }
        }
        public event EventHandler PotakaAdd;
        private void PotakaAdd_ButtonClick(object sender, EventArgs e1, PotakaListRecord record)
        {
            if (this.PotakaAdd != null)
                this.PotakaAdd(record, e1);
        }
        public event EventHandler DecisionText;
        private void DecisionAdd_ButtonClick(string test, EventArgs e1)
        {
            if (this.DecisionText != null)
                this.DecisionText(test, e1);
        }
        public event EventHandler AttachmentAdd;
        private void AttachmentAdd_ButtonClick(DakAttachmentDTO record, EventArgs e1)
        {
            if (this.AttachmentAdd != null)
                this.AttachmentAdd(record, e1);
        }
        public event EventHandler OnuchhedAdd;
        private void OnuchhedAdd_ButtonClick(string text, EventArgs e1)
        {
            if (this.OnuchhedAdd != null)
                this.OnuchhedAdd(text, e1);
        }
        private void btnNothiDecisionListCross_Click(object sender, EventArgs e)
        {
            if (isNothi == 1)
            {
                List<Form> openForms = new List<Form>();

                foreach (Form f in Application.OpenForms)
                    openForms.Add(f);

                foreach (Form f in openForms)
                {
                    if (f.Name != "Nothi")
                        f.Close();
                }
            } else
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

            
        }
    }
}

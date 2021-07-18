using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
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
                if (nothiDecisionList.Data.Records.Count > 0) 
                {
                    lbLengthStart.Text = "১";
                    lbLengthEnd.Text = string.Concat(nothiDecisionList.Data.TotalRecords.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalNothi.Text = " সর্বমোট: " + string.Concat(nothiDecisionList.Data.TotalRecords.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiInboxinPanel(nothiDecisionList.Data.Records);
                }
                
            } else {
                ErrorMessage(nothiDecisionList.Status);
            }
        }
        private void LoadNothiInboxinPanel(Dictionary<string, string> nothiDecisionLists)
        {
            foreach (KeyValuePair<string, string> nothiDecisionList in nothiDecisionLists)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiDecisionListRow>();
                nothiDecisionListRow.decisionText = nothiDecisionList.Value.ToString();
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
        private void LoadAttachmentinPanel(List<DakAttachmentDTO> Attachments)
        {
            foreach (DakAttachmentDTO record in Attachments)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiDecisionListRow>();
                nothiDecisionListRow.decisionText = record.user_file_name;
                nothiDecisionListRow.URL = record.url;
                nothiDecisionListRow.AttachmentAddButton += delegate (object sender1, EventArgs e1) { AttachmentAdd_ButtonClick(sender1 as DakAttachmentDTO, e1); };
                UIDesignCommonMethod.AddRowinTable(decisionViewFLP, nothiDecisionListRow);
            }
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
        private void btnNothiDecisionListCross_Click(object sender, EventArgs e)
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

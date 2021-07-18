using dNothi.Desktop.UI.CustomMessageBox;
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

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiGaurdFileList : UserControl
    {
        IUserService _userService { get; set; }
        INothiDecisionListService _nothiDecisionListService { get; set; }
        public NothiGaurdFileList(IUserService userService, INothiDecisionListService nothiDecisionListService)
        {
            _userService = userService;
            _nothiDecisionListService = nothiDecisionListService;
            InitializeComponent();
            loadRow();
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
    }
}

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
            loadRow();
        }
        public void loadRow()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 32;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiDecisionList = _nothiDecisionListService.GetNothiDecisionList(dakListUserParam);
            if (nothiDecisionList != null && nothiDecisionList.Status == "success")
            {
                LoadNothiInboxinPanel(nothiDecisionList.Data.Records);
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
        public event EventHandler DecisionText;
        private void DecisionAdd_ButtonClick(string test, EventArgs e1)
        {
            if (this.DecisionText != null)
                this.DecisionText(test, e1);
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

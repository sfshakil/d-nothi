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
    public partial class NothiBibechhoPotroList : UserControl
    {
        IUserService _userService { get; set; }
        INothiDecisionListService _nothiDecisionListService { get; set; }
        public NothiBibechhoPotroList(IUserService userService, INothiDecisionListService nothiDecisionListService)
        {
            _userService = userService;
            _nothiDecisionListService = nothiDecisionListService;
            InitializeComponent();
            //loadRow();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        private string _nothi_id;
        [Category("Custom Props")]
        public string nothi_id
        {
            get { return _nothi_id; }
            set { _nothi_id = value; }
        }
        public void loadRow()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 74;
            dakListUserParam.page = 1;
            var token = _userService.GetToken();
            var nothiBibechhoPotroList = _nothiDecisionListService.GetNothiBibechhoPotroList(dakListUserParam, _nothi_id);
            if (nothiBibechhoPotroList != null && nothiBibechhoPotroList.status == "success")
            {
                if (nothiBibechhoPotroList.data.records.Count > 0)
                {
                    lbLengthStart.Text = "১";
                    lbLengthEnd.Text = string.Concat(nothiBibechhoPotroList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalBibechhoPotro.Text = " সর্বমোট: " + string.Concat(nothiBibechhoPotroList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    LoadNothiInboxinPanel(nothiBibechhoPotroList.data.records);
                }

            }
            else
            {
                ErrorMessage(nothiBibechhoPotroList.status);
            }
        }
        private void LoadNothiInboxinPanel(List<BibechhoPotroRecord> records)
        {
            foreach (BibechhoPotroRecord record in records)
            {
                var nothiBibechhoPotroListRow = UserControlFactory.Create<NothiBibechhoPotroListRow>();
                nothiBibechhoPotroListRow.potroName = record.basic.subject;
                nothiBibechhoPotroListRow.potroNumber = record.basic.sarok_no;
                nothiBibechhoPotroListRow.potroDate = record.basic.created;
                nothiBibechhoPotroListRow.potroNote = record.note_owner.note_no.ToString();
                nothiBibechhoPotroListRow.mulpotroURL = record.mulpotro.url;
                nothiBibechhoPotroListRow.GaurdFileAddButton += delegate (object sender1, EventArgs e1) { BibechhoPotroAdd_ButtonClick(sender1 , e1, record); };
                UIDesignCommonMethod.AddRowinTable(bibechhoPotroViewFLP, nothiBibechhoPotroListRow);
            }
        }
        public event EventHandler BibechhoPotroRecord;
        private void BibechhoPotroAdd_ButtonClick(object sender, EventArgs e, BibechhoPotroRecord record)
        {
            if (this.BibechhoPotroRecord != null)
                this.BibechhoPotroRecord(record, e);
        }
        private void btnNothiBibechhoPotroListCross_Click(object sender, EventArgs e)
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

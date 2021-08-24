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
    public partial class NothiALLDecisionList : UserControl
    {
        IUserService _userService { get; set; }
        INothiDecisionListService _nothiDecisionListService { get; set; }
        public NothiALLDecisionList(IUserService userService, INothiDecisionListService nothiDecisionListService)
        {
            _userService = userService;
            _nothiDecisionListService = nothiDecisionListService;
            InitializeComponent();
            NewDecisionListAddPanel.Visible = false;
        }

        private void panel67_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void btnNewDecision_Click(object sender, EventArgs e)
        {
            NewDecisionListAddPanel.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnNewDecision.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSubject.Text = "";
            cbxdecisions_employee.Checked = false;
            NewDecisionListAddPanel.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnNewDecision.Visible = true;
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        int totalDecisionList = 0;
        int pageNumber = 0;
        public void loadRow()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            dakListUserParam.page = pageNumber = 1;
            var token = _userService.GetToken();
            var nothiDecisionList = _nothiDecisionListService.GetNothiALLDecisionList(dakListUserParam);
            if (nothiDecisionList != null && nothiDecisionList.Status == "success")
            {
                if (nothiDecisionList.Data.records.Count > 0)
                {
                    lbLengthStart.Text = "১";
                    lbLengthEnd.Text = string.Concat(nothiDecisionList.Data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotalBibechhoPotro.Text = " সর্বমোট: " + string.Concat(nothiDecisionList.Data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    totalDecisionList = nothiDecisionList.Data.total_records;
                    LoadNothiInboxinPanel(nothiDecisionList.Data.records,1);
                }

            }
            else
            {
                ErrorMessage(nothiDecisionList.Status);
            }
        }
        private void LoadNothiInboxinPanel(List<RecordsDTO> nothiDecisionLists, int startingSerialnumber)
        {
            bibechhoPotroViewFLP.Controls.Clear();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            foreach (RecordsDTO nothiDecisionList in nothiDecisionLists)
            {
                var nothiDecisionListRow = UserControlFactory.Create<NothiALLDecisionListRow>();
                nothiDecisionListRow.decision = nothiDecisionList.decisions;
                nothiDecisionListRow.serialNo = startingSerialnumber;
                nothiDecisionListRow.NothiDecisionDeleteButton += delegate (object sender1, EventArgs e1) { NothiDecisionDelete_ButtonClick(nothiDecisionList, e1); };
                nothiDecisionListRow.NothiDecisionEditButton += delegate (object sender1, EventArgs e1) { NothiDecisionEdit_ButtonClick(sender1 as RecordsDTO, nothiDecisionList, e1); };
                nothiDecisionListRow.cbxDecisionList(nothiDecisionList.decisions_employee);
                if (nothiDecisionList.officer_id != dakListUserParam.officer_id)
                {
                    nothiDecisionListRow.visibility_off_cbx_edit_dlt();
                }
                else
                {
                    nothiDecisionListRow.visibility_on_cbx_edit_dlt();
                }
                if (startingSerialnumber % 2 != 0)
                    nothiDecisionListRow.BackColor = Color.FromArgb(243, 246, 249);
                UIDesignCommonMethod.AddRowinTable(bibechhoPotroViewFLP, nothiDecisionListRow);
                startingSerialnumber++;
            }
        }
        
        private void btnNothiDecisionListCross_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name == "ExtraPopUPWindow")
                    f.Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageNumber * 10 < totalDecisionList)
            {
                lbLengthStart.Text = string.Concat((pageNumber * 10 + 1).ToString().Select(c => (char)('\u09E6' + c - '0')));

                pageNumber++;
                
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.page = pageNumber;
                dakListUserParam.limit = 10;
                var nothiNoteTalika = _nothiDecisionListService.GetNothiALLDecisionList(dakListUserParam);
                if (nothiNoteTalika.Status == "success")
                {
                    if (nothiNoteTalika.Data.records.Count > 0)
                    {
                        int flag = pageNumber - 1;
                        int flag1 = flag * 10;
                        int flag2 = nothiNoteTalika.Data.records.Count;
                        lbLengthEnd.Text = string.Concat((flag1 + flag2).ToString().Select(c => (char)('\u09E6' + c - '0')));
                        bibechhoPotroViewFLP.Controls.Clear();
                        LoadNothiInboxinPanel(nothiNoteTalika.Data.records, flag1 + 1);

                    }
                }

            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {


                pageNumber--;

                if (pageNumber == 1)
                {
                    lbLengthStart.Text = string.Concat((pageNumber * 10 - 10 + 1).ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                else
                {
                    lbLengthStart.Text = string.Concat((pageNumber * 10 - 10 + 1).ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                lbLengthEnd.Text = string.Concat((pageNumber * 10).ToString().Select(c => (char)('\u09E6' + c - '0')));
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.page = pageNumber;
                dakListUserParam.limit = 10;
                var nothiDecisionList = _nothiDecisionListService.GetNothiALLDecisionList(dakListUserParam);
                if (nothiDecisionList != null && nothiDecisionList.Status == "success")
                {
                    if (nothiDecisionList.Data.records.Count > 0)
                    {
                        bibechhoPotroViewFLP.Controls.Clear();
                        LoadNothiInboxinPanel(nothiDecisionList.Data.records, (pageNumber * 10 - 9));
                    }

                }
            }
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
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtSubject.Text != "")
            {
                string decisions = txtSubject.Text;
                int decisions_employee = 0;

                if (cbxdecisions_employee.Checked == true)
                {
                    decisions_employee = 1;
                }
                else
                {
                    decisions_employee = 0;
                }
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                var saveResponse = _nothiDecisionListService.GetNothiAddDecisionList(dakListUserParam, decisions, decisions_employee, 0);
                if (saveResponse.status == "success")
                {
                    SuccessMessage("নথি সিদ্ধান্ত সংরক্ষণ হয়েছে");
                    btnCancel_Click(null, null);
                    loadRow();
                }
            }
            else
            {
                ErrorMessage("দুঃখিত! নথি সিদ্ধান্ত সংরক্ষন করা সম্ভব হচ্ছে না।");
            }
        }
        private void NothiDecisionDelete_ButtonClick(RecordsDTO nothiDecisionList, EventArgs e)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var saveResponse = _nothiDecisionListService.GetNothiDeleteDecisionList(dakListUserParam, nothiDecisionList.id);
            if (saveResponse.status == "success")
            {
                SuccessMessage("নথি সিদ্ধান্ত মুছে ফেলা হয়েছে।");
                loadRow();
            }
            else
            {
                ErrorMessage(saveResponse.status);
            }
        }
        private void NothiDecisionEdit_ButtonClick(RecordsDTO EditedRecord, RecordsDTO nothiDecisionList, EventArgs e)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var saveResponse = _nothiDecisionListService.GetNothiAddDecisionList(dakListUserParam, EditedRecord.decisions, EditedRecord.decisions_employee, nothiDecisionList.id);
            if (saveResponse.status == "success")
            {
                SuccessMessage("নথি সিদ্ধান্ত হালনাগাদ করা হয়েছে।");
                btnCancel_Click(null, null);
                loadRow();
            }
        }
    }
}

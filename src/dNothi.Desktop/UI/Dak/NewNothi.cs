using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.AccountServices;
using dNothi.Services.DakServices;
using java.lang;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Utility;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NewNothi : UserControl
    {
        IUserService _userService { get; set; }
        INothiCreateService _nothiCreateServices { get; set; }
        INothiTypeListServices _nothiType { get; set; }
        INothiNoteTalikaServices _nothiNoteTalikaService { get; set; }
        IAccountService _accountService { get; set; }
        public NewNothi(IUserService userService, INothiTypeListServices nothiType, IAccountService accountService, INothiNoteTalikaServices nothiNoteTalikaService, INothiCreateService nothiCreateServices)
        {
            _userService = userService;
            _nothiType = nothiType;
            _accountService = accountService;
            _nothiNoteTalikaService = nothiNoteTalikaService;
            _nothiCreateServices = nothiCreateServices;
            InitializeComponent();
            LoadNothiTypeListDropDown();
            SetDefaultFont(this.Controls);
            nothiTalikaPnl.Visible = false;

        }
        private void cbxNothiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNothilast4digitText.Visible = false;
            lbNothiNoText.Visible = false;
            nothiTalikaPnl.Visible = true;
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            nothiTalikaPnl.Visible = true;
            int i = cbxNothiType.SelectedIndex;
            var nothi_type_code = nothi_type_codes[i];
            var nothi_type_id = ids[i];
            var token = _userService.GetToken();
            var nothiNoteTalika = _nothiNoteTalikaService.GetNothiNoteTalika(dakListUserParam, Convert.ToString(nothi_type_id));
            var nothinumber = _nothiNoteTalikaService.GetNothiNumber(dakListUserParam, Convert.ToString(nothi_type_id));

            if (nothiNoteTalika.status == "success" && nothinumber.status == "success")
            {
                if (nothiNoteTalika.data.records.Count > 0)
                {
                    pnlNoData.Visible = false;
                    nothiTalikaFlowLayoutPnl.Visible = true;
                    string code = nothinumber.data.ToString().Substring(0, 18);//"৫৬.৪২.০০০০.০১০." + string.Concat(nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ".";
                    string nothi4Digit = nothinumber.data.ToString().Substring(18, 4);
                    LoadNothiNoteTalikaListinPanel(nothiNoteTalika.data.records, code, nothi4Digit);


                }
                else
                {
                    pnlNoData.Visible = true;
                    nothiTalikaFlowLayoutPnl.Visible = false;
                    nothiTalikaFlowLayoutPnl.Controls.Clear();
                    lbNothiNo.Text = nothinumber.data.ToString().Substring(0, 18);//"৫৬.৪২.০০০০.০১০." + string.Concat(nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ".";
                    lbNothilast4digit.Text = nothinumber.data.ToString().Substring(18, 4);//"০০১.";
                    lbTotalNote.Text = " সর্বমোট: ০";
                }
                loadLast2digitNothiNo();

            }
        }
        public void loadNewNothiPage()
        {
            cbxNothiType.Text = "বাছাই করুন";
            lbNothilast4digitText.Visible = true;
            lbNothiNoText.Visible = true;
            lbNothiNo.Text = "";
            lbNothiNoText.Text = "**.**.****.***.**.";
            lbNothilast4digitText.Text = "***.**";
            lbNothilast4digit.Text = "";
            cbxLast2digitNothiNo.Text = "বাছাই করুন";
            cbxNothiClass.Text = "বাছাই করুন";
            nothiTalikaPnl.Visible = false;
            txtNothiSubject.Text = "";
            txtNothiSubject.PlaceholderText = "নথির বিষয়";
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
        public int[] ids;
        public string[] nothi_type_codes;
        public string[] nothiNoteNos;
        public void LoadNothiTypeListDropDown()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var token = _userService.GetToken();
            var nothiType = _nothiType.GetNothiTypeList(dakListUserParam);
            int i = 0;
            if (nothiType != null && nothiType.status == "success")
            {
                lbNothiShakha.Text = _userService.GetOfficeInfo().unit_name_bn;

                if (nothiType.data.Count > 0)
                {
                    string[] playerNames = new string[nothiType.data.Count];
                    int[] id = new int[nothiType.data.Count];
                    string[] nothi_type_code = new string[nothiType.data.Count];
                    foreach (NothiTypeListDTO nothiTypeListDTO in nothiType.data)
                    {
                        id[i] = nothiTypeListDTO.id;
                        nothi_type_code[i] = nothiTypeListDTO.nothi_type_code;
                        cbxNothiType.Items.Add(nothiTypeListDTO.nothi_type);
                        cbxNothiType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbxNothiType.AutoCompleteSource = AutoCompleteSource.ListItems;
                        playerNames[i] = nothiTypeListDTO.nothi_type;
                        i++;

                    }
                    nothi_type_codes = nothi_type_code;
                    ids = id;
                    searchOfficeDetailSearch.listboxcollection = playerNames;

                }
            }
        }
        private void loadLast2digitNothiNo()
        {
            cbxLast2digitNothiNo.Items.Clear();
            string initialYear = "1971";
            int i = 0;
            var currentYear = DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4);
            for (int j = Convert.ToInt32(initialYear); j <= Convert.ToInt32(currentYear); j++)
            {
                cbxLast2digitNothiNo.Items.Add(string.Concat(j.ToString().Substring(2, 2).ToString().Select(c => (char)('\u09E6' + c - '0'))));
                i++;
            }
            cbxLast2digitNothiNo.SelectedIndex = i - 1;
        }

        private void btnGuidelines_Click(object sender, EventArgs e)
        {
            //NothiGuidelines nothiGuidelines = new NothiGuidelines();
            //nothiGuidelines.Visible = true;
            //nothiGuidelines.Location = new System.Drawing.Point(0,0);
            //Controls.Add(nothiGuidelines);
            //nothiGuidelines.BringToFront();

            var nothiGuidelines = UserControlFactory.Create<NothiGuidelines>();
            nothiGuidelines.Visible = true;
            nothiGuidelines.Enabled = true;
            nothiGuidelines.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //nothiGuidelines.Location = new System.Drawing.Point(0, 0);
            var nothiTypeform = AttachNothiGuidelinesControlToForm(nothiGuidelines);
            CalPopUpWindow(nothiTypeform);
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
        public Form AttachNothiGuidelinesControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            //form.Location = new System.Drawing.Point(100, 100);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        public Form AttachNothiTypeListControlToForm(Control control)
        {
            Form form = new Form();
            //form.Dock = System.Windows.Forms.DockStyle.Right;
            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            //var nothi = FormFactory.Create<Nothi>();
            form.AutoSize = true;
            form.Location = new System.Drawing.Point(this.Width - control.Width + this.Location.X, 0);//(nothi.Height - nothi.ClientSize.Height) / 2);
            control.Location = new System.Drawing.Point(0, 0);
            //form.Size = control.Size;
            form.Height = Screen.PrimaryScreen.WorkingArea.Height;
            form.Width = control.Width;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Height = form.Height;
            form.Controls.Add(control);
            return form;
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();

            hideform.BackColor = Color.Black;
            hideform.Height = Screen.PrimaryScreen.WorkingArea.Height; //{Width = 1382 Height = 744}
            hideform.Width = Screen.PrimaryScreen.WorkingArea.Width; //{Width = 1382 Height = 744}
            hideform.Opacity = .4;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        private void btnNothiTypeList_Click_1(object sender, EventArgs e)
        {
            var nothiType = UserControlFactory.Create<NothiType>();
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType.Location = new System.Drawing.Point(845, 0);
            var nothiTypeform = AttachNothiTypeListControlToForm(nothiType);
            CalPopUpWindow(nothiTypeform);
        }

        private void btnNothiTypeList_MouseHover(object sender, EventArgs e)
        {
            btnNothiTypeList.BackColor = Color.Orange;
            btnNothiTypeList.FlatAppearance.BorderColor = Color.Orange;
            btnNothiTypeList.ForeColor = Color.FromArgb(243, 246, 249);
            btnNothiTypeList.IconColor = Color.FromArgb(243, 246, 249);
        }

        private void btnNothiTypeList_MouseLeave(object sender, EventArgs e)
        {
            btnNothiTypeList.BackColor = Color.Transparent;
            btnNothiTypeList.ForeColor = Color.FromArgb(255, 168, 0);
            btnNothiTypeList.FlatAppearance.BorderColor = Color.FromArgb(255, 168, 0);
            btnNothiTypeList.IconColor = Color.FromArgb(255, 168, 0);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void lbNothiShakha_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void label14_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);

        }

        private void panel11_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);

        }

        private void searchOfficeDetailSearch_Click(object sender, EventArgs e)
        {

        }
        private void LoadNothiNoteTalikaListinPanel(List<NothiNoteTalikaRecordsDTO> nothiNotetalikaLists, string code, string nothi4digit)
        {
            nothiTalikaFlowLayoutPnl.Controls.Clear();
            List<NothiTalika> nothiTalikas = new List<NothiTalika>();
            int i = 0;
            int flaguse = 0;
            int[] flag = new int[nothiNotetalikaLists.Count + 1];
            string[] nothiNoteNo = new string[nothiNotetalikaLists.Count];
            foreach (NothiNoteTalikaRecordsDTO NothiNoteTalikaListDTO in nothiNotetalikaLists)
            {
                //if (code == NothiNoteTalikaListDTO.nothi_no.Substring(0, 18))
                //{
                pnlNoData.Visible = false;
                flaguse++;
                NothiTalika nothiTalika = new NothiTalika();
                nothiTalika.nothi = NothiNoteTalikaListDTO.nothi_no + " " + NothiNoteTalikaListDTO.subject;
                nothiTalika.shakha = NothiNoteTalikaListDTO.office_unit;
                nothiTalika.nothi_last_date = NothiNoteTalikaListDTO.created;

                nothiNoteNo[i] = NothiNoteTalikaListDTO.nothi_no;
                int totalnote = nothiNotetalikaLists.Count + 1;
                lbNothiNo.Text = code;
                //string value =   totalnote.ToString("000");
                //lbNothilast4digit.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')))+".";//NothiNoteTalikaListDTO.nothi_no.Substring(18, 4);
                string english_text = string.Concat(NothiNoteTalikaListDTO.nothi_no.Select(c => (char)('0' + c - '\u09E6')));
                i = i + 1;
                nothiTalika.permitted = Convert.ToString(NothiNoteTalikaListDTO.permitted);
                UIDesignCommonMethod.AddRowinTable(nothiTalikaFlowLayoutPnl, nothiTalika);


                //var currentYear = DateTime.Now.ToString("yy");
                //if (english_text.Substring(22, 2) == currentYear)
                //{
                //    int num;
                //    if (int.TryParse(english_text.Substring(18, 3), out num))
                //    {
                //        string w = english_text.Substring(18, 3);
                //        flag[i] = Integer.parseInt(english_text.Substring(18, 3));
                //    }
                //}
                //int max = flag.Max() + 1;
                //string value = max.ToString("000");
                lbNothilast4digit.Text = nothi4digit;
                //}
                //if (flaguse == 0)
                //{
                //    pnlNoData.Visible = true;
                //    lbNothiNo.Text = code;
                //    lbNothilast4digit.Text = "০০১.";
                //}
            }
            lbTotalNote.Text = "সর্বমোট: " + string.Concat(i.ToString().Select(c => (char)('\u09E6' + c - '0')));
            nothiNoteNos = nothiNoteNo;
            
        }

        private void btnNothiSave_Click(object sender, EventArgs e)
        {
            if (cbxNothiType.Text == "বাছাই করুন" || lbNothilast4digit.Text == "***.**")
            {
                ErrorMessage("দুঃখিত! নথির ধরন ফাকা রাখা যাবে না।");
            }
            else if (cbxNothiClass.Text == "বাছাই করুন")
            {
                ErrorMessage("দুঃখিত! নথির শ্রেণি ফাকা রাখা যাবে না।");
            }
            else if (txtNothiSubject.Text == "")
            {
                ErrorMessage("দুঃখিত! নথির বিষয় ফাকা রাখা যাবে না।");
            }
            else
            {
                createNothi();
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
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        public void createNothi()
        {
            DakUserParam UserParam = _userService.GetLocalDakUserParam();
            var nothishkha = lbNothiShakha.Text;
            var nothi_no = lbNothiNo.Text + lbNothilast4digit.Text + cbxLast2digitNothiNo.SelectedItem;
            var nothi_type_id = nothi_type_codes[cbxNothiType.SelectedIndex];
            var nothi_subject = txtNothiSubject.Text;
            string nothiclass = "0";

            if (cbxNothiClass.SelectedItem == "ঘ")
                nothiclass = "4";
            else if (cbxNothiClass.SelectedItem == "গ")
                nothiclass = "3";
            else if (cbxNothiClass.SelectedItem == "খ")
                nothiclass = "2";
            else if (cbxNothiClass.SelectedItem == "ক")
                nothiclass = "1";

            var nothi_class = nothiclass;
            var currentYear = DateTime.Now.ToString("yyyy-MM-dd");
            NothiCreateResponse nothiCreate = _nothiCreateServices.GetNothiCreate(UserParam, nothishkha, nothi_no, nothi_type_id, nothi_subject, nothi_class, currentYear);
            if (!InternetConnection.Check())
            {
                if (nothiCreate.status == "success" && nothiCreate.message == "Local")
                {
                    foreach (Form f in Application.OpenForms)
                    { f.Hide(); }
                    var form = FormFactory.Create<Nothi>();
                    form.ForceLoadNothiALL();
                    form.ShowDialog();
                }
            }
            else
            {
                if (nothiCreate.status == "success")
                {
                    var form = FormFactory.Create<NothiCreateNextStep>();
                    form.loadNewNothiInfo(nothiCreate.data);
                    CalPopUpWindow(form);
                }
                else
                    SuccessMessage(nothiCreate.message);
            }
        }

        private void lbNothilast4digit_MouseClick(object sender, MouseEventArgs e)
        {
            lbNothilast4digitText.Visible = false;
        }

        private void lbNothilast4digit_MouseLeave(object sender, EventArgs e)
        {
            lbNothilast4digitText.Visible = true;
        }
    }
}

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
            if (nothiType!=null && nothiType.status == "success")
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
            cbxLast2digitNothiNo.SelectedIndex = i-1;
        }

        private void btnGuidelines_Click(object sender, EventArgs e)
        {
            NothiGuidelines nothiGuidelines = new NothiGuidelines();
            nothiGuidelines.Visible = true;
            nothiGuidelines.Location = new System.Drawing.Point(0,0);
            Controls.Add(nothiGuidelines);
            nothiGuidelines.BringToFront();
        }

        private void btnNothiTypeList_Click_1(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            { f.Hide(); }
            var form = FormFactory.Create<Nothi>();
            form.ForceLoadNewNothi();
            var nothiType = UserControlFactory.Create<NothiType>();
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType.Location = new System.Drawing.Point(845, 0);
            form.Controls.Add(nothiType);
            nothiType.BringToFront();
            form.ShowDialog();
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

        private void cbxNothiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            nothiTalikaPnl.Visible = true;
            int i = cbxNothiType.SelectedIndex;
            var nothi_type_code = nothi_type_codes[i];
            var nothi_type_id = ids[i];
            var token = _userService.GetToken();
            var nothiNoteTalika = _nothiNoteTalikaService.GetNothiNoteTalika(dakListUserParam, Convert.ToString(nothi_type_id));
            if (nothiNoteTalika.status == "success")
            {
                if (nothiNoteTalika.data.records.Count > 0)
                {
                    
                    LoadNothiNoteTalikaListinPanel(nothiNoteTalika.data.records);
                    lbTotalNote.Text = "সর্বমোট: " + string.Concat(nothiNoteTalika.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    
                }
                else
                {
                    nothiTalikaFlowLayoutPnl.Controls.Clear();
                    lbNothiNo.Text = "৫৬.৪২.০০০০.০১০." + string.Concat(nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0')))+".";
                    lbNothilast4digit.Text = "০০১.";
                }
                loadLast2digitNothiNo();

            }
        }
        private void LoadNothiNoteTalikaListinPanel(List<NothiNoteTalikaRecordsDTO> nothiNotetalikaLists)
        {
            List<NothiTalika> nothiTalikas = new List<NothiTalika>();
            int i = 0;
            int[] flag= new int[nothiNotetalikaLists.Count+1];
            string[] nothiNoteNo = new string[nothiNotetalikaLists.Count];
            foreach (NothiNoteTalikaRecordsDTO NothiNoteTalikaListDTO in nothiNotetalikaLists)
            {
                NothiTalika nothiTalika = new NothiTalika();
                nothiTalika.nothi = NothiNoteTalikaListDTO.nothi_no + " " + NothiNoteTalikaListDTO.subject;
                nothiTalika.shakha = NothiNoteTalikaListDTO.office_unit;
                nothiTalika.nothi_last_date = NothiNoteTalikaListDTO.created;
                
                nothiNoteNo[i] = NothiNoteTalikaListDTO.nothi_no;
                int totalnote = nothiNotetalikaLists.Count+1;
                lbNothiNo.Text = NothiNoteTalikaListDTO.nothi_no.Substring(0,18);
                //string value =   totalnote.ToString("000");
                //lbNothilast4digit.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')))+".";//NothiNoteTalikaListDTO.nothi_no.Substring(18, 4);
                string english_text = string.Concat(NothiNoteTalikaListDTO.nothi_no.Select(c => (char)('0' + c - '\u09E6')));
                i = i + 1;
                nothiTalika.permitted = Convert.ToString(NothiNoteTalikaListDTO.permitted);
                nothiTalikas.Add(nothiTalika);


                var currentYear = DateTime.Now.ToString("yy");
                if (english_text.Substring(22, 2) == currentYear)
                {
                    flag[i]= Integer.parseInt(english_text.Substring(18, 3));
                }
                int max = flag.Max()+1;
                string value = max.ToString("000");
                lbNothilast4digit.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ".";
            }
            nothiNoteNos = nothiNoteNo;
            nothiTalikaFlowLayoutPnl.Controls.Clear();
            nothiTalikaFlowLayoutPnl.AutoScroll = true;
            nothiTalikaFlowLayoutPnl.FlowDirection = FlowDirection.TopDown;
            nothiTalikaFlowLayoutPnl.WrapContents = false;
            
            for (int j = 0; j <= nothiTalikas.Count - 1; j++)
            {
                nothiTalikaFlowLayoutPnl.Controls.Add(nothiTalikas[j]);
            }
        }

        private void btnNothiSave_Click(object sender, EventArgs e)
        {
            if(cbxNothiType.Text== "বাছাই করুন" || lbNothilast4digit.Text == "***.**")
            {
                MessageBox.Show("দুঃখিত! নথির ধরন ফাকা রাখা যাবে না।");
            }
            else if (cbxNothiClass.Text == "বাছাই করুন")
            {
                MessageBox.Show("দুঃখিত! নথির শ্রেণি ফাকা রাখা যাবে না।");
            }
            else if (txtNothiSubject.Text == "")
            {
                MessageBox.Show("দুঃখিত! নথির বিষয় ফাকা রাখা যাবে না।");
            }
            else
            {
                createNothi();
            }
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
            var nothiCreate =  _nothiCreateServices.GetNothiCreate(UserParam, nothishkha, nothi_no, nothi_type_id, nothi_subject, nothi_class, currentYear);
            if (nothiCreate.status == "success")
            {
                
                var form = FormFactory.Create<NothiCreateNextStep>();
                //form.Location = new System.Drawing.Point(108, 219);
                form.BringToFront();
                form.ShowDialog();
                
            }
            else
                MessageBox.Show("নথি  নম্বর  ইতিমধ্যে  বিদ্যমান");


        }

    }
}

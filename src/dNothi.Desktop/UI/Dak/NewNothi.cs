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

namespace dNothi.Desktop.UI.Dak
{
    public partial class NewNothi : UserControl
    {
        IUserService _userService { get; set; }
        INothiTypeListServices _nothiType { get; set; }
        INothiNoteTalikaServices _nothiNoteTalikaService { get; set; }
        IAccountService _accountService { get; set; }
        public NewNothi(IUserService userService, INothiTypeListServices nothiType, IAccountService accountService, INothiNoteTalikaServices nothiNoteTalikaService)
        {
            _userService = userService;
            _nothiType = nothiType;
            _accountService = accountService;
            _nothiNoteTalikaService = nothiNoteTalikaService;
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
        private void LoadNothiTypeListDropDown()
        {
            var token = _userService.GetToken();
            var nothiType = _nothiType.GetNothiTypeList(token);
            int i = 0;
            if (nothiType!=null && nothiType.status == "success")
            {
                if (nothiType.data.Count > 0)
                {
                    string[] playerNames = new string[nothiType.data.Count];
                    int[] id = new int[nothiType.data.Count];
                    foreach (NothiTypeListDTO nothiTypeListDTO in nothiType.data)
                    {
                        id[i] = nothiTypeListDTO.id;
                        cbxNothiType.Items.Add(nothiTypeListDTO.nothi_type);
                        playerNames[i] = nothiTypeListDTO.nothi_type;
                        i++;

                    }
                    ids = id;
                    searchOfficeDetailSearch.listboxcollection = playerNames;
                }
            }
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
            var nothiType = UserControlFactory.Create<NothiType>();
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType.Location = new System.Drawing.Point(602, 0);
            Controls.Add(nothiType);
            nothiType.BringToFront();
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
            nothiTalikaPnl.Visible = true;
            int i = cbxNothiType.SelectedIndex;
            var nothi_type_id = ids[i];
            var token = _userService.GetToken();
            var nothiNoteTalika = _nothiNoteTalikaService.GetNothiNoteTalika(token, Convert.ToString(nothi_type_id));
            if (nothiNoteTalika.status == "success")
            {
                if (nothiNoteTalika.data.records.Count > 0)
                {
                    LoadNothiNoteTalikaListinPanel(nothiNoteTalika.data.records);
                    lbTotalNote.Text = "সর্বমোট: " + string.Concat(nothiNoteTalika.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }

            }
        }
        private void LoadNothiNoteTalikaListinPanel(List<NothiNoteTalikaRecordsDTO> nothiNotetalikaLists)
        {
            List<NothiTalika> nothiTalikas = new List<NothiTalika>();
            int i = 0;
            foreach (NothiNoteTalikaRecordsDTO NothiNoteTalikaListDTO in nothiNotetalikaLists)
            {
                NothiTalika nothiTalika = new NothiTalika();
                nothiTalika.nothi = NothiNoteTalikaListDTO.nothi_no + " " + NothiNoteTalikaListDTO.subject;
                nothiTalika.shakha = NothiNoteTalikaListDTO.office_unit;
                nothiTalika.nothi_last_date = NothiNoteTalikaListDTO.created;
                lbNothiNo.Text = NothiNoteTalikaListDTO.nothi_no.Substring(0,18);
                lbNothilast4digit.Text = NothiNoteTalikaListDTO.nothi_no.Substring(18, 4);
                i = i + 1;
                nothiTalika.permitted = Convert.ToString(NothiNoteTalikaListDTO.permitted);
                nothiTalikas.Add(nothiTalika);
            }
            nothiTalikaFlowLayoutPnl.Controls.Clear();
            nothiTalikaFlowLayoutPnl.AutoScroll = true;
            nothiTalikaFlowLayoutPnl.FlowDirection = FlowDirection.TopDown;
            nothiTalikaFlowLayoutPnl.WrapContents = false;
            
            for (int j = 0; j <= nothiTalikas.Count - 1; j++)
            {
                nothiTalikaFlowLayoutPnl.Controls.Add(nothiTalikas[j]);
            }
        }
    }
}

using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class ReviewDashBoard : Form
    {
        IUserService _userService { get; set; }
        INothiReviewerServices _nothiReviewerServices { get; set; }
        designationSelect designationDetailsPanelNothi = new designationSelect();
        ModulePanelUserControl modulePanel = new ModulePanelUserControl();
        SettingsUserControl settingsUserControl = UserControlFactory.Create<SettingsUserControl>();
        public ReviewDashBoard(IUserService userService, INothiReviewerServices nothiReviewerServices)
        {
            _userService = userService;
            _nothiReviewerServices = nothiReviewerServices;
            
            InitializeComponent();
            loadTotalDakNothi();
            btnReviewByMe_Click(null,null);
        }
        public void loadTotalDakNothi()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = dakListUserParam.officer_name + "(" + dakListUserParam.designation_label + "," + dakListUserParam.unit_label + ")";
            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakListUserParam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakListUserParam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            NothiInboxTotal.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());
        }
        private void loadpotrojariGroupContentinPanel(List<NothiShaeredByMeRecord> records)
        {
            foreach (NothiShaeredByMeRecord record in records)
            {
                ReviewDashBoardContent pgc = new ReviewDashBoardContent();
                pgc.nothiShaeredByMeRecord = record;
                pgc.ReviewDashboard_Back += delegate (object sender1, EventArgs e1) { btnReviewByMe_Click(null, null); };
                UIDesignCommonMethod.AddRowinTable(dakBodyFlowLayoutPanel, pgc);
            }
        }
        
        private void btnReviewByMe_Click(object sender, EventArgs e)
        {
            
            if (InternetConnection.Check())
            {
                allButtonColorClear();
                btnReviewByMe.ForeColor = Color.FromArgb(78, 165, 254);
                btnReviewByMe.BackColor = Color.FromArgb(243, 246, 249);
                LoadReviewByMe();
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
        }
        private void LoadReviewByMe()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            NothiShaeredByMeDTO nothiShaeredByMe = _nothiReviewerServices.GetNothiSharedByMe(dakListUserParam);
            if (nothiShaeredByMe != null )
            {
                if (nothiShaeredByMe.records.Count > 0)
                {
                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiShaeredByMe.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    dakBodyFlowLayoutPanel.Controls.Clear();
                    loadpotrojariGroupContentinPanel(nothiShaeredByMe.records);

                }
                else
                {
                    //allNextButtonVisibilityOff();

                    pnlNoData.Visible = true;
                    dakBodyFlowLayoutPanel.Controls.Clear();
                }
            }
            else
            {
                pnlNoData.Visible = true;
                dakBodyFlowLayoutPanel.Controls.Clear();
            }

        }
        private void btnReviewToMe_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                allButtonColorClear();
                btnReviewToMe.ForeColor = Color.FromArgb(78, 165, 254);
                btnReviewToMe.BackColor = Color.FromArgb(243, 246, 249);
                LoadReviewToMe();
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
        }
        private void LoadReviewToMe()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            NothiShaeredByMeDTO nothiShaeredByMe = _nothiReviewerServices.GetNothiSharedToMe(dakListUserParam);
            if (nothiShaeredByMe != null)
            {
                if (nothiShaeredByMe.records.Count > 0)
                {
                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiShaeredByMe.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    dakBodyFlowLayoutPanel.Controls.Clear();
                    loadpotrojariGroupContentinPanel(nothiShaeredByMe.records);

                }
                else
                {
                    pnlNoData.Visible = true;
                    dakBodyFlowLayoutPanel.Controls.Clear();
                }
            }
            else
            {
                pnlNoData.Visible = true;
                dakBodyFlowLayoutPanel.Controls.Clear();
            }

        }
        private void btnReviewRecent_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                allButtonColorClear();
                btnReviewRecent.ForeColor = Color.FromArgb(78, 165, 254);
                btnReviewRecent.BackColor = Color.FromArgb(243, 246, 249);
                LoadReviewRecent();
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
            
        }
        private void LoadReviewRecent()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            NothiShaeredByMeDTO nothiShaeredByMe = _nothiReviewerServices.GetNothiSharedRecent(dakListUserParam);
            if (nothiShaeredByMe != null)
            {
                if (nothiShaeredByMe.records.Count > 0)
                {
                    pnlNoData.Visible = false;
                    lbTotalNothi.Text = "সর্বমোট: " + string.Concat(nothiShaeredByMe.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    dakBodyFlowLayoutPanel.Controls.Clear();
                    loadpotrojariGroupContentinPanel(nothiShaeredByMe.records);

                }
                else
                {
                    pnlNoData.Visible = true;
                    dakBodyFlowLayoutPanel.Controls.Clear();
                }
            }
            else
            {
                pnlNoData.Visible = true;
                dakBodyFlowLayoutPanel.Controls.Clear();
            }

        }
        public void allButtonColorClear()
        {
            btnReviewByMe.ForeColor = Color.FromArgb(63, 66, 84);
            btnReviewByMe.BackColor = Color.White;

            btnReviewToMe.ForeColor = Color.FromArgb(63, 66, 84);
            btnReviewToMe.BackColor = Color.White;

            btnReviewRecent.ForeColor = Color.FromArgb(63, 66, 84);
            btnReviewRecent.BackColor = Color.White;
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
        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }
        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev, 0); };
        }

        private void dakModulePanel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
        }

        private void dakModulePanel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }

        private void nothiModulePanel_MouseHover(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            nothiModulePanel.ForeColor = Color.Blue;
        }

        private void nothiModulePanel_MouseLeave(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.Transparent;
            nothiModulePanel.ForeColor = Color.Black;
        }
        
        private void moduleButton_Click(object sender, EventArgs e)
        {
            if (modulePanel.Width == 334 && !modulePanel.Visible)
            {
                modulePanel.Visible = true;
                modulePanel.Location = new System.Drawing.Point(moduleButton.Location.X + dakModulePanel.Width + nothiModulePanel.Width, 40);
                Controls.Add(modulePanel);
                modulePanel.BringToFront();
                modulePanel.Width = 335;

            }
            else
            {
                modulePanel.Visible = false;
                modulePanel.Width = 334;
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var x = SettingsButton.Parent;
            if (!settingsUserControl.Visible)
            {
                settingsUserControl.Visible = true;
                settingsUserControl.Location = new System.Drawing.Point(SettingsButton.Location.X, SettingsButton.Height);
                Controls.Add(settingsUserControl);
                settingsUserControl.BringToFront();
                settingsUserControl.SettingsSaveButton += delegate (object sender1, EventArgs e1) { SettingsSaveButton_Click(sender1 as Settings, e1); };

            }
            else
            {
                settingsUserControl.Visible = false;
                //modulePanel.Width = 334;
            }
        }
        private void SettingsSaveButton_Click(Settings settings, EventArgs e)
        {
            

        }
        private void profilePanel_Click_1(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Dock = System.Windows.Forms.DockStyle.Right;
                designationDetailsPanelNothi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                designationDetailsPanelNothi.Visible = true;
                //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(this.Width - designationDetailsPanelNothi.Width, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                //designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                List<OfficeInfoDTO> officeInfoDTO = _userService.GetAllLocalOfficeInfo();


                foreach (OfficeInfoDTO officeInfoDTO1 in officeInfoDTO)
                {
                    dakUserParam.designation_id = officeInfoDTO1.office_unit_organogram_id;
                    dakUserParam.office_id = officeInfoDTO1.office_id;
                    EmployeDakNothiCountResponse singleOfficeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                    var singleOfficeDakNothiCount = singleOfficeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                    officeInfoDTO1.dakCount = singleOfficeDakNothiCount.Value.dak;
                    officeInfoDTO1.nothiCount = singleOfficeDakNothiCount.Value.own_office_nothi;
                }



                designationDetailsPanelNothi.officeInfos = officeInfoDTO;

                designationDetailsPanelNothi.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanelNothi._designationId); };

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
        }
        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            NothiInboxTotal.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());
            //loadNothiExtra();
        }

        private void profilePanel_MouseHover(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void profilePanel_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
        }

        private void newPotrojariPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void ReviewDashBoardBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InternetConnection.Check())
            {
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

        private void ReviewDashBoardBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ReviewDashBoardBackGroundWorker.IsBusy && this.Visible)
            {
                ReviewDashBoardBackGroundWorker.RunWorkerAsync();
            }
        }

        private void ReviewDashBoard_Load(object sender, EventArgs e)
        {
            ReviewDashBoardBackGroundWorker.RunWorkerAsync();
        }
    }
}

﻿
using dNothi.Desktop.UI.ReportUI;
using dNothi.JsonParser.Entity;

using dNothi.Services.DakServices;

using dNothi.Services.SyncServices;
using dNothi.Services.UserServices;
using dNothi.Utility;

using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;

using System.Windows.Forms;


namespace dNothi.Desktop.UI
{
    public partial class ReportDashboard : Form
    {
        
        DakUserParam dakListUserParam = new DakUserParam();
        DakUserParam _dakuserparam = new DakUserParam();
        ISyncerService _syncerServices { get; set; }
        IUserService _userService { get; set; }
        public ReportDashboard(IUserService userService, ISyncerService syncerServices)
        {
            InitializeComponent();
            _userService = userService;
            _syncerServices = syncerServices;
            designationDetailsPanel.Visible = false;
        }



        private void MakeClickUnClickButton(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            if (control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {

                    c.ForeColor = foreColor;


                }
            }
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }

       
        private void ReportDashboard_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            label7.Text = UIDesignCommonMethod.copyRightLableText;
            UserProfile();
        }

        private void UserProfile()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();


            try
            {
                EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
                moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());

            }
            catch (Exception Ex)
            {

            }


            List<OfficeInfoDTO> officeInfoDTO = _userService.GetAllLocalOfficeInfo();


            foreach (OfficeInfoDTO officeInfoDTO1 in officeInfoDTO)
            {
                dakUserParam.designation_id = officeInfoDTO1.office_unit_organogram_id;
                dakUserParam.office_id = officeInfoDTO1.office_id;
                try
                {
                    EmployeDakNothiCountResponse singleOfficeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                    var singleOfficeDakNothiCount = singleOfficeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                    officeInfoDTO1.dakCount = singleOfficeDakNothiCount.Value.dak;
                    officeInfoDTO1.nothiCount = singleOfficeDakNothiCount.Value.own_office_nothi;
                }
                catch
                {

                }
            }


            designationDetailsPanel.officeInfos = officeInfoDTO;




            userNameLabel.Text = dakUserParam.officer_name + "(" + dakUserParam.designation_label + "," + dakUserParam.unit_label + ")";

            designationDetailsPanel.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanel._designationId); };

        }
       
        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            dakListUserParam = _dakuserparam  = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());


           
        }

      
        private void DakModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.DakModuleClick(this);
        }
        private void NothiModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.NothiModuleClick(this);
        }

        private void designationDetailsPanel_Load(object sender, EventArgs e)
        {

        }
        designationSelect designationDetailsPanel = new designationSelect();
        private void profileShowArrowButton_Click(object sender, EventArgs e)
        {
            if (!designationDetailsPanel.Visible)
            {
                int designationPanleX = this.Width - designationDetailsPanel.Width - 25;
                int designationPanleY = profilePanel.Location.Y + profilePanel.Height;
                designationDetailsPanel.Location = new Point(designationPanleX, designationPanleY);
                Controls.Add(designationDetailsPanel);
                designationDetailsPanel.BringToFront();
                designationDetailsPanel.Visible = true;


            }
            else
            {
                designationDetailsPanel.Visible = false;
            }
        }
       
        public bool InternetConnectionTemp;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InternetConnection.Check())
            {

                _syncerServices.SyncLocaltoRemoteData();
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




                    //dakUploadBackgorundWorker.RunWorkerAsync();
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
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (!backgroundWorker1.IsBusy && this.Visible)
            {

                backgroundWorker1.RunWorkerAsync();
            }


        }
        

        private void reportSettingButton_Click(object sender, EventArgs e)
        {
            ShowSubMenu(reportSettingDropDownPanel);
        }

        private void reportSettingMenuArrow_Click(object sender, EventArgs e)
        {
            ShowSubMenu(reportSettingDropDownPanel);
        }

        private void reportModuleButton_Click(object sender, EventArgs e)
        {

            ResetAllMenuButtonSelection();
            SelectButton(reportModuleButton);
            bodyTableLayoutPanel.Controls.Clear();
            var usersListuc = UserControlFactory.Create<UCAnumatiPraptaUserList>();

            bodyTableLayoutPanel.Controls.Add(usersListuc);
            usersListuc.Dock = DockStyle.Fill;
            usersListuc.Height = panel2.Height;
            usersListuc.Show();

        }
        private void SelectButton(Button button)
        {
            button.BackColor = Color.FromArgb(243, 246, 249);
            button.ForeColor = Color.FromArgb(78, 165, 254);
        }
        private void ResetAllMenuButtonSelection()
        {
            IterateControlsReseatSelection(menuTableLayoutPanel.Controls);



        }
        void IterateControlsReseatSelection(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                ctrl.BackColor = Color.FromArgb(254, 254, 254);
                ctrl.ForeColor = Color.FromArgb(97, 99, 114);


                IterateControlsReseatSelection(ctrl.Controls);
            }

        }

        private void categoryOfficeMappingButton_Click(object sender, EventArgs e)
        {

        }

        private void reportCategoryButton_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(reportCategoryButton);
            bodyTableLayoutPanel.Controls.Clear();
            var userListuc = UserControlFactory.Create<ReportCategoryUserControl>();

            bodyTableLayoutPanel.Controls.Add(userListuc);
            userListuc.Dock = DockStyle.Fill;
            userListuc.Height = panel2.Height; 
            userListuc.Show();
        }
        private void ShowSubMenu(Panel reportSettingDropDownPanel)
        {
            if (reportSettingDropDownPanel.Visible == true)
            {
                reportSettingDropDownPanel.Visible = false;
                reportSettingMenuArrow.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            }
            else
            {
                reportSettingDropDownPanel.Visible = false;
                reportSettingDropDownPanel.Visible = true;
                reportSettingMenuArrow.IconChar = FontAwesome.Sharp.IconChar.ChevronUp;
            }
        }

        private void ReportDashboard_Shown(object sender, EventArgs e)
        {
            bodyTableLayoutPanel.Controls.Clear();
            var usersListuc = UserControlFactory.Create<UCAnumatiPraptaUserList>();

            bodyTableLayoutPanel.Controls.Add(usersListuc);
            usersListuc.Dock = DockStyle.Fill;
            usersListuc.Height = panel2.Height;
            usersListuc.Show();
        }
        SettingsUserControl settingsUserControl = UserControlFactory.Create<SettingsUserControl>();
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var x = SettingsButton.Parent;
            if (!settingsUserControl.Visible)
            {
                settingsUserControl.Visible = true;
                settingsUserControl.Location = new System.Drawing.Point(SettingsButton.Location.X, SettingsButton.Height);
                Controls.Add(settingsUserControl);
                settingsUserControl.BringToFront();
                //settingsUserControl.SettingsSaveButton += delegate (object sender1, EventArgs e1) { SettingsSaveButton_Click(sender1 as Settings, e1); };

            }
            else
            {
                settingsUserControl.Visible = false;
                //modulePanel.Width = 334;
            }
        }
    }
}

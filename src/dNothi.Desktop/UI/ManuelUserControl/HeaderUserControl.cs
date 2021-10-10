using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.ManuelUserControl
{
    public partial class HeaderUserControl : UserControl
    {
        IUserService _userService { get; set; }
        IRepository<SettingsList> _settingsList;
        DakUserParam _dakuserparam { get; set; }
        SettingsUserControl settingsUserControl = UserControlFactory.Create<SettingsUserControl>();

        designationSelect designationDetailsPanel { get; set; }

        public HeaderUserControl(IUserService userService, IRepository<SettingsList> settingsList)
        {
            InitializeComponent();

            _userService = userService;

            _settingsList = settingsList;

            SetDesignation();
            settingsUserControl.Visible = false;

            SettingPagination();


        }

        private void SettingPagination()
        {
           
            List<SettingsList> settingsListDB = _settingsList.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();

            if (settingsListDB != null)
            {
                if (settingsListDB.Count > 0)
                {
                    foreach (SettingsList settingsList in settingsListDB)
                    {
                        settingsUserControl.setupcbxFromDB(settingsList);
                      
                    }
                }
                
            }
           
        }

        private void SetDesignation()
        {
            DakUserParam dakUserParam = _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

          
            designationDetailsPanel = new designationSelect();
            //designationDetailsPanel.Visible = false;



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

            designationDetailsPanel._designationId = dakUserParam.designation_id;



            designationDetailsPanel.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanel._designationId, changeButtonSender, changeButtonEvent); };

        }

        public event EventHandler ChangeUserClick;
        private void ChageUser(int designationId, object changeButtonSender, EventArgs changeButtonEvent)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());



            if (this.ChangeUserClick != null)
                this.ChangeUserClick(changeButtonSender, changeButtonEvent);
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.ParentForm.Hide();
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        public void ChangeOnlineStatus()
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

        

        public void RefreshDaakCount()
        {
            DakUserParam dakUser = _userService.GetLocalDakUserParam();

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUser);

            try
            {


                moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla((employeDakNothiCountResponse.data.total.dak).ToString());
                designationDetailsPanel.ChangeDaakCount(employeDakNothiCountResponse.data.total.dak);

            }
            catch
            {

            }

        }


        private void moduleButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this.ParentForm);
        }

        private void profilePanel_Click(object sender, EventArgs e)
        {
            var form = this.ParentForm;
            var designationPanel = form.Controls.OfType<designationSelect>().FirstOrDefault(a => a.Visible == true);

            if (designationPanel == null)
            {
                Point locationOnForm = profilePanel.FindForm().PointToClient(
                profilePanel.Parent.PointToScreen(profilePanel.Location));


                int x_loc = locationOnForm.X + profilePanel.Width - designationDetailsPanel.Width;


                designationDetailsPanel.Location = new Point(x_loc, locationOnForm.Y + profilePanel.Height + 1);



                form.Controls.Add(designationDetailsPanel);

               

                designationDetailsPanel.BringToFront();


            }
            else
            {
                form.Controls.Remove(designationPanel);
            }
        }

        private void dakModulePanel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Azure;
        }

        private void dakModulePanel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.White;
        }

        private void nothiModulePanel_MouseHover(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.Azure;
        }

        private void nothiModulePanel_MouseLeave(object sender, EventArgs e)
        {
            nothiModulePanel.BackColor = Color.White;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var form = this.ParentForm;
            var settingUsers = form.Controls.OfType<SettingsUserControl>().FirstOrDefault(a => a.Visible == true);


            if(settingUsers ==null)
            {
               Point locationOnForm = SettingsButton.FindForm().PointToClient(
               SettingsButton.Parent.PointToScreen(SettingsButton.Location));





                settingsUserControl.Location = new Point(locationOnForm.X, locationOnForm.Y + SettingsButton.Height + 1);
                Controls.Add(settingsUserControl);
                
                settingsUserControl.SettingsSaveButton += delegate (object sender1, EventArgs e1) { SettingsSaveButton_Click(sender1 as Settings, e1); };

            }


            if (!settingsUserControl.Visible)
            {
                settingsUserControl.Visible = true;
                settingsUserControl.BringToFront();

            }
            else
            {
                settingsUserControl.Visible = false;
              
            }
        }
        public event EventHandler SettingsSaveButton;
        private void SettingsSaveButton_Click(Settings settings, EventArgs e)
        {
            if (this.SettingsSaveButton != null)
                this.SettingsSaveButton(settings, e);
        }
    }
}

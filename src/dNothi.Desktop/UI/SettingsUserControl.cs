using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class SettingsUserControl : UserControl
    {
        IRepository<SettingsList> _settingsList;
        IUserService _userService { get; set; }
        public SettingsUserControl(IUserService userService, IRepository<SettingsList> settingsList)
        {
            _userService = userService;
            _settingsList = settingsList;

            InitializeComponent();
            showpaginationoffnotification();
            btnDakSettings_Click(null,null);
        }
        private void DakModuleOff()
        {
            cbxDakInbox.Visible = false;
            cbxDakSent.Visible = false;
            cbxArchaiveDak.Visible = false;
            cbxNothijatoDak.Visible = false;
            cbxNothiteUposthapitoDak.Visible = false;

            SixthLabel.Visible = false;
            cbxKhoshra.Visible = false;

            ReportButton.Visible = false;
        }
        private void DakModuleOn()
        {
            cbxDakInbox.Visible = true;
            cbxDakSent.Visible = true;
            cbxArchaiveDak.Visible = true;
            cbxNothijatoDak.Visible = true;
            cbxNothiteUposthapitoDak.Visible = true;

            SixthLabel.Visible = true;
            cbxKhoshra.Visible = true;

            ReportButton.Visible = false;
        }
        private void NothiModuleOn()
        {
            cbxNothiInbox.Visible = true;
            cbxNothiSent.Visible = true;
            cbxNothiAll.Visible = true;
            cbxOthersOfficeNothiInbox.Visible = true;
            cbxOthersOfficeNothiSent.Visible = true;

            ReportButton.Visible = false;
        }
        private void NothiModuleOff()
        {
            cbxNothiInbox.Visible = false;
            cbxNothiSent.Visible = false;
            cbxNothiAll.Visible = false;
            cbxOthersOfficeNothiInbox.Visible = false;
            cbxOthersOfficeNothiSent.Visible = false;

            ReportButton.Visible = false;
        }
        private void SetLabelForNothi()
        {
            headingLabel.Text = "নথির পেইজে পেজিনেশন ব্যবস্থা";
            FirstLabel.Text = "আগত";
            SecondLabel.Text = "প্রেরিত";
            ThirdLabel.Text = "সকল";
            ThirdLabel.Font = new Font("SolaimanLipi", 12f);
            FourthLabel.Text = "অন্যান্য অফিসের \nআগত";
            FourthLabel.Font = new Font("SolaimanLipi", 8f);
            FifthLabel.Text = "অন্যান্য অফিসে \nপ্রেরিত";
            FifthLabel.Font = new Font("SolaimanLipi", 8f);
            //SixthLabel.Text = "আগত";
        }
        private void SetLabelForDak()
        {
            headingLabel.Text = "ডাকের পেইজে পেজিনেশন ব্যবস্থা";
            FirstLabel.Text = "আগত";
            SecondLabel.Text = "প্রেরিত";
            ThirdLabel.Text = "নথিতে উপস্থাপিত";
            ThirdLabel.Font = new Font("SolaimanLipi", 8f);
            FourthLabel.Text = "নথিজাত";
            FourthLabel.Font = new Font("SolaimanLipi", 12f);
            FifthLabel.Font = new Font("SolaimanLipi", 12f);
            FifthLabel.Text = "আর্কাইভ";
            SixthLabel.Text = "খসড়া";
        }
        private void btnNothiSettings_Click(object sender, EventArgs e)
        {
            btnNothiSettings.ForeColor = Color.White;
            btnDakSettings.ForeColor = Color.FromArgb(243, 246, 249);
            nothiSliderPanel.BackColor = Color.FromArgb(27, 197, 189);
            DakSliderPanel.BackColor = Color.White;

            btnNotificationSettings.ForeColor = Color.FromArgb(243, 246, 249);
            notificationSliderPanel.BackColor = Color.White;

            btnOthersSettings.ForeColor = Color.FromArgb(243, 246, 249);
            othersSliderPanel.BackColor = Color.White;

            showpaginationoffnotification();
            SetLabelForNothi();
            NothiModuleOn();
            DakModuleOff();
        }
        private void btnNotificationSettings_Click(object sender, EventArgs e)
        {
            btnNotificationSettings.ForeColor = Color.White;
            notificationSliderPanel.BackColor = Color.FromArgb(27, 197, 189);
            
            btnDakSettings.ForeColor = Color.FromArgb(243, 246, 249);
            DakSliderPanel.BackColor = Color.White;

            btnNothiSettings.ForeColor = Color.FromArgb(243, 246, 249);
            nothiSliderPanel.BackColor = Color.White;
            
            btnOthersSettings.ForeColor = Color.FromArgb(243, 246, 249);
            othersSliderPanel.BackColor = Color.White;

            shownotification();
            loadNotification();
        }
        private void loadNotification() 
        {
            if (InternetConnection.Check())
            {
                DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
                var response = _userService.GetNotificationSettings(_dakuserparam);
                loadPushNotification(response.data.push_actions);
                loadEmailNotification(response.data.email_actions);
                loadSMSNotification(response.data.sms_actions);
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        private void loadPushNotification(PushActions pushActions)
        {
            dak_receivePushCheckBox.Checked = (Convert.ToInt32(pushActions.dak_receive) == 1) ? true : false;
            nothi_permissionPushCheckBox.Checked = (Convert.ToInt32(pushActions.nothi_permission) == 1) ? true : false;
            note_permissionPushCheckBox.Checked = (Convert.ToInt32(pushActions.note_permission) == 1) ? true : false;
            note_receivePushCheckBox.Checked = (Convert.ToInt32(pushActions.note_receive) == 1) ? true : false;
            potrojari_receivePushCheckBox.Checked = (Convert.ToInt32(pushActions.potrojari_receive) == 1) ? true : false;
        }
        private void loadEmailNotification(EmailActions emailActions)
        {
            dak_receiveEmailCheckBox.Checked = (Convert.ToInt32(emailActions.dak_receive) == 1) ? true : false;
            nothi_permissionEmailCheckBox.Checked = (Convert.ToInt32(emailActions.nothi_permission) == 1) ? true : false;
            note_permissionEmailCheckBox.Checked = (Convert.ToInt32(emailActions.note_permission) == 1) ? true : false;
            note_receiveEmailCheckBox.Checked = (Convert.ToInt32(emailActions.note_receive) == 1) ? true : false;
            potrojari_receiveEmailCheckBox.Checked = (Convert.ToInt32(emailActions.potrojari_receive) == 1) ? true : false;
        }
        private void loadSMSNotification(SmsActions smsActions)
        {
            dak_receiveSMSCheckBox.Checked = (Convert.ToInt32(smsActions.dak_receive) == 1) ? true : false;
            nothi_permissionSMSCheckBox.Checked = (Convert.ToInt32(smsActions.nothi_permission) == 1) ? true : false;
            note_permissionSMSCheckBox.Checked = (Convert.ToInt32(smsActions.note_permission) == 1) ? true : false;
            note_receiveSMSCheckBox.Checked = (Convert.ToInt32(smsActions.note_receive) == 1) ? true : false;
            potrojari_receiveSMSCheckBox.Checked = (Convert.ToInt32(smsActions.potrojari_receive) == 1) ? true : false;
        }

        private void showpaginationoffnotification()
        {
            NotificationPanel.Visible = false;
            NotificationSaveButton.Visible = false;
            PaginationPanel.Visible = true;
            PaginationSaveButton.Visible = true;
            this.Height = HeaderPanel.Height + SelectorPanel.Height + PaginationPanel.Height + FooterPanel.Height;
        }
        private void shownotification()
        {
            NotificationPanel.Visible = true;
            NotificationSaveButton.Visible = true;
            PaginationSaveButton.Visible = false;

            PaginationPanel.Visible = false;
            this.Height = HeaderPanel.Height + SelectorPanel.Height + NotificationPanel.Height + FooterPanel.Height;

            ReportButton.Visible = false;
        }
        private void hidenotification()
        {
            NotificationPanel.Visible = false;
            NotificationSaveButton.Visible = false;
            PaginationSaveButton.Visible = false;

            PaginationPanel.Visible = false;
            this.Height = HeaderPanel.Height + SelectorPanel.Height + FooterPanel.Height;

            ReportButton.Visible = false;
        }
        private void btnDakSettings_Click(object sender, EventArgs e)
        {
            btnDakSettings.ForeColor = Color.White;
            btnNothiSettings.ForeColor = Color.FromArgb(243, 246, 249);
            DakSliderPanel.BackColor = Color.FromArgb(27, 197, 189);
            nothiSliderPanel.BackColor = Color.White;

            btnNotificationSettings.ForeColor = Color.FromArgb(243, 246, 249);
            notificationSliderPanel.BackColor = Color.White;

            btnOthersSettings.ForeColor = Color.FromArgb(243, 246, 249);
            othersSliderPanel.BackColor = Color.White;

            showpaginationoffnotification();
            SetLabelForDak();
            NothiModuleOff();
            DakModuleOn();
        }
        private void BodyPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        public event EventHandler SettingsSaveButton;
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.nothiInboxPagination = setpagination(cbxNothiInbox.SelectedIndex);
            settings.nothiSentPagination = setpagination(cbxNothiSent.SelectedIndex);
            settings.nothiAllPagination = setpagination(cbxNothiAll.SelectedIndex);
            settings.othersOfficeNothiInboxPagination = setpagination(cbxOthersOfficeNothiInbox.SelectedIndex);
            settings.othersOfficeNothiSentPagination = setpagination(cbxOthersOfficeNothiSent.SelectedIndex);
            
            settings.dakInboxPagination = setpagination(cbxDakInbox.SelectedIndex);
            settings.dakSentPagination = setpagination(cbxDakSent.SelectedIndex);
            settings.dakNothiteUposthapitoPagination = setpagination(cbxNothiteUposthapitoDak.SelectedIndex);
            settings.dakNothijatoPagination = setpagination(cbxNothijatoDak.SelectedIndex);
            settings.dakArchaivePagination = setpagination(cbxArchaiveDak.SelectedIndex);
            settings.dakKhoshraPagination = setpagination(cbxKhoshra.SelectedIndex);
            saveinDatabase(settings);
            if (this.SettingsSaveButton != null)
                this.SettingsSaveButton(settings, e);
        }
        private void saveinDatabase(Settings settings)
        {
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            SettingsList settingsListDB = _settingsList.Table.FirstOrDefault(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id);

            if (settingsListDB != null)
            {
                settingsListDB.nothiInboxPagination = settings.nothiInboxPagination;
                settingsListDB.nothiSentPagination = settings.nothiSentPagination;
                settingsListDB.nothiAllPagination = settings.nothiAllPagination;
                settingsListDB.othersOfficeNothiInboxPagination = settings.othersOfficeNothiInboxPagination;
                settingsListDB.othersOfficeNothiSentPagination = settings.othersOfficeNothiSentPagination;

                settingsListDB.dakInboxPagination = settings.dakInboxPagination;
                settingsListDB.dakSentPagination = settings.dakSentPagination;
                settingsListDB.dakNothiteUposthapitoPagination = settings.dakNothiteUposthapitoPagination;
                settingsListDB.dakNothijatoPagination = settings.dakNothijatoPagination;
                settingsListDB.dakArchaivePagination = settings.dakArchaivePagination;
                settingsListDB.dakKhoshraPagination = settings.dakKhoshraPagination;
                _settingsList.Update(settingsListDB);
            }
            else
            {
                SettingsList settingsList = new SettingsList();
                settingsList.nothiInboxPagination = settings.nothiInboxPagination;
                settingsList.nothiSentPagination = settings.nothiSentPagination;
                settingsList.nothiAllPagination = settings.nothiAllPagination;
                settingsList.othersOfficeNothiInboxPagination = settings.othersOfficeNothiInboxPagination;
                settingsList.othersOfficeNothiSentPagination = settings.othersOfficeNothiSentPagination;

                settingsList.dakInboxPagination = settings.dakInboxPagination;
                settingsList.dakSentPagination = settings.dakSentPagination;
                settingsList.dakNothiteUposthapitoPagination = settings.dakNothiteUposthapitoPagination;
                settingsList.dakNothijatoPagination = settings.dakNothijatoPagination;
                settingsList.dakArchaivePagination = settings.dakArchaivePagination;
                settingsList.dakKhoshraPagination = settings.dakKhoshraPagination;

                settingsList.designation_id = _userService.GetLocalDakUserParam().designation_id;
                settingsList.office_id = _userService.GetLocalDakUserParam().office_id;
                _settingsList.Insert(settingsList);
            }
        }
        public int setpagination(int index)
        {
            var i = 0;
            if (index == 0)
            {
                i = 10;
            }else if (index == 1)
            {
                i = 20;
            }else if (index == 2)
            {
                i = 50;
            }else if (index == 3)
            {
                i = 100;
            }
            return i;
        }
        public int returnIndexFromLimit(int limit)
        {
            var i = 0;
            if (limit == 10)
            {
                i = 0;
            }
            else if (limit == 20)
            {
                i = 1;
            }
            else if (limit == 50)
            {
                i = 2;
            }
            else if (limit == 100)
            {
                i = 3;
            }
            return i;
        }
        public void setupcbxFromDB(SettingsList settings)
        {
            cbxNothiInbox.SelectedIndex = returnIndexFromLimit(settings.nothiInboxPagination) ;
            cbxNothiSent.SelectedIndex = returnIndexFromLimit(settings.nothiSentPagination) ;
            cbxNothiAll.SelectedIndex = returnIndexFromLimit(settings.nothiAllPagination) ;
            cbxOthersOfficeNothiInbox.SelectedIndex = returnIndexFromLimit(settings.othersOfficeNothiInboxPagination) ;
            cbxOthersOfficeNothiSent.SelectedIndex = returnIndexFromLimit(settings.othersOfficeNothiSentPagination) ;

            cbxDakInbox.SelectedIndex = returnIndexFromLimit(settings.dakInboxPagination) ;
            cbxDakSent.SelectedIndex = returnIndexFromLimit(settings.dakSentPagination );
            cbxNothiteUposthapitoDak.SelectedIndex = returnIndexFromLimit(settings.dakNothiteUposthapitoPagination) ;
            cbxNothijatoDak.SelectedIndex = returnIndexFromLimit(settings.dakNothijatoPagination) ;
            cbxArchaiveDak.SelectedIndex = returnIndexFromLimit(settings.dakArchaivePagination) ;
            cbxKhoshra.SelectedIndex = returnIndexFromLimit(settings.dakKhoshraPagination) ;
        }

        private void NotificationSaveButton_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
                NotificationSettingsData notificationSettingsData = new NotificationSettingsData();
                PushActions pushActions = new PushActions();
                EmailActions emailActions = new EmailActions();
                SmsActions smsActions = new SmsActions();

                pushActions = SetPushActions();
                emailActions = SetEmailActions();
                smsActions = SetSMSActions();

                notificationSettingsData.push_actions = pushActions;
                notificationSettingsData.email_actions = emailActions;
                notificationSettingsData.sms_actions = smsActions;

                var response = _userService.SaveNotificationSettings(_dakuserparam, notificationSettingsData);
                if (response.status == "success")
                {
                    this.Hide();
                    UIDesignCommonMethod.SuccessMessage("সফলভাবে সংরক্ষণ হয়েছে");
                }
                else
                {
                    UIDesignCommonMethod.ErrorMessage("দুঃখিত! সংরক্ষণ সম্ভব হচ্ছে না");
                }
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        private PushActions SetPushActions()
        {
            PushActions pushActions = new PushActions();
            pushActions.dak_receive = (dak_receivePushCheckBox.Checked == true) ? "1" :"0";
            pushActions.nothi_permission = (nothi_permissionPushCheckBox.Checked == true) ? "1" :"0";
            pushActions.note_receive = (note_receivePushCheckBox.Checked == true) ? "1" :"0";
            pushActions.note_permission = (note_permissionPushCheckBox.Checked == true) ? "1" :"0";
            pushActions.potrojari_receive = (potrojari_receivePushCheckBox.Checked == true) ? "1" :"0";
            return pushActions;
        }
        private EmailActions SetEmailActions()
        {
            EmailActions emailActions = new EmailActions();
            emailActions.dak_receive = (dak_receiveEmailCheckBox.Checked == true) ? "1" : "0";
            emailActions.nothi_permission = (nothi_permissionEmailCheckBox.Checked == true) ? "1" : "0";
            emailActions.note_receive = (note_receiveEmailCheckBox.Checked == true) ? 1 : 0;
            emailActions.note_permission = (note_permissionEmailCheckBox.Checked == true) ? "1" : "0";
            emailActions.potrojari_receive = (potrojari_receiveEmailCheckBox.Checked == true) ? 1 : 0;
            return emailActions;
        }
        private SmsActions SetSMSActions()
        {
            SmsActions smsActions = new SmsActions();
            smsActions.dak_receive = (dak_receiveSMSCheckBox.Checked == true) ? 1 : 0;
            smsActions.nothi_permission = (nothi_permissionSMSCheckBox.Checked == true) ? 1 : 0;
            smsActions.note_receive = (note_receiveSMSCheckBox.Checked == true) ? 1 : 0;
            smsActions.note_permission = (note_permissionSMSCheckBox.Checked == true) ? 1 : 0;
            smsActions.potrojari_receive = (potrojari_receiveSMSCheckBox.Checked == true) ? 1 : 0;
            return smsActions;
        }

        private void btnOthersSettings_Click(object sender, EventArgs e)
        {
            btnOthersSettings.ForeColor = Color.White;
            othersSliderPanel.BackColor = Color.FromArgb(27, 197, 189);

            btnNotificationSettings.ForeColor = Color.FromArgb(243, 246, 249);
            notificationSliderPanel.BackColor = Color.White;

            btnDakSettings.ForeColor = Color.FromArgb(243, 246, 249);
            DakSliderPanel.BackColor = Color.White;

            btnNothiSettings.ForeColor = Color.FromArgb(243, 246, 249);
            nothiSliderPanel.BackColor = Color.White;

            

            NothiModuleOff();
            DakModuleOff();
            hidenotification();
            ReportButton.Visible = true;
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void ReportButton_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<ReportDashboard>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        //public Settings getLocalData()
        //{
        //    Settings settings = new Settings();
        //    settings.nothiInboxPagination = setpagination(cbxNothiInbox.SelectedIndex);
        //    settings.nothiSentPagination = setpagination(cbxNothiSent.SelectedIndex);
        //    settings.nothiAllPagination = setpagination(cbxNothiAll.SelectedIndex);
        //    settings.othersOfficeNothiInboxPagination = setpagination(cbxOthersOfficeNothiInbox.SelectedIndex);
        //    settings.othersOfficeNothiSentPagination = setpagination(cbxOthersOfficeNothiSent.SelectedIndex);

        //    settings.dakInboxPagination = setpagination(cbxDakInbox.SelectedIndex);
        //    settings.dakSentPagination = setpagination(cbxDakSent.SelectedIndex);
        //    settings.dakNothiteUposthapitoPagination = setpagination(cbxNothiteUposthapitoDak.SelectedIndex);
        //    settings.dakNothijatoPagination = setpagination(cbxNothijatoDak.SelectedIndex);
        //    settings.dakArchaivePagination = setpagination(cbxArchaiveDak.SelectedIndex);
        //    settings.dakKhoshraPagination = setpagination(cbxKhoshra.SelectedIndex);
        //    return settings;
        //}
    }
}

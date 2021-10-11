
using dNothi.Core.Entities;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity.Email;
using dNothi.Services.DakServices;
using dNothi.Services.EmailBoxService;
using dNothi.Services.SettingServices;
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
    public partial class EmailBox : Form
    {
        public int pageNo { get; set; }
        public int pageLimit { get; set; }
        public int totalPage { get; set; }

        ISettingServices _settingServices { get; set; }


        IEmailBoxService _emailBoxService { get; set; }
        IUserService _userService { get; set; }

        public DakUserParam _dakUserParam { get; set; }
        public HeaderUserControl headerControl { get; set; }
        public EmailBox(ISettingServices settingServices, IEmailBoxService emailBoxService, IUserService userService)
        {
            _settingServices = settingServices;
            _emailBoxService = emailBoxService;
            _userService = userService;
            InitializeComponent();
            headerControl = UserControlFactory.Create<HeaderUserControl>();
            UIDesignCommonMethod.AddRowinTable(headerTableLayoutPanel, headerControl);
            
            _dakUserParam = _userService.GetLocalDakUserParam();
            RefreshPagination();
        }

        private void RefreshPagination()
        {
            SettingsList setting = _settingServices.GetSettingList(_dakUserParam);
            pageNo = 1;
            // pageLimit = (setting.dakSentPagination == 0) ? 10 : setting.nothiAllPagination;
            pageLimit = 10;
        }
     
        private void EmailBox_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            cpyrightLabel.Text = UIDesignCommonMethod.copyRightLableText;


            LoadEmailList();

           



        }
        private void SetPagination(int count, int total)
        {
            int startpage = (pageNo - 1) * pageLimit + 1;
            int endPage = startpage + count - 1;


            totalPage = total / pageLimit;
            totalPage += ((total % pageLimit) != 0) ? 1 : 0;


            paginationLabel.Text = ConversionMethod.EngDigittoBanDigit(startpage.ToString()) + "-" + ConversionMethod.EngDigittoBanDigit(endPage.ToString()) + " সর্বমোট:" + ConversionMethod.EngDigittoBanDigit(total.ToString());

            prevButton.Enabled = (startpage != 1);
            nextButton.Enabled = (totalPage != pageNo);

        }
        private void LoadEmailList()
        {
            _dakUserParam.limit = pageLimit;
            _dakUserParam.page = pageNo;

            List<string> operationString = new List<string>();
            operationString=GetOperationStringParam();

            string dateRange = "";
            if(!string.IsNullOrEmpty(dateTextBox.Text))
            {
                dateRange = dateTextBox.Text;
            }


            emailBodyTableLayoutPanel.Controls.Clear();

            SendEmailResponse sendEmailResponse = _emailBoxService.GetSentEmailBox(_dakUserParam, operationString, dateRange);


            if(sendEmailResponse != null && sendEmailResponse.data.total_records>0)
            {
                foreach(var email in sendEmailResponse.data.records)
                {
                    UI.EmailBoxModule.preritoEmailRowUserControl preritoEmailRowUserControl = new UI.EmailBoxModule.preritoEmailRowUserControl();

                    preritoEmailRowUserControl.sub = (!string.IsNullOrEmpty(email.data_info.nothi_subject))? email.data_info.nothi_subject: email.data_info.dak_subject;
                    if(!string.IsNullOrEmpty(email.resource.dak_type))
                    {
                        preritoEmailRowUserControl.type = email.resource.dak_type;
                        preritoEmailRowUserControl.sharokNo = email.data_info.sarok_no;
                    }
                    else
                    {
                        preritoEmailRowUserControl.nothiNo = email.data_info.nothi_no;
                    }


                    preritoEmailRowUserControl.activityInfo = EmailOperationList.GetBanglaOperationNameByEng(email.operation_type);
                    preritoEmailRowUserControl.sender = email.recipients.sender.office+","+email.recipients.sender.designation;
                    preritoEmailRowUserControl.receiver = email.recipients.receiver[0].office+","+email.recipients.receiver[0].designation + "," + email.recipients.receiver[0].officer_email;
                    preritoEmailRowUserControl.mailDate = email.created;


                    UIDesignCommonMethod.AddRowinTable(emailBodyTableLayoutPanel, preritoEmailRowUserControl);

                }

                SetPagination(sendEmailResponse.data.records.Count, sendEmailResponse.data.total_records);
            }


           

        }

        private List<string> GetOperationStringParam()
        {
            List<string> operationString = new List<string>();

            if (potrojariSendCheckBox.Checked)
            {
                operationString.Add(EmailOperationList.GetEnglishOperationNameByNBng("পত্রজারি প্রেরণ"));
            }
            if (noteSendCheckBox.Checked)
            {
                operationString.Add(EmailOperationList.GetEnglishOperationNameByNBng("নোট প্রেরণ"));
            }
            if (notePermissionCheckBox.Checked)
            {
                operationString.Add(EmailOperationList.GetEnglishOperationNameByNBng("নোটের অনুমতি"));
            }
            if (nothiPermissionCheckBox.Checked)
            {
                operationString.Add(EmailOperationList.GetEnglishOperationNameByNBng("নথি অনুমতি"));
            }
            if (senderCheckBox.Checked)
            {
                operationString.Add(EmailOperationList.GetEnglishOperationNameByNBng("ডাক প্রেরণ"));
            }
            

            return operationString;
        }

        public void ShowPopUpControl(UserControl userControl, Control clickedControl, Form form)
        {
            Point locationOnForm = clickedControl.FindForm().PointToClient(
               clickedControl.Parent.PointToScreen(clickedControl.Location));
            userControl.Location = new Point(locationOnForm.X, locationOnForm.Y + clickedControl.Height + 1);
            form.Controls.Add(userControl);
            userControl.BringToFront();
           
        }

        public void ShowPopUpControl(Control userControl, Control clickedControl, Form form)
        {
            Point locationOnForm = clickedControl.FindForm().PointToClient(
               clickedControl.Parent.PointToScreen(clickedControl.Location));
            userControl.Location = new Point(locationOnForm.X, locationOnForm.Y + clickedControl.Height + 1);
            form.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void dateRangleCalenderButton_Click(object sender, EventArgs e)
        {
            if(customDatePicker.Visible)
            {
                customDatePicker.Visible = false;
            }
            else
            {
                ShowPopUpControl(customDatePicker, dateRangePanel, dateRangePanel.FindForm());
                customDatePicker.Visible = true;
            }
        }

        private void activitySelectionButton_Click(object sender, EventArgs e)
        {
            if (activitySearchingPanel.Visible)
            {
                activitySearchingPanel.Visible = false;
            }
            else
            {
                ShowPopUpControl(activitySearchingPanel, activitySelectionButton, activitySelectionButton.FindForm());
                activitySearchingPanel.Visible = true;
            }
        }

        private void customDatePicker_OptionClick(object sender, EventArgs e)
        {
            dateTextBox.Text = customDatePicker._date;

            customDatePicker.Visible = false;
           // page = 1;
          //  lastCountValue = 0;
          //  LoadData();
        }

        private void preritoEmailButton_Click(object sender, EventArgs e)
        {
           
            RefreshPagination();
            LoadEmailList();
        }

        private void operation_type_search_changed(object sender, EventArgs e)
        {
            RefreshPagination();
            LoadEmailList();
        }

        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshPagination();
            LoadEmailList();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            pageNo -= 1;
            LoadEmailList();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            pageNo += 1;

            LoadEmailList();
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (headerControl != null)
            {
                headerControl.ChangeOnlineStatus();
            }
        }



        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           

            if (!backgroundWorker1.IsBusy && this.Visible)
            {

                backgroundWorker1.RunWorkerAsync();
            }


        }

    }
}

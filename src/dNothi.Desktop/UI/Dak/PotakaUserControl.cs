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
    public partial class PotakaUserControl : UserControl
    {
        IUserService _userService { get; set; }
        INothiDecisionListService _nothiDecisionListService { get; set; }
        public PotakaUserControl(IUserService userService, INothiDecisionListService nothiDecisionListService)
        {
            _userService = userService;
            _nothiDecisionListService = nothiDecisionListService;
            InitializeComponent();
        }

        private void shironamPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        private string _attachmentURL;
        public string attachmentURL
        {
            get { return _attachmentURL; }
            set { _attachmentURL = value; attachmentViewWebBrowser.Url = new Uri(value); }
        }
        private int _officeId;
        private int _noteId;
        public int officeId
        {
            get { return _officeId; }
            set { _officeId = value;}
        }public int noteId
        {
            get { return _noteId; }
            set { _noteId = value;}
        }
        public KhoshraPotroWaitinDataRecordDTO _khoshraPotroWaitinDataRecordDTO { get; set; }
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name == "ExtraPotakaForm")
                    f.Close();
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
        private void potakaSaveButton_Click(object sender, EventArgs e)
        {
            //color = সর্বোচ্চ অগ্রাধিকার(#fada5e) index = 1
            //color = অবিলম্বে(#dc143c) index = 2
            //color = জরুরি(#6495ed) index = 3
            var title = "";
            var color = "";
            var page_no = "";
            if (titleLabel.Text != "")
            {
                title = titleLabel.Text;
                if (cbxPotakaColor.SelectedIndex != 0)
                {
                    if (cbxPotakaColor.SelectedIndex == 1)
                    {
                        color = "#fada5e";
                    }else if (cbxPotakaColor.SelectedIndex == 2)
                    {
                        color = "#dc143c";
                    }else if (cbxPotakaColor.SelectedIndex == 3)
                    {
                        color = "#6495ed";
                    }
                    page_no = pageNoLabel.Text;
                    ///////////////API call////////
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    NothiPotakaData nothiPotakaData = new NothiPotakaData();
                    nothiPotakaData.title = title;
                    nothiPotakaData.color = color;
                    nothiPotakaData.page_number = page_no;
                    nothiPotakaData.office_id = _officeId;
                    nothiPotakaData.nothi_note_id = _noteId;

                    var nothiPotakaSaveResponse = _nothiDecisionListService.GetNothiPotakaSaveResponse(dakListUserParam, nothiPotakaData, _khoshraPotroWaitinDataRecordDTO);
                    if (nothiPotakaSaveResponse != null && nothiPotakaSaveResponse.status == "success")
                    {
                        SuccessMessage("সফলভাবে পতাকা সংরক্ষণ হয়েছে");
                        btnCross_Click(null, null);
                    }
                    else
                    {
                        ErrorMessage(nothiPotakaSaveResponse.status);
                    }
                }
                else
                {
                    ErrorMessage("দুঃখিত! রঙ ফাঁকা রাখা যাবে না");
                }
            }
            else
            {
                ErrorMessage("দুঃখিত! শিরোনাম ফাঁকা রাখা যাবে না");
            }
        }
    }
}

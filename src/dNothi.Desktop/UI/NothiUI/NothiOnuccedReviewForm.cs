using dNothi.Desktop.UI;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using javax.sound.midi;
using javax.xml.crypto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class NothiOnuccedReviewForm : Form
    {
        IDesignationSealService _designationSealService { get; set; }
        IUserService _userService { get; set; }
        INothiReviewerServices _nothiReviewerServices { get; set; }
        AllAlartMessage alartMessage = new AllAlartMessage();
        public List<int> _selectedOfficerDesignations = new List<int>();
        public List<User> _selectedUser = new List<User>();
        AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
        public NothiOnuccedReviewForm(IDesignationSealService designationSealService, IUserService userService, INothiReviewerServices nothiReviewerServices)
        {
            _nothiReviewerServices = nothiReviewerServices;
            _designationSealService = designationSealService;
            _userService = userService;
         
            InitializeComponent();

           
        }
        private int _onucchedId;
        public int onucchedId
        {
            get { return _onucchedId; }
            set { _onucchedId = value; }
        }
        public NothiListInboxNoteRecordsDTO _NoteAllListDataRecordDTO { get; set; }
        public NothiListInboxNoteRecordsDTO noteAllListDataRecordDTO { get { return _NoteAllListDataRecordDTO; } set { _NoteAllListDataRecordDTO = value; } }

        private NothiReviewerDTO _nothiReviewerDTO { get; set; }
        public NothiReviewerDTO nothiReviewerDTO { get=> _nothiReviewerDTO;
            set { _nothiReviewerDTO = value;

                if (value != null)
                {
                    if (value.users!= null && value.users.Count > 0)
                    {
                        officerEmptyPanel.Visible = false;
                        officerTableLayoutPanel.Controls.Clear();
                        foreach (var item in value.users)
                        {
                            int designationId = Convert.ToInt32(item.designation_id);
                            KhosraReviewOfficerRowUserControl officerTalika = new KhosraReviewOfficerRowUserControl();
                            officerTalika.permission = item.review_mode;
                            officerTalika.officerName = item.officer;
                            officerTalika.designation = item.designation;
                            officerTalika.officeName = item.office;
                            officerTalika.designationId = designationId;
                            _selectedOfficerDesignations.Add(designationId);
                            _selectedUser.Add(item);
                            officerTalika.DeleteButtonClick += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, designationId, item); };
                            officerTalika.PermissionChangedButton += delegate (object s2, EventArgs e1) { officerTalika_UpdateButtonClick(s2 as string, e1, designationId, item); };

                            UIDesignCommonMethod.AddRowinTable(officerTableLayoutPanel, officerTalika);
                        }
                        saveButton.Visible = true;
                        shareStopButton.Visible = true;
                    }
                    else
                    {
                        officerEmptyPanel.Visible = true;
                    }
                }
                else
                {
                    officerEmptyPanel.Visible = true;
                }
            } }
        private void NothiOnuccedReviewForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = scr.WorkingArea.Height;
            SetDefaultFont(this.Controls);
        }
        private void NothiOnuccedReviewForm_Shown(object sender, EventArgs e)
        {
            LoadOfficer();

           // LoadAssignOfficerList();
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dakBoxSharedOfficerRowUserControl2_Load(object sender, EventArgs e)
        {

        }

        private void BorderTableLayoutColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);

        }

        private void BorderTableLayoutColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);

        }

        private void crossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void searchOfficerRightButton_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightListBox_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void searchOfficerRightListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }

        private void searchOfficerRightXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void prerokBachaiButton_Click(object sender, EventArgs e)
        {

        }

        private void prerokBachaifroOfficeRightButton_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightControl_Load(object sender, EventArgs e)
        {

        }

        private void officeAddressManualEntryXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void prerokBachaiOwnRightButton_Click(object sender, EventArgs e)
        {

        }



        public void LoadOfficer()
        {
            DakUserParam userParam = _userService.GetLocalDakUserParam();
          
            designationSealListResponse = _designationSealService.GetAllDesignationSeal(userParam, userParam.office_id);
            List<ComboBoxItems> comboBoxItems = new List<ComboBoxItems>();
            try
            {

                if (designationSealListResponse.data.Count > 0)
                {

                    foreach (PrapokDTO prapokDTO in designationSealListResponse.data)
                    {
                        comboBoxItems.Add(new ComboBoxItems { id = prapokDTO.officer_id, Name = prapokDTO.NameWithDesignation +","+prapokDTO.office });
                    }
                }


            }
            catch (Exception Ex)
            {

            }

            officerSearchList.itemList = comboBoxItems;
            officerSearchList.isListShown = true;
        }
      
        private void officerTalika_DeleteButtonClick(Object sender,EventArgs e, int designationId, User user)
        {
            if(_selectedOfficerDesignations.Contains(designationId) && _selectedUser.Contains(user)  )
            {
                var officerList = officerTableLayoutPanel.Controls.OfType<KhosraReviewOfficerRowUserControl>().Where(a => a.Hide != true).ToList();

                _selectedOfficerDesignations.Remove(designationId);
                _selectedUser.Remove(user);

                if (officerList.Count == 0)
                {
                    officerEmptyPanel.Visible = true;
                    shareStopButton.Visible=false;
                    saveButton.Visible = false;
                }
                else
                {
                    officerEmptyPanel.Visible = false;
                    saveButton.Visible = true;

                }
            }

           // ReloadOfficerList();
        }
        private void officerTalika_UpdateButtonClick(string review_mode, EventArgs e, int designationId, User user)
        {
            if(_selectedOfficerDesignations.Contains(designationId) && _selectedUser.Contains(user)  )
            {
                User update_user = user;
                update_user.review_mode = review_mode;
                
                _selectedUser.Remove(user);
                _selectedUser.Add(update_user);
            }

           // ReloadOfficerList();
        }
        

        private void ReloadOfficerList()
        {
            var officerList = officerTableLayoutPanel.Controls.OfType<KhosraReviewOfficerRowUserControl>().Where(a => a.Hide != true).ToList();


            if (officerList.Count == 0)
            {
                officerEmptyPanel.Visible = true;
            }
            else
            {
                officerEmptyPanel.Visible = false;

            }

        }
        private void prerokBachaiOfficerButton_Click(object sender, EventArgs e)
        {
            int officerId= officerSearchList.selectedId;
            var officerdata = designationSealListResponse.data.Where(x => x.officer_id == officerSearchList.selectedId).FirstOrDefault();

            if (officerId > 0 && !_selectedOfficerDesignations.Contains(officerdata.designation_id))
            {
                officerEmptyPanel.Visible = false;
               
                KhosraReviewOfficerRowUserControl officerTalika = new KhosraReviewOfficerRowUserControl();
                officerTalika.permission = "write";
                officerTalika.officerName = officerdata.officer_bng;
                officerTalika.designation = officerdata.designation_bng;
                officerTalika.officeName = officerdata.office;
                officerTalika.designationId = officerdata.designation_id;
                _selectedOfficerDesignations.Add(officerdata.designation_id);
                User newUser = new User();
                newUser.recipient_type = "reviewer";
                newUser.sms_message = "";
                newUser.group_id = "0";
                newUser.group_name = "";
                newUser.group_member = "";
                newUser.group_display = "";
                newUser.office_id = officerdata.office_id.ToString();
                newUser.office_unit_id = officerdata.office_unit_id.ToString();
                newUser.designation_id = officerdata.designation_id.ToString();
                newUser.officer_id = officerdata.officer_id.ToString();
                newUser.office = officerdata.office;
                newUser.office_unit = officerdata.office_unit;
                newUser.designation = officerdata.designation;
                newUser.officer = officerdata.officer;
                newUser.officer_email = officerdata.personal_email;
                newUser.officer_mobile = officerdata.personal_mobile;
                newUser.review_mode = "write";

                _selectedUser.Add(newUser);
                officerTalika.DeleteButtonClick += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, officerdata.designation_id, newUser); };
                officerTalika.PermissionChangedButton += delegate (object s2, EventArgs e1) { officerTalika_UpdateButtonClick(s2 as string, e1, officerdata.designation_id, newUser); };

                UIDesignCommonMethod.AddRowinTable(officerTableLayoutPanel, officerTalika);

                saveButton.Visible = true;
                officerSearchList.searchButtonText = "নাম/পদবী দিয়ে খুঁজুন";
                officerSearchList.selectedId = 0;
            }
           
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                NothiListInboxNoteRecordsDTO noteAllListDataRecord = noteAllListDataRecordDTO;
                User nothiReviewer = new User();
                var dakuserparam = _userService.GetLocalDakUserParam();
                var response = _nothiReviewerServices.GetNothiSharedSave(dakuserparam, noteAllListDataRecord, _onucchedId, _selectedUser);
                if (response.status == "success")
                {
                    SuccessMessage("সফলভাবে সংরক্ষণ করা হয়েছে");
                    this.Hide();
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "extra")
                        {
                            f.Close();
                        }

                    }
                    if (this.SharingSaveButton != null)
                        this.SharingSaveButton(sender, e);
                }
                else
                {
                    ErrorMessage(response.status);
                }

            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        public event EventHandler SharingOffButton;
        public event EventHandler SharingSaveButton;
        private void shareStopButton_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                NothiListInboxNoteRecordsDTO noteAllListDataRecord = noteAllListDataRecordDTO;
                NothiReviewerDTO nothiReviewer = nothiReviewerDTO;
                nothiReviewer.nothi.shared_status = "revoke";
                var dakuserparam = _userService.GetLocalDakUserParam();
                var response = _nothiReviewerServices.GetNothiSharedOff(dakuserparam, nothiReviewer);
                if (response.status == "success")
                {
                    SuccessMessage("শেয়ারিং বন্ধ করা হয়েছে");
                    this.Hide();
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "extra")
                        {
                            f.Close();
                        }
                        
                    }
                    if (this.SharingOffButton != null)
                        this.SharingOffButton(sender, e);
                }
                else
                {
                    ErrorMessage(response.status);
                }

            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
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
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();

        }
    }
}

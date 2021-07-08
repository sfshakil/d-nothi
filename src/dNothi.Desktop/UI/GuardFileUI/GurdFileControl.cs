using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Desktop.UI.OtherModule.GuardFileUserControls;
using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.SyncServices;
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

namespace dNothi.Desktop.UI.OtherModule
{
    public partial class GurdFileControl : Form
    {
        private DakUserParam dakListUserParam = new DakUserParam();
        private DakUserParam _dakuserparam = new DakUserParam();
        IUserService _userService { get; set; }
        IGuardFileService<GuardFileModel, GuardFileModel.Record> _guardFileService;
        IGuardFileService<GuardFileCategory, GuardFileCategory.Record> _guardFileCategoryService;
        ISyncerService _syncerServices { get; set; }
        public int currentPage { get { return 1; } set { } }
        private bool _iscurrentPage = false;
        public bool iscurrentPage { get => _iscurrentPage; set => _iscurrentPage = value; }
        UCGuardFileList guardFileListuc;
        UCGuardFileUpload guardFileUploaduc; 
        UCGuardFileTypes guardFileTypeuc; 
        public GurdFileControl(IUserService userService, IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService, IGuardFileService<GuardFileCategory, GuardFileCategory.Record> guardFileCategoryService, ISyncerService syncerServices)
        {
          
            InitializeComponent();
            _userService = userService;
            _guardFileService = guardFileService;
            _guardFileCategoryService = guardFileCategoryService;
            _syncerServices = syncerServices;



        }

        
        private void guardFileTypeButton_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "গার্ড ফাইলের ধরন";
            guardFileTypeuc = new UCGuardFileTypes(_userService, _guardFileCategoryService, _guardFileService, _syncerServices);
            guardFileTypeuc.page = _currentPage;
            bodyPanel.Controls.Clear();
            bodyPanel.Controls.Add(guardFileTypeuc);
            guardFileTypeuc.Dock = DockStyle.Top;
            bodyPanel.Visible = true;
            guardFileTypeuc.Show();
            guardFileAddButton.Show();
            SelectThisButton(sender, e);
          
        }

        private void SelectThisButton(object sender, EventArgs e)
        {
            foreach(Control control in menuTableLayoutPanel.Controls)
            {
                if(control is Button && control==sender)
                {
                    control.ForeColor = Color.FromArgb(78, 165, 254);
                    control.BackColor = Color.FromArgb(243, 246, 249);
                }
                else
                {
                    control.ForeColor = Color.FromArgb(97, 99, 114);
                    control.BackColor = Color.White;
                }

            }
        }

        private void guardFileListButton_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "গার্ড ফাইল তালিকা";
            guardFileListuc = new UCGuardFileList(_userService, _guardFileService, _guardFileCategoryService);
            bodyPanel.Controls.Clear();
            bodyPanel.Controls.Add(guardFileListuc);
            guardFileListuc.Dock = DockStyle.Top;
            bodyPanel.Visible = true;
            guardFileListuc.Show();
            guardFileAddButton.Hide();

            SelectThisButton(sender, e);
        }

        private void guardFileUploadButton_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "আপলোড গার্ড ফাইল";
            guardFileUploaduc = new UCGuardFileUpload(_userService,_guardFileService);
            bodyPanel.Controls.Clear();
            bodyPanel.Controls.Add(guardFileUploaduc);
            guardFileUploaduc.Dock = DockStyle.None;
            bodyPanel.Visible = true;
            
            guardFileUploaduc.Show();
           
            guardFileAddButton.Hide();
            SelectThisButton(sender, e);
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {

            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guardFileAddButton_Click(object sender, EventArgs e)
        {
          
            var createGuardFileTypeForm = FormFactory.Create<CreateGuardFileTypeForm>();
            createGuardFileTypeForm._currentPage = _currentPage;

            createGuardFileTypeForm.SubmitButtonClick += delegate (object s, EventArgs e1) { submitUserControl_ButtonClick(s, e1); };

            UIDesignCommonMethod.CalPopUpWindow(createGuardFileTypeForm, this);
        }

        private void dakModulePanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void submitUserControl_ButtonClick(object sender, EventArgs e)
        {
            bodyPanel.Controls.Clear();
            guardFileTypeuc = new UCGuardFileTypes(_userService, _guardFileCategoryService, _guardFileService, _syncerServices);
            guardFileTypeuc.page = _currentPage;
            guardFileTypeuc.Dock = DockStyle.Top;
            bodyPanel.Controls.Add(guardFileTypeuc);
            guardFileAddButton.Show();
        }
        private void DakDashboardClick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.DakModuleClick(this);
        }

        private void Nothi_ModuleCLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.NothiModuleClick(this);
        }

        private void GurdFileControl_Shown(object sender, EventArgs e)
        {
            int page = currentPage;
           
            
            guardFileTypeuc = new UCGuardFileTypes(_userService,_guardFileCategoryService,_guardFileService, _syncerServices);
            guardFileTypeuc.page = _currentPage;

            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = dakUserParam.officer_name + "(" + dakUserParam.designation_label + "," + dakUserParam.unit_label + ")";

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


            designationDetailsPanel.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanel._designationId); };

            guardFileTypeuc.Dock = DockStyle.Top;
            bodyPanel.Controls.Add(guardFileTypeuc);
            guardFileAddButton.Show();
        }

        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            dakListUserParam = _dakuserparam = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());



        }
        public int _currentPage { get { return currentPage; } set { currentPage=value; } }

        private void profileShowArrowButton_Click(object sender, EventArgs e)
        {
            if (!designationDetailsPanel.Visible)
            {
                int designationPanleX = this.Width - designationDetailsPanel.Width - 25;
                int designationPanleY = profilePanel.Location.Y + profilePanel.Height;
                designationDetailsPanel.Location = new Point(designationPanleX, designationPanleY);

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

        private void GurdFileControl_Load(object sender, EventArgs e)
        {
            label7.Text = UIDesignCommonMethod.copyRightLableText;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}

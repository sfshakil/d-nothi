using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Desktop.UI.OtherModule.GuardFileUserControls;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
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

namespace dNothi.Desktop.UI.OtherModule
{
    public partial class GurdFileControl : Form
    {
        IUserService _userService { get; set; }
        IGuardFileService<GuardFileModel, GuardFileModel.Record> _guardFileService;
        IGuardFileService<GuardFileCategory, GuardFileCategory.Record> _guardFileCategoryService;
        public int currentPage { get { return 1; } set { } }
        

        UCGuardFileList guardFileListuc;
        UCGuardFileUpload guardFileUploaduc; 
        UCGuardFileTypes guardFileTypeuc; 
        public GurdFileControl(IUserService userService, IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService, IGuardFileService<GuardFileCategory, GuardFileCategory.Record> guardFileCategoryService)
        {
          
            InitializeComponent();
            _userService = userService;
            _guardFileService = guardFileService;
            _guardFileCategoryService = guardFileCategoryService;


        }

        
        private void guardFileTypeButton_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "গার্ড ফাইলের ধরন";
            guardFileTypeuc = new UCGuardFileTypes(_userService, _guardFileCategoryService);
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
            CreateGuardFileTypeForm createGuardFileTypeForm = new CreateGuardFileTypeForm(_userService, _guardFileCategoryService, _guardFileService);
            createGuardFileTypeForm._currentPage = _currentPage;

            UIDesignCommonMethod.CalPopUpWindow(createGuardFileTypeForm, this);
        }

        private void dakModulePanel_Paint(object sender, PaintEventArgs e)
        {

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
           
            guardFileTypeuc = new UCGuardFileTypes(_userService,_guardFileCategoryService);
            guardFileTypeuc.page = _currentPage;


            guardFileTypeuc.Dock = DockStyle.Top;
            bodyPanel.Controls.Add(guardFileTypeuc);
            guardFileAddButton.Show();
        }

       
        public int _currentPage { get { return currentPage; } set { currentPage=value; } }
    }
}

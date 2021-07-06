using CefSharp.DevTools.CSS;
using com.sun.org.apache.bcel.@internal.generic;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.OtherModule;
using dNothi.Services.DakServices;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.SyncServices;
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
 

namespace dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls
{
    public partial class CreateGuardFileTypeForm : Form
    {
     
        IGuardFileService<GuardFileCategory,GuardFileCategory.Record> _guardFileCategoryService { get; set; }
      
        IUserService _userService { get; set; }
        public const string GuardFileCategory = "GuardFileCategories";
      
        AllAlartMessage _alartMessage = new AllAlartMessage();
       
        public CreateGuardFileTypeForm(IUserService userService, IGuardFileService<GuardFileCategory, GuardFileCategory.Record> guardFileCategoryService)
        {
            InitializeComponent();
            _userService = userService;
            _guardFileCategoryService = guardFileCategoryService;
        }

        public DakUserParam dakUserParam { get; }
        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void AddDesignationCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateGuardFileTypeForm_Load(object sender, EventArgs e)
        {

            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);

            this.Height = scr.WorkingArea.Height;




        }
        public event EventHandler SubmitButtonClick;
        private void saveEditButton_Click(object sender, EventArgs e)
        {
            if (placeholderTextBox1.Text != string.Empty)
            {
                
                var dakListUserParam = _userService.GetLocalDakUserParam();

                GuardFileCategory.Record model = new GuardFileCategory.Record();
                model.name_bng = placeholderTextBox1.Text;
                model.id = 0;

                var response = _guardFileCategoryService.Insert(dakListUserParam, 3, GuardFileCategory, model);
                if(response.status=="success")
                {
                    this.Close();
                    _alartMessage.SuccessMessage("ধরন সংরক্ষণ সফল হয়েছে।");
                    if (this.saveEditButton != null)
                    {
                        SubmitButtonClick(sender, e);
                    }
                }
            }
            else
            {

                _alartMessage.ShowAlertMessage("দুংখিত! ধরন ফাঁকা রাখা যাবে না।");

            }
        }



        public int _currentPage { get; set; }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

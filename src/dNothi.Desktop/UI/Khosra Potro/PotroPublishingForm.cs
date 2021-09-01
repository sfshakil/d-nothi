using CefSharp.DevTools.CSS;
using com.sun.org.apache.bcel.@internal.generic;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.ManuelUserControl;
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
    public partial class PotroPublishingForm : Form
    {
        IUserService _userService { get; set; }
       
        AllAlartMessage _alartMessage = new AllAlartMessage();
       
        public PotroPublishingForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            typesearchComboBox.itemList = Categories();
            typesearchComboBox.isListShown = true;

        }
        private string _subject { get; set; }
        public string subject { get=>_subject; set { _subject = value; subjectTextBox.Text = value; } }

        private string _type { get; set; }
        public string type { get => _type; set { _type = value; } }

        private string _subtype { get; set; }
        public string subtype { get => _subtype; set { _subtype = value; } }

        private string _description { get; set; }
        public string description { get => _description; set { _description = value; descriptionRichTextBox.Text = value; } }

        private string _potrojariDate { get; set; }
        public string potrojariDate { get => _potrojariDate; set { _potrojariDate = value; potrojariDateTextBox.Text = value; } }

        private string _archiveDate { get; set; }
        public string archiveDate { get => _archiveDate; set { _archiveDate = value; archiveTextBox.Text = value; } }
        private string _domainname { get; set; }
        public string domainname { get => _domainname; set { _domainname = value; domainTextBox.Text = value; } }


        private List<ComboBoxItems> Categories()
        {
            List<ComboBoxItems> categoryList = new List<ComboBoxItems>();
            categoryList.Add(new ComboBoxItems { id = 0, Name = "ধরন বাছাই করুন" });
            categoryList.Add(new ComboBoxItems { id = 1, Name = "নোটিশ" });
            categoryList.Add(new ComboBoxItems { id = 2, Name = "খবর" });
        
            return categoryList;
        }

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
        //public event EventHandler SubmitButtonClick;
        //private void saveEditButton_Click(object sender, EventArgs e)
        //{
        //    if (subjectTextBox.Text != string.Empty)
        //    {
                
        //        var dakListUserParam = _userService.GetLocalDakUserParam();

        //        GuardFileCategory.Record model = new GuardFileCategory.Record();
        //        model.name_bng = subjectTextBox.Text;
        //        model.id = 0;

        //        var response = _guardFileCategoryService.Insert(dakListUserParam, 3, GuardFileCategory, model);
        //        if(response.status=="success")
        //        {
        //            this.Close();
        //            _alartMessage.SuccessMessage("ধরন সংরক্ষণ সফল হয়েছে।");
        //            //if (this.saveEditButton != null)
        //            //{
        //            //    SubmitButtonClick(sender, e);
        //            //}
        //        }
        //    }
        //    else
        //    {

        //        _alartMessage.ShowAlertMessage("দুংখিত! ধরন ফাঁকা রাখা যাবে না।");

        //    }
        //}

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

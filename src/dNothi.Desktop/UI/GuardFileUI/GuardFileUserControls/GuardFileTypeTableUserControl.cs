using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.GuardFile;
using dNothi.Desktop.UI.GuardFileUI;
using dNothi.Utility;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class GuardFileTypeTableUserControl : UserControl
    {
       
        IGuardFileService<GuardFileCategory, GuardFileCategory.Record> _guardFileService { get; set; }
        public  const string GuardFileCategory = "GuardFileCategories";
        IUserService _userService { get; set; }
        AllAlartMessage alartMessage = new AllAlartMessage();
        public GuardFileTypeTableUserControl(IUserService userService, IGuardFileService<GuardFileCategory, GuardFileCategory.Record> guardFileService)
        {
         
            _userService = userService;
            _guardFileService = guardFileService;
            InitializeComponent();
            SetToolTips();

        }
        private void SetToolTips()
        {
            MyToolTip.SetToolTip(decisionEditRightButton, "সম্পাদন করুন");
            MyToolTip.SetToolTip(decisionDeleteButton, "মুছে ফেলুন");
            MyToolTip.SetToolTip(saveEditButton, "সংরক্ষণ করুন");
            MyToolTip.SetToolTip(cancelButton, "বাতিল করুন");
        }
        public int _office_unit_organogram_id { get; set; }
        public int designation_id { get; set; }
        public int TypeId { get; set; }
        public int _id { get; set; }
       
        public string _decisision { get; set; }
       
        public string decision
        {
            get { return _decisision; }
            set
            {
                _decisision = value;
               
                decisionNameLabel.Text = value;
                decisionNameTextBox.Text = value;

            }

        }
        public int office_unit_organogram_id
        {

            get
            {

                return _office_unit_organogram_id;
            }

            set
            {
                _office_unit_organogram_id = value;

                if (value != designation_id)

                {
                    decisionDeleteButton.Visible = false;
                    decisionEditRightButton.Visible = false;

                }
                else
                {
                    decisionDeleteButton.Visible = true;
                    decisionEditRightButton.Visible = true;
                }

            }
        }
        public int id { get { return _id; } set { _id = value;label1.Text =value.ToString();  } }

        public string _typeNo
        {
            get; set;
        }
        public string TypeNo { get { return _typeNo; } set { _typeNo = value;
                if (Convert.ToInt32(value) > 0)
                { label2.Text = ConversionMethod.EnglishNumberToBangla(value); }
            } }

       
        public event EventHandler DeleteButtonClick;
        private void decisionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void decisionEditRightButton_Click(object sender, EventArgs e)
        {
          

             EditMode();
        }

        private void EditMode()
        {
            decisionNameLabel.Visible = false;
            decisionNamePanel.Visible = true;


            cancelButton.Visible = true;
            saveEditButton.Visible = true;

            decisionDeleteButton.Visible = false;
            decisionEditRightButton.Visible = false;


        }

        private void NormalMode()
        {
            decisionNameLabel.Visible = true;
            decisionNamePanel.Visible = false;


            cancelButton.Visible = false;
            saveEditButton.Visible = false;

            decisionDeleteButton.Visible = true;
            decisionEditRightButton.Visible = true;


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            NormalMode();
        }

        private void saveEditButton_Click(object sender, EventArgs e)
        {
            if (TypeId > 0)
            {
               
                var dakListUserParam = _userService.GetLocalDakUserParam();

                GuardFileCategory.Record model = new GuardFileCategory.Record();
                model.name_bng = decisionNameTextBox.Text;
                model.id = TypeId;



                var response = _guardFileService.Insert(dakListUserParam, 3, GuardFileCategory, model);
                if(response.status=="success")
                {
                    alartMessage.SuccessMessage("ধরন সংরক্ষণ সফল হয়েছে।");

                    NormalMode();
                }
                else
                {
                    alartMessage.ErrorMessage("পুনরায় চেষ্ঠা করুন।");
                }
            }
            
        }

        private void decisionDeleteButton_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি নিশ্চিতভাবে সিদ্ধান্ত টি মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            { if(this.decisionDeleteButton!=null)
                {
                    DeleteButtonClick(sender,e);
                }
               
            }
       

        }

        private void EditUpdatetableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Border_ColorPanel(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void Border_Color_Table(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }

        private void Table_Border_Color(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }
       
        public event EventHandler GuardFileCountLabelClick;
        private void label2_Click(object sender, EventArgs e)
        {
            if (this.GuardFileCountLabelClick != null)
                    this.GuardFileCountLabelClick(sender, e);
        }

        //Update



        //Delete
    }

}


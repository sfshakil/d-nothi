﻿using System;
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

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class GuardFileTypeTableUserControl : UserControl
    {
       
        IGuardFileService<GuardFileCategory, GuardFileCategory.Record> _guardFileService { get; set; }
        public  const string GuardFileCategory = "GuardFileCategories";
        IUserService _userService { get; set; }
        AllAlartMessage alartMessage = new AllAlartMessage();
        public GuardFileTypeTableUserControl(IUserService userService)
        {
         
            _userService = userService;
            InitializeComponent();
        }

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
        public int id { get { return _id; } set { _id = value;label1.Text =value.ToString();  } }

        public string _typeNo
        {
            get; set;
        }
        public string TypeNo { get { return _typeNo; } set { _typeNo = value;  label2.Text = value.ToString(); } }

        public event EventHandler RadioButtonClick;
        private void decisionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
           //// if (decisionRadioButton.Checked)
           // {
           //     isDecisionSelected = decisionRadioButton.Checked;
           //     if (this.RadioButtonClick != null)
           //         this.RadioButtonClick(sender, e);
           // }
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
                _guardFileService = new GuardFileService<GuardFileCategory,GuardFileCategory.Record>();
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
            {
                if (TypeId > 0)
                {
                    _guardFileService = new GuardFileService<GuardFileCategory, GuardFileCategory.Record>();
                    var dakListUserParam = _userService.GetLocalDakUserParam();
                    var response = _guardFileService.Delete(dakListUserParam, 4, TypeId, GuardFileCategory);
                    if (response.status == "success")
                    {

                        alartMessage.SuccessMessage("গার্ড ফাইল ধরন মুছে ফেলা হয়েছে।");
                        NormalMode();
                    }
                    else
                    {

                        alartMessage.ErrorMessage("পুনরায় চেষ্ঠা করুন।");

                    }
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

        //Update



        //Delete
    }

}


﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Core.Entities;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakDecisionTableUserControl : UserControl
    {
        IDakForwardService _dakForwardService { get; set; }
        IUserService _userService { get; set; }
        //DakDecisionDTO _dakDecisionDTO { get; set; }
        public DakDecisionTableUserControl(IDakForwardService dakForwardService, IUserService userService)
        {
            _dakForwardService = dakForwardService;
            _userService = userService;
            InitializeComponent();
        }

        public bool _isAdded { get; set; }
        public bool _isCurrentlyAdded { get; set; }
        public int _id { get; set; }
        public bool _isDecisionSelected { get; set; }
        public string _decisision { get; set; }
        public string _updatedecisision { get; set; }

        public string decision
        {
            get { return _decisision; }
            set
            {
                _decisision = value;
                _updatedecisision = value;

                decisionNameLabel.Text = value ;
                decisionNameTextBox.Text = value;

            }

        }
        public int id { get { return _id; } set { _id = value; } }

        public bool isAdded { get { return _isAdded; } set { _isAdded = value; decisionCheckBox.Checked = value;_isCurrentlyAdded = value; } }

        private void decisionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _isCurrentlyAdded = decisionCheckBox.Checked;
        }

        public bool isDecisionSelected { get { return _isDecisionSelected; } set { _isDecisionSelected = value; decisionRadioButton.Checked = value; } }

        public event EventHandler RadioButtonClick;
        private void decisionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(decisionRadioButton.Checked)
            {
                isDecisionSelected = decisionRadioButton.Checked;
                if (this.RadioButtonClick != null)
                    this.RadioButtonClick(sender, e);
            }
        }

        private void decisionEditRightButton_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void EditMode()
        {
            decisionNameLabel.Visible = false;
            decisionNameTextBox.Visible = true;


            cancelButton.Visible = true;
            saveEditButton.Visible = true;

            decisionDeleteButton.Visible = false;
            decisionEditRightButton.Visible = false;


        }

        private void NormalMode()
        {
            decisionNameLabel.Visible = true;
            decisionNameTextBox.Visible = false;


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
            DakDecisionDTO dakDecision = new DakDecisionDTO();
            dakDecision.dak_decision = decisionNameTextBox.Text;

            if(decisionCheckBox.Checked)
            {
                dakDecision.dak_decision_employee = 1;
            }
            else
            {
                dakDecision.dak_decision_employee = 0;
            }
           
            dakDecision.id = _id;

            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            DakDecisionAddResponse dakDecisionAddResponse = _dakForwardService.GetDakDecisionAddResponse(dakUserParam, dakDecision);
            if(dakDecisionAddResponse.status=="success")
            {
                decision = dakDecision.dak_decision;
                UIFormValidationAlertMessageForm uIFormValidationAlertMessageForm = new UIFormValidationAlertMessageForm();
                uIFormValidationAlertMessageForm.message = "সফলভাবে সংরক্ষণ হ​য়েছে";
                uIFormValidationAlertMessageForm.isSuccess = true;
                uIFormValidationAlertMessageForm.Show();
                var t = Task.Delay(3000); //1 second/1000 ms
                t.Wait();
                uIFormValidationAlertMessageForm.Hide();
                NormalMode();
            }

        }

        private void decisionDeleteButton_Click(object sender, EventArgs e)
        {


            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি নিশ্চিতভাবে সিদ্ধান্ত টি মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {

                
                DakDecisionDTO dakDecision = new DakDecisionDTO();
                dakDecision.dak_decision = decisionNameTextBox.Text;

                if (decisionCheckBox.Checked)
                {
                    dakDecision.dak_decision_employee = 1;
                }
                else
                {
                    dakDecision.dak_decision_employee = 0;
                }

                dakDecision.id = _id;

                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

                DakDecisionDeleteResponse dakDecisionAddResponse = _dakForwardService.GetDakDecisionDeleteResponse(dakUserParam, dakDecision);
                if (dakDecisionAddResponse.status == "success")
                {
                   
                  UIDesignCommonMethod.SuccessMessage("সফলভাবে ডিলেট হ​য়েছে।");
                    decision = dakDecision.dak_decision;
                    this.Hide();
                }
                else
                {
                    UIDesignCommonMethod.ErrorMessage("সফলভাবে ডিলেট হইনি!");
                }
            }
        }

        //Update



        //Delete
    }


}

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
using System.IO;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Desktop.UI.CustomMessageBox;
using sun.invoke.empty;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.UserServices;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class UCGuardFileReferenceNothi : Form
    {
       
      
        IUserService _userService { get; set; }
        IGuardFileService<GuardFileModel,GuardFileModel.Record> _guardFileService { get; set; }
        public const string guardFiles = "GuardFiles";
        public UCGuardFileReferenceNothi(IUserService userService, IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService)
        {
            InitializeComponent();
            _userService = userService;
            _guardFileService = guardFileService;


             MyToolTip.SetToolTip(guardFileAddButton, "বন্ধ করুন");
            // MyToolTip.SetToolTip(SubmitButton, "সংরক্ষণ করুন");
            MyToolTip.SetToolTip(AddDesignationCloseButton, "বন্ধ করুন");

        }
        public void fileAddInWebBrowser(string uri, string fileName)
        {
            if (uri != "")
            {
                fileWebBrowser.Url = new Uri(uri);
                //int q = fileWebBrowser.Document.Body.ScrollRectangle.Height;
               // lbFileName.Text = fileName;

            }

        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void userIdPanel_Paint(object sender, PaintEventArgs e)
        {
            
           ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void UCGuardFileUpload_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            
            string subjectText = subjectTextBox.Text.Trim();
           
           
            if(subjectText!=string.Empty)
            {
                GuardFileModel.Record record = new GuardFileModel.Record();
                record.name_bng = subjectTextBox.Text.Trim();
                record.name_eng = subjectTextBox.Text.Trim();
               
                 var response=   _guardFileService.Insert(_userService.GetLocalDakUserParam(),3, guardFiles, record);
                if (response.status == "success")
                {

                    SuccessMessage("সংরক্ষণ করা সফল হয়েছে।");
                   
                    subjectTextBox.Text = string.Empty;
                  
                }
            }
            else
            {
                if (subjectTextBox.Text == string.Empty)
                {
                    ShowAlertMessage("দুংখিত! শিরোনাম ফাঁকা রাখা যাবে না।");
                }
               
               
            }

           

        }
        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000);
            t.Wait();
            successMessage.Hide();
        }
        private void ShowAlertMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000);
            t.Wait();
            successMessage.Hide();
            //alertMessageBox.ShowDialog();
        }

       
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.Show();
            var t = Task.Delay(3000);
            t.Wait();
            successMessage.Hide();
            // successMessage.ShowDialog();

        }

       

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void typesearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }

        private void AddDesignationCloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guardFileAddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public event EventHandler GaurdFileAddButtonOnucced;
        private void iconButton1_Click(object sender, EventArgs e)
        {
           string  st=  subjectTextBox.Text;
            object data = st;
           
            if (this.GaurdFileAddButtonOnucced!=null)
            {
                this.Hide();
                this.GaurdFileAddButtonOnucced(data, e);
            }

        }
    }
}

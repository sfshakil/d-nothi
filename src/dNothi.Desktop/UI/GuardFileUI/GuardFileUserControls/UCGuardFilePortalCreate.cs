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
using System.Net.Http;
using System.Net;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class UCGuardFilePortalCreate : Form
    {

        GuardFileAttachment _uploadFileResponse = new GuardFileAttachment();
        IUserService _userService { get; set; }
        IGuardFileService<GuardFileModel,GuardFileModel.Record> _guardFileService { get; set; }
        IGuardFileService<GuardFileCategory, GuardFileCategory.Record> _guardFilecategoryService;
       
        public const string guardFiles = "GuardFiles";
        public UCGuardFilePortalCreate(IUserService userService, IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService, IGuardFileService<GuardFileCategory, GuardFileCategory.Record> guardFilecategoryService)
        {
            InitializeComponent();
            _userService = userService;
            _guardFileService = guardFileService;
            _guardFilecategoryService = guardFilecategoryService;


           var data = from s in LoadGuardFileTypeList()
                       select new ComboBoxItems
                       {
                           id = s.id,
                           Name = s.name_bng
                       };
           
            typesearchComboBox.itemList = data.ToList();
            typesearchComboBox.isListShown = true;


             MyToolTip.SetToolTip(guardFileAddButton, "বন্ধ করুন");
             MyToolTip.SetToolTip(SubmitButton, "সংরক্ষণ করুন");
            MyToolTip.SetToolTip(AddDesignationCloseButton, "বন্ধ করুন");

        }
       private GuardFilePortal.Record _guardFilePortal { get; set; }
       public GuardFilePortal.Record guardFilePortal { get => _guardFilePortal; set => _guardFilePortal = value; }
        public List<GuardFileCategory.Record> LoadGuardFileTypeList()
        {
            var dakListUserParam = _userService.GetLocalDakUserParam();
          
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            var datalist = _guardFilecategoryService.GetList(dakListUserParam, 1);
            return datalist.data.records;
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

        public event EventHandler SubmitButtonClick;


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();

            string subjectText = subjectTextBox.Text.Trim();
            int typeId = typesearchComboBox.selectedId;

            if (subjectText != string.Empty && typeId != 0)
            {
                GuardFileModel.Record record = new GuardFileModel.Record();
                record.name_bng = subjectTextBox.Text.Trim();
                record.name_eng = subjectTextBox.Text.Trim();
                record.guard_file_category_id = typesearchComboBox.selectedId;
                var client = new WebClient();
               
                 byte[] dataBytes = client.DownloadData(new Uri(_guardFilePortal.link));
                 string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                 _dakFileUploadParam.content = encodedFileAsBase64;
               

                _dakFileUploadParam.user_file_name = _guardFilePortal.name;
                //float d = (float)((float)3 / (float)4);

                //var size = (encodedFileAsBase64.Length *d ) - 2;

                _dakFileUploadParam.file_size_in_kb = calcBase64SizeInKBytes(encodedFileAsBase64) + " KB";

                _uploadFileResponse = UploadFile(_dakFileUploadParam);
               
               if (_uploadFileResponse != null)
                { 
                record.attachment = _uploadFileResponse.data[0];



                var response = _guardFileService.Inserts(_userService.GetLocalDakUserParam(), 3, guardFiles, record);
                if (response.status == "success")
                {

                    SuccessMessage("সংরক্ষণ করা সফল হয়েছে।");

                    subjectTextBox.Text = string.Empty;
                    typesearchComboBox.searchButtonText = "ধরণ বাছাই করুন";

                    if (this.SubmitButtonClick != null)
                    {
                        this.Hide();
                        this.SubmitButtonClick(sender, e);
                    }

                }
                 }
                else
            {
                if (subjectTextBox.Text == string.Empty)
                {
                    ShowAlertMessage("দুংখিত! শিরোনাম ফাঁকা রাখা যাবে না।");
                }
                if (typesearchComboBox.selectedId <= 0)
                {
                    ShowAlertMessage("দুংখিত! ধরণ ফাঁকা রাখা যাবে না।");
                }

            }

                }

        }
        private Double calcBase64SizeInKBytes(String base64String)
        {
            Double result = -1.0;
            if (string.IsNullOrEmpty(base64String))
            {
                int padding = 0;
                if (base64String.EndsWith("=="))
                {
                    padding = 2;
                }
                else
                {
                    if (base64String.EndsWith("=")) padding = 1;
                }
               
                result = (base64String.Length / 4 * 3) - padding;
            }
            return result / 1024;
        }
        public GuardFileAttachment UploadFile(DakFileUploadParam dakFileUploadParam)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            GuardFileAttachment uploadedFileResponse = _guardFileService.UploadedFile(dakListUserParam, dakFileUploadParam, 5);

            return uploadedFileResponse;
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
        private void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = mulpotroNotSelectErrorMessage;
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
    }
}

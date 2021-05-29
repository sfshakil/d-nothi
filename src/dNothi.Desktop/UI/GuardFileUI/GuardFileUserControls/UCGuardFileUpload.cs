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
    public partial class UCGuardFileUpload : UserControl
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "JPE", "BMP", "GIF", "PNG", ".JPE", ".BMP", ".GIF", ".PNG", "IMAGE", "IMG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF" };
        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        GuardFileAttachment _uploadFileResponse = new GuardFileAttachment();
      
        IUserService _userService { get; set; }
        IGuardFileService<GuardFileModel,GuardFileModel.Record> _guardFileService { get; set; }
        public const string guardFiles = "GuardFiles";
        public UCGuardFileUpload(IUserService userService, IGuardFileService<GuardFileModel, GuardFileModel.Record> guardFileService)
        {
            InitializeComponent();
            _userService = userService;
            _guardFileService = guardFileService;


           var data = from s in LoadGuardFileTypeList()
                       select new ComboBoxItems
                       {
                           id = s.id,
                           Name = s.name_bng
                       };
           
            typesearchComboBox.itemList = data.ToList();
            typesearchComboBox.isListShown = true;


            MyToolTip.SetToolTip(guardFileTextBox, "সর্বোচ্চ ফাইল সাইজ ২৫ মেগাবাইট।");
            MyToolTip.SetToolTip(fileUploadButton, "সর্বোচ্চ ফাইল সাইজ ২৫ মেগাবাইট।");
            panel5.Hide();  
        }
        public List<GuardFileCategory.Record> LoadGuardFileTypeList()
        {
            var dakListUserParam = _userService.GetLocalDakUserParam();
            IGuardFileService<GuardFileCategory, GuardFileCategory.Record> _guardFilecategoryService;
            _guardFilecategoryService = new GuardFileService<GuardFileCategory, GuardFileCategory.Record>();
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            var datalist = _guardFilecategoryService.GetList(dakListUserParam, 1);
            return datalist.data.records;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                // var fileStream = opnfd.OpenFile();

                // using (StreamReader reader = new StreamReader(opnfd.FileName, Encoding.UTF8))
                // {
                //     _dakFileUploadParam.content = reader.ReadToEnd();
                // }

                //// _dakFileUploadParam.content = File.ReadAllText(opnfd.FileName);
                // // _dakFileUploadParam.file_size_in_kb=opnfd.

                Byte[] bytes = File.ReadAllBytes(opnfd.FileName);
                _dakFileUploadParam.content = Convert.ToBase64String(bytes);

                var size = new System.IO.FileInfo(opnfd.FileName).Length;

                _dakFileUploadParam.file_size_in_kb = size.ToString() + " KB";



                 _uploadFileResponse = UploadFile(_dakFileUploadParam);

                if (_uploadFileResponse.status == "success")
                {
                    if (_uploadFileResponse.data.Count > 0)
                    {
                        panel5.Show();
                        GuardFileBrowseUC dakUploadAttachmentTableRow = new GuardFileBrowseUC();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            dakUploadAttachmentTableRow._isAllowedforOCR = true;
                            dakUploadAttachmentTableRow.imgSource = opnfd.FileName;
                        }

                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                        }
                        else
                        {
                            dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }


                        dakUploadAttachmentTableRow.imageBase64String = _dakFileUploadParam.content;



                        dakUploadAttachmentTableRow.fileexension = new System.IO.FileInfo(opnfd.FileName).Extension.ToLowerInvariant();
                        dakUploadAttachmentTableRow._Attachment = _uploadFileResponse.data[0];
                        dakUploadAttachmentTableRow.imageLink = _uploadFileResponse.data[0].url;

                        dakUploadAttachmentTableRow.attachmentName = _uploadFileResponse.data[0].user_file_name;
                        dakUploadAttachmentTableRow.attachmentId = _uploadFileResponse.data[0].id;
                       // dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._Attachment); };
                        dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.attachmentName); };

                        guardFileTextBox.Text = new System.IO.FileInfo(opnfd.FileName).Name;
                        dakUploadAttachmentTableRow.Dock = DockStyle.Top;
                        flowLayoutPanel1.Controls.Add(dakUploadAttachmentTableRow);
                        panel3.Hide();
                    }
                }

                      
            }
        }

      

        public GuardFileAttachment UploadFile(DakFileUploadParam dakFileUploadParam)
        {
             DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

             GuardFileAttachment uploadedFileResponse = _guardFileService.UploadedFile(dakListUserParam, dakFileUploadParam,5);

             return uploadedFileResponse;
        }


        private void DeleteControl_ButtonClick(object sender, EventArgs e,string filename)
        {
            _uploadFileResponse = null;
            flowLayoutPanel1.Controls.Clear();
            guardFileTextBox.Text = string.Empty;
            panel3.Show();
            panel5.Hide();

        }

        //private void DeleteControl_ButtonClick(object sender, EventArgs e, GuardFileModel.Attachment attachment)
        //{
        //    DakUploadFileDeleteParam deleteParam = new DakUploadFileDeleteParam();
        //    deleteParam.delete_token = attachment.delete_token;
        //    deleteParam.file_name = attachment.file_name;

        //    DakFileDeleteResponse response;

        //    using (var form = FormFactory.Create<Dashboard>())
        //    {
        //        response = form.DeleteFile(deleteParam);
        //    }
        //    if (attachment.id == 0 || (response != null && response.status == "success"))
        //    {
        //        SuccessMessage("সফলভাবে সংযুক্তি মুছে ফেলা হয়েছে");
        //        flowLayoutPanel1.Controls.Clear();
        //        panel3.Show();
        //        panel5.Hide();
        //        _uploadFileResponse = null;
        //    }


        //}



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
            int typeId = typesearchComboBox.selectedId;
            string guardFileName = guardFileTextBox.Text.Trim();
            if(subjectText!=string.Empty && typeId!=0 && guardFileName!=string.Empty &&  _uploadFileResponse!=null)
            {
                GuardFileModel.Record record = new GuardFileModel.Record();
                record.name_bng = subjectTextBox.Text.Trim();
                record.name_eng = subjectTextBox.Text.Trim();
                record.guard_file_category_id = typesearchComboBox.selectedId;
                 record.attachment = _uploadFileResponse.data[0];
                 var response=   _guardFileService.Insert(_userService.GetLocalDakUserParam(),3, guardFiles, record);
                if (response.status == "success")
                {

                    SuccessMessage("সংরক্ষণ করা সফল হয়েছে।");
                    _uploadFileResponse = null;
                    flowLayoutPanel1.Controls.Clear();
                    panel3.Show();
                    panel5.Hide();
                   subjectTextBox.Text = string.Empty;

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
                if (_uploadFileResponse.data.Count<=0)
                {
                    ShowAlertMessage("দুংখিত! গার্ড ফাইল দেয়া হয়নি।");
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
        private void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {
            UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
            alertMessageBox.message = mulpotroNotSelectErrorMessage;

            alertMessageBox.ShowDialog();
        }

       
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }

       

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void typesearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {

        }
    }
}

using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
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

namespace dNothi.Desktop.UI.Dak
{
    public partial class FolderCreatePopUpForm : Form
    {

        public IUserService _userService { get; set; }
        public IDakFolderService _dakFolderService { get; set; }

        public FolderCreatePopUpForm(IUserService userService, IDakFolderService dakFolderService)
        {
            _userService = userService;
            _dakFolderService = dakFolderService;
            InitializeComponent();
        }
        public string _folderName { get; set; }
        public int  _selectedFolderId { get; set; }
        public int  selectedFolderId { get { return _selectedFolderId; } set { _selectedFolderId = value; } }
        public FolderDTO _folderDTO { get; set; }
        public FolderDTO folderDTO { get { return _folderDTO; } set { _folderDTO = value;} }
        public string folderName { get { return _folderName; } set { _folderName = value; textBox.Text = value; } }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            this.Hide();
        }

        private void BorderColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);

        }

        public event EventHandler SaveButtonClick;
        private void saveButton_Click(object sender, EventArgs e)
        {
            _folderName = textBox.Text;
            if(textBox.Text=="")
            {
                UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
                alertMessageBox.message = "নতুন ফোল্ডার এর নাম ইনপুট দিন!";

                alertMessageBox.ShowDialog();
                return;
            }



           if(_selectedFolderId !=0)
            {
                EditFolder(sender,e);
            }
            else
            {
                SaveFolder(sender, e);
            }



           
        }

        private void SaveFolder(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();

            conditonBoxForm.message = "অপনি কি ফোল্ডার টি সংযুক্ত করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                DakFolderParam dakFolderParam = new DakFolderParam();
                dakFolderParam.custom_name = textBox.Text;
                dakFolderParam.open_for_all = _folderDTO.open_for_all;
                dakFolderParam.parent_id = _folderDTO.id;



                DakFolderAddResponse dakFolderAddResponse = _dakFolderService.GetDakFolderAddResponse(dakUserParam, dakFolderParam);

                if (dakFolderAddResponse.status == "success")
                {
                    //_selectedFolderId= dakFolderAddResponse.data.id;
                    SuccessMessage("ফোল্ডার টি সফলভাবে সংযুক্ত হযেছে!");
                    if (this.SaveButtonClick != null)
                        this.SaveButtonClick(sender, e);

                    this.Hide();
                }
                else
                {
                    ErrorMessage("ফোল্ডার টি সংযুক্তি সফল হইনি!");
                }


            }


        }

        private void EditFolder(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();

            conditonBoxForm.message = "অপনি কি ফোল্ডার টির নাম পরিবর্তন করতে চান??";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                DakFolderParam dakFolderParam = new DakFolderParam();
                dakFolderParam.custom_name = textBox.Text;
                dakFolderParam.open_for_all = _folderDTO.open_for_all;
                dakFolderParam.parent_id = _folderDTO.parent;
                dakFolderParam.id = _selectedFolderId;



                DakFolderAddResponse dakFolderAddResponse = _dakFolderService.GetDakFolderAddResponse(dakUserParam, dakFolderParam);

                if (dakFolderAddResponse.status == "success")
                {
                    dakFolderParam.id = dakFolderAddResponse.data.id;
                    SuccessMessage("ফোল্ডার টির নাম সফলভাবে পরিবর্তন হযেছে!");
                    if (this.SaveButtonClick != null)
                        this.SaveButtonClick(sender, e);

                    this.Hide();
                }
                else
                {
                    ErrorMessage("ফোল্ডার টির নাম পরিবর্তন সফল হইনি!");
                }


            }


        }

        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }

        private void FolderCreatePopUpForm_Load(object sender, EventArgs e)
        {

        }
    }
}

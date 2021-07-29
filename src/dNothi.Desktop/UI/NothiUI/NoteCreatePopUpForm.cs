using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
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
    public partial class NoteCreatePopUpForm : Form
    {

        public IUserService _userService { get; set; }
        IDakNothivuktoService _dakNothivuktoService { get; set; }

        public NoteCreatePopUpForm(IUserService userService, IDakNothivuktoService dakNothivuktoService)
        {
            _userService = userService;
            _dakNothivuktoService = dakNothivuktoService;


            InitializeComponent();
        }
        public string _noteSubject{ get; set; }
        public int  _noteId { get; set; }
        public int noteId { get { return _noteId; } set { _noteId = value; } }
       
        public string noteSubject { get { return _noteSubject; } set { _noteSubject = value; textBox.Text = value; } }

        public NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO;
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
            _noteSubject = textBox.Text;
            if(textBox.Text=="")
            {
                UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
                alertMessageBox.message = "বিষয় দিন!";

                alertMessageBox.ShowDialog();
                return;
            }


                UpdateNoteSubject(sender, e);
          

        }

      
        private void UpdateNoteSubject(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();

            conditonBoxForm.message = "অপনি কি নোট টির বিষয় পরিবর্তন করতে চান??";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                DakNothivuktoNoteAddParam dakNothivuktoNoteAddParam = new DakNothivuktoNoteAddParam();
                dakNothivuktoNoteAddParam.note_subject = textBox.Text;
                dakNothivuktoNoteAddParam.id = nothiListInboxNoteRecordsDTO.desk.nothi_note_id;
                dakNothivuktoNoteAddParam.nothi_master_id = nothiListInboxNoteRecordsDTO.desk.nothi_master_id;
               
                //dakNothivuktoNoteAddParam.officer_name = nothiListInboxNoteRecordsDTO.desk.officer;
                //dakNothivuktoNoteAddParam.office_designation_name= nothiListInboxNoteRecordsDTO.desk.designation;
                //dakNothivuktoNoteAddParam.office_id= nothiListInboxNoteRecordsDTO.desk.office_id;
                //dakNothivuktoNoteAddParam.office_name=nothiListInboxNoteRecordsDTO.desk.office;
                //dakNothivuktoNoteAddParam.office_unit_name=nothiListInboxNoteRecordsDTO.desk.office_unit;
                dakNothivuktoNoteAddParam.officer_name = dakUserParam.officer_name;
                dakNothivuktoNoteAddParam.office_designation_name = dakUserParam.designation;
                dakNothivuktoNoteAddParam.office_id = dakUserParam.office_id;
                dakNothivuktoNoteAddParam.office_name = dakUserParam.office_label;
                dakNothivuktoNoteAddParam.office_unit_name = dakUserParam.office_unit;

                var nothivuktoNoteAddResponse = _dakNothivuktoService.GetNothivuktoNoteAddResponse(dakUserParam, dakNothivuktoNoteAddParam);

                if (nothivuktoNoteAddResponse.status == "success")
                {
                    
                    SuccessMessage("নোট টির বিষয় সফলভাবে পরিবর্তন হযেছে!");
                    object noteSubject = textBox.Text;
                     
                    if (this.SaveButtonClick != null)
                        this.SaveButtonClick(noteSubject, e);

                    this.Hide();
                }
                else
                {
                    ErrorMessage("নোট টির বিষয় পরিবর্তন সফল হইনি!");
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

       
    }
}

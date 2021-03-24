using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.UserServices;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiTypeList : UserControl
    {
        IUserService _userService { get; set; }
        INoteDeleteService _noteDelete { get; set; }
        public NothiTypeList(IUserService userService, INoteDeleteService noteDelete)
        {
            _userService = userService;
            _noteDelete = noteDelete;
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }
        private string _serialNo;
        private string _nothiSubjectType;
        private string _nothiCode;
        private string _nothiNumber;
        private string _noteId;

        [Category("Custom Props")]
        public string serialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; lblSerialNo.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }


        [Category("Custom Props")]
        public string nothiSubjectType
        {
            get { return _nothiSubjectType; }
            set { _nothiSubjectType = value; lbNothiSubjectType.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiCode
        {
            get { return _nothiCode; }
            set { _nothiCode = value;
                try
                {
                    int val = Int32.Parse(value);
                    lbNothiCode.Text = string.Concat(val.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                catch
                {
                    string vl = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbNothiCode.Text = string.Concat(vl.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                
                
            }
        }

        [Category("Custom Props")]
        public string nothiNumber
        {
            get { return _nothiNumber; }
            set { _nothiNumber = value; lbNothiNumber.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                if (value == "0")
                {
                    btnDelete.Visible = true;
                }       
            }
        }
        [Category("Custom Props")]
        public string noteId
        {
            get { return _noteId; }
            set { _noteId = value; lbNoteId.Text = value; }
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "আপনি কি নথি ধরনটি মুছে ফেলতে চান?";
            //string title = "আপনি কি নথি ধরনটি মুছে ফেলতে চান?";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);
            if (conditonBoxForm.Yes)
            {
                //this.Hide();
                string noteId = lbNoteId.Text;
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                var noteDelete = _noteDelete.GetNoteDelete(dakListUserParam, noteId);
                if (noteDelete.status == "success")
                {
                    SuccessMessage("নথি ধরন মুছে ফেলা হয়েছে।");
                    foreach (Form f in Application.OpenForms)
                    { f.Hide(); }
                    var form = FormFactory.Create<Nothi>();
                    form.ForceLoadNewNothi();
                    form.ShowDialog();
                }
            }
            else
            {
                // Do something  
            }
            

            ///////////////////
        }
    }
}

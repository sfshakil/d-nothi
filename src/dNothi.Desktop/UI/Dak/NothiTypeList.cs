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
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Utility;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiTypeList : UserControl
    {
        IUserService _userService { get; set; }
        INoteDeleteService _noteDelete { get; set; }
        INothiTypeListServices _nothiType { get; set; }
        INothiTypeSaveService _nothiTypeSave { get; set; }
        INothiNoteTalikaServices _nothiNoteTalikaService { get; set; }
        public NothiTypeList(IUserService userService, INoteDeleteService noteDelete, INothiTypeListServices nothiType,
            INothiTypeSaveService nothiTypeSave, INothiNoteTalikaServices nothiNoteTalikaService)
        {
            _userService = userService;
            _noteDelete = noteDelete;
            _nothiType = nothiType;
            _nothiTypeSave = nothiTypeSave;
            _nothiNoteTalikaService = nothiNoteTalikaService;

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

        public void offline()
        {
            lbNothiNumber.Visible = false;
            btnNothiTypeEdit.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnSchedule.Visible = true;
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
                    btnNothiTypeEdit.Visible = true;
                }       
            }
        }
        [Category("Custom Props")]
        public string noteId
        {
            get { return _noteId; }
            set { _noteId = value; lbNoteId.Text = value; }
        }
        public event EventHandler NothiTypeDeleteButton;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                string message = "আপনি কি নথি ধরনটি মুছে ফেলতে চান?";
                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = message;
                conditonBoxForm.ShowDialog(this);
                if (conditonBoxForm.Yes)
                {
                    string noteId = lbNoteId.Text;
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    var noteDelete = _noteDelete.GetNoteDelete(dakListUserParam, noteId);
                    if (noteDelete.status == "success")
                    {
                        UIDesignCommonMethod.SuccessMessage("নথি ধরন মুছে ফেলা হয়েছে।");
                        if (this.NothiTypeDeleteButton != null)
                            this.NothiTypeDeleteButton(sender, e);
                        //foreach (Form f in Application.OpenForms)
                        //{ BeginInvoke((Action)(() => f.Hide())); }
                        //var form = FormFactory.Create<Nothi>();
                        //form.ForceLoadNewNothi();
                        //BeginInvoke((Action)(() => form.ShowDialog()));
                        //form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
                    }
                }
                else
                {
                    // Do something  
                }
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            

            ///////////////////
        }

        private void btnNothiTypeEdit_Click(object sender, EventArgs e)
        {
            lbNothiSubjectType.Visible = false;
            lbNothiCode.Visible = false;

            txtNothiCodeEdit.Visible = true;
            txtNothiSubjectTypeEdit.Visible = true;

            btnNothiTypeEdit.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = false;

            btnEditSave.Visible = true;
            btnEditCancel.Visible = true;

            txtNothiSubjectTypeEdit.Text = lbNothiSubjectType.Text;
            txtNothiCodeEdit.Text = lbNothiCode.Text;
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            lbNothiSubjectType.Visible = true;
            lbNothiCode.Visible = true;

            txtNothiCodeEdit.Visible = false;
            txtNothiSubjectTypeEdit.Visible = false;

            btnNothiTypeEdit.Visible = true;
            btnDelete.Visible = true;
            btnAdd.Visible = true;

            btnEditSave.Visible = false;
            btnEditCancel.Visible = false;
        }
        public event EventHandler nothitypeeditbutton;
        public NothiTypeListResponse nothiType;
        public bool IsEnglishDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void btnEditSave_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                if (txtNothiSubjectTypeEdit.Text != "" && txtNothiCodeEdit.Text != "")
                {
                    string type_id = "0";
                    bool check = false;
                    bool IsEnglish = true;
                    var type_code = "";
                    if (!IsEnglishDigitsOnly(txtNothiCodeEdit.Text))
                    {
                        type_code = string.Concat(txtNothiCodeEdit.Text.Select(c => (char)('0' + c - '\u09E6')));
                    }
                    else
                    {
                        type_code = txtNothiCodeEdit.Text;
                    }
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    nothiType = _nothiType.GetNothiTypeList(dakListUserParam);
                    if (nothiType.status == "success")
                    {
                        if (nothiType.data.Count > 0)
                        {
                            foreach (NothiTypeListDTO response in nothiType.data)
                            {
                                if (response.nothi_type == lbNothiSubjectType.Text && response.nothi_type_code == string.Concat(lbNothiCode.Text.Select(c => (char)('0' + c - '\u09E6'))))
                                {
                                    type_id = response.id.ToString();
                                    continue;
                                }
                                else if (response.nothi_type != lbNothiSubjectType.Text && response.nothi_type_code == type_code)
                                {
                                    check = true;
                                    break;
                                }
                                else
                                {
                                    check = false;
                                }
                            }
                        }
                    }
                    if (check)
                    {
                        UIDesignCommonMethod.ErrorMessage("দুঃখিত! এই ধরণ কোর্ডটি পূর্বে ব্যবহার করা হয়েছে");

                    }
                    else
                    {
                        bool eng = IsEnglishDigitsOnly(txtNothiCodeEdit.Text);
                        if (eng)
                        {
                            var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, txtNothiSubjectTypeEdit.Text, type_code, type_id);
                            if (nothiTypeSave.status == "success")
                            {
                                this.Hide();
                                UIDesignCommonMethod.SuccessMessage("নথি ধরণ হালনাগাদ করা হয়েছে।");
                                if (this.nothitypeeditbutton != null)
                                    this.nothitypeeditbutton(sender, e);
                            }
                        }
                        else
                        {
                            var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, txtNothiSubjectTypeEdit.Text, type_code, type_id);
                            if (nothiTypeSave.status == "success")
                            {
                                UIDesignCommonMethod.SuccessMessage("নথি ধরণ হালনাগাদ করা হয়েছে।");
                                if (this.nothitypeeditbutton != null)
                                    this.nothitypeeditbutton(sender, e);
                                //foreach (Form f in Application.OpenForms)
                                //{ BeginInvoke((Action)(() => f.Hide())); }
                                //var form = FormFactory.Create<Nothi>();
                                //form.ForceLoadNewNothi();
                                //BeginInvoke((Action)(() => form.ShowDialog()));
                                //form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };

                            }
                        }
                    }

                }
                else
                {
                    UIDesignCommonMethod.ErrorMessage("দুঃখিত! ধরন ফাকা রাখা যাবে না।");
                }
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        public event EventHandler NothiAddButton;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var nothi_type = lbNothiSubjectType.Text;
            if (this.NothiAddButton != null)
                this.NothiAddButton(nothi_type, e);
        }
        public Form NothiTalikaControlToForm(Control control)
        {
            Form form = new Form();
            form.Name = "ExtraNothiTalikaForm";
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.AutoSize = true;
            //form.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - control.Width, 0);
            control.Location = new System.Drawing.Point(0, 0);
            //form.Size = control.Size;
            form.Height = Screen.PrimaryScreen.WorkingArea.Height;
            form.Width = control.Width;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Height = form.Height;
            form.Controls.Add(control);
            return form;
        }
        
        private void lbNothiNumber_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                var nothi_type_id = _noteId;
                var nothiNoteTalika = _nothiNoteTalikaService.GetNothiNoteTalika(dakListUserParam, Convert.ToString(nothi_type_id));
                if (nothiNoteTalika.status == "success")
                {
                    if (nothiNoteTalika.data.records.Count > 0)
                    {
                        var nothiTalikaNewWindow = UserControlFactory.Create<NothiTalikaNewWindow>();
                        nothiTalikaNewWindow.nothiTalikaHeading = lbNothiSubjectType.Text;
                        nothiTalikaNewWindow.LoadNothiNoteTalikaListinPanel(nothiNoteTalika.data.records);
                        var form = NothiTalikaControlToForm(nothiTalikaNewWindow);
                        UIDesignCommonMethod.CalPopUpWindow(form,this);
                    }

                }
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
            
        }
        

    }
}

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
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class CreateNewNothiType : UserControl
    {
        IUserService _userService { get; set; }
        INothiTypeSaveService _nothiTypeSave { get; set; }
        
        public CreateNewNothiType(IUserService userService, INothiTypeSaveService nothiTypeSave)
        {
            _userService = userService;
            _nothiTypeSave = nothiTypeSave;
            InitializeComponent();
            SetDefaultFont(this.Controls);
            //txtDhoronCode.MaxLength = 2;


        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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
        private string _nothiType;
        private string _invisibleNothiType;

        [Category("Custom Props")]
        public string nothiType
        {
            get { return _nothiType; }
            set {
                _nothiType = value;
                cbxNothiType.Items.Add(value);
                cbxNothiType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbxNothiType.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
        }
        [Category("Custom Props")]
        public string invisibleNothiType
        {
            get { return _invisibleNothiType; }
            set {
                _invisibleNothiType = value;
                invisiblecbxNothiType.Items.Add(value);
                }
        }

        private void btnGuidelines_Click(object sender, EventArgs e)
        {
            
        }
        public Form AttachNothiGuidelinesControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            //form.Location = new System.Drawing.Point(100, 100);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            //NewNothiCreateGuidelines newguideline = new NewNothiCreateGuidelines();
            //newguideline.Height = Screen.PrimaryScreen.WorkingArea.Height; 
            ////newguideline.ShowDialog();

            ////NewNothiCreateGuidelines nothiGuidelines = UserControlFactory.Create<NewNothiCreateGuidelines>();
            ////nothiGuidelines.Visible = true;
            ////nothiGuidelines.Enabled = true;
            ////nothiGuidelines.Location = new System.Drawing.Point(0, 0);
            ////var nothiTypeform = AttachNothiGuidelinesControlToForm(newguideline);
            //CalPopUpWindow(newguideline);

            var nothiGuidelines = UserControlFactory.Create<NewNothiTypeGuidelines>();
            nothiGuidelines.Visible = true;
            nothiGuidelines.Enabled = true;
            nothiGuidelines.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //nothiGuidelines.Location = new System.Drawing.Point(0, 0);
            var nothiTypeform = AttachNothiGuidelinesControlToForm(nothiGuidelines);
            nothiTypeform.Text = "NothiGuidelines";
            CalPopUpWindow(nothiTypeform);
        }

        private void CreateNewNothiType_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }
        public Form AttachNothiTypeListControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Location = new System.Drawing.Point(845, 0);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();

            hideform.BackColor = Color.Black;
            hideform.Height = Screen.PrimaryScreen.WorkingArea.Height; //{Width = 1382 Height = 744}
            hideform.Width = Screen.PrimaryScreen.WorkingArea.Width; //{Width = 1382 Height = 744}
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
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
        public event EventHandler NothiTypeAddButton;
        private void btnNothiDhoron_Click(object sender, EventArgs e)
        {

            if (cbxNothiType.Text != "বিষয়ের ধরন" && lbNothitype2digit.Text != "")
            {
                int i = cbxNothiType.SelectedIndex;
                int index = cbxNothiType.Items.IndexOf(lbNothitype2digit.Text);
                if (index >= 0 || i >= 0)
                {
                    ErrorMessage("দুঃখিত! এই ধরণ কোর্ডটি পূর্বে ব্যবহার করা হয়েছে");
                    
                }
                else
                {
                    bool eng =  IsEnglishDigitsOnly(lbNothitype2digit.Text);
                    if (eng)
                    {
                        string bng = string.Concat(lbNothitype2digit.Text.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        int index1 = cbxNothiType.Items.IndexOf(bng);
                        if (index1 >= 0)
                        {
                            ErrorMessage("দুঃখিত! এই ধরণ কোর্ডটি পূর্বে ব্যবহার করা হয়েছে");
                        }
                        else
                        {
                            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                            var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, cbxNothiType.Text, lbNothitype2digit.Text, "0");
                            if (nothiTypeSave.status == "success")
                            
                            {
                                this.Hide();
                                SuccessMessage("নথি ধরন সংরক্ষন হয়েছে।");
                                if (this.NothiTypeAddButton != null)
                                    this.NothiTypeAddButton(sender, e);
                                //foreach (Form f in Application.OpenForms)
                                //{ BeginInvoke((Action)(() => f.Hide())); }
                                //var form = FormFactory.Create<Nothi>();
                                //form.ForceLoadNewNothi();
                                //BeginInvoke((Action)(() => form.ShowDialog()));
                                //form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };

                            }
                        }
                    }
                    else
                    {
                        string english_text = string.Concat(lbNothitype2digit.Text.Select(c => (char)('0' + c - '\u09E6')));

                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                        var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, cbxNothiType.Text, english_text, "0");
                        if (nothiTypeSave.status == "success")
                        {
                            SuccessMessage("নথি ধরন সংরক্ষন হয়েছে।");
                            if (this.NothiTypeAddButton != null)
                                this.NothiTypeAddButton(sender, e);

                        }
                    }
                }
                
            }
            else
            {
                ErrorMessage("দুঃখিত! ধরন ফাকা রাখা যাবে না।");
            }
            
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }
        public bool IsEnglishDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void userIdPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        List<NothiTypeListDTO> nothiTypeLists = new List<NothiTypeListDTO>();
        public void nothiTypeList(List<NothiTypeListDTO> nothiTypeListDTO)
        {
            nothiTypeLists = nothiTypeListDTO;
        }
        private void cbxNothiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbNothitype2digitText.Visible = false;
                int index = invisiblecbxNothiType.Items.IndexOf(cbxNothiType.SelectedItem);
                int i = cbxNothiType.SelectedIndex;
                int checking = CheckArray(i);
                if (checking == 2 || checking == 3)
                    cbxNothiType.SelectedIndex = -1;
                var st = nothiTypeLists[index];
                lbNothitype2digit.Text = string.Concat(st.nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0')));
                //txtDhoronCode.Text = string.Concat(st.nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0')));
            }
            catch
            {
                cbxNothiType.Text = "বাছাই করুন";
                //txtDhoronCode.Text = "";
                lbNothitype2digit.Text = "";
            }
            
        }
        private int CheckArray(int i)
        {
            int checking = 0;
            for (int a=0; a<=100; a=a+3)
            {
                if (i == a)
                { 
                    checking =  1; 
                }

            }
            for (int a = 1; a <= 100; a = a + 3)
            {
                if (i == a)
                {
                    checking = 2;
                }

            }
            for (int a = 2; a <= 100; a = a + 3)
            {
                if (i == a)
                {
                    checking = 3;
                }

            }
            return checking;
        }

        
        Font myFont = new Font("Aerial", 10, FontStyle.Regular);
        private void invisiblecbxNothiType_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == 1)//We are disabling item based on Index, you can have your logic here
            {
                e.Graphics.DrawString(invisiblecbxNothiType.Items[e.Index].ToString(), myFont, Brushes.LightGray, e.Bounds);
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(invisiblecbxNothiType.Items[e.Index].ToString(), myFont, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void invisiblecbxNothiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (invisiblecbxNothiType.SelectedIndex == 1)
                invisiblecbxNothiType.SelectedIndex = -1;
        }

        private void lbNothitype2digit_MouseClick(object sender, MouseEventArgs e)
        {
            lbNothitype2digitText.Visible = false;
        }

        private void lbNothitype2digitText_MouseHover(object sender, EventArgs e)
        {
            lbNothitype2digitText.Visible = false;
        }
    }
}

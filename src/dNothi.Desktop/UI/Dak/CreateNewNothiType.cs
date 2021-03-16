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

        private void btnInfo_Click(object sender, EventArgs e)
        {
            NewNothiCreateGuidelines newguideline = new NewNothiCreateGuidelines();
            newguideline.ShowDialog();
        }

        private void CreateNewNothiType_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
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
            hideform.Height = 744; //{Width = 1382 Height = 744}
            hideform.Width = 1382; //{Width = 1382 Height = 744}
            hideform.Opacity = .4;

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
        private void btnNothiDhoron_Click(object sender, EventArgs e)
        {
            if (cbxNothiType.Text != "বিষয়ের ধরন" && txtDhoronCode.Text != "")
            {
                int i = cbxNothiType.SelectedIndex;
                int index = cbxNothiType.Items.IndexOf(txtDhoronCode.Text);
                if (index >= 0 || i >= 0)
                {
                    MessageBox.Show("দুঃখিত! এই ধরণ কোর্ডটি পূর্বে ব্যবহার করা হয়েছে");
                    
                }
                else
                {
                    bool eng =  IsEnglishDigitsOnly(txtDhoronCode.Text);
                    if (eng)
                    {
                        string bng = string.Concat(txtDhoronCode.Text.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        int index1 = cbxNothiType.Items.IndexOf(bng);
                        if (index1 >= 0)
                        {
                            MessageBox.Show("দুঃখিত! এই ধরণ কোর্ডটি পূর্বে ব্যবহার করা হয়েছে");
                        }
                        else
                        {
                            //string english_text = string.Concat(txtDhoronCode.Text.Select(c => (char)('0' + c - '\u09E6')));

                            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                            //int parsed_number = int.Parse(english_text);
                            var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, cbxNothiType.Text, txtDhoronCode.Text);
                            if (nothiTypeSave.status == "success")
                            {
                                MessageBox.Show("নথি ধরন সংরক্ষন হয়েছে।");
                                foreach (Form f in Application.OpenForms)
                                { f.Hide(); }
                                var form = FormFactory.Create<Nothi>();
                                form.ForceLoadNewNothi();
                                form.ShowDialog();

                            }
                        }
                    }
                    else
                    {
                        string english_text = string.Concat(txtDhoronCode.Text.Select(c => (char)('0' + c - '\u09E6')));

                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                        //int parsed_number = int.Parse(english_text);
                        var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, cbxNothiType.Text, english_text);
                        if (nothiTypeSave.status == "success")
                        {
                            MessageBox.Show("নথি ধরন সংরক্ষন হয়েছে।");
                            foreach (Form f in Application.OpenForms)
                            { f.Hide(); }
                            var form = FormFactory.Create<Nothi>();
                            form.ForceLoadNewNothi();
                            form.ShowDialog();

                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("দুঃখিত! ধরন ফাকা রাখা যাবে না।");
            }
            
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
                int index = invisiblecbxNothiType.Items.IndexOf(cbxNothiType.SelectedItem);
                int i = cbxNothiType.SelectedIndex;
                int checking = CheckArray(i);
                if (checking == 2 || checking == 3)
                    cbxNothiType.SelectedIndex = -1;
                var st = nothiTypeLists[index];
                txtDhoronCode.Text = string.Concat(st.nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0')));
            }
            catch
            {
                cbxNothiType.Text = "বাছাই করুন";
                txtDhoronCode.Text = "";
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

        private void txtDhoronCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtDhoronCode.MaxLength = 2;
            
            if (txtDhoronCode.Text.Length >= 2)
            {
                MessageBox.Show("Can Enter only two Digit in this Textbox");
                e.Handled = true;
            }
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
    }
}

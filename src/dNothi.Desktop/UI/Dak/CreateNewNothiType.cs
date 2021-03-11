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
                if (i>=0)
                {
                    var st = nothiTypeLists[i];
                    //cbxNothiType.Text = st.nothi_type;
                    if (string.Concat(st.nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0'))) != txtDhoronCode.Text)
                    {
                        string english_text = string.Concat(txtDhoronCode.Text.Select(c => (char)('0' + c - '\u09E6')));
                        int parsed_number = int.Parse(english_text);
                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                        var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, cbxNothiType.Text, english_text);
                        if (nothiTypeSave.status == "success")
                        {
                            MessageBox.Show("নথি ধরন সংরক্ষন হয়েছে।");
                            foreach (Form f in Application.OpenForms)
                            { f.Hide(); }
                            var form = FormFactory.Create<Nothi>();
                            form.ForceLoadNewNothi();
                            form.ShowDialog();


                            //var form = FormFactory.Create<Nothi>();
                            //form.ForceLoadNewNothi();
                            //var nothiType = UserControlFactory.Create<NothiType>();

                            //nothiType.Visible = true;
                            //nothiType.Enabled = true;
                            //nothiType.Location = new System.Drawing.Point(845, 0);
                            //form.Controls.Add(nothiType);
                            //nothiType.BringToFront();
                            //form.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("দুঃখিত! এই ধরণ কোর্ডটি পূর্বে ব্যবহার করা হয়েছে");
                        }

                    }
                    else
                    {

                        MessageBox.Show("দুঃখিত! এই ধরণ কোর্ডটি পূর্বে ব্যবহার করা হয়েছে");
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
                        //foreach (Form f in Application.OpenForms)
                        //{ f.Hide(); }
                        //var form = FormFactory.Create<Nothi>();
                        //form.ForceLoadNewNothi();
                        //var nothiType = UserControlFactory.Create<NothiType>();

                        //nothiType.Visible = true;
                        //nothiType.Enabled = true;
                        //nothiType.Location = new System.Drawing.Point(845, 0);
                        //form.Controls.Add(nothiType);
                        //nothiType.BringToFront();
                        //form.ShowDialog();

                    }
                }
                
            }
            else
            {
                MessageBox.Show("দুঃখিত! ধরন ফাকা রাখা যাবে না।");
            }
            
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
            int i = cbxNothiType.SelectedIndex;
            var st = nothiTypeLists[i];

            //cbxNothiType.Controls.Clear(); //= st.nothi_type;
            //cbxNothiType.Items.Clear();
            //var s = cbxNothiType.SelectedValue;
            cbxNothiType.Text = st.nothi_type;
            txtDhoronCode.Text = string.Concat(st.nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0')));
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
    }
}

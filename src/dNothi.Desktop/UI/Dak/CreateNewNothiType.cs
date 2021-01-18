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

        private void btnNothiDhoron_Click(object sender, EventArgs e)
        {
            if (cbxNothiType.Text != "বিষয়ের ধরন" && txtDhoronCode.Text != "")
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                var nothiTypeSave = _nothiTypeSave.GetNothiTypeList(dakListUserParam, cbxNothiType.Text, txtDhoronCode.Text);
                if (nothiTypeSave.status == "success")
                {
                    
                    foreach (Form f in Application.OpenForms)
                    { f.Hide(); }
                    var form = FormFactory.Create<Nothi>();
                    form.ForceLoadNewNothi();
                    var nothiType = UserControlFactory.Create<NothiType>();
                    MessageBox.Show("নথি ধরন সংরক্ষন হয়েছে।");
                    nothiType.Visible = true;
                    nothiType.Enabled = true;
                    nothiType.Location = new System.Drawing.Point(845, 0);
                    form.Controls.Add(nothiType);
                    nothiType.BringToFront();
                    form.ShowDialog();
                    
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
    }
}

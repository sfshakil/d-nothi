using dNothi.Desktop.UI.Profile;
using dNothi.JsonParser.Entity;
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
    public partial class UserProfileForm : Form
    {
        IUserService _userService { get; set; }
        public UserProfileForm(IUserService userService)
        {
            _userService = userService;
            

            InitializeComponent();
        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Hide();


        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {

            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = scr.WorkingArea.Height;
            SetDefaultFont(this.Controls);
            SetUserData();
        }

        private void SetUserData()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List<OfficeInfoDTO> officeInfoDTO = _userService.GetAllLocalOfficeInfo();
            
            userIdLabel.Text = dakUserParam.loginId.ToString();
          
            
            var signImage = UIDesignCommonMethod.GetImageFromBase64(dakUserParam.SignBase64);
            if(signImage != null)
            {
                signatureIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.None;
                signatureIconPictureBox.Image = signImage;

            }

            nameLabel.Text += dakUserParam.officer_name;
            fatherNameLabel.Text += dakUserParam.fatherName;
            motherNameLabel.Text += dakUserParam.motherName;
            dateofBirthLabel.Text += dakUserParam.DateofBirth;
            nationalIdLabel.Text += dakUserParam.nationalId;
            birthCertificate.Text += dakUserParam.officer_name;
            emailLabel.Text += dakUserParam.officer_email;
            mobileLabel.Text += dakUserParam.officer_mobile;
            joiningDateLabel.Text += dakUserParam.joiningDate;


            if(officeInfoDTO!=null && officeInfoDTO.Count>0)
            {
                foreach (var office in officeInfoDTO)
                {
                    designationListBox.Items.Add(office.designation + ", " + office.unit_name_bn + ", " + office.office_name_bn);
                }
            }
           


            
            
        }

        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }




        private void BorderColorBlue(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void profileUpdateButton_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<ProfileManagementForm>();

            Screen scr = Screen.FromPoint(this.Location);

            form.Height = scr.WorkingArea.Height - 40;
            form.Width = scr.WorkingArea.Width - 40;

            
            UIDesignCommonMethod.CalPopUpWindow(form, this);
        }
    }
}

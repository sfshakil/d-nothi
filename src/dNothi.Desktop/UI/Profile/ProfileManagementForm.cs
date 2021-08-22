using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using dNothi.Services.ProfileChangeService;
using dNothi.Services.UserServices;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Profile
{
    public partial class ProfileManagementForm : Form
    {
        IUserService _userService { get; set; }
        IProfileManagementServices _profileManagementServices { get; set; }

        public ProfileManagementForm(IUserService userService, IProfileManagementServices profileManagementServices)
        {
            _userService = userService;
            _profileManagementServices = profileManagementServices;

            InitializeComponent();
        }

        private void Blue_Border_Color_Panel(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Gray(sender, e);
        }

        private void informationIconButton_Click(object sender, EventArgs e)
        {
            UnSelectOtherButton(informationIconButton);
            RefreshInformationTable();
            InformationTableEditable(false);
            
        }

        private void InformationTableEditable(bool isenable)
        {
            fatherNameBanglaTextBox.Enabled = isenable;
            fatherNameEngTextBox.Enabled = isenable;

            motherNameBanglaTextBox.Enabled = isenable;
            motherNameEngTextBox.Enabled = isenable;
            
            genderComboBox.Enabled = isenable;
            personalMobile2TextBox.Enabled = isenable;
            religionComboBox.Enabled = isenable;
            maritialStatusComboBox.Enabled = isenable;
            bloodGroupComboBox.Enabled = isenable;
            loginNameTextBox.Enabled = isenable;
        }

        private void RefreshInformationTable()
        {
            
        }

        private Color unselectButtonColo=Color.FromArgb(100, 108, 154);
        private Color selectButtonColo=Color.FromArgb(34, 138, 232);
        private void UnSelectOtherButton(IconButton iconButton)
        {
            if(iconButton!=informationIconButton)
            {
                informationIconButton.IconColor = unselectButtonColo;
                informationIconButton.ForeColor = unselectButtonColo;
                informationTableLayoutPanel.Visible = false;
            }
            else
            {
                informationIconButton.IconColor = selectButtonColo;
                informationIconButton.ForeColor = selectButtonColo;
                informationTableLayoutPanel.Visible = true;
            }
            if (iconButton != passwordIconButton)
            {
                passwordIconButton.IconColor = unselectButtonColo;
                passwordIconButton.ForeColor = unselectButtonColo;
                passwordTableLayoutPanel.Visible = false;
            }
            else
            {
                passwordIconButton.IconColor = selectButtonColo;
                passwordIconButton.ForeColor = selectButtonColo;
                passwordTableLayoutPanel.Visible = true;
            }


            if (iconButton != signIconButton)
            {
                signIconButton.IconColor = unselectButtonColo;
                signIconButton.ForeColor = unselectButtonColo;
                signTableLayoutPanel.Visible = false;
            }
            else
            {
                signIconButton.IconColor = selectButtonColo;
                signIconButton.ForeColor = selectButtonColo;
                signTableLayoutPanel.Visible = true;
            }

            if (iconButton != profilePicIconButton)
            {
                profilePicIconButton.IconColor = unselectButtonColo;
                profilePicIconButton.ForeColor = unselectButtonColo;
                pictureChangeTableLayoutPanel.Visible = false;
            }
            else
            {
                profilePicIconButton.IconColor = selectButtonColo;
                profilePicIconButton.ForeColor = selectButtonColo;
                pictureChangeTableLayoutPanel.Visible = true;
            }


        }

        private void ProfileManagementForm_Load(object sender, EventArgs e)
        {

          

            LoadUserProfileData();
        }


        

        private DakUserParam _dakUserParam;
        private void LoadUserProfileData()
        {
            _dakUserParam = _userService.GetLocalDakUserParam();

            //var profileImage = UIDesignCommonMethod.GetImageFromBase64(_dakUserParam.);
            //if (profileImage != null)
            //{

            //    signatureIconPictureBox.Image = profileImage;

            //}

            officerNameLabel.Text = _dakUserParam.officer_name;
            officerDesignationLabel.Text = _dakUserParam.designation_label + "," + _dakUserParam.unit_label + "," + _dakUserParam.office_label;
           
            officerEmailLabel.Text = _dakUserParam.officer_email;
            officerMobileLabel.Text = _dakUserParam.officer_mobile;
            officerUserIdLabel.Text = _dakUserParam.user_id.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void infoChangeIconButton_Click(object sender, EventArgs e)
        {
            InformationTableEditable(true);
        }

        private void passwordIconButton_Click(object sender, EventArgs e)
        {
            UnSelectOtherButton(passwordIconButton);
        }


        private void choosePicButton_Click(object sender, EventArgs e)
        {
            UploadPictureUserControl uploadPictureUserControl = new UploadPictureUserControl();
            uploadPictureUserControl.ChooseImage();
            uploadPictureUserControl.SaveImageButton += delegate (object sr, EventArgs ev) { SaveProfileImage(sr, ev, uploadPictureUserControl._PictureBoxImage); };

            UIDesignCommonMethod.CalPopUpWindow(uploadPictureUserControl, this);
        }

        private void SaveProfileImage(object sr, EventArgs ev, Image pictureBoxImage)
        {
            officerEditablePictureBox.Image = pictureBoxImage;
        }

        private void signChangeButton_Click(object sender, EventArgs e)
        {
            UploadPictureUserControl uploadPictureUserControl = new UploadPictureUserControl();
            uploadPictureUserControl.ChooseImage();
            uploadPictureUserControl.SaveImageButton += delegate (object sr, EventArgs ev) { SaveSignatureImage(sr, ev, uploadPictureUserControl._PictureBoxImage); };

            UIDesignCommonMethod.CalPopUpWindow(uploadPictureUserControl, this);
        }

        private void SaveSignatureImage(object sr, EventArgs ev, Image pictureBoxImage)
        {
            signatureEditablePictureBox.Image = pictureBoxImage;
        }

        private void profilePicIconButton_Click(object sender, EventArgs e)
        {
            UnSelectOtherButton(profilePicIconButton);
        }
        private void signIconButton_Click(object sender, EventArgs e)
        {
            UnSelectOtherButton(signIconButton);
        }


        Button btn = new Button();
        bool pass_hide = true;
        protected override void OnLoad(EventArgs e)
        {

            btn.Size = new Size(33, newPasswordTextBox.ClientSize.Height + 2);
            btn.Location = new Point(newPasswordTextBox.ClientSize.Width - btn.Width, -1);
            btn.BringToFront();
            btn.Cursor = Cursors.Default;
            btn.Click += pasword_Show;
            btn.FlatStyle = FlatStyle.Flat;

            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btn.FlatAppearance.BorderSize = 0;
            btn.TabIndex = 15;
            btn.Image = Properties.Resources.icons8_eye_15;
            newPasswordTextBox.Controls.Add(btn);

            SendMessage(newPasswordTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
            base.OnLoad(e);



        }

        private void pasword_Show(object sender, EventArgs e)
        {
            if (pass_hide)
            {
                btn.Image = Properties.Resources.icons8_hide_15;
                pass_hide = false;

            }
            else
            {
                btn.Image = Properties.Resources.icons8_eye_15;
                pass_hide = true;
            }
            newPasswordTextBox.PasswordChar = newPasswordTextBox.PasswordChar == '\0' ? '●' : '\0';


        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void passwordSaveIconButton_Click(object sender, EventArgs e)
        {
            if(confirmNewPasswordTextBox.Text==newPasswordTextBox.Text)
            {
                PasswordChangeParam passwordChangeParam = new PasswordChangeParam();
                PasswordChangeResponse passwordChangeResponse = _profileManagementServices.GetPasswordChangeResponse(_dakUserParam, passwordChangeParam);
                if(passwordChangeResponse.status=="success")
                {
                    UIDesignCommonMethod.SuccessMessage(passwordChangeResponse.data);
                }
                else
                {
                    UIDesignCommonMethod.SuccessMessage(passwordChangeResponse.message);
                }
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("নতুন পাসওয়ার্ড এবং পুনরায় পাসওয়ার্ড অবশ্যই একই হতে হবে।");
            }
        }
    }
}

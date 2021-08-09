using dNothi.JsonParser.Entity;
using dNothi.Services.AccountServices;
using dNothi.Services.UserServices;
using dNothi.Services.DakServices;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using dNothi.Desktop.Interfaces;
using System.Text.RegularExpressions;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Services.SyncServices;
using System.Diagnostics;
using Microsoft.Win32;
using dNothi.Utility;

namespace dNothi.Desktop.UI
{
    public partial class Login : Form
    {
        Button btn = new Button();
        bool pass_hide = true;
       
        

        IAccountService _accountService { get; set; }
        IUserService _userService { get; set; }
        ISyncerService _syncerservice { get; set; }
        
        public Login(IUserService userService, IAccountService accountService, ISyncerService syncerservice)
        {
            InitializeComponent();
            select_UserID();
            //this.pnlUserId.Show();
            _userService = userService;
            _accountService = accountService;
            _syncerservice = syncerservice;
        }
        public void select_UserID()
        {
           
        }


        UserNamePanel ucUserNamePanel = new UserNamePanel();
        
        public void userName()
        {
                ucUserNamePanel.Visible = true;
                ucUserNamePanel.Location = new System.Drawing.Point(8, 73);
                Controls.Add(ucUserNamePanel);
                ucUserNamePanel.BringToFront();
        }

        PasswordResetPanel ucPasswordResetPanel = new PasswordResetPanel();
        private void passwordReset()
        {
            ucPasswordResetPanel.Visible = true;
            ucPasswordResetPanel.Location = new System.Drawing.Point(278 + 420, 60 + 151);
            Controls.Add(ucPasswordResetPanel);
            ucPasswordResetPanel.BringToFront();
        }
        private void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {
            UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
            alertMessageBox.message = mulpotroNotSelectErrorMessage;

            alertMessageBox.ShowDialog();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUser.Text.Trim();
            var password = txtPassword.Text.Trim();
            var isRemember = true;
            UserParam userParam = new UserParam(userName, password);
            try
            {
                var resmessage = await _userService.GetUserMessageAsync(userParam);

                if (resmessage.status == "success")
                {
                    _accountService.SaveOrUpdateUser(userName, password, isRemember);

                    // Sign Assign
                    resmessage.data.user.SignBase64 = resmessage.data.signature.encode_sign;

                    SaveOrUpdateUser(resmessage?.data?.user);
                    SaveOrUpdateEmployee(resmessage?.data?.employee_info);
                    SaveOrUpdateOffice(resmessage?.data?.office_info);
                    SaveOrUpdateToken(resmessage?.data?.token);

                    DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                    // _syncerservice.SyncDak(dakUserParam);


                    HideAndSHow();

                    this.Hide();
                    var form = FormFactory.Create<Dashboard>();

                    form.ShowDialog();


                }
                else
                {
                    ShowAlertMessage("আপনি ভূল ইউজার নেম অথবা পাসওয়ার্ড ইনপুট দিয়েছেন।");
                }
            }
            catch(Exception Ex)
            {
                var appUser = _accountService.LoginUser(userName, password);
                if (appUser != null)
                {
                    this.Hide();
                    var form = FormFactory.Create<Dashboard>();

                    form.ShowDialog();
                }

                else
                {
                    ShowAlertMessage("আপনার ইন্টারনেট সংযোগ বিচ্ছিন্ন রযেছে।");
                }

            }
        }

        private void HideAndSHow()
        {
            HideAndShowData.Refresh();
        }

        private void SaveOrUpdateToken(string token)
        {
            _userService.SaveOrUpdateToken(token);
        }

        private void SaveOrUpdateUser(UserDTO userDTO)
        {
            _userService.SaveOrUpdateUser(userDTO);
        }
        private void SaveOrUpdateEmployee(EmployeeInfoDTO employeeInfoDTO)
        {
            _userService.SaveOrUpdateUserEmployeeInfo(employeeInfoDTO);
        }

        private void SaveOrUpdateOffice(List<OfficeInfoDTO> officeInfoDTO)
        {
            _userService.DeleteLocalOfficeInfo();
            _userService.SaveOrUpdateUserOfficeInfo(officeInfoDTO);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            txtUser.Text = "200000002986";
            txtPassword.Text = "abc123";
           
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if(ctrl.Name== "txtPassword")
                {
                    continue;
                }

               
                    if(ctrl.Font.Style!=FontStyle.Regular)
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
        private void txtUser_Leave(object sender, EventArgs e)
        {
                string userId = txtUser.Text.ToString();
                if (userId.Length < 12)
                {
                    if (userId.Length > 0)
                    {
                        string WithoutFirstDigit = userId.Substring(1);
                        string newString = WithoutFirstDigit.PadLeft(11, '0');
                        newString = userId[0] + newString;

                        txtUser.Text = newString;
                    }
                    else
                    {
                        txtUser.Text = "";
                    }
                }
                else
                {
                    txtUser.Text = userId;
                }
            
        }

       

       
       

        
       

      

        

        
     

        
        //private void txtUserId_Enter(object sender, EventArgs e)
        //{
        //    txtUserId.Visible = false;
        //    txtUser.Focus();
        //    if (txtPassword.Text == "")
        //    {
        //        txtUserPassword.Visible = true;
        //    }
        //    else
        //    {
        //        txtUserPassword.Visible = false;
        //    }
        //}
        //private void txtUserPassword_Enter(object sender, EventArgs e)
        //{
        //    txtUserPassword.Visible = false;

        //    txtPassword.Focus();
        //}

        private void Login_Load(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.Hide();

            SetDefaultFont(this.Controls);
            //Screen scr = Screen.FromPoint(this.Location);
            //this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        protected override void OnLoad(EventArgs e)
        {
           
            btn.Size = new Size(33, txtPassword.ClientSize.Height + 2);
            btn.Location = new Point(txtPassword.ClientSize.Width - btn.Width, -1);
            btn.BringToFront();
            btn.Cursor = Cursors.Default;
            btn.Click += pasword_Show;
            btn.FlatStyle = FlatStyle.Flat;

            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn.FlatAppearance.BorderSize = 0;
            btn.TabIndex = 15;
            btn.Image = Properties.Resources.icons8_eye_15;
            txtPassword.Controls.Add(btn);
          
            SendMessage(txtPassword.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
            base.OnLoad(e);


            this.AcceptButton = userLoginByUserIdButton;
        }

            private void pasword_Show(object sender, EventArgs e)
        {
            if(pass_hide)
            {
                btn.Image = Properties.Resources.icons8_hide_15;
                pass_hide = false;
                
            }
            else
            {
                btn.Image = Properties.Resources.icons8_eye_15;
                pass_hide = true;
            }
            txtPassword.PasswordChar = txtPassword.PasswordChar == '\0' ? '●' : '\0';
           
           
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

 

        private void txtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {


            validateTxtPass(e);

            

        }

        private void validateTxtPass(KeyPressEventArgs e)
        {
            if (!_userService.ValidatePassword(e.KeyChar))
            {
               ShowAlertMessage(_userService.InvalidPasswordMessage());
                e.Handled = true;
            }
           
        }

        private void userIdPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            //if(txtPassword.Text=="")
            //{
            //    txtPassword.PasswordChar = '\0';
            //}
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '●';
            }
        }

        private void OpenBrowser(string linkname)
        {
            RegistryKey browserKeys;
           
            browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

                string[] browserNames = browserKeys.GetSubKeyNames();

                if (browserNames.Contains("Google Chrome"))
                {
                    Process.Start("chrome", linkname);
                }
                else
                {
                    if (browserNames.Contains("Firefox"))
                    {
                        Process.Start("firefox", linkname);
                    }
                    else
                    {
                        if (browserNames.Contains("IEXPLORE.EXE"))
                        {
                            Process.Start("iexplore", linkname);
                        }
                        else
                        {
                            if (browserNames.Contains("Microsoft Edge"))
                            {
                                Process.Start("iexplore", linkname);
                            }
                        
                            Process.Start(linkname);
                        }
                    }
                }
        }
        struct LinkNames
        {
            public const string lg = "https://fb.com/groups/nothi/";
            public const string mg = "https://nothi-next.tappware.com/mobile-app";
            public const string bc = "https://nothi-next.tappware.com/#";
            public const string faq = "https://nothi-next.tappware.com/faq";
            public const string up = "https://nothi-next.tappware.com/release-note";
            public const string nt = "https://nothi-next.tappware.com/notice";
            public const string um = "https://nothi-next.tappware.com/user-manual";
            public const string vt = "https://nothi-next.tappware.com/video/tutorial";
           // public const string vtn = "https://nothi-next.tappware.com/#";
        }

        private void label29_Click(object sender, EventArgs e)
        {
            
            OpenBrowser(LinkNames.lg);
         
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.vt);
           // Process.Start("chrome.exe", "https://nothi-next.tappware.com/video/tutorial");
            
        }

        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            OpenBrowser(LinkNames.vt);
           // Process.Start("chrome.exe", "https://nothi-next.tappware.com/video/tutorial");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.mg);
           // Process.Start("chrome.exe", "https://nothi-next.tappware.com/mobile-app");
            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.bc);
            //Process.Start("chrome.exe", "https://nothi-next.tappware.com/#");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.faq);
            //Process.Start("chrome.exe", "https://nothi-next.tappware.com/faq");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.up);
            //Process.Start("chrome.exe", "https://nothi-next.tappware.com/release-note");
        }

        private void label19_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.nt);
           // Process.Start("chrome.exe", "https://nothi-next.tappware.com/notice");
        }

        private void label21_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.um);
           // Process.Start("chrome.exe", "https://nothi-next.tappware.com/user-manual");
        }

        private void label31_Click(object sender, EventArgs e)
        {
            OpenBrowser(LinkNames.bc);
            //Process.Start("chrome.exe", "https://nothi-next.tappware.com/#");
        }

        private void label28_Click(object sender, EventArgs e)
        {
           //Process.Start("chrome.exe", "mailto: support @nothi.org.bd");
           
        }
    }
}

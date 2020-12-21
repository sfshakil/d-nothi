﻿using dNothi.JsonParser.Entity;
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

namespace dNothi.Desktop.UI
{
    public partial class Login : Form
    {
       
        IAccountService _accountService { get; set; }
        IUserService _userService { get; set; }
        
        public Login(IUserService userService, IAccountService accountService)
        {
            InitializeComponent();
            select_UserID();
            this.pnlUserId.Show();
            _userService = userService;
            _accountService = accountService;
        }
        public void select_UserID()
        {
            this.btnUserId.ForeColor = Color.Indigo;
            this.pnlUserIdTop.BackColor = Color.Indigo;
            this.btnUserId.FlatAppearance.BorderColor = Color.Gainsboro;
            this.pnlUserIdNamePasswordBottom.BackColor = Color.Gainsboro;
            this.btnUserName.ForeColor = Color.Black;
            this.pnlUserNameTop.BackColor = Color.White;
            this.btnUserName.FlatAppearance.BorderColor = Color.White;
            this.btnPasswordReset.ForeColor = Color.Black;
            this.pnlPasswordResetTop.BackColor = Color.White;
            this.btnPasswordReset.FlatAppearance.BorderColor = Color.White;
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
                    SaveOrUpdateUser(resmessage?.data?.user);
                    SaveOrUpdateEmployee(resmessage?.data?.employee_info);
                    SaveOrUpdateOffice(resmessage?.data?.office_info);
                    SaveOrUpdateToken(resmessage?.data?.token);
                    using (var form = FormFactory.Create<Dashboard>())
                    {
                        form.ShowDialog();
                    }
                }
            }
            catch
            {
                var appUser = _accountService.LoginUser(userName, password);
                if (appUser != null)
                {
                    var form = FormFactory.Create<Dashboard>();

                    form.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Login Failed!");
                }

            }
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
            _userService.SaveOrUpdateUserOfficeInfo(officeInfoDTO);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            txtUser.Text = "200000002986";
            txtPassword.Text = "abc123";
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

        private void lbMobileNo1_MouseHover(object sender, EventArgs e)
        {
            this.lbMobileNo1.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
        }

        private void lbMobileNo1_MouseLeave(object sender, EventArgs e)
        {
            this.lbMobileNo1.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void lbMobileNo2_MouseHover(object sender, EventArgs e)
        {
            this.lbMobileNo2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
        }

        private void lbMobileNo2_MouseLeave(object sender, EventArgs e)
        {
            this.lbMobileNo2.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void lbMobileNo3_MouseHover(object sender, EventArgs e)
        {
            this.lbMobileNo3.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
        }

        private void lbMobileNo3_MouseLeave(object sender, EventArgs e)
        {
            this.lbMobileNo3.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void btnUserId_MouseHover(object sender, EventArgs e)
        {
            this.btnUserId.ForeColor = Color.Indigo;
            this.pnlUserIdTop.BackColor = Color.Indigo;
            this.btnUserId.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void btnUserId_Click(object sender, EventArgs e)
        {
            loginFlowLayoutPanel.Controls.Clear();
            loginFlowLayoutPanel.Controls.Add(pnlUserId);

            this.pnlUserIdNamePasswordBottom.BackColor = Color.Gainsboro;
            this.btnUserName.ForeColor = Color.Black;
            this.pnlUserNameTop.BackColor = Color.White;
            this.btnUserName.FlatAppearance.BorderColor = Color.White;
            this.btnPasswordReset.ForeColor = Color.Black;
            this.pnlPasswordResetTop.BackColor = Color.White;
            this.btnPasswordReset.FlatAppearance.BorderColor = Color.White;
            
            ucUserNamePanel.Visible = false;
            ucPasswordResetPanel.Visible = false;
            this.pnlUserId.Show();
        }

        private void btnUserName_MouseHover(object sender, EventArgs e)
        {
            this.btnUserName.ForeColor = Color.Indigo;
            this.pnlUserNameTop.BackColor = Color.Indigo;
            this.btnUserName.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void btnUserName_Click(object sender, EventArgs e)
        {
            loginFlowLayoutPanel.Controls.Clear();
            UserNamePanel ucUserNamePanel = new UserNamePanel();
            loginFlowLayoutPanel.Controls.Add(ucUserNamePanel);

            this.btnUserId.ForeColor = Color.Black;
            this.pnlUserIdTop.BackColor = Color.White;
            this.btnUserId.FlatAppearance.BorderColor = Color.White;
            this.pnlUserIdNamePasswordBottom.BackColor = Color.Gainsboro;
            this.btnUserName.ForeColor = Color.Indigo;
            this.pnlUserNameTop.BackColor = Color.Indigo;
            this.btnUserName.FlatAppearance.BorderColor = Color.Gainsboro;
            this.btnPasswordReset.ForeColor = Color.Black;
            this.pnlPasswordResetTop.BackColor = Color.White;
            this.btnPasswordReset.FlatAppearance.BorderColor = Color.White;
        }

        private void btnPasswordReset_MouseHover(object sender, EventArgs e)
        {
            this.btnPasswordReset.ForeColor = Color.Indigo;
            this.pnlPasswordResetTop.BackColor = Color.Indigo;
            this.btnPasswordReset.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            loginFlowLayoutPanel.Controls.Clear();
            PasswordResetPanel passwordResetPanel = new PasswordResetPanel();
            loginFlowLayoutPanel.Controls.Add(passwordResetPanel);


            this.btnUserId.ForeColor = Color.Black;
            this.pnlUserIdTop.BackColor = Color.White;
            this.btnUserId.FlatAppearance.BorderColor = Color.White;
            this.pnlUserIdNamePasswordBottom.BackColor = Color.Gainsboro;
            this.btnUserName.ForeColor = Color.Black;
            this.pnlUserNameTop.BackColor = Color.White;
            this.btnUserName.FlatAppearance.BorderColor = Color.White;
            this.btnPasswordReset.ForeColor = Color.Indigo;
            this.pnlPasswordResetTop.BackColor = Color.Indigo;
            this.btnPasswordReset.FlatAppearance.BorderColor = Color.Gainsboro;
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
             
           
        

    }
        protected override void OnLoad(EventArgs e)
        {
            var btn = new Button();
            btn.Size = new Size(33, txtPassword.ClientSize.Height + 2);
            btn.Location = new Point(txtPassword.ClientSize.Width - btn.Width, -1);
            btn.BringToFront();
            btn.Cursor = Cursors.Default;
            btn.Click += pasword_Show;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Image = Properties.Resources.icons8_eye_15;
            txtPassword.Controls.Add(btn);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(txtPassword.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
            base.OnLoad(e);
        }

            private void pasword_Show(object sender, EventArgs e)
        {
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Input Only English Character!");
            }

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}
        }
    }
}

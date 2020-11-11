using dNothi.JsonParser.Entity;
using dNothi.Services.AccountServices;
using dNothi.Services.UserServices;
using Nothi.Services.DakServices;
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

namespace dNothi.Desktop.UI
{
    public partial class Login : Form
    {
        //public Login()
        //{
        //    InitializeComponent();
        //    select_UserID();
        //    this.panel13.Show();

        //}
        IAccountService _accountService { get; set; }
        IUserService _userService { get; set; }
        IDakInboxLIstServices _dakInbox { get; set; }
        public Login(IUserService userService, IAccountService accountService, IDakInboxLIstServices dakInboxLIst)
        {
            InitializeComponent();
            select_UserID();
            this.panel13.Show();
            _userService = userService;
            _accountService = accountService;
            _dakInbox = dakInboxLIst;
        }
        public void select_UserID()
        {
            this.button6.ForeColor = Color.Indigo;
            this.panel5.BackColor = Color.Indigo;
            this.button6.FlatAppearance.BorderColor = Color.Gainsboro;
            this.panel8.BackColor = Color.Gainsboro;
            this.button7.ForeColor = Color.Black;
            this.panel6.BackColor = Color.White;
            this.button7.FlatAppearance.BorderColor = Color.White;
            this.button8.ForeColor = Color.Black;
            this.panel7.BackColor = Color.White;
            this.button8.FlatAppearance.BorderColor = Color.White;
        }
        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.button6.ForeColor = Color.Indigo;
            this.panel5.BackColor = Color.Indigo;
            this.button6.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            this.button7.ForeColor = Color.Indigo;
            this.panel6.BackColor = Color.Indigo;
            this.button7.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            this.button8.ForeColor = Color.Indigo;
            this.panel7.BackColor = Color.Indigo;
            this.button8.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            select_UserID();
            ucUserNamePanel.Visible = false;
            ucPasswordResetPanel.Visible = false;
            this.panel13.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.panel13.Hide();
            userName();
            this.button6.ForeColor = Color.Black;
            this.panel5.BackColor = Color.White;
            this.button6.FlatAppearance.BorderColor = Color.White;
            this.panel8.BackColor = Color.Gainsboro;
            this.button7.ForeColor = Color.Indigo;
            this.panel6.BackColor = Color.Indigo;
            this.button7.FlatAppearance.BorderColor = Color.Gainsboro;
            this.button8.ForeColor = Color.Black;
            this.panel7.BackColor = Color.White;
            this.button8.FlatAppearance.BorderColor = Color.White;
        }

        UserNamePanel ucUserNamePanel = new UserNamePanel();
        
        public void userName()
        {
                ucUserNamePanel.Visible = true;
                ucUserNamePanel.Location = new System.Drawing.Point(278+420, 60+ 151);
                Controls.Add(ucUserNamePanel);
                ucUserNamePanel.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            passwordReset();
            ucUserNamePanel.Visible = false;
            this.panel13.Hide();
            this.button6.ForeColor = Color.Black;
            this.panel5.BackColor = Color.White;
            this.button6.FlatAppearance.BorderColor = Color.White;
            this.panel8.BackColor = Color.Gainsboro;
            this.button7.ForeColor = Color.Black;
            this.panel6.BackColor = Color.White;
            this.button7.FlatAppearance.BorderColor = Color.White;
            this.button8.ForeColor = Color.Indigo;
            this.panel7.BackColor = Color.Indigo;
            this.button8.FlatAppearance.BorderColor = Color.Gainsboro;
        }
        PasswordResetPanel ucPasswordResetPanel = new PasswordResetPanel();
        private void passwordReset()
        {
            ucPasswordResetPanel.Visible = true;
            ucPasswordResetPanel.Location = new System.Drawing.Point(278 + 420, 60 + 151);
            Controls.Add(ucPasswordResetPanel);
            ucPasswordResetPanel.BringToFront();
        }

        private void xTextBox1_MouseHover(object sender, EventArgs e)
        {
            //this.txtUser.Text = "";
        }

        private void xTextBox1_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUser.Text))
            {
               
            }
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            this.label10.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            this.label10.Font = new Font("Microsoft Sans Serif", 8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.ShowDialog();
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUser.Text.Trim();
            var password = txtPassword.Text.Trim();
            var isRemember = true;
            UserParam userParam = new UserParam(userName, password);
            var resmessage = await _userService.GetUserMessageAsync(userParam);


            if (resmessage.status == "success")
            {
                _accountService.SaveOrUpdateUser(userName, password, isRemember);
                SaveOrUpdateUser(resmessage?.data?.user);
                SaveOrUpdateEmployee(resmessage?.data?.employee_info);
                SaveOrUpdateOffice(resmessage?.data?.office_info);
                SaveOrUpdateToken(resmessage?.data?.token);
                // Call DakInbox
                var dakInbox =  _dakInbox.GetDakInbox(resmessage.data.token);
                if(dakInbox.status=="success")
                {
                    foreach(var record in dakInbox.data.records)
                    {

                        _dakInbox.SaveOrUpdateDakUser(record.dak_user);
                    }
                if(dakInbox.data.records.Count>0)
                    {

                        Form form = new Dashboard(dakInbox.data.records);
                        form.Show();
                       

                    }

                }


                using (var form = FormFactory.Create<Dashboard>())
                {
                    form.ShowDialog();
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

      

       

       
        
       

        private void FackPasswordTextBox_Enter(object sender, EventArgs e)
        {

            FackPasswordTextBox.Visible = false;

            txtPassword.Focus();
        }

        private void xTextBoxFake_Enter(object sender, EventArgs e)
        {
          
            xTextBoxFake.Visible = false;
            
            if (txtPassword.Text == "")
            {
                FackPasswordTextBox.Visible = true;
            }
            else
            {
                FackPasswordTextBox.Visible = false;
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
                        txtUser.Text = "000000000000";
                    }



                }
                else
                {
                    txtUser.Text = userId;
                }
            
            
        }
    }
}

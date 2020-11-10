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

            this.panel13.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.panel13.Hide();
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

        private void button8_Click(object sender, EventArgs e)
        {

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

        public void userid()
        {

            Panel dynamicPanel = new Panel();
            dynamicPanel.BackColor = System.Drawing.SystemColors.Window;
            
            dynamicPanel.Location = new System.Drawing.Point(692, 204);
            dynamicPanel.Name = "panel14";
            dynamicPanel.Size = new System.Drawing.Size(405, 467);
            dynamicPanel.TabIndex = 8;

            XTextBox xTextBox2 = new XTextBox();
            xTextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            xTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            xTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xTextBox2.ForeColor = System.Drawing.Color.DimGray;
            xTextBox2.Location = new System.Drawing.Point(21, 16);
            xTextBox2.Multiline = true;
            xTextBox2.Name = "xTextBox2";
            xTextBox2.Size = new System.Drawing.Size(161, 31);
            xTextBox2.TabIndex = 7;
            xTextBox2.Text = "ইউজার নেম";

            MetroTextBox metroTextBox2 = new MetroTextBox();
            metroTextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            metroTextBox2.CustomBackground = true;
            metroTextBox2.CustomForeColor = true;
            metroTextBox2.ForeColor = System.Drawing.Color.DimGray;
            metroTextBox2.Location = new System.Drawing.Point(214, 16);
            metroTextBox2.Name = "metroTextBox2";
            metroTextBox2.PasswordChar = '●';
            metroTextBox2.PromptText = "পাসওয়ার্ড";
            metroTextBox2.Size = new System.Drawing.Size(161, 31);
            metroTextBox2.TabIndex = 8;
            metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroTextBox2.UseStyleColors = true;
            metroTextBox2.UseSystemPasswordChar = true;

            Label label25 = new Label();
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.ForeColor = System.Drawing.Color.SaddleBrown;
            label25.Location = new System.Drawing.Point(7, 8);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(252, 24);
            label25.TabIndex = 0;
            label25.Text = "ইউজার নেম ব্যবহার করে প্রবেশ করুন";

            Panel panel15 = new Panel();
            panel15.BackColor = System.Drawing.Color.Moccasin;
            panel15.Controls.Add(label25);
            panel15.Location = new System.Drawing.Point(19, 72);
            panel15.Name = "panel15";
            panel15.Size = new System.Drawing.Size(264, 38);
            panel15.TabIndex = 9;

            

            Button button10 = new Button();
            button10.BackColor = System.Drawing.Color.RoyalBlue;
            button10.FlatAppearance.BorderColor = System.Drawing.Color.White;
            button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button10.ForeColor = System.Drawing.Color.WhiteSmoke;
            //this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            button10.Location = new System.Drawing.Point(289, 72);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(86, 38);
            button10.TabIndex = 10;
            button10.Text = "প্রবেশ";
            button10.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            button10.UseVisualStyleBackColor = false;

            dynamicPanel.Controls.Add(xTextBox2);
            dynamicPanel.Controls.Add(metroTextBox2);
            dynamicPanel.Controls.Add(panel15);
            dynamicPanel.Controls.Add(button10);
            Controls.Add(dynamicPanel);
            
            

            // 
            // xTextBox2
            // 
            
            // 
            // metroTextBox2
            // 
            
            // 
            // panel15
            // 
            
            // 
            // label25
            // 
            
            // 
            // button10
            // 
            
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

                // Call DakInbox
                var dakInbox =  _dakInbox.GetDakInbox(resmessage.data.token);
                if(dakInbox.status=="success")
                {
                    foreach(var record in dakInbox.data.records)
                    {

                        _dakInbox.SaveOrUpdateDakUser(record.dak_user);
                    }
                }




                using (var form = FormFactory.Create<Dashboard>())
                {
                    form.ShowDialog();
                }
            }
        }
        private void SaveOrUpdateUser(UserDTO userDTO)
        {
            _userService.SaveOrUpdateUser(userDTO);
        }
        private void SaveOrUpdateEmployee(EmployeeInfoDTO employeeInfoDTO)
        {
            _userService.SaveOrUpdateUserEmployeeInfo(employeeInfoDTO);
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

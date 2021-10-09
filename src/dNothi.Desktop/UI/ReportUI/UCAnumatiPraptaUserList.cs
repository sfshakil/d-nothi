using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using dNothi.Services.ReportPermited;
using dNothi.Services.ReportPermited.Model;

namespace dNothi.Desktop.UI.ReportUI
{
    public partial class UCAnumatiPraptaUserList : UserControl
    {
        IUserService _userService { get; set; }
        IReportPermissionServices _reportPermissionServices { get; set; }

        AllAlartMessage alartMessage = new AllAlartMessage();

        string type = string.Empty;
       

       
        public UCAnumatiPraptaUserList(IUserService userService, IReportPermissionServices reportPermissionServices)
        {
            _userService = userService;
            _reportPermissionServices = reportPermissionServices;


              InitializeComponent();
           
           
        }

        private void LoadData()
        {
            userListPanelTableLayoutPanel.Controls.Clear();

            int count = 0;
            var userParam = _userService.GetLocalDakUserParam();

            type = "list";
            var userlist = _reportPermissionServices.ReportPermission(userParam, type, string.Empty);

            if (userlist.status == "success" )
            {
                //noKhosraPanel.Visible = false;
                var userslist= JsonConvert.DeserializeObject<List<ReportPermissionModel.User>>(userlist.data.ToString()); 
                foreach (var item in userslist)
                {

                    UCAnumatiPraptaUser anumatiPraptaUser = new UCAnumatiPraptaUser();

                    count++;
                    anumatiPraptaUser.userNo = ConversionMethod.EngDigittoBanDigit(item.username);
                    anumatiPraptaUser.userId = item.username;
                    anumatiPraptaUser.createDate= item.created;
                    anumatiPraptaUser.serial = ConversionMethod.EngDigittoBanDigit(count.ToString()); 

                    anumatiPraptaUser.decisionDeleteButtonClick += delegate (object sender, EventArgs e) { anumatiPraptaUser_decisionDeleteButtonClick(sender, e, item); };

                    UIDesignCommonMethod.AddRowinTable(userListPanelTableLayoutPanel, anumatiPraptaUser);

                }

            }
            else
            {
                // noKhosraPanel.Visible = true;
            }

        }
        private void anumatiPraptaUser_decisionDeleteButtonClick(object sender,EventArgs e, ReportPermissionModel.User user)
        {
            
                var userParam = _userService.GetLocalDakUserParam();
                type = "delete";
                var userlist = _reportPermissionServices.ReportPermission(userParam, type, user.username);

                if (userlist.status == "success")
                {
                    UIDesignCommonMethod.SuccessMessage(userlist.data.ToString());
                  
                    LoadData();
                }
                else
                {
                  UIDesignCommonMethod.ErrorMessage(userlist.data.ToString());

               }

        }
      

        private void Table_Border_Color_Blue(object sender, PaintEventArgs e)
        {
           // UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }

        private void Table_Border_Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }



        private void userIdBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void userIdSaveButton_Click(object sender, EventArgs e)
        {
           
           
            string userid = userIdTextBox.Text;

           
            if (userid != string.Empty)
            {
                var userParam = _userService.GetLocalDakUserParam();
                type = "add";
                var userlist = _reportPermissionServices.ReportPermission(userParam, type, userid);

                if (userlist.status == "success")
                {
                    var users= JsonConvert.DeserializeObject<ReportPermissionModel.User>(userlist.data.ToString());
                    UIDesignCommonMethod.SuccessMessage(userlist.message);
                    userIdTextBox.Text = string.Empty;
                    LoadData();
                }
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("ব্যবহারকারীর ইউজার আইডি দিতে হবে");
            }
        }

        private void UCAnumatiPraptaUserList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

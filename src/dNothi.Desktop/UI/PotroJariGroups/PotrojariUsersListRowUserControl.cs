using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.PotroJariGroup.Models;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class PotrojariUsersListRowUserControl : UserControl
    {
        public PotrojariUsersListRowUserControl()
        {
            InitializeComponent();
        }
        private bool _isPatrajariGroupFromKasra { get; set; }
        public bool isPatrajariGroupFromKasra { get=> _isPatrajariGroupFromKasra; set {
                _isPatrajariGroupFromKasra = value;
                
                    userCheckBox.Visible = value;
              
            } 
        }
        private bool _isAllChecked { get; set; }
        public bool isAllChecked
        {
            get => _isAllChecked; 
            set
            {
                _isAllChecked = value;
                
                userCheckBox.Checked = value;
                
            }
        }


        public int _id { get; set; }
        public int id { get { return _id; } set { _id = value;  } }
        public int _designationId { get; set; }
        public int designationId { get { return _designationId; } set { _designationId = value; } }

        public int _groupId { get; set; }
        public int groupId { get { return _groupId; } set { _groupId = value; } }
        public string _groupName { get; set; }
        public string groupName { get { return _groupName; } set { _groupName = value; } }
        public string _UserName { get; set; }
        public string UserName { get {return _UserName ; } set { _UserName = value ; userNameLabel.Text = value; } }

       
        public string _UserDesignation { get; set; }
        public string UserDesignation { get { return _UserDesignation; } set { _UserDesignation = value; userDesignationLabel.Text = value; } }


        public string _UserOfficeName { get; set; }
        public string UserOfficeName { get { return _UserOfficeName; } set { _UserOfficeName = value; userOfficeLabel.Text = value; } }

        public event EventHandler userCheckBoxCheckedChanged;
        private void userCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PotrojariGroupModel.User users = new PotrojariGroupModel.User();
            users.officer = _UserName;
            users.designation = _UserDesignation;
            users.officer_email = _UserOfficeName;
            users.id = _id;
            users.group_id = _groupId;
            if (userCheckBox.Checked)
            {
                users.isRemoved = false;
            }
            else
            {
                users.isRemoved = true;
            }
            if (this.userCheckBoxCheckedChanged!=null)
            {
                this.userCheckBoxCheckedChanged(users, e);
            }

        }

        private void userCheckBox_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Desktop.UI.GuardFileUI;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class GuarFileListViewDeleteUC : UserControl
    {
        IDakForwardService _dakForwardService { get; set; }
        IUserService _userService { get; set; }
       
        public GuarFileListViewDeleteUC(IDakForwardService dakForwardService, IUserService userService)
        {
            _dakForwardService = dakForwardService;
            _userService = userService;
            InitializeComponent();
        }


        public int _id { get; set; }
       
        public string _name { get; set; }
        public string _type { get; set; }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;

                typeNameLabel.Text = value;
              

            }

        }
        public string type
        {
            get { return _type; }
            set
            {
                _type = value;

                typeLabel.Text = value;


            }

        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private void guardFileViewButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("সফল হ​য়েছে।");
        }

        private void guardFileDeleteButton_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি নিশ্চিতভাবে সিদ্ধান্ত টি মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {


                //gdftype gd = new gdftype();
                //gd.type = typeNameLabel.Text;

                //if (decisionCheckBox.Checked)
                //{
                //    dakDecision.dak_decision_employee = 1;
                //}
                //else
                //{
                //    dakDecision.dak_decision_employee = 0;
                //}

               // gd.rowNo = _id.ToString();
                var status = true;

                //DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

                //DakDecisionDeleteResponse dakDecisionAddResponse = _dakForwardService.GetDakDecisionDeleteResponse(dakUserParam, dakDecision);
                if (status)
                {

                    MessageBox.Show("সফল হ​য়েছে।");

                    this.Hide();
                }
            }
        }

        private void Border_Color(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }

        private void Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }

        private void decisionEditRightButton_Click(object sender, EventArgs e)
        {
          
        }

        private void decisionDeleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}

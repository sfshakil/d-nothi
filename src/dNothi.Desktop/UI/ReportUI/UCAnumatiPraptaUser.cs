using System;
using System.Windows.Forms;
using dNothi.Desktop.UI.CustomMessageBox;


namespace dNothi.Desktop.UI.ReportUI
{
    public partial class UCAnumatiPraptaUser : UserControl
    {
        
       
        public UCAnumatiPraptaUser()
        {
            InitializeComponent();
        }


        private string _serial { get; set; }
        private string _userNo { get; set; }
        private string _createDate { get; set; }
        private string _userId { get; set; }

     
        public string serial
        {
            get { return _serial; }
            set
            {
                _serial = value;

                serialLabel.Text = value;


            }

        }
        public string userNo
        {
            get { return _userNo; }
            set
            {
                _userNo = value;

                userIdlabel.Text = value;


            }

        }
        public string createDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value;

                dateLabel.Text = value;


            }

        }
        public string userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

     
        private void Border_Color(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }

        private void Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }

        public event EventHandler decisionDeleteButtonClick;
        private void decisionDeleteButton_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি নিশ্চিতভাবে সিদ্ধান্ত টি মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                if (this.decisionDeleteButtonClick != null)
                    this.decisionDeleteButtonClick(sender, e);
            }
        }
    }
}

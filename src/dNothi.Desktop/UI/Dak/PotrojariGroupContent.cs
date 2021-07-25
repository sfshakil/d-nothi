using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.Services.PotroJariGroup;
using dNothi.Services.UserServices;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dNothi.Services.PotroJariGroup.Models.PotrojariGroupModel;

namespace dNothi.Desktop.UI.Dak
{
    public partial class PotrojariGroupContent : UserControl
    {
        IPotroJariGroupService _potroJariGroupService { get; set; }
       
        IUserService _userService { get; set; }
        private string _creator { get; set; }
        public string creator { get => _creator; 
            
            set { _creator = value;
                if (!string.IsNullOrEmpty(value))
                    lbCreater.Text = value + " গ্রুপটি তৈরি করেছেন";
               
            else
                lbCreater.Text = string.Empty;
            
            }
        }

        private string _groupName { get; set; }
        public string groupName { get => _groupName; set { _groupName = value; lbDetails.Text = value; } }
        private int _totalPerson { get; set; }
        public int totalPerson { get => _totalPerson; set { _totalPerson = value; btnTotalPerson.Text = "মোট সদস্য: "+ ConversionMethod.EnglishNumberToBangla(value.ToString()); } }

        private string _privacyType { get; set; }
        public string privacyType { get => _privacyType; set { _privacyType = value; lbNoteNumber.Text = value; } }
        private bool _isEditable { get; set; }
        public bool isEditable { get => _isEditable; set { _isEditable = value; btnEdit.Visible = value; } }
        private bool _isDelete { get; set; }
        public bool isDelete { get => _isDelete; set { _isDelete = value; btnDelete.Visible = value; } }

        public int id=0;
        private bool isActive = false;
        public List<User> users;
        int clickedId = 0;

        public PotrojariGroupContent(IUserService userService, IPotroJariGroupService potroJariGroupService)
        {
            InitializeComponent();
            _userService = userService;
          
            _potroJariGroupService = potroJariGroupService;
            rvwDashBoardContentShare.Visible = false;

        }
       
        int page = 1;
        int pageLimit = 10;
        int menuNo = 2;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;

        public event EventHandler PotrojariEditButtonClick;
      //  public event EventHandler PotrojariDetailsButtonClick;
        public event EventHandler PotrojariDeleteButtonClick;
        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.PotrojariEditButtonClick != null)
                this.PotrojariEditButtonClick(sender, e);
        }
      
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "আপনি কি গ্রুপটি মুছে ফেলতে চান?";
        
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
          
            if (conditonBoxForm.Yes)
            {
                if (this.PotrojariDeleteButtonClick != null)
                    this.PotrojariDeleteButtonClick(sender, e);
              
            }
        }

        private void Formload()
        {
            page = 1;
            start = 1;
            LoadData(menuNo, page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            NextPreviousButtonShow();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }
        private void LoadData(int menuNo, int pages)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Controls.Clear();

                if (menuNo >= 7)
                {
                   // List<User> users = potroJariGrouplist.data.records.Where(x=>x.group.id== id).Select(x => x.users).FirstOrDefault();
                    foreach (var item in users)
                    {

                        PotrojariUsersListRowUserControl pgc = new PotrojariUsersListRowUserControl();

                        pgc.UserName = item.officer;
                        pgc.UserDesignation = item.designation + ", " + item.office + ", " + item.office_unit;
                        pgc.UserOfficeName = item.officer_email + ", " + item.officer_mobile;

                        UIDesignCommonMethod.AddRowinTable(tableLayoutPanel2, pgc);

                    }
                    totalrecord = users.Count;
                    totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                    float pagesize = (float)totalrecord / (float)pageLimit;
                    totalPage = (int)Math.Ceiling(pagesize);

                }
                else
                {

                var dakListUserParam = _userService.GetLocalDakUserParam();

                dakListUserParam.limit = pageLimit;

                dakListUserParam.page = pages;
                // int row = 2;

                var potroJariGrouplist = _potroJariGroupService.GetList(dakListUserParam, menuNo);
                // RemoveArbitraryRow(tableLayoutPanel1, tableLayoutPanel1.RowCount, 2);
                if (potroJariGrouplist.status == "success")
                {
                    foreach (var item in potroJariGrouplist.data.records)
                    {

                        PotrojariUsersListRowUserControl pgc = new PotrojariUsersListRowUserControl();

                        pgc.UserName = item.officer;
                        pgc.UserDesignation = item.designation + ", " + item.office + ", " + item.office_unit;
                        pgc.UserOfficeName = item.officer_email + ", " + item.officer_mobile;
                        ///pgc.Dock = DockStyle.Fill;


                        //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 45f));

                        //tableLayoutPanel1.Controls.Add(pgc, 0, row);
                        //row = tableLayoutPanel1.RowCount++;

                        UIDesignCommonMethod.AddRowinTable(tableLayoutPanel2, pgc);

                    }
                    totalrecord = potroJariGrouplist.data.total_records;
                    totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                    float pagesize = (float)totalrecord / (float)pageLimit;
                    totalPage = (int)Math.Ceiling(pagesize);
                }

               
                  }
          
        }
    
        private void nextIconButton_Click(object sender, EventArgs e)
        {
            string endrow;

            if (page <= totalPage)
            {
                page += 1;
                start += pageLimit;
                end += pageLimit;

            }
            else
            {
                page = totalPage;
                start = start;
                end = end;

            }
            endrow = end.ToString();
            LoadData(menuNo, page);
            if (totalrecord < end) { endrow = totalrecord.ToString(); }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(endrow);

            NextPreviousButtonShow();
        }

        private void PreviousIconButton_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {

                page -= 1;
                start -= pageLimit;
                end -= pageLimit;

            }
            else
            {
                page = 1;
                start = start;
                end = end;

            }

            LoadData(menuNo, page);
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
            NextPreviousButtonShow();


        }
        private void NextPreviousButtonShow()
        {
            if (page < totalPage)
            {
                if (page == 1 && totalPage > 1)
                {
                    PreviousIconButton.Enabled = false;
                }
                else
                {
                    PreviousIconButton.Enabled = true;

                }
                nextIconButton.Enabled = true;
            }
            if (page == totalPage)
            {
                if (page == 1 && totalPage == 1)
                {
                    PreviousIconButton.Enabled = false;

                }
                else
                {
                    PreviousIconButton.Enabled = true;

                }
                nextIconButton.Enabled = false;
            }

        }

        private void DetailsIconButton_Click(object sender, EventArgs e)
        {
            if(id>=1 && id<=5)
            {
                menuNo = id + 1;
            }
            else
            {
                menuNo = 7;
            }
           
            if (isActive == false && id!=clickedId)
            {

                Formload();
                isActive = true;
                clickedId = id;
            }
            else
            {
                clickedId = 0;
                isActive = false;
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel2.Controls.Clear();
            }
            //if (this.PotrojariDeleteButtonClick != null)
            //    this.PotrojariDeleteButtonClick(sender, e);
        }
        private void btnTotalPerson_Click(object sender, EventArgs e)
        {
            //if (rvwDashBoardContentShare.Visible)
            //{
            //    rvwDashBoardContentShare.Visible = false;
            //}
            //else
            //{
            //    Controls.Add(rvwDashBoardContentShare);
            //    rvwDashBoardContentShare.Location = new Point(430, 56);
            //    rvwDashBoardContentShare.Visible = true;
            //    rvwDashBoardContentShare.BringToFront();
            //}

        }


        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        private void detailsPanel_MouseHover(object sender, EventArgs e)
        {
            lbDetails.ForeColor = Color.FromArgb(78, 165, 254);
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void detailsPanel_MouseLeave(object sender, EventArgs e)
        {
            lbDetails.ForeColor = Color.FromArgb(63, 66, 84);
            this.BackColor = Color.FromArgb(250, 250, 250);
        }
        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            btnEdit.IconColor = Color.Red;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.IconColor = Color.FromArgb(78, 165, 254); 
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.IconColor = Color.Red;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.IconColor = Color.FromArgb(78, 165, 254);
        }
        ReviewDashBoardContentShare rvwDashBoardContentShare = new ReviewDashBoardContentShare();
    }
}

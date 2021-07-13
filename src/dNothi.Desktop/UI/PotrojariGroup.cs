using dNothi.Desktop.UI.Dak;
using dNothi.Services.PotroJariGroup;
using dNothi.Services.PotroJariGroup.Models;
using dNothi.Services.UserServices;
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
    public partial class PotrojariGroup : Form
    {
        IPotroJariGroupService _potroJariGroupService { get; set; }
        int page = 1;
        int pageLimit = 10;
        int menuNo = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        public PotrojariGroup(IUserService userService, IPotroJariGroupService potroJariGroupService)
        {
            _userService = userService;
            _potroJariGroupService = potroJariGroupService;
            InitializeComponent();
           // loadpotrojariGroupContent();

        }

        private PotrojariGroupModel LoadData(int menuNo, int pages)
        {
            //khosraListTableLayoutPanel.Controls.Clear();
            //_kasaraPatraDashBoardService = new KararaPotroDashBoardServices();
            //string nameSearchparam = dakSearchSubTextBox.Text;
            var dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = pageLimit;

            dakListUserParam.page = pages;
           // dakListUserParam.NameSearchParam = nameSearchparam;

            var potroJariGrouplist = _potroJariGroupService.GetList(dakListUserParam, menuNo);

            return potroJariGrouplist;

        }
       
        private void ViewData(int menuNo,int pageNo)
        {
            var potroJariGrouplist = LoadData(menuNo, pageNo);

            if (potroJariGrouplist.status == "success")
            {
                // noKhosraPanel.Visible = false;
                foreach (var item in potroJariGrouplist.data.records)
                {

                    PotrojariGroupContent pgc = UserControlFactory.Create< PotrojariGroupContent>();

                    //pgc.creator = item.created;
                    //pgc.details = item.officer;
                    //commonKhosraRowUserControl.viewButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_NoteDetails_ButtonClick(mapmodel.Item1, e, mapmodel.Item2, mapmodel.Item3); };

                   UIDesignCommonMethod.AddRowinTable(dakBodyFlowLayoutPanel, pgc);

                }

                totalrecord = potroJariGrouplist.data.total_records;
                // totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = (float)totalrecord / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
            }
            else
            {
                // noKhosraPanel.Visible = true;
            }
           
        }
        private void Formload()
        {
            page = 1;
            start = 1;
            ViewData(1,1);
           // LoadData(menuNo, page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
           // NextPreviousButtonShow();
           // perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }
        private void loadpotrojariGroupContent()
        {
            newPotrojariPanel.Visible = false;
            totalPotrojariPanel.Visible = true;

            btnNewPotrojariGroup.BackColor = Color.FromArgb(27, 197, 189);
            btnNewPotrojariGroup.FlatAppearance.BorderColor = Color.FromArgb(27, 197, 189);
            btnNewPotrojariGroup.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnNewPotrojariGroup.Text = "নতুন পত্রজারি গ্রুপ";

            dakBodyFlowLayoutPanel.Controls.Clear();


            for (int j = 0; j <= 10 ; j++)
            {

                PotrojariGroupContent pgc = UserControlFactory.Create< PotrojariGroupContent>();
                pgc.PotrojariEditButtonClick += delegate (object sender, EventArgs e) { editButtonClick(sender , e); };
                dakBodyFlowLayoutPanel.AutoScroll = true;

                pgc.Dock = DockStyle.Fill;

                int row = dakBodyFlowLayoutPanel.RowCount++;

                dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                if (row == 1)
                {
                    row = dakBodyFlowLayoutPanel.RowCount++;
                    dakBodyFlowLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                }
                dakBodyFlowLayoutPanel.Controls.Add(pgc, 0, row);
            }
        }
        public void editButtonClick(object sender, EventArgs e)
        {
            if (newPotrojariPanel.Visible != true)
            {
                dakBodyFlowLayoutPanel.Controls.Clear();
                lbPotrojariName.Text = "পত্রজারি গ্রুপ অন্তর্ভুক্তিকরণ";
                newPotrojariPanel.Visible = true;
                totalPotrojariPanel.Visible = false;
                btnNewPotrojariGroup.BackColor = Color.FromArgb(54, 153, 255);
                btnNewPotrojariGroup.FlatAppearance.BorderColor = Color.FromArgb(54, 153, 255);
                btnNewPotrojariGroup.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
                btnNewPotrojariGroup.Text = "পত্রজারি গ্রুপ তালিকা";
            }
            else
            {
                loadpotrojariGroupContent();
            }
        }

        private void potrojariGroupButton_MouseHover(object sender, EventArgs e)
        {
            potrojariGroupButton.BackColor = Color.FromArgb(243, 246, 249);
            potrojariGroupButton.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void potrojariGroupButton_MouseLeave(object sender, EventArgs e)
        {
            potrojariGroupButton.BackColor = Color.White;
            potrojariGroupButton.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void btnNewPotrojariGroup_Click(object sender, EventArgs e)
        {
            if (newPotrojariPanel.Visible != true)
            {
                dakBodyFlowLayoutPanel.Controls.Clear();
                lbPotrojariName.Text = "পত্রজারি গ্রুপ অন্তর্ভুক্তিকরণ";
                newPotrojariPanel.Visible = true;
                totalPotrojariPanel.Visible = false;
                btnNewPotrojariGroup.BackColor = Color.FromArgb(54, 153, 255);
                btnNewPotrojariGroup.FlatAppearance.BorderColor = Color.FromArgb(54, 153, 255);
                btnNewPotrojariGroup.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
                btnNewPotrojariGroup.Text = "পত্রজারি গ্রুপ তালিকা";
            }
            else
            {
                loadpotrojariGroupContent();
            }
            
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void potrojariGroupButton_Click(object sender, EventArgs e)
        {
            loadpotrojariGroupContent();
        }

        private void btnNothiIcon_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }
        IUserService _userService { get; set; }
        designationSelect designationDetailsPanelNothi = new designationSelect();
        private void userNameLabel_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Visible = true;
                //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 50);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
        }
    }
}

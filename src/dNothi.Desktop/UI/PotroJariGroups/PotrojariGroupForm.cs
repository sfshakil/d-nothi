using dNothi.Desktop.UI.Dak;

using dNothi.JsonParser.Entity;

using dNothi.Services.DakServices;


using dNothi.Services.PotroJariGroup;
using dNothi.Services.SyncServices;
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
using System.Windows.Forms.Design;

namespace dNothi.Desktop.UI.PotroJariGroups
{
    public partial class PotrojariGroupForm : Form
    {
        private DakUserParam dakListUserParam = new DakUserParam();
        private DakUserParam _dakuserparam = new DakUserParam();
        IPotroJariGroupService _potroJariGroupService { get; set; }
      
        ISyncerService _syncerServices { get; set; }

        int page = 1;
        int pageLimit = 10;
        int menuNo = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
       
        IUserService _userService { get; set; }
        public PotrojariGroupForm(IUserService userService, 
            ISyncerService syncerServices,
            IPotroJariGroupService potroJariGroupService)
        {
            InitializeComponent();
            _userService = userService;
            _syncerServices = syncerServices;
            _potroJariGroupService= potroJariGroupService;

        }


        private void MakeThisPanelClicked(object sender)
        {
            Panel panel = sender as Panel;
            if(panel == null)
            {
                panel = (sender as Control).Parent as Panel;
            }


            foreach (Control control in menuTableLayoutPanel.Controls)
            {
                if (control is Panel)
                {
                    if (control == panel)
                    {
                        MakeClickUnClickButton(control, Color.FromArgb(243, 246, 249), Color.FromArgb(78, 165, 254));

                    }
                    else
                    {
                        if(control is Button)
                        {
                            listTypeLabel.Text = control.Text;
                        }
                        MakeClickUnClickButton(control, Color.FromArgb(254, 254, 254), Color.FromArgb(97, 99, 114));

                    }
                }
            }
        }

        private void MakeClickUnClickButton(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            if (control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {

                    c.ForeColor = foreColor;


                }
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

        private void PotrojariGroupForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            label7.Text = UIDesignCommonMethod.copyRightLableText;
        }

        private void PotrojariGroupForm_Shown(object sender, EventArgs e)
        {
            Formload();
            UserProfile();
        }

        private void draftPotroPanel_Click(object sender, EventArgs e)
        {
            menuNo = 1;
            MakeThisPanelClicked(sender);
            Formload();
            listTypeLabel.Text = draftPotroButton.Text;
           
           
        }

      

        private void jarikritoButton_Click(object sender, EventArgs e)
        {
            //menuNo = 5;
            //MakeThisPanelClicked(sender);
            //Formload();
            //listTypeLabel.Text = jarikritoButton.Text;
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }

       
        private void UserProfile()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();


            try
            {
                EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
                moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());

            }
            catch (Exception Ex)
            {

            }


            List<OfficeInfoDTO> officeInfoDTO = _userService.GetAllLocalOfficeInfo();


            foreach (OfficeInfoDTO officeInfoDTO1 in officeInfoDTO)
            {
                dakUserParam.designation_id = officeInfoDTO1.office_unit_organogram_id;
                dakUserParam.office_id = officeInfoDTO1.office_id;
                try
                {
                    EmployeDakNothiCountResponse singleOfficeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(dakUserParam);
                    var singleOfficeDakNothiCount = singleOfficeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == dakUserParam.designation_id.ToString());

                    officeInfoDTO1.dakCount = singleOfficeDakNothiCount.Value.dak;
                    officeInfoDTO1.nothiCount = singleOfficeDakNothiCount.Value.own_office_nothi;
                }
                catch
                {

                }
            }


            designationDetailsPanel.officeInfos = officeInfoDTO;




            userNameLabel.Text = dakUserParam.officer_name + "(" + dakUserParam.designation_label + "," + dakUserParam.unit_label + ")";

            designationDetailsPanel.ChangeUserClick += delegate (object changeButtonSender, EventArgs changeButtonEvent) { ChageUser(designationDetailsPanel._designationId); };

        }
       
        private void ChageUser(int designationId)
        {
            _userService.MakeThisOfficeCurrent(designationId);
            dakListUserParam = _dakuserparam  = _userService.GetLocalDakUserParam();
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";

            EmployeDakNothiCountResponse employeDakNothiCountResponse = _userService.GetDakNothiCountResponseUsingEmployeeDesignation(_dakuserparam);
            var employeDakNothiCountResponseTotal = employeDakNothiCountResponse.data.designation.FirstOrDefault(a => a.Key == _dakuserparam.designation_id.ToString());

            moduleDakCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.dak.ToString());
            moduleNothiCountLabel.Text = ConversionMethod.EnglishNumberToBangla(employeDakNothiCountResponseTotal.Value.own_office_nothi.ToString());


           
        }

      

        private void LoadData(int menuNo,int pages)
        {
            khosraListTableLayoutPanel.Controls.Clear();
          
            var dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = pageLimit;

            dakListUserParam.page = pages;
            

            var potroJariGrouplist = _potroJariGroupService.GetList(dakListUserParam, menuNo);
            if (potroJariGrouplist.status == "success")
            {
                 noKhosraPanel.Visible = false;
                foreach (var item in potroJariGrouplist.data.records)
                {

                    PotrojariGroupContent pgc =UserControlFactory.Create<PotrojariGroupContent>();

                    pgc.creator = item.group.createdby_officer;
                    pgc.groupName = item.group.group_name;
                    pgc.privacyType = item.group.privacy_type;
                    pgc.totalPerson = item.group.total_users>0? item.group.total_users:0;
                    pgc.id = item.group.id;
                    pgc.users = item.users;

                    if (dakListUserParam.designation_id == item.group.createdby_designation_id)
                    {
                        pgc.isDelete = true;
                        pgc.isEditable = true;
                    }
                    else
                    {
                        pgc.isDelete = false;
                        pgc.isEditable = false;
                    }
                    //commonKhosraRowUserControl.viewButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_NoteDetails_ButtonClick(mapmodel.Item1, e, mapmodel.Item2, mapmodel.Item3); };

                    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, pgc);

                }

                totalrecord = potroJariGrouplist.data.total_records;
                totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = (float)totalrecord / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
            }
            else
            {
                 noKhosraPanel.Visible = true;
            }

        }

     

        private void DakModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.DakModuleClick(this);
        }
        private void NothiModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.NothiModuleClick(this);
        }

        private void designationDetailsPanel_Load(object sender, EventArgs e)
        {

        }

        private void nextIconButton_Click(object sender, EventArgs e)
        {
            string endrow;
           
            if (page <= totalPage)
            {
                page += 1;
                start +=  pageLimit;
                end += pageLimit;
                
            }
            else
            {
                page = totalPage;
                start = start;
                end = end;
                
            }
            endrow = end.ToString();
            LoadData( menuNo, page);
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
           
            LoadData( menuNo, page);
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

        private void profileShowArrowButton_Click(object sender, EventArgs e)
        {
            if (!designationDetailsPanel.Visible)
            {
                int designationPanleX = this.Width - designationDetailsPanel.Width - 25;
                int designationPanleY = profilePanel.Location.Y + profilePanel.Height;
                designationDetailsPanel.Location = new Point(designationPanleX, designationPanleY);

                designationDetailsPanel.Visible = true;


            }
            else
            {
                designationDetailsPanel.Visible = false;
            }
        }
       
        public bool InternetConnectionTemp;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {



            if (InternetConnection.Check())
            {

                _syncerServices.SyncLocaltoRemoteData();
                if (onlineStatus.IconColor != Color.LimeGreen)
                {



                    if (IsHandleCreated)
                    {
                        onlineStatus.Invoke(new MethodInvoker(delegate

                        {
                            onlineStatus.IconColor = Color.LimeGreen;
                            MyToolTip.SetToolTip(onlineStatus, "Online");

                        }));
                    }
                    else
                    {

                    }




                    //dakUploadBackgorundWorker.RunWorkerAsync();
                }





            }
            else
            {
                if (IsHandleCreated)
                {
                    onlineStatus.Invoke(new MethodInvoker(delegate

                    {
                        onlineStatus.IconColor = Color.Silver;
                        MyToolTip.SetToolTip(onlineStatus, "Offline");

                    }));
                }
                else
                {

                }



            }






        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (!backgroundWorker1.IsBusy && this.Visible)
            {

                backgroundWorker1.RunWorkerAsync();
            }


        }
     
      
       
    }
}

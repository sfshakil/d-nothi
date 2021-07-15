using dNothi.Desktop.UI.Dak;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
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
using System.Runtime.InteropServices;
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
        AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
        List<PrapokDTO> _addedOwnOfficerDesignationSeal { get; set; }
        private List<PrapokDTO> _ownOfficeDesignationList = new List<PrapokDTO>();
        IDesignationSealService _designationSealService { get; set; }
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
            IPotroJariGroupService potroJariGroupService,
             IDesignationSealService designationSealService)
        {
            InitializeComponent();
            _userService = userService;
            _syncerServices = syncerServices;
            _potroJariGroupService= potroJariGroupService;
            _designationSealService = designationSealService;



        }
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
                                                 ref TVITEM lParam);


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
            khosraListTableLayoutPanel.Controls.Clear();
            khosraListTableLayoutPanel.Visible = false;
            noKhosraPanel.Visible = false ;
            panel5.Visible = false;
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


        private void LoadOwnOfficerTree()
        {



          var   _dakUserParam = _userService.GetLocalDakUserParam();


            AllDesignationSealListResponse designationSealListOwnOfficeResponse = _designationSealService.GetAllDesignationSeal(_dakUserParam, _dakUserParam.office_id);
            OfficeListResponse officeListResponse = _designationSealService.GetAllOffice(_dakUserParam);



            int unitOwnOffice = 0, designationOwnOffice = 0, emptydesignationOwnOffice = 0, workingdesignationOwnOffice = 0;
            if (designationSealListOwnOfficeResponse.status == "success")
            {
                if (designationSealListOwnOfficeResponse.data.Count > 0)
                {
                    List<PrapokDTO> ownOfficers = designationSealListOwnOfficeResponse.data.Where(a => a.office_id == _dakUserParam.office_id).ToList();
                    _ownOfficeDesignationList = ownOfficers;
                    if (ownOfficers.Count > 0)
                    {

                        designationOwnOffice = ownOfficers.Count;
                        var groupOwnOfficebyUnit = ownOfficers.GroupBy(a => a.unitWithCode);
                        unitOwnOffice = groupOwnOfficebyUnit.Count();

                        foreach (var group in groupOwnOfficebyUnit)
                        {



                            string branchName = group.Key;

                            int count = group.Count();
                            branchName += "(" +ConversionMethod.EnglishNumberToBangla(count.ToString()) + ")";
                            TreeNode branchNodeOwnOffice = new TreeNode(branchName);



                            foreach (var officer in group)
                            {
                                if (officer.officer_id > 0)
                                {
                                    workingdesignationOwnOffice += 1;

                                }
                                else
                                {
                                    emptydesignationOwnOffice += 1;


                                }


                                TreeNode childNode = new TreeNode();
                                childNode.Tag = officer.designation_id;
                                childNode.Text = officer.NameWithDesignation;
                                if (_addedOwnOfficerDesignationSeal.Any(a => a.designation_id == officer.designation_id))
                                {
                                    childNode.Checked = true;
                                    childNode.ForeColor = Color.Gray;

                                }

                                branchNodeOwnOffice.Nodes.Add(childNode);





                            }

                            prapokownOfficeTreeView.Nodes.Add(branchNodeOwnOffice);






                        }

                        HideParentNodeCheckBox(prapokownOfficeTreeView);
                    }



                }
            }









            OfficerStatTreeOwn(unitOwnOffice, designationOwnOffice, emptydesignationOwnOffice, workingdesignationOwnOffice);





        }
        private void HideParentNodeCheckBox(TreeView tvw)
        {
            foreach (TreeNode trNode in tvw.Nodes)
            {

                TVITEM tvi = new TVITEM();
                tvi.hItem = trNode.Handle;
                tvi.mask = TVIF_STATE;
                tvi.stateMask = TVIS_STATEIMAGEMASK;
                tvi.state = 0;
                SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);





            }


        }
        private void OfficerStatTreeOwn(int unit, int designation, int emptydesignation, int workingdesignation)
        {
            designationStateOwnLabel.Text = "শাখা " +ConversionMethod.EnglishNumberToBangla(unit.ToString()) + " টি, পদ " +ConversionMethod.EnglishNumberToBangla(designation.ToString()) + "টি, শুন্যপদ " +ConversionMethod.EnglishNumberToBangla(emptydesignation.ToString()) + "টি, কর্মরত " +ConversionMethod.EnglishNumberToBangla(workingdesignation.ToString()) + " জন";

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

        private void CreatePotroJariGroupButton_Click(object sender, EventArgs e)
        {
            khosraListTableLayoutPanel.Controls.Clear();
            khosraListTableLayoutPanel.Visible = false;
            noKhosraPanel.Visible = true;
            label2.Text = "পত্রজারি গ্রুপ অন্তর্ভুক্তিকরণ এর কাজ চলছে । ";
            panel5.Visible = false;
            newPotrojariPanel.Visible = false;
            //var uscontrol = UserControlFactory.Create<PatraJariGroupCreateUserControl>();
            //bodyContentPanel.Controls.Add(uscontrol);


            MakeThisPanelClicked(sender);
            //var panels = tableLayoutPanel2.Controls.OfType<Panel>().Where(x => x.Name.EndsWith("Txt"));
            //foreach (Panel p in panels)
            //{
            //    p.Paint += new System.Windows.Forms.PaintEventHandler(allPanel_Paint);
            //}

            listTypeLabel.Text = "পত্রজারি গ্রুপ অন্তর্ভুক্তিকরণ";
           // LoadOfficer();
           // LoadOwnOfficerTree();
        }

        private void potrojariGroupTalikaButton_Click(object sender, EventArgs e)
        {
            newPotrojariPanel.Visible = false;
            khosraListTableLayoutPanel.Visible = true;
            panel5.Visible = true;
            menuNo = 1;
            MakeThisPanelClicked(sender);
            Formload();
            listTypeLabel.Text = "পত্রজারি গ্রুপ তালিকা";
        }
        public void LoadOfficer()
        {
            DakUserParam userParam = _userService.GetLocalDakUserParam();

            designationSealListResponse = _designationSealService.GetAllDesignationSeal(userParam, userParam.office_id);
            List<ComboBoxItems> comboBoxItems = new List<ComboBoxItems>();
            try
            {

                if (designationSealListResponse.data.Count > 0)
                {

                    foreach (PrapokDTO prapokDTO in designationSealListResponse.data)
                    {
                        comboBoxItems.Add(new ComboBoxItems { id = prapokDTO.officer_id, Name = prapokDTO.NameWithDesignation });
                    }
                }


            }
            catch (Exception Ex)
            {

            }

            officerSearchList.itemList = comboBoxItems;
            officerSearchList.isListShown = true;
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void allPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void officerSearchList_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void OfficerSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void potrojariButton_Click(object sender, EventArgs e)
        {
            this.Hide();
           
            PotrojariGroupForm potrojariGroup = FormFactory.Create<PotrojariGroupForm>();
           
            potrojariGroup.ShowDialog();
        }
    }
}

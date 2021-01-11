using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class AddDesignationSeal : Form
    {
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

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
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



        private void button1_Click(object sender, System.EventArgs e)
        {
           
        }
        IDakUploadService _dakuploadservice { get; set; }
        IUserService _userService { get; set; }
       
        private DakUserParam _dakUserParam = new DakUserParam();
        private List<OfficeInfoDTO> _officeInfo = new List<OfficeInfoDTO>();
        private List<PrapokDTO> _ownOfficeDesignationList = new List<PrapokDTO>();
        private List<PrapokDTO> _otherOfficeDesignationList = new List<PrapokDTO>();
        

        public AddDesignationSeal(IDakUploadService dakUploadService, IUserService userService)
        {
            _dakuploadservice = dakUploadService;
            _userService = userService;
            InitializeComponent();

           
            LoadOwnOfficerTree();
            LoadOwnOfficeRight();
           
            LoadOtherOfficeLeftList();
        }

        private void LoadOtherOfficeLeftList()
        {
            searchOfficeListBox.DataSource = null;

            OfficeListResponse officeListResponse = _dakuploadservice.GetAllOffice(_dakUserParam);
            if (officeListResponse.status == "success")
            {
                if (officeListResponse.data != null)
                {
                    searchOfficeListBox.DisplayMember = "office_name_bng";
                    _officeInfo = officeListResponse.data[_dakUserParam.office_id.ToString()];
                    searchOfficeListBox.DataSource = _officeInfo;
                }
            }
        }

        private void LoadOwnOfficeLeftTree()
        {
            searchOfficeListBox.DataSource = null;

            OfficeListResponse officeListResponse = _dakuploadservice.GetAllOffice(_dakUserParam);
            if(officeListResponse.status=="success")
            {
                if(officeListResponse.data != null)
                {
                    searchOfficeListBox.DisplayMember = "office_name_bng";
                        _officeInfo = officeListResponse.data[_dakUserParam.office_id.ToString()];
                    searchOfficeListBox.DataSource = _officeInfo;
                }
            }

        }

        private void LoadOwnOfficerTree()
        {



          _dakUserParam = _userService.GetLocalDakUserParam();
           

            AllDesignationSealListResponse designationSealListOwnOfficeResponse = _dakuploadservice.GetAllDesignationSeal(_dakUserParam, _dakUserParam.office_id);
            OfficeListResponse officeListResponse = _dakuploadservice.GetAllOffice(_dakUserParam);

        

            int unitOwnOffice = 0, designationOwnOffice = 0, emptydesignationOwnOffice = 0, workingdesignationOwnOffice = 0;
             if(designationSealListOwnOfficeResponse.status=="success")
            {
                if(designationSealListOwnOfficeResponse.data.Count>0)
                {
                    List<PrapokDTO> ownOfficers = designationSealListOwnOfficeResponse.data.Where(a => a.office_id == _dakUserParam.office_id).ToList();
                    _ownOfficeDesignationList = ownOfficers;
                    if(ownOfficers.Count>0)
                    {

                        designationOwnOffice = ownOfficers.Count;
                        var groupOwnOfficebyUnit = ownOfficers.GroupBy(a => a.unitWithCode);
                        unitOwnOffice = groupOwnOfficebyUnit.Count();
                        
                        foreach (var group in groupOwnOfficebyUnit)
                        {


                          
                            string branchName = group.Key;






                            int count = group.Count();
                            branchName += "(" + ConvertEnglishNumbertoBangle(count) + ")";
                            TreeNode branchNodeOwnOffice = new TreeNode(branchName);

                            

                            foreach (var officer in group)
                            {
                                if (officer.officer_id>0)
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

        private void PopulateOtherOfficerTree(int office_id)
        {
            int unitOtherOffice = 0, designationOtherOffice = 0, emptydesignationOtherOffice = 0, workingdesignationOtherOffice = 0;


            AllDesignationSealListResponse designationSealListOtherOfficeResponse = _dakuploadservice.GetAllDesignationSeal(_dakUserParam, office_id);

            if (designationSealListOtherOfficeResponse.status == "success")
            {
                if (designationSealListOtherOfficeResponse.data.Count > 0)
                {
                    List<PrapokDTO> otherOfficers = designationSealListOtherOfficeResponse.data.ToList();
                    _otherOfficeDesignationList.AddRange(otherOfficers.Where(x => !_otherOfficeDesignationList.Any(y => y.designation_id == x.designation_id)).ToList());

                    if (otherOfficers.Count > 0)
                    {
                        designationOtherOffice = otherOfficers.Count;
                        var groupOtherOfficebyUnit = otherOfficers.GroupBy(a => a.unitWithCode);
                        unitOtherOffice = groupOtherOfficebyUnit.Count();

                        foreach (var group in groupOtherOfficebyUnit)
                        {



                            string branchName = group.Key;
                            int count = group.Count();
                            branchName += "(" + ConvertEnglishNumbertoBangle(count) + ")";
                            TreeNode branchNodeOtherOffice = new TreeNode(branchName);
                            branchNodeOtherOffice.Tag = 0;


                            foreach (var officer in group)
                            {
                                if (officer.designation_id > 0)
                                {
                                    workingdesignationOtherOffice += 1;

                                }
                                else
                                {
                                    workingdesignationOtherOffice += 1;


                                }
                                TreeNode childNodeOther = new TreeNode();
                                childNodeOther.Tag = officer.designation_id;
                                childNodeOther.Text = officer.NameWithDesignation;
                              
                                if(_otherOfficeDesignationList.Any(a=>a.designation_id==officer.designation_id && a.isofficerAdded==true))
                                {
                                    childNodeOther.Checked = true;
                                }
                                
                               
                                branchNodeOtherOffice.Nodes.Add(childNodeOther);
                               
                            }




                            otherOfficeTreeView.Nodes.Add(branchNodeOtherOffice);



                        }


                    }

                }
            }

            OfficerStatTreeOther(unitOtherOffice, designationOtherOffice, emptydesignationOtherOffice, workingdesignationOtherOffice);

        }

        private void OfficerStatTreeOther(int unit, int designation, int emptydesignation, int workingdesignation)
        {
            designationStateOtherLabel.Text = "শাখা "+ConvertEnglishNumbertoBangle(unit)+ " টি, পদ " + ConvertEnglishNumbertoBangle(designation) + "টি, শুন্যপদ " + ConvertEnglishNumbertoBangle(emptydesignation) + "টি, কর্মরত " + ConvertEnglishNumbertoBangle(workingdesignation) + " জন";
        }


        private string ConvertEnglishNumbertoBangle(int engNumber)
        {
            return string.Concat(engNumber.ToString().Select(c => (char)('\u09E6' + c - '0')));
        }

        private void OfficerStatTreeOwn(int unit, int designation, int emptydesignation, int workingdesignation)
        {
            designationStateOwnLabel.Text = "শাখা " + ConvertEnglishNumbertoBangle(unit) + " টি, পদ " + ConvertEnglishNumbertoBangle(designation) + "টি, শুন্যপদ " + ConvertEnglishNumbertoBangle(emptydesignation) + "টি, কর্মরত " + ConvertEnglishNumbertoBangle(workingdesignation) + " জন";

        }

        private void LoadOwnOfficeRight()
        {
            if (_ownOfficeDesignationList.Count > 0)
            {

               
                var groupOwnOfficebyUnit = _ownOfficeDesignationList.GroupBy(a => a.unitWithCode);

                int i = 0;
                foreach (var group in groupOwnOfficebyUnit)
                {
                   


                    List<PrapokDTO> prapokGroupWise = _ownOfficeDesignationList.Where(a => a.unitWithCode == group.Key).ToList();


                    DesignationSealBranchRowUserControl designationSealBranchRowUserControl = new DesignationSealBranchRowUserControl();
                    designationSealBranchRowUserControl.branchOfficeName = prapokGroupWise.FirstOrDefault().unit_name_bng;
                    designationSealBranchRowUserControl.unitCode = prapokGroupWise.FirstOrDefault().office_unit_code;
                    designationSealBranchRowUserControl.unitId = prapokGroupWise.FirstOrDefault().unit_id;

                    designationSealBranchRowUserControl.prapokDtos = prapokGroupWise;


                    designationSealBranchRowUserControl.DesignationDeleteButton += delegate (object sender, EventArgs e) { OfficerDelete_ButtonClick(sender, e, designationSealBranchRowUserControl.isAnyDesignationNewlyAdded,designationSealBranchRowUserControl._designationid); };

                    designationSealBranchRowUserControl.Visible = false;
                    ownOfficeRightFlowLayoutPanel.Controls.Add(designationSealBranchRowUserControl);


                }


              






            }


        }

        private void LoadOwnOfficeRight(int officeid)
        {

            if (_ownOfficeDesignationList.Count > 0)
            {
                List<PrapokDTO> otherOfficeDesignationByOfficeId = _otherOfficeDesignationList.Where(a => a.office_id == officeid).ToList();

                var groupOfficebyUnit = otherOfficeDesignationByOfficeId.GroupBy(a => a.unitWithCode);

                int i = 0;
                foreach (var group in groupOfficebyUnit)
                {



                    List<PrapokDTO> prapokGroupWise = otherOfficeDesignationByOfficeId.Where(a => a.unitWithCode == group.Key).ToList();


                    DesignationSealBranchRowUserControl designationSealBranchRowUserControl = new DesignationSealBranchRowUserControl();
                    designationSealBranchRowUserControl.branchOfficeName = prapokGroupWise.FirstOrDefault().unit_name_bng;
                    designationSealBranchRowUserControl.unitCode = prapokGroupWise.FirstOrDefault().office_unit_code;
                    designationSealBranchRowUserControl.unitId = prapokGroupWise.FirstOrDefault().unit_id;

                    designationSealBranchRowUserControl.prapokDtos = prapokGroupWise;


                    designationSealBranchRowUserControl.DesignationDeleteButton += delegate (object sender, EventArgs e) { OfficerDelete_ButtonClick(sender, e, designationSealBranchRowUserControl.isAnyDesignationNewlyAdded, designationSealBranchRowUserControl._designationid); };



                    if(otherOfficeDesignationByOfficeId.Any(a=>a.unitWithCode==group.Key && a.isofficerAdded==true))
                    {
                        designationSealBranchRowUserControl.Visible = true;
                    }
                    else
                    {
                        designationSealBranchRowUserControl.Visible = false;
                    }
                
                    ownOfficeRightFlowLayoutPanel.Controls.Add(designationSealBranchRowUserControl);


                }









            }









        }

        private void OfficerDelete_ButtonClick(object sender, EventArgs e, bool isAnyDesignationNewlyAdded,int designationId)
        {
            var designationBranchList = ownOfficeRightFlowLayoutPanel.Controls.OfType<DesignationSealBranchRowUserControl>().ToList();
           
            foreach (var designationBranch in designationBranchList)
            {

                if (designationBranch._designationid==designationId && !designationBranch.isAnyDesignationNewlyAdded)
                {
                    designationBranch.Visible = false;
                }
               
            }

          

            try
            {
                _ownOfficeDesignationList.FirstOrDefault(a => a.designation_id == designationId).isofficerAdded = false;
               
                CheckUncheckTreeNode(prapokownOfficeTreeView.Nodes, false, designationId);
            }
            catch(Exception Ex)
            {
                _otherOfficeDesignationList.FirstOrDefault(a => a.designation_id == designationId).isofficerAdded = false;
                //otherOfficeTreeView.Nodes.OfType<TreeNode>()
                //           .FirstOrDefault(node => node.Tag.Equals(designationId)).Checked = false;
                CheckUncheckTreeNode(otherOfficeTreeView.Nodes, false, designationId);
            }
            
        }
        private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck, int designationid)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                if(Convert.ToInt32(trNode.Tag)==designationid)
                {
                    if(!isCheck)
                    {
                        trNode.ForeColor = Color.Black;
                    }

                    trNode.Checked = isCheck;
                    break;
                }

                 if (trNode.Nodes.Count > 0)
                CheckUncheckTreeNode(trNode.Nodes, isCheck, designationid);
            }
        }
        private void tabControlLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlLeft.SelectedTab == tabControlLeft.TabPages["ownOfficeTabPageLeft"])
            {
                tabControlRight.SelectTab(ownOfficeTabPageRight);
            }
            else if(tabControlLeft.SelectedTab == tabControlLeft.TabPages["otherOfficeTabPageLeft"])
            {
                tabControlRight.SelectTab(otherOfficeTabPageRight);
            }
        }

        private void tabControlRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlRight.SelectedTab == tabControlRight.TabPages["ownOfficeTabPageRight"])
            {
                tabControlLeft.SelectTab(ownOfficeTabPageLeft);
            }
            else if(tabControlRight.SelectedTab == tabControlRight.TabPages["otherOfficeTabPageRight"])
            {
                tabControlLeft.SelectTab(otherOfficeTabPageLeft);
            }
        }

        // public event EventHandler CloseButton;
        private void AddDesignationCloseButton_Click(object sender, EventArgs e)
        {
          
            this.Close();

           
        }

        private void BorderBlueColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void prapokownOfficeTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Nodes.Count != 0)
            {
                e.Node.Checked = false;
            }
            e.DrawDefault = true;
        }
        private void prapokotherOfficeTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Nodes.Count != 0)
            {
                e.Node.Checked = false;
            }
            e.DrawDefault = true;
        }

        private void otherOfficeTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.Node.Checked = false;
            }
            if (e.Action != TreeViewAction.Unknown)
            {



                if (e.Node.Checked == true)
                {
                    int designation_id = Convert.ToInt32(e.Node.Tag);
                    PrapokDTO otherOfficer = _otherOfficeDesignationList.FirstOrDefault(a => a.designation_id == designation_id);
                    _otherOfficeDesignationList.FirstOrDefault(a => a.designation_id == designation_id).isofficerAdded = true;



                    var branchList = otherOfficeRightFlowLayoutPanel.Controls.OfType<DesignationSealBranchRowUserControl>().ToList();

                    foreach (var branch in branchList)
                    {
                        if (branch.branchOfficeName == otherOfficer.unit_name_bng && branch.unitCode == otherOfficer.office_unit_code && branch.unitId == otherOfficer.unit_id)

                        {
                            branch.Visible = true;
                            branch.designationid = otherOfficer.designation_id;

                        }

                    }
                }
                if (e.Node.Checked == false)
                {


                }
            }
        }

        private void searchOfficerRightButton_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightListBox_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchOfficePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchOfficeButton_Click(object sender, EventArgs e)
        {
            if (searchOfficePanel.Visible)
            {

                searchOfficePanel.Visible = false;
            }
            else
            {
               
            
                searchOfficePanel.Visible = true;
               

                searchOfficeTextBox.Focus();
            }
        }

        private void searchOfficeTextBox_TextChanged(object sender, EventArgs e)
        {
            searchOfficeListBox.DataSource = null;
           

                List<OfficeInfoDTO> officeInfoSearch = _officeInfo.Where(a => a.office_name_bng.Contains(searchOfficeTextBox.Text)).ToList();


          

                if (officeInfoSearch.Count > 0)
                {
                    searchOfficeListBox.DisplayMember = "office_name_bng";
                    searchOfficeListBox.DataSource = null;
                    searchOfficeListBox.DataSource = officeInfoSearch;

                    searchOfficeListBox.Visible = true;
                }
               

            
        }

        private void prapokownOfficeTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Parent==null)
            {
                e.Node.Checked = false;
            }
            if (e.Action != TreeViewAction.Unknown)
            {

                

                if (e.Node.Checked == true)
                {
                   int designation_id= Convert.ToInt32(e.Node.Tag);
                   PrapokDTO otherOfficer= _ownOfficeDesignationList.FirstOrDefault(a => a.designation_id == designation_id);
                    _ownOfficeDesignationList.FirstOrDefault(a => a.designation_id == designation_id).isofficerAdded = true;
                    
                    
                    
                    var branchList = ownOfficeRightFlowLayoutPanel.Controls.OfType<DesignationSealBranchRowUserControl>().ToList();

                    foreach (var branch in branchList)
                    {
                        if (branch.branchOfficeName == otherOfficer.unit_name_bng && branch.unitCode == otherOfficer.office_unit_code && branch.unitId == otherOfficer.unit_id)

                        {
                            branch.Visible = true;
                            branch.designationid = otherOfficer.designation_id;
                            
                        }

                    }
                }
                if (e.Node.Checked == false)
                {
                   

                }
            }
            
        }

        private void prapokownOfficeTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
           
        }

        private void prapokownOfficeTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.Cancel = true;
            }
            if (Color.Gray == e.Node.ForeColor)
            {
                e.Cancel = true;
            }
              
            else if(!e.Node.Checked)
            {
                e.Node.ForeColor = Color.Gray;
            }


        }

        private void searchOfficeListBox_Click(object sender, EventArgs e)
        {
            searchOfficePanel.Visible = false;
            officeSearchOfficeNameLabel.Text = searchOfficeListBox.GetItemText(searchOfficeListBox.SelectedItem);
            officerSearchOfficeIdLabel.Text = (searchOfficeListBox.SelectedItem as OfficeInfoDTO).id.ToString();


            PopulateOtherOfficerTree((searchOfficeListBox.SelectedItem as OfficeInfoDTO).id);
        }

        private void otherOfficeTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.Cancel = true;
            }
        }

        private void saveDesignationSealButton_Click(object sender, EventArgs e)
        {
            DialogResult DialogResultSttring = MessageBox.Show("আপনি কি প্রাপকের তালিকাটি সংযুক্ত করতে চান??\n",
                               "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResultSttring == DialogResult.Yes)
            {
               

                var form = FormFactory.Create<Dashboard>();
                List<PrapokDTO> designationSealResponse = _ownOfficeDesignationList.Where(a => a.isofficerAdded == true).ToList();
                var designationSealListJson =new JavaScriptSerializer().Serialize(designationSealResponse);
              

                AddDesignationSealResponse addDesignationSealResponse = form.AddDesignation(designationSealListJson);

                if(addDesignationSealResponse.status=="success")
                {
                    MessageBox.Show("সফলভাবে সংরক্ষণ হ​য়েছে।");
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("সংরক্ষণ সফল হ​য়নি।।");
                }

            }
            else
            {

            }
        }
    }
}

using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
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

namespace dNothi.Desktop.UI.Dak
{
    public partial class AddDesignationSeal : Form
    {
        IDakUploadService _dakuploadservice { get; set; }
        IUserService _userService { get; set; }
       
        private DakUserParam _dakUserParam = new DakUserParam();
        private List<OfficeInfoDTO> _officeInfo = new List<OfficeInfoDTO>();
        private List<PrapokDTO> _ownOfficeDesignationList = new List<PrapokDTO>();
      

        public AddDesignationSeal(IDakUploadService dakUploadService, IUserService userService)
        {
            _dakuploadservice = dakUploadService;
            _userService = userService;
            InitializeComponent();

           
            LoadOwnOfficerTree();
            LoadOwnOfficeRight();

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

                                //if(officer.==true)
                                //{
                                //    branchNodeOwnOffice.Nodes.Add(officer.designation_id.ToString(), officer.employee_name_bng).Checked=true;


                                //}
                                //else
                                //{
                                //    branchNodeOwnOffice.Nodes.Add(officer.designation_id.ToString(), officer.employee_name_bng);


                                //}
                                TreeNode childNode = new TreeNode();
                                childNode.Tag = officer.designation_id;
                                childNode.Text = officer.NameWithDesignation;
                              
                                branchNodeOwnOffice.Nodes.Add(childNode);

                                prapokownOfficeTreeView.Nodes.Add(branchNodeOwnOffice);
                            }


                            

                            



                        }


                    }

                 

                }
            }


            if(officeListResponse.status=="success")
            {
                if(officeListResponse.data.officeInfos!=null)
                {
                    _officeInfo = officeListResponse.data.officeInfos;

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


                    if (otherOfficers.Count > 0)
                    {
                        designationOtherOffice = otherOfficers.Count;
                        var groupOtherOfficebyUnit = otherOfficers.GroupBy(a => a.unitWithCode);
                        unitOtherOffice = groupOtherOfficebyUnit.Count();

                        foreach (var group in groupOtherOfficebyUnit)
                        {



                            string branchName = group.Key;
                            int count = group.Count();
                            branchName = "(" + ConvertEnglishNumbertoBangle(count) + ")";
                            TreeNode branchNodeOtherOffice = new TreeNode(branchName);
                        

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

                                if (officer.status == true)
                                {
                                    branchNodeOtherOffice.Nodes.Add(officer.designation_id.ToString(), officer.NameWithDesignation).Checked = true;


                                }
                                else
                                {
                                    branchNodeOtherOffice.Nodes.Add(officer.designation_id.ToString(), officer.NameWithDesignation);


                                }
                                TreeNode childNode = new TreeNode();
                                childNode.Tag = officer.designation_id;
                                childNode.Text = officer.NameWithDesignation;
                                branchNodeOtherOffice.Nodes.Add(childNode);
                                otherOfficeTreeView.Nodes.Add(branchNodeOtherOffice);
                            }








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
                    i++;
                    if(i>5)
                    {
                        break;
                    }


                    List<PrapokDTO> prapokGroupWise = _ownOfficeDesignationList.Where(a => a.unitWithCode == group.Key).ToList();


                    DesignationSealBranchRowUserControl designationSealBranchRowUserControl = new DesignationSealBranchRowUserControl();
                    designationSealBranchRowUserControl.branchOfficeName = prapokGroupWise.FirstOrDefault().unit_name_bng;
                    designationSealBranchRowUserControl.unitCode = prapokGroupWise.FirstOrDefault().office_unit_code;
                    designationSealBranchRowUserControl.unitId = prapokGroupWise.FirstOrDefault().unit_id;

                    designationSealBranchRowUserControl.prapokDtos = prapokGroupWise;




                    ownOfficeRightFlowLayoutPanel.Controls.Add(designationSealBranchRowUserControl);


                }


              






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

        private void otherOfficeTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Checked==true)
            {
                MessageBox.Show(e.Node.Name);
                MessageBox.Show(e.Node.Text);
                MessageBox.Show(e.Node.Tag.ToString());

            }
            if (e.Node.Checked == false)
            {
                MessageBox.Show(e.Node.Name);
                MessageBox.Show(e.Node.Text);

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
                searchOfficeTextBox.Text = "";
                searchOfficeListBox.Visible = false;
                searchOfficePanel.Visible = true;
               

                searchOfficeTextBox.Focus();
            }
        }

        private void searchOfficeTextBox_TextChanged(object sender, EventArgs e)
        {
            searchOfficeListBox.DataSource = null;
            if (searchOfficeTextBox.Text == "")
            {
                searchOfficeListBox.Visible = false;

            }
            else
            {

                List<OfficeInfoDTO> officeInfoSearch = _officeInfo.Where(a => a.office_name_bng.Contains(searchOfficeTextBox.Text)).ToList();


          

                if (officeInfoSearch.Count > 0)
                {
                    searchOfficeListBox.DisplayMember = "office_name_bng";
                    searchOfficeListBox.DataSource = null;
                    searchOfficeListBox.DataSource = _officeInfo;

                    searchOfficeListBox.Visible = true;
                }
                else
                {
                    searchOfficeListBox.Visible = false;
                 
                }

            }
        }

        private void searchOfficeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchOfficePanel.Visible = false;
            officeSearchOfficeNameLabel.Text = searchOfficeListBox.GetItemText(searchOfficeListBox.SelectedItem);
            officerSearchOfficeIdLabel.Text = (searchOfficeListBox.SelectedItem as OfficeInfoDTO).id.ToString();


            PopulateOtherOfficerTree((searchOfficeListBox.SelectedItem as OfficeInfoDTO).id);

        }

        private void prapokownOfficeTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {

                

                if (e.Node.Checked == true)
                {
                    MessageBox.Show(e.Node.Name);
                    MessageBox.Show(e.Node.Text);
                    MessageBox.Show(e.Node.Tag.ToString());

                }
                if (e.Node.Checked == false)
                {
                    MessageBox.Show(e.Node.Name);
                    MessageBox.Show(e.Node.Text);

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
        }
    }
}

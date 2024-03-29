﻿
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.NothiUI;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiOnumodonDesignationSeal : Form
    {

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        private OnumodonResponse _onumodonResponse { get; set; }

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
        private void HideParentNodeCheckBox(TreeView treeView, TreeNode trNode)
        {
            
                TVITEM tvi = new TVITEM();
                tvi.hItem = trNode.Handle;
                tvi.mask = TVIF_STATE;
                tvi.stateMask = TVIS_STATEIMAGEMASK;
                tvi.state = 0;
                SendMessage(treeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);





            


        }





        private void button1_Click(object sender, System.EventArgs e)
        {
           
        }
        IDakUploadService _dakuploadservice { get; set; }
        IUserService _userService { get; set; }
        IOnumodonService _onumodonService { get; set; }

        private DakUserParam _dakUserParam = new DakUserParam();
        INothiNotePermissionService _nothiNotePermission { get; set; }

        private List<OfficeInfoDTO> _officeInfo = new List<OfficeInfoDTO>();
        private List<PrapokDTO> _ownOfficeDesignationList = new List<PrapokDTO>();
        private List<PrapokDTO> _otherOfficeDesignationList = new List<PrapokDTO>();
    
        public List<onumodonDataRecordDTO> _currentOnumodonRow = new List<onumodonDataRecordDTO>();
        public List<onumodonDataRecordDTO> _deletedOnumodonRow = new List<onumodonDataRecordDTO>();
        public List<onumodonDataRecordDTO> _addedOnumodonRow = new List<onumodonDataRecordDTO>();

        public NothiListRecordsDTO _nothiListRecordsDTO;

        public NothiListRecordsDTO nothiListRecordsDTO { get { return _nothiListRecordsDTO; } set { _nothiListRecordsDTO = value; } }

        public NothiOnumodonDesignationSeal(IDakUploadService dakUploadService, IUserService userService, INothiNotePermissionService nothiNotePermission, IOnumodonService onumodonService)
        {
            _dakuploadservice = dakUploadService;
            _userService = userService;
            _nothiNotePermission = nothiNotePermission;
            _onumodonService = onumodonService;
            _dakUserParam = _userService.GetLocalDakUserParam();
            InitializeComponent();

            _prapokownOfficeTreeView = new TreeView();


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

        

        public NothiListRecordsDTO nothiListRecord = new NothiListRecordsDTO();
        private int noteOrNothi = 0;//0 means nothi, 1 means note
        private string noteID ;//0 means nothi, 1 means note
        public void GetNothiInboxRecords(NothiListRecordsDTO nothiListRecordsDTO, string nothiOrNote, string NoteID)
        {
            nothiListRecord = nothiListRecordsDTO;
            var onumodonList = new OnumodonResponse();
            if (nothiOrNote == "Note") 
            {
                onumodonList = _onumodonService.GetNoteOnumodonMembers(_dakUserParam, nothiListRecord, NoteID);
                noteOrNothi = 1;
                noteID = NoteID;
            }
            else
            {
                onumodonList = _onumodonService.GetOnumodonMembers(_dakUserParam, nothiListRecord);
            } 
            if (onumodonList.status == "success")
            {
                _onumodonResponse = onumodonList;

                if (onumodonList.data.records.Count > 0)
                {
                    _currentOnumodonRow = onumodonList.data.records.OrderByDescending(a=>a.layer_index).ThenBy(a=>a.route_index).ToList();
                    var groupLevel = _currentOnumodonRow.GroupBy(a => a.layer_index);
                    foreach (var group in groupLevel)
                    {

                     

                        NothiOnumodonLevel nothiOnumodonRow = new NothiOnumodonLevel();
                        
                        nothiOnumodonRow.layerIndex = group.Key;
                        nothiOnumodonRow.DeleteButtonClick += delegate (object sender, EventArgs e) { officerdeleteButton_Click(sender, e, nothiOnumodonRow._designationId); };
                        nothiOnumodonRow.DeleteLevelButtonClick += delegate (object sender, EventArgs e) { leveldeleteButton_Click(sender, e, nothiOnumodonRow._layerIndex); };
                        nothiOnumodonRow.UpButton += delegate (object sender, EventArgs e) { officerUpButton_Click(sender, e,nothiOnumodonRow._layerIndex, nothiOnumodonRow._selectedRouteIndex); };
                        nothiOnumodonRow.DownButton += delegate (object sender, EventArgs e) { officerDownButton_Click(sender, e, nothiOnumodonRow._layerIndex, nothiOnumodonRow._selectedRouteIndex); };
                        nothiOnumodonRow.KarjodiboshButtonClick += delegate (object sender, EventArgs e) { karjodiboshButton_Click(sender , e, nothiOnumodonRow._layerIndex); };






                        foreach (var officer in group)
                        {
                            
                            nothiOnumodonRow.AddNewOfficer(officer.officer, officer.designation_id, officer.designation + "," + officer.office_unit + "," + officer.nothi_office_name, officer.route_index, officer.is_signatory);
                            nothiOnumodonRow.SignatoryCheckboxChanged += delegate (object sender, EventArgs e) { SignatoryCheckbox_Changed(sender as onumodonDataRecordDTO, e, officer.designation_id); };

                            nothiOnumodonRow.level = officer.layer_index.ToString();
                            nothiOnumodonRow.karjodibosh = officer.max_transaction_day.ToString();
                        }

                        nothiOnumodonFLP.Controls.Add(nothiOnumodonRow);



                    }
                }
                LoadOwnOfficerTree();

            }
        }

        private void officerDownButton_Click(object sender, EventArgs e, int layerIndex, int selectedRouteIndex)
        {
           // this.Hide();
       
          var sourceOnumodonRow=  _currentOnumodonRow.FirstOrDefault(a => a.layer_index == layerIndex && a.route_index == selectedRouteIndex);
          var destOnumodonRow=  _currentOnumodonRow.FirstOrDefault(a => a.layer_index == layerIndex && a.route_index == selectedRouteIndex+1);

            sourceOnumodonRow.route_index = selectedRouteIndex + 1;
            destOnumodonRow.route_index = selectedRouteIndex;

        }

        private void officerUpButton_Click(object sender, EventArgs e, int layerIndex, int selectedRouteIndex)
        {
         
            var sourceOnumodonRow = _currentOnumodonRow.FirstOrDefault(a => a.layer_index == layerIndex && a.route_index == selectedRouteIndex);
            var destOnumodonRow = _currentOnumodonRow.FirstOrDefault(a => a.layer_index == layerIndex && a.route_index == selectedRouteIndex - 1);

            sourceOnumodonRow.route_index = selectedRouteIndex - 1;
            destOnumodonRow.route_index = selectedRouteIndex;
        }

        private void leveldeleteButton_Click(object sender, EventArgs e, int level)
        {

            var onumodonRowforThisLevel = _currentOnumodonRow.Where(a => a.layer_index == level).ToList();

            if(onumodonRowforThisLevel != null && onumodonRowforThisLevel.Count>0)
            {
                foreach(var singleOnumodon in onumodonRowforThisLevel)
                {
                    CheckUncheckTreeNode(prapokownOfficeTreeView.Nodes, false, singleOnumodon.designation_id);
                    

                }
                _currentOnumodonRow = _currentOnumodonRow.Where(a=>a.layer_index!=level).ToList();
                _deletedOnumodonRow.AddRange(onumodonRowforThisLevel);
               

            }

            if(level < _currentOnumodonRow.Max(a=>a.layer_index))
            {
                var highLevelOnumodonRow = _currentOnumodonRow.Where(a => a.layer_index > level).ToList();
                if(highLevelOnumodonRow != null && highLevelOnumodonRow.Count>0)
                {
                    foreach(var onumodonRow in highLevelOnumodonRow)
                    {
                        onumodonRow.layer_index -= 1;
                    }
                }
            }


            LoadOnumodonLevelinRightSide(_currentOnumodonRow.OrderByDescending(a => a.layer_index).ToList());

            

        }
        private void karjodiboshButton_Click(object max_transaction_day, EventArgs e, int level)
        {
            var onumodonRowforThisLevel = _currentOnumodonRow.Where(a => a.layer_index == level).ToList();

            if (onumodonRowforThisLevel != null && onumodonRowforThisLevel.Count > 0)
            {
                _currentOnumodonRow = _currentOnumodonRow.Where(a => a.layer_index != level).ToList();

                foreach (var singleOnumodon in onumodonRowforThisLevel)
                {
                    onumodonDataRecordDTO onumodonDataRecordDTO = new onumodonDataRecordDTO();
                    onumodonDataRecordDTO.officer_id = singleOnumodon.officer_id;
                    onumodonDataRecordDTO.layer_index = singleOnumodon.layer_index;
                    onumodonDataRecordDTO.office_id = singleOnumodon.office_id;
                    onumodonDataRecordDTO.office_unit = singleOnumodon.office_unit;
                    onumodonDataRecordDTO.office_unit_id = singleOnumodon.office_unit_id;
                    onumodonDataRecordDTO.officer = singleOnumodon.officer;
                    onumodonDataRecordDTO.office = singleOnumodon.office;
                    onumodonDataRecordDTO.designation_level = singleOnumodon.designation_level;
                    onumodonDataRecordDTO.designation_id = singleOnumodon.designation_id;
                    onumodonDataRecordDTO.designation = singleOnumodon.designation;
                    onumodonDataRecordDTO.route_index = singleOnumodon.route_index;
                    onumodonDataRecordDTO.nothi_master_id = singleOnumodon.nothi_master_id;
                    onumodonDataRecordDTO.is_active = singleOnumodon.is_active;
                    onumodonDataRecordDTO.is_signatory = singleOnumodon.is_signatory;
                    onumodonDataRecordDTO.level_name = singleOnumodon.level_name;
                    onumodonDataRecordDTO.max_transaction_day = Convert.ToInt32(max_transaction_day.ToString());

                    _currentOnumodonRow.Add(onumodonDataRecordDTO);

                }
                


            }
            LoadOnumodonLevelinRightSide(_currentOnumodonRow.OrderByDescending(a => a.layer_index).ToList());
        }
        private void SignatoryCheckbox_Changed(onumodonDataRecordDTO onumodonDataRecordDTO1, EventArgs e, int id)
        {
            if (onumodonDataRecordDTO1.designation_id == id)
            {
                var onumodonRowforThisLevel = _currentOnumodonRow.Where(a => a.designation_id == id).ToList();

                if (onumodonRowforThisLevel != null && onumodonRowforThisLevel.Count > 0)
                {
                    _currentOnumodonRow = _currentOnumodonRow.Where(a => a.designation_id != id).ToList();

                    foreach (var singleOnumodon in onumodonRowforThisLevel)
                    {
                        onumodonDataRecordDTO onumodonDataRecordDTO = new onumodonDataRecordDTO();
                        onumodonDataRecordDTO.officer_id = singleOnumodon.officer_id;
                        onumodonDataRecordDTO.layer_index = singleOnumodon.layer_index;
                        onumodonDataRecordDTO.office_id = singleOnumodon.office_id;
                        onumodonDataRecordDTO.office_unit = singleOnumodon.office_unit;
                        onumodonDataRecordDTO.office_unit_id = singleOnumodon.office_unit_id;
                        onumodonDataRecordDTO.officer = singleOnumodon.officer;
                        onumodonDataRecordDTO.office = singleOnumodon.office;
                        onumodonDataRecordDTO.designation_level = singleOnumodon.designation_level;
                        onumodonDataRecordDTO.designation_id = singleOnumodon.designation_id;
                        onumodonDataRecordDTO.designation = singleOnumodon.designation;
                        onumodonDataRecordDTO.route_index = singleOnumodon.route_index;
                        onumodonDataRecordDTO.nothi_master_id = singleOnumodon.nothi_master_id;
                        onumodonDataRecordDTO.is_active = singleOnumodon.is_active;
                        onumodonDataRecordDTO.is_signatory = onumodonDataRecordDTO1.is_signatory;
                        onumodonDataRecordDTO.level_name = singleOnumodon.level_name;
                        onumodonDataRecordDTO.max_transaction_day = singleOnumodon.max_transaction_day;

                        _currentOnumodonRow.Add(onumodonDataRecordDTO);

                    }



                }
                //LoadOnumodonLevelinRightSide(_currentOnumodonRow.OrderByDescending(a => a.layer_index).ToList());
            }
        }
        private TreeNode FindTreeNode(TreeNodeCollection nodes, int id)
        {
            foreach(TreeNode treeNode in nodes)
            {
                int treeId = 0;

                try { treeId = Convert.ToInt32(treeNode.Name); } catch{ }

                if(treeId== id)
                {
                    return treeNode;
                }
                else if(treeNode.Nodes.Count>0)
                {
                    TreeNode searchTreeNode = FindTreeNode(treeNode.Nodes, id);
                    if(searchTreeNode != null)
                    {
                        return searchTreeNode;
                    }
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        private void officerdeleteButton_Click(object sender, EventArgs e, int designationid)
        {
             onumodonDataRecordDTO onumodonDataRecordDTOs = _currentOnumodonRow.FirstOrDefault(a =>a.designation_id==designationid);
            if(onumodonDataRecordDTOs != null)
            {
                _deletedOnumodonRow.Add(onumodonDataRecordDTOs);
                _currentOnumodonRow = _currentOnumodonRow.Where(a=>a.designation_id!=designationid).ToList();

            }


            CheckUncheckTreeNode(prapokownOfficeTreeView.Nodes, false, designationid);


        }

        List<NothiOnumodonRowDTO> nothiOnumodons = new List<NothiOnumodonRowDTO>();
        List<NothiOnumodonLevel> nothiOnumodonRows = new List<NothiOnumodonLevel>();
        int inc = 0;
        int level = 1;
        private void LoadOwnOfficerTree()
        {



          
            

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
                                childNode.Tag = officer.designation_bng + "," + officer.office_unit_bng + "," + officer.office_name_bng;
                                childNode.Text = officer.NameWithDesignation;
                                childNode.Name = officer.designation_id.ToString();
                                if (officer.employee_name_bng == "শুন্যপদ")
                                {
                                    childNode.ForeColor = Color.Gray;
                                }

                              
                                

                                  branchNodeOwnOffice.Nodes.Add(childNode);


                                if(_onumodonResponse.data.records.Any(a => a.designation_id == officer.designation_id))
                                {
                                    CheckUncheckTreeNode(branchNodeOwnOffice.Nodes, true, officer.designation_id);
                                }




                            }

                            prapokownOfficeTreeView.Nodes.Add(branchNodeOwnOffice);






                        }


                    }

                 

                }
            }








            UIDesignCommonMethod.AssignNode(prapokownOfficeTreeView, _prapokownOfficeTreeView);
            OfficerStatTreeOwn(unitOwnOffice, designationOwnOffice, emptydesignationOwnOffice, workingdesignationOwnOffice);

            MakeParentTreeDisable(prapokownOfficeTreeView);

          


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

        public TreeView _prapokownOfficeTreeView;
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


                    



                    if(otherOfficeDesignationByOfficeId.Any(a=>a.unitWithCode==group.Key && a.isofficerAdded==true))
                    {
                        designationSealBranchRowUserControl.Visible = true;
                    }
                    else
                    {
                        designationSealBranchRowUserControl.Visible = false;
                    }
                


                }









            }









        }

        
        private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck, int designationid)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                try
                {
                    if (Convert.ToInt32(trNode.Name) == designationid)
                    {
                       
                        if(isCheck)
                        {
                            trNode.Checked = isCheck;
                            trNode.ForeColor = Color.Gray;
                        }
                        else
                        {
                            trNode.ForeColor = Color.Black;
                            trNode.Checked = false;
                        }
                      
                        break;
                    }
                }
                catch
                {

                }

                 if (trNode.Nodes.Count > 0)
                CheckUncheckTreeNode(trNode.Nodes, isCheck, designationid);
            }
        }
        private void tabControlLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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


          






            if (e.Node.Parent==null)
            {
                e.Node.Checked = false;
            }
            if (e.Action != TreeViewAction.Unknown)
            {

                if (e.Node.Checked == true)
                {
                    int maxLevel = _currentOnumodonRow.Max(a => a.layer_index);

                    var nothiLevelAddForm = FormFactory.Create<NothiLevelAddForm>();

                    nothiLevelAddForm.SetLevelComboBox(maxLevel);
                    
                    PrapokDTO officer = _ownOfficeDesignationList.FirstOrDefault(a => a.designation_id == Convert.ToInt32(e.Node.Name));

                    nothiLevelAddForm.SaveButtonClick += delegate (object saveSender, EventArgs saveEvent) { newOfficerSaveButton_Click(saveSender, saveEvent, nothiLevelAddForm._selectedLevel, officer); };
                  

                    CalPopUpWindow(nothiLevelAddForm);
                   

                   
                }
             

            }
            
        }

        private void newOfficerSaveButton_Click(object saveSender, EventArgs saveEvent, int selectedLevel, PrapokDTO officer)
        {
            AddNewOfficerTotheLevel(officer, selectedLevel);
        }

        private void AddNewOfficerTotheLevel(PrapokDTO officer, int selectedLevel)
        {
            int ab = nothiOnumodonFLP.Controls.Count;
            var officerSearch = _currentOnumodonRow.FirstOrDefault(a => a.layer_index == selectedLevel);

           if(selectedLevel==0 || officerSearch ==null)
            {
                ReorderLevel(selectedLevel, officer);
            }
           else
            {
                var nothiOnumodonSearch = nothiOnumodonFLP.Controls.OfType<NothiOnumodonLevel>().FirstOrDefault(a=>a._layerIndex==selectedLevel);

                if (nothiOnumodonSearch != null)
                {

                    List<onumodonDataRecordDTO> countOnumodonDataRecordDTO = _currentOnumodonRow.Where(a => a.layer_index == selectedLevel).ToList();

                    onumodonDataRecordDTO onumodonDataRecordDTO = new onumodonDataRecordDTO();
                    onumodonDataRecordDTO.officer_id = officer.officer_id;
                    onumodonDataRecordDTO.layer_index = selectedLevel;
                    onumodonDataRecordDTO.office_id = officer.office_id;
                    onumodonDataRecordDTO.office_unit = officer.office_unit;
                    onumodonDataRecordDTO.office_unit_id = officer.office_unit_id;
                    onumodonDataRecordDTO.officer = officer.officer;
                    onumodonDataRecordDTO.office = officer.office;
                    onumodonDataRecordDTO.designation_level = officer.designation_level;
                    onumodonDataRecordDTO.designation_id = officer.designation_id;
                    onumodonDataRecordDTO.designation = officer.designation;
                    onumodonDataRecordDTO.is_signatory = officer.is_signatory;
                    onumodonDataRecordDTO.route_index = countOnumodonDataRecordDTO.Count + 1;
                    onumodonDataRecordDTO.nothi_master_id = Convert.ToInt32(_nothiListRecordsDTO.id);
                    onumodonDataRecordDTO.is_active = 1;
                    onumodonDataRecordDTO.level_name = "লেভেল " + string.Concat((ab + 1).ToString().Select(c => (char)('\u09E6' + c - '0')));

                    _currentOnumodonRow.Add(onumodonDataRecordDTO);
                    nothiOnumodonSearch.AddNewOfficer(officer.employee_name_bng, officer.designation_id, officer.designation_bng + "," + officer.office_unit_bng + "," + officer.office_name_bng, onumodonDataRecordDTO.route_index, officer.is_signatory);

                }
            }
        }

        private void ReorderLevel(int selectedLevel, PrapokDTO officer)
        {
            int ab = nothiOnumodonFLP.Controls.Count;
            var onumodonDataRecordFrom_current = _currentOnumodonRow.First();
            onumodonDataRecordDTO onumodonDataRecordDTO = new onumodonDataRecordDTO();


            int id = _currentOnumodonRow.Max(a => a.layer_index);



            if(selectedLevel==0)
            {
                onumodonDataRecordDTO.layer_index = 1;
                foreach (var onumodon in _currentOnumodonRow)
                {
                    onumodon.layer_index += 1;
                }
               
               
            }
            else
            {
                onumodonDataRecordDTO.layer_index = id + 1;
            }
            List<onumodonDataRecordDTO> countOnumodonDataRecordDTO = _currentOnumodonRow.Where(a => a.layer_index == onumodonDataRecordDTO.layer_index).ToList();


            onumodonDataRecordDTO.officer_id = officer.officer_id;
            onumodonDataRecordDTO.office_id = officer.office_id;
            onumodonDataRecordDTO.office_unit = officer.office_unit;
            onumodonDataRecordDTO.office_unit_id = officer.office_unit_id;
            onumodonDataRecordDTO.officer = officer.officer;
            onumodonDataRecordDTO.office = officer.office;
            onumodonDataRecordDTO.designation_level = officer.designation_level;
            onumodonDataRecordDTO.designation_id = officer.designation_id;
            onumodonDataRecordDTO.designation = officer.designation;
            onumodonDataRecordDTO.is_signatory = officer.is_signatory;
            onumodonDataRecordDTO.route_index = countOnumodonDataRecordDTO.Count + 1 ;
            onumodonDataRecordDTO.nothi_master_id =Convert.ToInt32(_nothiListRecordsDTO.id);
            onumodonDataRecordDTO.is_active =1;
            onumodonDataRecordDTO.level_name = "লেভেল " + string.Concat((ab+1).ToString().Select(c => (char)('\u09E6' + c - '0')));


            _currentOnumodonRow.Add(onumodonDataRecordDTO);

                LoadOnumodonLevelinRightSide(_currentOnumodonRow.OrderByDescending(a=>a.layer_index).ThenBy(a=>a.route_index).ToList());

            
        }
       
        private void LoadOnumodonLevelinRightSide(List<onumodonDataRecordDTO> onumodonList)
        {

            nothiOnumodonFLP.Controls.Clear();

            var groupLevel = onumodonList.GroupBy(a => a.layer_index);
            foreach (var group in groupLevel)
            {



                NothiOnumodonLevel nothiOnumodonRow = new NothiOnumodonLevel();
                
                nothiOnumodonRow.layerIndex = group.Key;
                nothiOnumodonRow.DeleteButtonClick += delegate (object sender, EventArgs e) { officerdeleteButton_Click(sender, e, nothiOnumodonRow._designationId); };
                nothiOnumodonRow.DeleteLevelButtonClick += delegate (object sender, EventArgs e) { leveldeleteButton_Click(sender, e, nothiOnumodonRow._layerIndex); };
                nothiOnumodonRow.KarjodiboshButtonClick += delegate (object sender, EventArgs e) { karjodiboshButton_Click(sender, e, nothiOnumodonRow._layerIndex); };






                foreach (var officer in group)
                {

                    nothiOnumodonRow.AddNewOfficer(officer.officer, officer.designation_id, officer.designation + "," + officer.office_unit + "," + officer.nothi_office_name,officer.route_index, officer.is_signatory);
                    nothiOnumodonRow.SignatoryCheckboxChanged += delegate (object sender, EventArgs e) { SignatoryCheckbox_Changed(sender as onumodonDataRecordDTO, e, officer.designation_id); };

                    nothiOnumodonRow.level = officer.layer_index.ToString();
                    nothiOnumodonRow.karjodibosh = officer.max_transaction_day.ToString();
                }

                nothiOnumodonFLP.Controls.Add(nothiOnumodonRow);



            }
        }

        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .6;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog(this);
        }

        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog(this);

            (sender as Form).Hide();

           
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

            else if (!e.Node.Checked)
            {
                e.Node.ForeColor = Color.Gray;
                
            }
        }

        public void MakeParentTreeDisable(TreeView treeView)
        {
            foreach (TreeNode singleNode in treeView.Nodes)
            {
                singleNode.ForeColor = Color.Gray;
                HideParentNodeCheckBox(treeView, singleNode);
                
            }

            HideParentNodeCheckBox(treeView, treeView.Nodes[0]);
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
        NothiNextStep nothiType = UserControlFactory.Create<NothiNextStep>();
        
        public void loadNewNoteDataFromNote(NothiNextStep newNoteViewFromNote)
        {
            nothiType = newNoteViewFromNote;
        }
        NoteListDataRecordNoteDTO notelist = new NoteListDataRecordNoteDTO();
        public void loadNoteList(NoteListDataRecordNoteDTO notelistFromNote)
        {
            notelist = notelistFromNote;
        }
        private string _nothiLastDate;
        private string _noteSubject;
        private string _noteIdfromNothiInboxNoteShomuho;

        [Category("Custom Props")]
        public string noteIdfromNothiInboxNoteShomuho
        {
            get { return _noteIdfromNothiInboxNoteShomuho; }
            set
            {
                _noteIdfromNothiInboxNoteShomuho = value;
            }
        }
        [Category("Custom Props")]
        public string noteTotal
        {
            get { return _noteTotal; }
            set
            {
                _noteTotal = value;
            }
        }
        public string totalRange
        {
            get { return _noteTotal; }
            set
            {
                _noteTotal = value;
            }
        }

        [Category("Custom Props")]
        public string nothiLastDate
        {
            get { return _nothiLastDate; }
            set { _nothiLastDate = value;  }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; }
        }
        private string _nothiShakha;
        private string _nothiNo;
        private string _nothiSubject;
        private string _noteTotal;
        private string _office;
        private string _totalRange;
        public NothiListInboxNoteRecordsDTO _NoteAllListDataRecordDTO { get; set; }
        public NothiListInboxNoteRecordsDTO noteAllListDataRecordDTO
        {
            get { return _NoteAllListDataRecordDTO; }
            set
            {
                _NoteAllListDataRecordDTO = value;
            }
        }
        NothiListRecordsDTO nothiListRecords = new NothiListRecordsDTO();
        public void loadNothiInboxRecords(NothiListRecordsDTO nothiListRecordsDTO)
        {
            nothiListRecords = nothiListRecordsDTO;
        }
        NoteView newNoteView = new NoteView();
        public void loadNoteView(NoteView noteView)
        {
            newNoteView = noteView;
        }
        [Category("Custom Props")]
        public string office
        {
            get { return _office; }
            set { _office = value; }
        }

        [Category("Custom Props")]
        public string nothiShakha
        {
            get { return _nothiShakha; }
            set { _nothiShakha = value; }
        }

        [Category("Custom Props")]
        public string nothiNo
        {
            get { return _nothiNo; }
            set { _nothiNo = value; }
        }

        [Category("Custom Props")]
        public string nothiSubject
        {
            get { return _nothiSubject; }
            set { _nothiSubject = value; }
        }
        public event EventHandler SuccessfullyOnumodonSaveButton;
        private void saveDesignationSealButton_Click(object sender, EventArgs e)
        {
         
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি সফলভাবে সংরক্ষণ করতে চান?";
            conditonBoxForm.ShowDialog(this);
            var nothiNotePermission = new NothiNotePermissionResponse();
            if (conditonBoxForm.Yes)
            {
                if (noteOrNothi == 0)
                {
                    nothiNotePermission = _nothiNotePermission.GetNothiPermission(_dakUserParam, _currentOnumodonRow.OrderByDescending(a => a.layer_index).ThenBy(a => a.route_index).ToList(), _nothiListRecordsDTO, Convert.ToInt32(_nothiListRecordsDTO.office_id));

                }else if(noteOrNothi == 1)
                {
                    nothiNotePermission = _nothiNotePermission.GetNothiNotePermission(_dakUserParam, _currentOnumodonRow.OrderByDescending(a => a.layer_index).ThenBy(a => a.route_index).ToList(), _nothiListRecordsDTO, Convert.ToInt32(_nothiListRecordsDTO.office_id), noteID);
                }

                if (nothiNotePermission.status == "success" && nothiNotePermission.message != "Local")
                {
                    UIDesignCommonMethod.SuccessMessage("সফলভাবে তথ্য সংরক্ষণ করা হয়েছে");

                    
                    if (this.SuccessfullyOnumodonSaveButton != null)
                        this.SuccessfullyOnumodonSaveButton(sender, e);
                    
                    this.Hide();
                    if (notelist.note_status != null)
                    {
                        var invi = FormFactory.Create<Note>();
                        invi.loadnothiListRecordsAndNothiTypeFromNothiOnumodonDesgSeal(_nothiListRecordsDTO, nothiType, notelist, noteID, 
                            _noteIdfromNothiInboxNoteShomuho, _nothiNo, _nothiShakha, _nothiSubject, _nothiLastDate, _NoteAllListDataRecordDTO, _office, newNoteView);
                    }
                          
                }else if (nothiNotePermission.status == "success" && nothiNotePermission.message == "Local")
                {
                    UIDesignCommonMethod.SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে তথ্য সংরক্ষণ করা হবে");
                    this.Hide();
                }
                else
                {
                    UIDesignCommonMethod.ErrorMessage("সংরক্ষণ সফল হ​য়নি।।");
                }

            }
      
            
            
        }

        private void nothiOnumodonFLP_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Move;
        }

        private void nothiOnumodonFLP_DragDrop(object sender, DragEventArgs e)
        {
            NothiOnumodonLevel data = (NothiOnumodonLevel)e.Data.GetData(typeof(NothiOnumodonLevel));

            FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
            FlowLayoutPanel _source = (FlowLayoutPanel)data.Parent;

            if (_source == _destination)
            {
                // Just add the control to the new panel.
                // No need to remove from the other panel, this changes the Control.Parent property.
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);
                _destination.Controls.SetChildIndex(data, index);
                _destination.Invalidate();
            }
           
        }

        private void allCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            var nothiOnumodonSearch = nothiOnumodonFLP.Controls.OfType<NothiOnumodonLevel>().ToList();
            if(nothiOnumodonSearch != null && nothiOnumodonSearch.Count>0)
            {
                
                foreach (NothiOnumodonLevel nothiOnumodonLevel in nothiOnumodonSearch)
                {
                    nothiOnumodonLevel.checkedBox = allCheckBox.Checked;
                }
            }


          
        }


        

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void prapokSearchOwnOfficeTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = prapokSearchOwnOfficeTextBox.Text.ToString();

            UIDesignCommonMethod.SearchFromTree(prapokownOfficeTreeView,_prapokownOfficeTreeView, searchText);
        }

        private void allSignedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allSignedCheckBox.Checked == true)
            {
                onumodonDataRecordDTO onumodonDataRecordDTO1 = new onumodonDataRecordDTO();
                onumodonDataRecordDTO1.is_signatory = 1;
                allSignedCheckBox.Checked = true;
                AllSignatoryCheckbox_Changed(onumodonDataRecordDTO1, e);
            }
            else
            {
                onumodonDataRecordDTO onumodonDataRecordDTO1 = new onumodonDataRecordDTO();
                onumodonDataRecordDTO1.is_signatory = 2;
                allSignedCheckBox.Checked = false;
                AllSignatoryCheckbox_Changed(onumodonDataRecordDTO1, e);
            }
        }
        private void AllSignatoryCheckbox_Changed(onumodonDataRecordDTO onumodonDataRecordDTO1, EventArgs e)
        {
            var onumodonRowforThisLevel = _currentOnumodonRow;
            _currentOnumodonRow = new List<onumodonDataRecordDTO>();

                if (onumodonRowforThisLevel != null && onumodonRowforThisLevel.Count > 0)
                {
                    foreach (var singleOnumodon in onumodonRowforThisLevel)
                    {
                        onumodonDataRecordDTO onumodonDataRecordDTO = new onumodonDataRecordDTO();
                        onumodonDataRecordDTO.officer_id = singleOnumodon.officer_id;
                        onumodonDataRecordDTO.layer_index = singleOnumodon.layer_index;
                        onumodonDataRecordDTO.office_id = singleOnumodon.office_id;
                        onumodonDataRecordDTO.office_unit = singleOnumodon.office_unit;
                        onumodonDataRecordDTO.office_unit_id = singleOnumodon.office_unit_id;
                        onumodonDataRecordDTO.officer = singleOnumodon.officer;
                        onumodonDataRecordDTO.office = singleOnumodon.office;
                        onumodonDataRecordDTO.designation_level = singleOnumodon.designation_level;
                        onumodonDataRecordDTO.designation_id = singleOnumodon.designation_id;
                        onumodonDataRecordDTO.designation = singleOnumodon.designation;
                        onumodonDataRecordDTO.route_index = singleOnumodon.route_index;
                        onumodonDataRecordDTO.nothi_master_id = singleOnumodon.nothi_master_id;
                        onumodonDataRecordDTO.is_active = singleOnumodon.is_active;
                        onumodonDataRecordDTO.is_signatory = onumodonDataRecordDTO1.is_signatory;
                        onumodonDataRecordDTO.level_name = singleOnumodon.level_name;
                        onumodonDataRecordDTO.max_transaction_day = singleOnumodon.max_transaction_day;

                        _currentOnumodonRow.Add(onumodonDataRecordDTO);

                    }



                }
                LoadOnumodonLevelinRightSide(_currentOnumodonRow.OrderByDescending(a => a.layer_index).ToList());
        
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Desktop.View_Model;
using AutoMapper;
using System.Web.Script.Serialization;
using dNothi.Utility;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Constants;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.DakServices.DakSharingService;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakForwardUserControl : Form
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;
        
        public int _inbox_officer_designation_id { get; set; }


        IDakForwardService _dakForwardService { get; set; }
        IUserService _userService { get; set; }
        IDakSharingService<ResponseModel> _dakSharingService { get; set; }
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        private int _dak_id;
        private string _dak_type;
        private string _dak_subject;
        private int _is_copied_dak;

        public bool  _IsDakLocallyUploaded;
     
        private string _dakSecurityIconValue;

        private string _dakPriority;
        public bool fromDakBacai;
    public bool _fromDakBacai { get { return fromDakBacai; }  
                               set { fromDakBacai = value; 
                                      if (value == true) {
                                                sendButton.Text = "সংরক্ষণ করুন";
                    MyToolTip.SetToolTip(sendButton, "সংরক্ষণ করুন");
                                        }
                                        else
                                        {
                                           sendButton.Text = "প্রেরণ করুন";
                    MyToolTip.SetToolTip(sendButton, "প্রেরণ করুন");
                }
                                   } 
                              }

        
    public string dakPrioriy
        {
            get { return _dakPriority; }
            set
            {
                _dakPriority = value;


                DakPriorityList dakPriorityList = new DakPriorityList();
                string priorityName = dakPriorityList.GetDakPriorityName(value);


                if (priorityName == "")
                {
                   
                }
                else
                {
                    prioritySearchButton.searchButtonText = priorityName;

                }






            }
        }

        public string dakSecurityIconValue
        {



            get { return _dakSecurityIconValue; }
            set
            {
                _dakSecurityIconValue = value;

                DakSecurityList dakSecurityList = new DakSecurityList();
                string securityName = dakSecurityList.GetDakSecuritiesName(value);
                if(securityName!="")
                {
                    secretLevelSearchButton.searchButtonText = securityName;
                }
               






            }
        }

        public int _totalForwardRequest;
        
        public int _totalSuccessForwardRequest;
        
        public int _totalFailForwardRequest;
       
        private DakUserParam _dak_List_User_Param;

        public List<DakListRecordsDTO> _dakListRecordsDTO;
        public List<DakListRecordsDTO> _dakListResponse;

        public List<DakListRecordsDTO> dakListRecordsDTO
        {

            get { return _dakListRecordsDTO; }
            set
            {
                _dakListRecordsDTO = value;

                foreach(DakListRecordsDTO dakListRecordsDTO in value)
                {
                    SelectedDakListUserControl selectedDakListUserControl = new SelectedDakListUserControl();
                    selectedDakListUserControl.dakUserDTO = dakListRecordsDTO.dak_user;
                    selectedDakListUserControl.dakorigin = dakListRecordsDTO.dak_origin;
                    if(dakListRecordsDTO.movement_status!=null && dakListRecordsDTO.movement_status.from!=null)
                    {
                        selectedDakListUserControl.prerok = dakListRecordsDTO.movement_status.from.officer;
                    }
                    selectedDakListUserControl.DeleteDakFromList += delegate (object sender, EventArgs e) { DeleteDak(); };


                    UIDesignCommonMethod.AddRowinTable(selectedDakListFlowLayoutPanel, selectedDakListUserControl);



                }
            }
        
        }

        private void DeleteDak()
        {
            var dakInboxUserControls = selectedDakListFlowLayoutPanel.Controls.OfType<SelectedDakListUserControl>().ToList();
            if(!dakInboxUserControls.Any(a=>a._isSelected==true))
            {
                this.Hide();
            }
        }

        public bool _isMultipleDak { get; set; }
        public int _dakCount { get; set; }
        public int dakCount { get { return _dakCount; } set { _dakCount = value; selectedCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }



        public bool isMultipleDak { get { return _isMultipleDak; }
            set { _isMultipleDak = value;
            if(value)
                {
                    multipleDakHeaderLabel.Visible = true;
                    singleDakHeaderLabel.Visible = false;

                    selectedDakListPanel.Visible = true;
                    Subjectlabel.Visible = false;

                   



                }
            } 
        
        }




        public DakUserParam dak_List_User_Param {
            get { return _dak_List_User_Param; }

            set { _dak_List_User_Param = value; }
        }
        public string dak_subject {
            get { return _dak_subject; }

            set { _dak_subject = value; Subjectlabel.Text = value; }
        }

        public int dak_id
        {
            get { return _dak_id; }
            set
            {
                _dak_id = value;
            }

        }

        public int is_copied_dak
        {
            get { return _is_copied_dak; }
            set
            {
                _is_copied_dak = value;
            }

        }

        public string dak_type
        {
            get { return _dak_type; }
            set
            {
                _dak_type = value;
            }

        }

        public void LoadDecisionList()
        {
            try
            {
                decisionListFlowLayoutPanel.Controls.Clear();
                DakUserParam userParam = _userService.GetLocalDakUserParam();

                DakDecisionListResponse dakDecisionListResponse = _dakForwardService.GetDakDecisionListResponse(userParam);
                if (dakDecisionListResponse != null)
                {
                    if (dakDecisionListResponse.data.Count > 0)
                    {
                        foreach (DakDecisionDTO dakDecisionDTO in dakDecisionListResponse.data)
                        {
                            var decisionTable = UserControlFactory.Create<DakDecisionTableUserControl>();
                            decisionTable.id = dakDecisionDTO.id;
                            decisionTable.decision = dakDecisionDTO.dak_decision;
                            decisionTable.RadioButtonClick += delegate (object sender, EventArgs e) { dakDecisionTableUserControl_RadioButtonClick(sender, e, dakDecisionDTO.id); };


                            if (dakDecisionDTO.dak_decision_employee == 1)
                            {
                                decisionTable.isAdded = true;
                                decisionComboBox.Items.Add(dakDecisionDTO.dak_decision);
                            }
                            else
                            {
                                decisionTable.isAdded = false;
                            }

                            UIDesignCommonMethod.AddRowinTable(decisionListFlowLayoutPanel, decisionTable);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private DesignationSealListResponse _designationSealListResponse;

        public DesignationSealListResponse designationSealListResponse
        {
            get { return _designationSealListResponse; }
            set
            {
                _designationSealListResponse = value;
                try
                {
                    foreach (PrapokDTO ownOfficeDTO in value.data.own_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOwnOffice = mapper.Map<ViewDesignationSealList>(ownOfficeDTO);



                        viewdesignationListOwnOffice.nij_Office = true;



                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOwnOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOwnOffice);
                        }

                    }

                    foreach (PrapokDTO otherOfficeDTO in value.data.other_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOtherOffice = mapper.Map<ViewDesignationSealList>(otherOfficeDTO);
                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOtherOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOtherOffice);
                        }

                    }

                    PopulateOwnOfficeGrid();
                    PopulateOtherOfficeGrid();

                }
                catch
                {

                }



            }

        }

        public DakForwardUserControl(IDakForwardService dakForwardService, IUserService userService, IDakSharingService<ResponseModel> dakSharingService )
        {
            _dakForwardService = dakForwardService;
            _userService = userService;
            _dakSharingService = dakSharingService;
            InitializeComponent();
            PriorityListCollection.Clear();
            LoadDecisionList();
           



        }

       
        private void nothivuktoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = nothivuktoRadioButton.Text;
        }

        private void NothijatoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = NothijatoRadioButton.Text;
        }

        private void decisionOwnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = decisionComboBox.Text.ToString();
        }

     
        private void decisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = decisionComboBox.SelectedItem.ToString();
        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        int designationColumn = 2;
        private void SaveOwnOnulipiPrapok(int row_index)
        {
           
            for (int i = 0; i <= prapokOwnDataGridView.Rows.Count-1; i++)
            {
                if (i == row_index)
                {
                    prapokOwnDataGridView.Rows[i].Cells[onulipiColumn].Value = false;
                    prapokOwnDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;
                    

                
                    int designation_id = (int)prapokOwnDataGridView.Rows[i].Cells[designationColumn].Value;
                    SetThisMulprapokfalse(designation_id);
                }
            }
        }

        private void SaveOtherOnulipiPrapok(int row_index)
        {

            for (int i = 0; i <= prapokOthersDataGridView.Rows.Count - 1; i++)
            {
                if (i == row_index)
                {
                    prapokOthersDataGridView.Rows[i].Cells[onulipiColumn].Value = false;
                    prapokOthersDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                    int designation_id = (int)prapokOthersDataGridView.Rows[i].Cells[designationColumn].Value;
                    SetThisMulprapokfalse(designation_id);
                }
            }
        }

        private void SetThisMulprapokfalse(int designation_id)
        {
          viewDesignationSealLists.FirstOrDefault(a => a.designation_id == designation_id).mul_prapok=false;

            
        }

        private void SaveOwnMulPrapok(int row_index)
        {
            for (int i = 0; i <= prapokOwnDataGridView.Rows.Count-1; i++)
            {
                prapokOwnDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;
             
                if (i != row_index)
                {
                    prapokOwnDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;
          


                }
                else
                {
                    int designation_id = (int)prapokOwnDataGridView.Rows[i].Cells[designationColumn].Value;
                    prapokOwnDataGridView.Rows[i].Cells[onulipiColumn].Value = false;

                    SetOtherMulprapokfalse(designation_id);

                }
            }
        }

        private void SaveOtherMulPrapok(int row_index)
        {
            for (int i = 0; i <= prapokOthersDataGridView.Rows.Count - 1; i++)
            {
                prapokOthersDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;

                if (i != row_index)
                {
                    prapokOthersDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                }
                else
                {
                    int designation_id = (int)prapokOthersDataGridView.Rows[i].Cells[designationColumn].Value;
                    prapokOthersDataGridView.Rows[i].Cells[onulipiColumn].Value = false;

                    SetOtherMulprapokfalse(designation_id);

                }
            }
        }

        private void SetOtherMulprapokfalse(int designation_id)
        {
            foreach(ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists)
            {
                if(viewDesignationSealList.designation_id!=designation_id)
                {
                    viewDesignationSealList.mul_prapok = false;
                }
                else
                {
                    viewDesignationSealList.mul_prapok = true;
                }
            }
        }

        
        public void PopulateOwnOfficeGrid()
        {
           

            BindingList<ViewDesignationSealList> bindinglist = new BindingList<ViewDesignationSealList>();
            foreach (ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists.Where(a => a.nij_Office == true))
            {
                bindinglist.Add(viewDesignationSealList);
            }
            prapokOwnDataGridView.DataSource = null;
            prapokOwnDataGridView.DataSource = bindinglist;
        }
        public void PopulateOtherOfficeGrid()
        {

            BindingList<ViewDesignationSealList> bindinglist = new BindingList<ViewDesignationSealList>();
            foreach (ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists.Where(a => a.nij_Office == true))
            {
                bindinglist.Add(viewDesignationSealList);
            }
            prapokOthersDataGridView.DataSource = null;
            prapokOthersDataGridView.DataSource = bindinglist;
        }

         private void prapokDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;
            //bool mulprapok = (bool)prapokDataGridView.Rows[row_index].Cells[mulPrapokColumn].Value;
            //bool Onulipi = (bool)prapokDataGridView.Rows[row_index].Cells[onulipiColumn].Value;
            //  if(e.ColumnIndex==prapokDataGridView.Columns["mul_prapok"].Index)
            if (e.ColumnIndex == mulPrapokColumn)
            {
                SaveOwnMulPrapok(row_index);
            }
            else if (e.ColumnIndex == onulipiColumn)
            {
                SaveOwnOnulipiPrapok(row_index);
            }

            prapokOwnDataGridView.Refresh();
            prapokOthersDataGridView.Refresh();
        }
         public event EventHandler SucessfullyDakForwarded;
         public event EventHandler DecreaseDaakCount;

        public MultipleDakSelectedListConfirmForm ActionResult;

        private void sendButton_Click(object sender, EventArgs e)
        {
           if(!ValidateUserInput())
            {
                return;
            }

            if (_isMultipleDak)
            {
                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "অপনি কি সিলেক্টেড ডাকসমূহ প্রেরণ করতে চান?";
                conditonBoxForm.ShowDialog();
                if (conditonBoxForm.Yes)
                {
                    if (_fromDakBacai == true)
                    {
                        AddDakSorting(sender, e);
                        return;
                    }
                    DakForwardRequestParam dakForwardRequestParam = new DakForwardRequestParam();

                    DakPriorityList dakPriority = new DakPriorityList();
                    int dak_priority_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.Text.ToString()));



                    DakSecurityList dakSecurityList = new DakSecurityList();
                    int dak_security_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.Text.ToString()));


                    dakForwardRequestParam.priority = dak_priority_id;
                    dakForwardRequestParam.security = dak_security_id;
                    dakForwardRequestParam.comment = decisionXTextBox.Text;
                    dakForwardRequestParam.token = _dak_List_User_Param.token;

                    var config = new MapperConfiguration(cfg =>
                              cfg.CreateMap<DakUserParam, DakForwardRequestSenderInfo>()
                          );
                    var mapper = new Mapper(config);
                    var dakSender = mapper.Map<DakForwardRequestSenderInfo>(_dak_List_User_Param);


                    dakForwardRequestParam.sender_info = dakForwardRequestParam.CSharpObjtoJson(dakSender);


                    ViewDesignationSealList mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);

                    if (mulprapok.nij_Office == true)
                    {
                        var receiver_info = designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                        dakForwardRequestParam.receiver_info = dakForwardRequestParam.CSharpObjtoJson(receiver_info);
                    }
                    else
                    {
                        var receiver_info = designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                        dakForwardRequestParam.receiver_info = dakForwardRequestParam.CSharpObjtoJson(receiver_info);
                    }

                    List<PrapokDTO> OnulipiprapokDTOs = new List<PrapokDTO>();

                    List<ViewDesignationSealList> viewDesignationSealListsOnulipPrapok = viewDesignationSealLists.Where(a => a.onulipi_prapok == true).ToList();
                    foreach (ViewDesignationSealList viewDesignationSeal in viewDesignationSealListsOnulipPrapok)
                    {
                        if (viewDesignationSeal.nij_Office == true)
                        {
                            OnulipiprapokDTOs.Add(designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                        }
                        else
                        {
                            OnulipiprapokDTOs.Add(designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                        }
                    }

                    dakForwardRequestParam.onulipi_info = dakForwardRequestParam.CSharpObjtoJson(OnulipiprapokDTOs);

                    var daklist = selectedDakListFlowLayoutPanel.Controls.OfType<SelectedDakListUserControl>().Where(a=>a.Visible==true).ToList();
                   
                    if (daklist.Count > 0)
                    {
                        List<SelectedDakListUserControl> dakListSelected = daklist.Where(a => a._isSelected == true).ToList();
                        List<SelectedDakListUserControl> notSelecteddak = daklist.Where(a => a._isSelected == false).ToList();
                        if (dakListSelected.Count > 0)
                        {
                            foreach (SelectedDakListUserControl dakSelected in dakListSelected)
                            {
                                _totalForwardRequest += 1;

                                dakForwardRequestParam.dak_id = dakSelected.dakUserDTO.dak_id;
                                dakForwardRequestParam.is_copied_dak = dakSelected.dakUserDTO.is_copied_dak;
                                dakForwardRequestParam.dak_type = dakSelected.dakUserDTO.dak_type;


                                var dakForwardResponse = _dakForwardService.GetDakForwardResponse(dakForwardRequestParam);

                                if (dakForwardResponse!= null && dakForwardResponse.status == "success")
                                {

                                    _totalSuccessForwardRequest += 1;

                                    dakSelected.Hide();


                                }
                                else if(dakForwardResponse != null && dakForwardResponse.status == "error")
                                {

                                    if(notSelecteddak.Count>0)
                                    {
                                        UIDesignCommonMethod.ErrorMessage(dakForwardResponse.data);
                                    }
                                    _totalFailForwardRequest += 1;

                                    MultipleDakActionResultDakRowUserControl multipleDakActionResultDakRowUserControl = new MultipleDakActionResultDakRowUserControl();


                                    multipleDakActionResultDakRowUserControl.dakUserDTO = dakSelected.dakUserDTO;
                                    multipleDakActionResultDakRowUserControl.error = dakForwardResponse.data;
                                    multipleDakActionResultDakRowUserControl.prerok = dakSelected._prerok;
                                    ActionResult.multiplaeDakActionResultAdd.Controls.Add(multipleDakActionResultDakRowUserControl);

                                }
                                else
                                {
                                    if (notSelecteddak.Count > 0)
                                    {
                                        UIDesignCommonMethod.ErrorMessage("Server Error!");
                                    }
                                  
                                    _totalFailForwardRequest += 1;

                                    MultipleDakActionResultDakRowUserControl multipleDakActionResultDakRowUserControl = new MultipleDakActionResultDakRowUserControl();


                                    multipleDakActionResultDakRowUserControl.dakUserDTO = dakSelected.dakUserDTO;
                                    multipleDakActionResultDakRowUserControl.error = "Server Error!";
                                    multipleDakActionResultDakRowUserControl.prerok = dakSelected._prerok;
                                    ActionResult.multiplaeDakActionResultAdd.Controls.Add(multipleDakActionResultDakRowUserControl);

                                }
                            }
                        }

                       
                      if(notSelecteddak.Count==0)
                        {

                            ActionResult.isDakForwardReturn = true;
                            ActionResult.totalRequest = _totalForwardRequest;
                            ActionResult.totalRequestFail = _totalFailForwardRequest;
                            ActionResult.totalForwardRequest = _totalSuccessForwardRequest;

                            this.Opacity = .1;

                            Form form = AttachControlToForm(ActionResult);
                            form.ShowDialog();
                            // this.Opacity = 1;

                            if (this.SucessfullyDakForwarded != null)
                                this.SucessfullyDakForwarded(sender, e);
                            this.Hide();

                        }
                       


                    }

                    
                }

            }
            else
            {



                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "অপনি কি ডাকটি প্রেরণ করতে চান?";
                conditonBoxForm.ShowDialog();
                if (conditonBoxForm.Yes)
                {
                    
                    DakForwardRequestParam dakForwardRequestParam = new DakForwardRequestParam();
                    dakForwardRequestParam.dak_id = _dak_id;
                    dakForwardRequestParam.is_copied_dak = _is_copied_dak;
                    dakForwardRequestParam.dak_type = _dak_type.ToString();

                    DakPriorityList dakPriority = new DakPriorityList();
                    int dak_priority_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.Text.ToString()));



                    DakSecurityList dakSecurityList = new DakSecurityList();
                    int dak_security_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.Text.ToString()));


                    dakForwardRequestParam.priority = dak_priority_id;
                    dakForwardRequestParam.security = dak_security_id;
                    dakForwardRequestParam.comment = decisionXTextBox.Text;
                    dakForwardRequestParam.token = _dak_List_User_Param.token;

                    var config = new MapperConfiguration(cfg =>
                              cfg.CreateMap<DakUserParam, DakForwardRequestSenderInfo>()
                          );
                    var mapper = new Mapper(config);
                    var dakSender = mapper.Map<DakForwardRequestSenderInfo>(_dak_List_User_Param);


                    dakForwardRequestParam.sender_info = dakForwardRequestParam.CSharpObjtoJson(dakSender);


                    ViewDesignationSealList mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);

                    if(mulprapok != null)
                    {
                        if (mulprapok.nij_Office == true)
                        {
                            var receiver_info = designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                            dakForwardRequestParam.receiver_info = dakForwardRequestParam.CSharpObjtoJson(receiver_info);
                        }
                        else
                        {
                            var receiver_info = designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);
                            dakForwardRequestParam.receiver_info = dakForwardRequestParam.CSharpObjtoJson(receiver_info);
                        }
                    }

                    List<PrapokDTO> OnulipiprapokDTOs = new List<PrapokDTO>();

                    List<ViewDesignationSealList> viewDesignationSealListsOnulipPrapok = viewDesignationSealLists.Where(a => a.onulipi_prapok == true).ToList();
                    foreach (ViewDesignationSealList viewDesignationSeal in viewDesignationSealListsOnulipPrapok)
                    {
                        if (viewDesignationSeal.nij_Office == true)
                        {
                            OnulipiprapokDTOs.Add(designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                        }
                        else
                        {
                            OnulipiprapokDTOs.Add(designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                        }
                    }

                    dakForwardRequestParam.onulipi_info = dakForwardRequestParam.CSharpObjtoJson(OnulipiprapokDTOs);

                    var dakForwardResponse =_dakForwardService.GetDakForwardResponse(dakForwardRequestParam);


                    if(dakForwardResponse.message == "Local")
                    {
                        UIDesignCommonMethod.SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে এই ডাকটি প্রেরণ করা হবে");
                        _IsDakLocallyUploaded = true;
                        if (this.SucessfullyDakForwarded != null)
                            this.SucessfullyDakForwarded(sender, e);
                        this.Hide();
                    }
                    else if (dakForwardResponse.status == "success")
                    {
                        UIDesignCommonMethod.SuccessMessage(dakForwardResponse.data);
                        _totalSuccessForwardRequest = 1;
                        if (this.SucessfullyDakForwarded != null)
                            this.SucessfullyDakForwarded(sender, e);
                        this.Hide();
                    }

                    else
                    {
                        ErrorMessage(dakForwardResponse.message);
                    }


                }
            }
    

        }
        #region DakSorting
        private void AddDakSorting(object sender, EventArgs e)
        {
             bool isSuccess = false;
            //DakForwardRequestParam dakForwardRequestParam = new DakForwardRequestParam();
            //dakForwardRequestParam.priority = PriorityAndSecurity().Item1;
            //dakForwardRequestParam.security = PriorityAndSecurity().Item2;
            //dakForwardRequestParam.comment = decisionXTextBox.Text;
            //dakForwardRequestParam.token = _dak_List_User_Param.token;
            //dakForwardRequestParam.receiver_info = dakForwardRequestParam.CSharpObjtoJson(GetMul_Prapok()); 
            // dakForwardRequestParam.onulipi_info = dakForwardRequestParam.CSharpObjtoJson(GetOnulipi());
            Recipient recipient = new Recipient
            {
                mul_prapok = GetMul_Prapok(),
                onulipi = GetOnulipi()
            };
            
            var daklist = selectedDakListFlowLayoutPanel.Controls.OfType<SelectedDakListUserControl>().ToList();
          //  var ActionResult = UserControlFactory.Create<MultipleDakSelectedListConfirmForm>();
            if (daklist.Count > 0)
            {
                List<SelectedDakListUserControl> dakListSelected = daklist.Where(a => a._isSelected == true).ToList();
                if (dakListSelected.Count > 0)
                {
                    var priorityAndSecurity = PriorityAndSecurity();

                    foreach (SelectedDakListUserControl dakSelected in dakListSelected)
                    {
                        _totalForwardRequest += 1;

                       
                        DakSorting daksort =
                                new DakSorting
                                {
                                    dak_inbox_designation_id = _inbox_officer_designation_id,
                                    dak_subject = dakSelected.dakUserDTO.dak_subject,
                                    dak_type = dakSelected.dakUserDTO.dak_type,
                                    decision = decisionXTextBox.Text,
                                    id = dakSelected.dakUserDTO.dak_id,
                                    is_copied_dak = Convert.ToByte(dakSelected.dakUserDTO.is_copied_dak),
                                    priority = priorityAndSecurity.Item1,
                                    security = priorityAndSecurity.Item2,
                                    sender = dakSelected.dakorigin.sender_name,
                                    sending_date = dakSelected.dakorigin.sending_date,
                                    recipients = recipient

                                };



                        var dakForwardResponse = _dakSharingService.AddDakSorting(_userService.GetLocalDakUserParam(), daksort);


                        if (dakForwardResponse.status == "success")
                        {
                            
                            _totalSuccessForwardRequest += 1;

                        }

                        else
                        {
                            _totalFailForwardRequest += 1;

                            MultipleDakActionResultDakRowUserControl multipleDakActionResultDakRowUserControl = new MultipleDakActionResultDakRowUserControl();


                            multipleDakActionResultDakRowUserControl.dakUserDTO = dakSelected.dakUserDTO;
                             multipleDakActionResultDakRowUserControl.prerok = dakSelected._prerok;
                        
                        }
                    }
                }
            }

         
            if(_totalSuccessForwardRequest!=0)
            {
                UIDesignCommonMethod.SuccessMessage("ডাক সর্টিং সফল হয়েছে!");

                if (this.DecreaseDaakCount != null)
                    this.DecreaseDaakCount(sender, e);


                if (this.SucessfullyDakForwarded != null)
                    this.SucessfullyDakForwarded(sender, e);
                this.Hide();
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("ডাক সর্টিং সফল হইনি!");
            }
            

        }
        private (int, int) PriorityAndSecurity()
        {
            DakPriorityList dakPriority = new DakPriorityList();
            int dak_priority_id = Convert.ToInt32(dakPriority.GetDakPrioritiesId(prioritySearchButton.searchButtonText));

            DakSecurityList dakSecurityList = new DakSecurityList();
            int dak_security_id = Convert.ToInt32(dakSecurityList.GetDakSecuritiesId(secretLevelSearchButton.searchButtonText));
            return (dak_priority_id, dak_security_id);
        }

        private PrapokDTO GetMul_Prapok()
        {
            PrapokDTO receiver_info = new PrapokDTO();
            ViewDesignationSealList mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);

            if (mulprapok.nij_Office == true)
            {
                receiver_info = designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);

            }
            else
            {
                receiver_info = designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == mulprapok.designation_id);

            }
            return receiver_info;

        }
        private MulPrapok GetMulParapak(PrapokDTO receiver_info)
        {
            MulPrapok mulPrapok = new MulPrapok
            {
                designation_bng = receiver_info.designation_bng,
                designation_eng = receiver_info.designation_eng,
                designation_id = receiver_info.designation_id,
                unit_name_bng = receiver_info.unit_name_bng,
                unit_name_eng = receiver_info.unit_name_eng,
                unit_id = receiver_info.unit_id,
                office_name_bng = receiver_info.office_name_bng,
                office_name_eng = receiver_info.office_name_eng,
                office_id = receiver_info.office_id,
                employee_name_bng = receiver_info.employee_name_bng,
               
                employee_record_id = receiver_info.employee_record_id,
                incharge_label = receiver_info.incharge_label

            };
            return mulPrapok;
        }

        private  Dictionary<string, PrapokDTO> GetOnulipi()
        {
        
            List<PrapokDTO> OnulipiprapokDTOs = new List<PrapokDTO>();

            List<ViewDesignationSealList> viewDesignationSealListsOnulipPrapok = viewDesignationSealLists.Where(a => a.onulipi_prapok == true).ToList();

            if (viewDesignationSealListsOnulipPrapok.Count > 0)
            {
                foreach (ViewDesignationSealList viewDesignationSeal in viewDesignationSealListsOnulipPrapok)
                {
                    if (viewDesignationSeal.nij_Office == true)
                    {
                        OnulipiprapokDTOs.Add(designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                    }
                    else
                    {
                        OnulipiprapokDTOs.Add(designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == viewDesignationSeal.designation_id));
                    }
                }

            }

            return OnulipiprapokDTOs.ToDictionary(a => a.designation_id.ToString());

        }

        private T AutoMapData<T, g>(object obj)
        {
            var config = new MapperConfiguration(cfg =>
                         cfg.CreateMap<g, T>()
                     );
            var mapper = new Mapper(config);

            return mapper.Map<T>(obj);
        }

        #endregion
        private bool ValidateUserInput()
        {
           if(string.IsNullOrEmpty(decisionXTextBox.Text))
            {
                ShowAlertMessage("ডাকটি প্রেরণ করার পূর্বে সিদ্ধান্ত বাছাই করুন");
             
                return false;
                
            }

           var mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);

           if (mulprapok == null)
            {
                ShowAlertMessage("দয়া করে মূল প্রাপক বাছাই করুন");
                return false;
            }

            return true;
        }

        private void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {
            UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
            alertMessageBox.message = mulpotroNotSelectErrorMessage;

            alertMessageBox.ShowDialog();
        }
        public Form AttachControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Height = 100;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }


        protected string GetDesignationSealListEndpoint()
        {
            return DefaultAPIConfiguration.GetDesignationSealListEndpoint;
        }
        protected string GetDakForwardEndpoint()
        {
            return DefaultAPIConfiguration.GetDakForwardEndpoint;
        }

        public DakForwardResponse GetDakForwardResponse(DakForwardRequestParam dakForwardParam)
        {
            try
            {

                var DakForwardApi = new RestClient(GetAPIDomain() + GetDakForwardEndpoint());
                DakForwardApi.Timeout = -1;
                var dakForwardRequest = new RestRequest(Method.POST);
                dakForwardRequest.AddHeader("api-version", GetAPIVersion());
                dakForwardRequest.AddHeader("Authorization", "Bearer " + dakForwardParam.token);
                dakForwardRequest.AlwaysMultipartFormData = true;
                dakForwardRequest.AddParameter("sender_info", dakForwardParam.sender_info);
                dakForwardRequest.AddParameter("receiver_info", dakForwardParam.receiver_info);
                dakForwardRequest.AddParameter("onulipi_info", dakForwardParam.onulipi_info);
                dakForwardRequest.AddParameter("dak_type", dakForwardParam.dak_type);
                dakForwardRequest.AddParameter("dak_id", dakForwardParam.dak_id);
                dakForwardRequest.AddParameter("priority", dakForwardParam.priority);
                dakForwardRequest.AddParameter("comment", dakForwardParam.comment);
                dakForwardRequest.AddParameter("security", dakForwardParam.security);
                dakForwardRequest.AddParameter("is_copied_dak", dakForwardParam.is_copied_dak);

                IRestResponse dakForwardResponseAPI = DakForwardApi.Execute(dakForwardRequest);


                var dakForwardResponseJson = dakForwardResponseAPI.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakForwardResponse dakForwardResponse = JsonConvert.DeserializeObject<DakForwardResponse>(dakForwardResponseJson);
                return dakForwardResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void prapokOthersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;
            if (e.ColumnIndex == mulPrapokColumn)
            {
                SaveOtherMulPrapok(row_index);
            }
            else if (e.ColumnIndex == onulipiColumn)
            {
                SaveOtherOnulipiPrapok(row_index);
            }

            prapokOwnDataGridView.Refresh();
            prapokOthersDataGridView.Refresh();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        private void prapokOwnDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;

            if (prapokOwnDataGridView.Columns[prapokOwnDataGridView.CurrentCell.ColumnIndex].Name == "ActionButton")
            {
                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                conditonBoxForm.message = "অপনি কি প্রাপকটিকে মুছে ফেলতে চান?";
                conditonBoxForm.ShowDialog();
                if (conditonBoxForm.Yes)
                {
                    
                    int designation_id = Convert.ToInt32(prapokOwnDataGridView.Rows[row_index].Cells["designationid_id"].Value);
                    var form = FormFactory.Create<Dashboard>();
                    string designationSealIdJson = designation_id.ToString();
                    DeleteDesignationSealResponse deleteDesignationSealResponse = form.DeleteDesignation(designationSealIdJson);

                    if (deleteDesignationSealResponse.status == "success")
                    {
                        UIDesignCommonMethod.SuccessMessage("প্রাপকটিকে সফলভাবে মুছে ফেলা হ​য়েছে।");

                        prapokOwnDataGridView.Rows.RemoveAt(row_index);



                        viewDesignationSealLists = viewDesignationSealLists.Where(a => a.designation_id != designation_id).ToList();

                    }
                    else
                    {
                        ErrorMessage("মুছে ফেলা সফল হ​য়নি।।");
                    }

                }
                else
                {

                }
            }



            //bool mulprapok = (bool)prapokDataGridView.Rows[row_index].Cells[mulPrapokColumn].Value;
            //bool Onulipi = (bool)prapokDataGridView.Rows[row_index].Cells[onulipiColumn].Value;
            //  if(e.ColumnIndex==prapokDataGridView.Columns["mul_prapok"].Index)
            if (e.ColumnIndex == mulPrapokColumn)
            {
                SaveOwnMulPrapok(row_index);
            }
            else if (e.ColumnIndex == onulipiColumn)
            {
                SaveOwnOnulipiPrapok(row_index);
            }

            prapokOwnDataGridView.Refresh();
            prapokOthersDataGridView.Refresh();
        }

        private void BorderColorBlue(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);

        }

        private void officerSearchOwnXTextBox_TextChanged(object sender, EventArgs e)
        {
            var prapokList = prapokOwnDataGridView.DataSource;

            IEnumerable<ViewDesignationSealList> designationSealListsinGridView = (IEnumerable<ViewDesignationSealList>)prapokList;
            List<ViewDesignationSealList> NewViewDesignationSealLists = new List<ViewDesignationSealList>();


            if (officerSearchOwnXTextBox.Text == "")
            {
                PopulateOwnOfficeGrid();
            }
            else
            {
                foreach (var des in designationSealListsinGridView.Where(a=>a.nij_Office==true))
                {
                    if (des.designation.Contains(officerSearchOwnXTextBox.Text) || des.employee_name_bng.Contains(officerSearchOwnXTextBox.Text))
                    {
                        NewViewDesignationSealLists.Add(des);
                    }

                }
                BindingList<ViewDesignationSealList> bindinglist = new BindingList<ViewDesignationSealList>();
                foreach (ViewDesignationSealList viewDesignationSealList in NewViewDesignationSealLists)
                {
                    bindinglist.Add(viewDesignationSealList);
                }
                prapokOwnDataGridView.DataSource = null;
                prapokOwnDataGridView.DataSource = bindinglist;
            }

        }


        public event EventHandler AddDesignationButtonClick;
        private void addDesignationButton_Click_Click(object sender, EventArgs e)
        {
            if (this.AddDesignationButtonClick != null)
                this.AddDesignationButtonClick(sender, e);
        }

        private void newDecisionAddButton_Click(object sender, EventArgs e)
        {
            newDecisionAddFormPanel.Visible = true;
            newDecisionAddButton.Visible = false;
        }

        private void newDecisionAddCrossButton_Click(object sender, EventArgs e)
        {
            newDecisionAddFormPanel.Visible = false;
            newDecisionAddButton.Visible = true;
            newDecisionTextBox.Text = "";
        }

        private void GetDecisionListButton_Click(object sender, EventArgs e)
        {
            if(newDecisionAddPanel.Visible)
            {
                newDecisionAddPanel.Visible = false;

               
              
            }
            else
            {
                newDecisionAddPanel.Visible = true;
            }
        }

        
        

        private void dakDecisionTableUserControl_RadioButtonClick(object sender, EventArgs e, int id)
        {
            var decisionTable = decisionListFlowLayoutPanel.Controls.OfType<DakDecisionTableUserControl>().ToList();

            foreach (var dakDecisionTableUser in decisionTable)
            {
                if(dakDecisionTableUser._id!=id)
                {
                    dakDecisionTableUser.isDecisionSelected = false;
                }
            }
        }

        private void decisionAddAllButton_Click(object sender, EventArgs e)
        {

            newDecisionAddPanel.Visible = false;
            string addJson = "", deleteJson = "";
            
              
            var decisionTable = decisionListFlowLayoutPanel.Controls.OfType<DakDecisionTableUserControl>().ToList();

                foreach (var dakDecisionTableUser in decisionTable)
                {
                    if (dakDecisionTableUser._isDecisionSelected ==true)
                    {
                        decisionXTextBox.Text = dakDecisionTableUser._decisision;
                      
                    }
                    if(dakDecisionTableUser._isCurrentlyAdded==true && dakDecisionTableUser._isAdded == false)
                    {
                       if(addJson!="")
                       {
                        addJson += ",";
                       }
                       addJson += dakDecisionTableUser._id;
                    }
                   else if(dakDecisionTableUser._isCurrentlyAdded == false && dakDecisionTableUser._isAdded == true)
                       {
                    if (deleteJson != "")
                    {
                        deleteJson += ",";
                    }
                    deleteJson += dakDecisionTableUser._id;

                }
                }


             if(decisionAddCheckBox.Checked)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                DakDecisionSetupResponse dakDecisionSetupResponse = _dakForwardService.GetDakDecisionSetupResponse(dakUserParam, addJson, deleteJson);
                if(dakDecisionSetupResponse.status=="success")
                {
                    UIDesignCommonMethod.SuccessMessage("সফলভাবে সংরক্ষণ হ​য়েছে।");
                    LoadDecisionList();
                }
            }

            LoadDecisionList();

        }
        
        private void newDecisionAddRightButton_Click(object sender, EventArgs e)
        {
            DakDecisionDTO dakDecision = new DakDecisionDTO();
            dakDecision.dak_decision = newDecisionTextBox.Text;

            if (newDecisionCheckBox.Checked)
            {
                dakDecision.dak_decision_employee = 1;
            }
            else
            {
                dakDecision.dak_decision_employee = 0;
            }

            dakDecision.id = 0;

            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            DakDecisionAddResponse dakDecisionAddResponse = _dakForwardService.GetDakDecisionAddResponse(dakUserParam, dakDecision);
            if (dakDecisionAddResponse != null && dakDecisionAddResponse.status == "success")
            {
                UIDesignCommonMethod.SuccessMessage("সফলভাবে সংরক্ষণ হ​য়েছে।");
                newDecisionTextBox.Text = "";
                LoadDecisionList();
                //var decisionTable = UserControlFactory.Create<DakDecisionTableUserControl>();
                //decisionTable.id = dakDecisionAddResponse.data.Keys.First();
                //decisionTable.decision = dakDecision.dak_decision;
                //if (dakDecision.dak_decision_employee == 1)
                //{
                //    decisionTable.isAdded = true;
                //    decisionComboBox.Items.Add(dakDecision.dak_decision);
                //}
                //else
                //{
                //    decisionTable.isAdded = false;
                //}

                //decisionListFlowLayoutPanel.Controls.Add(decisionTable);

            }
            else if (dakDecisionAddResponse.status == "error")
            {
                UIDesignCommonMethod.ErrorMessage("সফলভাবে সংরক্ষণ হইনি।");
            }
            else;
            {

            }
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DakForwardUserControl_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = scr.WorkingArea.Height;
            SetDefaultFont(this.Controls);
            ActionResult = UserControlFactory.Create<MultipleDakSelectedListConfirmForm>();
        }

        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void sendButton_MouseHover(object sender, EventArgs e)
        {
            sendButton.BackColor = Color.FromArgb(137, 80, 252);
            sendButton.ForeColor = Color.White;
        }

        private void sendButton_Leave(object sender, EventArgs e)
        {

            sendButton.BackColor = Color.White;
            sendButton.ForeColor = Color.FromArgb(137, 80, 252);
        }
    }
}

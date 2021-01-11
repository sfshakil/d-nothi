using System;
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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakForwardUserControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;

        IDakForwardService _dakForwardService { get; set; }
        IUserService _userService { get; set; }
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        private int _dak_id;
        private string _dak_type;
        private string _dak_subject;
        private int _is_copied_dak;
        private DakUserParam _dak_List_User_Param;


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

                        decisionListFlowLayoutPanel.Controls.Add(decisionTable);
                    }
                }
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

                }
                catch
                {

                }



            }

        }

        public DakForwardUserControl(IDakForwardService dakForwardService, IUserService userService)
        {
            _dakForwardService = dakForwardService;
            _userService = userService;
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
            decisionXTextBox.Text = decisionComboBox.SelectedItem.ToString();
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
            foreach (ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists.Where(a => a.nij_Office == false))
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

        private void sendButton_Click(object sender, EventArgs e)
        {

            DialogResult DialogResultSttring = MessageBox.Show("অপনি কি ডাকটি প্রেরণ করুন চান ?\n",
                               "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResultSttring == DialogResult.Yes)
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

                var dakForwardResponse = GetDakForwardResponse(dakForwardRequestParam);

                if (dakForwardResponse.status == "success")
                {
                    if (this.ButtonClick != null)
                        this.ButtonClick(sender, e);
                }
                else
                {
                    MessageBox.Show(dakForwardResponse.status);
                }
            }

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

        private void prapokOwnDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;

            if (prapokOwnDataGridView.Columns[prapokOwnDataGridView.CurrentCell.ColumnIndex].Name == "ActionButton")
            {

                DialogResult DialogResultSttring = MessageBox.Show("অপনি কি প্রাপকটিকে মুছে ফেলতে চান?\n",
                                   "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResultSttring == DialogResult.Yes)
                {
                    int designation_id = Convert.ToInt32(prapokOwnDataGridView.Rows[row_index].Cells["designationid_id"].Value);
                    var form = FormFactory.Create<Dashboard>();
                    string designationSealIdJson = designation_id.ToString();
                    DeleteDesignationSealResponse deleteDesignationSealResponse = form.DeleteDesignation(designationSealIdJson);

                    if (deleteDesignationSealResponse.status == "success")
                    {
                        MessageBox.Show("প্রাপকটিকে সফলভাবে মুছে ফেলা হ​য়েছে।");

                        prapokOwnDataGridView.Rows.RemoveAt(row_index);



                        viewDesignationSealLists = viewDesignationSealLists.Where(a => a.designation_id != designation_id).ToList();

                    }
                    else
                    {
                        MessageBox.Show("মুছে ফেলা সফল হ​য়নি।।");
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
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void officerSearchOwnXTextBox_TextChanged(object sender, EventArgs e)
        {
            var prapokList = prapokOwnDataGridView.DataSource;

            List<ViewDesignationSealList> designationSealListsinGridView = (List<ViewDesignationSealList>)prapokList;
            List<ViewDesignationSealList> NewViewDesignationSealLists = new List<ViewDesignationSealList>();


            if (officerSearchOwnXTextBox.Text == "")
            {
                PopulateOwnOfficeGrid();
            }
            else
            {
                foreach (var des in designationSealListsinGridView.Where(a=>a.nij_Office==true))
                {
                    if (des.designation.StartsWith(officerSearchOwnXTextBox.Text) || des.employee_name_bng.StartsWith(officerSearchOwnXTextBox.Text))
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
                    MessageBox.Show("সফলভাবে সংরক্ষণ হ​য়েছে।");
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
            if (dakDecisionAddResponse.status == "success")
            {
                MessageBox.Show("সফলভাবে সংরক্ষণ হ​য়েছে।");
                var decisionTable = UserControlFactory.Create<DakDecisionTableUserControl>();
                decisionTable.id = dakDecisionAddResponse.data.id;
                decisionTable.decision = dakDecision.dak_decision;
                if (dakDecision.dak_decision_employee == 1)
                {
                    decisionTable.isAdded = true;
                    decisionComboBox.Items.Add(dakDecision.dak_decision);
                }
                else
                {
                    decisionTable.isAdded = false;
                }

                decisionListFlowLayoutPanel.Controls.Add(decisionTable);

            }
        }
    }
}

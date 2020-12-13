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
    public partial class DakSendUserControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;


        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        private int _dak_id;
        private string _dak_type;
        private int _is_copied_dak;
        private DakListUserParam _dak_List_User_Param;


        public DakListUserParam dak_List_User_Param {
            get { return _dak_List_User_Param; }

            set { _dak_List_User_Param = value; }
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


        private DesignationSealListResponse _designationSealListResponse;


        public DesignationSealListResponse designationSealListResponse {
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
                        viewDesignationSealLists.Add(viewdesignationListOwnOffice);
                    }

                    foreach (PrapokDTO otherOfficeDTO in value.data.other_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOtherOffice = mapper.Map<ViewDesignationSealList>(otherOfficeDTO);

                        viewDesignationSealLists.Add(viewdesignationListOtherOffice);
                    }

                    PopulateOwnOfficeGrid();
                }
                catch
                {

                }


              
            }
        
        }

        public DakSendUserControl()
        {
            InitializeComponent();
            PriorityListCollection.Clear();

            foreach(string str in dakPriorityListBox.Items)
            {
                PriorityListCollection.Add(str);
            }

            SecurityListCollection.Clear();
            foreach (string str in securityLevelListBox.Items)
            {
                SecurityListCollection.Add(str);
            }

        }

        private void prioritySearchXTextBox_TextChanged(object sender, EventArgs e)
        {
            dakPriorityListBox.Items.Clear();
            if(prioritySearchXTextBox.Text=="")
            {
                foreach(string str in PriorityListCollection)
                {
                    dakPriorityListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in PriorityListCollection)
                {
                    if(str.StartsWith(prioritySearchXTextBox.Text))
                    {
                        dakPriorityListBox.Items.Add(str);
                    }
                   
                }
             
            }
        }

        private void prioritySearchButton_Click(object sender, EventArgs e)
        {
            if(prioritySearchPanel.Visible)
            {
                prioritySearchPanel.Visible = false;
            }
            else
            {
                prioritySearchPanel.Visible = true;
            }
        }

        private void dakPriorityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            prioritySearchPanel.Visible = false;
            prioritySearchButton.Text = dakPriorityListBox.GetItemText(dakPriorityListBox.SelectedItem);
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

        private void secretLevelSearchButton_Click(object sender, EventArgs e)
        {
            if (dakSecurityLevelPanel.Visible)
            {
                dakSecurityLevelPanel.Visible = false;
            }
            else
            {
                dakSecurityLevelPanel.Visible = true;
            }
        }

        private void securityLevelXTextBox_TextChanged(object sender, EventArgs e)
        {
            securityLevelListBox.Items.Clear();
            if (securityLevelXTextBox.Text == "")
            {
                foreach (string str in SecurityListCollection)
                {
                    securityLevelListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in SecurityListCollection)
                {
                    if (str.StartsWith(securityLevelXTextBox.Text))
                    {
                        securityLevelListBox.Items.Add(str);
                    }

                }

            }
        }

        private void securityLevelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dakSecurityLevelPanel.Visible = false;
            secretLevelSearchButton.Text = securityLevelListBox.GetItemText(securityLevelListBox.SelectedItem);
        }

        private void decisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = decisionComboBox.SelectedItem.ToString();
        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        int designationColumn = 2;
        private void SaveOnulipiPrapok(int row_index)
        {
           
            for (int i = 0; i <= prapokDataGridView.Rows.Count-1; i++)
            {
                if (i == row_index)
                {
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;
                    

                
                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    SetThisMulprapokfalse(designation_id);
                }
            }
        }

        private void SetThisMulprapokfalse(int designation_id)
        {
          viewDesignationSealLists.FirstOrDefault(a => a.designation_id == designation_id).mul_prapok=false;

            
        }

        private void SaveMulPrapok(int row_index)
        {
            for (int i = 0; i <= prapokDataGridView.Rows.Count-1; i++)
            {
                prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;
             
                if (i != row_index)
                {
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;
          


                }
                else
                {
                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;

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

        private void ownOfficeButton_Click(object sender, EventArgs e)
        {
            PopulateOwnOfficeGrid();


        }
        public void PopulateOwnOfficeGrid()
        {
            prapokDataGridView.DataSource = null;
            prapokDataGridView.DataSource = viewDesignationSealLists.Where(a => a.nij_Office == true).ToList();
        }
        private void otherOfficeButton_Click(object sender, EventArgs e)
        {
            prapokDataGridView.DataSource = null;
            prapokDataGridView.DataSource = viewDesignationSealLists.Where(a => a.nij_Office == false).ToList();
        }

        private void prapokDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;
            //bool mulprapok = (bool)prapokDataGridView.Rows[row_index].Cells[mulPrapokColumn].Value;
            //bool Onulipi = (bool)prapokDataGridView.Rows[row_index].Cells[onulipiColumn].Value;
            //  if(e.ColumnIndex==prapokDataGridView.Columns["mul_prapok"].Index)
            if (e.ColumnIndex == mulPrapokColumn)
            {
                SaveMulPrapok(row_index);
            }
            else if (e.ColumnIndex == onulipiColumn)
            {
                SaveOnulipiPrapok(row_index);
            }

            prapokDataGridView.Refresh();
        }

        private void sendButton_Click(object sender, EventArgs e)
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
                      cfg.CreateMap<DakListUserParam,DakForwardRequestSenderInfo>()
                  );
            var mapper = new Mapper(config);
            var dakSender = mapper.Map<DakForwardRequestSenderInfo>(_dak_List_User_Param);


            dakForwardRequestParam.sender_info = dakForwardRequestParam.CSharpObjtoJson(dakSender);


            ViewDesignationSealList mulprapok = viewDesignationSealLists.FirstOrDefault(a => a.mul_prapok == true);

            if(mulprapok.nij_Office==true)
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
            foreach(ViewDesignationSealList viewDesignationSeal in viewDesignationSealListsOnulipPrapok)
            {
                if(viewDesignationSeal.nij_Office==true)
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
               
            if(dakForwardResponse.status=="success")
            {
                if (this.ButtonClick != null)
                    this.ButtonClick(sender, e);
            }
            else
            {
                MessageBox.Show(dakForwardResponse.status);
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
    }
}

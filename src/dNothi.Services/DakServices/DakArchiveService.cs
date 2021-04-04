using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakArchiveService : IDakArchiveService
    {
        IRepository<DakItem> _dakItem;
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakArchiveService(IRepository<DakItem> dakItem,IRepository<DakType> daktype, IDakListService dakListService)
        {
            _daktype = daktype;
            _dakItem = dakItem;
            _dakListService = dakListService;
        }
        private void SaveOrUpdateDakOutBoxListJsonResponse(DakUserParam dakListUserParam, string responseJson)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Archived == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_Archived = true;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }
        public DakListArchiveResponse GetDakList(DakUserParam dakListUserParam)
        {
            DakListArchiveResponse dakListArchiveResponse = new DakListArchiveResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Archived == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListArchiveResponse = JsonConvert.DeserializeObject<DakListArchiveResponse>(dakList.jsonResponse);

                }
                return dakListArchiveResponse;
            }

            try
            {
                var dakArchiveApi = new RestClient(GetAPIDomain()+GetDakListArchiveEndpoint());
                dakArchiveApi.Timeout = -1;
                var dakArchiveRequest = new RestRequest(Method.POST);
                dakArchiveRequest.AddHeader("api-version", GetAPIVersion());
                dakArchiveRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakArchiveRequest.AlwaysMultipartFormData = true;
                dakArchiveRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakArchiveRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakArchiveRequest.AddParameter("page", dakListUserParam.page);
                dakArchiveRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakArchiveResponse = dakArchiveApi.Execute(dakArchiveRequest);


                var dakArchiveResponseJson = dakArchiveResponse.Content;
                SaveOrUpdateDakOutBoxListJsonResponse(dakListUserParam, dakArchiveResponseJson);
                dakListArchiveResponse = JsonConvert.DeserializeObject<DakListArchiveResponse>(dakArchiveResponseJson);
                return dakListArchiveResponse;
            }
            catch (Exception ex)
            {
                return dakListArchiveResponse;
            }
        }

        public void SaveorUpdateDakArchive(DakListArchiveResponse dakListArchiveResponse)
        {
            DakType dakType = new DakType();
            dakType.is_archived = true;
            if (dakListArchiveResponse.data != null)
            {
                dakType.total_records = dakListArchiveResponse.data.total_records;

            }

            var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_archived == true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }

            _dakListService.SaveOrUpdateDakList(dakListArchiveResponse.data, dakType.Id);
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetDakListArchiveEndpoint()
        {
            return DefaultAPIConfiguration.DakListOnulipiEndPoint;
        }
        protected string GetDakArchiveEndpoint()
        {
            return DefaultAPIConfiguration.DakArchiveEndPoint;
        }
        protected string GetDakArchiveRevertEndpoint()
        {
            return DefaultAPIConfiguration.DakArchiveRevertEndPoint;
        }

        public DakArchiveResponse GetDakArcivedResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            try
            {
                var dakArchiveApi = new RestClient(GetAPIDomain() + GetDakArchiveEndpoint());
                dakArchiveApi.Timeout = -1;
                var dakArchiveRequest = new RestRequest(Method.POST);
                dakArchiveRequest.AddHeader("api-version", GetOldAPIVersion());
                dakArchiveRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakArchiveRequest.AlwaysMultipartFormData = true;
                dakArchiveRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakArchiveRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakArchiveRequest.AddParameter("dak_id", dak_id);
                dakArchiveRequest.AddParameter("dak_type", dak_type);
                dakArchiveRequest.AddParameter("is_copied_dak", is_copied_dak);
                IRestResponse dakArchiveResponseIRest = dakArchiveApi.Execute(dakArchiveRequest);


                var dakArchiveResponseJson = dakArchiveResponseIRest.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakArchiveResponse dakArchiveResponse = JsonConvert.DeserializeObject<DakArchiveResponse>(dakArchiveResponseJson);
                return dakArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakArchiveRevertResponse GetDakArcivedRevertResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            try
            {
                var dakArchiveRevertApi = new RestClient(GetAPIDomain() + GetDakArchiveRevertEndpoint());
                dakArchiveRevertApi.Timeout = -1;
                var dakArchiveRequest = new RestRequest(Method.POST);
                dakArchiveRequest.AddHeader("api-version", GetOldAPIVersion());
                dakArchiveRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakArchiveRequest.AlwaysMultipartFormData = true;
                dakArchiveRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakArchiveRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakArchiveRequest.AddParameter("dak_id", dak_id);
                dakArchiveRequest.AddParameter("dak_type", dak_type);
                dakArchiveRequest.AddParameter("is_copied_dak", is_copied_dak);
                IRestResponse dakArchiveResponseIRest = dakArchiveRevertApi.Execute(dakArchiveRequest);


                var dakArchiveResponseJson = dakArchiveResponseIRest.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakArchiveRevertResponse dakArchiveResponse = JsonConvert.DeserializeObject<DakArchiveRevertResponse>(dakArchiveResponseJson);
                return dakArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakListArchiveResponse GetDakList(DakUserParam dakListUserParam, string searchParam)
        {
            try
            {
                var dakArchiveApi = new RestClient(GetAPIDomain() + GetDakListArchiveEndpoint());
                dakArchiveApi.Timeout = -1;
                var dakArchiveRequest = new RestRequest(Method.POST);
                dakArchiveRequest.AddHeader("api-version", GetAPIVersion());
                dakArchiveRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakArchiveRequest.AlwaysMultipartFormData = true;
                dakArchiveRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakArchiveRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakArchiveRequest.AddParameter("page", dakListUserParam.page);
                dakArchiveRequest.AddParameter("limit", dakListUserParam.limit);
                dakArchiveRequest.AddParameter("search_params", searchParam);
                IRestResponse dakArchiveResponse = dakArchiveApi.Execute(dakArchiveRequest);


                var dakArchiveResponseJson = dakArchiveResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListArchiveResponse dakListArchiveResponse = JsonConvert.DeserializeObject<DakListArchiveResponse>(dakArchiveResponseJson);
                return dakListArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

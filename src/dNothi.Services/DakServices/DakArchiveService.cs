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
using dNothi.Services.UserServices;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakArchiveService : IDakArchiveService
    {
        IRepository<DakItem> _dakItem;
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }


        IRepository<DakItemAction> _dakItemAction;
        IUserService _userService { get; set; }

        public DakArchiveService(IUserService userService, IRepository<DakItemAction> dakItemAction, IRepository<DakItem> dakItem, IRepository<DakType> daktype, IDakListService dakListService)
        {
            _dakItemAction = dakItemAction;
            _userService = userService;

            _daktype = daktype;
            _dakItem = dakItem;
            _dakListService = dakListService;
        }
        private void SaveOrUpdateDakArchiveListJsonResponse(DakUserParam dakListUserParam, string responseJson, string searchParam)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Archived_Search == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.searchParameter == searchParam);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_Archived_Search = true;
                dakItem.searchParameter = searchParam;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
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


        public bool Is_Locally_Archived(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isArchived == true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Is_Locally_ArchiveReverted(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isArchiveReverted == true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool DakArchivedFromLocal()
        {
            bool isSuccess = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isArchived == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {

                    //NothijatoActionParam noteNothiDTO = JsonConvert.DeserializeObject<NothijatoActionParam>(dakItemAction.dak_Action_Json);


                    var dakArchiveResponse = GetDakArcivedResponse(dakUserParam, dakItemAction.dak_id, dakItemAction.dak_type, dakItemAction.is_copied_dak);

                    if (dakArchiveResponse != null && (dakArchiveResponse.status == "error" || dakArchiveResponse.status == "success"))

                    {
                        _dakItemAction.Delete(dakItemAction);
                        isSuccess = true;

                    }
                }
            }


            return isSuccess;
        }

        public bool DakArchiveRevertFromLocal()
        {
            bool isSuccess = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isArchiveReverted == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {
                    if (dakUserParam.designation_id == dakItemAction.designation_id)
                    {
                        var dakArchiveResponse = GetDakArcivedRevertResponse(dakUserParam, dakItemAction.dak_id, dakItemAction.dak_type, dakItemAction.is_copied_dak);

                        if (dakArchiveResponse != null && (dakArchiveResponse.status == "error" || dakArchiveResponse.status == "success"))

                        {
                            _dakItemAction.Delete(dakItemAction);
                            isSuccess = true;

                        }
                    }
                    else
                    {
                        _dakItemAction.Delete(dakItemAction);
                        isSuccess = true;
                    }



                }
            }


            return isSuccess;
        }

        public DakArchiveResponse GetDakArcivedResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            DakArchiveResponse dakArchiveResponse = new DakArchiveResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                dakArchiveResponse.status = "success";
                dakArchiveResponse.message = "Local";

                DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_type && a.is_copied_dak == is_copied_dak);

                if (dakItemAction == null)
                {
                    dakItemAction = new DakItemAction();
                    dakItemAction.isArchived = true;
                    dakItemAction.is_copied_dak = is_copied_dak;
                    dakItemAction.dak_id = dak_id;
                    dakItemAction.dak_type = dak_type;
                    // dakItemAction.dak_Action_Json = JsonParsingMethod.ObjecttoJson(nothi);

                    _dakItemAction.Insert(dakItemAction);
                }





                return dakArchiveResponse;
            }


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
                dakArchiveResponse = JsonConvert.DeserializeObject<DakArchiveResponse>(dakArchiveResponseJson);
                return dakArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakArchiveRevertResponse GetDakArcivedRevertResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            DakArchiveRevertResponse dakArchiveResponse = new DakArchiveRevertResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                dakArchiveResponse.status = "success";
                dakArchiveResponse.message = "Local";

                DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_type && a.is_copied_dak == is_copied_dak);

                if (dakItemAction == null)
                {
                    dakItemAction = new DakItemAction();
                    dakItemAction.isArchiveReverted = true;
                    dakItemAction.is_copied_dak = is_copied_dak;
                    dakItemAction.dak_id = dak_id;
                    dakItemAction.dak_type = dak_type;
                    dakItemAction.designation_id = dakListUserParam.designation_id;
                    // dakItemAction.dak_Action_Json = JsonParsingMethod.ObjecttoJson(nothi);

                    _dakItemAction.Insert(dakItemAction);
                }





                return dakArchiveResponse;
            }

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
                dakArchiveResponse = JsonConvert.DeserializeObject<DakArchiveRevertResponse>(dakArchiveResponseJson);
                return dakArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakListArchiveResponse GetDakList(DakUserParam dakListUserParam, string searchParam)
        {
            DakListArchiveResponse dakListArchiveResponse = new DakListArchiveResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Archived_Search == true && a.searchParameter==searchParam && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListArchiveResponse = JsonConvert.DeserializeObject<DakListArchiveResponse>(dakList.jsonResponse);

                }
                return dakListArchiveResponse;
            }
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
                SaveOrUpdateDakArchiveListJsonResponse(dakListUserParam, dakArchiveResponseJson, searchParam);
                dakListArchiveResponse = JsonConvert.DeserializeObject<DakListArchiveResponse>(dakArchiveResponseJson);
                return dakListArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

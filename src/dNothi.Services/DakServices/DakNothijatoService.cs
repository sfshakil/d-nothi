using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.UserServices;

using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakNothijatoService : IDakNothijatoService
    {
        IRepository<DakItem> _dakItem;
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }

        IRepository<DakItemAction> _dakItemAction;
        IUserService _userService { get; set; }
        public DakNothijatoService(IUserService userService, IRepository<DakItemAction> dakItemAction, IRepository<DakItem> dakItem, IRepository<DakType> daktype, IDakListService dakListService)
        {
            _dakItemAction = dakItemAction;
            _userService = userService;


            _daktype = daktype;
            _dakItem = dakItem;
            _dakListService = dakListService;
        }

        private void SaveOrUpdateDakNothijatoListJsonResponse(DakUserParam dakListUserParam, string responseJson, string searchParam)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothijato_Search == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.searchParameter == searchParam);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_Nothijato_Search = true;
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
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothijato == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_Nothijato = true;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }
        public DakListNothijatoResponse GetNothijatoDak(DakUserParam dakListUserParam)
        {

            DakListNothijatoResponse dakListNothijatoResponse = new DakListNothijatoResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothijato == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListNothijatoResponse = JsonConvert.DeserializeObject<DakListNothijatoResponse>(dakList.jsonResponse);

                }
                return dakListNothijatoResponse;
            }

            try
            {
                var nothijatoDakApi = new RestClient(GetAPIDomain() + GetDakListNothijatoEndpoint());
                nothijatoDakApi.Timeout = -1;
                var nothijatoDakRequest = new RestRequest(Method.POST);
                nothijatoDakRequest.AddHeader("api-version", GetAPIVersion());
                nothijatoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothijatoDakRequest.AlwaysMultipartFormData = true;
                nothijatoDakRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                nothijatoDakRequest.AddParameter("office_id", dakListUserParam.office_id);
                nothijatoDakRequest.AddParameter("page", dakListUserParam.page);
                nothijatoDakRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse nothijatoDakResponse = nothijatoDakApi.Execute(nothijatoDakRequest);


                var nothijatoDakResponseJson = nothijatoDakResponse.Content;
                SaveOrUpdateDakOutBoxListJsonResponse(dakListUserParam, nothijatoDakResponseJson);
                dakListNothijatoResponse = JsonConvert.DeserializeObject<DakListNothijatoResponse>(nothijatoDakResponseJson);
                return dakListNothijatoResponse;
            }
            catch (Exception ex)
            {
                return dakListNothijatoResponse;
            }
        }

        public void SaveorUpdateDakNothijato(DakListNothijatoResponse dakListNothijatoResponse)
        {
            DakType dakType = new DakType();
            dakType.is_nothijato = true;
            if (dakListNothijatoResponse.data != null)
            {
                dakType.total_records = dakListNothijatoResponse.data.total_records;

            }

            var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_nothijato == true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }

            _dakListService.SaveOrUpdateDakList(dakListNothijatoResponse.data, dakType.Id);
        }

        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetDakListNothijatoEndpoint()
        {
            return DefaultAPIConfiguration.DakListNothijatoEndPoint;
        }

        protected string GetDakNothijatoEndpoint()
        {
            return DefaultAPIConfiguration.DakNothijatoEndpoint;
        }
        protected string GetDakNothijatoRevertEndpoint()
        {
            return DefaultAPIConfiguration.DakNothijatoRevertEndpoint;
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }

        public bool Is_Locally_Nothijato(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isNothijato == true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Is_Locally_NothijatoReverted(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isNothijatoReverted == true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool DakNothijatoFromLocal()
        {
            bool isSuccess = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isNothijato == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {

                    NothijatoActionParam noteNothiDTO = JsonConvert.DeserializeObject<NothijatoActionParam>(dakItemAction.dak_Action_Json);


                    var dakForwardResponse = GetDakNothijatoResponse(dakUserParam, noteNothiDTO, dakItemAction.dak_id, dakItemAction.dak_type, dakItemAction.is_copied_dak);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))

                    {
                        _dakItemAction.Delete(dakItemAction);
                        isSuccess = true;

                    }
                }
            }


            return isSuccess;
        }
        public bool DakNothijatoRevertFromLocal()
        {
            bool isSuccess = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isNothijatoReverted == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {
                    if (dakUserParam.designation_id == dakItemAction.designation_id)
                    {
                        var revertResponse = GetDakNothijatoRevertResponse(dakUserParam, dakItemAction.dak_id, dakItemAction.dak_type, dakItemAction.is_copied_dak);

                        if (revertResponse != null && (revertResponse.status == "error" || revertResponse.status == "success"))

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
        public DakNothijatoResponse GetDakNothijatoResponse(DakUserParam dakUserParam, NothijatoActionParam nothi, int dak_id, string dak_type, int is_copied_dak)
        {
            DakNothijatoResponse dakNothijatoResponse = new DakNothijatoResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                dakNothijatoResponse.status = "success";
                dakNothijatoResponse.message = "Local";

                DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_type && a.is_copied_dak == is_copied_dak);

                if (dakItemAction == null)
                {
                    dakItemAction = new DakItemAction();
                    dakItemAction.isNothijato = true;
                    dakItemAction.is_copied_dak = is_copied_dak;
                    dakItemAction.dak_id = dak_id;
                    dakItemAction.dak_type = dak_type;
                    dakItemAction.designation_id = dakUserParam.designation_id;
                    dakItemAction.dak_Action_Json = JsonParsingMethod.ObjecttoJson(nothi);

                    _dakItemAction.Insert(dakItemAction);
                }





                return dakNothijatoResponse;
            }


            var nothijatoDakSendAPI = new RestClient(GetAPIDomain() + GetDakNothijatoEndpoint());
            nothijatoDakSendAPI.Timeout = -1;
            var NothijatoDakSendRequest = new RestRequest(Method.POST);
            NothijatoDakSendRequest.AddHeader("api-version", GetOldAPIVersion());
            NothijatoDakSendRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            NothijatoDakSendRequest.AddParameter("cdesk", dakUserParam.json_String);

            NothijatoDakSendRequest.AddParameter("daak", "{\"dak_id\":\"" + dak_id + "\",\"dak_type\":\"" + dak_type + "\",\"is_copied_dak\":" + is_copied_dak + "}");
            var nothijsonString = new JavaScriptSerializer().Serialize(nothi);


            NothijatoDakSendRequest.AddParameter("nothi", nothijsonString);
            IRestResponse dakNothijatoIRestResponse = nothijatoDakSendAPI.Execute(NothijatoDakSendRequest);
            var dakNothijatoResponseJson = dakNothijatoIRestResponse.Content;

            dakNothijatoResponse = JsonConvert.DeserializeObject<DakNothijatoResponse>(dakNothijatoResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakNothijatoResponse;
        }

        public void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public DakNothijatoRevertResponse GetDakNothijatoRevertResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            DakNothijatoRevertResponse dakNothijatoRevertResponse = new DakNothijatoRevertResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                dakNothijatoRevertResponse.status = "success";
                dakNothijatoRevertResponse.message = "Local";

                DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_type && a.is_copied_dak == is_copied_dak);

                if (dakItemAction == null)
                {
                    dakItemAction = new DakItemAction();
                    dakItemAction.isNothijatoReverted = true;
                    dakItemAction.is_copied_dak = is_copied_dak;
                    dakItemAction.dak_id = dak_id;
                    dakItemAction.dak_type = dak_type;
                    dakItemAction.designation_id = dakUserParam.designation_id;
                    // dakItemAction.dak_Action_Json = JsonParsingMethod.ObjecttoJson(nothi);

                    _dakItemAction.Insert(dakItemAction);
                }





                return dakNothijatoRevertResponse;
            }
            var nothijatoRevertDakSendAPI = new RestClient(GetAPIDomain() + GetDakNothijatoRevertEndpoint());
            nothijatoRevertDakSendAPI.Timeout = -1;
            var NothijatoRevertDakSendRequest = new RestRequest(Method.POST);
            NothijatoRevertDakSendRequest.AddHeader("api-version", GetOldAPIVersion());
            NothijatoRevertDakSendRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            NothijatoRevertDakSendRequest.AddParameter("designation_id", dakUserParam.designation_id);
            NothijatoRevertDakSendRequest.AddParameter("office_id", dakUserParam.office_id);

            NothijatoRevertDakSendRequest.AddParameter("dak", "{\"dak_id\":\"" + dak_id + "\",\"dak_type\":\"" + dak_type + "\",\"is_copied_dak\":" + is_copied_dak + "}");

            IRestResponse dakNothijatoRevertIRestResponse = nothijatoRevertDakSendAPI.Execute(NothijatoRevertDakSendRequest);
            var dakNothijatoRevertResponseJson = dNothi.Utility.ConversionMethod.FilterJsonResponse(dakNothijatoRevertIRestResponse.Content);

            dakNothijatoRevertResponse = JsonConvert.DeserializeObject<DakNothijatoRevertResponse>(dakNothijatoRevertResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakNothijatoRevertResponse;
        }

        public DakListNothijatoResponse GetNothijatoDak(DakUserParam dakListUserParam, string searchParam)
        {
            DakListNothijatoResponse dakListNothijatoResponse = new DakListNothijatoResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothijato_Search == true && a.searchParameter==searchParam && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListNothijatoResponse = JsonConvert.DeserializeObject<DakListNothijatoResponse>(dakList.jsonResponse);

                }
                return dakListNothijatoResponse;
            }

            try
            {
                var nothijatoDakApi = new RestClient(GetAPIDomain() + GetDakListNothijatoEndpoint());
                nothijatoDakApi.Timeout = -1;
                var nothijatoDakRequest = new RestRequest(Method.POST);
                nothijatoDakRequest.AddHeader("api-version", GetAPIVersion());
                nothijatoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothijatoDakRequest.AlwaysMultipartFormData = true;
                nothijatoDakRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                nothijatoDakRequest.AddParameter("office_id", dakListUserParam.office_id);
                nothijatoDakRequest.AddParameter("page", dakListUserParam.page);
                nothijatoDakRequest.AddParameter("limit", dakListUserParam.limit);
                nothijatoDakRequest.AddParameter("search_params", searchParam);
                IRestResponse nothijatoDakResponse = nothijatoDakApi.Execute(nothijatoDakRequest);


                var nothijatoDakResponseJson = nothijatoDakResponse.Content;
                SaveOrUpdateDakNothijatoListJsonResponse(dakListUserParam, nothijatoDakResponseJson, searchParam);
                dakListNothijatoResponse = JsonConvert.DeserializeObject<DakListNothijatoResponse>(nothijatoDakResponseJson);
                return dakListNothijatoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

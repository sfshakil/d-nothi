using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using Newtonsoft.Json;
using RestSharp;


using Newtonsoft.Json.Serialization;
using dNothi.Services.UserServices;
using dNothi.JsonParser;

namespace dNothi.Services.DakServices
{
    public class DakNothivuktoService : IDakNothivuktoService
    {
        IRepository<DakItem> _dakItem;
        IRepository<DakType> _daktype;
        
        IDakListService _dakListService { get; set; }

        IRepository<DakItemAction> _dakItemAction;
        IUserService _userService { get; set; }
        public DakNothivuktoService(IUserService userService, IRepository<DakItemAction> dakItemAction,IRepository<DakItem> dakItem, IRepository<DakType> daktype, IDakListService dakListService)
        {
            _dakItemAction = dakItemAction;
            _userService = userService;

            _daktype = daktype;
            _dakItem = dakItem;
            _dakListService = dakListService;
        }


        public bool Is_Locally_Nothivukto(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isNothivukto==true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DakNothivuktoFromLocal()
        {
            bool isForwarded = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isNothivukto == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {

                    NoteNothiDTO noteNothiDTO = JsonConvert.DeserializeObject<NoteNothiDTO>(dakItemAction.dak_Action_Json);
                    

                    var dakForwardResponse = GetDakNothivuktoResponse(dakUserParam, noteNothiDTO,dakItemAction.dak_id,dakItemAction.dak_type,dakItemAction.is_copied_dak);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))

                    {
                        _dakItemAction.Delete(dakItemAction);
                        isForwarded = true;

                    }
                }
            }


            return isForwarded;
        }



        private void SaveOrUpdateDakOutBoxListJsonResponse(DakUserParam dakListUserParam, string responseJson)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothivukto == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_Nothivukto = true;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }
        public DakListNothivuktoResponse GetNothivuktoDakList(DakUserParam dakListUserParam)
        {
            DakListNothivuktoResponse dakListNothivuktoResponse = new DakListNothivuktoResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothivukto == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListNothivuktoResponse = JsonConvert.DeserializeObject<DakListNothivuktoResponse>(dakList.jsonResponse);

                }
                return dakListNothivuktoResponse;
            }
            try
            {
                var nothivuktoDakApi = new RestClient(GetAPIDomain()+GetDakListNothivuktoEndpoint());
                nothivuktoDakApi.Timeout = -1;
                var nothivuktoDakRequest = new RestRequest(Method.POST);
                nothivuktoDakRequest.AddHeader("api-version", GetAPIVersion());
                nothivuktoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothivuktoDakRequest.AlwaysMultipartFormData = true;
                nothivuktoDakRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                nothivuktoDakRequest.AddParameter("office_id", dakListUserParam.office_id);
                nothivuktoDakRequest.AddParameter("page", dakListUserParam.page);
                nothivuktoDakRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse nothivuktoDakResponse = nothivuktoDakApi.Execute(nothivuktoDakRequest);


                var nothivuktoDakResponseJson = nothivuktoDakResponse.Content;
                SaveOrUpdateDakOutBoxListJsonResponse(dakListUserParam, nothivuktoDakResponseJson);
                dakListNothivuktoResponse = JsonConvert.DeserializeObject<DakListNothivuktoResponse>(nothivuktoDakResponseJson);
                return dakListNothivuktoResponse;
            }
            catch (Exception ex)
            {
                return dakListNothivuktoResponse;
            }
        }

        public void SaveorUpdateDakNothivukto(DakListNothivuktoResponse dakListNothivuktoResponse)
        {
            DakType dakType = new DakType();
            dakType.is_nothivukto = true;
            if (dakListNothivuktoResponse.data != null)
            {
                dakType.total_records = dakListNothivuktoResponse.data.total_records;

            }

            var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_nothivukto == true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }

            _dakListService.SaveOrUpdateDakList(dakListNothivuktoResponse.data, dakType.Id);
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

        protected string GetDakListNothivuktoEndpoint()
        {
            return DefaultAPIConfiguration.DakListNothivuktoEndPoint;
        }

        public GetNothivuktoNoteAddResponse GetNothivuktoNoteAddResponse(DakUserParam dakUserParam, DakNothivuktoNoteAddParam dakNothivuktoNoteAddParam)
        {
            try
            {
                var nothivuktoNoteAddDakApi = new RestClient(GetAPIDomain() + GetNothivuktoNoteAddEndpoint());
                nothivuktoNoteAddDakApi.Timeout = -1;
                var nothivuktoNoteAddDakRequest = new RestRequest(Method.POST);
                nothivuktoNoteAddDakRequest.AddHeader("api-version", GetOldAPIVersion());
                nothivuktoNoteAddDakRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                nothivuktoNoteAddDakRequest.AlwaysMultipartFormData = true;
                nothivuktoNoteAddDakRequest.AddParameter("designation_id", dakUserParam.designation_id);
                nothivuktoNoteAddDakRequest.AddParameter("office_id", dakUserParam.office_id);


                var jsonString = new JavaScriptSerializer().Serialize(dakNothivuktoNoteAddParam);
                nothivuktoNoteAddDakRequest.AddParameter("data", jsonString);
    
                IRestResponse nothivuktoNoteAddDakResponse = nothivuktoNoteAddDakApi.Execute(nothivuktoNoteAddDakRequest);


                var nothivuktoNoteAddDakResponseJson = nothivuktoNoteAddDakResponse.Content;
                   GetNothivuktoNoteAddResponse noteAddResponse = JsonConvert.DeserializeObject<GetNothivuktoNoteAddResponse>(nothivuktoNoteAddDakResponseJson);
                return noteAddResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetNothivuktoNoteAddEndpoint()
        {
            return DefaultAPIConfiguration.NothivuktoNoteAddEndPoint;
        }
        private string GetDakNothivuktoEndpoint()
        {
            return DefaultAPIConfiguration.DakNothivuktoEndpointEndPoint;
        }
        private string GetDakNothivuktoRevertEndpoint()
        {
            return DefaultAPIConfiguration.DakNothivuktoRevertEndPoint;
        }

        public DakNothivuktoResponse GetDakNothivuktoResponse(DakUserParam dakUserParam, NoteNothiDTO nothi, int dak_id, string dak_type, int is_copied_dak)
        {


            DakNothivuktoResponse dakNothivuktoResponse = new DakNothivuktoResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                dakNothivuktoResponse.status = "success";
                dakNothivuktoResponse.message = "Local";

                DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_type && a.is_copied_dak == is_copied_dak);

                if (dakItemAction == null)
                {
                    dakItemAction = new DakItemAction();
                    dakItemAction.isNothivukto = true;
                    dakItemAction.is_copied_dak = is_copied_dak;
                    dakItemAction.dak_id = dak_id;
                    dakItemAction.dak_type = dak_type;
                    dakItemAction.dak_Action_Json = JsonParsingMethod.ObjecttoJson(nothi);

                    _dakItemAction.Insert(dakItemAction);
                }





                return dakNothivuktoResponse;
            }


            var nothivuktoDakSendAPI = new RestClient(GetAPIDomain() + GetDakNothivuktoEndpoint());
            nothivuktoDakSendAPI.Timeout = -1;
            var NothivuktoDakSendRequest = new RestRequest(Method.POST);
            NothivuktoDakSendRequest.AddHeader("api-version", GetOldAPIVersion());
            NothivuktoDakSendRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            NothivuktoDakSendRequest.AddParameter("cdesk", dakUserParam.json_String);
          
            NothivuktoDakSendRequest.AddParameter("daak", "{\"dak_id\":\""+dak_id+"\",\"dak_type\":\""+dak_type+"\",\"is_copied_dak\":"+is_copied_dak+"}");
            var nothijsonString = new JavaScriptSerializer().Serialize(nothi);


            NothivuktoDakSendRequest.AddParameter("nothi", nothijsonString);
            IRestResponse dakNothivuktoIRestResponse = nothivuktoDakSendAPI.Execute(NothivuktoDakSendRequest);
            var dakNothivuktoResponseJson = dakNothivuktoIRestResponse.Content;

             dakNothivuktoResponse = JsonConvert.DeserializeObject<DakNothivuktoResponse>(dakNothivuktoResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakNothivuktoResponse;
        }

        public void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public DakNothivuktoRevertResponse GetDakNothivuktoRevertResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            try
            {
                var nothivuktoRevertDakApi = new RestClient(GetAPIDomain() + GetDakNothivuktoRevertEndpoint());
                nothivuktoRevertDakApi.Timeout = -1;
                var nothivuktoRevertRequest = new RestRequest(Method.POST);
                nothivuktoRevertRequest.AddHeader("api-version", GetOldAPIVersion());
                nothivuktoRevertRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                nothivuktoRevertRequest.AlwaysMultipartFormData = true;
                nothivuktoRevertRequest.AddParameter("designation_id", dakUserParam.designation_id);
                nothivuktoRevertRequest.AddParameter("office_id", dakUserParam.office_id);
                nothivuktoRevertRequest.AddParameter("dak", "{\"dak_id\":\""+dak_id+"\",\"dak_type\":\""+dak_type+"\", \"is_copied_dak\":\""+is_copied_dak+"\"}");


               
                IRestResponse nothivuktoRevertResponse = nothivuktoRevertDakApi.Execute(nothivuktoRevertRequest);


                var nothivuktoRevertResponseJson = nothivuktoRevertResponse.Content;
                DakNothivuktoRevertResponse revertResponse = JsonConvert.DeserializeObject<DakNothivuktoRevertResponse>(nothivuktoRevertResponseJson);
                return revertResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakListNothivuktoResponse GetNothivuktoDakList(DakUserParam dakListUserParam, string searchParam)
        {
            try
            {
                var nothivuktoDakApi = new RestClient(GetAPIDomain() + GetDakListNothivuktoEndpoint());
                nothivuktoDakApi.Timeout = -1;
                var nothivuktoDakRequest = new RestRequest(Method.POST);
                nothivuktoDakRequest.AddHeader("api-version", GetAPIVersion());
                nothivuktoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothivuktoDakRequest.AlwaysMultipartFormData = true;
                nothivuktoDakRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                nothivuktoDakRequest.AddParameter("office_id", dakListUserParam.office_id);
                nothivuktoDakRequest.AddParameter("page", dakListUserParam.page);
                nothivuktoDakRequest.AddParameter("limit", dakListUserParam.limit);
                nothivuktoDakRequest.AddParameter("search_params", searchParam);
                IRestResponse nothivuktoDakResponse = nothivuktoDakApi.Execute(nothivuktoDakRequest);


                var nothivuktoDakResponseJson = nothivuktoDakResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListNothivuktoResponse dakListNothivuktoResponse = JsonConvert.DeserializeObject<DakListNothivuktoResponse>(nothivuktoDakResponseJson);
                return dakListNothivuktoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

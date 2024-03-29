﻿using System;
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
using dNothi.Services.SyncServices;

namespace dNothi.Services.DakServices
{
    public class DakNothivuktoService : IDakNothivuktoService
    {
        IRepository<DakItem> _dakItem;
        IRepository<DakType> _daktype;

        IDakListService _dakListService { get; set; }

        IRepository<DakItemAction> _dakItemAction;
        IUserService _userService { get; set; }
        public DakNothivuktoService(IUserService userService, IRepository<DakItemAction> dakItemAction, IRepository<DakItem> dakItem, IRepository<DakType> daktype, IDakListService dakListService)
        {
            _dakItemAction = dakItemAction;
            _userService = userService;

            _daktype = daktype;
            _dakItem = dakItem;
            _dakListService = dakListService;
        }

        private void SaveOrUpdateDakNothivuktoListJsonResponse(DakUserParam dakListUserParam, string responseJson, string searchParam)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothivukto_Search == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.searchParameter == searchParam);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_Nothivukto_Search = true;
                dakItem.searchParameter = searchParam;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }
        public bool Is_Locally_Nothivukto(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isNothivukto == true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Is_Locally_NothivuktoReverted(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isNothivuktoReverted == true);
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



            LocalChangeData._isLocallYDakNothivukto = false;


            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isNothivukto == true && a.localNoteId == 0).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {

                    NoteNothiDTO noteNothiDTO = JsonConvert.DeserializeObject<NoteNothiDTO>(dakItemAction.dak_Action_Json);

                    var dakForwardResponse = GetDakNothivuktoResponse(dakUserParam, noteNothiDTO, dakItemAction.dak_id, dakItemAction.dak_type, dakItemAction.is_copied_dak);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))
                    {
                        _dakItemAction.Delete(dakItemAction);
                        LocalChangeData._isLocallYDakNothivukto = true;

                    }
                    
                }
            }


            return LocalChangeData._isLocallYDakNothivukto;
        }

        public bool DakNothivuktoFromLocal(long localNoteId, int remoteNoteId, NoteSaveDTO note)
        {




            LocalChangeData._isLocallYDakNothivukto = false;

            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isNothivukto == true && a.localNoteId == localNoteId).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {

                    NoteNothiDTO noteNothiDTO = JsonConvert.DeserializeObject<NoteNothiDTO>(dakItemAction.dak_Action_Json);
                   
                    noteNothiDTO.note_id = remoteNoteId.ToString();
                    noteNothiDTO.office_designation_name = note.office_designation_name;
                    noteNothiDTO.office_id = note.office_id;
                    noteNothiDTO.office_name = note.office_name;
                    noteNothiDTO.office_unit = note.office_unit_name;
                    noteNothiDTO.office_unit_id = note.office_unit_id;
                    noteNothiDTO.office_unit_organogram_id = note.office_unit_organogram_id;
                    noteNothiDTO.id = note.nothi_id;
                    noteNothiDTO.is_active = note.is_active;
                    noteNothiDTO.is_archived = note.is_archived;
                    noteNothiDTO.is_deleted = note.is_deleted;
                    noteNothiDTO.modified = note.modified;
                    noteNothiDTO.modified_by = note.modified_by;
                    noteNothiDTO.note_id = note.note_id.ToString();
                    noteNothiDTO.note_no = note.note_no;
                    noteNothiDTO.note_subject = note.note_subject;
                    noteNothiDTO.nothi_class = note.nothi_class;
                    noteNothiDTO.nothi_created_date = note.nothi_created_date;
                    noteNothiDTO.nothi_no = note.nothi_no;
                    noteNothiDTO.nothi_type_id = note.nothi_type_id;
                    noteNothiDTO.subject = note.subject;
                    noteNothiDTO._isOffline = false;
                   
                    
                    var dakForwardResponse = GetDakNothivuktoResponse(dakUserParam, noteNothiDTO, dakItemAction.dak_id, dakItemAction.dak_type, dakItemAction.is_copied_dak);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))
                    {
                        _dakItemAction.Delete(dakItemAction);
                        LocalChangeData._isLocallYDakNothivukto = true;

                    }
                }
            }


          return  LocalChangeData._isLocallYDakNothivukto;
        }
        public bool DakNothivuktoRevertFromLocal()
        {
            bool isSuccess = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isNothivuktoReverted == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {
                    if (dakUserParam.designation_id == dakItemAction.designation_id)
                    {
                        var dakArchiveResponse = GetDakNothivuktoRevertResponse(dakUserParam, dakItemAction.dak_id, dakItemAction.dak_type, dakItemAction.is_copied_dak);

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
                var nothivuktoDakApi = new RestClient(GetAPIDomain() + GetDakListNothivuktoEndpoint());
                nothivuktoDakApi.Timeout = -1;
                var nothivuktoDakRequest = new RestRequest(Method.POST);
                nothivuktoDakRequest.AddHeader("api-version", GetAPIVersion());
                nothivuktoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothivuktoDakRequest.AlwaysMultipartFormData = true;
                nothivuktoDakRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                nothivuktoDakRequest.AddParameter("office_id", dakListUserParam.office_id);
                nothivuktoDakRequest.AddParameter("page", dakListUserParam.page);
                nothivuktoDakRequest.AddParameter("length", dakListUserParam.limit);
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
            if (!dNothi.Utility.InternetConnection.Check() || nothi._isOffline)
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
                    if(nothi._isOffline)
                    {
                        dakItemAction.localNoteId = Convert.ToInt64(nothi.note_id);
                    }
                    _dakItemAction.Insert(dakItemAction);
                }
                else
                {
                    dakNothivuktoResponse.status = "Internet";
                }

                return dakNothivuktoResponse;
            }


            var nothivuktoDakSendAPI = new RestClient(GetAPIDomain() + GetDakNothivuktoEndpoint());
            nothivuktoDakSendAPI.Timeout = -1;
            var NothivuktoDakSendRequest = new RestRequest(Method.POST);
            NothivuktoDakSendRequest.AddHeader("api-version", GetOldAPIVersion());
            NothivuktoDakSendRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            NothivuktoDakSendRequest.AddParameter("cdesk", dakUserParam.json_String);

            NothivuktoDakSendRequest.AddParameter("daak", "{\"dak_id\":\"" + dak_id + "\",\"dak_type\":\"" + dak_type + "\",\"is_copied_dak\":" + is_copied_dak + "}");
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
            DakNothivuktoRevertResponse revertResponse = new DakNothivuktoRevertResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                revertResponse.status = "success";
                revertResponse.message = "Local";

                DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_type && a.is_copied_dak == is_copied_dak);

                if (dakItemAction == null)
                {
                    dakItemAction = new DakItemAction();
                    dakItemAction.isNothivuktoReverted = true;
                    dakItemAction.is_copied_dak = is_copied_dak;
                    dakItemAction.dak_id = dak_id;
                    dakItemAction.dak_type = dak_type;
                    dakItemAction.designation_id = dakUserParam.designation_id;
                    // dakItemAction.dak_Action_Json = JsonParsingMethod.ObjecttoJson(nothi);

                    _dakItemAction.Insert(dakItemAction);
                }





                return revertResponse;
            }
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
                nothivuktoRevertRequest.AddParameter("dak", "{\"dak_id\":\"" + dak_id + "\",\"dak_type\":\"" + dak_type + "\", \"is_copied_dak\":\"" + is_copied_dak + "\"}");



                IRestResponse nothivuktoRevertResponse = nothivuktoRevertDakApi.Execute(nothivuktoRevertRequest);


                var nothivuktoRevertResponseJson = nothivuktoRevertResponse.Content;
                revertResponse = JsonConvert.DeserializeObject<DakNothivuktoRevertResponse>(nothivuktoRevertResponseJson);
                return revertResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakListNothivuktoResponse GetNothivuktoDakList(DakUserParam dakListUserParam, string searchParam)
        {
            DakListNothivuktoResponse dakListNothivuktoResponse = new DakListNothivuktoResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_Nothivukto_Search == true && a.searchParameter==searchParam && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListNothivuktoResponse = JsonConvert.DeserializeObject<DakListNothivuktoResponse>(dakList.jsonResponse);

                }
                return dakListNothivuktoResponse;
            }


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
                SaveOrUpdateDakNothivuktoListJsonResponse(dakListUserParam, nothivuktoDakResponseJson,searchParam);
                dakListNothivuktoResponse = JsonConvert.DeserializeObject<DakListNothivuktoResponse>(nothivuktoDakResponseJson);
                return dakListNothivuktoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

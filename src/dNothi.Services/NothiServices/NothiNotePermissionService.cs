using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.Services.NothiServices
{
    public class NothiNotePermissionService : INothiNotePermissionService
    {
        IRepository<NothiNotePermissionItem> _nothiNotePermissionItem;
        IUserService _userService { get; set; }
        public NothiNotePermissionService(IUserService userService, IRepository<NothiNotePermissionItem> nothiNotePermissionItem)
        {
            _userService = userService;
            _nothiNotePermissionItem = nothiNotePermissionItem;
        }
        public NothiNotePermissionResponse GetNothiNotePermission(DakUserParam dakListUserParam, List<onumodonDataRecordDTO> nothiOnumodonRows, NothiListRecordsDTO nothiListRecordsDTO, int other_office_id, string note_Id)
        {
            NothiNotePermissionResponse nothiNotePermissionResponse = new NothiNotePermissionResponse();
            if (!InternetConnection.Check())
            {
                nothiNotePermissionResponse.status = "success";
                nothiNotePermissionResponse.message = "Local";

                var cDeskJsonString = new JavaScriptSerializer().Serialize(dakListUserParam);
                var onumodonJsonString = new JavaScriptSerializer().Serialize(nothiOnumodonRows);
                var nothiRecordsJsonString = new JavaScriptSerializer().Serialize(nothiListRecordsDTO);

                NothiNotePermissionItem nothiNotePermissionItem = new NothiNotePermissionItem();
                
                nothiNotePermissionItem.json_user_param = cDeskJsonString;
                nothiNotePermissionItem.json_nothiOnumodonRows = onumodonJsonString;
                nothiNotePermissionItem.json_nothiListRecordsDTO = nothiRecordsJsonString;
                nothiNotePermissionItem.other_office_id = other_office_id;
                nothiNotePermissionItem.note_Id = note_Id; 
                nothiNotePermissionItem.noteOrNothi =1;//0 means nothi, 1 means note
                nothiNotePermissionItem.office_id = dakListUserParam.office_id;
                nothiNotePermissionItem.designation_id = dakListUserParam.designation_id;

                _nothiNotePermissionItem.Insert(nothiNotePermissionItem);

                return nothiNotePermissionResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNotePermissionEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;

                List<NothiOnumodonSealParam> nothiOnumodonSealParams = new List<NothiOnumodonSealParam>();
                foreach (onumodonDataRecordDTO nothiOnumodonRowDTO in nothiOnumodonRows)
                {
                    if (nothiOnumodonRowDTO.office_id == 0)
                    {
                        nothiOnumodonRowDTO.office_id = nothiOnumodonRowDTO.nothi_office;
                    }
                    NothiOnumodonSealParam nothiOnumodonSealParam = new NothiOnumodonSealParam();
                    nothiOnumodonSealParam.ConvertDTOtoReques(nothiOnumodonRowDTO);
                    nothiOnumodonSealParams.Add(nothiOnumodonSealParam);
                }
                
                var cDeskJsonString = new JavaScriptSerializer().Serialize(dakListUserParam);
                request.AddParameter("cdesk", "{\"office_id\":" + dakListUserParam.office_id + ",\"office_unit_id\":" + dakListUserParam.office_unit_id + ",\"designation_id\":" + dakListUserParam.designation_id + ",\"officer_id\":" + dakListUserParam.officer_id + ",\"user_id\":" + dakListUserParam.user_id + ",\"office\":\"" + dakListUserParam.office + "\",\"officer\":\"" + dakListUserParam.officer + "\",\"designation_level\":" + dakListUserParam.designation_level + "}");
                var authorityJsonString = new JavaScriptSerializer().Serialize(nothiOnumodonSealParams);
                request.AddParameter("authority", authorityJsonString);
                request.AddParameter("note", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\",\"nothi_office_name\":\"" + nothiListRecordsDTO.office_name + "\",\"other_office_id\":\"" + other_office_id + "\",\"nothi_note_id\":\""+ note_Id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;

                nothiNotePermissionResponse = JsonConvert.DeserializeObject<NothiNotePermissionResponse>(responseJson);
                return nothiNotePermissionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiNotePermissionResponse GetNothiPermission(DakUserParam dakListUserParam, List<onumodonDataRecordDTO> nothiOnumodonRows, NothiListRecordsDTO nothiListRecordsDTO, int other_office_id)
        {
            NothiNotePermissionResponse nothiNotePermissionResponse = new NothiNotePermissionResponse();
            if (!InternetConnection.Check())
            {
                nothiNotePermissionResponse.status = "success";
                nothiNotePermissionResponse.message = "Local";

                var cDeskJsonString = new JavaScriptSerializer().Serialize(dakListUserParam);
                var onumodonJsonString = new JavaScriptSerializer().Serialize(nothiOnumodonRows);
                var nothiRecordsJsonString = new JavaScriptSerializer().Serialize(nothiListRecordsDTO);

                NothiNotePermissionItem nothiNotePermissionItem = new NothiNotePermissionItem();

                nothiNotePermissionItem.json_user_param = cDeskJsonString;
                nothiNotePermissionItem.json_nothiOnumodonRows = onumodonJsonString;
                nothiNotePermissionItem.json_nothiListRecordsDTO = nothiRecordsJsonString;
                nothiNotePermissionItem.other_office_id = other_office_id;
                nothiNotePermissionItem.noteOrNothi = 0;//0 means nothi, 1 means note
                nothiNotePermissionItem.office_id = dakListUserParam.office_id;
                nothiNotePermissionItem.designation_id = dakListUserParam.designation_id;

                _nothiNotePermissionItem.Insert(nothiNotePermissionItem);

                return nothiNotePermissionResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPermissionEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;

                List<NothiOnumodonSealParam> nothiOnumodonSealParams = new List<NothiOnumodonSealParam>();
                foreach(onumodonDataRecordDTO nothiOnumodonRowDTO in nothiOnumodonRows)
                {
                    if(nothiOnumodonRowDTO.office_id==0)
                    {
                        nothiOnumodonRowDTO.office_id = nothiOnumodonRowDTO.nothi_office;
                    }
                    NothiOnumodonSealParam nothiOnumodonSealParam = new NothiOnumodonSealParam();
                    nothiOnumodonSealParam.ConvertDTOtoReques(nothiOnumodonRowDTO);
                    nothiOnumodonSealParams.Add(nothiOnumodonSealParam);
                }
                var cDeskJsonString = new JavaScriptSerializer().Serialize(dakListUserParam);
                request.AddParameter("cdesk", "{\"office_id\":"+dakListUserParam.office_id+",\"office_unit_id\":"+dakListUserParam.office_unit_id+",\"designation_id\":"+dakListUserParam.designation_id+",\"officer_id\":"+dakListUserParam.officer_id+",\"user_id\":"+dakListUserParam.user_id+",\"office\":\""+dakListUserParam.office+"\",\"officer\":\""+ dakListUserParam.officer+ "\",\"designation_level\":"+dakListUserParam.designation_level+"}");
                var authorityJsonString = new JavaScriptSerializer().Serialize(nothiOnumodonSealParams);
                request.AddParameter("authority",authorityJsonString);
                request.AddParameter("nothi", "{\"nothi_id\":\""+nothiListRecordsDTO.id+"\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\",\"nothi_office_name\":\""+nothiListRecordsDTO.office_name+"\"}");
                request.AddParameter("note", "0");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
              
                nothiNotePermissionResponse = JsonConvert.DeserializeObject<NothiNotePermissionResponse>(responseJson);
                return nothiNotePermissionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool SendNothiNotePermissionFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            List<NothiNotePermissionItem> nothiNotePermissionItemDB = _nothiNotePermissionItem.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
            
            if (nothiNotePermissionItemDB != null && nothiNotePermissionItemDB.Count > 0)
            {
                foreach (NothiNotePermissionItem nothiNotePermissionItem in nothiNotePermissionItemDB)
                {
                    var other_office_id = nothiNotePermissionItem.other_office_id;
                    var noteID = nothiNotePermissionItem.note_Id;
                    var noteOrNothi = nothiNotePermissionItem.noteOrNothi;//0 means nothi, 1 means note
                    var office_id = nothiNotePermissionItem.office_id;
                    var designation_id = nothiNotePermissionItem.designation_id;

                    var _dakUserParam = JsonConvert.DeserializeObject<DakUserParam>(nothiNotePermissionItem.json_user_param);
                    var nothiOnumodonRows = JsonConvert.DeserializeObject<List<onumodonDataRecordDTO>>(nothiNotePermissionItem.json_nothiOnumodonRows);
                    var _nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(nothiNotePermissionItem.json_nothiListRecordsDTO);

                    var nothiNotePermission = new NothiNotePermissionResponse();
                    if (noteOrNothi == 0)
                    {
                        nothiNotePermission = GetNothiPermission(_dakUserParam, nothiOnumodonRows, _nothiListRecordsDTO, Convert.ToInt32(_nothiListRecordsDTO.office_id));

                    }
                    else if (noteOrNothi == 1)
                    {
                        nothiNotePermission = GetNothiNotePermission(_dakUserParam, nothiOnumodonRows, _nothiListRecordsDTO, Convert.ToInt32(_nothiListRecordsDTO.office_id), noteID);
                    }
                    _nothiNotePermissionItem.Delete(nothiNotePermissionItem);
                        isForwarded = true;
                }
            }


            return isForwarded;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        protected string GetNothiNotePermissionEndPoint()
        {
            return DefaultAPIConfiguration.NothiNotePermissionEndPoint;
        }
        protected string GetNothiPermissionEndPoint()
        {
            return DefaultAPIConfiguration.NothiPermissionSaveEndPoint;
        }
    }
}

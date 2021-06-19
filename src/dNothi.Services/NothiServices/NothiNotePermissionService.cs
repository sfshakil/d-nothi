using dNothi.Constants;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
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
        public NothiNotePermissionResponse GetNothiNotePermission(DakUserParam dakListUserParam, List<onumodonDataRecordDTO> nothiOnumodonRows, NothiListRecordsDTO nothiListRecordsDTO, int other_office_id, string note_Id)
        {
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


                //  request.AddParameter("nothi", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\",\"nothi_office_name\":\"" + nothiListRecordsDTO.office_name + "\",\"other_office_id\":\"" + other_office_id + "\"}");


                request.AddParameter("note", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\",\"nothi_office_name\":\"" + nothiListRecordsDTO.office_name + "\",\"other_office_id\":\"" + other_office_id + "\",\"nothi_note_id\":\""+ note_Id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;

                NothiNotePermissionResponse nothiNotePermissionResponse = JsonConvert.DeserializeObject<NothiNotePermissionResponse>(responseJson);
                return nothiNotePermissionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiNotePermissionResponse GetNothiPermission(DakUserParam dakListUserParam, List<onumodonDataRecordDTO> nothiOnumodonRows, NothiListRecordsDTO nothiListRecordsDTO, int other_office_id)
        {
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


              //  request.AddParameter("nothi", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\",\"nothi_office_name\":\"" + nothiListRecordsDTO.office_name + "\",\"other_office_id\":\"" + other_office_id + "\"}");


                request.AddParameter("nothi", "{\"nothi_id\":\""+nothiListRecordsDTO.id+"\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\",\"nothi_office_name\":\""+nothiListRecordsDTO.office_name+"\"}");

                request.AddParameter("note", "0");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
              
                NothiNotePermissionResponse nothiNotePermissionResponse = JsonConvert.DeserializeObject<NothiNotePermissionResponse>(responseJson);
                return nothiNotePermissionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
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

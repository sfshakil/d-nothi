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

namespace dNothi.Services.NothiServices
{
    public class NoteSaveService : INoteSaveService
    {
        public NoteSaveResponse GetNoteSave(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO, string noteSubject)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteCreateEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", dakUserParam.office_id);
                request.AddParameter("designation_id", dakUserParam.designation_id);
                request.AddParameter("data", "{\"id\":\""+ nothiListRecordsDTO.id+ "\",\"nothi_master_id\":\""+ nothiListRecordsDTO.id + "\",\"note_subject\":\""+noteSubject+"\",\"office_id\":"+nothiListRecordsDTO.office_id+",\"office_name\":\""+nothiListRecordsDTO.office_name+ "\",\"office_unit_name\":\"" + nothiListRecordsDTO.office_unit_name + "\",\"office_designation_name\":\"" + nothiListRecordsDTO.office_designation_name + "\",\"officer_name\":\"" + dakUserParam.officer_name + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NoteSaveResponse noteSaveResponse = JsonConvert.DeserializeObject<NoteSaveResponse>(responseJson);
                return noteSaveResponse;
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
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetNothiNoteCreateEndpoint()
        {
            return DefaultAPIConfiguration.NothiNoteCreateEndPoint;
        }
    }
}

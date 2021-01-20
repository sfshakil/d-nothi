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
    public class OnuchhedForwardService : IOnuchhedForwardService
    {
        public OnuchhedForwardResponse GetOnuchhedForwardResponse(DakUserParam dakUserParam, NoteSaveDTO newnotedata, NothiListRecordsDTO nothiListRecord, List<onumodonDataRecordDTO> newrecords)
        {

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedSendEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);

                request.AddParameter("onucched", "{\"note_no\":\""+newnotedata.note_no+"\",\"note_subject\":\""+newnotedata.note_subject+"\",\"nothi_unit\":\""+nothiListRecord.office_unit_name+"\",\"nothi_no\":\""+nothiListRecord.nothi_no+"\",\"nothi_id\":\""+nothiListRecord.id+"\",\"nothi_office\":\""+nothiListRecord.office_id+"\",\"nothi_office_name\":\""+nothiListRecord.office_name+"\",\"note_id\":\""+newnotedata.note_id+"\",\"priority\":\"0\"}");
    
                request.AddParameter("recipient", "{\"office_id\":\""+ newrecords[0].office_id+ "\",\"office\":\""+newrecords[0].office+"\",\"office_unit_id\":\""+newrecords[0].office_unit_id+"\",\"office_unit\":\""+newrecords[0].office_unit+"\",\"designation_id\":\""+newrecords[0].designation_id+"\",\"designation\":\""+newrecords[0].designation+"\",\"officer_id\":\""+newrecords[0].officer_id+"\",\"officer\":\""+newrecords[0].officer+"\",\"designation_level\":\""+newrecords[0].designation_level+"\"}");
    
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);



                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                OnuchhedForwardResponse onuchhedForwardResponse = JsonConvert.DeserializeObject<OnuchhedForwardResponse>(responseJson);
                return onuchhedForwardResponse;
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

        protected string GetNoteOnuchhedSendEndPoint()
        {
            return DefaultAPIConfiguration.NoteOnuchhedSendEndPoint;
        }
    }
}

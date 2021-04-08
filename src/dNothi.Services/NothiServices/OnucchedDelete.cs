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
    public class OnucchedDelete : IOnucchedDelete
    {
        public OnucchedDeleteResponseDTO GetNothiOnuchhedDelete(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata, string onucchedId)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedDeleteEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);
                request.AddParameter("onucched", "{\"nothi_id\":\""+nothiListRecords.id+"\",\"nothi_office\":\""+nothiListRecords.office_id+"\",\"note_id\":\""+newnotedata.note_id+"\",\"onucched_id\":\""+onucchedId+"\"}");

                IRestResponse response = client.Execute(request);


                var responseJson = response.Content;
                OnucchedDeleteResponseDTO onucchedDeleteResponseDTO = JsonConvert.DeserializeObject<OnucchedDeleteResponseDTO>(responseJson);
                return onucchedDeleteResponseDTO;
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

        protected string GetNoteOnuchhedDeleteEndPoint()
        {
            return DefaultAPIConfiguration.NoteOnuchhedDeleteEndPoint;
        }
    }
}

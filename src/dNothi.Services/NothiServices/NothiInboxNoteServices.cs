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
    public class NothiInboxNoteServices : INothiInboxNoteServices
    {
        public NothiListInboxNoteResponse GetNothiInboxNote(DakUserParam dakListUserParam, string eachNothiId, string note_category)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiInboxNoteEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\""+ dakListUserParam.office_id + "\",\"office_unit_id\":\""+ dakListUserParam.office_unit_id + "\",\"designation_id\":\""+ dakListUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+ Convert.ToInt32(eachNothiId) +"\",\"note_category\":\""+ note_category + "\"}");
                request.AddParameter("length", "100");
                request.AddParameter("page", "1");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NothiListInboxNoteResponse nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NothiListInboxNoteResponse>(responseJson);
                return nothiListInboxNoteResponse;
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
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        protected string GetNothiInboxNoteEndPoint()
        {
            return DefaultAPIConfiguration.NothiInboxNoteEndPoint;
        }

    }
}

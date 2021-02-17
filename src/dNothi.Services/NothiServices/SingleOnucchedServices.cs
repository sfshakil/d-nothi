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
    public class SingleOnucchedServices : ISingleOnucchedServices
    {
        public SingleOnucchedResponse GetSingleOnucched(DakUserParam dakUserParam, long nothiId, long noteId, long onucchedId)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteSingleOnucchedEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("note", "{\"nothi_id\":\"" + nothiId + "\",\"note_id\":\"" + noteId + "\", \"onucched_id\":\"" + onucchedId + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                SingleOnucchedResponse singleOnucchedResponse = JsonConvert.DeserializeObject<SingleOnucchedResponse>(responseJson);
                return singleOnucchedResponse;
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

        protected string GetNothiNoteSingleOnucchedEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteSingleOnucchedEndPoint;
        }
    }
}

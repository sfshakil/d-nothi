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
    public class OnumodonService : IOnumodonService
    {
        public OnumodonResponse GetOnumodonMembers(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecords)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiAuthorityEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\""+dakUserParam.designation_id+"\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+nothiListRecords.id+"\",\"nothi_office\":\""+nothiListRecords.office_id+"\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                var responseJson = response.Content;
                OnumodonResponse onumodonResponse = JsonConvert.DeserializeObject<OnumodonResponse>(responseJson);
                return onumodonResponse;
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

        protected string GetNothiAuthorityEndPoint()
        {
            return DefaultAPIConfiguration.NothiAuthorityEndPoint;
        }
    }
}

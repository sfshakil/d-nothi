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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiPotrangshoServices : INothiPotrangshoServices
    {
        public NothiPotrangshoResponse GetNothiPotrangsho(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+nothiListRecordsDTO.id+"\", \"nothi_office\":\""+dakUserParam.office_id+"\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                NothiPotrangshoResponse nothiPotrangshoResponse = JsonConvert.DeserializeObject<NothiPotrangshoResponse>(responseJson);
                return nothiPotrangshoResponse;
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

        protected string GetNothiPotrangshoEndpoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoEndPoint;
        }
    }
}

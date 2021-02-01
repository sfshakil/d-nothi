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
    public class KhoshraPotroServices : IKhoshraPotroServices
    {
        public KhoshraPotroResponse GetKhoshraPotroInfo(DakUserParam dakUserParam, long id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoKhoshraPotroEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                KhoshraPotroResponse khoshraPotroResponse = JsonConvert.DeserializeObject<KhoshraPotroResponse>(responseJson);
                return khoshraPotroResponse;
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

        protected string GetNothiPotrangshoKhoshraPotroEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoKhoshraPotroEndPoint;
        }
    }
}

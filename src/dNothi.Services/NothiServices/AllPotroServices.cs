using dNothi.Constants;
using dNothi.JsonParser;
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
    public class AllPotroServices : IAllPotroServices
    {
        private readonly IAllPotroParser _allPotroParser;
        public AllPotroServices(IAllPotroParser allPotroParser)
        {
            _allPotroParser = allPotroParser;
        }
        public AllPotroResponse GetAllPotroInfo(DakUserParam dakUserParam, long id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoAllPotroEndPoint());
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
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["data"].ToString();
                //var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                AllPotroResponse allPotroResponse = _allPotroParser.ParseMessage(responseJson);
                return allPotroResponse;
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

        protected string GetNothiPotrangshoAllPotroEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoAllPotroEndPoint;
        }
    }
}

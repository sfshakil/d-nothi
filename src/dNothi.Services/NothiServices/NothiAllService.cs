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
    public class NothiAllService : INothiAllServices
    {
        //public NothiListAllResponse GetNothiAll(string token)
        //{
        //    try
        //    {
        //        var client = new RestClient("https://dev.nothibs.tappware.com/api/nothi/list/all");
        //        client.Timeout = -1;
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("api-version", "1");
        //        request.AddHeader("Authorization", "Bearer " + token);
        //        request.AlwaysMultipartFormData = true;
        //        request.AddParameter("cdesk", "{\"office_id\":\"65\",\"office_unit_id\":\"40372\",\"designation_id\":\"244930\"}");
        //        request.AddParameter("length", "24");
        //        request.AddParameter("page", "1");
        //        IRestResponse response = client.Execute(request);
        //        Console.WriteLine(response.Content);

        //        var responseJson = response.Content;
        //        //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
        //        // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
        //        NothiListAllResponse dakListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(responseJson);
        //        return dakListAllResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public NothiListAllResponse GetNothiAll(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiAllListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NothiListAllResponse dakListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(responseJson);
                return dakListAllResponse;
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

        protected string GetNothiAllListEndpoint()
        {
            return DefaultAPIConfiguration.NothiAllListEndPoint;
        }

        public NothiListAllResponse GetNothiAllByUser(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient("https://dev.nothibs.tappware.com/api/nothi/list/all");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

               

                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "24");
                request.AddParameter("page", "1");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NothiListAllResponse dakListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(responseJson);
                return dakListAllResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

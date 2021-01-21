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
    public class NothiOutboxService : INothiOutboxServices
    {
        //public NothiListOutboxResponse GetNothiOutbox(string token)
        //{
        //    try
        //    {
        //        var client = new RestClient("https://dev.nothibs.tappware.com/api/nothi/list/outbox");
        //        client.Timeout = -1;
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("api-version", "1");
        //        request.AddHeader("Authorization", "Bearer " + token);
        //        request.AlwaysMultipartFormData = true;
        //        request.AddParameter("cdesk", "{\"office_id\":\"65\",\"office_unit_id\":\"40372\",\"designation_id\":\"244930\"}");
        //        request.AddParameter("length", "3");
        //        request.AddParameter("page", "1");
        //        IRestResponse response = client.Execute(request);
        //        Console.WriteLine(response.Content);

        //        var responseJson = response.Content;
        //        //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
        //        // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
        //        NothiListOutboxResponse dakListOutboxResponse = JsonConvert.DeserializeObject<NothiListOutboxResponse>(responseJson);
        //        return dakListOutboxResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        public NothiListOutboxResponse GetNothiOutbox(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiOutboxListEndpoint());
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
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                NothiListOutboxResponse dakListOutboxResponse = JsonConvert.DeserializeObject<NothiListOutboxResponse>(responseJson);
                return dakListOutboxResponse;
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

        protected string GetNothiOutboxListEndpoint()
        {
            return DefaultAPIConfiguration.NothiOutboxListEndPoint;
        }
    }
}

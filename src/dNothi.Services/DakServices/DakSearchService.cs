using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakSearchService : IDakSearchService
    {
        public DakSearchResponse GetDakSearchDetailsResponse(DakUserParam dakListUserParam, string dakSearchParam)
        {
            DakSearchResponse dakSearchResponse = new DakSearchResponse();
            try
            {


                var dakSearchApi = new RestClient(GetAPIDomain() + GetDakSearchEndPoint());
                dakSearchApi.Timeout = -1;
                var dakSearchRequest = new RestRequest(Method.POST);
                dakSearchRequest.AddHeader("api-version", GetAPIVersion());
                dakSearchRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakSearchRequest.AlwaysMultipartFormData = true;
                dakSearchRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakSearchRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakSearchRequest.AddParameter("page", dakListUserParam.page);
                dakSearchRequest.AddParameter("limit", dakListUserParam.limit);
                //var search_params = new JavaScriptSerializer().Serialize(dakSearchParam);
                dakSearchRequest.AddParameter("search_params", dakSearchParam);
                IRestResponse dakInboxResponse = dakSearchApi.Execute(dakSearchRequest);
             

                var dakResponseJson = dakInboxResponse.Content;
                int firstStringIndex = dakResponseJson.IndexOf("{\"status\":");

                var jsonStringDiscardedGarbage = dakResponseJson.Substring(firstStringIndex,dakResponseJson.Length-firstStringIndex );
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                dakSearchResponse = JsonConvert.DeserializeObject<DakSearchResponse>(jsonStringDiscardedGarbage);
                return dakSearchResponse;
            }
            catch (Exception ex)
            {
                return dakSearchResponse;
            }
        }

        public DakSearchResponse GetDakSearchResponse(DakUserParam dakListUserParam, string dak_sub)
        {
            throw new NotImplementedException();
        }

        protected string GetDakSearchEndPoint()
        {
            return DefaultAPIConfiguration.DakSearchEndPoint;
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




    }
}

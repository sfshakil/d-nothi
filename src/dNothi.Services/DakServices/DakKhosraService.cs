using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakKhosraService : IDakKhosraService
    {
        public DakListKhosraResponse GetDakKhosraList(DakUserParam dakListUserParam)
        {
            try
            {


                var dakKhorsAPI = new RestClient(GetAPIDomain() + GetDakListKhosraEndpoint());
                dakKhorsAPI.Timeout = -1;
                var dakKhosraRequest = new RestRequest(Method.POST);
                dakKhosraRequest.AddHeader("api-version", GetOldAPIVersion());
                dakKhosraRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakKhosraRequest.AlwaysMultipartFormData = true;
                dakKhosraRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakKhosraRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakKhosraRequest.AddParameter("page", dakListUserParam.page);
                dakKhosraRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakKhosraResponse = dakKhorsAPI.Execute(dakKhosraRequest);


                var dakKhosraResponseJson = dakKhosraResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListKhosraResponse dakListKhosraResponse = JsonConvert.DeserializeObject<DakListKhosraResponse>(dakKhosraResponseJson);
                return dakListKhosraResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetDakListKhosraEndpoint()
        {
            return DefaultAPIConfiguration.DakListKhosraEndPoint;
        }

        public DakListKhosraResponse GetDakKhosraList(DakUserParam dakListUserParam, string searchParam)
        {
            try
            {


                var dakKhorsAPI = new RestClient(GetAPIDomain() + GetDakListKhosraEndpoint());
                dakKhorsAPI.Timeout = -1;
                var dakKhosraRequest = new RestRequest(Method.POST);
                dakKhosraRequest.AddHeader("api-version", GetOldAPIVersion());
                dakKhosraRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakKhosraRequest.AlwaysMultipartFormData = true;
                dakKhosraRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakKhosraRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakKhosraRequest.AddParameter("page", dakListUserParam.page);
                dakKhosraRequest.AddParameter("limit", dakListUserParam.limit);
                dakKhosraRequest.AddParameter("search_params", searchParam);
                IRestResponse dakKhosraResponse = dakKhorsAPI.Execute(dakKhosraRequest);


                var dakKhosraResponseJson = dakKhosraResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListKhosraResponse dakListKhosraResponse = JsonConvert.DeserializeObject<DakListKhosraResponse>(dakKhosraResponseJson);
                return dakListKhosraResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

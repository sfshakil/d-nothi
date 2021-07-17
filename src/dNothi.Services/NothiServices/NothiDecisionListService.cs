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
    public class NothiDecisionListService : INothiDecisionListService
    {
        public NothiDecisionListResponse GetNothiDecisionList(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiDecisionListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("limit", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NothiDecisionListResponse nothiDecisionListResponse = JsonConvert.DeserializeObject<NothiDecisionListResponse>(responseJson);
                return nothiDecisionListResponse;
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

        protected string GetNothiDecisionListEndpoint()
        {
            return DefaultAPIConfiguration.NothiDecisionListEndpoint;
        }
        protected string GetNothiGaurdFileListEndpoint()
        {
            return DefaultAPIConfiguration.NothiGaurdFileListEndpoint;
        }

        public NothiGaurdFileListResponse GetNothiGaurdFileList(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiGaurdFileListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", dakUserParam.office_id);
                request.AddParameter("page", dakUserParam.page);
                request.AddParameter("limit", dakUserParam.limit);
                request.AddParameter("designation_id", dakUserParam.designation_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiGaurdFileListResponse nothiDecisionListResponse = JsonConvert.DeserializeObject<NothiGaurdFileListResponse>(responseJson);
                return nothiDecisionListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

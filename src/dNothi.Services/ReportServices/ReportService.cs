using dNothi.Constants;
using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.ReportServices
{
    public class ReportService : IReportService
    {
        public ReportCategoryResponse GetReportCategoryList(DakUserParam userParam, string type)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetReportCategoryEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("type", type);

                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;

                ReportCategoryResponse reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryResponse>(responseJson);
                return reportCategoryResponse;
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
        protected string GetReportCategoryEndPoint()
        {
            return DefaultAPIConfiguration.ReportCategoryEndPoint;
        }
    }
}

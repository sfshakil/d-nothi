using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
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
    public class NothiReviewerServices : INothiReviewerServices
    {
        public NothiReviewerDTO GetNothiReviewer(DakUserParam dakUserParam, long nothi_shared_id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiReviewerEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                var serializedObject1 = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject1); 
                request.AddParameter("shared_nothi_id", nothi_shared_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiReviewerDTO allPotroResponse = JsonConvert.DeserializeObject<NothiReviewerDTO>(responseJson);
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

        protected string GetNothiReviewerEndPoint()
        {
            return DefaultAPIConfiguration.NothiReviewerEndPoint;
        }
    }
}

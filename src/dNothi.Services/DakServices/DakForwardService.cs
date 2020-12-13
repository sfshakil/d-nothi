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
    public class DakForwardService : IDakForwardService
    {
        public DesignationSealListResponse GetSealListResponse(DakListUserParam dakListUserParam)
        {
            try
            {

                var designationSealList = new RestClient(GetAPIDomain() + GetDesignationSealListEndpoint());
                designationSealList.Timeout = -1;
                var designationSealRequest = new RestRequest(Method.POST);
                designationSealRequest.AddHeader("api-version", GetOldAPIVersion());
                designationSealRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                designationSealRequest.AlwaysMultipartFormData = true;
                designationSealRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                designationSealRequest.AddParameter("office_id", dakListUserParam.office_id);
              
                IRestResponse designationSealResponseAPI = designationSealList.Execute(designationSealRequest);


                var designationSealResponseJson = designationSealResponseAPI.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DesignationSealListResponse designationSealResponse = JsonConvert.DeserializeObject<DesignationSealListResponse>(designationSealResponseJson);
                return designationSealResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }


        protected string GetDesignationSealListEndpoint()
        {
            return DefaultAPIConfiguration.GetDesignationSealListEndpoint;
        }
        protected string GetDakForwardEndpoint()
        {
            return DefaultAPIConfiguration.GetDakForwardEndpoint;
        }

        public DakForwardResponse GetDakForwardResponse(DakForwardRequestParam dakForwardParam)
        {
            try
            {

                var DakForwardApi = new RestClient(GetAPIDomain() + GetDakForwardEndpoint());
                DakForwardApi.Timeout = -1;
                var dakForwardRequest = new RestRequest(Method.POST);
                dakForwardRequest.AddHeader("api-version", GetOldAPIVersion());
                dakForwardRequest.AddHeader("Authorization", "Bearer " + dakForwardParam.token);
                dakForwardRequest.AlwaysMultipartFormData = true;
                dakForwardRequest.AddParameter("sender_info", dakForwardParam.sender_info);
                dakForwardRequest.AddParameter("receiver_info", dakForwardParam.receiver_info);
                dakForwardRequest.AddParameter("onulipi_info", dakForwardParam.onulipi_info);
                dakForwardRequest.AddParameter("dak_type", dakForwardParam.dak_type);
                dakForwardRequest.AddParameter("dak_id", dakForwardParam.dak_id);
                dakForwardRequest.AddParameter("priority", dakForwardParam.priority);
                dakForwardRequest.AddParameter("comment", dakForwardParam.comment);
                dakForwardRequest.AddParameter("security", dakForwardParam.security);
                dakForwardRequest.AddParameter("is_copied_dak", dakForwardParam.is_copied_dak);
            
                IRestResponse dakForwardResponseAPI = DakForwardApi.Execute(dakForwardRequest);


                var dakForwardResponseJson = dakForwardResponseAPI.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakForwardResponse dakForwardResponse = JsonConvert.DeserializeObject<DakForwardResponse>(dakForwardResponseJson);
                return dakForwardResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

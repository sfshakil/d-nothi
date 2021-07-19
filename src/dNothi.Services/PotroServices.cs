using dNothi.Constants;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.DakServices;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services
{
   public class PotroServices:IPotroServices
    {
        public PermittedPotroResponse GetPermittedPotro(DakUserParam dakUserParameter)
        {
            try
            {

                PermittedPotroResponse permittedPotroResponse = new PermittedPotroResponse();
                var permittedPotroAPI = new RestClient(GetAPIDomain() + GetPermittedPotroEndPointt());
                permittedPotroAPI.Timeout = -1;
                var PermittedPotroEndPointRequest = new RestRequest(Method.POST);
                PermittedPotroEndPointRequest.AddHeader("api-version", GetAPIVersion());
                PermittedPotroEndPointRequest.AddHeader("Authorization", "Bearer " + dakUserParameter.token);
                PermittedPotroEndPointRequest.AlwaysMultipartFormData = true;
                PermittedPotroEndPointRequest.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParameter.office_id + "\",\"office_unit_id\":\"" + dakUserParameter.office_unit_id + "\",\"designation_id\":\"" + dakUserParameter.designation_id + "\"}");
                PermittedPotroEndPointRequest.AddParameter("length", dakUserParameter.limit);
                PermittedPotroEndPointRequest.AddParameter("page", dakUserParameter.page);

                IRestResponse PermittedPotroEndPointResponse = permittedPotroAPI.Execute(PermittedPotroEndPointRequest);


                var permittedPotroResponseJson =ConversionMethod.FilterJsonResponse(PermittedPotroEndPointResponse.Content);
               
                permittedPotroResponse = JsonConvert.DeserializeObject<PermittedPotroResponse>(permittedPotroResponseJson);
                return permittedPotroResponse;
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
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetPermittedPotroEndPointt()
        {
            return DefaultAPIConfiguration.PermittedPotroEndPoint;
        }
    }

    public interface IPotroServices
    {
        PermittedPotroResponse GetPermittedPotro(DakUserParam dakUserParameter);
    }
}

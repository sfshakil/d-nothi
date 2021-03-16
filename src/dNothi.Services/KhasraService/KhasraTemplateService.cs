using dNothi.Constants;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.DakServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KhasraService
{
    public class KhasraTemplateService : IKhasraTemplateService
    {
        public KhasraPotroTemplateResponse GetKhosraTemplate(DakUserParam dakUserParameter)
        {
            try
            {


                var khasraTemplateAPI = new RestClient(GetAPIDomain() + GetKhosraTemplateEndpoint());
                khasraTemplateAPI.Timeout = -1;
                var khasraTemplateRequest = new RestRequest(Method.POST);
                khasraTemplateRequest.AddHeader("api-version", GetAPIVersion());
                khasraTemplateRequest.AddHeader("Authorization", "Bearer " + dakUserParameter.token);
                khasraTemplateRequest.AlwaysMultipartFormData = true;
                khasraTemplateRequest.AddParameter("cdesk", "{\"office_id\":\""+dakUserParameter.office_id+"\",\"office_unit_id\":\""+dakUserParameter.office_unit_id+"\",\"designation_id\":\""+dakUserParameter.designation_id+"\"}");
               
                IRestResponse khasraTemplateResponse = khasraTemplateAPI.Execute(khasraTemplateRequest);


                var khasraTemplateResponseJson = khasraTemplateResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                KhasraPotroTemplateResponse khasraPotroTemplateResponse = JsonConvert.DeserializeObject<KhasraPotroTemplateResponse>(khasraTemplateResponseJson);
                return khasraPotroTemplateResponse;
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

        protected string GetKhosraTemplateEndpoint()
        {
            return DefaultAPIConfiguration.KhosraTemplateEndpoint;
        }
    }

    public interface IKhasraTemplateService
    {
        KhasraPotroTemplateResponse GetKhosraTemplate(DakUserParam dakUserParameter);
       
    }
}

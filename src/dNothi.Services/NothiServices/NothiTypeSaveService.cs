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
    public class NothiTypeSaveService : INothiTypeSaveService
    {
        public NothiTypeSaveResponse GetNothiTypeList(DakUserParam dakUserParam, string nothiDhoron, string nothiDhoronCode)
        {
                try
                {
                    var client = new RestClient(GetAPIDomain() + GetNothiTypeCreateEndPoint());
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("api-version", GetAPIVersion());
                    request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                    request.AlwaysMultipartFormData = true;
                    request.AddParameter("office_id", +dakUserParam.office_id);
                    request.AddParameter("designation_id", +dakUserParam.designation_id);
                    request.AddParameter("model", "NothiTypes");
                    request.AddParameter("data", "{\"id\":0,\"type_name\":\""+nothiDhoron+"\",\"type_code\":\""+nothiDhoronCode+"\",\"type_last_number\":\"0\"}");
                    IRestResponse response = client.Execute(request);
                    Console.WriteLine(response.Content);

                    var responseJson = response.Content;
                    NothiTypeSaveResponse nothiTypeSaveResponse = JsonConvert.DeserializeObject<NothiTypeSaveResponse>(responseJson);
                    return nothiTypeSaveResponse;
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

            protected string GetNothiTypeCreateEndPoint()
            {
                return DefaultAPIConfiguration.NothiTypeCreateEndPoint;
            }
        
    }
}

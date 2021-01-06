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
    public class NothiCreateService : INothiCreateService
    {
        public NothiCreateResponse GetNothiCreate(DakUserParam UserParam, string nothishkha, string nothi_no, string nothi_type_id, string nothi_subject, string nothi_class,string currentYear)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiCreateEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + UserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", +UserParam.office_id);
                request.AddParameter("designation_id", +UserParam.designation_id);
                request.AddParameter("model", "NothiMasters");
                request.AddParameter("data", "{\"id\":\"0\",\"office_id\":\"" + UserParam.office_id + "\",\"office_name\":\"" + UserParam.officer_name + "\",\"office_unit_id\":\"" + UserParam.office_unit_id + "\",\"office_unit_name\":\"" + nothishkha + "\",\"office_unit_organogram_id\":\"" + UserParam.designation_id + "\",\"office_designation_name\":\"" + UserParam.designation + "\",\"nothi_type_id\":\"" + nothi_type_id + "\",\"nothi_no\":\"" + nothi_no + "\",\"subject\":\"" + nothi_subject + "\",\"description\":\"NULL\",\"nothi_class\":\"" + nothi_class + "\",\"nothi_created_date\":\"" + currentYear + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NothiCreateResponse nothiCreateResponse = JsonConvert.DeserializeObject<NothiCreateResponse>(responseJson);
                return nothiCreateResponse;
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
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        protected string GetNothiCreateEndPoint()
        {
            return DefaultAPIConfiguration.NothiCreateEndPoint;
        }

    }
}

using dNothi.Constants;

using dNothi.Services.BasicService.Models;
using dNothi.Services.DakServices;

using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.Services.BasicService
{
   public class BasicService : IBasicService
    {
        public OfficeUnit GetOfficeUnitList(DakUserParam userParam)
        {

            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + DefaultAPIConfiguration.OfficeUintEndpoint);
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
               
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("office_id", userParam.office_id);
               
              
                IRestResponse Response = Api.Execute(request);
                var responseJson = Response.Content;

                OfficeUnit potrojariGrouplist = JsonConvert.DeserializeObject<OfficeUnit>(responseJson, NullDeserializeSetting());
                return potrojariGrouplist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

      

        private JsonSerializerSettings NullDeserializeSetting()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return settings;
        }
       
    }
}

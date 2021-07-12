using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.PotroJariGroup.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.PotroJariGroup
{
   public class PotroJariGroupService : IPotroJariGroupService
    {
        public PotrojariGroupModel GetList(DakUserParam userParam, int menuNo)
        {

            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + ApiEndPoint.GetEndPoint(menuNo));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\"}");
                request.AddParameter("page", userParam.page);
                request.AddParameter("limit", userParam.limit);
                //if (!string.IsNullOrEmpty(userParam.NameSearchParam))
                //{
                //    request.AddParameter("search_params", "potro_subject="+ userParam.NameSearchParam + "");
                //}
              
                IRestResponse Response = Api.Execute(request);
                var responseJson = Response.Content;
              
                PotrojariGroupModel potrojariGrouplist = JsonConvert.DeserializeObject<PotrojariGroupModel>(responseJson, NullDeserializeSetting());
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

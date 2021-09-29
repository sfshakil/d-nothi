using dNothi.Constants;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Dak;
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

       public AllDakDownlodModel AllFileDownload(DakUserParam userParam, List<DakAttachmentDTO> attchmentDTos)
        {
            List<string> downloadurl = new List<string>();

            foreach (var item in attchmentDTos.Where(x=>x.is_main!=1).ToList())
            {
                string filedir = item.file_dir+"/" + item.file_name;
                
                downloadurl.Add(filedir);
            }
            string jsonstring = JsonParsingMethod.ObjecttoJson(downloadurl);
            string files = "{\"files\":"+jsonstring+",\"file_name\":\"DAK-3677\"}";
            // 
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + DefaultAPIConfiguration.AllFileDownloadEndpoint);
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                //request.AddParameter("designation_id", userParam.designation_id);
                //request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("zip_data", files);
               
                IRestResponse Response = Api.Execute(request);
                var responseJson = Response.Content;

                AllDakDownlodModel response = JsonConvert.DeserializeObject<AllDakDownlodModel>(responseJson, NullDeserializeSetting());
                return response;
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

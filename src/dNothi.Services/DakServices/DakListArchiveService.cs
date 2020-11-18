using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakListArchiveService : IDakListArchiveService
    {
        public DakListArchiveResponse GetDakList(DakListUserParam dakListUserParam)
        {
              try
            {
                var dakArchiveApi = new RestClient(dakListUserParam.api);
                dakArchiveApi.Timeout = -1;
                var dakArchiveRequest = new RestRequest(Method.POST);
                dakArchiveRequest.AddHeader("api-version", "2");
                dakArchiveRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakArchiveRequest.AlwaysMultipartFormData = true;
                dakArchiveRequest.AddParameter("designation_id", dakListUserParam.designationId);
                dakArchiveRequest.AddParameter("office_id", dakListUserParam.officeId);
                dakArchiveRequest.AddParameter("page", dakListUserParam.page);
                dakArchiveRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakArchiveResponse = dakArchiveApi.Execute(dakArchiveRequest);


                var dakArchiveResponseJson = dakArchiveResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListArchiveResponse dakListArchiveResponse = JsonConvert.DeserializeObject<DakListArchiveResponse>(dakArchiveResponseJson);
                return dakListArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

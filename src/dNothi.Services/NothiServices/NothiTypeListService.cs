using dNothi.JsonParser.Entity.Nothi;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiTypeListService : INothiTypeListServices
    {
        public NothiTypeListResponse GetNothiTypeList(string token)
        {
            try
            {
                var client = new RestClient("https://a2i.nothibs.tappware.com/api/nothi/type/list");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", "65");
                request.AddParameter("designation_id", "244930");
                request.AddParameter("nothi_type_id", "4");
                request.AddParameter("office_unit_id", "40372");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NothiTypeListResponse nothiTypeListResponse = JsonConvert.DeserializeObject<NothiTypeListResponse>(responseJson);
                return nothiTypeListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

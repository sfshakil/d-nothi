using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakNothivuktoService : IDakNothivuktoService
    {
        IRepository<DakNothivukto> _daknothivukto;
        IDakListService _dakListService { get; set; }
        public DakNothivuktoService(IRepository<DakNothivukto> daknothivukto, IDakListService dakListService)
        {
            _daknothivukto = daknothivukto;
            _dakListService = dakListService;
        }
        public DakListNothivuktoResponse GetNothivuktoDakList(DakListUserParam dakListUserParam)
        {
            try
            {
                var nothivuktoDakApi = new RestClient(dakListUserParam.api);
                nothivuktoDakApi.Timeout = -1;
                var nothivuktoDakRequest = new RestRequest(Method.POST);
                nothivuktoDakRequest.AddHeader("api-version", "2");
                nothivuktoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothivuktoDakRequest.AlwaysMultipartFormData = true;
                nothivuktoDakRequest.AddParameter("designation_id", dakListUserParam.designationId);
                nothivuktoDakRequest.AddParameter("office_id", dakListUserParam.officeId);
                nothivuktoDakRequest.AddParameter("page", dakListUserParam.page);
                nothivuktoDakRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse nothivuktoDakResponse = nothivuktoDakApi.Execute(nothivuktoDakRequest);


                var nothivuktoDakResponseJson = nothivuktoDakResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListNothivuktoResponse dakListNothivuktoResponse = JsonConvert.DeserializeObject<DakListNothivuktoResponse>(nothivuktoDakResponseJson);
                return dakListNothivuktoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakNothivukto(DakListNothivuktoResponse dakListNothivuktoResponse)
        {
            DakNothivukto dakNothivukto = new DakNothivukto();
            dakNothivukto.status = dakListNothivuktoResponse.status;
            dakNothivukto.dak_list_record_id = _dakListService.SaveOrUpdateDakInbox(dakListNothivuktoResponse.data);

            var dbdakNothivukto = _daknothivukto.Table.FirstOrDefault();
            if (dbdakNothivukto != null)
            {
                _daknothivukto.Delete(dbdakNothivukto);
            }

            try
            {
                _daknothivukto.Insert(dakNothivukto);
            }
            catch
            {

            }
        }
    }
}

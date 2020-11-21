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
    public class DakNothijatoService : IDakNothijatoService
    {
        IRepository<DakNothijato> _dakNothijato;
        IDakListService _dakListService { get; set; }
        public DakNothijatoService(IRepository<DakNothijato> dakNothijato, IDakListService dakListService)
        {
            _dakNothijato = dakNothijato;
            _dakListService = dakListService;
        }
        public DakListNothijatoResponse GetNothijatoDak(DakListUserParam dakListUserParam)
        {
            try
            {
                var nothijatoDakApi = new RestClient(dakListUserParam.api);
                nothijatoDakApi.Timeout = -1;
                var nothijatoDakRequest = new RestRequest(Method.POST);
                nothijatoDakRequest.AddHeader("api-version", "2");
                nothijatoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothijatoDakRequest.AlwaysMultipartFormData = true;
                nothijatoDakRequest.AddParameter("designation_id", dakListUserParam.designationId);
                nothijatoDakRequest.AddParameter("office_id", dakListUserParam.officeId);
                nothijatoDakRequest.AddParameter("page", dakListUserParam.page);
                nothijatoDakRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse nothijatoDakResponse = nothijatoDakApi.Execute(nothijatoDakRequest);


                var nothijatoDakResponseJson = nothijatoDakResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListNothijatoResponse dakListNothijatoResponse = JsonConvert.DeserializeObject<DakListNothijatoResponse>(nothijatoDakResponseJson);
                return dakListNothijatoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakNothijato(DakListNothijatoResponse dakListNothijatoResponse)
        {
            DakNothijato dakNothijato = new DakNothijato();
            dakNothijato.status = dakListNothijatoResponse.status;
            dakNothijato.dak_list_record_id = _dakListService.SaveOrUpdateDakInbox(dakListNothijatoResponse.data);

            var dbdakNothijato = _dakNothijato.Table.FirstOrDefault();
            if (dbdakNothijato != null)
            {
                _dakNothijato.Delete(dbdakNothijato);
            }

            try
            {
                _dakNothijato.Insert(dakNothijato);
            }
            catch
            {

            }
        }
    }
}

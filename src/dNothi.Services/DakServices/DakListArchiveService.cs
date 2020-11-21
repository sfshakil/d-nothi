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
    public class DakListArchiveService : IDakListArchiveService
    {
        IRepository<DakArchive> _dakarchive;
        IDakListService _dakListService { get; set; }
        public DakListArchiveService(IRepository<DakArchive> dakarchive, IDakListService dakListService)
        {
            _dakarchive = dakarchive;
            _dakListService = dakListService;
        }
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

        public void SaveorUpdateDakArchive(DakListArchiveResponse dakListArchiveResponse)
        {
            DakArchive dakArchive = new DakArchive();
            dakArchive.status = dakListArchiveResponse.status;
            dakArchive.dak_list_record_id = _dakListService.SaveOrUpdateDakInbox(dakListArchiveResponse.data);

            var dbdakArchive = _dakarchive.Table.FirstOrDefault();
            if (dbdakArchive != null)
            {
                _dakarchive.Delete(dbdakArchive);
            }

            try
            {
                _dakarchive.Insert(dakArchive);
            }
            catch
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.Services.UserServices;
using Newtonsoft.Json;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using RestSharp;
using dNothi.Core.Entities;

namespace dNothi.Services.DakServices
{
   public class DakOutboxService : IDakOutboxService
    {
        IRepository<DakOutbox> _dakOutbox;
        IDakListService _dakListService { get; set; }
        public DakOutboxService(IRepository<DakOutbox> dakOutbox, IDakListService dakListService)
        {
            this._dakOutbox = dakOutbox;
            _dakListService = dakListService;
        }

        public DakListOutboxResponse GetDakOutbox(DakListUserParam dakListUserParam)
        {
            try
            {
                var dakOutboxApi = new RestClient(dakListUserParam.api);
                dakOutboxApi.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "2");
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", dakListUserParam.designationId);
                request.AddParameter("office_id", dakListUserParam.officeId);
                request.AddParameter("page", dakListUserParam.page);
                request.AddParameter("limit", dakListUserParam.limit);
                IRestResponse Response = dakOutboxApi.Execute(request);


                var responseJson = Response.Content;
                DakListOutboxResponse dakListOutboxResponse = JsonConvert.DeserializeObject<DakListOutboxResponse>(responseJson);
                return dakListOutboxResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakOutbox(DakListOutboxResponse dakListOutboxResponse)
        {
            DakOutbox dakOutbox = new DakOutbox();
            dakOutbox.status = dakListOutboxResponse.status;
            dakOutbox.dak_list_record_id = _dakListService.SaveOrUpdateDakInbox(dakListOutboxResponse.data);

            var dbdakOutbox = _dakOutbox.Table.FirstOrDefault();
            if (dbdakOutbox != null)
            {
                _dakOutbox.Delete(dbdakOutbox);
            }

            try
            {
                _dakOutbox.Insert(dakOutbox);
            }
            catch
            {

            }

        }
    }
}

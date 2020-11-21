using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using dNothi.Core.Interfaces;
using Newtonsoft.Json;
using dNothi.Core.Entities;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using RestSharp;
using System.Data.Entity;

namespace dNothi.Services.DakServices
{
    public class DakInboxService : IDakInboxServices
    {
        IRepository<DakInbox> _dakInbox;
        IDakListService _dakListService { get; set; }

        public DakInboxService(IRepository<DakInbox> dakInbox, IDakListService dakListService)
        {
            _dakInbox = dakInbox;
            _dakListService = dakListService;
        }
        public DakListInboxResponse GetDakInbox(DakListUserParam dakListUserParam)
        {
            try
            {
                var dakInboxApi = new RestClient(dakListUserParam.api);
                dakInboxApi.Timeout = -1;
                var dakInboxRequest = new RestRequest(Method.POST);
                dakInboxRequest.AddHeader("api-version", "2");
                dakInboxRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakInboxRequest.AlwaysMultipartFormData = true;
                dakInboxRequest.AddParameter("designation_id", dakListUserParam.designationId);
                dakInboxRequest.AddParameter("office_id", dakListUserParam.officeId);
                dakInboxRequest.AddParameter("page", dakListUserParam.page);
                dakInboxRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakInboxResponse = dakInboxApi.Execute(dakInboxRequest);


                var dakInboxResponseJson = dakInboxResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListInboxResponse dakListInboxResponse = JsonConvert.DeserializeObject<DakListInboxResponse>(dakInboxResponseJson);
                return dakListInboxResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakInbox(DakListInboxResponse dakListInboxResponse)
        {


            DakInbox castDakInbox = new DakInbox();
            castDakInbox.status = dakListInboxResponse.status;
            castDakInbox.dak_list_record_id = _dakListService.SaveOrUpdateDakInbox(dakListInboxResponse.data);
           
            var dbdakInbox = _dakInbox.Table.FirstOrDefault();
            if (dbdakInbox != null)
            {
                _dakInbox.Delete(dbdakInbox);
            }

            try
            {
                _dakInbox.Insert(castDakInbox);
            }
            catch
            {

            }



           
        }

        public DakListInboxResponse GetLocalDakInbox()
        {
            var dbdakInbox = _dakInbox.Table.Include(a=>a.data.records).Include(a=>a.data.records).FirstOrDefault();

            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<DakInbox, DakListInboxResponse>()
                 );
            var mapper = new Mapper(config);
            var dakInboxListResponse = mapper.Map<DakListInboxResponse>(dbdakInbox);

            return dakInboxListResponse;
        }
    }
}

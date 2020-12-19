using AutoMapper;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
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
    public class NothiInboxService : INothiInboxServices
    {
        IRepository<NothiListRecords> _nothiListRecords;
        public NothiInboxService(IRepository<NothiListRecords> nothiListRecords)
        {
            this._nothiListRecords = nothiListRecords;
        }
        public NothiListInboxResponse GetNothiInbox(string token)
        {
            try
            {
                var client = new RestClient("https://dev.nothibs.tappware.com/api/nothi/list/inbox");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("length", "10");
                request.AddParameter("page", "1");
                request.AddParameter("cdesk", "{\"office_id\": 65,\n  \"office_unit_id\": 40372,\n  \"designation_id\": 244930,\n  \"officer_id\": 77858,\n  \"user_id\": 3923}");

                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NothiListInboxResponse dakListInboxResponse = JsonConvert.DeserializeObject<NothiListInboxResponse>(responseJson);
                return dakListInboxResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveOrUpdateNothiRecords(List<NothiListRecordsDTO> nothi_list_records)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<NothiListRecordsDTO, NothiListRecords>()
                );
            var mapper = new Mapper(config);
            
            foreach (var nothi_list_record in nothi_list_records)
            {
                var nothilist = mapper.Map<NothiListRecords>(nothi_list_record);
                var dbnothilist = _nothiListRecords.Table.Where(q => q.Id == nothi_list_record.id).FirstOrDefault();
                if (dbnothilist == null)
                {
                    _nothiListRecords.Insert(nothilist);
                }
                else
                {
                    _nothiListRecords.Update(nothilist);
                }
            }
        }
    }
}

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

namespace dNothi.Services.DakServices
{
    public class DakInboxService : IDakInboxServices
    {
        IRepository<DakTag> _daktags;
        IRepository<DakUser> _dakuser;
        public DakInboxService(IRepository<DakTag> daktags, IRepository<DakUser> dakuser)
        {
            this._daktags = daktags;
            this._dakuser = dakuser;
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

        public void SaveOrUpdateDakTag(DakTagDTO dak_Tagsdto)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<DakTagDTO, DakTag>()
                );
            var mapper = new Mapper(config);
            var daktag = mapper.Map<DakTag>(dak_Tagsdto);
            var dbdaktag = _daktags.Table.Where(q => q.Id == dak_Tagsdto.id).FirstOrDefault();
            if (dbdaktag == null)
            {
                _daktags.Insert(daktag);
            }
            else
            {
                _daktags.Update(daktag);
            }
        }

        public void SaveOrUpdateDakUser(DakUserDTO dak_Userdto)
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<DakUserDTO, DakUser>()
                 );
            var mapper = new Mapper(config);
            var daktuser = mapper.Map<DakUser>(dak_Userdto);
            var dbdaktuser = _dakuser.Table.Where(q => q.dak_id == dak_Userdto.dak_id).FirstOrDefault();
            if (dbdaktuser == null)
            {
                _dakuser.Insert(daktuser);
            }
            else
            {
                _dakuser.Update(daktuser);
            }
        }
    }
}

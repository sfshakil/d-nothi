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
                var request2 = new RestRequest(Method.POST);
                request2.AddHeader("api-version", "2");
                request2.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request2.AlwaysMultipartFormData = true;
                request2.AddParameter("designation_id", dakListUserParam.designationId);
                request2.AddParameter("office_id", dakListUserParam.officeId);
                request2.AddParameter("page", dakListUserParam.page);
                request2.AddParameter("limit", dakListUserParam.limit);
                IRestResponse tResponse2 = dakInboxApi.Execute(request2);


                var responseJson2 = tResponse2.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListInboxResponse dakListInboxResponse = JsonConvert.DeserializeObject<DakListInboxResponse>(responseJson2);
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

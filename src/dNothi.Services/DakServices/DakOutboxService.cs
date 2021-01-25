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
using dNothi.Constants;
using System.Configuration;

namespace dNothi.Services.DakServices
{
   public class DakOutboxService : IDakOutboxService
    {
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakOutboxService(IRepository<DakType> daktype, IDakListService dakListService)
        {
            this._daktype = daktype;
            _dakListService = dakListService;
        }

        public DakListOutboxResponse GetDakOutbox(DakUserParam dakListUserParam)
        {
            try
            {
                var dakOutboxApi = new RestClient(GetAPIDomain()+GetDakOutboxEndpoint());
                dakOutboxApi.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version",GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", dakListUserParam.designation_id);
                request.AddParameter("office_id", dakListUserParam.office_id);
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
            DakType dakType = new DakType();
            dakType.is_outbox = true;
            if (dakListOutboxResponse.data != null)
            {
                dakType.total_records = dakListOutboxResponse.data.total_records;

            }

            var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_outbox == true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }

            _dakListService.SaveOrUpdateDakList(dakListOutboxResponse.data, dakType.Id);

        }

        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        

        protected string GetDakOutboxEndpoint()
        {
            return DefaultAPIConfiguration.DakListOutboxEndPoint;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public DakListOutboxResponse GetDakOutbox(DakUserParam dakListUserParam, string searchParam)
        {
            try
            {
                var dakOutboxApi = new RestClient(GetAPIDomain() + GetDakOutboxEndpoint());
                dakOutboxApi.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", dakListUserParam.designation_id);
                request.AddParameter("office_id", dakListUserParam.office_id);
                request.AddParameter("page", dakListUserParam.page);
                request.AddParameter("limit", dakListUserParam.limit);
                request.AddParameter("search_params", searchParam);
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
    }
}

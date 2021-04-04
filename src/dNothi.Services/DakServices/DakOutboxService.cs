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
using dNothi.Utility;

namespace dNothi.Services.DakServices
{
   public class DakOutboxService : IDakOutboxService
    {
        IRepository<Core.Entities.DakType> _daktype;
        IRepository<DakItem> _dakItem;
        IDakListService _dakListService { get; set; }
        public DakOutboxService(IRepository<Core.Entities.DakType> daktype, IRepository<DakItem> dakItem, IDakListService dakListService)
        {
            this._dakItem = dakItem;
            this._daktype = daktype;
            _dakListService = dakListService;
        }

        public DakListOutboxResponse GetDakOutbox(DakUserParam dakListUserParam)
        {
            DakListOutboxResponse dakListOutboxResponse = new DakListOutboxResponse();
            if (!InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_outbox == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if(dakList !=null)
                {
                    dakListOutboxResponse = JsonConvert.DeserializeObject<DakListOutboxResponse>(dakList.jsonResponse);

                }
                return dakListOutboxResponse;
            }



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

                SaveOrUpdateDakOutBoxListJsonResponse(dakListUserParam, responseJson);
                
                dakListOutboxResponse = JsonConvert.DeserializeObject<DakListOutboxResponse>(responseJson);
                return dakListOutboxResponse;



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SaveOrUpdateDakOutBoxListJsonResponse(DakUserParam dakListUserParam, string responseJson)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_outbox == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_outbox = true;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }

        public void SaveorUpdateDakOutbox(DakListOutboxResponse dakListOutboxResponse)
        {
            Core.Entities.DakType dakType = new Core.Entities.DakType();
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

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
using dNothi.Constants;
using System.Configuration;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Services.DakServices
{
    public class DakInboxService : IDakInboxServices
    {
        IRepository<DakType> _daktype;
        IRepository<DakItem> _dakItem;
        IRepository<DakList> _daklist;
       
        IDakListService _dakListService { get; set; }

        

        public DakInboxService(IRepository<DakItem> dakItem,IRepository<DakType> daktype, IRepository<DakList> daklist,IDakListService dakListService)
        {
            _daktype = daktype;
            _daklist = daklist;
            _dakItem = dakItem;
            _dakListService = dakListService;
        }

        private void SaveOrUpdateDakOutBoxListJsonResponse(DakUserParam dakListUserParam, string responseJson)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_inbox == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_inbox = true;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }


        public DakListInboxResponse GetDakInbox(DakUserParam dakListUserParam)
        {

            DakListInboxResponse dakListInboxResponse = new DakListInboxResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_inbox == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListInboxResponse = JsonConvert.DeserializeObject<DakListInboxResponse>(dakList.jsonResponse);

                }
                return dakListInboxResponse;
            }

            try
            {

              
                var dakInboxApi = new RestClient(GetAPIDomain()+GetDakListInboxEndpoint());
                dakInboxApi.Timeout = -1;
                var dakInboxRequest = new RestRequest(Method.POST);
                dakInboxRequest.AddHeader("api-version", GetAPIVersion());
                dakInboxRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakInboxRequest.AlwaysMultipartFormData = true;
                dakInboxRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakInboxRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakInboxRequest.AddParameter("page", dakListUserParam.page);
                dakInboxRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakInboxResponse = dakInboxApi.Execute(dakInboxRequest);


                var dakInboxResponseJson = dakInboxResponse.Content;
                SaveOrUpdateDakOutBoxListJsonResponse(dakListUserParam, dakInboxResponseJson);
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                dakListInboxResponse = JsonConvert.DeserializeObject<DakListInboxResponse>(dakInboxResponseJson);
                return dakListInboxResponse;
            }
            catch (Exception ex)
            {
                return dakListInboxResponse;
            }
        }
        public DakListInboxResponse GetDakInbox(DakUserParam dakListUserParam, string searchParam)
        {
            try
            {


                var dakInboxApi = new RestClient(GetAPIDomain() + GetDakListInboxEndpoint());
                dakInboxApi.Timeout = -1;
                var dakInboxRequest = new RestRequest(Method.POST);
                dakInboxRequest.AddHeader("api-version", GetAPIVersion());
                dakInboxRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakInboxRequest.AlwaysMultipartFormData = true;
                dakInboxRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakInboxRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakInboxRequest.AddParameter("page", dakListUserParam.page);
                dakInboxRequest.AddParameter("limit", dakListUserParam.limit);
                dakInboxRequest.AddParameter("search_params", searchParam);
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


            DakType dakType = new DakType();
            dakType.is_inbox = true;
           if(dakListInboxResponse.data != null)
            {
                dakType.total_records = dakListInboxResponse.data.total_records;
                
            }

            var dbdakType = _daktype.Table.FirstOrDefault(a=>a.is_inbox==true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }
          
            _dakListService.SaveOrUpdateDakList(dakListInboxResponse.data,dakType.Id);


           
        }

        public DakListInboxResponse GetLocalDakInbox(DakUserParam dakListUserParam)
        {
            var dbdakInbox = _daktype.Table.FirstOrDefault(a=>a.is_inbox==true);

           
            DakListInboxResponse dakListInboxResponse = new DakListInboxResponse();
            if(dbdakInbox != null)
            {
                DakListDTO dakListDTO = new DakListDTO();
                dakListDTO.total_records = dbdakInbox.total_records;
                dakListInboxResponse.data = dakListDTO;
                dakListInboxResponse.data = _dakListService.GetLocalDakListbyType(dbdakInbox.Id, dakListUserParam);
            }
            
            
           
            return dakListInboxResponse;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetDakListInboxEndpoint()
        {
            return DefaultAPIConfiguration.DakListInboxEndPoint;
        }
    }
}

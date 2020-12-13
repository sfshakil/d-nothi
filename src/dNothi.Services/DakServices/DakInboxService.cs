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

namespace dNothi.Services.DakServices
{
    public class DakInboxService : IDakInboxServices
    {
        IRepository<DakType> _daktype;
        IRepository<DakList> _daklist;
       
        IDakListService _dakListService { get; set; }

        public DakInboxService(IRepository<DakType> daktype, IRepository<DakList> daklist,IDakListService dakListService)
        {
            _daktype = daktype;
            _daklist = daklist;
            _dakListService = dakListService;
        }
        public DakListInboxResponse GetDakInbox(DakListUserParam dakListUserParam)
        {
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

        public DakListInboxResponse GetLocalDakInbox(DakListUserParam dakListUserParam)
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

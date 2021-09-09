using AutoMapper;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiInboxService : INothiInboxServices
    {
        IRepository<NothiListRecords> _nothiListRecords;
        IRepository<NothiItem> _nothiItem;
        public NothiInboxService(IRepository<NothiListRecords> nothiListRecords, IRepository<NothiItem> nothiItem)
        {
            this._nothiListRecords = nothiListRecords;
            _nothiItem = nothiItem;
        }

        public NothiListInboxResponse GetNothiInbox(DakUserParam dakUserParam)
        {
            NothiListInboxResponse nothiListInboxResponse = new NothiListInboxResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.page == dakUserParam.page && a.is_nothi_inbox == true && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    nothiListInboxResponse = JsonConvert.DeserializeObject<NothiListInboxResponse>(nothiList.jsonResponse);

                }
                return nothiListInboxResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiInboxListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);
                IRestResponse response = client.Execute(request);


                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, responseJson);
                nothiListInboxResponse = JsonConvert.DeserializeObject<NothiListInboxResponse>(responseJson);
                return nothiListInboxResponse;
            }
            catch (Exception ex)
            {
                return nothiListInboxResponse;
            }
        }
        public NothiListInboxResponse GetSearchNothiInbox(DakUserParam dakUserParam, string search_params)
        {
            NothiListInboxResponse nothiListInboxResponse = new NothiListInboxResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiInboxListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);
                request.AddParameter("search_params", search_params);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                nothiListInboxResponse = JsonConvert.DeserializeObject<NothiListInboxResponse>(responseJson);
                return nothiListInboxResponse;
            }
            catch (Exception ex)
            {
                return nothiListInboxResponse;
            }
        }
        public class cdesk
        {
            public int office_id { get; set; }
            public int office_unit_id { get; set; }
            public int designation_id { get; set; }
            public int officer_id { get; set; }
            public int user_id { get; set; }
        }

        public void SaveOrUpdateNothiRecords(DakUserParam dakListUserParam, string responseJson)
        {
            NothiItem nothiItemDB = _nothiItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_nothi_inbox == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiItemDB != null)
            {
                nothiItemDB.jsonResponse = responseJson;
                _nothiItem.Update(nothiItemDB);
            }
            else
            {
                NothiItem nothiItem = new NothiItem();
                nothiItem.is_nothi_inbox = true;
                nothiItem.page = dakListUserParam.page;
                nothiItem.designation_id = dakListUserParam.designation_id;
                nothiItem.office_id = dakListUserParam.office_id;
                nothiItem.jsonResponse = responseJson;
                _nothiItem.Insert(nothiItem);

            }
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetNothiInboxListEndpoint()
        {
            return DefaultAPIConfiguration.NothiInboxListEndPoint;
        }
        protected string GetOtherOfficeNothiInboxListEndPoint()
        {
            return DefaultAPIConfiguration.OtherOfficeNothiInboxListEndPoint;
        }

        public OthersOfficeNothiListInboxResponse GetOthersOfficeNothiInbox(DakUserParam dakUserParam, string search_params)
        {
            OthersOfficeNothiListInboxResponse nothiListInboxResponse = new OthersOfficeNothiListInboxResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetOtherOfficeNothiInboxListEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);
                request.AddParameter("search_params", search_params);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                nothiListInboxResponse = JsonConvert.DeserializeObject<OthersOfficeNothiListInboxResponse>(responseJson);
                return nothiListInboxResponse;
            }
            catch (Exception ex)
            {
                return nothiListInboxResponse;
            }
        }
    }
}

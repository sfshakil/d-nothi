using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiOutboxService : INothiOutboxServices
    {
        IRepository<NothiItem> _nothiItem;
        IRepository<NothiInboxSearchItem> _nothiInboxSearchItem;
        public NothiOutboxService(IRepository<NothiItem> nothiItem, IRepository<NothiInboxSearchItem> nothiInboxSearchItem)
        {
            _nothiInboxSearchItem = nothiInboxSearchItem;
            _nothiItem = nothiItem;
        }
        public NothiListOutboxResponse GetNothiOutbox(DakUserParam dakUserParam)
        {
            NothiListOutboxResponse nothiListOutboxResponse = new NothiListOutboxResponse();

            if (!InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.page == dakUserParam.page && a.is_nothi_outbox == true && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    nothiListOutboxResponse = JsonConvert.DeserializeObject<NothiListOutboxResponse>(nothiList.jsonResponse);

                }
                return nothiListOutboxResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiOutboxListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                SaveOrUpdateNothiRecords(dakUserParam, responseJson);
                nothiListOutboxResponse = JsonConvert.DeserializeObject<NothiListOutboxResponse>(responseJson);
                return nothiListOutboxResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakListUserParam, string responseJson)
        {
            NothiItem nothiItemDB = _nothiItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_nothi_outbox == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiItemDB != null)
            {
                nothiItemDB.jsonResponse = responseJson;
                _nothiItem.Update(nothiItemDB);
            }
            else
            {
                NothiItem nothiItem = new NothiItem();
                nothiItem.is_nothi_outbox = true;
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

        protected string GetNothiOutboxListEndpoint()
        {
            return DefaultAPIConfiguration.NothiOutboxListEndPoint;
        }
        protected string GetOtherOfficeNothiOutboxListEndPoint()
        {
            return DefaultAPIConfiguration.OtherOfficeNothiOutboxListEndPoint;
        }

        public NothiListOutboxResponse GetNothiOutbox(DakUserParam dakUserParam, string search_params)
        {
            NothiListOutboxResponse nothiListOutboxResponse = new NothiListOutboxResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiInboxSearch = _nothiInboxSearchItem.Table.FirstOrDefault(a => a.Search_param == search_params && a.is_nothi_outbox == true && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiInboxSearch != null)
                {
                    nothiListOutboxResponse = JsonConvert.DeserializeObject<NothiListOutboxResponse>(nothiInboxSearch.json_response_outbox);

                }
                return nothiListOutboxResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiOutboxListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                request.AddParameter("search_params", search_params);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                SaveOrUpdateNothiOutboxSearch(dakUserParam, search_params, responseJson);
                nothiListOutboxResponse = JsonConvert.DeserializeObject<NothiListOutboxResponse>(responseJson);
                return nothiListOutboxResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiOutboxSearch(DakUserParam dakListUserParam, string search_param, string responseJson)
        {
            var nothiInboxSearchDB = _nothiInboxSearchItem.Table.FirstOrDefault(a => a.Search_param == search_param && a.is_nothi_outbox == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiInboxSearchDB != null)
            {
                nothiInboxSearchDB.json_response_outbox = responseJson;
                _nothiInboxSearchItem.Update(nothiInboxSearchDB);
            }
            else
            {
                NothiInboxSearchItem nothiInboxSearchItem = new NothiInboxSearchItem();
                nothiInboxSearchItem.Search_param = search_param;
                nothiInboxSearchItem.is_nothi_outbox = true;
                nothiInboxSearchItem.designation_id = dakListUserParam.designation_id;
                nothiInboxSearchItem.office_id = dakListUserParam.office_id;
                nothiInboxSearchItem.json_response_outbox = responseJson;
                _nothiInboxSearchItem.Insert(nothiInboxSearchItem);

            }
        }
        public OtherOfficeNothiListOutboxResponse OtherOfficeNothiOutboxListEndPoint(DakUserParam dakUserParam, string search_params)
        {
            OtherOfficeNothiListOutboxResponse nothiListOutboxResponse = new OtherOfficeNothiListOutboxResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetOtherOfficeNothiOutboxListEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                request.AddParameter("search_params", search_params);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                //responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                nothiListOutboxResponse = JsonConvert.DeserializeObject<OtherOfficeNothiListOutboxResponse>(responseJson);
                return nothiListOutboxResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

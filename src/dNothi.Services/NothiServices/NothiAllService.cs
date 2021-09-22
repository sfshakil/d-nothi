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
using System.Web.Script.Serialization;

namespace dNothi.Services.NothiServices
{
    public class NothiAllService : INothiAllServices
    {
        IRepository<NothiItem> _nothiItem;
        IRepository<NothiInboxSearchItem> _nothiInboxSearchItem;
        public NothiAllService(IRepository<NothiItem> nothiItem, IRepository<NothiInboxSearchItem> nothiInboxSearchItem)
        {
            _nothiItem = nothiItem;
            _nothiInboxSearchItem = nothiInboxSearchItem;
        }
        public NothiListAllResponse GetNothiAll(DakUserParam dakUserParam)
        {
            NothiListAllResponse nothiListAllResponse = new NothiListAllResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.page == dakUserParam.page && a.is_nothi_all == true && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    nothiListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(nothiList.jsonResponse);

                }
                return nothiListAllResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiAllListEndpoint());
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
                SaveOrUpdateNothiRecords(dakUserParam, responseJson);
                nothiListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(responseJson);
                return nothiListAllResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakListUserParam, string responseJson)
        {
            NothiItem nothiItemDB = _nothiItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_nothi_all == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiItemDB != null)
            {
                nothiItemDB.jsonResponse = responseJson;
                _nothiItem.Update(nothiItemDB);
            }
            else
            {
                NothiItem nothiItem = new NothiItem();
                nothiItem.is_nothi_all = true;
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

        protected string GetNothiAllListEndpoint()
        {
            return DefaultAPIConfiguration.NothiAllListEndPoint;
        }
        protected string GetNothiInformationEndpoint()
        {
            return DefaultAPIConfiguration.NothiInformationEndpoint;
        }

        public NothiListAllResponse GetNothiAllByUser(DakUserParam dakUserParam)
        {


            try
            {
                var client = new RestClient("https://dev.nothibs.tappware.com/api/nothi/list/all");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

               

                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "24");
                request.AddParameter("page", "1");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NothiListAllResponse dakListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(responseJson);
                return dakListAllResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiListAllResponse GetNothiAll(DakUserParam dakUserParam, string search_params)
        {
            NothiListAllResponse nothiListAllResponse = new NothiListAllResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiInboxSearch = _nothiInboxSearchItem.Table.FirstOrDefault(a => a.Search_param == search_params && a.is_nothi_all == true && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiInboxSearch != null)
                {
                    nothiListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(nothiInboxSearch.json_response_all);

                }
                return nothiListAllResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiAllListEndpoint());
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
                SaveOrUpdateNothiAllSearch(dakUserParam, search_params, responseJson);
                nothiListAllResponse = JsonConvert.DeserializeObject<NothiListAllResponse>(responseJson);
                return nothiListAllResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiAllSearch(DakUserParam dakListUserParam, string search_param, string responseJson)
        {
            var nothiInboxSearchDB = _nothiInboxSearchItem.Table.FirstOrDefault(a => a.Search_param == search_param && a.is_nothi_all == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiInboxSearchDB != null)
            {
                nothiInboxSearchDB.json_response_all = responseJson;
                _nothiInboxSearchItem.Update(nothiInboxSearchDB);
            }
            else
            {
                NothiInboxSearchItem nothiInboxSearchItem = new NothiInboxSearchItem();
                nothiInboxSearchItem.Search_param = search_param;
                nothiInboxSearchItem.is_nothi_all = true;
                nothiInboxSearchItem.designation_id = dakListUserParam.designation_id;
                nothiInboxSearchItem.office_id = dakListUserParam.office_id;
                nothiInboxSearchItem.json_response_all = responseJson;
                _nothiInboxSearchItem.Insert(nothiInboxSearchItem);

            }
        }
        public NothiInformationResponse GetNothiInformation(DakUserParam dakUserParam, long nothi_id)
        {
            NothiInformationResponse nothiInformationResponse = new NothiInformationResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiInformationEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", dakUserParam.designation_id);
                request.AddParameter("office_id", dakUserParam.office_id);
                request.AddParameter("nothi_id", nothi_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                nothiInformationResponse = JsonConvert.DeserializeObject<NothiInformationResponse>(responseJson);
                return nothiInformationResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

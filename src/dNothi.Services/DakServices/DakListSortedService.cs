using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakListSortedService : IDakListSortedService
    {
        IRepository<DakItem> _dakItem;
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakListSortedService(IRepository<DakItem> dakItem, IRepository<DakType> daktype, IDakListService dakListService)
        {
            _daktype = daktype;
            _dakItem = dakItem;
            _dakListService = dakListService;
        }

        private void SaveOrUpdateDakSortedListJsonResponse(DakUserParam dakListUserParam, string responseJson, string searchParam)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_sorted_Search == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.searchParameter == searchParam);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_sorted_Search = true;
                dakItem.searchParameter = searchParam;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }


        private void SaveOrUpdateDakOutBoxListJsonResponse(DakUserParam dakListUserParam, string responseJson)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_sorted == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_sorted = true;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }
        public DakListSortedResponse GetDakList(DakUserParam dakListUserParam)
        {
            DakListSortedResponse dakListSortedResponse = new DakListSortedResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_sorted == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListSortedResponse = JsonConvert.DeserializeObject<DakListSortedResponse>(dakList.jsonResponse);

                }
                return dakListSortedResponse;
            }
            try
            {
                var dakSortedApi = new RestClient(GetAPIDomain() + GetDakListSortedEndpoint());
                dakSortedApi.Timeout = -1;
                var dakSortedRequest = new RestRequest(Method.POST);
                dakSortedRequest.AddHeader("api-version", GetAPIVersion());
                dakSortedRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakSortedRequest.AlwaysMultipartFormData = true;
                dakSortedRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakSortedRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakSortedRequest.AddParameter("page", dakListUserParam.page);
                dakSortedRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakSortedResponse = dakSortedApi.Execute(dakSortedRequest);


                var dakSortedResponseJson = dakSortedResponse.Content;
                SaveOrUpdateDakOutBoxListJsonResponse(dakListUserParam, dakSortedResponseJson);

                dakListSortedResponse = JsonConvert.DeserializeObject<DakListSortedResponse>(dakSortedResponseJson);
                return dakListSortedResponse;
            }
            catch (Exception ex)
            {
                return dakListSortedResponse;
            }
        }

        public void SaveorUpdateDakSorted(DakListSortedResponse dakListArchiveResponse)
        {

              DakType dakType = new DakType();
                dakType.is_outbox = true;
                if (dakListArchiveResponse.data != null)
                {
                    dakType.total_records = dakListArchiveResponse.data.total_records;

                }

                var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_sorted == true);
                if (dbdakType != null)
                {
                    dakType.Id = dbdakType.Id;
                    _daktype.Update(dakType);
                }
                else
                {
                    _daktype.Insert(dakType);
                }

                _dakListService.SaveOrUpdateDakList(dakListArchiveResponse.data, dakType.Id);

            
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

        protected string GetDakListSortedEndpoint()
        {
            return DefaultAPIConfiguration.DakListSortedEndPoint;
        }

        public DakListSortedResponse GetDakList(DakUserParam dakListUserParam, string searchParam)
        {
            DakListSortedResponse dakListSortedResponse = new DakListSortedResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_sorted_Search == true && a.searchParameter==searchParam && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListSortedResponse = JsonConvert.DeserializeObject<DakListSortedResponse>(dakList.jsonResponse);

                }
                return dakListSortedResponse;
            }

            try
            {
                var dakSortedApi = new RestClient(GetAPIDomain() + GetDakListSortedEndpoint());
                dakSortedApi.Timeout = -1;
                var dakSortedRequest = new RestRequest(Method.POST);
                dakSortedRequest.AddHeader("api-version", GetAPIVersion());
                dakSortedRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakSortedRequest.AlwaysMultipartFormData = true;
                dakSortedRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakSortedRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakSortedRequest.AddParameter("page", dakListUserParam.page);
                dakSortedRequest.AddParameter("limit", dakListUserParam.limit);
                dakSortedRequest.AddParameter("search_params", searchParam);
                IRestResponse dakSortedResponse = dakSortedApi.Execute(dakSortedRequest);


                var dakSortedResponseJson = dakSortedResponse.Content;
                SaveOrUpdateDakSortedListJsonResponse(dakListUserParam, dakSortedResponseJson, searchParam);
                dakListSortedResponse = JsonConvert.DeserializeObject<DakListSortedResponse>(dakSortedResponseJson);
                return dakListSortedResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakSearchService : IDakSearchService
    {
        IRepository<DakItem> _dakItem;
        public DakSearchService(IRepository<DakItem> dakItem)
        {
           
            _dakItem = dakItem;
          
        }

        private void SaveOrUpdateDakAllListJsonResponse(DakUserParam dakListUserParam, string responseJson, string searchParam)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_All_Search == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.searchParameter == searchParam);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_All_Search = true;
                dakItem.searchParameter = searchParam;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }

        public DakSearchResponse GetDakSearchDetailsResponse(DakUserParam dakListUserParam, string dakSearchParam)
        {
            DakSearchResponse dakSearchResponse = new DakSearchResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_All_Search == true && a.searchParameter==dakSearchParam && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakSearchResponse = JsonConvert.DeserializeObject<DakSearchResponse>(dakList.jsonResponse);

                }
                return dakSearchResponse;
            }

            try
            {


                var dakSearchApi = new RestClient(GetAPIDomain() + GetDakSearchEndPoint());
                dakSearchApi.Timeout = -1;
                var dakSearchRequest = new RestRequest(Method.POST);
                dakSearchRequest.AddHeader("api-version", GetAPIVersion());
                dakSearchRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakSearchRequest.AlwaysMultipartFormData = true;
                dakSearchRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakSearchRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakSearchRequest.AddParameter("page", dakListUserParam.page);
                dakSearchRequest.AddParameter("limit", dakListUserParam.limit);
                //var search_params = new JavaScriptSerializer().Serialize(dakSearchParam);
                dakSearchRequest.AddParameter("search_params", dakSearchParam);
                IRestResponse dakInboxResponse = dakSearchApi.Execute(dakSearchRequest);
             

                var dakResponseJson = dakInboxResponse.Content;
                int firstStringIndex = dakResponseJson.IndexOf("{\"status\":");

                var jsonStringDiscardedGarbage = dakResponseJson.Substring(firstStringIndex,dakResponseJson.Length-firstStringIndex );
                SaveOrUpdateDakAllListJsonResponse(dakListUserParam, jsonStringDiscardedGarbage, dakSearchParam);
                dakSearchResponse = JsonConvert.DeserializeObject<DakSearchResponse>(jsonStringDiscardedGarbage);
                return dakSearchResponse;
            }
            catch (Exception ex)
            {
                return dakSearchResponse;
            }
        }

        public DakSearchResponse GetDakSearchResponse(DakUserParam dakListUserParam, string dak_sub)
        {
            throw new NotImplementedException();
        }

        protected string GetDakSearchEndPoint()
        {
            return DefaultAPIConfiguration.DakSearchEndPoint;
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




    }
}

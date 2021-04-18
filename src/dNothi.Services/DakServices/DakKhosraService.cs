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
    
    public class DakKhosraService : IDakKhosraService
    {
        IRepository<DakItem> _dakItem;
        public DakKhosraService(IRepository<DakItem> dakItem)
        {
            _dakItem = dakItem;
        }

        private void SaveOrUpdateKhosraListJsonResponse(DakUserParam dakListUserParam, string responseJson, string searchParam)
        {
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_khosra_Search == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.searchParameter == searchParam);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_khosra_Search = true;
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
            DakItem dakItemDB = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_khosra == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (dakItemDB != null)
            {
                dakItemDB.jsonResponse = responseJson;
                _dakItem.Update(dakItemDB);
            }
            else
            {
                DakItem dakItem = new DakItem();
                dakItem.is_dak_khosra = true;
                dakItem.page = dakListUserParam.page;
                dakItem.designation_id = dakListUserParam.designation_id;
                dakItem.office_id = dakListUserParam.office_id;
                dakItem.jsonResponse = responseJson;
                _dakItem.Insert(dakItem);

            }
        }

        public DakListKhosraResponse GetDakKhosraList(DakUserParam dakListUserParam)
        {
            DakListKhosraResponse dakListKhosraResponse = new DakListKhosraResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_khosra == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (dakList != null)
                {
                    dakListKhosraResponse = JsonConvert.DeserializeObject<DakListKhosraResponse>(dakList.jsonResponse);

                }
                return dakListKhosraResponse;
            }

            try
            {
               

                var dakKhorsAPI = new RestClient(GetAPIDomain() + GetDakListKhosraEndpoint());
                dakKhorsAPI.Timeout = -1;
                var dakKhosraRequest = new RestRequest(Method.POST);
                dakKhosraRequest.AddHeader("api-version", GetOldAPIVersion());
                dakKhosraRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakKhosraRequest.AlwaysMultipartFormData = true;
                dakKhosraRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakKhosraRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakKhosraRequest.AddParameter("page", dakListUserParam.page);
                dakKhosraRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakKhosraResponse = dakKhorsAPI.Execute(dakKhosraRequest);


                var dakKhosraResponseJson = dakKhosraResponse.Content;
                SaveOrUpdateDakOutBoxListJsonResponse(dakListUserParam, dakKhosraResponseJson);

                dakListKhosraResponse = JsonConvert.DeserializeObject<DakListKhosraResponse>(dakKhosraResponseJson);
                return dakListKhosraResponse;
            }
            catch (Exception ex)
            {
                return dakListKhosraResponse;
            }
        }


        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
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

        protected string GetDakListKhosraEndpoint()
        {
            return DefaultAPIConfiguration.DakListKhosraEndPoint;
        }

        public DakListKhosraResponse GetDakKhosraList(DakUserParam dakListUserParam, string searchParam)
        {
            DakListKhosraResponse dakListKhosraResponse = new DakListKhosraResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakList = _dakItem.Table.FirstOrDefault(a => a.page == dakListUserParam.page && a.is_dak_khosra_Search == true && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.searchParameter==searchParam);

                if (dakList != null)
                {
                    dakListKhosraResponse = JsonConvert.DeserializeObject<DakListKhosraResponse>(dakList.jsonResponse);

                }
                return dakListKhosraResponse;
            }
            try
            {


                var dakKhorsAPI = new RestClient(GetAPIDomain() + GetDakListKhosraEndpoint());
                dakKhorsAPI.Timeout = -1;
                var dakKhosraRequest = new RestRequest(Method.POST);
                dakKhosraRequest.AddHeader("api-version", GetOldAPIVersion());
                dakKhosraRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakKhosraRequest.AlwaysMultipartFormData = true;
                dakKhosraRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakKhosraRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakKhosraRequest.AddParameter("page", dakListUserParam.page);
                dakKhosraRequest.AddParameter("limit", dakListUserParam.limit);
                dakKhosraRequest.AddParameter("search_params", searchParam);
                IRestResponse dakKhosraResponse = dakKhorsAPI.Execute(dakKhosraRequest);


                var dakKhosraResponseJson = dakKhosraResponse.Content;
                SaveOrUpdateKhosraListJsonResponse(dakListUserParam, dakKhosraResponseJson,searchParam);
                dakListKhosraResponse = JsonConvert.DeserializeObject<DakListKhosraResponse>(dakKhosraResponseJson);
                return dakListKhosraResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

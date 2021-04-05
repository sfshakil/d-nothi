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
    public class NothiTypeListService : INothiTypeListServices
    {
        IRepository<NothiTypeListItem> _nothiTypeListItem;
        public NothiTypeListService(IRepository<NothiTypeListItem> nothiTypeListItem)
        {
            _nothiTypeListItem = nothiTypeListItem;
        }
        public NothiTypeListResponse GetNothiTypeList(DakUserParam dakUserParam)
        {
            NothiTypeListResponse nothiTypeListResponse = new NothiTypeListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiTypeListItem.Table.FirstOrDefault(a =>  a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    nothiTypeListResponse = JsonConvert.DeserializeObject<NothiTypeListResponse>(nothiList.jsonResponse);

                }
                return nothiTypeListResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiTypleListEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", +dakUserParam.office_id);
                request.AddParameter("designation_id", +dakUserParam.designation_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, responseJson);
                nothiTypeListResponse = JsonConvert.DeserializeObject<NothiTypeListResponse>(responseJson);
                return nothiTypeListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakListUserParam, string responseJson)
        {
            NothiTypeListItem nothiTypeListItemDB = _nothiTypeListItem.Table.FirstOrDefault(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiTypeListItemDB != null)
            {
                nothiTypeListItemDB.jsonResponse = responseJson;
                _nothiTypeListItem.Update(nothiTypeListItemDB);
            }
            else
            {
                NothiTypeListItem nothiTypeListItem = new NothiTypeListItem();
                nothiTypeListItem.designation_id = dakListUserParam.designation_id;
                nothiTypeListItem.office_id = dakListUserParam.office_id;
                nothiTypeListItem.jsonResponse = responseJson;
                _nothiTypeListItem.Insert(nothiTypeListItem);

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

        protected string GetNothiTypleListEndPoint()
        {
            return DefaultAPIConfiguration.NothiTypleListEndPoint;
        }
    }
}

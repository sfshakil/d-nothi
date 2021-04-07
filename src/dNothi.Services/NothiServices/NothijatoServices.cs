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
    public class NothijatoServices : INothijatoServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;
        public NothijatoServices(IRepository<PotrangshoNothiItem> nothiItem)
        {
            _nothiItem = nothiItem;
        }
        public NothijatoResponse GetNothijatoListInfo(DakUserParam dakUserParam, long id)
        {
            NothijatoResponse nothijatoResponse = new NothijatoResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    nothijatoResponse = JsonConvert.DeserializeObject<NothijatoResponse>(nothiList.nothijatojsonResponse);

                }
                return nothijatoResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoNothijatoEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, id, responseJson);
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["data"].ToString();
                //var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                nothijatoResponse = JsonConvert.DeserializeObject<NothijatoResponse>(responseJson);
                return nothijatoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakUserParam, long id, string responseJson)
        {
            var nothiListDB = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (nothiListDB != null)
            {
                nothiListDB.nothijatojsonResponse = responseJson;
                _nothiItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNothiItem nothiItem = new PotrangshoNothiItem();
                nothiItem.nothi_id = id;
                nothiItem.designation_id = dakUserParam.designation_id;
                nothiItem.office_id = dakUserParam.office_id;
                nothiItem.nothijatojsonResponse = responseJson;
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

        protected string GetNothiPotrangshoNothijatoEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoNothijatoEndPoint;
        }
    }
}

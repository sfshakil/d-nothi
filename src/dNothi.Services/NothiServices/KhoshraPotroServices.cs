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
    public class KhoshraPotroServices : IKhoshraPotroServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;
        public KhoshraPotroServices(IRepository<PotrangshoNothiItem> nothiItem)
        {
            _nothiItem = nothiItem;
        }
        public KhoshraPotroResponse GetKhoshraPotroInfo(DakUserParam dakUserParam, long id)
        {
            KhoshraPotroResponse khoshraPotroResponse = new KhoshraPotroResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    khoshraPotroResponse = JsonConvert.DeserializeObject<KhoshraPotroResponse>(nothiList.khoshrajsonResponse);

                }
                return khoshraPotroResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoKhoshraPotroEndPoint());
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
                khoshraPotroResponse = JsonConvert.DeserializeObject<KhoshraPotroResponse>(responseJson);
                return khoshraPotroResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakUserParam,long id, string responseJson)
        {
            var nothiListDB = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (nothiListDB != null)
            {
                nothiListDB.khoshrajsonResponse = responseJson;
                _nothiItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNothiItem nothiItem = new PotrangshoNothiItem();
                nothiItem.nothi_id = id;
                nothiItem.designation_id = dakUserParam.designation_id;
                nothiItem.office_id = dakUserParam.office_id;
                nothiItem.khoshrajsonResponse = responseJson;
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

        protected string GetNothiPotrangshoKhoshraPotroEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoKhoshraPotroEndPoint;
        }
    }
}

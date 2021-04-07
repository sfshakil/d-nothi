using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
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
    public class PotrojariServices : IPotrojariServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;

        private readonly IPotrojariParser _potrojariParser;
        public PotrojariServices(IPotrojariParser potrojariParser, IRepository<PotrangshoNothiItem> nothiItem)
        {
            _potrojariParser = potrojariParser;
            _nothiItem = nothiItem;
        }
        public PotrojariResponse GetPotrojariListInfo(DakUserParam dakUserParam, long id)
        {
            PotrojariResponse potrojariResponse = new PotrojariResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    potrojariResponse = _potrojariParser.ParseMessage(nothiList.potrojarijsonResponse);
                    //allPotroResponse = JsonConvert.DeserializeObject<KhoshraPotroWaitingResponse>(nothiList.khoshrawaitingjsonResponse);

                }
                return potrojariResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoPotrojariEndPoint());
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
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                potrojariResponse = _potrojariParser.ParseMessage(responseJson);
                return potrojariResponse;

                //PotrojariResponse potrojariResponse = JsonConvert.DeserializeObject<PotrojariResponse>(responseJson);
                //return potrojariResponse;
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
                nothiListDB.potrojarijsonResponse = responseJson;
                _nothiItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNothiItem nothiItem = new PotrangshoNothiItem();
                nothiItem.nothi_id = id;
                nothiItem.designation_id = dakUserParam.designation_id;
                nothiItem.office_id = dakUserParam.office_id;
                nothiItem.potrojarijsonResponse = responseJson;
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

        protected string GetNothiPotrangshoPotrojariEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoPotrojariEndPoint;
        }
    }
}

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
    public class AllPotroServices : IAllPotroServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;

        private readonly IAllPotroParser _allPotroParser;
        public AllPotroServices(IAllPotroParser allPotroParser, IRepository<PotrangshoNothiItem> nothiItem)
        {
            _allPotroParser = allPotroParser;
            _nothiItem = nothiItem;
        }
        public AllPotroResponse GetAllPotroInfo(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO, string potro_subject)
        {
            AllPotroResponse allPotroResponse = new AllPotroResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecordsDTO.id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    allPotroResponse = _allPotroParser.ParseMessage(nothiList.allpotrojsonResponse);
                    //allPotroResponse = JsonConvert.DeserializeObject<KhoshraPotroWaitingResponse>(nothiList.khoshrawaitingjsonResponse);

                }
                return allPotroResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoAllPotroEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\", \"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\"}");
                request.AddParameter("length", "1000000000000");
                if (potro_subject != "")
                {
                    request.AddParameter("search_params", "potro_subject=" + potro_subject);
                }
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, nothiListRecordsDTO.id, responseJson);
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["data"].ToString();
                //var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                allPotroResponse = _allPotroParser.ParseMessage(responseJson);
                return allPotroResponse;
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
                nothiListDB.allpotrojsonResponse = responseJson;
                _nothiItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNothiItem nothiItem = new PotrangshoNothiItem();
                nothiItem.nothi_id = id;
                nothiItem.designation_id = dakUserParam.designation_id;
                nothiItem.office_id = dakUserParam.office_id;
                nothiItem.allpotrojsonResponse = responseJson;
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

        protected string GetNothiPotrangshoAllPotroEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoAllPotroEndPoint;
        }
    }
}

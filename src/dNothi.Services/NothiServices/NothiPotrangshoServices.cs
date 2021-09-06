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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiPotrangshoServices : INothiPotrangshoServices
    {
        IRepository<NothiPotrangshoItem> _nothiPotrangshoItem;
        public NothiPotrangshoServices(IRepository<NothiPotrangshoItem> nothiPotrangshoItem)
        {
            _nothiPotrangshoItem = nothiPotrangshoItem;
        }
        public NothiPotrangshoResponse GetNothiPotrangsho(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO)
        {
            NothiPotrangshoResponse nothiPotrangshoResponse = new NothiPotrangshoResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiPotrangshoItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecordsDTO.id && a.office_unit_id == dakUserParam.office_unit_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    nothiPotrangshoResponse = JsonConvert.DeserializeObject<NothiPotrangshoResponse>(nothiList.jsonResponse);

                }
                return nothiPotrangshoResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+nothiListRecordsDTO.id+"\", \"nothi_office\":\""+ nothiListRecordsDTO.office_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                SaveOrUpdateNothiRecords(dakUserParam, nothiListRecordsDTO, responseJson);
                nothiPotrangshoResponse = JsonConvert.DeserializeObject<NothiPotrangshoResponse>(responseJson);
                return nothiPotrangshoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO, string responseJson)
        {
            NothiPotrangshoItem nothiPotrangshoItemDB = _nothiPotrangshoItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecordsDTO.id && a.office_unit_id == dakUserParam.office_unit_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (nothiPotrangshoItemDB != null)
            {
                nothiPotrangshoItemDB.jsonResponse = responseJson;
                _nothiPotrangshoItem.Update(nothiPotrangshoItemDB);
            }
            else
            {
                NothiPotrangshoItem nothiPotrangshoItem = new NothiPotrangshoItem();
                nothiPotrangshoItem.nothi_id = nothiListRecordsDTO.id;
                nothiPotrangshoItem.office_unit_id = dakUserParam.office_unit_id;
                nothiPotrangshoItem.designation_id = dakUserParam.designation_id;
                nothiPotrangshoItem.office_id = dakUserParam.office_id;
                nothiPotrangshoItem.jsonResponse = responseJson;
                _nothiPotrangshoItem.Insert(nothiPotrangshoItem);

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

        protected string GetNothiPotrangshoEndpoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoEndPoint;
        }
    }
}

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
    public class NothivuktoPotroServices : INothivuktoPotroServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;
        private readonly INothivuktoPotroParser _nothivuktoPotroParser;
        public NothivuktoPotroServices(IRepository<PotrangshoNothiItem> nothiItem, INothivuktoPotroParser nothivuktoPotroParser)
        {
            _nothiItem = nothiItem;
            _nothivuktoPotroParser = nothivuktoPotroParser;
        }
        public NothivuktoPotroResponse GetNothivuktoPotroInfo(DakUserParam dakUserParam, long id, string potro_subject)
        {
            NothivuktoPotroResponse khoshraPotroResponse = new NothivuktoPotroResponse();

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoNothivuktoPotroEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\"}");
                request.AddParameter("length", "1000000000000");
                if (potro_subject != "")
                {
                    request.AddParameter("search_params", "potro_subject=" + potro_subject);
                }
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                khoshraPotroResponse = _nothivuktoPotroParser.ParseMessage(responseJson);
                return khoshraPotroResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NothivuktoPotroResponse GetNoteNothivuktoPotroInfo(DakUserParam dakUserParam, long nothi_id, int nothi_note_id, string potro_subject)
        {
            NothivuktoPotroResponse khoshraPotroResponse = new NothivuktoPotroResponse();

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoNothivuktoPotroEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothi_id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\", \"nothi_note_id\":\"" + nothi_note_id + "\"}");
                request.AddParameter("length", "1000000000000");
                if (potro_subject != "")
                {
                    request.AddParameter("search_params", "potro_subject=" + potro_subject);
                }
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                khoshraPotroResponse = _nothivuktoPotroParser.ParseMessage(responseJson);
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

        protected string GetNothiPotrangshoNothivuktoPotroEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoNothivuktoPotroEndPoint;
        }

        
    }
}

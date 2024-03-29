﻿using dNothi.Constants;
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
    public class KhoshraPotroWaitingServices : IKhoshraPotroWaitingServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;
        private readonly IAllPotroParser _allPotroParser;
        public KhoshraPotroWaitingServices(IAllPotroParser allPotroParser , IRepository<PotrangshoNothiItem> nothiItem)
        {
            _allPotroParser = allPotroParser;
            _nothiItem = nothiItem;
        }
        public KhoshraPotroWaitingResponse GetKhoshraPotroWaitingInfo(DakUserParam dakUserParam, long id, string potro_subject)
        {
            KhoshraPotroWaitingResponse khoshraPotroWaitingResponse = new KhoshraPotroWaitingResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    khoshraPotroWaitingResponse = _allPotroParser.KhoshraWaitingParseMessage(nothiList.khoshrawaitingjsonResponse);

                }
                return khoshraPotroWaitingResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoKhoshraPotroWaitingEndPoint());
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
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                SaveOrUpdateNothiRecords(dakUserParam, id, responseJson);
                khoshraPotroWaitingResponse = _allPotroParser.KhoshraWaitingParseMessage(responseJson);
                return khoshraPotroWaitingResponse;
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
                nothiListDB.khoshrawaitingjsonResponse = responseJson;
                _nothiItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNothiItem nothiItem = new PotrangshoNothiItem();
                nothiItem.nothi_id = id;
                nothiItem.designation_id = dakUserParam.designation_id;
                nothiItem.office_id = dakUserParam.office_id;
                nothiItem.khoshrawaitingjsonResponse = responseJson;
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

        protected string GetNothiPotrangshoKhoshraPotroWaitingEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoKhoshraPotroWaitingEndPoint;
        }
    }
}

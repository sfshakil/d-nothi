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
    public class OnumodonService : IOnumodonService
    {
        IRepository<NothiOnumodonItem> _nothiOnumodonItem;
        IRepository<NothiNoteOnumodonItem> _nothiNoteOnumodonItem;
        public OnumodonService(IRepository<NothiOnumodonItem> nothiOnumodonItem, IRepository<NothiNoteOnumodonItem> nothiNoteOnumodonItem)
        {
            _nothiOnumodonItem = nothiOnumodonItem;
            _nothiNoteOnumodonItem = nothiNoteOnumodonItem;
        }
        public OnumodonResponse GetOnumodonMembers(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecords)
        {
            OnumodonResponse onumodonResponse = new OnumodonResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiOnumodonList = _nothiOnumodonItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecords.id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id && a.office_unit_id == dakUserParam.office_unit_id);

                if (nothiOnumodonList != null)
                {
                    onumodonResponse = JsonConvert.DeserializeObject<OnumodonResponse>(nothiOnumodonList.jsonResponse);

                }
                return onumodonResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiAuthorityEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\""+dakUserParam.designation_id+"\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+nothiListRecords.id+"\",\"nothi_office\":\""+nothiListRecords.office_id+"\"}");
                IRestResponse response = client.Execute(request);


                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, nothiListRecords, responseJson);
                onumodonResponse = JsonConvert.DeserializeObject<OnumodonResponse>(responseJson);
                return onumodonResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, string responseJson)
        {
            NothiOnumodonItem nothiOnumodonItemDB = _nothiOnumodonItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecords.id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.office_unit_id == dakListUserParam.office_unit_id);

            if (nothiOnumodonItemDB != null)
            {
                nothiOnumodonItemDB.jsonResponse = responseJson;
                _nothiOnumodonItem.Update(nothiOnumodonItemDB);
            }
            else
            {
                NothiOnumodonItem nothiOnumodonItem = new NothiOnumodonItem();
                nothiOnumodonItem.nothi_id = nothiListRecords.id;
                nothiOnumodonItem.office_unit_id = dakListUserParam.office_unit_id;
                nothiOnumodonItem.designation_id = dakListUserParam.designation_id;
                nothiOnumodonItem.office_id = dakListUserParam.office_id;
                nothiOnumodonItem.jsonResponse = responseJson;
                _nothiOnumodonItem.Insert(nothiOnumodonItem);

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

        protected string GetNothiAuthorityEndPoint()
        {
            return DefaultAPIConfiguration.NothiAuthorityEndPoint;
        }
        protected string GetNothiNoteAuthorityEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteAuthorityEndPoint;
        }

        public OnumodonResponse GetNoteOnumodonMembers(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecords, string noteId)
        {
            OnumodonResponse onumodonResponse = new OnumodonResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                long note_Id = Convert.ToInt32(noteId);
                var nothiOnumodonList = _nothiNoteOnumodonItem.Table.FirstOrDefault(a => a.note_id == note_Id && a.nothi_id == nothiListRecords.id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id && a.office_unit_id == dakUserParam.office_unit_id);

                if (nothiOnumodonList != null)
                {
                    onumodonResponse = JsonConvert.DeserializeObject<OnumodonResponse>(nothiOnumodonList.jsonResponse);

                }
                return onumodonResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteAuthorityEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                
                request.AddParameter("note", "{\"note_id\":\"" + noteId + "\",\"nothi_id\":\"" + nothiListRecords.id + "\",\"nothi_office\":\"" + dakUserParam.office_id + "\"}");
                IRestResponse response = client.Execute(request);


                var responseJson = response.Content;
                SaveOrUpdateNothiNoteRecords(dakUserParam, nothiListRecords, responseJson, noteId);
                onumodonResponse = JsonConvert.DeserializeObject<OnumodonResponse>(responseJson);
                return onumodonResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiNoteRecords(DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, string responseJson, string noteId)
        {
            long note_Id = Convert.ToInt32(noteId);
            var nothiOnumodonItemDB = _nothiNoteOnumodonItem.Table.FirstOrDefault(a => a.note_id == note_Id && a.nothi_id == nothiListRecords.id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.office_unit_id == dakListUserParam.office_unit_id);

            if (nothiOnumodonItemDB != null)
            {
                nothiOnumodonItemDB.jsonResponse = responseJson;
                _nothiNoteOnumodonItem.Update(nothiOnumodonItemDB);
            }
            else
            {
                NothiNoteOnumodonItem nothiOnumodonItem = new NothiNoteOnumodonItem();
                nothiOnumodonItem.note_id = note_Id;
                nothiOnumodonItem.nothi_id = nothiListRecords.id;
                nothiOnumodonItem.office_unit_id = dakListUserParam.office_unit_id;
                nothiOnumodonItem.designation_id = dakListUserParam.designation_id;
                nothiOnumodonItem.office_id = dakListUserParam.office_id;
                nothiOnumodonItem.jsonResponse = responseJson;
                _nothiNoteOnumodonItem.Insert(nothiOnumodonItem);

            }
        }
    }
}

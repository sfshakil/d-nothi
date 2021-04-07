﻿using dNothi.Constants;
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
    public class NothiInboxNoteServices : INothiInboxNoteServices
    {
        IRepository<NoteItem> _noteItem;
        public NothiInboxNoteServices( IRepository<NoteItem> noteItem)
        {
            _noteItem = noteItem;
        }
        public NothiListInboxNoteResponse GetNothiInboxNote(DakUserParam dakListUserParam, string eachNothiId, string note_category)
        {
            NothiListInboxNoteResponse nothiListInboxNoteResponse = new NothiListInboxNoteResponse();
            
            if (!dNothi.Utility.InternetConnection.Check())
            {
                int nothi_id = Convert.ToInt32(eachNothiId);
                var noteList = _noteItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_category == note_category && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (noteList != null)
                {
                    nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NothiListInboxNoteResponse>(noteList.jsonResponse);

                }
                return nothiListInboxNoteResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiInboxNoteEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\""+ dakListUserParam.office_id + "\",\"office_unit_id\":\""+ dakListUserParam.office_unit_id + "\",\"designation_id\":\""+ dakListUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+ Convert.ToInt32(eachNothiId) +"\",\"note_category\":\""+ note_category + "\"}");
                request.AddParameter("length", "100");
                request.AddParameter("page", "1");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakListUserParam, responseJson, Convert.ToInt32(eachNothiId), note_category);
                nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NothiListInboxNoteResponse>(responseJson);
                return nothiListInboxNoteResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakListUserParam, string responseJson, int nothi_Id, string note_category)
        {
            NoteItem noteItemDB = _noteItem.Table.FirstOrDefault(a => a.nothi_id == nothi_Id && a.note_category == note_category && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (noteItemDB != null)
            {
                noteItemDB.jsonResponse = responseJson;
                _noteItem.Update(noteItemDB);
            }
            else
            {
                NoteItem noteItem = new NoteItem();
                noteItem.nothi_id = nothi_Id;
                noteItem.note_category = note_category;
                noteItem.designation_id = dakListUserParam.designation_id;
                noteItem.office_id = dakListUserParam.office_id;
                noteItem.jsonResponse = responseJson;
                _noteItem.Insert(noteItem);

            }
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        protected string GetNothiInboxNoteEndPoint()
        {
            return DefaultAPIConfiguration.NothiInboxNoteEndPoint;
        }

    }
}

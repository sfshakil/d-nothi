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
using System.Web.Script.Serialization;

namespace dNothi.Services.NothiServices
{
    public class NothiNoteTalikaServices : INothiNoteTalikaServices
    {
        private readonly INoteListParser _noteListParser;
        IRepository<NothiNoteTalikaItem> _nothiNoteTalikaItem;
        IRepository<NoteInboxSentAllItem> _noteInboxSentAllItem;
        IRepository<NoteSearchItem> _noteSearchItem;
        public NothiNoteTalikaServices(INoteListParser noteListParser, 
            IRepository<NothiNoteTalikaItem> nothiNoteTalikaItem, 
            IRepository<NoteInboxSentAllItem> noteInboxSentAllItem,
            IRepository<NoteSearchItem> noteSearchItem)
        {
            _noteListParser = noteListParser;
            _nothiNoteTalikaItem = nothiNoteTalikaItem;
            _noteInboxSentAllItem = noteInboxSentAllItem;
            _noteSearchItem = noteSearchItem;
        }
        public NothiNoteTalikaListResponse GetNothiNoteTalika(DakUserParam dakUserParam, string nothi_type_id)
        {
            NothiNoteTalikaListResponse nothiNoteTalikaListResponse = new NothiNoteTalikaListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiNoteTalikaList = _nothiNoteTalikaItem.Table.FirstOrDefault(a => a.nothi_type_id == nothi_type_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiNoteTalikaList != null)
                {
                    nothiNoteTalikaListResponse = JsonConvert.DeserializeObject<NothiNoteTalikaListResponse>(nothiNoteTalikaList.jsonResponse);

                }
                return nothiNoteTalikaListResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteTalikaEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);
                //request.AddParameter("cdesk", "{\"office_id\":\""+ dakUserParam.office_id+"\",\"office_unit_id\":\""+ dakUserParam.office_unit_id+ "\",\"designation_id\":\"" + dakUserParam.designation_id + "\",\"officer_id\":\"" + dakUserParam.officer_id + "\",\"user_id\":\"" + dakUserParam.user_id + "\",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":\"" + dakUserParam.designation_level + "\"}");
                request.AddParameter("length", "10");
                request.AddParameter("page", dakUserParam.page);
                //request.AddParameter("search_params", "{\"nothi_type_id\":\"\"}");
                request.AddParameter("search_params", "{\"nothi_type_id\":\"" + nothi_type_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, responseJson, nothi_type_id);
                nothiNoteTalikaListResponse = JsonConvert.DeserializeObject<NothiNoteTalikaListResponse>(responseJson);
                return nothiNoteTalikaListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakListUserParam, string responseJson, string nothi_type_id)
        {
            NothiNoteTalikaItem nothiNoteTalikaItemDB = _nothiNoteTalikaItem.Table.FirstOrDefault(a => a.nothi_type_id == nothi_type_id  && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiNoteTalikaItemDB != null)
            {
                nothiNoteTalikaItemDB.jsonResponse = responseJson;
                _nothiNoteTalikaItem.Update(nothiNoteTalikaItemDB);
            }
            else
            {
                NothiNoteTalikaItem nothiNoteTalikaItem = new NothiNoteTalikaItem();
                nothiNoteTalikaItem.nothi_type_id= nothi_type_id;
                nothiNoteTalikaItem.designation_id = dakListUserParam.designation_id;
                nothiNoteTalikaItem.office_id = dakListUserParam.office_id;
                nothiNoteTalikaItem.jsonResponse = responseJson;
                _nothiNoteTalikaItem.Insert(nothiNoteTalikaItem);

            }
        }

        public void SaveOrUpdateNothiNumberGenerate(DakUserParam dakListUserParam, string responseJson, string nothi_type_id)
        {
            NothiNoteTalikaItem nothiNoteTalikaItemDB = _nothiNoteTalikaItem.Table.FirstOrDefault(a => a.nothi_type_id == nothi_type_id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (nothiNoteTalikaItemDB != null)
            {
                nothiNoteTalikaItemDB.nothiGenerateJsonResponse = responseJson;
                _nothiNoteTalikaItem.Update(nothiNoteTalikaItemDB);
            }
            else
            {
                NothiNoteTalikaItem nothiNoteTalikaItem = new NothiNoteTalikaItem();
                nothiNoteTalikaItem.nothi_type_id = nothi_type_id;
                nothiNoteTalikaItem.designation_id = dakListUserParam.designation_id;
                nothiNoteTalikaItem.office_id = dakListUserParam.office_id;
                nothiNoteTalikaItem.nothiGenerateJsonResponse = responseJson;
                _nothiNoteTalikaItem.Insert(nothiNoteTalikaItem);

            }
        }

        public NothiNoteListResponse GetNothiNoteListAll(DakUserParam dakUserParam, int nothi__id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain()+GetNoteListAllEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
              

                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "50");
                request.AddParameter("page", "1");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothi__id + "\",\"note_category\":\"ALL\"}");
                IRestResponse response = client.Execute(request);
               
                var responseJson = response.Content;
                NothiNoteListResponse nothiNoteListResponse = JsonConvert.DeserializeObject<NothiNoteListResponse>(responseJson);
                return nothiNoteListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NothiNoteListResponse GetNothiNoteListSent(DakUserParam dakUserParam, int nothi__id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteListSentEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "50");
                request.AddParameter("page", "1");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothi__id + "\",\"note_category\":\"Sent\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiNoteListResponse nothiNoteListResponse = JsonConvert.DeserializeObject<NothiNoteListResponse>(responseJson);
                return nothiNoteListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NothiNoteListResponse GetNothiNoteListInbox(DakUserParam dakUserParam, int nothi__id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteListInboxEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "50");
                request.AddParameter("page", "1");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothi__id + "\",\"note_category\":\"Inbox\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiNoteListResponse nothiNoteListResponse = JsonConvert.DeserializeObject<NothiNoteListResponse>(responseJson);
                return nothiNoteListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NoteListResponse GetNoteListSent(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO)
        {
            NoteListResponse noteListResponse = new NoteListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var noteInboxSentAllItem = _noteInboxSentAllItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecordsDTO.id && a.note_category == "Sent" && a.office_id == nothiListRecordsDTO.office_id && a.designation_id == dakUserParam.designation_id);

                if (noteInboxSentAllItem != null)
                {
                    noteListResponse = JsonConvert.DeserializeObject<NoteListResponse>(noteInboxSentAllItem.jsonResponse);

                }
                return noteListResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteListSentEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "1000");
                request.AddParameter("page", "1");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"note_category\":\"Sent\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNoteInboxSentAll(dakUserParam, responseJson, nothiListRecordsDTO.id, "Sent");
                noteListResponse = JsonConvert.DeserializeObject<NoteListResponse>(responseJson);
                return noteListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NoteListResponse GetNoteListInbox(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO)
        {
            NoteListResponse noteListResponse = new NoteListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var noteInboxSentAllItem = _noteInboxSentAllItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecordsDTO.id && a.note_category == "Inbox" && a.office_id == nothiListRecordsDTO.office_id && a.designation_id == dakUserParam.designation_id);

                if (noteInboxSentAllItem != null)
                {
                    noteListResponse = JsonConvert.DeserializeObject<NoteListResponse>(noteInboxSentAllItem.jsonResponse);

                }
                return noteListResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteListSentEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "1000");
                request.AddParameter("page", "1");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"note_category\":\"Inbox\",\"nothi_office\":\""+ nothiListRecordsDTO.office_id + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNoteInboxSentAll(dakUserParam, responseJson, nothiListRecordsDTO.id, "Inbox");
                noteListResponse = JsonConvert.DeserializeObject<NoteListResponse>(responseJson);
                return noteListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NoteAllListResponse GetNoteListAll(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO)
        {
            NoteAllListResponse noteListResponse = new NoteAllListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var noteInboxSentAllItem = _noteInboxSentAllItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecordsDTO.id && a.note_category == "All" && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (noteInboxSentAllItem != null)
                {
                    noteListResponse = _noteListParser.ParseMessage(noteInboxSentAllItem.jsonResponse);
                    //noteListResponse = JsonConvert.DeserializeObject<NoteAllListResponse>(noteListResponse);

                }
                return noteListResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteListSentEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "1000");
                request.AddParameter("page", "1");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"note_category\":\"All\",\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNoteInboxSentAll(dakUserParam, responseJson, nothiListRecordsDTO.id, "All");
                noteListResponse = _noteListParser.ParseMessage(responseJson);
                return noteListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNoteInboxSentAll(DakUserParam dakListUserParam, string responseJson, long nothi_id, string note_category)
        {
            NoteInboxSentAllItem noteInboxSentAllItemDB = _noteInboxSentAllItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_category == note_category && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (noteInboxSentAllItemDB != null)
            {
                noteInboxSentAllItemDB.jsonResponse = responseJson;
                _noteInboxSentAllItem.Update(noteInboxSentAllItemDB);
            }
            else
            {
                NoteInboxSentAllItem noteInboxSentAllItem = new NoteInboxSentAllItem();
                noteInboxSentAllItem.nothi_id = nothi_id;
                noteInboxSentAllItem.note_category = note_category;
                noteInboxSentAllItem.designation_id = dakListUserParam.designation_id;
                noteInboxSentAllItem.office_id = dakListUserParam.office_id;
                noteInboxSentAllItem.jsonResponse = responseJson;
                _noteInboxSentAllItem.Insert(noteInboxSentAllItem);

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

        protected string GetNoteListAllEndpoint()
        {
            return DefaultAPIConfiguration.GetNoteListAllEndpoint;
        }
        protected string GetNoteListInboxEndpoint()
        {
            return DefaultAPIConfiguration.GetNoteListInboxEndpoint;
        }
        protected string GetNoteListSentEndpoint()
        {
            return DefaultAPIConfiguration.GetNoteListSentpoint;
        }
        protected string GetNoteSearchListEndpoint()
        {
            return DefaultAPIConfiguration.GetNoteSearchListEndpoint;
        }
        protected string GetNothiNoteTalikaEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteTalikaEndPoint;
        }

        protected string GetNothiNumberEndPoint()
        {
            return DefaultAPIConfiguration.NothiNumberEndPoint;
        }

        public NothiNumberResponse GetNothiNumber(DakUserParam dakListUserParam, string nothi_type_id)
        {
            NothiNumberResponse nothiNumberResponse = new NothiNumberResponse();
            
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiNoteTalikaList = _nothiNoteTalikaItem.Table.FirstOrDefault(a => a.nothi_type_id == nothi_type_id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (nothiNoteTalikaList != null)
                {
                    nothiNumberResponse = JsonConvert.DeserializeObject<NothiNumberResponse>(nothiNoteTalikaList.nothiGenerateJsonResponse);

                }
                return nothiNumberResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNumberEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                //var serializedObject = JsonConvert.SerializeObject(dakListUserParam);
                //request.AddParameter("cdesk", serializedObject);
                //request.AddParameter("cdesk", "{\"office_id\":\""+ dakUserParam.office_id+"\",\"office_unit_id\":\""+ dakUserParam.office_unit_id+ "\",\"designation_id\":\"" + dakUserParam.designation_id + "\",\"officer_id\":\"" + dakUserParam.officer_id + "\",\"user_id\":\"" + dakUserParam.user_id + "\",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":\"" + dakUserParam.designation_level + "\"}");
                request.AddParameter("designation_id", dakListUserParam.designation_id);
                request.AddParameter("office_id", dakListUserParam.office_id);
                request.AddParameter("nothi_type_id", nothi_type_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNothiNumberGenerate(dakListUserParam, responseJson, nothi_type_id);
                nothiNumberResponse = JsonConvert.DeserializeObject<NothiNumberResponse>(responseJson);
                return nothiNumberResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NoteAllListResponse GetNoteListAll(DakUserParam dakUserParam, long nothi_id, string note_category, string note_subject, string officer_designation_id)
        {
            NoteAllListResponse noteListResponse = new NoteAllListResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var noteList = _noteSearchItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_category == note_category && a.note_subject == note_subject && a.officer_designation_id == officer_designation_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (noteList != null)
                {
                    noteListResponse = JsonConvert.DeserializeObject<NoteAllListResponse>(noteList.jsonResponse);

                }
                return noteListResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteSearchListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "25");
                request.AddParameter("page", "1");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothi_id + "\",\"note_category\":\""+ note_category + "\"}");
                request.AddParameter("search_params", "note_subject="+ note_subject + "&officer_designation_id="+ officer_designation_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNoteSearchRecords(dakUserParam, nothi_id, note_category, note_subject, officer_designation_id, responseJson);
                noteListResponse = _noteListParser.ParseMessage(responseJson);
                return noteListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNoteSearchRecords(DakUserParam dakListUserParam, long nothi_id, string note_category, string note_subject, string officer_designation_id, string responseJson)
        {
            var noteListDB = _noteSearchItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_category == note_category && a.note_subject == note_subject && a.officer_designation_id == officer_designation_id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (noteListDB != null)
            {
                noteListDB.jsonResponse = responseJson;
                _noteSearchItem.Update(noteListDB);
            }
            else
            {
                NoteSearchItem noteSearchItem = new NoteSearchItem();
                noteSearchItem.nothi_id = nothi_id;
                noteSearchItem.note_category = note_category;
                noteSearchItem.note_subject = note_subject;
                noteSearchItem.officer_designation_id = officer_designation_id;
                noteSearchItem.jsonResponse = responseJson;

                noteSearchItem.designation_id = dakListUserParam.designation_id;
                noteSearchItem.office_id = dakListUserParam.office_id;
                _noteSearchItem.Insert(noteSearchItem);

            }
        }
    }
}

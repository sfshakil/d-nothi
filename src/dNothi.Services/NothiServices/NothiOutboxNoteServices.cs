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
    public class NothiOutboxNoteServices : INothiOutboxNoteServices
    {
        IRepository<NoteItem> _noteItem;
        IRepository<NoteSaveItemAction> _noteSaveItemAction;
        public NothiOutboxNoteServices( IRepository<NoteItem> noteItem, IRepository<NoteSaveItemAction> noteSaveItemAction)
        {
            _noteItem = noteItem;
            _noteSaveItemAction = noteSaveItemAction;
        }
        public NothiListOutboxNoteResponse GetNothiOutboxNote(DakUserParam dakListUserParam, string eachNothiId, string note_category, string note_order, string nothi_office)
        {
            NothiListOutboxNoteResponse nothiListInboxNoteResponse = new NothiListOutboxNoteResponse();
            
            if (!dNothi.Utility.InternetConnection.Check())
            {
                int nothi_id = Convert.ToInt32(eachNothiId);
                var noteList = _noteItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_category == note_category && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (noteList != null)
                {
                    nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NothiListOutboxNoteResponse>(noteList.jsonResponse);

                }
                return nothiListInboxNoteResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiOutboxNoteEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\""+ dakListUserParam.office_id + "\",\"office_unit_id\":\""+ dakListUserParam.office_unit_id + "\",\"designation_id\":\""+ dakListUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+ Convert.ToInt32(eachNothiId) +"\",\"note_category\":\""+ note_category + "\",\"nothi_office\":\"" + nothi_office + "\"}");
                request.AddParameter("length", "100");
                request.AddParameter("page", "1");
                request.AddParameter("order", note_order);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakListUserParam, responseJson, Convert.ToInt32(eachNothiId), note_category);
                nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NothiListOutboxNoteResponse>(responseJson);
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
        public List<NoteSaveItemAction> GetNotUploadedNoteFromLocal(DakUserParam dakListUserParam, string eachNothiId, string note_category)
        {
            int nothi_id = Convert.ToInt32(eachNothiId);
            List<NoteSaveItemAction> noteSaveItemActions = _noteSaveItemAction.Table.Where(a => a.nothi_id == nothi_id && a.nothi_type == note_category && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
            
            return noteSaveItemActions;
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
        protected string GetNothiOutboxNoteEndPoint()
        {
            return DefaultAPIConfiguration.NothiOutboxNoteEndPoint;
        }

        public NothiListOutboxNoteResponse GetOtherOfficeNothiOutboxNote(DakUserParam dakListUserParam, string eachNothiId, string note_category, string note_order, string nothi_office)
        {
            NothiListOutboxNoteResponse nothiListInboxNoteResponse  = new NothiListOutboxNoteResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiOutboxNoteEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakListUserParam.office_id + "\",\"office_unit_id\":\"" + dakListUserParam.office_unit_id + "\",\"designation_id\":\"" + dakListUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + Convert.ToInt32(eachNothiId) + "\",\"note_category\":\"" + note_category + "\",\"nothi_office\":\"" + nothi_office + "\"}");
                request.AddParameter("length", "100");
                request.AddParameter("page", "1");
                request.AddParameter("order", note_order);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NothiListOutboxNoteResponse>(responseJson);
                return nothiListInboxNoteResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

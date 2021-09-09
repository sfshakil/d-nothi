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
    public class OnuchhedListServices : IOnuchhedListServices
    {
        IRepository<NoteOnuchhedListItem> _noteOnuchhedListItem;
        public OnuchhedListServices(IRepository<NoteOnuchhedListItem> noteOnuchhedListItem)
        {
            _noteOnuchhedListItem = noteOnuchhedListItem;
        }
        public OnucchedListResponse GetAllOnucchedList(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO, long note_id)
        {
            OnucchedListResponse onucchedListResponse = new OnucchedListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _noteOnuchhedListItem.Table.FirstOrDefault(a => a.nothi_id == nothiListRecordsDTO.id && a.note_id == note_id && a.office_unit_id == dakUserParam.office_unit_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    onucchedListResponse = JsonConvert.DeserializeObject<OnucchedListResponse>(nothiList.onuchhedList_jsonResponse);

                }
                return onucchedListResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteOnucchedListEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("note", "{\"nothi_office\":\"" + nothiListRecordsDTO.office_id + "\",\"nothi_id\":\"" + nothiListRecordsDTO.id + "\",\"note_id\":\"" + note_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, nothiListRecordsDTO.id, note_id, responseJson);
                onucchedListResponse = JsonConvert.DeserializeObject<OnucchedListResponse>(responseJson);
                return onucchedListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakUserParam, long nothi_id, long note_id, string responseJson)
        {
            NoteOnuchhedListItem noteOnuchhedListItemDB = _noteOnuchhedListItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_id == note_id && a.office_unit_id == dakUserParam.office_unit_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (noteOnuchhedListItemDB != null)
            {
                noteOnuchhedListItemDB.onuchhedList_jsonResponse = responseJson;
                _noteOnuchhedListItem.Update(noteOnuchhedListItemDB);
            }
            else
            {
                NoteOnuchhedListItem noteOnuchhedListItem = new NoteOnuchhedListItem();
                noteOnuchhedListItem.nothi_id = nothi_id;
                noteOnuchhedListItem.note_id = note_id;
                noteOnuchhedListItem.office_unit_id = dakUserParam.office_unit_id;
                noteOnuchhedListItem.designation_id = dakUserParam.designation_id;
                noteOnuchhedListItem.office_id = dakUserParam.office_id;
                noteOnuchhedListItem.onuchhedList_jsonResponse = responseJson;
                _noteOnuchhedListItem.Insert(noteOnuchhedListItem);

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

        protected string GetNothiNoteOnucchedListEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteOnucchedListEndPoint;
        }
    }
}

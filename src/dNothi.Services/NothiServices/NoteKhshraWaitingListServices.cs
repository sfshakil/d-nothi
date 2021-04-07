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
    public class NoteKhshraWaitingListServices : INoteKhshraWaitingListServices
    {
        IRepository<PotrangshoNoteItem> _noteItem;
        public NoteKhshraWaitingListServices(IRepository<PotrangshoNoteItem> noteItem)
        {
            _noteItem = noteItem;
        }
        public NoteKhshraWaitingListResponse GetNoteKhshraWaitingListInfo(DakUserParam dakUserParam, long id, int note_id)
        {
            NoteKhshraWaitingListResponse noteKhshraWaitingListResponse = new NoteKhshraWaitingListResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _noteItem.Table.FirstOrDefault(a => a.nothi_id == id && a.note_id == note_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    noteKhshraWaitingListResponse = JsonConvert.DeserializeObject<NoteKhshraWaitingListResponse>(nothiList.notekhoshrawaitingjsonResponse);

                }
                return noteKhshraWaitingListResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoNotePotrojariEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\",\"nothi_note_id\":\"" + note_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, id, note_id, responseJson);
                noteKhshraWaitingListResponse = JsonConvert.DeserializeObject<NoteKhshraWaitingListResponse>(responseJson);
                return noteKhshraWaitingListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakUserParam, long id, int note_id, string responseJson)
        {
            PotrangshoNoteItem nothiListDB = _noteItem.Table.FirstOrDefault(a => a.nothi_id == id && a.note_id == note_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (nothiListDB != null)
            {
                nothiListDB.notekhoshrawaitingjsonResponse = responseJson;
                _noteItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNoteItem potrangshoNoteItem = new PotrangshoNoteItem();
                potrangshoNoteItem.nothi_id = id;
                potrangshoNoteItem.note_id = note_id;
                potrangshoNoteItem.designation_id = dakUserParam.designation_id;
                potrangshoNoteItem.office_id = dakUserParam.office_id;
                potrangshoNoteItem.notekhoshrawaitingjsonResponse = responseJson;
                _noteItem.Insert(potrangshoNoteItem);

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

        protected string GetNothiPotrangshoNotePotrojariEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoKhoshraPotroWaitingEndPoint;
        }
    }
}
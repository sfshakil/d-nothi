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
    public class NoteKhoshraListServices : INoteKhoshraListServices
    {
        IRepository<PotrangshoNoteItem> _noteItem;
        private readonly IAllPotroParser _allPotroParser;
        public NoteKhoshraListServices(IAllPotroParser allPotroParser, IRepository<PotrangshoNoteItem> noteItem)
        {
            _allPotroParser = allPotroParser;
            _noteItem = noteItem;
        }
        public NoteKhoshraListResponse GetnoteKhoshraListInfo(DakUserParam dakUserParam, long id, int note_id)
        {
            NoteKhoshraListResponse noteKhoshraListResponse = new NoteKhoshraListResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _noteItem.Table.FirstOrDefault(a => a.nothi_id == id && a.note_id == note_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    noteKhoshraListResponse = _allPotroParser.NoteKhoshraParseMessage(nothiList.notekhoshrajsonResponse);

                }
                return noteKhoshraListResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoNoteKhshrapotroEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\",\"nothi_note_id\":\"" + note_id + "\"}");
                request.AddParameter("length", "1000000000000");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, id, note_id, responseJson);
                noteKhoshraListResponse = _allPotroParser.NoteKhoshraParseMessage(responseJson);
                return noteKhoshraListResponse;
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
                nothiListDB.notekhoshrajsonResponse = responseJson;
                _noteItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNoteItem potrangshoNoteItem = new PotrangshoNoteItem();
                potrangshoNoteItem.nothi_id = id;
                potrangshoNoteItem.note_id = note_id;
                potrangshoNoteItem.designation_id = dakUserParam.designation_id;
                potrangshoNoteItem.office_id = dakUserParam.office_id;
                potrangshoNoteItem.notekhoshrajsonResponse = responseJson;
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

        protected string GetNothiPotrangshoNoteKhshrapotroEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoNoteKhshrapotroEndPoint;
        }
    }
}
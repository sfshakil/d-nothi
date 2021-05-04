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
    public class NotePotrojariServices : INotePotrojariServices
    {
        IRepository<PotrangshoNoteItem> _noteItem;
        private readonly IAllPotroParser _allPotroParser;
        public NotePotrojariServices(IAllPotroParser allPotroParser, IRepository<PotrangshoNoteItem> noteItem)
        {
            _allPotroParser = allPotroParser;
            _noteItem = noteItem;
        }
        public NotePotrojariResponse GetPotrojariListInfo(DakUserParam dakUserParam, long id, int note_id)
        {
            NotePotrojariResponse notePotrojariResponse = new NotePotrojariResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _noteItem.Table.FirstOrDefault(a => a.nothi_id == id && a.note_id == note_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    notePotrojariResponse = _allPotroParser.NotePotrojariParseMessage(nothiList.notepotrojarijsonResponse);

                }
                return notePotrojariResponse;
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
                request.AddParameter("length", "1000000000000");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, id, note_id, responseJson);
                notePotrojariResponse = _allPotroParser.NotePotrojariParseMessage(responseJson);
                return notePotrojariResponse;
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
                nothiListDB.notepotrojarijsonResponse = responseJson;
                _noteItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNoteItem potrangshoNoteItem = new PotrangshoNoteItem();
                potrangshoNoteItem.nothi_id = id;
                potrangshoNoteItem.note_id = note_id;
                potrangshoNoteItem.designation_id = dakUserParam.designation_id;
                potrangshoNoteItem.office_id = dakUserParam.office_id;
                potrangshoNoteItem.notepotrojarijsonResponse = responseJson;
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
            return DefaultAPIConfiguration.NothiPotrangshoNotePotrojariEndPoint;
        }
    }
}
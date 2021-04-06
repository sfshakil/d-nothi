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
    public class SingleOnucchedServices : ISingleOnucchedServices
    {
        IRepository<NoteOnuchhedListItem> _noteOnuchhedListItem;
        public SingleOnucchedServices(IRepository<NoteOnuchhedListItem> noteOnuchhedListItem)
        {
            _noteOnuchhedListItem = noteOnuchhedListItem;
        }
        public SingleOnucchedResponse GetSingleOnucched(DakUserParam dakUserParam, long nothi_id, long note_id, long onucched_id)
        {
            SingleOnucchedResponse singleOnucchedResponse = new SingleOnucchedResponse();
            
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _noteOnuchhedListItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_id == note_id && a.onuchhed_id == onucched_id && a.office_unit_id == dakUserParam.office_unit_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    singleOnucchedResponse = JsonConvert.DeserializeObject<SingleOnucchedResponse>(nothiList.single_onuchhed_jsonResponse);

                }
                return singleOnucchedResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteSingleOnucchedEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("note", "{\"nothi_id\":\"" + nothi_id + "\",\"note_id\":\"" + note_id + "\", \"onucched_id\":\"" + onucched_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, nothi_id, note_id, onucched_id, responseJson);
                singleOnucchedResponse = JsonConvert.DeserializeObject<SingleOnucchedResponse>(responseJson);
                return singleOnucchedResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakUserParam, long nothi_id, long note_id, long onucched_id, string responseJson)
        {
            NoteOnuchhedListItem noteOnuchhedListItemDB = _noteOnuchhedListItem.Table.FirstOrDefault(a => a.nothi_id == nothi_id && a.note_id == note_id && a.onuchhed_id == onucched_id && a.office_unit_id == dakUserParam.office_unit_id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (noteOnuchhedListItemDB != null)
            {
                noteOnuchhedListItemDB.single_onuchhed_jsonResponse = responseJson;
                _noteOnuchhedListItem.Update(noteOnuchhedListItemDB);
            }
            else
            {
                NoteOnuchhedListItem noteOnuchhedListItem = new NoteOnuchhedListItem();
                noteOnuchhedListItem.nothi_id = nothi_id;
                noteOnuchhedListItem.note_id = note_id;
                noteOnuchhedListItem.onuchhed_id = onucched_id;
                noteOnuchhedListItem.office_unit_id = dakUserParam.office_unit_id;
                noteOnuchhedListItem.designation_id = dakUserParam.designation_id;
                noteOnuchhedListItem.office_id = dakUserParam.office_id;
                noteOnuchhedListItem.single_onuchhed_jsonResponse = responseJson;
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

        protected string GetNothiNoteSingleOnucchedEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteSingleOnucchedEndPoint;
        }
    }
}

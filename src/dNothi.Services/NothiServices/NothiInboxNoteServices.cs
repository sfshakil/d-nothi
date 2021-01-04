using dNothi.JsonParser.Entity.Nothi;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiInboxNoteServices : INothiInboxNoteServices
    {
        public NothiListInboxNoteResponse GetNothiInboxNote(string token, string eachNothiId)
        {
            try
            {
                var client = new RestClient("https://dev.nothibs.tappware.com/api/nothi/note/pending");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"65\",\"office_unit_id\":\"40372\",\"designation_id\":\"244930\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\""+ Convert.ToInt32(eachNothiId) +"\",\"note_category\":\"Inbox\"}");
                request.AddParameter("length", "100");
                request.AddParameter("page", "1");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                var responseJson = response.Content;
                NothiListInboxNoteResponse nothiListInboxNoteResponse = JsonConvert.DeserializeObject<NothiListInboxNoteResponse>(responseJson);
                return nothiListInboxNoteResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

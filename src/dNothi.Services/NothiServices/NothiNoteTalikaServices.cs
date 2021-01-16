using dNothi.Constants;
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
        public NothiNoteTalikaListResponse GetNothiNoteTalika(string token, string nothi_type_id)
        {
            try
            {
                var client = new RestClient("https://dev.nothibs.tappware.com/api/nothis");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":65,\"office_unit_id\":40372,\"designation_id\":244930,\"officer_id\":77858,\"user_id\":3923,\"office\":\"\\u098f\\u09b8\\u09aa\\u09be\\u09df\\u09be\\u09b0 \\u099f\\u09c1 \\u0987\\u09a8\\u09cb\\u09ad\\u09c7\\u099f (\\u098f\\u099f\\u09c1\\u0986\\u0987) \\u09aa\\u09cd\\u09b0\\u09cb\\u0997\\u09cd\\u09b0\\u09be\\u09ae\",\"office_unit\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"designation\":\"\\u09b8\\u09b2\\u09cd\\u09af\\u09c1\\u09b6\\u09a8 \\u0986\\u09b0\\u09cd\\u0995\\u09bf\\u099f\\u09c7\\u0995\\u09cd\\u099f\",\"officer\":\"\\u09ae\\u09cb\\u0983 \\u09b9\\u09be\\u09b8\\u09be\\u09a8\\u09c1\\u099c\\u09cd\\u099c\\u09be\\u09ae\\u09be\\u09a8\",\"designation_level\":4}");
                request.AddParameter("length", "30");
                request.AddParameter("page", "1");
                request.AddParameter("search_params", "{\"nothi_type_id\":\""+nothi_type_id+"\",\"office_unit_id\":\"40372\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NothiNoteTalikaListResponse nothiNoteTalikaListResponse = JsonConvert.DeserializeObject<NothiNoteTalikaListResponse>(responseJson);
                return nothiNoteTalikaListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiNoteListResponse GetNothiNoteListAll(DakUserParam dakUserParam, int nothi__id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain()+GetNoteListAllEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
              

                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "10");
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
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "10");
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
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", dakUserParam.json_String);
                request.AddParameter("length", "10");
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

    }
}

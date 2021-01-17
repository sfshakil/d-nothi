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
        public NothiNoteTalikaListResponse GetNothiNoteTalika(DakUserParam dakUserParam, string nothi_type_id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteTalikaEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\""+ dakUserParam.office_id+"\",\"office_unit_id\":\""+ dakUserParam.office_unit_id+ "\",\"designation_id\":\"" + dakUserParam.designation_id + "\",\"officer_id\":\"" + dakUserParam.officer_id + "\",\"user_id\":\"" + dakUserParam.user_id + "\",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":\"" + dakUserParam.designation_level + "\"}");
                request.AddParameter("length", "100");
                request.AddParameter("page", "1");
                request.AddParameter("search_params", "{\"nothi_type_id\":\""+nothi_type_id+ "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
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
                request.AddHeader("api-version", GetAPIVersion());
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
                request.AddHeader("api-version", GetAPIVersion());
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
                request.AddHeader("api-version", GetAPIVersion());
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
        protected string GetNothiNoteTalikaEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteTalikaEndPoint;
        }
    }
}

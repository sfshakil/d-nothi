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

namespace dNothi.Services.NothiServices
{
    public class NoteDeleteService : INoteDeleteService
    {
        public NoteDeleteResponse GetNoteDelete(DakUserParam dakUserParam, string nothiTypeId)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiTypeDeleteEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true; 
                request.AddParameter("office_id", dakUserParam.office_id);
                request.AddParameter("designation_id", dakUserParam.designation_id);
                request.AddParameter("model", "NothiTypes");
                request.AddParameter("id", nothiTypeId);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                var responseJson = response.Content;
                NoteDeleteResponse noteDeleteResponse = JsonConvert.DeserializeObject<NoteDeleteResponse>(responseJson);
                return noteDeleteResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NoteDeleteResponse GetNoteDelteResponse(DakUserParam dakUserParam,string model,  string noteId)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiTypeDeleteEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true; 
                request.AddParameter("office_id", dakUserParam.office_id);
                request.AddParameter("designation_id", dakUserParam.designation_id);
                request.AddParameter("model", model);
                request.AddParameter("id", noteId);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                var responseJson = response.Content;
                NoteDeleteResponse noteDeleteResponse = JsonConvert.DeserializeObject<NoteDeleteResponse>(responseJson);
                return noteDeleteResponse;
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

        protected string GetNothiTypeDeleteEndPoint()
        {
            return DefaultAPIConfiguration.NothiTypeDeleteEndPoint;
        }
    }
}

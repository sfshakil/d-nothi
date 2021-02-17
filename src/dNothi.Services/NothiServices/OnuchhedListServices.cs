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
    public class OnuchhedListServices : IOnuchhedListServices
    {
        public OnucchedListResponse GetAllOnucchedList(DakUserParam dakUserParam, long nothiid, long note_id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteOnucchedListEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("note", "{\"nothi_office\":\"" + dakUserParam.office_id + "\",\"nothi_id\":\"" + nothiid + "\",\"note_id\":\"" + note_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                OnucchedListResponse onucchedListResponse = JsonConvert.DeserializeObject<OnucchedListResponse>(responseJson);
                return onucchedListResponse;
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

        protected string GetNothiNoteOnucchedListEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteOnucchedListEndPoint;
        }
    }
}

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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiDecisionListService : INothiDecisionListService
    {
        public NothiDecisionListResponse GetNothiDecisionList(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiDecisionListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\",\"officer_id\":\"" + dakUserParam.officer_id + "\",\"user_id\":\"" + dakUserParam.user_id + "\",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":\"" + dakUserParam.designation_level + "\"}");
                request.AddParameter("limit", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NothiDecisionListResponse nothiDecisionListResponse = JsonConvert.DeserializeObject<NothiDecisionListResponse>(responseJson);
                return nothiDecisionListResponse;
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

        protected string GetNothiDecisionListEndpoint()
        {
            return DefaultAPIConfiguration.NothiDecisionListEndpoint;
        }
        protected string GetNothiALLDecisionListEndpoint()
        {
            return DefaultAPIConfiguration.NothiALLDecisionListEndpoint;
        }
        protected string GetNothiDeleteDecisionListEndpoint()
        {
            return DefaultAPIConfiguration.NothiDeleteDecisionListEndpoint;
        }
        protected string GetNothiAddDecisionListEndpoint()
        {
            return DefaultAPIConfiguration.NothiAddDecisionListEndpoint;
        }

        protected string GetNothiGaurdFileListEndpoint()
        {
            return DefaultAPIConfiguration.NothiGaurdFileListEndpoint;
        }
        protected string GetNothiBibechhoPotroListEndpoint()
        {
            return DefaultAPIConfiguration.NothiBibechhoPotroListEndpoint;
        }
        protected string GetNothiOnuchhedListEndpoint()
        {
            return DefaultAPIConfiguration.NothiOnuchhedListEndpoint;
        }
        protected string GetNothiPotakaListEndpoint()
        {
            return DefaultAPIConfiguration.NothiPotakaListEndpoint;
        }

        public NothiGaurdFileListResponse GetNothiGaurdFileList(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiGaurdFileListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", dakUserParam.office_id);
                request.AddParameter("page", dakUserParam.page);
                request.AddParameter("limit", dakUserParam.limit);
                request.AddParameter("designation_id", dakUserParam.designation_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiGaurdFileListResponse nothiDecisionListResponse = JsonConvert.DeserializeObject<NothiGaurdFileListResponse>(responseJson);
                return nothiDecisionListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiBibechhoPotroResponse GetNothiBibechhoPotroList(DakUserParam dakUserParam, string nothi_id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiBibechhoPotroListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\",\"officer_id\":\"" + dakUserParam.officer_id + "\",\"user_id\":\"" + dakUserParam.user_id + "\",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":\"" + dakUserParam.designation_level + "\"}");
                request.AddParameter("length", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                request.AddParameter("nothi", "{\"nothi_id\":\""+ nothi_id +"\", \"nothi_office\":\""+ dakUserParam.office_id + "\"}");

                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiBibechhoPotroResponse nothiBibechhoPotroResponse = JsonConvert.DeserializeObject<NothiBibechhoPotroResponse>(responseJson);
                return nothiBibechhoPotroResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiOnuchhedListResponse GetNothiOnuchhedList(DakUserParam dakUserParam, string nothi_id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiOnuchhedListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + nothi_id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiOnuchhedListResponse nothiBibechhoPotroResponse = JsonConvert.DeserializeObject<NothiOnuchhedListResponse>(responseJson);
                return nothiBibechhoPotroResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiPotakaListResponse GetNothiPotakaList(DakUserParam dakUserParam, string nothi_id, string note_id)
        {
            NothiPotakaListResponse nothiBibechhoPotroResponse = new NothiPotakaListResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotakaListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\",\"officer_id\":\"" + dakUserParam.officer_id + "\",\"user_id\":\"" + dakUserParam.user_id + "\",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":\"" + dakUserParam.designation_level + "\"}");
                request.AddParameter("note", "{\"nothi_note_id\":\""+ note_id + "\",\"nothi_office_id\":"+ dakUserParam.office_id + ",\"nothi_master_id\":\""+ nothi_id + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                nothiBibechhoPotroResponse = JsonConvert.DeserializeObject<NothiPotakaListResponse>(responseJson);
                return nothiBibechhoPotroResponse;
            }
            catch (Exception ex)
            {
                return nothiBibechhoPotroResponse;
            }
        }

        public NothiDecisionListResponse GetNothiALLDecisionList(DakUserParam dakUserParam)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiALLDecisionListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\",\"officer_id\":\"" + dakUserParam.officer_id + "\",\"user_id\":\"" + dakUserParam.user_id + "\",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":\"" + dakUserParam.designation_level + "\"}");
                request.AddParameter("limit", dakUserParam.limit);
                request.AddParameter("page", dakUserParam.page);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NothiDecisionListResponse nothiDecisionListResponse = JsonConvert.DeserializeObject<NothiDecisionListResponse>(responseJson);
                return nothiDecisionListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiDecisionListAddResponse GetNothiAddDecisionList(DakUserParam dakUserParam, string decision, long decisions_employee)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiAddDecisionListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("decisions", decision);
                request.AddParameter("decisions_employee", decisions_employee);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiDecisionListAddResponse nothiDecisionListResponse = JsonConvert.DeserializeObject<NothiDecisionListAddResponse>(responseJson);
                return nothiDecisionListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiDecisionListDeleteResponse GetNothiDeleteDecisionList(DakUserParam dakUserParam, long nothi_decision_id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiDeleteDecisionListEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("nothi_decision_id", nothi_decision_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiDecisionListDeleteResponse nothiDecisionListResponse = JsonConvert.DeserializeObject<NothiDecisionListDeleteResponse>(responseJson);
                return nothiDecisionListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

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
using System.Web.Script.Serialization;
using User = dNothi.JsonParser.Entity.Nothi.User;

namespace dNothi.Services.NothiServices
{
    public class NothiReviewerServices : INothiReviewerServices
    {
        public NothiReviewerDTO GetNothiReviewer(DakUserParam dakUserParam, long nothi_shared_id)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiReviewerEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                var serializedObject1 = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject1); 
                request.AddParameter("shared_nothi_id", nothi_shared_id);
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiReviewerDTO allPotroResponse = JsonConvert.DeserializeObject<NothiReviewerDTO>(responseJson);
                return allPotroResponse;
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

        protected string GetNothiReviewerEndPoint()
        {
            return DefaultAPIConfiguration.NothiReviewerEndPoint;
        }
        protected string GetNothiSharedOffEndPoint()
        {
            return DefaultAPIConfiguration.NothiSharedOff;
        }

        public NothiSharedOffDTO GetNothiSharedOff(DakUserParam dakListUserParam, NothiReviewerDTO nothiReviewer)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiSharedOffEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                //var serializedObject1 = JsonConvert.SerializeObject(dakListUserParam);
                request.AddParameter("cdesk", "{\"office_id\":" + dakListUserParam.office_id + ",\"office_unit_id\":" + dakListUserParam.office_unit_id + ",\"designation_id\":" + dakListUserParam.designation_id + ",\"officer_id\":" + dakListUserParam.officer_id + ",\"user_id\":" + dakListUserParam.user_id + ",\"office\":\"" + dakListUserParam.office + "\",\"officer\":\"" + dakListUserParam.officer + "\",\"designation_level\":" + dakListUserParam.designation_level + "}");
                request.AddParameter("nothi", "{\"shared_nothi_id\":\""+ nothiReviewer.nothi.id+ "\",\"operation_type\":\""+ nothiReviewer.nothi.shared_status+ "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                NothiSharedOffDTO allPotroResponse = JsonConvert.DeserializeObject<NothiSharedOffDTO>(responseJson);
                return allPotroResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public NothiSharedSaveDTO GetNothiSharedSave(DakUserParam dakListUserParam, NothiListInboxNoteRecordsDTO noteAllListDataRecord, long onuchhed_id, List<User> selectedUser)
        {
            try
            {
                var user_string = "";
                int i = 0;
                var client = new RestClient(GetAPIDomain() + GetNothiSharedOffEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                //var serializedObject1 = JsonConvert.SerializeObject(dakListUserParam);
                request.AddParameter("cdesk", "{\"office_id\":" + dakListUserParam.office_id + ",\"office_unit_id\":" + dakListUserParam.office_unit_id + ",\"designation_id\":" + dakListUserParam.designation_id + ",\"officer_id\":" + dakListUserParam.officer_id + ",\"user_id\":" + dakListUserParam.user_id + ",\"office\":\"" + dakListUserParam.office + "\",\"officer\":\"" + dakListUserParam.officer + "\",\"designation_level\":" + dakListUserParam.designation_level + "}");
                request.AddParameter("nothi", "{\"potrojari_id\":\"0\",\"onucched_id\":\""+ onuchhed_id + "\",\"nothi_id\":\"" + noteAllListDataRecord.nothi.id + "\",\"note_id\":\"" + noteAllListDataRecord.note.nothi_note_id + "\",\"subject\":\"" + noteAllListDataRecord.note.note_subject + "\",\"shared_nothi_id\":\"0\",\"content\":\"\"}");
                foreach (User user in selectedUser)
                {
                    i++;
                    user_string += "\"user:"+ user.designation_id + "\":";
                    var JsonString = new JavaScriptSerializer().Serialize(user);
                    user_string += JsonString;
                    if (i < selectedUser.Count)
                    {
                        user_string += ",";
                    }
                }
                
                request.AddParameter("user", "{"+ user_string + "}");
                IRestResponse response = client.Execute(request);
                
                var responseJson = response.Content;
                NothiSharedSaveDTO allPotroResponse = JsonConvert.DeserializeObject<NothiSharedSaveDTO>(responseJson);
                return allPotroResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

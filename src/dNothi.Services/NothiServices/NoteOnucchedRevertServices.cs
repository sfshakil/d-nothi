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
    public class NoteOnucchedRevertServices : INoteOnucchedRevertServices
    {
        public NoteOnucchedRevertResPonse GetNoteOnucchedRevert(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteOnucchedRevertEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":" + dakUserParam.office_id + ",\"office_unit_id\":" + dakUserParam.office_unit_id + ",\"designation_id\":" + dakUserParam.designation_id + ",\"officer_id\":" + dakUserParam.officer_id + ",\"user_id\":" + dakUserParam.user_id + ",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":" + dakUserParam.designation_level + "}");
                request.AddParameter("onucched", "{\"note_no\":\"" + newnotedata.note_id + "\",\"note_subject\":\"" + newnotedata.note_subject + "\",\"nothi_subject\":\""+ nothiListRecords .subject+ "\",\"nothi_id\":\"" + newnotedata.nothi_id + "\",\"nothi_office\":\"" + dakUserParam.office_id + "\",\"nothi_office_name\":\"" + nothiListRecords.office_name + "\",\"note_id\":\"" + newnotedata.note_id + "\"}");
                request.AddParameter("recipient", "{\"office_id\":" + dakUserParam.office_id + ",\"office_unit_id\":" + dakUserParam.office_unit_id + ",\"designation_id\":" + dakUserParam.designation_id + ",\"officer_id\":" + dakUserParam.officer_id + ",\"user_id\":" + dakUserParam.user_id + ",\"office\":\"" + dakUserParam.office + "\",\"office_unit\":\"" + dakUserParam.office_unit + "\",\"designation\":\"" + dakUserParam.designation + "\",\"officer\":\"" + dakUserParam.officer + "\",\"designation_level\":" + dakUserParam.designation_level + "}");

                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NoteOnucchedRevertResPonse noteOnucchedRevertResPonse = JsonConvert.DeserializeObject<NoteOnucchedRevertResPonse>(responseJson);
                return noteOnucchedRevertResPonse;
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

        protected string GetNothiNoteOnucchedRevertEndPoint()
        {
            return DefaultAPIConfiguration.NothiNoteOnucchedRevertEndPoint;
        }
    }
}

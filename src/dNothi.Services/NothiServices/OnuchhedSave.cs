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
    public class OnuchhedSave : IOnucchedSave
    {
        public NothiOnuchhedSaveResponse GetNothiOnuchhedSave(DakUserParam dakUserParam, List<FileAttachment> fileattachments, NothiListRecordsDTO nothiListRecordsDTO, NoteSaveDTO newnotedata, string editorEncodedData)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedSaveEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id+ "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id+ "\",\"designation_id\":\"" + dakUserParam.designation_id+ "\",\"officer_id\":\"" + dakUserParam.officer_id+ "\",\"user_id\":\"" + dakUserParam.user_id+ "\",\"office\":\"" + dakUserParam.office+ "\",\"office_unit\":\"Technology\",\"designation\":\"" + dakUserParam.designation+ "\",\"officer\":\"" + dakUserParam.officer+ "\",\"designation_level\":\"" + dakUserParam.designation_level+ "\"}");
                request.AddParameter("onucched", "{\"nothi_id\":\""+newnotedata.nothi_id+"\",\"nothi_office\":\""+newnotedata.office_id+"\",\"note_id\":\""+newnotedata.note_id+"\",\"id\":\""+newnotedata.id+"\",\"note_description\":\""+ editorEncodedData + "\",\"attachments\":[]}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                NothiOnuchhedSaveResponse nothiOnuchhedSaveResponse = JsonConvert.DeserializeObject<NothiOnuchhedSaveResponse>(responseJson);
                return nothiOnuchhedSaveResponse;
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

        protected string GetNoteOnuchhedSaveEndPoint()
        {
            return DefaultAPIConfiguration.NoteOnuchhedSaveEndPoint;
        }
    }
}

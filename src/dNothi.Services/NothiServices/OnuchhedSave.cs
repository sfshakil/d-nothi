using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
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
    public class OnuchhedSave : IOnucchedSave
    {
        public NothiOnuchhedSaveResponse GetNothiOnuchhedSave(DakUserParam dakUserParam, List<DakUploadedFileResponse> onuchhedSaveWithAttachments, NothiListRecordsDTO nothiListRecordsDTO, NoteSaveDTO newnotedata, string editorEncodedData)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedSaveEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

                var serializedObject1 = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject1);
                var attachment = "";
                if (onuchhedSaveWithAttachments.Count > 0)
                {
                    FileInfo f1 = new FileInfo();
                    f1.attachment_type = onuchhedSaveWithAttachments[0].data[0].attachment_type;
                    f1.user_file_name = onuchhedSaveWithAttachments[0].data[0].user_file_name;
                    f1.id = onuchhedSaveWithAttachments[0].data[0].id;
                    f1.file_name = onuchhedSaveWithAttachments[0].data[0].file_name;
                    f1.file_size_in_kb = onuchhedSaveWithAttachments[0].data[0].file_size_in_kb;
                    f1.img_base64 = onuchhedSaveWithAttachments[0].data[0].img_base64;
                    f1.url = onuchhedSaveWithAttachments[0].data[0].url;

                    var fileinfo = JsonConvert.SerializeObject(f1);

                    attachment = "{" + onuchhedSaveWithAttachments[0].data[0].id + ":" + fileinfo + "}";
                }
                

                Onuchhed o1 = new Onuchhed();
                o1.nothi_id = newnotedata.nothi_id.ToString();
                o1.nothi_office = newnotedata.office_id.ToString();
                o1.note_description = editorEncodedData;
                o1.note_id = newnotedata.note_id.ToString();
                o1.id = "0";
                o1.attachment = attachment;

                var onuchhed = JsonConvert.SerializeObject(o1);

                request.AddParameter("onucched", onuchhed);

                //foreach (DakUploadedFileResponse onuchhedSaveWithAttachment in onuchhedSaveWithAttachments)
                //{
                //    FileInfo f1 = new FileInfo();
                //    f1.attachment_type = onuchhedSaveWithAttachment.data[0].attachment_type;
                //    f1.user_file_name = onuchhedSaveWithAttachment.data[0].user_file_name;
                //    f1.id = onuchhedSaveWithAttachment.data[0].id;
                //    f1.file_name = onuchhedSaveWithAttachment.data[0].file_name;
                //    f1.file_size_in_kb = onuchhedSaveWithAttachment.data[0].file_size_in_kb;
                //    f1.img_base64 = onuchhedSaveWithAttachment.data[0].img_base64;
                //    f1.url = onuchhedSaveWithAttachment.data[0].url;

                //    var fileinfo = JsonConvert.SerializeObject(f1);

                //    var attachment = "{" + onuchhedSaveWithAttachment.data[0].id + ":" + fileinfo + "}";

                //    request.AddParameter("attachments", attachment);
                //}
                
                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;
                responseJson =  System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                NothiOnuchhedSaveResponse nothiOnuchhedSaveResponse = JsonConvert.DeserializeObject<NothiOnuchhedSaveResponse>(responseJson);
                return nothiOnuchhedSaveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public class FileInfo
        {
            public int id { get; set; }
            public string img_base64 { get; set; }
            public string user_file_name { get; set; }
            public string file_name { get; set; }
            public string attachment_type { get; set; }
            public string file_size_in_kb { get; set; }
            public string url { get; set; }
        }
        public class Onuchhed
        {
            public string nothi_id { get; set; }
            public string nothi_office { get; set; }
            public string note_id { get; set; }
            public string id { get; set; }
            public string note_description { get; set; }
            public string attachment { get; set; }
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

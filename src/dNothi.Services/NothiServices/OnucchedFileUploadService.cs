using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
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
    public class OnucchedFileUploadService : IOnucchedFileUploadService
    {
        public DakUploadedFileResponse GetOnuchhedUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam)
        {
            DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
            try
            {
                var client = new RestClient(GetAPIDomain() + GetOnuchhedFileUploadEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("model", dakFileUploadParam.model);
                request.AddParameter("office_id", dakListUserParam.office_id);
                request.AddParameter("designation_id", dakListUserParam.designation_id);
                request.AddParameter("path", dakFileUploadParam.path);
                request.AddParameter("file_size_in_kb", dakFileUploadParam.file_size_in_kb);
                request.AddParameter("user_file_name", dakFileUploadParam.user_file_name);
                request.AddParameter("content", dakFileUploadParam.content);
                
                IRestResponse response = client.Execute(request);

                var onucchedFileUploadResponseJson = response.Content;
                dakUploadedFileResponse = JsonConvert.DeserializeObject<DakUploadedFileResponse>(onucchedFileUploadResponseJson);
                return dakUploadedFileResponse;
            }
            catch (Exception ex)
            {
                return dakUploadedFileResponse;
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
        protected string GetOnuchhedFileUploadEndPoint()
        {
            return DefaultAPIConfiguration.OnuchhedFileUploadEndPoint;
        }
    }
}

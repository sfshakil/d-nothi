using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public class DakUploadService : IDakUploadService
    {
        public DakUploadedFileResponse GetDakUploadedFile(DakListUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam)
        {
            try
            {


                var dakFileUploadApi = new RestClient(GetAPIDomain() + GetDakUploadedFileEndpoint());
                dakFileUploadApi.Timeout = -1;
                var dakFileUploadRequest = new RestRequest(Method.POST);
                dakFileUploadRequest.AddHeader("api-version", GetAPIVersion());
                dakFileUploadRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakFileUploadRequest.AddHeader("model", dakFileUploadParam.model);
                dakFileUploadRequest.AlwaysMultipartFormData = true;
                dakFileUploadRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakFileUploadRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakFileUploadRequest.AddParameter("path", dakFileUploadParam.path);
                dakFileUploadRequest.AddParameter("file_size_in_kb", dakFileUploadParam.file_size_in_kb);
                dakFileUploadRequest.AddParameter("user_file_name", dakFileUploadParam.user_file_name);
                dakFileUploadRequest.AddParameter("content", dakFileUploadParam.content);
               
                IRestResponse dakFileUploadResponse = dakFileUploadApi.Execute(dakFileUploadRequest);


                var dakFileUploadResponseJson = dakFileUploadResponse.Content;
                DakUploadedFileResponse dakUploadedFileResponse = JsonConvert.DeserializeObject<DakUploadedFileResponse>(dakFileUploadResponseJson);
                return dakUploadedFileResponse;
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

        protected string GetOCREndpoint()
        {
            return DefaultAPIConfiguration.OCREndpoint;
        }
        protected string GetDakUploadedFileEndpoint()
        {
            return DefaultAPIConfiguration.DakFileUploadEndPoint;
        }
        protected string GetDakDeleteFileEndpoint()
        {
            return DefaultAPIConfiguration.DakFileDeleteEndPoint;
        }

        protected string GetDakUploadEndpoint()
        {
            return DefaultAPIConfiguration.DakUploadEndpoint;
        }

        public OCRResponse GetOCRResponsse(DakListUserParam dakListUserParam, OCRParameter oCRParameter)
        {
            try
            {


                var OCRApi = new RestClient(GetOCREndpoint());
                OCRApi.Timeout = -1;
                var oCRRequest = new RestRequest(Method.POST);
              
                oCRRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
             
                oCRRequest.AlwaysMultipartFormData = true;
                oCRRequest.AddParameter("image", oCRParameter.image());
                oCRRequest.AddParameter("language", oCRParameter.language);
               
                IRestResponse oCRApiResponse = OCRApi.Execute(oCRRequest);


                var oCRResponseJson = oCRApiResponse.Content;
                OCRResponse oCRResponse1 = JsonConvert.DeserializeObject<OCRResponse>(oCRResponseJson);

                return oCRResponse1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakFileDeleteResponse GetFileDeleteResponsse(DakListUserParam dakListUserParam, DakUploadFileDeleteParam deleteParam)
        {
            var deleteAPI = new RestClient(GetAPIDomain() + GetDakDeleteFileEndpoint());
            deleteAPI.Timeout = -1;
            var deleteRequest = new RestRequest(Method.POST);
            deleteRequest.AddHeader("api-version", "1");
            deleteRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            deleteRequest.AlwaysMultipartFormData = true;
            deleteRequest.AddParameter("office_id", dakListUserParam.office_id);
            deleteRequest.AddParameter("designation_id", dakListUserParam.designation_id);
            deleteRequest.AddParameter("file_name", deleteParam.file_name);
            deleteRequest.AddParameter("delete_token",deleteParam.delete_token);
            IRestResponse deleteResponse = deleteAPI.Execute(deleteRequest);

            var deleteResponseJson = deleteResponse.Content;
            DakFileDeleteResponse deleteResponse1 = JsonConvert.DeserializeObject<DakFileDeleteResponse>(deleteResponseJson);

            return deleteResponse1;



        }

        public DakUploadResponse GetDakUploadResponse(DakListUserParam dakListUserParam, DakUploadParameter dakUploadParameter)
        {
            var dakUploadAPI = new RestClient(GetAPIDomain() + GetDakUploadEndpoint());
            dakUploadAPI.Timeout = -1;
            var dakUploadRequest = new RestRequest(Method.POST);
            dakUploadRequest.AddHeader("api-version", GetAPIVersion());
            dakUploadRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            dakUploadRequest.AddParameter("sender",dakUploadParameter.sender_info);
            dakUploadRequest.AddParameter("receiver", dakUploadParameter.receiver_info);
            dakUploadRequest.AddParameter("dak",dakUploadParameter.dak_info);
            dakUploadRequest.AddParameter("others",dakUploadParameter.others);
            dakUploadRequest.AddParameter("uploader", dakUploadParameter.uploader);
            dakUploadRequest.AddParameter("path", dakUploadParameter.path);
            dakUploadRequest.AddParameter("content", dakUploadParameter.content);
            dakUploadRequest.AddParameter("office_id", dakUploadParameter.office_id);
            dakUploadRequest.AddParameter("designation_id", dakUploadParameter.designation_id);
            IRestResponse dakUploadIRestResponse = dakUploadAPI.Execute(dakUploadRequest);
            var dakFileUploadResponseJson = dakUploadIRestResponse.Content;
            DakUploadResponse dakUploadResponse = JsonConvert.DeserializeObject<DakUploadResponse>(dakFileUploadResponseJson);
            return dakUploadResponse;
        }
    }
}

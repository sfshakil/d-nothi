using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        public DakUploadedFileResponse GetDakUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam)
        {
            DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
            try
            {


                var dakFileUploadApi = new RestClient(GetAPIDomain() + GetDakUploadedFileEndpoint());
                dakFileUploadApi.Timeout = -1;
                var dakFileUploadRequest = new RestRequest(Method.POST);
                dakFileUploadRequest.AddHeader("api-version", GetAPIVersion());
                dakFileUploadRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
              //  dakFileUploadRequest.AddHeader("model", dakFileUploadParam.model);
                dakFileUploadRequest.AlwaysMultipartFormData = true;
                dakFileUploadRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakFileUploadRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakFileUploadRequest.AddParameter("path", dakFileUploadParam.path);
                dakFileUploadRequest.AddParameter("file_size_in_kb", dakFileUploadParam.file_size_in_kb);
                dakFileUploadRequest.AddParameter("user_file_name", dakFileUploadParam.user_file_name);
                dakFileUploadRequest.AddParameter("content", dakFileUploadParam.content);
               
                IRestResponse dakFileUploadResponse = dakFileUploadApi.Execute(dakFileUploadRequest);


                var dakFileUploadResponseJson = dakFileUploadResponse.Content;
                dakUploadedFileResponse = JsonConvert.DeserializeObject<DakUploadedFileResponse>(dakFileUploadResponseJson);
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

        protected string GetDakSendEndpoint()
        {
            return DefaultAPIConfiguration.DakSendEndpoint;
        }
        protected string GetDakDraftEndpoint()
        {
            return DefaultAPIConfiguration.DakDraftEndpoint;
        }
        protected string GetAllDesignationSealEndpoint()
        {
            return DefaultAPIConfiguration.AllDesignationSealEndPoint;
        }   
        protected string GetOfficeListEndpoint()
        {
            return DefaultAPIConfiguration.OfficeListEndpoint;
        }
        protected string GetDraftedDakDeleteEndpoint()
        {
            return DefaultAPIConfiguration.DraftedDakDeleteEndpoint;
        }

        public OCRResponse GetOCRResponsse(DakUserParam dakListUserParam, OCRParameter oCRParameter)
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

        public DakFileDeleteResponse GetFileDeleteResponsse(DakUserParam dakListUserParam, DakUploadFileDeleteParam deleteParam)
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

        public DakDraftedResponse GetDakDraftedResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter)
        {
            var dakDraftedAPI = new RestClient(GetAPIDomain() + GetDakDraftEndpoint());
            dakDraftedAPI.Timeout = -1;
            var dakDraftedRequest = new RestRequest(Method.POST);
            dakDraftedRequest.AddHeader("api-version", GetAPIVersion());
            dakDraftedRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            dakDraftedRequest.AddParameter("sender",dakUploadParameter.sender_info);
            dakDraftedRequest.AddParameter("receiver", dakUploadParameter.receiver_info);
            dakDraftedRequest.AddParameter("dak",dakUploadParameter.dak_info);
            dakDraftedRequest.AddParameter("others",dakUploadParameter.others);
            dakDraftedRequest.AddParameter("uploader", dakUploadParameter.uploader);
            dakDraftedRequest.AddParameter("path", dakUploadParameter.path);
            dakDraftedRequest.AddParameter("content", dakUploadParameter.content);
            dakDraftedRequest.AddParameter("office_id", dakUploadParameter.office_id);
            dakDraftedRequest.AddParameter("designation_id", dakUploadParameter.designation_id);
            IRestResponse dakDraftedIRestResponse = dakDraftedAPI.Execute(dakDraftedRequest);
            var dakDraftedResponseJson = dakDraftedIRestResponse.Content;
            int firstStringIndex = dakDraftedResponseJson.IndexOf("{\"status\":");

            var jsonStringDiscardedGarbage = dakDraftedResponseJson.Substring(firstStringIndex, dakDraftedResponseJson.Length - firstStringIndex);
            //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
            // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();



            var dakDraftedResponse = JsonConvert.DeserializeObject<DakDraftedResponse>(jsonStringDiscardedGarbage, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });
            
            return dakDraftedResponse;
        }
      

        public AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam,int office_id)
        {
            var designationSealAPI = new RestClient(GetAPIDomain() + GetAllDesignationSealEndpoint());
            designationSealAPI.Timeout = -1;
            var designationSealRequest = new RestRequest(Method.POST);
            designationSealRequest.AddHeader("api-version", GetAPIVersion());
            designationSealRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
       
            designationSealRequest.AddParameter("office_id",office_id);
            designationSealRequest.AddParameter("cdesk", dakListUserParam.json_String);
            IRestResponse designationSealIRestResponse = designationSealAPI.Execute(designationSealRequest);
            var designationSealResponseJson = designationSealIRestResponse.Content;
            AllDesignationSealListResponse designationSealListResponse = JsonConvert.DeserializeObject<AllDesignationSealListResponse>(designationSealResponseJson);
            return designationSealListResponse;
        }

        public OfficeListResponse GetAllOffice(DakUserParam dakListUserParam)
        {
            var dakOfficeAPI = new RestClient(GetAPIDomain() + GetOfficeListEndpoint());
            dakOfficeAPI.Timeout = -1;
            var dakOfficeRequest = new RestRequest(Method.POST);
            dakOfficeRequest.AddHeader("api-version", GetAPIVersion());
            dakOfficeRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            dakOfficeRequest.AddParameter("office_id", dakListUserParam.office_id);
            dakOfficeRequest.AddParameter("cdesk", dakListUserParam.json_String);

            IRestResponse dakOfficeIRestResponse = dakOfficeAPI.Execute(dakOfficeRequest);
            var dakOfficeResponseJson = dakOfficeIRestResponse.Content;
            OfficeListResponse officeListResponse = JsonConvert.DeserializeObject<OfficeListResponse>(dakOfficeResponseJson);
            return officeListResponse;
        }

        

        DakUploadResponse IDakUploadService.GetDakSendResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter)
        {
            var dakSendAPI = new RestClient(GetAPIDomain() + GetDakSendEndpoint());
            dakSendAPI.Timeout = -1;
            var dakSendRequest = new RestRequest(Method.POST);
            dakSendRequest.AddHeader("api-version", GetAPIVersion());
            dakSendRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            dakSendRequest.AddParameter("sender", dakUploadParameter.sender_info);
            dakSendRequest.AddParameter("receiver", dakUploadParameter.receiver_info);
            dakSendRequest.AddParameter("dak", dakUploadParameter.dak_info);
            dakSendRequest.AddParameter("others", dakUploadParameter.others);
            dakSendRequest.AddParameter("uploader", dakUploadParameter.uploader);
            dakSendRequest.AddParameter("path", dakUploadParameter.path);
            dakSendRequest.AddParameter("content", dakUploadParameter.content);
            dakSendRequest.AddParameter("office_id", dakUploadParameter.office_id);
            dakSendRequest.AddParameter("designation_id", dakUploadParameter.designation_id);
            IRestResponse dakSendIRestResponse = dakSendAPI.Execute(dakSendRequest);
            var dakSendResponseJson = dakSendIRestResponse.Content;

            var dakSendResponse = JsonConvert.DeserializeObject<DakUploadResponse>(dakSendResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });


         
            return dakSendResponse;
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public DakUploadResponse GetDraftedDakSendResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            var draftedDakSendAPI = new RestClient(GetAPIDomain() + GetDraftedDakSendEndpoint());
            draftedDakSendAPI.Timeout = -1;
            var draftedDakSendRequest = new RestRequest(Method.POST);
            draftedDakSendRequest.AddHeader("api-version", GetAPIVersion());
            draftedDakSendRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            draftedDakSendRequest.AddParameter("office_id", dakUserParam.office_id);
            draftedDakSendRequest.AddParameter("designation_id", dakUserParam.designation_id);
            draftedDakSendRequest.AddParameter("is_copied_dak",is_copied_dak);
            draftedDakSendRequest.AddParameter("dak_id", dak_id);
            draftedDakSendRequest.AddParameter("dak_type", dak_type);
            IRestResponse dakSendIRestResponse = draftedDakSendAPI.Execute(draftedDakSendRequest);
            var dakSendResponseJson = dakSendIRestResponse.Content;

            int firstStringIndex = dakSendResponseJson.IndexOf("{\"status\":");

            var jsonStringDiscardedGarbage = dakSendResponseJson.Substring(firstStringIndex, dakSendResponseJson.Length - firstStringIndex);
            //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
            // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
          


            var dakSendResponse = JsonConvert.DeserializeObject<DakUploadResponse>(jsonStringDiscardedGarbage, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakSendResponse;
        }

        private string GetDraftedDakSendEndpoint()
        {
            return DefaultAPIConfiguration.DraftedDakSendEndpoint;
        }

        public DraftedDakDeleteResponse GetDraftedDakDeleteResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            var draftedDakDeleteAPI = new RestClient(GetAPIDomain() + GetDraftedDakDeleteEndpoint());
            draftedDakDeleteAPI.Timeout = -1;
            var draftedDakDeleteRequest = new RestRequest(Method.POST);
            draftedDakDeleteRequest.AddHeader("api-version", GetAPIVersion());
            draftedDakDeleteRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            draftedDakDeleteRequest.AddParameter("office_id", dakUserParam.office_id);
            draftedDakDeleteRequest.AddParameter("designation_id", dakUserParam.designation_id);
            draftedDakDeleteRequest.AddParameter("is_copied_dak", is_copied_dak);
            draftedDakDeleteRequest.AddParameter("dak_id", dak_id);
            draftedDakDeleteRequest.AddParameter("dak_type", dak_type);
            IRestResponse dakDeleteIRestResponse = draftedDakDeleteAPI.Execute(draftedDakDeleteRequest);
            var dakDeleteResponseJson = dakDeleteIRestResponse.Content;

            var dakDeleteResponse = JsonConvert.DeserializeObject<DraftedDakDeleteResponse>(dakDeleteResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakDeleteResponse;
        }

        public DraftedDakEditResponse GetDraftedDakEditResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            var draftedDakEditAPI = new RestClient(GetAPIDomain() + GetDraftedDakEditEndpoint());
            draftedDakEditAPI.Timeout = -1;
            var draftedDakEditRequest = new RestRequest(Method.POST);
            draftedDakEditRequest.AddHeader("api-version", GetAPIVersion());
            draftedDakEditRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            draftedDakEditRequest.AddParameter("office_id", dakUserParam.office_id);
            draftedDakEditRequest.AddParameter("designation_id", dakUserParam.designation_id);
            draftedDakEditRequest.AddParameter("is_copied_dak", is_copied_dak);
            draftedDakEditRequest.AddParameter("dak_id", dak_id);
            draftedDakEditRequest.AddParameter("dak_type", dak_type);
            IRestResponse dakEditIRestResponse = draftedDakEditAPI.Execute(draftedDakEditRequest);
            var dakEditResponseJson = dakEditIRestResponse.Content;

            var dakEditResponse = JsonConvert.DeserializeObject<DraftedDakEditResponse>(dakEditResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakEditResponse;
        }

        private string GetDraftedDakEditEndpoint()
        {
            return DefaultAPIConfiguration.DraftedDakEditEndpoint;
        }
        private string GetDesignationSealAddEndpoint()
        {
            return DefaultAPIConfiguration.DesignationSealAddEndpoint;
        }
        private string GetDesignationSealDeleteEndpoint()
        {
            return DefaultAPIConfiguration.DesignationSealDeleteEndpoint;
        }


        public AddDesignationSealResponse GetDesiognationSealAddResponse(DakUserParam dakUserParam, string sealInfo)
        {
            
            var designationAddAPI = new RestClient(GetAPIDomain() + GetDesignationSealAddEndpoint());
            designationAddAPI.Timeout = -1;
            var designationSealAddRequest = new RestRequest(Method.POST);
            designationSealAddRequest.AddHeader("api-version", GetAPIVersion());
            designationSealAddRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
      
            designationSealAddRequest.AddParameter("designation_id", dakUserParam.designation_id);
          
            designationSealAddRequest.AddParameter("seal_info", sealInfo);
            IRestResponse designationSealAddIRestResponse = designationAddAPI.Execute(designationSealAddRequest);
            var designationSealAddResponseJson = designationSealAddIRestResponse.Content;

            var designationAddResponse = JsonConvert.DeserializeObject<AddDesignationSealResponse>(designationSealAddResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return designationAddResponse;
        }

        public DeleteDesignationSealResponse GetDesiognationSealDeleteResponse(DakUserParam dakUserParam, string remove_designation_ids)
        {
            var designationDeleteAPI = new RestClient(GetAPIDomain() + GetDesignationSealDeleteEndpoint());
            designationDeleteAPI.Timeout = -1;
            var designationSealDeleteRequest = new RestRequest(Method.POST);
            designationSealDeleteRequest.AddHeader("api-version", GetAPIVersion());
            designationSealDeleteRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);

            designationSealDeleteRequest.AddParameter("designation_id", dakUserParam.designation_id);

            designationSealDeleteRequest.AddParameter("remove_designation_ids", remove_designation_ids);
            IRestResponse designationSealDeleteIRestResponse = designationDeleteAPI.Execute(designationSealDeleteRequest);
            var designationSealDeleteResponseJson = designationSealDeleteIRestResponse.Content;

            var designationDeleteResponse = JsonConvert.DeserializeObject<DeleteDesignationSealResponse>(designationSealDeleteResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return designationDeleteResponse;
        }
    }
}

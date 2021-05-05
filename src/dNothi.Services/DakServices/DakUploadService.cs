using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Services.UserServices;
using dNothi.Utility;
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
        IRepository<LocalUploadedDak> _localUploadedDakRepository;
        public IUserService _userService { get; set;}
        IRepository<AllOfficeItem> _allOfficeItem;
        IRepository<DakItemDetails> _dakItemRepository;
        public DakUploadService(IRepository<DakItemDetails> dakItemRepository,IRepository<LocalUploadedDak> localUploadedDak, IUserService userService, IRepository<AllOfficeItem> allOfficeItem)
        {
            _dakItemRepository = dakItemRepository;
            _localUploadedDakRepository = localUploadedDak;
            _userService = userService;
            _allOfficeItem = allOfficeItem;
        }
        public DakUploadedFileResponse GetDakUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam)
        {
            DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
            if (!InternetConnection.Check())
            {
                dakUploadedFileResponse.status = "success";
                dakUploadedFileResponse.data = new List<DakAttachmentDTO>();
                DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();

                dakAttachmentDTO.path = dakFileUploadParam.path;
                dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                dakAttachmentDTO.content_body = dakFileUploadParam.content;
                dakUploadedFileResponse.data.Add(dakAttachmentDTO);


                return dakUploadedFileResponse;

            }


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
            deleteRequest.AddParameter("delete_token", deleteParam.delete_token);
            IRestResponse deleteResponse = deleteAPI.Execute(deleteRequest);

            var deleteResponseJson = deleteResponse.Content;
            DakFileDeleteResponse deleteResponse1 = JsonConvert.DeserializeObject<DakFileDeleteResponse>(deleteResponseJson);

            return deleteResponse1;



        }

        public DakDraftedResponse GetLocalDakDraftedResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter)
        {
            DakDraftedResponse dakSendResponse = new DakDraftedResponse();


            dakUploadParameter.remoteAttachments.AddRange(UploadDakAttachmentList(dakListUserParam, dakUploadParameter.localAttachments));

            dakUploadParameter.dak_Info_Obj.attachment = dakUploadParameter.remoteAttachments.ToDictionary(a => a.file_infoModel.id.ToString());
            dakUploadParameter.dak_info = dakUploadParameter.CSharpObjtoJson(dakUploadParameter.dak_Info_Obj);

            var dakSendAPI = new RestClient(GetAPIDomain() + GetDakDraftEndpoint());
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

            dakSendResponse = JsonConvert.DeserializeObject<DakDraftedResponse>(dakSendResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });




            return dakSendResponse;
        }
        public DakDraftedResponse GetDakDraftedResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter)
        {
            DakDraftedResponse dakSendResponse = new DakDraftedResponse();
            if (!InternetConnection.Check())
            {
                dakSendResponse.status = "success";
               dakSendResponse.data = "ইন্টারনেট সংযোগ ফিরে এলে এই ডাকটি খসড়া করা হবে!";
                //dakSendResponse.me = "Request Pending!";
                DakUploadLocally(dakUploadParameter,true);

                return dakSendResponse;
            }

            dakUploadParameter.dak_Info_Obj.attachment = dakUploadParameter.remoteAttachments.ToDictionary(a => a.file_infoModel.id.ToString());
            dakUploadParameter.dak_info = dakUploadParameter.CSharpObjtoJson(dakUploadParameter.dak_Info_Obj);


            var dakDraftedAPI = new RestClient(GetAPIDomain() + GetDakDraftEndpoint());
            dakDraftedAPI.Timeout = -1;
            var dakDraftedRequest = new RestRequest(Method.POST);
            dakDraftedRequest.AddHeader("api-version", GetAPIVersion());
            dakDraftedRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            dakDraftedRequest.AddParameter("sender", dakUploadParameter.sender_info);
            dakDraftedRequest.AddParameter("receiver", dakUploadParameter.receiver_info);
            dakDraftedRequest.AddParameter("dak", dakUploadParameter.dak_info);
            dakDraftedRequest.AddParameter("others", dakUploadParameter.others);
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


        public AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam, int office_id)
        {
            AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                AllOfficeItem allOfficeItem = _allOfficeItem.Table.FirstOrDefault(a => a.office_unit_id == dakListUserParam.office_unit_id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (allOfficeItem != null)
                {
                    designationSealListResponse = JsonConvert.DeserializeObject<AllDesignationSealListResponse>(allOfficeItem.designationSealResponseJson);

                }
                return designationSealListResponse;
            }
            try
            {
                var designationSealAPI = new RestClient(GetAPIDomain() + GetAllDesignationSealEndpoint());
                designationSealAPI.Timeout = -1;
                var designationSealRequest = new RestRequest(Method.POST);
                designationSealRequest.AddHeader("api-version", GetAPIVersion());
                designationSealRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);

                designationSealRequest.AddParameter("office_id", office_id);
                designationSealRequest.AddParameter("cdesk", dakListUserParam.json_String);
                IRestResponse designationSealIRestResponse = designationSealAPI.Execute(designationSealRequest);
                var designationSealResponseJson = designationSealIRestResponse.Content;
                SaveOrUpdateAllOfficeandDesignationSeal(dakListUserParam, designationSealResponseJson, false);
                designationSealListResponse = JsonConvert.DeserializeObject<AllDesignationSealListResponse>(designationSealResponseJson);
                return designationSealListResponse;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public OfficeListResponse GetAllOffice(DakUserParam dakListUserParam)
        {
            OfficeListResponse officeListResponse = new OfficeListResponse();

            if (!dNothi.Utility.InternetConnection.Check())
            {
                AllOfficeItem allOfficeItem = _allOfficeItem.Table.FirstOrDefault(a => a.office_unit_id == dakListUserParam.office_unit_id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                if (allOfficeItem != null)
                {
                    officeListResponse = JsonConvert.DeserializeObject<OfficeListResponse>(allOfficeItem.dakOfficeResponseJson);

                }
                return officeListResponse;
            }

            try
            {
                var dakOfficeAPI = new RestClient(GetAPIDomain() + GetOfficeListEndpoint());
                dakOfficeAPI.Timeout = -1;
                var dakOfficeRequest = new RestRequest(Method.POST);
                dakOfficeRequest.AddHeader("api-version", GetAPIVersion());
                dakOfficeRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakOfficeRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakOfficeRequest.AddParameter("cdesk", dakListUserParam.json_String);

                IRestResponse dakOfficeIRestResponse = dakOfficeAPI.Execute(dakOfficeRequest);
                var dakOfficeResponseJson =ConversionMethod.FilterJsonResponse(dakOfficeIRestResponse.Content);
                SaveOrUpdateAllOfficeandDesignationSeal(dakListUserParam, dakOfficeResponseJson, true);
                officeListResponse = JsonConvert.DeserializeObject<OfficeListResponse>(dakOfficeResponseJson);
                return officeListResponse;
            }

            catch (Exception ex)
            {
                throw;
            }

        }

        public void SaveOrUpdateAllOfficeandDesignationSeal(DakUserParam dakListUserParam, string responseJson, bool alloffice)
        {
            AllOfficeItem allOfficeItemDB = _allOfficeItem.Table.FirstOrDefault(a => a.office_unit_id == dakListUserParam.office_unit_id && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

            if (alloffice)
            {
                if (allOfficeItemDB != null)
                {
                    allOfficeItemDB.dakOfficeResponseJson = responseJson;
                    _allOfficeItem.Update(allOfficeItemDB);
                }
                else
                {
                    AllOfficeItem allOfficeItem = new AllOfficeItem();
                    allOfficeItem.designation_id = dakListUserParam.designation_id;
                    allOfficeItem.office_id = dakListUserParam.office_id;
                    allOfficeItem.office_unit_id = dakListUserParam.office_unit_id;
                    allOfficeItem.dakOfficeResponseJson = responseJson;
                    _allOfficeItem.Insert(allOfficeItem);

                }
            }
            else
            {
                if (allOfficeItemDB != null)
                {
                    allOfficeItemDB.designationSealResponseJson = responseJson;
                    _allOfficeItem.Update(allOfficeItemDB);
                }
                else
                {
                    AllOfficeItem allOfficeItem = new AllOfficeItem();
                    allOfficeItem.designation_id = dakListUserParam.designation_id;
                    allOfficeItem.office_id = dakListUserParam.office_id;
                    allOfficeItem.office_unit_id = dakListUserParam.office_unit_id;
                    allOfficeItem.designationSealResponseJson = responseJson;
                    _allOfficeItem.Insert(allOfficeItem);

                }
            }
        }

        public DakUploadResponse GetDakSendResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter)
        {
            DakUploadResponse dakSendResponse = new DakUploadResponse();
            if (!InternetConnection.Check())
            {
                dakSendResponse.status = "success";
                dakSendResponse.data = new DakSendResponseMessageDTO();
                dakSendResponse.data.message = "Request Pending!";
                DakUploadLocally(dakUploadParameter,false);

                return dakSendResponse;
            }

            dakUploadParameter.remoteAttachments.AddRange(UploadDakAttachmentList(dakListUserParam, dakUploadParameter.localAttachments));

            dakUploadParameter.dak_Info_Obj.attachment = dakUploadParameter.remoteAttachments.ToDictionary(a => a.file_infoModel.id.ToString());
            dakUploadParameter.dak_info = dakUploadParameter.CSharpObjtoJson(dakUploadParameter.dak_Info_Obj);

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

            dakSendResponse = JsonConvert.DeserializeObject<DakUploadResponse>(dakSendResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });




            return dakSendResponse;
        }

        public DakUploadResponse GetLocalUploadDakSendResponse(DakUserParam dakListUserParam, DakUploadParameter dakUploadParameter)
        {
            DakUploadResponse dakSendResponse = new DakUploadResponse();


            dakUploadParameter.remoteAttachments.AddRange(UploadDakAttachmentList(dakListUserParam, dakUploadParameter.localAttachments));

            dakUploadParameter.dak_Info_Obj.attachment = dakUploadParameter.remoteAttachments.ToDictionary(a => a.file_infoModel.id.ToString());
            dakUploadParameter.dak_info = dakUploadParameter.CSharpObjtoJson(dakUploadParameter.dak_Info_Obj);

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

            dakSendResponse = JsonConvert.DeserializeObject<DakUploadResponse>(dakSendResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });




            return dakSendResponse;
        }


        public List<DakListRecordsDTO> GetPendingDakUpload(bool is_Drafted)
            {
               List <DakListRecordsDTO> dakListRecordsDTOs= new List<DakListRecordsDTO>();

               DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

               var localUploadedDaks = _localUploadedDakRepository.Table.Where(a => a.designation_id == dakUserParam.designation_id && a.office_id == dakUserParam.office_id && a.is_Drafted_Dak==is_Drafted).ToList();



            if (localUploadedDaks != null)
            {
                foreach (LocalUploadedDak localUploadedDak in localUploadedDaks)
                {
                    DakUploadParameter dakUploadParameter = new DakUploadParameter();
                    dakUploadParameter = JsonConvert.DeserializeObject<DakUploadParameter>(localUploadedDak.uploaded_Dak_Json);

                    DakListRecordsDTO dakListRecordsDTO = new DakListRecordsDTO();
                    dakListRecordsDTO.dak_user = new DakUserDTO();
                    dakListRecordsDTO.dak_origin = new DakOriginDTO();
                    dakListRecordsDTO.dak_user = new DakUserDTO();
                    DakInfo dak = new DakInfo(true);

                    dak = JsonConvert.DeserializeObject<DakInfo>(dakUploadParameter.dak_info);
                    DakUploadReceiver dakUploadReceiver = JsonConvert.DeserializeObject<DakUploadReceiver>(dakUploadParameter.receiver_info);

                    dakListRecordsDTO.dak_id_Remote = dak.id;

                    if (dakUploadParameter.sender_info=="[]")
                    {
                        dakListRecordsDTO.dak_user.dak_type = "Nagorik";


                        dakListRecordsDTO.dak_origin.sender_name = dak.name_bng;
                        dakListRecordsDTO.dak_origin.sender_name = dak.name_bng;
                        dakListRecordsDTO.dak_origin.sender_name = dak.name_bng;
                        dakListRecordsDTO.dak_origin.name_bng = dak.name_bng;
                    }
                    else
                    {
                        PrapokDTO prapokDTO = JsonConvert.DeserializeObject<PrapokDTO>(dakUploadParameter.sender_info) ;
                        dakListRecordsDTO.dak_user.dak_type = "Daptorik";
                        dakListRecordsDTO.dak_origin.sender_office_name = prapokDTO.office_name_bng;
                        dakListRecordsDTO.dak_origin.sender_office_unit_name = prapokDTO.office_unit_bng;
                        dakListRecordsDTO.dak_origin.sender_officer_designation_label = prapokDTO.designation_bng;

                        dakListRecordsDTO.dak_origin.sender_name = prapokDTO.officer_bng;
                        dakListRecordsDTO.dak_origin.name_bng = prapokDTO.officer_bng;
                    }


                    
                  


                    dakListRecordsDTO.dak_user.last_movement_date="";
                    dakListRecordsDTO.dak_user.dak_id= Convert.ToInt32(localUploadedDak.Id);


                    dakListRecordsDTO.dak_user.dak_subject=dak.dak_subject;

                   // dakListRecordsDTO.dak_user.dak_decision=dak;
                    //dakOutboxUserControl.dakViewStatus = dakListInboxRecordsDTO.dak_user.dak_view_status;

                   

                    dakListRecordsDTO.dak_origin.receiving_officer_name= dakUploadReceiver.mul_prapok.office_name_bng;
                    dakListRecordsDTO.dak_origin.receiving_office_name = dakUploadReceiver.mul_prapok.office_name_bng;
                    dakListRecordsDTO.dak_origin.receiving_office_unit_name = dakUploadReceiver.mul_prapok.office_unit_bng;
                    dakListRecordsDTO.dak_origin.receiving_officer_designation_label = dakUploadReceiver.mul_prapok.designation_bng;

                    dakListRecordsDTO.dak_user.attention_type="0";
                    dakListRecordsDTO.dak_user.dak_decision= "সদয় সিদ্ধান্তের জন্যে প্রেরণ করা হলো";
                    dakListRecordsDTO.dak_user.dak_security=dak.security;
                    dakListRecordsDTO.dak_user.dak_priority = dak.priority;
               
                    dakListRecordsDTO.dak_user.from_potrojari=0;
                    dakListRecordsDTO.attachment_count= dakUploadParameter.localAttachments.Count+dakUploadParameter.remoteAttachments.Count;



                    dakListRecordsDTOs.Add(dakListRecordsDTO);
                }
            }



            return dakListRecordsDTOs;

            
            
        }

        public bool UploadDakFromLocal()
        {

            bool isUploaded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            var localUploadedDaks = _localUploadedDakRepository.Table.Where(a => a.designation_id == dakUserParam.designation_id && a.office_id == dakUserParam.office_id).ToList();
          


            if(localUploadedDaks != null)
            {
                foreach(LocalUploadedDak localUploadedDak in  localUploadedDaks)
                {

                    DakUploadParameter dakUploadParameter = new DakUploadParameter();
                    dakUploadParameter= JsonConvert.DeserializeObject<DakUploadParameter>(localUploadedDak.uploaded_Dak_Json);

                    

                   if(localUploadedDak.is_Drafted_Dak)
                    {
                        DakDraftedResponse dakDraftedResponse = GetLocalDakDraftedResponse(dakUserParam, dakUploadParameter);
                        if (dakDraftedResponse != null && dakDraftedResponse.status == "success")
                        {
                            _localUploadedDakRepository.Delete(localUploadedDak);
                            isUploaded = true;
                        }
                    }
                    else
                    {
                        DakUploadResponse dakUploadResponse = GetLocalUploadDakSendResponse(dakUserParam, dakUploadParameter);
                        if (dakUploadResponse != null && dakUploadResponse.status == "success")
                        {
                            _localUploadedDakRepository.Delete(localUploadedDak);
                            isUploaded = true;
                        }
                    }

                    

                    
                }
            }

            return isUploaded;

        } 
        public bool UploadDakFromLocal(int dak_id)
        {

            bool isUploaded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            var localUploadedDaks = _localUploadedDakRepository.Table.Where(a => a.designation_id == dakUserParam.designation_id && a.office_id == dakUserParam.office_id && a.Id==dak_id).ToList();
          


            if(localUploadedDaks != null)
            {
                foreach(LocalUploadedDak localUploadedDak in  localUploadedDaks)
                {

                    DakUploadParameter dakUploadParameter = new DakUploadParameter();
                    dakUploadParameter= JsonConvert.DeserializeObject<DakUploadParameter>(localUploadedDak.uploaded_Dak_Json);
                   
                    DakUploadResponse dakUploadResponse=  GetLocalUploadDakSendResponse(dakUserParam, dakUploadParameter);
                    if(dakUploadResponse!= null && dakUploadResponse.status=="success")
                    {
                        _localUploadedDakRepository.Delete(localUploadedDak);
                        isUploaded = true;
                    }

                    
                }
            }

            return isUploaded;

        }

        private IEnumerable<DakUploadAttachment> UploadDakAttachmentList(DakUserParam dakListUserParam,List<DakUploadAttachment> localAttachments)
        {
           foreach(DakUploadAttachment dakUploadAttachment in localAttachments)
            {
                DakFileUploadParam dakFileUploadParam = new DakFileUploadParam { content= dakUploadAttachment.file_infoModel.content_body,file_size_in_kb=dakUploadAttachment.file_infoModel.file_size_in_kb,path= dakUploadAttachment.file_infoModel.path, user_file_name=dakUploadAttachment.file_infoModel.user_file_name};
                DakUploadedFileResponse dakUploadedFileResponse = GetDakUploadedFile(dakListUserParam, dakFileUploadParam);

                if (dakUploadedFileResponse.status=="success")
                {
                   


                    dakUploadAttachment.file_infoModel = dakUploadedFileResponse.data[0];
                    dakUploadAttachment.file_info = JsonParsingMethod.ObjecttoJson(dakUploadAttachment.file_infoModel);




                }
                else
                {
                    localAttachments.Remove(dakUploadAttachment);
                }

            }

            return localAttachments;
        }

        private void DakUploadLocally(DakUploadParameter dakUploadParameter, bool is_drafted)
        {
            LocalUploadedDak localUploadedDak = new LocalUploadedDak { is_Drafted_Dak = is_drafted, office_id=dakUploadParameter.office_id,designation_id=dakUploadParameter.designation_id, uploaded_Dak_Json=JsonParsingMethod.ObjecttoJson(dakUploadParameter)};

            _localUploadedDakRepository.Insert(localUploadedDak);
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public DakUploadResponse GetDraftedDakSendResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak,bool is_local)
        {
            DakUploadResponse dakSendResponse = new DakUploadResponse();

            if (is_local)
            {


                try
                {
                    var localDakUploadeParam = _localUploadedDakRepository.Table.FirstOrDefault(a => a.is_Drafted_Dak == true && a.Id == dak_id);
                    if (localDakUploadeParam != null)
                    {
                        localDakUploadeParam.is_Drafted_Dak = false;
                        _localUploadedDakRepository.Update(localDakUploadeParam);
                        dakSendResponse.status = "success";
                        return dakSendResponse;
                    }
                }
                catch
                {
                    dakSendResponse.status = "error";
                    return dakSendResponse;
                }

                
            }



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
          


             dakSendResponse = JsonConvert.DeserializeObject<DakUploadResponse>(jsonStringDiscardedGarbage, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakSendResponse;
        }

        private string GetDraftedDakSendEndpoint()
        {
            return DefaultAPIConfiguration.DraftedDakSendEndpoint;
        }

        public DraftedDakDeleteResponse GetDraftedDakDeleteResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak, bool is_local)
        {
            DraftedDakDeleteResponse dakDeleteResponse = new DraftedDakDeleteResponse();

            if (is_local)
            {


                try
                {
                    var localDakUploadeParam = _localUploadedDakRepository.Table.FirstOrDefault(a => a.is_Drafted_Dak == true && a.Id == dak_id);
                    if (localDakUploadeParam != null)
                    {

                        _localUploadedDakRepository.Delete(localDakUploadeParam);
                    }
                    dakDeleteResponse.status = "success";
                    return dakDeleteResponse;
                }

                catch
                {
                    dakDeleteResponse.status = "error";
                    return dakDeleteResponse;
                }
            }

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

             dakDeleteResponse = JsonConvert.DeserializeObject<DraftedDakDeleteResponse>(dakDeleteResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakDeleteResponse;
        }

        public DraftedDakEditResponse GetDraftedDakEditResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            DraftedDakEditResponse dakEditResponse = new DraftedDakEditResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var dakEditDetails = _dakItemRepository.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_KhosraDetails == true );

                if (dakEditDetails != null && dakEditDetails.dak_details_Json != null)
                {
                    dakEditResponse = JsonConvert.DeserializeObject<DraftedDakEditResponse>(dakEditDetails.dak_details_Json, new JsonSerializerSettings
                    {
                        Error = HandleDeserializationError
                    });
                }
                return dakEditResponse;
            }

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
            SaveKhosraDetailsJsonResponse(dak_id, dakEditResponseJson);


             dakEditResponse = JsonConvert.DeserializeObject<DraftedDakEditResponse>(dakEditResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakEditResponse;
        }

        private void SaveKhosraDetailsJsonResponse(int dak_id, string dakEditResponse)
        {
            var dakEditDetails = _dakItemRepository.Table.FirstOrDefault(a => a.dak_id == dak_id && a.is_KhosraDetails == true);

            if (dakEditDetails != null)
            {
                dakEditDetails.dak_details_Json = dakEditResponse;
                _dakItemRepository.Update(dakEditDetails);
            }
            else
            {
                dakEditDetails = new DakItemDetails
                {
                    dak_id = dak_id,
                    is_KhosraDetails = true,
                    dak_details_Json = dakEditResponse
                    
                
                
                };

                _dakItemRepository.Insert(dakEditDetails);
            }
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

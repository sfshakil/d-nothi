using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
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
        IRepository<FileUploadAction> _fileUploadAction;
        IRepository<OnuchhedSaveItemAction> _onuchhedSaveItemAction;
        IUserService _userService { get; set; }
        public OnucchedFileUploadService(IUserService userService, IRepository<FileUploadAction> fileUploadAction, IRepository<OnuchhedSaveItemAction> onuchhedSaveItemAction)
        {
            _userService = userService;
            _fileUploadAction = fileUploadAction;
            _onuchhedSaveItemAction = onuchhedSaveItemAction;
        }
        public DakUploadedFileResponse GetOnuchhedUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam)
        {
            DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                dakUploadedFileResponse.status = "success";
                dakUploadedFileResponse.message = "Local";

                FileUploadAction fileUploadAction = new FileUploadAction();
                
                string dup = JsonConvert.SerializeObject(dakListUserParam);
                string oswa = JsonConvert.SerializeObject(dakFileUploadParam);

                fileUploadAction.dakListUserParamJson = dup;
                fileUploadAction.dakFileUploadParamJson = oswa;
                fileUploadAction.designation_id = dakListUserParam.designation_id;
                fileUploadAction.office_id = dakListUserParam.office_id;
                _fileUploadAction.Insert(fileUploadAction);
                
                //List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id && a.dakListUserParamJson == dup && a.dakFileUploadParamJson == oswa).ToList();
                
                dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                dakAttachmentDTO.id = fileUploadAction.Id;

                dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                return dakUploadedFileResponse;
            }
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
        public bool SendNoteListFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
            if (fileUploadActions != null && fileUploadActions.Count > 0)
            {
                foreach (FileUploadAction fileUploadItemAction in fileUploadActions)
                {
                    DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                    DakUserParam dakUserParamLocal = JsonConvert.DeserializeObject<DakUserParam>(fileUploadItemAction.dakListUserParamJson);
                    dakUserParamLocal.token = dakUserParam.token;
                    var onuchhedSaveResponse = GetOnuchhedUploadedFile(dakUserParamLocal, dakFileUploadParam);

                    if (onuchhedSaveResponse != null && (onuchhedSaveResponse.status == "error" || onuchhedSaveResponse.status == "success"))
                    {
                        List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
                        if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                        {
                            foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                            {
                                List<DakUploadedFileResponse> onuchhedSaveWithAttachments = new List<DakUploadedFileResponse>();
                                List<DakUploadedFileResponse> onuchhedSaveWithAttachmentsde = new List<DakUploadedFileResponse>();
                                try
                                {
                                    
                                    DakUploadedFileResponse dakUploadedFileResponse = JsonConvert.DeserializeObject<DakUploadedFileResponse>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                    onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                }
                                catch
                                {
                                    onuchhedSaveWithAttachments = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);

                                }

                                if (onuchhedSaveWithAttachments.Count > 0)
                                {
                                    foreach (DakUploadedFileResponse onuchhedSaveWithAttachment in onuchhedSaveWithAttachments)
                                    {
                                        if (onuchhedSaveWithAttachment.data[0].id == fileUploadItemAction.Id)
                                        {
                                            onuchhedSaveWithAttachment.data[0].id = onuchhedSaveResponse.data[0].id;
                                            onuchhedSaveWithAttachmentsde.Add(onuchhedSaveWithAttachment);
                                            
                                        }
                                        else
                                        {
                                            onuchhedSaveWithAttachmentsde.Add(onuchhedSaveWithAttachment);
                                        }
                                    }
                                    onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson = JsonConvert.SerializeObject(onuchhedSaveWithAttachmentsde);
                                    _onuchhedSaveItemAction.Update(onuchhedSaveItemAction);
                                }
                            }
                        }
                        _fileUploadAction.Delete(fileUploadItemAction);
                        isForwarded = true;
                    }
                }
            }
            return isForwarded;
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

using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Services.DakServices;
using dNothi.Services.GuardFile.Model;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.GuardFile
{
    public class GuardFileService<ResponseData, Inputparam> : IGuardFileService<ResponseData, Inputparam> where ResponseData : class where Inputparam : class
    {
        
        IRepository<GuardFileList> _localGuardFileListRepository;
        IRepository<GuardFileInsert> _localGuardFileInsertRepository;
        IRepository<GuardFileUpload> _localGuardFileUploadRepository;

        public GuardFileService(IRepository<GuardFileList> localGuardFileListRepository, IRepository<GuardFileInsert> localGuardFileInsertRepository, IRepository<GuardFileUpload> localGuardFileUploadRepository)
        {

            _localGuardFileListRepository = localGuardFileListRepository;
            _localGuardFileInsertRepository = localGuardFileInsertRepository;
            _localGuardFileUploadRepository = localGuardFileUploadRepository;
        }

        public ResponseData GetList(DakUserParam userParam, int actionLink)
        {
            if (!InternetConnection.Check())
            {
               
                    ResponseData localResponse = JsonConvert.DeserializeObject<ResponseData>(GetLocalGuardFileList(userParam, actionLink).Replace("\"attachment\":[]", "\"attachment\":\"\""));
                    return localResponse;
                
            }

            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("page", userParam.page);
                request.AddParameter("limit", userParam.limit);
                if (userParam.CategoryId > 0)
                {
                    request.AddParameter("guard_file_category_id", userParam.CategoryId);
                }
                if (userParam.NameSearchParam != string.Empty)
                {
                    request.AddParameter("search_params", userParam.NameSearchParam);
                }

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;
                SaveLocalllyGuardFileList(responseJson, userParam, actionLink);

                ResponseData guardfilelist = JsonConvert.DeserializeObject<ResponseData>(responseJson.Replace("\"attachment\":[]", "\"attachment\":\"\""));
                return guardfilelist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseEdit Insert(DakUserParam userParam, int actionLink, string model, Inputparam data)
        {
            string inputData = string.Empty;
            if (model == "GuardFiles")
            {
                inputData = getparamGuardFiles(userParam, (GuardFileModel.Record)Convert.ChangeType(data, typeof(GuardFileModel.Record)));
            }
            else
            {
                inputData = getparamGuardFilesCategories((GuardFileCategory.Record)Convert.ChangeType(data, typeof(GuardFileCategory.Record)));
            }

            if (!InternetConnection.Check())
            {


                return SaveDeleteLocalGuardFile(userParam, inputData, actionLink, model, 0, true);

            }
            else
            {
               
                return InsertGuardFile(userParam, actionLink, model, inputData);
            }
            //try
            //{
            //    var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
            //    Api.Timeout = -1;
            //    var request = new RestRequest(Method.POST);
            //    request.AddHeader("api-version", CommonSetting.GetAPIVersion());
            //    request.AddHeader("Authorization", "Bearer " + userParam.token);
            //    request.AlwaysMultipartFormData = true;
            //    request.AddParameter("designation_id", userParam.designation_id);
            //    request.AddParameter("office_id", userParam.office_id);
            //    request.AddParameter("model", "" + model + "");
               
            //    request.AddParameter("data",inputData);
            //   IRestResponse Response = Api.Execute(request);

            //    var responseJson = Response.Content;

            //    ResponseEdit responseEdit = JsonConvert.DeserializeObject<ResponseEdit>(responseJson);
            //    return responseEdit;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

        private ResponseEdit InsertGuardFile(DakUserParam userParam,int actionLink,string model,string inputData)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("model", "" + model + "");

                request.AddParameter("data", inputData);
                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseEdit responseEdit = JsonConvert.DeserializeObject<ResponseEdit>(responseJson);
                return responseEdit;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ResponseEdit Inserts(DakUserParam userParam, int actionLink, string model, Inputparam data)
        {

            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("model", "" + model + "");
                if (model == "GuardFiles")
                {
                    getparamGuardFile(request, userParam, (GuardFileModel.Record)Convert.ChangeType(data, typeof(GuardFileModel.Record)));
                }


                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseEdit responseEdit = JsonConvert.DeserializeObject<ResponseEdit>(responseJson);
                return responseEdit;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DeleteResponse Delete(DakUserParam userParam, int actionLink, int id, string model)
        {
            if (!InternetConnection.Check())
            {

                ResponseEdit response= SaveDeleteLocalGuardFile(userParam, string.Empty, actionLink, model, id, false);
                return new DeleteResponse { status = response.status };
            }
            return deleteGuardFile(userParam, actionLink, id, model);
            //try
            //{
            //    var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
            //    Api.Timeout = -1;
            //    var request = new RestRequest(Method.POST);
            //    request.AddHeader("api-version", CommonSetting.GetAPIVersion());
            //    request.AddHeader("Authorization", "Bearer " + userParam.token);
            //    request.AlwaysMultipartFormData = true;
            //    request.AddParameter("designation_id", userParam.designation_id);
            //    request.AddParameter("office_id", userParam.office_id);
            //    request.AddParameter("model", model);
            //    request.AddParameter("id", id);

            //    IRestResponse Response = Api.Execute(request);

            //    var responseJson = Response.Content;

            //    DeleteResponse responseEdit = JsonConvert.DeserializeObject<DeleteResponse>(responseJson);
            //    return responseEdit;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }
        private DeleteResponse deleteGuardFile(DakUserParam userParam, int actionLink, int id, string model)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("model", model);
                request.AddParameter("id", id);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                DeleteResponse responseEdit = JsonConvert.DeserializeObject<DeleteResponse>(responseJson);
                return responseEdit;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public GuardFileAttachment UploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam, int actionLink)
        {
            GuardFileAttachment guardFileUploadedFileResponse = new GuardFileAttachment();
            if (!InternetConnection.Check())
            {
                guardFileUploadedFileResponse.status = "success";
                guardFileUploadedFileResponse.data = new List<GuardFileModel.Attachment>();
                GuardFileModel.Attachment attachment = new GuardFileModel.Attachment();

                attachment.path = dakFileUploadParam.path;
                attachment.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                attachment.user_file_name = dakFileUploadParam.user_file_name;
                attachment.content_body = dakFileUploadParam.content;
                guardFileUploadedFileResponse.data.Add(attachment);

                SaveLocalGuardFileUpload(dakListUserParam, "GuardFileAttachments", dakFileUploadParam);
                return guardFileUploadedFileResponse;

            }
          return  guardFileAttachmentUpload( dakListUserParam,  dakFileUploadParam,  actionLink);

        }

        private GuardFileAttachment guardFileAttachmentUpload(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam, int actionLink)
        {
            GuardFileAttachment guardFileUploadedFileResponse = new GuardFileAttachment();
            try
            {


                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var fileUploadRequest = new RestRequest(Method.POST);
                fileUploadRequest.AddHeader("api-version", CommonSetting.GetAPIVersion());
                fileUploadRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);

                fileUploadRequest.AlwaysMultipartFormData = true;
                fileUploadRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                fileUploadRequest.AddParameter("office_id", dakListUserParam.office_id);
                fileUploadRequest.AddParameter("path", "Guard");
                fileUploadRequest.AddParameter("model", "GuardFileAttachments");
                fileUploadRequest.AddParameter("file_size_in_kb", dakFileUploadParam.file_size_in_kb);
                fileUploadRequest.AddParameter("user_file_name", dakFileUploadParam.user_file_name);
                fileUploadRequest.AddParameter("content", dakFileUploadParam.content);

                IRestResponse fileUploadResponse = Api.Execute(fileUploadRequest);


                var fileUploadResponseJson = fileUploadResponse.Content;
                guardFileUploadedFileResponse = JsonConvert.DeserializeObject<GuardFileAttachment>(fileUploadResponseJson);
                return guardFileUploadedFileResponse;
            }
            catch (Exception ex)
            {


                return guardFileUploadedFileResponse;
            }
        }
        public GuardFilePortal GuardFilePortalList(DakUserParam userParam, string name, string type)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + DefaultAPIConfiguration.guardFilePortallist);
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("page", userParam.page);
                request.AddParameter("limit", userParam.limit);
                // request.AddParameter("layer_id", layerId);
                request.AddParameter("type", type);
                request.AddParameter("name", name);



                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                GuardFilePortal guardfileportallist = JsonConvert.DeserializeObject<GuardFilePortal>(responseJson);
                return guardfileportallist;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public GuardFileOffice GuardFilePortalOfficeList(DakUserParam userParam, int layerId, string type)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + DefaultAPIConfiguration.guardFileOfficelist);
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("layer_id", layerId);
                // request.AddParameter("type", type);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                GuardFileOffice guardfileofficelist = JsonConvert.DeserializeObject<GuardFileOffice>(responseJson);
                return guardfileofficelist;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public string getparamGuardFilesCategories( GuardFileCategory.Record data)
        {
            return "{\"id\":" + data.id + ",\"name_bng\":\"" + data.name_bng + "\"}";
            //request.AddParameter("data", "{\"id\":" + data.id + ",\"name_bng\":\"" + data.name_bng + "\"}");
        }
        public string getparamGuardFiles( DakUserParam userParam, GuardFileModel.Record model)
        {
            string data = "{\"name_bng\":\"" + model.name_bng + "\",\"name_eng\":\"" + model.name_eng + "\",\"file_number\":" + model.file_number + ",\"guard_file_category_id\":\"" + model.guard_file_category_id + "\",\"office_id\":" + userParam.officer_id + ",\"office_name\":\"" + model.office_name + "\",\"office_unit_id\":" + userParam.office_unit_id + ",\"office_unit_name\":\"" + model.office_unit_name + "\",\"office_unit_organogram_id\":" + model.office_unit_organogram_id + ",\"office_unit_organogram_name\":\"" + model.office_name + "\",\"attachment\":{\"id\":\"" + model.attachment.id + "\",\"user_file_name\":\"" + model.attachment.user_file_name + "\",\"file_name\":\"" + model.attachment.file_name + "\",\"attachment_type\":\"" + model.attachment.attachment_type + "\",\"file_size_in_kb\":\"" + model.attachment.file_size_in_kb + "\",\"url\":\"" + model.attachment.url + "\",\"thumb_url\":\"" + model.attachment.thumb_url + "\",\"delete_token\":\"" + model.attachment.delete_token + "\",\"delete_url\":\"" + model.attachment.file_url + "\"}}";
           // request.AddParameter("data", "{\"name_bng\":\"" + model.name_bng + "\",\"name_eng\":\"" + model.name_eng + "\",\"file_number\":" + model.file_number + ",\"guard_file_category_id\":\"" + model.guard_file_category_id + "\",\"office_id\":" + userParam.officer_id + ",\"office_name\":\"" + model.office_name + "\",\"office_unit_id\":" + userParam.office_unit_id + ",\"office_unit_name\":\"" + model.office_unit_name + "\",\"office_unit_organogram_id\":" + model.office_unit_organogram_id + ",\"office_unit_organogram_name\":\"" + model.office_name + "\",\"attachment\":{\"id\":\"" + model.attachment.id + "\",\"user_file_name\":\"" + model.attachment.user_file_name + "\",\"file_name\":\"" + model.attachment.file_name + "\",\"attachment_type\":\"" + model.attachment.attachment_type + "\",\"file_size_in_kb\":\"" + model.attachment.file_size_in_kb + "\",\"url\":\"" + model.attachment.url + "\",\"thumb_url\":\"" + model.attachment.thumb_url + "\",\"delete_token\":\"" + model.attachment.delete_token + "\",\"delete_url\":\"" + model.attachment.file_url + "\"}}");
            return data;
        }
        public void getparamGuardFile(RestRequest request, DakUserParam userParam, GuardFileModel.Record model)
        {
            request.AddParameter("data", "{\"name_bng\":\"" + model.name_bng + "\",\"name_eng\":\"" + model.name_eng + "\",\"file_number\":" + 2 + ",\"guard_file_category_id\":\"" + model.guard_file_category_id + "\",\"office_id\":" + userParam.office_id + ",\"office_name\":\"" + userParam.office + "\",\"office_unit_id\":" + userParam.office_unit_id + ",\"office_unit_name\":\"" + userParam.office_unit + "\",\"office_unit_organogram_id\":" + userParam.designation_id + ",\"office_unit_organogram_name\":\"" + userParam.office_unit + "\",\"attachment\":{\"id\":\"" + model.attachment.id + "\",\"user_file_name\":\"" + model.attachment.user_file_name + "\",\"file_name\":\"" + model.attachment.file_name + "\",\"attachment_type\":\"" + model.attachment.attachment_type + "\",\"file_size_in_kb\":\"" + model.attachment.file_size_in_kb + "\",\"url\":\"" + model.attachment.url + "\",\"thumb_url\":\"" + model.attachment.thumb_url + "\",\"delete_token\":\"" + model.attachment.delete_token + "\",\"delete_url\":\"" + model.attachment.file_url + "\"}}");


           // request.AddParameter("data", "{\"name_bng\":\"" + model.name_bng + "\",\"name_eng\":\"" + model.name_eng + "\",\"file_number\":" + 2 + ",\"guard_file_category_id\":\"" + model.guard_file_category_id + "\",\"office_id\":" + userParam.office_id + ",\"office_name\":\"" + userParam.office + "\",\"office_unit_id\":" + userParam.office_unit_id + ",\"office_unit_name\":\"" + userParam.office_unit + "\",\"office_unit_organogram_id\":" + userParam.designation_id + ",\"office_unit_organogram_name\":\"" + userParam.office_unit + "\",\"attachment\":{\"id\":\"" + 229 + "\",\"user_file_name\":\"" + "doc 80.pdf" + "\",\"file_name\":\"" + "Guard_2021_65_08_2216296376934701821263.pdf" + "\",\"attachment_type\":\"" + "pdf" + "\",\"file_size_in_kb\":\"" + "1,295.86 KB" + "\",\"url\":\"" + "https://dev.nothibs.tappware.com/api/content/render/doc%2080.pdf?token=NjEyMjRjM2RlNWUyMCZvZmZpY2VJZF82NV8yMjk%3D" + "\",\"thumb_url\":\"\",\"delete_token\":\"" + "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2Mjk2NTU2OTMsImlhdCI6MTYyOTYzNzA5MywianRpIjoiTVRZeU9UWXpOekE1TXc9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2Mjk2MzcwOTMsImRhdGEiOnsiZmlsZSI6Ikd1YXJkXC8yMDIxXC82NVwvMDhcLzIyXC9HdWFyZF8yMDIxXzY1XzA4XzIyMTYyOTYzNzY5MzQ3MDE4MjEyNjMucGRmIiwiaWQiOjIyOX19.nM2BYN-0N_7uyMAL0_39EuZOYnbJXMo9VOd7CPMrREbqvQQ4k0Y15KSgs-zZCXefaBpSi2Z3U_iLlS4u0__SHg" + "\",\"delete_url\":\"" + "/nothi-next/guard/attachment/remove" + "\"}}");

          
        }


        private string GetLocalGuardFileList(DakUserParam userParam, int actionLink)
        {
            bool isGuardFileCategory = actionLink == 1 ? true : false;
            var guardFileData = _localGuardFileListRepository.Table.
                Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.limit == userParam.limit &&
                q.isGuardFileCategory == isGuardFileCategory && q.page == userParam.page && q.guard_file_category_id == userParam.CategoryId && q.search_params == userParam.NameSearchParam).FirstOrDefault();

            if (guardFileData != null)
            {
                return guardFileData.responseData;
            }
            else
            {
                return "";
            }

        }
        private void SaveLocalllyGuardFileList(string responseJson, DakUserParam userParam, int actionLink)
        {
            bool isGuardFileCategory = actionLink == 1 ? true : false;
            var guardFileData = _localGuardFileListRepository.Table.
                Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.limit == userParam.limit &&
                q.isGuardFileCategory== isGuardFileCategory && q.page == userParam.page && q.guard_file_category_id== userParam.CategoryId && q.search_params==userParam.NameSearchParam).FirstOrDefault();

            if (guardFileData != null)
            {
                guardFileData.responseData = responseJson;
                _localGuardFileListRepository.Update(guardFileData);
            }
            else
            {
                GuardFileList localGuardFileList = new GuardFileList
                {
                    designation_id = userParam.designation_id,
                    office_id = userParam.office_id,

                    page = userParam.page,
                    limit = userParam.limit,
                    guard_file_category_id = userParam.CategoryId,
                    isGuardFileCategory = isGuardFileCategory,
                    search_params=userParam.NameSearchParam,
                    responseData=responseJson


                };
                _localGuardFileListRepository.Insert(localGuardFileList);
            }

        }

        private ResponseEdit SaveDeleteLocalGuardFile(DakUserParam userParam, string data, int actionLink, string model,int id,bool isInsert)
        {
            GuardFileInsert localGuardFileInsert = new GuardFileInsert { 
                    data=data, designation_id=userParam.designation_id, isCreated= isInsert, model= model,
                     office_id=userParam.office_id,
                     GuardFileId = id, isInProblem=false
            };
                _localGuardFileInsertRepository.Insert(localGuardFileInsert);
            if( localGuardFileInsert.model == "GuardFiles")
            {
                long maxId = _localGuardFileInsertRepository.Table.Max(x => x.Id);

                if (maxId>0)
                {
                    long Gid= _localGuardFileUploadRepository.Table.Max(x => x.Id);
                    var localGuardFileUpload = _localGuardFileUploadRepository.Table.Where(x => x.Id == Gid).FirstOrDefault();
                    if (localGuardFileUpload != null)
                    {
                        localGuardFileUpload.GuardFileId = localGuardFileUpload.Id;

                        _localGuardFileUploadRepository.Update(localGuardFileUpload);
                    }
                }
            }

            return new ResponseEdit {  status = "success" };
        }

        private ResponseEdit SaveLocalGuardFileUpload(DakUserParam userParam,string model, DakFileUploadParam dakFileUploadParam)
        {
            GuardFileUpload localGuardFileUpload = new GuardFileUpload
            {
                
                designation_id = userParam.designation_id,
                model = model,
                office_id = userParam.office_id,
                content= dakFileUploadParam.content,
                file_size_in_kb=dakFileUploadParam.file_size_in_kb,
                user_file_name=dakFileUploadParam.user_file_name,
                    
            };
            _localGuardFileUploadRepository.Insert(localGuardFileUpload);

            return new ResponseEdit { status = "success" };
        }
        public bool SendGuradFileLocalDataTOServer(DakUserParam userParam)
        {
          
            var localGuardFileInsertDelete = _localGuardFileInsertRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id).ToList();
            string status = string.Empty;
            foreach (var item in localGuardFileInsertDelete)
            {
                string inputData = item.data;
                if (!item.isInProblem)
                {
                    if (item.isCreated == true)
                    {
                        if (item.model == "GuardFiles")
                        {
                            var localGuardFileUpload = _localGuardFileUploadRepository.Table.Where(x => x.GuardFileId == item.Id).FirstOrDefault();
                            DakFileUploadParam fileUploadParam = new DakFileUploadParam
                            {
                                content = localGuardFileUpload.content,
                                file_size_in_kb = localGuardFileUpload.file_size_in_kb,
                                user_file_name = localGuardFileUpload.user_file_name
                            };
                            var uploadFileResponse = guardFileAttachmentUpload(userParam, fileUploadParam, 5);

                            GuardFileModel.Record record = new GuardFileModel.Record();
                            record = JsonConvert.DeserializeObject<GuardFileModel.Record>(item.data);
                            record.attachment = uploadFileResponse.data[0];
                            inputData = getparamGuardFiles(userParam, record);

                        }
                        ResponseEdit response = InsertGuardFile(userParam, 3, item.model, inputData);
                        status = response.status;
                    }
                    else
                    {
                        DeleteResponse response = deleteGuardFile(userParam, 4, item.GuardFileId, item.model);
                        status = response.status;
                    }
                    if (status == "success")
                    {
                        _localGuardFileInsertRepository.Delete(item);
                    }
                }
                else
                {
                    _localGuardFileInsertRepository.Delete(item);
                }
            }

            return true;
        }
      
    }
}


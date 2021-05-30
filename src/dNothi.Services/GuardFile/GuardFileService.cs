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
    public class GuardFileService<T,U> : IGuardFileService<T,U> where T:class   where U:class
    {
       
        public T GetList(DakUserParam userParam, int actionLink)
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
                request.AddParameter("page", userParam.page);
                request.AddParameter("limit", userParam.limit);
                if(userParam.CategoryId>0)
                {
                    request.AddParameter("guard_file_category_id", userParam.CategoryId);
                }
                if(userParam.NameSearchParam!=string.Empty)
                {
                    request.AddParameter("search_params", userParam.NameSearchParam);
                }

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                T guardfilelist = JsonConvert.DeserializeObject<T>(responseJson);
                return guardfilelist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseEdit Insert(DakUserParam userParam, int actionLink, string model,U data)
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
                request.AddParameter("model", ""+model+"");
                if (model == "GuardFiles")
                {
                    getparamGuardFiles(request, userParam,(GuardFileModel.Record)Convert.ChangeType(data, typeof(GuardFileModel.Record)));
                }
                else
                {
                    getparamGuardFilesCategories(request, (GuardFileCategory.Record)Convert.ChangeType(data, typeof(GuardFileCategory.Record)));
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

        public GuardFileAttachment UploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam,int actionLink)
        {
            GuardFileAttachment guardFileUploadedFileResponse = new GuardFileAttachment();
            if (!InternetConnection.Check())
            {
                guardFileUploadedFileResponse.status = "success";
                guardFileUploadedFileResponse.data = new List<GuardFileModel.Attachment>();
                GuardFileModel.Attachment attachment = new GuardFileModel.Attachment();

                attachment.path = dakFileUploadParam.path;
                attachment.file_size_in_kb =dakFileUploadParam.file_size_in_kb;
                attachment.user_file_name = dakFileUploadParam.user_file_name;
                attachment.content_body = dakFileUploadParam.content;
                guardFileUploadedFileResponse.data.Add(attachment);


                return guardFileUploadedFileResponse;

            }


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

        public void getparamGuardFilesCategories(RestRequest request, GuardFileCategory.Record data)
        {
           
            request.AddParameter("data", "{\"id\":" + data.id + ",\"name_bng\":\"" + data.name_bng + "\"}");
        }
        public void getparamGuardFiles(RestRequest request, DakUserParam userParam,GuardFileModel.Record model)
        {
           
            request.AddParameter("data", "{\"name_bng\":\""+model.name_bng+"\",\"name_eng\":\""+model.name_eng + "\",\"file_number\":"+model.file_number+",\"guard_file_category_id\":\""+model.guard_file_category_id+"\",\"office_id\":"+ userParam .officer_id+ ",\"office_name\":\""+model.office_name+"\",\"office_unit_id\":"+ userParam .office_unit_id+ ",\"office_unit_name\":\""+model.office_unit_name+"\",\"office_unit_organogram_id\":"+model.office_unit_organogram_id+",\"office_unit_organogram_name\":\""+model.office_name+"\",\"attachment\":{\"id\":\""+ model.attachment.id+"\",\"user_file_name\":\""+model.attachment.user_file_name+"\",\"file_name\":\""+ model.attachment.file_name+"\",\"attachment_type\":\""+ model.attachment.attachment_type+"\",\"file_size_in_kb\":\""+ model.attachment.file_size_in_kb+"\",\"url\":\""+model.attachment.url+"\",\"thumb_url\":\""+ model.attachment.thumb_url+"\",\"delete_token\":\""+model.attachment.delete_token+"\",\"delete_url\":\""+model.attachment.file_url+"\"}}");
        }
    }
}

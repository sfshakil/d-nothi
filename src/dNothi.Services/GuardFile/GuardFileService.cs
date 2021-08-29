using dNothi.Constants;
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

        public ResponseData GetList(DakUserParam userParam, int actionLink)
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
                    getparamGuardFiles(request, userParam, (GuardFileModel.Record)Convert.ChangeType(data, typeof(GuardFileModel.Record)));
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
        public void getparamGuardFilesCategories(RestRequest request, GuardFileCategory.Record data)
        {

            request.AddParameter("data", "{\"id\":" + data.id + ",\"name_bng\":\"" + data.name_bng + "\"}");
        }
        public void getparamGuardFiles(RestRequest request, DakUserParam userParam, GuardFileModel.Record model)
        {

            request.AddParameter("data", "{\"name_bng\":\"" + model.name_bng + "\",\"name_eng\":\"" + model.name_eng + "\",\"file_number\":" + model.file_number + ",\"guard_file_category_id\":\"" + model.guard_file_category_id + "\",\"office_id\":" + userParam.officer_id + ",\"office_name\":\"" + model.office_name + "\",\"office_unit_id\":" + userParam.office_unit_id + ",\"office_unit_name\":\"" + model.office_unit_name + "\",\"office_unit_organogram_id\":" + model.office_unit_organogram_id + ",\"office_unit_organogram_name\":\"" + model.office_name + "\",\"attachment\":{\"id\":\"" + model.attachment.id + "\",\"user_file_name\":\"" + model.attachment.user_file_name + "\",\"file_name\":\"" + model.attachment.file_name + "\",\"attachment_type\":\"" + model.attachment.attachment_type + "\",\"file_size_in_kb\":\"" + model.attachment.file_size_in_kb + "\",\"url\":\"" + model.attachment.url + "\",\"thumb_url\":\"" + model.attachment.thumb_url + "\",\"delete_token\":\"" + model.attachment.delete_token + "\",\"delete_url\":\"" + model.attachment.file_url + "\"}}");
        }

        public void getparamGuardFile(RestRequest request, DakUserParam userParam, GuardFileModel.Record model)
        {

            request.AddParameter("data", "{\"name_bng\":\"" + model.name_bng + "\",\"name_eng\":\"" + model.name_eng + "\",\"file_number\":" + 2 + ",\"guard_file_category_id\":\"" + model.guard_file_category_id + "\",\"office_id\":" + userParam.office_id + ",\"office_name\":\"" + userParam.office + "\",\"office_unit_id\":" + userParam.office_unit_id + ",\"office_unit_name\":\"" + userParam.office_unit + "\",\"office_unit_organogram_id\":" + userParam.designation_id + ",\"office_unit_organogram_name\":\"" + userParam.office_unit + "\",\"attachment\":{\"id\":\"" + 229 + "\",\"user_file_name\":\"" + "doc 80.pdf" + "\",\"file_name\":\"" + "Guard_2021_65_08_2216296376934701821263.pdf" + "\",\"attachment_type\":\"" + "pdf" + "\",\"file_size_in_kb\":\"" + "1,295.86 KB" + "\",\"url\":\"" + "https://dev.nothibs.tappware.com/api/content/render/doc%2080.pdf?token=NjEyMjRjM2RlNWUyMCZvZmZpY2VJZF82NV8yMjk%3D" + "\",\"thumb_url\":\"\",\"delete_token\":\"" + "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2Mjk2NTU2OTMsImlhdCI6MTYyOTYzNzA5MywianRpIjoiTVRZeU9UWXpOekE1TXc9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2Mjk2MzcwOTMsImRhdGEiOnsiZmlsZSI6Ikd1YXJkXC8yMDIxXC82NVwvMDhcLzIyXC9HdWFyZF8yMDIxXzY1XzA4XzIyMTYyOTYzNzY5MzQ3MDE4MjEyNjMucGRmIiwiaWQiOjIyOX19.nM2BYN-0N_7uyMAL0_39EuZOYnbJXMo9VOd7CPMrREbqvQQ4k0Y15KSgs-zZCXefaBpSi2Z3U_iLlS4u0__SHg" + "\",\"delete_url\":\"" + "/nothi-next/guard/attachment/remove" + "\"}}");

            // "attachment":{ "id":"13337","user_file_name":"11.02.2015 Circular.pdf","file_name":"Guard_2021_17828_08_2216296295136934584272.pdf","attachment_type":"pdf","file_size_in_kb":"935.85 KB","url":"https:\/\/gw-core-digital.nothi.gov.bd\/api\/content\/render\/11.02.2015%20Circular.pdf?token=Jm9mZmljZUlkXzE3ODI4XzEzMzM3","thumb_url":"","delete_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2Mjk2NDc1MTMsImlhdCI6MTYyOTYyODkxMywianRpIjoiTVRZeU9UWXlPRGt4TXc9PSIsImlzcyI6Imh0dHBzOlwvXC9maWxlcy1kaWdpdGFsLm5vdGhpLmdvdi5iZFwvIiwibmJmIjoxNjI5NjI4OTEzLCJkYXRhIjp7ImZpbGUiOiJHdWFyZFwvMjAyMVwvMTc4MjhcLzA4XC8yMlwvR3VhcmRfMjAyMV8xNzgyOF8wOF8yMjE2Mjk2Mjk1MTM2OTM0NTg0MjcyLnBkZiIsImlkIjoxMzMzN319.aW8Chx8Ne2XVfG6VbW3ZzL0Jc4vOgo8LMI6zZCaT-fEzMvI-Or2-8sTckPjm1ODlB0U5vxiOxJxLfNgZY94BcQ","delete_url":"\/nothi-next\/guard\/attachment\/remove"}

            //[data] =>"office_id":65,"office_name":"\u098f\u09b8\u09aa\u09be\u09df\u09be\u09b0 \u099f\u09c1 \u0987\u09a8\u09cb\u09ad\u09c7\u099f (\u098f\u099f\u09c1\u09cd\u0986\u0987) \u09aa\u09cd\u09b0\u09cb\u0997\u09cd\u09b0\u09be\u09ae","office_unit_id":9625,"office_unit_name":"\u0987-\u09b8\u09be\u09b0\u09cd\u09ad\u09bf\u09b8","office_unit_organogram_id":22418,"office_unit_organogram_name":"\u09b8\u09ab\u099f\u0993\u09df\u09cd\u09af\u09be\u09b0 \u0987\u099e\u09cd\u099c\u09bf\u09a8\u09bf\u09df\u09be\u09b0","attachment":{ "id":"229","user_file_name":"doc 80.pdf","file_name":"Guard_2021_65_08_2216296376934701821263.pdf","attachment_type":"pdf","file_size_in_kb":"1,295.86 KB","url":"https:\/\/dev.nothibs.tappware.com\/api\/content\/render\/doc%2080.pdf?token=NjEyMjRjM2RlNWUyMCZvZmZpY2VJZF82NV8yMjk%3D","thumb_url":"","delete_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2Mjk2NTU2OTMsImlhdCI6MTYyOTYzNzA5MywianRpIjoiTVRZeU9UWXpOekE1TXc9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2Mjk2MzcwOTMsImRhdGEiOnsiZmlsZSI6Ikd1YXJkXC8yMDIxXC82NVwvMDhcLzIyXC9HdWFyZF8yMDIxXzY1XzA4XzIyMTYyOTYzNzY5MzQ3MDE4MjEyNjMucGRmIiwiaWQiOjIyOX19.nM2BYN-0N_7uyMAL0_39EuZOYnbJXMo9VOd7CPMrREbqvQQ4k0Y15KSgs-zZCXefaBpSi2Z3U_iLlS4u0__SHg","delete_url":"\/nothi-next\/guard\/attachment\/remove"} }

        }
    }
}


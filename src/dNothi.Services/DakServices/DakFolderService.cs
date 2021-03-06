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
using System.Web.Script.Serialization;

namespace dNothi.Services.DakServices
{
   public class DakFolderService:IDakFolderService
    {
        public FolderListResponse GetFolderList(DakUserParam dakUserParam)
        {
            FolderListResponse folderListResponse = new FolderListResponse();

            try
            {
                var dakFolderListApi = new RestClient(GetAPIDomain() + GetDakFolderListEndPoint());
                dakFolderListApi.Timeout = -1;
                var dakFolderListRequest = new RestRequest(Method.POST);
                dakFolderListRequest.AddHeader("api-version", GetOldAPIVersion());
                dakFolderListRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakFolderListRequest.AlwaysMultipartFormData = true;
                dakFolderListRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakFolderListRequest.AddParameter("office_id", dakUserParam.office_id);
                IRestResponse dakFolderListResponseIRest = dakFolderListApi.Execute(dakFolderListRequest);


                var dakFolderListResponseJson = dakFolderListResponseIRest.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                folderListResponse = JsonConvert.DeserializeObject<FolderListResponse>(dakFolderListResponseJson);
                return folderListResponse;
            }
            catch (Exception ex)
            {
                return folderListResponse;
            }

           
        }
        public DakFolderDeleteResponse GetDakFolderDeleteResponse(DakUserParam dakUserParam,int folder_id)
        {
            DakFolderDeleteResponse dakFolderDeleteResponse = new DakFolderDeleteResponse();

            try
            {
                var dakFolderDeleteApi = new RestClient(GetAPIDomain() + GetDakFolderDeleteEndPoint());
                dakFolderDeleteApi.Timeout = -1;
                var dakFolderDeleteRequest = new RestRequest(Method.POST);
                dakFolderDeleteRequest.AddHeader("api-version", GetOldAPIVersion());
                dakFolderDeleteRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakFolderDeleteRequest.AlwaysMultipartFormData = true;
                dakFolderDeleteRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakFolderDeleteRequest.AddParameter("office_id", dakUserParam.office_id);
                dakFolderDeleteRequest.AddParameter("id", folder_id);

              
                IRestResponse dakFolderDeleteResponseIRest = dakFolderDeleteApi.Execute(dakFolderDeleteRequest);




                var dakFolderDeleteResponseJson = dakFolderDeleteResponseIRest.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                dakFolderDeleteResponse = JsonConvert.DeserializeObject<DakFolderDeleteResponse>(dakFolderDeleteResponseJson);
                return dakFolderDeleteResponse;
            }
            catch (Exception ex)
            {
                return dakFolderDeleteResponse;
            }


        }

        public DakFolderAddResponse GetDakFolderAddResponse(DakUserParam dakUserParam,DakFolderParam dakFolderParam)
        {
            DakFolderAddResponse dakFolderAddResponse = new DakFolderAddResponse();

            try
            {
                var dakFolderAddApi = new RestClient(GetAPIDomain() + GetDakFolderAddEndPoint());
                dakFolderAddApi.Timeout = -1;
                var dakFolderAddRequest = new RestRequest(Method.POST);
                dakFolderAddRequest.AddHeader("api-version", GetOldAPIVersion());
                dakFolderAddRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakFolderAddRequest.AlwaysMultipartFormData = true;
                dakFolderAddRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakFolderAddRequest.AddParameter("office_id", dakUserParam.office_id);

                var cDeskJsonString = new JavaScriptSerializer().Serialize(dakUserParam);
                dakFolderAddRequest.AddParameter("cdesk", cDeskJsonString);
               
                var folderJsonString = new JavaScriptSerializer().Serialize(dakFolderParam);
                dakFolderAddRequest.AddParameter("folder", folderJsonString);
               
                IRestResponse dakFolderAddResponseIRest = dakFolderAddApi.Execute(dakFolderAddRequest);

              


                var dakFolderAddResponseJson = dakFolderAddResponseIRest.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                dakFolderAddResponse = JsonConvert.DeserializeObject<DakFolderAddResponse>(dakFolderAddResponseJson);
                return dakFolderAddResponse;
            }
            catch (Exception ex)
            {
                return dakFolderAddResponse;
            }


        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetOldAPIVersion()
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

        protected string GetDakFolderListEndPoint()
        {
            return DefaultAPIConfiguration.DakFolderListEndPoint;
        }
        protected string GetDakFolderAddEndPoint()
        {
            return DefaultAPIConfiguration.DakFolderAddEndPoint;
        }
        protected string GetDakFolderDeleteEndPoint()
        {
            return DefaultAPIConfiguration.DakFolderDeleteEndPoint;
        }
    }

    public interface IDakFolderService
    {
        FolderListResponse GetFolderList(DakUserParam dakUserParam);
        DakFolderAddResponse GetDakFolderAddResponse(DakUserParam dakUserParam, DakFolderParam dakFolderParam);
        DakFolderDeleteResponse GetDakFolderDeleteResponse(DakUserParam dakUserParam, int folder_id);
    }
}

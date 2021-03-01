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
    }

    public interface IDakFolderService
    {
        FolderListResponse GetFolderList(DakUserParam dakUserParam);
    }
}

using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.UserServices;
using dNothi.Utility;
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
        IRepository<LocalDakFolderList> _dakFolderRep;
        IRepository<DakItemAction> _dakItemRepo;
        IUserService _userService { get; set; }
        public  DakFolderService(IRepository<LocalDakFolderList> dakFolderRep, IRepository<DakItemAction> dakItemRepo, IUserService userService)
        {
            _dakFolderRep = dakFolderRep;
            _dakItemRepo = dakItemRepo;
            _userService = userService;
        }

        public FolderListResponse GetFolderList(DakUserParam dakUserParam)
        {
            FolderListResponse folderListResponse = new FolderListResponse();
            if(!InternetConnection.Check())
            {
                folderListResponse.status = "success";
                var localDakFolderList = _dakFolderRep.Table.FirstOrDefault(a => a.designation_id == dakUserParam.designation_id && a.office_id == dakUserParam.office_id);
                if(localDakFolderList !=null)
                {
                    folderListResponse = JsonConvert.DeserializeObject<FolderListResponse>(localDakFolderList.dak_Action_Json);
                }

                return folderListResponse;
            }



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
                AddDakFolderListLocally(dakUserParam, dakFolderListResponseJson);

                folderListResponse = JsonConvert.DeserializeObject<FolderListResponse>(dakFolderListResponseJson);
                return folderListResponse;
            }
            catch (Exception ex)
            {
                return folderListResponse;
            }

           
        }

        private void AddDakFolderListLocally(DakUserParam dakUserParam, string dakFolderListResponseJson)
        {
            var localDakFolderListDB = _dakFolderRep.Table.FirstOrDefault(a => a.designation_id == dakUserParam.designation_id && a.office_id == dakUserParam.office_id);
            if (localDakFolderListDB != null)
            {
                localDakFolderListDB.dak_Action_Json = dakFolderListResponseJson;

                _dakFolderRep.Update(localDakFolderListDB);
            }

            LocalDakFolderList localDakFolderList = new LocalDakFolderList { designation_id=dakUserParam.designation_id, office_id=dakUserParam.office_id,dak_Action_Json= dakFolderListResponseJson };
            _dakFolderRep.Insert(localDakFolderList);



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

        protected string GetDakFolderMapEndPoint()
        {
            return DefaultAPIConfiguration.DakFolderMapEndPoint;
        }

        public DakFolderMapResponse GetDakFolderMapResponse(DakUserParam dakUserParam, int dak_id, int is_copied_dak, string dak_Type, string dak_Folder)
        {
            DakFolderMapResponse dakFolderAddResponse = new DakFolderMapResponse();

            if(!InternetConnection.Check())
            {
                dakFolderAddResponse.status = "success";
                dakFolderAddResponse.message = "Local";
                DakItemAction dakItemAction = _dakItemRepo.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_Type && a.is_copied_dak == is_copied_dak);

                if (dakItemAction == null)
                {
                    dakItemAction = new DakItemAction();
                 
                    dakItemAction.isDakTagged = true;
                 
                    dakItemAction.is_copied_dak = is_copied_dak;
                    dakItemAction.dak_id = dak_id;
                    dakItemAction.dak_type = dak_Type;
                  
                    dakItemAction.dak_folder_name = dak_Folder;
                   
                    dakItemAction.designation_id = dakUserParam.designation_id;
                    dakItemAction.office_id = dakUserParam.office_id;

                  

                    _dakItemRepo.Insert(dakItemAction);
                }
              




                return dakFolderAddResponse;


            }


            try
            {
                var dakFolderMapApi = new RestClient(GetAPIDomain() + GetDakFolderMapEndPoint());
                dakFolderMapApi.Timeout = -1;
                var dakFolderMapRequest = new RestRequest(Method.POST);
                dakFolderMapRequest.AddHeader("api-version", GetOldAPIVersion());
                dakFolderMapRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakFolderMapRequest.AlwaysMultipartFormData = true;
                dakFolderMapRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakFolderMapRequest.AddParameter("office_id", dakUserParam.office_id);

                var cDeskJsonString = new JavaScriptSerializer().Serialize(dakUserParam);
                dakFolderMapRequest.AddParameter("cdesk", cDeskJsonString);

              
                dakFolderMapRequest.AddParameter("daak_custom_folder", "{\"folders\":"+dak_Folder+",\"dak_id\":\""+dak_id+"\",\"dak_type\":\""+dak_Type+"\",\"is_copied_dak\":"+is_copied_dak+"}");

                IRestResponse dakFolderMapResponseIRest = dakFolderMapApi.Execute(dakFolderMapRequest);




                var dakFolderMapResponseJson = dakFolderMapResponseIRest.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                dakFolderAddResponse = JsonConvert.DeserializeObject<DakFolderMapResponse>(dakFolderMapResponseJson);
                return dakFolderAddResponse;
            }
            catch (Exception ex)
            {
                return dakFolderAddResponse;
            }
        }


        public bool Is_Locally_DakTagged(int dak_id)
        {
            var dakForwardCheck = _dakItemRepo.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isDakTagged == true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DakTagFromLocal()
        {
            bool isSuccessful = false;
            List<DakItemAction> dakItemActions = _dakItemRepo.Table.Where(a => a.isDakTagged == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {
                    if(dakUserParam.designation_id != dakItemAction.designation_id)
                    {
                        _dakItemRepo.Delete(dakItemAction);
                        
                    }
                    else
                    {
                        var dakTagResponse = GetDakFolderMapResponse(dakUserParam, dakItemAction.dak_id, dakItemAction.is_copied_dak, dakItemAction.dak_type,dakItemAction.dak_folder_name);

                        if (dakTagResponse != null && (dakTagResponse.status == "error" || dakTagResponse.status == "success"))

                        {
                            _dakItemRepo.Delete(dakItemAction);
                            isSuccessful = true;

                        }
                    }

                    
                }
            }


            return isSuccessful;
        }
    }

    public interface IDakFolderService
    {
        bool Is_Locally_DakTagged(int dak_id);
        bool DakTagFromLocal();

        DakFolderMapResponse GetDakFolderMapResponse(DakUserParam dakUserParam, int dak_id, int is_copied_dak, string dak_Type, string dak_Folder);
        FolderListResponse GetFolderList(DakUserParam dakUserParam);
        DakFolderAddResponse GetDakFolderAddResponse(DakUserParam dakUserParam, DakFolderParam dakFolderParam);
        DakFolderDeleteResponse GetDakFolderDeleteResponse(DakUserParam dakUserParam, int folder_id);
    }
}

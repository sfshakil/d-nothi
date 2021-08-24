using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakForwardService : IDakForwardService
    {

        IRepository<LocalDesignationSeal> _localDesignationSealRepository;
        IRepository<DakItemAction> _dakItemAction;
        IUserService _userService { get; set; }
        public DakForwardService(IUserService userService, IRepository<DakItemAction> dakItemAction,IRepository<LocalDesignationSeal> localDesignationSealRepository)
        {
            _dakItemAction = dakItemAction;
            _userService = userService;
            _localDesignationSealRepository = localDesignationSealRepository;
        }


        public DesignationSealListResponse GetSealListResponse(DakUserParam dakListUserParam)
        {
            if(!InternetConnection.Check())
            {
           

                DesignationSealListResponse designationSealResponse = JsonConvert.DeserializeObject<DesignationSealListResponse>(GetLocalDesignationSeal(dakListUserParam));



                return designationSealResponse;
            }
            try
            {

                var designationSealList = new RestClient(GetAPIDomain() + GetDesignationSealListEndpoint());
                designationSealList.Timeout = -1;
                var designationSealRequest = new RestRequest(Method.POST);
                designationSealRequest.AddHeader("api-version", GetOldAPIVersion());
                designationSealRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                designationSealRequest.AlwaysMultipartFormData = true;
                designationSealRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                designationSealRequest.AddParameter("office_id", dakListUserParam.office_id);
              
                IRestResponse designationSealResponseAPI = designationSealList.Execute(designationSealRequest);


                var designationSealResponseJson = designationSealResponseAPI.Content;
                       
                // Save  Designation Seal Response to Local DB
                SaveLocalDesignationSeal(designationSealResponseJson, dakListUserParam);
                
                
                DesignationSealListResponse designationSealResponse = JsonConvert.DeserializeObject<DesignationSealListResponse>(designationSealResponseJson);



                return designationSealResponse;
            }
            catch (Exception ex)
            {
                throw;
            }

           
        }


        public bool Is_Locally_Forwarde(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isForwarded==true);
            if(dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Is_Locally_Forward_Reverted(int dak_id)
        {
            var dakForwardCheck = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.isForwardReverted == true);
            if (dakForwardCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SendDakForwardFromLocal()
        {
            bool isForwarded = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isForwarded == true).ToList();
            if(dakItemActions != null && dakItemActions.Count>0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach(DakItemAction dakItemAction in dakItemActions)
                {

                    if (dakUserParam.designation_id == dakItemAction.designation_id)
                    {


                        DakForwardRequestParam dakForwardRequest = JsonConvert.DeserializeObject<DakForwardRequestParam>(dakItemAction.dak_Action_Json);
                        dakForwardRequest.token = dakUserParam.token;

                        var dakForwardResponse = GetDakForwardResponse(dakForwardRequest);

                        if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))

                        {
                            _dakItemAction.Delete(dakItemAction);
                            isForwarded = true;

                        }
                    }
                    else
                    {
                        _dakItemAction.Delete(dakItemAction);
                    }
                }
            }


            return isForwarded;
        }
        public bool SendDakForwardRevertedFromLocal()
        {
            bool isForwarded = false;
            List<DakItemAction> dakItemActions = _dakItemAction.Table.Where(a => a.isForwardReverted == true).ToList();
            if (dakItemActions != null && dakItemActions.Count > 0)
            {
                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                foreach (DakItemAction dakItemAction in dakItemActions)
                {
                    if(dakUserParam.designation_id==dakItemAction.designation_id)
                    {
                       
                        var dakForwardResponse = GetDakForwardRevertResponse(dakUserParam,dakItemAction.dak_id,dakItemAction.dak_type,dakItemAction.is_copied_dak);

                        if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))
                        {
                            _dakItemAction.Delete(dakItemAction);
                            isForwarded = true;

                        }
                    }
                    else
                    {
                        _dakItemAction.Delete(dakItemAction);
                        isForwarded = true;
                    }
                    
                }
            }


            return isForwarded;
        }

        private void SaveLocalDesignationSeal(string designationSealResponseJson, DakUserParam dakListUserParam)
        {
            var dbDesignationSeals = _localDesignationSealRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id).FirstOrDefault();

            if (dbDesignationSeals != null)
            {
                dbDesignationSeals.designation_Seal_Json = designationSealResponseJson;
                _localDesignationSealRepository.Update(dbDesignationSeals);
            }
            else
            {
                LocalDesignationSeal localDesignationSeal = new LocalDesignationSeal { designation_id = dakListUserParam.designation_id, office_id = dakListUserParam.office_id, designation_Seal_Json = designationSealResponseJson };



                _localDesignationSealRepository.Insert(localDesignationSeal);
            }

        }

        private string GetLocalDesignationSeal(DakUserParam dakListUserParam)
        {
            var dbDesignationSeals = _localDesignationSealRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id).FirstOrDefault();

            if(dbDesignationSeals != null)
            {
                return dbDesignationSeals.designation_Seal_Json;
            }
            else
            {
                return "";
            }
           
        }



        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string GetDesignationSealListEndpoint()
        {
            return DefaultAPIConfiguration.GetDesignationSealListEndpoint;
        }
        protected string GetDakForwardEndpoint()
        {
            return DefaultAPIConfiguration.GetDakForwardEndpoint;
        }
         protected string GetDakDecisionListEndpoint()
        {
            return DefaultAPIConfiguration.DakDecisionListEndpoint;
        }
        protected string GetDakDecisionAddEndpoint()
        {
            return DefaultAPIConfiguration.DakDecisionAddEndpoint;
        }
        protected string GetDakDecisionDeleteEndpoint()
        {
            return DefaultAPIConfiguration.DakDecisionDeleteEndpoint;
        } 
        protected string GetDakDecisionSetupEndpoint()
        {
            return DefaultAPIConfiguration.DakDecisionSetupEndpoint;
        }
        protected string GetDakForwardRevertEndpoint()
        {
            return DefaultAPIConfiguration.DakForwardRevertEndPoint;
        }

        public DakForwardResponse GetDakForwardResponse(DakForwardRequestParam dakForwardParam)
        {
            DakForwardResponse dakForwardResponse = new DakForwardResponse();
            if (!InternetConnection.Check())
            {
                dakForwardResponse.status = "success";
                dakForwardResponse.message = "Local";

                DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dakForwardParam.dak_id && a.dak_type == dakForwardParam.dak_type && a.is_copied_dak == dakForwardParam.is_copied_dak);

                if(dakItemAction == null)
                {
                    DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                    dakItemAction = new DakItemAction();
                    dakItemAction.isForwarded = true;
                    dakItemAction.is_copied_dak = dakForwardParam.is_copied_dak;
                    dakItemAction.dak_id = dakForwardParam.dak_id;
                    dakItemAction.dak_type = dakForwardParam.dak_type;
                    dakItemAction.dak_Action_Json = JsonParsingMethod.ObjecttoJson(dakForwardParam);
                    dakItemAction.designation_id = dakUserParam.designation_id;
                    _dakItemAction.Insert(dakItemAction);
                }

                return dakForwardResponse;
            }
            try
            {

                
                var DakForwardApi = new RestClient(GetAPIDomain() + GetDakForwardEndpoint());
                DakForwardApi.Timeout = -1;
                var dakForwardRequest = new RestRequest(Method.POST);
                dakForwardRequest.AddHeader("api-version", GetAPIVersion());
                dakForwardRequest.AddHeader("Authorization", "Bearer " + dakForwardParam.token);
                dakForwardRequest.AlwaysMultipartFormData = true;
                dakForwardRequest.AddParameter("sender_info", dakForwardParam.sender_info);
                dakForwardRequest.AddParameter("receiver_info", dakForwardParam.receiver_info);
                dakForwardRequest.AddParameter("onulipi_info", dakForwardParam.onulipi_info);
                dakForwardRequest.AddParameter("dak_type", dakForwardParam.dak_type);
                dakForwardRequest.AddParameter("dak_id", dakForwardParam.dak_id);
                dakForwardRequest.AddParameter("priority", dakForwardParam.priority);
                dakForwardRequest.AddParameter("comment", dakForwardParam.comment);
                dakForwardRequest.AddParameter("security", dakForwardParam.security);
                dakForwardRequest.AddParameter("is_copied_dak", dakForwardParam.is_copied_dak);

                IRestResponse dakForwardResponseAPI = DakForwardApi.Execute(dakForwardRequest);


                var dakForwardResponseJson = dakForwardResponseAPI.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                 dakForwardResponse = JsonConvert.DeserializeObject<DakForwardResponse>(ConversionMethod.FilterJsonResponse(dakForwardResponseJson));
                return dakForwardResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakDecisionListResponse GetDakDecisionListResponse(DakUserParam dakUserParam)
        {
            try
            {

                var DakDecisionListApi = new RestClient(GetAPIDomain() + GetDakDecisionListEndpoint());
                DakDecisionListApi.Timeout = -1;
                var dakDecisionListRequest = new RestRequest(Method.POST);
                dakDecisionListRequest.AddHeader("api-version", GetOldAPIVersion());
                dakDecisionListRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakDecisionListRequest.AlwaysMultipartFormData = true;
                dakDecisionListRequest.AddParameter("user_id", dakUserParam.user_id);
                
                IRestResponse dakDecisionResponseAPI = DakDecisionListApi.Execute(dakDecisionListRequest);


                var dakDecisionResponseJson = dakDecisionResponseAPI.Content;
                DakDecisionListResponse dakDecisionResponse = JsonConvert.DeserializeObject<DakDecisionListResponse>(dakDecisionResponseJson);
                return dakDecisionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakDecisionAddResponse GetDakDecisionAddResponse(DakUserParam dakUserParam,DakDecisionDTO dakDecision)
        {
            try
            {

                var DakDecisionAddApi = new RestClient(GetAPIDomain() + GetDakDecisionAddEndpoint());
                DakDecisionAddApi.Timeout = -1;
                var dakDecisionAddRequest = new RestRequest(Method.POST);
                dakDecisionAddRequest.AddHeader("api-version", GetOldAPIVersion());
                dakDecisionAddRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakDecisionAddRequest.AlwaysMultipartFormData = true;
                //dakDecisionAddRequest.AddParameter("user_id", dakUserParam.user_id);
                //dakDecisionAddRequest.AddParameter("desk", dakUserParam.json_String);
                dakDecisionAddRequest.AddParameter("dak_decision_employee", dakDecision.dak_decision_employee);
                dakDecisionAddRequest.AddParameter("dak_decision", dakDecision.dak_decision);
                if(dakDecision.id !=0)
                {
                    dakDecisionAddRequest.AddParameter("id", dakDecision.id);
                }

                IRestResponse dakDecisionResponseAPI = DakDecisionAddApi.Execute(dakDecisionAddRequest);


                var dakDecisionResponseJson = dakDecisionResponseAPI.Content;
                DakDecisionAddResponse dakDecisionResponse = JsonConvert.DeserializeObject<DakDecisionAddResponse>(dakDecisionResponseJson);
                return dakDecisionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakDecisionDeleteResponse GetDakDecisionDeleteResponse(DakUserParam dakUserParam, DakDecisionDTO dakDecision)
        {
            try
            {

                var DakDecisionDeleteApi = new RestClient(GetAPIDomain() + GetDakDecisionDeleteEndpoint());
                DakDecisionDeleteApi.Timeout = -1;
                var dakDecisionDeleteRequest = new RestRequest(Method.POST);
                dakDecisionDeleteRequest.AddHeader("api-version", GetOldAPIVersion());
                dakDecisionDeleteRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakDecisionDeleteRequest.AlwaysMultipartFormData = true;
                dakDecisionDeleteRequest.AddParameter("desk", dakUserParam.json_String);
                dakDecisionDeleteRequest.AddParameter("dak_decision_id", dakDecision.id);
            
                IRestResponse dakDecisionResponseAPI = DakDecisionDeleteApi.Execute(dakDecisionDeleteRequest);


                var dakDecisionResponseJson = dakDecisionResponseAPI.Content;
                DakDecisionDeleteResponse dakDecisionResponse = JsonConvert.DeserializeObject<DakDecisionDeleteResponse>(dakDecisionResponseJson);
                return dakDecisionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DakDecisionSetupResponse GetDakDecisionSetupResponse(DakUserParam dakUserParam, string addJson, string deleteJson)
        {
            try
            {

                var DakDecisionSetupApi = new RestClient(GetAPIDomain() + GetDakDecisionSetupEndpoint());
                DakDecisionSetupApi.Timeout = -1;
                var dakDecisionSetupRequest = new RestRequest(Method.POST);
                dakDecisionSetupRequest.AddHeader("api-version", GetOldAPIVersion());
                dakDecisionSetupRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakDecisionSetupRequest.AlwaysMultipartFormData = true;
                dakDecisionSetupRequest.AddParameter("added_as_default", addJson);
                dakDecisionSetupRequest.AddParameter("deleted_as_default", deleteJson);

                IRestResponse dakDecisionResponseAPI = DakDecisionSetupApi.Execute(dakDecisionSetupRequest);

               

                var dakDecisionResponseJson = dakDecisionResponseAPI.Content;
                var dakDecisionResponse = JsonConvert.DeserializeObject<DakDecisionSetupResponse>(dakDecisionResponseJson, new JsonSerializerSettings
                {
                    Error = HandleDeserializationError
                });
               // DakDecisionSetupResponse dakDecisionResponse = JsonConvert.DeserializeObject<DakDecisionSetupResponse>(dakDecisionResponseJson);
                return dakDecisionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public DakForwardRevertResponse GetDakForwardRevertResponse(DakUserParam dakUserParam, int dak_id, string dak_type, int is_copied_dak)
        {
            try
            {

                DakForwardRevertResponse revertResponse = new DakForwardRevertResponse();
                if (!InternetConnection.Check())
                {
                    revertResponse.status = "success";
                    revertResponse.message = "Local";

                    DakItemAction dakItemAction = _dakItemAction.Table.FirstOrDefault(a => a.dak_id == dak_id && a.dak_type == dak_type && a.is_copied_dak ==is_copied_dak);

                    if (dakItemAction == null)
                    {
                        dakItemAction = new DakItemAction();
                        dakItemAction.isForwardReverted = true;
                        dakItemAction.is_copied_dak = is_copied_dak;
                        dakItemAction.dak_id = dak_id;
                        dakItemAction.dak_type =dak_type;
                        dakItemAction.designation_id =dakUserParam.designation_id;
                        dakItemAction.office_id =dakUserParam.office_id;
                        dakItemAction.dak_type =dak_type;
                        
                        _dakItemAction.Insert(dakItemAction);
                    }





                    return revertResponse;
                }

                var forwardRevertDakApi = new RestClient(GetAPIDomain() + GetDakForwardRevertEndpoint());
                forwardRevertDakApi.Timeout = -1;
                var forwardRevertRequest = new RestRequest(Method.POST);
                forwardRevertRequest.AddHeader("api-version", GetAPIVersion());
                forwardRevertRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                forwardRevertRequest.AlwaysMultipartFormData = true;
                forwardRevertRequest.AddParameter("designation_id", dakUserParam.designation_id);
                forwardRevertRequest.AddParameter("office_id", dakUserParam.office_id);
                forwardRevertRequest.AddParameter("dak_id",dak_id);
                forwardRevertRequest.AddParameter("dak_type", dak_type);
                forwardRevertRequest.AddParameter("is_copied_dak",is_copied_dak);
               


                IRestResponse nothivuktoRevertResponse = forwardRevertDakApi.Execute(forwardRevertRequest);


                var nothivuktoRevertResponseJson = nothivuktoRevertResponse.Content;
                 revertResponse = JsonConvert.DeserializeObject<DakForwardRevertResponse>(nothivuktoRevertResponseJson);
                return revertResponse;
            }
        
            catch (Exception ex)
            {
               return null;
            }
}
    }
}

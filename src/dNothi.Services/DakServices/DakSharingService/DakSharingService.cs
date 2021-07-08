using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static dNothi.Services.DakServices.DakSharingService.Model.ShareList;
//using static dNothi.Constants.DefaultAPIConfiguration;

namespace dNothi.Services.DakServices.DakSharingService
{
    public class DakSharingService<ResponseData> : IDakSharingService<ResponseData> where ResponseData : class
    {
        IRepository<DakBoxSharedToOfficer> _localAssigneeRepository;
        IRepository<DakBoxSharing> _localDakBoxSharingRepository;

        IRepository<DakBacaiKaranList> _localDakBacaiKaranListRepository;
        IRepository<DakBacaiKaran> _localDakBacaiKaranRepository;
        IUserService _userService { get; set; }
        public DakSharingService(IUserService userService, 
            IRepository<DakBoxSharedToOfficer> localAssigneeRepository,
            IRepository<DakBoxSharing> localDakBoxSharingRepository,
             IRepository<DakBacaiKaranList> localDakBacaiKaranListRepository,
             IRepository<DakBacaiKaran> localDakBacaiKaranRepository)
        {
           
            _userService = userService;
            _localAssigneeRepository = localAssigneeRepository;
            _localDakBoxSharingRepository = localDakBoxSharingRepository;
            _localDakBacaiKaranListRepository = localDakBacaiKaranListRepository;
            _localDakBacaiKaranRepository = localDakBacaiKaranRepository;
        }
        public ResponseModel Add(DakUserParam userParam,PrapokDTO assignee)
        {
            string assignorjson = "{\"office_id\":" + userParam.office_id + ",\"office_name\":\"" + userParam.office + "\",\"office_unit_id\":\"" + userParam.office_unit_id + "\",\"office_unit_name\":\"" + userParam.office_unit + "\",\"designation_id\":" + userParam.designation_id + ",\"designation_level\":\"" + userParam.designation_level + "\",\"name\":\"" + userParam.officer_name + "\"}";

            string assigneejson = "[{\"office_id\":" + assignee.office_id + ",\"office_name\":\"" + assignee.office + "\",\"office_unit_id\":\"" + assignee.office_unit_id + "\",\"office_unit_name\":\"" + assignee.office_unit + "\",\"designation_id\":" + assignee.designation_id + ",\"designation_level\":\"" + assignee.designation_level + "\",\"name\":\"" + assignee.officer_name + "\"}]";
            
            if (!InternetConnection.Check())
            {
                string assigneeData = "{\"office_id\":" + assignee.office_id + ",\"office_name\":\"" + assignee.office + "\",\"office_unit_id\":\"" + assignee.office_unit_id + "\",\"office_unit_name\":\"" + assignee.office_unit + "\",\"designation_id\":" + assignee.designation_id + ",\"designation_level\":\"" + assignee.designation_level + "\",\"name\":\"" + assignee.officer_name + "\"}";

                return SaveUpdateLocalAssignee(userParam, assignorjson, assigneeData,  assignee);

            }
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(3));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("assignor", assignorjson);
                request.AddParameter("assignee", assigneejson);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel Delete(DakUserParam userParam, int assignee_designation_id)
        {
            if (!InternetConnection.Check())
            {

                return RemoveUpdateLocalAssignee( userParam,  assignee_designation_id);

            }
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(4));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("assignee_designation_id", assignee_designation_id);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseData GetList(DakUserParam userParam, int actionLink,int? assignor_designation_id)
        {
            if (!InternetConnection.Check())
            {
                if (actionLink == 2)
                {
                    ResponseData localResponse = JsonConvert.DeserializeObject<ResponseData>(GetLocaldakBoxList(userParam, assignor_designation_id??default));
                    return localResponse; 
                }
                else
                {
                    ResponseData localResponse = JsonConvert.DeserializeObject<ResponseData>(GetLocaldakBoxSharedToOfficer(userParam, assignor_designation_id));
                    return localResponse;
                }
            }

            try
            {
               
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);


                request.AddHeader("Authorization", "Bearer " + userParam.token);

                request.AlwaysMultipartFormData = true;

                request.AddParameter("designation_id", userParam.designation_id);

                request.AddParameter("office_id", userParam.office_id);
                if (actionLink == 2)
                {
                    request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                    request.AddParameter("assignor_designation_id", assignor_designation_id);
                    request.AddParameter("page", userParam.page);
                    request.AddParameter("limit", userParam.limit);
                }
                else
                {
                    request.AddHeader("api-version", CommonSetting.GetAPIVersion());

                    if (assignor_designation_id == 1)
                    {
                        request.AddParameter("assignee_designation_id", userParam.designation_id);
                    }
                    else
                    {
                        request.AddParameter("assignor_designation_id", userParam.designation_id);
                    }

                }

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;
                if (actionLink == 2)
                     SaveLocalDakBoxBacaikaranlist(responseJson, userParam, assignor_designation_id??default);
                else
                    SaveLocalDakBoxSharedToOfficer(responseJson, userParam, assignor_designation_id);
                ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(responseJson);
                
                return responseData;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public ResponseModel AddDakSorting(DakUserParam userParam, DakSorting daksortParam)
        {
            string dakname = "daak_container_sorting_daak_box_" + daksortParam.is_copied_dak.ToString() + "_" + daksortParam.id.ToString() + "_" + daksortParam.dak_type;

            string dakSortingParam = ConversionMethod.ObjecttoJson(daksortParam);
            string dakInfoJson = "{\"" + dakname + "\":" + dakSortingParam + "}";
            if (!InternetConnection.Check())
            {

                return SaveUpdateLocalDakSorting(userParam, daksortParam, dakSortingParam);

            }
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(6));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
              
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);

                request.AddParameter("daks", dakInfoJson);
               // string d=\"recipients\":{\"mul_prapok\":{\"designation_bng\":\"\\u09a1\\u09cb\\u09ae\\u09c7\\u09a8 \\u09b8\\u09cd\\u09aa\\u09c7\\u09b6\\u09be\\u09b2\\u09bf\\u09b8\\u09cd\\u099f\",\"designation_eng\":\"\",\"designation_id\":\"12639\",\"unit_name_bng\":\"\\u09a8\\u09a5\\u09bf \",\"unit_name_eng\":\"Nothi \",\"unit_id\":\"5121\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09a8\\u09bf\\u09b2\\u09c1\\u09ab\\u09be \\u0987\\u09df\\u09be\\u09b8\\u09ae\\u09bf\\u09a8 \",\"employee_name_eng\":\"Nilufa Yasmin\",\"employee_record_id\":\"183124\",\"incharge_label\":\"\\u0985\\u09a4\\u09bf\\u09b0\\u09bf\\u0995\\u09cd\\u09a4 \\u09a6\\u09be\\u09df\\u09bf\\u09a4\\u09cd\\u09ac\"},\"onulipi\":{\"244873\":{\"designation_bng\":\"\\u099a\\u09c0\\u09ab \\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf \\u0985\\u09ab\\u09bf\\u09b8\\u09be\\u09b0\",\"designation_eng\":\"Chief Technology Officer\",\"designation_id\":\"244873\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u0986\\u09b0\\u09ab\\u09c7 \\u098f\\u09b2\\u09be\\u09b9\\u09c0\",\"employee_name_eng\":\"Mohammad Arfe Elahi\",\"employee_record_id\":\"77835\",\"incharge_label\":\"\"},\"244930\":{\"designation_bng\":\"\\u09b8\\u09b2\\u09cd\\u09af\\u09c1\\u09b6\\u09a8 \\u0986\\u09b0\\u09cd\\u0995\\u09bf\\u099f\\u09c7\\u0995\\u09cd\\u099f\",\"designation_eng\":\"Solution Architect\",\"designation_id\":\"244930\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u09b9\\u09be\\u09b8\\u09be\\u09a8\\u09c1\\u099c\\u09cd\\u099c\\u09be\\u09ae\\u09be\\u09a8\",\"employee_name_eng\":\"Mr. Md. Hasanuzzaman\",\"employee_record_id\":\"77858\",\"incharge_label\":\"\"}}}}}"
               // request.AddParameter("daks", "{\"daak_container_sorting_daak_box_1_6976_Daptorik\":{\"id\":\"6976\",\"dak_type\":\"Daptorik\",\"is_copied_dak\":\"1\",\"dak_subject\":\"\\u09a6\\u09be\\u09aa\\u09cd\\u09a4\\u09b0\\u09bf\\u0995 \\u09a1\\u09be\\u0995 \\u0986\\u09aa\\u09b2\\u09cb\\u09a1\",\"sender\":\"\\u099c\\u09be\\u09ab\\u09b0\\u09bf\\u09a8 \\u0986\\u09b9\\u09ae\\u09c7\\u09a6\",\"sending_date\":\"\\n                                        \\u09e6\\u09e7-\\u09e6\\u09e7-\\u09e7\\u09ef\\u09ed\\u09e6 \\u09e6\\u09e6:\\u09e6\\u09e6:\\u09e6\\u09e6                                    \",\"decision\":\"Test Decision\",\"priority\":\"6\",\"security\":\"5\",\"recipients\":{\"mul_prapok\":{\"designation_bng\":\"\\u09a1\\u09cb\\u09ae\\u09c7\\u09a8 \\u09b8\\u09cd\\u09aa\\u09c7\\u09b6\\u09be\\u09b2\\u09bf\\u09b8\\u09cd\\u099f\",\"designation_eng\":\"\",\"designation_id\":\"12639\",\"unit_name_bng\":\"\\u09a8\\u09a5\\u09bf \",\"unit_name_eng\":\"Nothi \",\"unit_id\":\"5121\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09a8\\u09bf\\u09b2\\u09c1\\u09ab\\u09be \\u0987\\u09df\\u09be\\u09b8\\u09ae\\u09bf\\u09a8 \",\"employee_name_eng\":\"Nilufa Yasmin\",\"employee_record_id\":\"183124\",\"incharge_label\":\"\\u0985\\u09a4\\u09bf\\u09b0\\u09bf\\u0995\\u09cd\\u09a4 \\u09a6\\u09be\\u09df\\u09bf\\u09a4\\u09cd\\u09ac\"},\"onulipi\":{\"244873\":{\"designation_bng\":\"\\u099a\\u09c0\\u09ab \\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf \\u0985\\u09ab\\u09bf\\u09b8\\u09be\\u09b0\",\"designation_eng\":\"Chief Technology Officer\",\"designation_id\":\"244873\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u0986\\u09b0\\u09ab\\u09c7 \\u098f\\u09b2\\u09be\\u09b9\\u09c0\",\"employee_name_eng\":\"Mohammad Arfe Elahi\",\"employee_record_id\":\"77835\",\"incharge_label\":\"\"},\"244930\":{\"designation_bng\":\"\\u09b8\\u09b2\\u09cd\\u09af\\u09c1\\u09b6\\u09a8 \\u0986\\u09b0\\u09cd\\u0995\\u09bf\\u099f\\u09c7\\u0995\\u09cd\\u099f\",\"designation_eng\":\"Solution Architect\",\"designation_id\":\"244930\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u09b9\\u09be\\u09b8\\u09be\\u09a8\\u09c1\\u099c\\u09cd\\u099c\\u09be\\u09ae\\u09be\\u09a8\",\"employee_name_eng\":\"Mr. Md. Hasanuzzaman\",\"employee_record_id\":\"77858\",\"incharge_label\":\"\"}}}}}");
               // request.AddParameter("office_id", "{{office_id}}");
                request.AddParameter("dak_inbox_designation_id", daksortParam.dak_inbox_designation_id);
               // request.AddParameter("designation_id", "{{designation_id}}");


                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;
               

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel DakSortingDelete(DakUserParam userParam, DakSorting daksortParam)
        {
            if (!InternetConnection.Check())
            {

                return RemoveUpdateLocalDakSorting(userParam, daksortParam);

            }
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(7));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("daks", "[{\"id\":\""+ daksortParam.id+ "\",\"dak_type\":\""+daksortParam.dak_type+"\",\"is_copied_dak\":\""+ daksortParam.is_copied_dak+ "\"}]");
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("dak_inbox_designation_id", daksortParam.dak_inbox_designation_id);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SendLocalDataToServer(DakUserParam userParam)
        {
            var localDakBoxSharingData = _localDakBoxSharingRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id).ToList();

            foreach (var item in localDakBoxSharingData)
            {
                if (item.IsEnable == true && item.IsLocal == true)
                {
                    Assignee assignee = JsonConvert.DeserializeObject<Assignee>(item.assignee);

                    PrapokDTO prapokDTO = new PrapokDTO { office_id = assignee.office_id, office = assignee.office_name, office_unit_id = assignee.office_unit_id, office_unit = assignee.office_unit_name, designation_id = assignee.designation_id, designation_level = Convert.ToInt32(assignee.designation_level), officer_name = assignee.name };

                    var response = Add(userParam, prapokDTO);
                    if (response.status == "success")
                    {
                        _localDakBoxSharingRepository.Delete(item);
                    }
                }
                else
                {

                    var response = Delete(userParam, item.assignee_designation_id);
                    if (response.status == "success")
                    {
                        _localDakBoxSharingRepository.Delete(item);
                    }
                }

            }

            return true;
        }
        public bool SendDakSortingLocalDataToServer(DakUserParam userParam)
        {
            ResponseModel response = new ResponseModel();
            var localDakBoxSharingData = _localDakBacaiKaranRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id).ToList();

            foreach (var item in localDakBoxSharingData)
            {
                //DakSorting dakSorting = new DakSorting { dak_inbox_designation_id= item.dak_inbox_designation_id,
                //    dak_type=item.dak_type, id=item.dak_id, is_copied_dak=item.is_copied_dak };
                DakSorting dakSorting = JsonConvert.DeserializeObject<DakSorting>(item.dakInfoJson);
                if (item.IsEnable == true )
                {
                     response = AddDakSorting( userParam,  dakSorting);
                   
                }
                else
                {
                   response = DakSortingDelete(userParam, dakSorting);
                }
                if (response.status == "success")
                {
                    _localDakBacaiKaranRepository.Delete(item);
                }
            }

            return true;
        }

        public List<DakBacaiKaran> LocalDakSortingList(DakUserParam userParam,int dak_id)
        {
            var localDakBoxSharingData = _localDakBacaiKaranRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.dak_id== dak_id).ToList();
            return localDakBoxSharingData;
        }

        //DakSortingDelete
        private void SaveLocalDakBoxSharedToOfficer(string dakBoxSharedToOfficerResponseJson, DakUserParam dakListUserParam,int? assignor_designation_id)
        {
            var dakBoxSharedToOfficer = _localAssigneeRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.assignor_designation_id== (assignor_designation_id == null ? dakListUserParam.designation_id : 0) && q.assignee_designation_id == (assignor_designation_id != null ? dakListUserParam.designation_id : 0)).FirstOrDefault();

            if (dakBoxSharedToOfficer != null)
            {
                dakBoxSharedToOfficer.officer_details_Json = dakBoxSharedToOfficerResponseJson;
               
                _localAssigneeRepository.Update(dakBoxSharedToOfficer);
            }
            else
            {
                DakBoxSharedToOfficer localDakBoxSharedToOfficer = new DakBoxSharedToOfficer { designation_id = dakListUserParam.designation_id, office_id = dakListUserParam.office_id, assignor_designation_id = (assignor_designation_id == null ? dakListUserParam.designation_id : 0), assignee_designation_id = (assignor_designation_id != null ? dakListUserParam.designation_id : 0), officer_details_Json = dakBoxSharedToOfficerResponseJson };


                _localAssigneeRepository.Insert(localDakBoxSharedToOfficer);
            }

            string da = "data";

            if (dakBoxSharedToOfficer != null)
            {
                var jObject = JObject.Parse(dakBoxSharedToOfficer.officer_details_Json);


                var data = jObject[da].ToString();


                if (data == "[]")
                {
                    _localAssigneeRepository.Delete(dakBoxSharedToOfficer);
                }
            }



        }
        private string GetLocaldakBoxSharedToOfficer(DakUserParam dakListUserParam, int? assignor_designation_id)
        {
            var dakBoxSharedToOfficer = _localAssigneeRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.assignor_designation_id == (assignor_designation_id == null ? dakListUserParam.designation_id : 0) && q.assignee_designation_id == (assignor_designation_id != null ? dakListUserParam.designation_id : 0)).FirstOrDefault();

            if (dakBoxSharedToOfficer != null)
            {
                return dakBoxSharedToOfficer.officer_details_Json;
            }
            else
            {
                 string defaultJson= "{\"status\":\"success\",\"data\":[],\"options\":[]}";
                return defaultJson;
            }

        }

        private ResponseModel SaveUpdateLocalAssignee(DakUserParam userParam,string assignorjson, string assigneejson, PrapokDTO assignee)
        {
            var localDakBoxSharing = _localDakBoxSharingRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.assignee_designation_id == assignee.designation_id).FirstOrDefault();

            if (localDakBoxSharing != null)
            {
                localDakBoxSharing.IsEnable = true;
                _localDakBoxSharingRepository.Update(localDakBoxSharing);

            }
            else
            {
                DakBoxSharing localDakBoxSharingInsert = new DakBoxSharing { IsEnable = true, assignee_designation_id = assignee.designation_id, designation_id = userParam.designation_id, office_id = userParam.office_id, assignor = assignorjson, assignee = assigneejson, EntryDate = DateTime.Now, IsLocal = true, IsSubmitted = false };
                _localDakBoxSharingRepository.Insert(localDakBoxSharingInsert);
            }
           
            var assignes = new Assignee { designation_id = assignee.designation_id, designation_level = assignee.designation_level.ToString(), name = assignee.officer_name, office_id = assignee.office_id, office_name = assignee.office_name, office_unit_id = assignee.office_unit_id, office_unit_name = assignee.office_unit_bng };
            var assignor = new Assignor { designation_id = userParam.designation_id, designation_level = userParam.designation_level.ToString(), name = userParam.officer_name, office_id = userParam.office_id, office_name = userParam.office, office_unit_id = userParam.office_unit_id, office_unit_name = userParam.office_unit };
            
            string dakBoxAssignee = string.Empty;
            var dakBoxSharedToOfficer = _localAssigneeRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.assignor_designation_id ==  userParam.designation_id).FirstOrDefault();
           
            if (dakBoxSharedToOfficer != null )
            {
                ShareList localResponse = new ShareList();
                localResponse = JsonConvert.DeserializeObject<ShareList>(dakBoxSharedToOfficer.officer_details_Json);
                localResponse.data.assignee.Add(assignes);

                dakBoxAssignee = JsonConvert.SerializeObject(localResponse);
              
            }
            else
            {
                
               
                List<Assignee> s =new List<Assignee>();
                s.Add(assignes);
                List<Assignor> ass = new List<Assignor>();
                ass.Add(assignor);
                ShareList.Data data = new ShareList.Data {  assignee=s, assignor=ass};
              
               // shareList.status = "success";
                ShareList shareList = new ShareList {  status= "success" , data= data };
                //shareList.data.assignee.Add(assignes);
                //shareList.data.assignor.Add(assignor);
                dakBoxAssignee = JsonConvert.SerializeObject(shareList);
            }
            SaveLocalDakBoxSharedToOfficer(dakBoxAssignee, userParam, null);
           return new ResponseModel { data = "Dak Sorting Permission Saved Locally", status = "success" };
        }

        private ResponseModel RemoveUpdateLocalAssignee(DakUserParam userParam, int assignee_designation_id)
        {
            string dakBoxAssignee = string.Empty;
            var dakBoxSharedToOfficer = _localAssigneeRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.assignor_designation_id == userParam.designation_id).FirstOrDefault();
            if (dakBoxSharedToOfficer != null)
            {
                var localResponse = JsonConvert.DeserializeObject<ShareList>(dakBoxSharedToOfficer.officer_details_Json);
                var assignee = localResponse.data.assignee.Where(x => x.designation_id == assignee_designation_id).FirstOrDefault();

                var localDakBoxSharing = _localDakBoxSharingRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.assignee_designation_id == assignee_designation_id).FirstOrDefault();
                if (localDakBoxSharing != null)
                {
                    localDakBoxSharing.IsEnable = false;
                    _localDakBoxSharingRepository.Update(localDakBoxSharing);
                }
                else
                {
                    DakBoxSharing localDakBoxSharingInsert = new DakBoxSharing { IsEnable = false, assignee_designation_id = assignee.designation_id, designation_id = userParam.designation_id, office_id = userParam.office_id, EntryDate = DateTime.Now, IsLocal = false, assignor= JsonConvert.SerializeObject(userParam), IsSubmitted = false };
                    _localDakBoxSharingRepository.Insert(localDakBoxSharingInsert);
                }

                localResponse.data.assignee.RemoveAll(x=>x.designation_id== assignee_designation_id);

                dakBoxAssignee = JsonConvert.SerializeObject(localResponse);

            }
           
            SaveLocalDakBoxSharedToOfficer(dakBoxAssignee, userParam, null);
            return new ResponseModel { data = "Dak Sorting Permission Deleted Locally", status = "success" };
        }


        #region dakBacaikaranLocally
      
        private void SaveLocalDakBoxBacaikaranlist(string dakBoxResponseJson, DakUserParam dakListUserParam, int assignor_designation_id)
        {
            var dakBoxBacaikaranlist = _localDakBacaiKaranListRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.assignor_designation_id == assignor_designation_id && q.page== dakListUserParam.page).FirstOrDefault();

            if (dakBoxBacaikaranlist != null)
            {
                dakBoxBacaikaranlist.daklist_json = dakBoxResponseJson;
                _localDakBacaiKaranListRepository.Update(dakBoxBacaikaranlist);
            }
            else
            {
                DakBacaiKaranList localdakBoxBacaikaranlist = new DakBacaiKaranList { designation_id = dakListUserParam.designation_id, office_id = dakListUserParam.office_id, assignor_designation_id = assignor_designation_id,  daklist_json = dakBoxResponseJson, page= dakListUserParam.page, limit= dakListUserParam.limit };


                _localDakBacaiKaranListRepository.Insert(localdakBoxBacaikaranlist);
            }

        }
       
        private string GetLocaldakBoxList(DakUserParam dakListUserParam, int assignor_designation_id)
        {
            var dakBox = _localDakBacaiKaranListRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.assignor_designation_id == assignor_designation_id && q.page== dakListUserParam.page).FirstOrDefault();

            if (dakBox != null)
            {
                return dakBox.daklist_json;
            }
            else
            {
                return "";
            }

        }

        private ResponseModel SaveUpdateLocalDakSorting (DakUserParam userParam, DakSorting daksortParam, string  dakSortingjson)
        {
            var localDakBoxSorting = _localDakBacaiKaranRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.dak_id== daksortParam.id && q.IsEnable==true).FirstOrDefault();

            if (localDakBoxSorting != null)
            {
                localDakBoxSorting.IsEnable = true;
                localDakBoxSorting.dakInfoJson = dakSortingjson;
                _localDakBacaiKaranRepository.Update(localDakBoxSorting);

            }
            else
            {
                DakBacaiKaran localDakBoxBacaiInsert = new DakBacaiKaran { 
                    designation_id = userParam.designation_id, office_id = userParam.office_id,
                    dak_inbox_designation_id= daksortParam.dak_inbox_designation_id,
                    dak_id = daksortParam.id, dak_type= daksortParam.dak_type, is_copied_dak=daksortParam.is_copied_dak,
                    dakInfoJson = dakSortingjson,
                    IsLocal = true,
                    IsSubmitted = false,
                    IsEnable = true, 
                };
                _localDakBacaiKaranRepository.Insert(localDakBoxBacaiInsert);
            }

            return new ResponseModel { data = "Dak Sorting Permission Saved Locally", status = "success" };
        }

        private ResponseModel RemoveUpdateLocalDakSorting(DakUserParam userParam, DakSorting daksortParam)
        {
            var localDakBoxSorting = _localDakBacaiKaranRepository.Table.Where(q => q.designation_id == userParam.designation_id && q.office_id == userParam.office_id && q.dak_id == daksortParam.id && q.IsEnable==false).FirstOrDefault();

            if (localDakBoxSorting != null)
            {
                 localDakBoxSorting.IsEnable = false;
               
                _localDakBacaiKaranRepository.Update(localDakBoxSorting);

            }
            else
            {
                DakBacaiKaran localDakBoxBacaiInsert = new DakBacaiKaran
                {
                    designation_id = userParam.designation_id,
                    office_id = userParam.office_id,
                    dak_inbox_designation_id = daksortParam.dak_inbox_designation_id,
                    dak_id = daksortParam.id,
                    dak_type = daksortParam.dak_type,
                    is_copied_dak = daksortParam.is_copied_dak,
                    dakInfoJson = string.Empty,
                    IsLocal = true,
                    IsSubmitted = false,
                    IsEnable = false
                };
                _localDakBacaiKaranRepository.Insert(localDakBoxBacaiInsert);
            }

            return new ResponseModel { data = "Dak Sorting Permission Saved Locally", status = "success" };
           
        }



        #endregion


    }
}

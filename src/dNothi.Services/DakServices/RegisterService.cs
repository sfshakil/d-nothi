using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.BasicService.Models;
using dNothi.Services.DakServices.DakReports;
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
   public class RegisterService:IRegisterService
    {
        IRepository<DakRegisterBook> _localDakRegisterBookRepository;
        IRepository<DakTraking> _localDakTrakingRepository;
        
        public RegisterService(IRepository<DakRegisterBook> localDakRegisterBookRepository, IRepository<DakTraking> localDakTrakingRepository)
        {
            _localDakRegisterBookRepository = localDakRegisterBookRepository;
            _localDakTrakingRepository = localDakTrakingRepository;
        }
        public DakReportModel GetDakGrohonResponse(DakUserParam dakUserParam,string fromDate, string toDate, string branchName, bool isDakGrahan, bool isDakBili, bool isShakaDiary)
        {
            int unitid = 0;
            if(branchName!=null)
            {
                unitid = Convert.ToInt32(branchName);
            }
           
            DakReportModel registerReportResponse = new DakReportModel();
            if (!InternetConnection.Check())
            {
               

                registerReportResponse = JsonConvert.DeserializeObject<DakReportModel>(GetLocalDakRegisterBook(dakUserParam, fromDate , toDate, unitid, isDakGrahan, isDakBili, isShakaDiary));
                return registerReportResponse;
               
            }

            try
            {
                string search_params=string.Empty;
                var dakGrohonAPI = new RestClient(GetAPIDomain() + DefaultAPIConfiguration.DakNibondanBohiEndPoint);
                dakGrohonAPI.Timeout = -1;
                var dakGrohonRequest = new RestRequest(Method.POST);
                dakGrohonRequest.AddHeader("api-version", GetOldAPIVersion());
                dakGrohonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakGrohonRequest.AlwaysMultipartFormData = true;
                dakGrohonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakGrohonRequest.AddParameter("office_id", dakUserParam.office_id);
                dakGrohonRequest.AddParameter("length", dakUserParam.limit);
                dakGrohonRequest.AddParameter("page", dakUserParam.page);
               
               if(isDakGrahan)
                 search_params = "to_office_unit_id=" + unitid + "&to_office_id=" + dakUserParam.office_id + "&movement_date_range=" + fromDate + ":" + toDate + "";
               if(isDakBili)
                    search_params = "to_office_unit_id=" + unitid + "&from_office_id=" + dakUserParam.office_id + "&movement_date_range=" + fromDate + ":" + toDate + "";
               if (isShakaDiary)
                   search_params = "office_unit_id=" + unitid + "&office_id=" + dakUserParam.office_id + "&movement_date_range=" + fromDate + ":" + toDate + "";
               
                dakGrohonRequest.AddParameter("search_params", search_params);
              
                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
                SaveLocalDakRegisterBook(dakGrohonResponseJson, dakUserParam, fromDate, toDate, unitid, isDakGrahan, isDakBili, isShakaDiary);
                
                registerReportResponse = JsonConvert.DeserializeObject<DakReportModel>(dakGrohonResponseJson);
                return registerReportResponse;
            }
            catch (Exception ex)
            {
                return registerReportResponse;
            }


        }
        private string GetLocalDakRegisterBook(DakUserParam dakListUserParam, string fromDate, string toDate, int unitid, bool isDakGrahan, bool isDakBili, bool isShakaDiary)
        {
            var dakBox = _localDakRegisterBookRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit== dakListUserParam.limit && q.page == dakListUserParam.page && q.fromDate==fromDate && q.toDate==toDate && q.isDakGrahan==isDakGrahan && q.isDakBili==isDakBili && q.isShakaDiary==isShakaDiary && q.unitId==unitid ).FirstOrDefault();

            if (dakBox != null)
            {
                return dakBox.daklist_json;
            }
            else
            {
                string data= "{\"status\":\"success\",\"data\":{\"records\":[],\"total_records\":0},\"options\":[]}";
               return data;
            }

        }
        private void SaveLocalDakRegisterBook(string dakBoxResponseJson, DakUserParam dakListUserParam, string fromDate, string toDate, int  unitid, bool isDakGrahan, bool isDakBili, bool isShakaDiary)
        {
            var dakBox = _localDakRegisterBookRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.fromDate == fromDate && q.toDate == toDate && q.isDakGrahan == isDakGrahan && q.isDakBili == isDakBili && q.isShakaDiary == isShakaDiary && q.unitId==unitid ).FirstOrDefault();

            if (dakBox != null)
            {
                dakBox.daklist_json = dakBoxResponseJson;
                _localDakRegisterBookRepository.Update(dakBox);
            }
            else
            {
                DakRegisterBook localDakRegisterBook = new DakRegisterBook
                { 
                    designation_id = dakListUserParam.designation_id, office_id = dakListUserParam.office_id, 
                    daklist_json = dakBoxResponseJson, page = dakListUserParam.page, limit = dakListUserParam.limit,
                      isDakGrahan=isDakGrahan,  isDakBili=isDakBili,  isShakaDiary=isShakaDiary, fromDate=fromDate, toDate=toDate, unitId=unitid
                };
               _localDakRegisterBookRepository.Insert(localDakRegisterBook);
            }
           
        }

     
        /*
        public RegisterReportResponse GetDakBiliResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            int unitid = 0;
            if (branchName != null)
            {
                unitid = Convert.ToInt32(branchName);
            }
            bool dnb = false;
            bool dnc = true;
            bool dnd = false;
            RegisterReportResponse registerReportResponse = new RegisterReportResponse();
            if (!InternetConnection.Check())
            {


                registerReportResponse = JsonConvert.DeserializeObject<RegisterReportResponse>(GetLocalDakRegisterBook(dakUserParam, fromDate, toDate, unitid, dnb, dnc, dnd));
                return registerReportResponse;

            }

            try
            {
                var dakGrohonAPI = new RestClient(GetAPIDomain() + GetDakBiliAddEndPoint());
                dakGrohonAPI.Timeout = -1;
                var dakGrohonRequest = new RestRequest(Method.POST);
                dakGrohonRequest.AddHeader("api-version", GetOldAPIVersion());
                dakGrohonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakGrohonRequest.AlwaysMultipartFormData = true;
                dakGrohonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakGrohonRequest.AddParameter("office_id", dakUserParam.office_id);

                dakGrohonRequest.AddParameter("start_date", fromDate);
                dakGrohonRequest.AddParameter("end_date", toDate);
                dakGrohonRequest.AddParameter("unit_id", branchName);
                dakGrohonRequest.AddParameter("length", dakUserParam.limit);
                dakGrohonRequest.AddParameter("page", dakUserParam.page);

                //string search_params = "to_office_unit_id=" + unitid + "&from_office_id=" + dakUserParam.office_id + "&movement_date_range=" + fromDate + ":" + toDate + "";
                //dakGrohonRequest.AddParameter("search_params", search_params);

                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
                var data = SaveLocalDakRegisterBook(dakGrohonResponseJson, dakUserParam, fromDate, toDate, unitid, dnb, dnc, dnd);
             
                registerReportResponse = JsonConvert.DeserializeObject<RegisterReportResponse>(dakGrohonResponseJson);
                return registerReportResponse;
            }
            catch (Exception ex)
            {
                return registerReportResponse;
            }


        }
        public RegisterReportResponse GetDakDiaryResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            int unitid = 0;
            if (branchName != null)
            {
                unitid = Convert.ToInt32(branchName);
            }
            bool dnb = false;
            bool dnc = false;
            bool dnd = true;
            RegisterReportResponse registerReportResponse = new RegisterReportResponse();
            if (!InternetConnection.Check())
            {


                registerReportResponse = JsonConvert.DeserializeObject<RegisterReportResponse>(GetLocalDakRegisterBook(dakUserParam, fromDate, toDate, unitid, dnb, dnc, dnd));
                return registerReportResponse;

            }

            try
            {
                var dakGrohonAPI = new RestClient(GetAPIDomain() + GetDakDiaryEndPoint());
                dakGrohonAPI.Timeout = -1;
                var dakGrohonRequest = new RestRequest(Method.POST);
                dakGrohonRequest.AddHeader("api-version", GetOldAPIVersion());
                dakGrohonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakGrohonRequest.AlwaysMultipartFormData = true;
                dakGrohonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakGrohonRequest.AddParameter("office_id", dakUserParam.office_id);

                dakGrohonRequest.AddParameter("start_date", fromDate);
                dakGrohonRequest.AddParameter("end_date", toDate);
                dakGrohonRequest.AddParameter("unit_id", branchName);
                dakGrohonRequest.AddParameter("length", dakUserParam.limit);
                dakGrohonRequest.AddParameter("page", dakUserParam.page);

                //string search_params = "office_unit_id=" + unitid + "&office_id=" + dakUserParam.office_id + "&movement_date_range=" + fromDate + ":" + toDate + "";
                //dakGrohonRequest.AddParameter("search_params", search_params);

                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
                var data = SaveLocalDakRegisterBook(dakGrohonResponseJson, dakUserParam, fromDate, toDate, unitid, dnb, dnc, dnd);
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                registerReportResponse = JsonConvert.DeserializeObject<RegisterReportResponse>(dakGrohonResponseJson);
                return registerReportResponse;
            }
            catch (Exception ex)
            {
                return registerReportResponse;
            }


        }
        */
        public DakReportModel GetDakTrakingResponse(DakUserParam dakUserParam, string fromDate, string toDate, string mobile,string subject,string getapplication)
        {
            string searchParam = "dak_subject=" + subject + "&dak_received_no=" + getapplication + "&phone=" + mobile + "&last_modified_date =" + fromDate + ":" + toDate + "";
            DakReportModel registerReportResponse = new DakReportModel();
            if (!InternetConnection.Check())
            {


                registerReportResponse = JsonConvert.DeserializeObject<DakReportModel>(GetLocalDakTraking(dakUserParam, searchParam));
                return registerReportResponse;

            }

            try
            {
                var dakTrakingAPI = new RestClient(GetAPIDomain() + DefaultAPIConfiguration.DakSearchEndPoint);
                dakTrakingAPI.Timeout = -1;
                var dakTrakingRequest = new RestRequest(Method.POST);
                dakTrakingRequest.AddHeader("api-version", GetOldAPIVersion());
                dakTrakingRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakTrakingRequest.AlwaysMultipartFormData = true;
                dakTrakingRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakTrakingRequest.AddParameter("office_id", dakUserParam.office_id);
                //dakGrohonRequest.AddParameter("user_id", dakUserParam.user_id);


                // dakGrohonRequest.AddParameter("search_params", "dak_subject=&dak_received_no=&phone=&last_modified_date=2021/09/14:2021/10/13");
                dakTrakingRequest.AddParameter("search_params", searchParam);
                // dakGrohonRequest.AddParameter("dak_list_type", "dak_tracking");
                // dakGrohonRequest.AddParameter("length", dakUserParam.limit);
                dakTrakingRequest.AddParameter("limit", dakUserParam.limit);
                dakTrakingRequest.AddParameter("page", dakUserParam.page);



                IRestResponse dakTrakingResponseIRest = dakTrakingAPI.Execute(dakTrakingRequest);




                var dakTrakingResponseJson = dakTrakingResponseIRest.Content;
                SaveLocalDakTraking(dakTrakingResponseJson, dakUserParam, searchParam);
                registerReportResponse = JsonConvert.DeserializeObject<DakReportModel>(dakTrakingResponseJson);
                return registerReportResponse;
            }
            catch (Exception ex)
            {
                return registerReportResponse;
            }


        }
        private string GetLocalDakTraking(DakUserParam dakListUserParam,string searchparam)
        {
            var dakBox = _localDakTrakingRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.search_params==searchparam).FirstOrDefault();

            if (dakBox != null)
            {
                return dakBox.daklist_json;
            }
            else
            {
                string data = "{\"status\":\"success\",\"data\":{\"records\":[],\"total_records\":0},\"options\":[]}";
                return data;
            }

        }
        private void SaveLocalDakTraking(string dakBoxResponseJson, DakUserParam dakListUserParam, string searchParam)
        {
            var dakBox = _localDakTrakingRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.search_params==searchParam).FirstOrDefault();

            if (dakBox != null)
            {
                dakBox.daklist_json = dakBoxResponseJson;
                _localDakTrakingRepository.Update(dakBox);
            }
            else
            {
                DakTraking localDakTraking = new DakTraking
                {
                    designation_id = dakListUserParam.designation_id,
                    office_id = dakListUserParam.office_id,
                    daklist_json = dakBoxResponseJson,
                    page = dakListUserParam.page,
                    limit = dakListUserParam.limit,
                    search_params=searchParam
                };
                _localDakTrakingRepository.Insert(localDakTraking);
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
        //protected string GetDakGrohonEndPoint()
        //{
        //    return DefaultAPIConfiguration.DakGrohonEndPoint;
        //}
        //protected string GetDakBiliAddEndPoint()
        //{
        //    return DefaultAPIConfiguration.DakBiliAddEndPoint;
        //}
        //protected string GetDakDiaryEndPoint()
        //{
        //    return DefaultAPIConfiguration.DakDiaryEndPoint;
        //}

     
    }

    public interface IRegisterService
    {
        DakReportModel GetDakGrohonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName, bool isDakGrahan, bool isDakBili, bool isShakaDiary);
        //RegisterReportResponse GetDakBiliResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        //RegisterReportResponse GetDakDiaryResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        DakReportModel GetDakTrakingResponse(DakUserParam dakUserParam, string fromDate, string toDate, string mobile, string subject, string application_no);
        

        }

}

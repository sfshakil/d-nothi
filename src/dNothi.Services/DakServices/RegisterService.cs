using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.BasicService.Models;
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
        public RegisterService(IRepository<DakRegisterBook> localDakRegisterBookRepository)
        {
            _localDakRegisterBookRepository = localDakRegisterBookRepository;
        }
        public RegisterReportResponse GetDakGrohonResponse(DakUserParam dakUserParam,string fromDate, string toDate, string branchName)
        {
            int unitid = 0;
            if(branchName!=null)
            {
                unitid = Convert.ToInt32(branchName);
            }
            bool dnb = true;
            bool dnc = false;
            bool dnd = false;
            RegisterReportResponse registerReportResponse = new RegisterReportResponse();
            if (!InternetConnection.Check())
            {
               

                registerReportResponse = JsonConvert.DeserializeObject<RegisterReportResponse>(GetLocalDakRegisterBook(dakUserParam, fromDate , toDate, unitid, dnb, dnc, dnd));
                return registerReportResponse;
               
            }

            try
            {
                var dakGrohonAPI = new RestClient(GetAPIDomain() + GetDakGrohonEndPoint());
                dakGrohonAPI.Timeout = -1;
                var dakGrohonRequest = new RestRequest(Method.POST);
                dakGrohonRequest.AddHeader("api-version", GetOldAPIVersion());
                dakGrohonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakGrohonRequest.AlwaysMultipartFormData = true;
                dakGrohonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakGrohonRequest.AddParameter("office_id", dakUserParam.office_id);

                dakGrohonRequest.AddParameter("start_date",fromDate);
                dakGrohonRequest.AddParameter("end_date", toDate);
                dakGrohonRequest.AddParameter("unit_id", branchName);
                dakGrohonRequest.AddParameter("length", dakUserParam.limit);
                dakGrohonRequest.AddParameter("page", dakUserParam.page);



                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
                var data=  SaveLocalDakRegisterBook(dakGrohonResponseJson, dakUserParam, fromDate, toDate, unitid, dnb, dnc, dnd);
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
        private string GetLocalDakRegisterBook(DakUserParam dakListUserParam, string fromDate, string toDate, int unitid, bool dnb, bool dnc, bool dnd)
        {
            var dakBox = _localDakRegisterBookRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit== dakListUserParam.limit && q.page == dakListUserParam.page && q.fromDate==fromDate && q.toDate==toDate && q.dnd==dnd && q.dnc==q.dnc && q.dnb==q.dnb && q.unitId==unitid ).FirstOrDefault();

            if (dakBox != null)
            {
                return dakBox.daklist_json;
            }
            else
            {
                return "";
            }

        }
        private bool SaveLocalDakRegisterBook(string dakBoxResponseJson, DakUserParam dakListUserParam, string fromDate, string toDate, int  unitid, bool dnb, bool dnc, bool dnd)
        {
            var dakBox = _localDakRegisterBookRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.fromDate == fromDate && q.toDate == toDate && q.dnd == dnd && q.dnc == q.dnc && q.dnb == q.dnb && q.unitId==unitid ).FirstOrDefault();

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
                     dnb=dnb, dnc=dnc, dnd=dnd, fromDate=fromDate, toDate=toDate, unitId=unitid
                };
               _localDakRegisterBookRepository.Insert(localDakRegisterBook);
            }
            return true;
        }

        //private void param() {
        //[designation_id] => 22418
        //[office_id] => 65
        //[user_id] => 4398
        //[page] => 1
        //[length] => 10
        //[start_date] => 2021 / 07 / 04
        //[end_date] => 2021 / 08 / 02
        //[unit_id] => 
        //[subject] =>
        //[from] => 
        //[previous_sender] =>
        //[security_level] => 
        //[priority_level] =>
        //[daak_type] => 
        //}

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

                dakGrohonRequest.AddParameter("start_date",fromDate);
                dakGrohonRequest.AddParameter("end_date", toDate);
                dakGrohonRequest.AddParameter("unit_id", branchName);
                dakGrohonRequest.AddParameter("length", dakUserParam.limit);
                dakGrohonRequest.AddParameter("page", dakUserParam.page);



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

        public dakTrakingModel GetDakTrakingResponse(DakUserParam dakUserParam, string fromDate, string toDate, string mobile,string subject,string getapplication)
        {

            dakTrakingModel registerReportResponse = new dakTrakingModel();
            //if (!InternetConnection.Check())
            //{


            //    registerReportResponse = JsonConvert.DeserializeObject<RegisterReportResponse>(GetLocalDakRegisterBook(dakUserParam, fromDate, toDate, unitid, dnb, dnc, dnd));
            //    return registerReportResponse;

            //}

            try
            {
                var dakGrohonAPI = new RestClient(GetAPIDomain() + DefaultAPIConfiguration.DakSearchEndPoint);
                dakGrohonAPI.Timeout = -1;
                var dakGrohonRequest = new RestRequest(Method.POST);
                dakGrohonRequest.AddHeader("api-version", GetOldAPIVersion());
                dakGrohonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                dakGrohonRequest.AlwaysMultipartFormData = true;
                dakGrohonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                dakGrohonRequest.AddParameter("office_id", dakUserParam.office_id);
                dakGrohonRequest.AddParameter("user_id", dakUserParam.user_id);

                string searchParam = "dak_subject=" + subject + "&dak_received_no=" + getapplication + "&phone=" + mobile + "&last_modified_date =" + fromDate + ":" + toDate + "";

                dakGrohonRequest.AddParameter("search_params", searchParam);
                dakGrohonRequest.AddParameter("dak_list_type", "dak_tracking");
                dakGrohonRequest.AddParameter("length", dakUserParam.limit);
                dakGrohonRequest.AddParameter("page", dakUserParam.page);
               


                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
                //var data = SaveLocalDakRegisterBook(dakGrohonResponseJson, dakUserParam, fromDate, toDate, unitid, dnb, dnc, dnd);
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                registerReportResponse = JsonConvert.DeserializeObject<dakTrakingModel>(dakGrohonResponseJson);
                return registerReportResponse;
            }
            catch (Exception ex)
            {
                return registerReportResponse;
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
        protected string GetDakGrohonEndPoint()
        {
            return DefaultAPIConfiguration.DakGrohonEndPoint;
        }
        protected string GetDakBiliAddEndPoint()
        {
            return DefaultAPIConfiguration.DakBiliAddEndPoint;
        }
        protected string GetDakDiaryEndPoint()
        {
            return DefaultAPIConfiguration.DakDiaryEndPoint;
        }

     
    }

    public interface IRegisterService
    {
        RegisterReportResponse GetDakGrohonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        RegisterReportResponse GetDakBiliResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        RegisterReportResponse GetDakDiaryResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        dakTrakingModel GetDakTrakingResponse(DakUserParam dakUserParam, string fromDate, string toDate, string mobile, string subject, string application_no);
        

        }

}

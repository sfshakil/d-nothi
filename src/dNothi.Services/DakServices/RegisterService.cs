using dNothi.Constants;
using dNothi.JsonParser.Entity;
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
   public class RegisterService:IRegisterService
    {
        public RegisterReportResponse GetDakGrohonResponse(DakUserParam dakUserParam,string fromDate, string toDate, string branchName)
        {
            RegisterReportResponse registerReportResponse = new RegisterReportResponse();

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
                dakGrohonRequest.AddParameter("length", "10");
                dakGrohonRequest.AddParameter("page", "1");



                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
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

        public RegisterReportResponse GetDakBiliResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            RegisterReportResponse registerReportResponse = new RegisterReportResponse();

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
                dakGrohonRequest.AddParameter("length", "10");
                dakGrohonRequest.AddParameter("page", "1");



                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
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
            RegisterReportResponse registerReportResponse = new RegisterReportResponse();

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
                dakGrohonRequest.AddParameter("length", "10");
                dakGrohonRequest.AddParameter("page", "1");



                IRestResponse dakGrohonResponseIRest = dakGrohonAPI.Execute(dakGrohonRequest);




                var dakGrohonResponseJson = dakGrohonResponseIRest.Content;
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
    }

}

using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
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

namespace dNothi.Services.DakServices
{
  public class ProtibedonService:IProtibedonService
    {
        public ProtibedonResponse GetPendingProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            ProtibedonResponse pendingProtibedonResponse = new ProtibedonResponse();

            try
            {
                var pendingProtibedonAPI = new RestClient(GetAPIDomain() + GetPendingProtibedonEndPoint());
                pendingProtibedonAPI.Timeout = -1;
                var protibedonRequest = new RestRequest(Method.POST);
                protibedonRequest.AddHeader("api-version", GetOldAPIVersion());
                protibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                protibedonRequest.AlwaysMultipartFormData = true;
                protibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                protibedonRequest.AddParameter("office_id", dakUserParam.office_id);

                protibedonRequest.AddParameter("start_date", fromDate);
                protibedonRequest.AddParameter("end_date", toDate);
                protibedonRequest.AddParameter("unit_id", branchName);
                protibedonRequest.AddParameter("length", dakUserParam.limit);
                protibedonRequest.AddParameter("page", dakUserParam.page);


                IRestResponse pendingProtibedonResponseIRest = pendingProtibedonAPI.Execute(protibedonRequest);




                var pendingProtibedonResponseJson = ConversionMethod.FilterJsonResponse(pendingProtibedonResponseIRest.Content);



                pendingProtibedonResponse = JsonConvert.DeserializeObject<ProtibedonResponse>(pendingProtibedonResponseJson);
                return pendingProtibedonResponse;
            }
            catch (Exception ex)
            {
                return pendingProtibedonResponse;
            }


        }
        public ProtibedonResponse GetResolvedProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            ProtibedonResponse pendingProtibedonResponse = new ProtibedonResponse();

            try
            {
                var pendingProtibedonAPI = new RestClient(GetAPIDomain() + GetResolvesProtibedonEndPoint());
                pendingProtibedonAPI.Timeout = -1;
                var protibedonRequest = new RestRequest(Method.POST);
                protibedonRequest.AddHeader("api-version", GetOldAPIVersion());
                protibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                protibedonRequest.AlwaysMultipartFormData = true;
                protibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                protibedonRequest.AddParameter("office_id", dakUserParam.office_id);

                protibedonRequest.AddParameter("start_date", fromDate);
                protibedonRequest.AddParameter("end_date", toDate);
                protibedonRequest.AddParameter("unit_id", branchName);
                protibedonRequest.AddParameter("length", dakUserParam.limit);
                protibedonRequest.AddParameter("page", dakUserParam.page);


                IRestResponse pendingProtibedonResponseIRest = pendingProtibedonAPI.Execute(protibedonRequest);




                var pendingProtibedonResponseJson = ConversionMethod.FilterJsonResponse(pendingProtibedonResponseIRest.Content);



                pendingProtibedonResponse = JsonConvert.DeserializeObject<ProtibedonResponse>(pendingProtibedonResponseJson);
                return pendingProtibedonResponse;
            }
            catch (Exception ex)
            {
                return pendingProtibedonResponse;
            }


        }
        public DakProtibedonResponse GetNothijatoProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            DakProtibedonResponse protibedonResponse = new DakProtibedonResponse();

            try
            {
                var protibedonAPI = new RestClient(GetAPIDomain() + GetNothijatoProtibedonEndPoint());
                protibedonAPI.Timeout = -1;
                var protibedonRequest = new RestRequest(Method.POST);
                protibedonRequest.AddHeader("api-version", GetOldAPIVersion());
                protibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                protibedonRequest.AlwaysMultipartFormData = true;
                protibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                protibedonRequest.AddParameter("office_id", dakUserParam.office_id);

                //protibedonRequest.AddParameter("start_date", fromDate);
                //protibedonRequest.AddParameter("end_date", toDate);
                protibedonRequest.AddParameter("search_params", "last_modified_date="+ fromDate + ":"+ toDate + "");
                protibedonRequest.AddParameter("unit_id", branchName);
                protibedonRequest.AddParameter("length", dakUserParam.limit);
                protibedonRequest.AddParameter("page", dakUserParam.page);


                IRestResponse protibedonResponseIRest = protibedonAPI.Execute(protibedonRequest);

  
                var protibedonResponseJson = ConversionMethod.FilterJsonResponse(protibedonResponseIRest.Content);



                protibedonResponse = JsonConvert.DeserializeObject<DakProtibedonResponse>(protibedonResponseJson);
                return protibedonResponse;
            }
            catch (Exception ex)
            {
                return protibedonResponse;
            }


        }
        public DakProtibedonResponse GetNothiteUposthapitoProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            DakProtibedonResponse protibedonResponse = new DakProtibedonResponse();

            try
            {
                var protibedonAPI = new RestClient(GetAPIDomain() + GetNothiteUposthapitoProtibedonEndPoint());
                protibedonAPI.Timeout = -1;
                var protibedonRequest = new RestRequest(Method.POST);
                protibedonRequest.AddHeader("api-version", GetOldAPIVersion());
                protibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                protibedonRequest.AlwaysMultipartFormData = true;
                protibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                protibedonRequest.AddParameter("office_id", dakUserParam.office_id);

                protibedonRequest.AddParameter("start_date", fromDate);
                protibedonRequest.AddParameter("end_date", toDate);
                protibedonRequest.AddParameter("unit_id", branchName);
                protibedonRequest.AddParameter("length", dakUserParam.limit);
                protibedonRequest.AddParameter("page", dakUserParam.page);


                IRestResponse protibedonResponseIRest = protibedonAPI.Execute(protibedonRequest);




                var protibedonResponseJson = ConversionMethod.FilterJsonResponse(protibedonResponseIRest.Content);



                protibedonResponse = JsonConvert.DeserializeObject<DakProtibedonResponse>(protibedonResponseJson);
                return protibedonResponse;
            }
            catch (Exception ex)
            {
                return protibedonResponse;
            }


        }
        public DakProtibedonResponse GetPotrojariProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName)
        {
            DakProtibedonResponse protibedonResponse = new DakProtibedonResponse();

            try
            {
                var protibedonAPI = new RestClient(GetAPIDomain() + GetPotrojariProtibedonEndPoint());
                protibedonAPI.Timeout = -1;
                var protibedonRequest = new RestRequest(Method.POST);
                protibedonRequest.AddHeader("api-version", GetOldAPIVersion());
                protibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                protibedonRequest.AlwaysMultipartFormData = true;
                protibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                protibedonRequest.AddParameter("office_id", dakUserParam.office_id);

                protibedonRequest.AddParameter("start_date", fromDate);
                protibedonRequest.AddParameter("end_date", toDate);
                protibedonRequest.AddParameter("unit_id", branchName);
                protibedonRequest.AddParameter("length", dakUserParam.limit);
                protibedonRequest.AddParameter("page", dakUserParam.page);

                IRestResponse protibedonResponseIRest = protibedonAPI.Execute(protibedonRequest);




                var protibedonResponseJson = ConversionMethod.FilterJsonResponse(protibedonResponseIRest.Content);



                protibedonResponse = JsonConvert.DeserializeObject<DakProtibedonResponse>(protibedonResponseJson);
                return protibedonResponse;
            }
            catch (Exception ex)
            {
                return protibedonResponse;
            }

        }

        public DakReportModel GetProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string unitid,bool isPending, bool isResolved, bool isNothiteUposthapito, bool isPotrojari, bool isNothijato)
        {

            DakReportModel pendingProtibedonResponse = new DakReportModel();

            try
            {
                string endPoint = string.Empty;
                if (isPending)
                    endPoint = DefaultAPIConfiguration.PendingProtibedonEndPoint;
                if (isResolved)
                    endPoint = DefaultAPIConfiguration.ResolvesProtibedonEndPoint;
                if (isNothiteUposthapito)
                    endPoint = DefaultAPIConfiguration.NothiVoiktaEndPoint;
                if (isPotrojari)
                    endPoint = DefaultAPIConfiguration.PotrojariProtibedonEndPoint;
                if (isNothijato)
                    endPoint = DefaultAPIConfiguration.NothijatoProtibedonEndPoint;
                var pendingProtibedonAPI = new RestClient(GetAPIDomain() + endPoint);
                pendingProtibedonAPI.Timeout = -1;
                var protibedonRequest = new RestRequest(Method.POST);
                protibedonRequest.AddHeader("api-version", GetAPIVersion());
                protibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                protibedonRequest.AlwaysMultipartFormData = true;
                protibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                protibedonRequest.AddParameter("office_id", dakUserParam.office_id);
                protibedonRequest.AddParameter("search_params", "last_modified_date=" + fromDate + ":" + toDate + "");
                protibedonRequest.AddParameter("unit_id", unitid);
                protibedonRequest.AddParameter("length", dakUserParam.limit);
                protibedonRequest.AddParameter("page", dakUserParam.page);


                IRestResponse pendingProtibedonResponseIRest = pendingProtibedonAPI.Execute(protibedonRequest);

                var pendingProtibedonResponseJson = ConversionMethod.FilterJsonResponse(pendingProtibedonResponseIRest.Content);

                pendingProtibedonResponse = JsonConvert.DeserializeObject<DakReportModel>(pendingProtibedonResponseJson);
                return pendingProtibedonResponse;
            }
            catch (Exception ex)
            {
                return pendingProtibedonResponse;
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
        protected string GetNothijatoProtibedonEndPoint()
        {
            return DefaultAPIConfiguration.NothijatoProtibedonEndPoint;
        }
        protected string GetNothiteUposthapitoProtibedonEndPoint()
        {
            return DefaultAPIConfiguration.NothiteUposthapitoProtibedonEndPoint;
        }
        protected string GetPotrojariProtibedonEndPoint()
        {
            return DefaultAPIConfiguration.PotrojariProtibedonEndPoint;
        }
        protected string GetPendingProtibedonEndPoint()
        {
            return DefaultAPIConfiguration.PendingProtibedonEndPoint;
        }
        protected string GetResolvesProtibedonEndPoint()
        {
            return DefaultAPIConfiguration.ResolvesProtibedonEndPoint;
        }

       
    }
  public interface IProtibedonService
    {
        ProtibedonResponse GetResolvedProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        ProtibedonResponse GetPendingProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        DakProtibedonResponse GetPotrojariProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        DakProtibedonResponse GetNothiteUposthapitoProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        DakProtibedonResponse GetNothijatoProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string branchName);
        DakReportModel GetProtibedonResponse(DakUserParam dakUserParam, string fromDate, string toDate, string unitid, bool isPending, bool isResolved, bool isNothiteUposthapito, bool isPotrojari, bool isNothijato);

    }
}

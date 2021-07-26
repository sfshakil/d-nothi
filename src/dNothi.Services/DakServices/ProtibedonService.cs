using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
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
                var pendingProtibedonRequest = new RestRequest(Method.POST);
                pendingProtibedonRequest.AddHeader("api-version", GetOldAPIVersion());
                pendingProtibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                pendingProtibedonRequest.AlwaysMultipartFormData = true;
                pendingProtibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                pendingProtibedonRequest.AddParameter("office_id", dakUserParam.office_id);

                pendingProtibedonRequest.AddParameter("start_date", "2019-12-01");
                pendingProtibedonRequest.AddParameter("end_date", "2021-12-01");
                pendingProtibedonRequest.AddParameter("length", dakUserParam.limit);
                pendingProtibedonRequest.AddParameter("page", dakUserParam.page);


                IRestResponse pendingProtibedonResponseIRest = pendingProtibedonAPI.Execute(pendingProtibedonRequest);




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
                var pendingProtibedonRequest = new RestRequest(Method.POST);
                pendingProtibedonRequest.AddHeader("api-version", GetOldAPIVersion());
                pendingProtibedonRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                pendingProtibedonRequest.AlwaysMultipartFormData = true;
                pendingProtibedonRequest.AddParameter("designation_id", dakUserParam.designation_id);
                pendingProtibedonRequest.AddParameter("office_id", dakUserParam.office_id);

                pendingProtibedonRequest.AddParameter("start_date", "2020-12-01");
                pendingProtibedonRequest.AddParameter("end_date", "2021-12-01");
                pendingProtibedonRequest.AddParameter("length", "10");
                pendingProtibedonRequest.AddParameter("page", "1");


                IRestResponse pendingProtibedonResponseIRest = pendingProtibedonAPI.Execute(pendingProtibedonRequest);




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

                protibedonRequest.AddParameter("start_date", "2020-12-01");
                protibedonRequest.AddParameter("end_date", "2021-12-01");
                protibedonRequest.AddParameter("length", "10");
                protibedonRequest.AddParameter("page", "1");


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

                protibedonRequest.AddParameter("start_date", "2020-12-01");
                protibedonRequest.AddParameter("end_date", "2021-12-01");
                protibedonRequest.AddParameter("length", "10");
                protibedonRequest.AddParameter("page", "1");


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

                protibedonRequest.AddParameter("start_date", "2020-12-01");
                protibedonRequest.AddParameter("end_date", "2021-12-01");
                protibedonRequest.AddParameter("length", "10");
                protibedonRequest.AddParameter("page", "1");


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
    }
}

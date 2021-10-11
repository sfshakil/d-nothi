using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
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
       
        IRepository<DakProtibedan> _localDakProtibedanRepository;
        public ProtibedonService(IRepository<DakProtibedan> localDakProtibedanRepository)
        {
            _localDakProtibedanRepository = localDakProtibedanRepository;
        }
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
            string searchParam= "last_modified_date=" + fromDate + ":" + toDate + "";
            DakReportModel pendingProtibedonResponse = new DakReportModel();
            if(!InternetConnection.Check())
            {
                pendingProtibedonResponse = JsonConvert.DeserializeObject<DakReportModel>(GetLocalDakProtibedan(dakUserParam, searchParam, unitid, isPending, isResolved, isNothiteUposthapito, isPotrojari, isNothijato));
                return pendingProtibedonResponse;
            }

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
                protibedonRequest.AddParameter("search_params", searchParam);
                protibedonRequest.AddParameter("unit_id", unitid);
                protibedonRequest.AddParameter("length", dakUserParam.limit);
                protibedonRequest.AddParameter("page", dakUserParam.page);


                IRestResponse pendingProtibedonResponseIRest = pendingProtibedonAPI.Execute(protibedonRequest);

                var pendingProtibedonResponseJson = ConversionMethod.FilterJsonResponse(pendingProtibedonResponseIRest.Content);
                SaveLocalDakProtibedan(pendingProtibedonResponseJson, dakUserParam, searchParam, unitid, isPending, isResolved, isNothiteUposthapito, isPotrojari, isNothijato);
                pendingProtibedonResponse = JsonConvert.DeserializeObject<DakReportModel>(pendingProtibedonResponseJson);
                return pendingProtibedonResponse;
            }
            catch (Exception ex)
            {
                return pendingProtibedonResponse;
            }


        }
        private string GetLocalDakProtibedan(DakUserParam dakListUserParam, string searchparam, string unitid, bool isPending, bool isResolved, bool isNothiteUposthapito, bool isPotrojari, bool isNothijato)
        {
            var dakBox = _localDakProtibedanRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.search_params == searchparam && q.unitId == unitid && q.isPending == isPending && q.isResolved == isResolved && q.isNothiteUposthapito == isNothiteUposthapito && q.isNothijato == isNothijato && q.isPotrojari == isPotrojari).FirstOrDefault();

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
        private void SaveLocalDakProtibedan(string dakBoxResponseJson, DakUserParam dakListUserParam, string searchparam, string unitid, bool isPending, bool isResolved, bool isNothiteUposthapito, bool isPotrojari, bool isNothijato)
        {
            var dakBox = _localDakProtibedanRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.search_params == searchparam && q.unitId == unitid && q.isPending == isPending && q.isResolved == isResolved && q.isNothiteUposthapito == isNothiteUposthapito && q.isNothijato==isNothijato && q.isPotrojari==isPotrojari ).FirstOrDefault();

            if (dakBox != null)
            {
                dakBox.daklist_json = dakBoxResponseJson;
                _localDakProtibedanRepository.Update(dakBox);
            }
            else
            {
                DakProtibedan localDakProtibedan = new DakProtibedan
                {
                    designation_id = dakListUserParam.designation_id,
                    office_id = dakListUserParam.office_id,
                    daklist_json = dakBoxResponseJson,
                    page = dakListUserParam.page,
                    limit = dakListUserParam.limit,
                    unitId = unitid,
                     search_params=searchparam,
                      isPending=isPending, isResolved=isResolved, isNothiteUposthapito=isNothiteUposthapito, isNothijato=isNothijato, isPotrojari=isPotrojari
                };
                _localDakProtibedanRepository.Insert(localDakProtibedan);
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

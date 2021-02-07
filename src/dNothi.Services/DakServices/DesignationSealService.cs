﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DesignationSealService : IDesignationSealService
    {
        public DesignationSealListResponse GetOfficerAddedSealList(DakUserParam dakListUserParam)
        {
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
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DesignationSealListResponse designationSealResponse = JsonConvert.DeserializeObject<DesignationSealListResponse>(designationSealResponseJson);
                return designationSealResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetDesignationSealListEndpoint()
        {
            return DefaultAPIConfiguration.GetDesignationSealListEndpoint;
        }
        public AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam, int office_id)
        {
            var designationSealAPI = new RestClient(GetAPIDomain() + GetAllDesignationSealEndpoint());
            designationSealAPI.Timeout = -1;
            var designationSealRequest = new RestRequest(Method.POST);
            designationSealRequest.AddHeader("api-version", GetAPIVersion());
            designationSealRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);

            designationSealRequest.AddParameter("office_id", office_id);
            designationSealRequest.AddParameter("cdesk", dakListUserParam.json_String);
            IRestResponse designationSealIRestResponse = designationSealAPI.Execute(designationSealRequest);
            var designationSealResponseJson = designationSealIRestResponse.Content;
            AllDesignationSealListResponse designationSealListResponse = JsonConvert.DeserializeObject<AllDesignationSealListResponse>(designationSealResponseJson);
            return designationSealListResponse;
        }


        public OfficeListResponse GetAllOffice(DakUserParam dakListUserParam)
        {
            var dakOfficeAPI = new RestClient(GetAPIDomain() + GetOfficeListEndpoint());
            dakOfficeAPI.Timeout = -1;
            var dakOfficeRequest = new RestRequest(Method.POST);
            dakOfficeRequest.AddHeader("api-version", GetAPIVersion());
            dakOfficeRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            dakOfficeRequest.AddParameter("office_id", dakListUserParam.office_id);
            dakOfficeRequest.AddParameter("cdesk", dakListUserParam.json_String);

            IRestResponse dakOfficeIRestResponse = dakOfficeAPI.Execute(dakOfficeRequest);
            var dakOfficeResponseJson = dakOfficeIRestResponse.Content;
            OfficeListResponse officeListResponse = JsonConvert.DeserializeObject<OfficeListResponse>(dakOfficeResponseJson);
            return officeListResponse;
        }

        protected string GetAllDesignationSealEndpoint()
        {
            return DefaultAPIConfiguration.AllDesignationSealEndPoint;
        }
        protected string GetOfficeListEndpoint()
        {
            return DefaultAPIConfiguration.OfficeListEndpoint;
        }

        protected string GetAPIVersion()
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
    }
}
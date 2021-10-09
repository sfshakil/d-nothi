﻿using dNothi.Constants;
using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.ReportServices
{
    public class ReportService : IReportService
    {
        public ReportCategoryResponse GetReportCategoryList(DakUserParam userParam, string type)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetReportCategoryEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("type", type);

                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;

                ReportCategoryResponse reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryResponse>(responseJson);
                return reportCategoryResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
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
        protected string GetReportCategoryEndPoint()
        {
            return DefaultAPIConfiguration.ReportCategoryEndPoint;
        }

        public ReportCategorySerialUpdateResponse GetReportCategorySerialUpdate(DakUserParam userParam, string type, List<Category> updateCategories)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetReportCategoryEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("type", type);
                var serializedObject = JsonConvert.SerializeObject(updateCategories);
                request.AddParameter("serial_data", serializedObject);

                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;

                ReportCategorySerialUpdateResponse reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategorySerialUpdateResponse>(responseJson);
                return reportCategoryResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ReportCategoryAddResponse GetReportCategoryAdd(DakUserParam userParam, ReportCategoryAddData reportCategoryAddData)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetReportCategoryEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("type", reportCategoryAddData.type);

                if (reportCategoryAddData.category_id != null && reportCategoryAddData.category_id != "")
                {
                    request.AddParameter("category_id", reportCategoryAddData.category_id);
                }
                
                request.AddParameter("category_name", reportCategoryAddData.category_name);

                if ( reportCategoryAddData.serial >= 0 )
                {
                    request.AddParameter("serial", reportCategoryAddData.serial);
                }
                else
                {
                    request.AddParameter("serial", "");
                }
                
                request.AddParameter("offices", "");

                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;

                ReportCategoryAddResponse reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryAddResponse>(responseJson);
                return reportCategoryResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ReportCategoryDeleteResponse GetReportCategoryDelete(DakUserParam userParam, ReportCategoryAddData reportCategoryAddData)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetReportCategoryEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("type", reportCategoryAddData.type);

                if (reportCategoryAddData.category_id != null && reportCategoryAddData.category_id != "")
                {
                    request.AddParameter("category_id", reportCategoryAddData.category_id);
                }
                
                request.AddParameter("category_name", reportCategoryAddData.category_name);

                if ( reportCategoryAddData.serial >= 0 )
                {
                    request.AddParameter("serial", reportCategoryAddData.serial);
                }
                else
                {
                    request.AddParameter("serial", "");
                }
                
                request.AddParameter("offices", "");

                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;

                ReportCategoryDeleteResponse reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryDeleteResponse>(responseJson);
                return reportCategoryResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

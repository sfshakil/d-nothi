using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
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
        IRepository<ReportCategoryItem> _reportCategoryItem;
        IRepository<ReportCategoryAddItem> _reportCategoryAddItem;
        IUserService _userService { get; set; }
        public ReportService(IUserService userService, IRepository<ReportCategoryItem> reportCategoryItem, IRepository<ReportCategoryAddItem> reportCategoryAddItem)
        {
            _userService = userService;
            _reportCategoryItem = reportCategoryItem;
            _reportCategoryAddItem = reportCategoryAddItem;
        }
        public ReportCategoryResponse GetReportCategoryList(DakUserParam userParam, string type)
        {
            ReportCategoryResponse reportCategoryResponse = new ReportCategoryResponse();
            if (!InternetConnection.Check())
            {
                var reportCategoryItemList = _reportCategoryItem.Table.FirstOrDefault(a => a.type == type);

                if (reportCategoryItemList != null)
                {
                    reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryResponse>(reportCategoryItemList.jsonResponse);

                }
                return reportCategoryResponse;
            }
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
                SaveOrUpdateRecords(type, responseJson);
                reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryResponse>(responseJson);
                return reportCategoryResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveOrUpdateRecords(string type, string responseJson)
        {
            ReportCategoryItem ReportCategoryItemDB = _reportCategoryItem.Table.FirstOrDefault(a => a.type == type);

            if (ReportCategoryItemDB != null)
            {
                ReportCategoryItemDB.jsonResponse = responseJson;
                _reportCategoryItem.Update(ReportCategoryItemDB);
            }
            else
            {
                ReportCategoryItem reportCategoryItem = new ReportCategoryItem();
                reportCategoryItem.type = type;
                reportCategoryItem.jsonResponse = responseJson;
                _reportCategoryItem.Insert(reportCategoryItem);
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
            ReportCategoryAddResponse reportCategoryResponse = new ReportCategoryAddResponse();
            if (!InternetConnection.Check())
            {
                reportCategoryResponse.status = "success";
                reportCategoryResponse.message = "Local";

                ReportCategoryAddItem reportCategoryAddItem = new ReportCategoryAddItem();
                reportCategoryAddItem.type = reportCategoryAddData.type;
                reportCategoryAddItem.category_name = reportCategoryAddData.category_name;

                _reportCategoryAddItem.Insert(reportCategoryAddItem);

                return reportCategoryResponse;
            }
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

                reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryAddResponse>(responseJson);
                return reportCategoryResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool SendReportCategoryAddFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List<ReportCategoryAddItem> nothiTypeItemActions = _reportCategoryAddItem.Table.Where(a => a.type == "add").ToList();
            if (nothiTypeItemActions != null && nothiTypeItemActions.Count > 0)
            {
                foreach (ReportCategoryAddItem nothiTypeItemAction in nothiTypeItemActions)
                {
                    ReportCategoryAddData reportCategoryAddItem = new ReportCategoryAddData();
                    reportCategoryAddItem.type = nothiTypeItemAction.type;
                    reportCategoryAddItem.category_name = nothiTypeItemAction.category_name;

                    var dakForwardResponse = GetReportCategoryAdd(dakUserParam, reportCategoryAddItem);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))

                    {
                        _reportCategoryAddItem.Delete(nothiTypeItemAction);
                        isForwarded = true;

                    }
                }
            }


            return isForwarded;
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

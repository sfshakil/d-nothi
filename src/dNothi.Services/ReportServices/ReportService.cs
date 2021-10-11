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
        IRepository<ReportCategoryDeleteItem> _reportCategoryDeleteItem;
        IRepository<ReportCategorySerialUpdateItem> _reportCategorySerialUpdateItem;
        IUserService _userService { get; set; }
        public ReportService(IUserService userService, IRepository<ReportCategoryItem> reportCategoryItem, IRepository<ReportCategoryAddItem> reportCategoryAddItem,
            IRepository<ReportCategorySerialUpdateItem> reportCategorySerialUpdateItem, IRepository<ReportCategoryDeleteItem> reportCategoryDeleteItem)
        {
            _userService = userService;
            _reportCategoryItem = reportCategoryItem;
            _reportCategoryAddItem = reportCategoryAddItem;
            _reportCategoryDeleteItem = reportCategoryDeleteItem;
            _reportCategorySerialUpdateItem = reportCategorySerialUpdateItem;
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
            ReportCategorySerialUpdateResponse reportCategoryResponse = new ReportCategorySerialUpdateResponse();
            var serializedObject = JsonConvert.SerializeObject(updateCategories);
            if (!InternetConnection.Check())
            {
                reportCategoryResponse.status = "success";
                reportCategoryResponse.message = "Local";

                ReportCategorySerialUpdateItem reportCategorySerialUpdateItem = new ReportCategorySerialUpdateItem();
                reportCategorySerialUpdateItem.type = type;
                reportCategorySerialUpdateItem.json_serial_data = serializedObject;

                _reportCategorySerialUpdateItem.Insert(reportCategorySerialUpdateItem);

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

                request.AddParameter("serial_data", serializedObject);

                IRestResponse response = client.Execute(request);
                var responseJson = response.Content;

                reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategorySerialUpdateResponse>(responseJson);
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

                if (reportCategoryAddData.category_id == null || reportCategoryAddData.category_id == "")
                {
                    ReportCategoryAddItem reportCategoryAddItem = new ReportCategoryAddItem();
                    reportCategoryAddItem.type = reportCategoryAddData.type;
                    reportCategoryAddItem.category_name = reportCategoryAddData.category_name;

                    _reportCategoryAddItem.Insert(reportCategoryAddItem);
                }
                else if (reportCategoryAddData.category_id != null || reportCategoryAddData.category_id != "")
                {
                    ReportCategoryAddItem reportCategoryAddItem = new ReportCategoryAddItem();
                    reportCategoryAddItem.type = reportCategoryAddData.type;
                    reportCategoryAddItem.category_name = reportCategoryAddData.category_name;
                    reportCategoryAddItem.category_id = reportCategoryAddData.category_id;
                    reportCategoryAddItem.serial = reportCategoryAddData.serial.ToString();

                    _reportCategoryAddItem.Insert(reportCategoryAddItem);
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
                request.AddParameter("type", reportCategoryAddData.type);

                if (reportCategoryAddData.category_id != null || reportCategoryAddData.category_id != "")
                {
                    request.AddParameter("category_id", reportCategoryAddData.category_id);
                }

                request.AddParameter("category_name", reportCategoryAddData.category_name);

                if (reportCategoryAddData.serial >= 0)
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

                    if (nothiTypeItemAction.category_id != null || nothiTypeItemAction.category_id != "")
                    {
                        reportCategoryAddItem.category_id = nothiTypeItemAction.category_id;
                        reportCategoryAddItem.serial = Convert.ToInt32(nothiTypeItemAction.serial);
                    }

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

        public bool SendReportCategorySerialUpdateFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List<ReportCategorySerialUpdateItem> nothiTypeItemActions = _reportCategorySerialUpdateItem.Table.Where(a => a.type == "serial_update").ToList();
            if (nothiTypeItemActions != null && nothiTypeItemActions.Count > 0)
            {
                foreach (ReportCategorySerialUpdateItem nothiTypeItemAction in nothiTypeItemActions)
                {
                    List<Category> updateCategories = JsonConvert.DeserializeObject<List<Category>>(nothiTypeItemAction.json_serial_data);

                    var dakForwardResponse = GetReportCategorySerialUpdate(dakUserParam, nothiTypeItemAction.type, updateCategories);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))
                    {
                        _reportCategorySerialUpdateItem.Delete(nothiTypeItemAction);
                        isForwarded = true;
                    }
                }
            }
            return isForwarded;
        }
        public ReportCategoryDeleteResponse GetReportCategoryDelete(DakUserParam userParam, ReportCategoryAddData reportCategoryAddData)
        {
            ReportCategoryDeleteResponse reportCategoryResponse = new ReportCategoryDeleteResponse();

            if (!InternetConnection.Check())
            {
                reportCategoryResponse.status = "success";
                reportCategoryResponse.message = "Local";

                ReportCategoryDeleteItem reportCategoryAddItem = new ReportCategoryDeleteItem();
                reportCategoryAddItem.type = reportCategoryAddData.type;
                reportCategoryAddItem.category_name = reportCategoryAddData.category_name;
                reportCategoryAddItem.category_id = reportCategoryAddData.category_id;
                reportCategoryAddItem.serial = reportCategoryAddData.serial.ToString();

                _reportCategoryDeleteItem.Insert(reportCategoryAddItem);


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

                if (reportCategoryAddData.serial >= 0)
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

                reportCategoryResponse = JsonConvert.DeserializeObject<ReportCategoryDeleteResponse>(responseJson);
                return reportCategoryResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool SendReportCategoryDeleteFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List<ReportCategoryDeleteItem> nothiTypeItemActions = _reportCategoryDeleteItem.Table.Where(a => a.type == "delete").ToList();
            if (nothiTypeItemActions != null && nothiTypeItemActions.Count > 0)
            {
                foreach (ReportCategoryDeleteItem nothiTypeItemAction in nothiTypeItemActions)
                {
                    ReportCategoryAddData reportCategoryAddItem = new ReportCategoryAddData();
                    reportCategoryAddItem.type = nothiTypeItemAction.type;
                    reportCategoryAddItem.category_name = nothiTypeItemAction.category_name;

                    reportCategoryAddItem.category_id = nothiTypeItemAction.category_id;
                    reportCategoryAddItem.serial = Convert.ToInt32(nothiTypeItemAction.serial);

                    var dakForwardResponse = GetReportCategoryDelete(dakUserParam, reportCategoryAddItem);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))

                    {
                        _reportCategoryDeleteItem.Delete(nothiTypeItemAction);
                        isForwarded = true;

                    }
                }
            }


            return isForwarded;
        }
    }
}

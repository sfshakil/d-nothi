

using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Services.DakServices;
using dNothi.Services.ReportPermited.Model;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.ReportPermited
{
    public class ReportPermissionServices : IReportPermissionServices
    {
        //ReportPermission
        IRepository<ReportPermission> _localReportPermissionRepository;
        public ReportPermissionServices(IRepository<ReportPermission> localReportPermissionRepository)
        {
            _localReportPermissionRepository = localReportPermissionRepository;
        }
        public ReportPermissionModel ReportPermission(DakUserParam userParam, string type, string userid)
        {
            ReportPermissionModel reportPermissionModel = new ReportPermissionModel();
            if (!InternetConnection.Check())
            {
                if (type != "list")
                {
                    reportPermissionModel = AddDeleteLocalReportPermission(userid, type);
                }
                else
                {
                    reportPermissionModel = JsonConvert.DeserializeObject<ReportPermissionModel>(GetLocalReportPermission(userid, type));
                    var userslist = JsonConvert.DeserializeObject<List<ReportPermissionModel.User>>(reportPermissionModel.data.ToString());
                    var localuser = _localReportPermissionRepository.Table.Where(x => x.type != type).ToList();
                    foreach (var item in localuser)
                    {
                        if (item.isAdd == true && item.type=="add")
                        {
                            ReportPermissionModel.User user = new ReportPermissionModel.User { 
                                username = item.user, 
                                created = ConversionMethod.EngDigittoBanDigit(DateTime.Now.ToString("dd/MM/yy hh:mm tt")) };
                            userslist.Add(user);
                            
                            //_localReportPermissionRepository.Delete(item);
                        }
                        else
                        {
                            
                                var data = userslist.Where(x => x.username == item.user).FirstOrDefault();
                                if (data != null)
                                {
                                    userslist.Remove(userslist.FirstOrDefault(t => t.id == data.id));

                                }
                            
                            //_localReportPermissionRepository.Delete(item);
                        }

                    }
                    reportPermissionModel.data = JsonConvert.SerializeObject(userslist);
                }
                return reportPermissionModel;
            }
            else
            {
                return GetServerResponse(userParam, userid, type);
            }
           
        }
        private ReportPermissionModel GetServerResponse(DakUserParam userParam,string userid,string type)
        {
            ReportPermissionModel reportPermissionModel = new ReportPermissionModel();
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + DefaultAPIConfiguration.ReportPermitUserEndpoint);
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                // request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("type", type);

                request.AddParameter("user", userid);

                IRestResponse Response = Api.Execute(request);
                var responseJson = Response.Content;
                if (type == "list")
                {
                    SaveLocalReportPermission(responseJson, userid, type);
                }
                reportPermissionModel = JsonConvert.DeserializeObject<ReportPermissionModel>(responseJson);
                return reportPermissionModel;
            }
            catch (Exception ex)
            {
                return reportPermissionModel;
            }
        }
        private ReportPermissionModel AddDeleteLocalReportPermission(string userid,string type)
        {
            object data = string.Empty;
            var userData = _localReportPermissionRepository.Table.Where(x => x.user == userid).FirstOrDefault();
            if (userData != null)
            {
                userData.isAdd = false;
                _localReportPermissionRepository.Update(userData);
            }
            else
            {
                ReportPermission localReportPermissionInsert = new ReportPermission
                {
                    type = type,
                    isAdd = true,
                    user = userid
                };
                _localReportPermissionRepository.Insert(localReportPermissionInsert);
            }
           
            if(type=="add")
            {
                ReportPermissionModel.User user = new ReportPermissionModel.User { type=type, user= userid, username= userid };
                data = JsonConvert.SerializeObject(user);
            }
            else
            {
                data = "Deleted Successfully";
            }
           
            return new ReportPermissionModel { status = "success",data=data, message="Success" };
        }
        private string GetLocalReportPermission(string userid, string type)
        {
            var userdata = _localReportPermissionRepository.Table.Where(q => q.user== userid && q.type==type).FirstOrDefault();

            if (userdata != null)
            {
                return userdata.responseJson;
            }
            else
            {
                string data = "{\"status\":\"success\",\"data\":{\"records\":[],\"total_records\":0},\"options\":[]}";
                return data;
            }

        }
        private void SaveLocalReportPermission(string responseData,string userid, string type)
        {
            var userdata = _localReportPermissionRepository.Table.Where(q => q.user == userid && q.type == type).FirstOrDefault();

            if (userdata != null)
            {
                userdata.responseJson = responseData;
                _localReportPermissionRepository.Update(userdata);
            }
            else
            {
                ReportPermission localReportPermission = new ReportPermission
                {
                    type=type,
                     user=userid,
                      responseJson=responseData
                };
                _localReportPermissionRepository.Insert(localReportPermission);
            }

        }
        public bool SendLocalReportPermissionDataTOServer(DakUserParam userParam)
        {
            var localuser = _localReportPermissionRepository.Table.Where(x => x.type != "list").ToList();
            foreach(var item in localuser)
            {
                if (item.isAdd == true)
                {
                    var response = GetServerResponse(userParam, item.user, item.type);
                }

                _localReportPermissionRepository.Delete(item);
              
            }
            return true;
        }
    }
    public interface IReportPermissionServices
    {
        ReportPermissionModel ReportPermission(DakUserParam userParam, string type, string userid);
        bool SendLocalReportPermissionDataTOServer(DakUserParam userParam);

    }
}

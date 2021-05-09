using dNothi.Core.Entities;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices.DakSharingService.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static dNothi.Constants.DefaultAPIConfiguration;

namespace dNothi.Services.DakServices.DakSharingService
{
    public class DakSharingService<T> : IDakSharingService<T> where T : class
    {
        public ResponseModel Add(DakUserParam userParam,PrapokDTO assignee)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(3));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("assignor", "{\"office_id\":"+ userParam.office_id + ",\"office_name\":\""+userParam.office+"\",\"office_unit_id\":\""+userParam.office_unit_id+"\",\"office_unit_name\":\""+userParam.office_unit+"\",\"designation_id\":"+userParam.designation_id+",\"designation_level\":\""+userParam.designation_level+"\",\"name\":\""+userParam.officer_name+"\"}");
                request.AddParameter("assignee", "[{\"office_id\":" + assignee.office_id + ",\"office_name\":\""+assignee.office+"\",\"office_unit_id\":\""+assignee.office_unit_id+"\",\"office_unit_name\":\""+assignee.office_unit+"\",\"designation_id\":"+assignee.designation_id+",\"designation_level\":\""+assignee.designation_level+"\",\"name\":\""+assignee.officer_name+"\"}]");

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel Delete(DakUserParam userParam, int assignee_designation_id)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(4));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("assignee_designation_id", assignee_designation_id);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetList(DakUserParam userParam, int actionLink,int assignor_designation_id)
        {
            try
            {
               
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);


                request.AddHeader("Authorization", "Bearer " + userParam.token);

                request.AlwaysMultipartFormData = true;

                request.AddParameter("designation_id", userParam.designation_id);

                request.AddParameter("office_id", userParam.office_id);
                if (actionLink == 2)
                {
                    request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                    request.AddParameter("assignor_designation_id", assignor_designation_id);
                    request.AddParameter("page", userParam.page);
                    request.AddParameter("limit", userParam.limit);

                }
                else
                {
                    request.AddHeader("api-version", CommonSetting.GetAPIVersion());

                    if (assignor_designation_id == 1)
                    {
                        request.AddParameter("assignee_designation_id", userParam.designation_id);

                    }
                    else
                    {
                        request.AddParameter("assignor_designation_id", userParam.designation_id);
                    }

                }

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                T responseData = JsonConvert.DeserializeObject<T>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}



using dNothi.Constants;
using dNothi.Services.DakServices;
using dNothi.Services.ReportPermited.Model;
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
       
       public ReportPermissionModel ReportPermission(DakUserParam userParam, string type, string userid)
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

                reportPermissionModel = JsonConvert.DeserializeObject<ReportPermissionModel>(responseJson);
                return reportPermissionModel;
            }
            catch (Exception ex)
            {
              return  reportPermissionModel;
            }
        }
    }
    public interface IReportPermissionServices
    {
        ReportPermissionModel ReportPermission(DakUserParam userParam, string type, string userid);

    }
}

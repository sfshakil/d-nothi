using dNothi.Constants;
using dNothi.Services.DakServices;
using dNothi.Services.NothiReportService.Model;
using dNothi.Services.PotroJariGroup;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiReportService
{
    public class NothiReportService : INothiReportService
    {
        public NothiRegisterReport NothiRegisterBook(DakUserParam userParam)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + DefaultAPIConfiguration.NothiAllListEndPoint);
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\"}");
                request.AddParameter("page", userParam.page);
                request.AddParameter("limit",userParam.limit);
               
                IRestResponse Response = Api.Execute(request);
                var responseJson = Response.Content;

                NothiRegisterReport nothiRegisterReport = JsonConvert.DeserializeObject<NothiRegisterReport>(responseJson);
                return nothiRegisterReport;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

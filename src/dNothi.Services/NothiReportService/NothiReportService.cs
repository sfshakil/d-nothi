using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Services.DakServices;
using dNothi.Services.NothiReportService.Model;
using dNothi.Services.PotroJariGroup;
using dNothi.Utility;
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
        IRepository<NothiRegisterBook> _localNothiRegisterBookRepository;
        public NothiReportService(IRepository<NothiRegisterBook> localNothiRegisterBookRepository)
        {
            _localNothiRegisterBookRepository = localNothiRegisterBookRepository;
        }
        public NothiRegisterReport NothiRegisterBook(DakUserParam userParam, string fromDate, string toDate, string branchName,  bool isNothiPreron, bool isNothiGrahon, bool isNothiReigister, bool isPotrajaribohi)
        {
            string endPoint = string.Empty;
            if (isNothiPreron)
            {
                endPoint = DefaultAPIConfiguration.NothiOutboxListEndPoint;
            }
            if (isNothiGrahon)
            {
                endPoint = DefaultAPIConfiguration.NothiListInboxEndPoint;
            }
            if (isNothiReigister)
            {
                endPoint = DefaultAPIConfiguration.NothiAllListEndPoint;
            }
            if(isPotrajaribohi)
            {
                endPoint = DefaultAPIConfiguration.NothiPotrangshoNotePotrojariEndPoint;
            }


            int unitid = 0;
            bool nrb = true; //nothi register book
            bool dnc = false;
            bool dnd = false;
            if(branchName!=null)
            {
                unitid = Convert.ToInt32(branchName);
            }
            NothiRegisterReport nothiRegisterReport = new NothiRegisterReport();
            if (!InternetConnection.Check())
            {
                if (isNothiReigister)
                {
                    nothiRegisterReport = JsonConvert.DeserializeObject<NothiRegisterReport>(GetLocalNothiRegisterBook(userParam, fromDate, toDate, unitid, nrb, dnc, dnd));
                    return nothiRegisterReport;
                }
                return nothiRegisterReport;
            }
            try
            {  
                var Api = new RestClient(CommonSetting.GetAPIDomain() + endPoint);
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\"}");
                request.AddParameter("page", userParam.page);
                request.AddParameter("length", userParam.limit);
                string search_params = string.Empty;
                
                if (isPotrajaribohi)
                {
                    request.AddParameter("unit_id", unitid);
                    search_params = "last_issue_date=" + fromDate + ":" + toDate + "&potro_subject=";
                }
                else
                {
                    search_params = "office_unit_id=" + unitid + "&last_modified_date=" + fromDate + ":" + toDate + "";
                }
              
                request.AddParameter("search_params", search_params);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;
                if (isNothiReigister)
                {
                    SaveLocalNothiRegisterBook(responseJson, userParam, fromDate, toDate, unitid, nrb, dnc, dnd);
                }
                 nothiRegisterReport = JsonConvert.DeserializeObject<NothiRegisterReport>(responseJson);
                return nothiRegisterReport;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
        private string GetLocalNothiRegisterBook(DakUserParam dakListUserParam, string fromDate, string toDate, int unitid, bool nrb, bool dnc, bool dnd)
        {
            var dakBox = _localNothiRegisterBookRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.fromDate == fromDate && q.toDate == toDate && q.unitId == unitid && q.dnd == dnd && q.dnc == q.dnc && q.nrb == q.nrb).FirstOrDefault();

            if (dakBox != null)
            {
                return dakBox.daklist_json;
            }
            else
            {
                return "";
            }

        }
        private void SaveLocalNothiRegisterBook(string dakBoxResponseJson, DakUserParam dakListUserParam, string fromDate, string toDate, int unitid, bool nrb, bool dnc, bool dnd)
        {
            var dakBox = _localNothiRegisterBookRepository.Table.Where(q => q.designation_id == dakListUserParam.designation_id && q.office_id == dakListUserParam.office_id && q.limit == dakListUserParam.limit && q.page == dakListUserParam.page && q.fromDate == fromDate && q.toDate == toDate && q.unitId==unitid && q.dnd == dnd && q.dnc == q.dnc && q.nrb == q.nrb).FirstOrDefault();

            if (dakBox != null)
            {
                dakBox.daklist_json = dakBoxResponseJson;
                _localNothiRegisterBookRepository.Update(dakBox);
            }
            else
            {
                NothiRegisterBook localnothiRegisterBook = new NothiRegisterBook
                {
                    designation_id = dakListUserParam.designation_id,
                    office_id = dakListUserParam.office_id,
                    daklist_json = dakBoxResponseJson,
                    page = dakListUserParam.page,
                    limit = dakListUserParam.limit,
                    unitId = unitid,
                    nrb = nrb,
                    dnc = dnc,
                    dnd = dnd,
                    fromDate = fromDate,
                    toDate = toDate,
                };
                _localNothiRegisterBookRepository.Insert(localnothiRegisterBook);
            }
           
        }

    }
}

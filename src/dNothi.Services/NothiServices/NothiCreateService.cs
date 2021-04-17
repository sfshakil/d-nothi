using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Nothi;
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

namespace dNothi.Services.NothiServices
{
    public class NothiCreateService : INothiCreateService
    {
        IRepository<NothiCreateItemAction> _nothiCreateItemAction;
        IRepository<NoteSaveItemAction> _noteSaveItemAction;
        IUserService _userService { get; set; }
        public NothiCreateService(IUserService userService, IRepository<NothiCreateItemAction> nothiCreateItemAction, IRepository<NoteSaveItemAction> noteSaveItemAction)
        {
            _userService = userService;
            _nothiCreateItemAction = nothiCreateItemAction;
            _noteSaveItemAction = noteSaveItemAction;
        }
        public NothiCreateResponse GetNothiCreate(DakUserParam UserParam, string nothishkha, string nothi_no, string nothi_type_id, string nothi_subject, string nothi_class, string currentYear)
        {
            NothiCreateResponse nothiCreateResponse = new NothiCreateResponse();

            if (!InternetConnection.Check())
            {
                nothiCreateResponse.status = "success";
                nothiCreateResponse.message = "Local";

                NothiCreateItemAction nothiCreateItemAction; //= _nothiCreateItemAction.Table.FirstOrDefault(a => a. == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                nothiCreateItemAction = new NothiCreateItemAction();
                nothiCreateItemAction.designation_id = UserParam.designation_id;
                nothiCreateItemAction.office_id = UserParam.office_id;
                nothiCreateItemAction.officer_name = UserParam.officer_name;
                nothiCreateItemAction.office_unit_id = UserParam.office_unit_id;
                nothiCreateItemAction.designation = UserParam.designation;

                nothiCreateItemAction.office_unit_name = UserParam.office_unit;
                nothiCreateItemAction.office_label = UserParam.office_label;


                nothiCreateItemAction.nothishkha = nothishkha;
                nothiCreateItemAction.nothi_no = nothi_no;
                nothiCreateItemAction.nothi_type_id = nothi_type_id;
                nothiCreateItemAction.nothi_subject = nothi_subject;
                nothiCreateItemAction.nothi_class = nothi_class;
                nothiCreateItemAction.currentYear = currentYear;

                _nothiCreateItemAction.Insert(nothiCreateItemAction);

                return nothiCreateResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiCreateEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + UserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", +UserParam.office_id);
                request.AddParameter("designation_id", +UserParam.designation_id);
                request.AddParameter("model", "NothiMasters");
                request.AddParameter("data", "{\"id\":\"0\",\"office_id\":\"" + UserParam.office_id + "\",\"office_name\":\"" + UserParam.officer_name + "\",\"office_unit_id\":\"" + UserParam.office_unit_id + "\",\"office_unit_name\":\"" + nothishkha + "\",\"office_unit_organogram_id\":\"" + UserParam.designation_id + "\",\"office_designation_name\":\"" + UserParam.designation + "\",\"nothi_type_id\":\"" + nothi_type_id + "\",\"nothi_no\":\"" + nothi_no + "\",\"subject\":\"" + nothi_subject + "\",\"description\":\"NULL\",\"nothi_class\":\"" + nothi_class + "\",\"nothi_created_date\":\"" + currentYear + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                nothiCreateResponse = JsonConvert.DeserializeObject<NothiCreateResponse>(responseJson);
                return nothiCreateResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool SendNothiCreateListFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List<NothiCreateItemAction> nothiCreateItemActions = _nothiCreateItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
            if (nothiCreateItemActions != null && nothiCreateItemActions.Count > 0)
            {
                foreach (NothiCreateItemAction nothiCreateItemAction in nothiCreateItemActions)
                {
                    DakUserParam userParam = new DakUserParam();
                    userParam.designation_id = nothiCreateItemAction.designation_id;
                    userParam.office_id = nothiCreateItemAction.office_id;
                    userParam.officer_name = nothiCreateItemAction.officer_name;
                    userParam.unit_id = nothiCreateItemAction.office_unit_id;
                    userParam.designation_label = nothiCreateItemAction.designation;
                    userParam.token = dakUserParam.token;
                    var nothiCreateResponse = GetNothiCreate(userParam, nothiCreateItemAction.nothishkha, nothiCreateItemAction.nothi_no, nothiCreateItemAction.nothi_type_id, nothiCreateItemAction.nothi_subject, nothiCreateItemAction.nothi_class, nothiCreateItemAction.currentYear);

                    if (nothiCreateResponse != null && (nothiCreateResponse.status == "error" || nothiCreateResponse.status == "success"))
                    {
                        List<NoteSaveItemAction> noteSaveItemActions = _noteSaveItemAction.Table.Where(a => a.nothi_id == nothiCreateItemAction.Id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();

                        if (nothiCreateResponse.status == "success")
                        {
                            if (noteSaveItemActions != null && noteSaveItemActions.Count > 0)
                            {
                                foreach (NoteSaveItemAction noteSaveItemAction in noteSaveItemActions)
                                {
                                    //NoteItem noteItemDB = _noteItem.Table.FirstOrDefault(a => a.nothi_id == nothi_Id && a.note_category == note_category && a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id);

                                    //if (noteItemDB != null)
                                    //{
                                    //    noteItemDB.jsonResponse = responseJson;
                                    //    _noteItem.Update(noteItemDB);
                                    //}
                                    noteSaveItemAction.nothi_id = nothiCreateResponse.data.id;
                                    noteSaveItemAction.office_name = nothiCreateResponse.data.office_name;
                                    noteSaveItemAction.office_unit_name = nothiCreateResponse.data.office_unit_name;
                                    _noteSaveItemAction.Update(noteSaveItemAction);
                                }
                            }
                        }
                        else
                        {
                            if (noteSaveItemActions != null && noteSaveItemActions.Count > 0)
                            {
                                foreach (NoteSaveItemAction noteSaveItemAction in noteSaveItemActions)
                                {
                                    _noteSaveItemAction.Delete(noteSaveItemAction);
                                }
                            }
                        }
                        
                        _nothiCreateItemAction.Delete(nothiCreateItemAction);
                        isForwarded = true;

                    }
                }
            }


            return isForwarded;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        protected string GetNothiCreateEndPoint()
        {
            return DefaultAPIConfiguration.NothiCreateEndPoint;
        }

    }
}

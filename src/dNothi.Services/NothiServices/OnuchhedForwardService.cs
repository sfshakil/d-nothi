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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class OnuchhedForwardService : IOnuchhedForwardService
    {
        IRepository<NoteSendItemAction> _noteSendItemAction;
        IUserService _userService { get; set; }
        public OnuchhedForwardService(IUserService userService, IRepository<NoteSendItemAction> noteSendItemAction)
        {
            _userService = userService;
            _noteSendItemAction = noteSendItemAction;
        }
        public OnuchhedForwardResponse GetOnuchhedForwardResponse(DakUserParam dakUserParam, NoteSaveDTO newnotedata, NothiListRecordsDTO nothiListRecord, List<onumodonDataRecordDTO> newrecords)
        {
            OnuchhedForwardResponse onuchhedForwardResponse = new OnuchhedForwardResponse();
            
            if (!InternetConnection.Check())
            {
                onuchhedForwardResponse.status = "success";
                onuchhedForwardResponse.message = "Local";

                string dakUserParamJson = JsonConvert.SerializeObject(dakUserParam);

                NoteSendItemAction noteSendItemAction = new NoteSendItemAction();
                noteSendItemAction.office_id = dakUserParam.office_id;
                noteSendItemAction.designation_id = dakUserParam.designation_id;
                noteSendItemAction.note_no = newnotedata.note_no;
                noteSendItemAction.note_subject = newnotedata.note_subject;
                noteSendItemAction.note_id = newnotedata.note_id;
                noteSendItemAction.office_unit_name = nothiListRecord.office_unit_name;
                noteSendItemAction.nothi_no = nothiListRecord.nothi_no;
                noteSendItemAction.nothi_id = nothiListRecord.id;
                noteSendItemAction.office_name = nothiListRecord.office_name;
                noteSendItemAction.local_nothi_type = nothiListRecord.local_nothi_type;
                noteSendItemAction.nothi_office = newrecords[0].nothi_office;
                noteSendItemAction.office = newrecords[0].office;
                noteSendItemAction.office_unit_id = newrecords[0].office_unit_id;
                noteSendItemAction.office_unit = newrecords[0].office_unit;
                noteSendItemAction.designation = newrecords[0].designation;
                noteSendItemAction.officer_id = newrecords[0].officer_id;
                noteSendItemAction.officer = newrecords[0].officer;
                noteSendItemAction.designation_level = newrecords[0].designation_level;
                noteSendItemAction.dakUserParamJson = dakUserParamJson;

                _noteSendItemAction.Insert(noteSendItemAction);

                return onuchhedForwardResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedSendEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;

                
                var serializedObject = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject);

                request.AddParameter("onucched", "{\"note_no\":\""+newnotedata.note_no+"\",\"note_subject\":\""+newnotedata.note_subject+"\",\"nothi_unit\":\""+nothiListRecord.office_unit_name+"\",\"nothi_no\":\""+nothiListRecord.nothi_no+"\",\"nothi_id\":\""+nothiListRecord.id+"\",\"nothi_office\":\""+nothiListRecord.office_id+"\",\"nothi_office_name\":\""+nothiListRecord.office_name+"\",\"note_id\":\""+newnotedata.note_id+"\",\"priority\":\""+ nothiListRecord.priority + "\"}");

                request.AddParameter("recipient", "{\"office_id\":\"" + newrecords[0].nothi_office + "\",\"office\":\"" + newrecords[0].office + "\",\"office_unit_id\":\"" + newrecords[0].office_unit_id + "\",\"office_unit\":\"" + newrecords[0].office_unit + "\",\"designation_id\":\"" + newrecords[0].designation_id + "\",\"designation\":\"" + newrecords[0].designation + "\",\"officer_id\":\"" + newrecords[0].officer_id + "\",\"officer\":\"" + newrecords[0].officer + "\",\"designation_level\":\"" + newrecords[0].designation_level + "\"}");

                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);



                var responseJson = response.Content;
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                onuchhedForwardResponse = JsonConvert.DeserializeObject<OnuchhedForwardResponse>(responseJson);
                return onuchhedForwardResponse;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public OnuchhedForwardResponse GetOnuchhedForwardResponseLocal(string token, string dakUserParam, NoteSaveDTO newnotedata, NothiListRecordsDTO nothiListRecord, onumodonDataRecordDTO newrecords)
        {
            OnuchhedForwardResponse onuchhedForwardResponse = new OnuchhedForwardResponse();

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedSendEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("cdesk", dakUserParam);

                request.AddParameter("onucched", "{\"note_no\":\"" + newnotedata.note_no + "\",\"note_subject\":\"" + newnotedata.note_subject + "\",\"nothi_unit\":\"" + nothiListRecord.office_unit_name + "\",\"nothi_no\":\"" + nothiListRecord.nothi_no + "\",\"nothi_id\":\"" + nothiListRecord.id + "\",\"nothi_office\":\"" + nothiListRecord.office_id + "\",\"nothi_office_name\":\"" + nothiListRecord.office_name + "\",\"note_id\":\"" + newnotedata.note_id + "\",\"priority\":\"0\"}");
                request.AddParameter("recipient", "{\"office_id\":\"" + newrecords.nothi_office + "\",\"office\":\"" + newrecords.office + "\",\"office_unit_id\":\"" + newrecords.office_unit_id + "\",\"office_unit\":\"" + newrecords.office_unit + "\",\"designation_id\":\"" + newrecords.designation_id + "\",\"designation\":\"" + newrecords.designation + "\",\"officer_id\":\"" + newrecords.officer_id + "\",\"officer\":\"" + newrecords.officer + "\",\"designation_level\":\"" + newrecords.designation_level + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                responseJson = System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                onuchhedForwardResponse = JsonConvert.DeserializeObject<OnuchhedForwardResponse>(responseJson);
                return onuchhedForwardResponse;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool SendNoteListFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List<NoteSendItemAction> noteSendItemActions = _noteSendItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
            if (noteSendItemActions != null && noteSendItemActions.Count > 0)
            {
                foreach (NoteSendItemAction noteSendItemAction in noteSendItemActions)
                {
                    NoteSaveDTO newnotedata = new NoteSaveDTO();
                    newnotedata.note_no = noteSendItemAction.note_no;
                    newnotedata.note_subject = noteSendItemAction.note_subject;
                    newnotedata.note_id = noteSendItemAction.note_id;

                    NothiListRecordsDTO nothiListRecord = new NothiListRecordsDTO();
                    nothiListRecord.office_unit_name = noteSendItemAction.office_unit_name;
                    nothiListRecord.nothi_no = noteSendItemAction.nothi_no;
                    nothiListRecord.id = noteSendItemAction.nothi_id;
                    nothiListRecord.office_id = noteSendItemAction.office_id;
                    nothiListRecord.office_name = noteSendItemAction.office_name;

                    onumodonDataRecordDTO onumodonDataRecord = new onumodonDataRecordDTO();
                    onumodonDataRecord.nothi_office = noteSendItemAction.nothi_office;
                    onumodonDataRecord.office = noteSendItemAction.office;
                    onumodonDataRecord.office_unit_id = noteSendItemAction.office_unit_id;
                    onumodonDataRecord.office_unit = noteSendItemAction.office_unit;
                    onumodonDataRecord.designation = noteSendItemAction.designation;
                    onumodonDataRecord.officer_id = noteSendItemAction.officer_id;
                    onumodonDataRecord.officer = noteSendItemAction.officer;
                    onumodonDataRecord.designation_level = noteSendItemAction.designation_level;
                    onumodonDataRecord.designation_id = noteSendItemAction.designation_id;

                    var noteSaveResponse = GetOnuchhedForwardResponseLocal(dakUserParam.token, noteSendItemAction.dakUserParamJson, newnotedata, nothiListRecord, onumodonDataRecord);

                    if (noteSaveResponse != null && (noteSaveResponse.status == "error" || noteSaveResponse.status == "success"))

                    {
                        _noteSendItemAction.Delete(noteSendItemAction);
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
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetNoteOnuchhedSendEndPoint()
        {
            return DefaultAPIConfiguration.NoteOnuchhedSendEndPoint;
        }
    }
}

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
    public class NoteSaveService : INoteSaveService
    {
        IRepository<NoteSaveItemAction> _noteSaveItemAction;
        IRepository<OnuchhedSaveItemAction> _onuchhedSaveItemAction;
        IUserService _userService { get; set; }
        public NoteSaveService(IUserService userService, IRepository<NoteSaveItemAction> noteSaveItemAction,
            IRepository<OnuchhedSaveItemAction> onuchhedSaveItemAction)
        {
            _userService = userService;
            _noteSaveItemAction = noteSaveItemAction;
            _onuchhedSaveItemAction = onuchhedSaveItemAction;
        }
        public NoteSaveResponse GetNoteSave(DakUserParam dakUserParam, NothiListRecordsDTO nothiListRecordsDTO, string noteSubject)
        {
            NoteSaveResponse noteSaveResponse = new NoteSaveResponse();

            if (!InternetConnection.Check())
            {
                noteSaveResponse.status = "success";
                noteSaveResponse.message = "Local";

                NoteSaveItemAction noteSaveItemAction = new NoteSaveItemAction();
                noteSaveItemAction.office_id = dakUserParam.office_id;
                noteSaveItemAction.designation_id = dakUserParam.designation_id;
                noteSaveItemAction.officer_name = dakUserParam.officer_name;
                noteSaveItemAction.nothi_id = nothiListRecordsDTO.id;
                noteSaveItemAction.local_nothi_id = nothiListRecordsDTO.id;
                noteSaveItemAction.office_id = nothiListRecordsDTO.office_id;
                noteSaveItemAction.office_name = nothiListRecordsDTO.office_name;
                noteSaveItemAction.office_unit_name = nothiListRecordsDTO.office_unit_name;
                noteSaveItemAction.office_designation_name = nothiListRecordsDTO.office_designation_name;
                noteSaveItemAction.noteSubject = noteSubject;
                noteSaveItemAction.nothi_type = nothiListRecordsDTO.nothi_type;

                _noteSaveItemAction.Insert(noteSaveItemAction);

                return noteSaveResponse;
            }
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNoteCreateEndpoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", dakUserParam.office_id);
                request.AddParameter("designation_id", dakUserParam.designation_id);
                request.AddParameter("data", "{\"id\":\"0\",\"nothi_master_id\":\"" + nothiListRecordsDTO.id + "\",\"note_subject\":\"" + noteSubject + "\",\"office_id\":" + nothiListRecordsDTO.office_id + ",\"office_name\":\"" + nothiListRecordsDTO.office_name + "\",\"office_unit_name\":\"" + nothiListRecordsDTO.office_unit_name + "\",\"office_designation_name\":\"" + nothiListRecordsDTO.office_designation_name + "\",\"officer_name\":\"" + dakUserParam.officer_name + "\"}");
                IRestResponse response = client.Execute(request);

                var responseJson = response.Content;
                noteSaveResponse = JsonConvert.DeserializeObject<NoteSaveResponse>(responseJson);
                return noteSaveResponse;
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
            List<NoteSaveItemAction> noteSaveItemActions = _noteSaveItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
            if (noteSaveItemActions != null && noteSaveItemActions.Count > 0)
            {
                foreach (NoteSaveItemAction noteSaveItemAction in noteSaveItemActions)
                {
                    DakUserParam userParam = new DakUserParam();
                    userParam.designation_id = noteSaveItemAction.designation_id;
                    userParam.office_id = noteSaveItemAction.office_id;
                    userParam.officer_name = noteSaveItemAction.officer_name;
                    userParam.token = dakUserParam.token;

                    NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
                    nothiListRecordsDTO.id = noteSaveItemAction.nothi_id;
                    nothiListRecordsDTO.office_id = noteSaveItemAction.office_id;
                    nothiListRecordsDTO.office_name = noteSaveItemAction.office_name;
                    nothiListRecordsDTO.office_unit_name = noteSaveItemAction.office_unit_name ;
                    nothiListRecordsDTO.office_designation_name = noteSaveItemAction.office_designation_name;

                    var noteSaveResponse = GetNoteSave(userParam, nothiListRecordsDTO, noteSaveItemAction.noteSubject);

                    if (noteSaveResponse != null && (noteSaveResponse.status == "error" || noteSaveResponse.status == "success"))

                    {
                        if (noteSaveItemAction.nothi_type == "all")
                        {
                            List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();

                            if (noteSaveResponse.status == "success")
                            {
                                if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                                {
                                    foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                    {
                                        NothiListRecordsDTO nothiListRecordsDTO1 = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                        if (nothiListRecordsDTO1.id == noteSaveItemAction.local_nothi_id)
                                        {
                                            NoteSaveDTO newnotedata = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                            nothiListRecordsDTO1.id = noteSaveItemAction.nothi_id;
                                            newnotedata.note_id = noteSaveResponse.data.note_id;
                                            onuchhedSaveItemAction.newnotedataJson = JsonConvert.SerializeObject(newnotedata);
                                            onuchhedSaveItemAction.nothiListRecordsDTOJson = JsonConvert.SerializeObject(nothiListRecordsDTO1);
                                            _onuchhedSaveItemAction.Update(onuchhedSaveItemAction);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                                {
                                    foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                    {
                                        _onuchhedSaveItemAction.Delete(onuchhedSaveItemAction);
                                    }
                                }
                            }
                        }
                        if (noteSaveItemAction.nothi_type == "Inbox")
                        {
                            List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();

                            if (noteSaveResponse.status == "success")
                            {
                                if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                                {
                                    foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                    {
                                        NothiListRecordsDTO nothiListRecordsDTO1 = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                        if (nothiListRecordsDTO1.id == noteSaveItemAction.local_nothi_id && nothiListRecordsDTO1.office_id == 0)
                                        {
                                            NoteSaveDTO newnotedata = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                            newnotedata.note_id = noteSaveResponse.data.note_id;
                                            onuchhedSaveItemAction.newnotedataJson = JsonConvert.SerializeObject(newnotedata);
                                            _onuchhedSaveItemAction.Update(onuchhedSaveItemAction);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                                {
                                    foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                    {
                                        _onuchhedSaveItemAction.Delete(onuchhedSaveItemAction);
                                    }
                                }
                            }
                        }
                        if (noteSaveItemAction.nothi_type == "sent")
                        {
                            List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();

                            if (noteSaveResponse.status == "success")
                            {
                                if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                                {
                                    foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                    {
                                        NothiListRecordsDTO nothiListRecordsDTO1 = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                        if (nothiListRecordsDTO1.id == noteSaveItemAction.local_nothi_id && nothiListRecordsDTO1.office_id == 0)
                                        {
                                            NoteSaveDTO newnotedata = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                            newnotedata.note_id = noteSaveResponse.data.note_id;
                                            onuchhedSaveItemAction.newnotedataJson = JsonConvert.SerializeObject(newnotedata);
                                            _onuchhedSaveItemAction.Update(onuchhedSaveItemAction);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                                {
                                    foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                    {
                                        _onuchhedSaveItemAction.Delete(onuchhedSaveItemAction);
                                    }
                                }
                            }
                        }
                        _noteSaveItemAction.Delete(noteSaveItemAction);
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

        protected string GetNothiNoteCreateEndpoint()
        {
            return DefaultAPIConfiguration.NothiNoteCreateEndPoint;
        }
    }
}

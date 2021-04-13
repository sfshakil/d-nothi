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
        IUserService _userService { get; set; }
        public NoteSaveService(IUserService userService, IRepository<NoteSaveItemAction> noteSaveItemAction)
        {
            _userService = userService;
            _noteSaveItemAction = noteSaveItemAction;
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
                noteSaveItemAction.office_id = nothiListRecordsDTO.office_id;
                noteSaveItemAction.office_name = nothiListRecordsDTO.office_name;
                noteSaveItemAction.office_unit_name = nothiListRecordsDTO.office_unit_name;
                noteSaveItemAction.office_designation_name = nothiListRecordsDTO.office_designation_name;
                noteSaveItemAction.noteSubject = noteSubject;

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

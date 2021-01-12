using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using Newtonsoft.Json;
using RestSharp;


using Newtonsoft.Json.Serialization;


namespace dNothi.Services.DakServices
{
    public class DakNothivuktoService : IDakNothivuktoService
    {
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakNothivuktoService(IRepository<DakType> daktype, IDakListService dakListService)
        {
            _daktype = daktype;
            _dakListService = dakListService;
        }
        public DakListNothivuktoResponse GetNothivuktoDakList(DakUserParam dakListUserParam)
        {
            try
            {
                var nothivuktoDakApi = new RestClient(GetAPIDomain()+GetDakListNothivuktoEndpoint());
                nothivuktoDakApi.Timeout = -1;
                var nothivuktoDakRequest = new RestRequest(Method.POST);
                nothivuktoDakRequest.AddHeader("api-version", GetAPIVersion());
                nothivuktoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothivuktoDakRequest.AlwaysMultipartFormData = true;
                nothivuktoDakRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                nothivuktoDakRequest.AddParameter("office_id", dakListUserParam.office_id);
                nothivuktoDakRequest.AddParameter("page", dakListUserParam.page);
                nothivuktoDakRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse nothivuktoDakResponse = nothivuktoDakApi.Execute(nothivuktoDakRequest);


                var nothivuktoDakResponseJson = nothivuktoDakResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListNothivuktoResponse dakListNothivuktoResponse = JsonConvert.DeserializeObject<DakListNothivuktoResponse>(nothivuktoDakResponseJson);
                return dakListNothivuktoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakNothivukto(DakListNothivuktoResponse dakListNothivuktoResponse)
        {
            DakType dakType = new DakType();
            dakType.is_nothivukto = true;
            if (dakListNothivuktoResponse.data != null)
            {
                dakType.total_records = dakListNothivuktoResponse.data.total_records;

            }

            var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_nothivukto == true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }

            _dakListService.SaveOrUpdateDakList(dakListNothivuktoResponse.data, dakType.Id);
        }

        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }

        protected string GetOldAPIVersion()
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

        protected string GetDakListNothivuktoEndpoint()
        {
            return DefaultAPIConfiguration.DakListNothivuktoEndPoint;
        }

        public GetNothivuktoNoteAddResponse GetNothivuktoNoteAddResponse(DakUserParam dakUserParam, DakNothivuktoNoteAddParam dakNothivuktoNoteAddParam)
        {
            try
            {
                var nothivuktoNoteAddDakApi = new RestClient(GetAPIDomain() + GetNothivuktoNoteAddEndpoint());
                nothivuktoNoteAddDakApi.Timeout = -1;
                var nothivuktoNoteAddDakRequest = new RestRequest(Method.POST);
                nothivuktoNoteAddDakRequest.AddHeader("api-version", GetOldAPIVersion());
                nothivuktoNoteAddDakRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                nothivuktoNoteAddDakRequest.AlwaysMultipartFormData = true;
                nothivuktoNoteAddDakRequest.AddParameter("designation_id", dakUserParam.designation_id);
                nothivuktoNoteAddDakRequest.AddParameter("office_id", dakUserParam.office_id);


                var jsonString = new JavaScriptSerializer().Serialize(dakNothivuktoNoteAddParam);
                nothivuktoNoteAddDakRequest.AddParameter("data", jsonString);
    
                IRestResponse nothivuktoNoteAddDakResponse = nothivuktoNoteAddDakApi.Execute(nothivuktoNoteAddDakRequest);


                var nothivuktoNoteAddDakResponseJson = nothivuktoNoteAddDakResponse.Content;
                   GetNothivuktoNoteAddResponse noteAddResponse = JsonConvert.DeserializeObject<GetNothivuktoNoteAddResponse>(nothivuktoNoteAddDakResponseJson);
                return noteAddResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetNothivuktoNoteAddEndpoint()
        {
            return DefaultAPIConfiguration.NothivuktoNoteAddEndPoint;
        }
        private string GetDakNothivuktoEndpoint()
        {
            return DefaultAPIConfiguration.DakNothivuktoEndpointEndPoint;
        }

        public DakNothivuktoResponse GetDakNothivuktoResponse(DakUserParam dakUserParam, NoteNothiDTO nothi, int dak_id, string dak_type, int is_copied_dak)
        {
            var nothivuktoDakSendAPI = new RestClient(GetAPIDomain() + GetDakNothivuktoEndpoint());
            nothivuktoDakSendAPI.Timeout = -1;
            var NothivuktoDakSendRequest = new RestRequest(Method.POST);
            NothivuktoDakSendRequest.AddHeader("api-version", GetOldAPIVersion());
            NothivuktoDakSendRequest.AddHeader("Authorization", "Bearer " + dakUserParam.token);
            NothivuktoDakSendRequest.AddParameter("cdesk", dakUserParam.json_String);
          
            NothivuktoDakSendRequest.AddParameter("daak", "{\"dak_id\":\""+dak_id+"\",\"dak_type\":\""+dak_type+"\",\"is_copied_dak\":"+is_copied_dak+"}");
            var nothijsonString = new JavaScriptSerializer().Serialize(nothi);


            NothivuktoDakSendRequest.AddParameter("nothi", nothijsonString);
            IRestResponse dakNothivuktoIRestResponse = nothivuktoDakSendAPI.Execute(NothivuktoDakSendRequest);
            var dakNothivuktoResponseJson = dakNothivuktoIRestResponse.Content;

            var dakNothivuktoResponse = JsonConvert.DeserializeObject<DakNothivuktoResponse>(dakNothivuktoResponseJson, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });



            return dakNothivuktoResponse;
        }

        public void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

       

    }
}

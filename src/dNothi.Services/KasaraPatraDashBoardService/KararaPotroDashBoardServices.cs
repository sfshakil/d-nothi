using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Entities.Khosra;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.KasaraPatraDashBoardService.Models;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KasaraPatraDashBoardService
{
   public class KararaPotroDashBoardServices : IKasaraPatraDashBoardService
    {
        IRepository<KhosraLocal> _localKhosraLocalRepository;
        IRepository<KhosraListLocal> _localKhosraListLocalRepository;

        public KararaPotroDashBoardServices(IRepository<KhosraLocal> localKhosraLocalRepository, IRepository<KhosraListLocal> localKhosraListLocalRepository)
        {
            _localKhosraLocalRepository = localKhosraLocalRepository;
            _localKhosraListLocalRepository = localKhosraListLocalRepository;
        }
        public KasaraPotro GetList(DakUserParam userParam, int menuNo)
        {
            string cdesk = "{\"office_id\":\"" + userParam.office_id + "\",\"office_unit_id\":\"" + userParam.office_unit_id + "\",\"designation_id\":\"" + userParam.designation_id + "\"}";
            string searchParam = "potro_subject=" + userParam.NameSearchParam + "";


            if (!InternetConnection.Check())
            {
                var responseJson= GetLocalKhasraList(userParam, menuNo, cdesk, searchParam);
                KasaraPotro nothikhoshrapotrolist = JsonConvert.DeserializeObject<KasaraPotro>(responseJson, NullDeserializeSetting());
                return nothikhoshrapotrolist;
            }
            
            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(menuNo));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("cdesk", cdesk);

                request.AddParameter("page", userParam.page);
                request.AddParameter("limit", userParam.limit);
                if (!string.IsNullOrEmpty(userParam.NameSearchParam))
                {
                    request.AddParameter("search_params", searchParam);
                }
              
                IRestResponse Response = Api.Execute(request);
                var responseJson = Response.Content;

                responseJson = responseJson.Replace("\"recipient\":[]","\"recipient\":\"\"");
                SaveLocalllyKhosraList(responseJson, userParam, menuNo, cdesk, searchParam);
                KasaraPotro nothikhoshrapotrolist = JsonConvert.DeserializeObject<KasaraPotro>(responseJson, NullDeserializeSetting());
                return nothikhoshrapotrolist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PrapakerTalika GetPrapakerTalika(DakUserParam userParam, int potro)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(6));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"Technology\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");
                request.AddParameter("potro", potro);
                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;
                responseJson = responseJson.Replace("\"data\":[]", "\"data\":\"\"");
                PrapakerTalika nothikhoshrapotrolist = JsonConvert.DeserializeObject<PrapakerTalika>(responseJson, NullDeserializeSetting());
                return nothikhoshrapotrolist;
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public DakAttachmentResponse GetMulPattraAndSanjukti(DakUserParam userParam, KasaraPotro.Record record)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(7));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

               
                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + "," +
                    "\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\"," +
                    "\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\"," +
                    "\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "," +
                    "\"officer_email\":" + userParam.officer_email + ",\"officer_mobile\":" + userParam.officer_mobile + "}");
                if (record.Basic.PotroType != 0)
                {
                    request.AddParameter("potro", "{\"nothi_id\":\"" + record.Basic.NothiMasterId + "\",\"nothi_office\":\"" + userParam.office_id + "\"," +
                    "\"note_id\":\"" + record.Basic.NothiNoteId + "\",\"onucched_id\":\"" + record.NoteOnucched.Id + "\"," +
                    "\"nothi_potro_id\":\"" + record.Basic.NothiPotroId + "\",\"potrojari_id\":\"" + record.Basic.Id + "\",\"cloned_potrojari_id\":\"" + record.Basic.ClonedPotrojariId + "\"," +
                    "\"nothi_potro_attachment_id\":\"" + record.Basic.NothiPotroAttachmentId + "\",\"potro_type\":\"" + record.Basic.PotroType + "\",\"sarok_no\":\"" + record.Basic.SarokNo + "\",\"potro_subject\":\"" + record.Basic.PotroSubject + "\"}");

                }
                else
                {
                    request.AddParameter("potro", "{\"sarok_no\": \"" + record.Basic.SarokNo + "\",\"potro_subject\": \" " + record.Basic.PotroSubject + "\",\"nothi_potro_id\": \"" + record.Basic.Id + "\",\"nothi_id\": \"" + record.Basic.NothiMasterId + "\",\"nothi_office\": \"" + userParam.office_id + "\"}");

                }
                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;

                DakAttachmentResponse attachmentlist = JsonConvert.DeserializeObject<DakAttachmentResponse>(responseJson, NullDeserializeSetting());
                return attachmentlist;
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public ResponseModel KasaraDashBoardRecordCount(DakUserParam userParam)
        {
            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(8));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);

                request.AddHeader("api-version", "1");

                request.AddHeader("Authorization", "Bearer " + userParam.token);

                request.AlwaysMultipartFormData = true;

                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");

                IRestResponse Response = Api.Execute(request);
              
                var responseJson = Response.Content;

                ResponseModel response = JsonConvert.DeserializeObject<ResponseModel>(responseJson, NullDeserializeSetting());

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private string GetLocalKhasraList(DakUserParam userParam, int menuid,string cdesk,string searchParam)
        {
            var khasraData = _localKhosraListLocalRepository.Table.
                Where(x=>x.cdesk== cdesk && x.limit==userParam.limit && x.MenuId==menuid && x.page==userParam.page && x.search_params== searchParam)
                .FirstOrDefault();

            if (khasraData != null)
            {
                return khasraData.responseData;
            }
            else
            {
                return "";
            }

        }

        private void SaveLocalllyKhosraList(string responseJson, DakUserParam userParam, int menuid, string cdesk, string searchParam)
        {

            var khasraData = _localKhosraListLocalRepository.Table.
                Where(x => x.cdesk == cdesk && x.limit == userParam.limit && x.MenuId == menuid && x.page == userParam.page && x.search_params == searchParam)
                .FirstOrDefault();

            if (khasraData != null)
            {
                khasraData.responseData = responseJson;
                _localKhosraListLocalRepository.Update(khasraData);
            }
            else
            {
                KhosraListLocal localkasraList = new KhosraListLocal
                {
                    cdesk = cdesk,
                    MenuId = menuid,
                    page = userParam.page,
                    limit = userParam.limit,
                    search_params = searchParam,
                    responseData = responseJson,
                    isLocal = true
                     
                };
                _localKhosraListLocalRepository.Insert(localkasraList);
            }

        }


        private JsonSerializerSettings NullDeserializeSetting()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return settings;
        }
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string GetEndPoint(int code)
        {
            string endPoint = string.Empty;
            if (code == 1)
            {
                endPoint = DefaultAPIConfiguration.nothidraftpotrolist;
            }
            if (code == 2)
            {
                endPoint = DefaultAPIConfiguration.nothikhoshrapotrolist;
            }
            if (code == 3)
            {
                endPoint = DefaultAPIConfiguration.nothikhoshrawaitingforapprovallist;
            }
            if (code == 4)
            {
                endPoint = DefaultAPIConfiguration.nothiapprovedpotrolist;
            }
            if (code == 5)
            {
                endPoint = DefaultAPIConfiguration.nothipotrojariassenderapproverlist;
            }
            if (code == 6)
            {
                endPoint = DefaultAPIConfiguration.prapakerTalika;
            }
            if (code == 7)
            {
                endPoint = DefaultAPIConfiguration.mulPattraAndSanjukti;
            }
            if (code == 8)
            {
                endPoint = DefaultAPIConfiguration.kasaraDashboard;
            }
            return endPoint;
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}

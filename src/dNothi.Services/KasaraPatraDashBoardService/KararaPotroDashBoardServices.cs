using dNothi.Constants;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.KasaraPatraDashBoardService.Models;
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
        public KasaraPotro GetList(DakUserParam userParam, int menuNo)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(menuNo));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("cdesk", "{\"office_id\":\"" + userParam.office_id + "\",\"office_unit_id\":\"" + userParam.office_unit_id + "\",\"designation_id\":\"" + userParam.designation_id + "\"}");

                request.AddParameter("page", userParam.page);
                request.AddParameter("limit", userParam.limit);
                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;

                KasaraPotro nothikhoshrapotrolist = JsonConvert.DeserializeObject<KasaraPotro>(responseJson);
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
                request.AddParameter("potro", 10);
                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;

                PrapakerTalika nothikhoshrapotrolist = JsonConvert.DeserializeObject<PrapakerTalika>(responseJson);
                return nothikhoshrapotrolist;
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public Attachment GetMulPattraAndSanjukti(DakUserParam userParam, KasaraPotro.Record record)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetEndPoint(7));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                //request.AddParameter("cdesk", "{\"office_id\":\"" + userParam.office_id + "\",\"office_unit_id\":\"" + userParam.office_unit_id + "\",\"designation_id\":\"" + userParam.designation_id + "\"}");
                //request.AddParameter("potro", "{\"nothi_id\":\""+ record .basic.shared_nothi_id + "\",\"nothi_office\":\""+record.note_owner.nothi_office+"\",\"note_id\":\""+record.basic.nothi_note_id+"\",\"onucched_id\":\""+record.basic.note_onucched_id+"\",\"nothi_potro_id\":\""+ record.basic.nothi_potro_id + "\",\"potrojari_id\":\""+ record.basic.cloned_potrojari_id + "\",\"cloned_potrojari_id\":\""+ record.basic.cloned_potrojari_id + "\",\"nothi_potro_attachment_id\":\""+ record.basic.nothi_potro_attachment_id + "\",\"potro_type\":\""+record.basic.potro_type+"\",\"sarok_no\":\""+record.basic.sarok_no+"\",\"potro_subject\":\""+record.basic.potro_subject+"\"}");

                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");

                request.AddParameter("length", userParam.limit);
                request.AddParameter("potro", "{\"sarok_no\":\"" + record.basic.sarok_no + "\",\"potro_subject\":\"" + record.basic.potro_subject + "\",\"nothi_potro_id\":\"" + record.basic.nothi_potro_id + "\",\"nothi_id\":\"" + record.basic.shared_nothi_id + "\",\"nothi_office\":\"" + record.note_owner.nothi_office + "\"}");


                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;

                Attachment attachmentlist = JsonConvert.DeserializeObject<Attachment>(responseJson);
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

                ResponseModel response = JsonConvert.DeserializeObject<ResponseModel>(responseJson);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }


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

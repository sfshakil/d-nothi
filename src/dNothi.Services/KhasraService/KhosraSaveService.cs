using dNothi.Constants;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.DakServices;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KhasraService
{
  public  class KhosraSaveService:IKhosraSaveService
    {
        public GetSarokNoResponse GetSharokNoResponse(DakUserParam dakUserParameter, int nothiid, int potrojariid)
        {
            try
            {


                var GetSharokNoAPI = new RestClient(GetAPIDomain() + GetSharokNoEndpoint());
                GetSharokNoAPI.Timeout = -1;
                var GetSharokNoRequest = new RestRequest(Method.POST);
                GetSharokNoRequest.AddHeader("api-version", GetOldAPIVersion());
                GetSharokNoRequest.AddHeader("Authorization", "Bearer " + dakUserParameter.token);
                GetSharokNoRequest.AlwaysMultipartFormData = true;
                GetSharokNoRequest.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParameter.office_id + "\",\"office_unit_id\":\"" + dakUserParameter.office_unit_id + "\",\"designation_id\":\"" + dakUserParameter.designation_id + "\"}");
                GetSharokNoRequest.AddParameter("potro", "{\"nothi_id\":\""+nothiid+"\",\"potrojari_id\":\""+potrojariid+"\",\"req_data\":{\"sarok_no\":\"\"}}");


                

                IRestResponse GetSharokNoResponse = GetSharokNoAPI.Execute(GetSharokNoRequest);


                var GetSharokNoResponseJson = GetSharokNoResponse.Content;

                GetSarokNoResponse sarok_no = JsonConvert.DeserializeObject<GetSarokNoResponse>(GetSharokNoResponseJson);
                return sarok_no;
            }
            catch (Exception ex)
            {
                GetSarokNoResponse sarok_no = new GetSarokNoResponse();
                sarok_no.sarok_no = "";
                return sarok_no;
            }
        }


        public KhosraSaveResponse GetKhosraSaveResponse(DakUserParam dakUserParameter, KhosraSaveParamPotro potro)
        {
            try
            {


                var khasraSaveAPI = new RestClient(GetAPIDomain() + GetKhosraSaveEndpoint());
                khasraSaveAPI.Timeout = -1;
                var khasraSaveRequest = new RestRequest(Method.POST);
                khasraSaveRequest.AddHeader("api-version", GetOldAPIVersion());
                khasraSaveRequest.AddHeader("Authorization", "Bearer " + dakUserParameter.token);
                khasraSaveRequest.AlwaysMultipartFormData = true;
                khasraSaveRequest.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParameter.office_id + "\",\"office_unit_id\":\"" + dakUserParameter.office_unit_id + "\",\"designation_id\":\"" + dakUserParameter.designation_id + "\"}");
                string potroRequestJson = JsonParsingMethod.ObjecttoJson(potro);
                
                khasraSaveRequest.AddParameter("potro", potroRequestJson);

                IRestResponse khasraSaveResponse = khasraSaveAPI.Execute(khasraSaveRequest);


                var khasraSaveResponseJson = ConversionMethod.FilterJsonResponse(khasraSaveResponse.Content);
                
                KhosraSaveResponse khasraPotroSaveResponse = JsonConvert.DeserializeObject<KhosraSaveResponse>(khasraSaveResponseJson);
                return khasraPotroSaveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
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

        protected string GetKhosraSaveEndpoint()
        {
            return DefaultAPIConfiguration.KhosraSaveEndpoint;
        }
        protected string GetSharokNoEndpoint()
        {
            return DefaultAPIConfiguration.SharokNoEndpoint;
        }
    }

 public interface IKhosraSaveService
    {
         KhosraSaveResponse GetKhosraSaveResponse(DakUserParam dakUserParameter, KhosraSaveParamPotro potro);
         GetSarokNoResponse GetSharokNoResponse(DakUserParam dakUserParameter, int nothiid, int potrojariid);
    }
}

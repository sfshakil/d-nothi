using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Entities.Khosra;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Dak;
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
        IRepository<KhosraLocal> _localKhosraLocalRepository;
        IRepository<KhosraFileUpload> _localKhosraFileUploadRepository;

        public KhosraSaveService(IRepository<KhosraLocal> localKhosraLocalRepository, IRepository<KhosraFileUpload> localKhosraFileUploadRepository)
        {
            _localKhosraLocalRepository = localKhosraLocalRepository;
            _localKhosraFileUploadRepository = localKhosraFileUploadRepository;
        }

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
            string cdesk = "{\"office_id\":\"" + dakUserParameter.office_id + "\",\"office_unit_id\":\"" + dakUserParameter.office_unit_id + "\",\"designation_id\":\"" + dakUserParameter.designation_id + "\"}";
            string potroRequestJson = JsonParsingMethod.ObjecttoJson(potro);
            if (!InternetConnection.Check())
            {
                if(potro.recipient.receiver!=null)
                {
                    if (potro.recipient.receiver.Count > 0)
                    {
                        return SaveLocalKhosra(cdesk, potroRequestJson, potro);
                    }
                    else
                    {
                        return new KhosraSaveResponse { status = "error", message = "কমপক্ষে একজন প্রাপক লাগবে।" };
                    }
                }
                else
                {
                    return new KhosraSaveResponse { status = "error", message = "কমপক্ষে একজন প্রাপক লাগবে।" };
                }
                
            }

        
            return KhosraSave(dakUserParameter, cdesk, potroRequestJson);
       
        }
        private KhosraSaveResponse KhosraSave(DakUserParam dakUserParameter,string cdesk,string potroRequestJson)
        {
            KhosraSaveResponse khasraPotroSaveResponse = new KhosraSaveResponse();
            try
            {


                var khasraSaveAPI = new RestClient(GetAPIDomain() + GetKhosraSaveEndpoint());
                khasraSaveAPI.Timeout = -1;
                var khasraSaveRequest = new RestRequest(Method.POST);
                khasraSaveRequest.AddHeader("api-version", GetOldAPIVersion());
                khasraSaveRequest.AddHeader("Authorization", "Bearer " + dakUserParameter.token);
                khasraSaveRequest.AlwaysMultipartFormData = true;
                khasraSaveRequest.AddParameter("cdesk", cdesk);

                khasraSaveRequest.AddParameter("potro", potroRequestJson);

                IRestResponse khasraSaveResponse = khasraSaveAPI.Execute(khasraSaveRequest);


                var khasraSaveResponseJson = ConversionMethod.FilterJsonResponse(khasraSaveResponse.Content);

                khasraPotroSaveResponse = JsonConvert.DeserializeObject<KhosraSaveResponse>(khasraSaveResponseJson);
                return khasraPotroSaveResponse;
            }
            catch(Exception ex)
            {
                return khasraPotroSaveResponse;
            }
        }
        private KhosraSaveResponse SaveLocalKhosra(string cdesk,string potro, KhosraSaveParamPotro potroParam)
        {
             
            KhosraLocal localKhosraLocal = new KhosraLocal
            {

                cdesk = cdesk,
                isLocal = true,
                 potro= potro

            };
            _localKhosraLocalRepository.Insert(localKhosraLocal);
            long maxId = _localKhosraLocalRepository.Table.Max(x=>x.Id);
            if (potroParam.attachment.Count > 0)
            {
                foreach (var item in potroParam.attachments)
                {
                    if (item.nothi_potro_attachment_id > 0)
                    {
                    }
                    else {

                          var uploadedData=   _localKhosraFileUploadRepository.Table.Where(x => x.Id == item.id).FirstOrDefault();
                        if(uploadedData!=null)
                        {
                            uploadedData.KhosraId = maxId;
                            _localKhosraFileUploadRepository.Update(uploadedData);
                        }
                       }
                }
            }

           return new KhosraSaveResponse { status = "success", data="খসড়া সংরক্ষণ সফল হয়েছে।" };

        }

        public bool SendKosraLocalDataTOServer(DakUserParam userParam)
        {
            bool success = false;
            var localKosraInsertDelete = _localKhosraLocalRepository.Table.ToList();
           
            foreach (var item in localKosraInsertDelete)
            {
                   string potro   = GetAttachment( userParam, item);

                   var returnData=  KhosraSave(userParam, item.cdesk, potro);
                   if (returnData.status == "success")
                    {
                        success = true;
                       _localKhosraLocalRepository.Delete(item);
                    }
                   
            }

            return success;
        }
        private string GetAttachment(DakUserParam userParam,KhosraLocal khosraLocal)
        {
            List<string> attachments = new List<string>();
            var potroData= JsonConvert.DeserializeObject<KhosraSaveParamPotro>(khosraLocal.potro);
            
            var khosraAttachment = _localKhosraFileUploadRepository.Table.Where(x => x.KhosraId == khosraLocal.Id).ToList();
            if (potroData.attachments.Count > 0)
            {
                foreach (var item in khosraAttachment)
                {
                    DakFileUploadParam fileUploadParam = new DakFileUploadParam
                    {
                        content = item.content,
                        file_size_in_kb = item.file_size_in_kb,
                        model = item.model,
                        path = item.path,
                        user_file_name = item.user_file_name
                    };
                    var uploadedFileResponse = GetDakUploadedFile(userParam, fileUploadParam);
                    attachments.Add(ConversionMethod.ObjecttoJson(new { id = uploadedFileResponse.data[0].id, user_file_name = uploadedFileResponse.data[0].user_file_name }));
                    _localKhosraFileUploadRepository.Delete(item);
                }
                foreach (var item in potroData.attachments)
                {
                    if (item.nothi_potro_id > 0)
                    {

                        attachments.Add(ConversionMethod.ObjecttoJson(new { nothi_potro_attachment_id = item.id, nothi_potro_id = item.nothi_potro_id, user_file_name = item.user_file_name }));

                    }
                }
                potroData.attachment = attachments;
            }
            string potroRequestJson = JsonParsingMethod.ObjecttoJson(potroData);
            return potroRequestJson;
        }
        private DakUploadedFileResponse GetDakUploadedFile(DakUserParam dakListUserParam, DakFileUploadParam dakFileUploadParam)
        {
            DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
       
            try
            {
                var dakFileUploadApi = new RestClient(GetAPIDomain() + DefaultAPIConfiguration.DakFileUploadEndPoint);
                dakFileUploadApi.Timeout = -1;
                var dakFileUploadRequest = new RestRequest(Method.POST);
                dakFileUploadRequest.AddHeader("api-version", GetAPIVersion());
                dakFileUploadRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);

                dakFileUploadRequest.AlwaysMultipartFormData = true;
                dakFileUploadRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakFileUploadRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakFileUploadRequest.AddParameter("path", dakFileUploadParam.path);
                dakFileUploadRequest.AddParameter("file_size_in_kb", dakFileUploadParam.file_size_in_kb);
                dakFileUploadRequest.AddParameter("user_file_name", dakFileUploadParam.user_file_name);
                dakFileUploadRequest.AddParameter("content", dakFileUploadParam.content);
              
                dakFileUploadRequest.AddParameter("model", dakFileUploadParam.model);
               
                IRestResponse dakFileUploadResponse = dakFileUploadApi.Execute(dakFileUploadRequest);


                var dakFileUploadResponseJson = dakFileUploadResponse.Content;
                dakUploadedFileResponse = JsonConvert.DeserializeObject<DakUploadedFileResponse>(dakFileUploadResponseJson);
                return dakUploadedFileResponse;
            }
            catch (Exception ex)
            {


                return dakUploadedFileResponse;
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
         bool SendKosraLocalDataTOServer(DakUserParam userParam);

    }
}

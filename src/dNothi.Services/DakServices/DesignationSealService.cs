using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DesignationSealService : IDesignationSealService
    {
        IDakForwardService _dakForwardService { get; set; }
        IRepository<LocalDesignationSealByOffice> _designationByOfficerRepository;
        IRepository<LocalOfficeList> _officerRepository;


        public DesignationSealService(IDakForwardService dakForwardService,
             IRepository<LocalDesignationSealByOffice> designationByOfficerRepository,
        IRepository<LocalOfficeList> officerRepository
        )
        {
            _officerRepository = officerRepository;
            _designationByOfficerRepository = designationByOfficerRepository;
            _dakForwardService = dakForwardService;
        }
        public DesignationSealListResponse GetOfficerAddedSealList(DakUserParam dakListUserParam)
        {
            try
            {

                var designationSealList = new RestClient(GetAPIDomain() + GetDesignationSealListEndpoint());
                designationSealList.Timeout = -1;
                var designationSealRequest = new RestRequest(Method.POST);
                designationSealRequest.AddHeader("api-version", GetOldAPIVersion());
                designationSealRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                designationSealRequest.AlwaysMultipartFormData = true;
                designationSealRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                designationSealRequest.AddParameter("office_id", dakListUserParam.office_id);

                IRestResponse designationSealResponseAPI = designationSealList.Execute(designationSealRequest);


                var designationSealResponseJson = designationSealResponseAPI.Content;
                
                DesignationSealListResponse designationSealResponse = JsonConvert.DeserializeObject<DesignationSealListResponse>(designationSealResponseJson);
                return designationSealResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected string GetOldAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string GetDesignationSealListEndpoint()
        {
            return DefaultAPIConfiguration.GetDesignationSealListEndpoint;
        }
        public AllDesignationSealListResponse GetAllDesignationSeal(DakUserParam dakListUserParam, int office_id)
        {
            AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {

                var localDesignationSealResponse = _designationByOfficerRepository.Table.FirstOrDefault(a => a.designationId == dakListUserParam.designation_id && a.officeId == office_id);
                if(localDesignationSealResponse != null && localDesignationSealResponse.jsonResponse != null)
                {
                    designationSealListResponse = JsonConvert.DeserializeObject<AllDesignationSealListResponse>(localDesignationSealResponse.jsonResponse);

                    
                }
                return designationSealListResponse;
            }
            var designationSealAPI = new RestClient(GetAPIDomain() + GetAllDesignationSealEndpoint());
            designationSealAPI.Timeout = -1;
            var designationSealRequest = new RestRequest(Method.POST);
            designationSealRequest.AddHeader("api-version", GetAPIVersion());
            designationSealRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);

            designationSealRequest.AddParameter("office_id", office_id);
            designationSealRequest.AddParameter("cdesk", dakListUserParam.json_String);
            
            IRestResponse designationSealIRestResponse = designationSealAPI.Execute(designationSealRequest);
            
            var designationSealResponseJson = designationSealIRestResponse.Content;

            AllDesignationSealListResponseLocally(dakListUserParam.designation_id,office_id,designationSealResponseJson);

            designationSealListResponse = JsonConvert.DeserializeObject<AllDesignationSealListResponse>(designationSealResponseJson);
            return designationSealListResponse;
        }

        private void AllDesignationSealListResponseLocally(int designation_id, int office_id, string designationSealResponseJson)
        {
            var localDesignationSealResponse = _designationByOfficerRepository.Table.FirstOrDefault(a => a.designationId == designation_id && a.officeId == office_id);
            if(localDesignationSealResponse != null)
            {
                localDesignationSealResponse.jsonResponse = designationSealResponseJson;
                _designationByOfficerRepository.Update(localDesignationSealResponse);
            }
            else
            {
                localDesignationSealResponse = new LocalDesignationSealByOffice
                {
                    designationId = designation_id,
                    officeId = office_id,
                    jsonResponse = designationSealResponseJson


                };

                _designationByOfficerRepository.Insert(localDesignationSealResponse);

            }
        }
        private void SaveAllOfficeListResponseLocally(int designation_id, int office_id, string designationSealResponseJson)
        {
            var localDesignationSealResponse = _officerRepository.Table.FirstOrDefault(a => a.designationId == designation_id && a.officeId == office_id);
            if (localDesignationSealResponse != null)
            {
                localDesignationSealResponse.jsonResponse = designationSealResponseJson;
                _officerRepository.Update(localDesignationSealResponse);
            }
            else
            {
                localDesignationSealResponse = new LocalOfficeList
                {
                    designationId = designation_id,
                    officeId = office_id,
                    jsonResponse = designationSealResponseJson


                };

                _officerRepository.Insert(localDesignationSealResponse);

            }
        }
        public OfficeListResponse GetAllOffice(DakUserParam dakListUserParam)
        {
            OfficeListResponse officeListResponse = new OfficeListResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {

                var localDesignationSealResponse = _officerRepository.Table.FirstOrDefault(a => a.designationId == dakListUserParam.designation_id && a.officeId == dakListUserParam.office_id);
                if (localDesignationSealResponse != null && localDesignationSealResponse.jsonResponse != null)
                {
                    officeListResponse = JsonConvert.DeserializeObject<OfficeListResponse>(localDesignationSealResponse.jsonResponse);


                }
                return officeListResponse;
            }
            var dakOfficeAPI = new RestClient(GetAPIDomain() + GetOfficeListEndpoint());
            dakOfficeAPI.Timeout = -1;
            var dakOfficeRequest = new RestRequest(Method.POST);
            dakOfficeRequest.AddHeader("api-version", GetAPIVersion());
            dakOfficeRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
            dakOfficeRequest.AddParameter("office_id", dakListUserParam.office_id);
            dakOfficeRequest.AddParameter("cdesk", dakListUserParam.json_String);

            IRestResponse dakOfficeIRestResponse = dakOfficeAPI.Execute(dakOfficeRequest);
            var dakOfficeResponseJson = ConversionMethod.FilterJsonResponse(dakOfficeIRestResponse.Content);


            SaveAllOfficeListResponseLocally(dakListUserParam.designation_id, dakListUserParam.office_id, dakOfficeResponseJson);



            officeListResponse = JsonConvert.DeserializeObject<OfficeListResponse>(dakOfficeResponseJson);
            return officeListResponse;
        }
        public List<LocalOfficesResponse> GetAllLocalOffice()
        {
           
            string currentFolderPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\JsonData\offices.json";

            List<LocalOfficesResponse> localOfficesResponses = JsonConvert.DeserializeObject<List<LocalOfficesResponse>>(File.ReadAllText(currentFolderPath));

             return localOfficesResponses;
        }

        protected string GetAllDesignationSealEndpoint()
        {
            return DefaultAPIConfiguration.AllDesignationSealEndPoint;
        }
        protected string GetOfficeListEndpoint()
        {
            return DefaultAPIConfiguration.OfficeListEndpoint;
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
    }
}

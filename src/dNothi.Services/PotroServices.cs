using dNothi.Constants;
using dNothi.Core.Entities.Khosra;
using dNothi.Core.Interfaces;
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

namespace dNothi.Services
{
   public class PotroServices:IPotroServices
    {
        IRepository<PermittedPotroLocal> _localPermittedPotroLocalListLocalRepository;

        public PotroServices(IRepository<PermittedPotroLocal> localPermittedPotroLocalListLocalRepository)
        {
            _localPermittedPotroLocalListLocalRepository = localPermittedPotroLocalListLocalRepository;
        }
        public PermittedPotroResponse GetPermittedPotro(DakUserParam dakUserParameter)
        {
            PermittedPotroResponse permittedPotroResponse = new PermittedPotroResponse();
            string cdesk = "{\"office_id\":\"" + dakUserParameter.office_id + "\",\"office_unit_id\":\"" + dakUserParameter.office_unit_id + "\",\"designation_id\":\"" + dakUserParameter.designation_id + "\"}";
            if (!InternetConnection.Check())
            {
                var permittedPotroResponseJson = GetLocalpermittedPotroList(dakUserParameter,cdesk);
                permittedPotroResponse = JsonConvert.DeserializeObject<PermittedPotroResponse>(permittedPotroResponseJson);
                return permittedPotroResponse;
            }
            try
            {

               
                var permittedPotroAPI = new RestClient(GetAPIDomain() + GetPermittedPotroEndPointt());
                permittedPotroAPI.Timeout = -1;
                var PermittedPotroEndPointRequest = new RestRequest(Method.POST);
                PermittedPotroEndPointRequest.AddHeader("api-version", GetAPIVersion());
                PermittedPotroEndPointRequest.AddHeader("Authorization", "Bearer " + dakUserParameter.token);
                PermittedPotroEndPointRequest.AlwaysMultipartFormData = true;
                PermittedPotroEndPointRequest.AddParameter("cdesk", cdesk);
                PermittedPotroEndPointRequest.AddParameter("length", dakUserParameter.limit);
                PermittedPotroEndPointRequest.AddParameter("page", dakUserParameter.page);

                IRestResponse PermittedPotroEndPointResponse = permittedPotroAPI.Execute(PermittedPotroEndPointRequest);


                var permittedPotroResponseJson =ConversionMethod.FilterJsonResponse(PermittedPotroEndPointResponse.Content);
                SaveLocalllyPermittedPotroList(permittedPotroResponseJson, dakUserParameter, cdesk);
                permittedPotroResponse = JsonConvert.DeserializeObject<PermittedPotroResponse>(permittedPotroResponseJson);
                return permittedPotroResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private string GetLocalpermittedPotroList(DakUserParam userParam, string cdesk)
        {
            var permittedPotroData = _localPermittedPotroLocalListLocalRepository.Table.
                Where(x => x.cdesk == cdesk && x.limit == userParam.limit && x.page == userParam.page)
                .FirstOrDefault();

            if (permittedPotroData != null)
            {
                return permittedPotroData.responseData;
            }
            else
            {
                return null;
            }

        }

        private void SaveLocalllyPermittedPotroList(string responseJson, DakUserParam userParam, string cdesk)
        {

            var permittedPotroData = _localPermittedPotroLocalListLocalRepository.Table.
                Where(x => x.cdesk == cdesk && x.limit == userParam.limit && x.page == userParam.page )
                .FirstOrDefault();

            if (permittedPotroData != null)
            {
                permittedPotroData.responseData = responseJson;
                _localPermittedPotroLocalListLocalRepository.Update(permittedPotroData);
            }
            else
            {
                PermittedPotroLocal permittedPotro = new PermittedPotroLocal
                {
                    cdesk = cdesk,
                   
                    page = userParam.page,
                    limit = userParam.limit,
                   
                    responseData = responseJson,
                    isLocal = true

                };
                _localPermittedPotroLocalListLocalRepository.Insert(permittedPotro);
            }

        }


        protected string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.NewAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetPermittedPotroEndPointt()
        {
            return DefaultAPIConfiguration.PermittedPotroEndPoint;
        }
    }

    public interface IPotroServices
    {
        PermittedPotroResponse GetPermittedPotro(DakUserParam dakUserParameter);
    }
}

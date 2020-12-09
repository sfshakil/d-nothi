using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Dak;
using Newtonsoft.Json;
using RestSharp;

namespace dNothi.Services.DakServices
{
    public class DakNothijatoService : IDakNothijatoService
    {
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakNothijatoService(IRepository<DakType> daktype, IDakListService dakListService)
        {
            _daktype = daktype;
            _dakListService = dakListService;
        }
        public DakListNothijatoResponse GetNothijatoDak(DakListUserParam dakListUserParam)
        {
            try
            {
                var nothijatoDakApi = new RestClient(GetAPIDomain()+GetDakListNothijatoEndpoint());
                nothijatoDakApi.Timeout = -1;
                var nothijatoDakRequest = new RestRequest(Method.POST);
                nothijatoDakRequest.AddHeader("api-version",GetAPIVersion());
                nothijatoDakRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                nothijatoDakRequest.AlwaysMultipartFormData = true;
                nothijatoDakRequest.AddParameter("designation_id", dakListUserParam.designationId);
                nothijatoDakRequest.AddParameter("office_id", dakListUserParam.officeId);
                nothijatoDakRequest.AddParameter("page", dakListUserParam.page);
                nothijatoDakRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse nothijatoDakResponse = nothijatoDakApi.Execute(nothijatoDakRequest);


                var nothijatoDakResponseJson = nothijatoDakResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListNothijatoResponse dakListNothijatoResponse = JsonConvert.DeserializeObject<DakListNothijatoResponse>(nothijatoDakResponseJson);
                return dakListNothijatoResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakNothijato(DakListNothijatoResponse dakListNothijatoResponse)
        {
            DakType dakType = new DakType();
            dakType.is_nothijato = true;
            if (dakListNothijatoResponse.data != null)
            {
                dakType.total_records = dakListNothijatoResponse.data.total_records;

            }

            var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_nothijato == true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }

            _dakListService.SaveOrUpdateDakList(dakListNothijatoResponse.data, dakType.Id);
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

        protected string GetDakListNothijatoEndpoint()
        {
            return DefaultAPIConfiguration.DakListNothijatoEndPoint;
        }
    }
}

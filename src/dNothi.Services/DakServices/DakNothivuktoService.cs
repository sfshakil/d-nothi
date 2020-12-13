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
    public class DakNothivuktoService : IDakNothivuktoService
    {
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakNothivuktoService(IRepository<DakType> daktype, IDakListService dakListService)
        {
            _daktype = daktype;
            _dakListService = dakListService;
        }
        public DakListNothivuktoResponse GetNothivuktoDakList(DakListUserParam dakListUserParam)
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
    }
}

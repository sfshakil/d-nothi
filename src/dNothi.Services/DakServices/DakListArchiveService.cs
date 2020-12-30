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
    public class DakListArchiveService : IDakListArchiveService
    {
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakListArchiveService(IRepository<DakType> daktype, IDakListService dakListService)
        {
            _daktype = daktype;
            _dakListService = dakListService;
        }
        public DakListArchiveResponse GetDakList(DakUserParam dakListUserParam)
        {
              try
            {
                var dakArchiveApi = new RestClient(GetAPIDomain()+GetDakListArchiveEndpoint());
                dakArchiveApi.Timeout = -1;
                var dakArchiveRequest = new RestRequest(Method.POST);
                dakArchiveRequest.AddHeader("api-version", GetAPIVersion());
                dakArchiveRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakArchiveRequest.AlwaysMultipartFormData = true;
                dakArchiveRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakArchiveRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakArchiveRequest.AddParameter("page", dakListUserParam.page);
                dakArchiveRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakArchiveResponse = dakArchiveApi.Execute(dakArchiveRequest);


                var dakArchiveResponseJson = dakArchiveResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListArchiveResponse dakListArchiveResponse = JsonConvert.DeserializeObject<DakListArchiveResponse>(dakArchiveResponseJson);
                return dakListArchiveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakArchive(DakListArchiveResponse dakListArchiveResponse)
        {
            DakType dakType = new DakType();
            dakType.is_archived = true;
            if (dakListArchiveResponse.data != null)
            {
                dakType.total_records = dakListArchiveResponse.data.total_records;

            }

            var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_archived == true);
            if (dbdakType != null)
            {
                dakType.Id = dbdakType.Id;
                _daktype.Update(dakType);
            }
            else
            {
                _daktype.Insert(dakType);
            }

            _dakListService.SaveOrUpdateDakList(dakListArchiveResponse.data, dakType.Id);
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

        protected string GetDakListArchiveEndpoint()
        {
            return DefaultAPIConfiguration.DakListOnulipiEndPoint;
        }
    }
}

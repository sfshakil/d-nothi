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
    public class DakListSortedService : IDakListSortedService
    {
        IRepository<DakType> _daktype;
        IDakListService _dakListService { get; set; }
        public DakListSortedService(IRepository<DakType> daktype, IDakListService dakListService)
        {
            _daktype = daktype;
            _dakListService = dakListService;
        }
        public DakListSortedResponse GetDakList(DakListUserParam dakListUserParam)
        {
            try
            {
                var dakSortedApi = new RestClient(GetAPIDomain() + GetDakListSortedEndpoint());
                dakSortedApi.Timeout = -1;
                var dakSortedRequest = new RestRequest(Method.POST);
                dakSortedRequest.AddHeader("api-version", GetAPIVersion());
                dakSortedRequest.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                dakSortedRequest.AlwaysMultipartFormData = true;
                dakSortedRequest.AddParameter("designation_id", dakListUserParam.designation_id);
                dakSortedRequest.AddParameter("office_id", dakListUserParam.office_id);
                dakSortedRequest.AddParameter("page", dakListUserParam.page);
                dakSortedRequest.AddParameter("limit", dakListUserParam.limit);
                IRestResponse dakSortedResponse = dakSortedApi.Execute(dakSortedRequest);


                var dakSortedResponseJson = dakSortedResponse.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                DakListSortedResponse dakListSortedResponse = JsonConvert.DeserializeObject<DakListSortedResponse>(dakSortedResponseJson);
                return dakListSortedResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveorUpdateDakSorted(DakListSortedResponse dakListArchiveResponse)
        {

              DakType dakType = new DakType();
                dakType.is_outbox = true;
                if (dakListArchiveResponse.data != null)
                {
                    dakType.total_records = dakListArchiveResponse.data.total_records;

                }

                var dbdakType = _daktype.Table.FirstOrDefault(a => a.is_sorted == true);
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

        protected string GetDakListSortedEndpoint()
        {
            return DefaultAPIConfiguration.DakListSortedEndPoint;
        }
    }
}

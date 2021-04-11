using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class NothiTypeSaveService : INothiTypeSaveService
    {
        IRepository<NothiTypeItemAction> _nothiTypeItemAction;
        IUserService _userService { get; set; }
        public NothiTypeSaveService(IUserService userService, IRepository<NothiTypeItemAction> nothiTypeItemAction)
        {
            _userService = userService;
            _nothiTypeItemAction = nothiTypeItemAction;
        }
        public NothiTypeSaveResponse GetNothiTypeList(DakUserParam dakUserParam, string nothiDhoron, string nothiDhoronCode)
        {
            NothiTypeSaveResponse nothiTypeSaveResponse = new NothiTypeSaveResponse();
            if (!InternetConnection.Check())
            {
                nothiTypeSaveResponse.status = "success";
                nothiTypeSaveResponse.message = "Local";

                NothiTypeItemAction nothiTypeItemAction; //= _nothiTypeItemAction.Table.FirstOrDefault(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                nothiTypeItemAction = new NothiTypeItemAction();
                nothiTypeItemAction.designation_id = dakUserParam.designation_id;
                nothiTypeItemAction.office_id = dakUserParam.office_id;
                nothiTypeItemAction.nothiDhoron = nothiDhoron;
                nothiTypeItemAction.nothiDhoronCode = nothiDhoronCode;

                _nothiTypeItemAction.Insert(nothiTypeItemAction);
                //if (nothiTypeItemAction == null)
                //{
                    
                //}

                return nothiTypeSaveResponse;
            }

            try
                {
                    var client = new RestClient(GetAPIDomain() + GetNothiTypeCreateEndPoint());
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("api-version", GetAPIVersion());
                    request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                    request.AlwaysMultipartFormData = true;
                    request.AddParameter("office_id", +dakUserParam.office_id);
                    request.AddParameter("designation_id", +dakUserParam.designation_id);
                    request.AddParameter("model", "NothiTypes");
                    request.AddParameter("data", "{\"id\":0,\"type_name\":\""+nothiDhoron+"\",\"type_code\":\""+nothiDhoronCode+"\",\"type_last_number\":\"0\"}");
                    IRestResponse response = client.Execute(request);

                    var responseJson = response.Content;
                    nothiTypeSaveResponse = JsonConvert.DeserializeObject<NothiTypeSaveResponse>(responseJson);
                    return nothiTypeSaveResponse;
                }
                catch (Exception ex)
                {
                    throw;
                }
            
        }

        public bool SendNothiTypeListFromLocal()
        {
            bool isForwarded = false;
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            List<NothiTypeItemAction> nothiTypeItemActions = _nothiTypeItemAction.Table.Where(a => a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
            if (nothiTypeItemActions != null && nothiTypeItemActions.Count > 0)
            {
                foreach (NothiTypeItemAction nothiTypeItemAction in nothiTypeItemActions)
                {
                    var dakForwardResponse = GetNothiTypeList(dakUserParam, nothiTypeItemAction.nothiDhoron, nothiTypeItemAction.nothiDhoronCode);

                    if (dakForwardResponse != null && (dakForwardResponse.status == "error" || dakForwardResponse.status == "success"))

                    {
                        _nothiTypeItemAction.Delete(nothiTypeItemAction);
                        isForwarded = true;

                    }
                }
            }


            return isForwarded;
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

        protected string GetNothiTypeCreateEndPoint()
        {
            return DefaultAPIConfiguration.NothiTypeCreateEndPoint;
        }
        
    }
}

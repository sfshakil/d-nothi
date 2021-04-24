using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.DakServices;
using dNothi.Services.KasaraPatraDashBoardService.Models;
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
    public class PotrojariServices : IPotrojariServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;

        private readonly IPotrojariParser _potrojariParser;
        public PotrojariServices(IPotrojariParser potrojariParser, IRepository<PotrangshoNothiItem> nothiItem)
        {
            _potrojariParser = potrojariParser;
            _nothiItem = nothiItem;
        }
        public PotrojariResponse GetPotrojariListInfo(DakUserParam dakUserParam, long id)
        {
            PotrojariResponse potrojariResponse = new PotrojariResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                var nothiList = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

                if (nothiList != null)
                {
                    potrojariResponse = _potrojariParser.ParseMessage(nothiList.potrojarijsonResponse);
                    //allPotroResponse = JsonConvert.DeserializeObject<KhoshraPotroWaitingResponse>(nothiList.khoshrawaitingjsonResponse);

                }
                return potrojariResponse;
            }

            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiPotrangshoPotrojariEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParam.office_id + "\",\"office_unit_id\":\"" + dakUserParam.office_unit_id + "\",\"designation_id\":\"" + dakUserParam.designation_id + "\"}");
                request.AddParameter("nothi", "{\"nothi_id\":\"" + id + "\", \"nothi_office\":\"" + dakUserParam.office_id + "\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                SaveOrUpdateNothiRecords(dakUserParam, id, responseJson);
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                potrojariResponse = _potrojariParser.ParseMessage(responseJson);
                return potrojariResponse;

                //PotrojariResponse potrojariResponse = JsonConvert.DeserializeObject<PotrojariResponse>(responseJson);
                //return potrojariResponse;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void SaveOrUpdateNothiRecords(DakUserParam dakUserParam, long id, string responseJson)
        {
            var nothiListDB = _nothiItem.Table.FirstOrDefault(a => a.nothi_id == id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id);

            if (nothiListDB != null)
            {
                nothiListDB.potrojarijsonResponse = responseJson;
                _nothiItem.Update(nothiListDB);
            }
            else
            {
                PotrangshoNothiItem nothiItem = new PotrangshoNothiItem();
                nothiItem.nothi_id = id;
                nothiItem.designation_id = dakUserParam.designation_id;
                nothiItem.office_id = dakUserParam.office_id;
                nothiItem.potrojarijsonResponse = responseJson;
                _nothiItem.Insert(nothiItem);

            }
        }

        public PrapakerTalika GetPrapakerTalika(DakUserParam userParam, int potro)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetPrapakerTalikaEndPoint());
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");
                request.AddParameter("potro", potro);
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


        public PotroApproveResponse GetPotroOnumodonResponse(DakUserParam userParam, int potrojari_id, string potro_status, string potro_description)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetPotroOnumodonEndPoint());
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");
                  request.AddParameter("potro", "{\"potrojari_id\":\"" + potrojari_id + "\", \"potro_status\":\"" + potro_status + "\",\"potro_description\":\"" + potro_description + "\"}");
               // request.AddParameter("potro", "{\"potrojari_id\":\""+potrojari_id+"\", \"potro_status\":\""+potro_status+"\"}");

                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;

                PotroApproveResponse potroApproveResponse = JsonConvert.DeserializeObject<PotroApproveResponse>(responseJson);
                return potroApproveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public PotrojariCompleteResponse GetPotrojariResponse(DakUserParam userParam, PotrojariParameter potrojariParameter)
        {

            try
            {
                var Api = new RestClient(GetAPIDomain() + GetPotrojariEndPoint());
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                string potroJson = JsonParsingMethod.ObjecttoJson(potrojariParameter);


                request.AddParameter("cdesk", "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}");
                request.AddParameter("potro", potroJson);


                IRestResponse Response = Api.Execute(request);


                var responseJson = Response.Content;

                PotrojariCompleteResponse potrojariResponse = JsonConvert.DeserializeObject<PotrojariCompleteResponse>(responseJson);
                return potrojariResponse;
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

        protected string GetPotrojariEndPoint()
        {
            return DefaultAPIConfiguration.PotrojariEndPoint;
        }

        protected string GetPrapakerTalikaEndPoint()
        {
            return DefaultAPIConfiguration.prapakerTalika;
        }
        protected string GetPotroOnumodonEndPoint()
        {
            return DefaultAPIConfiguration.PotroOnumodonEndPoint;
        }


        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


       

        protected string GetNothiPotrangshoPotrojariEndPoint()
        {
            return DefaultAPIConfiguration.NothiPotrangshoPotrojariEndPoint;
        }
    }
}

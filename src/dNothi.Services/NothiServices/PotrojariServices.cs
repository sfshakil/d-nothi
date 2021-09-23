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
using Newtonsoft.Json.Linq;
using dNothi.Utility;
using dNothi.Core.Entities.Khosra;

namespace dNothi.Services.NothiServices
{
    public class PotrojariServices : IPotrojariServices
    {
        IRepository<PotrangshoNothiItem> _nothiItem;
        IRepository<kosraAnumodanLocal> _kosraAnumodanLocal;

        private readonly IPotrojariParser _potrojariParser;
        public PotrojariServices(IPotrojariParser potrojariParser,
            
            IRepository<PotrangshoNothiItem> nothiItem,
             IRepository<kosraAnumodanLocal> kosraAnumodanLocal)
        {
            _potrojariParser = potrojariParser;
            _nothiItem = nothiItem;
            _kosraAnumodanLocal = kosraAnumodanLocal;
        }
        public PotrojariResponse GetPotrojariListInfo(DakUserParam dakUserParam, long id, string potro_subject)
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
                request.AddParameter("length", "1000000000000");
                if (potro_subject != "")
                {
                    request.AddParameter("search_params", "potro_subject=" + potro_subject);
                }
                IRestResponse response = client.Execute(request);

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
            PrapakerTalika nothikhoshrapotrolist = new PrapakerTalika();
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
                try 
                {
                    nothikhoshrapotrolist = JsonConvert.DeserializeObject<PrapakerTalika>(responseJson);
                }
                catch
                {
                    var parseData = JToken.Parse(JsonConvert.SerializeObject(responseJson));
                    if (parseData.ToString().Contains("success"))
                    {
                        nothikhoshrapotrolist.status = "success";
                        nothikhoshrapotrolist.data = null;
                    }
                }
                return nothikhoshrapotrolist;
            }
            catch (Exception ex)
            {
                throw;
            }



        }


        public PotroApproveResponse GetPotroOnumodonResponse(DakUserParam userParam, int potrojari_id, string potro_status, string potro_description)
        {
            string cdesk = "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}";
            string potro = "{\"potrojari_id\":\"" + potrojari_id + "\", \"potro_status\":\"" + potro_status + "\",\"potro_description\":\"" + potro_description + "\"}";


            if (!InternetConnection.Check())
            {
                localKosraAnumodanSaveUpdate( potrojari_id, cdesk, potro,  potro_status);
                PotroApproveResponse potroApproveResponse = new PotroApproveResponse { status = "success", data="অনুমোদন দেয়া সফল হয়েছে।" };
                return potroApproveResponse;
            }


            else
            {
                return anumodan(cdesk, potro, userParam);
            }


        }
        private PotroApproveResponse anumodan(string cdesk, string potro,DakUserParam userParam)
        {
            try
            {
                var Api = new RestClient(GetAPIDomain() + GetPotroOnumodonEndPoint());
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;


                request.AddParameter("cdesk", cdesk);
                request.AddParameter("potro", potro);
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
        public bool SendAnumodanLocalDataTOServer(DakUserParam userParam)
        {
            string cdesk = "{\"office_id\":" + userParam.office_id + ",\"office_unit_id\":" + userParam.office_unit_id + ",\"designation_id\":" + userParam.designation_id + ",\"officer_id\":" + userParam.officer_id + ",\"user_id\":" + userParam.user_id + ",\"office\":\"" + userParam.office + "\",\"office_unit\":\"" + userParam.office_unit + "\",\"designation\":\"" + userParam.designation + "\",\"officer\":\"" + userParam.officer + "\",\"designation_level\":" + userParam.designation_level + "}";

            var localanumodanInsertDelete = _kosraAnumodanLocal.Table.Where(q => q.cdesk==cdesk).ToList();
            foreach(var item in localanumodanInsertDelete)
            {
                _kosraAnumodanLocal.Delete(item);
                //var response= anumodan(item.cdesk, item.potro, userParam);
                // if(response.status=="success")
                // {
                //     _kosraAnumodanLocal.Delete(item);
                // }
                // else
                // {
                //     _kosraAnumodanLocal.Delete(item);
                // }
            }
            return true;
        }
       private void localKosraAnumodanSaveUpdate(int potrojari_id,string cdesk,string potro,string potro_status)
        {
            var kosradata = _kosraAnumodanLocal.Table.Where(x => x.potrojari_id == potrojari_id).FirstOrDefault();
            if(kosradata!=null)
            {
                kosradata.potrojari_id = potrojari_id;
                kosradata.cdesk = cdesk;
                kosradata.potro = potro;
                kosradata.potro_status = potro_status;

                _kosraAnumodanLocal.Update(kosradata);
            }
            else
            {
                kosraAnumodanLocal kosra = new kosraAnumodanLocal
                {
                    cdesk = cdesk,
                    potro = potro,
                    potrojari_id = potrojari_id,
                    potro_status = potro_status
                };
                _kosraAnumodanLocal.Insert(kosra);
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
                responseJson = Utility.ConversionMethod.FilterJsonResponse(responseJson);
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

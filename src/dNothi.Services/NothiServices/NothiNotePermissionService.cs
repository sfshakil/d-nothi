using dNothi.Constants;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
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
    public class NothiNotePermissionService : INothiNotePermissionService
    {
        public NothiNotePermissionResponse GetNothiNotePermission(DakUserParam dakListUserParam, List<NothiOnumodonRowDTO> nothiOnumodonRows)
        {
            try
            {
                var client = new RestClient(GetAPIDomain() + GetNothiNotePermissionEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakListUserParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("cdesk", "{\"office_id\":\"" + dakListUserParam.office_id + "\",\"office_unit_id\":\"" + dakListUserParam.office_unit_id + "\",\"designation_id\":\"" + dakListUserParam.designation_id + "\",\"officer_id\":\"" + dakListUserParam.officer_id + "\",\"user_id\":\"" + dakListUserParam.user_id + "\",\"office\":\""+ dakListUserParam.office+ "\",\"office_unit\":\"" + dakListUserParam.office_unit + "\",\"designation\":\""+ dakListUserParam.designation+ "\",\"officer\":\""+ dakListUserParam.officer+ "\",\"designation_level\":\"" + dakListUserParam.designation_level + "\"}");

                foreach (NothiOnumodonRowDTO nothiOnumodonRow in nothiOnumodonRows)
                {
                    request.AddParameter("authority", "[{\"id\":\"" + nothiOnumodonRow.id + "\",\"office_id\":\"" + nothiOnumodonRow.office_id + "\",\"office_unit_id\":\"" + nothiOnumodonRow.office_unit_id + "\",\"designation_id\":\"" + nothiOnumodonRow.designation_id + "\",\"officer_id\":\"" + nothiOnumodonRow.officer_id + "\",\"office\":\"\\u098f\\u0995\\u09b8\\u09c7\\u09b8 \\u099f\\u09c1 \\u0987\\u09a8\\u09ab\\u09b0\\u09ae\\u09c7\\u09b6\\u09a8 (\\u098f\\u099f\\u09c1\\u0986\\u0987) \\u09aa\\u09cd\\u09b0\\u09cb\\u0997\\u09cd\\u09b0\\u09be\\u09ae\",\"office_unit\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"designation\":\"\\u09b8\\u09b2\\u09cd\\u09af\\u09c1\\u09b6\\u09a8 \\u0986\\u09b0\\u09cd\\u0995\\u09bf\\u099f\\u09c7\\u0995\\u09cd\\u099f\",\"officer\":\"\\u09ae\\u09cb\\u0983 \\u09b9\\u09be\\u09b8\\u09be\\u09a8\\u09c1\\u099c\\u09cd\\u099c\\u09be\\u09ae\\u09be\\u09a8\",\"designation_level\":\"" + nothiOnumodonRow.designation_level + "\",\"is_strict_route\":\"0\",\"is_signatory\":\"1\",\"max_transaction_day\":\"0\",\"layer_index\":\"1\",\"route_index\":\"1\"}]");
                }

                request.AddParameter("note", "{\"nothi_id\":\"2047\",\"nothi_office\":\"" + dakListUserParam.office_id + "\",\"nothi_office_name\":\"\\u098f\\u0995\\u09b8\\u09c7\\u09b8 \\u099f\\u09c1 \\u0987\\u09a8\\u09ab\\u09b0\\u09ae\\u09c7\\u09b6\\u09a8 (\\u098f\\u099f\\u09c1\\u0986\\u0987) \\u09aa\\u09cd\\u09b0\\u09cb\\u0997\\u09cd\\u09b0\\u09be\\u09ae\",\"other_office_id\":\"65\",\"nothi_note_id\":\"7279\"}");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                var responseJson = response.Content;
                //var data2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson2)["data"].ToString();
                // var rec = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2)["records"].ToString();
                NothiNotePermissionResponse nothiNotePermissionResponse = JsonConvert.DeserializeObject<NothiNotePermissionResponse>(responseJson);
                return nothiNotePermissionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        protected string GetNothiNotePermissionEndPoint()
        {
            return DefaultAPIConfiguration.NothiNotePermissionEndPoint;
        }
    }
}

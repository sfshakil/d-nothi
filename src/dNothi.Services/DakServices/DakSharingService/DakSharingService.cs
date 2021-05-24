using dNothi.Core.Entities;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static dNothi.Constants.DefaultAPIConfiguration;

namespace dNothi.Services.DakServices.DakSharingService
{
    public class DakSharingService<T> : IDakSharingService<T> where T : class
    {
        public ResponseModel Add(DakUserParam userParam,PrapokDTO assignee)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(3));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("assignor", "{\"office_id\":"+ userParam.office_id + ",\"office_name\":\""+userParam.office+"\",\"office_unit_id\":\""+userParam.office_unit_id+"\",\"office_unit_name\":\""+userParam.office_unit+"\",\"designation_id\":"+userParam.designation_id+",\"designation_level\":\""+userParam.designation_level+"\",\"name\":\""+userParam.officer_name+"\"}");
                request.AddParameter("assignee", "[{\"office_id\":" + assignee.office_id + ",\"office_name\":\""+assignee.office+"\",\"office_unit_id\":\""+assignee.office_unit_id+"\",\"office_unit_name\":\""+assignee.office_unit+"\",\"designation_id\":"+assignee.designation_id+",\"designation_level\":\""+assignee.designation_level+"\",\"name\":\""+assignee.officer_name+"\"}]");

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel Delete(DakUserParam userParam, int assignee_designation_id)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(4));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;

                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("assignee_designation_id", assignee_designation_id);

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetList(DakUserParam userParam, int actionLink,int assignor_designation_id)
        {
            try
            {
               
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(actionLink));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);


                request.AddHeader("Authorization", "Bearer " + userParam.token);

                request.AlwaysMultipartFormData = true;

                request.AddParameter("designation_id", userParam.designation_id);

                request.AddParameter("office_id", userParam.office_id);
                if (actionLink == 2)
                {
                    request.AddHeader("api-version", CommonSetting.GetAPIVersions());
                    request.AddParameter("assignor_designation_id", assignor_designation_id);
                    request.AddParameter("page", userParam.page);
                    request.AddParameter("limit", userParam.limit);

                }
                else
                {
                    request.AddHeader("api-version", CommonSetting.GetAPIVersion());

                    if (assignor_designation_id == 1)
                    {
                        request.AddParameter("assignee_designation_id", userParam.designation_id);

                    }
                    else
                    {
                        request.AddParameter("assignor_designation_id", userParam.designation_id);
                    }

                }

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                T responseData = JsonConvert.DeserializeObject<T>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel AddDakSorting(DakUserParam userParam, DakSorting daksortParam)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(6));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
              
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);

                

                string dakname = "daak_container_sorting_daak_box_" + daksortParam.is_copied_dak.ToString() + "_" + daksortParam.id.ToString() + "_" + daksortParam.dak_type;
               
                string dakSortingParam = ConversionMethod.ObjecttoJson(daksortParam);
                string dakInfoJson = "{\"" + dakname + "\":"+ dakSortingParam + "}";
                request.AddParameter("daks", dakInfoJson);
               // string d=\"recipients\":{\"mul_prapok\":{\"designation_bng\":\"\\u09a1\\u09cb\\u09ae\\u09c7\\u09a8 \\u09b8\\u09cd\\u09aa\\u09c7\\u09b6\\u09be\\u09b2\\u09bf\\u09b8\\u09cd\\u099f\",\"designation_eng\":\"\",\"designation_id\":\"12639\",\"unit_name_bng\":\"\\u09a8\\u09a5\\u09bf \",\"unit_name_eng\":\"Nothi \",\"unit_id\":\"5121\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09a8\\u09bf\\u09b2\\u09c1\\u09ab\\u09be \\u0987\\u09df\\u09be\\u09b8\\u09ae\\u09bf\\u09a8 \",\"employee_name_eng\":\"Nilufa Yasmin\",\"employee_record_id\":\"183124\",\"incharge_label\":\"\\u0985\\u09a4\\u09bf\\u09b0\\u09bf\\u0995\\u09cd\\u09a4 \\u09a6\\u09be\\u09df\\u09bf\\u09a4\\u09cd\\u09ac\"},\"onulipi\":{\"244873\":{\"designation_bng\":\"\\u099a\\u09c0\\u09ab \\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf \\u0985\\u09ab\\u09bf\\u09b8\\u09be\\u09b0\",\"designation_eng\":\"Chief Technology Officer\",\"designation_id\":\"244873\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u0986\\u09b0\\u09ab\\u09c7 \\u098f\\u09b2\\u09be\\u09b9\\u09c0\",\"employee_name_eng\":\"Mohammad Arfe Elahi\",\"employee_record_id\":\"77835\",\"incharge_label\":\"\"},\"244930\":{\"designation_bng\":\"\\u09b8\\u09b2\\u09cd\\u09af\\u09c1\\u09b6\\u09a8 \\u0986\\u09b0\\u09cd\\u0995\\u09bf\\u099f\\u09c7\\u0995\\u09cd\\u099f\",\"designation_eng\":\"Solution Architect\",\"designation_id\":\"244930\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u09b9\\u09be\\u09b8\\u09be\\u09a8\\u09c1\\u099c\\u09cd\\u099c\\u09be\\u09ae\\u09be\\u09a8\",\"employee_name_eng\":\"Mr. Md. Hasanuzzaman\",\"employee_record_id\":\"77858\",\"incharge_label\":\"\"}}}}}"
               // request.AddParameter("daks", "{\"daak_container_sorting_daak_box_1_6976_Daptorik\":{\"id\":\"6976\",\"dak_type\":\"Daptorik\",\"is_copied_dak\":\"1\",\"dak_subject\":\"\\u09a6\\u09be\\u09aa\\u09cd\\u09a4\\u09b0\\u09bf\\u0995 \\u09a1\\u09be\\u0995 \\u0986\\u09aa\\u09b2\\u09cb\\u09a1\",\"sender\":\"\\u099c\\u09be\\u09ab\\u09b0\\u09bf\\u09a8 \\u0986\\u09b9\\u09ae\\u09c7\\u09a6\",\"sending_date\":\"\\n                                        \\u09e6\\u09e7-\\u09e6\\u09e7-\\u09e7\\u09ef\\u09ed\\u09e6 \\u09e6\\u09e6:\\u09e6\\u09e6:\\u09e6\\u09e6                                    \",\"decision\":\"Test Decision\",\"priority\":\"6\",\"security\":\"5\",\"recipients\":{\"mul_prapok\":{\"designation_bng\":\"\\u09a1\\u09cb\\u09ae\\u09c7\\u09a8 \\u09b8\\u09cd\\u09aa\\u09c7\\u09b6\\u09be\\u09b2\\u09bf\\u09b8\\u09cd\\u099f\",\"designation_eng\":\"\",\"designation_id\":\"12639\",\"unit_name_bng\":\"\\u09a8\\u09a5\\u09bf \",\"unit_name_eng\":\"Nothi \",\"unit_id\":\"5121\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09a8\\u09bf\\u09b2\\u09c1\\u09ab\\u09be \\u0987\\u09df\\u09be\\u09b8\\u09ae\\u09bf\\u09a8 \",\"employee_name_eng\":\"Nilufa Yasmin\",\"employee_record_id\":\"183124\",\"incharge_label\":\"\\u0985\\u09a4\\u09bf\\u09b0\\u09bf\\u0995\\u09cd\\u09a4 \\u09a6\\u09be\\u09df\\u09bf\\u09a4\\u09cd\\u09ac\"},\"onulipi\":{\"244873\":{\"designation_bng\":\"\\u099a\\u09c0\\u09ab \\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf \\u0985\\u09ab\\u09bf\\u09b8\\u09be\\u09b0\",\"designation_eng\":\"Chief Technology Officer\",\"designation_id\":\"244873\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u0986\\u09b0\\u09ab\\u09c7 \\u098f\\u09b2\\u09be\\u09b9\\u09c0\",\"employee_name_eng\":\"Mohammad Arfe Elahi\",\"employee_record_id\":\"77835\",\"incharge_label\":\"\"},\"244930\":{\"designation_bng\":\"\\u09b8\\u09b2\\u09cd\\u09af\\u09c1\\u09b6\\u09a8 \\u0986\\u09b0\\u09cd\\u0995\\u09bf\\u099f\\u09c7\\u0995\\u09cd\\u099f\",\"designation_eng\":\"Solution Architect\",\"designation_id\":\"244930\",\"unit_name_bng\":\"\\u099f\\u09c7\\u0995\\u09a8\\u09cb\\u09b2\\u099c\\u09bf\",\"unit_name_eng\":\"Technology\",\"unit_id\":\"40372\",\"office_name_eng\":\"\",\"office_name_bng\":\"\",\"office_id\":\"65\",\"employee_name_bng\":\"\\u09ae\\u09cb\\u0983 \\u09b9\\u09be\\u09b8\\u09be\\u09a8\\u09c1\\u099c\\u09cd\\u099c\\u09be\\u09ae\\u09be\\u09a8\",\"employee_name_eng\":\"Mr. Md. Hasanuzzaman\",\"employee_record_id\":\"77858\",\"incharge_label\":\"\"}}}}}");
               // request.AddParameter("office_id", "{{office_id}}");
                request.AddParameter("dak_inbox_designation_id", daksortParam.dak_inbox_designation_id);
               // request.AddParameter("designation_id", "{{designation_id}}");


                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel DakSortingDelete(DakUserParam userParam, DakSorting daksortParam)
        {
            try
            {
                var Api = new RestClient(CommonSetting.GetAPIDomain() + CommonSetting.GetEndPoint(7));
                Api.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", CommonSetting.GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + userParam.token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("daks", "[{\"id\":\"6179\",\"dak_type\":\"Daptorik\",\"is_copied_dak\":\"1\"}]");
                request.AddParameter("office_id", userParam.office_id);
                request.AddParameter("designation_id", userParam.designation_id);
                request.AddParameter("dak_inbox_designation_id", "149239");

                IRestResponse Response = Api.Execute(request);

                var responseJson = Response.Content;

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(responseJson);
                return responseData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //DakSortingDelete
        
       

    }
}

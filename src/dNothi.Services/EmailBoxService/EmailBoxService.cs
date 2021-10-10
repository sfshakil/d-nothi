using dNothi.Constants;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.JsonParser.Entity.Email;
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

namespace dNothi.Services.EmailBoxService
{
   public class EmailBoxService:IEmailBoxService
    {
        IRepository<EmailList> _emailList;
        public EmailBoxService(IRepository<EmailList> emailList)
        {
            _emailList = emailList;
        }
        public SendEmailResponse GetSentEmailBox(DakUserParam dakUserParameter, List<string> actionTypes, string dateRange )
        {
            SendEmailResponse sendEmailResponse = new SendEmailResponse();
            if (!dNothi.Utility.InternetConnection.Check())
            {
                
                string response = GetSendEmailResponse(dakUserParameter, dateRange, ConversionMethod.ObjecttoJson(actionTypes));

                if (response != null)
                {
                    sendEmailResponse = JsonConvert.DeserializeObject<SendEmailResponse>(ConversionMethod.FilterJsonResponse(response));
                  
                   
                }
                return sendEmailResponse;
            }

            try
            {


                var emailBoxAPI = new RestClient(GetAPIDomain() + GetEmailBoxEndPoint());
                emailBoxAPI.Timeout = -1;
                var emailBoxRequest = new RestRequest(Method.POST);
                emailBoxRequest.AddHeader("api-version", GetAPIVersion());
                emailBoxRequest.AddHeader("Authorization", "Bearer " + dakUserParameter.token);
                emailBoxRequest.AlwaysMultipartFormData = true;
                emailBoxRequest.AddParameter("cdesk", "{\"office_id\":\"" + dakUserParameter.office_id + "\",\"officer\":\"" + dakUserParameter.officer + "\",\"designation\":\"" + dakUserParameter.designation + "\",\"user_id\":\"" + dakUserParameter.user_id + "\",\"office_unit_id\":\"" + dakUserParameter.office_unit_id + "\",\"designation_level\":\"" + dakUserParameter.designation_level + "\",\"designation_sequence\":\"" + dakUserParameter.designation_label + "\",\"officer_email\":\"" + dakUserParameter.officer_email + "\",\"officer_mobile\":\"" + dakUserParameter.officer_mobile + "\",\"designation_id\":\"" + dakUserParameter.designation_id + "\"}");
                emailBoxRequest.AddParameter("page", dakUserParameter.page);
                emailBoxRequest.AddParameter("length", dakUserParameter.limit);
                if(!String.IsNullOrEmpty(dateRange))
                {
                    emailBoxRequest.AddParameter("date_range", dateRange);
                }

                if(actionTypes !=null && actionTypes.Count>0)
                {
                    emailBoxRequest.AddParameter("action_type",ConversionMethod.ObjecttoJson(actionTypes));
                }

               

                IRestResponse emailBoxResponse = emailBoxAPI.Execute(emailBoxRequest);

                var emailBoxResponseJson = emailBoxResponse.Content;
                
               
                
                 sendEmailResponse = JsonConvert.DeserializeObject<SendEmailResponse>(ConversionMethod.FilterJsonResponse(emailBoxResponseJson));
                 SaveOrUpdateEmailListJsonResponse(dakUserParameter, emailBoxResponseJson, dateRange, ConversionMethod.ObjecttoJson(actionTypes));

                return sendEmailResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SaveOrUpdateEmailListJsonResponse(DakUserParam dakUserParameter, string sendEmailResponse, string dateRange, string action_type)
        {
            EmailList emailList = _emailList.Table.FirstOrDefault(a => a.page == dakUserParameter.page  && a.is_prerito_email == true && a.office_id == dakUserParameter.office_id && a.designation_id == dakUserParameter.designation_id && a.date_range==dateRange && a.action_type== action_type);

            if (emailList != null)
            {
                emailList.email_list_response = sendEmailResponse;
                _emailList.Update(emailList);
            }
            else
            {
                emailList = new EmailList();
                emailList.is_prerito_email = true;
                emailList.page = dakUserParameter.page;
                emailList.designation_id = dakUserParameter.designation_id;
                emailList.office_id = dakUserParameter.office_id;
                emailList.email_list_response = sendEmailResponse;
                emailList.action_type = action_type;
                emailList.date_range = dateRange;
                _emailList.Insert(emailList);

            }
        }

        private string GetSendEmailResponse(DakUserParam dakUserParameter, string dateRange, string action_type)
        {
            EmailList emailList = _emailList.Table.FirstOrDefault(a => a.page == dakUserParameter.page && a.is_prerito_email == true && a.office_id == dakUserParameter.office_id && a.designation_id == dakUserParameter.designation_id && a.date_range == dateRange && a.action_type == action_type);

           if(emailList!=null)
            {
                return emailList.email_list_response;
            }
            return null;
           
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

        protected string GetEmailBoxEndPoint()
        {
            return DefaultAPIConfiguration.EmailBoxEndPoint;
        }
    }
    public interface IEmailBoxService
    {
        SendEmailResponse GetSentEmailBox(DakUserParam dakUserParameter, List<string> actionTypes, string dateRange);
    }

}

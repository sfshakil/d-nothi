using dNothi.Constants;
using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.ProfileChangeService
{
  public  class ProfileManagementServices: IProfileManagementServices
    {
        public PasswordChangeResponse GetPasswordChangeResponse(DakUserParam dakUserParam, PasswordChangeParam passwordChangeParam)
        {
            try
            {
                var client = new RestClient(DefaultAPIConfiguration.DoptorDomainAddress+DefaultAPIConfiguration.DoptorPasswordChangeEndPoint);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.doptor_token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("username", dakUserParam.loginId);
                request.AddParameter("old_password", passwordChangeParam.oldPassword);
                request.AddParameter("new_password", passwordChangeParam.newPassword);
                IRestResponse response = client.Execute(request);

                PasswordChangeResponse apiResponse = JsonConvert.DeserializeObject<PasswordChangeResponse>(response.Content);

                return apiResponse;
            }
            catch
            {
                PasswordChangeResponse passwordChangeResponse = new PasswordChangeResponse();
              
                return passwordChangeResponse;
            }
        }

        public PasswordChangeResponse GetPhotoChangeResponse(DakUserParam dakUserParam, string image)
        {
            try
            {
                var client = new RestClient(DefaultAPIConfiguration.DoptorDomainAddress + DefaultAPIConfiguration.DoptorPhotoChangeEndPoint);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.doptor_token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("username", dakUserParam.loginId);
                request.AddFile("image",image);
                IRestResponse response = client.Execute(request);

                PasswordChangeResponse apiResponse = JsonConvert.DeserializeObject<PasswordChangeResponse>(response.Content);

                return apiResponse;
            }
            catch
            {
                PasswordChangeResponse passwordChangeResponse = new PasswordChangeResponse();

                return passwordChangeResponse;
            }
        }
        public PasswordChangeResponse GetSignatureChangeResponse(DakUserParam dakUserParam, String filePath)
        {
            try
            {
                var client = new RestClient(DefaultAPIConfiguration.DoptorDomainAddress + DefaultAPIConfiguration.DoptorSignChangeEndPoint);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", "1");
                request.AddHeader("Authorization", "Bearer " + dakUserParam.doptor_token);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("username", dakUserParam.loginId);
                request.AddFile("image", filePath);
                IRestResponse response = client.Execute(request);

                PasswordChangeResponse apiResponse = JsonConvert.DeserializeObject<PasswordChangeResponse>(response.Content);

                return apiResponse;
            }
            catch
            {
                PasswordChangeResponse passwordChangeResponse = new PasswordChangeResponse();

                return passwordChangeResponse;
            }
        }

    }
    public interface IProfileManagementServices
    {
        PasswordChangeResponse GetPasswordChangeResponse(DakUserParam dakUserParam, PasswordChangeParam passwordChangeParam);
        PasswordChangeResponse GetPhotoChangeResponse(DakUserParam dakUserParam, String filePath);
        PasswordChangeResponse GetSignatureChangeResponse(DakUserParam dakUserParam, String filePath);
    }
}

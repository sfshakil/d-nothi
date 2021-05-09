using dNothi.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices.DakSharingService
{
   public   class CommonSetting
    {
        public static string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        public static string GetEndPoint(int actionLink)
        {
            string endPoint = string.Empty;
           
            //  as actionLink;
            if (actionLink == 1)
            {
                endPoint = DefaultAPIConfiguration.SharingList;
            }
            if (actionLink == 2)
            {
                endPoint = DefaultAPIConfiguration.DakInbox;
            }
            if (actionLink == 3)
            {
                endPoint = DefaultAPIConfiguration.SharingAdd;
            }
            if (actionLink == 4)
            {
                 
                endPoint = DefaultAPIConfiguration.SharingDelete;
            }
            if (actionLink == 5)
            {

                endPoint = DefaultAPIConfiguration.DakFileUploadEndPoint;
            }

            return endPoint; 
        }
        public static string GetAPIVersion()
        {
           // return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
            return  DefaultAPIConfiguration.DefaultAPIversion;
        }
        public static string GetAPIVersions()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
            // return  DefaultAPIConfiguration.DefaultAPIversion;
        }
        public static string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}

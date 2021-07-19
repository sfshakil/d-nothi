using dNothi.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services
{
   public class CommonSetting
    {
        public static string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

      
        public static string GetAPIVersion()
        {
            return ReadAppSettings("newapi-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
            
        }
        public static string GetAPIVersions()
        {
           
            return DefaultAPIConfiguration.DefaultAPIversion;
        }
        public static string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

      
    }
}

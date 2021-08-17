using dNothi.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.PotroJariGroup
{
   public class ApiEndPoint
    {
        public static string GetEndPoint(int actionLink)
        {
            string endPoint = DefaultAPIConfiguration.potraJariTalikaEndpoint;
           
            if (actionLink == 1)
            {
                endPoint = DefaultAPIConfiguration.potraJariTalikaEndpoint;
            }
            if (actionLink == -1)
            {
                endPoint = DefaultAPIConfiguration.potraJariTalikaDistrictCommissionerEndpoint;
            }
            if (actionLink == -2)
            {
                endPoint = DefaultAPIConfiguration.potraJariTalikaDeputyCommissionerEndpoint;
            }
            if (actionLink == -3)
            {
                 
                endPoint = DefaultAPIConfiguration.potraJariTalikaUNOEndpoint;
            }
            if (actionLink == -4)
            {

                endPoint = DefaultAPIConfiguration.potraJariTalikaOfficeHeadEndpoint;
            }
            if (actionLink == -5)
            {

                endPoint = DefaultAPIConfiguration.potraJariTalikaOfficeAdminEndpoint;
            }

            return endPoint; 
        }
      

    }
}

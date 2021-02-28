using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public class ThirdPartyServiceList
    {
       
           public List<ThirdPartyService> thirdPartyServices = new List<ThirdPartyService>();

            public ThirdPartyServiceList()
            {
            thirdPartyServices.Add(new ThirdPartyService("0", "সার্ভিস", "সার্ভিস-PNG1"));
            thirdPartyServices.Add(new ThirdPartyService("3", "অভিযোগপত্র দায়ের ফরম - BSAP", "-PNG1"));


            }

            public string GetThirdPartyServicesIcon(string id)
            {
            ThirdPartyService thirdPartyServiceIcon = thirdPartyServices.FirstOrDefault(a => a._id == id);

                if (thirdPartyServiceIcon != null)
                {
                    return thirdPartyServiceIcon._icon;
                }
                else
                {
                    return "";
                }
            }
            public string GetThirdPartyServicesName(string id)
            {
            ThirdPartyService thirdPartyService = thirdPartyServices.FirstOrDefault(a => a._id == id);
                if (thirdPartyService != null)
                {
                    return thirdPartyService._typeName;
                }
                else
                {
                    return "";
                }

            }


        }

        public class ThirdPartyService
    {

            public string _id { get; set; }
            public string _typeName { get; set; }
            public string _icon { get; set; }

            public ThirdPartyService(string id, string typeName, string icon)
            {
                _id = id;
                _typeName = typeName;
                _icon = icon;
            }


        }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public class DakSecurityList
    {
        List<DakSecurity> _dakSecurities = new List<DakSecurity>();

        public DakSecurityList()
        {
            _dakSecurities.Add(new DakSecurity("2", "সীমিত", "সীমিত"));
            _dakSecurities.Add(new DakSecurity("3", "গোপনীয়", "গোপনীয়"));
            _dakSecurities.Add(new DakSecurity("4", "বিশেষ গোপনীয়", "বিশেষ গোপনীয়"));
            _dakSecurities.Add(new DakSecurity("5", "অতি গোপনীয়", "অতি গোপনীয়"));


        }

        public string GetDakSecuritiesIcon(string id)
        {
            DakSecurity dakSecurity = _dakSecurities.FirstOrDefault(a => a._id == id);
            if(dakSecurity != null)
            {
                return dakSecurity._icon;
            }
            else
            {
                return "";
            }
            
        }
        public string GetDakSecuritiesName(string id)
        {
            DakSecurity dakSecurity = _dakSecurities.FirstOrDefault(a => a._id == id);

            if (dakSecurity != null)
            {
                return dakSecurity._typeName;
            }
            else
            {
                return "";
            }
        }

    }

    public class DakSecurity
    {

        public string _id { get; set; }
        public string _typeName { get; set; }
        public string _icon { get; set; }

        public DakSecurity(string id, string typeName, string icon)
        {
            _id = id;
            _typeName = typeName;
            _icon = icon;
        }


    }
}


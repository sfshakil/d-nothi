﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public class DakSecurityList
    {
       public  List<DakSecurity> _dakSecurities = new List<DakSecurity>();

        public DakSecurityList()
        {
            _dakSecurities.Add(new DakSecurity("2", "সীমিত", "সীমিত-Icon-PNG2"));
            _dakSecurities.Add(new DakSecurity("3", "গোপনীয়", "গোপনীয়-Icon-PNG"));
            _dakSecurities.Add(new DakSecurity("4", "বিশেষ গোপনীয়", "বিশেষ গোপনীয়-Icon-PNG"));
            _dakSecurities.Add(new DakSecurity("5", "অতি গোপনীয়", "অতি গোপনীয়-Icon-PNG"));
           // _dakSecurities.Add(new DakSecurity("0", "বাছাই করুন", ""));


        }
        public DakSecurityList(bool isCombobox)
        {
            _dakSecurities.Add(new DakSecurity("2", "সীমিত", "সীমিত-Icon-PNG2"));
            _dakSecurities.Add(new DakSecurity("3", "গোপনীয়", "গোপনীয়-Icon-PNG"));
            _dakSecurities.Add(new DakSecurity("4", "বিশেষ গোপনীয়", "বিশেষ গোপনীয়-Icon-PNG"));
            _dakSecurities.Add(new DakSecurity("5", "অতি গোপনীয়", "অতি গোপনীয়-Icon-PNG"));
            _dakSecurities.Add(new DakSecurity("0", "বাছাই করুন", ""));


        }

        public string GetDakSecuritiesIcon(string id)
        {
            DakSecurity dakSecurity = _dakSecurities.FirstOrDefault(a => a._id == id);
            if (id == "0")
            {
                return "";
            }

            if (dakSecurity != null)
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
        public string GetDakSecuritiesId(string Name)
        {
            DakSecurity dakSecurity = _dakSecurities.FirstOrDefault(a => a._typeName == Name);

            if (dakSecurity != null)
            {
                return dakSecurity._id;
            }
            else
            {
                return "0";
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


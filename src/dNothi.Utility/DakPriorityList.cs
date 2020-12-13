using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public class DakPriorityList
    {
       public List<DakPriority> _dakPriority = new List<DakPriority>();

        public DakPriorityList()
        {
            _dakPriority.Add(new DakPriority("6", "সর্বোচ্চ অগ্রাধিকার", "সর্বোচ্চ অগ্রাধিকার"));
            _dakPriority.Add(new DakPriority("5", "অবিলম্বে", "অবিলম্বে"));
            _dakPriority.Add(new DakPriority("4", "জরুরি", "জরুরি"));
            _dakPriority.Add(new DakPriority("4", "তাগিদপত্র", "তাগিদপত্র"));
            _dakPriority.Add(new DakPriority("3", "দৃষ্টি আকর্ষণ", "দৃষ্টি আকর্ষণ"));
           

        }

        public string GetDakPriorityIcon(string id)
        {
            DakPriority dakPriority = _dakPriority.FirstOrDefault(a => a._id == id);
            if (dakPriority != null)
            {
                return dakPriority._icon;
            }
            else
            {
                return "";
            }

        }
        public string GetDakPriorityName(string id)
        {
            DakPriority dakPriority = _dakPriority.FirstOrDefault(a => a._id == id);

            if (dakPriority != null)
            {
                return dakPriority._typeName;
            }
            else
            {
                return "";
            }
        }

        public string GetDakPrioritiesId(string Name)
        {
            DakPriority dakPriority = _dakPriority.FirstOrDefault(a => a._typeName == Name);

            if (dakPriority != null)
            {
                return dakPriority._id;
            }
            else
            {
                return "0";
            }
        }
    }
    public class DakPriority
    {

        public string _id { get; set; }
        public string _typeName { get; set; }
        public string _icon { get; set; }

        public DakPriority(string id, string typeName, string icon)
        {
            _id = id;
            _typeName = typeName;
            _icon = icon;
        }


    }
}

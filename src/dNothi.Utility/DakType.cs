using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   

    public class DakTypeList
    {
       public List<DakType> _dakTypes = new List<DakType>();

        public DakTypeList()
        {
            _dakTypes.Add(new DakType("", "ডাকের ধরণ", ""));
            _dakTypes.Add(new DakType("দাপ্তরিক", "দাপ্তরিক", ""));
            _dakTypes.Add(new DakType("নাগরিক", "নাগরিক", ""));

        }

        public string GetDakTypeIcon(string id)
        {
            DakType dakType = _dakTypes.FirstOrDefault(a => a._id == id);
            if (dakType != null)
            {
                return dakType._icon;
            }
            else
            {
                return "";
            }

        }
        public string GetDakTypeName(string id)
        {
            DakType dakType = _dakTypes.FirstOrDefault(a => a._id == id);

            if (dakType != null)
            {
                return dakType._typeName;
            }
            else
            {
                return "";
            }
        }
        public string GetDakTypeId(string Name)
        {
            DakType dakType = _dakTypes.FirstOrDefault(a => a._typeName == Name);

            if (dakType != null)
            {
                return dakType._id;
            }
            else
            {
                return "0";
            }
        }

    }

    public class DakType
    {

        public string _id { get; set; }
        public string _typeName { get; set; }
        public string _icon { get; set; }

        public DakType(string id, string typeName, string icon)
        {
            _id = id;
            _typeName = typeName;
            _icon = icon;
        }


    }
}

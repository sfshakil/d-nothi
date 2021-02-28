using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
    public class DakStatusList
    {
       public List<DakStatus> _dakStatus = new List<DakStatus>();

        public DakStatusList()
        {
            _dakStatus.Add(new DakStatus("", "সকল", ""));
            _dakStatus.Add(new DakStatus("New", "অপঠিত", ""));
            _dakStatus.Add(new DakStatus("View", "পঠিত", ""));
            _dakStatus.Add(new DakStatus("mul_prapok", "মূল-প্রাপক", ""));
            _dakStatus.Add(new DakStatus("onulipi", "অনুলিপি", ""));
           


        }

        public string GetDakStatusIcon(string id)
        {
            DakStatus dakStatus = _dakStatus.FirstOrDefault(a => a._id == id);
            if (dakStatus != null)
            {
                return dakStatus._icon;
            }
            else
            {
                return "";
            }

        }
        public string GetDakStatusName(string id)
        {
            DakStatus dakStatus = _dakStatus.FirstOrDefault(a => a._id == id);

            if (dakStatus != null)
            {
                return dakStatus._typeName;
            }
            else
            {
                return "";
            }
        }
        public string GetDakStatusId(string Name)
        {
            DakStatus dakStatus = _dakStatus.FirstOrDefault(a => a._typeName == Name);

            if (dakStatus != null)
            {
                return dakStatus._id;
            }
            else
            {
                return "0";
            }
        }

    }

    public class DakStatus
    {

        public string _id { get; set; }
        public string _typeName { get; set; }
        public string _icon { get; set; }

        public DakStatus(string id, string typeName, string icon)
        {
            _id = id;
            _typeName = typeName;
            _icon = icon;
        }


    }
}

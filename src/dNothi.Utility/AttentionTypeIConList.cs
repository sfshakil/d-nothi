using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
    public class AttentionTypeList
    {
        List<AttentionType> attentionTypes = new List<AttentionType>();

       public AttentionTypeList()
        {
            attentionTypes.Add(new AttentionType("0", "জ্ঞাতার্থে অনুলিপি", "অনুলিপি-PNG1"));
            attentionTypes.Add(new AttentionType("1", "মূল-প্রাপক", "মূল-প্রাপক-PNG1"));
            attentionTypes.Add(new AttentionType("2", "দৃষ্টি আকর্ষণ", "মূল-প্রাপক-PNG1"));
            attentionTypes.Add(new AttentionType("3", "কার্যার্থে অনুলিপি", "মূল-প্রাপক-PNG1"));
           
        }

        public string GetAttentionTypeIcon(string id)
        {
            AttentionType attentionTypeIcon = attentionTypes.FirstOrDefault(a => a._id == id);

            if (attentionTypeIcon != null)
            {
                return attentionTypeIcon._icon;
            }
            else
            {
                return "";
            }
        }
        public string GetAttentionTypeName(string id)
        {
            AttentionType attentionType = attentionTypes.FirstOrDefault(a => a._id == id);
            if(attentionType != null)
            {
                return attentionType._typeName;
            }
            else
            {
                return "মূল-প্রাপক";
            }
           
        }
      

    }

    public class AttentionType
    {
    
    public string _id { get; set; } 
    public string _typeName { get; set; } 
    public string _icon { get; set; } 
    
      public  AttentionType(string id, string typeName, string icon  )
        {
            _id = id;
            _typeName = typeName;
            _icon = icon;
        }


    }

}

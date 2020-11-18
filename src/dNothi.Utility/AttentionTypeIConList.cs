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
            attentionTypes.Add(new AttentionType("0", "অনুলিপি", "Anulipiu"));
            attentionTypes.Add(new AttentionType("1", "মূল-প্রাপক", "MulPrapok"));

           
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
                return "";
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

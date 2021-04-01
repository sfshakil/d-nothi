using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace dNothi.JsonParser
{
   public class JsonParsingMethod
    {
        public static string ObjecttoJson(object obj)
        {
            var jsonString = new JavaScriptSerializer().Serialize(obj);
            return jsonString;
        }
    }
}

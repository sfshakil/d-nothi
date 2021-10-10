using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ReportCategoryData
    {
        public int id { get; set; }
        public int serialNumber { get; set; }
        public string name { get; set; }
        public int serial { get; set; }
        public object offices { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string device_id { get; set; }
        public string device_type { get; set; }
    }

    public class ReportCategoryResponse
    {
        public string status { get; set; }
        public List<ReportCategoryData> data { get; set; }
        public List<object> options { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public int serial { get; set; }
    }
    public class ReportCategorySerialUpdateResponse
    {
        public string status { get; set; }
        public string data { get; set; }
        public List<object> options { get; set; }
    }
    public class ReportCategoryDeleteResponse
    {
        public string status { get; set; }
        public string data { get; set; }
        public List<object> options { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ReportCategoryAddData
    {
        public string type { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public int serial { get; set; }
        public string offices { get; set; }
        public string name { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public string modified { get; set; }
        public string created { get; set; }
        public string device_type { get; set; }
        public string device_id { get; set; }
        public int id { get; set; }
    }

    public class ReportCategoryAddResponse
    {
        public string status { get; set; }
        public ReportCategoryAddData data { get; set; }
        public int id { get; set; }
        public string message { get; set; }
    }



}

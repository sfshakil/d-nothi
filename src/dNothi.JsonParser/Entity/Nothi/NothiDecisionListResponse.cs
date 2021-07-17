using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    
    public class NothiDecisionListResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public DataDTO Data { get; set; }

        [JsonProperty("options")]
        public object[] Options { get; set; }
    }

    public class DataDTO
    {
        [JsonProperty("records")]
        public Dictionary<string, string> Records { get; set; }

        [JsonProperty("total_records")]
        public long TotalRecords { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class GaurdFileAttachment
    {
        public int id { get; set; }
        public int guard_file_id { get; set; }
        public string name_bng { get; set; }
        public string attachment_type { get; set; }
        public string user_file_name { get; set; }
        public string file_name { get; set; }
        public string file_custom_name { get; set; }
        public string file_dir { get; set; }
        public double file_size_in_kb { get; set; }
        public string created { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public string thumb_url { get; set; }
    }

    public class GaurdFileRecord
    {
        public string name_bng { get; set; }
        public int id { get; set; }
        public int file_number { get; set; }
        public string office_name { get; set; }
        public string office_unit_name { get; set; }
        public int office_unit_organogram_id { get; set; }
        public int guard_file_category_id { get; set; }
        public string guard_file_category_name_bng { get; set; }
        public GaurdFileAttachment attachment { get; set; }
    }

    public class GaurdFileData
    {
        public List<GaurdFileRecord> records { get; set; }
        public int total_records { get; set; }
    }

    public class NothiGaurdFileListResponse
    {
        public string status { get; set; }
        public GaurdFileData data { get; set; }
        public List<object> options { get; set; }
    }


}

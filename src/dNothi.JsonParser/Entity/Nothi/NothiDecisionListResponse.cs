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
}

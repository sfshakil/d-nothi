using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class onumodonDataRecordDTO
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_office { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int designation_id { get; set; }
        public string nothi_office_name { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public int designation_level { get; set; }
    
        [JsonProperty("created")]
        public string createDate { get; set; }
        public string modified { get; set; }
        public int is_strict_route { get; set; }
        public int route_index { get; set; }
        public int max_transaction_day { get; set; }
        public int layer_index { get; set; }
        public int is_active { get; set; }
        public int officer_id { get; set; }
        public string officer { get; set; }
        public string incharge_label { get; set; }
        public string level_name { get; set; }
        public int designation_sequence { get; set; }
        public int extra { get; set; }
        public int is_signatory { get; set; }
    }
}

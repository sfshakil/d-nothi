using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak_List_Inbox
{
   public class OtherDTO
    {
        public string operation_type { get; set; }
        public string last_movement_date { get; set; }
        public int dak_priority { get; set; }
        public string dak_security_level { get; set; }
        public int sequence { get; set; }
        public string dak_actions { get; set; }
        public int docketing_no { get; set; }

        [JsonProperty("id")]
        public string dak_origin_id { get; set; }


       
    }
}

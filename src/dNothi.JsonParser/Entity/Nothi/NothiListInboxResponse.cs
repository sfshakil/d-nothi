using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiListInboxResponse
    {
        public string status { get; set; }
        public NothiListInboxDTO data { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class OthersOfficeNothiListInboxDataRecord
    {
        public int id { get; set; }
        public int office_id { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string office_designation_name { get; set; }
        public string nothi_no { get; set; }
        public string subject { get; set; }
        public int nothi_class { get; set; }
        public string modified { get; set; }
        public string last_note_date { get; set; }
        public string priority { get; set; }
        public int note_count { get; set; }
    }

    public class OthersOfficeNothiListInboxData
    {
        public List<OthersOfficeNothiListInboxDataRecord> records { get; set; }
        public int total_records { get; set; }
    }

    public class OthersOfficeNothiListInboxResponse
    {
        public string status { get; set; }
        public OthersOfficeNothiListInboxData data { get; set; }
        public List<object> options { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.BasicService.Models
{
    public class dakTrakingModel
    {
        public class Nothi
        {
            public int nothi_master_id { get; set; }
            public int nothi_note_id { get; set; }
            public int nothi_potro_id { get; set; }
            public int dak_id { get; set; }
            public string dak_type { get; set; }
            public int is_copied_dak { get; set; }
            public int id { get; set; }
            public string nothi_no { get; set; }
            public string subject { get; set; }
            public int office_id { get; set; }
            public string office_name { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_name { get; set; }
        }

        public class Record
        {
            public int dak_id { get; set; }
            public string dak_type { get; set; }
            public int is_copied_dak { get; set; }
            public string office { get; set; }
            public string office_unit { get; set; }
            public string dak_origin { get; set; }
            public bool from_potrojari { get; set; }
            public string dak_view_status { get; set; }
            public string attention_type { get; set; }
            public string dak_priority { get; set; }
            public string dak_security { get; set; }
            public int dak_movement_sequence { get; set; }
            public string last_movement_date { get; set; }
            public string dak_category { get; set; }
            public string dak_receipt_no { get; set; }
            public string dak_subject { get; set; }
            public string dak_decision { get; set; }
            public object drafted_decisions { get; set; }
            public string modified { get; set; }
            public Nothi nothi { get; set; }
        }

        public class Data
        {
            public List<Record> records { get; set; }
            public int total_records { get; set; }
        }

        
            public string status { get; set; }
            public Data data { get; set; }
            public List<object> options { get; set; }
       
    }
}

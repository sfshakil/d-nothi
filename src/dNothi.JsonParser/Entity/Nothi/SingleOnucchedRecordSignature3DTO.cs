using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class SingleOnucchedRecordSignature3DTO
    {
        public int id { get; set; }
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int office_unit_organogram_id { get; set; }
        public int employee_id { get; set; }
        public string office_name { get; set; }
        public string office_unit_name { get; set; }
        public string designation_name { get; set; }
        public string employee_name { get; set; }
        public string employee_designation { get; set; }
        public int designation_level { get; set; }
        public int sequence { get; set; }
        public int note_onucched_id { get; set; }
        public string note_onucched_decision { get; set; }
        public int is_signature { get; set; }
        public int cross_signature { get; set; }
        public string signature_date { get; set; }
        public int digital_sign { get; set; }
        public int can_delete { get; set; }
        public int user_signature_id { get; set; }
        public int is_hidden_signature { get; set; }
        public string position { get; set; }
        public string encode_sign { get; set; }
    }
}

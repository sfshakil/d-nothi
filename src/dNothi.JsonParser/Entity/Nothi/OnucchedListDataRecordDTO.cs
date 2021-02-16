using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class OnucchedListDataRecordDTO
    {
        public int id { get; set; }
        public string note_onucched_status { get; set; }
        public string created { get; set; }
        public int onucched_sequence { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int office_unit_organogram_id { get; set; }
        public int employee_id { get; set; }
        public string office_name { get; set; }
        public string office_unit_name { get; set; }
        public string employee_name { get; set; }
        public string designation_name { get; set; }
        public string onucched_no { get; set; }
        public string sequence_onucched_ids { get; set; }
        public OnucchedListDataRecordPotroDTO potro { get; set; }
        public int attachment_count { get; set; }
    }
}

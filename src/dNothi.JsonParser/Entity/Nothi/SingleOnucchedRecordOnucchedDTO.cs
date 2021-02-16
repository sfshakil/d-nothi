using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class SingleOnucchedRecordOnucchedDTO
    {
        public int id { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int office_unit_organogram_id { get; set; }
        public int employee_id { get; set; }
        public string office_name { get; set; }
        public string office_unit_name { get; set; }
        public string employee_name { get; set; }
        public string designation_name { get; set; }
        public string onucched_no { get; set; }
        public string subject { get; set; }
        public string note_description { get; set; }
        public string note_onucched_status { get; set; }
        public int potrojari { get; set; }
        public int decision_id { get; set; }
        public string meta_data { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
    }
}

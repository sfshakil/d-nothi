using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiOutboxDTO
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
        public string last_note_date { get; set; }
    }
}

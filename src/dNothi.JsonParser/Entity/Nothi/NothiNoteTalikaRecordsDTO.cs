using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiNoteTalikaRecordsDTO
    {
        public int id { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string office_designation_name { get; set; }
        public int nothi_type_id { get; set; }
        public string nothi_no { get; set; }
        public string subject { get; set; }
        public string nothi_created_date { get; set; }
        public string description { get; set; }
        public int nothi_class { get; set; }
        public int is_active { get; set; }
        public int is_deleted { get; set; }
        public int is_archived { get; set; }
        public string archived_date { get; set; }
        public string archived_organogram_id { get; set; }
        public string archived_designation_name { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public int permitted { get; set; }
    }
}

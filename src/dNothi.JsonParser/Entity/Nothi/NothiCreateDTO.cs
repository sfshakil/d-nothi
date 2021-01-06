using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiCreateDTO
    {
        public int office_id { get; set; }
        public string designation_id { get; set; }
        public string model { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string office_designation_name { get; set; }
        public int nothi_type_id { get; set; }
        public string nothi_no { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public int nothi_class { get; set; }
        public string nothi_created_date { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public string modified { get; set; }
        public string created { get; set; }
        public int id { get; set; }
    }
}

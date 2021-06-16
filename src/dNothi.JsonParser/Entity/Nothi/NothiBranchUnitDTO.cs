using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiBranchUnitDTO
    {
        public int office_origin_unit_id { get; set; }
        public string unit_name_bng { get; set; }
        public string unit_name_eng { get; set; }
        public string office_unit_category { get; set; }
        public int parent_unit_id { get; set; }
        public string unit_nothi_code { get; set; }
        public int unit_level { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public int office_unit_id { get; set; }
    }
}

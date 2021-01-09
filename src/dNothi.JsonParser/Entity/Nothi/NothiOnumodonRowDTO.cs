using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiOnumodonRowDTO
    {
        public string id { get; set; }
        public string office_id { get; set; }
        public string office_unit_id { get; set; }

        public string designation_id { get; set; }
        public string officer_id { get; set; }
        public string designation_level { get; set; }
        public string is_strict_route { get; set; }
        public string is_signatory { get; set; }
        public string max_transaction_day { get; set; }
        public string layer_index { get; set; }
        public string route_index { get; set; }

        public string name { get; set; }
        public string designation { get; set; }
        public string level { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class ToOutboxDTO
    {
        public int office_id { get; set; }
        public string office { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit { get; set; }
        public int designation_id { get; set; }
        public string designation { get; set; }
        public int officer_id { get; set; }
        public string officer { get; set; }
        public int view_status { get; set; }
        public string issue_date { get; set; }
        public int priority { get; set; }
    }
}

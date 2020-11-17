using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class DeskAllDTO
    {
        public int nothi_master_id { get; set; }
        public string issue_date { get; set; }
        public int note_count { get; set; }
        public string note_current_status { get; set; }
        public int priority { get; set; }
    }
}

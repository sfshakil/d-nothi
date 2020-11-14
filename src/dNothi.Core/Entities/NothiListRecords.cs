using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NothiListRecords : BaseEntity
    {
        public int office_id { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public int office_unit_organogram_id { get; set; }
        public string office_designation_name { get; set; }
        public string nothi_no { get; set; }
        public string subject { get; set; }
        public int nothi_class { get; set; }
        public string note_current_status { get; set; }
        public string priority { get; set; }
        public int note_count { get; set; }
        public string issue_date { get; set; }
        public string last_note_date { get; set; }
    }
}

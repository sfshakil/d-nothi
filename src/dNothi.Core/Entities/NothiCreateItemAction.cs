using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NothiCreateItemAction : BaseEntity
    {
        public  string officer_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
        public string office_label { get; set; }
        public string officer { get { return officer_name; } }

        public int designation_id { get; set; }
        public string designation { get; set; }
        public string nothishkha { get; set; }
        public string nothi_no { get; set; }
        public string nothi_type_id { get; set; }
        public string nothi_subject { get; set; }
        public string nothi_class { get; set; }
        public string currentYear { get; set; }
        public int office_id { get; set; }
        public long nothi_id { get; set; }
    }
}

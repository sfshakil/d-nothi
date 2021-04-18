using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NoteSaveItemAction : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public string officer_name { get; set; }
        public string office_name { get; set; }
        public long nothi_id { get; set ; }
        public long local_nothi_id { get; set; }
        public string office_unit_name { get; set; }
        public string office_designation_name { get; set; }
        public string noteSubject { get; set; }
        public string nothi_type { get; set; }

    }
}

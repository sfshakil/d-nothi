using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakBoxSharedToOfficer : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public int? assignor_designation_id { get; set; }
        public int? assignee_designation_id { get; set; }

        [MaxLength]
        public string officer_details_Json { get; set; }
    }
}

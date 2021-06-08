using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakBoxSharing : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public int assignee_designation_id { get; set; }

        [MaxLength]
        public string assignor { get; set; }
        [MaxLength]
        public string assignee { get; set; }
        public bool IsLocal { get; set; }
        public bool IsEnable { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime EntryDate { get; set; }
    }
}

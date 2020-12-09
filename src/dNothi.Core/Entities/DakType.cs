using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
  public class DakType: BaseEntity
    {

        public virtual ICollection<DakList> dakLists { get; set; }
        public int total_records { get; set; }

        public bool is_inbox { get; set; }
        public bool is_outbox { get; set; }
        public bool is_archived { get; set; }
        public bool is_sorted { get; set; }
        public bool is_nothijato { get; set; }
        public bool is_nothivukto { get; set; }
    }
}

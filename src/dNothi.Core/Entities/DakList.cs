using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
  public class DakList: BaseEntity
    {

        public virtual ICollection<DakListDakListRecord> records { get; set; }
        public int total_records { get; set; }
    }
}

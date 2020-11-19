using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakListDakListRecord: BaseEntity
    {
        public long dakListRecordId { get; set; }
        
        public long dakListId { get; set; }
    }
}

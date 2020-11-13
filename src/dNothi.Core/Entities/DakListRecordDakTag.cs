using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class DakListRecordDakTag : BaseEntity
    {
        public long DakListRecordId { get; set; }
        public long DakTagId { get; set; }
    }
}

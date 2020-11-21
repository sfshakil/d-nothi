using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class MovementStatusTo : BaseEntity
    {
        public long MovStatusId { get; set; }
        public long ToId { get; set; }
    }
}

using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class MovementStatus:BaseEntity
    {
        [ForeignKey("from")]
        public long from_id { get; set; }

        [ForeignKey("other")]
        public long other_id { get; set; }

        public virtual From from { get; set; }
        public virtual Other other { get; set; }
        public virtual ICollection<MovementStatusTo> to { get; set; }
    }
}

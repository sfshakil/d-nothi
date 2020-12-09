using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class To : BaseEntity
    {

       
        public string attention_type { get; set; }

        [ForeignKey("to")]
        public long to_id { get; set; }
        public virtual Officer to { get; set; }

        [ForeignKey("movement_status")]
        public long movement_status_id { get; set; }
        public virtual MovementStatus  movement_status { get; set; }


    }
}

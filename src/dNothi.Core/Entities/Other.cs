using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class Other : BaseEntity
    {
        public string operation_type { get; set; }
        public string last_movement_date { get; set; }
        public int dak_priority { get; set; }
        public string dak_security_level { get; set; }
        public int sequence { get; set; }
        public string dak_actions { get; set; }
        public int docketing_no { get; set; }
        public string otherId { get; set; }
    }
}

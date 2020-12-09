using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
  public class Officer : BaseEntity
    {
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public int designation_id { get; set; }
        public int officer_id { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public string officer { get; set; }

        public virtual ICollection<To> Tos { get; set; }


    }
}

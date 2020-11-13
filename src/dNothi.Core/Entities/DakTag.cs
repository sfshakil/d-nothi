using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakTag: BaseEntity
    {
        
        public int dak_custom_label_id { get; set; }
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public string tag { get; set; }
        public virtual ICollection<DakListRecordDakTag> DakListRecordDakTags { get; set; }
    }
}

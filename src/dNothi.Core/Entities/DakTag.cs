using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakTag: BaseEntity
    {
        public int dak_tag_id { get; set; }
        public int dak_custom_label_id { get; set; }
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public string tag { get; set; }

     
        
        [ForeignKey("dak_list")]
        public long dak_list_id { get; set; }
        public virtual DakList dak_list { get; set; }
    }
}

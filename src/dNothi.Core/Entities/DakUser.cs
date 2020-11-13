using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakUser : BaseEntity
    {
        
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public string dak_origin { get; set; }
        public int from_potrojari { get; set; }
        public string dak_view_status { get; set; }
        public string attention_type { get; set; }
        public string dak_priority { get; set; }
        public string dak_security { get; set; }
        public int dak_movement_sequence { get; set; }
        public string last_movement_date { get; set; }
        public string dak_category { get; set; }
        public string dak_subject { get; set; }
        public string dak_decision { get; set; }
        public string drafted_decisions { get; set; }
    }
}

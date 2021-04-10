using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakItemAction : BaseEntity
    {


        public bool isForwarded { get; set; }
       
        public bool isNothijato { get; set; }
        public bool isArchived { get; set; }
        public bool isNothivukto { get; set; }
       
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        

        [MaxLength]
        public string dak_Action_Json { get; set; }

    }
}

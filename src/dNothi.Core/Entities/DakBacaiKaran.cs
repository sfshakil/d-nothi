using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakBacaiKaran : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public int dak_inbox_designation_id { get; set; }

        public byte is_copied_dak { get; set; } 
        public int dak_id { get; set; } 
        public string dak_type { get; set; }

        [MaxLength]
        public string dakInfoJson { get; set; }
       
       

        public bool IsLocal { get; set; }
        public bool IsEnable { get; set; }
        public bool IsSubmitted { get; set; }

    }
}

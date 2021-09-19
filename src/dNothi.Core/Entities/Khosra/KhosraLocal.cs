using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class KhosraLocal : BaseEntity
    {
        public string cdesk { get; set; }
        [MaxLength]
        public string potro { get; set; }
        public int kosra_type { get; set; }
        public int page { get; set; }
        public string EntryDate { get; set; }
        public bool isLocal { get; set; }
    }
}

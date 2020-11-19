using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class Log : BaseEntity
    {
        
        public DateTime Date { get; set; }
        [StringLength(255)]
        public string Thread { get; set; }
        [StringLength(50)]
        public string Level { get; set; }
        [StringLength(255)]
        public string Logger { get; set; }
        [StringLength(4000)]
        public string Message { get; set; }
        [StringLength(2000)]
        public string Exception { get; set; }
    }
}

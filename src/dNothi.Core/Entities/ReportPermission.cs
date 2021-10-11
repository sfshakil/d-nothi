using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class ReportPermission : BaseEntity
    {
        public string type { get; set; }
        public string user { get; set; }
        public bool isAdd { get; set; }
        [MaxLength]
        public string responseJson { get; set; }

    }
}

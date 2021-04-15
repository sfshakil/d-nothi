using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class LocalOfficeList : BaseEntity
    {
        public int designationId { get; set; }
        public int officeId { get; set; }

        [MaxLength]
        public string jsonResponse { get; set; }
    }
}

using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class PotroTemplateList : BaseEntity
    {
        [MaxLength]
        public string jsonResponse { get; set; }
        public int _officeId { get; set; }
        public int _designationId { get; set; }
    }
}

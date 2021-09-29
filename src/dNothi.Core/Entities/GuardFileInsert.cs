using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class GuardFileInsert : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public string model { get; set; }
        public bool isCreated { get; set; }
        public bool isGuardFile { get; set; }
        public int  GuardFileId { get; set; }
        public bool isInProblem { get; set; }
        [MaxLength]
        public string data { get; set; }
     
    }
}

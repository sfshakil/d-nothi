using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities.Khosra
{
   public class PermittedPotroLocal : BaseEntity
    {
        public string cdesk { get; set; }
        [MaxLength]
        public string responseData { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public bool isLocal { get; set; }
    }
}

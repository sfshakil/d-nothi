using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities.Khosra
{
   public class SarokNoLocal : BaseEntity
    {
        public string cdesk { get; set; }
        public string potro { get; set; }
        public long  khosraId { get; set; }
        [MaxLength]
        public string responseData { get; set; }
       
    }
}

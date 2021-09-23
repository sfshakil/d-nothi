using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities.Khosra
{
   public class kosraAnumodanLocal : BaseEntity
    {
        public string cdesk { get; set; }
        public string potro { get; set; }
        public int potrojari_id { get; set; }
        public string potro_status { get; set; }
        [MaxLength]
        public string responseData { get; set; }
       
    }
}

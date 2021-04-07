using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NothiOnumodonItem : BaseEntity
    {
        public long nothi_id { get; set; }


        [MaxLength]
        public string jsonResponse { get; set; }


        public int office_unit_id { get; set; }
        public int designation_id { get; set; }
        public int office_id { get; set; }
    }
}

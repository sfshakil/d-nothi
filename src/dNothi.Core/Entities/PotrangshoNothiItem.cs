using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class PotrangshoNothiItem : BaseEntity
    {


        public long nothi_id { get; set; }

        [MaxLength]
        public string khoshrajsonResponse { get; set; }
        [MaxLength]
        public string khoshrawaitingjsonResponse { get; set; }
        [MaxLength]
        public string allpotrojsonResponse { get; set; }
        [MaxLength]
        public string potrojarijsonResponse { get; set; }
        [MaxLength]
        public string nothijatojsonResponse { get; set; }

        public int designation_id { get; set; }
        public int office_id { get; set; }
    }
}

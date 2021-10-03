using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class DakRegisterBook : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int unitId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public bool isDakGrahan { get; set; }
        public bool isDakBili { get; set; }
        public bool isShakaDiary { get; set; }

        [MaxLength]
        public string daklist_json { get; set; }

        public bool IsEnable { get; set; }
     

    }
}

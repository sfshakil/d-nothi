using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NothiNoteTalikaItem : BaseEntity
    {


        public string nothi_type_id { get; set; }

        [MaxLength]
        public string jsonResponse { get; set; }
        
        [MaxLength]
        public string nothiGenerateJsonResponse { get; set; }
        public int designation_id { get; set; }
        public int office_id { get; set; }
    }
}

using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
   public class GuardFileList : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public bool isGuardFileCategory { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int guard_file_category_id { get; set; }
        public string search_params { get; set; }

        [MaxLength]
        public string responseData { get; set; }
     
    }
}

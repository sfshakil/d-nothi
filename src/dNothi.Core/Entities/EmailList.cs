using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class EmailList : BaseEntity
    {

        public bool is_prerito_email { get; set; }

        public int designation_id { get; set; }
        public int office_id { get; set; }
        public int page { get; set; }
        public int length { get; set; }
        public string date_range { get; set; }
        public string action_type { get; set; }

        
        [MaxLength]
        public string email_list_response { get; set; }



    }
}

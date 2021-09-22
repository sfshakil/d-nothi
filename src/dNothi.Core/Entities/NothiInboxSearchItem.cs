using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NothiInboxSearchItem : BaseEntity
    {
        public bool is_nothi_inbox { get; set; }
        public bool is_nothi_outbox { get; set; }
        public bool is_nothi_all { get; set; }
        public string Search_param { get; set; }

        [MaxLength]
        public string json_response_inbox { get; set; }
        public string json_response_outbox { get; set; }
        public string json_response_all { get; set; }

        public int designation_id { get; set; }
        public int office_id { get; set; }
    }
}

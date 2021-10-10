using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NothiItem : BaseEntity
    {
        public bool is_nothi_inbox { get; set; }
        public bool is_nothi_outbox { get; set; }
        public bool is_nothi_all { get; set; }

        [MaxLength]
        public string jsonResponse { get; set; }

        public int designation_id { get; set; }
        public int office_id { get; set; }
        public int page { get; set; }
    }
}

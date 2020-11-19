using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class DakInbox : BaseEntity
    {
        [ForeignKey("data")]
        public long dak_list_record_id { get; set; }

        public string status { get; set; }

        public virtual DakList data { get; set; }
    }
}

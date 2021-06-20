using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NoteSendItemAction : BaseEntity
    {
        public int office_id { get; set; }
        public int designation_id { get; set; }
        public int note_id { get; set; }
        public string note_no { get; set; }
        public string local_nothi_type { get; set; }
        public string note_subject { get; set; }
        public string office_unit_name { get; set; }
        public string nothi_no { get; set; }
        public string office_name { get; set; }
        public long nothi_id { get; set; }


        public int nothi_office { get; set; }
        public string office { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public int officer_id { get; set; }
        public string officer { get; set; }
        public int designation_level { get; set; }

        [MaxLength]
        public string dakUserParamJson { get; set; }

    }
}

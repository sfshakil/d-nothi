using dNothi.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Core.Entities
{
    public class NothiNotePermissionItem : BaseEntity
    {

        [MaxLength]
        public string json_user_param { get; set; }
        [MaxLength]
        public string json_nothiOnumodonRows { get; set; }
        [MaxLength]
        public string json_nothiListRecordsDTO { get; set; }
        public string note_Id { get; set; }
        public int noteOrNothi { get; set; }//0 means nothi, 1 means note { get; set; }
        public int designation_id { get; set; }
        public int other_office_id { get; set; }
        public int office_id { get; set; }
    }
}

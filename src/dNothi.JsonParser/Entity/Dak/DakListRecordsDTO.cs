using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak_List_Inbox
{
    public class DakListRecordsDTO
    {
        public DakUserDTO dak_user { get; set; }
        public DakOriginDTO dak_origin { get; set; }
        public MovementStatusDTO movement_status { get; set; }
        public List<DakTagDTO> dak_Tags { get; set; }
        public int attachment_count { get; set; }
        public NothiDTO nothi { get; set; }
    }
}

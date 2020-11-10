using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.JsonParser.Entity.Dak_List_Inbox
{
    public class DakLISTInboxDTO
    {
        public List<DakListInboxRecordsDTO> records { get; set; }
        public int total_records { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak_List_Inbox
{
    public class DakListDTO
    {
        public List<DakListRecordsDTO> records { get; set; }
        public int total_records { get; set; }
    }
}

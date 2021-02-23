using dNothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
    public class DakListWithDetailsResponse
    {
        public string status { get; set; }
        public DakListWithDetailsDataDTO data { get; set; }
    }

   
    public class DakListWithDetailsRecordDTO
    {
        public DakUserDTO dak_user { get; set; }
        public DakOriginDTO dak_origin { get; set; }
        public MovementStatusDTO movement_status { get; set; }
        public List<DakTagDTO> dak_Tags { get; set; }
        public int attachment_count { get; set; }
        public NothiDTO nothi { get; set; }
        public List<DakAttachmentDTO> attachment { get; set; }
        public string s_hash { get; set; }
        public object Status { get; set; }
    }

    public class DakListWithDetailsDataDTO
    {
        public List<DakListWithDetailsRecordDTO> records { get; set; }
        public int total_records { get; set; }
    }

  
}

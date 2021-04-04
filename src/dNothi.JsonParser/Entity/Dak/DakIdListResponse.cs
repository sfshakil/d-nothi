using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public  class DakIdListResponse
    {
        public string status { get; set; }
        public DakIdListDataDTO data { get; set; }
    }

    public class DakIdListRecordDTO
    {
        public long dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public int page { get; set; }
        public string dak_category { get; set; }
        public string dak_hash { get; set; }
    }

    public class DakIdListDataDTO
    {
        public List<DakIdListRecordDTO> records { get; set; }
        public int total_records { get; set; }
    }

    
}

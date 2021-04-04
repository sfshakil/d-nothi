using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
  public  class DakItemDTO
    {

        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public string dak_category { get; set; }
        public string dak_hash { get; set; }
        public int page { get; set; }
    }
}

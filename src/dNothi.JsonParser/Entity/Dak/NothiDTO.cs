using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.JsonParser.Entity.Dak_List_Inbox
{
    public class NothiDTO
    {
        public int nothi_master_id { get; set; }
        public int nothi_note_id { get; set; }
        public int nothi_potro_id { get; set; }
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
      
        public int id { get; set; }
        public string nothi_no { get; set; }
        public string subject { get; set; }
        public int office_id { get; set; }
        public string office_name { get; set; }
        public int office_unit_id { get; set; }
        public string office_unit_name { get; set; }
    }
}

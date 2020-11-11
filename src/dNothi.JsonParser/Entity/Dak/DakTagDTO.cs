using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.JsonParser.Entity.Dak_List_Inbox
{
    public class DakTagDTO
    {
        public int id { get; set; }
        public int dak_custom_label_id { get; set; }
        public int dak_id { get; set; }
        public string dak_type { get; set; }
        public int is_copied_dak { get; set; }
        public string tag { get; set; }
    }
}

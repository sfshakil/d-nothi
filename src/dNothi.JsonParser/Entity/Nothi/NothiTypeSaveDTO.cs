using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiTypeSaveDTO
    {
        public int id { get; set; }
        public string type_name { get; set; }
        public string type_code { get; set; }
        public int type_last_number { get; set; }
        public int office_id { get; set; }
        public int office_unit_id { get; set; }
        public bool is_deleted { get; set; }
        public string created { get; set; }
        public string modified { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public string designation_id { get; set; }
        public string model { get; set; }
    }
}

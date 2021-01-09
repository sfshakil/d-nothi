using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class DakNothivuktoNoteAddParam
    {
        public int nothi_master_id { get; set; }
        public string note_subject { get; set; }
        public int office_id { get; set; }
        public string office_name { get; set; }
        public string office_unit_name { get; set; }
        public string office_designation_name { get; set; }
        public string officer_name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity
{
   public class LocalOfficesResponse
    {
        public int division { get; set; }
        public int origin { get; set; }
        public int district { get; set; }
        public string nameBn { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int upazila { get; set; }
        public int ministry { get; set; }
        public int layer { get; set; }
    }
}

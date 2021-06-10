using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiBranchListDTO
    {
        public int office_id { get; set; }
        public int office_layer_id { get; set; }
        public int office_ministry_id { get; set; }
        public List<NothiBranchUnitDTO> units { get; set; }
    }
}

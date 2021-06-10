using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Nothi
{
    public class NothiBranchListResponse
    {
        public string status { get; set; }
        public List<NothiBranchListDTO> data { get; set; }
    }
}

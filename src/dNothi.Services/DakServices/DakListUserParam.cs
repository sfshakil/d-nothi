using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
    public class DakListUserParam
    {
        public string token { get; set; }
        public int designationId { get; set; }
        public int officeId { get; set; }
        public string api { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
}

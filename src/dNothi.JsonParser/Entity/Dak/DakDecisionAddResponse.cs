using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class DakDecisionAddResponse
    {
        public string status { get; set; }
        //public Dictionary<int, string> data { get; set; }
    }

    public class DakDecisionDeleteResponse
    {
        public string status { get; set; }
        public object data { get; set; }
    }
    public class DakDecisionSetupResponse
    {
        public string status { get; set; }
        public DakDecisionDTO data { get; set; }
    }
}

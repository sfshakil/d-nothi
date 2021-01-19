using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
   public class DakNothijatoResponse
    {
        public string status { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }
    public class DakNothijatoRevertResponse
    {
        public string status { get; set; }
        public string data { get; set; }
    }
    public class NothijatoActionParam
    {

        public string nothi_id { get; set; }
        public string nothi_no { get; set; }
        public string office_unit { get; set; }
        public string nothi_office { get; set; }
    }


}

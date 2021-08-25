using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity
{
    public class PasswordChangeResponse
    {
        public string status { get; set; }
        public string message { get; set; }
       
        public string data { get; set; }
    }

    public class DoptorImageResponse
    {
        public string status { get; set; }
   

        public List<DoptorImagedata> data { get; set; }
    }

    public class DoptorImagedata
    {
        public string username { get; set; }
        public string employee_record_id { get; set; }
        public string image { get; set; }
        public string signature { get; set; }
    }
}

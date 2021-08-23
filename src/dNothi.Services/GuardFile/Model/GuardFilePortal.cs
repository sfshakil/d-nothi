using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.GuardFile.Model
{
   public class GuardFilePortal
    {
        public class Record
        {
            public int id { get; set; }
            public int layer_id { get; set; }
            public string type { get; set; }
            public string subdomain { get; set; }
            public string name { get; set; }
            public string link { get; set; }
            public string created { get; set; }
        }

        public class Data
        {
            public List<Record> records { get; set; }
            public int total_records { get; set; }
        }

            public string status { get; set; }
            public Data data { get; set; }
            public List<object> options { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.GuardFile.Model
{
   public class GuardFileOffice
    {
        public class Datum
        {
            public int id { get; set; }
            public int layer_id { get; set; }
            public string type { get; set; }
        }

       
            public string status { get; set; }
            public List<Datum> data { get; set; }
            public List<object> options { get; set; }
        
    }
}

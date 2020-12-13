using Newtonsoft.Json;
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
        public string designation_label { get; set; }
        public string unit_label { get; set; }
        public string office_label { get; set; }
        public string officer_name { get; set; }
        public string incharge_label { get; set; }

        public int employee_record_id { get; set; }


        public int designation_id { get; set; }
        public int unit_id { get; set; }
     
      
        public int office_id { get; set; }
        public string api { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
}

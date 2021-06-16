using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices.DakSharingService.Model
{
   public class ShareList
    {
        public class Assignor
        {
            public int office_id { get; set; }
            public string office_name { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_name { get; set; }
            public int designation_id { get; set; }
            public string designation_level { get; set; }
            public string name { get; set; }
            public int id { get; set; }
        }

        public class Assignee
        {
            public int office_id { get; set; }
            public string office_name { get; set; }
            public int office_unit_id { get; set; }
            public string office_unit_name { get; set; }
            public int designation_id { get; set; }
            public string designation_level { get; set; }
            public string name { get; set; }
        }

        public class Data
        {
            public List<Assignor> assignor { get; set; }
            public List<Assignee> assignee { get; set; }
        }
        public class CheckData
        {
            public List<object> list { get; set; }
        }
        public string status { get; set; }
        public Data data { get; set; }
       

    }
}

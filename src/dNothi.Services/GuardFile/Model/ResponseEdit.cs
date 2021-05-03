using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.GuardFile.Model
{
   public class ResponseEdit
    {
        public class Data
        {
            public int id { get; set; }
            public string name_bng { get; set; }
            public int parent_id { get; set; }
            public int office_id { get; set; }
            public int office_unit_id { get; set; }
            public int office_unit_organogram_id { get; set; }
            public int created_by { get; set; }
            public int modified_by { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
            public string designation_id { get; set; }
            public string model { get; set; }
        }

        
            public string status { get; set; }
            public Data data { get; set; }
            public int id { get; set; }
            public string message { get; set; }
        

    }
}

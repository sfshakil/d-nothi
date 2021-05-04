using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.GuardFile.Model
{
   public class GuardFileCategory
    {
        public class Record
        {
            public int id { get; set; }
            public string name_bng { get; set; }
            public int parent_id { get; set; }
            public int office_id { get; set; }
            public int office_unit_id { get; set; }
            public int office_unit_organogram_id { get; set; }
            public string created { get; set; }
            public string guard_file_type_count { get; set; }
        }

        public class Data
        {
            public List<Record> records { get; set; }
            public int total_records { get; set; }
        }

      
            public string status { get; set; }
            public Data data { get; set; }
        


    }
}

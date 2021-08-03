using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.BasicService.Models
{
   public class OfficeUnit
    {
        public class Employee
        {
            public string name_eng { get; set; }
            public string name_bng { get; set; }
            public int employee_record_id { get; set; }
            public string incharge_label { get; set; }
        }

        public class Designation
        {
            public int designation_id { get; set; }
            public string designation_eng { get; set; }
            public string designation_bng { get; set; }
            public int designation_level { get; set; }
            public int designation_sequence { get; set; }
            public Employee employee { get; set; }
            public int selected { get; set; }
        }

        public class Basic
        {
            public int unit_id { get; set; }
            public string unit_name_bng { get; set; }
            public string unit_name_eng { get; set; }
            public List<Designation> designation { get; set; }
        }

       
            public string status { get; set; }
            public List<Basic> data { get; set; }
            public List<object> options { get; set; }
        

    }
}

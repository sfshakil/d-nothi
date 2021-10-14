using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity
{
  

    

    public class EmployeDakNothiCountResponseTotal
    {
        public int dak { get; set; }
        public int dak_draft { get; set; }

        public int own_office_nothi { get; set; }
        public int other_office_nothi { get; set; }
    }

    public class EmployeDakNothiCountResponseData
    {
        public Dictionary<string, EmployeDakNothiCountResponseTotal> designation { get; set; }
        public EmployeDakNothiCountResponseTotal total { get; set; }
    }

    public class EmployeDakNothiCountResponse
    {
        public string status { get; set; }
        public EmployeDakNothiCountResponseData data { get; set; }
    }
}

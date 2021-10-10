using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.ReportPermited.Model
{
   public class ReportPermissionModel
    {
        public class User
        {
            public int id { get; set; }
            public string username { get; set; }
            public int status { get; set; }
            public string created { get; set; }
            public string modified { get; set; }
            public string type { get; set; }
            public string user { get; set; }
           
            public int created_by { get; set; }
            public int modified_by { get; set; }
           
            public string device_type { get; set; }
            public int device_id { get; set; }
           
        }

        public string status { get; set; }
        public object data { get; set; }
        public int id { get; set; }
        public string message { get; set; }
        public List<object> options { get; set; }

        // public List<User> data { get; set; }
        // public User data { get; set; }

    }
}

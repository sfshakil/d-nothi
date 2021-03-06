using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
  public  class DakFolderAddResponse
    {
            public string status { get; set; }
            public DakFolderAddDataDTO data { get; set; }
        
    }
    public class DakFolderDeleteResponse
    {
        public string status { get; set; }
        public string message { get; set; }

    }

    public class DakFolderAddDataDTO
    {
        public int id { get; set; }
    }
}

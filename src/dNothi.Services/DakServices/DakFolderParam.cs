using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
  public class DakFolderParam
    {
        public int open_for_all { get; set; }
        public string module_type { get; set; }


        public string custom_name { get; set; }
        public int parent_id { get; set; }
        public int id { get; set; }

       public DakFolderParam()
        {
            module_type = "Daak";
        }
    }

   

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.JsonParser.Entity.Dak
{
  public  class DakMovementStatusResponse
    {
        public string status { get; set; }

        public DakMovementStatusListDTO data { get; set; }
    }
}

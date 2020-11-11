using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothi.JsonParser.Entity.Dak_List_Inbox
{
  public  class MovementStatusDTO
    {
        public OtherDTO other { get; set; }
        public FromDTO from { get; set; }
        public List<ToDTO> to { get; set; }
    }
}
